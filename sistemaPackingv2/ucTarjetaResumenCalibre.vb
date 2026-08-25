'Public Class ucTarjetaResumenCalibre

'Public Sub CargarDatos(row As DataRow)
' Título
'lblNombreCalibre.Text = row("Nombre_Calibre").ToString().ToUpper()
'
' Totales
'lblBinsTotales.Text = String.Format("Bins: {0:N0}", row("Bins_Totales"))  'row("Bins_Totales").ToString()
'lblKilosTotales.Text = String.Format("{0:N0} kg", row("Kilos_Totales"))
'lblPorcTotales.Text = String.Format("{0:N1}%", row("Porcentaje_Totales"))


'End Sub

'Public Sub ActualizarGrafico(porcentaje As Double)
' Supongamos que pnlBarraFondo es el contenedor y pnlBarraColor es la barrita
'Dim anchoMaximo As Integer = pnlBarraFondo.Width
'pnlBarraColor.Width = CInt((porcentaje / 100) * anchoMaximo)
'
' Cambio de color según concentración
'If porcentaje > 40 Then
'pnlBarraColor.BackColor = Color.OrangeRed
'Else
'pnlBarraColor.BackColor = Color.SteelBlue
'End If
'End Sub
'End Class

Public Class ucTarjetaResumenCalibre

    Public Sub CargarDatos(row As DataRow)
        ' 1. Extraer valores para cálculos
        Dim nombre As String = row("Nombre_Calibre").ToString().ToUpper()
        Dim bins As Integer = Convert.ToInt32(row("Bins_Totales"))
        Dim kilos As Double = Convert.ToDouble(row("Kilos_Totales"))
        Dim porcentaje As Double = Convert.ToDouble(row("Porcentaje_Totales"))

        ' 2. Título y Totales Principales
        lblNombreCalibre.Text = nombre
        lblKilosTotales.Text = String.Format("{0:N0} kg", kilos)
        lblBinsTotales.Text = String.Format("{0:N0} Bins", bins)

        ' 3. Cálculo de Densidad (Kilos promedio por bin)
        ' Usamos una fórmula simple: $$Promedio = \frac{Kilos}{Bins}$$
        If bins > 0 Then
            Dim promedio As Double = kilos / bins
            lblPromedio.Text = String.Format("Prom: {0:N1} kg/bin", promedio)
        Else
            lblPromedio.Text = "Prom: 0 kg/bin"
        End If

        ' 4. Porcentaje y Gráfico
        lblPorcTotales.Text = String.Format("Stock: {0:N1}%", porcentaje)
        ActualizarGrafico(porcentaje)
    End Sub

    Private Sub ActualizarGrafico(porcentaje As Double)
        ' Aseguramos que la barra no se salga del contenedor
        Dim porcLimitado As Double = Math.Min(porcentaje, 100)
        Dim anchoMaximo As Integer = pnlBarraFondo.Width

        pnlBarraColor.Width = CInt((porcLimitado / 100) * anchoMaximo)

        ' Semántica de colores (Lógica de alertas)
        Select Case porcentaje
            Case > 40
                pnlBarraColor.BackColor = Color.FromArgb(231, 76, 60) ' Rojo suave (Alerta de saturación)
            Case 15 To 40
                pnlBarraColor.BackColor = Color.FromArgb(46, 204, 113) ' Verde (Stock saludable)
            Case Else
                pnlBarraColor.BackColor = Color.FromArgb(52, 152, 219) ' Azul (Baja concentración)
        End Select
    End Sub

End Class
