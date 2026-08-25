Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Cursor



Public Class ucNuevoProceso


	Private _idRecepcion As Integer
	' Variable de respaldo para el ID
	Private _idRecepcionSeleccionada As Integer = 0


	Private Sub ucNuevoProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		'cargar los datos de las recepciones que están en estado "Finalizada" para mostrarlos en el combo box
		Dim sqlRecepcionEstado As String = "SELECT id_recepcion,nombre FROM vw_recepciones_estados  WHERE estados_recepciones_id = 2 "
		Dim dtRecepcionEstado As DataTable = ObtenerDatos(sqlRecepcionEstado)


		' Desvinculamos el evento temporalmente para evitar que limpie el label al cargar
		RemoveHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged

		cmbRecepcionEstado.DataSource = dtRecepcionEstado
		cmbRecepcionEstado.DisplayMember = "nombre"
		cmbRecepcionEstado.ValueMember = "id_recepcion"
		cmbRecepcionEstado.SelectedIndex = -1

		lblIdRecepcion.Text = ""
		_idRecepcionSeleccionada = 0

		' Volvemos a vincular el evento
		AddHandler cmbRecepcionEstado.SelectedIndexChanged, AddressOf cmbRecepcionEstado_SelectedIndexChanged

		' 2. Evento que detecta el cambio y actualiza el Label y la Variable

	End Sub

	Private Sub cmbRecepcionEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRecepcionEstado.SelectedIndexChanged
		' Validamos que haya una selección real
		If cmbRecepcionEstado.SelectedIndex <> -1 AndAlso cmbRecepcionEstado.SelectedValue IsNot Nothing Then

			' Intentamos obtener el ID (manejando si es DataRowView o el valor directo)
			Dim idTmp As String = cmbRecepcionEstado.SelectedValue.ToString()

			' Actualizamos el Label (Funcionalidad recuperada)
			lblIdRecepcion.Text = idTmp

			' Actualizamos la variable para el botón Terminar
			Integer.TryParse(idTmp, _idRecepcionSeleccionada)
		Else
			lblIdRecepcion.Text = ""
			_idRecepcionSeleccionada = 0
		End If
	End Sub

	Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Try
            ConexionBD.Abrir()

            ' 1. Definimos la consulta (obtenemos el número de registros abiertos)
            Dim sqlValidacion As String = "SELECT COUNT(*) FROM procesos WHERE estados_procesos_id = 1"

            ' 2. Ejecutamos y convertimos el resultado a Entero
            ' Usamos ExecuteScalar (o tu método equivalente) para obtener el conteo
            Dim conteoAbiertas As Integer = Convert.ToInt32(ConexionBD.EjecutarEscalar(sqlValidacion))

            ' 3. Validación de Negocio
            If conteoAbiertas > 0 Then
                MessageBox.Show("Existe un Proceso 'Abierto'. Debe cerrarlo antes de continuar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return ' Detiene la ejecución si hay una abierta
            End If

            ' 4. Validación de Interfaz (Campos vacíos)
            If String.IsNullOrEmpty(cmbRecepcionEstado.SelectedValue) Then
                MessageBox.Show("Por favor, seleccione el Tipo de Recepción y la Persona.",
                        "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Error al validar recepción: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar() ' Siempre cerrar la conexión, ocurra error o no
        End Try

        'valida datos en comboboxs
        'If cmbTipoRecepcion.SelectedValue Is Nothing Or cmbPersona.SelectedValue Is Nothing Then
        'MessageBox.Show("Por favor, seleccione el Tipo de Recepción y la Persona.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Return
        ' End If

        ' 2. BLOQUEO DE BOTÓN: Evita duplicados por doble click
        btnRegistrar.Enabled = False
        btnRegistrar.Text = "Procesando..."

        Dim frm = TryCast(Me.FindForm(), Form1)
        If frm Is Nothing Then frm = TryCast(Application.OpenForms("Form1"), Form1)

        Try
            ConexionBD.Abrir()
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' Eliminamos el SELECT intermedio y dejamos el LAST_INSERT_ID() al final de todo el bloque

                    Dim sql As String =
"INSERT INTO procesos (recepciones_id, fecha, hora, estados_procesos_id, users_id, created_at, updated_at) " &  'INSERTA NUEVO PROCESO
    "VALUES (@recepcionesId, CURDATE(), CURTIME(), 1, 1, NOW(), NOW()); " &
    "SET @idProceso = LAST_INSERT_ID(); " &
    "UPDATE recepciones " &
    "SET estados_recepciones_id = 3, updated_at = NOW() " &
    "WHERE id = @recepcionesId; " &
    "UPDATE contenedores " &                     '--- AQUÍ ESTÁ EL UPDATE DE LOS CONTENEDORES estados_contenedores_id = 2 (En proceso) ---
    "SET estados_contenedores_id = 2 " &
    "WHERE recepciones_id = @recepcionesId; " &
    "INSERT INTO contenedores_historial (" &    ' --- AQUÍ ESTÁ EL INSERT AL HISTORIAL tipos_movimientos = 2 , estados_contenedores_id = 2 y tipos_ubicaciones = 1, fecha_movimiento --- ubicacion = 1 porque el operador de grua modifica la ubicación del contenedor a 2 'En patio proceso' ---
    "tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
    "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, " &
    "fecha_movimiento, users_id) " &
    "SELECT " &
    "2, tipos_contenedores_id, id, " &
    "1 , 2, kilos_brutos, kilos_netos, " &
    "NOW(), users_id_registro " &
    "FROM contenedores " &
    "WHERE recepciones_id = @recepcionesId; " &
    "SELECT @idProceso;" ' Esto es lo que devolverá el ExecuteScalar

                    Dim nuevoIdProceso As Integer
                    Using cmd As New MySqlCommand(sql, ConexionBD.conexion, transaccion)
                        ' Importante: Asegúrate que cmbRecepcionEstado.SelectedValue no sea nulo
                        cmd.Parameters.AddWithValue("@recepcionesId", cmbRecepcionEstado.SelectedValue)

                        ' Ejecutamos y obtenemos el ID final
                        nuevoIdProceso = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using

                    transaccion.Commit()
                    MessageBox.Show($"¡Proceso N° {nuevoIdProceso} creado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Actualización de UI
                    If frm IsNot Nothing Then
                        frm.IdRecepcionGlobal = nuevoIdProceso.ToString()
                    End If

                Catch ex As Exception
                    transaccion.Rollback()
                    btnRegistrar.Enabled = True
                    btnRegistrar.Text = "Registrar"
                    MessageBox.Show("Error en la transacción: " & ex.Message)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub



End Class
