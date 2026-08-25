<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPallet
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
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbTipoContenedor = New System.Windows.Forms.ComboBox()
        Me.cmbProcesoPallet = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvBinesDisponibles = New System.Windows.Forms.DataGridView()
        Me.btnCrearPallet = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(45, 150)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(249, 29)
        Me.lblPersona.TabIndex = 12
        Me.lblPersona.Text = "TIPO CONTENEDOR"
        '
        'cmbTipoContenedor
        '
        Me.cmbTipoContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContenedor.FormattingEnabled = True
        Me.cmbTipoContenedor.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbTipoContenedor.Location = New System.Drawing.Point(310, 147)
        Me.cmbTipoContenedor.Name = "cmbTipoContenedor"
        Me.cmbTipoContenedor.Size = New System.Drawing.Size(302, 37)
        Me.cmbTipoContenedor.TabIndex = 10
        '
        'cmbProcesoPallet
        '
        Me.cmbProcesoPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcesoPallet.FormattingEnabled = True
        Me.cmbProcesoPallet.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbProcesoPallet.Location = New System.Drawing.Point(310, 80)
        Me.cmbProcesoPallet.Name = "cmbProcesoPallet"
        Me.cmbProcesoPallet.Size = New System.Drawing.Size(302, 37)
        Me.cmbProcesoPallet.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 29)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "N° PROCESO PALLET"
        '
        'dgvBinesDisponibles
        '
        Me.dgvBinesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinesDisponibles.Location = New System.Drawing.Point(26, 351)
        Me.dgvBinesDisponibles.Name = "dgvBinesDisponibles"
        Me.dgvBinesDisponibles.RowHeadersWidth = 51
        Me.dgvBinesDisponibles.RowTemplate.Height = 24
        Me.dgvBinesDisponibles.Size = New System.Drawing.Size(799, 240)
        Me.dgvBinesDisponibles.TabIndex = 19
        '
        'btnCrearPallet
        '
        Me.btnCrearPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearPallet.Location = New System.Drawing.Point(310, 232)
        Me.btnCrearPallet.Name = "btnCrearPallet"
        Me.btnCrearPallet.Size = New System.Drawing.Size(233, 82)
        Me.btnCrearPallet.TabIndex = 20
        Me.btnCrearPallet.Text = "Crear Pallet"
        Me.btnCrearPallet.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(334, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 29)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "NUEVO PALLET"
        '
        'ucPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCrearPallet)
        Me.Controls.Add(Me.dgvBinesDisponibles)
        Me.Controls.Add(Me.lblPersona)
        Me.Controls.Add(Me.cmbTipoContenedor)
        Me.Controls.Add(Me.cmbProcesoPallet)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ucPallet"
        Me.Size = New System.Drawing.Size(856, 723)
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPersona As Label
    Friend WithEvents cmbTipoContenedor As ComboBox
    Friend WithEvents cmbProcesoPallet As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvBinesDisponibles As DataGridView
    Friend WithEvents btnCrearPallet As Button
    Friend WithEvents Label1 As Label
End Class
