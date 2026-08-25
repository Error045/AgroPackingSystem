Imports MySql.Data.MySqlClient

Public Class ucOrdenRepesajeActualizar
    Inherits System.Windows.Forms.UserControl

    ' Variable para guardar temporalmente los datos calculados de la sesión
    Private LotePesadoParaRevision As List(Of Dictionary(Of String, String))

    ' Eventos para comunicarse con el orquestador
    Public Event SolicitarGuardadoFinal(datosFinales As List(Of Dictionary(Of String, String)))
    Public Event ProcesoCancelado()

    ' 🟢 1. RECIBIR DATOS Y ARMAR LA TABLA DE REVISIÓN
    Public Sub RecibirDatosParaRevision(lote As List(Of Dictionary(Of String, String)))
        LotePesadoParaRevision = lote
        ArmarTablaComparativaDesdeBD()
    End Sub

    Private Sub ArmarTablaComparativaDesdeBD()
        dgvResumen.DataSource = Nothing
        dgvResumen.Columns.Clear()

        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("recepcion", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("variedad", GetType(String))
        dt.Columns.Add("calibre", GetType(String))
        dt.Columns.Add("tara", GetType(Decimal))
        dt.Columns.Add("kilos_origen", GetType(Decimal))
        dt.Columns.Add("kilos_actuales", GetType(Decimal))
        dt.Columns.Add("diferencia", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("tipos_contenedores_id", GetType(Integer))

        Try
            ConexionBD.Abrir()

            For Each item In LotePesadoParaRevision
                Dim idBin As Integer = Convert.ToInt32(item("ID_BIN"))
                Dim pesoNuevoBruto As Decimal = Convert.ToDecimal(item("Bruto"))
                Dim nuevaTara As Decimal = Convert.ToDecimal(item("Tara"))

                ' 🟢 Consultamos a la base de datos fresca usando el ID del bin
                Dim sql As String = "SELECT b.recepciones_id, p.nombre AS producto, v.nombre AS variedad, " &
                                "c.nombre AS calibre, b.kilos_brutos, b.tipos_contenedores_id " &
                                "FROM contenedores b " &
                                "LEFT JOIN productos p ON b.productos_id = p.id " &
                                "LEFT JOIN variedades v ON b.variedades_id = v.id " &
                                "LEFT JOIN calibres c ON b.calibres_id = c.id " &
                                "WHERE b.id = @idBin"

                Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                    cmd.Parameters.AddWithValue("@idBin", idBin)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim pesoOrigenBruto As Decimal = Convert.ToDecimal(reader("kilos_brutos"))
                            Dim diferencia As Decimal = pesoOrigenBruto - pesoNuevoBruto

                            ' Guardamos la diferencia en el diccionario para cuando se pulse "Guardar"
                            item("Diferencia") = diferencia.ToString()
                            item("ID_ORIGINAL_CONTENEDOR") = reader("tipos_contenedores_id").ToString()

                            ' Agregamos los 11 valores exactos a la grilla
                            dt.Rows.Add(
                            idBin,
                            reader("recepciones_id").ToString(),
                            reader("producto").ToString(),
                            reader("variedad").ToString(),
                            reader("calibre").ToString(),
                            nuevaTara,
                            pesoOrigenBruto,
                            pesoNuevoBruto,
                            diferencia,
                            "PESADO",
                            Convert.ToInt32(reader("tipos_contenedores_id"))
                        )
                        End If
                    End Using
                End Using
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos del bin: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        dgvResumen.DataSource = dt
        FormatearGrillaVisual()
    End Sub

    ' 🟢 2. APLICAR FORMATO VISUAL SOLICITADO
    Private Sub FormatearGrillaVisual()
        With dgvResumen
            .AllowUserToAddRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

            ' Configuración de Columnas (Formato solicitado)
            .Columns("id").Visible = True
            .Columns("id").HeaderText = "N° BINS"
            .Columns("id").DisplayIndex = 0

            .Columns("tipos_contenedores_id").Visible = False

            .Columns("recepcion").HeaderText = "RECEPCION"
            .Columns("producto").HeaderText = "PRODUCTO"
            .Columns("variedad").HeaderText = "VARIEDAD"
            .Columns("calibre").HeaderText = "CALIBRE"

            .Columns("tara").HeaderText = "TARA"
            .Columns("tara").DefaultCellStyle.Format = "N2"

            .Columns("kilos_origen").HeaderText = "PESO ORIGEN" ' Bruto anterior
            .Columns("kilos_origen").DefaultCellStyle.Format = "N2"
            .Columns("kilos_origen").DefaultCellStyle.ForeColor = Color.Blue

            .Columns("kilos_actuales").HeaderText = "PESO ACTUAL" ' Bruto nuevo
            .Columns("kilos_actuales").DefaultCellStyle.Format = "N2"
            .Columns("kilos_actuales").DefaultCellStyle.Font = New Font(dgvResumen.Font, FontStyle.Bold)

            .Columns("diferencia").HeaderText = "DIFERENCIA" ' Merma
            .Columns("diferencia").DefaultCellStyle.Format = "N2"

            ' Pintar diferencia si es negativa (ganancia peso) o positiva (merma)
            ' Aquí asumimos que Diferencia = Origen - Actual. Si es > 0 es pérdida (Merma).
            .Columns("diferencia").DefaultCellStyle.ForeColor = Color.Red

            .Columns("estado").HeaderText = "ESTADO"
        End With
    End Sub

    ' 🟢 3. BOTÓN CONFIRMAR: ENVÍA DATOS AL ORQUESTADOR PARA GUARDAR FÍSICAMENTE
    Private Sub btnConfirmarYGuardar_Click(sender As Object, e As EventArgs) Handles btnConfirmarYGuardar.Click
        If dgvResumen.Rows.Count = 0 Then Return

        Dim result As DialogResult = MessageBox.Show("¿Está seguro de guardar los nuevos pesos y aplicar mermas en la base de datos?",
                                                   "Confirmación Final", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            GuardarRepesajeEnB()
        End If
    End Sub

    ' 🟢 4. PROCESO TRANSACCIONAL DE GUARDADO
    Private Sub GuardarRepesajeEnB()
        Try
            ConexionBD.Abrir()
            Using trx As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                Try
                    ' Recorremos las filas de la grilla que armamos previamente
                    For Each fila As DataGridViewRow In dgvResumen.Rows
                        Dim idBin As Integer = Convert.ToInt32(fila.Cells("id").Value)
                        Dim kilosOrigen As Decimal = Convert.ToDecimal(fila.Cells("kilos_origen").Value)
                        Dim kilosNuevosBruto As Decimal = Convert.ToDecimal(fila.Cells("kilos_actuales").Value)
                        Dim diferencia As Decimal = Convert.ToDecimal(fila.Cells("diferencia").Value)

                        Dim tipoContenedorId As Integer = Convert.ToInt32(fila.Cells("tipos_contenedores_id").Value)
                        Dim taraEnvase As Decimal = Convert.ToDecimal(fila.Cells("tara").Value)

                        ' Cálculo dinámico del Neto
                        Dim kilosNuevosNeto As Decimal = kilosNuevosBruto - taraEnvase

                        ' A. UPDATE contenedores: Designamos la ubicación a 'patio proceso' (2) y estado 'En Proceso' (2)
                        Dim sqlUpdContenedor As String = "UPDATE contenedores SET tipos_ubicaciones_id = 2, estados_contenedores_id = 2, kilos_brutos = @bruto, kilos_netos = @neto, updated_at= NOW() WHERE id = @idBin"
                        Using cmd As New MySqlCommand(sqlUpdContenedor, ConexionBD.conexion, trx)
                            cmd.Parameters.AddWithValue("@bruto", kilosNuevosBruto)
                            cmd.Parameters.AddWithValue("@neto", kilosNuevosNeto)
                            cmd.Parameters.AddWithValue("@idBin", idBin)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' B. INSERT contenedores_historial (Re-pesaje: tipos_movimientos_id = 7, estados_contenedores_id = 16)
                        Dim sqlHistRepesaje As String = "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, tipos_ubicaciones_id, kilos_brutos, kilos_netos, estados_contenedores_id, fecha_movimiento, users_id) VALUES (7, @tipoContenedor, @idBin, 4, @bruto, @neto, 16, NOW(), 1)"
                        Using cmd As New MySqlCommand(sqlHistRepesaje, ConexionBD.conexion, trx)
                            cmd.Parameters.AddWithValue("@tipoContenedor", tipoContenedorId)
                            cmd.Parameters.AddWithValue("@idBin", idBin)
                            cmd.Parameters.AddWithValue("@bruto", kilosNuevosBruto)
                            cmd.Parameters.AddWithValue("@neto", kilosNuevosNeto)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' C. INSERT Merma (Solo si hay diferencia positiva. Movimiento = 8, Ubicacion = 10, Estado = 13)
                        If diferencia > 0 Then
                            Dim sqlMerma As String = "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, tipos_ubicaciones_id, kilos_brutos, kilos_netos, estados_contenedores_id, fecha_movimiento, users_id) VALUES (8, @tipoContenedor, @idBin, 10, @dif, @dif, 13, NOW(), 1)"
                            Using cmd As New MySqlCommand(sqlMerma, ConexionBD.conexion, trx)
                                cmd.Parameters.AddWithValue("@tipoContenedor", tipoContenedorId)
                                cmd.Parameters.AddWithValue("@idBin", idBin)
                                cmd.Parameters.AddWithValue("@dif", diferencia)
                                cmd.ExecuteNonQuery()
                            End Using
                        End If

                        ' D. INSERT contenedores_historial (Traslado: tipos_movimientos_id = 2, estados_contenedores_id = 2, ubicacion = 2)
                        Dim sqlHistTraslado As String = "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, tipos_ubicaciones_id, kilos_brutos, kilos_netos, estados_contenedores_id, fecha_movimiento, users_id) VALUES (2, @tipoContenedor, @idBin, 2, @bruto, @neto, 2, NOW(), 1)"
                        Using cmd As New MySqlCommand(sqlHistTraslado, ConexionBD.conexion, trx)
                            cmd.Parameters.AddWithValue("@tipoContenedor", tipoContenedorId)
                            cmd.Parameters.AddWithValue("@idBin", idBin)
                            cmd.Parameters.AddWithValue("@bruto", kilosNuevosBruto)
                            cmd.Parameters.AddWithValue("@neto", kilosNuevosNeto)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' E. UPDATE procesos_bines_origen (Modificamos para el nuevo sistema de paletizado)
                        Dim sqlUpdOrdenDetalle As String = "UPDATE procesos_bines_origen SET estados_bines_id = 3, fecha_registro = NOW() WHERE contenedores_id = @idBin AND estado = 1"
                        Using cmd As New MySqlCommand(sqlUpdOrdenDetalle, ConexionBD.conexion, trx)
                            cmd.Parameters.AddWithValue("@idBin", idBin)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    trx.Commit()
                    MessageBox.Show($"Se actualizaron {dgvResumen.Rows.Count} bines y sus historiales correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Avisar al orquestador padre que el proceso terminó con éxito para que limpie o cierre la pantalla
                    RaiseEvent SolicitarGuardadoFinal(LotePesadoParaRevision)

                Catch ex As Exception
                    trx.Rollback() ' Si cualquier insert/update falla, se deshace todo
                    MessageBox.Show("Error durante la transacción. Se han revertido los cambios:" & vbCrLf & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión al intentar guardar: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        RaiseEvent ProcesoCancelado()
    End Sub
End Class