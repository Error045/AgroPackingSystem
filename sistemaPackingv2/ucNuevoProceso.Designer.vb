<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNuevoProceso
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblRecep = New System.Windows.Forms.Label()
		Me.cmbRecepcionEstado = New System.Windows.Forms.ComboBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.btnRegistrar = New System.Windows.Forms.Button()
		Me.lblIdRecepcion = New System.Windows.Forms.Label()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(371, 63)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(275, 42)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Nuevo Proceso"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(134, 169)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(157, 36)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Recepción"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(134, 333)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(97, 36)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Fecha"
		'
		'lblRecep
		'
		Me.lblRecep.AutoSize = True
		Me.lblRecep.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecep.Location = New System.Drawing.Point(134, 259)
		Me.lblRecep.Name = "lblRecep"
		Me.lblRecep.Size = New System.Drawing.Size(199, 36)
		Me.lblRecep.TabIndex = 3
		Me.lblRecep.Text = "N° Recepción"
		'
		'cmbRecepcionEstado
		'
		Me.cmbRecepcionEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbRecepcionEstado.FormattingEnabled = True
		Me.cmbRecepcionEstado.Location = New System.Drawing.Point(378, 170)
		Me.cmbRecepcionEstado.Name = "cmbRecepcionEstado"
		Me.cmbRecepcionEstado.Size = New System.Drawing.Size(382, 44)
		Me.cmbRecepcionEstado.TabIndex = 4
		'
		'Button1
		'
		Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button1.Location = New System.Drawing.Point(236, 455)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(232, 107)
		Me.Button1.TabIndex = 6
		Me.Button1.Text = "Cancelar"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'btnRegistrar
		'
		Me.btnRegistrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRegistrar.Location = New System.Drawing.Point(541, 455)
		Me.btnRegistrar.Name = "btnRegistrar"
		Me.btnRegistrar.Size = New System.Drawing.Size(232, 107)
		Me.btnRegistrar.TabIndex = 7
		Me.btnRegistrar.Text = "Registrar"
		Me.btnRegistrar.UseVisualStyleBackColor = True
		'
		'lblIdRecepcion
		'
		Me.lblIdRecepcion.AutoSize = True
		Me.lblIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdRecepcion.Location = New System.Drawing.Point(436, 260)
		Me.lblIdRecepcion.Name = "lblIdRecepcion"
		Me.lblIdRecepcion.Size = New System.Drawing.Size(32, 36)
		Me.lblIdRecepcion.TabIndex = 8
		Me.lblIdRecepcion.Text = "0"
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.DateTimePicker1.Location = New System.Drawing.Point(378, 329)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(197, 41)
		Me.DateTimePicker1.TabIndex = 9
		'
		'ucNuevoProceso
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.lblIdRecepcion)
		Me.Controls.Add(Me.btnRegistrar)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.cmbRecepcionEstado)
		Me.Controls.Add(Me.lblRecep)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Name = "ucNuevoProceso"
		Me.Size = New System.Drawing.Size(1035, 709)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents lblRecep As Label
	Friend WithEvents cmbRecepcionEstado As ComboBox
	Friend WithEvents Button1 As Button
	Friend WithEvents btnRegistrar As Button
	Friend WithEvents lblIdRecepcion As Label
	Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
