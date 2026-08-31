Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports ZXing

Public Class ucTicket
    Private _idRecepcion As Integer
    Private _nCiclo As Integer
    Private _etiquetaFiltro As String = ""

    Public Sub New(idRecepcion As Integer, ciclo As Integer)
        InitializeComponent()
        _idRecepcion = idRecepcion
        _nCiclo = ciclo
    End Sub

    Private Sub ucConfirmacionPesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrillaPorLlaves()
    End Sub

    ' --- CARGA DE DATOS INDEXADA ---
    Private Sub CargarGrillaPorLlaves()
        Try
            ConexionBD.Abrir()

            Dim sql As String = "SELECT codigo, recepcion,prefijo , tipo,productor, producto, variedad, tara, bruto, neto, ciclo, numero, calibre, estado, fecha, hora " &
                             "FROM vw_recepciones_detalles_resumen " &
                             "WHERE recepcion = @idR AND ciclo = @ciclo"

            Dim da As New MySqlDataAdapter(sql, ConexionBD.conexion)
            da.SelectCommand.Parameters.AddWithValue("@idR", _idRecepcion)
            da.SelectCommand.Parameters.AddWithValue("@ciclo", _nCiclo)

            Dim dt As New DataTable()
            da.Fill(dt)

            ' 2. CREACIÓN DINÁMICA DE LA ETIQUETA PARA LA GRILLA
            dt.Columns.Add("etiqueta", GetType(String))

            For Each row As DataRow In dt.Rows
                Dim pref As String = row("prefijo").ToString()
                Dim rec As String = row("recepcion").ToString()
                Dim cic As String = row("ciclo").ToString()

                ' Arma la etiqueta y la inserta en la fila correspondiente
                row("etiqueta") = $"{pref}-{rec.PadLeft(2, "0"c)}-{cic}"
            Next

            ' 3. Se asigna el origen de datos al DGV (ahora incluye la columna etiqueta)
            dgvFinal.DataSource = dt

            ' 4. Guardar variable global (no fallará porque ya creamos la columna)
            If dt.Rows.Count > 0 Then
                _etiquetaFiltro = dt.Rows(0)("etiqueta").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al recuperar datos del ciclo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub


    Private Function GenerarImagenBarcode(texto As String) As Bitmap
        Try
            Dim escritor As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128
            }
            escritor.Options = New Common.EncodingOptions With {
                .Width = 350,
                .Height = 100,
                .Margin = 2
            }
            Return escritor.Write(texto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' --- LÓGICA DE IMPRESIÓN EN LOTE ---
    Private Sub btnImprimirTodo_Click(sender As Object, e As EventArgs) Handles btnImprimirTodo.Click
        If dgvFinal.Rows.Count = 0 Then Return

        For Each row As DataGridViewRow In dgvFinal.Rows
            If Not row.IsNewRow Then
                ImprimirTicketIndividual(row)
            End If
        Next
    End Sub

    Private Sub ImprimirTicketIndividual(row As DataGridViewRow)
        Dim pd As New PrintDocument()
        ' CORREGIDO: Medidas de 100mm x 200mm (394 x 787 centésimas de pulgada)
        pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        Dim filaSeleccionada = row
        AddHandler pd.PrintPage, Sub(sender, e)
                                     DisenoTicket100x200(e, filaSeleccionada)
                                 End Sub
        pd.Print()
    End Sub

    ' --- BOTÓN PARA IMPRIMIR ETIQUETA QR GIGANTE ---
    Private Sub btnImpQr_Click(sender As Object, e As EventArgs) Handles btnImpQr.Click
        If dgvFinal.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una fila primero.")
            Return
        End If

        ' Ahora pasamos la fila completa, no solo el ID
        Dim filaSeleccionada = dgvFinal.CurrentRow

        Dim pd As New PrintDocument()
        ' Ajustado a 100x150mm (394x590) para que quepa el QR gigante + los 7 datos + código de barras
        pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
        pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        AddHandler pd.PrintPage, Sub(s, ev)
                                     DisenoTicketQR_Grande(ev, filaSeleccionada)
                                 End Sub
        pd.Print()
    End Sub

    ' --- DISEÑO DEL TICKET QR GIGANTE (100mm x 150mm) ---
    Private Sub DisenoTicketQR_Grande(e As PrintPageEventArgs, row As DataGridViewRow)
        Dim anchoPapel As Integer = 394
        Dim x As Integer = 20
        Dim y As Integer = 20

        Using fCalibreNumero As New Font("Arial", 38, FontStyle.Bold),
              fCalibreLabel As New Font("Arial", 8, FontStyle.Bold),
              fDatosLabel As New Font("Arial", 11, FontStyle.Bold),
              fDatosValor As New Font("Arial", 11),
              fTimestamp As New Font("Arial", 9, FontStyle.Italic)

            Dim codigoBin As String = ObtenerTextoCelda(row, "codigo")

            ' 1. CÓDIGO QR GIGANTE A LA IZQUIERDA (220x220 px)
            Dim tamQR As Integer = 220
            Dim escritorQR As New ZXing.BarcodeWriter With {
                .Format = ZXing.BarcodeFormat.QR_CODE
            }
            escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {
                .Height = tamQR,
                .Width = tamQR,
                .Margin = 0
            }
            Using bmpQR As Bitmap = escritorQR.Write(codigoBin)
                If bmpQR IsNot Nothing Then
                    e.Graphics.DrawImage(bmpQR, x, y, tamQR, tamQR)
                End If
            End Using

            ' 2. RECUADRO DE CALIBRE (NÚMERO) A LA DERECHA
            Dim numCalibre As String = ObtenerTextoCelda(row, "numero")
            Dim recCalibre As New Rectangle(anchoPapel - 100, y, 80, 75)
            e.Graphics.DrawRectangle(Pens.Black, recCalibre)

            Dim tamCalLabel = e.Graphics.MeasureString("CALIBRE", fCalibreLabel)
            e.Graphics.DrawString("CALIBRE", fCalibreLabel, Brushes.Black, recCalibre.X + (80 - tamCalLabel.Width) / 2, recCalibre.Y + 4)

            Dim tamCalNum = e.Graphics.MeasureString(numCalibre, fCalibreNumero)
            e.Graphics.DrawString(numCalibre, fCalibreNumero, Brushes.Black, recCalibre.X + (80 - tamCalNum.Width) / 2, recCalibre.Y + 18)

            ' Avanzamos Y justo debajo del QR
            y += tamQR + 10

            ' LÍNEA SEPARADORA
            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 10

            ' 3. LISTA DE DATOS SOLICITADOS
            Dim etiqueta As String = ObtenerTextoCelda(row, "etiqueta")

            Dim datos As New Dictionary(Of String, String) From {
                {"Código ID:", codigoBin},
                {"Recepción:", ObtenerTextoCelda(row, "recepcion")},
                {"Tipo:", etiqueta},
                {"Productor:", ObtenerTextoCelda(row, "productor")},
                {"Producto:", ObtenerTextoCelda(row, "producto")},
                {"Variedad:", ObtenerTextoCelda(row, "variedad")},
                {"Calibre:", ObtenerTextoCelda(row, "calibre")}
            }

            Dim posXValor As Integer = 120 ' Tabulación para que los valores queden alineados
            For Each item In datos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, y)
                y += 24 ' Espaciado entre lineas
            Next

            ' LÍNEA SEPARADORA
            y += 5
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 10

            ' 4. CÓDIGO DE BARRAS INFERIOR
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(codigoBin)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    ' Reducimos la altura del barcode a 60px para optimizar el espacio inferior
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 60)
                    y += 65
                End If
            End Using

            ' 5. FECHA Y HORA AL FINAL
            Dim fechaVal As String = ObtenerTextoCelda(row, "fecha")
            Dim horaVal As String = ObtenerTextoCelda(row, "hora")
            e.Graphics.DrawString($"Fecha: {fechaVal} {horaVal}", fTimestamp, Brushes.Black, x, y)
        End Using
    End Sub

    ' --- DISEÑO DEL TICKET PRINCIPAL ---
    Private Sub DisenoTicket100x200(e As PrintPageEventArgs, row As DataGridViewRow)
        Dim anchoPapel As Integer = 394
        Dim x As Integer = 20
        Dim y As Integer = 20

        Using fTitulo As New Font("Arial", 14, FontStyle.Bold),
              fCalibreNumero As New Font("Arial", 38, FontStyle.Bold),
              fCalibreLabel As New Font("Arial", 8, FontStyle.Bold),
              fDatosLabel As New Font("Arial", 11, FontStyle.Bold),
              fDatosValor As New Font("Arial", 11),
              fNetoValue As New Font("Arial", 15, FontStyle.Bold),
              fTimestamp As New Font("Arial", 9, FontStyle.Italic),
              fEtiqueta As New Font("Arial", 9, FontStyle.Italic)

            ' 0. LEER EL ID
            Dim codigoBin As String = ObtenerTextoCelda(row, "codigo")

            ' 1. CÓDIGO QR A LA IZQUIERDA
            Dim escritorQR As New ZXing.BarcodeWriter With {
                .Format = ZXing.BarcodeFormat.QR_CODE
            }
            escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {
                .Height = 75,
                .Width = 75,
                .Margin = 0
            }
            Using bmpQR As Bitmap = escritorQR.Write(codigoBin)
                If bmpQR IsNot Nothing Then
                    e.Graphics.DrawImage(bmpQR, x, y, 75, 75)
                End If
            End Using

            ' 2. RECUADRO DE CALIBRE A LA DERECHA
            Dim numCalibre As String = ObtenerTextoCelda(row, "numero")
            Dim recCalibre As New Rectangle(anchoPapel - 100, y, 80, 75)
            e.Graphics.DrawRectangle(Pens.Black, recCalibre)

            Dim tamCalLabel = e.Graphics.MeasureString("CALIBRE", fCalibreLabel)
            e.Graphics.DrawString("CALIBRE", fCalibreLabel, Brushes.Black, recCalibre.X + (80 - tamCalLabel.Width) / 2, recCalibre.Y + 4)

            Dim tamCalNum = e.Graphics.MeasureString(numCalibre, fCalibreNumero)
            e.Graphics.DrawString(numCalibre, fCalibreNumero, Brushes.Black, recCalibre.X + (80 - tamCalNum.Width) / 2, recCalibre.Y + 18)

            ' 3. TÍTULO EN EL MEDIO (CENTRADO)
            Dim titulo As String = "PALTAS EL CHEJO"
            Dim tamTitulo = e.Graphics.MeasureString(titulo, fTitulo)
            ' Centrado horizontal entre el QR y el Calibre
            Dim xTitulo As Single = (anchoPapel - tamTitulo.Width) / 2
            ' Centrado vertical alineado a la altura de 75px del QR/Calibre
            Dim yTitulo As Single = y + ((75 - tamTitulo.Height) / 2)
            e.Graphics.DrawString(titulo, fTitulo, Brushes.Black, xTitulo, yTitulo)

            ' 4. LÍNEA SEPARADORA CABECERA
            y += 85
            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 15

            ' 5. LECTURA Y DIBUJO DE DATOS
            Dim bruto As Decimal = ObtenerDecimalCelda(row, "bruto")
            Dim neto As Decimal = ObtenerDecimalCelda(row, "neto")
            Dim tara As Decimal = ObtenerDecimalCelda(row, "tara")
            ' Dim etiqueta As String = ObtenerTextoCelda(row, "etiqueta")

            Dim datos As New Dictionary(Of String, String) From {
                {"Código ID:", codigoBin},
                {"Recepción:", ObtenerTextoCelda(row, "recepcion")},
                {"Tipo:", ObtenerTextoCelda(row, "tipo")},
                {"Ciclo:", ObtenerTextoCelda(row, "ciclo")},
                {"Productor:", ObtenerTextoCelda(row, "productor")},
                {"Producto:", ObtenerTextoCelda(row, "producto")},
                {"Variedad:", ObtenerTextoCelda(row, "variedad")},
                {"Calibre:", ObtenerTextoCelda(row, "calibre")},
                {"Kilos Brutos:", bruto.ToString("#,##0.#") & " kg"},
                {"Tara:", tara.ToString("#,##0.#") & " kg"}
            }

            Dim posXValor As Integer = 140
            For Each item In datos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, y)
                y += 26
            Next

            ' 6. KILOS NETOS DESTACADOS
            y += 5
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 10
            e.Graphics.DrawString("Kilos Netos:", fDatosLabel, Brushes.Black, x, y)
            e.Graphics.DrawString(neto.ToString("#,##0.#") & " kg", fNetoValue, Brushes.Black, posXValor, y)
            y += 32
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 20

            ' 7. CÓDIGO DE BARRAS INFERIOR
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(codigoBin)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 100)
                    y += 110
                End If
            End Using

            ' 8. FECHA Y HORA REGISTRO
            Dim fechaVal As String = ObtenerTextoCelda(row, "fecha")
            Dim horaVal As String = ObtenerTextoCelda(row, "hora")
            e.Graphics.DrawString($"Fecha Reg: {fechaVal} {horaVal}", fTimestamp, Brushes.Black, x, y)
            ' e.Graphics.DrawString($"Etiqueta: {etiqueta}", fEtiqueta, Brushes.Black, x, y)
        End Using
    End Sub

    ' --- VISTA PREVIA CORREGIDA ---
    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        If dgvFinal.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una fila en la tabla primero.")
            Return
        End If

        Try
            Dim pd As New PrintDocument()
            ' CORREGIDO: Medida 100x200mm para que la previa concuerde con el diseño
            pd.DefaultPageSettings.PaperSize = New PaperSize("100x200", 394, 787)
            pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            Dim filaActual = dgvFinal.CurrentRow

            AddHandler pd.PrintPage, Sub(s, ev)
                                         DisenoTicket100x200(ev, filaActual)
                                     End Sub

            Dim ppd As New PrintPreviewDialog With {
                .Document = pd,
                .WindowState = FormWindowState.Maximized
            }
            CType(ppd, Form).ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error al generar la vista previa: " & ex.Message)
        End Try
    End Sub

    Private Sub btnVerQR_Click(sender As Object, e As EventArgs) Handles btnVerQR.Click
        If dgvFinal.CurrentRow Is Nothing Then Return
        MostrarVentanaQR_80mm(dgvFinal.CurrentRow.Cells("codigo").Value.ToString())
    End Sub

    ' --- MÉTODOS AUXILIARES DE PARSEO SEGURO ---
    Private Function ObtenerTextoCelda(row As DataGridViewRow, colName As String) As String
        If row.Cells(colName) IsNot Nothing AndAlso row.Cells(colName).Value IsNot DBNull.Value Then
            Return row.Cells(colName).Value.ToString()
        End If
        Return "-"
    End Function

    Private Function ObtenerDecimalCelda(row As DataGridViewRow, colName As String) As Decimal
        If row.Cells(colName) IsNot Nothing AndAlso row.Cells(colName).Value IsNot DBNull.Value Then
            Dim val As Decimal
            If Decimal.TryParse(row.Cells(colName).Value.ToString(), val) Then
                Return val
            End If
        End If
        Return 0
    End Function

    Private Sub MostrarVentanaQR_80mm(idBin As String)
        Dim medidaPx As Integer = 302
        Dim margen As Integer = 10

        Dim frmQR As New Form With {
            .Text = "QR - ID: " & idBin,
            .Size = New Size(medidaPx + 40, medidaPx + 200),
            .StartPosition = FormStartPosition.CenterScreen,
            .BackColor = Color.White,
            .FormBorderStyle = FormBorderStyle.FixedSingle,
            .MaximizeBox = False
        }

        Dim picQR As New PictureBox With {
            .Size = New Size(medidaPx, medidaPx),
            .Location = New Point(margen, margen),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        Dim escritorQR As New ZXing.BarcodeWriter With {.Format = ZXing.BarcodeFormat.QR_CODE}
        escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {.Height = medidaPx, .Width = medidaPx, .Margin = 0}
        picQR.Image = escritorQR.Write(idBin)

        Dim picBarcode As New PictureBox With {
            .Size = New Size(medidaPx, 80),
            .Location = New Point(margen, medidaPx + 15),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        Dim escritorBar As New ZXing.BarcodeWriter With {.Format = ZXing.BarcodeFormat.CODE_128}
        escritorBar.Options = New ZXing.Common.EncodingOptions With {.Height = 50, .Width = medidaPx, .Margin = 2, .PureBarcode = True}
        picBarcode.Image = escritorBar.Write(idBin)

        Dim lblID As New Label With {
            .Text = "ID: " & idBin,
            .Font = New Font("Consolas", 14, FontStyle.Bold),
            .TextAlign = ContentAlignment.TopCenter,
            .Location = New Point(margen, medidaPx + 100),
            .Size = New Size(medidaPx, 30)
        }

        frmQR.Controls.Add(picQR)
        frmQR.Controls.Add(picBarcode)
        frmQR.Controls.Add(lblID)
        frmQR.ShowDialog()
    End Sub

    ' --- NAVEGACIÓN ---
    Private Sub btnNuevaRecepcion_Click(sender As Object, e As EventArgs) Handles btnNuevaRecepcion.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        If frm IsNot Nothing Then
            frm.PesoDesdeBascula = 0
            frm.NavegarA(New ucRecepcion())
        End If
    End Sub

    Private Sub btnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        If frm IsNot Nothing Then
            Dim ucFinal As New ucRecepcionFinal(_idRecepcion) With {.Dock = DockStyle.Fill}
            frm.pnlContenedor.Controls.Add(ucFinal)
            ucFinal.BringToFront()
        End If
    End Sub
End Class