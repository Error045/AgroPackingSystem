Imports System.Data

Public Class ucPesajeBloque

    Public Class RegistroPesajeItem
        Public Property NumeroOrden As Integer
        Public Property IdTipoContenedor As Integer
        Public Property Tara As Double
        Public Property PesoBruto As Double
        Public Property PesoNeto As Double
    End Class

    Public Event BloqueProcesado(listaBines As List(Of RegistroPesajeItem))

    Private _cantidadBines As Integer = 1
    Private _ciclo As Integer = 1
    Private _infoRecepcion As Dictionary(Of String, String)

    ' Lista en memoria para estabilizar el peso de la báscula por media móvil
    Private historialLecturas As New List(Of Double)

    Public Property Peso As String
        Get
            Return lblPeso.Text
        End Get
        Set(value As String)
            lblPeso.Text = value
        End Set
    End Property

    ' ==========================================
    ' 🔌 INICIALIZACIÓN Y EVENTOS DEL CONTROL
    ' ==========================================
    Private Sub ucPesajeBloque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode Then Return

        Timer1.Interval = 100 ' Refresco cada 100 ms
        Timer1.Start()
    End Sub

    Private Sub ucPesajeBloque_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            historialLecturas.Clear()
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Public Sub ConfigurarPesajeBloque(cantidad As Integer, ciclo As Integer, info As Dictionary(Of String, String))
        Me._cantidadBines = If(cantidad > 0, cantidad, 1)
        Me._ciclo = ciclo
        Me._infoRecepcion = info

        Dim dtContenedores As DataTable = ObtenerTablaContenedores()
        PoblarCombo(cboContenedor1, dtContenedores)
        PoblarCombo(cboContenedor2, dtContenedores)
        PoblarCombo(cboContenedor3, dtContenedores)

        AjustarVisibilidadContenedores(Me._cantidadBines)
        historialLecturas.Clear()
    End Sub

    Private Function ObtenerTablaContenedores() As DataTable
        Dim sql As String = "SELECT id, nombre, tara, COALESCE(capacidad, 550) AS capacidad FROM tipos_contenedores WHERE estado = 1"
        Return ConexionBD.ObtenerDatos(sql)
    End Function

    Private Sub PoblarCombo(cbo As ComboBox, dt As DataTable)
        If cbo IsNot Nothing AndAlso dt IsNot Nothing Then
            cbo.DataSource = dt.Copy()
            cbo.DisplayMember = "nombre"
            cbo.ValueMember = "id"
        End If
    End Sub

    '   Private Sub AjustarVisibilidadContenedores(cantidad As Integer)
    '  If pnlContenedor1 IsNot Nothing Then pnlContenedor1.Visible = (cantidad >= 1)
    ' If pnlContenedor2 IsNot Nothing Then pnlContenedor2.Visible = (cantidad >= 2)
    ' If pnlContenedor3 IsNot Nothing Then pnlContenedor3.Visible = (cantidad >= 3)
    ' End Sub


    ' ==========================================
    ' 👁️ CONTROL DE VISIBILIDAD Y ESTADO DE CONTENEDORES
    ' ==========================================
    Private Sub AjustarVisibilidadContenedores(cantidad As Integer)
        ' Paneles contenedores
        If pnlContenedor1 IsNot Nothing Then pnlContenedor1.Visible = (cantidad >= 1)
        If pnlContenedor2 IsNot Nothing Then pnlContenedor2.Visible = (cantidad >= 2)
        If pnlContenedor3 IsNot Nothing Then pnlContenedor3.Visible = (cantidad >= 3)

        ' ComboBox 1
        If cboContenedor1 IsNot Nothing Then
            cboContenedor1.Visible = (cantidad >= 1)
            cboContenedor1.Enabled = (cantidad >= 1)
        End If

        ' ComboBox 2
        If cboContenedor2 IsNot Nothing Then
            cboContenedor2.Visible = (cantidad >= 2)
            cboContenedor2.Enabled = (cantidad >= 2)
        End If

        ' ComboBox 3
        If cboContenedor3 IsNot Nothing Then
            cboContenedor3.Visible = (cantidad >= 3)
            cboContenedor3.Enabled = (cantidad >= 3)
        End If
    End Sub



    ' ==========================================
    ' ⚖️ LÓGICA DE LECTURA EN TIEMPO REAL (MEDIA MÓVIL)
    ' ==========================================
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not Me.Visible Then Exit Sub

        Try
            ' Lectura directa del hardware
            Dim pesoBrutoBalanza As Double = BasculaManager.Instancia.PesoActual

            ' Promediar las últimas 10 lecturas para suavizar el movimiento de números
            historialLecturas.Add(pesoBrutoBalanza)
            If historialLecturas.Count > 10 Then
                historialLecturas.RemoveAt(0)
            End If

            Dim pesoPromedio As Double = historialLecturas.Average()

            ' Filtro de ruido cercano a cero
            If pesoPromedio < 1.0 Then
                pesoPromedio = 0
            End If

            ' Despliegue fluido en el indicador principal
            lblPeso.Text = pesoPromedio.ToString("N1")

        Catch ex As Exception
            ' Mantiene la interfaz estable si hay lecturas nulas momentáneas
        End Try
    End Sub

    ' ==========================================
    ' 💾 CAPTURA DE PESO Y CÁLCULO POR BIN
    ' ==========================================
    Private Sub btnCapturarPeso_Click(sender As Object, e As EventArgs) Handles btnCapturarPeso.Click
        ' Tomamos el peso estabilizado desde la pantalla
        Dim pesoCapturado As Double = 0
        If Not Double.TryParse(lblPeso.Text, pesoCapturado) OrElse pesoCapturado <= 0 Then
            MessageBox.Show("No se registra peso válido en la báscula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim combos() As ComboBox = {cboContenedor1, cboContenedor2, cboContenedor3}
        Dim idsContenedor(_cantidadBines - 1) As Integer
        Dim taras(_cantidadBines - 1) As Double
        Dim sumaTaras As Double = 0.0

        ' Obtención de contenedores y taras seleccionadas para el bloque
        For i As Integer = 0 To _cantidadBines - 1
            Dim cbo = combos(i)
            idsContenedor(i) = 1
            taras(i) = 0.0

            If cbo IsNot Nothing AndAlso cbo.SelectedValue IsNot Nothing Then
                Integer.TryParse(cbo.SelectedValue.ToString(), idsContenedor(i))
                Dim rowView As DataRowView = TryCast(cbo.SelectedItem, DataRowView)
                If rowView IsNot Nothing AndAlso rowView.Row.Table.Columns.Contains("tara") Then
                    Double.TryParse(rowView("tara").ToString(), taras(i))
                End If
            End If

            sumaTaras += taras(i)
        Next

        ' Descuento global de taras y prorrateo entre los bines del bloque
        Dim pesoNetoTotal As Double = pesoCapturado - sumaTaras
        If pesoNetoTotal < 0 Then pesoNetoTotal = 0

        Dim netoPorBin As Double = Math.Round(pesoNetoTotal / _cantidadBines, 2)
        Dim listaItems As New List(Of RegistroPesajeItem)()

        For i As Integer = 0 To _cantidadBines - 1
            Dim brutoIndividual As Double = Math.Round(netoPorBin + taras(i), 2)

            Dim item As New RegistroPesajeItem() With {
                .NumeroOrden = i + 1,
                .IdTipoContenedor = idsContenedor(i),
                .Tara = taras(i),
                .PesoBruto = brutoIndividual,
                .PesoNeto = netoPorBin
            }
            listaItems.Add(item)
        Next

        ' Notificamos el resultado y reiniciamos el búfer de lecturas
        RaiseEvent BloqueProcesado(listaItems)
        historialLecturas.Clear()
    End Sub

End Class