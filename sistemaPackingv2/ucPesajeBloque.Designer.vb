<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPesajeBloque
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.flpInfoCabecera = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblIdRecepcion = New System.Windows.Forms.Label()
        Me.lblIdProceso = New System.Windows.Forms.Label()
        Me.lblIdCalibrado = New System.Windows.Forms.Label()
        Me.lblProductor = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblVariedad = New System.Windows.Forms.Label()
        Me.lblCalibre = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cboContenedor1 = New System.Windows.Forms.ComboBox()
        Me.lblPesoTotal = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMedio = New System.Windows.Forms.Panel()
        Me.cboContenedor2 = New System.Windows.Forms.ComboBox()
        Me.cboContenedor3 = New System.Windows.Forms.ComboBox()
        Me.pnlContenedor1 = New System.Windows.Forms.Panel()
        Me.pnlContenedor2 = New System.Windows.Forms.Panel()
        Me.pnlContenedor3 = New System.Windows.Forms.Panel()
        Me.lblPesoBruto = New System.Windows.Forms.Label()
        Me.btnCapturarPeso = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.flpInfoCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMedio.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'flpInfoCabecera
        '
        Me.flpInfoCabecera.Controls.Add(Me.lblIdRecepcion)
        Me.flpInfoCabecera.Controls.Add(Me.lblIdProceso)
        Me.flpInfoCabecera.Controls.Add(Me.lblIdCalibrado)
        Me.flpInfoCabecera.Controls.Add(Me.lblProductor)
        Me.flpInfoCabecera.Controls.Add(Me.lblProducto)
        Me.flpInfoCabecera.Controls.Add(Me.lblVariedad)
        Me.flpInfoCabecera.Controls.Add(Me.lblCalibre)
        Me.flpInfoCabecera.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpInfoCabecera.Location = New System.Drawing.Point(14, 49)
        Me.flpInfoCabecera.Name = "flpInfoCabecera"
        Me.flpInfoCabecera.Size = New System.Drawing.Size(261, 378)
        Me.flpInfoCabecera.TabIndex = 28
        '
        'lblIdRecepcion
        '
        Me.lblIdRecepcion.AutoSize = True
        Me.lblIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRecepcion.Location = New System.Drawing.Point(3, 0)
        Me.lblIdRecepcion.Name = "lblIdRecepcion"
        Me.lblIdRecepcion.Size = New System.Drawing.Size(129, 29)
        Me.lblIdRecepcion.TabIndex = 5
        Me.lblIdRecepcion.Text = "Recepcion"
        '
        'lblIdProceso
        '
        Me.lblIdProceso.AutoSize = True
        Me.lblIdProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProceso.Location = New System.Drawing.Point(3, 29)
        Me.lblIdProceso.Name = "lblIdProceso"
        Me.lblIdProceso.Size = New System.Drawing.Size(103, 29)
        Me.lblIdProceso.TabIndex = 22
        Me.lblIdProceso.Text = "Proceso"
        '
        'lblIdCalibrado
        '
        Me.lblIdCalibrado.AutoSize = True
        Me.lblIdCalibrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCalibrado.Location = New System.Drawing.Point(3, 58)
        Me.lblIdCalibrado.Name = "lblIdCalibrado"
        Me.lblIdCalibrado.Size = New System.Drawing.Size(118, 29)
        Me.lblIdCalibrado.TabIndex = 23
        Me.lblIdCalibrado.Text = "Calibrado"
        '
        'lblProductor
        '
        Me.lblProductor.AutoSize = True
        Me.lblProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductor.Location = New System.Drawing.Point(3, 87)
        Me.lblProductor.Name = "lblProductor"
        Me.lblProductor.Size = New System.Drawing.Size(118, 29)
        Me.lblProductor.TabIndex = 11
        Me.lblProductor.Text = "Productor"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(3, 116)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(110, 29)
        Me.lblProducto.TabIndex = 8
        Me.lblProducto.Text = "Producto"
        '
        'lblVariedad
        '
        Me.lblVariedad.AutoSize = True
        Me.lblVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariedad.Location = New System.Drawing.Point(3, 145)
        Me.lblVariedad.Name = "lblVariedad"
        Me.lblVariedad.Size = New System.Drawing.Size(110, 29)
        Me.lblVariedad.TabIndex = 10
        Me.lblVariedad.Text = "Variedad"
        '
        'lblCalibre
        '
        Me.lblCalibre.AutoSize = True
        Me.lblCalibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibre.Location = New System.Drawing.Point(3, 174)
        Me.lblCalibre.Name = "lblCalibre"
        Me.lblCalibre.Size = New System.Drawing.Size(91, 29)
        Me.lblCalibre.TabIndex = 24
        Me.lblCalibre.Text = "Calibre"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Tahoma", 120.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.Location = New System.Drawing.Point(401, 78)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(321, 241)
        Me.lblPeso.TabIndex = 25
        Me.lblPeso.Text = "---"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(476, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(266, 42)
        Me.lblTitulo.TabIndex = 24
        Me.lblTitulo.Text = "Contenedor #1"
        '
        'cboContenedor1
        '
        Me.cboContenedor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContenedor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContenedor1.FormattingEnabled = True
        Me.cboContenedor1.Location = New System.Drawing.Point(286, 353)
        Me.cboContenedor1.Name = "cboContenedor1"
        Me.cboContenedor1.Size = New System.Drawing.Size(202, 44)
        Me.cboContenedor1.TabIndex = 37
        '
        'lblPesoTotal
        '
        Me.lblPesoTotal.AutoSize = True
        Me.lblPesoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoTotal.Location = New System.Drawing.Point(278, 27)
        Me.lblPesoTotal.Name = "lblPesoTotal"
        Me.lblPesoTotal.Size = New System.Drawing.Size(248, 46)
        Me.lblPesoTotal.TabIndex = 20
        Me.lblPesoTotal.Text = "Valor Actual:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblPesoTotal)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 453)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 104)
        Me.Panel1.TabIndex = 27
        '
        'pnlMedio
        '
        Me.pnlMedio.Controls.Add(Me.Panel2)
        Me.pnlMedio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMedio.Location = New System.Drawing.Point(0, 557)
        Me.pnlMedio.Name = "pnlMedio"
        Me.pnlMedio.Size = New System.Drawing.Size(1200, 343)
        Me.pnlMedio.TabIndex = 26
        '
        'cboContenedor2
        '
        Me.cboContenedor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContenedor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContenedor2.FormattingEnabled = True
        Me.cboContenedor2.Location = New System.Drawing.Point(504, 353)
        Me.cboContenedor2.Name = "cboContenedor2"
        Me.cboContenedor2.Size = New System.Drawing.Size(202, 44)
        Me.cboContenedor2.TabIndex = 38
        '
        'cboContenedor3
        '
        Me.cboContenedor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContenedor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContenedor3.FormattingEnabled = True
        Me.cboContenedor3.Location = New System.Drawing.Point(734, 353)
        Me.cboContenedor3.Name = "cboContenedor3"
        Me.cboContenedor3.Size = New System.Drawing.Size(202, 44)
        Me.cboContenedor3.TabIndex = 39
        '
        'pnlContenedor1
        '
        Me.pnlContenedor1.Location = New System.Drawing.Point(286, 419)
        Me.pnlContenedor1.Name = "pnlContenedor1"
        Me.pnlContenedor1.Size = New System.Drawing.Size(169, 27)
        Me.pnlContenedor1.TabIndex = 40
        '
        'pnlContenedor2
        '
        Me.pnlContenedor2.Location = New System.Drawing.Point(496, 419)
        Me.pnlContenedor2.Name = "pnlContenedor2"
        Me.pnlContenedor2.Size = New System.Drawing.Size(169, 27)
        Me.pnlContenedor2.TabIndex = 41
        '
        'pnlContenedor3
        '
        Me.pnlContenedor3.Location = New System.Drawing.Point(742, 419)
        Me.pnlContenedor3.Name = "pnlContenedor3"
        Me.pnlContenedor3.Size = New System.Drawing.Size(169, 27)
        Me.pnlContenedor3.TabIndex = 42
        '
        'lblPesoBruto
        '
        Me.lblPesoBruto.AutoSize = True
        Me.lblPesoBruto.Location = New System.Drawing.Point(998, 265)
        Me.lblPesoBruto.Name = "lblPesoBruto"
        Me.lblPesoBruto.Size = New System.Drawing.Size(48, 16)
        Me.lblPesoBruto.TabIndex = 43
        Me.lblPesoBruto.Text = "Label1"
        '
        'btnCapturarPeso
        '
        Me.btnCapturarPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturarPeso.Location = New System.Drawing.Point(314, 60)
        Me.btnCapturarPeso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCapturarPeso.Name = "btnCapturarPeso"
        Me.btnCapturarPeso.Size = New System.Drawing.Size(440, 119)
        Me.btnCapturarPeso.TabIndex = 15
        Me.btnCapturarPeso.Text = "Capturar"
        Me.btnCapturarPeso.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCapturarPeso)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1200, 343)
        Me.Panel2.TabIndex = 20
        '
        'ucPesajeBloque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPesoBruto)
        Me.Controls.Add(Me.pnlContenedor3)
        Me.Controls.Add(Me.pnlContenedor2)
        Me.Controls.Add(Me.pnlContenedor1)
        Me.Controls.Add(Me.cboContenedor3)
        Me.Controls.Add(Me.cboContenedor2)
        Me.Controls.Add(Me.cboContenedor1)
        Me.Controls.Add(Me.flpInfoCabecera)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlMedio)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "ucPesajeBloque"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.flpInfoCabecera.ResumeLayout(False)
        Me.flpInfoCabecera.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMedio.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents flpInfoCabecera As FlowLayoutPanel
    Friend WithEvents lblIdRecepcion As Label
    Friend WithEvents lblIdProceso As Label
    Friend WithEvents lblIdCalibrado As Label
    Friend WithEvents lblProductor As Label
    Friend WithEvents lblProducto As Label
    Friend WithEvents lblVariedad As Label
    Friend WithEvents lblCalibre As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents cboContenedor1 As ComboBox
    Friend WithEvents lblPesoTotal As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlMedio As Panel
    Friend WithEvents cboContenedor2 As ComboBox
    Friend WithEvents cboContenedor3 As ComboBox
    Friend WithEvents pnlContenedor1 As Panel
    Friend WithEvents pnlContenedor2 As Panel
    Friend WithEvents pnlContenedor3 As Panel
    Friend WithEvents lblPesoBruto As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCapturarPeso As Button
End Class
