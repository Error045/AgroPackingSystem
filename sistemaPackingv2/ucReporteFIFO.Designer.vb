<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucReporteFIFO
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
        Me.cmbCamaras = New System.Windows.Forms.ComboBox()
        Me.dgvReporte = New System.Windows.Forms.DataGridView()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtrar Camara"
        '
        'cmbCamaras
        '
        Me.cmbCamaras.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCamaras.FormattingEnabled = True
        Me.cmbCamaras.Location = New System.Drawing.Point(216, 27)
        Me.cmbCamaras.Name = "cmbCamaras"
        Me.cmbCamaras.Size = New System.Drawing.Size(268, 39)
        Me.cmbCamaras.TabIndex = 1
        '
        'dgvReporte
        '
        Me.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporte.Location = New System.Drawing.Point(22, 106)
        Me.dgvReporte.Name = "dgvReporte"
        Me.dgvReporte.ReadOnly = True
        Me.dgvReporte.RowHeadersWidth = 51
        Me.dgvReporte.RowTemplate.Height = 24
        Me.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReporte.Size = New System.Drawing.Size(915, 574)
        Me.dgvReporte.TabIndex = 2
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.Location = New System.Drawing.Point(595, 27)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(93, 25)
        Me.lblContador.TabIndex = 3
        Me.lblContador.Text = "Contador"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.Location = New System.Drawing.Point(595, 60)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(107, 25)
        Me.lblCapacidad.TabIndex = 4
        Me.lblCapacidad.Text = "Capacidad"
        '
        'ucReporteFIFO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCapacidad)
        Me.Controls.Add(Me.lblContador)
        Me.Controls.Add(Me.dgvReporte)
        Me.Controls.Add(Me.cmbCamaras)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucReporteFIFO"
        Me.Size = New System.Drawing.Size(971, 700)
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCamaras As ComboBox
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents lblContador As Label
    Friend WithEvents lblCapacidad As Label
End Class
