Imports MySql.Data.MySqlClient

Public Class ucPesajePallets
    Enum PasoCalibrado
        Busqueda = 0
        Pesaje = 1
        Ubicacion = 2
    End Enum

    ' --- VARIABLES DE CONTROL ---
    Private PasoActual As Integer = 1
    Private CantidadTotalAProcesar As Integer = 0
    Private listaPesajes As New List(Of ucPesaje)
    Private PesoAcumuladoAnterior As Double = 0.0

    Public Sub GestionarPasos(paso As PasoCalibrado)
        ' 1. Apagamos todo
        UcValidacionPallet1.Visible = False ' Control de búsqueda de pallets
        pnlContenedorPesaje.Visible = False
        UcUbicacionPallets1.Visible = False

        ' 2. Encendemos lo correspondiente
        Select Case paso
            Case PasoCalibrado.Busqueda
                UcValidacionPallet1.Visible = True
                UcValidacionPallet1.BringToFront()
            Case PasoCalibrado.Pesaje
                pnlContenedorPesaje.Visible = True
                pnlContenedorPesaje.BringToFront()
            Case PasoCalibrado.Ubicacion
                UcUbicacionPallets1.Visible = True
                UcUbicacionPallets1.BringToFront()
                UcUbicacionPallets1.Dock = DockStyle.Fill
        End Select
    End Sub

    ' 🟢 RECEPCIÓN DE DATOS DEL PALLET (Sincronizado con los alias de tu consulta SQL)
    Private Sub ucValidacionPallet1_PalletValidado(pallets As List(Of DataRow)) Handles UcValidacionPallet1.PalletValidado
        CantidadTotalAProcesar = pallets.Count
        PasoActual = 1
        PesoAcumuladoAnterior = 0

        pnlContenedorPesaje.Controls.Clear()
        listaPesajes.Clear()

        For i As Integer = 1 To pallets.Count
            Dim row = pallets(i - 1)

            Dim nuevoContenedor As New ucPesaje()
            nuevoContenedor.Name = "ContPallet" & i

            ' 🔥 CORRECCIÓN 1: Cambiado row("id") por row("ID_Pallet")
            nuevoContenedor.Titulo = "⚖️ PESAJE PALLET N° " & row("ID_Pallet").ToString()

            ' 🔥 CORRECCIÓN 2: Mapeo exacto de los nombres de columna de tu consulta SQL
            Dim infoPallet As New Dictionary(Of String, String) From {
               {"ID_PALLET", row("ID_Pallet").ToString()},
               {"Proceso", row("Proceso").ToString()},
               {"NumeroCajas", row("Cajas").ToString()},
               {"ID_TipoContenedorCaja", row("Tipo_Caja").ToString()},
               {"ID_TipoContenedorPallet", row("Tipo_Pallet").ToString()}
            }

            ' Ajustar según el modo que uses en ucPesaje
            nuevoContenedor.ConfigurarVista(ucPesaje.ModoVista.Tarjado, infoPallet)

            AddHandler nuevoContenedor.ContenedorProcesado, AddressOf ProcesarCapturaContenedor

            nuevoContenedor.Dock = DockStyle.Fill
            nuevoContenedor.Visible = (i = 1)

            pnlContenedorPesaje.Controls.Add(nuevoContenedor)
            listaPesajes.Add(nuevoContenedor)
        Next

        GestionarPasos(PasoCalibrado.Pesaje)
    End Sub

    Private Sub ProcesarCapturaContenedor()
        Dim ucActual = listaPesajes(PasoActual - 1)
        Dim frm = DirectCast(Me.FindForm(), Form1)

        Dim pesoPuntual As Double = 0
        If Not Double.TryParse(ucActual.Peso, pesoPuntual) OrElse pesoPuntual <= 0 Then
            MessageBox.Show("No se ha detectado carga en la báscula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        PesoAcumuladoAnterior = frm.PesoDesdeBascula
        AvanzarFlujo()
    End Sub

    Private Sub AvanzarFlujo()
        listaPesajes(PasoActual - 1).Visible = False

        If PasoActual < CantidadTotalAProcesar Then
            PasoActual += 1
            Dim proximo = listaPesajes(PasoActual - 1)
            proximo.PesoAcumuladoAnterior = Me.PesoAcumuladoAnterior
            proximo.Visible = True
            proximo.BringToFront()
            proximo.Focus()
        Else
            ' 🎉 FINALIZÓ EL PESAJE: CÁLCULO DE TARA COMPUESTA Y PESO NETO
            Dim loteParaGuardar As New List(Of Dictionary(Of String, String))

            For Each uc In listaPesajes
                Dim bruto As Double = 0
                Double.TryParse(uc.Peso, bruto)

                ' 1. Recuperamos los datos inyectados en la configuración inicial (del Dictionary de arriba)
                Dim idPallet As String = uc.DatosActuales("ID_PALLET")
                Dim numeroCajas As Integer = Convert.ToInt32(uc.DatosActuales("NumeroCajas"))
                Dim idTipoCaja As Integer = Convert.ToInt32(uc.DatosActuales("ID_TipoContenedorCaja"))
                Dim idTipoPallet As Integer = Convert.ToInt32(uc.DatosActuales("ID_TipoContenedorPallet"))

                ' 2. Obtenemos las Taras desde la base de datos
                Dim taraCaja As Double = ObtenerTaraContenedor(idTipoCaja)
                Dim taraBasePallet As Double = ObtenerTaraContenedor(idTipoPallet)

                ' 3. FÓRMULA MATEMÁTICA:
                Dim taraTotalCompuesta As Double = taraBasePallet + (taraCaja * numeroCajas)
                Dim neto As Double = bruto - taraTotalCompuesta

                ' 4. Prevención de valores negativos
                If neto < 0 Then neto = 0

                Dim info As New Dictionary(Of String, String) From {
                   {"ID_PALLET", idPallet},
                   {"Bruto", bruto.ToString("F2")},
                   {"Neto", neto.ToString("F2")},
                   {"TaraTotal", taraTotalCompuesta.ToString("F2")}
               }
                loteParaGuardar.Add(info)
            Next

            ' Enviamos los datos procesados para su actualización en BD y guardado en Historial
            UcUbicacionPallets1.RecibirDatosParaGuardar(loteParaGuardar)
            MessageBox.Show("Lote guardado en memoria. Pasando a pantalla de Ubicación...", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GestionarPasos(PasoCalibrado.Ubicacion)
        End If
    End Sub

    ' --- MÉTODO AUXILIAR PARA CONSULTAR LA TARA EN LA BD ---
    Private Function ObtenerTaraContenedor(idContenedor As Integer) As Double
        Dim tara As Double = 0.0
        ' 🔥 CORRECCIÓN 3: Sincronizado el campo con tu consulta SELECT original ('tara' en lugar de 'peso_tara')
        Dim sql As String = "SELECT tara FROM tipos_contenedores WHERE id = @id"

        Try
            ConexionBD.Abrir()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@id", idContenedor)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    tara = Convert.ToDouble(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener la tara del contenedor ID " & idContenedor & ": " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        Return tara
    End Function


End Class