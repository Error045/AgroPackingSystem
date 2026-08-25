<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucNuevaRecepcion
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
		Me.lblRecepcion = New System.Windows.Forms.Label()
		Me.lblPersona = New System.Windows.Forms.Label()
		Me.cmbTipoRecepcion = New System.Windows.Forms.ComboBox()
		Me.cmbPersona = New System.Windows.Forms.ComboBox()
		Me.lblFecha = New System.Windows.Forms.Label()
		Me.btnRegistrar = New System.Windows.Forms.Button()
		Me.btnVolver = New System.Windows.Forms.Button()
		Me.datepicker = New System.Windows.Forms.DateTimePicker()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'lblRecepcion
		'
		Me.lblRecepcion.AutoSize = True
		Me.lblRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecepcion.Location = New System.Drawing.Point(160, 215)
		Me.lblRecepcion.Name = "lblRecepcion"
		Me.lblRecepcion.Size = New System.Drawing.Size(157, 36)
		Me.lblRecepcion.TabIndex = 0
		Me.lblRecepcion.Text = "Recepción"
		Me.lblRecepcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblPersona
		'
		Me.lblPersona.AutoSize = True
		Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPersona.Location = New System.Drawing.Point(160, 294)
		Me.lblPersona.Name = "lblPersona"
		Me.lblPersona.Size = New System.Drawing.Size(126, 36)
		Me.lblPersona.TabIndex = 1
		Me.lblPersona.Text = "Persona"
		'
		'cmbTipoRecepcion
		'
		Me.cmbTipoRecepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoRecepcion.FormattingEnabled = True
		Me.cmbTipoRecepcion.Location = New System.Drawing.Point(358, 212)
		Me.cmbTipoRecepcion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.cmbTipoRecepcion.Name = "cmbTipoRecepcion"
		Me.cmbTipoRecepcion.Size = New System.Drawing.Size(321, 46)
		Me.cmbTipoRecepcion.TabIndex = 2
		'
		'cmbPersona
		'
		Me.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbPersona.FormattingEnabled = True
		Me.cmbPersona.Location = New System.Drawing.Point(358, 294)
		Me.cmbPersona.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.cmbPersona.Name = "cmbPersona"
		Me.cmbPersona.Size = New System.Drawing.Size(321, 46)
		Me.cmbPersona.TabIndex = 3
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFecha.Location = New System.Drawing.Point(160, 399)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(97, 36)
		Me.lblFecha.TabIndex = 5
		Me.lblFecha.Text = "Fecha"
		'
		'btnRegistrar
		'
		Me.btnRegistrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRegistrar.Location = New System.Drawing.Point(531, 559)
		Me.btnRegistrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.btnRegistrar.Name = "btnRegistrar"
		Me.btnRegistrar.Size = New System.Drawing.Size(196, 105)
		Me.btnRegistrar.TabIndex = 8
		Me.btnRegistrar.Text = "Registrar"
		Me.btnRegistrar.UseVisualStyleBackColor = True
		'
		'btnVolver
		'
		Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVolver.Location = New System.Drawing.Point(241, 559)
		Me.btnVolver.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.btnVolver.Name = "btnVolver"
		Me.btnVolver.Size = New System.Drawing.Size(196, 105)
		Me.btnVolver.TabIndex = 9
		Me.btnVolver.Text = "Volver"
		Me.btnVolver.UseVisualStyleBackColor = True
		'
		'datepicker
		'
		Me.datepicker.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.datepicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.datepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.datepicker.Location = New System.Drawing.Point(358, 392)
		Me.datepicker.Name = "datepicker"
		Me.datepicker.Size = New System.Drawing.Size(236, 45)
		Me.datepicker.TabIndex = 10
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(323, 62)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(336, 46)
		Me.Label1.TabIndex = 11
		Me.Label1.Text = "Nueva Recepción"
		'
		'ucNuevaRecepcion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.datepicker)
		Me.Controls.Add(Me.btnVolver)
		Me.Controls.Add(Me.btnRegistrar)
		Me.Controls.Add(Me.lblFecha)
		Me.Controls.Add(Me.cmbPersona)
		Me.Controls.Add(Me.cmbTipoRecepcion)
		Me.Controls.Add(Me.lblPersona)
		Me.Controls.Add(Me.lblRecepcion)
		Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.Name = "ucNuevaRecepcion"
		Me.Size = New System.Drawing.Size(1200, 900)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lblRecepcion As Label
	Friend WithEvents lblPersona As Label
	Friend WithEvents cmbTipoRecepcion As ComboBox
	Friend WithEvents cmbPersona As ComboBox
	Friend WithEvents lblFecha As Label
	Friend WithEvents btnRegistrar As Button
	Friend WithEvents btnVolver As Button
	Friend WithEvents datepicker As DateTimePicker
	Friend WithEvents Label1 As Label
End Class
