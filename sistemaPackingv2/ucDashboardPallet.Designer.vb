<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDashboardPallet
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.UcProcesoPallet1 = New sistemaPackingv2.ucProcesoPallet()
        Me.UcPallet1 = New sistemaPackingv2.ucPallet()
        Me.UcCaja1 = New sistemaPackingv2.ucCaja()
        Me.UcPesajePallets1 = New sistemaPackingv2.ucPesajePallets()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1387, 875)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.UcProcesoPallet1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1379, 842)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Proceso Pallet"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.UcPallet1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1379, 842)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pallet"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.UcCaja1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1379, 842)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cajas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.UcPesajePallets1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1379, 842)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Pesaje Pallet"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'UcProcesoPallet1
        '
        Me.UcProcesoPallet1.Location = New System.Drawing.Point(0, 0)
        Me.UcProcesoPallet1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcProcesoPallet1.Name = "UcProcesoPallet1"
        Me.UcProcesoPallet1.Size = New System.Drawing.Size(1155, 884)
        Me.UcProcesoPallet1.TabIndex = 0
        '
        'UcPallet1
        '
        Me.UcPallet1.Location = New System.Drawing.Point(9, 6)
        Me.UcPallet1.Name = "UcPallet1"
        Me.UcPallet1.Size = New System.Drawing.Size(1165, 766)
        Me.UcPallet1.TabIndex = 0
        '
        'UcCaja1
        '
        Me.UcCaja1.Location = New System.Drawing.Point(4, 0)
        Me.UcCaja1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcCaja1.Name = "UcCaja1"
        Me.UcCaja1.Size = New System.Drawing.Size(1307, 848)
        Me.UcCaja1.TabIndex = 0
        '
        'UcPesajePallets1
        '
        Me.UcPesajePallets1.Location = New System.Drawing.Point(0, 0)
        Me.UcPesajePallets1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcPesajePallets1.Name = "UcPesajePallets1"
        Me.UcPesajePallets1.Size = New System.Drawing.Size(1266, 811)
        Me.UcPesajePallets1.TabIndex = 0
        '
        'ucDashboardPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucDashboardPallet"
        Me.Size = New System.Drawing.Size(1418, 1045)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents UcPallet1 As ucPallet
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents UcPesajePallets1 As ucPesajePallets
    Friend WithEvents UcProcesoPallet1 As ucProcesoPallet
    Friend WithEvents UcCaja1 As ucCaja
End Class
