Public Class ucSelector

    Public Event CantidadSeleccionada(cantidad As Integer)

    Private Sub ucSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Enabled = False
        Dim t As New Timer()
        t.Interval = 100
        AddHandler t.Tick, Sub()
                               Me.Enabled = True
                               t.Stop()
                               t.Dispose()
                           End Sub
        t.Start()
    End Sub

    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged, rb2.CheckedChanged, rb3.CheckedChanged
        Dim rb = DirectCast(sender, RadioButton)

        If rb.Checked Then
            Dim cantidad As Integer = Val(rb.Text)
            ' Solo disparamos el evento. No navegamos desde aquí.
            RaiseEvent CantidadSeleccionada(cantidad)
        End If
    End Sub

End Class