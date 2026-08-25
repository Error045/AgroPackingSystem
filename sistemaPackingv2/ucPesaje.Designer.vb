<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPesaje
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
		Me.components = New System.ComponentModel.Container()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.lblIdRecepcion = New System.Windows.Forms.Label()
		Me.lblProducto = New System.Windows.Forms.Label()
		Me.lblVariedad = New System.Windows.Forms.Label()
		Me.lblProductor = New System.Windows.Forms.Label()
		Me.lblPeso = New System.Windows.Forms.Label()
		Me.btnCapturarPeso = New System.Windows.Forms.Button()
		Me.flpContenedores = New System.Windows.Forms.FlowLayoutPanel()
		Me.rbContenedor1 = New System.Windows.Forms.RadioButton()
		Me.rbContenedor2 = New System.Windows.Forms.RadioButton()
		Me.pnlInferior = New System.Windows.Forms.Panel()
		Me.pnlMedio = New System.Windows.Forms.Panel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.lblPesoTotal = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblIdProceso = New System.Windows.Forms.Label()
		Me.flpInfoCabecera = New System.Windows.Forms.FlowLayoutPanel()
		Me.lblIdCalibrado = New System.Windows.Forms.Label()
		Me.lblCalibre = New System.Windows.Forms.Label()
		Me.flpContenedores.SuspendLayout()
		Me.pnlMedio.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.flpInfoCabecera.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.Location = New System.Drawing.Point(476, 31)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(266, 42)
		Me.lblTitulo.TabIndex = 0
		Me.lblTitulo.Text = "Contenedor #1"
		'
		'lblIdRecepcion
		'
		Me.lblIdRecepcion.AutoSize = True
		Me.lblIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdRecepcion.Location = New System.Drawing.Point(3, 0)
		Me.lblIdRecepcion.Name = "lblIdRecepcion"
		Me.lblIdRecepcion.Size = New System.Drawing.Size(129, 29)
		Me.lblIdRecepcion.TabIndex = 5
		Me.lblIdRecepcion.Text = "Recepcion"
		'
		'lblProducto
		'
		Me.lblProducto.AutoSize = True
		Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProducto.Location = New System.Drawing.Point(3, 116)
		Me.lblProducto.Name = "lblProducto"
		Me.lblProducto.Size = New System.Drawing.Size(110, 29)
		Me.lblProducto.TabIndex = 8
		Me.lblProducto.Text = "Producto"
		'
		'lblVariedad
		'
		Me.lblVariedad.AutoSize = True
		Me.lblVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblVariedad.Location = New System.Drawing.Point(3, 145)
		Me.lblVariedad.Name = "lblVariedad"
		Me.lblVariedad.Size = New System.Drawing.Size(110, 29)
		Me.lblVariedad.TabIndex = 10
		Me.lblVariedad.Text = "Variedad"
		'
		'lblProductor
		'
		Me.lblProductor.AutoSize = True
		Me.lblProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProductor.Location = New System.Drawing.Point(3, 87)
		Me.lblProductor.Name = "lblProductor"
		Me.lblProductor.Size = New System.Drawing.Size(118, 29)
		Me.lblProductor.TabIndex = 11
		Me.lblProductor.Text = "Productor"
		'
		'lblPeso
		'
		Me.lblPeso.AutoSize = True
		Me.lblPeso.Font = New System.Drawing.Font("Tahoma", 120.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPeso.Location = New System.Drawing.Point(479, 98)
		Me.lblPeso.Name = "lblPeso"
		Me.lblPeso.Size = New System.Drawing.Size(321, 241)
		Me.lblPeso.TabIndex = 14
		Me.lblPeso.Text = "---"
		'
		'btnCapturarPeso
		'
		Me.btnCapturarPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCapturarPeso.Location = New System.Drawing.Point(483, 218)
		Me.btnCapturarPeso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.btnCapturarPeso.Name = "btnCapturarPeso"
		Me.btnCapturarPeso.Size = New System.Drawing.Size(440, 119)
		Me.btnCapturarPeso.TabIndex = 15
		Me.btnCapturarPeso.Text = "Capturar"
		Me.btnCapturarPeso.UseVisualStyleBackColor = True
		'
		'flpContenedores
		'
		Me.flpContenedores.AutoScroll = True
		Me.flpContenedores.Controls.Add(Me.rbContenedor1)
		Me.flpContenedores.Controls.Add(Me.rbContenedor2)
		Me.flpContenedores.Location = New System.Drawing.Point(286, 36)
		Me.flpContenedores.Margin = New System.Windows.Forms.Padding(4)
		Me.flpContenedores.Name = "flpContenedores"
		Me.flpContenedores.Size = New System.Drawing.Size(1036, 176)
		Me.flpContenedores.TabIndex = 16
		'
		'rbContenedor1
		'
		Me.rbContenedor1.Appearance = System.Windows.Forms.Appearance.Button
		Me.rbContenedor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rbContenedor1.Location = New System.Drawing.Point(4, 2)
		Me.rbContenedor1.Margin = New System.Windows.Forms.Padding(4, 2, 3, 2)
		Me.rbContenedor1.Name = "rbContenedor1"
		Me.rbContenedor1.Size = New System.Drawing.Size(254, 145)
		Me.rbContenedor1.TabIndex = 6
		Me.rbContenedor1.Text = "34 kg"
		Me.rbContenedor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rbContenedor1.UseVisualStyleBackColor = True
		'
		'rbContenedor2
		'
		Me.rbContenedor2.Appearance = System.Windows.Forms.Appearance.Button
		Me.rbContenedor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rbContenedor2.Location = New System.Drawing.Point(265, 2)
		Me.rbContenedor2.Margin = New System.Windows.Forms.Padding(4, 2, 3, 2)
		Me.rbContenedor2.Name = "rbContenedor2"
		Me.rbContenedor2.Size = New System.Drawing.Size(254, 145)
		Me.rbContenedor2.TabIndex = 5
		Me.rbContenedor2.Text = "43 Kg"
		Me.rbContenedor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rbContenedor2.UseVisualStyleBackColor = True
		'
		'pnlInferior
		'
		Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.pnlInferior.Location = New System.Drawing.Point(0, 978)
		Me.pnlInferior.Margin = New System.Windows.Forms.Padding(4)
		Me.pnlInferior.Name = "pnlInferior"
		Me.pnlInferior.Size = New System.Drawing.Size(1600, 70)
		Me.pnlInferior.TabIndex = 18
		'
		'pnlMedio
		'
		Me.pnlMedio.Controls.Add(Me.flpContenedores)
		Me.pnlMedio.Controls.Add(Me.btnCapturarPeso)
		Me.pnlMedio.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.pnlMedio.Location = New System.Drawing.Point(0, 635)
		Me.pnlMedio.Name = "pnlMedio"
		Me.pnlMedio.Size = New System.Drawing.Size(1600, 343)
		Me.pnlMedio.TabIndex = 19
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'lblPesoTotal
		'
		Me.lblPesoTotal.AutoSize = True
		Me.lblPesoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPesoTotal.Location = New System.Drawing.Point(278, 27)
		Me.lblPesoTotal.Name = "lblPesoTotal"
		Me.lblPesoTotal.Size = New System.Drawing.Size(248, 46)
		Me.lblPesoTotal.TabIndex = 20
		Me.lblPesoTotal.Text = "Valor Actual:"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblPesoTotal)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 531)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1600, 104)
		Me.Panel1.TabIndex = 21
		'
		'lblIdProceso
		'
		Me.lblIdProceso.AutoSize = True
		Me.lblIdProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdProceso.Location = New System.Drawing.Point(3, 29)
		Me.lblIdProceso.Name = "lblIdProceso"
		Me.lblIdProceso.Size = New System.Drawing.Size(103, 29)
		Me.lblIdProceso.TabIndex = 22
		Me.lblIdProceso.Text = "Proceso"
		'
		'flpInfoCabecera
		'
		Me.flpInfoCabecera.Controls.Add(Me.lblIdRecepcion)
		Me.flpInfoCabecera.Controls.Add(Me.lblIdProceso)
		Me.flpInfoCabecera.Controls.Add(Me.lblIdCalibrado)
		Me.flpInfoCabecera.Controls.Add(Me.lblProductor)
		Me.flpInfoCabecera.Controls.Add(Me.lblProducto)
		Me.flpInfoCabecera.Controls.Add(Me.lblVariedad)
		Me.flpInfoCabecera.Controls.Add(Me.lblCalibre)
		Me.flpInfoCabecera.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
		Me.flpInfoCabecera.Location = New System.Drawing.Point(14, 64)
		Me.flpInfoCabecera.Name = "flpInfoCabecera"
		Me.flpInfoCabecera.Size = New System.Drawing.Size(261, 378)
		Me.flpInfoCabecera.TabIndex = 23
		'
		'lblIdCalibrado
		'
		Me.lblIdCalibrado.AutoSize = True
		Me.lblIdCalibrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdCalibrado.Location = New System.Drawing.Point(3, 58)
		Me.lblIdCalibrado.Name = "lblIdCalibrado"
		Me.lblIdCalibrado.Size = New System.Drawing.Size(118, 29)
		Me.lblIdCalibrado.TabIndex = 23
		Me.lblIdCalibrado.Text = "Calibrado"
		'
		'lblCalibre
		'
		Me.lblCalibre.AutoSize = True
		Me.lblCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCalibre.Location = New System.Drawing.Point(3, 174)
		Me.lblCalibre.Name = "lblCalibre"
		Me.lblCalibre.Size = New System.Drawing.Size(91, 29)
		Me.lblCalibre.TabIndex = 24
		Me.lblCalibre.Text = "Calibre"
		'
		'ucPesaje
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.flpInfoCabecera)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.pnlMedio)
		Me.Controls.Add(Me.pnlInferior)
		Me.Controls.Add(Me.lblPeso)
		Me.Controls.Add(Me.lblTitulo)
		Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.Name = "ucPesaje"
		Me.Size = New System.Drawing.Size(1600, 1048)
		Me.flpContenedores.ResumeLayout(False)
		Me.pnlMedio.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.flpInfoCabecera.ResumeLayout(False)
		Me.flpInfoCabecera.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lblTitulo As Label
	Friend WithEvents lblIdRecepcion As Label
	Friend WithEvents lblProducto As Label
	Friend WithEvents lblVariedad As Label
	Friend WithEvents lblProductor As Label
	Friend WithEvents lblPeso As Label
	Friend WithEvents btnCapturarPeso As Button
	Friend WithEvents flpContenedores As FlowLayoutPanel
	Friend WithEvents pnlInferior As Panel
	Friend WithEvents pnlMedio As Panel
	Friend WithEvents rbContenedor1 As RadioButton
	Friend WithEvents rbContenedor2 As RadioButton
	Friend WithEvents Timer1 As Timer
	Friend WithEvents lblPesoTotal As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents lblIdProceso As Label
	Friend WithEvents flpInfoCabecera As FlowLayoutPanel
	Friend WithEvents lblIdCalibrado As Label
	Friend WithEvents lblCalibre As Label
End Class
