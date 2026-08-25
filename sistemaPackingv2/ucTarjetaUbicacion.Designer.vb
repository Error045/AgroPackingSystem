<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTarjetaUbicacion
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
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.lblBins = New System.Windows.Forms.Label()
        Me.lblDetalle = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.DarkBlue
        Me.pnlCabecera.Controls.Add(Me.lblKilos)
        Me.pnlCabecera.Controls.Add(Me.lblUbicacion)
        Me.pnlCabecera.Controls.Add(Me.lblBins)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(10, 10)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(173, 67)
        Me.pnlCabecera.TabIndex = 0
        '
        'lblKilos
        '
        Me.lblKilos.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKilos.AutoSize = True
        Me.lblKilos.Font = New System.Drawing.Font("MS Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilos.ForeColor = System.Drawing.Color.White
        Me.lblKilos.Location = New System.Drawing.Point(38, 16)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(122, 40)
        Me.lblKilos.TabIndex = 1
        Me.lblKilos.Text = "Kilos"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.ForeColor = System.Drawing.Color.White
        Me.lblUbicacion.Location = New System.Drawing.Point(0, 0)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(120, 29)
        Me.lblUbicacion.TabIndex = 0
        Me.lblUbicacion.Text = "Ubicación"
        '
        'lblBins
        '
        Me.lblBins.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBins.AutoSize = True
        Me.lblBins.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblBins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBins.ForeColor = System.Drawing.Color.White
        Me.lblBins.Location = New System.Drawing.Point(3, 45)
        Me.lblBins.Name = "lblBins"
        Me.lblBins.Size = New System.Drawing.Size(50, 25)
        Me.lblBins.TabIndex = 2
        Me.lblBins.Text = "Bins"
        Me.lblBins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDetalle
        '
        Me.lblDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDetalle.Font = New System.Drawing.Font("Consolas", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalle.ForeColor = System.Drawing.Color.Black
        Me.lblDetalle.Location = New System.Drawing.Point(10, 80)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(173, 120)
        Me.lblDetalle.TabIndex = 3
        Me.lblDetalle.Text = "Detalle Calibres"
        '
        'ucTarjetaUbicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblDetalle)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "ucTarjetaUbicacion"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Size = New System.Drawing.Size(193, 210)
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents lblKilos As Label
    Friend WithEvents lblBins As Label
    Friend WithEvents lblDetalle As Label
End Class
