Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Cursor

Public Class ucNuevoProceso

    Private dtRecepciones As DataTable

    Private Sub ucNuevoProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Configurar las columnas del DataGridView manualmente
        ConfigurarDataGridView()

        ' 2. Cargar los datos en el ComboBox usando tu consulta SQL
        ' Se agregó CONCAT para mostrar "N° ID - Nombre" en el combobox
        ' Se agregó c.nombre al GROUP BY para evitar errores de sintaxis en MySQL
        Dim sql As String = "SELECT a.id, CONCAT('N° ', a.id, ' - ', c.nombre) AS display_name, " &
                            "d.tipo, c.nombre AS persona, count(b.id) AS contenedores, " &
                            "sum(b.kilos_brutos) AS kilos_brutos, sum(b.kilos_netos) AS kilos_netos " &
                            "FROM recepciones a " &
                            "INNER JOIN contenedores b ON a.id = b.recepciones_id " &
                            "INNER JOIN personas c ON a.personas_id = c.id " &
                            "INNER JOIN tipos_recepciones d ON a.tipos_recepciones_id = d.id " &
                            "WHERE a.estados_recepciones_id = 2 " &
                            "GROUP BY a.id, d.tipo, c.nombre;"

        dtRecepciones = ObtenerDatos(sql)

        ' 3. Llenar el ComboBox
        cmbRecepciones.DataSource = dtRecepciones
        cmbRecepciones.DisplayMember = "display_name"
        cmbRecepciones.ValueMember = "id"
        cmbRecepciones.SelectedIndex = -1
    End Sub

    Private Sub ConfigurarDataGridView()
        dgvRecepciones.Columns.Clear()
        dgvRecepciones.AllowUserToAddRows = False
        dgvRecepciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecepciones.ReadOnly = True ' Evitar que el usuario edite las celdas a mano

        dgvRecepciones.Columns.Add("id", "N° Recepción")
        dgvRecepciones.Columns.Add("tipo", "Tipo")
        dgvRecepciones.Columns.Add("persona", "Productor/Persona")
        dgvRecepciones.Columns.Add("contenedores", "Contenedores")
        dgvRecepciones.Columns.Add("kilos_brutos", "Kilos Brutos")
        dgvRecepciones.Columns.Add("kilos_netos", "Kilos Netos")
    End Sub

    ' =======================================================
    ' EVENTO: AGREGAR AL DATAGRIDVIEW
    ' =======================================================
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Validar que haya algo seleccionado
        If cmbRecepciones.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione una recepción de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Obtener la fila de datos seleccionada en el ComboBox
        Dim filaSeleccionada As DataRowView = DirectCast(cmbRecepciones.SelectedItem, DataRowView)
        Dim idRecepcion As Integer = Convert.ToInt32(filaSeleccionada("id"))

        ' Validar que no se haya agregado ya al DataGridView
        For Each row As DataGridViewRow In dgvRecepciones.Rows
            If Convert.ToInt32(row.Cells("id").Value) = idRecepcion Then
                MessageBox.Show("Esta recepción ya fue agregada a la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' Agregar los datos al DataGridView
        dgvRecepciones.Rows.Add(
            idRecepcion,
            filaSeleccionada("tipo").ToString(),
            filaSeleccionada("persona").ToString(),
            filaSeleccionada("contenedores").ToString(),
            filaSeleccionada("kilos_brutos").ToString(),
            filaSeleccionada("kilos_netos").ToString()
        )

        ' Opcional: Limpiar la selección del combo tras agregar
        cmbRecepciones.SelectedIndex = -1
    End Sub

    ' =======================================================
    ' EVENTO: QUITAR DEL DATAGRIDVIEW
    ' =======================================================
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If dgvRecepciones.SelectedRows.Count > 0 Then
            ' Eliminar la fila seleccionada
            dgvRecepciones.Rows.Remove(dgvRecepciones.SelectedRows(0))
        Else
            MessageBox.Show("Seleccione una fila en la grilla para quitarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' =======================================================
    ' EVENTO: REGISTRAR (TRANSACCIÓN DB)
    ' =======================================================
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        ' 1. Validación: Que haya al menos una recepción en la grilla
        If dgvRecepciones.Rows.Count = 0 Then
            MessageBox.Show("Debe agregar al menos una recepción a la lista antes de registrar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            ConexionBD.Abrir()
            Dim sqlValidacion As String = "SELECT COUNT(*) FROM procesos WHERE estados_procesos_id = 1"
            Dim conteoAbiertas As Integer = Convert.ToInt32(ConexionBD.EjecutarEscalar(sqlValidacion))

            If conteoAbiertas > 0 Then
                MessageBox.Show("Existe un Proceso 'Abierto'. Debe cerrarlo antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show("Error al validar procesos abiertos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            ConexionBD.Cerrar()
        End Try

        btnRegistrar.Enabled = False
        btnRegistrar.Text = "Procesando..."

        Dim frm = TryCast(Me.FindForm(), Form1)
        If frm Is Nothing Then frm = TryCast(Application.OpenForms("Form1"), Form1)

        Try
            ConexionBD.Abrir()
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' PASO A: CREAR EL PROCESO
                    Dim sqlProceso As String = "INSERT INTO procesos (fecha, hora, estados_procesos_id, users_id, created_at, updated_at) " &
                                               "VALUES (CURDATE(), CURTIME(), 1, 1, NOW(), NOW()); " &
                                               "SELECT LAST_INSERT_ID();"

                    Dim nuevoIdProceso As Integer
                    Using cmdProceso As New MySqlCommand(sqlProceso, ConexionBD.conexion, transaccion)
                        nuevoIdProceso = Convert.ToInt32(cmdProceso.ExecuteScalar())
                    End Using

                    ' PASO B: ITERAR POR CADA FILA DEL DATAGRIDVIEW
                    Dim sqlDetalle As String =
                        "INSERT INTO procesos_recepciones (procesos_id, recepciones_id, created_at, updated_at) " &
                        "VALUES (@idProceso, @idRecepcion, NOW(), NOW()); " &
                        "UPDATE recepciones SET estados_recepciones_id = 3, updated_at = NOW() WHERE id = @idRecepcion; " &
                        "UPDATE contenedores SET estados_contenedores_id = 2 WHERE recepciones_id = @idRecepcion; " &
                        "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
                        "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, fecha_movimiento, users_id) " &
                        "SELECT 2, tipos_contenedores_id, id, 1, 2, kilos_brutos, kilos_netos, NOW(), users_id_registro " &
                        "FROM contenedores WHERE recepciones_id = @idRecepcion;"

                    Using cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, transaccion)
                        cmdDetalle.Parameters.Add("@idProceso", MySqlDbType.Int32).Value = nuevoIdProceso
                        cmdDetalle.Parameters.Add("@idRecepcion", MySqlDbType.Int32)

                        ' Recorremos las filas del DataGridView
                        For Each row As DataGridViewRow In dgvRecepciones.Rows
                            Dim idRecepcionFila As Integer = Convert.ToInt32(row.Cells("id").Value)

                            cmdDetalle.Parameters("@idRecepcion").Value = idRecepcionFila
                            cmdDetalle.ExecuteNonQuery()
                        Next
                    End Using

                    transaccion.Commit()
                    MessageBox.Show($"¡Proceso N° {nuevoIdProceso} creado con éxito y asociado a {dgvRecepciones.Rows.Count} recepción(es)!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If frm IsNot Nothing Then
                        frm.IdRecepcionGlobal = nuevoIdProceso.ToString()
                    End If

                    ' Limpiar todo para un nuevo ingreso
                    dgvRecepciones.Rows.Clear()

                Catch ex As Exception
                    transaccion.Rollback()
                    MessageBox.Show("Error en la transacción DB: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
            btnRegistrar.Enabled = True
            btnRegistrar.Text = "Registrar"
        End Try
    End Sub
End Class