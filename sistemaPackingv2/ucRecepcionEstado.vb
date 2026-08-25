Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient




Public Class ucRecepcionEstado


	Private _idRecepcion As Integer
	' Variable de respaldo para el ID
	Private _idRecepcionSeleccionada As Integer = 0
	Private _idTipoRecepcionSeleccionada As Integer = 0


	' 1. Carga de datos
	Private Sub ucRecepcionEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Iconos de Botones (Usamos Segoe MDL2 Assets para íconos modernos)

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


        Dim sqlRecepcionEstado As String = "SELECT id_recepcion,personas_id, nombre ,tipos_recepciones_id ,tipo_nombre FROM vw_recepciones_estados WHERE estados_recepciones_id = 1"   'MODIFICAR CON LA NUEVA BASE DE DATOS Y VISTA
        Dim dtRecepcionEstado As DataTable = ObtenerDatos(sqlRecepcionEstado)

		' Desvinculamos el evento temporalmente para evitar que limpie el label al cargar
		RemoveHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged

		cmbRecepcionEstado.DataSource = dtRecepcionEstado
		cmbRecepcionEstado.DisplayMember = "nombre"
		cmbRecepcionEstado.ValueMember = "id_recepcion"
		cmbRecepcionEstado.SelectedIndex = -1

        lblIdRecepcion.Text = ""
        lblTipoRecepcion.Text = ""
		_idRecepcionSeleccionada = 0
		_idTipoRecepcionSeleccionada = 0

		' Volvemos a vincular el evento
		AddHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged
	End Sub

	' 2. Evento que detecta el cambio y actualiza el Label y la Variable
	Private Sub cmbRecepcionEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRecepcionEstado.SelectedIndexChanged
		' Validamos que haya una selección real
		If cmbRecepcionEstado.SelectedIndex <> -1 AndAlso cmbRecepcionEstado.SelectedValue IsNot Nothing Then


			' Intentamos obtener el ID (manejando si es DataRowView o el valor directo)
			'Dim idTmp As String = cmbRecepcionEstado.SelectedValue.ToString()
			Dim drv As DataRowView = DirectCast(cmbRecepcionEstado.SelectedItem, DataRowView)

			If drv IsNot Nothing Then
				' Actualizamos IDs y Labels
				_idRecepcionSeleccionada = Convert.ToInt32(drv("id_recepcion"))
				_idTipoRecepcionSeleccionada = Convert.ToInt32(drv("tipos_recepciones_id"))

				lblIdRecepcion.Text = _idRecepcionSeleccionada.ToString()
				lblTipoRecepcion.Text = drv("tipo_nombre").ToString()
			End If

			' Actualizamos el Label (Funcionalidad recuperada)
			'	lblIdRecepcion.Text = idTmp

			' Actualizamos la variable para el botón Terminar
			'	Integer.TryParse(idTmp, _idRecepcionSeleccionada)
		Else
			lblIdRecepcion.Text = ""
			_idRecepcionSeleccionada = 0
		End If
	End Sub

	' 3. Botón Terminar Recepción (Ahora usa la variable validada)
	Private Sub btnTerminarRecepcion_Click(sender As Object, e As EventArgs) Handles btnTerminarRecepcion.Click


		' Si el label está vacío, significa que no seleccionó nada
		If String.IsNullOrEmpty(lblIdRecepcion.Text) Or _idRecepcionSeleccionada = 0 Then
			MessageBox.Show("Debe seleccionar una recepción de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return
		End If

		' 1. VALIDACIÓN: Comprobar si existen detalles
		Dim sqlValidacion As String = "SELECT COUNT(a.id) FROM recepciones as a JOIN contenedores as b ON a.id = b.recepciones_id  WHERE a.id = @id"    ' MODIFICAR CON LA NUEVA BASE DE DATOS Y TABLA
		Dim conteoDetalles As Integer

		Try
			ConexionBD.Abrir()
			Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
				' ¡CORRECCIÓN AQUÍ! Usamos la variable correcta: _idRecepcionSeleccionada
				cmdCheck.Parameters.AddWithValue("@id", _idRecepcionSeleccionada)
				conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
			End Using

			' Si NO existen datos en detalles, bloqueamos el cierre
			If conteoDetalles = 0 Then
				' ¡CORRECCIÓN AQUÍ! Cerramos la conexión ANTES del Return
				ConexionBD.Cerrar()
				MessageBox.Show("No se puede Cerrar la recepción porque no tiene detalles registrados.",
						"Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			' Si pasa la validación, cerramos la conexión de esta etapa
			ConexionBD.Cerrar()

		Catch ex As Exception
			MessageBox.Show("Error al validar detalles: " & ex.Message)
			ConexionBD.Cerrar()
			Return
		End Try

		' 2. EJECUCIÓN DEL CIERRE DE RECEPCIÓN
		Dim respuesta = MessageBox.Show($"¿Cerrar la recepción N° {lblIdRecepcion.Text}?",
							   "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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
		' Dibuja el fondo (color azul si está seleccionado, blanco si no)
		e.DrawBackground()

		If e.Index >= 0 Then
			' Obtener el texto del ítem actual
			Dim texto As String = cmbRecepcionEstado.GetItemText(cmbRecepcionEstado.Items(e.Index))

			' Definir el formato: Centrado verticalmente para facilidad touch
			Dim formato As New StringFormat()
			formato.LineAlignment = StringAlignment.Center ' Centro vertical
			formato.Alignment = StringAlignment.Near      ' Alineado a la izquierda (margen)

			' Dibujar el texto con el color de fuente del sistema (blanco si está seleccionado)
			Using brush As New SolidBrush(e.ForeColor)
				e.Graphics.DrawString(texto, e.Font, brush, e.Bounds, formato)
			End Using
		End If

		' Dibuja el rectángulo de enfoque
		e.DrawFocusRectangle()
	End Sub


	Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click




		' 1. Validar que el usuario seleccionó algo en el ComboBox de MariaDB
		If cmbRecepcionEstado.SelectedValue IsNot Nothing Then

			' 2. Acceder al Formulario Principal (Solo una vez)
			Dim frm = DirectCast(Me.FindForm(), Form1)

			Dim row As DataRowView = DirectCast(cmbRecepcionEstado.SelectedItem, DataRowView)
			Dim idPersona As Integer = CInt(row("personas_id"))

			' 3. GUARDAR TODO EN EL "PUENTE" (Form1)
			' Guardamos el ID numérico Recepción para la base de datos
			frm.IdRecepcionGlobal = lblIdRecepcion.Text
			' Guardamos el ID numérico Productor para la base de datos
			frm.IdPersonaGlobal = idPersona
            ' Guardamos el Texto (Nombre) para mostrarlo en los Labels del ucPesaje
            frm.NombrePersonaGlobal = cmbRecepcionEstado.Text

			frm.IdTipoRecepcionGlobal = _idTipoRecepcionSeleccionada



			' 4. NAVEGAR al siguiente Control de Usuario (ucProducto)
			' Usamos el método profesional NavegarA que definimos en el Form1
			frm.NavegarA(New ucProducto())




		Else
			MessageBox.Show("Por favor, seleccione una recepción antes de continuar.")
		End If
		' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
		Dim ucNuevaRecepcion As New ucNuevaRecepcion()

		' 3. Ajustarlo para que ocupe todo el espacio disponible
		'ucRecepcion.BringToFront()
		ucNuevaRecepcion.Dock = DockStyle.Fill

		' 4. Agregarlo al panel central




	End Sub



	Private Sub LimpiarVariablesGlobales(ByRef frm As Form1)
		frm.IdRecepcionGlobal = "0"
		frm.IdTipoRecepcionGlobal = "0"
		frm.IdPersonaGlobal = "0"
		frm.NombrePersonaGlobal = ""
		frm.NombreProductoGlobal = ""
		frm.NombreVariedadGlobal = ""
		frm.IdProductoGlobal = 0
		frm.IdVariedadGlobal = 0
		frm.PesoDesdeBascula = 0

		' Cualquier otra variable de ruteo que necesite resetearse
	End Sub


	Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
		' 1. Validar selección y obtener datos
		If cmbRecepcionEstado.SelectedValue IsNot Nothing AndAlso cmbRecepcionEstado.SelectedItem IsNot Nothing Then

			' Intentar obtener el Form1 de forma segura
			Dim frm = TryCast(Application.OpenForms("Form1"), Form1)

			If frm IsNot Nothing Then
				' 2. Extraer datos del DataRowView de forma segura
				Dim row As DataRowView = TryCast(cmbRecepcionEstado.SelectedItem, DataRowView)


				If row IsNot Nothing Then
					Dim idPersona As Integer = Convert.ToInt32(row("personas_id"))

					' 3. Guardar en el "Puente" (Form1)
					frm.IdRecepcionGlobal = lblIdRecepcion.Text
					frm.IdPersonaGlobal = idPersona
					frm.NombrePersonaGlobal = cmbRecepcionEstado.Text

					' 4. Cargar el siguiente UserControl
					Dim ucFinal As New ucRecepcionFinal(lblIdRecepcion.Text)
					ucFinal.Dock = DockStyle.Fill

					' Limpiar el panel antes de agregar (opcional pero recomendado)
					' frm.pnlContenedor.Controls.Clear() 

					frm.pnlContenedor.Controls.Add(ucFinal)
					ucFinal.BringToFront()
				End If
			Else
				MsgBoxTouch("No se encontró el formulario principal.", "Aviso", True, TouchIcon.Advertencia)
				' Si no se encuentra el Form1, no podemos continuar, pero al menos cerramos el mensaje de error.
			End If
		Else
			MsgBoxTouch("Por favor, seleccione un estado de la lista.", "Aviso", True, TouchIcon.Advertencia)
		End If
	End Sub

	Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
		' Aquí puedes implementar la lógica para eliminar la recepción seleccionada, si es necesario.
		' Valida si existen datos en recepciones_detalles en la base de datos antes de eliminar, para evitar errores de integridad referencial.
		MsgBox("Botón presionado correctamente") ' PASO 1: ¿El botón responde?
		Try
			' 1. Abrir la conexión al inicio
			ConexionBD.Abrir()

			' 2. VALIDACIÓN: Comprobar si existen detalles asociados
			Dim sqlValidacion As String = "SELECT COUNT(*) FROM recepciones_detalles WHERE recepciones_id = @id"
			Dim conteoDetalles As Integer

			Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
				cmdCheck.Parameters.AddWithValue("@id", lblIdRecepcion.Text)
				conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
			End Using

			' 3. Integridad Referencial: Si existen detalles, cancelamos la eliminación
			If conteoDetalles > 0 Then
				MessageBox.Show("No se puede eliminar la recepción porque tiene detalles registrados. " &
						"Elimine primero los detalles asociados.",
						"Conflicto de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			' 4. Lógica de Eliminación (Solo si pasó la validación)
			Dim sqlDelete As String = "DELETE FROM recepciones WHERE id = @id"
			Using cmdDelete As New MySqlCommand(sqlDelete, ConexionBD.conexion)
				cmdDelete.Parameters.AddWithValue("@id", lblIdRecepcion.Text)

				Dim filasAfectadas As Integer = cmdDelete.ExecuteNonQuery()

				If filasAfectadas > 0 Then
					MessageBox.Show("Recepción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
					' Aquí podrías llamar a un método para refrescar el grid o navegar atrás
					' Me.ParentForm.NavegarA(New ucListaRecepciones())
				End If
			End Using

		Catch ex As MySqlException
			' Captura errores específicos de MySQL (ej: servidor caído, error de sintaxis)
			MessageBox.Show("Error de base de datos: " & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Catch ex As Exception
			' Captura cualquier otro error general
			MessageBox.Show("Ocurrió un error inesperado: " & ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			' El bloque Finally se ejecuta SIEMPRE, garantizando que no queden conexiones colgadas
			ConexionBD.Cerrar()
		End Try


	End Sub

	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

		' 1. Validar selección y obtener datos
		If cmbRecepcionEstado.SelectedValue IsNot Nothing AndAlso cmbRecepcionEstado.SelectedItem IsNot Nothing Then

			' Intentar obtener el Form1 de forma segura
			Dim frm = TryCast(Application.OpenForms("Form1"), Form1)

			If frm IsNot Nothing Then
				' 2. Extraer datos del DataRowView de forma segura
				Dim row As DataRowView = TryCast(cmbRecepcionEstado.SelectedItem, DataRowView)

				If row IsNot Nothing Then
					Dim idPersona As Integer = Convert.ToInt32(row("personas_id"))

					' 3. Guardar en el "Puente" (Form1)
					frm.IdRecepcionGlobal = lblIdRecepcion.Text
					frm.IdPersonaGlobal = idPersona
					frm.NombrePersonaGlobal = cmbRecepcionEstado.Text

					' 4. Cargar el siguiente UserControl
					Dim ucEditar As New ucEditarRecepcion(lblIdRecepcion.Text)
					ucEditar.Dock = DockStyle.Fill

					' Limpiar el panel antes de agregar (opcional pero recomendado)
					frm.pnlContenedor.Controls.Clear()

					frm.pnlContenedor.Controls.Add(ucEditar)
					ucEditar.BringToFront()
				End If
			Else
				MsgBoxTouch("No se encontró el formulario principal.", "Aviso", True, TouchIcon.Advertencia)
				' Si no se encuentra el Form1, no podemos continuar, pero al menos cerramos el mensaje de error.
			End If
		Else
			MsgBoxTouch("Por favor, seleccione una Recepción de la lista.", "Aviso", True, TouchIcon.Advertencia)
		End If
	End Sub


End Class
