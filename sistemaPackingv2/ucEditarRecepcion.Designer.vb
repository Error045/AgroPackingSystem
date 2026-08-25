<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEditarRecepcion
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
		Me.lblFecha = New System.Windows.Forms.Label()
		Me.cmbPersona = New System.Windows.Forms.ComboBox()
		Me.dateRecepcion = New System.Windows.Forms.DateTimePicker()
		Me.lblRecepcionTitulo = New System.Windows.Forms.Label()
		Me.lblRecepcion = New System.Windows.Forms.Label()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.btnModificar = New System.Windows.Forms.Button()
		Me.cmbTipoRecepcion = New System.Windows.Forms.ComboBox()
		Me.lnlTipoRecepcion = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(132, 297)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(126, 36)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Persona"
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFecha.Location = New System.Drawing.Point(132, 373)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(97, 36)
		Me.lblFecha.TabIndex = 1
		Me.lblFecha.Text = "Fecha"
		'
		'cmbPersona
		'
		Me.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbPersona.FormattingEnabled = True
		Me.cmbPersona.Location = New System.Drawing.Point(361, 297)
		Me.cmbPersona.Name = "cmbPersona"
		Me.cmbPersona.Size = New System.Drawing.Size(299, 44)
		Me.cmbPersona.TabIndex = 2
		'
		'dateRecepcion
		'
		Me.dateRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dateRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dateRecepcion.Location = New System.Drawing.Point(361, 373)
		Me.dateRecepcion.Name = "dateRecepcion"
		Me.dateRecepcion.Size = New System.Drawing.Size(227, 41)
		Me.dateRecepcion.TabIndex = 3
		'
		'lblRecepcionTitulo
		'
		Me.lblRecepcionTitulo.AutoSize = True
		Me.lblRecepcionTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecepcionTitulo.Location = New System.Drawing.Point(132, 146)
		Me.lblRecepcionTitulo.Name = "lblRecepcionTitulo"
		Me.lblRecepcionTitulo.Size = New System.Drawing.Size(199, 36)
		Me.lblRecepcionTitulo.TabIndex = 4
		Me.lblRecepcionTitulo.Text = "N° Recepción"
		'
		'lblRecepcion
		'
		Me.lblRecepcion.AutoSize = True
		Me.lblRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRecepcion.Location = New System.Drawing.Point(450, 149)
		Me.lblRecepcion.Name = "lblRecepcion"
		Me.lblRecepcion.Size = New System.Drawing.Size(32, 36)
		Me.lblRecepcion.TabIndex = 5
		Me.lblRecepcion.Text = "0"
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.Location = New System.Drawing.Point(252, 41)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(326, 46)
		Me.lblTitulo.TabIndex = 6
		Me.lblTitulo.Text = "Editar Recepción"
		'
		'btnCancelar
		'
		Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancelar.Location = New System.Drawing.Point(220, 514)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(188, 82)
		Me.btnCancelar.TabIndex = 7
		Me.btnCancelar.Text = "Cancelar"
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'btnModificar
		'
		Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnModificar.Location = New System.Drawing.Point(503, 514)
		Me.btnModificar.Name = "btnModificar"
		Me.btnModificar.Size = New System.Drawing.Size(188, 82)
		Me.btnModificar.TabIndex = 8
		Me.btnModificar.Text = "Modificar"
		Me.btnModificar.UseVisualStyleBackColor = True
		'
		'cmbTipoRecepcion
		'
		Me.cmbTipoRecepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoRecepcion.FormattingEnabled = True
		Me.cmbTipoRecepcion.Location = New System.Drawing.Point(361, 224)
		Me.cmbTipoRecepcion.Name = "cmbTipoRecepcion"
		Me.cmbTipoRecepcion.Size = New System.Drawing.Size(280, 44)
		Me.cmbTipoRecepcion.TabIndex = 10
		'
		'lnlTipoRecepcion
		'
		Me.lnlTipoRecepcion.AutoSize = True
		Me.lnlTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lnlTipoRecepcion.Location = New System.Drawing.Point(132, 224)
		Me.lnlTipoRecepcion.Name = "lnlTipoRecepcion"
		Me.lnlTipoRecepcion.Size = New System.Drawing.Size(74, 36)
		Me.lnlTipoRecepcion.TabIndex = 9
		Me.lnlTipoRecepcion.Text = "Tipo"
		'
		'ucEditarRecepcion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.cmbTipoRecepcion)
		Me.Controls.Add(Me.lnlTipoRecepcion)
		Me.Controls.Add(Me.btnModificar)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.lblTitulo)
		Me.Controls.Add(Me.lblRecepcion)
		Me.Controls.Add(Me.lblRecepcionTitulo)
		Me.Controls.Add(Me.dateRecepcion)
		Me.Controls.Add(Me.cmbPersona)
		Me.Controls.Add(Me.lblFecha)
		Me.Controls.Add(Me.Label1)
		Me.Name = "ucEditarRecepcion"
		Me.Size = New System.Drawing.Size(893, 702)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents lblFecha As Label
	Friend WithEvents cmbPersona As ComboBox
	Friend WithEvents dateRecepcion As DateTimePicker
	Friend WithEvents lblRecepcionTitulo As Label
	Friend WithEvents lblRecepcion As Label
	Friend WithEvents lblTitulo As Label
	Friend WithEvents btnCancelar As Button
	Friend WithEvents btnModificar As Button
	Friend WithEvents cmbTipoRecepcion As ComboBox
	Friend WithEvents lnlTipoRecepcion As Label
End Class
