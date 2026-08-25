<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProcesoPaletizado
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dgvHistorico = New System.Windows.Forms.DataGridView()
        Me.txtIdRecepcion = New System.Windows.Forms.TextBox()
        Me.lblRecepcion = New System.Windows.Forms.Label()
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Location = New System.Drawing.Point(681, 187)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(152, 61)
        Me.btnProcesar.TabIndex = 14
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(135, 197)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(108, 36)
        Me.lblEstado.TabIndex = 13
        Me.lblEstado.Text = "Estado"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(710, 117)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(123, 54)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(326, 37)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(448, 36)
        Me.lblTitulo.TabIndex = 11
        Me.lblTitulo.Text = "Registro de Procesos Paletizado"
        '
        'dgvHistorico
        '
        Me.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistorico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHistorico.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvHistorico.Location = New System.Drawing.Point(21, 278)
        Me.dgvHistorico.Name = "dgvHistorico"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistorico.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvHistorico.RowHeadersVisible = False
        Me.dgvHistorico.RowHeadersWidth = 51
        Me.dgvHistorico.RowTemplate.Height = 24
        Me.dgvHistorico.Size = New System.Drawing.Size(1139, 453)
        Me.dgvHistorico.TabIndex = 10
        '
        'txtIdRecepcion
        '
        Me.txtIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdRecepcion.Location = New System.Drawing.Point(397, 128)
        Me.txtIdRecepcion.Name = "txtIdRecepcion"
        Me.txtIdRecepcion.Size = New System.Drawing.Size(286, 34)
        Me.txtIdRecepcion.TabIndex = 9
        '
        'lblRecepcion
        '
        Me.lblRecepcion.AutoSize = True
        Me.lblRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecepcion.Location = New System.Drawing.Point(136, 128)
        Me.lblRecepcion.Name = "lblRecepcion"
        Me.lblRecepcion.Size = New System.Drawing.Size(225, 29)
        Me.lblRecepcion.TabIndex = 8
        Me.lblRecepcion.Text = "Código Contenedor"
        '
        'ucProcesoPaletizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dgvHistorico)
        Me.Controls.Add(Me.txtIdRecepcion)
        Me.Controls.Add(Me.lblRecepcion)
        Me.Name = "ucProcesoPaletizado"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnProcesar As Button
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvHistorico As DataGridView
    Friend WithEvents txtIdRecepcion As TextBox
    Friend WithEvents lblRecepcion As Label
End Class
