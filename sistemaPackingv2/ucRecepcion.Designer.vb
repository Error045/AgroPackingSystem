<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucRecepcion
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
		Me.pnlContenedores = New System.Windows.Forms.Panel()
		Me.UcSelector1 = New sistemaPackingv2.ucSelector()
		Me.UcProducto1 = New sistemaPackingv2.ucProducto()
		Me.UcRecepcionEstado1 = New sistemaPackingv2.ucRecepcionEstado()
		Me.SuspendLayout()
		'
		'pnlContenedores
		'
		Me.pnlContenedores.AutoScroll = True
		Me.pnlContenedores.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlContenedores.Location = New System.Drawing.Point(0, 1812)
		Me.pnlContenedores.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnlContenedores.Name = "pnlContenedores"
		Me.pnlContenedores.Size = New System.Drawing.Size(2213, 1119)
		Me.pnlContenedores.TabIndex = 5
		'
		'UcSelector1
		'
		Me.UcSelector1.Dock = System.Windows.Forms.DockStyle.Top
		Me.UcSelector1.Location = New System.Drawing.Point(0, 1230)
		Me.UcSelector1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.UcSelector1.Name = "UcSelector1"
		Me.UcSelector1.Size = New System.Drawing.Size(2213, 582)
		Me.UcSelector1.TabIndex = 0
		'
		'UcProducto1
		'
		Me.UcProducto1.Dock = System.Windows.Forms.DockStyle.Top
		Me.UcProducto1.Location = New System.Drawing.Point(0, 601)
		Me.UcProducto1.Margin = New System.Windows.Forms.Padding(5)
		Me.UcProducto1.Name = "UcProducto1"
		Me.UcProducto1.Size = New System.Drawing.Size(2213, 629)
		Me.UcProducto1.TabIndex = 8
		'
		'UcRecepcionEstado1
		'
		Me.UcRecepcionEstado1.Dock = System.Windows.Forms.DockStyle.Top
		Me.UcRecepcionEstado1.Location = New System.Drawing.Point(0, 0)
		Me.UcRecepcionEstado1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.UcRecepcionEstado1.Name = "UcRecepcionEstado1"
		Me.UcRecepcionEstado1.Size = New System.Drawing.Size(2213, 601)
		Me.UcRecepcionEstado1.TabIndex = 7
		'
		'ucRecepcion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.Controls.Add(Me.pnlContenedores)
		Me.Controls.Add(Me.UcSelector1)
		Me.Controls.Add(Me.UcProducto1)
		Me.Controls.Add(Me.UcRecepcionEstado1)
		Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.Name = "ucRecepcion"
		Me.Size = New System.Drawing.Size(2213, 2931)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents UcSelector1 As ucSelector
	Friend WithEvents pnlContenedores As Panel
	Friend WithEvents UcRecepcionEstado1 As ucRecepcionEstado
	Friend WithEvents UcProducto1 As ucProducto
End Class
