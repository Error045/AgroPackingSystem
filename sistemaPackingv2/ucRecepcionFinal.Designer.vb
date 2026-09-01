<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRecepcionFinal
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
        Me.lblCodRecepcion = New System.Windows.Forms.Label()
        Me.lblProductor = New System.Windows.Forms.Label()
        Me.lblTotalBruto = New System.Windows.Forms.Label()
        Me.lblTotalContenedor = New System.Windows.Forms.Label()
        Me.lblTotalNeto = New System.Windows.Forms.Label()
        Me.dgvHistorico = New System.Windows.Forms.DataGridView()
        Me.btnTerminarRecepcion = New System.Windows.Forms.Button()
        Me.btnProducto = New System.Windows.Forms.Button()
        Me.btnSeguirPesando = New System.Windows.Forms.Button()
        Me.lblTara = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCodRecepcion
        '
        Me.lblCodRecepcion.AutoSize = True
        Me.lblCodRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodRecepcion.Location = New System.Drawing.Point(51, 105)
        Me.lblCodRecepcion.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCodRecepcion.Name = "lblCodRecepcion"
        Me.lblCodRecepcion.Size = New System.Drawing.Size(109, 29)
        Me.lblCodRecepcion.TabIndex = 0
        Me.lblCodRecepcion.Text = "CODIGO"
        '
        'lblProductor
        '
        Me.lblProductor.AutoSize = True
        Me.lblProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductor.Location = New System.Drawing.Point(51, 143)
        Me.lblProductor.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblProductor.Name = "lblProductor"
        Me.lblProductor.Size = New System.Drawing.Size(119, 29)
        Me.lblProductor.TabIndex = 1
        Me.lblProductor.Text = "NOMBRE"
        '
        'lblTotalBruto
        '
        Me.lblTotalBruto.AutoSize = True
        Me.lblTotalBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBruto.Location = New System.Drawing.Point(676, 105)
        Me.lblTotalBruto.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotalBruto.Name = "lblTotalBruto"
        Me.lblTotalBruto.Size = New System.Drawing.Size(98, 29)
        Me.lblTotalBruto.TabIndex = 2
        Me.lblTotalBruto.Text = "BRUTO"
        '
        'lblTotalContenedor
        '
        Me.lblTotalContenedor.AutoSize = True
        Me.lblTotalContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalContenedor.Location = New System.Drawing.Point(464, 105)
        Me.lblTotalContenedor.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotalContenedor.Name = "lblTotalContenedor"
        Me.lblTotalContenedor.Size = New System.Drawing.Size(134, 29)
        Me.lblTotalContenedor.TabIndex = 3
        Me.lblTotalContenedor.Text = "CANTIDAD"
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.AutoSize = True
        Me.lblTotalNeto.Location = New System.Drawing.Point(676, 146)
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.Size = New System.Drawing.Size(82, 29)
        Me.lblTotalNeto.TabIndex = 7
        Me.lblTotalNeto.Text = "NETO"
        '
        'dgvHistorico
        '
        Me.dgvHistorico.AllowUserToAddRows = False
        Me.dgvHistorico.AllowUserToDeleteRows = False
        Me.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorico.Location = New System.Drawing.Point(19, 250)
        Me.dgvHistorico.MultiSelect = False
        Me.dgvHistorico.Name = "dgvHistorico"
        Me.dgvHistorico.ReadOnly = True
        Me.dgvHistorico.RowHeadersVisible = False
        Me.dgvHistorico.RowHeadersWidth = 51
        Me.dgvHistorico.RowTemplate.Height = 24
        Me.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistorico.Size = New System.Drawing.Size(930, 299)
        Me.dgvHistorico.TabIndex = 8
        '
        'btnTerminarRecepcion
        '
        Me.btnTerminarRecepcion.BackColor = System.Drawing.Color.Red
        Me.btnTerminarRecepcion.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnTerminarRecepcion.Location = New System.Drawing.Point(56, 582)
        Me.btnTerminarRecepcion.Name = "btnTerminarRecepcion"
        Me.btnTerminarRecepcion.Size = New System.Drawing.Size(188, 94)
        Me.btnTerminarRecepcion.TabIndex = 11
        Me.btnTerminarRecepcion.Text = "TERMINAR RECEPCIÓN"
        Me.btnTerminarRecepcion.UseVisualStyleBackColor = False
        '
        'btnProducto
        '
        Me.btnProducto.Location = New System.Drawing.Point(401, 582)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(188, 94)
        Me.btnProducto.TabIndex = 9
        Me.btnProducto.Text = "VOLVER INICIO"
        Me.btnProducto.UseVisualStyleBackColor = True
        '
        'btnSeguirPesando
        '
        Me.btnSeguirPesando.Location = New System.Drawing.Point(637, 582)
        Me.btnSeguirPesando.Name = "btnSeguirPesando"
        Me.btnSeguirPesando.Size = New System.Drawing.Size(188, 94)
        Me.btnSeguirPesando.TabIndex = 10
        Me.btnSeguirPesando.Text = "VOLVER A PESAJE"
        Me.btnSeguirPesando.UseVisualStyleBackColor = True
        '
        'lblTara
        '
        Me.lblTara.AutoSize = True
        Me.lblTara.Location = New System.Drawing.Point(676, 189)
        Me.lblTara.Name = "lblTara"
        Me.lblTara.Size = New System.Drawing.Size(76, 29)
        Me.lblTara.TabIndex = 12
        Me.lblTara.Text = "TARA"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(339, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(350, 36)
        Me.lblTitulo.TabIndex = 13
        Me.lblTitulo.Text = "RESUMEN RECEPCION"
        '
        'ucRecepcionFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblTara)
        Me.Controls.Add(Me.btnTerminarRecepcion)
        Me.Controls.Add(Me.btnSeguirPesando)
        Me.Controls.Add(Me.btnProducto)
        Me.Controls.Add(Me.dgvHistorico)
        Me.Controls.Add(Me.lblTotalNeto)
        Me.Controls.Add(Me.lblTotalContenedor)
        Me.Controls.Add(Me.lblTotalBruto)
        Me.Controls.Add(Me.lblProductor)
        Me.Controls.Add(Me.lblCodRecepcion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ucRecepcionFinal"
        Me.Size = New System.Drawing.Size(1136, 900)
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCodRecepcion As Label
	Friend WithEvents lblProductor As Label
	Friend WithEvents lblTotalBruto As Label
	Friend WithEvents lblTotalContenedor As Label
	Friend WithEvents lblTotalNeto As Label
	Friend WithEvents dgvHistorico As DataGridView
	Friend WithEvents btnTerminarRecepcion As Button
	Friend WithEvents btnProducto As Button
	Friend WithEvents btnSeguirPesando As Button
	Friend WithEvents lblTara As Label
	Friend WithEvents lblTitulo As Label
End Class
