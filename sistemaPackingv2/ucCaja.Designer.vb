<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaja
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
        Me.cmbPallet = New System.Windows.Forms.ComboBox()
        Me.cmbTipoContenedor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbVariedad = New System.Windows.Forms.ComboBox()
        Me.cmbCalibre = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.btnCrearCaja = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvCajas = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPallet
        '
        Me.cmbPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPallet.FormattingEnabled = True
        Me.cmbPallet.Location = New System.Drawing.Point(224, 70)
        Me.cmbPallet.Name = "cmbPallet"
        Me.cmbPallet.Size = New System.Drawing.Size(264, 37)
        Me.cmbPallet.TabIndex = 0
        '
        'cmbTipoContenedor
        '
        Me.cmbTipoContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContenedor.FormattingEnabled = True
        Me.cmbTipoContenedor.Location = New System.Drawing.Point(224, 158)
        Me.cmbTipoContenedor.Name = "cmbTipoContenedor"
        Me.cmbTipoContenedor.Size = New System.Drawing.Size(264, 37)
        Me.cmbTipoContenedor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "N° PALLET #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TIPO CAJA"
        '
        'cmbProducto
        '
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(224, 252)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(264, 37)
        Me.cmbProducto.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PRODUCTO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 29)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "VARIEDAD"
        '
        'cmbVariedad
        '
        Me.cmbVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVariedad.FormattingEnabled = True
        Me.cmbVariedad.Location = New System.Drawing.Point(224, 333)
        Me.cmbVariedad.Name = "cmbVariedad"
        Me.cmbVariedad.Size = New System.Drawing.Size(264, 37)
        Me.cmbVariedad.TabIndex = 7
        '
        'cmbCalibre
        '
        Me.cmbCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCalibre.FormattingEnabled = True
        Me.cmbCalibre.Location = New System.Drawing.Point(224, 416)
        Me.cmbCalibre.Name = "cmbCalibre"
        Me.cmbCalibre.Size = New System.Drawing.Size(264, 37)
        Me.cmbCalibre.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(55, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 29)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "CALIBRE"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.Location = New System.Drawing.Point(513, 70)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(212, 29)
        Me.lblCapacidad.TabIndex = 10
        Me.lblCapacidad.Text = "0/10  CAPACIDAD "
        '
        'btnCrearCaja
        '
        Me.btnCrearCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearCaja.Location = New System.Drawing.Point(213, 512)
        Me.btnCrearCaja.Name = "btnCrearCaja"
        Me.btnCrearCaja.Size = New System.Drawing.Size(225, 88)
        Me.btnCrearCaja.TabIndex = 11
        Me.btnCrearCaja.Text = "CREAR"
        Me.btnCrearCaja.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(257, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 36)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "NUEVA CAJA"
        '
        'dgvCajas
        '
        Me.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCajas.Location = New System.Drawing.Point(509, 102)
        Me.dgvCajas.MultiSelect = False
        Me.dgvCajas.Name = "dgvCajas"
        Me.dgvCajas.ReadOnly = True
        Me.dgvCajas.RowHeadersVisible = False
        Me.dgvCajas.RowHeadersWidth = 51
        Me.dgvCajas.RowTemplate.Height = 24
        Me.dgvCajas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCajas.Size = New System.Drawing.Size(466, 591)
        Me.dgvCajas.TabIndex = 14
        '
        'ucCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvCajas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCrearCaja)
        Me.Controls.Add(Me.lblCapacidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCalibre)
        Me.Controls.Add(Me.cmbVariedad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipoContenedor)
        Me.Controls.Add(Me.cmbPallet)
        Me.Name = "ucCaja"
        Me.Size = New System.Drawing.Size(1032, 719)
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPallet As ComboBox
    Friend WithEvents cmbTipoContenedor As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbVariedad As ComboBox
    Friend WithEvents cmbCalibre As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCapacidad As Label
    Friend WithEvents btnCrearCaja As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents dgvCajas As DataGridView
End Class
