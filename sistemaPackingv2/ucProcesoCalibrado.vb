Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports ZXing

Public Class ucProcesoCalibrado

    ' --- VARIABLE CLAVE ---
    ' Esta bandera evita que los eventos se disparen mientras llenamos o seteamos datos
    Private cargando As Boolean = True

    ' --- VARIABLES PARA EDICIÓN ---
    Private idContenedorEditar As Integer = 0
    Private modoEdicion As Boolean = False

    ' 1. CARGA INICIAL
    Private Sub ucProcesoCalibrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarDGV()
        CargarComboProceso()
    End Sub

    ' =========================================================================
    ' ====================== CONFIGURACIÓN Y CARGA DGV ========================
    ' =========================================================================

    Private Sub ConfigurarDGV()
        dgvRegistros.AutoGenerateColumns = False
        dgvRegistros.Columns.Clear()

        ' Columnas Ocultas con los IDs requeridos para la edición
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "productos_id", .DataPropertyName = "productos_id", .Visible = False})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "variedades_id", .DataPropertyName = "variedades_id", .Visible = False})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "calibres_id", .DataPropertyName = "calibres_id", .Visible = False})

        ' Columnas Visibles (Se define explícitamente el .Name para acceder mediante Cells("nombre"))
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "codigo", .DataPropertyName = "codigo", .HeaderText = "ID", .Width = 50})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "producto", .DataPropertyName = "producto", .HeaderText = "Producto", .Width = 120})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "variedad", .DataPropertyName = "variedad", .HeaderText = "Variedad", .Width = 120})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "calibre", .DataPropertyName = "calibre", .HeaderText = "Calibre", .Width = 100})
        dgvRegistros.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "fecha", .DataPropertyName = "fecha", .HeaderText = "Fecha", .Width = 100})

        ' Botón Modificar
        Dim btnModificar As New DataGridViewButtonColumn()
        btnModificar.HeaderText = "Editar"
        btnModificar.Name = "btnModificar"
        btnModificar.Text = "✏️ Modificar"
        btnModificar.UseColumnTextForButtonValue = True
        btnModificar.Width = 90
        dgvRegistros.Columns.Add(btnModificar)

        ' Botón Imprimir
        Dim btnImprimir As New DataGridViewButtonColumn()
        btnImprimir.HeaderText = "Imprimir"
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Text = "🖨️️ Imprimir"
        btnImprimir.UseColumnTextForButtonValue = True
        btnImprimir.Width = 90
        dgvRegistros.Columns.Add(btnImprimir)
    End Sub

    Private Sub CargarDGV()
        If cargando Then Return
        If cmbProceso.SelectedValue Is Nothing OrElse Not IsNumeric(cmbProceso.SelectedValue) Then Return

        Try
            ' CORRECCIÓN: Se añaden los campos c.productos_id, c.variedades_id y c.calibres_id
            Dim sql As String = "SELECT v.codigo, c.productos_id, c.variedades_id, c.calibres_id, v.producto, v.variedad, v.calibre, v.fecha " &
                                "FROM vw_calibrado_detalles_resumen v " &
                                "JOIN contenedores c ON v.codigo = c.id " &
                                "JOIN procesos_recepciones pr ON c.recepciones_id = pr.recepciones_id " &
                                "WHERE v.estados_contenedores_id = 4 AND pr.procesos_id = @idProc " &
                                "ORDER BY v.codigo DESC"

            Dim dtRegistros As DataTable = ObtenerDatos(sql, {New MySqlParameter("@idProc", cmbProceso.SelectedValue)})
            dgvRegistros.DataSource = dtRegistros
        Catch ex As Exception
            MessageBox.Show("Error al cargar la grilla: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' ====================== EVENTOS DEL DATAGRIDVIEW =========================
    ' =========================================================================

    Private Sub dgvRegistros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistros.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim colName As String = dgvRegistros.Columns(e.ColumnIndex).Name

        ' Botón Modificar
        If colName = "btnModificar" Then
            idContenedorEditar = Convert.ToInt32(dgvRegistros.Rows(e.RowIndex).Cells("codigo").Value)

            ' Leer los IDs ocultos de la fila
            Dim prodId As Object = dgvRegistros.Rows(e.RowIndex).Cells("productos_id").Value
            Dim varId As Object = dgvRegistros.Rows(e.RowIndex).Cells("variedades_id").Value
            Dim calId As Object = dgvRegistros.Rows(e.RowIndex).Cells("calibres_id").Value

            ' CORRECCIÓN: Carga en cascada controlada paso a paso
            cargando = True
            cmbProducto.SelectedValue = prodId
            cargando = False
            LlenarComboVariedad()

            cargando = True
            cmbVariedad.SelectedValue = varId
            cargando = False
            LlenarComboCalibre()

            cmbCalibre.SelectedValue = calId

            ' Configurar la interfaz para modo edición
            ConfigurarModoUI(esModoEdicion:=True)

            ' Botón Imprimir
        ElseIf colName = "btnImprimir" Then
            Dim idContenedor As Integer = Convert.ToInt32(dgvRegistros.Rows(e.RowIndex).Cells("codigo").Value)
            ImprimirTicket(idContenedor)
        End If
    End Sub

    ' =========================================================================
    ' ====================== MÉTODOS Y COMBOS DE INTERFAZ =====================
    ' =========================================================================

    Private Sub ConfigurarModoUI(esModoEdicion As Boolean)
        modoEdicion = esModoEdicion
        btnRegistrar.Visible = Not esModoEdicion
        btnActualizar.Visible = esModoEdicion
        btnCancelar.Visible = esModoEdicion

        If esModoEdicion Then
            lblTituloEstado.Text = "Modificando Registro..."
        Else
            lblTituloEstado.Text = "Nuevo Registro"
            LimpiarFormulario()
        End If
    End Sub

    Private Sub LimpiarFormulario()
        idContenedorEditar = 0
        cmbProducto.SelectedIndex = -1
        cmbVariedad.SelectedIndex = -1
        cmbCalibre.SelectedIndex = -1
    End Sub

    Private Sub CargarComboProceso()
        cargando = True

        Dim sqlProceso As String = "SELECT p.id, CONCAT(p.id, ' - ', per.nombre) as nombre " &
                                   "FROM procesos p " &
                                   "JOIN procesos_recepciones pr ON p.id = pr.procesos_id " &
                                   "JOIN recepciones r ON pr.recepciones_id = r.id " &
                                   "JOIN personas per ON r.personas_id = per.id " &
                                   "WHERE p.estados_procesos_id = 1 " &
                                   "GROUP BY p.id"

        Dim dtProceso As DataTable = ObtenerDatos(sqlProceso)

        cmbProceso.DataSource = dtProceso
        cmbProceso.DisplayMember = "nombre"
        cmbProceso.ValueMember = "id"
        cmbProceso.SelectedIndex = -1

        cargando = False

        LlenarComboProducto()
        CargarDGV()
    End Sub

    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        If cargando Then Return
        LlenarComboProducto()
        CargarDGV()
    End Sub

    Private Sub LlenarComboProducto()
        cargando = True

        cmbProducto.DataSource = Nothing
        cmbVariedad.DataSource = Nothing

        If cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT p.id, p.nombre " &
                                "FROM productos p " &
                                "JOIN contenedores c ON p.id = c.productos_id " &
                                "JOIN procesos_recepciones pr ON c.recepciones_id = pr.recepciones_id " &
                                "WHERE pr.procesos_id = @idProc " &
                                "GROUP BY p.id;"

            Dim param As New MySqlParameter("@idProc", idProceso)
            Dim dtProductos As DataTable = ObtenerDatos(sql, {param})

            cmbProducto.DataSource = dtProductos
            cmbProducto.DisplayMember = "nombre"
            cmbProducto.ValueMember = "id"

            If dtProductos.Rows.Count > 0 Then
                cmbProducto.SelectedIndex = 0
            Else
                cmbProducto.SelectedIndex = -1
            End If
        End If

        cargando = False
        LlenarComboVariedad()
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cargando Then Return
        LlenarComboVariedad()
    End Sub

    Private Sub LlenarComboVariedad()
        cargando = True

        cmbVariedad.DataSource = Nothing
        cmbCalibre.DataSource = Nothing

        If cmbProducto.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProducto.SelectedValue) AndAlso cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProducto As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT v.id, v.nombre " &
                                "FROM variedades v " &
                                "JOIN contenedores c ON v.id = c.variedades_id " &
                                "JOIN procesos_recepciones pr ON c.recepciones_id = pr.recepciones_id " &
                                "WHERE pr.procesos_id = @idProc AND c.productos_id = @idProd " &
                                "GROUP BY v.id"

            Dim p1 As New MySqlParameter("@idProc", idProceso)
            Dim p2 As New MySqlParameter("@idProd", idProducto)
            Dim dtVariedades As DataTable = ObtenerDatos(sql, {p1, p2})

            cmbVariedad.DataSource = dtVariedades
            cmbVariedad.DisplayMember = "nombre"
            cmbVariedad.ValueMember = "id"

            If dtVariedades.Rows.Count > 0 Then
                cmbVariedad.SelectedIndex = 0
            Else
                cmbVariedad.SelectedIndex = -1
            End If
        End If

        cargando = False
        LlenarComboCalibre()
    End Sub

    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        If cargando Then Return
        LlenarComboCalibre()
    End Sub

    Private Sub LlenarComboCalibre()
        cargando = True
        cmbCalibre.DataSource = Nothing

        If cmbVariedad.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbVariedad.SelectedValue) Then
            Dim idVariedad As Integer = Convert.ToInt32(cmbVariedad.SelectedValue)

            Dim sqlCalibre As String = "SELECT id, nombre FROM calibres WHERE variedades_id = @varId"
            Dim dtCalibres As DataTable = ObtenerDatos(sqlCalibre, {New MySqlParameter("@varId", idVariedad)})

            cmbCalibre.DisplayMember = "nombre"
            cmbCalibre.ValueMember = "id"
            cmbCalibre.DataSource = dtCalibres
            cmbCalibre.SelectedIndex = -1
        End If

        cargando = False
    End Sub

    Private Sub cmbCalibre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalibre.SelectedIndexChanged
        If cargando Then Return
    End Sub

    ' =========================================================================
    ' ====================== BARRAS DE ACCIONES (CRUD) ========================
    ' =========================================================================

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If idContenedorEditar = 0 Then
            MessageBox.Show("No se ha seleccionado ningún registro para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbProducto.SelectedIndex = -1 OrElse cmbVariedad.SelectedIndex = -1 OrElse cmbCalibre.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar Producto, Variedad y Calibre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim sqlUpdate As String = "UPDATE contenedores SET " &
                                      "productos_id = @prodId, " &
                                      "variedades_id = @varId, " &
                                      "calibres_id = @calId, " &
                                      "updated_at = NOW() " &
                                      "WHERE id = @idContenedor"

            ConexionBD.Abrir()
            Using cmd As New MySqlCommand(sqlUpdate, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@prodId", cmbProducto.SelectedValue)
                cmd.Parameters.AddWithValue("@varId", cmbVariedad.SelectedValue)
                cmd.Parameters.AddWithValue("@calId", cmbCalibre.SelectedValue)
                cmd.Parameters.AddWithValue("@idContenedor", idContenedorEditar)

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ImprimirTicket(idContenedorEditar)
                Else
                    MessageBox.Show("No se encontró el registro para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al actualizar el registro: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try

        ConfigurarModoUI(esModoEdicion:=False)
        CargarDGV()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ConfigurarModoUI(esModoEdicion:=False)
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim errorMensaje As String = ""
        If cmbProceso.SelectedValue Is Nothing OrElse cmbProceso.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Proceso." & vbCrLf
        If cmbProducto.SelectedValue Is Nothing OrElse cmbProducto.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Producto." & vbCrLf
        If cmbVariedad.SelectedValue Is Nothing OrElse cmbVariedad.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar una Variedad." & vbCrLf
        If cmbCalibre.SelectedValue Is Nothing OrElse cmbCalibre.SelectedIndex = -1 Then errorMensaje &= "- Debe seleccionar un Calibre." & vbCrLf

        If Not String.IsNullOrEmpty(errorMensaje) Then
            MessageBox.Show("Faltan datos requeridos:" & vbCrLf & vbCrLf & errorMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
        Dim idVariedad As Integer = Convert.ToInt32(cmbVariedad.SelectedValue)
        Dim idCalibre As Integer = Convert.ToInt32(cmbCalibre.SelectedValue)

        Dim nuevoIdContenedor As Integer = 0

        Try
            ConexionBD.Abrir()

            Dim sqlContenedor As String = "INSERT INTO contenedores (recepciones_id, productos_id, variedades_id, calibres_id, tipos_ubicaciones_id, estados_contenedores_id, fecha_registro, users_id_registro, estado, created_at, updated_at) " &
                                          "SELECT pr.recepciones_id, @prodId, @varId, @calId, 3, 4, NOW(), 1, 1, NOW(), NOW() " &
                                          "FROM procesos_recepciones pr " &
                                          "JOIN contenedores c ON pr.recepciones_id = c.recepciones_id " &
                                          "WHERE pr.procesos_id = @procId AND c.productos_id = @prodId AND c.variedades_id = @varId " &
                                          "LIMIT 1; " &
                                          "SELECT LAST_INSERT_ID();"

            Using cmd As New MySqlCommand(sqlContenedor, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@procId", idProceso)
                cmd.Parameters.AddWithValue("@prodId", idProducto)
                cmd.Parameters.AddWithValue("@varId", idVariedad)
                cmd.Parameters.AddWithValue("@calId", idCalibre)

                nuevoIdContenedor = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim sqlHistorial As String = "INSERT INTO contenedores_historial (tipos_movimientos_id, contenedores_id, tipos_ubicaciones_id, estados_contenedores_id, fecha_movimiento, users_id, estado, created_at, updated_at) " &
                                         "VALUES (1, @idCont, 3, 4, NOW(), 1, 1, NOW(), NOW());"

            Using cmd2 As New MySqlCommand(sqlHistorial, ConexionBD.conexion)
                cmd2.Parameters.AddWithValue("@idCont", nuevoIdContenedor)
                cmd2.ExecuteNonQuery()
            End Using

            ConexionBD.Cerrar()

            If nuevoIdContenedor > 0 Then
                ImprimirTicket(nuevoIdContenedor)
                cmbCalibre.SelectedIndex = -1
                CargarDGV()
            Else
                MessageBox.Show("No se pudo obtener el ID asignado al contenedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            If ConexionBD.conexion.State = ConnectionState.Open Then ConexionBD.Cerrar()
            MessageBox.Show("Error al guardar/imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================================
    ' ====================== MÉTODOS DE IMPRESIÓN =============================
    ' =========================================================================

    ' =========================================================================
    ' ====================== MÉTODOS DE IMPRESIÓN =============================
    ' =========================================================================

    Private Function GenerarImagenBarcode(texto As String) As Bitmap
        Try
            Dim escritor As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128
            }
            escritor.Options = New Common.EncodingOptions With {
                .Width = 350,
                .Height = 100,
                .Margin = 2
            }
            Return escritor.Write(texto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub DisenoTicketQR_Grande(e As PrintPageEventArgs, datos As Dictionary(Of String, String))
        Dim anchoPapel As Integer = 394
        Dim x As Integer = 20
        Dim y As Integer = 8 ' Posición superior máxima

        ' Fuentes ajustadas con Calibre en tamaño ultra gigante (110pt)
        Using fTitulo As New Font("Arial", 11, FontStyle.Bold),
              fCalibreGrande As New Font("Arial", 110, FontStyle.Bold), ' Calibre ultra gigante
              fMedium As New Font("Arial", 24, FontStyle.Bold),        ' Fecha y Responsable
              fDatosLabel As New Font("Arial", 9, FontStyle.Bold),
              fDatosValor As New Font("Arial", 9),
              fTimestamp As New Font("Arial", 8, FontStyle.Italic)

            Dim codigoBin As String = datos("codigo")

            ' -----------------------------------------------------------------
            ' 1. LOGO DE LA EMPRESA (COMPACTO)
            ' -----------------------------------------------------------------
            Dim imagenCargada As Boolean = False
            Try
                Dim imgLogo As Image = My.Resources.logo
                If imgLogo IsNot Nothing Then
                    Dim anchoImg As Integer = 140
                    Dim altoImg As Integer = 42
                    Dim xImg As Single = (anchoPapel - anchoImg) / 2

                    e.Graphics.DrawImage(imgLogo, xImg, CSng(y), CSng(anchoImg), CSng(altoImg))
                    y += altoImg + 4
                    imagenCargada = True
                End If
            Catch
                imagenCargada = False
            End Try

            If Not imagenCargada Then
                Dim titulo As String = "PALTAS EL CHEJO"
                Dim tamTitulo = e.Graphics.MeasureString(titulo, fTitulo)
                Dim xTitulo As Single = (anchoPapel - tamTitulo.Width) / 2
                e.Graphics.DrawString(titulo, fTitulo, Brushes.Black, xTitulo, CSng(y))
                y += CInt(tamTitulo.Height) + 4
            End If

            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 4

            ' -----------------------------------------------------------------
            ' 2. CALIBRE ULTRA GIGANTE (110pt)
            ' -----------------------------------------------------------------
            Dim nombreCalibre As String = datos("calibre")

            Dim tamCalNum = e.Graphics.MeasureString(nombreCalibre, fCalibreGrande)
            e.Graphics.DrawString(nombreCalibre, fCalibreGrande, Brushes.Black, (anchoPapel - tamCalNum.Width) / 2, CSng(y))
            y += CInt(tamCalNum.Height) + 2

            ' -----------------------------------------------------------------
            ' 3. FECHA Y PERSONA (DESTACADOS)
            ' -----------------------------------------------------------------
            Dim textoFecha As String = $"FECHA: {datos("fecha")}"
            Dim tamFecha = e.Graphics.MeasureString(textoFecha, fMedium)
            e.Graphics.DrawString(textoFecha, fMedium, Brushes.Black, (anchoPapel - tamFecha.Width) / 2, CSng(y))
            y += CInt(tamFecha.Height) + 2

            Dim nombrePersona As String = datos("productor")
            If Not String.IsNullOrEmpty(nombrePersona) Then
                Dim textoPersona As String = $"RESP: {nombrePersona}"
                Dim tamPersona = e.Graphics.MeasureString(textoPersona, fMedium)
                e.Graphics.DrawString(textoPersona, fMedium, Brushes.Black, (anchoPapel - tamPersona.Width) / 2, CSng(y))
                y += CInt(tamPersona.Height) + 8
            Else
                y += 6
            End If

            e.Graphics.DrawLine(Pens.Black, x, y, anchoPapel - x, y)
            y += 8

            ' -----------------------------------------------------------------
            ' 4. DATOS NORMALES EN PEQUEÑO
            ' -----------------------------------------------------------------
            Dim lineasDatos As New Dictionary(Of String, String) From {
                {"Código ID:", codigoBin},
                {"Recepción:", datos("recepcion")},
                {"Tipo:", datos("tipo")},
                {"Proceso:", datos("proceso")},
                {"Producto:", datos("producto")},
                {"Variedad:", datos("variedad")},
                {"N° Calibre:", datos("numero")}
            }

            Dim posXValor As Integer = 120
            For Each item In lineasDatos
                e.Graphics.DrawString(item.Key, fDatosLabel, Brushes.Black, x, CSng(y))
                e.Graphics.DrawString(item.Value, fDatosValor, Brushes.Black, posXValor, CSng(y))
                y += 17
            Next

            y += 6

            ' -----------------------------------------------------------------
            ' 5. CÓDIGO DE BARRAS INFERIOR
            ' -----------------------------------------------------------------
            Using bmpBarcode As Bitmap = GenerarImagenBarcode(codigoBin)
                If bmpBarcode IsNot Nothing Then
                    Dim anchoBarcode As Integer = anchoPapel - (x * 2)
                    Dim altoBarcode As Integer = 55
                    e.Graphics.DrawImage(bmpBarcode, x, y, anchoBarcode, altoBarcode)
                    y += altoBarcode + 6
                End If
            End Using

            ' -----------------------------------------------------------------
            ' 6. TIMBRE DE FECHA DE REGISTRO
            ' -----------------------------------------------------------------
            e.Graphics.DrawLine(Pens.Gray, x, y, anchoPapel - x, y)
            y += 3

            Dim textoTimbre As String = $"REGISTRO: {datos("fecha")} {datos("hora")}"
            Dim tamTimbre = e.Graphics.MeasureString(textoTimbre, fTimestamp)
            e.Graphics.DrawString(textoTimbre, fTimestamp, Brushes.Black, (anchoPapel - tamTimbre.Width) / 2, CSng(y))

        End Using
    End Sub

    Private Sub ImprimirTicket(idContenedor As Integer)
        Try
            Dim sqlVista As String =
                "SELECT " &
                "    a.id AS codigo, " &
                "    a.recepciones_id AS recepcion, " &
                "    j.tipo AS tipo, " &
                "    k.id AS proceso, " &
                "    h.nombre AS productor, " &
                "    b.nombre AS producto, " &
                "    c.nombre AS variedad, " &
                "    a.kilos_brutos AS bruto, " &
                "    a.kilos_netos AS neto, " &
                "    a.ciclo AS ciclo, " &
                "    g.prefijo AS prefijo, " &
                "    i.nombre AS calibre, " &
                "    i.numero AS numero, " &
                "    a.estados_contenedores_id AS estados_contenedores_id, " &
                "    a.fecha_registro AS fecha, " &
                "    a.hora_registro AS hora, " &
                "    f.nombre AS estado " &
                "FROM contenedores a " &
                "JOIN productos b ON a.productos_id = b.id " &
                "JOIN variedades c ON a.variedades_id = c.id " &
                "JOIN recepciones e ON a.recepciones_id = e.id " &
                "JOIN estados_contenedores f ON a.estados_contenedores_id = f.id " &
                "LEFT JOIN fases_sistema g ON f.fases_sistema_id = g.id " &
                "JOIN personas h ON e.personas_id = h.id " &
                "JOIN calibres i ON a.calibres_id = i.id " &
                "JOIN tipos_recepciones j ON e.tipos_recepciones_id = j.id " &
                "JOIN procesos_recepciones pr ON e.id = pr.recepciones_id " &
                "LEFT JOIN procesos k ON pr.procesos_id = k.id " &
                "WHERE a.id = @id " &
                "ORDER BY a.id DESC"

            Dim dtTicket As DataTable = ObtenerDatos(sqlVista, {New MySqlParameter("@id", idContenedor)})

            If dtTicket.Rows.Count > 0 Then
                Dim fila As DataRow = dtTicket.Rows(0)
                Dim datosTicket As New Dictionary(Of String, String) From {
                    {"codigo", fila("codigo").ToString()},
                    {"recepcion", fila("recepcion").ToString()},
                    {"tipo", fila("tipo").ToString()},
                    {"proceso", fila("proceso").ToString()},
                    {"productor", fila("productor").ToString()},
                    {"producto", fila("producto").ToString()},
                    {"variedad", fila("variedad").ToString()},
                    {"calibre", fila("calibre").ToString()},
                    {"numero", fila("numero").ToString()},
                    {"fecha", If(IsDBNull(fila("fecha")), DateTime.Now.ToString("dd/MM/yyyy"), Convert.ToDateTime(fila("fecha")).ToString("dd/MM/yyyy"))},
                    {"hora", fila("hora").ToString()}
                }

                Dim pd As New PrintDocument()
                pd.PrinterSettings.PrinterName = "Xprinter XP-420B"

                If Not pd.PrinterSettings.IsValid Then
                    MessageBox.Show("La impresora '" & pd.PrinterSettings.PrinterName & "' no es válida, no está conectada o el nombre es incorrecto.", "Error de Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                pd.DefaultPageSettings.PaperSize = New PaperSize("100x150", 394, 590)
                pd.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
                AddHandler pd.PrintPage, Sub(s, ev)
                                             DisenoTicketQR_Grande(ev, datosTicket)
                                         End Sub
                pd.Print()
            Else
                MessageBox.Show("No se encontró la información en la vista para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class