Imports MySql.Data.MySqlClient

Public Class ucReproceso

    ' Tablas en memoria para manejar el paso de datos entre grillas
    Private dtOrigen As New DataTable()
    Private dtReprocesar As New DataTable()

    Private Sub ucReproceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarTablas()
        CargarComboProcesos()
    End Sub

    ' --- 1. CONFIGURACIÓN DE TABLAS Y GRILLAS ---
    Private Sub ConfigurarTablas()
        ' Se añaden recepciones_id y kilos_brutos de forma interna para usarlos al registrar el historial y origen
        Dim columnas As String() = {"id", "recepciones_id", "persona", "tipo", "producto", "variedad", "calibre", "kilos_brutos", "kilos_netos"}

        For Each col In columnas
            dtOrigen.Columns.Add(col, GetType(String))
            dtReprocesar.Columns.Add(col, GetType(String))
        Next

        ' Vinculamos a los DataGridView
        dgvOrigen.DataSource = dtOrigen
        dgvReprocesar.DataSource = dtReprocesar

        dgvOrigen.AllowUserToAddRows = False
        dgvOrigen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReprocesar.AllowUserToAddRows = False
        dgvReprocesar.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Opcional: Ocultar columnas técnicas que el usuario no necesita ver en pantalla pero sí usar en código
        If dgvOrigen.Columns("recepciones_id") IsNot Nothing Then dgvOrigen.Columns("recepciones_id").Visible = False
        If dgvOrigen.Columns("kilos_brutos") IsNot Nothing Then dgvOrigen.Columns("kilos_brutos").Visible = False
        If dgvReprocesar.Columns("recepciones_id") IsNot Nothing Then dgvReprocesar.Columns("recepciones_id").Visible = False
        If dgvReprocesar.Columns("kilos_brutos") IsNot Nothing Then dgvReprocesar.Columns("kilos_brutos").Visible = False
    End Sub

    ' --- 2. CARGAR COMBOS Y GRILLA DE ORIGEN ---
    Private Sub CargarComboProcesos()
        Dim dtProcesos As New DataTable()

        Try
            ConexionBD.Abrir()
            Dim query As String = "SELECT a.id, CONCAT(a.id, ' - ', tr.tipo, ': ', c.nombre, ' (', DATE_FORMAT(a.created_at, '%d-%m-%Y'), ')') AS nombre FROM procesos a " &
                                  "INNER JOIN recepciones b ON a.recepciones_id = b.id " &
                                  "INNER JOIN personas c ON b.personas_id = c.id " &
                                  "INNER JOIN tipos_recepciones tr ON b.tipos_recepciones_id = tr.id " &
                                  "WHERE estados_procesos_id = 2 AND b.tipos_recepciones_id NOT IN (3, 4, 8) ORDER BY a.recepciones_id DESC;"

            Using cmd As New MySqlCommand(query, ConexionBD.conexion)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtProcesos)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar procesos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        cmbProceso.DisplayMember = "nombre"
        cmbProceso.ValueMember = "id"
        cmbProceso.DataSource = dtProcesos
        cmbProceso.SelectedIndex = -1
    End Sub

    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        If cmbProceso.SelectedValue IsNot Nothing Then
            Dim idProceso As Integer
            If Integer.TryParse(cmbProceso.SelectedValue.ToString(), idProceso) Then
                CargarBinesOrigen(idProceso)
            End If
        End If
    End Sub

    Private Sub CargarBinesOrigen(idProceso As Integer)
        dtOrigen.Clear()
        dtReprocesar.Clear()

        Try
            ConexionBD.Abrir()
            ' Se consultan también recepciones_id y kilos_brutos necesarios para el reproceso e historial
            Dim query As String = "SELECT a.id, a.recepciones_id, g.nombre AS persona, tr.tipo AS tipo, e.nombre AS producto, f.nombre AS variedad, d.nombre AS calibre, a.kilos_brutos, a.kilos_netos AS kilos_netos FROM " &
                                  " contenedores a " &
                                  " INNER JOIN recepciones b ON a.recepciones_id = b.id " &
                                  " INNER JOIN tipos_recepciones tr ON b.tipos_recepciones_id = tr.id " &
                                  " INNER JOIN procesos_recepciones pr ON b.id = pr.recepciones_id " &
                                  " INNER JOIN procesos c ON pr.procesos_id = c.id " &
                                  " INNER JOIN calibres d ON a.calibres_id = d.id " &
                                  " INNER JOIN productos e ON a.productos_id = e.id " &
                                  " INNER JOIN variedades f ON a.variedades_id = f.id " &
                                  " INNER JOIN personas g ON b.personas_id = g.id " &
                                  " WHERE c.id = @idProceso AND c.estados_procesos_id = 2 AND d.estados_calibres_id = 1; "

            Using cmd As New MySqlCommand(query, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idProceso", idProceso)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtOrigen)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los contenedores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- 3. MOVER CONTENEDORES ENTRE GRILLAS ---
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        MoverFilas(dgvOrigen, dtOrigen, dtReprocesar)
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        MoverFilas(dgvReprocesar, dtReprocesar, dtOrigen)
    End Sub

    Private Sub MoverFilas(gridOrigen As DataGridView, tablaOrigen As DataTable, tablaDestino As DataTable)
        If gridOrigen.SelectedRows.Count = 0 Then Return

        Dim filasAMover As New List(Of DataRowView)
        For Each row As DataGridViewRow In gridOrigen.SelectedRows
            filasAMover.Add(DirectCast(row.DataBoundItem, DataRowView))
        Next

        For Each drv In filasAMover
            tablaDestino.ImportRow(drv.Row)
            tablaOrigen.Rows.Remove(drv.Row)
        Next

        tablaOrigen.AcceptChanges()
        tablaDestino.AcceptChanges()
    End Sub

    ' --- 4. CREAR EL REPROCESO ---
    Private Sub btnCrearReProceso_Click(sender As Object, e As EventArgs) Handles btnCrearReProceso.Click
        If dtReprocesar.Rows.Count = 0 Then
            MessageBox.Show("No hay contenedores seleccionados para reprocesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim binesProcesados As Integer = 0
        Dim procesoExitoso As Boolean = False
        Dim idReprocesoGenerado As Integer = 0

        Try
            ConexionBD.Abrir()

            Using transaction As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                Try
                    ' 1. Insertar encabezado de reproceso y recuperar el ID generado automáticamente
                    Dim sqlCabecera As String = "INSERT INTO reprocesos (fecha) VALUES (NOW()); SELECT LAST_INSERT_ID();"
                    Using cmdCabecera As New MySqlCommand(sqlCabecera, ConexionBD.conexion, transaction)
                        idReprocesoGenerado = Convert.ToInt32(cmdCabecera.ExecuteScalar())
                    End Using

                    ' 2. Definición de consultas individuales por cada bin (Apuntando directamente al ID del contenedor)
                    Dim sqlDetalle As String = "INSERT INTO reprocesos_bines_origen (reprocesos_id, recepciones_id, contenedores_id, estados_bines_id, fecha, estado) VALUES (@reprocesos_id, @recepciones_id, @contenedores_id, 1 ,NOW(), 1);"    ' estados_bines_id : 1 (pendiente) debería cambiar a procesado con la app Flutter
                    Dim sqlUpdateContenedor As String = "UPDATE contenedores SET estados_contenedores_id = 18, tipos_ubicaciones_id = 2 WHERE id = @contenedores_id;"
                    Dim sqlHistorial As String = "INSERT INTO contenedores_historial (contenedores_id, tipos_movimientos_id, tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos) VALUES (@contenedores_id, 2, 2, 18, @kilos_brutos, @kilos_netos);"

                    ' 3. Recorrer cada contenedor seleccionado en la grilla de reprocesar
                    For Each row As DataRow In dtReprocesar.Rows
                        If row.RowState = DataRowState.Deleted Then Continue For

                        Dim contenedorId As Integer = Convert.ToInt32(row("id"))
                        Dim recepcionId As Integer = Convert.ToInt32(row("recepciones_id"))
                        Dim kilosBrutos As Decimal = Convert.ToDecimal(row("kilos_brutos"))
                        Dim kilosNetos As Decimal = Convert.ToDecimal(row("kilos_netos"))

                        ' A. Insertar relación en reprocesos_bines_origen
                        Using cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, transaction)
                            cmdDetalle.Parameters.AddWithValue("@reprocesos_id", idReprocesoGenerado)
                            cmdDetalle.Parameters.AddWithValue("@recepciones_id", recepcionId)
                            cmdDetalle.Parameters.AddWithValue("@contenedores_id", contenedorId)
                            cmdDetalle.ExecuteNonQuery()
                        End Using

                        ' B. Actualizar estado y ubicación del contenedor directamente por su ID
                        Using cmdUpdate As New MySqlCommand(sqlUpdateContenedor, ConexionBD.conexion, transaction)
                            cmdUpdate.Parameters.AddWithValue("@contenedores_id", contenedorId)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' C. Registrar en historial de contenedores
                        Using cmdHistorial As New MySqlCommand(sqlHistorial, ConexionBD.conexion, transaction)
                            cmdHistorial.Parameters.AddWithValue("@contenedores_id", contenedorId)
                            cmdHistorial.Parameters.AddWithValue("@kilos_brutos", kilosBrutos)
                            cmdHistorial.Parameters.AddWithValue("@kilos_netos", kilosNetos)
                            cmdHistorial.ExecuteNonQuery()
                        End Using

                        binesProcesados += 1
                    Next

                    transaction.Commit()
                    procesoExitoso = True

                Catch exSql As Exception
                    transaction.Rollback()
                    Throw New Exception("Error durante la transacción de bines. No se guardó ningún cambio. Detalle: " & exSql.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al guardar el reproceso: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        ' 4. RECARGA Y MENSAJE POST-PROCESO
        If procesoExitoso Then
            MessageBox.Show("Se han pasado a reproceso " & binesProcesados & " bines correctamente." & vbCrLf &
                            "ID de Reproceso Generado: " & idReprocesoGenerado, "Proceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dtReprocesar.Clear()
            If cmbProceso.SelectedValue IsNot Nothing Then
                Dim idProceso As Integer
                If Integer.TryParse(cmbProceso.SelectedValue.ToString(), idProceso) Then
                    CargarBinesOrigen(idProceso)
                End If
            End If
        End If
    End Sub

End Class