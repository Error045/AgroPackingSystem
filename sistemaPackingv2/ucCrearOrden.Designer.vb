<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCrearOrden
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
        Me.btnCrearOrden = New System.Windows.Forms.Button()
        Me.dgvReporte = New System.Windows.Forms.DataGridView()
        Me.lblRecepcion = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbRecepcion = New System.Windows.Forms.ComboBox()
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvDestino = New System.Windows.Forms.DataGridView()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.cmbCamaras = New System.Windows.Forms.ComboBox()
        Me.cmbProcesos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCrearOrden
        '
        Me.btnCrearOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearOrden.Location = New System.Drawing.Point(298, 709)
        Me.btnCrearOrden.Name = "btnCrearOrden"
        Me.btnCrearOrden.Size = New System.Drawing.Size(416, 71)
        Me.btnCrearOrden.TabIndex = 28
        Me.btnCrearOrden.Text = "Crear Orden"
        Me.btnCrearOrden.UseVisualStyleBackColor = True
        '
        'dgvReporte
        '
        Me.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporte.Location = New System.Drawing.Point(40, 283)
        Me.dgvReporte.Name = "dgvReporte"
        Me.dgvReporte.RowHeadersWidth = 51
        Me.dgvReporte.RowTemplate.Height = 24
        Me.dgvReporte.Size = New System.Drawing.Size(1141, 211)
        Me.dgvReporte.TabIndex = 27
        '
        'lblRecepcion
        '
        Me.lblRecepcion.AutoSize = True
        Me.lblRecepcion.Location = New System.Drawing.Point(72, 207)
        Me.lblRecepcion.Name = "lblRecepcion"
        Me.lblRecepcion.Size = New System.Drawing.Size(85, 16)
        Me.lblRecepcion.TabIndex = 26
        Me.lblRecepcion.Text = "RECEPCION"
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Location = New System.Drawing.Point(94, 160)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(63, 16)
        Me.lblPersona.TabIndex = 25
        Me.lblPersona.Text = "CLIENTE"
        '
        'cmbRecepcion
        '
        Me.cmbRecepcion.FormattingEnabled = True
        Me.cmbRecepcion.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbRecepcion.Location = New System.Drawing.Point(193, 199)
        Me.cmbRecepcion.Name = "cmbRecepcion"
        Me.cmbRecepcion.Size = New System.Drawing.Size(194, 24)
        Me.cmbRecepcion.TabIndex = 24
        '
        'cmbPersona
        '
        Me.cmbPersona.FormattingEnabled = True
        Me.cmbPersona.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbPersona.Location = New System.Drawing.Point(193, 157)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(194, 24)
        Me.cmbPersona.TabIndex = 23
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(193, 109)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(194, 33)
        Me.cmbTipoOperacion.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "TIPO OPERACION"
        '
        'dgvDestino
        '
        Me.dgvDestino.AllowUserToAddRows = False
        Me.dgvDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDestino.Location = New System.Drawing.Point(49, 532)
        Me.dgvDestino.Name = "dgvDestino"
        Me.dgvDestino.RowHeadersWidth = 51
        Me.dgvDestino.RowTemplate.Height = 24
        Me.dgvDestino.Size = New System.Drawing.Size(1141, 171)
        Me.dgvDestino.TabIndex = 47
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.Location = New System.Drawing.Point(910, 109)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(107, 25)
        Me.lblCapacidad.TabIndex = 50
        Me.lblCapacidad.Text = "Capacidad"
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.Location = New System.Drawing.Point(910, 76)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(93, 25)
        Me.lblContador.TabIndex = 49
        Me.lblContador.Text = "Contador"
        '
        'cmbCamaras
        '
        Me.cmbCamaras.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCamaras.FormattingEnabled = True
        Me.cmbCamaras.Location = New System.Drawing.Point(432, 76)
        Me.cmbCamaras.Name = "cmbCamaras"
        Me.cmbCamaras.Size = New System.Drawing.Size(404, 39)
        Me.cmbCamaras.TabIndex = 48
        '
        'cmbProcesos
        '
        Me.cmbProcesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcesos.FormattingEnabled = True
        Me.cmbProcesos.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbProcesos.Location = New System.Drawing.Point(193, 53)
        Me.cmbProcesos.Name = "cmbProcesos"
        Me.cmbProcesos.Size = New System.Drawing.Size(194, 33)
        Me.cmbProcesos.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "PROCESO PALLET"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(427, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(341, 29)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "CREAR ORDEN PALETIZADO"
        '
        'ucCrearOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbProcesos)
        Me.Controls.Add(Me.lblCapacidad)
        Me.Controls.Add(Me.lblContador)
        Me.Controls.Add(Me.cmbCamaras)
        Me.Controls.Add(Me.dgvDestino)
        Me.Controls.Add(Me.btnCrearOrden)
        Me.Controls.Add(Me.dgvReporte)
        Me.Controls.Add(Me.lblRecepcion)
        Me.Controls.Add(Me.lblPersona)
        Me.Controls.Add(Me.cmbRecepcion)
        Me.Controls.Add(Me.cmbPersona)
        Me.Controls.Add(Me.cmbTipoOperacion)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ucCrearOrden"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCrearOrden As Button
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents lblRecepcion As Label
    Friend WithEvents lblPersona As Label
    Friend WithEvents cmbRecepcion As ComboBox
    Friend WithEvents cmbPersona As ComboBox
    Friend WithEvents cmbTipoOperacion As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvDestino As DataGridView
    Friend WithEvents lblCapacidad As Label
    Friend WithEvents lblContador As Label
    Friend WithEvents cmbCamaras As ComboBox
    Friend WithEvents cmbProcesos As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
