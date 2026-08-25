Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports ZXing ' Importar la librería instalada

Public Class ucConfirmacionPesaje
    Private _idRecepcion As Integer
    Private _nCiclo As Integer
    Private _etiquetaFiltro As String = "" ' Se llenará desde la BD
    Dim dRecepcion As Integer

    ' CONSTRUCTOR
    Public Sub New(idRecepcion As Integer, ciclo As Integer)
        InitializeComponent()
        _idRecepcion = idRecepcion
        dRecepcion = idRecepcion
        _nCiclo = ciclo
    End Sub

    Private Sub ucConfirmacionPesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblInfo.Text = $"Recepción: {_idRecepcion} | Ciclo: {_nCiclo}"
        CargarGrillaPorLlaves()
    End Sub

    ' --- CARGA DE DATOS INDEXADA ---
    Private Sub CargarGrillaPorLlaves()
        Try
            ConexionBD.Abrir()
            ' Nota: Asegúrate de que el nombre del campo sea 'etiqueta_ciclo' como en tu INSERT
            Dim sql As String = "SELECT codigo,recepcion,productor,producto,variedad ,tara, bruto, neto,ciclo ,etiqueta as etiqueta_ciclo FROM vw_recepciones_detalles_resumen " &
                                "WHERE recepcion = @idR And ciclo = @ciclo"

            Dim da As New MySqlDataAdapter(sql, ConexionBD.conexion)
            da.SelectCommand.Parameters.AddWithValue("@idR", _idRecepcion)
            da.SelectCommand.Parameters.AddWithValue("@ciclo", _nCiclo)

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvFinal.DataSource = dt

            ' ASIGNACIÓN DINÁMICA DE LA ETIQUETA
            If dt.Rows.Count > 0 Then
                ' Tomamos la etiqueta del primer registro para usarla en todos los tickets
                _etiquetaFiltro = dt.Rows(0)("etiqueta_ciclo").ToString()
                lblTituloTransaccion.Text = "ETIQUETA: " & _etiquetaFiltro
            End If

        Catch ex As Exception
            MessageBox.Show("Error al recuperar datos del ciclo: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub
    Private Function GenerarImagenBarcode(texto As String) As Bitmap
        Try
            Dim escritor As New BarcodeWriter
            ' Configuramos el formato a CODE_128 (es más compacto y moderno que el 39)
            escritor.Format = BarcodeFormat.CODE_128

            ' Dimensiones para el ticket de 80mm (aprox 250px de ancho)
            escritor.Options = New Common.EncodingOptions With {
            .Width = 250,
            .Height = 80,
            .Margin = 2 ' Margen blanco alrededor para que el escáner lea bien
        }

            ' Retorna el mapa de bits (la imagen)
            Return escritor.Write(texto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' --- LÓGICA DE IMPRESIÓN ---
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
        ' Custom: 80mm (315px) x 100mm (393px)
        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 315, 393)

        ' Usamos una variable local para pasar la fila al evento de impresión
        Dim filaSeleccionada = row
        AddHandler pd.PrintPage, Sub(sender, e)
                                     DisenoTicket80x100(e, filaSeleccionada)
                                 End Sub
        pd.Print()
    End Sub
    Private Function GenerarImagenQR(contenido As String) As Bitmap
        Dim escritor = New ZXing.BarcodeWriter()
        escritor.Format = ZXing.BarcodeFormat.QR_CODE

        ' Configuramos el tamaño exacto de 80x80
        Dim opciones = New ZXing.QrCode.QrCodeEncodingOptions With {
        .Height = 80,
        .Width = 80,
        .Margin = 0 ' Sin bordes blancos para aprovechar el espacio
    }
        escritor.Options = opciones

        Return escritor.Write(contenido)
    End Function


    ' --- DISEÑO DEL TICKET (80mm x 100mm) ---
    Private Sub DisenoTicket80x100(e As PrintPageEventArgs, row As DataGridViewRow)
        ' Configuración de fuentes
        Dim fTitulo As New Font("Fuente A", 14, FontStyle.Bold)
        Dim fDatosLabel As New Font("Arial", 11, FontStyle.Bold)
        Dim fDatosValor As New Font("Arial", 11)
        Dim fTimestamp As New Font("Arial", 9, FontStyle.Italic)

        Dim x As Integer = 15
        Dim y As Integer = 15
        Dim anchoPapel As Integer = 280 ' Aproximado para 80mm
        Dim idBin As String = row.Cells("codigo").Value.ToString()



        ' 2. CENTRO: Etiqueta Título (Usando la variable _etiquetaFiltro o similar)
        ' Centramos el texto manualmente
        Dim titulo As String = "PALTAS EL CHEJO"
        Dim tamTitulo = e.Graphics.MeasureString(titulo, fTitulo)
        e.Graphics.DrawString(titulo, fTitulo, Brushes.Black, (anchoPapel - tamTitulo.Width) / 2, y)
        y += 35

        ' 1. ESQUINA SUPERIOR: Código QR (Tamaño 40x40)
        'Dim bmpQR As Bitmap = GenerarImagenQR(idBin)
        'If bmpQR IsNot Nothing Then
        'e.Graphics.DrawImage(bmpQR, x, y, 40, 40)
        'y += 40 ' Espacio después del QR
        'End If


        Dim bruto As Decimal = Convert.ToDecimal(row.Cells("bruto").Value)
        Dim neto As Decimal = Convert.ToDecimal(row.Cells("neto").Value)
        Dim tara As Decimal = Convert.ToDecimal(row.Cells("tara").Value)


        ' 3. CUERPO: Datos del Pesaje (Organizados en lista)
        ' Definimos una pequeña rutina para ahorrar líneas
        Dim datos As New Dictionary(Of String, String) From {
        {"Lote:", idBin},
        {"Recepción:", row.Cells("recepcion").Value.ToString()},
        {"Ciclo:", row.Cells("etiqueta_ciclo").Value.ToString()},
        {"Persona:", row.Cells("productor").Value.ToString()},
        {"Kilos Brutos:", bruto.ToString("#,##0.#") & " kg"},
        {"Kilos Neto:", neto.ToString("#,##0.#") & " kg"},
        {"Tara:", row.Cells("tara").Value.ToString() & " kg"}
    }

        For Each item In datos
            e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, y)
            e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, x + 100, y)
            y += 20
        Next
        y += 50

        ' 4. PARTE INFERIOR: Código de Barras (Ocupando el ancho disponible)
        Dim bmpBarcode As Bitmap = GenerarImagenBarcode(idBin)
        If bmpBarcode IsNot Nothing Then
            ' Ajustamos el dibujo para que ocupe el ancho (dejando márgenes)
            Dim anchoBarcode As Integer = anchoPapel - (x * 2)
            e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, 90)
            y += 80
        End If
        y += 30
        ' 5. FINAL: Timestamp
        Dim fechaStr As String = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        e.Graphics.DrawString(fechaStr, fTimestamp, Brushes.Black, x, y)
    End Sub

    Private Sub MostrarVentanaQR_80mm(idBin As String)
        ' 1. Cálculo de píxeles para 80mm
        Dim medidaPx As Integer = 302
        Dim margen As Integer = 10

        ' 2. Configuración del Formulario
        Dim frmQR As New Form
        frmQR.Text = "QR 80mm - ID: " & idBin
        ' Aumentamos el alto para que quepa el código de barras y el texto
        frmQR.Size = New Size(medidaPx + 40, medidaPx + 200)
        frmQR.StartPosition = FormStartPosition.CenterScreen
        frmQR.BackColor = Color.White
        frmQR.FormBorderStyle = FormBorderStyle.FixedSingle
        frmQR.MaximizeBox = False

        ' 3. PictureBox para el QR (80x80mm)
        Dim picQR As New PictureBox
        picQR.Size = New Size(medidaPx, medidaPx)
        picQR.Location = New Point(margen, margen)
        picQR.SizeMode = PictureBoxSizeMode.StretchImage

        Dim escritorQR = New ZXing.BarcodeWriter()
        escritorQR.Format = ZXing.BarcodeFormat.QR_CODE
        escritorQR.Options = New ZXing.QrCode.QrCodeEncodingOptions With {
        .Height = medidaPx,
        .Width = medidaPx,
        .Margin = 0
    }
        picQR.Image = escritorQR.Write(idBin)

        ' 4. PictureBox para el CÓDIGO DE BARRAS (Pequeño)
        Dim picBarcode As New PictureBox
        ' Altura de 90px para que sea discreto
        picBarcode.Size = New Size(medidaPx, 90)
        picBarcode.Location = New Point(margen, medidaPx + 20)
        picBarcode.SizeMode = PictureBoxSizeMode.StretchImage

        Dim escritorBar = New ZXing.BarcodeWriter()
        escritorBar.Format = ZXing.BarcodeFormat.CODE_128 ' Formato estándar de barras
        escritorBar.Options = New ZXing.Common.EncodingOptions With {
        .Height = 50,
        .Width = medidaPx,
        .Margin = 2,
        .PureBarcode = True ' True si quieres solo las barras, False para incluir el número abajo
    }
        picBarcode.Image = escritorBar.Write(idBin)

        ' 5. Label para el código numérico (opcional si PureBarcode = False)
        Dim lblID As New Label
        lblID.Text = "ID: " & idBin
        lblID.Font = New Font("Consolas", 14, FontStyle.Bold)
        lblID.TextAlign = ContentAlignment.TopCenter
        lblID.Location = New Point(margen, medidaPx + 75)
        lblID.Size = New Size(medidaPx, 30)

        ' 6. Agregar y mostrar
        frmQR.Controls.Add(picQR)
        frmQR.Controls.Add(picBarcode)
        frmQR.Controls.Add(lblID)
        frmQR.ShowDialog()
    End Sub

    ' --- BOTÓN PARA VER PREVIA EN PANTALLA ---
    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        If dgvFinal.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una fila en la tabla para generar la vista previa.")
            Return
        End If

        Try
            ' 1. Configurar el documento
            Dim pd As New PrintDocument()
            ' Definimos el tamaño 80mm x 100mm (en centésimas de pulgada: 315 x 393)
            pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 315, 393)

            ' 2. Capturar la fila seleccionada
            Dim filaActual = dgvFinal.CurrentRow

            ' 3. Vincular el evento de dibujo
            AddHandler pd.PrintPage, Sub(s, ev)
                                         DisenoTicket80x100(ev, filaActual)
                                     End Sub

            ' 4. Configurar y mostrar el cuadro de diálogo
            Dim ppd As New PrintPreviewDialog()
            ppd.Document = pd
            'ppd.Title = "Vista Previa de Ticket - Registro " & filaActual.Cells("id").Value.ToString()
            ppd.WindowState = FormWindowState.Maximized

            ' Esto corrige un error común donde la previa sale en blanco a veces
            CType(ppd, Form).ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error al generar la vista previa: " & ex.Message)
        End Try
    End Sub

    Private Sub btnVerQR_Click(sender As Object, e As EventArgs) Handles btnVerQR.Click
        If dgvFinal.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una fila primero.")
            Return
        End If

        ' Obtenemos el ID de la fila seleccionada
        Dim idSeleccionado As String = dgvFinal.CurrentRow.Cells("codigo").Value.ToString()

        ' Llamamos a la ventana emergente
        MostrarVentanaQR_80mm(idSeleccionado)
    End Sub

    ' --- NAVEGACIÓN ---
    Private Sub btnNuevaRecepcion_Click(sender As Object, e As EventArgs) Handles btnNuevaRecepcion.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        frm.NavegarA(New ucNuevaRecepcion())
    End Sub

    Private Sub btnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)

        ' En lugar de NavegarA (que destruye el anterior), lo agregamos encima
        Dim ucFinal As New ucRecepcionFinal(_idRecepcion)
        ucFinal.Dock = DockStyle.Fill

        ' Agregamos al panel y lo traemos al frente
        frm.pnlContenedor.Controls.Add(ucFinal)
        ucFinal.BringToFront()


        'Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        ' Ruteo: Regresamos al selector de cantidad para esta misma recepción
        'frm.NavegarA(New ucRecepcionFinal(_idRecepcion))

    End Sub
End Class