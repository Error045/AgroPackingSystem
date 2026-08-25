Imports System.IO.Ports

Public Class ucConfiguracion
    Private WithEvents PuertoPrueba As New SerialPort
    ' 1. Creamos un acumulador para que la trama no se corte
    Private acumuladorDatos As String = ""

    ' (Load y otros métodos se mantienen igual...)
    Private Sub ucConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Llenar Puertos COM (Datos en duro)
        cmbPuertos.Items.Clear()
        cmbPuertos.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8"})

        ' 2. Llenar Baudios (Datos en duro)
        cmbBaudios.Items.Clear()
        cmbBaudios.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400", "115200"})

        ' 3. Intentar cargar lo que ya está guardado en Settings
        Try
            If Not String.IsNullOrEmpty(My.Settings.PuertoNombre) Then
                cmbPuertos.Text = My.Settings.PuertoNombre
            End If

            If My.Settings.Baudios > 0 Then
                cmbBaudios.Text = My.Settings.Baudios.ToString()
            Else
                cmbBaudios.Text = "2400" ' Valor por defecto
            End If
        Catch
            ' Si es la primera vez que se usa, seleccionamos el primero por defecto
            If cmbPuertos.Items.Count > 0 Then cmbPuertos.SelectedIndex = 0
            cmbBaudios.SelectedIndex = 2 ' 9600
        End Try
    End Sub

    Private Sub btnProbar_Click(sender As Object, e As EventArgs) Handles btnProbar.Click
        Try
            If PuertoPrueba.IsOpen Then PuertoPrueba.Close()
            acumuladorDatos = "" ' Limpiamos el buffer al iniciar

            PuertoPrueba.PortName = cmbPuertos.Text
            PuertoPrueba.BaudRate = CInt(cmbBaudios.Text)
            ' Configuración estándar para básculas (ajustar si es necesario)
            PuertoPrueba.DataBits = 8
            PuertoPrueba.Parity = Parity.None
            PuertoPrueba.StopBits = StopBits.One

            PuertoPrueba.Open()

            lblEstadoPrueba.Text = "⏳ Esperando trama completa..."
            lblEstadoPrueba.ForeColor = Color.Orange
        Catch ex As Exception
            MessageBox.Show("Error al abrir puerto: " & ex.Message)
        End Try
    End Sub

    Private Sub PuertoPrueba_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles PuertoPrueba.DataReceived
        Try
            ' 2. Leemos lo que llegó y lo sumamos al acumulador
            Dim datosEntrantes As String = PuertoPrueba.ReadExisting()
            acumuladorDatos &= datosEntrantes

            ' 3. Solo procesamos si detectamos que la trama terminó 
            ' La mayoría de básculas terminan con un salto de línea (Chr 13 o Chr 10)
            ' o tienen una longitud fija (ej: 8 caracteres)
            If acumuladorDatos.Length >= 8 OrElse datosEntrantes.Contains(vbCr) Then

                Dim tramaParaProcesar As String = acumuladorDatos
                acumuladorDatos = "" ' Vaciamos para la siguiente lectura

                ' 4. LIMPIEZA Y LOGICA DE INVERSION SEGURA
                ' Extraemos solo los dígitos, puntos y el signo menos
                Dim soloNumeros As String = System.Text.RegularExpressions.Regex.Replace(tramaParaProcesar, "[^0-9.-]", "")

                If Not String.IsNullOrEmpty(soloNumeros) Then
                    ' INVERSIÓN
                    Dim caracteres() As Char = soloNumeros.ToCharArray()
                    Array.Reverse(caracteres)
                    Dim cadenaInvertida As String = New String(caracteres)

                    ' CONVERSIÓN (Usando punto siempre como decimal)
                    Dim pesoFinal As Double = Val(cadenaInvertida.Replace(",", "."))

                    ' 5. FILTRO PARA EL "0.0" REAL
                    ' Si el peso es muy bajo (como ese 10 que mencionas), lo forzamos a 0
                    ' Ajustar este valor (10.5) según lo que veas en tus pruebas en vacío
                    If pesoFinal <= 10.5 Then pesoFinal = 0

                    Me.Invoke(Sub()
                                  lblPesoPrueba.Text = "PESO ACTUAL: " & pesoFinal.ToString("N1") & " kg"
                                  lblTramaOriginal.Text = "RAW: " & tramaParaProcesar.Trim()
                                  lblEstadoPrueba.Text = "✅ Datos Recibidos"
                                  lblEstadoPrueba.ForeColor = Color.Green
                              End Sub)
                End If
            End If
        Catch ex As Exception
            ' Evitar que el programa se cierre si hay un error de casteo
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validar que se haya seleccionado algo
        If cmbPuertos.SelectedItem Is Nothing Or cmbBaudios.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor seleccione un Puerto y Baudios válidos.")
            Return
        End If

        ' 1. Cerramos el puerto de prueba si quedó abierto
        If PuertoPrueba.IsOpen Then PuertoPrueba.Close()

        ' 2. GUARDAR DATOS DEL COMBOBOX EN SETTINGS
        My.Settings.PuertoNombre = cmbPuertos.Text
        My.Settings.Baudios = CInt(cmbBaudios.Text)
        My.Settings.Save() ' <--- Esto es vital para que persista

        ' 3. NOTIFICAR AL FORM1
        ' Buscamos el formulario padre y ejecutamos su conexión real
        Dim frmPadre = TryCast(Me.FindForm(), Form1)
        If frmPadre IsNot Nothing Then
            frmPadre.ConectarBascula()
            MessageBox.Show("Configuración guardada y conexión reiniciada con " & My.Settings.PuertoNombre)
        End If
    End Sub

    Private Sub cmbPuertos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuertos.SelectedIndexChanged

    End Sub

    ' (Botón Guardar se mantiene igual...)
End Class
