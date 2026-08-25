<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfiguracion
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
		Me.cmbPuertos = New System.Windows.Forms.ComboBox()
		Me.cmbBaudios = New System.Windows.Forms.ComboBox()
		Me.lblPuertos = New System.Windows.Forms.Label()
		Me.lblBaudios = New System.Windows.Forms.Label()
		Me.btnProbar = New System.Windows.Forms.Button()
		Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		Me.lblEstadoPrueba = New System.Windows.Forms.Label()
		Me.lblPesoPrueba = New System.Windows.Forms.Label()
		Me.lblTramaOriginal = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'cmbPuertos
		'
		Me.cmbPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPuertos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbPuertos.FormattingEnabled = True
		Me.cmbPuertos.Location = New System.Drawing.Point(277, 126)
		Me.cmbPuertos.Name = "cmbPuertos"
		Me.cmbPuertos.Size = New System.Drawing.Size(179, 37)
		Me.cmbPuertos.TabIndex = 0
		'
		'cmbBaudios
		'
		Me.cmbBaudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbBaudios.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbBaudios.FormattingEnabled = True
		Me.cmbBaudios.Location = New System.Drawing.Point(277, 199)
		Me.cmbBaudios.Name = "cmbBaudios"
		Me.cmbBaudios.Size = New System.Drawing.Size(179, 37)
		Me.cmbBaudios.TabIndex = 1
		'
		'lblPuertos
		'
		Me.lblPuertos.AutoSize = True
		Me.lblPuertos.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPuertos.Location = New System.Drawing.Point(124, 129)
		Me.lblPuertos.Name = "lblPuertos"
		Me.lblPuertos.Size = New System.Drawing.Size(96, 29)
		Me.lblPuertos.TabIndex = 2
		Me.lblPuertos.Text = "Puertos"
		'
		'lblBaudios
		'
		Me.lblBaudios.AutoSize = True
		Me.lblBaudios.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblBaudios.Location = New System.Drawing.Point(119, 202)
		Me.lblBaudios.Name = "lblBaudios"
		Me.lblBaudios.Size = New System.Drawing.Size(101, 29)
		Me.lblBaudios.TabIndex = 3
		Me.lblBaudios.Text = "Baudios"
		'
		'btnProbar
		'
		Me.btnProbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnProbar.Location = New System.Drawing.Point(277, 276)
		Me.btnProbar.Name = "btnProbar"
		Me.btnProbar.Size = New System.Drawing.Size(157, 60)
		Me.btnProbar.TabIndex = 4
		Me.btnProbar.Text = "Probar"
		Me.btnProbar.UseVisualStyleBackColor = True
		'
		'lblEstadoPrueba
		'
		Me.lblEstadoPrueba.AutoSize = True
		Me.lblEstadoPrueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEstadoPrueba.Location = New System.Drawing.Point(586, 129)
		Me.lblEstadoPrueba.Name = "lblEstadoPrueba"
		Me.lblEstadoPrueba.Size = New System.Drawing.Size(91, 29)
		Me.lblEstadoPrueba.TabIndex = 5
		Me.lblEstadoPrueba.Text = "Prueba"
		'
		'lblPesoPrueba
		'
		Me.lblPesoPrueba.AutoSize = True
		Me.lblPesoPrueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPesoPrueba.Location = New System.Drawing.Point(586, 199)
		Me.lblPesoPrueba.Name = "lblPesoPrueba"
		Me.lblPesoPrueba.Size = New System.Drawing.Size(153, 29)
		Me.lblPesoPrueba.TabIndex = 6
		Me.lblPesoPrueba.Text = "Peso Prueba"
		'
		'lblTramaOriginal
		'
		Me.lblTramaOriginal.AutoSize = True
		Me.lblTramaOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTramaOriginal.Location = New System.Drawing.Point(586, 266)
		Me.lblTramaOriginal.Name = "lblTramaOriginal"
		Me.lblTramaOriginal.Size = New System.Drawing.Size(154, 29)
		Me.lblTramaOriginal.TabIndex = 7
		Me.lblTramaOriginal.Text = "Dato Original"
		'
		'btnGuardar
		'
		Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnGuardar.Location = New System.Drawing.Point(277, 455)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(157, 60)
		Me.btnGuardar.TabIndex = 8
		Me.btnGuardar.Text = "Guardar"
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'ucConfiguracion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.lblTramaOriginal)
		Me.Controls.Add(Me.lblPesoPrueba)
		Me.Controls.Add(Me.lblEstadoPrueba)
		Me.Controls.Add(Me.btnProbar)
		Me.Controls.Add(Me.lblBaudios)
		Me.Controls.Add(Me.lblPuertos)
		Me.Controls.Add(Me.cmbBaudios)
		Me.Controls.Add(Me.cmbPuertos)
		Me.Name = "ucConfiguracion"
		Me.Size = New System.Drawing.Size(1600, 900)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents cmbPuertos As ComboBox
	Friend WithEvents cmbBaudios As ComboBox
	Friend WithEvents lblPuertos As Label
	Friend WithEvents lblBaudios As Label
	Friend WithEvents btnProbar As Button
	Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
	Friend WithEvents lblEstadoPrueba As Label
	Friend WithEvents lblPesoPrueba As Label
	Friend WithEvents lblTramaOriginal As Label
	Friend WithEvents btnGuardar As Button
End Class
