<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfirmacionPesaje
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
		Me.dgvFinal = New System.Windows.Forms.DataGridView()
		Me.btnImprimirTodo = New System.Windows.Forms.Button()
		Me.btnNuevaRecepcion = New System.Windows.Forms.Button()
		Me.btnFinal = New System.Windows.Forms.Button()
		Me.lblTituloTransaccion = New System.Windows.Forms.Label()
		Me.lblInfo = New System.Windows.Forms.Label()
		Me.btnVistaPrevia = New System.Windows.Forms.Button()
		Me.btnVerQR = New System.Windows.Forms.Button()
		CType(Me.dgvFinal, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dgvFinal
		'
		Me.dgvFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvFinal.Location = New System.Drawing.Point(152, 328)
		Me.dgvFinal.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.dgvFinal.Name = "dgvFinal"
		Me.dgvFinal.RowHeadersWidth = 51
		Me.dgvFinal.RowTemplate.Height = 24
		Me.dgvFinal.Size = New System.Drawing.Size(1895, 444)
		Me.dgvFinal.TabIndex = 0
		'
		'btnImprimirTodo
		'
		Me.btnImprimirTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnImprimirTodo.Location = New System.Drawing.Point(180, 1087)
		Me.btnImprimirTodo.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.btnImprimirTodo.Name = "btnImprimirTodo"
		Me.btnImprimirTodo.Size = New System.Drawing.Size(489, 173)
		Me.btnImprimirTodo.TabIndex = 1
		Me.btnImprimirTodo.Text = "Imprimir"
		Me.btnImprimirTodo.UseVisualStyleBackColor = True
		'
		'btnNuevaRecepcion
		'
		Me.btnNuevaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNuevaRecepcion.Location = New System.Drawing.Point(824, 1087)
		Me.btnNuevaRecepcion.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.btnNuevaRecepcion.Name = "btnNuevaRecepcion"
		Me.btnNuevaRecepcion.Size = New System.Drawing.Size(489, 173)
		Me.btnNuevaRecepcion.TabIndex = 2
		Me.btnNuevaRecepcion.Text = "Nuevo Pesaje"
		Me.btnNuevaRecepcion.UseVisualStyleBackColor = True
		'
		'btnFinal
		'
		Me.btnFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFinal.Location = New System.Drawing.Point(1396, 1087)
		Me.btnFinal.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.btnFinal.Name = "btnFinal"
		Me.btnFinal.Size = New System.Drawing.Size(489, 173)
		Me.btnFinal.TabIndex = 3
		Me.btnFinal.Text = "Siguiente"
		Me.btnFinal.UseVisualStyleBackColor = True
		'
		'lblTituloTransaccion
		'
		Me.lblTituloTransaccion.AutoSize = True
		Me.lblTituloTransaccion.Location = New System.Drawing.Point(278, 106)
		Me.lblTituloTransaccion.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
		Me.lblTituloTransaccion.Name = "lblTituloTransaccion"
		Me.lblTituloTransaccion.Size = New System.Drawing.Size(111, 37)
		Me.lblTituloTransaccion.TabIndex = 4
		Me.lblTituloTransaccion.Text = "Label1"
		'
		'lblInfo
		'
		Me.lblInfo.AutoSize = True
		Me.lblInfo.Location = New System.Drawing.Point(278, 201)
		Me.lblInfo.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(70, 37)
		Me.lblInfo.TabIndex = 5
		Me.lblInfo.Text = "Info"
		'
		'btnVistaPrevia
		'
		Me.btnVistaPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVistaPrevia.Location = New System.Drawing.Point(1434, 837)
		Me.btnVistaPrevia.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.btnVistaPrevia.Name = "btnVistaPrevia"
		Me.btnVistaPrevia.Size = New System.Drawing.Size(451, 178)
		Me.btnVistaPrevia.TabIndex = 6
		Me.btnVistaPrevia.Text = "Vista Previa"
		Me.btnVistaPrevia.UseVisualStyleBackColor = True
		'
		'btnVerQR
		'
		Me.btnVerQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnVerQR.Location = New System.Drawing.Point(877, 837)
		Me.btnVerQR.Margin = New System.Windows.Forms.Padding(7)
		Me.btnVerQR.Name = "btnVerQR"
		Me.btnVerQR.Size = New System.Drawing.Size(451, 178)
		Me.btnVerQR.TabIndex = 7
		Me.btnVerQR.Text = "Vista QR"
		Me.btnVerQR.UseVisualStyleBackColor = True
		'
		'ucConfirmacionPesaje
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.btnVerQR)
		Me.Controls.Add(Me.btnVistaPrevia)
		Me.Controls.Add(Me.lblInfo)
		Me.Controls.Add(Me.lblTituloTransaccion)
		Me.Controls.Add(Me.btnFinal)
		Me.Controls.Add(Me.btnNuevaRecepcion)
		Me.Controls.Add(Me.btnImprimirTodo)
		Me.Controls.Add(Me.dgvFinal)
		Me.Margin = New System.Windows.Forms.Padding(7, 7, 7, 7)
		Me.Name = "ucConfirmacionPesaje"
		Me.Size = New System.Drawing.Size(2290, 1538)
		CType(Me.dgvFinal, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents dgvFinal As DataGridView
	Friend WithEvents btnImprimirTodo As Button
	Friend WithEvents btnNuevaRecepcion As Button
	Friend WithEvents btnFinal As Button
	Friend WithEvents lblTituloTransaccion As Label
	Friend WithEvents lblInfo As Label
	Friend WithEvents btnVistaPrevia As Button
	Friend WithEvents btnVerQR As Button
End Class
