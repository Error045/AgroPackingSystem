Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ucTarjadoPesaje
    Private dtPaletVirtual As New DataTable()
    Private _taraCajaActual As Decimal = 0

    Private Sub ucTarjadoPesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigurarGridVirtual()

            ' Carga de combos iniciales
            LlenarCombo(cmbTipoOperacion, "SELECT id, nombre FROM tipos_operaciones WHERE estado = 1", "id", "nombre")
            LlenarCombo(cmbProducto, "SELECT id, nombre FROM productos WHERE estado = 1", "id", "nombre")
            LlenarCombo(cmbCajaContenedor, "SELECT id, nombre FROM tipos_contenedores WHERE estado = 1", "id", "nombre")

            GenerarNuevoFolio()
        Catch ex As Exception
            MessageBox.Show("Error al iniciar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' EVENTOS CASCADA Y REFRESCO EN VIVO
    ' =========================================================================

    Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
        MostrarBinesDisponibles()
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        Dim idProd As Integer
        If cmbProducto.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbProducto.SelectedValue.ToString(), idProd) Then
            LlenarCombo(cmbVariedad, "SELECT id, nombre FROM variedades WHERE producto_id = " & idProd, "id", "nombre")
        End If
    End Sub

    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        Dim idVar As Integer
        If cmbVariedad.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbVariedad.SelectedValue.ToString(), idVar) Then
            LlenarCombo(cmbCalibre, "SELECT id, nombre FROM calibres WHERE variedades_id = " & idVar, "id", "nombre")
        End If
    End Sub

    Private Sub cmbCalibre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalibre.SelectedIndexChanged
        MostrarBinesDisponibles()
    End Sub

    Private Sub cmbCajaContenedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajaContenedor.SelectedIndexChanged
        Dim idContenedor As Integer
        If cmbCajaContenedor.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbCajaContenedor.SelectedValue.ToString(), idContenedor) Then
            ' 🟢 Traemos la capacidad teórica y la tara del envase
            Dim dt As DataTable = ObtenerDatos("SELECT capacidad, tara FROM tipos_contenedores WHERE id = " & idContenedor)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                txtKilosCaja.Text = Convert.ToDecimal(dt.Rows(0)("capacidad")).ToString("N2")
                _taraCajaActual = Convert.ToDecimal(dt.Rows(0)("tara"))
            Else
                txtKilosCaja.Text = "0.00"
                _taraCajaActual = 0
            End If
        End If
    End Sub

    ' =========================================================================
    ' MANEJO DE LA GRILLA VIRTUAL (PALET)
    ' =========================================================================
    ' 🟢 El botón ahora invoca la interfaz de pesaje
    Private Sub btnPesarLote_Click(sender As Object, e As EventArgs) Handles btnAgregarLote.Click
        Dim cantidadCajas As Integer = Convert.ToInt32(nudCantidadCajas.Value)

        If cantidadCajas <= 0 Then
            MessageBox.Show("Debes ingresar al menos 1 caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Preparamos los datos para el panel lateral de la báscula
        Dim datosPanelLateral As New Dictionary(Of String, String) From {
            {"Producto", cmbProducto.Text},
            {"Variedad", cmbVariedad.Text},
            {"Calibre", cmbCalibre.Text},
            {"Cant. Cajas", cantidadCajas.ToString()},
            {"Tara por Caja", _taraCajaActual.ToString("N2") & " Kg"}
        }

        UcPesaje1.Titulo = "⚖️ PESAJE LOTE (TARJADO)"
        UcPesaje1.ConfigurarVista(ucPesaje.ModoVista.Tarjado, datosPanelLateral)

        UcPesaje1.Visible = True
        UcPesaje1.BringToFront()
        UcPesaje1.Focus()
    End Sub

    ' 🟢 Evento que recibe el peso real desde la báscula y agrega a la grilla
    Private Sub UcPesaje1_ContenedorProcesado() Handles UcPesaje1.ContenedorProcesado
        Try
            Dim pesoBrutoReal As Decimal = 0
            If Not Decimal.TryParse(UcPesaje1.Peso, pesoBrutoReal) Then
                MessageBox.Show("Error al leer el peso de la balanza.")
                Return
            End If

            UcPesaje1.Visible = False

            Dim cantidadCajas As Integer = Convert.ToInt32(nudCantidadCajas.Value)
            Dim taraTotalLote As Decimal = cantidadCajas * _taraCajaActual
            Dim kilosNetosTotales As Decimal = pesoBrutoReal - taraTotalLote

            ' Evitamos valores negativos si la tara es mayor al peso
            If kilosNetosTotales < 0 Then kilosNetosTotales = 0

            ' Agregamos a la grilla virtual con la matemática resuelta
            dtPaletVirtual.Rows.Add(
                cmbProducto.SelectedValue, cmbProducto.Text,
                cmbVariedad.SelectedValue, cmbVariedad.Text,
                cmbCalibre.SelectedValue, cmbCalibre.Text,
                cmbCajaContenedor.SelectedValue, cmbCajaContenedor.Text,
                cantidadCajas,
                pesoBrutoReal,
                taraTotalLote,
                kilosNetosTotales ' 🟢 EL FIFO USARÁ ESTE VALOR
            )

            nudCantidadCajas.Value = 0
        Catch ex As Exception
            MessageBox.Show("Error al procesar el peso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarGridVirtual()
        dtPaletVirtual.Columns.Clear()

        dtPaletVirtual.Columns.Add("id_producto", GetType(Integer))
        dtPaletVirtual.Columns.Add("Producto", GetType(String))
        dtPaletVirtual.Columns.Add("id_variedad", GetType(Integer))
        dtPaletVirtual.Columns.Add("Variedad", GetType(String))
        dtPaletVirtual.Columns.Add("id_calibre", GetType(Integer))
        dtPaletVirtual.Columns.Add("Calibre", GetType(String))
        dtPaletVirtual.Columns.Add("id_contenedor", GetType(Integer))
        dtPaletVirtual.Columns.Add("Tipo Caja", GetType(String))
        dtPaletVirtual.Columns.Add("Cajas", GetType(Integer))

        ' 🟢 Nuevas columnas para control exacto de mermas e inventario
        dtPaletVirtual.Columns.Add("Kilos_Brutos", GetType(Decimal))
        dtPaletVirtual.Columns.Add("Tara_Total", GetType(Decimal))
        dtPaletVirtual.Columns.Add("Kilos_Netos", GetType(Decimal))

        dgvDetallePalet.DataSource = dtPaletVirtual

        dgvDetallePalet.Columns("id_producto").Visible = False
        dgvDetallePalet.Columns("id_variedad").Visible = False
        dgvDetallePalet.Columns("id_calibre").Visible = False
        dgvDetallePalet.Columns("id_contenedor").Visible = False

        dgvDetallePalet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetallePalet.AllowUserToAddRows = False
        dgvDetallePalet.ReadOnly = True
    End Sub

    ' =========================================================================
    ' GUARDAR FOLIO CON PROCESAMIENTO FIFO
    ' =========================================================================
    Private Sub btnGuardarFolio_Click(sender As Object, e As EventArgs) Handles btnGuardarFolio.Click
        If dtPaletVirtual.Rows.Count = 0 Then
            MessageBox.Show("El palet está vacío. Agrega al menos un lote.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("¿Generar folio y descontar bines según el pesaje?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Try
            ConexionBD.Abrir()

            Using trx As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                Try
                    ' 1. CABECERA
                    Dim sqlCabecera As String = "INSERT INTO folios_tarjado (numero_folio, tipos_operaciones_id, estados_procesos_tarjados_id) " &
                                               "VALUES (@folio, @idOp, 1); SELECT LAST_INSERT_ID();"

                    Dim cmdCabecera As New MySqlCommand(sqlCabecera, ConexionBD.conexion, trx)
                    cmdCabecera.Parameters.AddWithValue("@folio", txtNumeroFolio.Text)
                    cmdCabecera.Parameters.AddWithValue("@idOp", Convert.ToInt32(cmbTipoOperacion.SelectedValue))

                    Dim idFolioNuevo As Integer = Convert.ToInt32(cmdCabecera.ExecuteScalar())

                    ' 2. RECORRER LA GRILLA (Aquí se toman los bines en base a los kilos manuales)
                    'For Each row As DataRow In dtPaletVirtual.Rows
                    'Dim idCalibre As Integer = Convert.ToInt32(row("id_calibre"))
                    'Dim cantCajas As Integer = Convert.ToInt32(row("Cajas"))
                    'Dim kilosRequeridos As Decimal = Convert.ToDecimal(row("Total_Kilos"))

                    ' Detalle
                    'Dim sqlDetalle As String = "INSERT INTO folios_tarjado_detalles (folios_tarjado_id, productos_id, variedades_id, calibres_id, contenedores_id, cantidad_cajas, kilos_promedio_caja) " &
                    '                              "VALUES (@idFol, @idProd, @idVar, @idCal, @idCont, @cajas, @kilosCaja); SELECT LAST_INSERT_ID();"
                    '
                    ' Dim cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, trx)
                    'cmdDetalle.Parameters.AddWithValue("@idFol", idFolioNuevo)
                    'cmdDetalle.Parameters.AddWithValue("@idProd", Convert.ToInt32(row("id_producto")))
                    'cmdDetalle.Parameters.AddWithValue("@idVar", Convert.ToInt32(row("id_variedad")))
                    'cmdDetalle.Parameters.AddWithValue("@idCal", idCalibre)
                    'cmdDetalle.Parameters.AddWithValue("@idCont", Convert.ToInt32(row("id_contenedor")))
                    'cmdDetalle.Parameters.AddWithValue("@cajas", cantCajas)
                    ' cmdDetalle.Parameters.AddWithValue("@kilosCaja", Convert.ToDecimal(row("Kilos_Caja")))

                    'Dim idDetalleNuevo As Integer = Convert.ToInt32(cmdDetalle.ExecuteScalar())

                    ' 2. RECORRER LA GRILLA 
                    For Each row As DataRow In dtPaletVirtual.Rows
                        Dim idCalibre As Integer = Convert.ToInt32(row("id_calibre"))
                        Dim cantCajas As Integer = Convert.ToInt32(row("Cajas"))

                        ' 🟢 CRÍTICO: Consumimos de los bines solo la fruta neta
                        Dim kilosRequeridos As Decimal = Convert.ToDecimal(row("Kilos_Netos"))
                        Dim kilosBrutosTotales As Decimal = Convert.ToDecimal(row("Kilos_Brutos"))

                        ' Detalle (Asegúrate de que tu tabla soporte guardar ambos valores si lo requieres)
                        Dim sqlDetalle As String = "INSERT INTO folios_tarjado_detalles (folios_tarjado_id, productos_id, variedades_id, calibres_id, contenedores_id, cantidad_cajas, kilos_promedio_caja) " &
                                                   "VALUES (@idFol, @idProd, @idVar, @idCal, @idCont, @cajas, @kilosNetos); SELECT LAST_INSERT_ID();"

                        Dim cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, trx)
                        cmdDetalle.Parameters.AddWithValue("@idFol", idFolioNuevo)
                        cmdDetalle.Parameters.AddWithValue("@idProd", Convert.ToInt32(row("id_producto")))
                        cmdDetalle.Parameters.AddWithValue("@idVar", Convert.ToInt32(row("id_variedad")))
                        cmdDetalle.Parameters.AddWithValue("@idCal", idCalibre)
                        cmdDetalle.Parameters.AddWithValue("@idCont", Convert.ToInt32(row("id_contenedor")))
                        cmdDetalle.Parameters.AddWithValue("@cajas", cantCajas)

                        ' 🟢 Guardamos el promedio neto por caja para la trazabilidad
                        cmdDetalle.Parameters.AddWithValue("@kilosNetos", kilosRequeridos / cantCajas)

                        Dim idDetalleNuevo As Integer = Convert.ToInt32(cmdDetalle.ExecuteScalar())


                        ' Búsqueda FIFO de Bines para el calibre actual
                        Dim idOpCabecera As Integer = Convert.ToInt32(cmbTipoOperacion.SelectedValue)

                        ' Opcional: Podrías añadir "AND estados_contenedores_id = 6" si solo quieres tomar bines previamente pesados
                        Dim sqlBuscarBines As String = "SELECT id_bin, kilos_disponibles, tipos_operaciones_id " &
                                                       "FROM vw_inventario_bines " &
                                                       "WHERE calibres_id = @idCal AND tipos_operaciones_id = @idOp " &
                                                       "ORDER BY fecha ASC"

                        Dim cmdBuscar As New MySqlCommand(sqlBuscarBines, ConexionBD.conexion, trx)
                        cmdBuscar.Parameters.AddWithValue("@idCal", idCalibre)
                        cmdBuscar.Parameters.AddWithValue("@idOp", idOpCabecera)

                        Dim da As New MySqlDataAdapter(cmdBuscar)
                        Dim dtBinesDisponibles As New DataTable()
                        da.Fill(dtBinesDisponibles)

                        Dim kilosFaltantes As Decimal = kilosRequeridos
                        Dim idBinMayoritario As Integer = 0
                        Dim mayorKilosExtraidos As Decimal = 0

                        For Each binRow As DataRow In dtBinesDisponibles.Rows
                            If kilosFaltantes <= 0 Then Exit For

                            Dim idBinActual As Integer = Convert.ToInt32(binRow("id_bin"))
                            Dim origenBin As Integer = Convert.ToInt32(binRow("tipos_operaciones_id"))
                            Dim kilosEnBin As Decimal = Convert.ToDecimal(binRow("kilos_disponibles"))
                            Dim kilosAExtraer As Decimal = 0

                            If kilosEnBin >= kilosFaltantes Then
                                kilosAExtraer = kilosFaltantes
                                kilosFaltantes = 0
                            Else
                                kilosAExtraer = kilosEnBin
                                kilosFaltantes -= kilosEnBin
                            End If

                            If kilosAExtraer > mayorKilosExtraidos Then
                                mayorKilosExtraidos = kilosAExtraer
                                idBinMayoritario = idBinActual
                            End If

                            ' Consumo
                            Dim sqlConsumo As String = "INSERT INTO folios_consumo_bins (folios_tarjado_detalles_id, tipos_origen_id, id_bin, kilos_usados) " &
                                                       "VALUES (@idDet, @origen, @bin, @usados)"
                            Dim cmdConsumo As New MySqlCommand(sqlConsumo, ConexionBD.conexion, trx)
                            cmdConsumo.Parameters.AddWithValue("@idDet", idDetalleNuevo)
                            cmdConsumo.Parameters.AddWithValue("@origen", origenBin)
                            cmdConsumo.Parameters.AddWithValue("@bin", idBinActual)
                            cmdConsumo.Parameters.AddWithValue("@usados", kilosAExtraer)
                            cmdConsumo.ExecuteNonQuery()
                        Next

                        If kilosFaltantes > 0 Then
                            Throw New Exception("Stock insuficiente. Faltaron " & kilosFaltantes.ToString("N2") & " Kg del Calibre: " & row("Calibre").ToString())
                        End If

                        ' 4. CAJAS
                        For i As Integer = 1 To cantCajas
                            Dim sqlCaja As String = "INSERT INTO folios_cajas (folios_tarjado_detalles_id, correlativo_caja, tipos_origen_id, id_bin_mayoritario) " &
                                                    "VALUES (@idDet, @corr, 1, @binM)"
                            Dim cmdCaja As New MySqlCommand(sqlCaja, ConexionBD.conexion, trx)
                            cmdCaja.Parameters.AddWithValue("@idDet", idDetalleNuevo)
                            cmdCaja.Parameters.AddWithValue("@corr", i)
                            cmdCaja.Parameters.AddWithValue("@binM", idBinMayoritario)
                            cmdCaja.ExecuteNonQuery()
                        Next
                    Next

                    trx.Commit()
                    MessageBox.Show("Folio generado y bines descontados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dtPaletVirtual.Rows.Clear()
                    GenerarNuevoFolio()
                    MostrarBinesDisponibles() ' Refrescar grilla de bines

                Catch ex As Exception
                    trx.Rollback()
                    Throw New Exception(ex.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error en la transacción: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' =========================================================================
    ' UTILIDADES
    ' =========================================================================
    Private Sub LlenarCombo(combo As ComboBox, sql As String, valueM As String, displayM As String)
        Dim dt As DataTable = ObtenerDatos(sql)
        combo.DataSource = Nothing
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            combo.DataSource = dt
            combo.ValueMember = valueM
            combo.DisplayMember = displayM
        End If
    End Sub

    Private Sub GenerarNuevoFolio()
        Dim dt As DataTable = ObtenerDatos("SELECT IFNULL(MAX(id), 0) + 1 AS SiguienteFolio FROM folios_tarjado")
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            txtNumeroFolio.Text = "FOL-" & Convert.ToInt32(dt.Rows(0)("SiguienteFolio")).ToString("D5")
        End If
    End Sub

    Private Sub MostrarBinesDisponibles()
        If cmbTipoOperacion.SelectedValue Is Nothing OrElse cmbCalibre.SelectedValue Is Nothing Then
            dgvBinesDisponibles.DataSource = Nothing
            Return
        End If

        Dim idOperacion, idCalibre As Integer

        If Integer.TryParse(cmbTipoOperacion.SelectedValue.ToString(), idOperacion) AndAlso
           Integer.TryParse(cmbCalibre.SelectedValue.ToString(), idCalibre) Then

            Dim sql As String = "SELECT id_bin AS 'N° Bin', " &
                                "kilos_disponibles AS 'Kilos Disp.', " &
                                "fecha AS 'Fecha Antigüedad' " &
                                "FROM vw_inventario_bines " &
                                "WHERE calibres_id = " & idCalibre & " " &
                                "AND tipos_operaciones_id = " & idOperacion & " " &
                                "ORDER BY fecha ASC"

            Dim dtBines As DataTable = ObtenerDatos(sql)
            dgvBinesDisponibles.DataSource = dtBines

            dgvBinesDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvBinesDisponibles.ReadOnly = True
            dgvBinesDisponibles.AllowUserToAddRows = False
        End If
    End Sub

    Private Function ObtenerDatos(sql As String) As DataTable
        Return ConexionBD.ObtenerDatos(sql)
    End Function

    ' Función para simular el FIFO y obtener los bines requeridos
    Private Function SimularConsumoFIFO(idCalibre As Integer, idOperacion As Integer, kilosRequeridos As Decimal) As DataTable
        Dim dtBinesAUtilizar As New DataTable()
        dtBinesAUtilizar.Columns.Add("id_bin", GetType(Integer))
        dtBinesAUtilizar.Columns.Add("kilos_sistema", GetType(Decimal))
        dtBinesAUtilizar.Columns.Add("kilos_a_usar", GetType(Decimal))
        dtBinesAUtilizar.Columns.Add("estado", GetType(String)) ' Para saber si ya se pesó

        ' Buscamos los bines disponibles en la base de datos
        Dim sqlBuscar As String = "SELECT id_bin, kilos_disponibles " &
                                  "FROM vw_inventario_bines " &
                                  "WHERE calibres_id = @idCal AND tipos_operaciones_id = @idOp " &
                                  "ORDER BY fecha ASC"

        Dim cmdBuscar As New MySqlCommand(sqlBuscar, ConexionBD.conexion)
        cmdBuscar.Parameters.AddWithValue("@idCal", idCalibre)
        cmdBuscar.Parameters.AddWithValue("@idOp", idOperacion)

        Dim da As New MySqlDataAdapter(cmdBuscar)
        Dim dtDisponibles As New DataTable()
        da.Fill(dtDisponibles)

        Dim kilosFaltantes As Decimal = kilosRequeridos

        ' Simulamos el consumo
        For Each row As DataRow In dtDisponibles.Rows
            If kilosFaltantes <= 0 Then Exit For

            Dim kilosEnBin As Decimal = Convert.ToDecimal(row("kilos_disponibles"))
            Dim kilosAExtraer As Decimal = 0

            If kilosEnBin >= kilosFaltantes Then
                kilosAExtraer = kilosFaltantes
                kilosFaltantes = 0
            Else
                kilosAExtraer = kilosEnBin
                kilosFaltantes -= kilosEnBin
            End If

            ' Agregamos el bin a nuestra lista de "Bines Proyectados"
            dtBinesAUtilizar.Rows.Add(row("id_bin"), kilosEnBin, kilosAExtraer, "Pendiente Pesaje")
        Next

        If kilosFaltantes > 0 Then
            Throw New Exception($"Atención: Faltan {kilosFaltantes.ToString("N2")} Kg en stock para el calibre seleccionado.")
        End If

        Return dtBinesAUtilizar
    End Function

    Private Sub dgvDetallePalet_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetallePalet.CellContentClick

    End Sub
End Class