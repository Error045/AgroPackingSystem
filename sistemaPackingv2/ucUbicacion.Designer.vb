<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucUbicacion
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
        Me.cmbUbicacionGeneral = New System.Windows.Forms.ComboBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.btnAplicarATodos = New System.Windows.Forms.Button()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbUbicacionGeneral
        '
        Me.cmbUbicacionGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionGeneral.FormattingEnabled = True
        Me.cmbUbicacionGeneral.Location = New System.Drawing.Point(334, 152)
        Me.cmbUbicacionGeneral.Name = "cmbUbicacionGeneral"
        Me.cmbUbicacionGeneral.Size = New System.Drawing.Size(333, 44)
        Me.cmbUbicacionGeneral.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(337, 55)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(312, 36)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Seleccionar Ubicación"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.Location = New System.Drawing.Point(155, 155)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(148, 36)
        Me.lblUbicacion.TabIndex = 2
        Me.lblUbicacion.Text = "Ubicación"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(373, 595)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(225, 124)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Location = New System.Drawing.Point(46, 286)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.RowHeadersWidth = 51
        Me.dgvResumen.RowTemplate.Height = 24
        Me.dgvResumen.Size = New System.Drawing.Size(1035, 161)
        Me.dgvResumen.TabIndex = 4
        '
        'btnAplicarATodos
        '
        Me.btnAplicarATodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarATodos.Location = New System.Drawing.Point(730, 143)
        Me.btnAplicarATodos.Name = "btnAplicarATodos"
        Me.btnAplicarATodos.Size = New System.Drawing.Size(190, 53)
        Me.btnAplicarATodos.TabIndex = 5
        Me.btnAplicarATodos.Text = "Aplicar a Todos"
        Me.btnAplicarATodos.UseVisualStyleBackColor = True
        '
        'ucUbicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.Controls.Add(Me.btnAplicarATodos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.dgvResumen)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.cmbUbicacionGeneral)
        Me.Name = "ucUbicacion"
        Me.Size = New System.Drawing.Size(1446, 900)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbUbicacionGeneral As ComboBox
	Friend WithEvents lblTitulo As Label
	Friend WithEvents lblUbicacion As Label
	Friend WithEvents btnGuardar As Button
	Friend WithEvents dgvResumen As DataGridView
    Friend WithEvents btnAplicarATodos As Button
End Class
