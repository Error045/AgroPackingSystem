Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ucTarjado

    Private dtPaletVirtual As New DataTable()
    ' 1. CREAMOS EL "GRITO" (EVENTO)
    ' Le pasamos la tabla con los bines que el lector de códigos va a necesitar
    Public Event IrAPesajeBarcode(dtBinesProyectados As DataTable)

    Private Sub ucTarjado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigurarGridVirtual()

            ' --- CORRECCIÓN 1: SE DESCOMENTÓ LA OPERACIÓN PARA QUE EL FILTRO DE STOCK DE BINES FUNCIONE ---
            LlenarCombo(cmbTipoOperacion, "SELECT id, nombre FROM tipos_operaciones WHERE estado = 1", "id", "nombre")

            LlenarCombo(cmbProducto, "SELECT id, nombre FROM productos WHERE estado = 1", "id", "nombre")
            CargarComboPalets()
            LlenarCombo(cmbCajaContenedor, "SELECT id, nombre FROM tipos_contenedores WHERE estado = 1", "id", "nombre")
            GenerarNuevoFolio()
        Catch ex As Exception
            MessageBox.Show("Error al iniciar: " & ex.Message)
        End Try
    End Sub

    ' =========================================================================
    ' EVENTOS CASCADA Y REFRESCO EN VIVO (BINES DISPONIBLES)
    ' =========================================================================

    ' --- CORRECCIÓN 2: EJECUTAR BÚSQUEDA CUANDO CAMBIE LA OPERACIÓN ---
    ' Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
    ' MostrarBinesDisponibles()
    ' End Sub
    Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
        ' Validamos que haya una selección válida y numérica para evitar errores al inicializar el formulario
        If cmbTipoOperacion.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbTipoOperacion.SelectedValue) Then
            Dim idOp As Integer = Convert.ToInt32(cmbTipoOperacion.SelectedValue)

            ' Evaluamos si es igual a 2 (Servicio)
            Dim esServicio As Boolean = (idOp = 2)

            ' Mostramos u ocultamos los controles según corresponda
            lblPersona.Visible = esServicio
            cmbPersona.Visible = esServicio
            lblRecepcion.Visible = esServicio
            cmbRecepcion.Visible = esServicio

            ' [Opcional] Si pasa a ser servicio, podrías aprovechar de cargar los clientes aquí
            If esServicio Then
                CargarComboboxClientes()
            End If
        End If
    End Sub

    Private Sub cmbPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPersona.SelectedIndexChanged
        ' Nos aseguramos de que realmente el usuario seleccionó un ítem válido
        If cmbPersona.SelectedIndex > -1 AndAlso cmbPersona.SelectedValue IsNot Nothing Then

            ' Evitamos procesar si el valor todavía es un DataRowView (pasa durante el DataSource)
            If Not TypeOf cmbPersona.SelectedValue Is DataRowView Then

                Dim idPersona As Integer
                ' Convertimos de forma segura a entero
                If Integer.TryParse(cmbPersona.SelectedValue.ToString(), idPersona) Then
                    CargarComboboxRecepciones(idPersona)
                End If

            End If
        End If
    End Sub

    Private Sub CargarComboboxClientes()
        Try
            ' Buscamos clientes únicos que tengan stock disponible en operaciones de Servicio
            ' Nota: Ajusta "nombre_cliente" al nombre real de la columna en tu vista o tabla
            Dim sql As String = "SELECT DISTINCT personas_id, p.nombre As nombre_cliente,a.recepciones_id " &
                                "From vw_inventario_bines a " &
                                "INNER Join personas p ON a.personas_id = p.id " &
                                "WHERE tipos_operaciones_id = 2 And kilos_disponibles > 0 " &
                                "ORDER BY nombre_cliente ASC;"

            Dim dtClientes As New DataTable()

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dtClientes)
            End Using

            ' Desvinculamos el evento temporalmente para evitar que se dispare mientras se llena
            RemoveHandler cmbPersona.SelectedIndexChanged, AddressOf cmbPersona_SelectedIndexChanged

            cmbPersona.DataSource = dtClientes
            cmbPersona.DisplayMember = "nombre_cliente" ' Lo que ve el usuario
            cmbPersona.ValueMember = "personas_id"      ' El ID interno

            ' Añadimos el manejador de eventos nuevamente
            AddHandler cmbPersona.SelectedIndexChanged, AddressOf cmbPersona_SelectedIndexChanged

            ' Limpiamos la selección por defecto
            cmbPersona.SelectedIndex = -1

            ' Como cambió el cliente (a nada), limpiamos el combobox de recepciones
            cmbRecepcion.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarComboboxRecepciones(idPersona As Integer)
        Try
            ' Buscamos recepciones únicas de ese cliente específico que aún tengan stock
            ' Nota: Ajusta "numero_guia" o la columna que uses para mostrar el texto de la recepción
            Dim sql As String = "SELECT DISTINCT recepciones_id " & ' ,numero_guia ver la posibilidad de agregar campo guia para mostrar en el combo
                                "FROM vw_inventario_bines " &
                                "WHERE tipos_operaciones_id = 2 " &
                                "AND personas_id = @idPersona " &
                                "AND kilos_disponibles > 0 " &
                                "ORDER BY recepciones_id DESC" ' Orden descendente para ver las más nuevas primero

            Dim dtRecepciones As New DataTable()

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPersona", idPersona)
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dtRecepciones)
            End Using

            cmbRecepcion.DataSource = dtRecepciones
            cmbRecepcion.DisplayMember = "recepciones_id" 'numero_guia  Lo que ve el usuario (ej: "Guía 1234" o el ID)
            cmbRecepcion.ValueMember = "recepciones_id" ' El ID interno

            ' Limpiamos la selección por defecto para obligar al usuario a elegir una explícitamente
            cmbRecepcion.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar recepciones: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' 1. Si cambia el producto -> Cargar sus variedades
    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        Dim idProd As Integer
        If cmbProducto.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbProducto.SelectedValue.ToString(), idProd) Then
            LlenarCombo(cmbVariedad, "SELECT id, nombre FROM variedades WHERE producto_id = " & idProd, "id", "nombre")
        End If
    End Sub

    ' 2. Si cambia la variedad -> Cargar sus calibres
    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        Dim idVar As Integer
        If cmbVariedad.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbVariedad.SelectedValue.ToString(), idVar) Then
            LlenarCombo(cmbCalibre, "SELECT id, nombre FROM calibres WHERE variedades_id = " & idVar, "id", "nombre")
        End If
    End Sub

    ' --- CORRECCIÓN 3: EJECUTAR BÚSQUEDA EN VIVO CUANDO SE SELECCIONE UN CALIBRE ---
    Private Sub cmbCalibre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalibre.SelectedIndexChanged
        MostrarBinesDisponibles()
    End Sub

    ' 3. Si cambia el contenedor -> Traer capacidad
    Private Sub cmbCajaContenedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajaContenedor.SelectedIndexChanged
        Dim idContenedor As Integer
        If cmbCajaContenedor.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbCajaContenedor.SelectedValue.ToString(), idContenedor) Then
            Dim dt As DataTable = ObtenerDatos("SELECT capacidad FROM tipos_contenedores WHERE id = " & idContenedor)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                txtKilosCaja.Text = Convert.ToDecimal(dt.Rows(0)("capacidad")).ToString("N2")
            Else
                txtKilosCaja.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub CargarComboPalets()
        Try
            ' Consulta para obtener los palets. 
            ' Ajusta "nombre" por la columna real donde guardas la descripción (ej: 'Palet Madera', 'Palet Plástico').
            ' Si tienes una columna para diferenciar cajas de palets úsala en el WHERE, o puedes filtrar por los IDs específicos.
            Dim query As String = "SELECT id, nombre, tara FROM tipos_contenedores WHERE id = 4" ' <--- Ajusta el filtro según necesites

            Dim cmd As New MySqlCommand(query, ConexionBD.conexion)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            ' Usamos la conexión (asegurándonos de abrirla y cerrarla si tu patrón lo requiere aquí)
            ConexionBD.Abrir()
            da.Fill(dt)
            ' ConexionBD.Cerrar() ' Descomenta si tu método abrir/cerrar lo requiere de inmediato

            If dt.Rows.Count > 0 Then
                cmbPalet.DataSource = dt
                cmbPalet.DisplayMember = "nombre" ' Lo que ve el usuario
                cmbPalet.ValueMember = "id"       ' El valor interno que usamos en el código
                cmbPalet.SelectedIndex = -1       ' Para que aparezca vacío por defecto y obligue a seleccionar
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar los palets: " & ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' =========================================================================
    ' MANEJO DE LA GRILLA VIRTUAL (PALET)
    ' =========================================================================
    Private Sub btnAgregarLote_Click(sender As Object, e As EventArgs) Handles btnAgregarLote.Click
        Try
            Dim cantidadCajas As Integer = Convert.ToInt32(nudCantidadCajas.Value)
            Dim kilosPorCaja As Decimal = Convert.ToDecimal(txtKilosCaja.Text) ' Capacidad neta de la caja

            If cantidadCajas <= 0 Then
                MessageBox.Show("Debes ingresar al menos 1 caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If kilosPorCaja <= 0 Then
                MessageBox.Show("La caja seleccionada no tiene una capacidad válida configurada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cmbCajaContenedor.SelectedValue Is Nothing Then
                MessageBox.Show("Seleccione un tipo de caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' --- 1. BUSCAR LA TARA DE LA CAJA SELECCIONADA EN LA BD ---
            Dim idCaja As Integer = Convert.ToInt32(cmbCajaContenedor.SelectedValue)
            Dim taraCajaUnitaria As Decimal = 0

            Dim sqlCaja As String = "SELECT tara FROM tipos_contenedores WHERE id = @id"
            ConexionBD.Abrir()
            Using cmd As New MySqlCommand(sqlCaja, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@id", idCaja)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                    taraCajaUnitaria = Convert.ToDecimal(res)
                End If
            End Using

            ' --- 2. CÁLCULOS MATEMÁTICOS DEL LOTE ---
            Dim totalTaraLote As Decimal = cantidadCajas * taraCajaUnitaria
            Dim totalNetoLote As Decimal = cantidadCajas * kilosPorCaja
            Dim totalBrutoLote As Decimal = totalNetoLote + totalTaraLote
            'Dim totalKilosLote As Decimal = totalNetoLote ' Para mantener compatibilidad con tu lógica actual

            ' --- 3. AGREGAR FILA CON LA NUEVA ESTRUCTURA EQUIVALENTE ---
            dtPaletVirtual.Rows.Add(
            cmbProducto.SelectedValue, cmbProducto.Text,
            cmbVariedad.SelectedValue, cmbVariedad.Text,
            cmbCalibre.SelectedValue, cmbCalibre.Text,
            idCaja, cmbCajaContenedor.Text,
            cantidadCajas,
            kilosPorCaja,
            totalTaraLote,  ' Mapea a Tara_Total
            totalNetoLote,  ' Mapea a Kilos_Netos
            totalBrutoLote,  ' Mapea a Kilos_Brutos
            totalNetoLote   ' 🟢 Mapea a Total_Kilos (Mantiene la compatibilidad)
        )

            ' Limpieza de interfaz para el siguiente lote
            nudCantidadCajas.Value = 0

        Catch ex As Exception
            MessageBox.Show("Error al agregar lote: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarGridVirtual()
        dtPaletVirtual.Columns.Clear()

        dtPaletVirtual.Columns.Add("id_producto", GetType(Integer))
        dtPaletVirtual.Columns.Add("Producto", GetType(String))
        dtPaletVirtual.Columns.Add("id_variedad", GetType(Integer))
        dtPaletVirtual.Columns.Add("Variedad", GetType(String))
        dtPaletVirtual.Columns.Add("id_calibre", GetType(Integer))
        dtPaletVirtual.Columns.Add("Calibre", GetType(String)) ' 🟢 Corregido: Quitamos "(Categoría)" para evitar error en el row("Calibre")
        dtPaletVirtual.Columns.Add("id_contenedor", GetType(Integer))
        dtPaletVirtual.Columns.Add("Tipo Caja", GetType(String))
        dtPaletVirtual.Columns.Add("Cajas", GetType(Integer))
        dtPaletVirtual.Columns.Add("Kilos_Caja", GetType(Decimal))

        ' 🟢 NUEVAS COLUMNAS: Esenciales para los cálculos de totales del Palet
        dtPaletVirtual.Columns.Add("Tara_Total", GetType(Decimal))
        dtPaletVirtual.Columns.Add("Kilos_Netos", GetType(Decimal))
        dtPaletVirtual.Columns.Add("Kilos_Brutos", GetType(Decimal))

        ' 🟢 RE-AGREGADA: Para mantener compatibilidad con tu lógica FIFO y otras consultas
        dtPaletVirtual.Columns.Add("Total_Kilos", GetType(Decimal))

        dgvDetallePalet.DataSource = dtPaletVirtual

        ' Ocultamos los IDs internos
        dgvDetallePalet.Columns("id_producto").Visible = False
        dgvDetallePalet.Columns("id_variedad").Visible = False
        dgvDetallePalet.Columns("id_calibre").Visible = False
        dgvDetallePalet.Columns("id_contenedor").Visible = False

        dgvDetallePalet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetallePalet.AllowUserToAddRows = False
        dgvDetallePalet.ReadOnly = True
    End Sub

    ' =========================================================================
    ' GUARDAR FOLIO CON PROCESAMIENTO FIFO UNIFICADO
    ' =========================================================================
    Private Sub btnGuardarFolio_Click(sender As Object, e As EventArgs) Handles btnGuardarFolio.Click
        If dtPaletVirtual.Rows.Count = 0 Then
            MessageBox.Show("El palet está vacío. Agrega al menos un lote.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbPalet.SelectedValue Is Nothing Then
            MessageBox.Show("Por favor, seleccione el tipo de Palet (Base).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbCajaContenedor.SelectedValue Is Nothing Then
            MessageBox.Show("Por favor, seleccione el tipo de Caja de empaque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("¿Generar folio de tarjado y descontar bines?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.No Then Return


        Try

            ConexionBD.Abrir()

            Using trx As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                Try

                    ' --- 2. OBTENER LA TARA DEL PALET SELECCIONADO (cmbPalet) ---
                    Dim idTipoPalet As Integer = Convert.ToInt32(cmbPalet.SelectedValue)
                    Dim taraPaletEstructural As Decimal = 0

                    Dim sqlBuscarTaraPalet As String = "SELECT tara FROM tipos_contenedores WHERE id = @idPalet"
                    Using cmdTara = New MySqlCommand(sqlBuscarTaraPalet, ConexionBD.conexion, trx)
                        cmdTara.Parameters.AddWithValue("@idPalet", idTipoPalet)
                        Dim result = cmdTara.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            taraPaletEstructural = Convert.ToDecimal(result)
                        Else
                            Throw New Exception("No se pudo obtener la tara para el tipo de palet seleccionado.")
                        End If
                    End Using

                    ' --- 3. CÁLCULO DE TOTALES EN BASE A LA GRILLA VIRTUAL ---
                    ' Los kilos brutos y taras de las cajas ya vienen calculados en la grilla por fila
                    Dim totalBrutoCajas As Decimal = Convert.ToDecimal(dtPaletVirtual.Compute("SUM(Kilos_Brutos)", ""))
                    Dim totalTaraCajas As Decimal = Convert.ToDecimal(dtPaletVirtual.Compute("SUM(Tara_Total)", ""))
                    Dim totalNetoFruta As Decimal = Convert.ToDecimal(dtPaletVirtual.Compute("SUM(Kilos_Netos)", ""))

                    ' El peso bruto final del folio es: (Bruto acumulado de cajas) + (Peso muerto del palet base)
                    Dim pesoBrutoFinal As Decimal = totalBrutoCajas + taraPaletEstructural
                    ' La tara total registrada en el folio incluye la de todas las cajas más la del palet
                    Dim taraTotalFolio As Decimal = totalTaraCajas + taraPaletEstructural
                    Dim pesoNetoFinal As Decimal = totalNetoFruta

                    ' --- 4. REGISTRO DE CABECERA EN FOLIOS_TARJADO ---
                    ' Guardamos el idTipoPalet extraído de cmbPalet en la columna tipos_contenedores_id
                    Dim sqlCabecera As String = "INSERT INTO folios_tarjado (numero_folio, tipos_operaciones_id, estados_procesos_tarjados_id, tipos_contenedores_id, tara_palet, peso_bruto, peso_neto) " &
                                            "VALUES (@folio, @idOp, 1, @idTipoPalet, @taraPalet, @bruto, @neto); SELECT LAST_INSERT_ID();"



                    Dim idFolioNuevo As Integer = 0
                    Using cmdCabecera As New MySqlCommand(sqlCabecera, ConexionBD.conexion, trx)
                        cmdCabecera.Parameters.AddWithValue("@folio", txtNumeroFolio.Text)
                        cmdCabecera.Parameters.AddWithValue("@idOp", Convert.ToInt32(cmbTipoOperacion.SelectedValue))
                        cmdCabecera.Parameters.AddWithValue("@idTipoPalet", idTipoPalet)
                        cmdCabecera.Parameters.AddWithValue("@taraPalet", taraPaletEstructural)
                        cmdCabecera.Parameters.AddWithValue("@bruto", pesoBrutoFinal)
                        cmdCabecera.Parameters.AddWithValue("@neto", pesoNetoFinal)

                        idFolioNuevo = Convert.ToInt32(cmdCabecera.ExecuteScalar())
                    End Using

                    ' 2. RECORRER LA GRILLA (Aquí se toman los bines en base a los kilos netos)
                    For Each row As DataRow In dtPaletVirtual.Rows
                        Dim idCalibre As Integer = Convert.ToInt32(row("id_calibre"))
                        Dim cantCajas As Integer = Convert.ToInt32(row("Cajas"))

                        ' Consumimos la fruta neta requerida
                        Dim kilosRequeridos As Decimal = Convert.ToDecimal(row("Total_Kilos"))      '"Kilos_Netos"
                        Dim idOpCabecera As Integer = Convert.ToInt32(cmbTipoOperacion.SelectedValue)

                        ' --- A. GUARDAR DETALLE DEL FOLIO ---
                        Dim sqlDetalle As String = "INSERT INTO folios_tarjado_detalles (folios_tarjado_id, productos_id, variedades_id, calibres_id, contenedores_id, cantidad_cajas, kilos_promedio_caja) " &
                               "VALUES (@idFol, @idProd, @idVar, @idCal, @idCont, @cajas, @kilosNetos); SELECT LAST_INSERT_ID();"

                        Dim cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, trx)
                        cmdDetalle.Parameters.AddWithValue("@idFol", idFolioNuevo)
                        cmdDetalle.Parameters.AddWithValue("@idProd", Convert.ToInt32(row("id_producto")))
                        cmdDetalle.Parameters.AddWithValue("@idVar", Convert.ToInt32(row("id_variedad")))
                        cmdDetalle.Parameters.AddWithValue("@idCal", idCalibre)
                        cmdDetalle.Parameters.AddWithValue("@idCont", Convert.ToInt32(row("id_contenedor")))
                        cmdDetalle.Parameters.AddWithValue("@cajas", cantCajas)
                        cmdDetalle.Parameters.AddWithValue("@kilosNetos", kilosRequeridos / cantCajas)

                        Dim idDetalleNuevo As Integer = Convert.ToInt32(cmdDetalle.ExecuteScalar())

                        ' --- B. BÚSQUEDA FIFO (Adaptado al nuevo modelo, sin tipos_origen_id) ---
                        Dim sqlBuscarBines As String = "SELECT id_bin, kilos_disponibles " &
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

                            ' --- C. CONSUMO Y ACTUALIZACIÓN DEL NUEVO MODELO ---

                            ' 1. Guardar en folios_consumo_bins (Reemplazando tipos_origen_id por tipos_operaciones_id)
                            Dim sqlConsumo As String = "INSERT INTO folios_consumo_bins (folios_tarjado_detalles_id, tipos_origen_id, id_bin, kilos_usados) " &    ' -----CAMBIAR en la base dedatos de tipos_origen_id a tipos_operaciones_id
                                   "VALUES (@idDet, @idOp, @bin, @usados)"
                            Using cmdConsumo As New MySqlCommand(sqlConsumo, ConexionBD.conexion, trx)
                                cmdConsumo.Parameters.AddWithValue("@idDet", idDetalleNuevo)
                                cmdConsumo.Parameters.AddWithValue("@idOp", idOpCabecera)
                                cmdConsumo.Parameters.AddWithValue("@bin", idBinActual)
                                cmdConsumo.Parameters.AddWithValue("@usados", kilosAExtraer)
                                cmdConsumo.ExecuteNonQuery()
                            End Using

                            ' 2. 🟢 NUEVO: Descontar los kilos en la tabla principal de contenedores
                            Dim sqlUpdContenedor As String = "UPDATE contenedores SET " &
                          "kilos_netos = kilos_netos - @usados, " &
                          "kilos_brutos = kilos_brutos - @usados, " &
                          "tipos_ubicaciones_id = 4, " &
                          "estados_contenedores_id = CASE WHEN kilos_netos <= 0 THEN 8 ELSE 7 END " &
                          "WHERE id = @bin"
                            Using cmdUpdCont As New MySqlCommand(sqlUpdContenedor, ConexionBD.conexion, trx)
                                cmdUpdCont.Parameters.AddWithValue("@usados", kilosAExtraer)
                                cmdUpdCont.Parameters.AddWithValue("@bin", idBinActual)
                                cmdUpdCont.ExecuteNonQuery()
                            End Using

                            ' 3. 🟢 NUEVO: Registrar el movimiento en contenedores_historial
                            ' Nota: Uso el ID de movimiento 4  (bins Termina,para pasar a ser parte de un pallet). 
                            ' El INSERT...SELECT copia el estado actual del contenedor sin tener que hacer múltiples consultas.
                            Dim sqlHistorial As String = "INSERT INTO contenedores_historial (contenedores_id, tipos_contenedores_id, tipos_movimientos_id, tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, fecha_movimiento) " &
                                     "SELECT id, tipos_contenedores_id, 4, tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, NOW() FROM contenedores WHERE id = @bin"
                            Using cmdHist As New MySqlCommand(sqlHistorial, ConexionBD.conexion, trx)
                                cmdHist.Parameters.AddWithValue("@bin", idBinActual)
                                cmdHist.ExecuteNonQuery()
                            End Using

                        Next

                        If kilosFaltantes > 0 Then
                            Throw New Exception("Stock insuficiente. Faltaron " & kilosFaltantes.ToString("N2") & " Kg del Calibre: " & row("Calibre").ToString())
                        End If

                        ' --- D. CREACIÓN DE CAJAS (Reemplazando tipos_origen_id por tipos_operaciones_id) ---
                        For i As Integer = 1 To cantCajas
                            Dim sqlCaja As String = "INSERT INTO folios_cajas (folios_tarjado_detalles_id, correlativo_caja, tipos_origen_id, id_bin_mayoritario) " &   '---------------TIPOS_ORIGEN_ID REEMPLAZADO COMO EJEMPLO DESPUÉS SE DEBE CAMBIAR A  TIPOS_OPERACIONES_ID y en la base dedatos también-----------------
                                "VALUES (@idDet, @corr, @idOp, @binM)"
                            Using cmdCaja As New MySqlCommand(sqlCaja, ConexionBD.conexion, trx)
                                cmdCaja.Parameters.AddWithValue("@idDet", idDetalleNuevo)
                                cmdCaja.Parameters.AddWithValue("@corr", i)
                                cmdCaja.Parameters.AddWithValue("@idOp", idOpCabecera)
                                cmdCaja.Parameters.AddWithValue("@binM", idBinMayoritario)
                                cmdCaja.ExecuteNonQuery()
                            End Using
                        Next
                    Next




                    trx.Commit()
                    MessageBox.Show("Folio generado correctamente. Enviado a pesaje.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtPaletVirtual.Rows.Clear()
                    dgvBinesDisponibles.DataSource = Nothing ' Limpiar grilla de bines después de guardar

                Catch ex As Exception
                    trx.Rollback()
                    MessageBox.Show("Operación cancelada. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub
    '.............................................
    Private Sub LlenarCombo(combo As ComboBox, sql As String, valueM As String, displayM As String)
        Dim dt As DataTable = ObtenerDatos(sql)
        combo.DataSource = Nothing ' Limpiar antes de llenar
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



    ' =========================================================================
    ' SECCIÓN: MOSTRAR BINES DISPONIBLES EN LA SELECCIÓN
    ' =========================================================================
    Private Sub MostrarBinesDisponibles()
        ' Validamos que ambos combobox clave tengan datos
        If cmbTipoOperacion.SelectedValue Is Nothing OrElse cmbCalibre.SelectedValue Is Nothing Then
            dgvBinesDisponibles.DataSource = Nothing
            Return
        End If

        Dim idOperacion, idCalibre As Integer

        If Integer.TryParse(cmbTipoOperacion.SelectedValue.ToString(), idOperacion) AndAlso
           Integer.TryParse(cmbCalibre.SelectedValue.ToString(), idCalibre) Then

            ' Conservamos la columna 'fecha' tal como indicaste que se llama en tu vista
            Dim sql As String = "SELECT id_bin AS 'N° Bin', " &
                                "kilos_disponibles AS 'Kilos Disp.', " &
                                "fecha AS 'Fecha Antigüedad' " &
                                "FROM vw_inventario_bines " &
                                "WHERE calibres_id = " & idCalibre & " " &
                                "AND tipos_operaciones_id = " & idOperacion & " " &
                                "ORDER BY fecha ASC"

            Dim dtBines As DataTable = ObtenerDatos(sql)
            dgvBinesDisponibles.DataSource = dtBines

            ' Formato visual
            dgvBinesDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvBinesDisponibles.ReadOnly = True
            dgvBinesDisponibles.AllowUserToAddRows = False
        End If
    End Sub

    ' Redirección opcional en caso de usar el módulo localmente
    Private Function ObtenerDatos(sql As String) As DataTable
        Return ConexionBD.ObtenerDatos(sql)
    End Function

    ' =========================================================================
    ' ACCIÓN: ENVIAR ÓRDEN DE EXTRACCIÓN CON INVENTARIO EN MEMORIA
    ' =========================================================================
    Private Sub btnUpdateBines_Click(sender As Object, e As EventArgs) Handles btnUpdateBines.Click
        If dtPaletVirtual.Rows.Count = 0 Then
            MessageBox.Show("Agrega al menos un lote al palet antes de generar las órdenes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("¿Deseas generar las órdenes de extracción para el personal de grúa?", "Confirmar Logística", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Dim idOperacion As Integer = Convert.ToInt32(cmbTipoOperacion.SelectedValue)

            Dim idPersona As Integer = 0
            Dim idRecepcion As Integer = 0

            If idOperacion = 2 Then
                If cmbPersona.SelectedValue Is Nothing OrElse cmbRecepcion.SelectedValue Is Nothing Then
                    MessageBox.Show("Para operaciones de Servicio, debe seleccionar obligatoriamente el Cliente y la Recepción.", "Validación Logística", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                idPersona = Convert.ToInt32(cmbPersona.SelectedValue)
                idRecepcion = Convert.ToInt32(cmbRecepcion.SelectedValue)
            End If

            If MessageBox.Show("¿Deseas generar las órdenes de extracción para el personal de grúa?", "Confirmar Logística", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

            ' PASO 1: CARGAR EL STOCK COMPLETO UNA SOLA VEZ
            Dim sqlStock As String = "SELECT id_bin, calibres_id, kilos_disponibles " &
                                     "FROM vw_inventario_bines " &
                                     "WHERE tipos_operaciones_id = @idOp "


            ' PASO 2: CARGAR EL STOCK EN MEMORIA PASANDO LOS PARÁMETROS CONDICIONALES
            If idOperacion = 2 Then
                sqlStock &= "AND personas_id = @idPersona AND recepciones_id = @idRecepcion "
            End If

            sqlStock &= "ORDER BY fecha ASC"

            Dim dtInventarioLocal As New DataTable()
            Using cmdStock As New MySqlCommand(sqlStock, ConexionBD.conexion)
                cmdStock.Parameters.AddWithValue("@idOp", idOperacion)

                ' Solo inyectamos estos parámetros a MySQL si es Servicio
                If idOperacion = 2 Then
                    cmdStock.Parameters.AddWithValue("@idPersona", idPersona)
                    cmdStock.Parameters.AddWithValue("@idRecepcion", idRecepcion)
                End If

                Dim da As New MySqlDataAdapter(cmdStock)
                da.Fill(dtInventarioLocal)
            End Using

            ' 🟢 PASO 3: RECORRER LA GRILLA (Se mantiene idéntico, consumiendo de la memoria blindada)
            For Each row As DataRow In dtPaletVirtual.Rows
                Dim idCalibre As Integer = Convert.ToInt32(row("id_calibre"))
                Dim kilosRequeridos As Decimal = Convert.ToDecimal(row("Total_Kilos"))

                ' Enviamos el inventario local para que cada fila descuente de la memoria
                CrearOrdenParaOperador(idCalibre, idOperacion, kilosRequeridos, dtInventarioLocal)
            Next

            ' PASO 3: Limpiar la pantalla local
            dtPaletVirtual.Rows.Clear()
            dgvBinesDisponibles.DataSource = Nothing
            MessageBox.Show("Todas las órdenes fueron procesadas y distribuidas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de Stock / Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' 🟢 FIRMA CORREGIDA: Ahora recibe exactamente Calibre, Kilos y la Tabla de Memoria
    Private Function SimularConsumoFIFO(idCalibre As Integer, kilosRequeridos As Decimal, ByRef dtInventarioLocal As DataTable) As DataTable
        Dim dtBinesAUtilizar As New DataTable()
        dtBinesAUtilizar.Columns.Add("id_bin", GetType(Integer))
        dtBinesAUtilizar.Columns.Add("kilos_sistema", GetType(Decimal))

        Dim kilosFaltantes As Decimal = kilosRequeridos

        ' Filtramos el inventario en memoria buscando solo el calibre deseado y bines que aún tengan kilos
        Dim rowsAsignables = dtInventarioLocal.Select("calibres_id = " & idCalibre & " AND kilos_disponibles > 0")

        For Each row As DataRow In rowsAsignables
            If kilosFaltantes <= 0 Then Exit For

            Dim idBin As Integer = Convert.ToInt32(row("id_bin"))
            Dim kilosDisponiblesEnMemoria As Decimal = Convert.ToDecimal(row("kilos_disponibles"))
            Dim kilosAAsignar As Decimal = 0

            If kilosDisponiblesEnMemoria >= kilosFaltantes Then
                kilosAAsignar = kilosFaltantes
                row("kilos_disponibles") = kilosDisponiblesEnMemoria - kilosFaltantes
                kilosFaltantes = 0
            Else
                kilosAAsignar = kilosDisponiblesEnMemoria
                row("kilos_disponibles") = 0D
                kilosFaltantes -= kilosDisponiblesEnMemoria
            End If

            ' Guardamos el bin y los kilos asignados
            dtBinesAUtilizar.Rows.Add(idBin, kilosAAsignar)
        Next

        If kilosFaltantes > 0 Then
            Throw New Exception($"Atención: Stock insuficiente en memoria. Faltaron {kilosFaltantes.ToString("N2")} Kg para cubrir el calibre ID: {idCalibre}.")
        End If

        Return dtBinesAUtilizar
    End Function

    ' 🟢 FIRMA Y USINGS CORREGIDOS
    Private Sub CrearOrdenParaOperador(idCalibre As Integer, idOperacion As Integer, kilosRequeridos As Decimal, ByRef dtInventarioLocal As DataTable)
        Try
            ' Se llama a la simulación pasando los parámetros correspondientes
            Dim dtBinesCalculados As DataTable = SimularConsumoFIFO(idCalibre, kilosRequeridos, dtInventarioLocal)

            If dtBinesCalculados IsNot Nothing AndAlso dtBinesCalculados.Rows.Count > 0 Then

                ConexionBD.Abrir()

                Using trx As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                    Try
                        Dim idOrdenGenerada As Integer = 0

                        ' === PASO 2: CABECERA ===
                        Dim sqlCabecera As String = "INSERT INTO ordenes_extraccion (id_calibre, id_operacion, kilos_solicitados, id_estado) " &
                                                    "VALUES (@idCal, @idOp, @kilos, 1);"

                        Using cmdCab As New MySqlCommand(sqlCabecera, ConexionBD.conexion, trx)
                            cmdCab.Parameters.AddWithValue("@idCal", idCalibre)
                            cmdCab.Parameters.AddWithValue("@idOp", idOperacion)
                            cmdCab.Parameters.AddWithValue("@kilos", kilosRequeridos)
                            cmdCab.ExecuteNonQuery()

                            idOrdenGenerada = Convert.ToInt32(cmdCab.LastInsertedId)
                        End Using

                        ' === PASO 3: DETALLE ===
                        Dim sqlDetalle As String = "INSERT INTO ordenes_extraccion_detalle (orden_id, bin_id, kilos_sistema_momento, id_estado_bin) " &
                                                   "VALUES (@ordenId, @binId, @kilosSistema, 1);"

                        For Each row As DataRow In dtBinesCalculados.Rows
                            Using cmdDet As New MySqlCommand(sqlDetalle, ConexionBD.conexion, trx)
                                cmdDet.Parameters.AddWithValue("@ordenId", idOrdenGenerada)
                                cmdDet.Parameters.AddWithValue("@binId", Convert.ToInt32(row("id_bin")))
                                cmdDet.Parameters.AddWithValue("@kilosSistema", Convert.ToDecimal(row("kilos_sistema")))
                                cmdDet.ExecuteNonQuery()
                            End Using
                        Next

                        trx.Commit()

                    Catch ex As Exception
                        trx.Rollback()
                        Throw New Exception("Error al escribir orden del calibre " & idCalibre & ": " & ex.Message)
                    End Try
                End Using
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub dgvBinesDisponibles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBinesDisponibles.CellContentClick

    End Sub
End Class