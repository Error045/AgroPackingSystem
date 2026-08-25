<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRecepcionEstado
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
        Me.lblNumRecepcion = New System.Windows.Forms.Label()
        Me.cmbRecepcionEstado = New System.Windows.Forms.ComboBox()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblIdRecepcion = New System.Windows.Forms.Label()
        Me.lbTituloRecepcion = New System.Windows.Forms.Label()
        Me.btnTerminarRecepcion = New System.Windows.Forms.Button()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblTipoRecepcion = New System.Windows.Forms.Label()
        Me.lblTituloTipoRecepcion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNumRecepcion
        '
        Me.lblNumRecepcion.AutoSize = True
        Me.lblNumRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRecepcion.Location = New System.Drawing.Point(124, 174)
        Me.lblNumRecepcion.Name = "lblNumRecepcion"
        Me.lblNumRecepcion.Size = New System.Drawing.Size(120, 36)
        Me.lblNumRecepcion.TabIndex = 0
        Me.lblNumRecepcion.Text = "Nombre"
        '
        'cmbRecepcionEstado
        '
        Me.cmbRecepcionEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRecepcionEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRecepcionEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecepcionEstado.FormattingEnabled = True
        Me.cmbRecepcionEstado.ItemHeight = 40
        Me.cmbRecepcionEstado.Location = New System.Drawing.Point(292, 174)
        Me.cmbRecepcionEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbRecepcionEstado.MaxDropDownItems = 6
        Me.cmbRecepcionEstado.Name = "cmbRecepcionEstado"
        Me.cmbRecepcionEstado.Size = New System.Drawing.Size(348, 46)
        Me.cmbRecepcionEstado.TabIndex = 1
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Location = New System.Drawing.Point(427, 380)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(179, 73)
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(209, 380)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(179, 73)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(124, 265)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(199, 36)
        Me.lblCodigo.TabIndex = 4
        Me.lblCodigo.Text = "N° Recepción"
        '
        'lblIdRecepcion
        '
        Me.lblIdRecepcion.AutoSize = True
        Me.lblIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRecepcion.Location = New System.Drawing.Point(385, 265)
        Me.lblIdRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdRecepcion.Name = "lblIdRecepcion"
        Me.lblIdRecepcion.Size = New System.Drawing.Size(120, 36)
        Me.lblIdRecepcion.TabIndex = 5
        Me.lblIdRecepcion.Text = "Número"
        '
        'lbTituloRecepcion
        '
        Me.lbTituloRecepcion.AutoSize = True
        Me.lbTituloRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloRecepcion.Location = New System.Drawing.Point(285, 52)
        Me.lbTituloRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTituloRecepcion.Name = "lbTituloRecepcion"
        Me.lbTituloRecepcion.Size = New System.Drawing.Size(342, 42)
        Me.lbTituloRecepcion.TabIndex = 6
        Me.lbTituloRecepcion.Text = "Ingresar Recepción"
        '
        'btnTerminarRecepcion
        '
        Me.btnTerminarRecepcion.BackColor = System.Drawing.Color.Red
        Me.btnTerminarRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminarRecepcion.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnTerminarRecepcion.Location = New System.Drawing.Point(325, 499)
        Me.btnTerminarRecepcion.Name = "btnTerminarRecepcion"
        Me.btnTerminarRecepcion.Size = New System.Drawing.Size(188, 94)
        Me.btnTerminarRecepcion.TabIndex = 12
        Me.btnTerminarRecepcion.Text = "TERMINAR RECEPCIÓN"
        Me.btnTerminarRecepcion.UseVisualStyleBackColor = False
        '
        'btnVer
        '
        Me.btnVer.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVer.Location = New System.Drawing.Point(697, 174)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(78, 58)
        Me.btnVer.TabIndex = 13
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.Color.Black
        Me.btnEditar.Location = New System.Drawing.Point(794, 174)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 58)
        Me.btnEditar.TabIndex = 14
        Me.btnEditar.Text = "Edit"
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Tomato
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Location = New System.Drawing.Point(892, 174)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(78, 58)
        Me.btnEliminar.TabIndex = 15
        Me.btnEliminar.Text = "Eli"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'lblTipoRecepcion
        '
        Me.lblTipoRecepcion.AutoSize = True
        Me.lblTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoRecepcion.Location = New System.Drawing.Point(385, 322)
        Me.lblTipoRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoRecepcion.Name = "lblTipoRecepcion"
        Me.lblTipoRecepcion.Size = New System.Drawing.Size(74, 36)
        Me.lblTipoRecepcion.TabIndex = 17
        Me.lblTipoRecepcion.Text = "Tipo"
        '
        'lblTituloTipoRecepcion
        '
        Me.lblTituloTipoRecepcion.AutoSize = True
        Me.lblTituloTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloTipoRecepcion.Location = New System.Drawing.Point(124, 322)
        Me.lblTituloTipoRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTituloTipoRecepcion.Name = "lblTituloTipoRecepcion"
        Me.lblTituloTipoRecepcion.Size = New System.Drawing.Size(82, 36)
        Me.lblTituloTipoRecepcion.TabIndex = 16
        Me.lblTituloTipoRecepcion.Text = "Tipo "
        '
        'ucRecepcionEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Controls.Add(Me.lblTipoRecepcion)
        Me.Controls.Add(Me.lblTituloTipoRecepcion)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.btnTerminarRecepcion)
        Me.Controls.Add(Me.lbTituloRecepcion)
        Me.Controls.Add(Me.lblIdRecepcion)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.cmbRecepcionEstado)
        Me.Controls.Add(Me.lblNumRecepcion)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucRecepcionEstado"
        Me.Size = New System.Drawing.Size(1013, 824)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNumRecepcion As Label
	Friend WithEvents cmbRecepcionEstado As ComboBox
	Friend WithEvents btnSiguiente As Button
	Friend WithEvents btnCancelar As Button
	Friend WithEvents lblCodigo As Label
	Friend WithEvents lblIdRecepcion As Label
	Friend WithEvents lbTituloRecepcion As Label
	Friend WithEvents btnTerminarRecepcion As Button
	Friend WithEvents btnVer As Button
	Friend WithEvents btnEditar As Button
	Friend WithEvents btnEliminar As Button
	Friend WithEvents lblTipoRecepcion As Label
	Friend WithEvents lblTituloTipoRecepcion As Label
End Class
