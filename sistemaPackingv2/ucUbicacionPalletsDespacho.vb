Imports MySql.Data.MySqlClient

Public Class ucUbicacionPalletsDespacho

    Inherits System.Windows.Forms.UserControl

    Private LoteTerminado As New List(Of Dictionary(Of String, String))
    Private dtUbicaciones As DataTable

    Public Event LoteGuardadoExitosamente()

    Private Sub ucUbicacionPalletsDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            CargarUbicaciones()
            ConfigurarGridResumen()
        End If
    End Sub

    ' 1. Llenamos el ComboBox con las ubicaciones y su DISPONIBILIDAD
    Private Sub CargarUbicaciones()
        Try
            ' Ajustamos la consulta para calcular la ocupación basada en los Pallets
            Dim sql As String =
                "SELECT u.id, CONCAT(u.nombre, ' (Disp: ', (u.capacidad - IFNULL(p.Ocupados, 0)), ')') AS DisplayName " &
                "FROM tipos_ubicaciones u " &
                "LEFT JOIN (" &
                "   SELECT tipos_ubicaciones_id, COUNT(id) as Ocupados " &
                "   FROM pallets " &
                "   WHERE estados_contenedores_id = 2 " & ' Ajustado al nombre común de estado
                "   GROUP BY tipos_ubicaciones_id" &
                ") p ON u.id = p.tipos_ubicaciones_id " &
                "WHERE u.estado = 1 AND u.id <> 1"

            dtUbicaciones = ObtenerDatos(sql) ' Utiliza tu función global

            If dtUbicaciones IsNot Nothing AndAlso dtUbicaciones.Rows.Count > 0 Then
                cmbUbicacionGeneral.DataSource = dtUbicaciones
                cmbUbicacionGeneral.DisplayMember = "DisplayName"
                cmbUbicacionGeneral.ValueMember = "id"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar ubicaciones: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 2. Configuramos la grilla para permitir elección individual
    Private Sub ConfigurarGridResumen()
        dgvResumen.Columns.Clear()

        dgvResumen.Columns.Add("ID_PALLET", "N° Pallet")
        dgvResumen.Columns.Add("Bruto", "Kilos Brutos")
        dgvResumen.Columns.Add("Neto", "Kilos Netos")
        dgvResumen.Columns.Add("Tara", "Tara Compuesta")

        ' Columna ComboBox para elegir cámara de destino
        Dim colUbicacion As New DataGridViewComboBoxColumn()
        colUbicacion.Name = "colUbicacion"
        colUbicacion.HeaderText = "Cámara Destino"
        If dtUbicaciones IsNot Nothing Then
            colUbicacion.DataSource = dtUbicaciones.Copy()
            colUbicacion.DisplayMember = "DisplayName"
            colUbicacion.ValueMember = "id"
        End If
        dgvResumen.Columns.Add(colUbicacion)

        dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvResumen.AllowUserToAddRows = False
        dgvResumen.ReadOnly = False

        ' Bloqueamos la edición de los datos de pesaje y alineamos números a la derecha
        Dim columnasNumericas As String() = {"Bruto", "Neto", "Tara"}
        For Each nombreCol In columnasNumericas
            dgvResumen.Columns(nombreCol).ReadOnly = True
            dgvResumen.Columns(nombreCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        dgvResumen.Columns("ID_PALLET").ReadOnly = True
        dgvResumen.Columns("ID_PALLET").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' 3. Inyectar la lista de pesajes desde ucPesajePallets
    Public Sub RecibirDatosParaGuardar(datosLote As List(Of Dictionary(Of String, String)))
        LoteTerminado = datosLote
        dgvResumen.Rows.Clear()

        For Each item In LoteTerminado
            dgvResumen.Rows.Add(item("ID_PALLET"), item("Bruto"), item("Neto"), item("TaraTotal"))
        Next
    End Sub

    ' Aplica la cámara general a todos los pallets de la grilla
    Private Sub btnAplicarATodos_Click(sender As Object, e As EventArgs) Handles btnAplicarATodos.Click
        If cmbUbicacionGeneral.SelectedValue Is Nothing Then Return

        Dim idSeleccionado = cmbUbicacionGeneral.SelectedValue

        For Each row As DataGridViewRow In dgvResumen.Rows
            row.Cells("colUbicacion").Value = idSeleccionado
        Next
    End Sub

    ' 4. Guardado transaccional en tabla pallets y pallets_historial
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validación de destinos
        For Each row As DataGridViewRow In dgvResumen.Rows
            If row.Cells("colUbicacion").Value Is Nothing OrElse IsDBNull(row.Cells("colUbicacion").Value) Then
                MessageBox.Show("El Pallet N° " & row.Cells("ID_PALLET").Value.ToString() & " no tiene una cámara asignada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim idUsuario As Integer = 1 ' Reemplazar por tu variable de sesión global

        ' Consulta SQL combinada (Multiple statements)
        Dim sqlQuery As String =
            "UPDATE pallets SET " &
            "   kilos_brutos = @bruto, " &
            "   kilos_netos = @neto, " &
            "   tipos_ubicaciones_id = @ubicacionId, " &
            "   estados_contenedores_id = CASE " &
            "       WHEN @ubicacionId IN(5,6) THEN 6 " & _ ' Si es la ubicación 5,6 Camaras frio 6
            "       WHEN @ubicacionId IN(7,8,9) THEN 14 " & _ ' Si es la ubicación 7,8,9, asigna Camaras Maduración 14
            "       ELSE estados_contenedores_id " & _        ' Si no cumple ninguna, se queda con su valor actual
            "   END, " &
            "   estados_progresos_pallets_id = 2, " &
            " fecha_registro = NOW() " &
            "WHERE id = @id; " &
            "INSERT INTO pallets_historial (" &
            "   tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, " &
            "   tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, " &
            "   fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id,users_id, estado" &
            ") " &
            "SELECT 4, procesos_paletizado_id, id, tipos_contenedores_id, " &
            "   4, @neto, @bruto, numero_cajas, capacidad, " &  ' Usamos los parámetros aquí también por seguridad
            "   NOW(), 10, estados_progresos_pallets_id,@userId, estado " &  ' asignación de estado 10 (Asignación kilos Pallet) para el historial
            "FROM pallets WHERE id = @id; " &
            "INSERT INTO pallets_historial (" &
            "   tipos_movimientos_id, procesos_paletizado_id, pallets_id, tipos_contenedores_id, " &
            "   tipos_ubicaciones_id, kilos_netos, kilos_brutos, numero_cajas, capacidad, " &
            "   fecha_movimiento, estados_contenedores_id, estados_progresos_pallets_id,users_id, estado" &
            ") " &
            "SELECT 2, procesos_paletizado_id, id, tipos_contenedores_id, " &
            "   @ubicacionId, @neto, @bruto, numero_cajas, capacidad, " &
            "   NOW(), estados_contenedores_id, estados_progresos_pallets_id,@userId, estado " &
            "FROM pallets WHERE id = @id;"

        Dim transaccion As MySqlTransaction = Nothing

        Try
            ConexionBD.Abrir()
            transaccion = ConexionBD.conexion.BeginTransaction()

            Using cmd As New MySqlCommand(sqlQuery, ConexionBD.conexion, transaccion)
                cmd.Parameters.Add("@bruto", MySqlDbType.Double)
                cmd.Parameters.Add("@neto", MySqlDbType.Double)
                cmd.Parameters.Add("@ubicacionId", MySqlDbType.Int32)
                cmd.Parameters.Add("@userId", MySqlDbType.Int32)
                cmd.Parameters.Add("@id", MySqlDbType.Int32)

                ' ESTILO SEGURO: Convertimos usando InvariantCulture para ignorar problemas de comas/puntos en el sistema
                For Each row As DataGridViewRow In dgvResumen.Rows
                    Dim valBruto As String = row.Cells("Bruto").Value.ToString()
                    Dim valNeto As String = row.Cells("Neto").Value.ToString()

                    cmd.Parameters("@bruto").Value = Double.Parse(valBruto)  ', CultureInfo.InvariantCulture
                    cmd.Parameters("@neto").Value = Double.Parse(valNeto)    ', CultureInfo.InvariantCulture
                    cmd.Parameters("@ubicacionId").Value = Convert.ToInt32(row.Cells("colUbicacion").Value)
                    cmd.Parameters("@userId").Value = idUsuario
                    cmd.Parameters("@id").Value = Convert.ToInt32(row.Cells("ID_PALLET").Value)

                    cmd.ExecuteNonQuery()
                Next
            End Using

            transaccion.Commit()

            MessageBox.Show("Los pallets fueron pesados y ubicados correctamente.", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarUbicaciones()
            RaiseEvent LoteGuardadoExitosamente()

        Catch ex As Exception
            If transaccion IsNot Nothing Then transaccion.Rollback()
            MessageBox.Show("Error al guardar en la base de datos." & vbCrLf & "Detalle: " & ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        e.ThrowException = False
    End Sub


End Class
