Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports ZXing

Public Class ucProcesoCalibrado

    ' --- VARIABLE CLAVE ---
    ' Esta bandera evita que los eventos se disparen a lo loco mientras llenamos los datos
    Private cargando As Boolean = True

    ' 1. CARGA INICIAL
    Private Sub ucProcesoCalibrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboProceso()
        '  LlenarComboContenedor() ' <-- Agregar esta línea
    End Sub

    ' 2. LÓGICA DEL COMBO PROCESO
    Private Sub CargarComboProceso()
        cargando = True ' Bloqueamos eventos

        Dim sqlProceso As String = "SELECT a.id, CONCAT(a.id, ' - ', c.nombre) as nombre " &
                                   "FROM procesos a " &
                                   "JOIN recepciones b ON a.recepciones_id = b.id " &
                                   "JOIN personas c ON b.personas_id = c.id " &
                                   "WHERE a.estados_procesos_id = 1"

        Dim dtProceso As DataTable = ObtenerDatos(sqlProceso)

        cmbProceso.DataSource = dtProceso
        cmbProceso.DisplayMember = "nombre"
        cmbProceso.ValueMember = "id"
        cmbProceso.SelectedIndex = -1

        cargando = False ' Desbloqueamos eventos

        ' Forzamos la carga del hijo (Producto) basándonos en lo que quedó seleccionado
        LlenarComboProducto()
    End Sub

    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        ' Si estamos cargando datos por código, ignoramos el click del usuario
        If cargando Then Return
        LlenarComboProducto()
    End Sub

    ' 3. LÓGICA DEL COMBO PRODUCTO
    Private Sub LlenarComboProducto()
        cargando = True ' Bloqueamos eventos

        ' Limpiamos los combos hijos
        cmbProducto.DataSource = Nothing
        cmbVariedad.DataSource = Nothing

        ' Validamos que el proceso tenga un ID válido seleccionado
        If cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT p.id, p.nombre " &
                                "FROM productos p " &
                                "JOIN contenedores c ON p.id = c.productos_id " &
                                "JOIN recepciones r ON c.recepciones_id = r.id " &
                                "JOIN procesos pr ON r.id = pr.recepciones_id " &
                                "WHERE pr.id = @idProc " &
                                "GROUP BY p.id;"

            Dim param As New MySqlParameter("@idProc", idProceso)
            Dim dtProductos As DataTable = ObtenerDatos(sql, {param})

            cmbProducto.DataSource = dtProductos
            cmbProducto.DisplayMember = "nombre"
            cmbProducto.ValueMember = "id"

            ' Auto-selección de Producto
            If dtProductos.Rows.Count > 0 Then
                cmbProducto.SelectedIndex = 0
            Else
                cmbProducto.SelectedIndex = -1
            End If
        End If

        cargando = False ' Desbloqueamos eventos

        ' Forzamos la carga del nieto (Variedad)
        LlenarComboVariedad()
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cargando Then Return
        LlenarComboVariedad()
    End Sub

    ' 4. LÓGICA DEL COMBO VARIEDAD
    Private Sub LlenarComboVariedad()
        cargando = True ' Bloqueamos eventos

        cmbVariedad.DataSource = Nothing
        cmbCalibre.DataSource = Nothing ' <-- NUEVO: Limpiamos calibres viejos al recalcular variedades

        ' Validamos que Proceso y Producto tengan un ID válido
        If cmbProducto.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProducto.SelectedValue) AndAlso cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProducto As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT v.id, v.nombre " &
                                "FROM variedades v " &
                                "JOIN contenedores c ON v.id = c.variedades_id " &
                                "JOIN recepciones r ON c.recepciones_id = r.id " &
                                "JOIN procesos pr ON r.id = pr.recepciones_id " &
                                "WHERE pr.id = @idProc AND c.productos_id = @idProd " &
                                "GROUP BY v.id"

            Dim p1 As New MySqlParameter("@idProc", idProceso)
            Dim p2 As New MySqlParameter("@idProd", idProducto)
            Dim dtVariedades As DataTable = ObtenerDatos(sql, {p1, p2})

            cmbVariedad.DataSource = dtVariedades
            cmbVariedad.DisplayMember = "nombre"
            cmbVariedad.ValueMember = "id"

            ' Auto-selección de Variedad
            If dtVariedades.Rows.Count > 0 Then
                cmbVariedad.SelectedIndex = 0
            Else
                cmbVariedad.SelectedIndex = -1
            End If
        End If

        cargando = False ' Desbloqueamos eventos
        LlenarComboCalibre()
    End Sub

    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        If cargando Then Return
        LlenarComboCalibre()
    End Sub

    ' 5. LÓGICA DEL COMBO CALIBRE
    Private Sub LlenarComboCalibre()
        cargando = True
        cmbCalibre.DataSource = Nothing

        If cmbVariedad.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbVariedad.SelectedValue) Then
            Dim idVariedad As Integer = Convert.ToInt32(cmbVariedad.SelectedValue)

            Dim sqlCalibre As String = "SELECT id,nombre FROM calibres WHERE variedades_id = @varId"
            Dim dtCalibres As DataTable = ObtenerDatos(sqlCalibre, {New MySqlParameter("@varId", idVariedad)})

            cmbCalibre.DisplayMember = "nombre"
            cmbCalibre.ValueMember = "id"
            cmbCalibre.DataSource = dtCalibres
            cmbCalibre.SelectedIndex = -1
        End If

        cargando = False
    End Sub

    Private Sub cmbCalibre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalibre.SelectedIndexChanged
        If cargando Then Return
    End Sub

    ' 7. LÓGICA DE REGISTRO, IMPRESIÓN Y VALIDACIÓN
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        ' --- VALIDACIÓN DE CAMPOS ---
        Dim errorMensaje As String = ""
        If cmbProceso.SelectedValue Is Nothing OrElse cmbProceso.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Proceso." & vbCrLf
        If cmbProducto.SelectedValue Is Nothing OrElse cmbProducto.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Producto." & vbCrLf
        If cmbVariedad.SelectedValue Is Nothing OrElse cmbVariedad.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar una Variedad." & vbCrLf
        If cmbCalibre.SelectedValue Is Nothing OrElse cmbCalibre.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Calibre." & vbCrLf

        If Not String.IsNullOrEmpty(errorMensaje) Then
            MessageBox.Show("Faltan datos requeridos:" & vbCrLf & vbCrLf & errorMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- PROCESO DE INSERCIÓN Y CAPTURA DEL ID ---
        Dim nuevoIdContenedor As Integer = 0
        Try
            ConexionBD.Abrir()

            ' 1. Insertamos el contenedor y capturamos su nuevo ID con LAST_INSERT_ID()
            Dim sqlContenedor As String = "INSERT INTO contenedores (recepciones_id, productos_id, variedades_id, calibres_id, tipos_ubicaciones_id, estados_contenedores_id, fecha_registro, users_id_registro, estado, created_at, updated_at) " &
                                          "SELECT recepciones_id, @prodId, @varId, @calId, 3, 4, NOW(), 1, 1, NOW(), NOW() FROM procesos WHERE id = @procId; " &
                                          "SELECT LAST_INSERT_ID();"

            Using cmd As New MySqlCommand(sqlContenedor, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@procId", cmbProceso.SelectedValue)
                cmd.Parameters.AddWithValue("@prodId", cmbProducto.SelectedValue)
                cmd.Parameters.AddWithValue("@varId", cmbVariedad.SelectedValue)
                cmd.Parameters.AddWithValue("@calId", cmbCalibre.SelectedValue)

                ' ExecuteScalar nos devuelve el ID recién creado
                nuevoIdContenedor = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' 2. Insertamos el historial usando el ID capturado
            Dim sqlHistorial As String = "INSERT INTO contenedores_historial (tipos_movimientos_id, contenedores_id, tipos_ubicaciones_id, estados_contenedores_id, fecha_movimiento, users_id, estado, created_at, updated_at) " &
                                         "VALUES (1, @idCont, 3, 4, NOW(), 1, 1, NOW(), NOW());"

            Using cmd2 As New MySqlCommand(sqlHistorial, ConexionBD.conexion)
                cmd2.Parameters.AddWithValue("@idCont", nuevoIdContenedor)
                cmd2.ExecuteNonQuery()
            End Using

            ConexionBD.Cerrar()

            ' --- OBTENER DATOS DE LA VISTA PARA IMPRESIÓN ---
            ' Consultamos tu nueva vista usando el ID recién creado
            Dim sqlVista As String = "SELECT * FROM vw_calibrado_detalles_resumen WHERE codigo = @id"
            Dim dtTicket As DataTable = ObtenerDatos(sqlVista, {New MySqlParameter("@id", nuevoIdContenedor)})

            If dtTicket.Rows.Count > 0 Then
                Dim fila As DataRow = dtTicket.Rows(0)

                ' Llenamos el diccionario exactamente con los datos de la vista
                Dim datosTicket As New Dictionary(Of String, String) From {
                    {"codigo", fila("codigo").ToString()},
                    {"recepcion", fila("recepcion").ToString()},
                    {"tipo", fila("tipo").ToString()},
                    {"proceso", fila("proceso").ToString()},
                    {"productor", fila("productor").ToString()},
                    {"producto", fila("producto").ToString()},
                    {"variedad", fila("variedad").ToString()},
                    {"calibre", fila("calibre").ToString()},
                    {"numero", fila("numero").ToString()},
                    {"fecha", If(IsDBNull(fila("fecha")), DateTime.Now.ToString("dd/MM/yyyy"), Convert.ToDateTime(fila("fecha")).ToString("dd/MM/yyyy"))},
                    {"hora", fila("hora").ToString()}
                }

                ' Mandamos a imprimir usando el nuevo diseño
                Dim pd As New PrintDocument()
                pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
                pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                AddHandler pd.PrintPage, Sub(s, ev)
                                             DisenoTicketQR_Grande(ev, datosTicket)
                                         End Sub
                pd.Print()

                MessageBox.Show("Registro de calibración completado e impreso con éxito.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbCalibre.SelectedIndex = -1
            Else
                MessageBox.Show("El registro se guardó, pero no se encontró en la vista para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            If ConexionBD.conexion.State = ConnectionState.Open Then ConexionBD.Cerrar()
            MessageBox.Show("Error al guardar/imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' ====================== MÉTODOS DE IMPRESIÓN =============================
    ' =========================================================================

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

    ' --- DISEÑO DEL TICKET QR GIGANTE (100mm x 150mm) ---
    Private Sub DisenoTicketQR_Grande(e As PrintPageEventArgs, datos As Dictionary(Of String, String))
        Dim anchoPapel As Integer = 394
        Dim x As Integer = 20
        Dim y As Integer = 20

        Using fCalibreNumero As New Font("Arial", 38, FontStyle.Bold),
          fCalibreLabel As New Font("Arial", 8, FontStyle.Bold),
          fDatosLabel As New Font("Arial", 11, FontStyle.Bold),
          fDatosValor As New Font("Arial", 11),
          fTimestamp As New Font("Arial", 9, FontStyle.Italic)

            Dim codigoBin As String = datos("codigo")

            ' 1. CÓDIGO QR GIGANTE A LA IZQUIERDA (220x220 px)
            Dim tamQR As Integer = 220
            Dim escritorQR As New ZXing.BarcodeWriter With {
            .Format = ZXing.BarcodeFormat.QR_CODE
        }
            escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {
            .Height = tamQR,
            .Width = tamQR,
            .Margin = 0
        }
            Using bmpQR As Bitmap = escritorQR.Write(codigoBin)
                If bmpQR IsNot Nothing Then
                    e.Graphics.DrawImage(bmpQR, x, y, tamQR, tamQR)
                End If
            End Using

            ' 2. RECUADRO DE CALIBRE (NÚMERO) A LA DERECHA
            Dim numCalibre As String = datos("numero")
            Dim recCalibre As New Rectangle(anchoPapel - 100, y, 80, 75)
            e.Graphics.DrawRectangle(Pens.Black, recCalibre)

            Dim tamCalLabel = e.Graphics.MeasureString("CALIBRE", fCalibreLabel)
            e.Graphics.DrawString("CALIBRE", fCalibreLabel, Brushes.Black, recCalibre.X + (80 - tamCalLabel.Width) / 2, recCalibre.Y + 4)

            Dim tamCalNum = e.Graphics.MeasureString(numCalibre, fCalibreNumero)
            e.Graphics.DrawString(numCalibre, fCalibreNumero, Brushes.Black, recCalibre.X + (80 - tamCalNum.Width) / 2, recCalibre.Y + 18)

            ' Avanzamos Y justo debajo del QR
            y += tamQR + 10

            ' LÍNEA SEPARADORA
            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 10

            ' 3. LISTA DE DATOS SOLICITADOS
            Dim lineasDatos As New Dictionary(Of String, String) From {
            {"Código ID:", codigoBin},
            {"Recepción:", datos("recepcion")},
            {"Tipo:", datos("tipo")},
            {"Proceso:", datos("proceso")}, ' <--- AQUÍ SE AGREGÓ EL PROCESO
            {"Productor:", datos("productor")},
            {"Producto:", datos("producto")},
            {"Variedad:", datos("variedad")},
            {"Calibre:", datos("calibre")}
        }

            Dim posXValor As Integer = 120 ' Tabulación para que los valores queden alineados
            For Each item In lineasDatos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, y)
                y += 24 ' Espaciado entre lineas
            Next

            ' LÍNEA SEPARADORA
            y += 5
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 10

            ' 4. CÓDIGO DE BARRAS INFERIOR
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(codigoBin)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    ' Reducimos la altura del barcode a 60px para optimizar el espacio inferior
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 60)
                    y += 65
                End If
            End Using

            ' 5. FECHA Y HORA AL FINAL
            e.Graphics.DrawString($"Fecha: {datos("fecha")} {datos("hora")}", fTimestamp, Brushes.Black, x, y)
        End Using
    End Sub

End Class