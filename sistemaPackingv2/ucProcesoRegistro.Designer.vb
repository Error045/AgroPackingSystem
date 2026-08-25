<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucProcesoRegistro
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
        Me.lblRecepcion = New System.Windows.Forms.Label()
        Me.txtIdRecepcion = New System.Windows.Forms.TextBox()
        Me.dgvHistorico = New System.Windows.Forms.DataGridView()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnProcesar = New System.Windows.Forms.Button()
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRecepcion
        '
        Me.lblRecepcion.AutoSize = True
        Me.lblRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecepcion.Location = New System.Drawing.Point(145, 149)
        Me.lblRecepcion.Name = "lblRecepcion"
        Me.lblRecepcion.Size = New System.Drawing.Size(225, 29)
        Me.lblRecepcion.TabIndex = 0
        Me.lblRecepcion.Text = "Código Contenedor"
        '
        'txtIdRecepcion
        '
        Me.txtIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdRecepcion.Location = New System.Drawing.Point(406, 149)
        Me.txtIdRecepcion.Name = "txtIdRecepcion"
        Me.txtIdRecepcion.Size = New System.Drawing.Size(286, 34)
        Me.txtIdRecepcion.TabIndex = 2
        '
        'dgvHistorico
        '
        Me.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistorico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHistorico.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHistorico.Location = New System.Drawing.Point(30, 299)
        Me.dgvHistorico.Name = "dgvHistorico"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistorico.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHistorico.RowHeadersVisible = False
        Me.dgvHistorico.RowHeadersWidth = 51
        Me.dgvHistorico.RowTemplate.Height = 24
        Me.dgvHistorico.Size = New System.Drawing.Size(1139, 453)
        Me.dgvHistorico.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(335, 58)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(301, 36)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Registro de Procesos"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(719, 138)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(123, 54)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(144, 218)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(108, 36)
        Me.lblEstado.TabIndex = 6
        Me.lblEstado.Text = "Estado"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Location = New System.Drawing.Point(690, 208)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(152, 61)
        Me.btnProcesar.TabIndex = 7
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'ucProcesoRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dgvHistorico)
        Me.Controls.Add(Me.txtIdRecepcion)
        Me.Controls.Add(Me.lblRecepcion)
        Me.Name = "ucProcesoRegistro"
        Me.Size = New System.Drawing.Size(1222, 838)
        CType(Me.dgvHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRecepcion As Label
	Friend WithEvents txtIdRecepcion As TextBox
	Friend WithEvents dgvHistorico As DataGridView
	Friend WithEvents lblTitulo As Label
	Friend WithEvents btnBuscar As Button
	Friend WithEvents lblEstado As Label
	Friend WithEvents btnProcesar As Button

	Private Sub txtIdRecepcion_TextChanged(sender As Object, e As EventArgs) Handles txtIdRecepcion.TextChanged

	End Sub



End Class
