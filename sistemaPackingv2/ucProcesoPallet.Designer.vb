<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProcesoPallet
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCrearProcesoPallet = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProcesos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTerminarProcesoPallet = New System.Windows.Forms.Button()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblCajas = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(444, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NUEVO PROCESO PALETIZADO"
        '
        'btnCrearProcesoPallet
        '
        Me.btnCrearProcesoPallet.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCrearProcesoPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearProcesoPallet.ForeColor = System.Drawing.Color.White
        Me.btnCrearProcesoPallet.Location = New System.Drawing.Point(561, 102)
        Me.btnCrearProcesoPallet.Name = "btnCrearProcesoPallet"
        Me.btnCrearProcesoPallet.Size = New System.Drawing.Size(195, 107)
        Me.btnCrearProcesoPallet.TabIndex = 2
        Me.btnCrearProcesoPallet.Text = "Nuevo Proceso Pallet"
        Me.btnCrearProcesoPallet.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(58, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 29)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cantidad de Cajas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 29)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad de Pallet"
        '
        'cmbProcesos
        '
        Me.cmbProcesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcesos.FormattingEnabled = True
        Me.cmbProcesos.Location = New System.Drawing.Point(216, 102)
        Me.cmbProcesos.Name = "cmbProcesos"
        Me.cmbProcesos.Size = New System.Drawing.Size(301, 37)
        Me.cmbProcesos.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "N° Proceso Pallet"
        '
        'btnTerminarProcesoPallet
        '
        Me.btnTerminarProcesoPallet.BackColor = System.Drawing.Color.IndianRed
        Me.btnTerminarProcesoPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminarProcesoPallet.ForeColor = System.Drawing.Color.White
        Me.btnTerminarProcesoPallet.Location = New System.Drawing.Point(561, 102)
        Me.btnTerminarProcesoPallet.Name = "btnTerminarProcesoPallet"
        Me.btnTerminarProcesoPallet.Size = New System.Drawing.Size(154, 74)
        Me.btnTerminarProcesoPallet.TabIndex = 9
        Me.btnTerminarProcesoPallet.Text = "Terminar"
        Me.btnTerminarProcesoPallet.UseVisualStyleBackColor = False
        '
        'lblPallet
        '
        Me.lblPallet.AutoSize = True
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.Location = New System.Drawing.Point(314, 216)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(26, 29)
        Me.lblPallet.TabIndex = 10
        Me.lblPallet.Text = "0"
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajas.Location = New System.Drawing.Point(314, 254)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(26, 29)
        Me.lblCajas.TabIndex = 11
        Me.lblCajas.Text = "0"
        '
        'ucProcesoPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCajas)
        Me.Controls.Add(Me.lblPallet)
        Me.Controls.Add(Me.btnTerminarProcesoPallet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbProcesos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCrearProcesoPallet)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucProcesoPallet"
        Me.Size = New System.Drawing.Size(900, 800)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnCrearProcesoPallet As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbProcesos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnTerminarProcesoPallet As Button
    Friend WithEvents lblPallet As Label
    Friend WithEvents lblCajas As Label
End Class
