<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucRecepcionBloque
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
        Me.UcResumen1 = New sistemaPackingv2.ucResumen()
        Me.UcPesajeBloque1 = New sistemaPackingv2.ucPesajeBloque()
        Me.UcRecepcionEstadoBloque1 = New sistemaPackingv2.ucRecepcionEstadoBloque()
        Me.UcSelectorBloque1 = New sistemaPackingv2.ucSelectorBloque()
        Me.SuspendLayout()
        '
        'UcResumen1
        '
        Me.UcResumen1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcResumen1.Location = New System.Drawing.Point(0, 0)
        Me.UcResumen1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcResumen1.ModoActual = sistemaPackingv2.ucResumen.ModoOperacion.Recepcion
        Me.UcResumen1.Name = "UcResumen1"
        Me.UcResumen1.SelectedIdProducto = 0
        Me.UcResumen1.SelectedIdProductor = 0
        Me.UcResumen1.SelectedIdReferencia = 0
        Me.UcResumen1.SelectedIdVariedad = 0
        Me.UcResumen1.Size = New System.Drawing.Size(1200, 900)
        Me.UcResumen1.TabIndex = 4
        '
        'UcPesajeBloque1
        '
        Me.UcPesajeBloque1.Location = New System.Drawing.Point(0, 0)
        Me.UcPesajeBloque1.Name = "UcPesajeBloque1"
        Me.UcPesajeBloque1.Size = New System.Drawing.Size(1200, 900)
        Me.UcPesajeBloque1.TabIndex = 5
        '
        'UcRecepcionEstadoBloque1
        '
        Me.UcRecepcionEstadoBloque1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcRecepcionEstadoBloque1.Location = New System.Drawing.Point(0, 0)
        Me.UcRecepcionEstadoBloque1.Name = "UcRecepcionEstadoBloque1"
        Me.UcRecepcionEstadoBloque1.Size = New System.Drawing.Size(1200, 900)
        Me.UcRecepcionEstadoBloque1.TabIndex = 6
        '
        'UcSelectorBloque1
        '
        Me.UcSelectorBloque1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSelectorBloque1.Location = New System.Drawing.Point(0, 0)
        Me.UcSelectorBloque1.Name = "UcSelectorBloque1"
        Me.UcSelectorBloque1.Size = New System.Drawing.Size(1200, 900)
        Me.UcSelectorBloque1.TabIndex = 7
        '
        'ucRecepcionBloque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcRecepcionEstadoBloque1)
        Me.Controls.Add(Me.UcSelectorBloque1)
        Me.Controls.Add(Me.UcResumen1)
        Me.Controls.Add(Me.UcPesajeBloque1)
        Me.Name = "ucRecepcionBloque"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcResumen1 As ucResumen
    Friend WithEvents UcPesajeBloque1 As ucPesajeBloque
    Friend WithEvents UcRecepcionEstadoBloque1 As ucRecepcionEstadoBloque
    Friend WithEvents UcSelectorBloque1 As ucSelectorBloque
End Class
