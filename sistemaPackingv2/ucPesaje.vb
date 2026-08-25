Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ucPesaje

    ' ==========================================
    ' ⚙️ CONFIGURACIONES Y ENUMS
    ' ==========================================
    Dim _idBinActual As Integer = 0
    Dim _kilosTeoricosActuales As Decimal = 0

    Enum ModoVista
        Recepcion = 0
        Calibrado = 1
        Tarjado = 2
    End Enum

    Public Property PesoAcumuladoBinesAnteriores As Double = 0.0
    Public Property DatosActuales As Dictionary(Of String, String)


    ' ==========================================
    ' 👤 PROPIEDADES DE ESTADO
    ' ==========================================
    Public Property TaraSeleccionada As Double
    Public Property IdContenedorSeleccionado As Integer
    Public Property PesoAcumuladoAnterior As Double = 0.0

    ' Lista en memoria para promediar las lecturas inestables de la báscula
    Private historialLecturas As New List(Of Double)

    ' ==========================================
    ' ⚡ EVENTOS
    ' ==========================================
    ' El evento principal que enviará el resultado del pesaje al contenedor maestro
    Public Event AlCapturarPeso(pesoNeto As Decimal, idTipoContenedor As Integer)

    ' Declaración del evento que avisa hacia afuera que se presionó el botón
    Public Event ContenedorProcesado()



    ' Wrapper para leer o escribir de forma directa en el Label principal de peso
    Public Property Peso As String
        Get
            Return lblPeso.Text
        End Get
        Set(value As String)
            lblPeso.Text = value
        End Set
    End Property

    ' Esta propiedad permite que desde afuera le cambien el texto al Label del título
    Public Property Titulo() As String
        Get
            ' Cambia "lblTitulo" por el nombre real que tenga el Label del título en tu diseño
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            ' Cambia "lblTitulo" por el nombre real de tu Label
            lblTitulo.Text = value
        End Set
    End Property

    ' ==========================================
    ' 🔌 MÉTODOS DE INICIALIZACIÓN Y ENTRADA
    ' ==========================================

    ''' <summary>
    ''' Método clave llamado por ucPesajeBarcode para preparar la balanza con el bin escaneado.
    ''' </summary>
    Public Sub CargarBinAPesar(idBin As Integer, kilosTeoricos As Decimal)
        _idBinActual = idBin
        _kilosTeoricosActuales = kilosTeoricos

        ' Mostramos visualmente el Bin que se está procesando en la cabecera
        lblIdProceso.Text = $"📦 BIN ACTUAL: {idBin}"
        lblIdProceso.Visible = True

        ' Reiniciamos lecturas previas para asegurar una captura limpia
        historialLecturas.Clear()
    End Sub

    Public Sub ConfigurarVista(modo As ModoVista, datos As Dictionary(Of String, String))
        ' Limpiamos y ocultamos etiquetas para evitar "fantasmas" visuales de operaciones anteriores
        lblIdRecepcion.Visible = False
        lblIdProceso.Visible = False
        lblIdCalibrado.Visible = False
        lblProductor.Visible = False
        lblProducto.Visible = False
        lblVariedad.Visible = False
        lblCalibre.Visible = False

        Me.DatosActuales = datos

        ' Definimos el Título y colores de fondo según la etapa del flujo de trabajo
        Select Case modo
            Case ModoVista.Recepcion
                lblTitulo.Text = "📦 PESAJE RECEPCIÓN"
                Me.BackColor = Color.FromArgb(185, 215, 255) ' Azul suave
            Case ModoVista.Calibrado
                lblTitulo.Text = "⚖️ PESAJE CALIBRADO"
                Me.BackColor = Color.FromArgb(190, 240, 190) ' Verde suave
            Case ModoVista.Tarjado
                lblTitulo.Text = "🏷️ PESAJE TARJADO"
                Me.BackColor = Color.FromArgb(255, 220, 170) ' Naranja suave
        End Select

        ' Renderizado dinámico de datos solo si existen en el diccionario
        If datos.ContainsKey("ID_REC") Then
            lblIdRecepcion.Text = "🚚 REC: " & datos("ID_REC")
            lblIdRecepcion.Visible = True
        End If
        If datos.ContainsKey("ID_CAL") Then
            lblIdCalibrado.Text = "🆔 CAL: " & datos("ID_CAL")
            lblIdCalibrado.Visible = True
        End If
        If datos.ContainsKey("Proceso") Then
            lblIdProceso.Text = "⚙️ PROC: " & datos("Proceso")
            lblIdProceso.Visible = True
        End If
        If datos.ContainsKey("Productor") Then
            lblProductor.Text = "👤 " & datos("Productor")
            lblProductor.Visible = True
        End If
        If datos.ContainsKey("Producto") Then
            lblProducto.Text = "🥑 " & datos("Producto")
            lblProducto.Visible = True
        End If
        If datos.ContainsKey("Variedad") Then
            lblVariedad.Text = "🌲 " & datos("Variedad")
            lblVariedad.Visible = True
        End If
        If datos.ContainsKey("Calibre") Then
            lblCalibre.Text = "⚖️ " & datos("Calibre")
            lblCalibre.Visible = True
        End If
    End Sub

    Private Sub ucPesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode Then Return

        Timer1.Interval = 100
        Timer1.Start()
        CargarContenedoresDinamicos()
    End Sub

    Private Sub ucPesaje_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            historialLecturas.Clear()
            Timer1.Start()
            CargarContenedoresDinamicos()
        Else
            Timer1.Stop()
        End If
    End Sub

    ' ==========================================
    ' 📦 CONTENEDORES DINÁMICOS (UI)
    ' ==========================================
    Private Sub CargarContenedoresDinamicos()
        flpContenedores.Controls.Clear()

        Dim sql As String = "SELECT id, nombre, tara, capacidad FROM tipos_contenedores WHERE estado = 1"
        Dim dt As DataTable = ConexionBD.ObtenerDatos(sql)

        If dt IsNot Nothing Then
            For Each row As DataRow In dt.Rows
                Dim rb As New RadioButton()
                rb.Appearance = Appearance.Button
                rb.FlatStyle = FlatStyle.Flat
                rb.Size = New Size(150, 100)
                rb.TextAlign = ContentAlignment.MiddleCenter
                rb.Margin = New Padding(5)
                rb.BackColor = Color.White
                rb.FlatAppearance.CheckedBackColor = Color.FromArgb(35, 30, 68)

                Dim info As New ContenedorInfo With {
                    .Id = Convert.ToInt32(row("id")),
                    .Nombre = row("nombre").ToString(),
                    .Tara = Convert.ToDouble(row("tara")),
                    .Capacidad = Convert.ToDouble(row("capacidad"))
                }

                rb.Text = $"{info.Nombre.ToUpper()}{vbCrLf}{info.Tara:N1} KG"
                rb.Tag = info

                AddHandler rb.CheckedChanged, AddressOf BotonDinamico_CheckedChanged
                flpContenedores.Controls.Add(rb)
            Next
        End If
    End Sub

    Private Sub BotonDinamico_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb = DirectCast(sender, RadioButton)
        If rb.Checked Then
            rb.ForeColor = Color.White
            Dim info = DirectCast(rb.Tag, ContenedorInfo)
            Me.IdContenedorSeleccionado = info.Id
            Me.TaraSeleccionada = info.Tara
        Else
            rb.ForeColor = Color.Black
        End If
    End Sub

    ' ==========================================
    ' ⚖️ LÓGICA DE LECTURA EN TIEMPO REAL
    ' ==========================================
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not Me.Visible Then Exit Sub
        Try
            ' Lectura directa del hardware encapsulado en el Manager Global
            Dim pesoTotalEnBascula As Double = BasculaManager.Instancia.PesoActual

            ' Algoritmo de estabilización por media móvil (Últimas 10 lecturas)
            historialLecturas.Add(pesoTotalEnBascula)
            If historialLecturas.Count > 10 Then historialLecturas.RemoveAt(0)
            Dim pesoPromedioTotal As Double = historialLecturas.Average()

            ' Filtro de ruido de rango cero
            If pesoPromedioTotal < 1.0 Then pesoPromedioTotal = 0

            ' Cálculo diferencial de peso neto restando cargas acumuladas
            Dim pesoPuntualContenedor As Double = pesoPromedioTotal - Me.PesoAcumuladoBinesAnteriores
            If pesoPuntualContenedor < 0 Then pesoPuntualContenedor = 0

            ' Actualización de la interfaz
            lblPesoTotal.Text = $"Total Báscula: {pesoPromedioTotal:N1} kg"
            lblPeso.Text = pesoPuntualContenedor.ToString("N1")

        Catch ex As Exception
            ' Silenciamos para evitar interrupciones visuales críticas en planta
        End Try
    End Sub

    ' ==========================================
    ' 💾 BOTÓN CAPTURAR PESO
    ' ==========================================
    Private Sub btnCapturarPeso_Click(sender As Object, e As EventArgs) Handles btnCapturarPeso.Click
        ' 1. Validación de Contenedor Obligatorio
        Dim rbSeleccionado = flpContenedores.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked)
        If rbSeleccionado Is Nothing Then
            MessageBox.Show("Debe seleccionar un tipo de contenedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim info = DirectCast(rbSeleccionado.Tag, ContenedorInfo)

        ' 2. Conversión del peso puntual capturado de la báscula
        Dim pesoPuntualCapturado As Double = 0
        If Not Double.TryParse(lblPeso.Text, pesoPuntualCapturado) Then Return

        ' Peso neto real de la fruta (Bruto - Tara)
        Dim pesoNetoFrutaActual As Double = pesoPuntualCapturado - info.Tara

        ' 3. Validaciones Industriales
        If pesoPuntualCapturado <= info.Tara Then
            MessageBox.Show($"Carga insuficiente para este contenedor ({info.Tara} kg tara).", "Error de Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If pesoNetoFrutaActual > info.Capacidad Then
            MessageBox.Show($"¡EXCESO DE CARGA! Límite permitido: {info.Capacidad} kg", "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ' 4. LANZAMIENTO DEL EVENTO HACIA EL CONTROLADOR SUPERIOR
        ' Enviamos los datos procesados y limpios directamente en los parámetros del evento
        RaiseEvent AlCapturarPeso(Convert.ToDecimal(pesoNetoFrutaActual), info.Id)

        ' Avisamos al ucRecepcion que se capturó un peso
        RaiseEvent ContenedorProcesado()

        ' Limpiamos el historial para el próximo bulto/bin
        historialLecturas.Clear()
    End Sub



End Class