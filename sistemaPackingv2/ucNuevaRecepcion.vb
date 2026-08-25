Imports System.Transactions
Imports MySql.Data.MySqlClient

Public Class ucNuevaRecepcion


	Private Sub ucNuevaRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		' Llamamos a la clase ConexionBD
		Dim sqlTipoRecepcion As String = "SELECT id, tipo FROM tipos_recepciones"
		Dim dtTipoRecepcion As DataTable = ObtenerDatos(sqlTipoRecepcion) ' Llamada directa al módulo

		cmbTipoRecepcion.DataSource = dtTipoRecepcion
		cmbTipoRecepcion.DisplayMember = "tipo"
		cmbTipoRecepcion.ValueMember = "id"
		cmbTipoRecepcion.SelectedIndex = -1 ' Empieza vacío

        Dim sqlPersona As String = "SELECT id_recepcion,personas_id,nombre FROM vw_recepciones_personas"
        Dim dtPersona As DataTable = ObtenerDatos(sqlPersona) ' Llamada directa al módulo

		cmbPersona.DataSource = dtPersona
		cmbPersona.DisplayMember = "nombre"
        cmbPersona.ValueMember = "personas_id"
        cmbPersona.SelectedIndex = -1 ' Empieza vacío

	End Sub





	Private Sub cmbPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPersona.SelectedIndexChanged

	End Sub



    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Try
            ConexionBD.Abrir()

            ' 1. Definimos la consulta (obtenemos el número de registros abiertos)
            Dim sqlValidacion As String = "SELECT COUNT(*) FROM recepciones WHERE estados_recepciones_id = 1"

            ' 2. Ejecutamos y convertimos el resultado a Entero
            ' Usamos ExecuteScalar (o tu método equivalente) para obtener el conteo
            Dim conteoAbiertas As Integer = Convert.ToInt32(ConexionBD.EjecutarEscalar(sqlValidacion))

            ' 3. Validación de Negocio
            If conteoAbiertas > 0 Then
                MessageBox.Show("Existe una recepción 'Abierta'. Debe cerrarla antes de continuar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return ' Detiene la ejecución si hay una abierta
            End If

            ' 4. Validación de Interfaz (Campos vacíos)
            If String.IsNullOrEmpty(cmbTipoRecepcion.SelectedValue) OrElse String.IsNullOrEmpty(cmbPersona.Text) Then
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
                    ' 3. SQL con valores "en duro" (1) para pruebas iniciales (cambiar productores_id por personas_id
                    Dim sql As String = "INSERT INTO recepciones " &
                    "(tipos_recepciones_id, personas_id, fecha, hora, estados_recepciones_id, users_id, created_at, updated_at) " &
                    "VALUES (@tipoId, @personaId, CURDATE(), CURTIME(), 1, 1, NOW(), NOW()); " &
                    "SELECT LAST_INSERT_ID();"

                    Dim nuevoIdRecepcion As Integer
                    Using cmd As New MySqlCommand(sql, ConexionBD.conexion, transaccion)
                        cmd.Parameters.AddWithValue("@tipoId", cmbTipoRecepcion.SelectedValue)
                        cmd.Parameters.AddWithValue("@personaId", cmbPersona.SelectedValue)

                        nuevoIdRecepcion = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using

                    transaccion.Commit()

                    ' 4. MESAJE DE ÉXITO Y ACTUALIZACIÓN GLOBAL
                    MessageBox.Show($"¡Recepción N° {nuevoIdRecepcion} creada con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If frm IsNot Nothing Then
                        frm.IdRecepcionGlobal = nuevoIdRecepcion.ToString()
                        frm.IdPersonaGlobal = cmbPersona.SelectedValue.ToString()
                        frm.NombrePersonaGlobal = cmbPersona.Text

                        ' Navegar al siguiente paso si es necesario
                        ' frm.NavegarA(New ucSiguienteModulo())
                    End If

                Catch ex As Exception
                    transaccion.Rollback()
                    btnRegistrar.Enabled = True ' Reasigna si falla
                    btnRegistrar.Text = "Registrar"
                    Throw ex
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al registrar la recepción: " & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnRegistrar.Enabled = True
            btnRegistrar.Text = "Registrar"
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click

    End Sub
End Class
