Public Class ucProcesoEstadoPaletizado


	Private _idProceso As Integer
	' Variable de respaldo para el ID
	Private _idProcesoSeleccionado As Integer = 0



	' 1. Carga de datos
	Private Sub ucProcesoEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


		Dim sqlProcesoEstado As String = "SELECT a.id,a.fecha_inicio " &
											"FROM procesos_paletizado a " &
											"WHERE a.estados_procesos_pallets_id = 1"
		Dim dtProcesoEstado As DataTable = ObtenerDatos(sqlProcesoEstado)

		' Desvinculamos el evento temporalmente para evitar que limpie el label al cargar
		RemoveHandler cmbProcesoEstado.SelectedIndexChanged, AddressOf cmbProcesoEstado_SelectedIndexChanged

		cmbProcesoEstado.DataSource = dtProcesoEstado
		cmbProcesoEstado.DisplayMember = "fecha_inicio"
		cmbProcesoEstado.ValueMember = "id"
		cmbProcesoEstado.SelectedIndex = -1

		lblIdProceso.Text = ""
		_idProcesoSeleccionado = 0

		' Volvemos a vincular el evento
		AddHandler cmbProcesoEstado.SelectedIndexChanged, AddressOf cmbProcesoEstado_SelectedIndexChanged
	End Sub

	' 2. Evento que detecta el cambio y actualiza el Label y la Variable
	Private Sub cmbProcesoEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcesoEstado.SelectedIndexChanged
		' Validamos que haya una selección real
		If cmbProcesoEstado.SelectedIndex <> -1 AndAlso cmbProcesoEstado.SelectedValue IsNot Nothing Then

			' Intentamos obtener el ID (manejando si es DataRowView o el valor directo)
			Dim idTmp As String = cmbProcesoEstado.SelectedValue.ToString()

			' Actualizamos el Label (Funcionalidad recuperada)
			lblIdProceso.Text = idTmp

			' Actualizamos la variable para el botón Terminar
			Integer.TryParse(idTmp, _idProcesoSeleccionado)
		Else
			lblIdProceso.Text = ""
			_idProcesoSeleccionado = 0
		End If
	End Sub

	Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click



		' 1. Validar que el usuario seleccionó algo en el ComboBox de MariaDB
		If cmbProcesoEstado.SelectedValue IsNot Nothing Then

			' 2. Acceder al Formulario Principal (Solo una vez)
			Dim frm = DirectCast(Me.FindForm(), Form1)

			Dim row As DataRowView = DirectCast(cmbProcesoEstado.SelectedItem, DataRowView)
			'Dim idPersona As Integer = CInt(row("personas_id"))         '<---------------------------------------------------------- cambiar 

			' 3. GUARDAR TODO EN EL "PUENTE" (Form1)
			' Guardamos el ID numérico Recepción para la base de datos
			frm.IdRecepcionGlobal = lblIdProceso.Text
			' Guardamos el ID numérico Productor para la base de datos
			'frm.IdPersonaGlobal = idPersona
			' Guardamos el Texto (Nombre) para mostrarlo en los Labels del ucPesaje
			frm.NombrePersonaGlobal = cmbProcesoEstado.Text




			' 4. NAVEGAR al siguiente Control de Usuario (ucProducto)
			' Usamos el método profesional NavegarA que definimos en el Form1
			frm.NavegarA(New ucProcesoPaletizado(_idProcesoSeleccionado))




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
End Class
