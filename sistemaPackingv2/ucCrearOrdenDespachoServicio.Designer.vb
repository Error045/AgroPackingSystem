<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCrearOrdenDespachoServicio
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRecepcion = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.btnCrearOrden = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.cmbCamaras = New System.Windows.Forms.ComboBox()
        Me.dgvReporte = New System.Windows.Forms.DataGridView()
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.cmbRecepcion = New System.Windows.Forms.ComboBox()
        Me.cmbTIpoOperacion = New System.Windows.Forms.ComboBox()
        Me.cmbDespachos = New System.Windows.Forms.ComboBox()
        Me.dgvDestino = New System.Windows.Forms.DataGridView()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 25)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Tipo "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 25)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Despacho"
        '
        'lblRecepcion
        '
        Me.lblRecepcion.AutoSize = True
        Me.lblRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecepcion.Location = New System.Drawing.Point(30, 249)
        Me.lblRecepcion.Name = "lblRecepcion"
        Me.lblRecepcion.Size = New System.Drawing.Size(104, 25)
        Me.lblRecepcion.TabIndex = 86
        Me.lblRecepcion.Text = "Recepción"
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(40, 202)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(85, 25)
        Me.lblPersona.TabIndex = 85
        Me.lblPersona.Text = "Persona"
        '
        'btnCrearOrden
        '
        Me.btnCrearOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearOrden.Location = New System.Drawing.Point(327, 730)
        Me.btnCrearOrden.Name = "btnCrearOrden"
        Me.btnCrearOrden.Size = New System.Drawing.Size(416, 71)
        Me.btnCrearOrden.TabIndex = 84
        Me.btnCrearOrden.Text = "Crear Orden"
        Me.btnCrearOrden.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(322, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(445, 29)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "CREAR ORDEN DESPACHO SERVICIO"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.Location = New System.Drawing.Point(840, 113)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(107, 25)
        Me.lblCapacidad.TabIndex = 82
        Me.lblCapacidad.Text = "Capacidad"
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.Location = New System.Drawing.Point(840, 80)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(93, 25)
        Me.lblContador.TabIndex = 81
        Me.lblContador.Text = "Contador"
        '
        'cmbCamaras
        '
        Me.cmbCamaras.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCamaras.FormattingEnabled = True
        Me.cmbCamaras.Location = New System.Drawing.Point(431, 91)
        Me.cmbCamaras.Name = "cmbCamaras"
        Me.cmbCamaras.Size = New System.Drawing.Size(360, 39)
        Me.cmbCamaras.TabIndex = 80
        '
        'dgvReporte
        '
        Me.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporte.Location = New System.Drawing.Point(62, 300)
        Me.dgvReporte.Name = "dgvReporte"
        Me.dgvReporte.RowHeadersWidth = 51
        Me.dgvReporte.RowTemplate.Height = 24
        Me.dgvReporte.Size = New System.Drawing.Size(1101, 211)
        Me.dgvReporte.TabIndex = 78
        '
        'cmbPersona
        '
        Me.cmbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPersona.FormattingEnabled = True
        Me.cmbPersona.Location = New System.Drawing.Point(152, 199)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(245, 33)
        Me.cmbPersona.TabIndex = 77
        '
        'cmbRecepcion
        '
        Me.cmbRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecepcion.FormattingEnabled = True
        Me.cmbRecepcion.Location = New System.Drawing.Point(152, 241)
        Me.cmbRecepcion.Name = "cmbRecepcion"
        Me.cmbRecepcion.Size = New System.Drawing.Size(245, 33)
        Me.cmbRecepcion.TabIndex = 76
        '
        'cmbTIpoOperacion
        '
        Me.cmbTIpoOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIpoOperacion.FormattingEnabled = True
        Me.cmbTIpoOperacion.Location = New System.Drawing.Point(152, 146)
        Me.cmbTIpoOperacion.Name = "cmbTIpoOperacion"
        Me.cmbTIpoOperacion.Size = New System.Drawing.Size(245, 33)
        Me.cmbTIpoOperacion.TabIndex = 75
        '
        'cmbDespachos
        '
        Me.cmbDespachos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDespachos.FormattingEnabled = True
        Me.cmbDespachos.Location = New System.Drawing.Point(152, 91)
        Me.cmbDespachos.Name = "cmbDespachos"
        Me.cmbDespachos.Size = New System.Drawing.Size(245, 33)
        Me.cmbDespachos.TabIndex = 74
        '
        'dgvDestino
        '
        Me.dgvDestino.AllowUserToAddRows = False
        Me.dgvDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDestino.Location = New System.Drawing.Point(38, 538)
        Me.dgvDestino.Name = "dgvDestino"
        Me.dgvDestino.RowHeadersWidth = 51
        Me.dgvDestino.RowTemplate.Height = 24
        Me.dgvDestino.Size = New System.Drawing.Size(1141, 171)
        Me.dgvDestino.TabIndex = 89
        '
        'ucCrearOrdenDespachoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvDestino)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRecepcion)
        Me.Controls.Add(Me.lblPersona)
        Me.Controls.Add(Me.btnCrearOrden)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCapacidad)
        Me.Controls.Add(Me.lblContador)
        Me.Controls.Add(Me.cmbCamaras)
        Me.Controls.Add(Me.dgvReporte)
        Me.Controls.Add(Me.cmbPersona)
        Me.Controls.Add(Me.cmbRecepcion)
        Me.Controls.Add(Me.cmbTIpoOperacion)
        Me.Controls.Add(Me.cmbDespachos)
        Me.Name = "ucCrearOrdenDespachoServicio"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblRecepcion As Label
    Friend WithEvents lblPersona As Label
    Friend WithEvents btnCrearOrden As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCapacidad As Label
    Friend WithEvents lblContador As Label
    Friend WithEvents cmbCamaras As ComboBox
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents cmbPersona As ComboBox
    Friend WithEvents cmbRecepcion As ComboBox
    Friend WithEvents cmbTIpoOperacion As ComboBox
    Friend WithEvents cmbDespachos As ComboBox
    Friend WithEvents dgvDestino As DataGridView
End Class
