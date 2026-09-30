Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class ucProcesoEstado

    Private _idProceso As Integer
    ' Variable de respaldo para el ID
    Private _idProcesoSeleccionado As Integer = 0

    ' =====================================================================
    ' 1. CARGA DE DATOS
    ' =====================================================================
    Private Sub ucProcesoEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Iconos de Botones (Segoe MDL2 Assets)
        btnVer.Font = New Font("Segoe MDL2 Assets", 14)
        btnVer.Text = ChrW(&HE7B3)
        btnVer.ForeColor = Color.Olive
        btnVer.BackColor = Color.PaleGreen

        ucEditar.Font = New Font("Segoe MDL2 Assets", 14)
        ucEditar.Text = ChrW(&HE104)
        ucEditar.ForeColor = Color.CadetBlue

        btnEliminar.Font = New Font("Segoe MDL2 Assets", 14)
        btnEliminar.Text = ChrW(&HE107)
        btnEliminar.ForeColor = Color.Red

        ' NUEVO SQL: Como un proceso tiene muchas recepciones, mostramos el ID y la fecha.
        Dim sqlProcesoEstado As String = "SELECT id, CONCAT('Proceso N° ', id, ' (Creado: ', DATE_FORMAT(created_at, '%d-%m-%Y'), ')') AS nombre " &
                                         "FROM procesos " &
                                         "WHERE estados_procesos_id = 1"

        Dim dtProcesoEstado As DataTable = ObtenerDatos(sqlProcesoEstado)

        RemoveHandler cmbProcesoEstado.SelectedIndexChanged, AddressOf cmbProcesoEstado_SelectedIndexChanged

        cmbProcesoEstado.DataSource = dtProcesoEstado
        cmbProcesoEstado.DisplayMember = "nombre"
        cmbProcesoEstado.ValueMember = "id"
        cmbProcesoEstado.SelectedIndex = -1

        lblIdProceso.Text = ""
        _idProcesoSeleccionado = 0

        AddHandler cmbProcesoEstado.SelectedIndexChanged, AddressOf cmbProcesoEstado_SelectedIndexChanged
    End Sub

    ' =====================================================================
    ' 2. EVENTO COMBOBOX
    ' =====================================================================
    Private Sub cmbProcesoEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcesoEstado.SelectedIndexChanged
        If cmbProcesoEstado.SelectedIndex <> -1 AndAlso cmbProcesoEstado.SelectedValue IsNot Nothing Then
            Dim idTmp As String = cmbProcesoEstado.SelectedValue.ToString()
            lblIdProceso.Text = idTmp
            Integer.TryParse(idTmp, _idProcesoSeleccionado)
        Else
            lblIdProceso.Text = ""
            _idProcesoSeleccionado = 0
        End If
    End Sub

    ' =====================================================================
    ' 3. BOTÓN TERMINAR PROCESO
    ' =====================================================================
    Private Sub btnTerminarProceso_Click(sender As Object, e As EventArgs) Handles btnTerminarProceso.Click
        If String.IsNullOrEmpty(lblIdProceso.Text) Or _idProcesoSeleccionado = 0 Then
            MessageBox.Show("Debe seleccionar un proceso de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' VALIDACIÓN: Buscar detalles pendientes cruzando por la tabla intermedia procesos_recepciones
        Dim sqlValidacion As String =
            "SELECT COUNT(*) FROM procesos_recepciones pr " &
            "INNER JOIN contenedores c ON pr.recepciones_id = c.recepciones_id " &
            "WHERE pr.procesos_id = @id AND c.estados_contenedores_id = 1"

        Dim conteoDetalles As Integer

        Try
            ConexionBD.Abrir()
            Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
                cmdCheck.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
            End Using

            If conteoDetalles > 0 Then
                ConexionBD.Cerrar()
                MessageBox.Show("No se puede Cerrar el proceso porque tiene contenedores/recepciones pendientes.",
                                "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
            ConexionBD.Cerrar()
        Catch ex As Exception
            MessageBox.Show("Error al validar detalles: " & ex.Message)
            ConexionBD.Cerrar()
            Return
        End Try

        ' EJECUCIÓN DEL CIERRE
        If MessageBox.Show($"¿Cerrar el proceso N° {lblIdProceso.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()
                Using transaccion = ConexionBD.conexion.BeginTransaction()
                    Try
                        ' 1. Finalizar Proceso
                        Dim sqlUpdateProceso As String = "UPDATE procesos SET estados_procesos_id = 2, updated_at = NOW() WHERE id = @id"
                        Using cmd = New MySqlCommand(sqlUpdateProceso, ConexionBD.conexion, transaccion)
                            cmd.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' 2. Actualizar TODAS las recepciones asociadas a este proceso
                        Dim sqlUpdateRecepciones As String =
                            "UPDATE recepciones SET estados_recepciones_id = 4, updated_at = NOW() " &
                            "WHERE id IN (SELECT recepciones_id FROM procesos_recepciones WHERE procesos_id = @id)"
                        Using cmd = New MySqlCommand(sqlUpdateRecepciones, ConexionBD.conexion, transaccion)
                            cmd.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                            cmd.ExecuteNonQuery()
                        End Using

                        transaccion.Commit()

                        Dim frm = DirectCast(Me.FindForm(), Form1)
                        LimpiarVariablesGlobales(frm)

                        MessageBox.Show("Proceso finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        frm.NavegarA(New ucNuevoProceso()) ' Navegar al menú de procesos (Ajusta si es necesario)

                    Catch ex As Exception
                        transaccion.Rollback()
                        Throw New Exception("Error interno: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("No se pudo finalizar el proceso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If
    End Sub

    ' =====================================================================
    ' 4. BOTÓN VER Y BOTÓN SIGUIENTE (Misma lógica de navegación)
    ' =====================================================================
    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click, btnSiguiente.Click
        If cmbProcesoEstado.SelectedValue IsNot Nothing Then
            Dim frm = TryCast(Application.OpenForms("Form1"), Form1)
            If frm IsNot Nothing Then
                ' Ya no asignamos "Persona Global" porque el proceso tiene MUCHAS personas.
                ' Solo pasamos el ID del Proceso al constructor del siguiente UserControl.

                Dim ucFinal As New ucProcesoRegistro(_idProcesoSeleccionado)
                ucFinal.Dock = DockStyle.Fill

                frm.pnlContenedor.Controls.Clear()
                frm.pnlContenedor.Controls.Add(ucFinal)
                ucFinal.BringToFront()
            Else
                MsgBox("No se encontró el formulario principal.")
            End If
        Else
            MsgBox("Por favor, seleccione un Proceso de la lista.")
        End If
    End Sub

    ' =====================================================================
    ' 5. BOTÓN EDITAR
    ' =====================================================================
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles ucEditar.Click
        If cmbProcesoEstado.SelectedValue IsNot Nothing Then
            Dim frm = TryCast(Application.OpenForms("Form1"), Form1)
            If frm IsNot Nothing Then
                ' Cargar el formulario de edición (Asegúrate de haber creado ucEditarProceso)
                ' Si aún no existe, debes crearlo para manejar la edición de la tabla 'procesos'
                Dim ucEditar As New ucEditarProceso(_idProcesoSeleccionado)
                ucEditar.Dock = DockStyle.Fill

                frm.pnlContenedor.Controls.Clear()
                frm.pnlContenedor.Controls.Add(ucEditar)
                ucEditar.BringToFront()
            End If
        Else
            MsgBox("Por favor, seleccione un Proceso.")
        End If
    End Sub

    ' =====================================================================
    ' 6. BOTÓN ELIMINAR PROCESO
    ' =====================================================================
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If _idProcesoSeleccionado = 0 Then
            MessageBox.Show("Seleccione un proceso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"¿Desea ELIMINAR por completo el Proceso N° {_idProcesoSeleccionado}? Las recepciones volverán a estar disponibles.",
                           "Peligro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()
                Using transaccion = ConexionBD.conexion.BeginTransaction()
                    Try
                        ' 1. Revertir estado de las recepciones a 2 (Pendiente/Disponible)
                        Dim sqlRevertirRecepcion As String =
                            "UPDATE recepciones SET estados_recepciones_id = 2 WHERE id IN " &
                            "(SELECT recepciones_id FROM procesos_recepciones WHERE procesos_id = @id)"
                        Using cmdRevertir = New MySqlCommand(sqlRevertirRecepcion, ConexionBD.conexion, transaccion)
                            cmdRevertir.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                            cmdRevertir.ExecuteNonQuery()
                        End Using

                        ' 2. Eliminar referencias de la tabla intermedia (Si no tienes CASCADE)
                        Dim sqlDeleteIntermedia As String = "DELETE FROM procesos_recepciones WHERE procesos_id = @id"
                        Using cmdIntermedia = New MySqlCommand(sqlDeleteIntermedia, ConexionBD.conexion, transaccion)
                            cmdIntermedia.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                            cmdIntermedia.ExecuteNonQuery()
                        End Using

                        ' 3. Eliminar el proceso
                        Dim sqlDeleteProceso As String = "DELETE FROM procesos WHERE id = @id"
                        Using cmdDelete = New MySqlCommand(sqlDeleteProceso, ConexionBD.conexion, transaccion)
                            cmdDelete.Parameters.AddWithValue("@id", _idProcesoSeleccionado)
                            cmdDelete.ExecuteNonQuery()
                        End Using

                        transaccion.Commit()
                        MessageBox.Show("Proceso eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Recargar el ComboBox
                        ucProcesoEstado_Load(Nothing, Nothing)

                    Catch ex As Exception
                        transaccion.Rollback()
                        Throw New Exception("Error eliminando proceso: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Error de base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If
    End Sub

    ' =====================================================================
    ' FUNCIONES AUXILIARES
    ' =====================================================================
    Private Sub cmbProcesoEstado_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbProcesoEstado.DrawItem
        e.DrawBackground()
        If e.Index >= 0 Then
            Dim texto As String = cmbProcesoEstado.GetItemText(cmbProcesoEstado.Items(e.Index))
            Dim formato As New StringFormat() With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near}
            Using brush As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(texto, e.Font, brush, e.Bounds, formato)
            End Using
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub LimpiarVariablesGlobales(ByRef frm As Form1)
        frm.IdRecepcionGlobal = "0"
        frm.IdPersonaGlobal = "0"
        frm.NombrePersonaGlobal = ""
        frm.NombreProductoGlobal = ""
        frm.NombreVariedadGlobal = ""
        frm.IdProductoGlobal = 0
        frm.IdVariedadGlobal = 0
        frm.PesoDesdeBascula = 0
    End Sub

End Class


