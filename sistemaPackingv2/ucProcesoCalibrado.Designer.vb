<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProcesoCalibrado
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
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblVariedad = New System.Windows.Forms.Label()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.cmbVariedad = New System.Windows.Forms.ComboBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblNumProceso = New System.Windows.Forms.Label()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.cmbCalibre = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbProceso = New System.Windows.Forms.ComboBox()
        Me.dgvRegistros = New System.Windows.Forms.DataGridView()
        Me.lblTituloEstado = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.dgvRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(13, 138)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(110, 29)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'lblVariedad
        '
        Me.lblVariedad.AutoSize = True
        Me.lblVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariedad.Location = New System.Drawing.Point(13, 216)
        Me.lblVariedad.Name = "lblVariedad"
        Me.lblVariedad.Size = New System.Drawing.Size(110, 29)
        Me.lblVariedad.TabIndex = 1
        Me.lblVariedad.Text = "Variedad"
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(129, 138)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(238, 39)
        Me.cmbProducto.TabIndex = 2
        '
        'cmbVariedad
        '
        Me.cmbVariedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVariedad.FormattingEnabled = True
        Me.cmbVariedad.Location = New System.Drawing.Point(129, 206)
        Me.cmbVariedad.Name = "cmbVariedad"
        Me.cmbVariedad.Size = New System.Drawing.Size(238, 39)
        Me.cmbVariedad.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(226, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(266, 36)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Nuevo Contenedor"
        '
        'lblNumProceso
        '
        Me.lblNumProceso.AutoSize = True
        Me.lblNumProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumProceso.Location = New System.Drawing.Point(13, 69)
        Me.lblNumProceso.Name = "lblNumProceso"
        Me.lblNumProceso.Size = New System.Drawing.Size(163, 32)
        Me.lblNumProceso.TabIndex = 5
        Me.lblNumProceso.Text = "N°  Proceso"
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrar.Location = New System.Drawing.Point(74, 422)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(209, 89)
        Me.btnRegistrar.TabIndex = 7
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'cmbCalibre
        '
        Me.cmbCalibre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCalibre.FormattingEnabled = True
        Me.cmbCalibre.Location = New System.Drawing.Point(129, 296)
        Me.cmbCalibre.Name = "cmbCalibre"
        Me.cmbCalibre.Size = New System.Drawing.Size(238, 39)
        Me.cmbCalibre.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 29)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Categoría"
        '
        'cmbProceso
        '
        Me.cmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProceso.FormattingEnabled = True
        Me.cmbProceso.Location = New System.Drawing.Point(193, 66)
        Me.cmbProceso.Name = "cmbProceso"
        Me.cmbProceso.Size = New System.Drawing.Size(448, 39)
        Me.cmbProceso.TabIndex = 10
        '
        'dgvRegistros
        '
        Me.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegistros.Location = New System.Drawing.Point(391, 128)
        Me.dgvRegistros.Name = "dgvRegistros"
        Me.dgvRegistros.RowHeadersWidth = 51
        Me.dgvRegistros.RowTemplate.Height = 24
        Me.dgvRegistros.Size = New System.Drawing.Size(590, 635)
        Me.dgvRegistros.TabIndex = 11
        '
        'lblTituloEstado
        '
        Me.lblTituloEstado.AutoSize = True
        Me.lblTituloEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloEstado.Location = New System.Drawing.Point(35, 365)
        Me.lblTituloEstado.Name = "lblTituloEstado"
        Me.lblTituloEstado.Size = New System.Drawing.Size(88, 29)
        Me.lblTituloEstado.TabIndex = 12
        Me.lblTituloEstado.Text = "Estado"
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Location = New System.Drawing.Point(74, 533)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(209, 89)
        Me.btnActualizar.TabIndex = 13
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(74, 655)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(209, 89)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ucProcesoCalibrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.lblTituloEstado)
        Me.Controls.Add(Me.dgvRegistros)
        Me.Controls.Add(Me.cmbProceso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCalibre)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.lblNumProceso)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.cmbVariedad)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.lblVariedad)
        Me.Controls.Add(Me.lblProducto)
        Me.Name = "ucProcesoCalibrado"
        Me.Size = New System.Drawing.Size(1000, 900)
        CType(Me.dgvRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblProducto As Label
	Friend WithEvents lblVariedad As Label
	Friend WithEvents cmbProducto As ComboBox
	Friend WithEvents cmbVariedad As ComboBox
	Friend WithEvents lblTitulo As Label
	Friend WithEvents lblNumProceso As Label
	Friend WithEvents btnRegistrar As Button
	Friend WithEvents cmbCalibre As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbProceso As ComboBox
    Friend WithEvents dgvRegistros As DataGridView
    Friend WithEvents lblTituloEstado As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnCancelar As Button
End Class
