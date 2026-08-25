<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlObjeto
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
		Me.btnCapturar = New System.Windows.Forms.Button()
		Me.txtCodigo = New System.Windows.Forms.TextBox()
		Me.txtPeso = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.RadioButton1 = New System.Windows.Forms.RadioButton()
		Me.RadioButton2 = New System.Windows.Forms.RadioButton()
		Me.RadioButton3 = New System.Windows.Forms.RadioButton()
		Me.SuspendLayout()
		'
		'btnCapturar
		'
		Me.btnCapturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCapturar.Location = New System.Drawing.Point(262, 385)
		Me.btnCapturar.Name = "btnCapturar"
		Me.btnCapturar.Size = New System.Drawing.Size(199, 107)
		Me.btnCapturar.TabIndex = 3
		Me.btnCapturar.Text = "Seleccionar"
		Me.btnCapturar.UseVisualStyleBackColor = True
		'
		'txtCodigo
		'
		Me.txtCodigo.Location = New System.Drawing.Point(40, 333)
		Me.txtCodigo.Name = "txtCodigo"
		Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
		Me.txtCodigo.TabIndex = 2
		'
		'txtPeso
		'
		Me.txtPeso.Location = New System.Drawing.Point(40, 286)
		Me.txtPeso.Name = "txtPeso"
		Me.txtPeso.Size = New System.Drawing.Size(100, 22)
		Me.txtPeso.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(26, 395)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(43, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Bins 1"
		'
		'RadioButton1
		'
		Me.RadioButton1.Appearance = System.Windows.Forms.Appearance.Button
		Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton1.Location = New System.Drawing.Point(280, 92)
		Me.RadioButton1.Name = "RadioButton1"
		Me.RadioButton1.Size = New System.Drawing.Size(164, 63)
		Me.RadioButton1.TabIndex = 4
		Me.RadioButton1.TabStop = True
		Me.RadioButton1.Text = "1"
		Me.RadioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RadioButton1.UseVisualStyleBackColor = True
		'
		'RadioButton2
		'
		Me.RadioButton2.Appearance = System.Windows.Forms.Appearance.Button
		Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton2.Location = New System.Drawing.Point(280, 181)
		Me.RadioButton2.Name = "RadioButton2"
		Me.RadioButton2.Size = New System.Drawing.Size(163, 63)
		Me.RadioButton2.TabIndex = 5
		Me.RadioButton2.TabStop = True
		Me.RadioButton2.Text = "2"
		Me.RadioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RadioButton2.UseVisualStyleBackColor = True
		'
		'RadioButton3
		'
		Me.RadioButton3.Appearance = System.Windows.Forms.Appearance.Button
		Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton3.Location = New System.Drawing.Point(281, 270)
		Me.RadioButton3.Name = "RadioButton3"
		Me.RadioButton3.Size = New System.Drawing.Size(163, 63)
		Me.RadioButton3.TabIndex = 6
		Me.RadioButton3.TabStop = True
		Me.RadioButton3.Text = "3"
		Me.RadioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.RadioButton3.UseVisualStyleBackColor = True
		'
		'ctlObjeto
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.RadioButton3)
		Me.Controls.Add(Me.RadioButton2)
		Me.Controls.Add(Me.RadioButton1)
		Me.Controls.Add(Me.btnCapturar)
		Me.Controls.Add(Me.txtCodigo)
		Me.Controls.Add(Me.txtPeso)
		Me.Controls.Add(Me.Label1)
		Me.Name = "ctlObjeto"
		Me.Size = New System.Drawing.Size(845, 630)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnCapturar As Button
	Friend WithEvents txtCodigo As TextBox
	Friend WithEvents txtPeso As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents RadioButton3 As RadioButton
End Class
