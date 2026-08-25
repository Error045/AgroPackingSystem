Imports MySql.Data.MySqlClient

Public Class ucEditarRecepcion

    Private _idRecepcion As Integer

    Public Sub New(idRecepcion As Integer)
        InitializeComponent()
        _idRecepcion = idRecepcion
    End Sub

    Private Sub ucEditarRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llamamos a la clase ConexionBD

        Dim sqlPersona As String = "SELECT id_recepcion,personas_id,nombre FROM vw_recepciones_personas"
        Dim dtPersona As DataTable = ObtenerDatos(sqlPersona) ' Llamada directa al módulo


        cmbPersona.DataSource = dtPersona
        cmbPersona.DisplayMember = "nombre"
        cmbPersona.ValueMember = "personas_id"
        cmbPersona.SelectedIndex = -1 ' Empieza vacío

        Dim sqlTipoRecepcion As String = "SELECT id, tipo FROM tipos_recepciones"
        Dim dtTipoRecepcion As DataTable = ObtenerDatos(sqlTipoRecepcion)

        cmbTipoRecepcion.DataSource = dtTipoRecepcion
        cmbTipoRecepcion.DisplayMember = "tipo"
        cmbTipoRecepcion.ValueMember = "id"
        cmbTipoRecepcion.SelectedIndex = -1 ' Empieza vacío



        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)

        lblRecepcion.Text = _idRecepcion

		cmbPersona.Text = frm.NombrePersonaGlobal


    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click


        Try
            ConexionBD.Abrir()

            ' 1. VALIDACIÓN: Comprobar si existen detalles asociados a esta recepción
            ' Usamos la variable _idRecepcion que ya tienes en la clase
            Dim sqlValidacion As String = "SELECT COUNT(*) FROM recepciones_detalles WHERE recepciones_id = @id"
            Dim conteoDetalles As Integer


            Using cmdCheck As New MySqlCommand(sqlValidacion, ConexionBD.conexion)
                cmdCheck.Parameters.AddWithValue("@id", _idRecepcion)
                conteoDetalles = Convert.ToInt32(cmdCheck.ExecuteScalar())
            End Using

            ' Si existen datos en detalles, bloqueamos la edición
            If conteoDetalles > 0 Then
                MessageBox.Show("No se puede modificar la recepción porque ya tiene detalles registrados.",
                            "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            ' 2. Validación de Interfaz (Campos vacíos)
            If cmbPersona.SelectedValue Is Nothing OrElse cmbTipoRecepcion.SelectedValue Is Nothing Then
                MessageBox.Show("Por favor, seleccione todos los campos requeridos.",
                            "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If


            ' 3. EJECUCIÓN DEL UPDATE

            Dim sqlUpdate As String = "UPDATE recepciones " &
                         "SET tipos_recepciones_id = @tipoId, " &
                         "    personas_id = @personaId, " &
                         "    fecha = @fecha, " &
                         "    hora = CURTIME() " &
                         "WHERE id = @id"

            Using cmd = New MySqlCommand(sqlUpdate, ConexionBD.conexion)
                ' 1. Datos desde ComboBox (IDs)
                cmd.Parameters.AddWithValue("@tipoId", cmbTipoRecepcion.SelectedValue)
                cmd.Parameters.AddWithValue("@personaId", cmbPersona.SelectedValue)

                ' 2. Dato de Fecha (puedes usar un control o la fecha de hoy)
                ' Opción A: Desde un DateTimePicker (Recomendado)
                cmd.Parameters.AddWithValue("@fecha", dateRecepcion.Value)

                ' Opción B: Fecha y hora actual del sistema
                'cmd.Parameters.AddWithValue("@fecha", DateTime.Now)

                ' 3. La variable de clase que identifica el registro
                cmd.Parameters.AddWithValue("@id", _idRecepcion)

                Dim filas As Integer = cmd.ExecuteNonQuery()

                If filas > 0 Then
                    MessageBox.Show("Registro actualizado correctamente.", "Éxito")
                    ' Navegación de retorno
                    Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
                    frm.NavegarA(New ucRecepcion())
                End If
            End Using


        Catch ex As Exception
            MessageBox.Show("Error al modificar: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub
End Class
