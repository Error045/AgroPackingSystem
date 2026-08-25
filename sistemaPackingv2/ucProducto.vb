Imports MySql.Data.MySqlClient

Public Class ucProducto
	Private _idRecibido As Integer ' Variable interna para guardar el dato
	Private Sub ucProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim sqlProducto As String = "SELECT id, nombre FROM productos"
		Dim dtProducto As DataTable = ObtenerDatos(sqlProducto) ' Llamada directa al módulo

		cmbProducto.DataSource = dtProducto
		cmbProducto.DisplayMember = "nombre"
		cmbProducto.ValueMember = "id"
		cmbProducto.SelectedIndex = -1 ' Empieza vacío
	End Sub
	Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
		' Validar que hay una selección real y no es la carga inicial
		If cmbProducto.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProducto.SelectedValue) Then
			Dim id As Integer = Convert.ToInt32(cmbProducto.SelectedValue)

			' Consulta filtrada
			Dim sql As String = "SELECT id, nombre FROM variedades WHERE producto_id = @id"
			Dim v As New MySqlParameter("@id", id)

			' Llenar segundo combo usando la función del módulo
			cmbVariedad.DataSource = ObtenerDatos(sql, {v})
			cmbVariedad.DisplayMember = "nombre"
			cmbVariedad.ValueMember = "id"
		End If

	End Sub

	Private Sub btnSiguienteProducto_Click(sender As Object, e As EventArgs) Handles btnSiguienteProducto.Click

		If cmbVariedad.SelectedValue IsNot Nothing Then
			' 1. Acceder al Formulario Principal (Puente de datos)
			Dim frm = DirectCast(Me.FindForm(), Form1)

			' 2. Guardar Textos para los Labels (👤, 🥑, 🏷️)
			frm.NombreProductoGlobal = cmbProducto.Text
			frm.NombreVariedadGlobal = cmbVariedad.Text
			' Guardamos IDs (Base de Datos)
			frm.IdProductoGlobal = CInt(cmbProducto.SelectedValue)
			frm.IdVariedadGlobal = CInt(cmbVariedad.SelectedValue)

			' 4. NAVEGAR al Padre Maestro (ucRecepcion)
			' Al cargar, ucRecepcion decidirá mostrar el selector automáticamente
			frm.NavegarA(New ucRecepcion())
		Else
			MessageBox.Show("Seleccione una variedad de Producto 🥑 antes de continuar.")
		End If

	End Sub
End Class
