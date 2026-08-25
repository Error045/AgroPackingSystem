Imports MySql.Data.MySqlClient

Public Class ucOrdenDespachoRepesajeValidacion
        Inherits System.Windows.Forms.UserControl

        Private ListaValidados As New List(Of DataRow)
        Private dtDisponibles As DataTable

        ' Evento que envía la lista al control principal
        Public Event LoteValidado(lotes As List(Of DataRow))

        Public Sub New()
            InitializeComponent()
            ConfigurarGrid()
        End Sub

        Private Sub ucOrdenDespachoRepesajeValidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Not Me.DesignMode Then
                CargarPalletsDisponibles()
            End If
        End Sub

        Private Sub ConfigurarGrid()
            dgvContenedoresOrden.Columns.Add("id", "ID Pallet")
            dgvContenedoresOrden.Columns.Add("despacho", "N° Despacho")
            dgvContenedoresOrden.Columns.Add("numero_cajas", "N° Cajas")
            dgvContenedoresOrden.Columns.Add("tipos_contenedores_id", "ID Tipo Cont.")
            dgvContenedoresOrden.Columns.Add("tipo_contenedor", "Tipo Contenedor")
            dgvContenedoresOrden.Columns.Add("tara", "Tara")
            dgvContenedoresOrden.Columns.Add("kilos_brutos", "Kilos Brutos")
            dgvContenedoresOrden.Columns.Add("kilos_netos", "Kilos Netos")

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

        Private Sub CargarPalletsDisponibles()
            Try
                ' 🟢 CONSULTA DE PALLETS EN DESPACHOS ACTIVOS
                Dim sql As String =
                "SELECT a.id AS 'ID Pallet', c.id AS 'N_Despacho', a.numero_cajas AS 'N_Cajas', " &
                "a.tipos_contenedores_id, tc.nombre AS 'Tipo_Contenedor', tc.tara, a.kilos_brutos, a.kilos_netos " &
                "FROM pallets a " &
                "JOIN despachos_pallets b ON a.id = b.pallets_id " &
                "JOIN despachos c ON b.despachos_id = c.id " &
                "LEFT JOIN tipos_contenedores tc ON a.tipos_contenedores_id = tc.id " &
                "WHERE c.estados_despachos_id = 1"

                dtDisponibles = ConexionBD.ObtenerDatos(sql)

                If dtDisponibles IsNot Nothing Then
                    dgvDisponiblesOrden.DataSource = dtDisponibles
                    dgvDisponiblesOrden.AllowUserToAddRows = False
                    dgvDisponiblesOrden.ReadOnly = True
                    dgvDisponiblesOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    dgvDisponiblesOrden.ClearSelection()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar pallets disponibles: " & ex.Message)
            End Try
        End Sub

        Private Sub txtBusquedaOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusquedaOrden.KeyDown
            If e.KeyCode = Keys.Enter Then
                If String.IsNullOrWhiteSpace(txtBusquedaOrden.Text) Then Return

                If ListaValidados.Count >= 3 Then
                    MessageBox.Show("Límite máximo de 3 pallets por ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtBusquedaOrden.Clear()
                    Return
                End If

                Dim idActual As String = txtBusquedaOrden.Text.Trim()
                If ListaValidados.Any(Function(row) row("id").ToString() = idActual) Then
                    MessageBox.Show("Este pallet ya está en la lista de pesaje.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBusquedaOrden.Clear()
                    Return
                End If

                If Not Me.DesignMode Then
                    Try
                        ' 🟢 CONSULTA PARA VALIDAR UN PALLET ESPECÍFICO
                        Dim sql As String =
                        "SELECT a.id, c.id AS despacho, a.numero_cajas, a.tipos_contenedores_id, " &
                        "tc.nombre AS tipo_contenedor, tc.tara AS tara, a.kilos_brutos, a.kilos_netos " &
                        "FROM pallets a " &
                        "JOIN despachos_pallets b ON a.id = b.pallets_id " &
                        "JOIN despachos c ON b.despachos_id = c.id " &
                        "LEFT JOIN tipos_contenedores tc ON a.tipos_contenedores_id = tc.id " &
                        "WHERE a.id = @id AND c.estados_despachos_id = 1"

                        Dim parametros As MySqlParameter() = {New MySqlParameter("@id", idActual)}
                        Dim dt = ConexionBD.ObtenerDatos(sql, parametros)

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Dim row = dt.Rows(0)
                            ListaValidados.Add(row)

                            dgvContenedoresOrden.Rows.Add(
                            row("id"),
                            row("despacho"),
                            row("numero_cajas"),
                            row("tipos_contenedores_id"),
                            row("tipo_contenedor"),
                            row("tara"),
                            row("kilos_brutos"),
                            row("kilos_netos")
                        )

                            btnProcederPesajeOrden.Enabled = True

                            ' Quitar de la grilla de disponibles visualmente
                            If dtDisponibles IsNot Nothing Then
                                Dim filas() As DataRow = dtDisponibles.Select("[ID Pallet] = " & idActual)
                                For Each filaEncontrada In filas
                                    dtDisponibles.Rows.Remove(filaEncontrada)
                                Next
                            End If
                        Else
                            MessageBox.Show("Pallet no encontrado, inválido o no pertenece a un despacho activo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Dim idEliminar As String = dgvContenedoresOrden.Rows(e.RowIndex).Cells("id").Value.ToString()
                Dim filaParaBorrar = ListaValidados.FirstOrDefault(Function(row) row("id").ToString() = idEliminar)
                If filaParaBorrar IsNot Nothing Then
                    ListaValidados.Remove(filaParaBorrar)
                    CargarPalletsDisponibles()
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
            CargarPalletsDisponibles()
        End Sub
    End Class


