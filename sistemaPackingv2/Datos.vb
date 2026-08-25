Imports MySql.Data.MySqlClient

Public Module Datos
    ' Cambia esta cadena por la que usas en tu proyecto
    Private CadenaConexion As String = "Server=localhost;Database=prueba3;Uid=root;Pwd=;"

    Public Function ObtenerTarjetasCalibres() As DataTable
        Dim dt As New DataTable()
        ' La consulta que optimizamos con los nombres "_Totales" y porcentajes
        Dim sql As String = "SELECT * FROM vw_Tarjetas_Calibres"

        Using conn As New MySqlConnection(CadenaConexion)
            Try
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.Fill(dt)
            Catch ex As Exception
                MsgBox("Error al consultar base de datos: " & ex.Message)
            End Try
        End Using
        Return dt
    End Function
End Module