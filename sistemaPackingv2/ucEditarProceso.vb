Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class ucEditarProceso

    ' Variable para almacenar el ID del proceso que estamos editando
    Private _idProceso As Integer

    ' Constructor personalizado que recibe el ID del Proceso
    Public Sub New(idProceso As Integer)
        InitializeComponent()
        _idProceso = idProceso
    End Sub

    Private Sub ucEditarProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = $"Editando Proceso N° {_idProceso}"
        ConfigurarDataGridView()

        ' Cargar datos iniciales
        CargarRecepcionesDisponibles()
        CargarRecepcionesActuales()
    End Sub

    Private Sub ConfigurarDataGridView()
        dgvRecepcionesActuales.Columns.Clear()
        dgvRecepcionesActuales.AllowUserToAddRows = False
        dgvRecepcionesActuales.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecepcionesActuales.ReadOnly = True

        dgvRecepcionesActuales.Columns.Add("id", "N° Recepción")
        dgvRecepcionesActuales.Columns.Add("tipo", "Tipo")
        dgvRecepcionesActuales.Columns.Add("persona", "Productor/Persona")
        dgvRecepcionesActuales.Columns.Add("contenedores", "Contenedores")
        dgvRecepcionesActuales.Columns.Add("kilos_brutos", "Kilos Brutos")
    End Sub

    ' =====================================================================
    ' CARGAR DATOS
    ' =====================================================================
    Private Sub CargarRecepcionesDisponibles()
        ' Carga las recepciones que están en estado 2 (Disponibles)
        Dim sql As String = "SELECT a.id, CONCAT('N° ', a.id, ' - ', c.nombre) AS display_name " &
                            "FROM recepciones a " &
                            "INNER JOIN personas c ON a.personas_id = c.id " &
                            "WHERE a.estados_recepciones_id = 2"

        Dim dt As DataTable = ObtenerDatos(sql)
        cmbRecepcionesDisponibles.DataSource = dt
        cmbRecepcionesDisponibles.DisplayMember = "display_name"
        cmbRecepcionesDisponibles.ValueMember = "id"
        cmbRecepcionesDisponibles.SelectedIndex = -1
    End Sub

    Private Sub CargarRecepcionesActuales()
        ' Carga las recepciones que YA pertenecen a este proceso
        Dim sql As String =
            "SELECT r.id, t.tipo, p.nombre AS persona, COUNT(c.id) AS contenedores, SUM(c.kilos_brutos) AS kilos_brutos " &
            "FROM procesos_recepciones pr " &
            "INNER JOIN recepciones r ON pr.recepciones_id = r.id " &
            "INNER JOIN personas p ON r.personas_id = p.id " &
            "INNER JOIN tipos_recepciones t ON r.tipos_recepciones_id = t.id " &
            "INNER JOIN contenedores c ON r.id = c.recepciones_id " &
            "WHERE pr.procesos_id = " & _idProceso & " " &
            "GROUP BY r.id, t.tipo, p.nombre;"

        Dim dt As DataTable = ObtenerDatos(sql)

        dgvRecepcionesActuales.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgvRecepcionesActuales.Rows.Add(row("id"), row("tipo"), row("persona"), row("contenedores"), row("kilos_brutos"))
        Next
    End Sub

    ' =====================================================================
    ' AGREGAR RECEPCIÓN AL PROCESO
    ' =====================================================================
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbRecepcionesDisponibles.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione una recepción disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim idRecepcion As Integer = Convert.ToInt32(cmbRecepcionesDisponibles.SelectedValue)

        Try
            ConexionBD.Abrir()
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    Dim sqlDetalle As String =
                        "INSERT INTO procesos_recepciones (procesos_id, recepciones_id, created_at, updated_at) " &
                        "VALUES (@idProceso, @idRecepcion, NOW(), NOW()); " &
                        "UPDATE recepciones SET estados_recepciones_id = 3, updated_at = NOW() WHERE id = @idRecepcion; " &
                        "UPDATE contenedores SET estados_contenedores_id = 2 WHERE recepciones_id = @idRecepcion; " &
                        "INSERT INTO contenedores_historial (tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
                        "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, fecha_movimiento, users_id) " &
                        "SELECT 2, tipos_contenedores_id, id, 1, 2, kilos_brutos, kilos_netos, NOW(), users_id_registro " &
                        "FROM contenedores WHERE recepciones_id = @idRecepcion;"

                    Using cmd As New MySqlCommand(sqlDetalle, ConexionBD.conexion, transaccion)
                        cmd.Parameters.AddWithValue("@idProceso", _idProceso)
                        cmd.Parameters.AddWithValue("@idRecepcion", idRecepcion)
                        cmd.ExecuteNonQuery()
                    End Using

                    transaccion.Commit()
                    MessageBox.Show("Recepción agregada al proceso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Recargar listas
                    CargarRecepcionesDisponibles()
                    CargarRecepcionesActuales()

                Catch ex As Exception
                    transaccion.Rollback()
                    MessageBox.Show("Error al agregar: " & ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' =====================================================================
    ' QUITAR RECEPCIÓN DEL PROCESO (REVERTIR)
    ' =====================================================================
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If dgvRecepcionesActuales.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una recepción de la grilla para quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim idRecepcion As Integer = Convert.ToInt32(dgvRecepcionesActuales.SelectedRows(0).Cells("id").Value)

        If MessageBox.Show($"¿Quitar la Recepción N° {idRecepcion} del proceso? Volverá a estar disponible.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()
                Using transaccion = ConexionBD.conexion.BeginTransaction()
                    Try
                        ' 1. Borrar de la tabla intermedia
                        Dim sqlDelete As String = "DELETE FROM procesos_recepciones WHERE procesos_id = @idProceso AND recepciones_id = @idRecepcion;"
                        ' 2. Revertir recepción al estado 2 (Pendiente)
                        Dim sqlUpdateRec As String = "UPDATE recepciones SET estados_recepciones_id = 2 WHERE id = @idRecepcion;"
                        ' 3. Revertir contenedores al estado 1 (Si estado 1 es disponible/ingresado)
                        Dim sqlUpdateCont As String = "UPDATE contenedores SET estados_contenedores_id = 1 WHERE recepciones_id = @idRecepcion;"

                        Using cmd As New MySqlCommand(sqlDelete & sqlUpdateRec & sqlUpdateCont, ConexionBD.conexion, transaccion)
                            cmd.Parameters.AddWithValue("@idProceso", _idProceso)
                            cmd.Parameters.AddWithValue("@idRecepcion", idRecepcion)
                            cmd.ExecuteNonQuery()
                        End Using

                        transaccion.Commit()
                        MessageBox.Show("Recepción retirada del proceso correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Recargar listas
                        CargarRecepcionesDisponibles()
                        CargarRecepcionesActuales()
                    Catch ex As Exception
                        transaccion.Rollback()
                        MessageBox.Show("Error al quitar: " & ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Error de conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If
    End Sub

    ' =====================================================================
    ' BOTÓN VOLVER
    ' =====================================================================
    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim frm = TryCast(Me.FindForm(), Form1)
        If frm IsNot Nothing Then
            ' Navegar de vuelta al menú de Procesos (Ajusta ucProcesoEstado si se llama distinto)
            frm.NavegarA(New ucProcesoEstado())
        End If
    End Sub

End Class