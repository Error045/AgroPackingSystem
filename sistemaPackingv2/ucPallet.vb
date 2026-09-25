Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports ZXing

Public Class ucPallet

    Private Sub ucPallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombos()
        CargarDgvPalletsCreados()



    End Sub

    ' Evento para el botón de resta




    ' --- MÉTODO DE CARGA ---
    Private Sub CargarCombos()
        Try
            ' 1. Cargar combo de Procesos de Paletizado
            Dim sqlProcesos As String = "SELECT id, CONCAT('Proceso N° ', id) AS nombre_mostrar " &
                                        "FROM procesos_paletizado " &
                                        "WHERE estados_procesos_pallets_id = 1 AND estado = 1 " &
                                        "ORDER BY id DESC"

            LlenarCombo(cmbProcesoPallet, sqlProcesos, "id", "nombre_mostrar")

            ' 2. Cargar combo de Tipos de Contenedor
            Dim sqlTipos As String = "SELECT id, nombre " &
                                     "FROM tipos_contenedores " &
                                     "WHERE estado = 1 AND tipos_clases = 3 " &
                                     "ORDER BY nombre ASC"

            LlenarCombo(cmbTipoContenedor, sqlTipos, "id", "nombre")

        Catch ex As Exception
            MessageBox.Show("Error al cargar los desplegables: " & ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- MÉTODO AUXILIAR PARA LLENAR COMBOBOX ---
    Private Sub LlenarCombo(combo As ComboBox, sql As String, valueMember As String, displayMember As String)
        Try
            Dim dt As New DataTable()

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            combo.DataSource = dt
            combo.ValueMember = valueMember
            combo.DisplayMember = displayMember
            combo.SelectedIndex = -1

        Catch ex As Exception
            Throw New Exception("Error al procesar los datos del ComboBox: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub CargarDgvPalletsCreados()
        Try
            ' Se agregan ALIAS (AS 'Nombre') para que las columnas del DGV tengan nombres amigables
            Dim sql As String = "SELECT a.id AS 'ID Pallet', " &
                                "a.procesos_paletizado_id AS 'ID Proceso', " &
                                "c.nombre AS 'Contenedor', " &
                                "d.nombre AS 'Ubicación', " &
                                "e.nombre AS 'Estado' " &
                                "FROM pallets a " &
                                "JOIN procesos_paletizado b ON (a.procesos_paletizado_id = b.id) " &
                                "JOIN tipos_contenedores c ON (a.tipos_contenedores_id = c.id) " &
                                "JOIN tipos_ubicaciones d ON (a.tipos_ubicaciones_id = d.id) " &
                                "JOIN estados_contenedores e ON (a.estados_contenedores_id = e.id) " &
                                "WHERE b.estados_procesos_pallets_id = 1;"

            Dim dt As New DataTable()

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            ' Asignar los datos al DataGridView
            dgvPalletsCreados.DataSource = dt

            ' Opcional: Ajustar visualmente las columnas para que ocupen todo el ancho
            dgvPalletsCreados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error al cargar la tabla de pallets: " & ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub



    ' --- CREACIÓN DE PALLET Y SU HISTORIAL ---
    Private Sub btnCrearPallet_Click(sender As Object, e As EventArgs) Handles btnCrearPallet.Click
        ' --- 1. VALIDACIONES DE UI ---
        If cmbProcesoPallet.SelectedValue Is Nothing OrElse Not IsNumeric(cmbProcesoPallet.SelectedValue) Then
            MessageBox.Show("Por favor, seleccione un Proceso de Paletizado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTipoContenedor.SelectedValue Is Nothing OrElse Not IsNumeric(cmbTipoContenedor.SelectedValue) Then
            MessageBox.Show("Por favor, seleccione un Tipo de Contenedor (Pallet).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. VALORES INICIALES SEGÚN TU TABLA ---
        Dim idProceso As Integer = Convert.ToInt32(cmbProcesoPallet.SelectedValue)
        Dim idTipoContenedor As Integer = Convert.ToInt32(cmbTipoContenedor.SelectedValue)

        ' Valores por defecto para el nacimiento de un pallet (basado en tu volcado BD)
        Dim idUbicacion As Integer = 3 ' patio calibrado
        Dim kNetos As Decimal = 0.0
        Dim kBrutos As Decimal = 0.0
        Dim cajasIniciales As Integer = 0
        Dim capacidadDefecto As Integer = Convert.ToInt32(numCantidadCajas.Text) ' Valor por defecto de tu BD (puedes volverlo dinámico luego)
        Dim idEstContenedor As Integer = 9   ' 9 = "Asignación de Cajas, en calibrado"
        Dim estadoProgreso As Integer = 1 ' 1 = Abierto
        Dim estadoInicial As Integer = 1 ' 1 = Activo

        ' Variables de contexto (historial)
        Dim idUsuario As Integer = 1 ' Reemplazar por usuario logueado
        Dim idTipoMovimiento As Integer = 1 ' Ejemplo: 1 = "Creación de Pallet"

        Dim idPalletCreado As Integer = 0

        Try
            ConexionBD.Abrir()

            ' Iniciamos transacción
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' --- 3. INSERTAR EN PALLETS ---
                    Dim sqlInsertPallet As String = "INSERT INTO pallets (procesos_paletizado_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, estados_contenedores_id, estados_progresos_pallets_id, fecha_registro, estado) " &
                                                    "VALUES (@idProceso, @idTipo, @idUbi, @kNetos, @kBrutos, @cajas, @capacidad, @idEstContenedor, @estProgreso,NOW(), @estado); " &
                                                    "SELECT LAST_INSERT_ID();"

                    Using cmdPallet As New MySqlCommand(sqlInsertPallet, ConexionBD.conexion, transaccion)
                        cmdPallet.Parameters.AddWithValue("@idProceso", idProceso)
                        cmdPallet.Parameters.AddWithValue("@idTipo", idTipoContenedor)
                        cmdPallet.Parameters.AddWithValue("@idUbi", idUbicacion)
                        cmdPallet.Parameters.AddWithValue("@kNetos", kNetos)
                        cmdPallet.Parameters.AddWithValue("@kBrutos", kBrutos)
                        cmdPallet.Parameters.AddWithValue("@cajas", cajasIniciales)
                        cmdPallet.Parameters.AddWithValue("@capacidad", capacidadDefecto)
                        cmdPallet.Parameters.AddWithValue("@idEstContenedor", idEstContenedor)
                        cmdPallet.Parameters.AddWithValue("@estProgreso", estadoProgreso)
                        cmdPallet.Parameters.AddWithValue("@estado", estadoInicial)

                        ' Ejecutamos y capturamos el ID del Pallet generado
                        idPalletCreado = Convert.ToInt32(cmdPallet.ExecuteScalar())
                    End Using

                    ' --- 4. INSERTAR EN HISTORIAL ---
                    Dim sqlHistorial As String = "INSERT INTO pallets_historial (tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id, users_id, estado) " &
                                                 "VALUES (@mov, @proceso, @pallet, @tipoCont, @ubi, @kNetos, @kBrutos, @cajas, @capacidad, NOW(), @estContenedor, @estProgreso, @user, @estado)"

                    Using cmdHistorial As New MySqlCommand(sqlHistorial, ConexionBD.conexion, transaccion)
                        cmdHistorial.Parameters.AddWithValue("@mov", idTipoMovimiento)
                        cmdHistorial.Parameters.AddWithValue("@proceso", idProceso)
                        cmdHistorial.Parameters.AddWithValue("@pallet", idPalletCreado) ' Usamos el ID capturado arriba
                        cmdHistorial.Parameters.AddWithValue("@tipoCont", idTipoContenedor)
                        cmdHistorial.Parameters.AddWithValue("@ubi", idUbicacion)
                        cmdHistorial.Parameters.AddWithValue("@kNetos", kNetos)
                        cmdHistorial.Parameters.AddWithValue("@kBrutos", kBrutos)
                        cmdHistorial.Parameters.AddWithValue("@cajas", cajasIniciales)
                        cmdHistorial.Parameters.AddWithValue("@capacidad", capacidadDefecto)
                        cmdHistorial.Parameters.AddWithValue("@estContenedor", idEstContenedor)
                        cmdHistorial.Parameters.AddWithValue("@estProgreso", estadoProgreso)
                        cmdHistorial.Parameters.AddWithValue("@user", idUsuario)
                        cmdHistorial.Parameters.AddWithValue("@estado", estadoInicial)

                        cmdHistorial.ExecuteNonQuery()
                    End Using

                    ' --- 5. CONFIRMAR TRANSACCIÓN ---
                    transaccion.Commit()

                    MessageBox.Show("Pallet N° " & idPalletCreado & " creado exitosamente en estado 'Abierto'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- RECUPERAR EL NOMBRE DEL CONTENEDOR SELECCIONADO EN EL COMBO ---
                    Dim nombreContenedorStr As String = DirectCast(cmbTipoContenedor.SelectedItem, DataRowView)("nombre").ToString()

                    ' --- DISPARAR IMPRESIÓN DIRECTA DEL TICKET 60x40 mm ---
                    Dim printDoc As New Printing.PrintDocument()
                    Dim fechaActualStr As String = DateTime.Now.ToString("dd/MM/yyyy HH:mm")

                    ' Configurar el tamaño exacto del papel físico (6cm x 4cm = 236 x 157 centésimas de pulgada)
                    printDoc.DefaultPageSettings.PaperSize = New Printing.PaperSize("Etiqueta 60x40", 236, 157)
                    printDoc.DefaultPageSettings.Margins = New Printing.Margins(0, 0, 0, 0)

                    ' Opcional: Si tienes una impresora térmica específica, descomenta la siguiente línea y pon su nombre
                    ' printDoc.PrinterSettings.PrinterName = "Zebra TLP2844" 

                    AddHandler printDoc.PrintPage, Sub(s, ev)
                                                       ImprimirTicketPallet60x40(ev, idPalletCreado, idProceso, nombreContenedorStr, fechaActualStr)
                                                   End Sub

                    ' IMPRIMIR DIRECTAMENTE (sin vista previa)
                    printDoc.Print()

                    ' Limpiar interfaz
                    cmbTipoContenedor.SelectedIndex = -1
                    CargarDgvPalletsCreados()


                Catch ex As Exception
                    transaccion.Rollback()
                    Throw New Exception("Fallo en la transacción de creación: " & ex.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al crear el pallet: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Function GenerarImagenBarcode(texto As String) As Bitmap
        Try
            Dim escritor As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128
            }
            escritor.Options = New Common.EncodingOptions With {
                .Width = 350,
                .Height = 100,
                .Margin = 0 ' <--- CAMBIAR ESTO DE 2 a 0
            }
            Return escritor.Write(texto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub ImprimirTicketPallet60x40(e As PrintPageEventArgs, idPallet As Integer, idProceso As Integer, nombreContenedor As String, fechaReg As String)
        ' En PrintDocument, 1 unidad = 1/100 de pulgada.
        ' 6 cm (60 mm) = 236 unidades
        ' 4 cm (40 mm) = 157 unidades
        Dim anchoTicket As Integer = 236
        Dim altoTicket As Integer = 157

        Dim x As Integer = 2 ' Margen mínimo
        Dim y As Integer = 2

        Using fTituloEmpresa As New Font("Arial", 8, FontStyle.Bold),
              fTitulo As New Font("Arial", 9, FontStyle.Bold),
              fTexto As New Font("Arial", 7),
              fFecha As New Font("Arial", 6, FontStyle.Italic)

            ' --- A. LOGOTIPO O TEXTO EMPRESA ---
            Dim imagenCargada As Boolean = False
            Try
                Dim imgLogo As Image = My.Resources.logo
                If imgLogo IsNot Nothing Then
                    Dim anchoImg As Integer = 90 ' Tamaño de imagen ajustado para el ticket real
                    Dim altoImg As Integer = 30
                    Dim xImg As Single = (anchoTicket - anchoImg) / 2 ' Centrado horizontal
                    e.Graphics.DrawImage(imgLogo, xImg, y, anchoImg, altoImg)
                    imagenCargada = True
                End If
            Catch
                imagenCargada = False
            End Try

            If Not imagenCargada Then
                Dim textoEmpresa As String = "PALTAS EL CHEJO"
                Dim tamEmpresa = e.Graphics.MeasureString(textoEmpresa, fTituloEmpresa)
                Dim xEmpresa As Single = (anchoTicket - tamEmpresa.Width) / 2
                e.Graphics.DrawString(textoEmpresa, fTituloEmpresa, Brushes.Black, xEmpresa, y + 5)
            End If

            y += 32

            ' Línea separadora
            e.Graphics.DrawLine(Pens.Black, 10, y, anchoTicket - 10, y)
            y += 4

            ' --- B. INFORMACIÓN DEL PALLET ---
            ' Centrar el título de PALLET N°
            Dim txtPallet As String = $"PALLET N°: {idPallet}"
            Dim tamPallet = e.Graphics.MeasureString(txtPallet, fTitulo)
            e.Graphics.DrawString(txtPallet, fTitulo, Brushes.Black, (anchoTicket - tamPallet.Width) / 2, y)
            y += 15

            ' Resto de los datos a la izquierda
            e.Graphics.DrawString($"Proc: {idProceso} | Cont: {nombreContenedor}", fTexto, Brushes.Black, x + 5, y)
            y += 12

            e.Graphics.DrawString($"Fecha: {fechaReg}", fFecha, Brushes.Black, x + 5, y)
            y += 12

            ' --- C. CÓDIGO DE BARRAS INFERIOR ---
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(idPallet.ToString())
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBar As Integer = 190
                    Dim altoBar As Integer = 45
                    Dim xBar As Single = (anchoTicket - anchoBar) / 2
                    e.Graphics.DrawImage(bmpBarcode, xBar, y, anchoBar, altoBar)
                End If
            End Using
        End Using
    End Sub


End Class