<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdenRepesaje
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UcOrdenRepesajeValidacion1 = New sistemaPackingv2.ucOrdenRepesajeValidacion()
        Me.UcOrdenRepesajeActualizar1 = New sistemaPackingv2.ucOrdenRepesajeActualizar()
        Me.pnlContenedorPesaje = New System.Windows.Forms.Panel()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        Me.pnlContenedorPesaje.SuspendLayout()
        Me.SuspendLayout()
        '
        'UcOrdenRepesajeValidacion1
        '
        Me.UcOrdenRepesajeValidacion1.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdenRepesajeValidacion1.Name = "UcOrdenRepesajeValidacion1"
        Me.UcOrdenRepesajeValidacion1.Size = New System.Drawing.Size(951, 800)
        Me.UcOrdenRepesajeValidacion1.TabIndex = 0
        '
        'UcOrdenRepesajeActualizar1
        '
        Me.UcOrdenRepesajeActualizar1.Location = New System.Drawing.Point(18, 17)
        Me.UcOrdenRepesajeActualizar1.Name = "UcOrdenRepesajeActualizar1"
        Me.UcOrdenRepesajeActualizar1.Size = New System.Drawing.Size(900, 800)
        Me.UcOrdenRepesajeActualizar1.TabIndex = 1
        '
        'pnlContenedorPesaje
        '
        Me.pnlContenedorPesaje.Controls.Add(Me.UcPesaje1)
        Me.pnlContenedorPesaje.Location = New System.Drawing.Point(10, 9)
        Me.pnlContenedorPesaje.Name = "pnlContenedorPesaje"
        Me.pnlContenedorPesaje.Size = New System.Drawing.Size(1290, 985)
        Me.pnlContenedorPesaje.TabIndex = 2
        '
        'UcPesaje1
        '
        Me.UcPesaje1.DatosActuales = Nothing
        Me.UcPesaje1.IdContenedorSeleccionado = 0
        Me.UcPesaje1.Location = New System.Drawing.Point(3, 2)
        Me.UcPesaje1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcPesaje1.Name = "UcPesaje1"
        Me.UcPesaje1.Peso = "0,0"
        Me.UcPesaje1.PesoAcumuladoAnterior = 0R
        Me.UcPesaje1.PesoAcumuladoBinesAnteriores = 0R
        Me.UcPesaje1.Size = New System.Drawing.Size(1284, 875)
        Me.UcPesaje1.TabIndex = 0
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        '
        'ucOrdenRepesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlContenedorPesaje)
        Me.Controls.Add(Me.UcOrdenRepesajeActualizar1)
        Me.Controls.Add(Me.UcOrdenRepesajeValidacion1)
        Me.Name = "ucOrdenRepesaje"
        Me.Size = New System.Drawing.Size(1321, 1038)
        Me.pnlContenedorPesaje.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcOrdenRepesajeValidacion1 As ucOrdenRepesajeValidacion
    Friend WithEvents UcOrdenRepesajeActualizar1 As ucOrdenRepesajeActualizar
    Friend WithEvents pnlContenedorPesaje As Panel
    Friend WithEvents UcPesaje1 As ucPesaje
End Class
