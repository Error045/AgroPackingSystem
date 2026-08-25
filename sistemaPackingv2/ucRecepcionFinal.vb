Imports MySql.Data.MySqlClient
Imports sistemaPackingv2.ucRecepcion

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

            Dim sql As String = "SELECT * FROM vw_recepciones_detalles_resumen  WHERE recepcion = @idR ORDER BY codigo DESC"




            Dim da As New MySqlDataAdapter(sql, ConexionBD.conexion)
            da.SelectCommand.Parameters.AddWithValue("@idR", _idRecepcion)

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvHistorico.DataSource = dt

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
End Class
