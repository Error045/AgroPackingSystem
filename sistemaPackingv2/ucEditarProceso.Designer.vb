<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEditarProceso
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbRecepcionesDisponibles = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvRecepcionesActuales = New System.Windows.Forms.DataGridView()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        CType(Me.dgvRecepcionesActuales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(87, 92)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(86, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Label1"
        '
        'cmbRecepcionesDisponibles
        '
        Me.cmbRecepcionesDisponibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRecepcionesDisponibles.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecepcionesDisponibles.FormattingEnabled = True
        Me.cmbRecepcionesDisponibles.Location = New System.Drawing.Point(199, 92)
        Me.cmbRecepcionesDisponibles.Name = "cmbRecepcionesDisponibles"
        Me.cmbRecepcionesDisponibles.Size = New System.Drawing.Size(480, 37)
        Me.cmbRecepcionesDisponibles.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(733, 92)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(144, 67)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar A Proceso"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvRecepcionesActuales
        '
        Me.dgvRecepcionesActuales.AllowUserToAddRows = False
        Me.dgvRecepcionesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecepcionesActuales.Location = New System.Drawing.Point(44, 215)
        Me.dgvRecepcionesActuales.Name = "dgvRecepcionesActuales"
        Me.dgvRecepcionesActuales.RowHeadersWidth = 51
        Me.dgvRecepcionesActuales.RowTemplate.Height = 24
        Me.dgvRecepcionesActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecepcionesActuales.Size = New System.Drawing.Size(689, 199)
        Me.dgvRecepcionesActuales.TabIndex = 3
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Location = New System.Drawing.Point(767, 215)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(144, 67)
        Me.btnQuitar.TabIndex = 4
        Me.btnQuitar.Text = "Quitar Recepción"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(331, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "EDITAR PROCESO"
        '
        'btnVolver
        '
        Me.btnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolver.Location = New System.Drawing.Point(150, 476)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(150, 70)
        Me.btnVolver.TabIndex = 6
        Me.btnVolver.Text = "VOLVER"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'ucEditarProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.dgvRecepcionesActuales)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cmbRecepcionesDisponibles)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "ucEditarProceso"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.dgvRecepcionesActuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents cmbRecepcionesDisponibles As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dgvRecepcionesActuales As DataGridView
    Friend WithEvents btnQuitar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnVolver As Button
End Class
