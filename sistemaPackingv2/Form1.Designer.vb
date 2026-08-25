<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.btnDespacho = New System.Windows.Forms.Button()
        Me.btnPallet = New System.Windows.Forms.Button()
        Me.btnTarjado = New System.Windows.Forms.Button()
        Me.btnTotales = New System.Windows.Forms.Button()
        Me.btnCalibreValidacion = New System.Windows.Forms.Button()
        Me.btnCalibres = New System.Windows.Forms.Button()
        Me.btnRecepcionProceso = New System.Windows.Forms.Button()
        Me.btnNuevoProceso = New System.Windows.Forms.Button()
        Me.btnRecepcion = New System.Windows.Forms.Button()
        Me.btnNuevaRecepcion = New System.Windows.Forms.Button()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.btnSimularPeso = New System.Windows.Forms.Button()
        Me.txtSimulador = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.Button3)
        Me.pnlMenu.Controls.Add(Me.Button2)
        Me.pnlMenu.Controls.Add(Me.Button1)
        Me.pnlMenu.Controls.Add(Me.btnConfig)
        Me.pnlMenu.Controls.Add(Me.btnDespacho)
        Me.pnlMenu.Controls.Add(Me.btnPallet)
        Me.pnlMenu.Controls.Add(Me.btnTarjado)
        Me.pnlMenu.Controls.Add(Me.btnTotales)
        Me.pnlMenu.Controls.Add(Me.btnCalibreValidacion)
        Me.pnlMenu.Controls.Add(Me.btnCalibres)
        Me.pnlMenu.Controls.Add(Me.btnRecepcionProceso)
        Me.pnlMenu.Controls.Add(Me.btnNuevoProceso)
        Me.pnlMenu.Controls.Add(Me.btnRecepcion)
        Me.pnlMenu.Controls.Add(Me.btnNuevaRecepcion)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(307, 1415)
        Me.pnlMenu.TabIndex = 2
        '
        'btnConfig
        '
        Me.btnConfig.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfig.Location = New System.Drawing.Point(0, 890)
        Me.btnConfig.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(307, 89)
        Me.btnConfig.TabIndex = 16
        Me.btnConfig.Text = "Configuración"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'btnDespacho
        '
        Me.btnDespacho.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDespacho.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDespacho.Location = New System.Drawing.Point(0, 801)
        Me.btnDespacho.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDespacho.Name = "btnDespacho"
        Me.btnDespacho.Size = New System.Drawing.Size(307, 89)
        Me.btnDespacho.TabIndex = 15
        Me.btnDespacho.Text = "Despacho"
        Me.btnDespacho.UseVisualStyleBackColor = True
        '
        'btnPallet
        '
        Me.btnPallet.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPallet.Location = New System.Drawing.Point(0, 712)
        Me.btnPallet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPallet.Name = "btnPallet"
        Me.btnPallet.Size = New System.Drawing.Size(307, 89)
        Me.btnPallet.TabIndex = 14
        Me.btnPallet.Text = "Paletizado"
        Me.btnPallet.UseVisualStyleBackColor = True
        '
        'btnTarjado
        '
        Me.btnTarjado.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTarjado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarjado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTarjado.Location = New System.Drawing.Point(0, 623)
        Me.btnTarjado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTarjado.Name = "btnTarjado"
        Me.btnTarjado.Size = New System.Drawing.Size(307, 89)
        Me.btnTarjado.TabIndex = 9
        Me.btnTarjado.Text = "Re Pesaje"
        Me.btnTarjado.UseVisualStyleBackColor = True
        '
        'btnTotales
        '
        Me.btnTotales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTotales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTotales.Location = New System.Drawing.Point(0, 534)
        Me.btnTotales.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTotales.Name = "btnTotales"
        Me.btnTotales.Size = New System.Drawing.Size(307, 89)
        Me.btnTotales.TabIndex = 8
        Me.btnTotales.Text = "Totales"
        Me.btnTotales.UseVisualStyleBackColor = True
        '
        'btnCalibreValidacion
        '
        Me.btnCalibreValidacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCalibreValidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalibreValidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalibreValidacion.Location = New System.Drawing.Point(0, 445)
        Me.btnCalibreValidacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCalibreValidacion.Name = "btnCalibreValidacion"
        Me.btnCalibreValidacion.Size = New System.Drawing.Size(307, 89)
        Me.btnCalibreValidacion.TabIndex = 7
        Me.btnCalibreValidacion.Text = "Validacion Calibre"
        Me.btnCalibreValidacion.UseVisualStyleBackColor = True
        '
        'btnCalibres
        '
        Me.btnCalibres.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCalibres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalibres.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalibres.Location = New System.Drawing.Point(0, 356)
        Me.btnCalibres.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCalibres.Name = "btnCalibres"
        Me.btnCalibres.Size = New System.Drawing.Size(307, 89)
        Me.btnCalibres.TabIndex = 5
        Me.btnCalibres.Text = "Calibres"
        Me.btnCalibres.UseVisualStyleBackColor = True
        '
        'btnRecepcionProceso
        '
        Me.btnRecepcionProceso.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecepcionProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecepcionProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecepcionProceso.Location = New System.Drawing.Point(0, 267)
        Me.btnRecepcionProceso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRecepcionProceso.Name = "btnRecepcionProceso"
        Me.btnRecepcionProceso.Size = New System.Drawing.Size(307, 89)
        Me.btnRecepcionProceso.TabIndex = 4
        Me.btnRecepcionProceso.Text = "Recepción Proceso"
        Me.btnRecepcionProceso.UseVisualStyleBackColor = True
        '
        'btnNuevoProceso
        '
        Me.btnNuevoProceso.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNuevoProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoProceso.Location = New System.Drawing.Point(0, 178)
        Me.btnNuevoProceso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevoProceso.Name = "btnNuevoProceso"
        Me.btnNuevoProceso.Size = New System.Drawing.Size(307, 89)
        Me.btnNuevoProceso.TabIndex = 2
        Me.btnNuevoProceso.Text = "Nuevo Proceso"
        Me.btnNuevoProceso.UseVisualStyleBackColor = True
        '
        'btnRecepcion
        '
        Me.btnRecepcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecepcion.Location = New System.Drawing.Point(0, 89)
        Me.btnRecepcion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRecepcion.Name = "btnRecepcion"
        Me.btnRecepcion.Size = New System.Drawing.Size(307, 89)
        Me.btnRecepcion.TabIndex = 1
        Me.btnRecepcion.Text = "Agregar datos Recepción"
        Me.btnRecepcion.UseVisualStyleBackColor = True
        '
        'btnNuevaRecepcion
        '
        Me.btnNuevaRecepcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNuevaRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaRecepcion.Location = New System.Drawing.Point(0, 0)
        Me.btnNuevaRecepcion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevaRecepcion.Name = "btnNuevaRecepcion"
        Me.btnNuevaRecepcion.Size = New System.Drawing.Size(307, 89)
        Me.btnNuevaRecepcion.TabIndex = 0
        Me.btnNuevaRecepcion.Text = "Nueva Recepción"
        Me.btnNuevaRecepcion.UseVisualStyleBackColor = True
        '
        'pnlContenedor
        '
        Me.pnlContenedor.Location = New System.Drawing.Point(307, 0)
        Me.pnlContenedor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1275, 1060)
        Me.pnlContenedor.TabIndex = 3
        '
        'btnSimularPeso
        '
        Me.btnSimularPeso.Location = New System.Drawing.Point(455, 6)
        Me.btnSimularPeso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSimularPeso.Name = "btnSimularPeso"
        Me.btnSimularPeso.Size = New System.Drawing.Size(75, 31)
        Me.btnSimularPeso.TabIndex = 5
        Me.btnSimularPeso.Text = "Peso"
        Me.btnSimularPeso.UseVisualStyleBackColor = True
        '
        'txtSimulador
        '
        Me.txtSimulador.Location = New System.Drawing.Point(338, 11)
        Me.txtSimulador.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSimulador.Name = "txtSimulador"
        Me.txtSimulador.Size = New System.Drawing.Size(100, 22)
        Me.txtSimulador.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 979)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(307, 89)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Crear Orden Pallet"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(0, 1068)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(307, 89)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Despacho O Repesaje"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(0, 1157)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(307, 89)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Validar previo Bin/Pallet"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1582, 1415)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.btnSimularPeso)
        Me.Controls.Add(Me.txtSimulador)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Sistema Packing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents btnNuevaRecepcion As Button
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents btnRecepcion As Button
    Friend WithEvents txtSimulador As TextBox
    Friend WithEvents btnSimularPeso As Button
    Friend WithEvents btnNuevoProceso As Button
    Friend WithEvents btnRecepcionProceso As Button
    Friend WithEvents btnCalibres As Button
    Friend WithEvents btnCalibreValidacion As Button
    Friend WithEvents btnTotales As Button
    Friend WithEvents btnTarjado As Button
    Friend WithEvents btnPallet As Button
    Friend WithEvents btnDespacho As Button
    Friend WithEvents btnConfig As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
