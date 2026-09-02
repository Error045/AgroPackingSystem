Imports System.Transactions
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports ZXing

Public Class ucUbicacion
    Inherits System.Windows.Forms.UserControl

    Private LoteTerminado As New List(Of Dictionary(Of String, String))
    Private dtUbicaciones As DataTable
    Private FilaActualImprimir As DataRow ' Variable global temporal para la impresión

    Public Event LoteGuardadoExitosamente()

    Private Sub ucUbicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarUbicaciones()
            ConfigurarGridResumen()
        End If
    End Sub

    ' 1. Llenamos el ComboBox con las ubicaciones y su DISPONIBILIDAD
    Private Sub CargarUbicaciones()
        Try
            Dim sql As String =
                "SELECT u.id, CONCAT(u.nombre, ' (Disp: ', (u.capacidad - IFNULL(c.Ocupados, 0)), ')') AS DisplayName " &
                "FROM tipos_ubicaciones u " &
                "LEFT JOIN (" &
                "   SELECT a.tipos_ubicaciones_id, COUNT(a.id) as Ocupados " &
                "   FROM contenedores a " &
                "JOIN tipos_ubicaciones tu ON a.tipos_ubicaciones_id = tu.id " &
                "   WHERE tu.estado = 1 AND tu.funciones_id IN (5,9) AND tu.id <> 1 " &
                "   GROUP BY a.tipos_ubicaciones_id" &
                ") c ON u.id = c.tipos_ubicaciones_id " &
                "WHERE u.estado = 1 AND u.funciones_id IN (5,9) AND u.id <> 1"

            dtUbicaciones = ObtenerDatos(sql) ' Asumo que tienes esta función global

            If dtUbicaciones IsNot Nothing AndAlso dtUbicaciones.Rows.Count > 0 Then
                cmbUbicacionGeneral.DataSource = dtUbicaciones
                cmbUbicacionGeneral.DisplayMember = "DisplayName"
                cmbUbicacionGeneral.ValueMember = "id"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar ubicaciones: " & ex.Message)
        End Try
    End Sub

    ' 2,5. Buscamos el Tipo de Contenedor y lo mostramos en la grilla
    Private Function ObtenerNombreContenedor(idContenedor As String) As String
        Dim nombreContenedor As String = "Desconocido"
        Dim query As String = "SELECT tara FROM tipos_contenedores WHERE id = @id"
        Using cmd = New MySqlCommand(query, ConexionBD.conexion)
            cmd.Parameters.AddWithValue("@id", idContenedor)
            Try
                ConexionBD.Abrir()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    nombreContenedor = result.ToString()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al buscar el tipo de contenedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
        End Using
        Return nombreContenedor
    End Function

    ' 2. Configuramos la grilla
    Private Sub ConfigurarGridResumen()
        dgvResumen.Columns.Clear()

        dgvResumen.Columns.Add("ID_CAL", "ID Ticket")
        dgvResumen.Columns.Add("Producto", "Producto")
        dgvResumen.Columns.Add("Variedad", "Variedad")
        dgvResumen.Columns.Add("Calibre", "Calibre")
        dgvResumen.Columns.Add("Bruto", "K. Brutos")
        dgvResumen.Columns.Add("Neto", "K. Netos")
        dgvResumen.Columns.Add("NombreContenedor", "Tipo Envase")

        Dim colTipoCont As New DataGridViewTextBoxColumn()
        colTipoCont.Name = "idTipoCont"
        colTipoCont.Visible = False
        dgvResumen.Columns.Add(colTipoCont)

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

        For Each col As DataGridViewColumn In dgvResumen.Columns
            If col.Name <> "colUbicacion" Then
                col.ReadOnly = True
                col.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub

    ' 3. Inyectar la lista de pesajes
    Public Sub RecibirDatosParaGuardar(datosLote As List(Of Dictionary(Of String, String)))
        LoteTerminado = datosLote
        dgvResumen.Rows.Clear()

        For Each item In LoteTerminado
            Dim rowIndex As Integer = dgvResumen.Rows.Add()
            Dim row As DataGridViewRow = dgvResumen.Rows(rowIndex)

            row.Cells("ID_CAL").Value = item("ID_CAL")
            row.Cells("Producto").Value = item("Producto")
            row.Cells("Variedad").Value = item("Variedad")
            row.Cells("Calibre").Value = item("Calibre")
            row.Cells("Bruto").Value = item("Bruto")
            row.Cells("Neto").Value = item("Neto")

            Dim idContenedor As String = item("idTipoCont")
            row.Cells("idTipoCont").Value = idContenedor
            row.Cells("NombreContenedor").Value = ObtenerNombreContenedor(idContenedor)
        Next
    End Sub

    Private Sub btnAplicarATodos_Click(sender As Object, e As EventArgs) Handles btnAplicarATodos.Click
        If cmbUbicacionGeneral.SelectedValue Is Nothing Then Return
        Dim idSeleccionado = cmbUbicacionGeneral.SelectedValue
        For Each row As DataGridViewRow In dgvResumen.Rows
            row.Cells("colUbicacion").Value = idSeleccionado
        Next
    End Sub

    ' 4. Guardado transaccional
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        For Each row As DataGridViewRow In dgvResumen.Rows
            If row.Cells("colUbicacion").Value Is Nothing OrElse IsDBNull(row.Cells("colUbicacion").Value) Then
                MessageBox.Show("El ticket " & row.Cells("ID_CAL").Value.ToString() & " no tiene una cámara asignada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim idUsuario As Integer = 1
        Dim idFaseSistema As Integer = 4

        Dim sqlQuery As String =
            "UPDATE contenedores SET " &
            "   tipos_contenedores_id = @cont, kilos_brutos = @bruto, kilos_netos = @neto, " &
            "   tipos_ubicaciones_id = @ubicacionId, estados_contenedores_id = 6, ciclo = @ciclo, " &
            "   fecha_registro = NOW(), users_id_registro = @userId, updated_at = NOW() " &
            "WHERE id = @id; " &
            "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, ciclo, fecha_movimiento, users_id) " &
            "SELECT 1, tipos_contenedores_id, id, 4, 5, kilos_brutos, kilos_netos, @ciclo, NOW(), users_id_registro FROM contenedores WHERE id = @id; " &
            "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, ciclo, fecha_movimiento, users_id) " &
            "SELECT 2, tipos_contenedores_id, id, tipos_ubicaciones_id, 6, kilos_brutos, kilos_netos, @ciclo, NOW(), users_id_registro FROM contenedores WHERE id = @id;"

        Dim transaccion As MySqlTransaction = Nothing

        Try
            ConexionBD.Abrir()
            transaccion = ConexionBD.conexion.BeginTransaction()

            ' Calcular Ciclo
            Dim idRecepcion As Integer = 0
            Dim proximoCiclo As Integer = 1
            Dim primerIdContenedor As Integer = Convert.ToInt32(dgvResumen.Rows(0).Cells("ID_CAL").Value)

            Dim sqlRecep = "SELECT recepciones_id FROM contenedores WHERE id = @idCont LIMIT 1"
            Using cmdRecep = New MySqlCommand(sqlRecep, ConexionBD.conexion, transaccion)
                cmdRecep.Parameters.AddWithValue("@idCont", primerIdContenedor)
                idRecepcion = Convert.ToInt32(cmdRecep.ExecuteScalar())
            End Using

            Dim sqlCiclo = "SELECT COALESCE(MAX(ciclo), 0) + 1 FROM contenedores   WHERE recepciones_id = @idRec AND estados_contenedores_id NOT IN (1,2,3) "
            Using cmdMax = New MySqlCommand(sqlCiclo, ConexionBD.conexion, transaccion)
                cmdMax.Parameters.AddWithValue("@idRec", idRecepcion)
                proximoCiclo = Convert.ToInt32(cmdMax.ExecuteScalar())
            End Using

            Using cmd As New MySqlCommand(sqlQuery, ConexionBD.conexion, transaccion)
                cmd.Parameters.Add("@cont", MySqlDbType.Int32)
                cmd.Parameters.Add("@bruto", MySqlDbType.Double)
                cmd.Parameters.Add("@neto", MySqlDbType.Double)
                cmd.Parameters.Add("@ubicacionId", MySqlDbType.Int32)
                cmd.Parameters.Add("@ciclo", MySqlDbType.Int32)
                cmd.Parameters.Add("@userId", MySqlDbType.Int32)
                cmd.Parameters.Add("@id", MySqlDbType.Int32)

                For Each row As DataGridViewRow In dgvResumen.Rows
                    cmd.Parameters("@cont").Value = row.Cells("idTipoCont").Value
                    cmd.Parameters("@bruto").Value = row.Cells("Bruto").Value
                    cmd.Parameters("@neto").Value = row.Cells("Neto").Value
                    cmd.Parameters("@ubicacionId").Value = row.Cells("colUbicacion").Value
                    cmd.Parameters("@ciclo").Value = proximoCiclo
                    cmd.Parameters("@userId").Value = idUsuario
                    cmd.Parameters("@id").Value = row.Cells("ID_CAL").Value

                    cmd.ExecuteNonQuery()
                Next
            End Using

            transaccion.Commit()
            MessageBox.Show("Los contenedores fueron ubicados correctamente. Procediendo a imprimir tickets...", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarUbicaciones()

            ' 🟢 5. LLAMADA AL PROCESO DE IMPRESIÓN USANDO LA VISTA
            ImprimirTicketsLote()

            RaiseEvent LoteGuardadoExitosamente()

        Catch ex As Exception
            If transaccion IsNot Nothing Then transaccion.Rollback()
            MessageBox.Show("Error al guardar. Se cancelaron los cambios." & vbCrLf & "Detalle: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' -------------------------------------------------------------------------
    ' SECCIÓN DE IMPRESIÓN
    ' -------------------------------------------------------------------------

    Private Sub ImprimirTicketsLote()
        For Each row As DataGridViewRow In dgvResumen.Rows
            Dim idContenedor As Integer = Convert.ToInt32(row.Cells("ID_CAL").Value)

            ' Consultamos la vista para obtener toda la data cruzada
            Dim queryView As String = $"SELECT * FROM vw_calibrado_detalles_resumen_tara WHERE codigo = {idContenedor}"
            Dim dtTicket As DataTable = ObtenerDatos(queryView)

            If dtTicket IsNot Nothing AndAlso dtTicket.Rows.Count > 0 Then
                FilaActualImprimir = dtTicket.Rows(0)

                Dim pd As New PrintDocument()
                ' pd.PrinterSettings.PrinterName = "NombreDeTuImpresoraTermica" ' Descomentar y ajustar si es necesario
                AddHandler pd.PrintPage, AddressOf PrintDocument_PrintPage
                pd.Print()
            End If
        Next
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Pasamos el DataRow actual a tu función de diseño
        DisenoTicket100x200(e, FilaActualImprimir)
    End Sub

    Private Sub ImprimirTicketIndividual(row As DataGridViewRow)
        Dim pd As New PrintDocument()

        ' Configuración a 100mm x 200mm (394 x 787 centésimas de pulgada)
        pd.DefaultPageSettings.PaperSize = New PaperSize("100x200", 394, 787)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
        pd.OriginAtMargins = False

        ' Para invocar con DataRow o DataGridViewRow según donde lo uses:
        Dim filaSeleccionada = row
        AddHandler pd.PrintPage, Sub(sender, e)
                                     ' Si estás usando DataRow proveniente de la Vista:
                                     ' DisenoTicket100x200(e, CType(filaSeleccionada.DataBoundItem, DataRowView).Row)
                                     DisenoTicket100x200(e, filaSeleccionada)
                                 End Sub
        pd.Print()
    End Sub

    Private Sub DisenoTicket100x200(e As PrintPageEventArgs, row As Object)
        ' 🟢 1. NEUTRALIZAR MÁRGENES FÍSICOS DE LA IMPRESORA (Pone el origen 0,0 en el borde real del papel)
        e.Graphics.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY)

        Dim anchoPapel As Integer = 394
        Dim x As Integer = 10 ' Reducido para aprovechar el ancho real
        Dim y As Integer = 10 ' Reducido para evitar desfase superior

        Using fTitulo As New Font("Arial", 12, FontStyle.Bold),
          fCalibreNumero As New Font("Arial", 32, FontStyle.Bold),
          fCalibreLabel As New Font("Arial", 8, FontStyle.Bold),
          fDatosLabel As New Font("Arial", 10, FontStyle.Bold),
          fDatosValor As New Font("Arial", 10),
          fNetoValue As New Font("Arial", 14, FontStyle.Bold),
          fTimestamp As New Font("Arial", 8, FontStyle.Italic)

            ' Funciones auxiliares de lectura según el tipo de objeto recibido (DataRow o DataGridViewRow)
            Dim GetStr = Function(colName As String) As String
                             If TypeOf row Is DataGridViewRow Then
                                 Dim r = CType(row, DataGridViewRow)
                                 Return If(r.Cells(colName).Value IsNot Nothing, r.Cells(colName).Value.ToString(), "-")
                             ElseIf TypeOf row Is DataRow Then
                                 Dim r = CType(row, DataRow)
                                 Return If(r.Table.Columns.Contains(colName) AndAlso Not IsDBNull(r(colName)), r(colName).ToString(), "-")
                             End If
                             Return "-"
                         End Function

            Dim GetDec = Function(colName As String) As Decimal
                             Dim strVal = GetStr(colName)
                             Dim val As Decimal = 0
                             Decimal.TryParse(strVal, val)
                             Return val
                         End Function

            ' 0. LEER EL ID
            Dim codigoBin As String = GetStr("codigo")

            ' 1. CÓDIGO QR A LA IZQUIERDA
            Dim escritorQR As New ZXing.BarcodeWriter With {.Format = ZXing.BarcodeFormat.QR_CODE}
            escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {.Height = 70, .Width = 70, .Margin = 0}
            Using bmpQR As Bitmap = escritorQR.Write(codigoBin)
                If bmpQR IsNot Nothing Then
                    e.Graphics.DrawImage(bmpQR, x, y, 70, 70)
                End If
            End Using

            ' 2. RECUADRO DE CALIBRE A LA DERECHA (Ubicado dentro del margen visible)
            Dim numCalibre As String = GetStr("numero")
            Dim recCalibre As New Rectangle(anchoPapel - 90, y, 75, 70)
            e.Graphics.DrawRectangle(Pens.Black, recCalibre)

            Dim tamCalLabel = e.Graphics.MeasureString("CALIBRE", fCalibreLabel)
            e.Graphics.DrawString("CALIBRE", fCalibreLabel, Brushes.Black, recCalibre.X + (75 - tamCalLabel.Width) / 2, recCalibre.Y + 4)

            Dim tamCalNum = e.Graphics.MeasureString(numCalibre, fCalibreNumero)
            e.Graphics.DrawString(numCalibre, fCalibreNumero, Brushes.Black, recCalibre.X + (75 - tamCalNum.Width) / 2, recCalibre.Y + 16)

            ' 3. TÍTULO CENTRADO
            Dim titulo As String = "PALTAS EL CHEJO"
            Dim tamTitulo = e.Graphics.MeasureString(titulo, fTitulo)
            Dim xTitulo As Single = (anchoPapel - tamTitulo.Width) / 2
            Dim yTitulo As Single = y + ((70 - tamTitulo.Height) / 2)
            e.Graphics.DrawString(titulo, fTitulo, Brushes.Black, xTitulo, yTitulo)

            ' 4. LÍNEA SEPARADORA
            y += 78
            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 10

            ' 5. LECTURA Y DIBUJO DE DATOS
            Dim bruto As Decimal = GetDec("bruto")
            Dim neto As Decimal = GetDec("neto")
            Dim tara As Decimal = GetDec("tara")

            Dim datos As New Dictionary(Of String, String) From {
            {"Código ID:", codigoBin},
            {"Recepción:", GetStr("recepcion")},
            {"Tipo:", GetStr("tipo")},
            {"Proceso:", GetStr("proceso")},
            {"Ciclo:", GetStr("ciclo")},
            {"Productor:", GetStr("productor")},
            {"Producto:", GetStr("producto")},
            {"Variedad:", GetStr("variedad")},
            {"Calibre:", GetStr("calibre")},
            {"Kilos Brutos:", bruto.ToString("#,##0.#") & " kg"},
            {"Tara:", tara.ToString("#,##0.#") & " kg"}
        }

            Dim posXValor As Integer = 130
            For Each item In datos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, y)
                y += 22 ' Ajustado para optimizar el alto vertical
            Next

            ' 6. KILOS NETOS DESTACADOS
            y += 4
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 6
            e.Graphics.DrawString("Kilos Netos:", fDatosLabel, Brushes.Black, x, y)
            e.Graphics.DrawString(neto.ToString("#,##0.#") & " kg", fNetoValue, Brushes.Black, posXValor, y)
            y += 26
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 15

            ' 7. CÓDIGO DE BARRAS INFERIOR (Altura reducida a 70px para garantizar ajuste)
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(codigoBin)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 70)
                    y += 78
                End If
            End Using

            ' 8. FECHA Y HORA REGISTRO
            Dim fechaVal As String = GetStr("fecha")
            Dim horaVal As String = GetStr("hora")
            e.Graphics.DrawString($"Fecha Reg: {fechaVal} {horaVal}", fTimestamp, Brushes.Black, x, y)
        End Using
    End Sub


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

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        e.ThrowException = False
    End Sub

End Class