Imports System.Drawing.Printing

Public Class ucImpresionCalibres

    ' --- Variables para controlar la paginación ---
    Private totalCopias As Integer = 0
    Private copiasImpresas As Integer = 0
    Private textoCalibre As String = ""

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ' 1. Validaciones
        If String.IsNullOrWhiteSpace(txtCalibre.Text) Then
            MessageBox.Show("Debe ingresar un valor para el calibre (Ej: 18, EX).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If nudCopias.Value <= 0 Then
            MessageBox.Show("La cantidad de copias debe ser mayor a 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Capturamos los datos
        textoCalibre = txtCalibre.Text.Trim().ToUpper()
        totalCopias = Convert.ToInt32(nudCopias.Value)
        copiasImpresas = 0 ' Reiniciamos el contador

        ' 3. Configuramos la impresión
        Dim pd As New PrintDocument()
        ' Tamaño de 100mm x 200mm convertido a centésimas de pulgada (394 x 787)
        pd.DefaultPageSettings.PaperSize = New PaperSize("Calibres", 394, 787)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        ' Vinculamos el evento de diseño de página
        AddHandler pd.PrintPage, AddressOf pd_PrintPage

        ' 4. Mandamos a imprimir
        Try
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pd_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Configuraciones de tamaño para que quepan 5x10 (50 recuadros)
        Dim anchoCaja As Integer = 74
        Dim altoCaja As Integer = 75
        Dim espaciadoX As Integer = 3
        Dim espaciadoY As Integer = 3

        ' Margen inicial para centrar todo el bloque en la hoja
        Dim margenInicioX As Integer = 6
        Dim margenInicioY As Integer = 5

        ' Ajusté un poco el tamaño de fuente para asegurar que letras como "EX" entren bien en los 74px de ancho
        Using fCalibreNumero As New Font("Arial", 28, FontStyle.Bold),
              fCalibreLabel As New Font("Arial", 7, FontStyle.Bold)

            ' Límites de nuestra cuadrícula
            Dim maxColumnas As Integer = 5
            Dim maxFilas As Integer = 10

            ' Bucle para Filas y Columnas
            For f As Integer = 0 To maxFilas - 1
                For c As Integer = 0 To maxColumnas - 1

                    ' Si ya imprimimos todas las copias solicitadas, detenemos el proceso
                    If copiasImpresas >= totalCopias Then
                        e.HasMorePages = False
                        Return
                    End If

                    ' Calcular coordenadas X e Y exactas para este recuadro
                    Dim x As Integer = margenInicioX + c * (anchoCaja + espaciadoX)
                    Dim y As Integer = margenInicioY + f * (altoCaja + espaciadoY)

                    ' Dibujar el rectángulo (El contorno)
                    Dim recCalibre As New Rectangle(x, y, anchoCaja, altoCaja)
                    e.Graphics.DrawRectangle(Pens.Black, recCalibre)

                    ' Dibujar texto "CALIBRE" centrado
                    Dim tamCalLabel = e.Graphics.MeasureString("CALIBRE", fCalibreLabel)
                    Dim posXLabel As Single = recCalibre.X + (anchoCaja - tamCalLabel.Width) / 2
                    e.Graphics.DrawString("CALIBRE", fCalibreLabel, Brushes.Black, posXLabel, recCalibre.Y + 4)

                    ' Dibujar el Valor (Ej: 18, EX) centrado
                    Dim tamCalNum = e.Graphics.MeasureString(textoCalibre, fCalibreNumero)
                    Dim posXNum As Single = recCalibre.X + (anchoCaja - tamCalNum.Width) / 2
                    e.Graphics.DrawString(textoCalibre, fCalibreNumero, Brushes.Black, posXNum, recCalibre.Y + 20)

                    ' Aumentar el contador de impresiones
                    copiasImpresas += 1
                Next
            Next

            ' Si terminamos de recorrer toda la página (50 cajas) y aún faltan copias por imprimir,
            ' le decimos a la impresora que necesitamos otra página.
            If copiasImpresas < totalCopias Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

        End Using
    End Sub

End Class