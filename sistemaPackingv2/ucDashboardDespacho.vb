Imports MySql.Data.MySqlClient

Public Class ucDashboardDespacho


    ' Variable a nivel de clase para guardar el ID del proceso activo en memoria
    Private idProcesoActivo As Integer = 0

    Private Sub ucProcesoPallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarProcesosActivos()
        End If
    End Sub

    ' 1. Carga del proceso activo y control de visibilidad
    Private Sub CargarProcesosActivos()
        Try
            ' Buscamos el proceso activo. Usamos LIMIT 1 por si acaso, 
            ' ya que en un Label solo podemos mostrar uno.
            Dim sql As String = "SELECT id, concat('Despacho N° ', id) As NombreProceso " &
                                    "FROM despachos WHERE estados_despachos_id = 1 AND estado = 1 LIMIT 1;"

            Dim dt As DataTable = ObtenerDatos(sql)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' ✅ HAY UN PROCESO ACTIVO
                idProcesoActivo = Convert.ToInt32(dt.Rows(0)("id"))
                lblProcesoActual.Text = dt.Rows(0)("NombreProceso").ToString()

                ' Actualizamos los contadores de pallets y cajas pasándole la variable
                ActualizarContadores(idProcesoActivo)

                ' Mostramos el botón de Terminar, Ocultamos el de Crear
                btnTerminarDespacho.Visible = True
                btnCrearDespacho.Visible = False
            Else
                ' ❌ NO HAY PROCESOS ACTIVOS
                idProcesoActivo = 0
                lblProcesoActual.Text = "Ningún proceso activo"
                lblPallet.Text = "0"
                lblCajas.Text = "0"

                ' Mostramos el botón de Crear, Ocultamos el de Terminar
                btnTerminarDespacho.Visible = False
                btnCrearDespacho.Visible = True

                ' (Opcional) Puedes comentar el MessageBox si no quieres que avise cada vez que abres la pestaña
                MessageBox.Show("No hay procesos de paletizado abiertos el día de hoy.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar el proceso activo: " & ex.Message)
        End Try
    End Sub

    ' 2. Método para leer los conteos de la BD y actualizar los Labels
    Private Sub ActualizarContadores(idProceso As Integer)
        Dim sqlPallets As String = "SELECT count(a.id) FROM pallets a " &
                                "JOIN despachos_pallets b ON a.id = b.pallets_id " &
                                "JOIN despachos c ON b.despachos_id = c.id " &
                                "WHERE b.estados_despachos_pallets_id = 2 AND c.estados_despachos_id = 1;"      ' "SELECT count(id) FROM pallets WHERE despachos_pallets_id = @idProcesoPallet;"
        Dim sqlCajas As String = "SELECT count(a.id) FROM cajas a " &
                                 "INNER Join pallets b ON a.pallet_id = b.id " &
                                 "INNER Join despachos_pallets c ON b.id = c.pallets_id " &
                                 "INNER Join despachos d On c.despachos_id = d.id " &
                                 "WHERE d.estados_despachos_id = 1 And c.estados_despachos_pallets_id = 2;"  ' "SELECT count(a.id) FROM cajas a INNER JOIN pallets b ON a.pallet_id = b.id WHERE b.procesos_paletizado_id = @idProcesoPallet;"

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

    ' 3. Creación de Nuevo Proceso
    Private Sub btnCrearDespacho_Click(sender As Object, e As EventArgs) Handles btnCrearDespacho.Click
        Dim idUsuario As Integer = 1
        Dim idEstadoProceso As Integer = 1

        Dim sqlInsert As String = "INSERT INTO despachos (users_id, estados_despachos_id, fecha_inicio, estado) " &
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

            ' 🔄 Al recargar, automáticamente detectará el nuevo proceso y actualizará la UI.
            CargarProcesosActivos()

        Catch ex As Exception
            MessageBox.Show("Error al crear el proceso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' 4. Finalizar el proceso actual
    Private Sub btnTerminarDespacho_Click(sender As Object, e As EventArgs) Handles btnTerminarDespacho.Click
        ' Validamos usando la variable de clase, si es 0 no hay nada que terminar
        If idProcesoActivo = 0 Then Return

        Dim resp = MessageBox.Show("¿Está seguro que desea terminar y cerrar este proceso de paletizado?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resp = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()

                ' Iniciamos transacción para asegurar consistencia
                Using transaccion = ConexionBD.conexion.BeginTransaction()
                    Try
                        ' Usamos parámetros SQL (@id) para mayor seguridad y evitar concatenaciones
                        Dim sqlUpdate As String = "UPDATE despachos SET estados_despachos_id = 2, fecha_fin = NOW() WHERE id = @id"

                        ' Ejecutar actualización de Proceso
                        Using cmd = New MySqlCommand(sqlUpdate, ConexionBD.conexion, transaccion)
                            cmd.Parameters.AddWithValue("@id", idProcesoActivo)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Confirmamos
                        transaccion.Commit()
                        MessageBox.Show("Proceso finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

            ' 🔄 Refrescamos la pantalla para que limpie el Label, ponga los contadores en 0 
            ' y muestre el botón de crear proceso nuevamente.
            CargarProcesosActivos()
        End If
    End Sub

    Private Sub btnAgregarPallet_Click(sender As Object, e As EventArgs) Handles btnAgregarPallet.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)

        ' En lugar de NavegarA (que destruye el anterior), lo agregamos encima
        Dim ucCrearOrdenDespacho As New ucCrearOrdenDespacho()
        ucCrearOrdenDespacho.Dock = DockStyle.Fill

        ' Agregamos al panel y lo traemos al frente
        frm.pnlContenedor.Controls.Add(ucCrearOrdenDespacho)
        ucCrearOrdenDespacho.BringToFront()


    End Sub

    Private Sub btnValidarPallet_Click(sender As Object, e As EventArgs) Handles btnValidarPallet.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)

        ' En lugar de NavegarA (que destruye el anterior), lo agregamos encima
        Dim ucOrdenDespachoRepesaje As New ucOrdenDespachoRepesaje()
        ucOrdenDespachoRepesaje.Dock = DockStyle.Fill

        ' Agregamos al panel y lo traemos al frente
        frm.pnlContenedor.Controls.Add(ucOrdenDespachoRepesaje)
        ucOrdenDespachoRepesaje.BringToFront()
    End Sub
End Class
