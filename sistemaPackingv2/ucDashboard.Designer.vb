<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDashboard
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContStock = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblRecepción = New System.Windows.Forms.Label()
        Me.lblTotalKilos = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblContRecepcion = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRecepcionKilos = New System.Windows.Forms.Label()
        Me.lblContCamaras = New System.Windows.Forms.Label()
        Me.lblCamarasKilos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.flpCalibres = New System.Windows.Forms.FlowLayoutPanel()
        Me.UcTarjetaResumenCalibre1 = New sistemaPackingv2.ucTarjetaResumenCalibre()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.flpContenedor = New System.Windows.Forms.FlowLayoutPanel()
        Me.UcTarjetaUbicacion1 = New sistemaPackingv2.ucTarjetaUbicacion()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.UcReporteFIFO1 = New sistemaPackingv2.ucReporteFIFO()
        Me.Pallets = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.flpCalibres.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.flpContenedor.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.lblTotalKilos)
        Me.Panel1.Location = New System.Drawing.Point(140, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 204)
        Me.Panel1.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.lblContStock)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 56)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(194, 144)
        Me.Panel5.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(20, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "N° Contenedor"
        '
        'lblContStock
        '
        Me.lblContStock.AutoSize = True
        Me.lblContStock.Font = New System.Drawing.Font("MS Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContStock.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblContStock.Location = New System.Drawing.Point(18, 54)
        Me.lblContStock.Name = "lblContStock"
        Me.lblContStock.Size = New System.Drawing.Size(137, 40)
        Me.lblContStock.TabIndex = 4
        Me.lblContStock.Text = "000000"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel4.Controls.Add(Me.lblRecepción)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(879, 56)
        Me.Panel4.TabIndex = 5
        '
        'lblRecepción
        '
        Me.lblRecepción.AutoSize = True
        Me.lblRecepción.Font = New System.Drawing.Font("MS Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecepción.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblRecepción.Location = New System.Drawing.Point(331, 9)
        Me.lblRecepción.Name = "lblRecepción"
        Me.lblRecepción.Size = New System.Drawing.Size(237, 40)
        Me.lblRecepción.TabIndex = 1
        Me.lblRecepción.Text = "Stock Total"
        '
        'lblTotalKilos
        '
        Me.lblTotalKilos.AutoSize = True
        Me.lblTotalKilos.Font = New System.Drawing.Font("MS Gothic", 49.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKilos.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTotalKilos.Location = New System.Drawing.Point(284, 82)
        Me.lblTotalKilos.Name = "lblTotalKilos"
        Me.lblTotalKilos.Size = New System.Drawing.Size(581, 83)
        Me.lblTotalKilos.TabIndex = 2
        Me.lblTotalKilos.Text = "10.000.000 Kg"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lblRecepcionKilos)
        Me.Panel2.Location = New System.Drawing.Point(142, 284)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(879, 161)
        Me.Panel2.TabIndex = 6
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Controls.Add(Me.lblContRecepcion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 53)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(189, 108)
        Me.Panel7.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 28)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "N° Contenedor"
        '
        'lblContRecepcion
        '
        Me.lblContRecepcion.AutoSize = True
        Me.lblContRecepcion.Font = New System.Drawing.Font("MS Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContRecepcion.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblContRecepcion.Location = New System.Drawing.Point(20, 53)
        Me.lblContRecepcion.Name = "lblContRecepcion"
        Me.lblContRecepcion.Size = New System.Drawing.Size(43, 30)
        Me.lblContRecepcion.TabIndex = 5
        Me.lblContRecepcion.Text = "00"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(879, 53)
        Me.Panel6.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(333, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 30)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Recepción"
        '
        'lblRecepcionKilos
        '
        Me.lblRecepcionKilos.AutoSize = True
        Me.lblRecepcionKilos.Font = New System.Drawing.Font("MS Gothic", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecepcionKilos.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblRecepcionKilos.Location = New System.Drawing.Point(362, 83)
        Me.lblRecepcionKilos.Name = "lblRecepcionKilos"
        Me.lblRecepcionKilos.Size = New System.Drawing.Size(68, 47)
        Me.lblRecepcionKilos.TabIndex = 3
        Me.lblRecepcionKilos.Text = "00"
        '
        'lblContCamaras
        '
        Me.lblContCamaras.AutoSize = True
        Me.lblContCamaras.Font = New System.Drawing.Font("MS Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContCamaras.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblContCamaras.Location = New System.Drawing.Point(13, 51)
        Me.lblContCamaras.Name = "lblContCamaras"
        Me.lblContCamaras.Size = New System.Drawing.Size(43, 30)
        Me.lblContCamaras.TabIndex = 6
        Me.lblContCamaras.Text = "00"
        '
        'lblCamarasKilos
        '
        Me.lblCamarasKilos.AutoSize = True
        Me.lblCamarasKilos.Font = New System.Drawing.Font("MS Gothic", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamarasKilos.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCamarasKilos.Location = New System.Drawing.Point(360, 87)
        Me.lblCamarasKilos.Name = "lblCamarasKilos"
        Me.lblCamarasKilos.Size = New System.Drawing.Size(68, 47)
        Me.lblCamarasKilos.TabIndex = 3
        Me.lblCamarasKilos.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(335, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Camaras"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.Pallets)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(20, 43)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(2100, 854)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel8)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(2092, 810)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Totales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.lblCamarasKilos)
        Me.Panel8.Location = New System.Drawing.Point(140, 513)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(879, 161)
        Me.Panel8.TabIndex = 8
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel9.Controls.Add(Me.lblContCamaras)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel9.Location = New System.Drawing.Point(0, 53)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(189, 108)
        Me.Panel9.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(13, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 28)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "N° Contenedor"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.OliveDrab
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(879, 53)
        Me.Panel10.TabIndex = 6
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.flpCalibres)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(2092, 810)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Calibres"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'flpCalibres
        '
        Me.flpCalibres.AutoScroll = True
        Me.flpCalibres.Controls.Add(Me.UcTarjetaResumenCalibre1)
        Me.flpCalibres.Location = New System.Drawing.Point(3, 6)
        Me.flpCalibres.Name = "flpCalibres"
        Me.flpCalibres.Size = New System.Drawing.Size(1406, 798)
        Me.flpCalibres.TabIndex = 0
        '
        'UcTarjetaResumenCalibre1
        '
        Me.UcTarjetaResumenCalibre1.Location = New System.Drawing.Point(6, 6)
        Me.UcTarjetaResumenCalibre1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcTarjetaResumenCalibre1.Name = "UcTarjetaResumenCalibre1"
        Me.UcTarjetaResumenCalibre1.Size = New System.Drawing.Size(231, 432)
        Me.UcTarjetaResumenCalibre1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.flpContenedor)
        Me.TabPage3.Location = New System.Drawing.Point(4, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(2092, 810)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Camaras"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'flpContenedor
        '
        Me.flpContenedor.AutoScroll = True
        Me.flpContenedor.Controls.Add(Me.UcTarjetaUbicacion1)
        Me.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContenedor.Location = New System.Drawing.Point(3, 3)
        Me.flpContenedor.Name = "flpContenedor"
        Me.flpContenedor.Padding = New System.Windows.Forms.Padding(20)
        Me.flpContenedor.Size = New System.Drawing.Size(2086, 804)
        Me.flpContenedor.TabIndex = 0
        '
        'UcTarjetaUbicacion1
        '
        Me.UcTarjetaUbicacion1.BackColor = System.Drawing.Color.White
        Me.UcTarjetaUbicacion1.Location = New System.Drawing.Point(26, 26)
        Me.UcTarjetaUbicacion1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcTarjetaUbicacion1.Name = "UcTarjetaUbicacion1"
        Me.UcTarjetaUbicacion1.Padding = New System.Windows.Forms.Padding(20, 19, 20, 19)
        Me.UcTarjetaUbicacion1.Size = New System.Drawing.Size(220, 280)
        Me.UcTarjetaUbicacion1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.UcReporteFIFO1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 40)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(2092, 810)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Bins"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'UcReporteFIFO1
        '
        Me.UcReporteFIFO1.Location = New System.Drawing.Point(6, 6)
        Me.UcReporteFIFO1.Margin = New System.Windows.Forms.Padding(6)
        Me.UcReporteFIFO1.Name = "UcReporteFIFO1"
        Me.UcReporteFIFO1.Size = New System.Drawing.Size(2080, 795)
        Me.UcReporteFIFO1.TabIndex = 0
        '
        'Pallets
        '
        Me.Pallets.Location = New System.Drawing.Point(4, 40)
        Me.Pallets.Name = "Pallets"
        Me.Pallets.Padding = New System.Windows.Forms.Padding(3)
        Me.Pallets.Size = New System.Drawing.Size(2092, 810)
        Me.Pallets.TabIndex = 4
        Me.Pallets.Text = "Pallets"
        Me.Pallets.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 40)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(2092, 810)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "TabPage6"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ucDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucDashboard"
        Me.Size = New System.Drawing.Size(2139, 900)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.flpCalibres.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.flpContenedor.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalKilos As Label
    Friend WithEvents lblRecepción As Label
    Friend WithEvents lblRecepcionKilos As Label
    Friend WithEvents lblCamarasKilos As Label
    Friend WithEvents lblContStock As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblContRecepcion As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblContCamaras As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents flpContenedor As FlowLayoutPanel
    Friend WithEvents UcTarjetaUbicacion1 As ucTarjetaUbicacion
    Friend WithEvents flpCalibres As FlowLayoutPanel
    Friend WithEvents UcTarjetaResumenCalibre1 As ucTarjetaResumenCalibre
    Friend WithEvents Pallets As TabPage
    Friend WithEvents UcReporteFIFO1 As ucReporteFIFO
    Friend WithEvents TabPage6 As TabPage
End Class
