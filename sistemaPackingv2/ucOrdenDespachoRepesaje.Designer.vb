<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOrdenDespachoRepesaje
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlContenedorPesaje = New System.Windows.Forms.Panel()
        Me.UcOrdenDespachoRepesajeActualizar1 = New sistemaPackingv2.ucOrdenDespachoRepesajeActualizar()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        Me.UcOrdenDespachoRepesajeValidacion1 = New sistemaPackingv2.ucOrdenDespachoRepesajeValidacion()
        Me.pnlContenedorPesaje.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorPesaje
        '
        Me.pnlContenedorPesaje.Controls.Add(Me.UcPesaje1)
        Me.pnlContenedorPesaje.Location = New System.Drawing.Point(15, 15)
        Me.pnlContenedorPesaje.Name = "pnlContenedorPesaje"
        Me.pnlContenedorPesaje.Size = New System.Drawing.Size(1070, 771)
        Me.pnlContenedorPesaje.TabIndex = 1
        '
        'UcOrdenDespachoRepesajeActualizar1
        '
        Me.UcOrdenDespachoRepesajeActualizar1.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdenDespachoRepesajeActualizar1.Name = "UcOrdenDespachoRepesajeActualizar1"
        Me.UcOrdenDespachoRepesajeActualizar1.Size = New System.Drawing.Size(1100, 800)
        Me.UcOrdenDespachoRepesajeActualizar1.TabIndex = 2
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
        Me.UcPesaje1.Size = New System.Drawing.Size(1064, 760)
        Me.UcPesaje1.TabIndex = 0
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        '
        'UcOrdenDespachoRepesajeValidacion1
        '
        Me.UcOrdenDespachoRepesajeValidacion1.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdenDespachoRepesajeValidacion1.Name = "UcOrdenDespachoRepesajeValidacion1"
        Me.UcOrdenDespachoRepesajeValidacion1.Size = New System.Drawing.Size(1094, 783)
        Me.UcOrdenDespachoRepesajeValidacion1.TabIndex = 3
        '
        'ucOrdenDespachoRepesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcOrdenDespachoRepesajeValidacion1)
        Me.Controls.Add(Me.pnlContenedorPesaje)
        Me.Controls.Add(Me.UcOrdenDespachoRepesajeActualizar1)
        Me.Name = "ucOrdenDespachoRepesaje"
        Me.Size = New System.Drawing.Size(1100, 800)
        Me.pnlContenedorPesaje.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedorPesaje As Panel
    Friend WithEvents UcPesaje1 As ucPesaje
    Friend WithEvents UcOrdenDespachoRepesajeActualizar1 As ucOrdenDespachoRepesajeActualizar
    Friend WithEvents UcOrdenDespachoRepesajeValidacion1 As ucOrdenDespachoRepesajeValidacion
End Class
