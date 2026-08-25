Imports MySql.Data.MySqlClient

Public Class ucProcesoPaletizado

    Private _idProceso As Integer
    Private idDetalleValidado As Integer = 0
    Private procesoIdActual As Integer
    Private columnaBotonAgregada As Boolean = False

    Public Sub New(idProceso As Integer)
        InitializeComponent()
        _idProceso = idProceso
        procesoIdActual = idProceso
    End Sub

    ' --- CARGA INICIAL ---
    Private Sub ucProcesoPaletizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarHistorialFull()
        btnProcesar.Enabled = False
        txtIdRecepcion.Focus()
    End Sub

    ' --- DISEÑO: PINTAR FILAS SEGÚN ESTADO ---
    Private Sub dgvHistorico_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvHistorico.RowPrePaint
        If e.RowIndex >= 0 AndAlso Not dgvHistorico.Rows(e.RowIndex).IsNewRow Then
            Dim row As DataGridViewRow = dgvHistorico.Rows(e.RowIndex)

            ' Validamos de forma segura que la columna "Estado" exista en la grilla
            If dgvHistorico.Columns.Contains("Estado") Then
                If row.Cells("Estado").Value IsNot DBNull.Value AndAlso row.Cells("Estado").Value IsNot Nothing Then
                    Dim estadoActual As String = row.Cells("Estado").Value.ToString()

                    If estadoActual.Equals("Procesado", StringComparison.OrdinalIgnoreCase) Then
                        row.DefaultCellStyle.BackColor = Color.LightGreen
                        row.DefaultCellStyle.ForeColor = Color.Black
                    Else
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
            End If
        End If
    End Sub

    ' --- CARGAR HISTORIAL DE BINES EN EL PALET ---
    Private Sub CargarHistorialFull()
        Try
            Dim sql As String = "SELECT a.id AS 'N° Contenedor', e.nombre AS Producto, f.nombre AS Variedad, g.nombre AS Calibre, " &
                                "a.kilos_brutos AS 'Kilos Brutos', a.kilos_netos AS 'Kilos Netos', a.fecha_registro AS Fecha, d.nombre AS Estado " &
                                "FROM contenedores a " &
                                "INNER JOIN procesos_bines_origen AS h ON a.id = h.contenedores_id " &
                                "INNER JOIN estados_contenedores d ON a.estados_contenedores_id = d.id " &
                                "INNER JOIN productos e ON a.productos_id = e.id " &
                                "INNER JOIN variedades f ON a.variedades_id = f.id " &
                                "INNER JOIN calibres g ON a.calibres_id = g.id " &
                                "INNER JOIN procesos_paletizado i ON h.procesos_paletizado_id = i.id " &
                                "Where i.estados_procesos_pallets_id = 1 " &    ' Cambiado filtro por estados_procesos_pallets_id, para filtrar sin necesidad de seleccionar un combobox ( importante siempre cerrar los procesos para evitar confución).
                                "Order By CASE WHEN d.nombre = 'Procesado' THEN 1 ELSE 2 END ASC, a.fecha_registro DESC;"

            Dim dt As New DataTable()

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@procId", procesoIdActual)
                Dim da As New MySqlDataAdapter(cmd)

                ConexionBD.Abrir()
                da.Fill(dt)
            End Using

            dgvHistorico.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error al cargar historial: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- LÓGICA DE BÚSQUEDA Y VALIDACIÓN ---
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ValidarCodigoBarras()
    End Sub

    Private Sub txtIdRecepcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdRecepcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ValidarCodigoBarras()
        End If
    End Sub

    Private Sub ValidarCodigoBarras()
        Dim codigoLeido As String = txtIdRecepcion.Text.Trim()
        If String.IsNullOrEmpty(codigoLeido) Then Return

        Try
            ' Consulta corregida apuntando a la persistencia del flujo de paletizado
            Dim sql As String = "SELECT contenedores_id FROM procesos_bines_origen " &
                                "WHERE procesos_paletizado_id = @procesoid AND contenedores_id = @textodeltxt"

            ConexionBD.Abrir()
            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@procesoid", procesoIdActual)
                cmd.Parameters.AddWithValue("@textodeltxt", codigoLeido)

                Dim resultado = cmd.ExecuteScalar()

                If resultado IsNot Nothing Then
                    idDetalleValidado = Convert.ToInt32(resultado)
                    lblEstado.Text = "✅ VÁLIDO: Registro encontrado en el proceso"
                    lblEstado.ForeColor = Color.Green
                    btnProcesar.Enabled = True
                    btnProcesar.Focus()
                Else
                    idDetalleValidado = 0
                    lblEstado.Text = "❌ INVÁLIDO: No pertenece al proceso de paletizado"
                    lblEstado.ForeColor = Color.Red
                    btnProcesar.Enabled = False
                    txtIdRecepcion.SelectAll()
                    txtIdRecepcion.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al validar código: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' --- PROCESAR EL CAMBIO (TRANSACCIONAL) ---
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If idDetalleValidado = 0 Then Return

        Try
            ConexionBD.Abrir()

            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' 1. Actualizar el estado del contenedor a Procesado para Pallet (ID = 8)
                    Dim sqlProceso As String = "UPDATE contenedores SET estados_contenedores_id = 8 WHERE id = @id"

                    ' 2. Insertar el movimiento en el historial
                    Dim sqlDetalle As String = "INSERT INTO contenedores_historial (" &
                                               "tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
                                               "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, " &
                                               "fecha_movimiento, users_id) " &
                                               "SELECT 4, tipos_contenedores_id, id, tipos_ubicaciones_id, 8, kilos_brutos, kilos_netos, NOW(), users_id_registro " &
                                               "FROM contenedores " &
                                               "WHERE id = @id;"

                    Using cmdProceso As New MySqlCommand(sqlProceso, ConexionBD.conexion, transaccion)
                        cmdProceso.Parameters.AddWithValue("@id", idDetalleValidado)
                        cmdProceso.ExecuteNonQuery()
                    End Using

                    Using cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, transaccion)
                        cmdDetalle.Parameters.AddWithValue("@id", idDetalleValidado)
                        cmdDetalle.ExecuteNonQuery()
                    End Using

                    transaccion.Commit()

                    ' UI Limpieza inmediata para el siguiente escaneo
                    txtIdRecepcion.Clear()
                    lblEstado.Text = "Procesado con éxito"
                    lblEstado.ForeColor = Color.DarkGreen
                    btnProcesar.Enabled = False
                    idDetalleValidado = 0

                    CargarHistorialFull()
                    txtIdRecepcion.Focus()

                Catch ex As Exception
                    transaccion.Rollback()
                    Throw New Exception("Error interno en la transacción: " & ex.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de Procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

End Class