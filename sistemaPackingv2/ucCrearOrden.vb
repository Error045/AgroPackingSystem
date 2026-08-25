Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ucCrearOrden

    Private _capacidadTotalPlanta As Integer = 0
    Private dtPaletVirtual As New DataTable()
    Private dtDestino As New DataTable() ' <--- AÑADE ESTA LÍNEA

    Private Sub ucCrearOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarEstiloGrid()
        ConfigurarGridDestino()
        CargarComboCamaras()
        LlenarCombo(cmbTipoOperacion, "SELECT id, nombre FROM tipos_operaciones WHERE estado = 1", "id", "nombre")
        CargarComboProcesos()
        ActualizarGrid(0, _capacidadTotalPlanta) ' Carga inicial con todas las cámaras

    End Sub

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

    Private Sub LlenarCombo(combo As ComboBox, sql As String, valueM As String, displayM As String)
        Dim dt As DataTable = ObtenerDatos(sql)
        combo.DataSource = Nothing ' Limpiar antes de llenar
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            combo.DataSource = dt
            combo.ValueMember = valueM
            combo.DisplayMember = displayM
        End If
    End Sub

    Private Sub CargarComboCamaras()
        ' 1. Traemos también el campo capacidad de la base de datos
        Dim sql As String = "SELECT id, nombre, capacidad FROM tipos_ubicaciones  ORDER BY nombre ASC"
        Dim dt As DataTable = ObtenerDatos(sql)
        _capacidadTotalPlanta = 0
        ' 2. Calculamos la capacidad total acumulada de la planta para la opción "TODAS"
        'Dim capacidadTotalPlanta As Integer = 0
        For Each r As DataRow In dt.Rows
            If Not IsDBNull(r("capacidad")) Then
                _capacidadTotalPlanta += Convert.ToInt32(r("capacidad"))
            End If
        Next

        ' 3. Insertamos la fila por defecto vinculándole la capacidad total calculada
        Dim row As DataRow = dt.NewRow()
        row("id") = 0
        row("nombre") = "--- TODAS LAS CÁMARAS ---"
        row("capacidad") = _capacidadTotalPlanta
        dt.Rows.InsertAt(row, 0)

        cmbCamaras.DataSource = dt
        cmbCamaras.DisplayMember = "nombre"
        cmbCamaras.ValueMember = "id"
    End Sub

    Private Sub CargarComboProcesos()
        ' Traemos los procesos que están activos (ajusta el WHERE según tu lógica de estados)
        Dim sql As String = "SELECT id, CONCAT('Proceso Palet #', id) AS nombre_mostrar " &
                        "FROM procesos_paletizado " &
                        "WHERE estados_procesos_pallets_id = 1  AND estado = 1 " &
                        "ORDER BY id DESC"

        ' Reutilizamos tu método existente "LlenarCombo"
        LlenarCombo(cmbProcesos, sql, "id", "nombre_mostrar")

        ' Dejamos el combo sin selección por defecto para obligar al usuario a elegir uno
        cmbProcesos.SelectedIndex = -1
    End Sub

    Public Sub ActualizarGrid(idUbicacion As Integer, capacidadMax As Integer)
        ' Si no hay una operación válida seleccionada, limpiamos la grilla y detenemos la ejecución
        If cmbTipoOperacion.SelectedValue Is Nothing OrElse Not IsNumeric(cmbTipoOperacion.SelectedValue) Then
            dgvReporte.DataSource = Nothing
            lblContador.Text = "Bins en vista: 0"
            Return
        End If

        Dim sql As String = "SELECT * FROM vw_detalle_orden_paletizado WHERE 1=1"

        ' 1. Filtro por cámara
        If idUbicacion > 0 Then
            sql &= " AND id_ubicacion = @idUbicacion"
        End If



        ' Variables temporales para guardar los IDs si aplican
        Dim idOp As Integer = 0
        Dim idCliente As Integer = 0
        Dim idRecepcion As Integer = 0



        ' 2. Filtros por Tipo de Operación
        If cmbTipoOperacion.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbTipoOperacion.SelectedValue) Then
            idOp = Convert.ToInt32(cmbTipoOperacion.SelectedValue)

            sql &= " AND tipos_operaciones_id = @idOp"

            ' Si es servicio, sumamos cliente y recepción
            If idOp = 2 Then
                If cmbPersona.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbPersona.SelectedValue) Then
                    idCliente = Convert.ToInt32(cmbPersona.SelectedValue)
                    sql &= " AND personas_id = @idCliente"
                End If

                If cmbRecepcion.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbRecepcion.SelectedValue) Then
                    idRecepcion = Convert.ToInt32(cmbRecepcion.SelectedValue)
                    sql &= " AND recepciones_id = @idRecepcion"
                End If

            End If
        End If


        Dim dt As New DataTable()

        ' --- EJECUCIÓN CON EL MISMO PATRÓN QUE USAS EN UCTARJADO ---
        Try
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                ' Asignamos los parámetros solo si fueron detectados en los condicionales
                If idUbicacion > 0 Then cmd.Parameters.AddWithValue("@idUbicacion", idUbicacion)
                If idOp > 0 Then cmd.Parameters.AddWithValue("@idOp", idOp)
                If idCliente > 0 Then cmd.Parameters.AddWithValue("@idCliente", idCliente)
                If idRecepcion > 0 Then cmd.Parameters.AddWithValue("@idRecepcion", idRecepcion)

                Dim da As New MySqlDataAdapter(cmd)
                ConexionBD.Abrir()
                da.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar la grilla: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        dgvReporte.DataSource = dt

        If dgvReporte.Columns.Count > 0 Then

            ' Método seguro para renombrar columnas
            ActualizarNombreColumna(dgvReporte, "id_bin", "ID BIN")
            ActualizarNombreColumna(dgvReporte, "Nombre_Ubicacion", "CÁMARA")
            ActualizarNombreColumna(dgvReporte, "Nombre_Calibre", "CALIBRE")
            ActualizarNombreColumna(dgvReporte, "Kilos_Netos", "KILOS")
            ActualizarNombreColumna(dgvReporte, "Horas_En_Camara", "HORAS")
            ActualizarNombreColumna(dgvReporte, "Estado_Alerta", "ESTADO")
            ActualizarNombreColumna(dgvReporte, "Origen_Producto", "ORIGEN")

            ' Ocultar columnas solo si existen
            If dgvReporte.Columns.Contains("id_ubicacion") Then dgvReporte.Columns("id_ubicacion").Visible = False
            If dgvReporte.Columns.Contains("id_calibre") Then dgvReporte.Columns("id_calibre").Visible = False
            If dgvReporte.Columns.Contains("funciones_id") Then dgvReporte.Columns("funciones_id").Visible = False

            ' Agregamos el botón de acción
            If Not dgvReporte.Columns.Contains("btnAgregar") Then
                Dim colBoton As New DataGridViewButtonColumn()
                colBoton.Name = "btnAgregar"
                colBoton.HeaderText = "ACCIÓN"
                colBoton.Text = "Agregar"
                colBoton.UseColumnTextForButtonValue = True
                dgvReporte.Columns.Add(colBoton)
            End If

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        ' Actualización de contadores en pantalla
        Dim binsActuales As Integer = dgvReporte.Rows.Count
        lblContador.Text = String.Format("Bins en vista: {0}", binsActuales)
    End Sub

    Private Sub ActualizarNombreColumna(dgv As DataGridView, nombreActual As String, nuevoNombre As String)
        If dgv.Columns.Contains(nombreActual) Then
            dgv.Columns(nombreActual).HeaderText = nuevoNombre
        End If
    End Sub
    Private Sub ConfigurarEstiloGrid()
        With dgvReporte
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            ' Estilo de los encabezados
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            .ColumnHeadersHeight = 35
            .EnableHeadersVisualStyles = False

            ' Estilo de las filas
            .RowTemplate.Height = 30
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .RowHeadersVisible = False ' Quita la columna vacía de la izquierda
        End With
    End Sub

    Private Sub dgvReporte_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReporte.CellFormatting
        If dgvReporte.Columns(e.ColumnIndex).Name = "Estado_Alerta" AndAlso e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) Then

            Dim fila As DataGridViewRow = dgvReporte.Rows(e.RowIndex)

            Select Case e.Value.ToString()
                Case "CRITICO"
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210)
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28)
                Case "ADVERTENCIA"
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196)
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(130, 119, 23)
                Case "OPTIMO"
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201)
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32)
            End Select
        End If
    End Sub

    Private Sub cmbCamaras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCamaras.SelectedIndexChanged
        If cmbCamaras.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbCamaras.SelectedValue) Then
            Dim id As Integer = Convert.ToInt32(cmbCamaras.SelectedValue)
            Dim capMax As Integer = 0

            ' Extraemos la capacidad de la fila seleccionada en el ComboBox
            If TypeOf cmbCamaras.SelectedItem Is DataRowView Then
                Dim drv As DataRowView = DirectCast(cmbCamaras.SelectedItem, DataRowView)
                If Not IsDBNull(drv("capacidad")) Then
                    capMax = Convert.ToInt32(drv("capacidad"))
                End If
            End If

            ' Enviamos el ID de la ubicación y su capacidad máxima
            ActualizarGrid(id, capMax)
        End If
    End Sub

    Private Sub dgvReporte_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReporte.CellContentClick
        ' 1. Verificamos que se hizo clic en la columna del botón y no en el encabezado
        If e.RowIndex >= 0 AndAlso dgvReporte.Columns(e.ColumnIndex).Name = "btnAgregar" Then

            ' 2. Obtenemos la fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgvReporte.Rows(e.RowIndex)

            ' 3. Extraemos los datos (Asegúrate de que los nombres coincidan con tu vista/DataTable)
            Dim idBin As String = filaSeleccionada.Cells("id_bin").Value.ToString()
            Dim ubicacion As String = filaSeleccionada.Cells("Nombre_Ubicacion").Value.ToString()
            Dim kilos As String = filaSeleccionada.Cells("Kilos_Netos").Value.ToString()
            Dim calibre As String = filaSeleccionada.Cells("Nombre_Calibre").Value.ToString()

            ' 4. Llamamos a la función que pasa el dato al otro Grid
            AgregarAlGridDestino(idBin, ubicacion, kilos, calibre)

        End If

    End Sub
    Private Sub ConfigurarGridDestino()
        dtDestino.Columns.Clear()
        dtDestino.Columns.Add("id_bin", GetType(Integer))
        dtDestino.Columns.Add("Nombre_Ubicacion", GetType(String))
        dtDestino.Columns.Add("Kilos_Netos", GetType(Decimal))
        dtDestino.Columns.Add("Nombre_Calibre", GetType(String))

        ' Vincula esta tabla al segundo DataGridView
        dgvDestino.DataSource = dtDestino
    End Sub
    Private Sub AgregarAlGridDestino(idBin As String, ubicacion As String, kilos As String, calibre As String)
        ' Suponiendo que tienes un DataTable llamado dtDestino 
        ' y que este es el DataSource de tu otro DataGridView

        ' Verificamos que no esté ya agregado para evitar duplicados
        For Each row As DataRow In dtDestino.Rows
            If row("id_bin").ToString() = idBin Then
                MessageBox.Show("Este bin ya fue agregado.")
                Return
            End If
        Next

        ' Agregamos la nueva fila
        Dim nuevaFila As DataRow = dtDestino.NewRow()
        nuevaFila("id_bin") = idBin
        nuevaFila("Nombre_Ubicacion") = ubicacion
        nuevaFila("Nombre_Calibre") = calibre
        nuevaFila("Kilos_Netos") = kilos



        dtDestino.Rows.Add(nuevaFila)

        ' Refrescamos el Grid destino (por si acaso)
        dgvDestino.Refresh()
    End Sub


    Private Sub btnCrearOrden_Click(sender As Object, e As EventArgs) Handles btnCrearOrden.Click
        ' 1. VALIDACIONES DE SEGURIDAD
        If cmbProcesos.SelectedValue Is Nothing OrElse Not IsNumeric(cmbProcesos.SelectedValue) Then
            MessageBox.Show("Por favor, seleccione un proceso de paletizado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvDestino.Rows.Count = 0 OrElse dtDestino.Rows.Count = 0 Then
            MessageBox.Show("No hay bines agregados en el destino para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirmación del usuario
        Dim idProceso As Integer = Convert.ToInt32(cmbProcesos.SelectedValue)
        If MessageBox.Show("¿Está seguro de asignar " & dgvDestino.Rows.Count & " bines al Proceso #" & idProceso & "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        ' 2. INSTRUCCIONES SQL AGRUPADAS


        Dim sqlBatch As String =
            "INSERT INTO procesos_bines_origen (procesos_paletizado_id, contenedores_id, fecha_registro) " &
            "VALUES (@idProceso, @idContenedor, NOW()); "


        Dim insercionesExitosas As Integer = 0

        Try
            ConexionBD.Abrir()

            ' Iniciamos la transacción para asegurar la integridad de los datos
            Using transaction As MySqlTransaction = ConexionBD.conexion.BeginTransaction()

                Try
                    ' Utilizamos el DataTable de destino para recorrer los datos
                    For Each row As DataRow In dtDestino.Rows
                        ' Ignoramos filas eliminadas
                        If row.RowState = DataRowState.Deleted Then Continue For

                        Dim idBin As Integer = Convert.ToInt32(row("id_bin"))

                        Using cmd As New MySqlCommand(sqlBatch, ConexionBD.conexion, transaction)
                            cmd.Parameters.AddWithValue("@idProceso", idProceso)
                            cmd.Parameters.AddWithValue("@idContenedor", idBin)

                            cmd.ExecuteNonQuery()
                            insercionesExitosas += 1
                        End Using
                    Next

                    ' Si todo sale bien, confirmamos los cambios en la base de datos
                    transaction.Commit()

                    MessageBox.Show("Se han procesado " & insercionesExitosas & " bines correctamente.", "Proceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' 3. LIMPIEZA POST-PROCESO
                    dtDestino.Clear()
                    ActualizarGrid(0, _capacidadTotalPlanta)

                Catch exSql As Exception
                    ' Si falla alguna inserción, deshacemos todos los cambios de este lote
                    transaction.Rollback()
                    Throw New Exception("Error durante la transacción de bines. No se guardó ningún cambio. Detalle: " & exSql.Message)
                End Try

            End Using

        Catch ex As Exception
            MessageBox.Show("Error al guardar los bines: " & ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub


End Class
