Imports sistemaPackingv2.ucRecepcion

Public Class ucCalibradoPesaje

    Enum PasoCalibrado
        Busqueda = 0
        Pesaje = 1
        Ubicacion = 2
    End Enum

    ' --- VARIABLES PARA EL CONTROL DEL LOTE ---
    Private PasoActual As Integer = 1
    Private CantidadTotalAProcesar As Integer = 0
    Private sesionActual As New SesionPesaje()
    Private controlPesajeUnico As ucPesaje

    ' 🟢 NUEVA VARIABLE: Guardaremos los datos de los tickets aquí para no perderlos
    Private listaDatosCalibrado As New List(Of Dictionary(Of String, String))

    ' Gestión de visibilidad (Igual que en Recepción)
    Public Sub GestionarPasos(paso As PasoCalibrado)
        ucCalValidacion1.Visible = False
        pnlContenedorPesaje.Visible = False
        UcUbicacion1.Visible = False

        Select Case paso
            Case PasoCalibrado.Busqueda
                ucCalValidacion1.Visible = True
                ucCalValidacion1.BringToFront()
            Case PasoCalibrado.Pesaje
                pnlContenedorPesaje.Visible = True
                pnlContenedorPesaje.BringToFront()
            Case PasoCalibrado.Ubicacion
                UcUbicacion1.Visible = True
                UcUbicacion1.BringToFront()
                UcUbicacion1.Dock = DockStyle.Fill
        End Select
    End Sub

    ' 🟢 1. CUANDO SE VALIDAN LOS LOTES
    Private Sub ucCalValidacion1_LoteValidado(lotes As List(Of DataRow)) Handles ucCalValidacion1.LoteValidado
        CantidadTotalAProcesar = lotes.Count
        listaDatosCalibrado.Clear()

        ' A. Convertimos todos los DataRow en nuestra lista de Diccionarios
        For Each row In lotes
            Dim infoCalibrado As New Dictionary(Of String, String) From {
                {"ID_CAL", row("id").ToString()},
                {"Proceso", row("proceso").ToString()},
                {"Productor", row("productor").ToString()},
                {"Producto", row("producto").ToString()},
                {"Variedad", row("variedad").ToString()},
                {"Calibre", row("calibre").ToString()}
            }
            listaDatosCalibrado.Add(infoCalibrado)
        Next

        ' B. Iniciamos la memoria de la sesión matemática
        ' Le pasamos el primer diccionario solo como configuración inicial
        sesionActual.IniciarNuevaSesion(CantidadTotalAProcesar, listaDatosCalibrado(0))

        ' C. Limpiamos el panel y creamos UN SOLO control visual
        pnlContenedorPesaje.Controls.Clear()
        controlPesajeUnico = New ucPesaje()
        controlPesajeUnico.Name = "ucPesajePrincipal"
        controlPesajeUnico.Dock = DockStyle.Fill

        ' D. Configuramos el control visual PARA EL PRIMER BIN (Índice 0)
        ' NOTA: Asumo que en ucPesaje.ModoVista tienes "Calibrado", si no, usa Recepcion
        controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Calibrado, listaDatosCalibrado(0))
        controlPesajeUnico.Titulo = "📦 CONTENEDOR #1"

        AddHandler controlPesajeUnico.ContenedorProcesado, AddressOf ProcesarCapturaContenedor
        pnlContenedorPesaje.Controls.Add(controlPesajeUnico)

        GestionarPasos(PasoCalibrado.Pesaje)
    End Sub

    ' 🟢 2. CUANDO EL OPERARIO PRESIONA EL BOTÓN CAPTURAR
    Private Sub ProcesarCapturaContenedor()
        Dim totalRealBascula As Double = BasculaManager.Instancia.PesoActual

        ' A. Validamos visualmente
        Dim brutoDeBalanza As Double = 0
        If Not Double.TryParse(controlPesajeUnico.Peso, brutoDeBalanza) OrElse brutoDeBalanza <= 0 Then
            MessageBox.Show("No se ha detectado un aumento de carga en la báscula." & vbCrLf &
                            "Por favor, verifique el pesaje.",
                            "Aviso de Carga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' B. Guardamos la matemática en la sesión (Igual que en Recepción)
        sesionActual.RegistrarPesaje(totalRealBascula, controlPesajeUnico.TaraSeleccionada, controlPesajeUnico.IdContenedorSeleccionado)

        ' C. Evaluamos si terminamos el ciclo
        If sesionActual.CicloCompleto Then
            FinalizarYEnviarAUbicacion()
        Else
            ' D. PREPARAMOS EL CONTROL PARA EL SIGUIENTE BIN
            controlPesajeUnico.PesoAcumuladoBinesAnteriores = totalRealBascula

            Dim indiceSiguiente As Integer = sesionActual.PesajesCompletados.Count

            ' ACTUALIZAMOS la información en pantalla para que muestre los datos del siguiente ID_CAL
            controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Calibrado, listaDatosCalibrado(indiceSiguiente))
            controlPesajeUnico.Titulo = "📦 CONTENEDOR #" & (indiceSiguiente + 1)
            controlPesajeUnico.Refresh()
        End If
    End Sub

    ' 🟢 3. MÉTODO QUE REEMPLAZA A AvanzarFlujo() Y UNE LOS DATOS

    Private Sub FinalizarYEnviarAUbicacion()
        Dim loteParaGuardar As New List(Of Dictionary(Of String, String))

        ' Recorremos la lista de resultados de la sesión. 
        ' Como se pesaron en orden, el pesaje "i" corresponde a los datos "i"
        For i As Integer = 0 To sesionActual.PesajesCompletados.Count - 1
            Dim pesajeFinal = sesionActual.PesajesCompletados(i)
            Dim datosOriginales = listaDatosCalibrado(i)

            ' 🟢 CORRECCIÓN: Agregamos Producto, Variedad y Calibre desde datosOriginales
            Dim info As New Dictionary(Of String, String) From {
                {"ID_CAL", datosOriginales("ID_CAL")},
                {"Producto", datosOriginales("Producto")},
                {"Variedad", datosOriginales("Variedad")},
                {"Calibre", datosOriginales("Calibre")},
                {"idTipoCont", pesajeFinal.IdContenedor.ToString()},
                {"Bruto", pesajeFinal.PesoBruto.ToString("F2")},
                {"Neto", pesajeFinal.PesoNeto.ToString("F2")}
            }
            loteParaGuardar.Add(info)
        Next

        ' Enviamos todo a la pantalla de ubicación
        UcUbicacion1.RecibirDatosParaGuardar(loteParaGuardar)

        ' Cambiamos a la última pantalla
        GestionarPasos(PasoCalibrado.Ubicacion)
    End Sub


End Class