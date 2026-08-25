<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdenDespachoRepesajeActualizar
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
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnConfirmarYGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.pnlBotones.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnConfirmarYGuardar)
        Me.pnlBotones.Location = New System.Drawing.Point(224, 409)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(615, 121)
        Me.pnlBotones.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(19, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(225, 84)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnConfirmarYGuardar
        '
        Me.btnConfirmarYGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmarYGuardar.Location = New System.Drawing.Point(340, 15)
        Me.btnConfirmarYGuardar.Name = "btnConfirmarYGuardar"
        Me.btnConfirmarYGuardar.Size = New System.Drawing.Size(245, 84)
        Me.btnConfirmarYGuardar.TabIndex = 1
        Me.btnConfirmarYGuardar.Text = "Actualizar"
        Me.btnConfirmarYGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(398, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ACTUALIZAR PALLET"
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Location = New System.Drawing.Point(169, 118)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.RowHeadersWidth = 51
        Me.dgvResumen.RowTemplate.Height = 24
        Me.dgvResumen.Size = New System.Drawing.Size(723, 240)
        Me.dgvResumen.TabIndex = 4
        '
        'ucOrdenDespachoRepesajeActualizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvResumen)
        Me.Name = "ucOrdenDespachoRepesajeActualizacion"
        Me.Size = New System.Drawing.Size(1100, 800)
        Me.pnlBotones.ResumeLayout(False)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnConfirmarYGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvResumen As DataGridView
End Class
