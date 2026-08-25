<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSelector
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
		Me.rb3 = New System.Windows.Forms.RadioButton()
		Me.rb2 = New System.Windows.Forms.RadioButton()
		Me.rb1 = New System.Windows.Forms.RadioButton()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'rb3
		'
		Me.rb3.Appearance = System.Windows.Forms.Appearance.Button
		Me.rb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rb3.Location = New System.Drawing.Point(70, 300)
		Me.rb3.Name = "rb3"
		Me.rb3.Size = New System.Drawing.Size(223, 70)
		Me.rb3.TabIndex = 9
		Me.rb3.TabStop = True
		Me.rb3.Text = "3"
		Me.rb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rb3.UseVisualStyleBackColor = True
		'
		'rb2
		'
		Me.rb2.Appearance = System.Windows.Forms.Appearance.Button
		Me.rb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rb2.Location = New System.Drawing.Point(70, 186)
		Me.rb2.Name = "rb2"
		Me.rb2.Size = New System.Drawing.Size(224, 70)
		Me.rb2.TabIndex = 8
		Me.rb2.TabStop = True
		Me.rb2.Text = "2"
		Me.rb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rb2.UseVisualStyleBackColor = True
		'
		'rb1
		'
		Me.rb1.Appearance = System.Windows.Forms.Appearance.Button
		Me.rb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rb1.Location = New System.Drawing.Point(70, 77)
		Me.rb1.Name = "rb1"
		Me.rb1.Size = New System.Drawing.Size(223, 70)
		Me.rb1.TabIndex = 7
		Me.rb1.TabStop = True
		Me.rb1.Text = "1"
		Me.rb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rb1.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.rb3)
		Me.GroupBox1.Controls.Add(Me.rb2)
		Me.GroupBox1.Controls.Add(Me.rb1)
		Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(253, 95)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(362, 454)
		Me.GroupBox1.TabIndex = 10
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Nuevo Ciclo"
		'
		'ucSelector
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.GroupBox1)
		Me.Name = "ucSelector"
		Me.Size = New System.Drawing.Size(830, 691)
		Me.GroupBox1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents rb3 As RadioButton
	Friend WithEvents rb2 As RadioButton
	Friend WithEvents rb1 As RadioButton
	Friend WithEvents GroupBox1 As GroupBox
End Class
