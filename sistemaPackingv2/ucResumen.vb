Imports MySql.Data.MySqlClient

Public Class ucResumen
    ' 🟢 Propiedades para recibir los datos (ya no dependen de Form1)
    ' --- PROPIEDADES DE DATOS (Nombres únicos para evitar ambigüedad) ---
    Public Property SelectedIdReferencia As Integer
    Public Property SelectedIdProductor As Integer
    Public Property SelectedIdProducto As Integer
    Public Property SelectedIdVariedad As Integer ' <--- Antes era solo IdVarieda
    Private _idTipoRecepcion As Integer


    ' 🟢 Definir si estamos en modo Recepción o Calibrado
    Public Enum ModoOperacion
        Recepcion
        Calibrado
    End Enum
    Public Property ModoActual As ModoOperacion = ModoOperacion.Recepcion

    ' 🟢 Cargar los datos desde una lista de objetos, no de controles
    Public Sub CargarDatos(lista As List(Of PesajeFinal), idRef As Integer, idProd As Integer, idVar As Integer, idTipo As Integer)
        Me.SelectedIdReferencia = idRef
        Me.SelectedIdProducto = idProd
        Me.SelectedIdVariedad = idVar
        Me._idTipoRecepcion = idTipo ' Guardamos el tipo
        Try
            ConexionBD.Abrir()

            ' --- 2. CARGA DE LABELS SUPERIORES ---
            Dim resTipo = ConexionBD.EjecutarEscalar("SELECT tipo FROM tipos_recepciones WHERE id = @idT", {New MySqlParameter("@idT", idTipo)})
            lblTipoRecepcion.Text = If(resTipo IsNot Nothing, resTipo.ToString().ToUpper(), "N/A")

            Dim resNombre = ConexionBD.EjecutarEscalar("SELECT p.nombre FROM recepciones r JOIN personas p ON r.personas_id = p.id WHERE r.id = @idR", {New MySqlParameter("@idR", idRef)})
            lblNombre.Text = If(resNombre IsNot Nothing, resNombre.ToString(), "PROVEEDOR NO IDENTIFICADO")

            ' --- 3. OBTENCIÓN DE NOMBRES PARA LA GRILLA ---
            Dim resP = ConexionBD.EjecutarEscalar("SELECT nombre FROM productos WHERE id = @idP", {New MySqlParameter("@idP", idProd)})
            Dim resV = ConexionBD.EjecutarEscalar("SELECT nombre FROM variedades WHERE id = @idV", {New MySqlParameter("@idV", idVar)})
            Dim nombreProducto As String = If(resP IsNot Nothing, resP.ToString(), "N/A")
            Dim nombreVariedad As String = If(resV IsNot Nothing, resV.ToString(), "N/A")

            ' --- 4. CONFIGURACIÓN DE LISTAS FILTRADAS EN EL GRID ---
            dgvResumen.Rows.Clear()
            CargarListasEnGrid(idTipo, idVar) ' Aquí ejecutamos tu lógica de Select Case

            ' --- 5. VALIDACIÓN DE SEGURIDAD (CRÍTICO) ---
            ' Obtenemos los DataSources de las columnas ComboBox para validar que tengan datos
            Dim colCal = DirectCast(dgvResumen.Columns("colCalibre"), DataGridViewComboBoxColumn)
            Dim colUbi = DirectCast(dgvResumen.Columns("colUbicacion"), DataGridViewComboBoxColumn)

            Dim dtCal As DataTable = DirectCast(colCal.DataSource, DataTable)
            Dim dtUbi As DataTable = DirectCast(colUbi.DataSource, DataTable)

            ' Si alguna lista está vacía, abortamos para evitar el error de "Índice fuera de rango"
            If dtCal Is Nothing OrElse dtCal.Rows.Count = 0 OrElse dtUbi Is Nothing OrElse dtUbi.Rows.Count = 0 Then
                Throw New Exception("No se encontraron calibres o ubicaciones válidas para este tipo de recepción.")
            End If

            ' Si pasó la validación, tomamos los IDs por defecto (el primer registro de cada lista)
            Dim defaultCalibreId = dtCal.Rows(0)("id")
            Dim defaultUbicacionId = dtUbi.Rows(0)("id")

            ' --- 6. LLENADO DE FILAS ---
            Dim sumaTotalNeto As Double = 0
            Dim sumaTotalBruto As Double = 0

            For Each p In lista
                ' Usamos los nombres de columna definidos en el diseñador
                Dim rowIndex As Integer = dgvResumen.Rows.Add(
                 p.Titulo,
                 nombreProducto,
                 nombreVariedad,
                 p.IdContenedor,
                 p.Tara,
                 p.PesoBruto,
                 p.PesoNeto
                 )

                ' Asignamos los valores por defecto detectados
                dgvResumen.Rows(rowIndex).Cells("colCalibre").Value = defaultCalibreId
                dgvResumen.Rows(rowIndex).Cells("colUbicacion").Value = defaultUbicacionId

                sumaTotalNeto += p.PesoNeto
                sumaTotalBruto += p.PesoBruto
            Next

            ' --- 7. FINALIZAR INTERFAZ ---
            ConfigurarGrillaSegunTipo(idTipo)
            lblTotal.Text = $"TOTAL NETO: {sumaTotalNeto:N2} kg | TOTAL BRUTO: {sumaTotalBruto:N2} kg"

        Catch ex As Exception
            MessageBox.Show("Error en validación de datos: " & ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' Método para cargar las listas en las columnas del Grid
    Private Sub CargarListasEnGrid(idTipo As Integer, idVar As Integer)
        Try
            ' 1. Determinamos el comportamiento según el tipo de recepción
            Dim esFlujoEstandar As Boolean = False

            Select Case idTipo
                Case 1, 2, 6, 7 ' Agrega aquí fácilmente nuevos IDs
                    esFlujoEstandar = True
                Case Else
                    esFlujoEstandar = False
            End Select

            ' 2. Definir SQL de Calibres
            Dim sqlCalibres As String = If(esFlujoEstandar,
                                   "SELECT id, nombre FROM calibres WHERE variedades_id = @idVar AND estados_calibres_id = 2",
                                   "SELECT id, nombre FROM calibres WHERE variedades_id = @idVar AND estados_calibres_id <> 2")



            Dim dtCalibres As DataTable = ObtenerDatos(sqlCalibres)
            Using cmd As New MySqlCommand(sqlCalibres, ConexionBD.conexion)
                cmd.Parameters.AddWithValue("@idVar", idVar)
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dtCalibres)
            End Using

            Dim colCal As DataGridViewComboBoxColumn = DirectCast(dgvResumen.Columns("colCalibre"), DataGridViewComboBoxColumn)
            colCal.DataSource = dtCalibres
            colCal.DisplayMember = "nombre"
            colCal.ValueMember = "id"



            ' 3. Definir SQL de Ubicaciones
            Dim sqlUbicaciones As String = If(esFlujoEstandar,
                                      "SELECT id, nombre FROM tipos_ubicaciones WHERE id = 1",
                                      "SELECT id, nombre FROM tipos_ubicaciones WHERE id <> 1")

            Dim dtUbicaciones As DataTable = ObtenerDatos(sqlUbicaciones)
            Dim colUbi As DataGridViewComboBoxColumn = DirectCast(dgvResumen.Columns("colUbicacion"), DataGridViewComboBoxColumn)
            colUbi.DataSource = dtUbicaciones
            colUbi.DisplayMember = "nombre"
            colUbi.ValueMember = "id"

        Catch ex As Exception
            MessageBox.Show("Error cargando listas: " & ex.Message)
        End Try
    End Sub

    Private Sub ConfigurarGrillaSegunTipo(idTipo As Integer)
        ' 1 = Proveedor Estándar, 2 = Proveedor Calibrado, 3 = Refrigeración, 4 = Maduración
        Dim esDirecto As Boolean = (idTipo >= 2)

        ' Si es proveedor normal, la columna de calibre es de "Solo Lectura"
        dgvResumen.Columns("colCalibre").ReadOnly = Not esDirecto

        ' Opcional: Cambiar el color de la columna para que el usuario note que no puede editar
        If Not esDirecto Then
            dgvResumen.Columns("colCalibre").DefaultCellStyle.BackColor = Color.LightGray
        Else
            dgvResumen.Columns("colCalibre").DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If dgvResumen.Rows.Count = 0 Then Return

        ' 🟢 Aquí decides a qué tabla insertar según el modo
        If ModoActual = ModoOperacion.Recepcion Then
            GuardarEnRecepciones()
        Else
            GuardarEnCalibrados()
        End If
    End Sub

    Private Sub GuardarEnRecepciones()
        ' 1. Validaciones iniciales
        If dgvResumen.Rows.Count = 0 Then Return

        ' Usamos las propiedades locales que cargamos en el método CargarDatos
        Dim idRecActual As Integer = Me.SelectedIdReferencia
        Dim idOpLog As Integer = 1 ' 1 para Recepción, podrías hacerlo propiedad si varía

        Try
            ConexionBD.Abrir()

            ' 2. OBTENER PREFIJO Y PRÓXIMO CICLO (Lógica de Negocio)
            Dim prefijo As String = ""
            Dim proximoCiclo As Integer = 1

            ' Consulta para prefijo
            Dim sqlPrefijo = "SELECT prefijo FROM fases_sistema WHERE id = @idOp"   'operaciones_logisticas ahora se usa fases_sistema donde tiene el campo prefijo, se elimina una tabla y se simplifica la consulta
            Using cmdPre = New MySqlCommand(sqlPrefijo, ConexionBD.conexion)
                cmdPre.Parameters.AddWithValue("@idOp", idOpLog)
                Dim res = cmdPre.ExecuteScalar()
                If res IsNot Nothing Then prefijo = res.ToString()
            End Using

            ' Consulta para ciclo (MAX + 1)   
            Dim sqlCiclo = "SELECT COALESCE(MAX(ciclo), 0) + 1 FROM contenedores WHERE recepciones_id = @idR" 'Modificación importante: ahora buscamos en contenedores , no en bines_maestro ni en recepciones_detalles 
            Using cmdMax = New MySqlCommand(sqlCiclo, ConexionBD.conexion)
                cmdMax.Parameters.AddWithValue("@idR", idRecActual)
                proximoCiclo = Convert.ToInt32(cmdMax.ExecuteScalar())
            End Using

            Dim etiqueta As String = $"{prefijo}-{idRecActual}-{proximoCiclo}"

            ' 3. GUARDADO TRANSACCIONAL EN CONTENEDORES Y SU HISTORIAL
            Using transaccion As MySqlTransaction = ConexionBD.conexion.BeginTransaction()
                Try
                    ' SQL 1: Maestro de contenedores (Ajustado estrictamente a tu CREATE TABLE)
                    Dim sqlMaster As String = "INSERT INTO contenedores (" &
            "recepciones_id, tipos_contenedores_id, productos_id, variedades_id, " &
            "calibres_id, ciclo, etiqueta_ciclo, kilos_brutos, kilos_netos, " &
            "tipos_ubicaciones_id, estados_contenedores_id, fecha_registro, users_id_registro,estado) " &
            "VALUES (" &
            "@idR, @idTipoCont, @idProduc, @idVar, " &
            "@idCalibre, @nCiclo, @etiqueta, @bruto, @neto, " &
            "@idUbicacion, @idEstado, CURDATE(), @idUser,1)"

                    ' SQL 2: Historial unificado de movimientos
                    Dim sqlHistorial As String = "INSERT INTO contenedores_historial (" &
            "tipos_movimientos_id, tipos_contenedores_id, contenedores_id, " & 'cambio de elemento_id por contenedores_id
            "tipos_ubicaciones_id, estados_contenedores_id, kilos_brutos, kilos_netos, users_id,estado) " &
            "VALUES (" &
            "@idTipoMov, @idTipoCont, @idContenedores, " &
            "@idUbicacion, @idEstado, @bruto, @neto, @idUser,1)"

                    For Each row As DataGridViewRow In dgvResumen.Rows
                        If row.IsNewRow Then Continue For

                        Dim idContenedorGenerado As Long = 0
                        Dim idTipoContenedor As Object = row.Cells("colIdCont").Value
                        Dim idUbicacion As Object = row.Cells("colUbicacion").Value
                        Dim idEstadoInicial As Integer = 1 ' 1 = Recepcionado / Disponible
                        Dim idUsuarioActual As Integer = 1 ' Cambiar por tu variable global de sesión (ej. UsuarioLogueado.Id)

                        ' --- PASO A: INSERTAR EN MAESTRO ---
                        Using cmdMaster As New MySqlCommand(sqlMaster, ConexionBD.conexion, transaccion)
                            cmdMaster.Parameters.AddWithValue("@idR", Me.SelectedIdReferencia)
                            cmdMaster.Parameters.AddWithValue("@idTipoCont", idTipoContenedor)
                            cmdMaster.Parameters.AddWithValue("@idProduc", Me.SelectedIdProducto)
                            cmdMaster.Parameters.AddWithValue("@idVar", Me.SelectedIdVariedad)
                            cmdMaster.Parameters.AddWithValue("@idCalibre", row.Cells("colCalibre").Value)
                            cmdMaster.Parameters.AddWithValue("@nCiclo", proximoCiclo)
                            cmdMaster.Parameters.AddWithValue("@etiqueta", etiqueta)
                            cmdMaster.Parameters.AddWithValue("@bruto", row.Cells("colBruto").Value)
                            cmdMaster.Parameters.AddWithValue("@neto", row.Cells("colNeto").Value)
                            cmdMaster.Parameters.AddWithValue("@idUbicacion", idUbicacion)
                            cmdMaster.Parameters.AddWithValue("@idEstado", idEstadoInicial)
                            cmdMaster.Parameters.AddWithValue("@idUser", idUsuarioActual)

                            cmdMaster.ExecuteNonQuery()

                            ' Recuperamos el ID que la base de datos le asignó automáticamente a este contenedor
                            idContenedorGenerado = cmdMaster.LastInsertedId
                        End Using

                        ' --- PASO B: INSERTAR EN HISTORIAL ---
                        Using cmdHistorial As New MySqlCommand(sqlHistorial, ConexionBD.conexion, transaccion)
                            cmdHistorial.Parameters.AddWithValue("@idTipoMov", 1) ' 1 = 'Recepción Inicial' (Tu catálogo de movimientos)
                            cmdHistorial.Parameters.AddWithValue("@idTipoCont", idTipoContenedor)
                            cmdHistorial.Parameters.AddWithValue("@idContenedores", idContenedorGenerado) ' Enlazamos el maestro con el historial
                            cmdHistorial.Parameters.AddWithValue("@idUbicacion", idUbicacion)
                            cmdHistorial.Parameters.AddWithValue("@idEstado", idEstadoInicial)
                            cmdHistorial.Parameters.AddWithValue("@bruto", row.Cells("colBruto").Value)
                            cmdHistorial.Parameters.AddWithValue("@neto", row.Cells("colNeto").Value)
                            cmdHistorial.Parameters.AddWithValue("@idUser", idUsuarioActual)

                            cmdHistorial.ExecuteNonQuery()
                        End Using
                    Next

                    ' Si todo el bucle Grid se procesó sin errores, confirmamos la transacción de forma atómica
                    transaccion.Commit()
                    MessageBox.Show("Contenedores registrados e historial generado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    FinalizarProceso(idRecActual, proximoCiclo)
                Catch ex As MySqlException
                    transaccion.Rollback()
                    MessageBox.Show("Error de Base de Datos al guardar: " & ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    transaccion.Rollback()
                    MessageBox.Show("Error general en el proceso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConexionBD.Cerrar()
        End Try
    End Sub

    ' 🟢 Método de navegación limpio
    Private Sub FinalizarProceso(idRec As Integer, ciclo As Integer)
        ' Buscamos el formulario padre de forma genérica
        Dim frmPadre = Me.FindForm()

        ' Si el formulario tiene el método NavegarA (como tu Form1)
        ' Usamos CallByName para no tener que importar Form1 y mantener la independencia
        Try
            Dim ucTicket As New ucTicket(idRec, ciclo)
            CallByName(frmPadre, "NavegarA", CallType.Method, ucTicket)
        Catch
            MessageBox.Show("Guardado con éxito. (Error al intentar navegar al ticket)")
        End Try
    End Sub

    Private Sub GuardarEnCalibrados()
        ' ... Aquí irá la lógica para productos_calibrados
        MessageBox.Show("Guardando en Calibrados...")
    End Sub

    'solución temporal para evitar el error de validación visual del DataGridView al ingresar datos no numéricos en las columnas de peso
    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
        '  Silenciamos el Error de validación visual del DataGridView
        e.ThrowException = False
    End Sub
End Class