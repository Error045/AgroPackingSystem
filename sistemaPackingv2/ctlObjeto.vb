Public Class ctlObjeto

    ' Código dentro del UserControl
    Public Property Peso As String
        Get
            Return txtPeso.Text
        End Get
        Set(value As String)
            txtPeso.Text = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return txtCodigo.Text
        End Get
        Set(value As String)
            txtCodigo.Text = value
        End Set
    End Property

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class
