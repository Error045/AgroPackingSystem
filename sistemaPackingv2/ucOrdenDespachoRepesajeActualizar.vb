Imports MySql.Data.MySqlClient

Public Class ucOrdenDespachoRepesajeActualizar
        Inherits System.Windows.Forms.UserControl

        Private LotePesadoParaRevision As List(Of Dictionary(Of String, String))

        Public Event SolicitarGuardadoFinal(datosFinales As List(Of Dictionary(Of String, String)))
        Public Event ProcesoCancelado()

        Public Sub RecibirDatosParaRevision(lote As List(Of Dictionary(Of String, String)))
            LotePesadoParaRevision = lote
            ArmarTablaComparativaDesdeBD()
        End Sub

        Private Sub ArmarTablaComparativaDesdeBD()
            dgvResumen.DataSource = Nothing
            dgvResumen.Columns.Clear()

            Dim dt As New DataTable()
            dt.Columns.Add("id", GetType(Integer))
            dt.Columns.Add("despacho", GetType(String))
            dt.Columns.Add("numero_cajas", GetType(Integer))
            dt.Columns.Add("tara", GetType(Decimal))
            dt.Columns.Add("kilos_origen", GetType(Decimal))
            dt.Columns.Add("kilos_actuales", GetType(Decimal))
            dt.Columns.Add("diferencia", GetType(Decimal))
            dt.Columns.Add("estado", GetType(String))

            ' Columnas ocultas necesarias para el historial
            dt.Columns.Add("tipos_contenedores_id", GetType(Integer))
            dt.Columns.Add("procesos_paletizado_id", GetType(Integer))
            dt.Columns.Add("tipos_ubicaciones_id", GetType(Integer))
            dt.Columns.Add("capacidad", GetType(Integer))
            dt.Columns.Add("estados_contenedores_id", GetType(Integer))
            dt.Columns.Add("estados_progresos_pallets_id", GetType(Integer))

            Try
                ConexionBD.Abrir()

                For Each item In LotePesadoParaRevision
                    Dim idPallet As Integer = Convert.ToInt32(item("ID_PALLET"))
                    Dim pesoNuevoBruto As Decimal = Convert.ToDecimal(item("Bruto"))
                    Dim nuevaTara As Decimal = Convert.ToDecimal(item("Tara"))

                    ' Traemos datos completos del pallet para llenar el historial
                    Dim sql As String = "SELECT a.id, c.id AS despacho, a.numero_cajas, a.kilos_brutos, " &
                                        "a.tipos_contenedores_id, a.procesos_paletizado_id, a.tipos_ubicaciones_id, " &
                                        "a.capacidad, a.estados_contenedores_id, a.estados_progresos_pallets_id " &
                                        "FROM pallets a " &
                                        "JOIN despachos_pallets b ON a.id = b.pallets_id " &
                                        "JOIN despachos c ON b.despachos_id = c.id " &
                                        "WHERE a.id = @idPallet"

                    Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                        cmd.Parameters.AddWithValue("@idPallet", idPallet)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim pesoOrigenBruto As Decimal = Convert.ToDecimal(reader("kilos_brutos"))
                                Dim diferencia As Decimal = pesoOrigenBruto - pesoNuevoBruto

                                item("Diferencia") = diferencia.ToString()
                                item("ID_ORIGINAL_CONTENEDOR") = reader("tipos_contenedores_id").ToString()

                                dt.Rows.Add(
                                    idPallet,
                                    reader("despacho").ToString(),
                                    Convert.ToInt32(reader("numero_cajas")),
                                    nuevaTara,
                                    pesoOrigenBruto,
                                    pesoNuevoBruto,
                                    diferencia,
                                    "PESADO",
                                    Convert.ToInt32(reader("tipos_contenedores_id")),
                                    Convert.ToInt32(reader("procesos_paletizado_id")),
                                    Convert.ToInt32(reader("tipos_ubicaciones_id")),
                                    Convert.ToInt32(reader("capacidad")),
                                    Convert.ToInt32(reader("estados_contenedores_id")),
                                    Convert.ToInt32(reader("estados_progresos_pallets_id"))
                                )
                            End If
                        End Using
                    End Using
                Next
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos del pallet: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try

            dgvResumen.DataSource = dt
            FormatearGrillaVisual()
        End Sub

        Private Sub FormatearGrillaVisual()
            With dgvResumen
                .AllowUserToAddRows = False
                .ReadOnly = True
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

                ' Ocultar columnas técnicas de historial
                .Columns("tipos_contenedores_id").Visible = False
                .Columns("procesos_paletizado_id").Visible = False
                .Columns("tipos_ubicaciones_id").Visible = False
                .Columns("capacidad").Visible = False
                .Columns("estados_contenedores_id").Visible = False
                .Columns("estados_progresos_pallets_id").Visible = False

                .Columns("id").HeaderText = "N° PALLET"
                .Columns("despacho").HeaderText = "N° DESPACHO"
                .Columns("numero_cajas").HeaderText = "CAJAS"

                .Columns("tara").HeaderText = "TARA"
                .Columns("tara").DefaultCellStyle.Format = "N2"

                .Columns("kilos_origen").HeaderText = "PESO ORIGEN"
                .Columns("kilos_origen").DefaultCellStyle.Format = "N2"
                .Columns("kilos_origen").DefaultCellStyle.ForeColor = Color.Blue

                .Columns("kilos_actuales").HeaderText = "PESO ACTUAL"
                .Columns("kilos_actuales").DefaultCellStyle.Format = "N2"
                .Columns("kilos_actuales").DefaultCellStyle.Font = New Font(dgvResumen.Font, FontStyle.Bold)

                .Columns("diferencia").HeaderText = "DIFERENCIA"
                .Columns("diferencia").DefaultCellStyle.Format = "N2"
                .Columns("diferencia").DefaultCellStyle.ForeColor = Color.Red

                .Columns("estado").HeaderText = "ESTADO"
            End With
        End Sub

        Private Sub btnConfirmarYGuardar_Click(sender As Object, e As EventArgs) Handles btnConfirmarYGuardar.Click
            If dgvResumen.Rows.Count = 0 Then Return

            Dim result As DialogResult = MessageBox.Show("¿Está seguro de guardar los nuevos pesos y registrar los historiales de los pallets?",
                                                         "Confirmación Final", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                GuardarRepesajeEnB()
            End If
        End Sub

        Private Sub GuardarRepesajeEnB()
            Try
                ConexionBD.Abrir()
                Using trx As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                    Try
                        For Each fila As DataGridViewRow In dgvResumen.Rows
                            Dim idPallet As Integer = Convert.ToInt32(fila.Cells("id").Value)
                            Dim kilosNuevosBruto As Decimal = Convert.ToDecimal(fila.Cells("kilos_actuales").Value)
                            Dim diferencia As Decimal = Convert.ToDecimal(fila.Cells("diferencia").Value)
                            Dim tipoContenedorId As Integer = Convert.ToInt32(fila.Cells("tipos_contenedores_id").Value)
                            Dim taraEnvase As Decimal = Convert.ToDecimal(fila.Cells("tara").Value)
                            Dim kilosNuevosNeto As Decimal = kilosNuevosBruto - taraEnvase

                            ' Variables técnicas para historial
                            Dim procesosPaletizadoId = Convert.ToInt32(fila.Cells("procesos_paletizado_id").Value)
                            Dim tiposUbicacionesId = Convert.ToInt32(fila.Cells("tipos_ubicaciones_id").Value)
                            Dim capacidad = Convert.ToInt32(fila.Cells("capacidad").Value)
                            Dim nCajas = Convert.ToInt32(fila.Cells("numero_cajas").Value)
                            Dim estadosContId = Convert.ToInt32(fila.Cells("estados_contenedores_id").Value)
                            Dim estadosProgId = Convert.ToInt32(fila.Cells("estados_progresos_pallets_id").Value)
                            Dim userId As Integer = 1 ' Puedes enlazarlo a tu variable global de sesión de usuario

                            ' A. UPDATE pallets
                            Dim sqlUpdPallet As String = "UPDATE pallets SET kilos_brutos = @bruto, kilos_netos = @neto WHERE id = @idPallet"
                            Using cmd As New MySqlCommand(sqlUpdPallet, ConexionBD.conexion, trx)
                                cmd.Parameters.AddWithValue("@bruto", kilosNuevosBruto)
                                cmd.Parameters.AddWithValue("@neto", kilosNuevosNeto)
                                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                                cmd.ExecuteNonQuery()
                            End Using

                            ' B. INSERT pallets_historial (Repesaje: tipos_movimientos_id = 7)
                            Dim sqlHistRepesaje As String =
                                "INSERT INTO pallets_historial (tipos_movimientos_id, procesos_paletizado_id, pallets_id, " &
                                "tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, " &
                                "capacidad, estados_contenedores_id, estados_progresos_pallets_id, users_id, estado, fecha_movimiento) " &
                                "VALUES (7, @procId, @idPallet, @tipoContId, @ubicacion, @neto, @bruto, @cajas, @capacidad, @estadoCont, @estadoProg, @userId, 1, NOW())"

                            Using cmd As New MySqlCommand(sqlHistRepesaje, ConexionBD.conexion, trx)
                                cmd.Parameters.AddWithValue("@procId", procesosPaletizadoId)
                                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                                cmd.Parameters.AddWithValue("@tipoContId", tipoContenedorId)
                                cmd.Parameters.AddWithValue("@ubicacion", tiposUbicacionesId)
                                cmd.Parameters.AddWithValue("@neto", kilosNuevosNeto)
                                cmd.Parameters.AddWithValue("@bruto", kilosNuevosBruto)
                                cmd.Parameters.AddWithValue("@cajas", nCajas)
                                cmd.Parameters.AddWithValue("@capacidad", capacidad)
                                cmd.Parameters.AddWithValue("@estadoCont", estadosContId)
                                cmd.Parameters.AddWithValue("@estadoProg", estadosProgId)
                                cmd.Parameters.AddWithValue("@userId", userId)
                                cmd.ExecuteNonQuery()
                            End Using

                            ' C. INSERT Merma en pallets_historial (Opcional, similar al anterior con mov=8)
                            If diferencia > 0 Then
                                Dim sqlMerma As String =
                                    "INSERT INTO pallets_historial (tipos_movimientos_id, procesos_paletizado_id, pallets_id, " &
                                    "tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, " &
                                    "capacidad, estados_contenedores_id, estados_progresos_pallets_id, users_id, estado, fecha_movimiento) " &
                                    "VALUES (8, @procId, @idPallet, @tipoContId, @ubicacion, @dif, @dif, @cajas, @capacidad, @estadoCont, @estadoProg, @userId, 1, NOW())"
                                Using cmd As New MySqlCommand(sqlMerma, ConexionBD.conexion, trx)
                                    ' Mismos parámetros, pero Kilos Brutos y Netos llevan el valor de "diferencia"
                                    cmd.Parameters.AddWithValue("@procId", procesosPaletizadoId)
                                    cmd.Parameters.AddWithValue("@idPallet", idPallet)
                                    cmd.Parameters.AddWithValue("@tipoContId", tipoContenedorId)
                                    cmd.Parameters.AddWithValue("@ubicacion", tiposUbicacionesId)
                                    cmd.Parameters.AddWithValue("@dif", diferencia)
                                    cmd.Parameters.AddWithValue("@cajas", nCajas)
                                    cmd.Parameters.AddWithValue("@capacidad", capacidad)
                                    cmd.Parameters.AddWithValue("@estadoCont", estadosContId)
                                    cmd.Parameters.AddWithValue("@estadoProg", estadosProgId)
                                    cmd.Parameters.AddWithValue("@userId", userId)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End If

                            ' Opcional: UPDATE sobre despachos_pallets (si necesitaras cambiar el estado a "Repesado")
                            ' Dim sqlUpdDespachoPallet As String = "UPDATE despachos_pallets SET estado = X WHERE pallets_id = @idPallet"

                        Next

                        trx.Commit()
                        MessageBox.Show($"Se actualizaron {dgvResumen.Rows.Count} pallets y sus historiales correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        RaiseEvent SolicitarGuardadoFinal(LotePesadoParaRevision)

                    Catch ex As Exception
                        trx.Rollback()
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


