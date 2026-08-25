Imports System.IO.Ports


Public Class Form1

    ' --- Variables para el Puerto Serial ---
    Public WithEvents PuertoBascula As New SerialPort
    Public Property PuertoNombre As String = "COM1"
    Public Property Baudios As Integer = 2400
    Public Property PesoDesdeBascula As Double = 0 ' Esta variable recibirá el dato real


    ' Public Property IdVariedadGlobal As Integer = 0

    Public Property NombrePersonaGlobal As String = ""
    Public Property NombreProductoGlobal As String = ""
    Public Property NombreVariedadGlobal As String = ""
    Public Property IdRecepcionGlobal As String = 0

    Public Property IdTipoRecepcionGlobal As Integer = 0
    Public Property IdPersonaGlobal As String = 0

    Public Property IdProductoGlobal As Integer = 0
    Public Property IdVariedadGlobal As Integer = 0


    Public Property IdTaraGlobal As Double = 0 ' Valor fijo o configurable

    'Private vistaBarcode As ucPesajeOrden
    'Private vistaPesaje As ucPesaje

    ' En Form1.vb
    Public Sub ReiniciarPuerto()
        Try
            If PuertoBascula.IsOpen Then PuertoBascula.Close()

            ' Cargar datos actualizados desde los Settings
            PuertoBascula.PortName = My.Settings.PuertoNombre
            PuertoBascula.BaudRate = My.Settings.Baudios

            PuertoBascula.Open()
        Catch ex As Exception
            MessageBox.Show("Error al abrir puerto: " & ex.Message)
        End Try
    End Sub

    ' OPCIONAL: Agregar un TextBox pequeño en una esquina del Form1 para escribir el peso 
    ' y un botón para actualizarlo, simula que la báscula "envió" el dato.
    Private Sub btnSimularPeso_Click(sender As Object, e As EventArgs) Handles btnSimularPeso.Click
        Dim pesoSimulado As Double = Val(txtSimulador.Text)

        Me.PesoDesdeBascula = pesoSimulado
        ' 🟢 Avisamos al Manager para que ucPesaje se entere del cambio
        BasculaManager.Instancia.ActualizarPeso(pesoSimulado)
    End Sub

    ' En Form1.vb
    Public Sub ConectarBascula()

        Try
            ' Si el puerto ya estaba abierto, lo cerramos para aplicar cambios
            If PuertoBascula.IsOpen Then PuertoBascula.Close()

            ' ASIGNACIÓN DESDE SETTINGS (Esto hace que los ComboBox funcionen)
            PuertoBascula.PortName = My.Settings.PuertoNombre
            PuertoBascula.BaudRate = My.Settings.Baudios

            ' Configuraciones estándar de seguridad
            PuertoBascula.DataBits = 8
            PuertoBascula.Parity = Parity.None
            PuertoBascula.StopBits = StopBits.One
            PuertoBascula.ReadTimeout = 1000

            PuertoBascula.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar con los nuevos parámetros: " & ex.Message, "Error de Puerto")
        End Try

    End Sub




    Private Function LimpiarCadenaBascula(cadenaCruda As String) As Double
        Try
            ' 1. BUSCAR EL INICIO REAL (=)
            Dim inicio As Integer = cadenaCruda.IndexOf("=")
            If inicio = -1 Then Return -1

            ' Tomamos todo desde el "=" en adelante para analizar
            Dim desdeIgual As String = cadenaCruda.Substring(inicio)

            ' 2. BUSCAR EL FINAL DINÁMICO (Primer espacio o letra después del inicio)
            ' Buscamos la posición del primer espacio que separa el peso de la basura (C0Q3D)
            Dim fin As Integer = -1
            For i As Integer = 1 To desdeIgual.Length - 1
                Dim caracter As Char = desdeIgual(i)
                ' Si encontramos un espacio o una letra, ahí termina nuestro peso
                If caracter = " "c OrElse Char.IsLetter(caracter) OrElse caracter = "@"c Then
                    fin = i
                    Exit For
                End If
            Next

            ' 3. EXTRACCIÓN DINÁMICA
            Dim segmento As String = ""
            If fin <> -1 Then
                segmento = desdeIgual.Substring(0, fin) ' Corta justo antes del espacio/letra
            Else
                segmento = desdeIgual ' Si no hay espacios, toma lo que haya
            End If

            ' 4. LIMPIEZA FINAL Y REVERSE
            ' Quitamos el "=" y cualquier residuo, dejando solo "055.0"
            Dim soloNumeros As String = segmento.Replace("=", "").Trim()

            Dim caracteres() As Char = soloNumeros.Replace(",", ".").ToCharArray()
            Array.Reverse(caracteres)
            Dim cadenaInvertida As String = New String(caracteres)

            ' 5. CONVERSIÓN
            Dim pesoFinal As Double = Val(cadenaInvertida)

            ' Filtro de Cero Muerto para evitar el ruido de "30" o "10"
            If pesoFinal < 1.0 Then Return 0.0

            Return pesoFinal

        Catch ex As Exception
            Return -1
        End Try
    End Function

    ' Este evento detecta cuando la báscula envía información al puerto serial
    Private Sub PuertoBascula_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles PuertoBascula.DataReceived
        Try
            ' 1. Pausa estratégica: Esperamos 100ms para que la trama llegue completa al buffer
            ' Esto evita que los números se "corten" y causen errores como el de 700kg
            System.Threading.Thread.Sleep(100)

            ' 2. Leemos todo el contenido acumulado en el buffer
            Dim trama As String = PuertoBascula.ReadExisting()

            ' 3. Procesamos la trama con tu función de limpieza (la que invierte los números)
            Dim pesoValido As Double = LimpiarCadenaBascula(trama)

            ' 4. Filtro de estabilidad
            ' Solo actualizamos si el peso es mayor o igual a 0
            If pesoValido >= 0 Then
                Me.BeginInvoke(Sub()
                                   ' Aplicamos tu lógica de Cero Muerto
                                   Dim pesoFinal As Double = If(pesoValido <= 0.1, 0.0, pesoValido)

                                   ' Actualizamos la variable local (por si otros controles la usan)
                                   Me.PesoDesdeBascula = pesoFinal

                                   ' 🟢 ¡ESTA ES LA LÍNEA CLAVE! 🟢
                                   ' Le informamos al mundo (y a ucPesaje) cuál es el peso actual
                                   BasculaManager.Instancia.ActualizarPeso(pesoFinal)
                               End Sub)
            End If
        Catch ex As Exception
            ' En caso de error de lectura, no hacemos nada para no detener el programa
        End Try
    End Sub


    Private Sub panelContainer_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub pnlContenedor_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    ' Método para resaltar el botón seleccionado y resetear los demás
    Private Sub SeleccionarOpcion(btnSeleccionado As Button)
        ' 1. Iterar por todos los controles que están en el mismo contenedor que los botones
        ' Asumiendo que tus botones están directamente en el Form o en un Panel lateral.
        ' Si están dentro de un Panel llamado "pnlMenu", usa pnlMenu.Controls
        For Each ctrl As Control In btnSeleccionado.Parent.Controls
            ' Verificar si el control es un botón
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)

                ' 2. Restaurar colores originales (Estado Inicial)
                btn.BackColor = Color.FromKnownColor(KnownColor.Control) ' O el color original que tengan
                btn.ForeColor = Color.Black
            End If
        Next

        ' 3. Resaltar UNICAMENTE el botón que recibió el clic
        btnSeleccionado.BackColor = Color.FromArgb(31, 30, 68) ' Color oscuro
        btnSeleccionado.ForeColor = Color.White
    End Sub

    ' Eventos de los botones
    Private Sub btnNuevaRecepcion_Click(sender As Object, e As EventArgs) Handles btnNuevaRecepcion.Click
        SeleccionarOpcion(DirectCast(sender, Button))
        ' Aquí cargas tu formulario o control de Recepción

        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucNuevaRecepcion As New ucNuevaRecepcion()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucNuevaRecepcion.Dock = DockStyle.Fill

        ' 4. Agregarlo al panel central

        pnlContenedor.Controls.Add(ucNuevaRecepcion)


    End Sub


    Private Sub btnRecepcion_Click(sender As Object, e As EventArgs) Handles btnRecepcion.Click
        ' Limpiamos el rastro del proceso anterior
        Me.IdVariedadGlobal = 0
        SeleccionarOpcion(DirectCast(sender, Button))
        ' Aquí cargas tu formulario o control de Recepción

        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        'Dim ucRecepcion As New ucRecepcion()
        Dim ucRecepcion As New ucRecepcion()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        ucRecepcion.BringToFront()
        ucRecepcion.Dock = DockStyle.Fill
        'ucRecepcionEstado.BringToFront()
        'ucRecepcionEstado.Dock = DockStyle.Fill

        ' 4. Agregarlo al panel central

        pnlContenedor.Controls.Add(ucRecepcion)
    End Sub

    Private Sub btnRecepcionProceso_Click(sender As Object, e As EventArgs) Handles btnRecepcionProceso.Click
        SeleccionarOpcion(DirectCast(sender, Button))
        ' Aquí cargas tu formulario o control de Calibrado
        '1. Limpiar el panel central de cualquier otro control
        Dim ucProcesoRegistro As New ucProcesoEstado()
        pnlContenedor.Controls.Clear()
        ucProcesoRegistro.BringToFront()
        ucProcesoRegistro.Dock = DockStyle.Fill
        'ucRecepcionEstado.BringToFront()
        'ucRecepcionEstado.Dock = DockStyle.Fill

        ' 4. Agregarlo al panel central

        pnlContenedor.Controls.Add(ucProcesoRegistro)


    End Sub




    ' Método para intercambiar los controles de usuario
    Public Sub NavegarA(nuevoControl As UserControl)
        ' 1. Limpieza de recursos
        If pnlContenedor.Controls.Count > 0 Then
            Dim ctrlAnterior = pnlContenedor.Controls(0)
            ' Importante: Dispose cierra hilos y libera memoria
            pnlContenedor.Controls.Clear()
            ctrlAnterior.Dispose()
        End If

        ' 2. Configuración del nuevo control
        nuevoControl.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(nuevoControl)
        nuevoControl.BringToFront()
    End Sub

    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        SeleccionarOpcion(DirectCast(sender, Button))
        ' Aquí cargas tu formulario o control de Recepción

        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucConfiguracion As New ucConfiguracion()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucConfiguracion.Dock = DockStyle.Fill

        ' 4. Agregarlo al panel central

        pnlContenedor.Controls.Add(ucConfiguracion)

    End Sub

    Private Sub btnNuevoProceso_Click(sender As Object, e As EventArgs) Handles btnNuevoProceso.Click

        SeleccionarOpcion(DirectCast(sender, Button))
        ' Aquí cargas tu formulario o control de Recepción

        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucNuevoProceso As New ucNuevoProceso()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucNuevoProceso.Dock = DockStyle.Fill


        pnlContenedor.Controls.Add(ucNuevoProceso)

    End Sub

    Private Sub btnCalibres_Click(sender As Object, e As EventArgs) Handles btnCalibres.Click
        SeleccionarOpcion(DirectCast(sender, Button))
        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        'Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucProcesoCalibrado As New ucProcesoCalibrado()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucProcesoCalibrado.Dock = DockStyle.Fill


        pnlContenedor.Controls.Add(ucProcesoCalibrado)


    End Sub

    Private Sub btnCalibreValidacion_Click(sender As Object, e As EventArgs) Handles btnCalibreValidacion.Click
        SeleccionarOpcion(DirectCast(sender, Button))
        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        'Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucCalibradoPesaje As New ucCalibradoPesaje()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucCalibradoPesaje.Dock = DockStyle.Fill


        pnlContenedor.Controls.Add(ucCalibradoPesaje)

    End Sub

    Private Sub btnTotales_Click(sender As Object, e As EventArgs) Handles btnTotales.Click

        SeleccionarOpcion(DirectCast(sender, Button))
        '1. Limpiar el panel central de cualquier otro control
        pnlContenedor.Controls.Clear()
        ' Limpiamos el rastro del proceso anterior
        'Me.IdVariedadGlobal = 0


        ' 2. Crear instancia de tu interfaz de pesaje (UserControl maestro)
        Dim ucDashboard As New ucDashboard()

        ' 3. Ajustarlo para que ocupe todo el espacio disponible
        'ucRecepcion.BringToFront()
        ucDashboard.Dock = DockStyle.Fill

        pnlContenedor.Controls.Add(ucDashboard)


    End Sub

    Private Sub btnTarjado_Click(sender As Object, e As EventArgs) Handles btnTarjado.Click
        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()

        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim vistaOrden As New ucOrdenRepesaje()

        ' (Opcional) Si la orden ya se guardó en BD antes, ya no necesitas pasarle el dtBines por memoria.
        'vistaOrden se encargará de buscar en la BD al cargarse.

        vistaOrden.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(vistaOrden)
    End Sub

    Private Sub btnTarjadoPesaje_Click(sender As Object, e As EventArgs)



    End Sub


    Private Sub btnPallet_Click(sender As Object, e As EventArgs) Handles btnPallet.Click

        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()
        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim vistaPallet As New ucDashboardPallet() 'ucPallet()
        ' vistaPaletizado se encargará de buscar en la BD al cargarse.
        vistaPallet.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(vistaPallet)

    End Sub



    Private Sub btnDespacho_Click(sender As Object, e As EventArgs) Handles btnDespacho.Click
        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()
        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim ucDashboardDespacho As New ucDashboardDespacho()
        'vistaPaletizado se encargará de buscar en la BD al cargarse.
        ucDashboardDespacho.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(ucDashboardDespacho)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()
        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim ucCrearOrden As New ucCrearOrden()
        'vistaPaletizado se encargará de buscar en la BD al cargarse.
        ucCrearOrden.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(ucCrearOrden)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()
        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim ucOrdenDespachoRepesaje As New ucOrdenDespachoRepesaje()
        'vistaPaletizado se encargará de buscar en la BD al cargarse.
        ucOrdenDespachoRepesaje.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(ucOrdenDespachoRepesaje)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' 1. Limpiamos el panel central
        pnlContenedor.Controls.Clear()
        ' 2. Instanciamos el UserControl Maestro (tu sala de espera con el DataGridView)
        Dim ucOrdenRepesaje As New ucOrdenRepesaje()
        'vistaPaletizado se encargará de buscar en la BD al cargarse.
        ucOrdenRepesaje.Dock = DockStyle.Fill
        pnlContenedor.Controls.Add(ucOrdenRepesaje)

    End Sub
End Class
