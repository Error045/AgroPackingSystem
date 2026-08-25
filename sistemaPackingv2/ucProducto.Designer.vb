<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProducto
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
		Me.lblProducto = New System.Windows.Forms.Label()
		Me.lblVariedad = New System.Windows.Forms.Label()
		Me.cmbProducto = New System.Windows.Forms.ComboBox()
		Me.cmbVariedad = New System.Windows.Forms.ComboBox()
		Me.btnSiguienteProducto = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.lblTituloProducto = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'lblProducto
		'
		Me.lblProducto.AutoSize = True
		Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProducto.Location = New System.Drawing.Point(124, 148)
		Me.lblProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblProducto.Name = "lblProducto"
		Me.lblProducto.Size = New System.Drawing.Size(136, 36)
		Me.lblProducto.TabIndex = 0
		Me.lblProducto.Text = "Producto"
		'
		'lblVariedad
		'
		Me.lblVariedad.AutoSize = True
		Me.lblVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblVariedad.Location = New System.Drawing.Point(124, 244)
		Me.lblVariedad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblVariedad.Name = "lblVariedad"
		Me.lblVariedad.Size = New System.Drawing.Size(135, 36)
		Me.lblVariedad.TabIndex = 1
		Me.lblVariedad.Text = "Variedad"
		'
		'cmbProducto
		'
		Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.8!)
		Me.cmbProducto.FormattingEnabled = True
		Me.cmbProducto.Location = New System.Drawing.Point(308, 148)
		Me.cmbProducto.Margin = New System.Windows.Forms.Padding(4)
		Me.cmbProducto.Name = "cmbProducto"
		Me.cmbProducto.Size = New System.Drawing.Size(249, 43)
		Me.cmbProducto.TabIndex = 2
		'
		'cmbVariedad
		'
		Me.cmbVariedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.8!)
		Me.cmbVariedad.FormattingEnabled = True
		Me.cmbVariedad.Location = New System.Drawing.Point(308, 240)
		Me.cmbVariedad.Margin = New System.Windows.Forms.Padding(4)
		Me.cmbVariedad.Name = "cmbVariedad"
		Me.cmbVariedad.Size = New System.Drawing.Size(249, 43)
		Me.cmbVariedad.TabIndex = 3
		'
		'btnSiguienteProducto
		'
		Me.btnSiguienteProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSiguienteProducto.Location = New System.Drawing.Point(394, 435)
		Me.btnSiguienteProducto.Margin = New System.Windows.Forms.Padding(4)
		Me.btnSiguienteProducto.Name = "btnSiguienteProducto"
		Me.btnSiguienteProducto.Size = New System.Drawing.Size(195, 76)
		Me.btnSiguienteProducto.TabIndex = 4
		Me.btnSiguienteProducto.Text = "Siguiente"
		Me.btnSiguienteProducto.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button2.Location = New System.Drawing.Point(129, 435)
		Me.Button2.Margin = New System.Windows.Forms.Padding(4)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(195, 76)
		Me.Button2.TabIndex = 5
		Me.Button2.Text = "Volver"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'lblTituloProducto
		'
		Me.lblTituloProducto.AutoSize = True
		Me.lblTituloProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTituloProducto.Location = New System.Drawing.Point(301, 52)
		Me.lblTituloProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblTituloProducto.Name = "lblTituloProducto"
		Me.lblTituloProducto.Size = New System.Drawing.Size(168, 42)
		Me.lblTituloProducto.TabIndex = 6
		Me.lblTituloProducto.Text = "Producto"
		'
		'ucProducto
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.lblTituloProducto)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.btnSiguienteProducto)
		Me.Controls.Add(Me.cmbVariedad)
		Me.Controls.Add(Me.cmbProducto)
		Me.Controls.Add(Me.lblVariedad)
		Me.Controls.Add(Me.lblProducto)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "ucProducto"
		Me.Size = New System.Drawing.Size(800, 615)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lblProducto As Label
	Friend WithEvents lblVariedad As Label
	Friend WithEvents cmbProducto As ComboBox
	Friend WithEvents cmbVariedad As ComboBox
	Friend WithEvents btnSiguienteProducto As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents lblTituloProducto As Label
End Class
