<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPesajePalletsDespacho
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
        Me.pnlContenedorPesajePallets = New System.Windows.Forms.Panel()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        Me.UcValidacionPalletDespacho1 = New sistemaPackingv2.ucValidacionPalletDespacho()
        Me.UcUbicacionPalletsDespacho1 = New sistemaPackingv2.ucUbicacionPalletsDespacho()
        Me.pnlContenedorPesajePallets.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorPesajePallets
        '
        Me.pnlContenedorPesajePallets.Controls.Add(Me.UcValidacionPalletDespacho1)
        Me.pnlContenedorPesajePallets.Controls.Add(Me.UcUbicacionPalletsDespacho1)
        Me.pnlContenedorPesajePallets.Controls.Add(Me.UcPesaje1)
        Me.pnlContenedorPesajePallets.Location = New System.Drawing.Point(3, 3)
        Me.pnlContenedorPesajePallets.Name = "pnlContenedorPesajePallets"
        Me.pnlContenedorPesajePallets.Size = New System.Drawing.Size(1175, 884)
        Me.pnlContenedorPesajePallets.TabIndex = 0
        '
        'UcPesaje1
        '
        Me.UcPesaje1.DatosActuales = Nothing
        Me.UcPesaje1.IdContenedorSeleccionado = 0
        Me.UcPesaje1.Location = New System.Drawing.Point(0, 2)
        Me.UcPesaje1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcPesaje1.Name = "UcPesaje1"
        Me.UcPesaje1.Peso = "0,0"
        Me.UcPesaje1.PesoAcumuladoAnterior = 0R
        Me.UcPesaje1.PesoAcumuladoBinesAnteriores = 0R
        Me.UcPesaje1.Size = New System.Drawing.Size(1147, 849)
        Me.UcPesaje1.TabIndex = 0
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        '
        'UcValidacionPalletDespacho1
        '
        Me.UcValidacionPalletDespacho1.Location = New System.Drawing.Point(-3, 0)
        Me.UcValidacionPalletDespacho1.Name = "UcValidacionPalletDespacho1"
        Me.UcValidacionPalletDespacho1.Size = New System.Drawing.Size(1100, 800)
        Me.UcValidacionPalletDespacho1.TabIndex = 1
        '
        'UcUbicacionPalletsDespacho1
        '
        Me.UcUbicacionPalletsDespacho1.Location = New System.Drawing.Point(0, 3)
        Me.UcUbicacionPalletsDespacho1.Name = "UcUbicacionPalletsDespacho1"
        Me.UcUbicacionPalletsDespacho1.Size = New System.Drawing.Size(1200, 800)
        Me.UcUbicacionPalletsDespacho1.TabIndex = 2
        '
        'ucPesajePalletsDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlContenedorPesajePallets)
        Me.Name = "ucPesajePalletsDespacho"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.pnlContenedorPesajePallets.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedorPesajePallets As Panel
    Friend WithEvents UcPesaje1 As ucPesaje
    Friend WithEvents UcValidacionPalletDespacho1 As ucValidacionPalletDespacho
    Friend WithEvents UcUbicacionPalletsDespacho1 As ucUbicacionPalletsDespacho
End Class
