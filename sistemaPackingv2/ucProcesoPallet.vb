Imports MySql.Data.MySqlClient

Public Class ucProcesoPallet



    Private Sub ucProcesoPallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarProcesosActivos()
        End If
    End Sub

    ' 1. Carga de procesos y control de visibilidad de botones
    Private Sub CargarProcesosActivos()
        Try
            ' Buscamos los procesos cuyo estado sea "Abierto/Activo"
            Dim sql As String = "SELECT id, concat('Proceso N° ', id) As NombreProceso " &
                           " FROM procesos_paletizado WHERE estados_procesos_pallets_id = 1 AND estado = 1; "

            Dim dt As DataTable = ObtenerDatos(sql)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' ✅ HAY PROCESOS ACTIVOS
                cmbProcesos.DataSource = dt
                cmbProcesos.DisplayMember = "NombreProceso"
                cmbProcesos.ValueMember = "id"

                ' Mostramos el botón de Terminar, Ocultamos el de Crear
                btnTerminarProcesoPallet.Visible = True
                btnCrearProcesoPallet.Visible = False
            Else
                ' ❌ NO HAY PROCESOS ACTIVOS
                cmbProcesos.DataSource = Nothing
                lblPallet.Text = "0"
                lblCajas.Text = "0"

                ' Mostramos el botón de Crear, Ocultamos el de Terminar
                btnTerminarProcesoPallet.Visible = False
                btnCrearProcesoPallet.Visible = True

                MessageBox.Show("No hay procesos de paletizado abiertos el día de hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar procesos activos: " & ex.Message)
        End Try
    End Sub

    ' 2. Evento: Se dispara cuando el operador elige otro proceso en el ComboBox
    Private Sub cmbProcesos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcesos.SelectedIndexChanged
        ' Validamos que haya un valor seleccionado y que ya sea un número (ID)
        If cmbProcesos.SelectedValue IsNot Nothing AndAlso TypeOf cmbProcesos.SelectedValue Is Integer Then
            Dim idProcesoActual As Integer = Convert.ToInt32(cmbProcesos.SelectedValue)
            ActualizarContadores(idProcesoActual)
        End If
    End Sub

    ' 3. Método para leer los conteos de la BD y actualizar los Labels
    Private Sub ActualizarContadores(idProceso As Integer)
        ' Tus consultas SQL
        Dim sqlPallets As String = "SELECT count(id) FROM pallets WHERE procesos_paletizado_id = @idProcesoPallet;"
        Dim sqlCajas As String = "SELECT count(a.id) FROM cajas a INNER JOIN pallets b ON a.pallet_id = b.id WHERE b.procesos_paletizado_id = @idProcesoPallet;"

        Try
            ConexionBD.Abrir()

            ' Obtenemos la cantidad de pallets
            Using cmdPallet As New MySqlCommand(sqlPallets, ConexionBD.conexion)
                cmdPallet.Parameters.AddWithValue("@idProcesoPallet", idProceso)
                Dim cantidadPallets = Convert.ToInt32(cmdPallet.ExecuteScalar())
                lblPallet.Text = cantidadPallets.ToString()
            End Using

            ' Obtenemos la cantidad de cajas
            Using cmdCajas As New MySqlCommand(sqlCajas, ConexionBD.conexion)
                cmdCajas.Parameters.AddWithValue("@idProcesoPallet", idProceso)
                Dim cantidadCajas = Convert.ToInt32(cmdCajas.ExecuteScalar())
                lblCajas.Text = cantidadCajas.ToString()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar contadores: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' 4. Creación de Nuevo Proceso
    Private Sub btnCrearProcesoPallet_Click(sender As Object, e As EventArgs) Handles btnCrearProcesoPallet.Click
        Dim idUsuario As Integer = 1
        Dim idEstadoProceso As Integer = 1

        Dim sqlInsert As String = "INSERT INTO procesos_paletizado (users_id, estados_procesos_pallets_id, fecha_inicio, estado) " &
                              "VALUES (@idUser, @idEstado, NOW(), 1); " &
                              "SELECT LAST_INSERT_ID();"

        Dim idProcesoCreado As Integer = 0

        Try
            Using cmd As New MySqlCommand(sqlInsert, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idUser", idUsuario)
                cmd.Parameters.AddWithValue("@idEstado", idEstadoProceso)

                ConexionBD.Abrir()
                idProcesoCreado = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            MessageBox.Show("Proceso #" & idProcesoCreado & " creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 🔄 MAGIA AQUÍ: Volvemos a cargar. Esto ocultará automáticamente este botón,
            ' mostrará el de "Terminar", poblará el ComboBox y actualizará los labels a 0.
            CargarProcesosActivos()

        Catch ex As Exception
            MessageBox.Show("Error al crear el proceso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' 5. Estructura base para cuando presiones "Terminar Proceso"
    Private Sub btnTerminarProcesoPallet_Click(sender As Object, e As EventArgs) Handles btnTerminarProcesoPallet.Click
        If cmbProcesos.SelectedValue Is Nothing Then Return

        Dim resp = MessageBox.Show("¿Está seguro que desea terminar y cerrar este proceso de paletizado?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = DialogResult.Yes Then

            Dim idProcesoActual As Integer = Convert.ToInt32(cmbProcesos.SelectedValue)


            ' Aquí debes colocar tu lógica UPDATE a la base de datos
            ' Ej: "UPDATE procesos_paletizado SET estado = 2, fecha_fin = NOW() WHERE id = " & idProcesoActual

            ' Una vez cerrado en BD, recargamos la pantalla para que limpie todo:
            ' MessageBox.Show("Proceso terminado correctamente.")
            ' CargarProcesosActivos()


            Try
                ConexionBD.Abrir()

                ' Iniciamos transacción para asegurar consistencia
                Using transaccion = ConexionBD.conexion.BeginTransaction()
                    Try
                        ' 1. SQL para finalizar el Proceso
                        Dim sqlUpdate As String = "UPDATE procesos_paletizado SET estados_procesos_pallets_id = 2, fecha_fin = NOW() WHERE id = " & idProcesoActual



                        ' Ejecutar actualización de Proceso
                        Using cmd = New MySqlCommand(sqlUpdate, ConexionBD.conexion, transaccion)
                            cmd.Parameters.AddWithValue("@id", idProcesoActual)
                            cmd.ExecuteNonQuery()
                        End Using



                        ' Si ambas tuvieron éxito, confirmamos
                        transaccion.Commit()

                        ' --- Navegación y Limpieza ---
                        '   Dim frm = DirectCast(Me.FindForm(), Form1)


                        MessageBox.Show("Proceso finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Navegar a la siguiente pantalla
                        ' frm.NavegarA(New ucNuevaRecepcion())

                    Catch ex As Exception
                        ' Si algo falla en los SQL, deshacemos todo
                        transaccion.Rollback()
                        Throw New Exception("Error interno en la base de datos: " & ex.Message)
                    End Try
                End Using

            Catch ex As Exception
                MessageBox.Show("No se pudo finalizar el proceso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If

    End Sub

End Class