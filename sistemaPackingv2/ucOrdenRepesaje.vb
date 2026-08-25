Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ucOrdenRepesaje

    Enum PasoRepesaje
        Busqueda = 0
        Pesaje = 1
        Actualizacion = 2
    End Enum

    ' --- VARIABLES PARA EL CONTROL DEL LOTE ---
    Private PasoActual As Integer = 1
    Private CantidadTotalAProcesar As Integer = 0
    Private sesionActual As New SesionPesaje()
    Private controlPesajeUnico As ucPesaje

    ' Guardaremos los datos originales de los bines a repesar
    Private listaDatosRepesaje As New List(Of Dictionary(Of String, String))

    ' 🟢 Gestión de visibilidad
    Public Sub GestionarPasos(paso As PasoRepesaje)
        UcOrdenRepesajeValidacion1.Visible = False
        pnlContenedorPesaje.Visible = False
        UcOrdenRepesajeActualizar1.Visible = False

        Select Case paso
            Case PasoRepesaje.Busqueda
                UcOrdenRepesajeValidacion1.Visible = True
                UcOrdenRepesajeValidacion1.BringToFront()
            Case PasoRepesaje.Pesaje
                pnlContenedorPesaje.Visible = True
                pnlContenedorPesaje.BringToFront()
            Case PasoRepesaje.Actualizacion
                UcOrdenRepesajeActualizar1.Visible = True
                UcOrdenRepesajeActualizar1.BringToFront()
                UcOrdenRepesajeActualizar1.Dock = DockStyle.Fill
        End Select
    End Sub
    ' 🟢 0. AL CARGAR EL CONTROL ORQUESTADOR
    Private Sub ucOrdenRepesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Forzamos a que siempre inicie en la pantalla de Búsqueda/Validación
        GestionarPasos(PasoRepesaje.Busqueda)
    End Sub

    ' 🟢 1. CUANDO SE VALIDAN LOS LOTES A REPESAR (Viene de UcOrdenRepesajeValidacion)
    Private Sub UcOrdenRepesajeValidacion1_LoteValidado(lotes As List(Of DataRow)) Handles UcOrdenRepesajeValidacion1.LoteValidado
        CantidadTotalAProcesar = lotes.Count
        listaDatosRepesaje.Clear()

        ' A. Convertimos los DataRow a nuestra lista de Diccionarios con los datos originales
        For Each row In lotes
            Dim infoRepesaje As New Dictionary(Of String, String) From {
                {"ID_BIN", row("id").ToString()},
                {"Producto", row("producto").ToString()},
                {"Variedad", row("variedad").ToString()},
                {"Calibre", row("calibre").ToString()},
                {"KILOS_ORIGEN", row("kilos_brutos").ToString()},
                {"TARA_ORIGEN", row("tara").ToString()},
                {"ID_ORIGINAL_CONTENEDOR", row("tipos_contenedores_id").ToString()}
            }
            listaDatosRepesaje.Add(infoRepesaje)
        Next

        ' B. Iniciamos la memoria de la sesión matemática
        sesionActual.IniciarNuevaSesion(CantidadTotalAProcesar, listaDatosRepesaje(0))

        ' C. Limpiamos el panel y creamos UN SOLO control visual
        pnlContenedorPesaje.Controls.Clear()
        controlPesajeUnico = New ucPesaje()
        controlPesajeUnico.Name = "ucPesajePrincipal"
        controlPesajeUnico.Dock = DockStyle.Fill

        ' D. Configuramos el Panel Lateral para el PRIMER BIN
        Dim datosPanelLateral As New Dictionary(Of String, String) From {
            {"Nro. Bin", listaDatosRepesaje(0)("ID_BIN")},
            {"ID Envase Orig.", listaDatosRepesaje(0)("ID_ORIGINAL_CONTENEDOR")},
            {"Producto", listaDatosRepesaje(0)("Producto")},
            {"Variedad", listaDatosRepesaje(0)("Variedad")},
            {"Calibre", listaDatosRepesaje(0)("Calibre")},
            {"Peso Origen", Convert.ToDecimal(listaDatosRepesaje(0)("KILOS_ORIGEN")).ToString("N2") & " Kg"},
            {"Tara Origen", Convert.ToDecimal(listaDatosRepesaje(0)("TARA_ORIGEN")).ToString("N2") & " Kg"}
        }

        controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Tarjado, datosPanelLateral)
        controlPesajeUnico.Titulo = "⚖️ REPESAJE BIN #" & listaDatosRepesaje(0)("ID_BIN")

        ' Enganchamos el evento
        AddHandler controlPesajeUnico.ContenedorProcesado, AddressOf ProcesarCapturaContenedor
        pnlContenedorPesaje.Controls.Add(controlPesajeUnico)

        GestionarPasos(PasoRepesaje.Pesaje)
    End Sub

    ' 🟢 2. CUANDO EL OPERARIO PRESIONA EL BOTÓN CAPTURAR
    Private Sub ProcesarCapturaContenedor()
        Dim totalRealBascula As Double = BasculaManager.Instancia.PesoActual

        ' A. Validamos que haya peso en la balanza
        Dim brutoDeBalanza As Double = 0
        If Not Double.TryParse(controlPesajeUnico.Peso, brutoDeBalanza) OrElse brutoDeBalanza <= 0 Then
            MessageBox.Show("No se ha detectado un aumento de carga en la báscula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' B. Validar si el contenedor seleccionado es el mismo de la Base de Datos
        Dim indiceActual As Integer = sesionActual.PesajesCompletados.Count
        Dim datosOriginales = listaDatosRepesaje(indiceActual)
        Dim idContenedorEsperado As Integer = Convert.ToInt32(datosOriginales("ID_ORIGINAL_CONTENEDOR"))

        If controlPesajeUnico.IdContenedorSeleccionado <> idContenedorEsperado Then
            MessageBox.Show($"Cuidado: El envase original de este Bin es diferente al seleccionado." & vbCrLf &
                            $"Por favor, seleccione el envase correcto.",
                            "Discrepancia de Envase", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 🟢 C. LÓGICA ESCENARIO A (Acumulado)
        Dim pesoAcumuladoAnterior As Double = 0
        For Each pesajePrevio In sesionActual.PesajesCompletados
            pesoAcumuladoAnterior += pesajePrevio.PesoBruto
        Next

        ' Restamos el peso acumulado para obtener solo el peso de ESTE bin
        Dim pesoBrutoEsteBin As Double = totalRealBascula - pesoAcumuladoAnterior

        sesionActual.PesoAcumuladoAnterior = 0
        ' Guardamos en la sesión el peso CALCULADO
        sesionActual.RegistrarPesaje(pesoBrutoEsteBin, controlPesajeUnico.TaraSeleccionada, controlPesajeUnico.IdContenedorSeleccionado)


        ' D. Evaluamos si terminamos el ciclo
        If sesionActual.CicloCompleto Then
            FinalizarYEnviarAActualizar()
        Else
            ' E. PREPARAMOS EL CONTROL PARA EL SIGUIENTE BIN
            controlPesajeUnico.PesoAcumuladoBinesAnteriores = totalRealBascula

            Dim indiceSiguiente As Integer = sesionActual.PesajesCompletados.Count
            Dim datosSiguientes = listaDatosRepesaje(indiceSiguiente)

            ' Mapeo exacto para el panel lateral del siguiente bin
            Dim datosPanelSiguiente As New Dictionary(Of String, String) From {
                {"Nro. Bin", datosSiguientes("ID_BIN")},
                {"ID Envase Orig.", datosSiguientes("ID_ORIGINAL_CONTENEDOR")},
                {"Producto", datosSiguientes("Producto")},
                {"Variedad", datosSiguientes("Variedad")},
                {"Calibre", datosSiguientes("Calibre")},
                {"Peso Origen", Convert.ToDecimal(datosSiguientes("KILOS_ORIGEN")).ToString("N2") & " Kg"},
                {"Tara Origen", Convert.ToDecimal(datosSiguientes("TARA_ORIGEN")).ToString("N2") & " Kg"}
            }

            controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Tarjado, datosPanelSiguiente)
            controlPesajeUnico.Titulo = "⚖️ REPESAJE BIN #" & datosSiguientes("ID_BIN")
            controlPesajeUnico.Refresh()
        End If
    End Sub

    ' 🟢 3. MÉTODO PARA ENVIAR A LA GRILLA FINAL
    Private Sub FinalizarYEnviarAActualizar()
        Dim loteParaGuardar As New List(Of Dictionary(Of String, String))

        For i As Integer = 0 To sesionActual.PesajesCompletados.Count - 1
            Dim pesajeFinal = sesionActual.PesajesCompletados(i)
            Dim datosOriginales = listaDatosRepesaje(i)

            ' Solo mandamos ID, Bruto Nuevo y Tara Nueva. La BD hará el resto en el siguiente control.
            Dim info As New Dictionary(Of String, String) From {
                {"ID_BIN", datosOriginales("ID_BIN")},
                {"Bruto", pesajeFinal.PesoBruto.ToString("F2")},
                {"Tara", pesajeFinal.Tara.ToString("F2")}
            }
            loteParaGuardar.Add(info)
        Next

        ' Enviamos a la interfaz final
        UcOrdenRepesajeActualizar1.RecibirDatosParaRevision(loteParaGuardar)

        ' Cambiamos a la pantalla final
        GestionarPasos(PasoRepesaje.Actualizacion)
    End Sub

    Private Sub UcOrdenRepesajeActualizar1_ProcesoCancelado()

    End Sub
End Class