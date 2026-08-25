Public Class ucRecepcion

    ' 1. DEFINICIÓN DE ESTADOS (QUEDA EXACTAMENTE IGUAL)
    Enum PasoFlujo
        SeleccionRecepcion = 0
        SeleccionProducto = 1
        ConfiguracionContenedor = 2
        PesajeActivo = 3
    End Enum

    ' 2. VARIABLES GLOBALES DEL UC (AQUÍ ESTÁ EL CAMBIO)
    Private PasoActual As Integer = 1
    Public Property IdVariedadSeleccionada As Integer

    ' 🟢 NUEVO: Reemplazamos las variables viejas por nuestra sesión central y UN solo control visual
    Private sesionActual As New SesionPesaje()
    Private controlPesajeUnico As ucPesaje

    ' 3. MÉTODO MAESTRO GESTIONAR PASOS (QUEDA EXACTAMENTE IGUAL)
    Public Sub GestionarPasos(paso As PasoFlujo)
        UcRecepcionEstado1.Visible = False
        UcProducto1.Visible = False
        UcSelector1.Visible = False
        pnlContenedores.Visible = False

        Select Case paso
            Case PasoFlujo.SeleccionRecepcion
                UcRecepcionEstado1.Visible = True
                UcRecepcionEstado1.BringToFront()
            Case PasoFlujo.SeleccionProducto
                UcProducto1.Visible = True
                UcProducto1.BringToFront()
            Case PasoFlujo.ConfiguracionContenedor
                UcSelector1.Visible = True
                UcSelector1.BringToFront()
                RemoveHandler UcSelector1.CantidadSeleccionada, AddressOf ConfigurarFlujo
                AddHandler UcSelector1.CantidadSeleccionada, AddressOf ConfigurarFlujo
                UcSelector1.Focus()
            Case PasoFlujo.PesajeActivo
                pnlContenedores.Visible = True
                pnlContenedores.BringToFront()
        End Select
    End Sub

    ' 4, 5 y 6. CONSTRUCTOR, LOAD Y TRANSICIONES (QUEDAN EXACTAMENTE IGUAL)
    Public Sub New()
        InitializeComponent()
        AddHandler UcSelector1.CantidadSeleccionada, AddressOf ConfigurarFlujo
    End Sub

    Private Sub ucRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frm = DirectCast(Me.FindForm(), Form1)
        Me.IdVariedadSeleccionada = frm.IdVariedadGlobal
        If Me.IdVariedadSeleccionada > 0 Then
            GestionarPasos(PasoFlujo.ConfiguracionContenedor)
        Else
            GestionarPasos(PasoFlujo.SeleccionRecepcion)
        End If
    End Sub

    Public Sub AvanzarAProducto(idRecepcion As Integer)
        GestionarPasos(PasoFlujo.SeleccionProducto)
    End Sub

    Public Sub ActivarPasoSelector(idVar As Integer)
        Me.IdVariedadSeleccionada = idVar
        GestionarPasos(PasoFlujo.ConfiguracionContenedor)
    End Sub

    ' -------------------------------------------------------------------------
    ' 🟢 A PARTIR DE AQUÍ COMIENZA LA MAGIA DE LA NUEVA ARQUITECTURA
    ' -------------------------------------------------------------------------

    ' 7. LÓGICA DE CONFIGURACIÓN DE BULTOS
    Public Sub ConfigurarFlujo(cantidad As Integer)
        Dim frm = DirectCast(Me.FindForm(), Form1)
        Dim per As String = If(String.IsNullOrWhiteSpace(frm.NombrePersonaGlobal), "Persona no identificada", frm.NombrePersonaGlobal)
        Dim frt As String = If(String.IsNullOrWhiteSpace(frm.NombreProductoGlobal), "Producto no definido", frm.NombreProductoGlobal)

        ' 1. Preparamos los datos de cabecera
        Dim infoRecepcion As New Dictionary(Of String, String) From {
            {"ID_REC", frm.IdRecepcionGlobal},
            {"Productor", per},
            {"Producto", frt},
            {"Variedad", frm.NombreVariedadGlobal}
        }

        ' 2. Iniciamos la memoria de la sesión
        sesionActual.IniciarNuevaSesion(cantidad, infoRecepcion)

        ' 3. Limpiamos el panel y creamos UN SOLO control visual
        pnlContenedores.Controls.Clear()
        controlPesajeUnico = New ucPesaje()
        controlPesajeUnico.Name = "ucPesajePrincipal"
        controlPesajeUnico.Dock = DockStyle.Fill
        'controlPesajeUnico.PesoAcumuladoBinesAnteriores = 0.0

        controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Recepcion, infoRecepcion)
        controlPesajeUnico.Titulo = "📦 CONTENEDOR #1"

        AddHandler controlPesajeUnico.ContenedorProcesado, AddressOf ProcesarCapturaContenedor

        pnlContenedores.Controls.Add(controlPesajeUnico)
        GestionarPasos(PasoFlujo.PesajeActivo)
    End Sub

    ' 8. LÓGICA DE PESAJE Y AVANCE (MUCHO MÁS SIMPLE)
    Private Sub ProcesarCapturaContenedor()
        Dim frm = DirectCast(Me.FindForm(), Form1)
        Dim totalRealBascula As Double = BasculaManager.Instancia.PesoActual

        ' 1. Validamos que haya peso (Igual que lo tenías)
        Dim brutoDeBalanza As Double = 0
        If Not Double.TryParse(controlPesajeUnico.Peso, brutoDeBalanza) OrElse brutoDeBalanza <= 0 Then
            MessageBox.Show("No se ha detectado un aumento de carga en la báscula." & vbCrLf &
                            "Por favor, verifique el pesaje.",
                            "Aviso de Carga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        ' 2. Enviamos el dato a la sesión matemática (ella hace la resta por nosotros) ej: bin1 =500; bins2 = 400; totalRealBascula = bins1+bin2 (900); bin2 = totalRealBascula - bins1;  bin2 = 900-500 
        sesionActual.RegistrarPesaje(totalRealBascula, controlPesajeUnico.TaraSeleccionada, controlPesajeUnico.IdContenedorSeleccionado)
        ' Antiguo cálculo se modificó por problemas de resta de bines no tomaba el total de los bines ej: bin1 =500; bins2 = 400; brutoDeBalanza = bin2 (400); bin2 = brutoDeBalanza - bins1;   bin2 = 400 -500; bin2 = -100;
        ' sesionActual.RegistrarPesaje(brutoDeBalanza, controlPesajeUnico.TaraSeleccionada, controlPesajeUnico.IdContenedorSeleccionado)

        ' 3. Evaluamos si ya terminamos
        If sesionActual.CicloCompleto Then
            MostrarResumen()
        Else
            controlPesajeUnico.PesoAcumuladoBinesAnteriores = totalRealBascula
            ' Si faltan bines, NO creamos otro control. Solo le cambiamos el título al actual.
            controlPesajeUnico.Titulo = "📦 CONTENEDOR #" & (sesionActual.PesajesCompletados.Count + 1)
            ' controlPesajeUnico.LimpiarTara() ' <-- Opcional: Si quieres que el combo de tara se borre entre bines
            controlPesajeUnico.Refresh()
        End If
    End Sub

    ' ELIMINAMOS AvanzarFlujo() porque ya no ocultamos/mostramos paneles.

    Private Sub MostrarResumen()
        Dim frm As Form1 = TryCast(Me.FindForm(), Form1)
        If frm Is Nothing Then frm = DirectCast(Application.OpenForms("Form1"), Form1)

        If frm IsNot Nothing Then
            Dim resumen As New ucResumen()
            resumen.ModoActual = ucResumen.ModoOperacion.Recepcion

            ' 🟢 MAGIA FINAL: Le pasamos directamente la lista que la Sesion ya construyó
            resumen.CargarDatos(sesionActual.PesajesCompletados,
                                Val(frm.IdRecepcionGlobal),
                                Val(frm.IdProductoGlobal),
                                Val(frm.IdVariedadGlobal),
                                Val(frm.IdTipoRecepcionGlobal))

            frm.NavegarA(resumen)
        Else
            MessageBox.Show("Error de navegación: No se encontró el formulario principal.")
        End If
    End Sub

End Class