Imports MySql.Data.MySqlClient


Module ConexionBD

    Public cadena As String = "server=localhost;user=root;password=;database=prueba3;Allow Zero Datetime=True; Convert Zero Datetime=True; AllowUserVariables=True; AllowBatch=True;"
    Public conexion As New MySqlConnection(cadena)

    Public Sub Abrir()
        If conexion.State = ConnectionState.Closed Then conexion.Open()
    End Sub

    Public Sub Cerrar()
        If conexion.State = ConnectionState.Open Then conexion.Close()
    End Sub

    ' --- AGREGA ESTA FUNCIÓN PARA LOS COMBOBOX ---
    Public Function ObtenerDatos(sql As String, Optional parametros As MySqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()
        Try
            Abrir()
            Using cmd As New MySqlCommand(sql, conexion)
                If parametros IsNot Nothing Then cmd.Parameters.AddRange(parametros)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            Cerrar()
        End Try
        Return dt
    End Function

    Public Sub EjecutarComando(ByVal sql As String, Optional ByVal parametros As MySqlParameter() = Nothing)
        Try
            Abrir()
            Using cmd As New MySqlCommand(sql, conexion)
                If parametros IsNot Nothing Then
                    cmd.Parameters.AddRange(parametros)
                End If
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As MySqlException
            Throw New Exception("Error al ejecutar operación: " & ex.Message)
        Finally
            Cerrar()
        End Try
    End Sub

    Public Function EjecutarEscalar(ByVal sql As String, Optional ByVal parametros As MySqlParameter() = Nothing) As Object
        Dim resultado As Object = Nothing
        Try
            Using cmd As New MySqlCommand(sql, conexion) ' "Me.conexion" es tu objeto MySqlConnection
                ' Si hay parámetros, los agregamos al comando
                If parametros IsNot Nothing Then
                    cmd.Parameters.AddRange(parametros)
                End If


                resultado = cmd.ExecuteScalar()
            End Using
        Catch ex As MySqlException
            Throw New Exception("Error de base de datos: " & ex.Message)
        End Try
        Return resultado
    End Function

End Module