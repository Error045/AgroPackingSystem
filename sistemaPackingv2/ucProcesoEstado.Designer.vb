<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProcesoEstado
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
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnVer = New System.Windows.Forms.Button()
		Me.btnTerminarProceso = New System.Windows.Forms.Button()
		Me.lbTituloRecepcion = New System.Windows.Forms.Label()
		Me.lblIdProceso = New System.Windows.Forms.Label()
		Me.lblCodigo = New System.Windows.Forms.Label()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.btnSiguiente = New System.Windows.Forms.Button()
		Me.cmbProcesoEstado = New System.Windows.Forms.ComboBox()
		Me.lblNumRecepcion = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnEliminar
		'
		Me.btnEliminar.BackColor = System.Drawing.Color.Tomato
		Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnEliminar.ForeColor = System.Drawing.Color.Black
		Me.btnEliminar.Location = New System.Drawing.Point(880, 182)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(78, 58)
		Me.btnEliminar.TabIndex = 26
		Me.btnEliminar.Text = "Eli"
		Me.btnEliminar.UseVisualStyleBackColor = False
		'
		'btnEditar
		'
		Me.btnEditar.BackColor = System.Drawing.Color.PeachPuff
		Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnEditar.ForeColor = System.Drawing.Color.Black
		Me.btnEditar.Location = New System.Drawing.Point(782, 182)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(78, 58)
		Me.btnEditar.TabIndex = 25
		Me.btnEditar.Text = "Edit"
		Me.btnEditar.UseVisualStyleBackColor = False
		'
		'btnVer
		'
		Me.btnVer.BackColor = System.Drawing.SystemColors.ButtonShadow
		Me.btnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVer.Location = New System.Drawing.Point(685, 182)
		Me.btnVer.Name = "btnVer"
		Me.btnVer.Size = New System.Drawing.Size(78, 58)
		Me.btnVer.TabIndex = 24
		Me.btnVer.Text = "Ver"
		Me.btnVer.UseVisualStyleBackColor = False
		'
		'btnTerminarProceso
		'
		Me.btnTerminarProceso.BackColor = System.Drawing.Color.Red
		Me.btnTerminarProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnTerminarProceso.ForeColor = System.Drawing.SystemColors.ControlLight
		Me.btnTerminarProceso.Location = New System.Drawing.Point(313, 507)
		Me.btnTerminarProceso.Name = "btnTerminarProceso"
		Me.btnTerminarProceso.Size = New System.Drawing.Size(188, 94)
		Me.btnTerminarProceso.TabIndex = 23
		Me.btnTerminarProceso.Text = "TERMINAR PROCESO"
		Me.btnTerminarProceso.UseVisualStyleBackColor = False
		'
		'lbTituloRecepcion
		'
		Me.lbTituloRecepcion.AutoSize = True
		Me.lbTituloRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbTituloRecepcion.Location = New System.Drawing.Point(273, 60)
		Me.lbTituloRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lbTituloRecepcion.Name = "lbTituloRecepcion"
		Me.lbTituloRecepcion.Size = New System.Drawing.Size(302, 42)
		Me.lbTituloRecepcion.TabIndex = 22
		Me.lbTituloRecepcion.Text = "Ingresar Proceso"
		'
		'lblIdProceso
		'
		Me.lblIdProceso.AutoSize = True
		Me.lblIdProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdProceso.Location = New System.Drawing.Point(373, 273)
		Me.lblIdProceso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIdProceso.Name = "lblIdProceso"
		Me.lblIdProceso.Size = New System.Drawing.Size(120, 36)
		Me.lblIdProceso.TabIndex = 21
		Me.lblIdProceso.Text = "Número"
		'
		'lblCodigo
		'
		Me.lblCodigo.AutoSize = True
		Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCodigo.Location = New System.Drawing.Point(112, 273)
		Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblCodigo.Name = "lblCodigo"
		Me.lblCodigo.Size = New System.Drawing.Size(167, 36)
		Me.lblCodigo.TabIndex = 20
		Me.lblCodigo.Text = "N° Proceso"
		'
		'btnCancelar
		'
		Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancelar.Location = New System.Drawing.Point(197, 388)
		Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(179, 73)
		Me.btnCancelar.TabIndex = 19
		Me.btnCancelar.Text = "Cancelar"
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'btnSiguiente
		'
		Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSiguiente.Location = New System.Drawing.Point(415, 388)
		Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.btnSiguiente.Name = "btnSiguiente"
		Me.btnSiguiente.Size = New System.Drawing.Size(179, 73)
		Me.btnSiguiente.TabIndex = 18
		Me.btnSiguiente.Text = "Siguiente"
		Me.btnSiguiente.UseVisualStyleBackColor = True
		'
		'cmbProcesoEstado
		'
		Me.cmbProcesoEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cmbProcesoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbProcesoEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbProcesoEstado.FormattingEnabled = True
		Me.cmbProcesoEstado.ItemHeight = 40
		Me.cmbProcesoEstado.Location = New System.Drawing.Point(280, 182)
		Me.cmbProcesoEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.cmbProcesoEstado.MaxDropDownItems = 6
		Me.cmbProcesoEstado.Name = "cmbProcesoEstado"
		Me.cmbProcesoEstado.Size = New System.Drawing.Size(348, 46)
		Me.cmbProcesoEstado.TabIndex = 17
		'
		'lblNumRecepcion
		'
		Me.lblNumRecepcion.AutoSize = True
		Me.lblNumRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNumRecepcion.Location = New System.Drawing.Point(112, 182)
		Me.lblNumRecepcion.Name = "lblNumRecepcion"
		Me.lblNumRecepcion.Size = New System.Drawing.Size(120, 36)
		Me.lblNumRecepcion.TabIndex = 16
		Me.lblNumRecepcion.Text = "Nombre"
		'
		'ucProcesoEstado
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.ControlDark
		Me.Controls.Add(Me.btnEliminar)
		Me.Controls.Add(Me.btnEditar)
		Me.Controls.Add(Me.btnVer)
		Me.Controls.Add(Me.btnTerminarProceso)
		Me.Controls.Add(Me.lbTituloRecepcion)
		Me.Controls.Add(Me.lblIdProceso)
		Me.Controls.Add(Me.lblCodigo)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.btnSiguiente)
		Me.Controls.Add(Me.cmbProcesoEstado)
		Me.Controls.Add(Me.lblNumRecepcion)
		Me.Name = "ucProcesoEstado"
		Me.Size = New System.Drawing.Size(1000, 900)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnEliminar As Button
	Friend WithEvents btnEditar As Button
	Friend WithEvents btnVer As Button
	Friend WithEvents btnTerminarProceso As Button
	Friend WithEvents lbTituloRecepcion As Label
	Friend WithEvents lblIdProceso As Label
	Friend WithEvents lblCodigo As Label
	Friend WithEvents btnCancelar As Button
	Friend WithEvents btnSiguiente As Button
	Friend WithEvents cmbProcesoEstado As ComboBox
	Friend WithEvents lblNumRecepcion As Label
End Class
