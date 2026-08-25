<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucUbicacionPalletsDespacho
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAplicarATodos = New System.Windows.Forms.Button()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUbicacionGeneral = New System.Windows.Forms.ComboBox()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(97, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 29)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "UBICACIÓN PALLET DESTINO"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(325, 418)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(253, 73)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAplicarATodos
        '
        Me.btnAplicarATodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarATodos.Location = New System.Drawing.Point(586, 108)
        Me.btnAplicarATodos.Name = "btnAplicarATodos"
        Me.btnAplicarATodos.Size = New System.Drawing.Size(199, 66)
        Me.btnAplicarATodos.TabIndex = 10
        Me.btnAplicarATodos.Text = "Aplicar Todos"
        Me.btnAplicarATodos.UseVisualStyleBackColor = True
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Location = New System.Drawing.Point(46, 243)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.RowHeadersWidth = 51
        Me.dgvResumen.RowTemplate.Height = 24
        Me.dgvResumen.Size = New System.Drawing.Size(861, 136)
        Me.dgvResumen.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 29)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Ubicación"
        '
        'cmbUbicacionGeneral
        '
        Me.cmbUbicacionGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionGeneral.FormattingEnabled = True
        Me.cmbUbicacionGeneral.Location = New System.Drawing.Point(254, 124)
        Me.cmbUbicacionGeneral.Name = "cmbUbicacionGeneral"
        Me.cmbUbicacionGeneral.Size = New System.Drawing.Size(270, 37)
        Me.cmbUbicacionGeneral.TabIndex = 7
        '
        'ucUbicacionPalletsDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnAplicarATodos)
        Me.Controls.Add(Me.dgvResumen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbUbicacionGeneral)
        Me.Name = "ucUbicacionPalletsDespacho"
        Me.Size = New System.Drawing.Size(1200, 800)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnAplicarATodos As Button
    Friend WithEvents dgvResumen As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbUbicacionGeneral As ComboBox
End Class
