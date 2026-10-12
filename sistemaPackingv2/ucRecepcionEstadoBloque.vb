Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class ucRecepcionEstadoBloque

    ' ---> EVENTO PARA NOTIFICAR AL CONTENEDOR MAESTRO <---
    Public Event EstadoConfirmado()

    Private _idRecepcion As Integer
    Private _idRecepcionSeleccionada As Integer = 0
    Private _idTipoRecepcionSeleccionada As Integer = 0

    ' 1. Carga de datos
    Private Sub ucRecepcionEstadoBloque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Iconos de Botones
        btnVer.Font = New Font("Segoe MDL2 Assets", 14)
        btnVer.Text = ChrW(&HE7B3)
        btnVer.ForeColor = Color.Olive
        btnVer.BackColor = Color.PaleGreen

        btnEditar.Font = New Font("Segoe MDL2 Assets", 14)
        btnEditar.Text = ChrW(&HE104)
        btnEditar.ForeColor = Color.CadetBlue

        btnEliminar.Font = New Font("Segoe MDL2 Assets", 14)
        btnEliminar.Text = ChrW(&HE107)
        btnEliminar.ForeColor = Color.Red

        Dim sqlRecepcionEstado As String = "SELECT id_recepcion, personas_id, nombre, tipos_recepciones_id, tipo_nombre FROM vw_recepciones_estados WHERE estados_recepciones_id = 1"
        Dim dtRecepcionEstado As DataTable = ConexionBD.ObtenerDatos(sqlRecepcionEstado)

        RemoveHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged

        cmbRecepcionEstado.DataSource = dtRecepcionEstado
        cmbRecepcionEstado.DisplayMember = "nombre"
        cmbRecepcionEstado.ValueMember = "id_recepcion"
        cmbRecepcionEstado.SelectedIndex = -1

        lblIdRecepcion.Text = ""
        lblTipoRecepcion.Text = ""
        _idRecepcionSeleccionada = 0
        _idTipoRecepcionSeleccionada = 0

        AddHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged
    End Sub

    ' 2. Evento que detecta el cambio en la lista
    Private Sub cmbRecepcionEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRecepcionEstado.SelectedIndexChanged
        If cmbRecepcionEstado.SelectedIndex <> -1 AndAlso cmbRecepcionEstado.SelectedValue IsNot Nothing Then
            Dim drv As DataRowView = DirectCast(cmbRecepcionEstado.SelectedItem, DataRowView)

            If drv IsNot Nothing Then
                _idRecepcionSeleccionada = Convert.ToInt32(drv("id_recepcion"))
                _idTipoRecepcionSeleccionada = Convert.ToInt32(drv("tipos_recepciones_id"))

                lblIdRecepcion.Text = _idRecepcionSeleccionada.ToString()
                lblTipoRecepcion.Text = drv("tipo_nombre").ToString()
            End If
        Else
            lblIdRecepcion.Text = ""
            _idRecepcionSeleccionada = 0
        End If
    End Sub

    ' 3. Botón Siguiente (LIMPIO: Solo guarda variables globales y emite el evento)
    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If cmbRecepcionEstado.SelectedValue IsNot Nothing Then
            Dim frm = DirectCast(Me.FindForm(), Form1)
            Dim row As DataRowView = DirectCast(cmbRecepcionEstado.SelectedItem, DataRowView)
            Dim idPersona As Integer = CInt(row("personas_id"))

            ' Guardar datos en el formulario principal
            If frm IsNot Nothing Then
                frm.IdRecepcionGlobal = lblIdRecepcion.Text
                frm.IdPersonaGlobal = idPersona
                frm.NombrePersonaGlobal = cmbRecepcionEstado.Text
                frm.IdTipoRecepcionGlobal = _idTipoRecepcionSeleccionada
            End If

            ' Avisar a ucRecepcionBloque para que cambie de sub-panel (NO NAVEGAR)
            RaiseEvent EstadoConfirmado()
        Else
            MessageBox.Show("Por favor, seleccione una recepción antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' 4. Botón Terminar Recepción
    Private Sub btnTerminarRecepcion_Click(sender As Object, e As EventArgs) Handles btnTerminarRecepcion.Click
        If String.IsNullOrEmpty(lblIdRecepcion.Text) Or _idRecepcionSeleccionada = 0 Then
            MessageBox.Show("Debe seleccionar una recepción de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sqlValidacion As String = "SELECT COUNT(a.id) FROM recepciones as a JOIN contenedores as b ON a.id = b.recepciones_id WHERE a.id = @id"
        Dim conteoDetalles As Integer

        Try
            ConexionBD.Abrir()
            Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
                cmdCheck.Parameters.AddWithValue("@id", _idRecepcionSeleccionada)
                conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
            End Using

            If conteoDetalles = 0 Then
                ConexionBD.Cerrar()
                MessageBox.Show("No se puede cerrar la recepción porque no tiene detalles registrados.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            ConexionBD.Cerrar()
        Catch ex As Exception
            MessageBox.Show("Error al validar detalles: " & ex.Message)
            ConexionBD.Cerrar()
            Return
        End Try

        Dim respuesta = MessageBox.Show($"¿Cerrar la recepción N° {lblIdRecepcion.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()
                Dim sqlUpdate As String = "UPDATE recepciones SET estados_recepciones_id = 2, updated_at = NOW() WHERE id = @id"
                Using cmd = New MySqlCommand(sqlUpdate, ConexionBD.conexion)
                    cmd.Parameters.AddWithValue("@id", _idRecepcionSeleccionada)
                    cmd.ExecuteNonQuery()
                End Using

                Dim frm = DirectCast(Me.FindForm(), Form1)
                LimpiarVariablesGlobales(frm)
                MessageBox.Show("Recepción finalizada.")
                frm.NavegarA(New ucNuevaRecepcion())
            Catch ex As Exception
                MessageBox.Show("Error al actualizar: " & ex.Message)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If
    End Sub

    Private Sub cmbRecepcionEstado_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbRecepcionEstado.DrawItem
        e.DrawBackground()

        If e.Index >= 0 Then
            Dim texto As String = cmbRecepcionEstado.GetItemText(cmbRecepcionEstado.Items(e.Index))
            Dim formato As New StringFormat() With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Near
            }

            Using brush As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(texto, e.Font, brush, e.Bounds, formato)
            End Using
        End If

        e.DrawFocusRectangle()
    End Sub

    Private Sub LimpiarVariablesGlobales(ByRef frm As Form1)
        If frm Is Nothing Then Return
        frm.IdRecepcionGlobal = "0"
        frm.IdTipoRecepcionGlobal = "0"
        frm.IdPersonaGlobal = "0"
        frm.NombrePersonaGlobal = ""
        frm.NombreProductoGlobal = ""
        frm.NombreVariedadGlobal = ""
        frm.IdProductoGlobal = 0
        frm.IdVariedadGlobal = 0
        frm.PesoDesdeBascula = 0
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        If cmbRecepcionEstado.SelectedValue IsNot Nothing AndAlso cmbRecepcionEstado.SelectedItem IsNot Nothing Then
            Dim frm = TryCast(Application.OpenForms("Form1"), Form1)
            If frm IsNot Nothing Then
                Dim row As DataRowView = TryCast(cmbRecepcionEstado.SelectedItem, DataRowView)
                If row IsNot Nothing Then
                    Dim idPersona As Integer = Convert.ToInt32(row("personas_id"))
                    frm.IdRecepcionGlobal = lblIdRecepcion.Text
                    frm.IdPersonaGlobal = idPersona
                    frm.NombrePersonaGlobal = cmbRecepcionEstado.Text

                    Dim ucFinal As New ucRecepcionFinal(lblIdRecepcion.Text)
                    ucFinal.Dock = DockStyle.Fill
                    frm.pnlContenedor.Controls.Add(ucFinal)
                    ucFinal.BringToFront()
                End If
            End If
        Else
            MessageBox.Show("Por favor, seleccione un estado de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            ConexionBD.Abrir()
            Dim sqlValidacion As String = "SELECT COUNT(*) FROM contenedores WHERE recepciones_id = @id"
            Dim conteoDetalles As Integer

            Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
                cmdCheck.Parameters.AddWithValue("@id", lblIdRecepcion.Text)
                conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
            End Using

            If conteoDetalles > 0 Then
                MessageBox.Show("No se puede eliminar la recepción porque tiene detalles registrados.", "Conflicto de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim sqlDelete As String = "DELETE FROM recepciones WHERE id = @id"
            Using cmdDelete As New MySqlCommand(sqlDelete, ConexionBD.conexion)
                cmdDelete.Parameters.AddWithValue("@id", lblIdRecepcion.Text)
                Dim filasAfectadas As Integer = cmdDelete.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Recepción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If cmbRecepcionEstado.SelectedValue IsNot Nothing AndAlso cmbRecepcionEstado.SelectedItem IsNot Nothing Then
            Dim frm = TryCast(Application.OpenForms("Form1"), Form1)
            If frm IsNot Nothing Then
                Dim row As DataRowView = TryCast(cmbRecepcionEstado.SelectedItem, DataRowView)
                If row IsNot Nothing Then
                    Dim idPersona As Integer = Convert.ToInt32(row("personas_id"))
                    frm.IdRecepcionGlobal = lblIdRecepcion.Text
                    frm.IdPersonaGlobal = idPersona
                    frm.NombrePersonaGlobal = cmbRecepcionEstado.Text

                    Dim ucEditar As New ucEditarRecepcion(lblIdRecepcion.Text)
                    ucEditar.Dock = DockStyle.Fill
                    frm.pnlContenedor.Controls.Clear()
                    frm.pnlContenedor.Controls.Add(ucEditar)
                    ucEditar.BringToFront()
                End If
            End If
        Else
            MessageBox.Show("Por favor, seleccione una Recepción de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class