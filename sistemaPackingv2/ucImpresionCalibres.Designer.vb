<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucImpresionCalibres
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
        Me.txtCalibre = New System.Windows.Forms.TextBox()
        Me.nudCopias = New System.Windows.Forms.NumericUpDown()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.nudCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCalibre
        '
        Me.txtCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalibre.Location = New System.Drawing.Point(232, 150)
        Me.txtCalibre.Name = "txtCalibre"
        Me.txtCalibre.Size = New System.Drawing.Size(211, 38)
        Me.txtCalibre.TabIndex = 0
        '
        'nudCopias
        '
        Me.nudCopias.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCopias.Location = New System.Drawing.Point(232, 238)
        Me.nudCopias.Name = "nudCopias"
        Me.nudCopias.Size = New System.Drawing.Size(87, 49)
        Me.nudCopias.TabIndex = 1
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(189, 372)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(225, 99)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "CALIBRE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(259, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IMPRIMIR TICKETS CALIBRES"
        '
        'ucImpresionCalibres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.nudCopias)
        Me.Controls.Add(Me.txtCalibre)
        Me.Name = "ucImpresionCalibres"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.nudCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCalibre As TextBox
    Friend WithEvents nudCopias As NumericUpDown
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
