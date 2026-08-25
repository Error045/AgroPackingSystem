Imports System.Transactions
Imports MySql.Data.MySqlClient

Public Class ucUbicacion
    Inherits System.Windows.Forms.UserControl

    Private LoteTerminado As New List(Of Dictionary(Of String, String))

    ' Variable global para guardar las ubicaciones y pasárselas al ComboBox y a la Grilla
    Private dtUbicaciones As DataTable

    Public Event LoteGuardadoExitosamente()

    Private Sub ucUbicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarUbicaciones()
            ConfigurarGridResumen()
        End If
    End Sub

    ' 1. Llenamos el ComboBox con las ubicaciones y su DISPONIBILIDAD
    Private Sub CargarUbicaciones()
        Try
            Dim sql As String =
                "SELECT u.id, CONCAT(u.nombre, ' (Disp: ', (u.capacidad - IFNULL(c.Ocupados, 0)), ')') AS DisplayName " &
                "FROM tipos_ubicaciones u " &
                "LEFT JOIN (" &
                "   SELECT a.tipos_ubicaciones_id, COUNT(a.id) as Ocupados " &
                "   FROM contenedores a " &
                "JOIN tipos_ubicaciones tu ON a.tipos_ubicaciones_id = tu.id " &
                "   WHERE tu.estado = 1 AND tu.funciones_id IN (5,9) AND tu.id <> 1 " & ' Ajustado al nombre común de estado'
                "   GROUP BY a.tipos_ubicaciones_id" &
                ") c ON u.id = c.tipos_ubicaciones_id " &
                "WHERE u.estado = 1 AND u.funciones_id IN (5,9) AND u.id <> 1"

            dtUbicaciones = ObtenerDatos(sql)

            If dtUbicaciones IsNot Nothing AndAlso dtUbicaciones.Rows.Count > 0 Then
                cmbUbicacionGeneral.DataSource = dtUbicaciones
                cmbUbicacionGeneral.DisplayMember = "DisplayName"
                cmbUbicacionGeneral.ValueMember = "id"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar ubicaciones: " & ex.Message)
        End Try
    End Sub

    ' 2,5. Buscamos el Tipo de Contenedor y lo mostramos en la grilla






    Private Function ObtenerNombreContenedor(idContenedor As String) As String
        Dim nombreContenedor As String = "Desconocido"
        ConexionBD.Abrir()
        ' Ajusta "tipo_envase" si tu columna se llama distinto (ej: "nombre", "descripcion")
        Dim query As String = "SELECT tara FROM tipos_contenedores WHERE id = @id"
        Using cmd = New MySqlCommand(query, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@id", idContenedor)
            Try
                ConexionBD.Abrir()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    nombreContenedor = result.ToString()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al buscar el tipo de contenedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ConexionBD.Cerrar()
            End Try
            End Using

        Return nombreContenedor
    End Function


    ' 2. Configuramos la grilla para incluir Producto, Variedad, Calibre y Ciclo
    Private Sub ConfigurarGridResumen()
        dgvResumen.Columns.Clear()

        ' Columnas de solo lectura - NUEVOS CAMPOS AGREGADOS
        dgvResumen.Columns.Add("ID_CAL", "ID Ticket")
        dgvResumen.Columns.Add("Producto", "Producto")
        dgvResumen.Columns.Add("Variedad", "Variedad")
        dgvResumen.Columns.Add("Calibre", "Calibre")
        dgvResumen.Columns.Add("Bruto", "K. Brutos")
        dgvResumen.Columns.Add("Neto", "K. Netos")
        'dgvResumen.Columns.Add("Ciclo", "Ciclo")


        ' NUEVA COLUMNA VISIBLE: Para mostrar "bin 43", "bin 34", etc.
        dgvResumen.Columns.Add("NombreContenedor", "Tipo Envase")

        ' COLUMNA OCULTA: Solo para guardar el ID (1, 2, etc.) en la base de datos
        Dim colTipoCont As New DataGridViewTextBoxColumn()
        colTipoCont.Name = "idTipoCont"
        colTipoCont.Visible = False
        dgvResumen.Columns.Add(colTipoCont)

        ' Columna ComboBox para elegir destino individual
        Dim colUbicacion As New DataGridViewComboBoxColumn()
        colUbicacion.Name = "colUbicacion"
        colUbicacion.HeaderText = "Cámara Destino"
        If dtUbicaciones IsNot Nothing Then
            colUbicacion.DataSource = dtUbicaciones.Copy()
            colUbicacion.DisplayMember = "DisplayName"
            colUbicacion.ValueMember = "id"
        End If
        dgvResumen.Columns.Add(colUbicacion)

        ' Ajustes visuales y de edición
        dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvResumen.AllowUserToAddRows = False
        dgvResumen.ReadOnly = False

        ' Bloquear edición de datos informativos
        For Each col As DataGridViewColumn In dgvResumen.Columns
            If col.Name <> "colUbicacion" Then
                col.ReadOnly = True
                col.DefaultCellStyle.BackColor = Color.WhiteSmoke ' Efecto visual de deshabilitado
            End If
        Next
    End Sub

    ' 3. Inyectar la lista de pesajes desde ucCalibradoPesaje
    Public Sub RecibirDatosParaGuardar(datosLote As List(Of Dictionary(Of String, String)))
        LoteTerminado = datosLote
        dgvResumen.Rows.Clear()

        For Each item In LoteTerminado
            ' 1. Creamos una nueva fila en blanco y obtenemos su índice
            Dim rowIndex As Integer = dgvResumen.Rows.Add()
            Dim row As DataGridViewRow = dgvResumen.Rows(rowIndex)

            ' 2. Asignamos celda por celda usando el NOMBRE de la columna
            row.Cells("ID_CAL").Value = item("ID_CAL")
            row.Cells("Producto").Value = item("Producto")
            row.Cells("Variedad").Value = item("Variedad")
            row.Cells("Calibre").Value = item("Calibre")
            row.Cells("Bruto").Value = item("Bruto")
            row.Cells("Neto").Value = item("Neto")

            ' Validamos si viene el Ciclo en el diccionario (si no, quedará en blanco hasta calcularlo)
            ' If item.ContainsKey("Ciclo") Then
            ' row.Cells("Ciclo").Value = item("Ciclo")
            ' End If
            ' Obtenemos el ID que nos envió el otro UserControl
            Dim idContenedor As String = item("idTipoCont")
            row.Cells("idTipoCont").Value = idContenedor

            ' 🟢 Consultamos el nombre a la base de datos usando la nueva función
            row.Cells("NombreContenedor").Value = ObtenerNombreContenedor(idContenedor)

        Next
    End Sub

    Private Sub btnAplicarATodos_Click(sender As Object, e As EventArgs) Handles btnAplicarATodos.Click
        If cmbUbicacionGeneral.SelectedValue Is Nothing Then Return
        Dim idSeleccionado = cmbUbicacionGeneral.SelectedValue
        For Each row As DataGridViewRow In dgvResumen.Rows
            row.Cells("colUbicacion").Value = idSeleccionado
        Next
    End Sub

    ' 4. Guardado transaccional con la nueva estructura (Sin etiqueta_ciclo)
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        For Each row As DataGridViewRow In dgvResumen.Rows
            If row.Cells("colUbicacion").Value Is Nothing OrElse IsDBNull(row.Cells("colUbicacion").Value) Then
                MessageBox.Show("El ticket " & row.Cells("ID_CAL").Value.ToString() & " no tiene una cámara asignada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim idUsuario As Integer = 1 ' Sustituir por IdUsuarioGlobal
        Dim idFaseSistema As Integer = 4 ' EJEMPLO: 3 = Calibrado.  4 = pesaje Usar el ID correspondiente de tu tabla fases_sistema

        ' 🟢 CONSULTA SQL ACTUALIZADA (Sin etiqueta_ciclo y sin fases_sistema_id)
        Dim sqlQuery As String =
    "UPDATE contenedores SET " &
    "   tipos_contenedores_id = @cont, " &
    "   kilos_brutos = @bruto, " &
    "   kilos_netos = @neto, " &
    "   tipos_ubicaciones_id = @ubicacionId, " &
    "   estados_contenedores_id = 6, " & ' <-- 6 = Ingreso Camara Frío (Infiere Fase 5)
    "   ciclo = @ciclo, " &
    "   fecha_registro = NOW(), " &
    "   users_id_registro = @userId, " &
    "   updated_at = NOW() " &
    "WHERE id = @id; " &
    "" &
    "INSERT INTO contenedores_historial (" &
    "   tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
    "   tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, " &
    "   ciclo, fecha_movimiento, users_id" &
    ") " &
    "SELECT 1, tipos_contenedores_id, id, 4, 5, kilos_brutos, kilos_netos, @ciclo, NOW(), users_id_registro " &
    "FROM contenedores WHERE id = @id; " &
    "" &
    "INSERT INTO contenedores_historial (" &
    "   tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " &
    "   tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, " &
    "   ciclo, fecha_movimiento, users_id" &
    ") " &
    "SELECT 2, tipos_contenedores_id, id, tipos_ubicaciones_id, 6, kilos_brutos, kilos_netos, @ciclo, NOW(), users_id_registro " &
    "FROM contenedores WHERE id = @id;"

        Dim transaccion As MySqlTransaction = Nothing

        Try
            ConexionBD.Abrir()
            transaccion = ConexionBD.conexion.BeginTransaction()

            ' 🟢 1. CALCULAR EL PRÓXIMO CICLO AQUÍ ADENTRO
            Dim idRecepcion As Integer = 0
            Dim proximoCiclo As Integer = 1
            ' Tomamos el ID del primer contenedor en la grilla para saber a qué recepción pertenece
            Dim primerIdContenedor As Integer = Convert.ToInt32(dgvResumen.Rows(0).Cells("ID_CAL").Value)

            ' A) Buscamos el recepciones_id de ese contenedor
            Dim sqlRecep = "SELECT recepciones_id FROM contenedores WHERE id = @idCont LIMIT 1"
            Using cmdRecep = New MySqlCommand(sqlRecep, ConexionBD.conexion, transaccion)
                cmdRecep.Parameters.AddWithValue("@idCont", primerIdContenedor)
                idRecepcion = Convert.ToInt32(cmdRecep.ExecuteScalar())
            End Using

            ' B) Calculamos el próximo ciclo EXCLUSIVAMENTE para esa recepción
            Dim sqlCiclo = "SELECT COALESCE(MAX(ciclo), 0) + 1 FROM contenedores WHERE recepciones_id = @idRec"
            Using cmdMax = New MySqlCommand(sqlCiclo, ConexionBD.conexion, transaccion)
                cmdMax.Parameters.AddWithValue("@idRec", idRecepcion)
                proximoCiclo = Convert.ToInt32(cmdMax.ExecuteScalar())
            End Using


            Using cmd As New MySqlCommand(sqlQuery, ConexionBD.conexion, transaccion)
                cmd.Parameters.Add("@cont", MySqlDbType.Int32)
                cmd.Parameters.Add("@bruto", MySqlDbType.Double)
                cmd.Parameters.Add("@neto", MySqlDbType.Double)
                cmd.Parameters.Add("@ubicacionId", MySqlDbType.Int32)
                cmd.Parameters.Add("@ciclo", MySqlDbType.Int32)
                cmd.Parameters.Add("@userId", MySqlDbType.Int32)
                cmd.Parameters.Add("@id", MySqlDbType.Int32)

                For Each row As DataGridViewRow In dgvResumen.Rows
                    cmd.Parameters("@cont").Value = row.Cells("idTipoCont").Value
                    cmd.Parameters("@bruto").Value = row.Cells("Bruto").Value
                    cmd.Parameters("@neto").Value = row.Cells("Neto").Value
                    cmd.Parameters("@ubicacionId").Value = row.Cells("colUbicacion").Value
                    cmd.Parameters("@ciclo").Value = proximoCiclo
                    cmd.Parameters("@userId").Value = idUsuario
                    cmd.Parameters("@id").Value = row.Cells("ID_CAL").Value

                    cmd.ExecuteNonQuery()
                Next
            End Using

            transaccion.Commit()
            MessageBox.Show("Los contenedores fueron ubicados correctamente.", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarUbicaciones()
            RaiseEvent LoteGuardadoExitosamente()

        Catch ex As Exception
            If transaccion IsNot Nothing Then transaccion.Rollback()
            MessageBox.Show("Error al guardar. Se cancelaron los cambios." & vbCrLf & "Detalle: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        e.ThrowException = False
    End Sub

End Class