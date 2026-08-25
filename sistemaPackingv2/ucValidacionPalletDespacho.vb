Imports MySql.Data.MySqlClient

Public Class ucValidacionPalletDespacho

    Inherits System.Windows.Forms.UserControl

    ' 1. La lista donde guardaremos los datos validados
    Private ListaValidados As New List(Of DataRow)

    ' Tabla para manejar los pallets disponibles en memoria
    Private dtDisponibles As DataTable

    ' 2. El evento que envía la lista completa a la siguiente fase
    Public Event PalletValidado(lotes As List(Of DataRow))

    Public Sub New()
        InitializeComponent()
        ConfigurarGrid()
    End Sub

    Private Sub ucValidacionPalletDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            btnProcederPesaje.Enabled = False
            ' Ahora la carga puede ser automática porque la BD sabe cuál es el proceso activo
            CargarPalletsDisponibles()
        End If
    End Sub

    Private Sub ConfigurarGrid()
        ' --- CONFIGURACIÓN DE LA GRILLA DE PALLETS ESCANEADOS ---
        dgvContenedores.Columns.Clear()

        dgvContenedores.Columns.Add("ID_Pallet", "ID Pallet")
        dgvContenedores.Columns.Add("Proceso", "Proceso Paletizado")
        dgvContenedores.Columns.Add("Tipo_Pallet", "Tipo Pallet")
        dgvContenedores.Columns.Add("Tara_Pallet", "Tara Pallet")
        dgvContenedores.Columns.Add("Cajas", "N° Cajas")
        dgvContenedores.Columns.Add("Tipo_Caja", "Tipo Caja")
        dgvContenedores.Columns.Add("Tara_Caja", "Tara Caja")
        dgvContenedores.Columns.Add("Capacidad", "Capacidad")
        dgvContenedores.Columns.Add("Kilos", "Kilos Netos")

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
            If col.Name <> "Eliminar" Then col.ReadOnly = True
        Next
    End Sub

    ' 🟢 Carga la lista de pallets disponibles según el Proceso ACTIVO en la BD
    Public Sub CargarPalletsDisponibles()
        Try
            ' Tu nueva consulta sin parámetros externos, filtrando por e.estados_procesos_pallets_id = 1
            Dim sql As String =
                "SELECT DISTINCT a.id AS ID_Pallet, " &
                "a.procesos_paletizado_id As Proceso, " &
                "a.tipos_contenedores_id as Tipo_Pallet, " &
                "c.tara As Tara_Pallet, " &
                "a.numero_cajas AS Cajas, " &
                "b.tipos_contenedores_id As Tipo_Caja, " &
                "d.tara As Tara_Caja, " &
                "a.capacidad As Capacidad, " &
                "a.kilos_netos AS Kilos " &
                "FROM pallets a " &
                "JOIN cajas b ON a.id = b.pallet_id " &
                "JOIN tipos_contenedores c ON a.tipos_contenedores_id = c.id " &
                "JOIN tipos_contenedores d ON b.tipos_contenedores_id = d.id " &
                "JOIN procesos_paletizado e ON a.procesos_paletizado_id = e.id " &
                "WHERE  a.estados_contenedores_id = 14 ;"

            ' Ya no enviamos parámetros aquí
            dtDisponibles = ObtenerDatos(sql)

            If dtDisponibles IsNot Nothing Then
                dgvDisponibles.DataSource = dtDisponibles
                dgvDisponibles.AllowUserToAddRows = False
                dgvDisponibles.ReadOnly = True
                dgvDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvDisponibles.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar pallets disponibles: " & ex.Message)
        End Try
    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrWhiteSpace(txtBusqueda.Text) Then Return

            If ListaValidados.Count >= 3 Then
                MessageBox.Show("Has alcanzado el límite máximo de 3 pallets por ciclo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBusqueda.Clear()
                Return
            End If

            Dim idActual As String = txtBusqueda.Text.Trim()

            If ListaValidados.Any(Function(row) row("ID_Pallet").ToString() = idActual) Then
                MessageBox.Show("Este pallet ya está en la lista actual.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBusqueda.Clear()
                Return
            End If

            If Not Me.DesignMode Then
                Try
                    ' Validación extra: Asegurarnos de que el pallet escaneado PERTENEZCA a un proceso ACTIVO (estado 1)
                    Dim sql As String =
                        "SELECT DISTINCT a.id AS ID_Pallet, " &
                        "a.procesos_paletizado_id As Proceso, " &
                        "a.tipos_contenedores_id as Tipo_Pallet, " &
                        "c.tara As Tara_Pallet, " &
                        "a.numero_cajas AS Cajas, " &
                        "b.tipos_contenedores_id As Tipo_Caja, " &
                        "d.tara As Tara_Caja, " &
                        "a.capacidad As Capacidad, " &
                        "a.kilos_netos AS Kilos " &
                        "FROM pallets a " &
                        "JOIN cajas b ON a.id = b.pallet_id " &
                        "JOIN tipos_contenedores c ON a.tipos_contenedores_id = c.id " &
                        "JOIN tipos_contenedores d ON b.tipos_contenedores_id = d.id " &
                        "JOIN procesos_paletizado e ON a.procesos_paletizado_id = e.id " &
                        "WHERE a.estados_contenedores_id = 14;"

                    ' Solo necesitamos el ID escaneado como parámetro
                    Dim parametros As MySqlParameter() = {
                        New MySqlParameter("@id", idActual)
                    }

                    Dim dt = ObtenerDatos(sql, parametros)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim row = dt.Rows(0)
                        ListaValidados.Add(row)

                        dgvContenedores.Rows.Add(
                            row("ID_Pallet"),
                            row("Proceso"),
                            row("Tipo_Pallet"),
                            row("Tara_Pallet"),
                            row("Cajas"),
                            row("Tipo_Caja"),
                            row("Tara_Caja"),
                            row("Capacidad"),
                            row("Kilos")
                        )
                        btnProcederPesaje.Enabled = True

                        If dtDisponibles IsNot Nothing Then
                            Dim filas() As DataRow = dtDisponibles.Select("[ID_Pallet] = '" & idActual & "'")
                            For Each filaEncontrada In filas
                                dtDisponibles.Rows.Remove(filaEncontrada)
                            Next
                        End If
                    Else
                        MessageBox.Show("Pallet no encontrado, pertenece a un proceso cerrado, o no está disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    txtBusqueda.Clear()
                    txtBusqueda.Focus()

                Catch ex As Exception
                    MessageBox.Show("Error en búsqueda: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvContenedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContenedores.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvContenedores.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim idEliminar As String = dgvContenedores.Rows(e.RowIndex).Cells("ID_Pallet").Value.ToString()

            Dim filaParaBorrar = ListaValidados.FirstOrDefault(Function(row) row("ID_Pallet").ToString() = idEliminar)
            If filaParaBorrar IsNot Nothing Then
                ListaValidados.Remove(filaParaBorrar)

                ' Recargamos la grilla
                CargarPalletsDisponibles()
            End If

            dgvContenedores.Rows.RemoveAt(e.RowIndex)
            btnProcederPesaje.Enabled = (ListaValidados.Count > 0)
            txtBusqueda.Focus()
        End If
    End Sub

    Private Sub btnProcederPesaje_Click(sender As Object, e As EventArgs) Handles btnProcederPesaje.Click
        If ListaValidados.Count > 0 Then
            RaiseEvent PalletValidado(ListaValidados)
        End If
    End Sub

    ' Método de reinicio por si el operador cancela el pesaje y vuelve atrás
    Public Sub Reiniciar()
        ListaValidados.Clear()
        dgvContenedores.Rows.Clear()
        btnProcederPesaje.Enabled = False
        txtBusqueda.Clear()
        txtBusqueda.Focus()

        CargarPalletsDisponibles()
    End Sub



End Class
