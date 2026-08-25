<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucTarjetaResumenCalibre
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
        Me.lblNombreCalibre = New System.Windows.Forms.Label()
        Me.lblBinsTotales = New System.Windows.Forms.Label()
        Me.lblKilosTotales = New System.Windows.Forms.Label()
        Me.lblPorcTotales = New System.Windows.Forms.Label()
        Me.pnlBarraFondo = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblPromedio = New System.Windows.Forms.Label()
        Me.pnlBarraColor = New System.Windows.Forms.Panel()
        Me.pnlBarraFondo.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreCalibre
        '
        Me.lblNombreCalibre.AutoSize = True
        Me.lblNombreCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCalibre.ForeColor = System.Drawing.Color.Yellow
        Me.lblNombreCalibre.Location = New System.Drawing.Point(-1, 0)
        Me.lblNombreCalibre.Name = "lblNombreCalibre"
        Me.lblNombreCalibre.Size = New System.Drawing.Size(112, 32)
        Me.lblNombreCalibre.TabIndex = 0
        Me.lblNombreCalibre.Text = "Calibre"
        '
        'lblBinsTotales
        '
        Me.lblBinsTotales.AutoSize = True
        Me.lblBinsTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBinsTotales.ForeColor = System.Drawing.Color.White
        Me.lblBinsTotales.Location = New System.Drawing.Point(3, 0)
        Me.lblBinsTotales.Name = "lblBinsTotales"
        Me.lblBinsTotales.Size = New System.Drawing.Size(70, 32)
        Me.lblBinsTotales.TabIndex = 1
        Me.lblBinsTotales.Text = "Bins"
        '
        'lblKilosTotales
        '
        Me.lblKilosTotales.AutoSize = True
        Me.lblKilosTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilosTotales.ForeColor = System.Drawing.Color.Yellow
        Me.lblKilosTotales.Location = New System.Drawing.Point(19, 31)
        Me.lblKilosTotales.Name = "lblKilosTotales"
        Me.lblKilosTotales.Size = New System.Drawing.Size(164, 69)
        Me.lblKilosTotales.TabIndex = 2
        Me.lblKilosTotales.Text = "Kilos"
        '
        'lblPorcTotales
        '
        Me.lblPorcTotales.AutoSize = True
        Me.lblPorcTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcTotales.ForeColor = System.Drawing.Color.White
        Me.lblPorcTotales.Location = New System.Drawing.Point(112, -1)
        Me.lblPorcTotales.Name = "lblPorcTotales"
        Me.lblPorcTotales.Size = New System.Drawing.Size(71, 32)
        Me.lblPorcTotales.TabIndex = 3
        Me.lblPorcTotales.Text = "00%"
        '
        'pnlBarraFondo
        '
        Me.pnlBarraFondo.BackColor = System.Drawing.Color.DarkBlue
        Me.pnlBarraFondo.Controls.Add(Me.lblPromedio)
        Me.pnlBarraFondo.Controls.Add(Me.lblKilosTotales)
        Me.pnlBarraFondo.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlBarraFondo.Controls.Add(Me.panelHeader)
        Me.pnlBarraFondo.Location = New System.Drawing.Point(0, 0)
        Me.pnlBarraFondo.Name = "pnlBarraFondo"
        Me.pnlBarraFondo.Size = New System.Drawing.Size(200, 112)
        Me.pnlBarraFondo.TabIndex = 9
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue
        Me.FlowLayoutPanel1.Controls.Add(Me.lblBinsTotales)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 89)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(78, 20)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.DarkSlateGray
        Me.panelHeader.Controls.Add(Me.lblPorcTotales)
        Me.panelHeader.Controls.Add(Me.pnlBarraColor)
        Me.panelHeader.Controls.Add(Me.lblNombreCalibre)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(200, 31)
        Me.panelHeader.TabIndex = 4
        '
        'lblPromedio
        '
        Me.lblPromedio.AutoSize = True
        Me.lblPromedio.ForeColor = System.Drawing.Color.White
        Me.lblPromedio.Location = New System.Drawing.Point(89, 93)
        Me.lblPromedio.Name = "lblPromedio"
        Me.lblPromedio.Size = New System.Drawing.Size(66, 16)
        Me.lblPromedio.TabIndex = 6
        Me.lblPromedio.Text = "Promedio"
        '
        'pnlBarraColor
        '
        Me.pnlBarraColor.BackColor = System.Drawing.Color.Yellow
        Me.pnlBarraColor.Location = New System.Drawing.Point(5, 17)
        Me.pnlBarraColor.Name = "pnlBarraColor"
        Me.pnlBarraColor.Size = New System.Drawing.Size(192, 11)
        Me.pnlBarraColor.TabIndex = 4
        '
        'ucTarjetaResumenCalibre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlBarraFondo)
        Me.Name = "ucTarjetaResumenCalibre"
        Me.Size = New System.Drawing.Size(200, 112)
        Me.pnlBarraFondo.ResumeLayout(False)
        Me.pnlBarraFondo.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreCalibre As Label
    Friend WithEvents lblBinsTotales As Label
    Friend WithEvents lblKilosTotales As Label
    Friend WithEvents lblPorcTotales As Label
    Friend WithEvents pnlBarraFondo As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblPromedio As Label
    Friend WithEvents pnlBarraColor As Panel
End Class
