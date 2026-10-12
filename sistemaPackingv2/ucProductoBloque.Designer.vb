<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProductoBloque
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
        Me.lblTituloProducto = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSiguienteProducto = New System.Windows.Forms.Button()
        Me.cmbVariedad = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.lblVariedad = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTituloProducto
        '
        Me.lblTituloProducto.AutoSize = True
        Me.lblTituloProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloProducto.Location = New System.Drawing.Point(329, 40)
        Me.lblTituloProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTituloProducto.Name = "lblTituloProducto"
        Me.lblTituloProducto.Size = New System.Drawing.Size(334, 42)
        Me.lblTituloProducto.TabIndex = 13
        Me.lblTituloProducto.Text = "Producto BLOQUE"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(203, 430)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(195, 76)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSiguienteProducto
        '
        Me.btnSiguienteProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguienteProducto.Location = New System.Drawing.Point(468, 430)
        Me.btnSiguienteProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSiguienteProducto.Name = "btnSiguienteProducto"
        Me.btnSiguienteProducto.Size = New System.Drawing.Size(195, 76)
        Me.btnSiguienteProducto.TabIndex = 11
        Me.btnSiguienteProducto.Text = "Siguiente"
        Me.btnSiguienteProducto.UseVisualStyleBackColor = True
        '
        'cmbVariedad
        '
        Me.cmbVariedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.8!)
        Me.cmbVariedad.FormattingEnabled = True
        Me.cmbVariedad.Location = New System.Drawing.Point(382, 235)
        Me.cmbVariedad.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbVariedad.Name = "cmbVariedad"
        Me.cmbVariedad.Size = New System.Drawing.Size(249, 43)
        Me.cmbVariedad.TabIndex = 10
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.8!)
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(382, 143)
        Me.cmbProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(249, 43)
        Me.cmbProducto.TabIndex = 9
        '
        'lblVariedad
        '
        Me.lblVariedad.AutoSize = True
        Me.lblVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariedad.Location = New System.Drawing.Point(198, 239)
        Me.lblVariedad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVariedad.Name = "lblVariedad"
        Me.lblVariedad.Size = New System.Drawing.Size(135, 36)
        Me.lblVariedad.TabIndex = 8
        Me.lblVariedad.Text = "Variedad"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(198, 143)
        Me.lblProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(136, 36)
        Me.lblProducto.TabIndex = 7
        Me.lblProducto.Text = "Producto"
        '
        'ucProductoBloque
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
        Me.Name = "ucProductoBloque"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTituloProducto As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSiguienteProducto As Button
    Friend WithEvents cmbVariedad As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents lblVariedad As Label
    Friend WithEvents lblProducto As Label
End Class
