<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCalibradoValidacion
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblContenedor = New System.Windows.Forms.Label()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.btnProcederPesaje = New System.Windows.Forms.Button()
        Me.dgvContenedores = New System.Windows.Forms.DataGridView()
        Me.dgvDisponibles = New System.Windows.Forms.DataGridView()
        CType(Me.dgvContenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Validar Contenedor"
        '
        'lblContenedor
        '
        Me.lblContenedor.AutoSize = True
        Me.lblContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContenedor.Location = New System.Drawing.Point(48, 116)
        Me.lblContenedor.Name = "lblContenedor"
        Me.lblContenedor.Size = New System.Drawing.Size(201, 32)
        Me.lblContenedor.TabIndex = 1
        Me.lblContenedor.Text = "N° Contenedor"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(303, 116)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(329, 38)
        Me.txtBusqueda.TabIndex = 2
        '
        'btnProcederPesaje
        '
        Me.btnProcederPesaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcederPesaje.Location = New System.Drawing.Point(361, 622)
        Me.btnProcederPesaje.Name = "btnProcederPesaje"
        Me.btnProcederPesaje.Size = New System.Drawing.Size(221, 95)
        Me.btnProcederPesaje.TabIndex = 3
        Me.btnProcederPesaje.Text = "Pesaje"
        Me.btnProcederPesaje.UseVisualStyleBackColor = True
        '
        'dgvContenedores
        '
        Me.dgvContenedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContenedores.Location = New System.Drawing.Point(54, 180)
        Me.dgvContenedores.Name = "dgvContenedores"
        Me.dgvContenedores.RowHeadersWidth = 51
        Me.dgvContenedores.RowTemplate.Height = 24
        Me.dgvContenedores.Size = New System.Drawing.Size(882, 103)
        Me.dgvContenedores.TabIndex = 4
        '
        'dgvDisponibles
        '
        Me.dgvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDisponibles.Location = New System.Drawing.Point(54, 303)
        Me.dgvDisponibles.Name = "dgvDisponibles"
        Me.dgvDisponibles.RowHeadersWidth = 51
        Me.dgvDisponibles.RowTemplate.Height = 24
        Me.dgvDisponibles.Size = New System.Drawing.Size(882, 282)
        Me.dgvDisponibles.TabIndex = 5
        '
        'ucCalibradoValidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvDisponibles)
        Me.Controls.Add(Me.dgvContenedores)
        Me.Controls.Add(Me.btnProcederPesaje)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.lblContenedor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucCalibradoValidacion"
        Me.Size = New System.Drawing.Size(1000, 844)
        CType(Me.dgvContenedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
	Friend WithEvents lblContenedor As Label
	Friend WithEvents txtBusqueda As TextBox
	Friend WithEvents btnProcederPesaje As Button
	Friend WithEvents dgvContenedores As DataGridView
    Friend WithEvents dgvDisponibles As DataGridView
End Class
