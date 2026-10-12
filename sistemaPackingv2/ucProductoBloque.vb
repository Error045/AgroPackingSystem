Imports MySql.Data.MySqlClient

Public Class ucProductoBloque

    Public Event ProductoConfirmado()

    Private Sub ucProductoBloque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlProducto As String = "SELECT id, nombre FROM productos"
        Dim dtProducto As DataTable = ConexionBD.ObtenerDatos(sqlProducto)

        cmbProducto.DataSource = dtProducto
        cmbProducto.DisplayMember = "nombre"
        cmbProducto.ValueMember = "id"
        cmbProducto.SelectedIndex = -1
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cmbProducto.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProducto.SelectedValue) Then
            Dim id As Integer = Convert.ToInt32(cmbProducto.SelectedValue)

            Dim sql As String = "SELECT id, nombre FROM variedades WHERE producto_id = @id"
            Dim v As New MySqlParameter("@id", id)

            cmbVariedad.DataSource = ConexionBD.ObtenerDatos(sql, {v})
            cmbVariedad.DisplayMember = "nombre"
            cmbVariedad.ValueMember = "id"
        End If
    End Sub

    Private Sub btnSiguienteProducto_Click(sender As Object, e As EventArgs) Handles btnSiguienteProducto.Click
        If cmbVariedad.SelectedValue IsNot Nothing Then
            Dim frm = DirectCast(Me.FindForm(), Form1)

            If frm IsNot Nothing Then
                frm.NombreProductoGlobal = cmbProducto.Text
                frm.NombreVariedadGlobal = cmbVariedad.Text
                frm.IdProductoGlobal = CInt(cmbProducto.SelectedValue)
                frm.IdVariedadGlobal = CInt(cmbVariedad.SelectedValue)
            End If

            ' Emitimos evento interno para el contenedor maestro
            RaiseEvent ProductoConfirmado()
        Else
            MessageBox.Show("Seleccione una variedad de Producto 🥑 antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class