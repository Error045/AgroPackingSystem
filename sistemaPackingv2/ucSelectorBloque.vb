Public Class ucSelectorBloque

    Public Event CantidadSeleccionada(cantidad As Integer)

    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged, rb2.CheckedChanged, rb3.CheckedChanged
        Dim rb = DirectCast(sender, RadioButton)

        If rb.Checked Then
            Dim cantidad As Integer = Val(rb.Text)
            ' Avisa al contenedor de bloque qué cantidad se seleccionó
            RaiseEvent CantidadSeleccionada(cantidad)
        End If
    End Sub

End Class