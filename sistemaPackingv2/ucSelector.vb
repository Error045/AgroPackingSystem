Public Class ucSelector

    Private Sub ucSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Desactiva el control momentáneamente para ignorar clics residuales
        Me.Enabled = False
        Dim t As New Timer()
        t.Interval = 100 ' 100 milisegundos de pausa
        AddHandler t.Tick, Sub()
                               Me.Enabled = True
                               t.Stop()
                           End Sub
        t.Start()
    End Sub

    ' 1. Definimos el evento
    Public Event CantidadSeleccionada(cantidad As Integer)


    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged, rb2.CheckedChanged, rb3.CheckedChanged
        Dim rb = DirectCast(sender, RadioButton)

        ' Solo si el botón se marca
        If rb.Checked Then
            Dim cantidad As Integer = Val(rb.Text)

            ' Extraer el número del texto (ej: "1" o "2")


            ' Lanzar el grito al padre
            RaiseEvent CantidadSeleccionada(cantidad)

            ' BUSCAR AL PADRE (ucRecepcion) Y PEDIRLE QUE GENERE LOS OBJETOS
            ' Usamos TryCast para asegurar que el padre es efectivamente ucRecepcion
            ' Dim padre = TryCast(Me.Parent, ucRecepcion)
            ' If padre IsNot Nothing Then
            ' padre.ConfigurarFlujo(cantidad)
            'Opcional:       ocultar el selector para limpiar la pantalla

            'Me.Visible = False
            ' Opcional: Bloquear para evitar cambios durante el pesaje
            'Me.Enabled = False
            ' End If
        End If
    End Sub

End Class
