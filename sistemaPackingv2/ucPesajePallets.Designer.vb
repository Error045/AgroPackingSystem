<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPesajePallets
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
        Me.UcUbicacionPallets1 = New sistemaPackingv2.ucUbicacionPallets()
        Me.pnlContenedorPesaje = New System.Windows.Forms.Panel()
        Me.UcValidacionPallet1 = New sistemaPackingv2.ucValidacionPallet()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        Me.pnlContenedorPesaje.SuspendLayout()
        Me.SuspendLayout()
        '
        'UcUbicacionPallets1
        '
        Me.UcUbicacionPallets1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcUbicacionPallets1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcUbicacionPallets1.Location = New System.Drawing.Point(0, 0)
        Me.UcUbicacionPallets1.Name = "UcUbicacionPallets1"
        Me.UcUbicacionPallets1.Size = New System.Drawing.Size(1200, 900)
        Me.UcUbicacionPallets1.TabIndex = 2
        '
        'pnlContenedorPesaje
        '
        Me.pnlContenedorPesaje.Controls.Add(Me.UcValidacionPallet1)
        Me.pnlContenedorPesaje.Controls.Add(Me.UcPesaje1)
        Me.pnlContenedorPesaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedorPesaje.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedorPesaje.Name = "pnlContenedorPesaje"
        Me.pnlContenedorPesaje.Size = New System.Drawing.Size(1200, 900)
        Me.pnlContenedorPesaje.TabIndex = 2
        '
        'UcValidacionPallet1
        '
        Me.UcValidacionPallet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcValidacionPallet1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcValidacionPallet1.Location = New System.Drawing.Point(0, 0)
        Me.UcValidacionPallet1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcValidacionPallet1.Name = "UcValidacionPallet1"
        Me.UcValidacionPallet1.Size = New System.Drawing.Size(1200, 900)
        Me.UcValidacionPallet1.TabIndex = 3
        '
        'UcPesaje1
        '
        Me.UcPesaje1.DatosActuales = Nothing
        Me.UcPesaje1.IdContenedorSeleccionado = 0
        Me.UcPesaje1.Location = New System.Drawing.Point(51, 156)
        Me.UcPesaje1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcPesaje1.Name = "UcPesaje1"
        Me.UcPesaje1.Peso = "0,0"
        Me.UcPesaje1.PesoAcumuladoAnterior = 0R
        Me.UcPesaje1.PesoAcumuladoBinesAnteriores = 0R
        Me.UcPesaje1.Size = New System.Drawing.Size(1118, 872)
        Me.UcPesaje1.TabIndex = 0
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        '
        'ucPesajePallets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlContenedorPesaje)
        Me.Controls.Add(Me.UcUbicacionPallets1)
        Me.Name = "ucPesajePallets"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.pnlContenedorPesaje.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcUbicacionPallets1 As ucUbicacionPallets
    Friend WithEvents pnlContenedorPesaje As Panel
    Friend WithEvents UcPesaje1 As ucPesaje
    Friend WithEvents UcValidacionPallet1 As ucValidacionPallet
End Class
