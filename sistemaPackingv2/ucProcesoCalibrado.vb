Imports MySql.Data.MySqlClient

Public Class ucProcesoCalibrado

    ' --- VARIABLE CLAVE ---
    ' Esta bandera evita que los eventos se disparen a lo loco mientras llenamos los datos
    Private cargando As Boolean = True

    ' 1. CARGA INICIAL
    Private Sub ucProcesoCalibrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboProceso()
        '  LlenarComboContenedor() ' <-- Agregar esta línea
    End Sub

    ' 2. LÓGICA DEL COMBO PROCESO
    Private Sub CargarComboProceso()
        cargando = True ' Bloqueamos eventos

        Dim sqlProceso As String = "SELECT a.id, CONCAT(a.id, ' - ', c.nombre) as nombre " &
                                   "FROM procesos a " &
                                   "JOIN recepciones b ON a.recepciones_id = b.id " &
                                   "JOIN personas c ON b.personas_id = c.id " &
                                   "WHERE a.estados_procesos_id = 1"

        Dim dtProceso As DataTable = ObtenerDatos(sqlProceso)

        cmbProceso.DataSource = dtProceso
        cmbProceso.DisplayMember = "nombre"
        cmbProceso.ValueMember = "id"
        cmbProceso.SelectedIndex = -1

        ' Auto-selección inicial
        'If dtProceso.Rows.Count > 0 Then
        'cmbProceso.SelectedIndex = 0
        'Else
        'cmbProceso.SelectedIndex = -1
        ' End If

        cargando = False ' Desbloqueamos eventos

        ' Forzamos la carga del hijo (Producto) basándonos en lo que quedó seleccionado
        LlenarComboProducto()
    End Sub

    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        ' Si estamos cargando datos por código, ignoramos el click del usuario
        If cargando Then Return

        LlenarComboProducto()
    End Sub

    ' 3. LÓGICA DEL COMBO PRODUCTO
    Private Sub LlenarComboProducto()
        cargando = True ' Bloqueamos eventos

        ' Limpiamos los combos hijos
        cmbProducto.DataSource = Nothing
        cmbVariedad.DataSource = Nothing

        ' Validamos que el proceso tenga un ID válido seleccionado
        If cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT p.id, p.nombre " &
                                "FROM productos p " &
                                "JOIN contenedores c ON p.id = c.productos_id " &
                                "JOIN recepciones r ON c.recepciones_id = r.id " &
                                "JOIN procesos pr ON r.id = pr.recepciones_id " &
                                "WHERE pr.id = @idProc " &
                                "GROUP BY p.id;"

            Dim param As New MySqlParameter("@idProc", idProceso)
            Dim dtProductos As DataTable = ObtenerDatos(sql, {param})

            cmbProducto.DataSource = dtProductos
            cmbProducto.DisplayMember = "nombre"
            cmbProducto.ValueMember = "id"

            ' Auto-selección de Producto
            If dtProductos.Rows.Count > 0 Then
                cmbProducto.SelectedIndex = 0
            Else
                cmbProducto.SelectedIndex = -1
            End If
        End If

        cargando = False ' Desbloqueamos eventos

        ' Forzamos la carga del nieto (Variedad)
        LlenarComboVariedad()
        ' LlenarComboCalibre() '---------------------------------------------

    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cargando Then Return

        LlenarComboVariedad()
    End Sub

    ' 4. LÓGICA DEL COMBO VARIEDAD
    Private Sub LlenarComboVariedad()
        cargando = True ' Bloqueamos eventos

        cmbVariedad.DataSource = Nothing
        cmbCalibre.DataSource = Nothing ' <-- NUEVO: Limpiamos calibres viejos al recalcular variedades

        ' Validamos que Proceso y Producto tengan un ID válido
        If cmbProducto.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProducto.SelectedValue) AndAlso cmbProceso.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbProceso.SelectedValue) Then
            Dim idProducto As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
            Dim idProceso As Integer = Convert.ToInt32(cmbProceso.SelectedValue)

            Dim sql As String = "SELECT v.id, v.nombre " &
                                "FROM variedades v " &
                                "JOIN contenedores c ON v.id = c.variedades_id " &
                                "JOIN recepciones r ON c.recepciones_id = r.id " &
                                "JOIN procesos pr ON r.id = pr.recepciones_id " &
                                "WHERE pr.id = @idProc AND c.productos_id = @idProd " &
                                "GROUP BY v.id"

            Dim p1 As New MySqlParameter("@idProc", idProceso)
            Dim p2 As New MySqlParameter("@idProd", idProducto)
            Dim dtVariedades As DataTable = ObtenerDatos(sql, {p1, p2})

            cmbVariedad.DataSource = dtVariedades
            cmbVariedad.DisplayMember = "nombre"
            cmbVariedad.ValueMember = "id"

            ' Auto-selección de Variedad
            If dtVariedades.Rows.Count > 0 Then
                cmbVariedad.SelectedIndex = 0
            Else
                cmbVariedad.SelectedIndex = -1
            End If
        End If

        cargando = False ' Desbloqueamos eventos

        ' <-- NUEVO: Forzamos la carga del último eslabón de la cadena (Calibre)
        LlenarComboCalibre()
    End Sub


    Private Sub cmbVariedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVariedad.SelectedIndexChanged
        ' Si estamos cargando datos por código, ignoramos el disparo involuntario
        If cargando Then Return

        ' Cargamos los calibres correspondientes a la variedad seleccionada
        LlenarComboCalibre()
    End Sub


    ' ---------------------------------------------------------
    ' 5. LÓGICA DEL COMBO CALIBRE
    ' ---------------------------------------------------------
    Private Sub LlenarComboCalibre()
        cargando = True
        cmbCalibre.DataSource = Nothing

        ' Validamos que el producto esté seleccionado para traer sus calibres
        If cmbVariedad.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbVariedad.SelectedValue) Then

            Dim idVariedad As Integer = Convert.ToInt32(cmbVariedad.SelectedValue)

            ' Consulta para traer los 10-15 registros de calibres
            Dim sqlCalibre As String = "SELECT id,nombre FROM calibres WHERE variedades_id = @varId"

            Dim dtCalibres As DataTable = ObtenerDatos(sqlCalibre, {New MySqlParameter("@varId", idVariedad)})

            cmbCalibre.DisplayMember = "nombre"
            cmbCalibre.ValueMember = "id"
            cmbCalibre.DataSource = dtCalibres

            ' FORZAR SELECCIÓN MANUAL:
            ' Al ponerlo en -1, el combo aparecerá en blanco y el usuario 
            ' tendrá que desplegarlo y elegir uno obligatoriamente.
            cmbCalibre.SelectedIndex = -1
        End If

        cargando = False
    End Sub

    ' Este evento se disparará cuando el usuario finalmente elija un calibre
    Private Sub cmbCalibre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalibre.SelectedIndexChanged
        If cargando Then Return

        ' Validamos que haya una selección real hecha por el usuario
        If cmbCalibre.SelectedIndex <> -1 Then
            ' Aquí puedes colocar la lógica para "buscar la información" 
            ' o habilitar el botón de procesar/guardar.
            Dim idCalibre As Integer = Convert.ToInt32(cmbCalibre.SelectedValue)
            ' Ejemplo: CargarDatosSegunCalibre(idCalibre)
        End If
    End Sub

    ' ---------------------------------------------------------
    ' 6. LÓGICA DEL COMBO CONTENEDOR
    ' ---------------------------------------------------------
    'Private Sub LlenarComboContenedor()
    '    cargando = True
    '    cmbContenedor.DataSource = Nothing

    ' Consulta directa a la tabla contenedores
    'Dim sql As String = "SELECT id, nombre, tara FROM contenedores WHERE estado = 1"

    'Dim dtContenedores As DataTable = ObtenerDatos(sql)

    'If dtContenedores IsNot Nothing Then
    '       cmbContenedor.DisplayMember = "nombre"
    '      cmbContenedor.ValueMember = "id"
    '      cmbContenedor.DataSource = dtContenedores

    ' Forzamos selección manual (vacío al inicio)
    '     cmbContenedor.SelectedIndex = -1
    'End If

    '    cargando = False
    ' End Sub

    ' Private Sub cmbContenedor_SelectedIndexChanged(sender As Object, e As EventArgs)
    'If cargando Then Return

    '' Si el usuario selecciona un contenedor, puedes capturar el ID y la Tara
    ' If cmbContenedor.SelectedIndex <> -1 Then
    ' Dim idContenedor As Integer = Convert.ToInt32(cmbContenedor.SelectedValue)

    ' Si necesitas la tara para un cálculo automático:
    ' Dim fila As DataRowView = DirectCast(cmbContenedor.SelectedItem, DataRowView)
    ' txtTara.Text = fila("tara").ToString()
    ' End If
    ' End Sub

    ' 7. LÓGICA DE REGISTRO CON VALIDACIÓN
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        ' --- VALIDACIÓN DE CAMPOS SELECCIONADOS ---
        ' Verificamos que ninguno de los combos esté en su estado inicial (-1) o nulo
        Dim errorMensaje As String = ""

        If cmbProceso.SelectedValue Is Nothing OrElse cmbProceso.SelectedIndex = -1 Then
            errorMensaje &= "- Debe seleccionar un Proceso." & vbCrLf
        End If

        If cmbProducto.SelectedValue Is Nothing OrElse cmbProducto.SelectedIndex = -1 Then
            errorMensaje &= "- Debe seleccionar un Producto." & vbCrLf
        End If

        If cmbVariedad.SelectedValue Is Nothing OrElse cmbVariedad.SelectedIndex = -1 Then
            errorMensaje &= "- Debe seleccionar una Variedad." & vbCrLf
        End If

        If cmbCalibre.SelectedValue Is Nothing OrElse cmbCalibre.SelectedIndex = -1 Then
            errorMensaje &= "- Debe seleccionar un Calibre." & vbCrLf
        End If

        ' Si hay errores, mostramos un solo mensaje y detenemos la ejecución
        If Not String.IsNullOrEmpty(errorMensaje) Then
            MessageBox.Show("Faltan datos requeridos:" & vbCrLf & vbCrLf & errorMensaje,
                            "Validación de Selección",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Return
        End If

        ' --- PROCESO DE INSERCIÓN (Si las validaciones pasan) ---
        Try
            Dim sql As String = "INSERT INTO contenedores (" &
                                "   recepciones_id, productos_id, variedades_id, calibres_id, " &
                                "   tipos_ubicaciones_id, estados_contenedores_id, fecha_registro, users_id_registro,estado,created_at, updated_at) " &
                                "SELECT " &
                                "   recepciones_id, @prodId, @varId, @calId, " &
                                "   3 , 4, NOW(), 1 , 1, NOW(), NOW() " &
                                "FROM procesos " &
                                "WHERE id = @procId;" &
                                "   INSERT INTO contenedores_historial (" &
                                "       tipos_movimientos_id, contenedores_id, " &
                                "       tipos_ubicaciones_id, estados_contenedores_id, " &
                                "       fecha_movimiento, users_id, estado,created_at,updated_at) " &
                                "   VALUES (" &
                                "       1, LAST_INSERT_ID(), " & ' El sistema toma el ID recién creado arriba
                                "       3, 4, NOW(), 1, 1, NOW(),NOW());"


            Dim parametros As MySqlParameter() = {
                New MySqlParameter("@procId", cmbProceso.SelectedValue),
                New MySqlParameter("@prodId", cmbProducto.SelectedValue),
                New MySqlParameter("@varId", cmbVariedad.SelectedValue),
                New MySqlParameter("@calId", cmbCalibre.SelectedValue)
            }

            ' Ejecución usando tu método de base de datos
            EjecutarComando(sql, parametros)

            MessageBox.Show("Registro de calibración completado con éxito.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiamos la selección del calibre para el siguiente registro
            cmbCalibre.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al guardar en la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class