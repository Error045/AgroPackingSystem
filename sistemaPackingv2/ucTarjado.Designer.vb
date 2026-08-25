<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucTarjado
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
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumeroFolio = New System.Windows.Forms.TextBox()
        Me.cmbTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.cmbVariedad = New System.Windows.Forms.ComboBox()
        Me.cmbCalibre = New System.Windows.Forms.ComboBox()
        Me.cmbCajaContenedor = New System.Windows.Forms.ComboBox()
        Me.nudCantidadCajas = New System.Windows.Forms.NumericUpDown()
        Me.btnAgregarLote = New System.Windows.Forms.Button()
        Me.dgvDetallePalet = New System.Windows.Forms.DataGridView()
        Me.btnImprimirTickets = New System.Windows.Forms.Button()
        Me.btnGuardarFolio = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecepcion = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbRecepcion = New System.Windows.Forms.ComboBox()
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPalet = New System.Windows.Forms.ComboBox()
        Me.txtKilosCaja = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBinesDisponibles = New System.Windows.Forms.DataGridView()
        Me.lblBinesdisponibles = New System.Windows.Forms.Label()
        Me.btnUpdateBines = New System.Windows.Forms.Button()
        CType(Me.nudCantidadCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetallePalet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(128, 47)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(72, 25)
        Me.lblFolio.TabIndex = 0
        Me.lblFolio.Text = "FOLIO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TIPO OPERACION"
        '
        'txtNumeroFolio
        '
        Me.txtNumeroFolio.Location = New System.Drawing.Point(227, 42)
        Me.txtNumeroFolio.Name = "txtNumeroFolio"
        Me.txtNumeroFolio.ReadOnly = True
        Me.txtNumeroFolio.Size = New System.Drawing.Size(194, 30)
        Me.txtNumeroFolio.TabIndex = 2
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(227, 87)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(194, 33)
        Me.cmbTipoOperacion.TabIndex = 3
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(208, 43)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(134, 33)
        Me.cmbProducto.TabIndex = 5
        '
        'cmbVariedad
        '
        Me.cmbVariedad.FormattingEnabled = True
        Me.cmbVariedad.Location = New System.Drawing.Point(208, 86)
        Me.cmbVariedad.Name = "cmbVariedad"
        Me.cmbVariedad.Size = New System.Drawing.Size(134, 33)
        Me.cmbVariedad.TabIndex = 6
        '
        'cmbCalibre
        '
        Me.cmbCalibre.FormattingEnabled = True
        Me.cmbCalibre.Location = New System.Drawing.Point(208, 126)
        Me.cmbCalibre.Name = "cmbCalibre"
        Me.cmbCalibre.Size = New System.Drawing.Size(134, 33)
        Me.cmbCalibre.TabIndex = 7
        '
        'cmbCajaContenedor
        '
        Me.cmbCajaContenedor.FormattingEnabled = True
        Me.cmbCajaContenedor.Location = New System.Drawing.Point(558, 68)
        Me.cmbCajaContenedor.Name = "cmbCajaContenedor"
        Me.cmbCajaContenedor.Size = New System.Drawing.Size(193, 33)
        Me.cmbCajaContenedor.TabIndex = 8
        '
        'nudCantidadCajas
        '
        Me.nudCantidadCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCantidadCajas.Location = New System.Drawing.Point(558, 122)
        Me.nudCantidadCajas.Name = "nudCantidadCajas"
        Me.nudCantidadCajas.Size = New System.Drawing.Size(121, 45)
        Me.nudCantidadCajas.TabIndex = 9
        '
        'btnAgregarLote
        '
        Me.btnAgregarLote.Location = New System.Drawing.Point(99, 486)
        Me.btnAgregarLote.Name = "btnAgregarLote"
        Me.btnAgregarLote.Size = New System.Drawing.Size(147, 37)
        Me.btnAgregarLote.TabIndex = 11
        Me.btnAgregarLote.Text = "Agregar al Palet"
        Me.btnAgregarLote.UseVisualStyleBackColor = True
        '
        'dgvDetallePalet
        '
        Me.dgvDetallePalet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetallePalet.Location = New System.Drawing.Point(18, 570)
        Me.dgvDetallePalet.Name = "dgvDetallePalet"
        Me.dgvDetallePalet.RowHeadersWidth = 51
        Me.dgvDetallePalet.RowTemplate.Height = 24
        Me.dgvDetallePalet.Size = New System.Drawing.Size(1141, 120)
        Me.dgvDetallePalet.TabIndex = 12
        '
        'btnImprimirTickets
        '
        Me.btnImprimirTickets.Location = New System.Drawing.Point(288, 486)
        Me.btnImprimirTickets.Name = "btnImprimirTickets"
        Me.btnImprimirTickets.Size = New System.Drawing.Size(120, 51)
        Me.btnImprimirTickets.TabIndex = 14
        Me.btnImprimirTickets.Text = "Imprimir Etiquetas"
        Me.btnImprimirTickets.UseVisualStyleBackColor = True
        '
        'btnGuardarFolio
        '
        Me.btnGuardarFolio.Location = New System.Drawing.Point(445, 486)
        Me.btnGuardarFolio.Name = "btnGuardarFolio"
        Me.btnGuardarFolio.Size = New System.Drawing.Size(123, 49)
        Me.btnGuardarFolio.TabIndex = 15
        Me.btnGuardarFolio.Text = "Cerrar Palet/ Guardar"
        Me.btnGuardarFolio.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRecepcion)
        Me.GroupBox1.Controls.Add(Me.lblPersona)
        Me.GroupBox1.Controls.Add(Me.cmbRecepcion)
        Me.GroupBox1.Controls.Add(Me.cmbPersona)
        Me.GroupBox1.Controls.Add(Me.cmbTipoOperacion)
        Me.GroupBox1.Controls.Add(Me.txtNumeroFolio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblFolio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(58, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 213)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Folio"
        '
        'lblRecepcion
        '
        Me.lblRecepcion.AutoSize = True
        Me.lblRecepcion.Location = New System.Drawing.Point(73, 165)
        Me.lblRecepcion.Name = "lblRecepcion"
        Me.lblRecepcion.Size = New System.Drawing.Size(129, 25)
        Me.lblRecepcion.TabIndex = 7
        Me.lblRecepcion.Text = "RECEPCION"
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Location = New System.Drawing.Point(106, 129)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(96, 25)
        Me.lblPersona.TabIndex = 6
        Me.lblPersona.Text = "CLIENTE"
        '
        'cmbRecepcion
        '
        Me.cmbRecepcion.FormattingEnabled = True
        Me.cmbRecepcion.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbRecepcion.Location = New System.Drawing.Point(227, 165)
        Me.cmbRecepcion.Name = "cmbRecepcion"
        Me.cmbRecepcion.Size = New System.Drawing.Size(194, 33)
        Me.cmbRecepcion.TabIndex = 5
        '
        'cmbPersona
        '
        Me.cmbPersona.FormattingEnabled = True
        Me.cmbPersona.Items.AddRange(New Object() {"PROPIO", "SERVICIO"})
        Me.cmbPersona.Location = New System.Drawing.Point(227, 126)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(194, 33)
        Me.cmbPersona.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbPalet)
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
        Me.GroupBox2.Location = New System.Drawing.Point(58, 237)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(836, 243)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Armar  Cajas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(426, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 25)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Tipo Pallet"
        '
        'cmbPalet
        '
        Me.cmbPalet.FormattingEnabled = True
        Me.cmbPalet.Location = New System.Drawing.Point(558, 29)
        Me.cmbPalet.Name = "cmbPalet"
        Me.cmbPalet.Size = New System.Drawing.Size(193, 33)
        Me.cmbPalet.TabIndex = 17
        '
        'txtKilosCaja
        '
        Me.txtKilosCaja.Location = New System.Drawing.Point(561, 193)
        Me.txtKilosCaja.Name = "txtKilosCaja"
        Me.txtKilosCaja.Size = New System.Drawing.Size(85, 30)
        Me.txtKilosCaja.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(434, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 25)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Nro Cajas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(434, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 25)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Capacidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(421, 71)
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
        'dgvBinesDisponibles
        '
        Me.dgvBinesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBinesDisponibles.Location = New System.Drawing.Point(3, 746)
        Me.dgvBinesDisponibles.Name = "dgvBinesDisponibles"
        Me.dgvBinesDisponibles.RowHeadersWidth = 51
        Me.dgvBinesDisponibles.RowTemplate.Height = 24
        Me.dgvBinesDisponibles.Size = New System.Drawing.Size(1141, 132)
        Me.dgvBinesDisponibles.TabIndex = 18
        '
        'lblBinesdisponibles
        '
        Me.lblBinesdisponibles.AutoSize = True
        Me.lblBinesdisponibles.Location = New System.Drawing.Point(96, 713)
        Me.lblBinesdisponibles.Name = "lblBinesdisponibles"
        Me.lblBinesdisponibles.Size = New System.Drawing.Size(79, 16)
        Me.lblBinesdisponibles.TabIndex = 19
        Me.lblBinesdisponibles.Text = "Disponibles"
        '
        'btnUpdateBines
        '
        Me.btnUpdateBines.Location = New System.Drawing.Point(587, 486)
        Me.btnUpdateBines.Name = "btnUpdateBines"
        Me.btnUpdateBines.Size = New System.Drawing.Size(147, 49)
        Me.btnUpdateBines.TabIndex = 20
        Me.btnUpdateBines.Text = "Actualizar Bines"
        Me.btnUpdateBines.UseVisualStyleBackColor = True
        '
        'ucTarjado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnUpdateBines)
        Me.Controls.Add(Me.lblBinesdisponibles)
        Me.Controls.Add(Me.dgvBinesDisponibles)
        Me.Controls.Add(Me.btnGuardarFolio)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnImprimirTickets)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDetallePalet)
        Me.Controls.Add(Me.btnAgregarLote)
        Me.Name = "ucTarjado"
        Me.Size = New System.Drawing.Size(1200, 900)
        CType(Me.nudCantidadCajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetallePalet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvBinesDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFolio As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNumeroFolio As TextBox
    Friend WithEvents cmbTipoOperacion As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents cmbVariedad As ComboBox
    Friend WithEvents cmbCalibre As ComboBox
    Friend WithEvents cmbCajaContenedor As ComboBox
    Friend WithEvents nudCantidadCajas As NumericUpDown
    Friend WithEvents btnAgregarLote As Button
    Friend WithEvents dgvDetallePalet As DataGridView
    Friend WithEvents btnImprimirTickets As Button
    Friend WithEvents btnGuardarFolio As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtKilosCaja As TextBox
    Friend WithEvents dgvBinesDisponibles As DataGridView
    Friend WithEvents lblBinesdisponibles As Label
    Friend WithEvents btnUpdateBines As Button
    Friend WithEvents lblRecepcion As Label
    Friend WithEvents lblPersona As Label
    Friend WithEvents cmbRecepcion As ComboBox
    Friend WithEvents cmbPersona As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbPalet As ComboBox
End Class
