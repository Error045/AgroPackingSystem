<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTarjadoPesaje
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
        Me.lblBinesdisponibles = New System.Windows.Forms.Label()
        Me.dgvBinesDisponibles = New System.Windows.Forms.DataGridView()
        Me.btnGuardarFolio = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtKilosCaja = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudCantidadCajas = New System.Windows.Forms.NumericUpDown()
        Me.cmbCajaContenedor = New System.Windows.Forms.ComboBox()
        Me.cmbCalibre = New System.Windows.Forms.ComboBox()
        Me.cmbVariedad = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.btnImprimirTickets = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.txtNumeroFolio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.dgvDetallePalet = New System.Windows.Forms.DataGridView()
        Me.btnAgregarLote = New System.Windows.Forms.Button()
        Me.btn = New System.Windows.Forms.Button()
        Me.UcPesaje1 = New sistemaPackingv2.ucPesaje()
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudCantidadCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetallePalet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBinesdisponibles
        '
        Me.lblBinesdisponibles.AutoSize = True
        Me.lblBinesdisponibles.Location = New System.Drawing.Point(108, 695)
        Me.lblBinesdisponibles.Name = "lblBinesdisponibles"
        Me.lblBinesdisponibles.Size = New System.Drawing.Size(79, 16)
        Me.lblBinesdisponibles.TabIndex = 28
        Me.lblBinesdisponibles.Text = "Disponibles"
        '
        'dgvBinesDisponibles
        '
        Me.dgvBinesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinesDisponibles.Location = New System.Drawing.Point(30, 727)
        Me.dgvBinesDisponibles.Name = "dgvBinesDisponibles"
        Me.dgvBinesDisponibles.RowHeadersWidth = 51
        Me.dgvBinesDisponibles.RowTemplate.Height = 24
        Me.dgvBinesDisponibles.Size = New System.Drawing.Size(1141, 132)
        Me.dgvBinesDisponibles.TabIndex = 27
        '
        'btnGuardarFolio
        '
        Me.btnGuardarFolio.Location = New System.Drawing.Point(464, 452)
        Me.btnGuardarFolio.Name = "btnGuardarFolio"
        Me.btnGuardarFolio.Size = New System.Drawing.Size(123, 47)
        Me.btnGuardarFolio.TabIndex = 24
        Me.btnGuardarFolio.Text = "Cerrar Palet/ Guardar"
        Me.btnGuardarFolio.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKilosCaja)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.nudCantidadCajas)
        Me.GroupBox2.Controls.Add(Me.cmbCajaContenedor)
        Me.GroupBox2.Controls.Add(Me.cmbCalibre)
        Me.GroupBox2.Controls.Add(Me.cmbVariedad)
        Me.GroupBox2.Controls.Add(Me.cmbProducto)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(76, 214)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(836, 216)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Armar  Cajas"
        '
        'txtKilosCaja
        '
        Me.txtKilosCaja.Location = New System.Drawing.Point(577, 165)
        Me.txtKilosCaja.Name = "txtKilosCaja"
        Me.txtKilosCaja.Size = New System.Drawing.Size(100, 30)
        Me.txtKilosCaja.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(450, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 25)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Nro Cajas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(450, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 25)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Capacidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(437, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 25)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Tipo Cajas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Calibre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Variedad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Producto"
        '
        'nudCantidadCajas
        '
        Me.nudCantidadCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCantidadCajas.Location = New System.Drawing.Point(574, 94)
        Me.nudCantidadCajas.Name = "nudCantidadCajas"
        Me.nudCantidadCajas.Size = New System.Drawing.Size(136, 45)
        Me.nudCantidadCajas.TabIndex = 9
        '
        'cmbCajaContenedor
        '
        Me.cmbCajaContenedor.FormattingEnabled = True
        Me.cmbCajaContenedor.Location = New System.Drawing.Point(574, 40)
        Me.cmbCajaContenedor.Name = "cmbCajaContenedor"
        Me.cmbCajaContenedor.Size = New System.Drawing.Size(208, 33)
        Me.cmbCajaContenedor.TabIndex = 8
        '
        'cmbCalibre
        '
        Me.cmbCalibre.FormattingEnabled = True
        Me.cmbCalibre.Location = New System.Drawing.Point(208, 126)
        Me.cmbCalibre.Name = "cmbCalibre"
        Me.cmbCalibre.Size = New System.Drawing.Size(134, 33)
        Me.cmbCalibre.TabIndex = 7
        '
        'cmbVariedad
        '
        Me.cmbVariedad.FormattingEnabled = True
        Me.cmbVariedad.Location = New System.Drawing.Point(208, 86)
        Me.cmbVariedad.Name = "cmbVariedad"
        Me.cmbVariedad.Size = New System.Drawing.Size(134, 33)
        Me.cmbVariedad.TabIndex = 6
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(208, 43)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(134, 33)
        Me.cmbProducto.TabIndex = 5
        '
        'btnImprimirTickets
        '
        Me.btnImprimirTickets.Location = New System.Drawing.Point(307, 450)
        Me.btnImprimirTickets.Name = "btnImprimirTickets"
        Me.btnImprimirTickets.Size = New System.Drawing.Size(120, 51)
        Me.btnImprimirTickets.TabIndex = 23
        Me.btnImprimirTickets.Text = "Imprimir Etiquetas"
        Me.btnImprimirTickets.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbTipoOperacion)
        Me.GroupBox1.Controls.Add(Me.txtNumeroFolio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblFolio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(59, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 163)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Folio"
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(233, 74)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(194, 33)
        Me.cmbTipoOperacion.TabIndex = 3
        '
        'txtNumeroFolio
        '
        Me.txtNumeroFolio.Location = New System.Drawing.Point(233, 29)
        Me.txtNumeroFolio.Name = "txtNumeroFolio"
        Me.txtNumeroFolio.ReadOnly = True
        Me.txtNumeroFolio.Size = New System.Drawing.Size(194, 30)
        Me.txtNumeroFolio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TIPO OPERACION"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(146, 34)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(60, 25)
        Me.lblFolio.TabIndex = 0
        Me.lblFolio.Text = "Folio:"
        '
        'dgvDetallePalet
        '
        Me.dgvDetallePalet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetallePalet.Location = New System.Drawing.Point(30, 552)
        Me.dgvDetallePalet.Name = "dgvDetallePalet"
        Me.dgvDetallePalet.RowHeadersWidth = 51
        Me.dgvDetallePalet.RowTemplate.Height = 24
        Me.dgvDetallePalet.Size = New System.Drawing.Size(1141, 120)
        Me.dgvDetallePalet.TabIndex = 22
        '
        'btnAgregarLote
        '
        Me.btnAgregarLote.Location = New System.Drawing.Point(118, 450)
        Me.btnAgregarLote.Name = "btnAgregarLote"
        Me.btnAgregarLote.Size = New System.Drawing.Size(147, 49)
        Me.btnAgregarLote.TabIndex = 21
        Me.btnAgregarLote.Text = "Agregar al Palet"
        Me.btnAgregarLote.UseVisualStyleBackColor = True
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(606, 452)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(147, 47)
        Me.btn.TabIndex = 29
        Me.btn.Text = "Agregar al Palet"
        Me.btn.UseVisualStyleBackColor = True
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
        Me.UcPesaje1.Size = New System.Drawing.Size(1600, 1048)
        Me.UcPesaje1.TabIndex = 30
        Me.UcPesaje1.TaraSeleccionada = 0R
        Me.UcPesaje1.Titulo = "Contenedor #1"
        Me.UcPesaje1.Visible = False
        '
        'ucTarjadoPesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcPesaje1)
        Me.Controls.Add(Me.btn)
        Me.Controls.Add(Me.lblBinesdisponibles)
        Me.Controls.Add(Me.dgvBinesDisponibles)
        Me.Controls.Add(Me.btnGuardarFolio)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnImprimirTickets)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDetallePalet)
        Me.Controls.Add(Me.btnAgregarLote)
        Me.Name = "ucTarjadoPesaje"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudCantidadCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetallePalet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBinesdisponibles As Label
    Friend WithEvents dgvBinesDisponibles As DataGridView
    Friend WithEvents btnGuardarFolio As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtKilosCaja As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents nudCantidadCajas As NumericUpDown
    Friend WithEvents cmbCajaContenedor As ComboBox
    Friend WithEvents cmbCalibre As ComboBox
    Friend WithEvents cmbVariedad As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents btnImprimirTickets As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbTipoOperacion As ComboBox
    Friend WithEvents txtNumeroFolio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents dgvDetallePalet As DataGridView
    Friend WithEvents btnAgregarLote As Button
    Friend WithEvents btn As Button
    Friend WithEvents UcPesaje1 As ucPesaje
End Class
