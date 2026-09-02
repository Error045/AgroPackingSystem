Imports MySql.Data.MySqlClient

Public Class ucCalibradoValidacion
    Inherits System.Windows.Forms.UserControl

    ' 1. La lista donde guardaremos los datos validados
    Private ListaValidados As New List(Of DataRow)

    ' Tabla para manejar los bines disponibles en memoria
    Private dtDisponibles As DataTable

    ' 2. El nuevo evento que envía la lista completa, no solo un registro
    Public Event LoteValidado(lotes As List(Of DataRow))

    Public Sub New()
        InitializeComponent()
        ConfigurarGrid()
    End Sub

    Private Sub ucCalibradoValidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            ' 🟢 Modificado: Ya no pasamos un ID en duro, cargará todos los disponibles en procesos activos
            CargarBinesDisponibles()
        End If
    End Sub

    Private Sub ConfigurarGrid()
        ' --- CONFIGURACIÓN DE LA GRILLA DE BINES ESCANEADOS (dgvContenedores) ---
        dgvContenedores.Columns.Add("ID", "ID Calibrado")
        dgvContenedores.Columns.Add("Proceso", "ID Proceso")
        dgvContenedores.Columns.Add("Producto", "Producto")
        dgvContenedores.Columns.Add("Variedad", "Variedad")
        dgvContenedores.Columns.Add("Calibre", "Calibre")

        Dim colEliminar As New DataGridViewButtonColumn()
        colEliminar.Name = "Eliminar"
        colEliminar.HeaderText = "Acción"
        colEliminar.Text = "❌ Quitar"
        colEliminar.UseColumnTextForButtonValue = True
        colEliminar.Width = 80
        colEliminar.FlatStyle = FlatStyle.Flat
        dgvContenedores.Columns.Add(colEliminar)

        dgvContenedores.AllowUserToAddRows = False
        dgvContenedores.ReadOnly = False
        For Each col As DataGridViewColumn In dgvContenedores.Columns
            col.ReadOnly = True
        Next
    End Sub

    ' 🟢 Modificado: Se quitó el parámetro "idProceso As Integer"
    Private Sub CargarBinesDisponibles()
        Try
            ' La consulta ahora filtra nativamente por estados_procesos_id = 1 (Procesos activos)
            Dim sql As String =
                "SELECT a.id As 'Codigo', prod.nombre As Producto, v.nombre As Variedad, cal.nombre As Calibre " &
                "FROM contenedores a " &
                "INNER JOIN recepciones b ON a.recepciones_id = b.id " &
                "INNER JOIN procesos c ON b.id = c.recepciones_id " &
                "JOIN productos prod ON a.productos_id = prod.id " &
                "JOIN variedades v ON a.variedades_id = v.id " &
                "JOIN calibres cal ON a.calibres_id = cal.id " &
                "WHERE c.estados_procesos_id = 1 AND a.estados_contenedores_id = 4"

            ' 🟢 Modificado: Se quitó el parámetro de la ejecución porque ya no hace falta
            dtDisponibles = ObtenerDatos(sql)

            If dtDisponibles IsNot Nothing Then
                dgvDisponibles.DataSource = dtDisponibles

                ' Ajustes visuales para la grilla de disponibles
                dgvDisponibles.AllowUserToAddRows = False
                dgvDisponibles.ReadOnly = True
                dgvDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvDisponibles.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar bines disponibles: " & ex.Message)
        End Try
    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrWhiteSpace(txtBusqueda.Text) Then Return

            If ListaValidados.Count >= 3 Then
                MessageBox.Show("Has alcanzado el límite máximo de 3 contenedores por ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBusqueda.Clear()
                Return
            End If

            Dim idActual As String = txtBusqueda.Text.Trim()
            If ListaValidados.Any(Function(row) row("id").ToString() = idActual) Then
                MessageBox.Show("Este ticket ya está en la lista de pesaje actual.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBusqueda.Clear()
                Return
            End If

            If Not Me.DesignMode Then
                Try
                    ' Esta consulta ya filtraba correctamente por p.estados_procesos_id = 1, la dejamos igual
                    Dim sql As String = "SELECT c.id, p.id As proceso, prod.nombre As producto, v.nombre As variedad, cal.nombre As calibre, per.nombre As productor " &
                                    "FROM contenedores c " &
                                    "JOIN recepciones r ON c.recepciones_id = r.id " &
                                    "JOIN procesos p ON r.id = p.recepciones_id " &
                                    "JOIN personas per ON r.personas_id = per.id " &
                                    "JOIN productos prod ON c.productos_id = prod.id " &
                                    "JOIN variedades v ON c.variedades_id = v.id " &
                                    "JOIN calibres cal ON c.calibres_id = cal.id " &
                                    "WHERE c.id = @id AND c.estados_contenedores_id = 4 AND p.estados_procesos_id = 1;"

                    Dim dt = ObtenerDatos(sql, {New MySqlParameter("@id", idActual)})

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim row = dt.Rows(0)

                        ListaValidados.Add(row)
                        dgvContenedores.Rows.Add(row("id"), row("proceso"), row("producto"), row("variedad"), row("calibre"))
                        btnProcederPesaje.Enabled = True

                        ' Quitar el bin escaneado de la lista de "Disponibles"
                        If dtDisponibles IsNot Nothing Then
                            Dim filas() As DataRow = dtDisponibles.Select("[Codigo] = " & idActual)
                            For Each filaEncontrada In filas
                                dtDisponibles.Rows.Remove(filaEncontrada)
                            Next
                        End If
                    Else
                        MessageBox.Show("No encontrado, o ya procesado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    txtBusqueda.Clear()
                    txtBusqueda.Focus()

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvContenedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContenedores.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvContenedores.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim idEliminar As String = dgvContenedores.Rows(e.RowIndex).Cells("ID").Value.ToString()

            Dim filaParaBorrar = ListaValidados.FirstOrDefault(Function(row) row("id").ToString() = idEliminar)
            If filaParaBorrar IsNot Nothing Then
                ListaValidados.Remove(filaParaBorrar)

                ' 🟢 Modificado: Ya no pasamos el 9
                CargarBinesDisponibles()
            End If

            dgvContenedores.Rows.RemoveAt(e.RowIndex)
            btnProcederPesaje.Enabled = (ListaValidados.Count > 0)
            txtBusqueda.Focus()
        End If
    End Sub

    Private Sub btnProcederPesaje_Click(sender As Object, e As EventArgs) Handles btnProcederPesaje.Click
        If ListaValidados.Count > 0 Then
            RaiseEvent LoteValidado(ListaValidados)
        End If
    End Sub

    Public Sub Reiniciar()
        ListaValidados.Clear()
        dgvContenedores.Rows.Clear()
        btnProcederPesaje.Enabled = False
        txtBusqueda.Clear()
        txtBusqueda.Focus()

        ' 🟢 Modificado: Ya no pasamos el 9
        CargarBinesDisponibles()
    End Sub


End Class