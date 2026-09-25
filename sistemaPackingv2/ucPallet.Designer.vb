<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPallet
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
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbTipoContenedor = New System.Windows.Forms.ComboBox()
        Me.cmbProcesoPallet = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvPalletsCreados = New System.Windows.Forms.DataGridView()
        Me.btnCrearPallet = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numCantidadCajas = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvPalletsCreados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidadCajas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmbTipoContenedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContenedor.FormattingEnabled = True
        Me.cmbTipoContenedor.IntegralHeight = False
        Me.cmbTipoContenedor.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbTipoContenedor.Location = New System.Drawing.Point(310, 147)
        Me.cmbTipoContenedor.MaxDropDownItems = 10
        Me.cmbTipoContenedor.Name = "cmbTipoContenedor"
        Me.cmbTipoContenedor.Size = New System.Drawing.Size(302, 37)
        Me.cmbTipoContenedor.TabIndex = 10
        '
        'cmbProcesoPallet
        '
        Me.cmbProcesoPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcesoPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcesoPallet.FormattingEnabled = True
        Me.cmbProcesoPallet.IntegralHeight = False
        Me.cmbProcesoPallet.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbProcesoPallet.Location = New System.Drawing.Point(310, 80)
        Me.cmbProcesoPallet.MaxDropDownItems = 10
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
        'dgvPalletsCreados
        '
        Me.dgvPalletsCreados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPalletsCreados.Location = New System.Drawing.Point(29, 400)
        Me.dgvPalletsCreados.Name = "dgvPalletsCreados"
        Me.dgvPalletsCreados.RowHeadersWidth = 51
        Me.dgvPalletsCreados.RowTemplate.Height = 24
        Me.dgvPalletsCreados.Size = New System.Drawing.Size(799, 240)
        Me.dgvPalletsCreados.TabIndex = 19
        '
        'btnCrearPallet
        '
        Me.btnCrearPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearPallet.Location = New System.Drawing.Point(294, 287)
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
        'numCantidadCajas
        '
        Me.numCantidadCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCantidadCajas.Location = New System.Drawing.Point(310, 207)
        Me.numCantidadCajas.Name = "numCantidadCajas"
        Me.numCantidadCajas.Size = New System.Drawing.Size(98, 53)
        Me.numCantidadCajas.TabIndex = 22
        Me.numCantidadCajas.Value = New Decimal(New Integer() {88, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 29)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "CANTIDAD CAJAS"
        '
        'ucPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numCantidadCajas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCrearPallet)
        Me.Controls.Add(Me.dgvPalletsCreados)
        Me.Controls.Add(Me.lblPersona)
        Me.Controls.Add(Me.cmbTipoContenedor)
        Me.Controls.Add(Me.cmbProcesoPallet)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ucPallet"
        Me.Size = New System.Drawing.Size(856, 723)
        CType(Me.dgvPalletsCreados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidadCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPersona As Label
    Friend WithEvents cmbTipoContenedor As ComboBox
    Friend WithEvents cmbProcesoPallet As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvPalletsCreados As DataGridView
    Friend WithEvents btnCrearPallet As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents numCantidadCajas As NumericUpDown
    Friend WithEvents Label3 As Label
End Class
