Imports MySql.Data.MySqlClient

Public Class ucPallet

    Private Sub ucPallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombos()
    End Sub

    ' --- MÉTODO DE CARGA ---
    Private Sub CargarCombos()
        Try
            ' 1. Cargar combo de Procesos de Paletizado
            Dim sqlProcesos As String = "SELECT id, CONCAT('Proceso N° ', id) AS nombre_mostrar " &
                                        "FROM procesos_paletizado " &
                                        "WHERE estados_procesos_pallets_id = 1 AND estado = 1 " &
                                        "ORDER BY id DESC"

            LlenarCombo(cmbProcesoPallet, sqlProcesos, "id", "nombre_mostrar")

            ' 2. Cargar combo de Tipos de Contenedor
            Dim sqlTipos As String = "SELECT id, nombre " &
                                     "FROM tipos_contenedores " &
                                     "WHERE estado = 1 AND tipos_clases = 3 " &
                                     "ORDER BY nombre ASC"

            LlenarCombo(cmbTipoContenedor, sqlTipos, "id", "nombre")

        Catch ex As Exception
            MessageBox.Show("Error al cargar los desplegables: " & ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- MÉTODO AUXILIAR PARA LLENAR COMBOBOX ---
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
            Throw New Exception("Error al procesar los datos del ComboBox: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- CREACIÓN DE PALLET Y SU HISTORIAL ---
    Private Sub btnCrearPallet_Click(sender As Object, e As EventArgs) Handles btnCrearPallet.Click
        ' --- 1. VALIDACIONES DE UI ---
        If cmbProcesoPallet.SelectedValue Is Nothing OrElse Not IsNumeric(cmbProcesoPallet.SelectedValue) Then
            MessageBox.Show("Por favor, seleccione un Proceso de Paletizado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTipoContenedor.SelectedValue Is Nothing OrElse Not IsNumeric(cmbTipoContenedor.SelectedValue) Then
            MessageBox.Show("Por favor, seleccione un Tipo de Contenedor (Pallet).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. VALORES INICIALES SEGÚN TU TABLA ---
        Dim idProceso As Integer = Convert.ToInt32(cmbProcesoPallet.SelectedValue)
        Dim idTipoContenedor As Integer = Convert.ToInt32(cmbTipoContenedor.SelectedValue)

        ' Valores por defecto para el nacimiento de un pallet (basado en tu volcado BD)
        Dim idUbicacion As Integer = 3 ' patio calibrado
        Dim kNetos As Decimal = 0.0
        Dim kBrutos As Decimal = 0.0
        Dim cajasIniciales As Integer = 0
        Dim capacidadDefecto As Integer = 45 ' Valor por defecto de tu BD (puedes volverlo dinámico luego)
        Dim idEstContenedor As Integer = 9   ' 9 = "Asignación de Cajas, en calibrado"
        Dim estadoProgreso As Integer = 1 ' 1 = Abierto
        Dim estadoInicial As Integer = 1 ' 1 = Activo

        ' Variables de contexto (historial)
        Dim idUsuario As Integer = 1 ' Reemplazar por usuario logueado
        Dim idTipoMovimiento As Integer = 1 ' Ejemplo: 1 = "Creación de Pallet"

        Dim idPalletCreado As Integer = 0

        Try
            ConexionBD.Abrir()

            ' Iniciamos transacción
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' --- 3. INSERTAR EN PALLETS ---
                    Dim sqlInsertPallet As String = "INSERT INTO pallets (procesos_paletizado_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, estados_contenedores_id, estados_progresos_pallets_id, fecha_registro, estado) " &
                                                    "VALUES (@idProceso, @idTipo, @idUbi, @kNetos, @kBrutos, @cajas, @capacidad, @idEstContenedor, @estProgreso,NOW(), @estado); " &
                                                    "SELECT LAST_INSERT_ID();"

                    Using cmdPallet As New MySqlCommand(sqlInsertPallet, ConexionBD.conexion, transaccion)
                        cmdPallet.Parameters.AddWithValue("@idProceso", idProceso)
                        cmdPallet.Parameters.AddWithValue("@idTipo", idTipoContenedor)
                        cmdPallet.Parameters.AddWithValue("@idUbi", idUbicacion)
                        cmdPallet.Parameters.AddWithValue("@kNetos", kNetos)
                        cmdPallet.Parameters.AddWithValue("@kBrutos", kBrutos)
                        cmdPallet.Parameters.AddWithValue("@cajas", cajasIniciales)
                        cmdPallet.Parameters.AddWithValue("@capacidad", capacidadDefecto)
                        cmdPallet.Parameters.AddWithValue("@idEstContenedor", idEstContenedor)
                        cmdPallet.Parameters.AddWithValue("@estProgreso", estadoProgreso)
                        cmdPallet.Parameters.AddWithValue("@estado", estadoInicial)

                        ' Ejecutamos y capturamos el ID del Pallet generado
                        idPalletCreado = Convert.ToInt32(cmdPallet.ExecuteScalar())
                    End Using

                    ' --- 4. INSERTAR EN HISTORIAL ---
                    Dim sqlHistorial As String = "INSERT INTO pallets_historial (tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id, users_id, estado) " &
                                                 "VALUES (@mov, @proceso, @pallet, @tipoCont, @ubi, @kNetos, @kBrutos, @cajas, @capacidad, NOW(), @estContenedor, @estProgreso, @user, @estado)"

                    Using cmdHistorial As New MySqlCommand(sqlHistorial, ConexionBD.conexion, transaccion)
                        cmdHistorial.Parameters.AddWithValue("@mov", idTipoMovimiento)
                        cmdHistorial.Parameters.AddWithValue("@proceso", idProceso)
                        cmdHistorial.Parameters.AddWithValue("@pallet", idPalletCreado) ' Usamos el ID capturado arriba
                        cmdHistorial.Parameters.AddWithValue("@tipoCont", idTipoContenedor)
                        cmdHistorial.Parameters.AddWithValue("@ubi", idUbicacion)
                        cmdHistorial.Parameters.AddWithValue("@kNetos", kNetos)
                        cmdHistorial.Parameters.AddWithValue("@kBrutos", kBrutos)
                        cmdHistorial.Parameters.AddWithValue("@cajas", cajasIniciales)
                        cmdHistorial.Parameters.AddWithValue("@capacidad", capacidadDefecto)
                        cmdHistorial.Parameters.AddWithValue("@estContenedor", idEstContenedor)
                        cmdHistorial.Parameters.AddWithValue("@estProgreso", estadoProgreso)
                        cmdHistorial.Parameters.AddWithValue("@user", idUsuario)
                        cmdHistorial.Parameters.AddWithValue("@estado", estadoInicial)

                        cmdHistorial.ExecuteNonQuery()
                    End Using

                    ' --- 5. CONFIRMAR TRANSACCIÓN ---
                    transaccion.Commit()

                    MessageBox.Show("Pallet N° " & idPalletCreado & " creado exitosamente en estado 'Abierto'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Limpiar interfaz
                    cmbTipoContenedor.SelectedIndex = -1

                Catch ex As Exception
                    transaccion.Rollback()
                    Throw New Exception("Fallo en la transacción de creación: " & ex.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al crear el pallet: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub


End Class