Imports MySql.Data.MySqlClient

Public Class ucCaja

    ' --- CARGA INICIAL CONTROLADA ---
    Private Sub ucCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            ConfigurarGridCajas()
            CargarPalletsYContenedores()
            lblCapacidad.Text = "Seleccione un Pallet"
        End If
    End Sub

    Private Sub ConfigurarGridCajas()
        dgvCajas.Columns.Clear()

        ' Si agregas el campo a la BD, descomenta la siguiente línea y agrégala al SELECT
        dgvCajas.Columns.Add("numero_caja", "N° Caja")
        dgvCajas.Columns.Add("codigo", "Cód. Sistema")
        dgvCajas.Columns.Add("Producto", "Producto")
        dgvCajas.Columns.Add("Variedad", "Variedad")
        dgvCajas.Columns.Add("Calibre", "Calibre")

        Dim colReimprimir As New DataGridViewButtonColumn()
        colReimprimir.Name = "Reimprimir"
        colReimprimir.HeaderText = "Etiqueta"
        colReimprimir.Text = "🖨️ Imprimir"
        colReimprimir.UseColumnTextForButtonValue = True
        colReimprimir.Width = 90
        colReimprimir.FlatStyle = FlatStyle.Flat
        dgvCajas.Columns.Add(colReimprimir)

        dgvCajas.AllowUserToAddRows = False
        dgvCajas.ReadOnly = True
        dgvCajas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarPalletsYContenedores()
        Try
            ' 1. Pallets abiertos
            Dim sqlPallets As String = "SELECT id, CONCAT('Pallet N° ', id) AS nombre_mostrar FROM pallets WHERE estados_progresos_pallets_id = 1 ORDER BY id DESC"
            LlenarCombo(cmbPallet, sqlPallets, "id", "nombre_mostrar")

            ' 2. Tipos de Contenedor (Fijo para Cajas)
            Dim sqlCajas As String = "SELECT id, nombre FROM tipos_contenedores WHERE estado = 1 AND tipos_clases = 2 ORDER BY nombre ASC"
            LlenarCombo(cmbTipoContenedor, sqlCajas, "id", "nombre")

            ' Limpiamos los combos dependientes y el grid al iniciar
            cmbProducto.DataSource = Nothing
            cmbVariedad.DataSource = Nothing
            cmbCalibre.DataSource = Nothing
            dgvCajas.DataSource = Nothing
            dgvCajas.Rows.Clear()

        Catch ex As Exception
            MessageBox.Show("Error al inicializar datos base: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- 1. CAMBIO DE PALLET: CARGA PRODUCTOS Y EL GRID ---
    Private Sub cmbPallet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPallet.SelectedIndexChanged
        ' Limpieza en cascada hacia abajo
        cmbProducto.DataSource = Nothing
        cmbVariedad.DataSource = Nothing
        cmbCalibre.DataSource = Nothing
        lblCapacidad.Text = "Seleccione un Pallet"
        dgvCajas.Rows.Clear() ' Limpiamos el grid de las cajas del pallet anterior

        If cmbPallet.SelectedValue Is Nothing OrElse Not IsNumeric(cmbPallet.SelectedValue) Then Return

        Dim idPallet As Integer = Convert.ToInt32(cmbPallet.SelectedValue)
        ActualizarLabelCapacidad(idPallet)
        CargarProductosPorPallet(idPallet)

        ' 🟢 CARGAMOS LAS CAJAS DEL PALLET SELECCIONADO
        CargarCajasEnGrid(idPallet)
    End Sub

    ' 🟢 NUEVO MÉTODO: Llena el DataGridView
    Private Sub CargarCajasEnGrid(idPallet As Integer)
        Try
            ' Si agregas el número de caja, añade: a.numero_caja al inicio del SELECT
            Dim sql As String = "SELECT a.numero_caja, a.id as codigo, b.nombre as Producto, c.nombre as Variedad, d.nombre as Calibre " &
                                "FROM cajas a " &
                                "JOIN productos b ON a.productos_id = b.id " &
                                "JOIN variedades c ON a.variedades_id = c.id " &
                                "JOIN calibres d ON a.calibres_id = d.id " &
                                "WHERE a.pallet_id = @idPallet AND a.estado = 1 " &
                                "ORDER BY a.id DESC;" ' Ordenamos DESC para que la última caja creada aparezca arriba

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            dgvCajas.Rows.Clear()
            For Each row As DataRow In dt.Rows
                ' Si agregas el numero_caja, colócalo aquí como primer parámetro: row("numero_caja"),
                dgvCajas.Rows.Add(row("numero_caja"), row("codigo"), row("Producto"), row("Variedad"), row("Calibre"))
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar listado de cajas: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub CargarProductosPorPallet(idPallet As Integer)
        Try
            Dim sql As String = "SELECT DISTINCT a.id, a.nombre FROM productos a " &
                                "INNER JOIN contenedores b ON a.id = b.productos_id " &
                                "INNER JOIN procesos_bines_origen c ON b.id = c.contenedores_id " &
                                "INNER JOIN procesos_paletizado d ON c.procesos_paletizado_id = d.id " &
                                "INNER JOIN pallets e ON d.id = e.procesos_paletizado_id " &
                                "WHERE a.estado = 1 AND e.id = @idPallet " &
                                "ORDER BY a.nombre ASC;"

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            cmbProducto.DataSource = dt
            cmbProducto.ValueMember = "id"
            cmbProducto.DisplayMember = "nombre"
            cmbProducto.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- 2. CAMBIO DE PRODUCTO: CARGA VARIEDADES ---
    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        cmbVariedad.DataSource = Nothing
        cmbCalibre.DataSource = Nothing

        If cmbPallet.SelectedValue Is Nothing OrElse Not IsNumeric(cmbPallet.SelectedValue) Then Return
        If cmbProducto.SelectedValue Is Nothing OrElse Not IsNumeric(cmbProducto.SelectedValue) Then Return

        CargarVariedadesPorProducto(Convert.ToInt32(cmbPallet.SelectedValue), Convert.ToInt32(cmbProducto.SelectedValue))
    End Sub

    Private Sub CargarVariedadesPorProducto(idPallet As Integer, idProducto As Integer)
        Try
            Dim sql As String = "SELECT DISTINCT v.id, v.nombre FROM variedades v " &
                                "INNER JOIN contenedores c ON v.id = c.variedades_id " &
                                "INNER JOIN procesos_bines_origen pbo ON c.id = pbo.contenedores_id " &
                                "INNER JOIN pallets p ON pbo.procesos_paletizado_id = p.procesos_paletizado_id " &
                                "WHERE v.estado = 1 AND p.id = @idPallet AND c.productos_id = @idProducto " &
                                "ORDER BY v.nombre ASC;"

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                cmd.Parameters.AddWithValue("@idProducto", idProducto)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            cmbVariedad.DataSource = dt
            cmbVariedad.ValueMember = "id"
            cmbVariedad.DisplayMember = "nombre"
            cmbVariedad.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar variedades: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- 3. CAMBIO DE VARIEDAD: CARGA CALIBRES ---
    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        cmbCalibre.DataSource = Nothing

        If cmbPallet.SelectedValue Is Nothing OrElse Not IsNumeric(cmbPallet.SelectedValue) Then Return
        If cmbVariedad.SelectedValue Is Nothing OrElse Not IsNumeric(cmbVariedad.SelectedValue) Then Return

        CargarCalibresPorVariedad(Convert.ToInt32(cmbPallet.SelectedValue), Convert.ToInt32(cmbVariedad.SelectedValue))
    End Sub

    Private Sub CargarCalibresPorVariedad(idPallet As Integer, idVariedad As Integer)
        Try
            Dim sql As String = "SELECT DISTINCT ca.id, ca.nombre FROM calibres ca " &
                                "INNER JOIN contenedores c ON ca.id = c.calibres_id " &
                                "INNER JOIN procesos_bines_origen pbo ON c.id = pbo.contenedores_id " &
                                "INNER JOIN pallets p ON pbo.procesos_paletizado_id = p.procesos_paletizado_id " &
                                "WHERE ca.estado = 1 AND p.id = @idPallet AND c.variedades_id = @idVariedad " &
                                "ORDER BY ca.id ASC;"

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idPallet", idPallet)
                cmd.Parameters.AddWithValue("@idVariedad", idVariedad)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            cmbCalibre.DataSource = dt
            cmbCalibre.ValueMember = "id"
            cmbCalibre.DisplayMember = "nombre"
            cmbCalibre.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar calibres: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- METODO AUXILIAR DE CAPACIDAD ---
    Private Sub ActualizarLabelCapacidad(idPallet As Integer)
        Dim sql As String = "SELECT numero_cajas, capacidad FROM pallets WHERE id = @id"
        Try
            ConexionBD.Abrir()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@id", idPallet)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim actuales As Integer = Convert.ToInt32(reader("numero_cajas"))
                        Dim maximo As Integer = Convert.ToInt32(reader("capacidad"))
                        lblCapacidad.Text = String.Format("Cajas: {0} / {1}", actuales, maximo)
                        If actuales >= maximo Then
                            lblCapacidad.ForeColor = Color.Red
                        Else
                            lblCapacidad.ForeColor = Color.DarkBlue
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblCapacidad.Text = "Error al leer capacidad"
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- AUXILIAR PARA LLENAR COMBOBOX BASE ---
    Private Sub LlenarCombo(combo As ComboBox, sql As String, valueMember As String, displayMember As String)
        Try
            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using
            combo.DataSource = dt
            combo.ValueMember = valueMember
            combo.DisplayMember = displayMember
            combo.SelectedIndex = -1
        Catch ex As Exception
            Throw New Exception("Error en combo: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- MÉTODO DE VALIDACIÓN DE UI ---
    Private Function ValidarSelecciones() As Boolean
        If cmbPallet.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un Pallet de destino.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbTipoContenedor.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione el tipo de caja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbProducto.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione el producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbVariedad.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione la variedad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbCalibre.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione el calibre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    ' --- CREACIÓN DE CAJA Y VALIDACIÓN DE TOPES ---
    Private Sub btnCrearCaja_Click(sender As Object, e As EventArgs) Handles btnCrearCaja.Click
        If Not ValidarSelecciones() Then Return

        Dim idPallet As Integer = Convert.ToInt32(cmbPallet.SelectedValue)
        Dim idTipoCaja As Integer = Convert.ToInt32(cmbTipoContenedor.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
        Dim idVariedad As Integer = Convert.ToInt32(cmbVariedad.SelectedValue)
        Dim idCalibre As Integer = Convert.ToInt32(cmbCalibre.SelectedValue)

        Dim idUsuario As Integer = 1
        Dim idTipoMovimiento As Integer = 1

        Try
            ConexionBD.Abrir()

            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    Dim actuales As Integer = 0
                    Dim maximo As Integer = 0
                    Dim idProceso As Integer = 0
                    Dim idTipoContPallet As Integer = 0
                    Dim idUbicacion As Integer = 0
                    Dim kNetos As Decimal = 0
                    Dim kBrutos As Decimal = 0
                    Dim idEstContenedor As Integer = 0

                    Dim sqlCheck As String = "SELECT procesos_paletizado_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, estados_contenedores_id FROM pallets WHERE id = @id FOR UPDATE"

                    Using cmdCheck As New MySqlCommand(sqlCheck, ConexionBD.conexion, transaccion)
                        cmdCheck.Parameters.AddWithValue("@id", idPallet)
                        Using reader = cmdCheck.ExecuteReader()
                            If reader.Read() Then
                                actuales = Convert.ToInt32(reader("numero_cajas"))
                                maximo = Convert.ToInt32(reader("capacidad"))
                                idProceso = Convert.ToInt32(reader("procesos_paletizado_id"))
                                idTipoContPallet = Convert.ToInt32(reader("tipos_contenedores_id"))
                                idUbicacion = Convert.ToInt32(reader("tipos_ubicaciones_id"))
                                kNetos = Convert.ToDecimal(reader("kilos_netos"))
                                kBrutos = Convert.ToDecimal(reader("kilos_brutos"))
                                idEstContenedor = Convert.ToInt32(reader("estados_contenedores_id"))
                            End If
                        End Using
                    End Using

                    If actuales >= maximo Then
                        MessageBox.Show("No se pueden agregar más cajas. El Pallet ya alcanzó su capacidad máxima (" & maximo & ").", "Pallet Lleno", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        transaccion.Rollback()
                        Return
                    End If

                    Dim nuevoConteo As Integer = actuales + 1

                    ' Si agregas la columna a la BD, súmale esto al query de abajo: "numero_caja, " y su parámetro "@numCaja, "
                    Dim sqlInsertCaja As String = "INSERT INTO cajas (pallet_id, tipos_contenedores_id, numero_caja, productos_id, variedades_id, calibres_id, fecha_registro, estado) " &
                                                  "VALUES (@idPallet, @idTipo, @numCaja, @idProd, @idVar, @idCal, NOW(), 1);" &
                                                  "SELECT LAST_INSERT_ID();" ' Para traer el ID de la caja y mostrarlo en el grid

                    Dim idNuevaCaja As Integer = 0

                    Using cmdCaja As New MySqlCommand(sqlInsertCaja, ConexionBD.conexion, transaccion)
                        cmdCaja.Parameters.AddWithValue("@idPallet", idPallet)
                        cmdCaja.Parameters.AddWithValue("@idTipo", idTipoCaja)
                        cmdCaja.Parameters.AddWithValue("@idProd", idProducto)
                        cmdCaja.Parameters.AddWithValue("@idVar", idVariedad)
                        cmdCaja.Parameters.AddWithValue("@idCal", idCalibre)
                        cmdCaja.Parameters.AddWithValue("@numCaja", nuevoConteo) ' Descomentar si usas la columna
                        idNuevaCaja = Convert.ToInt32(cmdCaja.ExecuteScalar())
                    End Using

                    Dim nuevoEstado As Integer = 1
                    If nuevoConteo = maximo Then
                        nuevoEstado = 2
                    End If

                    Dim sqlUpdatePallet As String = "UPDATE pallets SET numero_cajas = @nuevoConteo, estados_progresos_pallets_id = @nuevoEstado WHERE id = @idPallet"

                    Using cmdPallet As New MySqlCommand(sqlUpdatePallet, ConexionBD.conexion, transaccion)
                        cmdPallet.Parameters.AddWithValue("@nuevoConteo", nuevoConteo)
                        cmdPallet.Parameters.AddWithValue("@nuevoEstado", nuevoEstado)
                        cmdPallet.Parameters.AddWithValue("@idPallet", idPallet)
                        cmdPallet.ExecuteNonQuery()
                    End Using

                    Dim sqlHistorial As String = "INSERT INTO pallets_historial (tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id,users_id, estado) " &
                                                 "VALUES (@mov, @proceso, @pallet, @tipoCont, @ubi, @kNetos, @kBrutos, @cajas, @capacidad, NOW(), @estContenedor, @estProgreso,@user, @estado)"

                    Using cmdHistorial As New MySqlCommand(sqlHistorial, ConexionBD.conexion, transaccion)
                        cmdHistorial.Parameters.AddWithValue("@mov", idTipoMovimiento)
                        cmdHistorial.Parameters.AddWithValue("@proceso", idProceso)
                        cmdHistorial.Parameters.AddWithValue("@pallet", idPallet)
                        cmdHistorial.Parameters.AddWithValue("@tipoCont", idTipoContPallet)
                        cmdHistorial.Parameters.AddWithValue("@ubi", idUbicacion)
                        cmdHistorial.Parameters.AddWithValue("@kNetos", kNetos)
                        cmdHistorial.Parameters.AddWithValue("@kBrutos", kBrutos)
                        cmdHistorial.Parameters.AddWithValue("@cajas", nuevoConteo)
                        cmdHistorial.Parameters.AddWithValue("@capacidad", maximo)
                        cmdHistorial.Parameters.AddWithValue("@estContenedor", idEstContenedor)
                        cmdHistorial.Parameters.AddWithValue("@estProgreso", nuevoEstado)
                        cmdHistorial.Parameters.AddWithValue("@user", idUsuario)
                        cmdHistorial.Parameters.AddWithValue("@estado", 1)
                        cmdHistorial.ExecuteNonQuery()
                    End Using

                    transaccion.Commit()

                    ' Actualizamos visualmente el DataGridView sin tener que hacer una consulta entera a la BD otra vez
                    ' Si agregas el numero_caja, ponlo de primero: nuevoConteo, 
                    dgvCajas.Rows.Insert(0, nuevoConteo, idNuevaCaja, cmbProducto.Text, cmbVariedad.Text, cmbCalibre.Text)

                    ' ActualizarLabelCapacidad(idPallet) ahora lo hace sin llamar bd
                    ' --- 2. Actualizar el label manualmente sin consultar la BD ---
                    lblCapacidad.Text = String.Format("Cajas: {0} / {1}", nuevoConteo, maximo)
                    If nuevoConteo >= maximo Then
                        lblCapacidad.ForeColor = Color.Red
                    Else
                        lblCapacidad.ForeColor = Color.DarkBlue
                    End If

                    ' --- 3. Evaluar si se completó el pallet ---
                    If nuevoEstado = 2 Then
                        MessageBox.Show("¡El Pallet se ha completado! (Cajas: " & maximo & "/" & maximo & ")", "Pallet Lleno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' OJO: Aquí se llama a CargarPalletsYContenedores(). Es preferible que lo 
                        ' llames FUERA del Using y del Try principal de la base de datos para evitar choques de conexión.
                    End If



                Catch ex As Exception
                    transaccion.Rollback()
                    Throw New Exception("Fallo en la transacción de guardado: " & ex.Message)
                End Try
            End Using
            ' CargarPalletsYContenedores()  para no reiniciar los combobox

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' 🟢 EVENTO DEL BOTÓN DE REIMPRESIÓN EN EL DATAGRIDVIEW
    Private Sub dgvCajas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCajas.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvCajas.Columns(e.ColumnIndex).Name = "Reimprimir" Then
            ' Obtenemos el ID de la caja de esa fila
            Dim idCajaImprimir As Integer = Convert.ToInt32(dgvCajas.Rows(e.RowIndex).Cells("codigo").Value)

            ' Aquí llamas a tu módulo o función de impresión, pasándole el ID
            ' Ejemplo:
            ' ModuloImpresion.ImprimirEtiquetaCaja(idCajaImprimir)

            MessageBox.Show("Enviando impresión de etiqueta para la Caja Código: " & idCajaImprimir, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class