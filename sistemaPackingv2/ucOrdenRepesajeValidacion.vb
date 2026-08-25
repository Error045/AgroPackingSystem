Imports MySql.Data.MySqlClient

Public Class ucOrdenRepesajeValidacion
        Inherits System.Windows.Forms.UserControl

        Private ListaValidados As New List(Of DataRow)
        Private dtDisponibles As DataTable

        ' Evento que envía la lista al control principal
        Public Event LoteValidado(lotes As List(Of DataRow))

        Public Sub New()
            InitializeComponent()
            ConfigurarGrid()
        End Sub

        Private Sub ucOrdenRepesajeValidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then

            CargarBinesDisponibles()
        End If

    End Sub

        Private Sub ConfigurarGrid()
        dgvContenedoresOrden.Columns.Add("ID", "ID Ticket")
        dgvContenedoresOrden.Columns.Add("Proceso", "ID Proceso")
        dgvContenedoresOrden.Columns.Add("Producto", "Producto")
        dgvContenedoresOrden.Columns.Add("Variedad", "Variedad")
        dgvContenedoresOrden.Columns.Add("Calibre", "Calibre")
        dgvContenedoresOrden.Columns.Add("tipos_contenedores_id", "Tipo Contenedor")
        dgvContenedoresOrden.Columns.Add("tara", "Tara")
        dgvContenedoresOrden.Columns.Add("kilos_brutos", "kilos brutos")
        dgvContenedoresOrden.Columns.Add("kilos_netos", "kilos netos")



        Dim colEliminar As New DataGridViewButtonColumn()
            colEliminar.Name = "Eliminar"
            colEliminar.HeaderText = "Acción"
            colEliminar.Text = "❌ Quitar"
            colEliminar.UseColumnTextForButtonValue = True
            colEliminar.Width = 80
            colEliminar.FlatStyle = FlatStyle.Flat
        dgvContenedoresOrden.Columns.Add(colEliminar)

        dgvContenedoresOrden.AllowUserToAddRows = False
        dgvContenedoresOrden.ReadOnly = False
        For Each col As DataGridViewColumn In dgvContenedoresOrden.Columns
            col.ReadOnly = True
        Next
    End Sub

        Private Sub CargarBinesDisponibles()
            Try
            ' 🟢 TU NUEVA CONSULTA DE DISPONIBLES
            Dim sql As String =
                    "SELECT a.id As 'ID Ticket', prod.nombre As Producto, v.nombre As Variedad, cal.nombre As Calibre,a.tipos_contenedores_id,tc.nombre As Tipo_Contenedor,a.kilos_brutos,a.kilos_netos, eb.nombre as Estado " &
                    "FROM contenedores a " &
                    "INNER JOIN procesos_bines_origen b ON a.id = b.contenedores_id " &
                    "INNER JOIN procesos_paletizado c ON b.procesos_paletizado_id = c.id " &
                    "INNER JOIN estados_bines eb ON b.estados_bines_id = eb.id " &
                    "JOIN productos prod ON a.productos_id = prod.id " &
                    "JOIN variedades v ON a.variedades_id = v.id " &
                    "JOIN calibres cal ON a.calibres_id = cal.id " &
                    "JOIN tipos_contenedores tc ON a.tipos_contenedores_id = tc.id " &
                    "WHERE c.estados_procesos_pallets_id = 1 " &
                    "ORDER BY b.estados_bines_id DESC"
            'AND a.estados_contenedores_id = 16
            dtDisponibles = ConexionBD.ObtenerDatos(sql)

                If dtDisponibles IsNot Nothing Then
                dgvDisponiblesOrden.DataSource = dtDisponibles
                dgvDisponiblesOrden.AllowUserToAddRows = False
                dgvDisponiblesOrden.ReadOnly = True
                dgvDisponiblesOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvDisponiblesOrden.ClearSelection()
            End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar bines disponibles: " & ex.Message)
            End Try
        End Sub

    Private Sub txtBusquedaOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusquedaOrden.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrWhiteSpace(txtBusquedaOrden.Text) Then Return

            If ListaValidados.Count >= 3 Then
                MessageBox.Show("Límite máximo de 3 contenedores por ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBusquedaOrden.Clear()
                Return
            End If

            Dim idActual As String = txtBusquedaOrden.Text.Trim()
            If ListaValidados.Any(Function(row) row("id").ToString() = idActual) Then
                MessageBox.Show("Este ticket ya está en la lista de pesaje.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBusquedaOrden.Clear()
                Return
            End If

            If Not Me.DesignMode Then
                Try
                    ' 🟢 TU NUEVA CONSULTA ADAPTADA PARA VALIDAR UN BIN ESPECÍFICO
                    Dim sql As String =
                            "SELECT a.id, c.id As proceso, prod.nombre As producto, v.nombre As variedad, cal.nombre As calibre,a.recepciones_id, a.tipos_contenedores_id,tc.tara As tara,a.kilos_brutos,a.kilos_netos, b.estados_bines_id " &
                            "FROM contenedores a " &
                            "INNER JOIN procesos_bines_origen b ON a.id = b.contenedores_id " &
                            "INNER JOIN procesos_paletizado c ON b.procesos_paletizado_id = c.id " &
                            "JOIN productos prod ON a.productos_id = prod.id " &
                            "JOIN variedades v ON a.variedades_id = v.id " &
                            "JOIN calibres cal ON a.calibres_id = cal.id " &
                            "JOIN tipos_contenedores tc ON a.tipos_contenedores_id = tc.id " &
                            "WHERE a.id = @id AND c.estados_procesos_pallets_id = 1 AND a.estados_contenedores_id = 16"

                    Dim parametros As MySqlParameter() = {New MySqlParameter("@id", idActual)}
                    Dim dt = ConexionBD.ObtenerDatos(sql, parametros)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim row = dt.Rows(0)

                        ListaValidados.Add(row)
                        ' 🟢 Se envían solo las 5 columnas visibles configuradas en la grilla (ID, Proceso, Producto, Variedad, Calibre)
                        dgvContenedoresOrden.Rows.Add(
                    row("id"),
                    row("proceso"),
                    row("producto"),
                    row("variedad"),
                    row("calibre")
                )

                        btnProcederPesajeOrden.Enabled = True

                        ' Quitar de la grilla de disponibles visualmente
                        If dtDisponibles IsNot Nothing Then
                            Dim filas() As DataRow = dtDisponibles.Select("[ID Ticket] = " & idActual)
                            For Each filaEncontrada In filas
                                dtDisponibles.Rows.Remove(filaEncontrada)
                            Next
                        End If
                    Else
                        MessageBox.Show("Bin no encontrado, inválido o no pertenece a un proceso activo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    txtBusquedaOrden.Clear()
                    txtBusquedaOrden.Focus()

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvContenedoresOrden_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContenedoresOrden.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvContenedoresOrden.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim idEliminar As String = dgvContenedoresOrden.Rows(e.RowIndex).Cells("ID").Value.ToString()
            Dim filaParaBorrar = ListaValidados.FirstOrDefault(Function(row) row("id").ToString() = idEliminar)
            If filaParaBorrar IsNot Nothing Then
                ListaValidados.Remove(filaParaBorrar)
                CargarBinesDisponibles() ' Recarga para volver a mostrar el bin en la lista de abajo
            End If

            dgvContenedoresOrden.Rows.RemoveAt(e.RowIndex)
            btnProcederPesajeOrden.Enabled = (ListaValidados.Count > 0)
            txtBusquedaOrden.Focus()
        End If
    End Sub

    Private Sub btnProcederPesajeOrden_Click(sender As Object, e As EventArgs) Handles btnProcederPesajeOrden.Click
        If ListaValidados.Count > 0 Then
            RaiseEvent LoteValidado(ListaValidados)
        End If
    End Sub

    Public Sub Reiniciar()
            ListaValidados.Clear()
        dgvContenedoresOrden.Rows.Clear()
        btnProcederPesajeOrden.Enabled = False
        txtBusquedaOrden.Clear()
        txtBusquedaOrden.Focus()
        CargarBinesDisponibles()
        End Sub
    End Class

