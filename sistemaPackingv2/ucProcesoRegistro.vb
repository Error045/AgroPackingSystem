Imports MySql.Data.MySqlClient

Public Class ucProcesoRegistro
    Private _idProceso As Integer
    ' Variables de estado
    Private idDetalleValidado As Integer = 0
    Private procesoIdActual As Integer = 0

    Public Sub New(idProceso As Integer)
        InitializeComponent()
        _idProceso = idProceso
        procesoIdActual = idProceso
    End Sub

    ' =====================================================================
    ' 1. CARGA INICIAL
    ' =====================================================================
    Private Sub ucProcesoRegistros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarHistorialFull()
        btnProcesar.Enabled = False ' Aseguramos que inicie apagado
        txtIdRecepcion.Focus()      ' Ponemos el cursor listo para el scanner
    End Sub

    Private Sub dgvHistorico_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvHistorico.RowPrePaint
        ' Validamos que el índice sea correcto y no sea la fila vacía del final
        If e.RowIndex >= 0 AndAlso Not dgvHistorico.Rows(e.RowIndex).IsNewRow Then
            Dim row As DataGridViewRow = dgvHistorico.Rows(e.RowIndex)

            ' Validamos que la celda "Estado" tenga datos
            If row.Cells("Estado").Value IsNot DBNull.Value AndAlso row.Cells("Estado").Value IsNot Nothing Then
                Dim estadoActual As String = row.Cells("Estado").Value.ToString()

                ' Aplicamos el color correspondiente
                If estadoActual.Equals("Procesado", StringComparison.OrdinalIgnoreCase) Then
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    row.DefaultCellStyle.BackColor = Color.White
                End If
            End If
        End If
    End Sub

    ' =====================================================================
    ' 2. MÉTODO PARA REFRESCAR EL GRID
    ' =====================================================================
    Private Sub CargarHistorialFull()
        Try
            ConexionBD.Abrir()

            ' 🟢 MODIFICACIÓN AQUÍ: Se cambió el JOIN hacia 'procesos' por la tabla 'procesos_recepciones'
            Dim sql As String =
                "SELECT a.id AS 'N° Contenedor', a.recepciones_id as Recepcion, i.nombre AS Persona, e.nombre AS Producto, f.nombre AS Variedad, g.nombre AS Calibre, " &
                "a.kilos_brutos AS 'Kilos Brutos', a.kilos_netos AS 'Kilos Netos', a.fecha_registro AS Fecha, d.nombre AS Estado " &
                "FROM contenedores a " &
                "INNER JOIN procesos_recepciones pr ON a.recepciones_id = pr.recepciones_id " &
                "INNER JOIN estados_contenedores d ON a.estados_contenedores_id = d.id " &
                "INNER JOIN productos e ON a.productos_id = e.id " &
                "INNER JOIN variedades f ON a.variedades_id = f.id " &
                "INNER JOIN calibres g ON a.calibres_id = g.id " &
                "INNER JOIN recepciones h ON a.recepciones_id = h.id " &
                "INNER JOIN personas i ON h.personas_id = i.id " &
                "WHERE pr.procesos_id = @procid AND (a.estados_contenedores_id = 2 OR a.estados_contenedores_id = 3) " &
                "ORDER BY CASE WHEN d.nombre = 'Procesado' THEN 1 ELSE 2 END ASC, a.fecha_registro DESC;"

            Dim da As New MySqlDataAdapter(sql, ConexionBD.conexion)
            da.SelectCommand.Parameters.AddWithValue("@procid", procesoIdActual)

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvHistorico.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error al cargar historial: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' =====================================================================
    ' 3. LÓGICA DE BÚSQUEDA Y VALIDACIÓN
    ' =====================================================================
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
            ConexionBD.Abrir()

            ' 🟢 MODIFICACIÓN AQUÍ: Cruzamos contenedores directamente con procesos_recepciones
            Dim sql As String =
                "SELECT a.id FROM contenedores a " &
                "INNER JOIN procesos_recepciones pr ON a.recepciones_id = pr.recepciones_id " &
                "WHERE pr.procesos_id = @procesoid AND a.id = @textodeltxt"

            Using cmd As New MySqlCommand(sql, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@procesoid", procesoIdActual)
                cmd.Parameters.AddWithValue("@textodeltxt", codigoLeido)

                Dim resultado = cmd.ExecuteScalar()

                If resultado IsNot Nothing Then
                    idDetalleValidado = Convert.ToInt32(resultado)
                    lblEstado.Text = "✅ VÁLIDO: Registro encontrado"
                    lblEstado.ForeColor = Color.Green
                    btnProcesar.Enabled = True
                    btnProcesar.Focus() ' Mover foco al botón
                Else
                    idDetalleValidado = 0
                    lblEstado.Text = "❌ INVÁLIDO: No pertenece al proceso"
                    lblEstado.ForeColor = Color.Red
                    btnProcesar.Enabled = False
                    txtIdRecepcion.SelectAll()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' =====================================================================
    ' 4. PROCESAR EL CAMBIO
    ' =====================================================================
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If idDetalleValidado = 0 Then Return

        Try
            ConexionBD.Abrir()

            ' Iniciamos una transacción para asegurar que ambos UPDATES se completen
            Using transaccion = ConexionBD.conexion.BeginTransaction()
                Try
                    ' 1. Consulta para actualizar el contenedor
                    Dim sqlProceso As String = "UPDATE contenedores SET estados_contenedores_id = 3 WHERE id = @id"

                    ' 2. Consulta para insertar en el historial (movimiento 4: Termino ciclo)
                    Dim sqlDetalle As String =
                        "INSERT INTO contenedores_historial (" &
                        "tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
                        "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, " &
                        "fecha_movimiento, users_id) " &
                        "SELECT 4, tipos_contenedores_id, id, tipos_ubicaciones_id, 3, kilos_brutos, kilos_netos, NOW(), users_id_registro " &
                        "FROM contenedores " &
                        "WHERE id = @id;"

                    ' Ejecutamos actualización
                    Using cmdProceso As New MySqlCommand(sqlProceso, ConexionBD.conexion, transaccion)
                        cmdProceso.Parameters.AddWithValue("@id", idDetalleValidado)
                        cmdProceso.ExecuteNonQuery()
                    End Using

                    ' Ejecutamos inserción de historial
                    Using cmdDetalle As New MySqlCommand(sqlDetalle, ConexionBD.conexion, transaccion)
                        cmdDetalle.Parameters.AddWithValue("@id", idDetalleValidado)
                        cmdDetalle.ExecuteNonQuery()
                    End Using

                    ' Confirmamos los cambios en la BD
                    transaccion.Commit()

                    ' --- UI Y LIMPIEZA ---
                    txtIdRecepcion.Clear()
                    lblEstado.Text = "✅ Procesado con éxito"
                    lblEstado.ForeColor = Color.DarkGreen
                    btnProcesar.Enabled = False
                    idDetalleValidado = 0

                    CargarHistorialFull()
                    txtIdRecepcion.Focus()

                Catch ex As Exception
                    transaccion.Rollback()
                    Throw New Exception("Error en la transacción: " & ex.Message)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al procesar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

End Class