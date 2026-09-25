Imports System.Drawing.Printing
Imports System.Globalization ' Necesario para el manejo seguro de decimales
Imports MySql.Data.MySqlClient
Imports ZXing

Public Class ucUbicacionPallets
    Inherits System.Windows.Forms.UserControl

    Private LoteTerminado As New List(Of Dictionary(Of String, String))
    Private dtUbicaciones As DataTable

    Public Event LoteGuardadoExitosamente()

    Private Sub ucUbicacionPallets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarUbicaciones()
            ConfigurarGridResumen()
        End If
    End Sub

    ' 1. Llenamos el ComboBox con las ubicaciones y su DISPONIBILIDAD
    Private Sub CargarUbicaciones()
        Try
            ' Ajustamos la consulta para calcular la ocupación basada en los Pallets
            Dim sql As String =
                "SELECT u.id, CONCAT(u.nombre, ' (Disp: ', (u.capacidad - IFNULL(p.Ocupados, 0)), ')') AS DisplayName " &
                "FROM tipos_ubicaciones u " &
                "LEFT JOIN (" &
                "   SELECT tipos_ubicaciones_id, COUNT(id) as Ocupados " &
                "   FROM pallets " &
                "   WHERE estados_contenedores_id = 2 " & ' Ajustado al nombre común de estado
                "   GROUP BY tipos_ubicaciones_id" &
                ") p ON u.id = p.tipos_ubicaciones_id " &
                "WHERE u.estado = 1 AND u.id <> 1"

            dtUbicaciones = ObtenerDatos(sql) ' Utiliza tu función global

            If dtUbicaciones IsNot Nothing AndAlso dtUbicaciones.Rows.Count > 0 Then
                cmbUbicacionGeneral.DataSource = dtUbicaciones
                cmbUbicacionGeneral.DisplayMember = "DisplayName"
                cmbUbicacionGeneral.ValueMember = "id"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar ubicaciones: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. Configuramos la grilla para permitir elección individual
    Private Sub ConfigurarGridResumen()
        dgvResumen.Columns.Clear()

        dgvResumen.Columns.Add("ID_PALLET", "N° Pallet")
        dgvResumen.Columns.Add("Bruto", "Kilos Brutos")
        dgvResumen.Columns.Add("Neto", "Kilos Netos")
        dgvResumen.Columns.Add("Tara", "Tara Compuesta")

        ' Columna ComboBox para elegir cámara de destino
        Dim colUbicacion As New DataGridViewComboBoxColumn()
        colUbicacion.Name = "colUbicacion"
        colUbicacion.HeaderText = "Cámara Destino"
        If dtUbicaciones IsNot Nothing Then
            colUbicacion.DataSource = dtUbicaciones.Copy()
            colUbicacion.DisplayMember = "DisplayName"
            colUbicacion.ValueMember = "id"
        End If
        dgvResumen.Columns.Add(colUbicacion)

        dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvResumen.AllowUserToAddRows = False
        dgvResumen.ReadOnly = False

        ' Bloqueamos la edición de los datos de pesaje y alineamos números a la derecha
        Dim columnasNumericas As String() = {"Bruto", "Neto", "Tara"}
        For Each nombreCol In columnasNumericas
            dgvResumen.Columns(nombreCol).ReadOnly = True
            dgvResumen.Columns(nombreCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        dgvResumen.Columns("ID_PALLET").ReadOnly = True
        dgvResumen.Columns("ID_PALLET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' 3. Inyectar la lista de pesajes desde ucPesajePallets
    Public Sub RecibirDatosParaGuardar(datosLote As List(Of Dictionary(Of String, String)))
        LoteTerminado = datosLote
        dgvResumen.Rows.Clear()

        For Each item In LoteTerminado
            dgvResumen.Rows.Add(item("ID_PALLET"), item("Bruto"), item("Neto"), item("TaraTotal"))
        Next
    End Sub

    ' Aplica la cámara general a todos los pallets de la grilla
    Private Sub btnAplicarATodos_Click(sender As Object, e As EventArgs) Handles btnAplicarATodos.Click
        If cmbUbicacionGeneral.SelectedValue Is Nothing Then Return

        Dim idSeleccionado = cmbUbicacionGeneral.SelectedValue

        For Each row As DataGridViewRow In dgvResumen.Rows
            row.Cells("colUbicacion").Value = idSeleccionado
        Next
    End Sub

    ' 4. Guardado transaccional en tabla pallets y pallets_historial
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validación de destinos
        For Each row As DataGridViewRow In dgvResumen.Rows
            If row.Cells("colUbicacion").Value Is Nothing OrElse IsDBNull(row.Cells("colUbicacion").Value) Then
                MessageBox.Show("El Pallet N° " & row.Cells("ID_PALLET").Value.ToString() & " no tiene una cámara asignada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim idUsuario As Integer = 1 ' Reemplazar por tu variable de sesión global

        ' Consulta SQL combinada (Multiple statements)
        Dim sqlQuery As String =
            "UPDATE pallets SET " &
            "   kilos_brutos = @bruto, " &
            "   kilos_netos = @neto, " &
            "   tipos_ubicaciones_id = @ubicacionId, " &
            "   estados_contenedores_id = CASE " &
            "       WHEN @ubicacionId IN(5,6) THEN 6 " & _ ' Si es la ubicación 5,6 Camaras frio 6
            "       WHEN @ubicacionId IN(7,8,9) THEN 14 " & _ ' Si es la ubicación 7,8,9, asigna Camaras Maduración 14
            "       ELSE estados_contenedores_id " & _        ' Si no cumple ninguna, se queda con su valor actual
            "   END, " &
            "   estados_progresos_pallets_id = 2, " &
            " fecha_registro = NOW() " &
            "WHERE id = @id; " &
            "INSERT INTO pallets_historial (" &
            "   tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, " &
            "   tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, " &
            "   fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id,users_id, estado" &
            ") " &
            "SELECT 4, procesos_paletizado_id, id, tipos_contenedores_id, " &
            "   4, @neto, @bruto, numero_cajas, capacidad, " &  ' Usamos los parámetros aquí también por seguridad
            "   NOW(), 10, estados_progresos_pallets_id,@userId, estado " &  ' asignación de estado 10 (Asignación kilos Pallet) para el historial
            "FROM pallets WHERE id = @id; " &
            "INSERT INTO pallets_historial (" &
            "   tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, " &
            "   tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, " &
            "   fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id,users_id, estado" &
            ") " &
            "SELECT 2, procesos_paletizado_id, id, tipos_contenedores_id, " &
            "   @ubicacionId, @neto, @bruto, numero_cajas, capacidad, " &
            "   NOW(), estados_contenedores_id, estados_progresos_pallets_id,@userId, estado " &
            "FROM pallets WHERE id = @id;"

        Dim transaccion As MySqlTransaction = Nothing

        Try
            ConexionBD.Abrir()
            transaccion = ConexionBD.conexion.BeginTransaction()

            Using cmd As New MySqlCommand(sqlQuery, ConexionBD.conexion, transaccion)
                cmd.Parameters.Add("@bruto", MySqlDbType.Double)
                cmd.Parameters.Add("@neto", MySqlDbType.Double)
                cmd.Parameters.Add("@ubicacionId", MySqlDbType.Int32)
                cmd.Parameters.Add("@userId", MySqlDbType.Int32)
                cmd.Parameters.Add("@id", MySqlDbType.Int32)

                ' ESTILO SEGURO: Convertimos usando InvariantCulture para ignorar problemas de comas/puntos en el sistema
                For Each row As DataGridViewRow In dgvResumen.Rows
                    Dim valBruto As String = row.Cells("Bruto").Value.ToString()
                    Dim valNeto As String = row.Cells("Neto").Value.ToString()

                    cmd.Parameters("@bruto").Value = Double.Parse(valBruto)  ', CultureInfo.InvariantCulture
                    cmd.Parameters("@neto").Value = Double.Parse(valNeto)    ', CultureInfo.InvariantCulture
                    cmd.Parameters("@ubicacionId").Value = Convert.ToInt32(row.Cells("colUbicacion").Value)
                    cmd.Parameters("@userId").Value = idUsuario
                    cmd.Parameters("@id").Value = Convert.ToInt32(row.Cells("ID_PALLET").Value)

                    cmd.ExecuteNonQuery()
                Next
            End Using

            transaccion.Commit()

            ' =========================================================================
            ' IMPRESIÓN AUTOMÁTICA DE TICKETS
            ' =========================================================================
            For Each row As DataGridViewRow In dgvResumen.Rows
                If Not row.IsNewRow Then
                    Dim idPallet As Integer = Convert.ToInt32(row.Cells("ID_PALLET").Value)

                    ' Consultamos las 2 Querys
                    Dim rowPallet As DataRow = ObtenerDatosPallet(idPallet)
                    Dim dtCajas As DataTable = ObtenerDetallesCajas(idPallet)

                    If rowPallet IsNot Nothing Then
                        ' Tomamos la ubicación devuelta directamente por tu Query 1
                        Dim nombreUbicacion As String = rowPallet("ubicacion").ToString()

                        Dim pd As New PrintDocument()
                        pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
                        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                        AddHandler pd.PrintPage, Sub(s, ev)
                                                     DisenoTicketPallet100x200(ev, rowPallet, dtCajas, nombreUbicacion)
                                                 End Sub
                        Try
                            pd.Print()
                        Catch exPrint As Exception
                            MessageBox.Show("Error al imprimir ticket del Pallet N° " & idPallet & ": " & exPrint.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End If
                End If
            Next
            ' =========================================================================


            MessageBox.Show("Los pallets fueron pesados y ubicados correctamente.", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)



            CargarUbicaciones()
            RaiseEvent LoteGuardadoExitosamente()

        Catch ex As Exception
            If transaccion IsNot Nothing Then transaccion.Rollback()
            MessageBox.Show("Error al guardar en la base de datos." & vbCrLf & "Detalle: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        e.ThrowException = False
    End Sub

    ' --- OBTENER DATOS PRINCIPALES DEL PALLET (Query 1) ---
    Private Function ObtenerDatosPallet(idPallet As Integer) As DataRow
        Dim dt As New DataTable()

        Dim sql As String =
        "SELECT a.id, " &
        "       a.procesos_paletizado_id, " &
        "       e.nombre AS ubicacion, " &
        "       a.kilos_netos, " &
        "       a.kilos_brutos, " &
        "       a.numero_cajas, " &
        "       a.capacidad, " &
        "       d.tara AS tara_pallet, " &
        "       (c.tara * a.numero_cajas) AS tara_compuesta " &
        "FROM pallets a " &
        "INNER JOIN cajas b ON (a.id = b.pallet_id) " &
        "INNER JOIN tipos_contenedores c ON (b.tipos_contenedores_id = c.id) " &
        "INNER JOIN tipos_contenedores d ON (a.tipos_contenedores_id = d.id) " &
        "INNER JOIN tipos_ubicaciones e ON (a.tipos_ubicaciones_id = e.id) " &
        "WHERE a.id = @idPallet " &
        "GROUP BY a.id, a.procesos_paletizado_id, e.nombre, a.kilos_netos, " &
        "         a.kilos_brutos, a.numero_cajas, a.capacidad, d.tara, c.tara;"

        Try
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error al obtener datos principales del pallet: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function


    ' --- 2. OBTENER DETALLE DE CAJAS Y CALIBRES (Query 2) ---
    Private Function ObtenerDetallesCajas(idPallet As Integer) As DataTable
        Dim dt As New DataTable()

        ' Reemplaza esta consulta SQL por tu Query 2 real para agrupar producto, variedad y calibres
        Dim sql As String = "SELECT " &
                         "   p.nombre AS Producto, " &
                         "   v.nombre AS Variedad, " &
                         "   cal.nombre AS Calibre, " &
                         "   COUNT(c.id) AS Cajas " &
                         "FROM cajas c " &
                         "INNER JOIN productos p ON c.productos_id = p.id " &
                         "INNER JOIN variedades v ON c.variedades_id = v.id " &
                         "INNER JOIN calibres cal ON c.calibres_id = cal.id " &
                         "WHERE c.pallet_id = @idPallet " &
                         "GROUP BY p.nombre, v.nombre, cal.nombre"

        Try
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            Return dt

        Catch ex As Exception
            MessageBox.Show("Error al obtener el detalle de cajas del pallet: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function


    Private Function GenerarImagenBarcode(texto As String) As Bitmap
        Try
            Dim escritor As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128
            }
            escritor.Options = New Common.EncodingOptions With {
                .Width = 350,
                .Height = 100,
                .Margin = 2
            }
            Return escritor.Write(texto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' --- DISEÑO DEL TICKET DE PALLET 100x200 mm ---
    ' Recibe el DataRow con la info del pallet (Query 1) y el DataTable con el detalle de calibres (Query 2)
    Private Sub DisenoTicketPallet100x200(e As PrintPageEventArgs, rowPallet As DataRow, dtCajas As DataTable, nombreUbicacion As String)
        ' 100 mm de ancho a 100 DPI son aproximadamente 394 píxeles
        Dim anchoPapel As Integer = 394
        Dim x As Integer = 20
        Dim y As Integer = 20

        Using fTitulo As New Font("Arial", 14, FontStyle.Bold),
              fNumeroPallet As New Font("Arial", 28, FontStyle.Bold), ' Ajustado para ID de pallet
              fLabelCaja As New Font("Arial", 8, FontStyle.Bold),
              fDatosLabel As New Font("Arial", 11, FontStyle.Bold),
              fDatosValor As New Font("Arial", 11),
              fNetoValue As New Font("Arial", 16, FontStyle.Bold),
              fSubtitulo As New Font("Arial", 12, FontStyle.Bold),
              fTimestamp As New Font("Arial", 9, FontStyle.Italic)

            ' 0. EXTRAER DATOS DEL PALLET (Query 1)
            Dim idPallet As String = rowPallet("id").ToString()
            Dim procesoId As String = rowPallet("procesos_paletizado_id").ToString()
            Dim ubicacion As String = rowPallet("ubicacion").ToString()
            Dim bruto As Decimal = Convert.ToDecimal(rowPallet("kilos_brutos"))
            Dim neto As Decimal = Convert.ToDecimal(rowPallet("kilos_netos"))
            Dim totalCajas As String = rowPallet("numero_cajas").ToString()
            Dim taraPallet As Decimal = Convert.ToDecimal(rowPallet("tara_pallet"))
            Dim taraCompuesta As Decimal = Convert.ToDecimal(rowPallet("tara_compuesta"))

            ' 0.1 EXTRAER DATOS GENERALES DE PRODUCTO (Tomados de la primera fila del Query 2)
            Dim producto As String = "N/A"
            Dim variedad As String = "N/A"
            If dtCajas IsNot Nothing AndAlso dtCajas.Rows.Count > 0 Then
                producto = dtCajas.Rows(0)("Producto").ToString()
                variedad = dtCajas.Rows(0)("Variedad").ToString()
            End If

            ' 1. CÓDIGO QR A LA IZQUIERDA
            Dim escritorQR As New ZXing.BarcodeWriter With {
                .Format = ZXing.BarcodeFormat.QR_CODE
            }
            escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {
                .Height = 75,
                .Width = 75,
                .Margin = 0
            }
            Using bmpQR As Bitmap = escritorQR.Write(idPallet) ' QR con el ID del Pallet
                If bmpQR IsNot Nothing Then
                    e.Graphics.DrawImage(bmpQR, x, y, 75, 75)
                End If
            End Using

            ' 2. RECUADRO DE NÚMERO DE PALLET A LA DERECHA
            Dim recNum As New Rectangle(anchoPapel - 100, y, 80, 75)
            e.Graphics.DrawRectangle(Pens.Black, recNum)

            Dim tamLabel = e.Graphics.MeasureString("PALLET", fLabelCaja)
            e.Graphics.DrawString("PALLET", fLabelCaja, Brushes.Black, recNum.X + (80 - tamLabel.Width) / 2, recNum.Y + 4)

            Dim tamNum = e.Graphics.MeasureString(idPallet, fNumeroPallet)
            e.Graphics.DrawString(idPallet, fNumeroPallet, Brushes.Black, recNum.X + (80 - tamNum.Width) / 2, recNum.Y + 22)

            ' 3. IMAGEN EN EL MEDIO (CENTRADA)
            Dim imagenCargada As Boolean = False
            Try
                Dim imgLogo As Image = My.Resources.logo ' Asegúrate de tener 'logo' en My.Resources
                If imgLogo IsNot Nothing Then
                    Dim anchoImg As Integer = 150
                    Dim altoImg As Integer = 75
                    Dim xImg As Single = (anchoPapel - anchoImg) / 2
                    Dim yImg As Single = y

                    e.Graphics.DrawImage(imgLogo, xImg, yImg, anchoImg, altoImg)
                    imagenCargada = True
                End If
            Catch
                imagenCargada = False
            End Try

            If Not imagenCargada Then
                Dim titulo As String = "PALTAS EL CHEJO"
                Dim tamTitulo = e.Graphics.MeasureString(titulo, fTitulo)
                Dim xTitulo As Single = (anchoPapel - tamTitulo.Width) / 2
                Dim yTitulo As Single = y + ((75 - tamTitulo.Height) / 2)
                e.Graphics.DrawString(titulo, fTitulo, Brushes.Black, xTitulo, yTitulo)
            End If

            ' 4. LÍNEA SEPARADORA CABECERA
            y += 85
            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 15

            ' 5. LECTURA Y DIBUJO DE DATOS DEL PALLET
            Dim datos As New Dictionary(Of String, String) From {
                {"N° Proceso:", procesoId},
                {"Producto:", producto},
                {"Variedad:", variedad},
                {"Total Cajas:", totalCajas & " cajas"},
                {"Kilos Brutos:", bruto.ToString("#,##0.00") & " kg"},
                {"Tara Pallet:", taraPallet.ToString("#,##0.00") & " kg"},
                {"Tara Cajas:", taraCompuesta.ToString("#,##0.00") & " kg"}
            }

            Dim posXValor As Integer = 140
            For Each item In datos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, y)
                y += 26
            Next

            ' 6. KILOS NETOS DESTACADOS
            y += 5
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 10
            e.Graphics.DrawString("Kilos Netos:", fDatosLabel, Brushes.Black, x, y)
            e.Graphics.DrawString(neto.ToString("#,##0.00") & " kg", fNetoValue, Brushes.Black, posXValor, y - 2)
            y += 32
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 20

            ' 7. DETALLE DE CALIBRES (Iterando el Query 2)
            e.Graphics.DrawString("Detalle de Cajas por Calibre:", fSubtitulo, Brushes.Black, x, y)
            y += 25

            If dtCajas IsNot Nothing AndAlso dtCajas.Rows.Count > 0 Then
                For Each rowCaja As DataRow In dtCajas.Rows
                    Dim cantCajas As String = rowCaja("Cajas").ToString()
                    Dim nombreCalibre As String = rowCaja("Calibre").ToString()

                    ' Dibuja Cantidad y Calibre
                    e.Graphics.DrawString($"• {cantCajas} cajas", fDatosLabel, Brushes.Black, x + 10, y)
                    e.Graphics.DrawString($"Calibre: {nombreCalibre}", fDatosValor, Brushes.Black, posXValor + 20, y)
                    y += 22
                Next
            Else
                e.Graphics.DrawString("Sin detalle de cajas.", fDatosValor, Brushes.Black, x + 10, y)
                y += 22
            End If

            ' Empujar 'y' hacia abajo para el código de barras asegurando espacio
            ' Si el detalle de calibres es muy largo, ajusta su posición dinámicamente
            y += 20

            ' 8. CÓDIGO DE BARRAS INFERIOR
            ' Asume que tienes la función GenerarImagenBarcode igual que en tu ticket anterior
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(idPallet)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 100)
                    y += 110
                End If
            End Using

            ' 9. FECHA Y HORA REGISTRO
            Dim textoFecha As String = $"Impreso: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}"
            e.Graphics.DrawString(textoFecha, fTimestamp, Brushes.Black, x, y)

        End Using
    End Sub



End Class