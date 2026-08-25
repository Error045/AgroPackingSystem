
Public Class ucOrdenDespachoRepesaje

        Enum PasoRepesaje
            Busqueda = 0
            Pesaje = 1
            Actualizacion = 2
        End Enum

        Private PasoActual As Integer = 1
        Private CantidadTotalAProcesar As Integer = 0
        Private sesionActual As New SesionPesaje()
        Private controlPesajeUnico As ucPesaje

        Private listaDatosRepesaje As New List(Of Dictionary(Of String, String))

        Public Sub GestionarPasos(paso As PasoRepesaje)
            UcOrdenDespachoRepesajeValidacion1.Visible = False
            pnlContenedorPesaje.Visible = False
            UcOrdenDespachoRepesajeActualizar1.Visible = False

            Select Case paso
                Case PasoRepesaje.Busqueda
                    UcOrdenDespachoRepesajeValidacion1.Visible = True
                    UcOrdenDespachoRepesajeValidacion1.BringToFront()
                Case PasoRepesaje.Pesaje
                    pnlContenedorPesaje.Visible = True
                    pnlContenedorPesaje.BringToFront()
                Case PasoRepesaje.Actualizacion
                    UcOrdenDespachoRepesajeActualizar1.Visible = True
                    UcOrdenDespachoRepesajeActualizar1.BringToFront()
                    UcOrdenDespachoRepesajeActualizar1.Dock = DockStyle.Fill
            End Select
        End Sub

        Private Sub ucOrdenDespachoRepesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            GestionarPasos(PasoRepesaje.Busqueda)
        End Sub

        Private Sub UcOrdenDespachoRepesajeValidacion1_LoteValidado(lotes As List(Of DataRow)) Handles UcOrdenDespachoRepesajeValidacion1.LoteValidado
            CantidadTotalAProcesar = lotes.Count
            listaDatosRepesaje.Clear()

            ' A. Convertimos a nuestra lista de diccionarios
            For Each row In lotes
                Dim infoRepesaje As New Dictionary(Of String, String) From {
                    {"ID_PALLET", row("id").ToString()},
                    {"Despacho", row("despacho").ToString()},
                    {"Cajas", row("numero_cajas").ToString()},
                    {"KILOS_ORIGEN", row("kilos_brutos").ToString()},
                    {"TARA_ORIGEN", row("tara").ToString()},
                    {"ID_ORIGINAL_CONTENEDOR", row("tipos_contenedores_id").ToString()}
                }
                listaDatosRepesaje.Add(infoRepesaje)
            Next

            sesionActual.IniciarNuevaSesion(CantidadTotalAProcesar, listaDatosRepesaje(0))

            pnlContenedorPesaje.Controls.Clear()
            controlPesajeUnico = New ucPesaje()
            controlPesajeUnico.Name = "ucPesajePrincipal"
            controlPesajeUnico.Dock = DockStyle.Fill

            ' D. Configuramos el Panel Lateral
            Dim datosPanelLateral As New Dictionary(Of String, String) From {
                {"Nro. Pallet", listaDatosRepesaje(0)("ID_PALLET")},
                {"Despacho", listaDatosRepesaje(0)("Despacho")},
                {"Nro. Cajas", listaDatosRepesaje(0)("Cajas")},
                {"ID Envase Orig.", listaDatosRepesaje(0)("ID_ORIGINAL_CONTENEDOR")},
                {"Peso Origen", Convert.ToDecimal(listaDatosRepesaje(0)("KILOS_ORIGEN")).ToString("N2") & " Kg"},
                {"Tara Origen", Convert.ToDecimal(listaDatosRepesaje(0)("TARA_ORIGEN")).ToString("N2") & " Kg"}
            }

            controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Tarjado, datosPanelLateral)
            controlPesajeUnico.Titulo = "⚖️ REPESAJE PALLET #" & listaDatosRepesaje(0)("ID_PALLET")

            AddHandler controlPesajeUnico.ContenedorProcesado, AddressOf ProcesarCapturaContenedor
            pnlContenedorPesaje.Controls.Add(controlPesajeUnico)

            GestionarPasos(PasoRepesaje.Pesaje)
        End Sub

        Private Sub ProcesarCapturaContenedor()
            Dim totalRealBascula As Double = BasculaManager.Instancia.PesoActual

            Dim brutoDeBalanza As Double = 0
            If Not Double.TryParse(controlPesajeUnico.Peso, brutoDeBalanza) OrElse brutoDeBalanza <= 0 Then
                MessageBox.Show("No se ha detectado un aumento de carga en la báscula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Dim indiceActual As Integer = sesionActual.PesajesCompletados.Count
            Dim datosOriginales = listaDatosRepesaje(indiceActual)
            Dim idContenedorEsperado As Integer = Convert.ToInt32(datosOriginales("ID_ORIGINAL_CONTENEDOR"))

            If controlPesajeUnico.IdContenedorSeleccionado <> idContenedorEsperado Then
                MessageBox.Show($"Cuidado: El envase original de este Pallet es diferente al seleccionado." & vbCrLf &
                                $"Por favor, seleccione el envase correcto.",
                                "Discrepancia de Envase", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim pesoAcumuladoAnterior As Double = 0
            For Each pesajePrevio In sesionActual.PesajesCompletados
                pesoAcumuladoAnterior += pesajePrevio.PesoBruto
            Next

            Dim pesoBrutoEstePallet As Double = totalRealBascula - pesoAcumuladoAnterior

            sesionActual.PesoAcumuladoAnterior = 0
            sesionActual.RegistrarPesaje(pesoBrutoEstePallet, controlPesajeUnico.TaraSeleccionada, controlPesajeUnico.IdContenedorSeleccionado)

            If sesionActual.CicloCompleto Then
                FinalizarYEnviarAActualizar()
            Else
                controlPesajeUnico.PesoAcumuladoBinesAnteriores = totalRealBascula

                Dim indiceSiguiente As Integer = sesionActual.PesajesCompletados.Count
                Dim datosSiguientes = listaDatosRepesaje(indiceSiguiente)

                Dim datosPanelSiguiente As New Dictionary(Of String, String) From {
                    {"Nro. Pallet", datosSiguientes("ID_PALLET")},
                    {"Despacho", datosSiguientes("Despacho")},
                    {"Nro. Cajas", datosSiguientes("Cajas")},
                    {"ID Envase Orig.", datosSiguientes("ID_ORIGINAL_CONTENEDOR")},
                    {"Peso Origen", Convert.ToDecimal(datosSiguientes("KILOS_ORIGEN")).ToString("N2") & " Kg"},
                    {"Tara Origen", Convert.ToDecimal(datosSiguientes("TARA_ORIGEN")).ToString("N2") & " Kg"}
                }

                controlPesajeUnico.ConfigurarVista(ucPesaje.ModoVista.Tarjado, datosPanelSiguiente)
                controlPesajeUnico.Titulo = "⚖️ REPESAJE PALLET #" & datosSiguientes("ID_PALLET")
                controlPesajeUnico.Refresh()
            End If
        End Sub

        Private Sub FinalizarYEnviarAActualizar()
            Dim loteParaGuardar As New List(Of Dictionary(Of String, String))

            For i As Integer = 0 To sesionActual.PesajesCompletados.Count - 1
                Dim pesajeFinal = sesionActual.PesajesCompletados(i)
                Dim datosOriginales = listaDatosRepesaje(i)

                Dim info As New Dictionary(Of String, String) From {
                    {"ID_PALLET", datosOriginales("ID_PALLET")},
                    {"Bruto", pesajeFinal.PesoBruto.ToString("F2")},
                    {"Tara", pesajeFinal.Tara.ToString("F2")}
                }
                loteParaGuardar.Add(info)
            Next

            UcOrdenDespachoRepesajeActualizar1.RecibirDatosParaRevision(loteParaGuardar)
            GestionarPasos(PasoRepesaje.Actualizacion)
        End Sub

        ' Manejadores de los eventos de la pantalla Final (Actualizar)
        Private Sub UcOrdenDespachoRepesajeActualizar1_ProcesoCancelado() Handles UcOrdenDespachoRepesajeActualizar1.ProcesoCancelado
            UcOrdenDespachoRepesajeValidacion1.Reiniciar()
            GestionarPasos(PasoRepesaje.Busqueda)
        End Sub

        Private Sub UcOrdenDespachoRepesajeActualizar1_SolicitarGuardadoFinal(datosFinales As List(Of Dictionary(Of String, String))) Handles UcOrdenDespachoRepesajeActualizar1.SolicitarGuardadoFinal
            UcOrdenDespachoRepesajeValidacion1.Reiniciar()
            GestionarPasos(PasoRepesaje.Busqueda)
        End Sub

    End Class







