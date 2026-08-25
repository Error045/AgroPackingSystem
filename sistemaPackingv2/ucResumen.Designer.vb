<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucResumen
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTipoRecepcion = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Título = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVariedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdCont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBruto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCalibre = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colUbicacion = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.idR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResumen
        '
        Me.dgvResumen.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResumen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Título, Me.colProducto, Me.colVariedad, Me.colIdCont, Me.colTara, Me.colBruto, Me.colNeto, Me.colCalibre, Me.colUbicacion, Me.idR, Me.IdPersona, Me.Variedad, Me.persona, Me.IdProducto})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResumen.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvResumen.Location = New System.Drawing.Point(15, 227)
        Me.dgvResumen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvResumen.Name = "dgvResumen"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResumen.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResumen.RowHeadersWidth = 25
        Me.dgvResumen.RowTemplate.Height = 40
        Me.dgvResumen.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvResumen.Size = New System.Drawing.Size(1374, 253)
        Me.dgvResumen.TabIndex = 0
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Location = New System.Drawing.Point(660, 583)
        Me.btnConfirmar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(167, 89)
        Me.btnConfirmar.TabIndex = 1
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(342, 583)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(167, 89)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(83, 500)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(148, 46)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "TOTAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo  Recepción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre:"
        '
        'lblTipoRecepcion
        '
        Me.lblTipoRecepcion.AutoSize = True
        Me.lblTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoRecepcion.Location = New System.Drawing.Point(336, 80)
        Me.lblTipoRecepcion.Name = "lblTipoRecepcion"
        Me.lblTipoRecepcion.Size = New System.Drawing.Size(219, 32)
        Me.lblTipoRecepcion.TabIndex = 8
        Me.lblTipoRecepcion.Text = "Tipo  Recepción"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(336, 127)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(114, 32)
        Me.lblNombre.TabIndex = 9
        Me.lblNombre.Text = "Nombre"
        '
        'Título
        '
        Me.Título.HeaderText = "Titulo"
        Me.Título.MinimumWidth = 6
        Me.Título.Name = "Título"
        Me.Título.Width = 125
        '
        'colProducto
        '
        Me.colProducto.HeaderText = "Producto"
        Me.colProducto.MinimumWidth = 6
        Me.colProducto.Name = "colProducto"
        Me.colProducto.Width = 125
        '
        'colVariedad
        '
        Me.colVariedad.HeaderText = "Variedad"
        Me.colVariedad.MinimumWidth = 6
        Me.colVariedad.Name = "colVariedad"
        Me.colVariedad.Width = 125
        '
        'colIdCont
        '
        Me.colIdCont.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colIdCont.HeaderText = "Contenedor"
        Me.colIdCont.MinimumWidth = 6
        Me.colIdCont.Name = "colIdCont"
        Me.colIdCont.Visible = False
        Me.colIdCont.Width = 192
        '
        'colTara
        '
        Me.colTara.HeaderText = "Tara"
        Me.colTara.MinimumWidth = 6
        Me.colTara.Name = "colTara"
        Me.colTara.Width = 125
        '
        'colBruto
        '
        Me.colBruto.HeaderText = "Peso Bruto"
        Me.colBruto.MinimumWidth = 6
        Me.colBruto.Name = "colBruto"
        Me.colBruto.Width = 125
        '
        'colNeto
        '
        Me.colNeto.HeaderText = "Peso Neto"
        Me.colNeto.MinimumWidth = 6
        Me.colNeto.Name = "colNeto"
        Me.colNeto.Width = 125
        '
        'colCalibre
        '
        Me.colCalibre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCalibre.HeaderText = "Calibre"
        Me.colCalibre.MinimumWidth = 6
        Me.colCalibre.Name = "colCalibre"
        Me.colCalibre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCalibre.Width = 125
        '
        'colUbicacion
        '
        Me.colUbicacion.HeaderText = "Ubicacion"
        Me.colUbicacion.MinimumWidth = 6
        Me.colUbicacion.Name = "colUbicacion"
        Me.colUbicacion.Width = 125
        '
        'idR
        '
        Me.idR.HeaderText = "N° Recepción"
        Me.idR.MinimumWidth = 6
        Me.idR.Name = "idR"
        Me.idR.ReadOnly = True
        Me.idR.Visible = False
        Me.idR.Width = 216
        '
        'IdPersona
        '
        Me.IdPersona.HeaderText = "IdPersona"
        Me.IdPersona.MinimumWidth = 6
        Me.IdPersona.Name = "IdPersona"
        Me.IdPersona.Visible = False
        Me.IdPersona.Width = 125
        '
        'Variedad
        '
        Me.Variedad.HeaderText = "Variedad"
        Me.Variedad.MinimumWidth = 6
        Me.Variedad.Name = "Variedad"
        Me.Variedad.Visible = False
        Me.Variedad.Width = 125
        '
        'persona
        '
        Me.persona.HeaderText = "Nombre"
        Me.persona.MinimumWidth = 6
        Me.persona.Name = "persona"
        Me.persona.Visible = False
        Me.persona.Width = 125
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.MinimumWidth = 6
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.Visible = False
        Me.IdProducto.Width = 125
        '
        'ucResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblTipoRecepcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.dgvResumen)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucResumen"
        Me.Size = New System.Drawing.Size(1406, 821)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnCancelar As Button
	Friend WithEvents lblTotal As Label
    Friend WithEvents dgvResumen As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTipoRecepcion As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents Título As DataGridViewTextBoxColumn
    Friend WithEvents colProducto As DataGridViewTextBoxColumn
    Friend WithEvents colVariedad As DataGridViewTextBoxColumn
    Friend WithEvents colIdCont As DataGridViewTextBoxColumn
    Friend WithEvents colTara As DataGridViewTextBoxColumn
    Friend WithEvents colBruto As DataGridViewTextBoxColumn
    Friend WithEvents colNeto As DataGridViewTextBoxColumn
    Friend WithEvents colCalibre As DataGridViewComboBoxColumn
    Friend WithEvents colUbicacion As DataGridViewComboBoxColumn
    Friend WithEvents idR As DataGridViewTextBoxColumn
    Friend WithEvents IdPersona As DataGridViewTextBoxColumn
    Friend WithEvents Variedad As DataGridViewTextBoxColumn
    Friend WithEvents persona As DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
End Class
