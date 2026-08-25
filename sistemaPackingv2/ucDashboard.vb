Imports MySql.Data.MySqlClient

Public Class ucDashboard
    Private Sub ucDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDashboard()
        CargarTarjetasPorCalibre()
        RenderizarTarjetas()



    End Sub

    Public Sub ActualizarDashboard()
        Try
            ConexionBD.Abrir()
            Dim sql = "SELECT * FROM vw_dashboard_general"
            Dim dt = ObtenerDatos(sql)

            If dt.Rows.Count > 0 Then
                ' Rellenamos los Labels con formato de miles
                lblTotalKilos.Text = String.Format("{0:N0} kg", dt.Rows(0)("Kilos_Globales"))
                lblRecepcionKilos.Text = String.Format("{0:N0} kg", dt.Rows(0)("Kilos_Recepcion"))
                lblCamarasKilos.Text = String.Format("{0:N0} kg", dt.Rows(0)("Kilos_Camaras"))
                lblContStock.Text = dt.Rows(0)("Bins_Globales").ToString()
                lblContRecepcion.Text = dt.Rows(0)("Bins_Recepcion").ToString()
                lblContCamaras.Text = dt.Rows(0)("Bins_Camaras").ToString()

            End If
        Catch ex As Exception
            ' Manejo de error
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub



    Public Sub CargarTarjetasPorCalibre()
        Try
            flpCalibres.SuspendLayout()
            flpCalibres.Controls.Clear()

            ' 1. Pedimos los datos al módulo
            Dim dt As DataTable = Datos.ObtenerTarjetasCalibres()

            ' 2. Creamos las tarjetas
            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    Dim tarjeta As New ucTarjetaResumenCalibre()

                    ' 3. La tarjeta se encarga de sus propios Labels
                    tarjeta.CargarDatos(row)

                    flpCalibres.Controls.Add(tarjeta)
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            flpCalibres.ResumeLayout()
        End Try
    End Sub



    Private Sub MiPanel_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias ' Suavizado de bordes

        Dim radio As Integer = 20 ' Ajusta el radio del suavizado
        Dim rect As New Rectangle(0, 0, Panel1.Width - 1, Panel1.Height - 1)
        Dim path As New Drawing2D.GraphicsPath()

        ' Creamos la ruta con arcos para las esquinas
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.X + rect.Width - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.X + rect.Width - radio, rect.Y + rect.Height - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Y + rect.Height - radio, radio, radio, 90, 90)
        path.CloseAllFigures()

        ' Aplicar la región al panel (esto corta las esquinas)
        Panel1.Region = New Region(path)

        ' Opcional: Dibujar un borde suave
        Using pen As New Pen(Color.Gray, 2)
            g.DrawPath(pen, path)
        End Using
    End Sub

    Public Sub RenderizarTarjetas()
        ' 1. Limpiamos el panel para no duplicar si refrescamos
        flpContenedor.Controls.Clear()
        flpContenedor.SuspendLayout() ' Mejora el rendimiento al cargar muchos

        Try
            ConexionBD.Abrir()
            Dim dt As New DataTable()
            Dim sql As String = "SELECT * FROM vw_tarjetas_inventario"
            Dim adapter As New MySqlDataAdapter(sql, ConexionBD.conexion)
            adapter.Fill(dt)

            For Each row As DataRow In dt.Rows
                ' 2. Creamos una instancia de nuestro UserControl (el molde)
                Dim tarjeta As New ucTarjetaUbicacion()

                ' 3. Seteamos los datos
                tarjeta.lblUbicacion.Text = row("Nombre_Ubicacion").ToString().ToUpper()
                tarjeta.lblKilos.Text = String.Format("{0:N0} kg", row("Kilos_Totales"))
                tarjeta.lblBins.Text = row("Cantidad_Bins").ToString() & " CONTENEDORES"
                tarjeta.lblDetalle.Text = row("Detalle_Calibres").ToString()

                ' 4. Lógica visual: Si es patio (ID 1) lo pintamos distinto
                If Convert.ToInt32(row("id_ubicacion")) = 1 Then
                    tarjeta.pnlCabecera.BackColor = Color.SeaGreen
                End If

                ' 5. Agregamos el cuadro al panel
                flpContenedor.Controls.Add(tarjeta)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar dashboard: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
            flpContenedor.ResumeLayout()
        End Try
    End Sub

End Class
