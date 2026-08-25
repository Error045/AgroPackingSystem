<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucTicket
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
		Me.btnVerQR = New System.Windows.Forms.Button()
		Me.btnVistaPrevia = New System.Windows.Forms.Button()
		Me.btnFinal = New System.Windows.Forms.Button()
		Me.btnNuevaRecepcion = New System.Windows.Forms.Button()
		Me.btnImprimirTodo = New System.Windows.Forms.Button()
		Me.dgvFinal = New System.Windows.Forms.DataGridView()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.btnImpQr = New System.Windows.Forms.Button()
		CType(Me.dgvFinal, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnVerQR
		'
		Me.btnVerQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVerQR.Location = New System.Drawing.Point(429, 342)
		Me.btnVerQR.Name = "btnVerQR"
		Me.btnVerQR.Size = New System.Drawing.Size(190, 77)
		Me.btnVerQR.TabIndex = 13
		Me.btnVerQR.Text = "Vista QR"
		Me.btnVerQR.UseVisualStyleBackColor = True
		'
		'btnVistaPrevia
		'
		Me.btnVistaPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVistaPrevia.Location = New System.Drawing.Point(664, 342)
		Me.btnVistaPrevia.Name = "btnVistaPrevia"
		Me.btnVistaPrevia.Size = New System.Drawing.Size(190, 77)
		Me.btnVistaPrevia.TabIndex = 12
		Me.btnVistaPrevia.Text = "Vista Previa"
		Me.btnVistaPrevia.UseVisualStyleBackColor = True
		'
		'btnFinal
		'
		Me.btnFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFinal.Location = New System.Drawing.Point(648, 485)
		Me.btnFinal.Name = "btnFinal"
		Me.btnFinal.Size = New System.Drawing.Size(206, 75)
		Me.btnFinal.TabIndex = 11
		Me.btnFinal.Text = "Siguiente"
		Me.btnFinal.UseVisualStyleBackColor = True
		'
		'btnNuevaRecepcion
		'
		Me.btnNuevaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNuevaRecepcion.Location = New System.Drawing.Point(165, 485)
		Me.btnNuevaRecepcion.Name = "btnNuevaRecepcion"
		Me.btnNuevaRecepcion.Size = New System.Drawing.Size(206, 75)
		Me.btnNuevaRecepcion.TabIndex = 10
		Me.btnNuevaRecepcion.Text = "Nuevo Pesaje"
		Me.btnNuevaRecepcion.UseVisualStyleBackColor = True
		'
		'btnImprimirTodo
		'
		Me.btnImprimirTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnImprimirTodo.Location = New System.Drawing.Point(413, 485)
		Me.btnImprimirTodo.Name = "btnImprimirTodo"
		Me.btnImprimirTodo.Size = New System.Drawing.Size(206, 75)
		Me.btnImprimirTodo.TabIndex = 9
		Me.btnImprimirTodo.Text = "Imprimir"
		Me.btnImprimirTodo.UseVisualStyleBackColor = True
		'
		'dgvFinal
		'
		Me.dgvFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvFinal.Location = New System.Drawing.Point(110, 90)
		Me.dgvFinal.Name = "dgvFinal"
		Me.dgvFinal.RowHeadersWidth = 51
		Me.dgvFinal.RowTemplate.Height = 24
		Me.dgvFinal.Size = New System.Drawing.Size(1052, 189)
		Me.dgvFinal.TabIndex = 8
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.Location = New System.Drawing.Point(312, 38)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(212, 32)
		Me.lblTitulo.TabIndex = 14
		Me.lblTitulo.Text = "Imprimir Tickets"
		'
		'btnImpQr
		'
		Me.btnImpQr.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnImpQr.Location = New System.Drawing.Point(165, 342)
		Me.btnImpQr.Name = "btnImpQr"
		Me.btnImpQr.Size = New System.Drawing.Size(206, 76)
		Me.btnImpQr.TabIndex = 15
		Me.btnImpQr.Text = "Imprimir QR"
		Me.btnImpQr.UseVisualStyleBackColor = True
		'
		'ucTicket
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.btnImpQr)
		Me.Controls.Add(Me.lblTitulo)
		Me.Controls.Add(Me.btnVerQR)
		Me.Controls.Add(Me.btnVistaPrevia)
		Me.Controls.Add(Me.btnFinal)
		Me.Controls.Add(Me.btnNuevaRecepcion)
		Me.Controls.Add(Me.btnImprimirTodo)
		Me.Controls.Add(Me.dgvFinal)
		Me.Name = "ucTicket"
		Me.Size = New System.Drawing.Size(1600, 900)
		CType(Me.dgvFinal, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnVerQR As Button
	Friend WithEvents btnVistaPrevia As Button
	Friend WithEvents btnFinal As Button
	Friend WithEvents btnNuevaRecepcion As Button
	Friend WithEvents btnImprimirTodo As Button
	Friend WithEvents dgvFinal As DataGridView
	Friend WithEvents lblTitulo As Label
	Friend WithEvents btnImpQr As Button
End Class
