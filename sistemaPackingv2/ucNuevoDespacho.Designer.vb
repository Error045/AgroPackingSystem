<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucNuevoDespacho
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProcesoActual = New System.Windows.Forms.Label()
        Me.btnCrearDespacho = New System.Windows.Forms.Button()
        Me.btnTerminarDespacho = New System.Windows.Forms.Button()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblCajas = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(113, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NUEVO DESPACHO"
        '
        'lblProcesoActual
        '
        Me.lblProcesoActual.AutoSize = True
        Me.lblProcesoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesoActual.Location = New System.Drawing.Point(114, 123)
        Me.lblProcesoActual.Name = "lblProcesoActual"
        Me.lblProcesoActual.Size = New System.Drawing.Size(259, 29)
        Me.lblProcesoActual.TabIndex = 1
        Me.lblProcesoActual.Text = "NUMERO DESPACHO"
        '
        'btnCrearDespacho
        '
        Me.btnCrearDespacho.BackColor = System.Drawing.Color.Lime
        Me.btnCrearDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearDespacho.Location = New System.Drawing.Point(112, 347)
        Me.btnCrearDespacho.Name = "btnCrearDespacho"
        Me.btnCrearDespacho.Size = New System.Drawing.Size(204, 97)
        Me.btnCrearDespacho.TabIndex = 2
        Me.btnCrearDespacho.Text = "INICIAR"
        Me.btnCrearDespacho.UseVisualStyleBackColor = False
        '
        'btnTerminarDespacho
        '
        Me.btnTerminarDespacho.BackColor = System.Drawing.Color.Fuchsia
        Me.btnTerminarDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminarDespacho.ForeColor = System.Drawing.Color.White
        Me.btnTerminarDespacho.Location = New System.Drawing.Point(112, 347)
        Me.btnTerminarDespacho.Name = "btnTerminarDespacho"
        Me.btnTerminarDespacho.Size = New System.Drawing.Size(261, 124)
        Me.btnTerminarDespacho.TabIndex = 3
        Me.btnTerminarDespacho.Text = "TERMINAR"
        Me.btnTerminarDespacho.UseVisualStyleBackColor = False
        '
        'lblPallet
        '
        Me.lblPallet.AutoSize = True
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.Location = New System.Drawing.Point(114, 218)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(249, 29)
        Me.lblPallet.TabIndex = 4
        Me.lblPallet.Text = "NUMERO PALLETS : "
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajas.Location = New System.Drawing.Point(127, 268)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(88, 29)
        Me.lblCajas.TabIndex = 5
        Me.lblCajas.Text = "CAJAS"
        '
        'ucNuevoDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCajas)
        Me.Controls.Add(Me.lblPallet)
        Me.Controls.Add(Me.btnCrearDespacho)
        Me.Controls.Add(Me.btnTerminarDespacho)
        Me.Controls.Add(Me.lblProcesoActual)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucNuevoDespacho"
        Me.Size = New System.Drawing.Size(1000, 800)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblProcesoActual As Label
    Friend WithEvents btnCrearDespacho As Button
    Friend WithEvents btnTerminarDespacho As Button
    Friend WithEvents lblPallet As Label
    Friend WithEvents lblCajas As Label
End Class
