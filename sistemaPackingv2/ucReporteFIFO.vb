Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1

Public Class ucReporteFIFO

    Private _capacidadTotalPlanta As Integer = 0


    Private Sub ucReporteFIFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarEstiloGrid()
        CargarComboCamaras()
        ActualizarGrid(0, _capacidadTotalPlanta) ' Carga inicial con todas las cámaras


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

    Public Sub ActualizarGrid(idUbicacion As Integer, capacidadMax As Integer)
        Dim sql As String = "SELECT * FROM vw_detalle_tiempos_ubicaciones"
        Dim parametros As MySqlParameter() = Nothing

        If idUbicacion > 0 Then
            sql &= " WHERE id_ubicacion = @id"
            parametros = {New MySqlParameter("@id", idUbicacion)}
        End If

        Dim dt As DataTable = ObtenerDatos(sql, parametros)
        dgvReporte.DataSource = dt

        ' --- CONFIGURACIÓN DE VISUALIZACIÓN DE COLUMNAS ---
        If dgvReporte.Columns.Count > 0 Then
            dgvReporte.Columns("id_bin").Visible = True
            dgvReporte.Columns("id_bin").HeaderText = "ID BIN"
            dgvReporte.Columns("id_bin").Width = 70

            dgvReporte.Columns("Nombre_Ubicacion").HeaderText = "CÁMARA"
            dgvReporte.Columns("Nombre_Calibre").HeaderText = "CALIBRE"
            dgvReporte.Columns("Kilos_Netos").HeaderText = "KILOS"
            dgvReporte.Columns("Horas_En_Camara").HeaderText = "HORAS"
            dgvReporte.Columns("Estado_Alerta").HeaderText = "ESTADO"
            dgvReporte.Columns("Origen_Producto").HeaderText = "ORIGEN"

            ' Ocultamos columnas técnicas (incluyendo funciones_id que viene de la nueva vista)
            If dgvReporte.Columns.Contains("id_ubicacion") Then dgvReporte.Columns("id_ubicacion").Visible = False
            If dgvReporte.Columns.Contains("id_calibre") Then dgvReporte.Columns("id_calibre").Visible = False
            If dgvReporte.Columns.Contains("funciones_id") Then dgvReporte.Columns("funciones_id").Visible = False

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        ' --- CONTROL DE CAPACIDAD Y TEXTOS DE ALERTA ---
        Dim binsActuales As Integer = dgvReporte.Rows.Count

        ' Supongamos que agregas un nuevo Label llamado lblCapacidad al lado de tu lblContador
        lblContador.Text = String.Format("Bins en vista: {0}", binsActuales)

        If idUbicacion > 0 Then
            lblCapacidad.Text = String.Format("Ocupación Cámara: {0} / {1} Bins", binsActuales, capacidadMax)

            ' Evaluamos el estado de llenado de la cámara específica
            If binsActuales >= capacidadMax Then
                lblCapacidad.ForeColor = Color.FromArgb(211, 47, 47) ' Rojo Oscuro
                lblCapacidad.Text &= " - ¡CÁMARA LLENA!"
            ElseIf binsActuales >= (capacidadMax * 0.85) Then
                lblCapacidad.ForeColor = Color.FromArgb(230, 126, 34) ' Naranja
                lblCapacidad.Text &= " - ¡Espacio Crítico!"
            Else
                lblCapacidad.ForeColor = Color.FromArgb(39, 174, 96) ' Verde
            End If
        Else
            ' Si la opción es "TODAS LAS CÁMARAS"
            lblCapacidad.Text = String.Format("Capacidad Total Planta: {0} / {1} Bins", binsActuales, capacidadMax)
            lblCapacidad.ForeColor = Color.FromArgb(44, 62, 80) ' Gris Azulado Estándar
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
End Class
