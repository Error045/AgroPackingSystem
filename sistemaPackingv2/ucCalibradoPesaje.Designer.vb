<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCalibradoPesaje
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
        Me.pnlContenedorPesaje = New System.Windows.Forms.Panel()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        Me.ucCalValidacion1 = New sistemaPackingv2.ucCalibradoValidacion()
        Me.UcUbicacion1 = New sistemaPackingv2.ucUbicacion()
        Me.pnlContenedorPesaje.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorPesaje
        '
        Me.pnlContenedorPesaje.BackColor = System.Drawing.SystemColors.Control
        Me.pnlContenedorPesaje.Controls.Add(Me.UcPesaje1)
        Me.pnlContenedorPesaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedorPesaje.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedorPesaje.Name = "pnlContenedorPesaje"
        Me.pnlContenedorPesaje.Size = New System.Drawing.Size(1000, 2000)
        Me.pnlContenedorPesaje.TabIndex = 2
        '
        'UcPesaje1
        '
        Me.UcPesaje1.DatosActuales = Nothing
        Me.UcPesaje1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UcPesaje1.IdContenedorSeleccionado = 0
        Me.UcPesaje1.Location = New System.Drawing.Point(0, 0)
        Me.UcPesaje1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcPesaje1.Name = "UcPesaje1"
        Me.UcPesaje1.Peso = "0,0"
        Me.UcPesaje1.PesoAcumuladoAnterior = 0R
        Me.UcPesaje1.PesoAcumuladoBinesAnteriores = 0R
        Me.UcPesaje1.Size = New System.Drawing.Size(1000, 662)
        Me.UcPesaje1.TabIndex = 3
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        '
        'ucCalValidacion1
        '
        Me.ucCalValidacion1.BackColor = System.Drawing.SystemColors.Control
        Me.ucCalValidacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCalValidacion1.Location = New System.Drawing.Point(0, 0)
        Me.ucCalValidacion1.Name = "ucCalValidacion1"
        Me.ucCalValidacion1.Size = New System.Drawing.Size(1000, 2000)
        Me.ucCalValidacion1.TabIndex = 1
        '
        'UcUbicacion1
        '
        Me.UcUbicacion1.BackColor = System.Drawing.SystemColors.Highlight
        Me.UcUbicacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcUbicacion1.Location = New System.Drawing.Point(0, 0)
        Me.UcUbicacion1.Name = "UcUbicacion1"
        Me.UcUbicacion1.Size = New System.Drawing.Size(1000, 2000)
        Me.UcUbicacion1.TabIndex = 2
        '
        'ucCalibradoPesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucCalValidacion1)
        Me.Controls.Add(Me.pnlContenedorPesaje)
        Me.Controls.Add(Me.UcUbicacion1)
        Me.Name = "ucCalibradoPesaje"
        Me.Size = New System.Drawing.Size(1000, 2000)
        Me.pnlContenedorPesaje.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucCalValidacion1 As ucCalibradoValidacion
	Friend WithEvents pnlContenedorPesaje As Panel
	Friend WithEvents UcUbicacion1 As ucUbicacion
	Friend WithEvents UcPesaje1 As ucPesaje
End Class
