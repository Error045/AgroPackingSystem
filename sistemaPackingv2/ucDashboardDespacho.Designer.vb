<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDashboardDespacho
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
        Me.btnAgregarPallet = New System.Windows.Forms.Button()
        Me.btnValidarPallet = New System.Windows.Forms.Button()
        Me.lblCajas = New System.Windows.Forms.Label()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.btnCrearDespacho = New System.Windows.Forms.Button()
        Me.btnTerminarDespacho = New System.Windows.Forms.Button()
        Me.lblProcesoActual = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PANEL DESPACHO"
        '
        'btnAgregarPallet
        '
        Me.btnAgregarPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPallet.Location = New System.Drawing.Point(56, 393)
        Me.btnAgregarPallet.Name = "btnAgregarPallet"
        Me.btnAgregarPallet.Size = New System.Drawing.Size(222, 74)
        Me.btnAgregarPallet.TabIndex = 2
        Me.btnAgregarPallet.Text = "Agregar Pallet"
        Me.btnAgregarPallet.UseVisualStyleBackColor = True
        '
        'btnValidarPallet
        '
        Me.btnValidarPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidarPallet.Location = New System.Drawing.Point(56, 501)
        Me.btnValidarPallet.Name = "btnValidarPallet"
        Me.btnValidarPallet.Size = New System.Drawing.Size(222, 74)
        Me.btnValidarPallet.TabIndex = 4
        Me.btnValidarPallet.Text = "Validar Pallet"
        Me.btnValidarPallet.UseVisualStyleBackColor = True
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajas.Location = New System.Drawing.Point(240, 221)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(26, 29)
        Me.lblCajas.TabIndex = 10
        Me.lblCajas.Text = "0"
        '
        'lblPallet
        '
        Me.lblPallet.AutoSize = True
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.Location = New System.Drawing.Point(240, 174)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(26, 29)
        Me.lblPallet.TabIndex = 9
        Me.lblPallet.Text = "0"
        '
        'btnCrearDespacho
        '
        Me.btnCrearDespacho.BackColor = System.Drawing.Color.Lime
        Me.btnCrearDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearDespacho.Location = New System.Drawing.Point(425, 106)
        Me.btnCrearDespacho.Name = "btnCrearDespacho"
        Me.btnCrearDespacho.Size = New System.Drawing.Size(204, 97)
        Me.btnCrearDespacho.TabIndex = 7
        Me.btnCrearDespacho.Text = "INICIAR"
        Me.btnCrearDespacho.UseVisualStyleBackColor = False
        '
        'btnTerminarDespacho
        '
        Me.btnTerminarDespacho.BackColor = System.Drawing.Color.Fuchsia
        Me.btnTerminarDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminarDespacho.ForeColor = System.Drawing.Color.White
        Me.btnTerminarDespacho.Location = New System.Drawing.Point(425, 106)
        Me.btnTerminarDespacho.Name = "btnTerminarDespacho"
        Me.btnTerminarDespacho.Size = New System.Drawing.Size(261, 124)
        Me.btnTerminarDespacho.TabIndex = 8
        Me.btnTerminarDespacho.Text = "TERMINAR"
        Me.btnTerminarDespacho.UseVisualStyleBackColor = False
        '
        'lblProcesoActual
        '
        Me.lblProcesoActual.AutoSize = True
        Me.lblProcesoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesoActual.Location = New System.Drawing.Point(51, 106)
        Me.lblProcesoActual.Name = "lblProcesoActual"
        Me.lblProcesoActual.Size = New System.Drawing.Size(26, 29)
        Me.lblProcesoActual.TabIndex = 6
        Me.lblProcesoActual.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 29)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "N° PALLET"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 29)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "N° CAJAS"
        '
        'ucDashboardDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCajas)
        Me.Controls.Add(Me.lblPallet)
        Me.Controls.Add(Me.btnCrearDespacho)
        Me.Controls.Add(Me.btnTerminarDespacho)
        Me.Controls.Add(Me.lblProcesoActual)
        Me.Controls.Add(Me.btnValidarPallet)
        Me.Controls.Add(Me.btnAgregarPallet)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucDashboardDespacho"
        Me.Size = New System.Drawing.Size(1100, 800)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnAgregarPallet As Button
    Friend WithEvents btnValidarPallet As Button
    Friend WithEvents lblCajas As Label
    Friend WithEvents lblPallet As Label
    Friend WithEvents btnCrearDespacho As Button
    Friend WithEvents btnTerminarDespacho As Button
    Friend WithEvents lblProcesoActual As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
