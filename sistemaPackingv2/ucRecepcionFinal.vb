Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports sistemaPackingv2.ucRecepcion
Imports ZXing

Public Class ucRecepcionFinal
    Private _idRecepcion As Integer

    Public Sub New(idRecepcion As Integer)
        InitializeComponent()
        _idRecepcion = idRecepcion
    End Sub

    Private Sub ucRecepcionFinal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        lblCodRecepcion.Text = "RECEPCIÓN N°: " & _idRecepcion
        lblProductor.Text = "NOMBRE: " & frm.NombrePersonaGlobal

        CargarHistorialFull()
    End Sub

    ' --- CARGA DE DATOS CON TU CONSULTA SQL OPTIMIZADA ---
    Private Sub CargarHistorialFull()
        Try
            ConexionBD.Abrir()

            Dim sql As String = "SELECT codigo, recepcion, tipo, productor, producto, variedad, " &
                                "calibre, numero, ciclo, tara, bruto, neto, fecha, hora " &
                                "FROM vw_recepciones_detalles_resumen " &
                                "WHERE recepcion = @idR ORDER BY codigo DESC"



            Dim da As New MySqlDataAdapter(sql, ConexionBD.conexion)
            da.SelectCommand.Parameters.AddWithValue("@idR", _idRecepcion)

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvHistorico.DataSource = dt

            ' 2. OCULTAR LAS COLUMNAS QUE SOLO SIRVEN PARA LA IMPRESIÓN
            Dim columnasOcultas() As String = {"recepcion", "tipo", "productor", "numero", "fecha", "hora"}
            For Each colName In columnasOcultas
                If dgvHistorico.Columns.Contains(colName) Then
                    dgvHistorico.Columns(colName).Visible = False
                End If
            Next

            ' 4. === NUEVO: AGREGAR COLUMNA DE BOTÓN DE IMPRESIÓN ===
            ' Verificamos si la columna ya existe para no duplicarla al recargar
            If Not dgvHistorico.Columns.Contains("colBtnImprimir") Then
                Dim colBtn As New DataGridViewButtonColumn()
                colBtn.Name = "colBtnImprimir"
                colBtn.HeaderText = "Acción"
                colBtn.Text = "🖨️ Imprimir" ' Texto que dirá el botón
                colBtn.UseColumnTextForButtonValue = True ' Obliga a que todos los botones tengan el texto de arriba
                colBtn.FlatStyle = FlatStyle.Standard
                colBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                ' Añadir al final del DataGridView
                dgvHistorico.Columns.Add(colBtn)
            End If

            ' --- APLICAR FORMATO AL DATAGRIDVIEW ---
            Dim columnasNum() As String = {"bruto", "tara", "neto"}

            For Each colName In columnasNum
                If dgvHistorico.Columns.Contains(colName) Then
                    ' Configura el contenido de las celdas
                    With dgvHistorico.Columns(colName).DefaultCellStyle
                        .Format = "#,##0.#"
                        .Alignment = DataGridViewContentAlignment.MiddleRight ' Números a la derecha
                    End With

                    ' Configura la cabecera (Título)
                    dgvHistorico.Columns(colName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvHistorico.Columns(colName).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next




            ' --- CÁLCULO DE TOTALES PARA LABELS ---
            Dim totalBruto As Double = 0
            Dim totalNeto As Double = 0
            Dim totalTara As Integer = 0
            Dim totalBins As Integer = dt.Rows.Count


            For Each row As DataRow In dt.Rows
                totalBruto += Convert.ToDouble(row("bruto"))
                totalNeto += Convert.ToDouble(row("neto"))
                totalTara += Convert.ToInt32(row("tara"))
            Next

            ' Actualizar labels
            lblTotalContenedor.Text = "TOTAL BINS: " & totalBins


            lblTotalBruto.Text = "TOTAL BRUTO: " & totalBruto.ToString("#,##0.#") & " KG"

            lblTara.Text = "TOTAL TARA: " & totalTara.ToString("#,##0.#") & " KG"
            lblTotalNeto.Text = "TOTAL NETO: " & totalNeto.ToString("#,##0.#") & " KG"

        Catch ex As Exception
            MessageBox.Show("Error al cargar historial detallado: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- BOTÓN: INGRESAR RECEPCIÓN DESDE PESAJE ---
    ' Este botón permite volver a pesar más bins para la MISMA recepción 
    ' En ucRecepcionFinal.vb
    Private Sub btnSeguirPesando_Click(sender As Object, e As EventArgs) Handles btnSeguirPesando.Click
        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)

        ' 1. Mantenemos el ID de Recepción y Productor
        ' 2. Mantenemos el ID de Variedad (Esto es la CLAVE para que no salte al paso 1)

        ' 3. Limpiamos solo el peso para seguridad
        frm.PesoDesdeBascula = 0

        ' 4. Navegamos a una NUEVA instancia de ucRecepcion
        ' Al nacer, el ucRecepcion detectará que ya hay una variedad y saltará al Selector
        frm.NavegarA(New ucRecepcion())


    End Sub


    ' --- BOTÓN: TERMINAR RECEPCIÓN ---
    ' Este botón cierra el proceso completo del camión
    Private Sub btnTerminarRecepcion_Click(sender As Object, e As EventArgs) Handles btnTerminarRecepcion.Click
        Dim respuesta = MessageBox.Show("¿Está seguro de cerrar esta recepción? No podrá agregar más pesajes.",
                                        "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Try
                ConexionBD.Abrir()
                ' 1. Cambiar estado en la tabla 'recepciones' (ej: estado_id = 2 es 'Cerrada')
                Dim sqlUpdate As String = "UPDATE recepciones SET estados_recepciones_id = 2 WHERE id = @id"
                Using cmd = New MySqlCommand(sqlUpdate, ConexionBD.conexion)
                    cmd.Parameters.AddWithValue("@id", _idRecepcion)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Limpiar variables globales en Form1 para seguridad de datos
                Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
                LimpiarVariablesGlobales(frm)

                ' 3. Volver al inicio
                MessageBox.Show("Recepción finalizada y datos liberados.", "Éxito")
                frm.NavegarA(New ucNuevaRecepcion())

            Catch ex As Exception
                MessageBox.Show("Error al cerrar recepción: " & ex.Message)
            Finally
                ConexionBD.Cerrar()
            End Try
        End If
    End Sub

    Private Sub LimpiarVariablesGlobalesPesaje(ByRef frm As Form1)

        frm.IdProductoGlobal = 0 'comentar
        frm.IdVariedadGlobal = 0 'comentar
        frm.PesoDesdeBascula = 0
        ' variables de ruteo específicas del pesaje.
    End Sub

    Private Sub LimpiarVariablesGlobales(ByRef frm As Form1)
        frm.IdRecepcionGlobal = "0"
        frm.IdPersonaGlobal = "0"
        frm.NombrePersonaGlobal = ""
        frm.NombreProductoGlobal = ""
        frm.NombreVariedadGlobal = ""
        frm.IdProductoGlobal = 0
        frm.IdVariedadGlobal = 0
        frm.PesoDesdeBascula = 0
        ' Cualquier otra variable de ruteo que necesite resetearse
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click

        Dim frm = DirectCast(Application.OpenForms("Form1"), Form1)
        frm.NavegarA(New ucRecepcion())


    End Sub

    ' --- EVENTO PARA DETECTAR EL CLIC EN EL BOTÓN DEL DATAGRIDVIEW ---
    Private Sub dgvHistorico_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistorico.CellContentClick
        ' 1. Validar que no se haya hecho clic en la cabecera (RowIndex = -1)
        If e.RowIndex < 0 Then Return

        ' 2. Verificar que la columna clickeada sea exactamente nuestro botón
        If dgvHistorico.Columns(e.ColumnIndex).Name = "colBtnImprimir" Then

            ' Obtener la fila específica donde el usuario hizo clic
            Dim filaSeleccionada = dgvHistorico.Rows(e.RowIndex)

            ' Mandar a imprimir el ticket usando tu diseño
            Dim pd As New PrintDocument()
            pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
            pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            AddHandler pd.PrintPage, Sub(s, ev)
                                         DisenoTicket100x200(ev, filaSeleccionada)
                                     End Sub
            Try
                pd.Print()
            Catch ex As Exception
                MessageBox.Show("Error al intentar imprimir: " & ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
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




End Class
