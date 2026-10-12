Imports System.Data
'Imports sistemaPackingv2 ' Asegúrate de usar tu namespace correcto

Public Class ucRecepcionBloque

    Public Enum PasoFlujo
        SeleccionRecepcion = 0
        SeleccionProducto = 1
        ConfiguracionContenedor = 2
        PesajeBloqueActivo = 3
    End Enum

    ' Declaramos los controles dinámicos. 
    ' Al usar WithEvents, podemos manejar sus eventos fácilmente si los declaramos a nivel de clase, 
    ' pero en este caso usaremos AddHandler para mayor control dinámico.
    Private controlEstado As ucRecepcionEstadoBloque
    Private controlProducto As ucProductoBloque
    Private controlSelector As ucSelectorBloque
    Private controlPesajeBloque As ucPesajeBloque

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ucRecepcionBloque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Iniciamos el flujo en el paso 1
        GestionarPasos(PasoFlujo.SeleccionRecepcion)
    End Sub

    ' 1. Gestor de Pasos Limpio (Sin interceptar botones)
    Public Sub GestionarPasos(paso As PasoFlujo)
        Me.Controls.Clear()

        Select Case paso
            Case PasoFlujo.SeleccionRecepcion
                controlEstado = New ucRecepcionEstadoBloque()
                controlEstado.Dock = DockStyle.Fill

                ' ESCUCHAMOS EL EVENTO NATIVO DE TU CONTROL
                AddHandler controlEstado.EstadoConfirmado, AddressOf AlConfirmarEstado

                Me.Controls.Add(controlEstado)

            Case PasoFlujo.SeleccionProducto
                controlProducto = New ucProductoBloque()
                controlProducto.Dock = DockStyle.Fill

                ' ASUMIMOS QUE AGREGARÁS UN EVENTO SIMILAR EN ucProducto
                AddHandler controlProducto.ProductoConfirmado, AddressOf AlConfirmarProducto

                Me.Controls.Add(controlProducto)

            Case PasoFlujo.ConfiguracionContenedor
                controlSelector = New ucSelectorBloque()
                controlSelector.Dock = DockStyle.Fill

                ' Escuchamos el evento cuando elige la cantidad de bines
                AddHandler controlSelector.CantidadSeleccionada, AddressOf AlConfirmarCantidad

                Me.Controls.Add(controlSelector)

            Case PasoFlujo.PesajeBloqueActivo
                ' Se maneja en el método ConfigurarFlujoBloque
        End Select
    End Sub


    ' --- 2. RECEPTORES DE EVENTOS (El camino normal) ---

    Private Sub AlConfirmarEstado()
        ' Como el ucRecepcionEstado ya guardó los datos en Form1 antes de disparar este evento,
        ' simplemente avanzamos a la siguiente pantalla de forma limpia.
        GestionarPasos(PasoFlujo.SeleccionProducto)
    End Sub

    Private Sub AlConfirmarProducto()
        ' Avanzamos al selector de bines
        GestionarPasos(PasoFlujo.ConfiguracionContenedor)
    End Sub

    Private Sub AlConfirmarCantidad(cantidad As Integer)
        ' Pasamos al pesaje múltiple
        ConfigurarFlujoBloque(cantidad)
    End Sub


    ' --- 3. CARGA FINAL DE LA PANTALLA DE PESAJE CON TARAS SEPARADAS ---
    Public Sub ConfigurarFlujoBloque(cantidad As Integer)
        Dim frm = TryCast(Me.FindForm(), Form1)
        If frm Is Nothing Then Return

        ' Rescatamos los datos que los controles anteriores ya guardaron en Form1
        Dim infoRecepcion As New Dictionary(Of String, String) From {
            {"ID_REC", frm.IdRecepcionGlobal.ToString()},
            {"Productor", frm.NombrePersonaGlobal},
            {"Producto", frm.NombreProductoGlobal},
            {"Variedad", frm.NombreVariedadGlobal}
        }

        Me.Controls.Clear()

        controlPesajeBloque = New ucPesajeBloque()
        controlPesajeBloque.Dock = DockStyle.Fill

        ' Configuramos (asumiendo que el peso por defecto es 1 o 0 según tu lógica)
        controlPesajeBloque.ConfigurarPesajeBloque(cantidad, 1, infoRecepcion)

        ' Escuchamos cuando el pesaje múltiple termine
        AddHandler controlPesajeBloque.BloqueProcesado, AddressOf AlCompletarPesajeBloque

        Me.Controls.Add(controlPesajeBloque)
    End Sub

    ' --- 4. AL GUARDAR, SE MANDAN LOS MÚLTIPLES BINES A RESUMEN ---
    Private Sub AlCompletarPesajeBloque(listaBines As List(Of ucPesajeBloque.RegistroPesajeItem))
        Dim frm As Form1 = TryCast(Me.FindForm(), Form1)

        If frm IsNot Nothing Then
            Dim listaPesajes As New List(Of PesajeFinal)()

            For Each item In listaBines
                Dim p As New PesajeFinal() With {
                    .Titulo = item.NumeroOrden.ToString(),
                    .IdContenedor = item.IdTipoContenedor,
                    .Tara = item.Tara,
                    .PesoBruto = item.PesoBruto,
                    .PesoNeto = item.PesoNeto
                }
                listaPesajes.Add(p)
            Next

            Dim resumen As New ucResumen()
            resumen.ModoActual = ucResumen.ModoOperacion.Recepcion

            resumen.CargarDatos(
                listaPesajes,
                Val(frm.IdRecepcionGlobal),
                Val(frm.IdProductoGlobal),
                Val(frm.IdVariedadGlobal),
                Val(frm.IdTipoRecepcionGlobal)
            )

            frm.NavegarA(resumen)
        End If
    End Sub

End Class