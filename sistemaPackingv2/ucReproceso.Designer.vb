<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucReproceso
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
        Me.cmbProceso = New System.Windows.Forms.ComboBox()
        Me.dgvOrigen = New System.Windows.Forms.DataGridView()
        Me.dgvReprocesar = New System.Windows.Forms.DataGridView()
        Me.btnCrearReProceso = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        CType(Me.dgvOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReprocesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° De Proceso"
        '
        'cmbProceso
        '
        Me.cmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProceso.FormattingEnabled = True
        Me.cmbProceso.Location = New System.Drawing.Point(39, 78)
        Me.cmbProceso.Name = "cmbProceso"
        Me.cmbProceso.Size = New System.Drawing.Size(644, 39)
        Me.cmbProceso.TabIndex = 2
        '
        'dgvOrigen
        '
        Me.dgvOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrigen.Location = New System.Drawing.Point(39, 145)
        Me.dgvOrigen.Name = "dgvOrigen"
        Me.dgvOrigen.RowHeadersWidth = 51
        Me.dgvOrigen.RowTemplate.Height = 24
        Me.dgvOrigen.Size = New System.Drawing.Size(923, 278)
        Me.dgvOrigen.TabIndex = 3
        '
        'dgvReprocesar
        '
        Me.dgvReprocesar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReprocesar.Location = New System.Drawing.Point(39, 458)
        Me.dgvReprocesar.Name = "dgvReprocesar"
        Me.dgvReprocesar.RowHeadersWidth = 51
        Me.dgvReprocesar.RowTemplate.Height = 24
        Me.dgvReprocesar.Size = New System.Drawing.Size(923, 243)
        Me.dgvReprocesar.TabIndex = 4
        '
        'btnCrearReProceso
        '
        Me.btnCrearReProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearReProceso.Location = New System.Drawing.Point(375, 734)
        Me.btnCrearReProceso.Name = "btnCrearReProceso"
        Me.btnCrearReProceso.Size = New System.Drawing.Size(180, 71)
        Me.btnCrearReProceso.TabIndex = 5
        Me.btnCrearReProceso.Text = "Reprocesar"
        Me.btnCrearReProceso.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(386, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 29)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "RE-PROCESAR"
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(843, 74)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(119, 49)
        Me.btnAgregar.TabIndex = 7
        Me.btnAgregar.Text = ">>"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Location = New System.Drawing.Point(708, 74)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(119, 49)
        Me.btnQuitar.TabIndex = 8
        Me.btnQuitar.Text = "<<"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'ucReproceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCrearReProceso)
        Me.Controls.Add(Me.dgvReprocesar)
        Me.Controls.Add(Me.dgvOrigen)
        Me.Controls.Add(Me.cmbProceso)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucReproceso"
        Me.Size = New System.Drawing.Size(1000, 900)
        CType(Me.dgvOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReprocesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbProceso As ComboBox
    Friend WithEvents dgvOrigen As DataGridView
    Friend WithEvents dgvReprocesar As DataGridView
    Friend WithEvents btnCrearReProceso As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
End Class
