<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRecepcionEstadoBloque
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
        Me.lblTipoRecepcion = New System.Windows.Forms.Label()
        Me.lblTituloTipoRecepcion = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnTerminarRecepcion = New System.Windows.Forms.Button()
        Me.lbTituloRecepcion = New System.Windows.Forms.Label()
        Me.lblIdRecepcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.cmbRecepcionEstado = New System.Windows.Forms.ComboBox()
        Me.lblNumRecepcion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTipoRecepcion
        '
        Me.lblTipoRecepcion.AutoSize = True
        Me.lblTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoRecepcion.Location = New System.Drawing.Point(299, 298)
        Me.lblTipoRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoRecepcion.Name = "lblTipoRecepcion"
        Me.lblTipoRecepcion.Size = New System.Drawing.Size(74, 36)
        Me.lblTipoRecepcion.TabIndex = 30
        Me.lblTipoRecepcion.Text = "Tipo"
        '
        'lblTituloTipoRecepcion
        '
        Me.lblTituloTipoRecepcion.AutoSize = True
        Me.lblTituloTipoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloTipoRecepcion.Location = New System.Drawing.Point(38, 298)
        Me.lblTituloTipoRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTituloTipoRecepcion.Name = "lblTituloTipoRecepcion"
        Me.lblTituloTipoRecepcion.Size = New System.Drawing.Size(82, 36)
        Me.lblTituloTipoRecepcion.TabIndex = 29
        Me.lblTituloTipoRecepcion.Text = "Tipo "
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Tomato
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Location = New System.Drawing.Point(806, 150)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(78, 58)
        Me.btnEliminar.TabIndex = 28
        Me.btnEliminar.Text = "Eli"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.Color.Black
        Me.btnEditar.Location = New System.Drawing.Point(708, 150)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 58)
        Me.btnEditar.TabIndex = 27
        Me.btnEditar.Text = "Edit"
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnVer
        '
        Me.btnVer.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVer.Location = New System.Drawing.Point(611, 150)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(78, 58)
        Me.btnVer.TabIndex = 26
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'btnTerminarRecepcion
        '
        Me.btnTerminarRecepcion.BackColor = System.Drawing.Color.Red
        Me.btnTerminarRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminarRecepcion.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnTerminarRecepcion.Location = New System.Drawing.Point(239, 475)
        Me.btnTerminarRecepcion.Name = "btnTerminarRecepcion"
        Me.btnTerminarRecepcion.Size = New System.Drawing.Size(188, 94)
        Me.btnTerminarRecepcion.TabIndex = 25
        Me.btnTerminarRecepcion.Text = "TERMINAR RECEPCIÓN"
        Me.btnTerminarRecepcion.UseVisualStyleBackColor = False
        '
        'lbTituloRecepcion
        '
        Me.lbTituloRecepcion.AutoSize = True
        Me.lbTituloRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloRecepcion.Location = New System.Drawing.Point(199, 28)
        Me.lbTituloRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTituloRecepcion.Name = "lbTituloRecepcion"
        Me.lbTituloRecepcion.Size = New System.Drawing.Size(521, 42)
        Me.lbTituloRecepcion.TabIndex = 24
        Me.lbTituloRecepcion.Text = "Ingresar Recepción en Bloque"
        '
        'lblIdRecepcion
        '
        Me.lblIdRecepcion.AutoSize = True
        Me.lblIdRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRecepcion.Location = New System.Drawing.Point(299, 241)
        Me.lblIdRecepcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdRecepcion.Name = "lblIdRecepcion"
        Me.lblIdRecepcion.Size = New System.Drawing.Size(120, 36)
        Me.lblIdRecepcion.TabIndex = 23
        Me.lblIdRecepcion.Text = "Número"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(38, 241)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(199, 36)
        Me.lblCodigo.TabIndex = 22
        Me.lblCodigo.Text = "N° Recepción"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(123, 356)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(179, 73)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Location = New System.Drawing.Point(341, 356)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(179, 73)
        Me.btnSiguiente.TabIndex = 20
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'cmbRecepcionEstado
        '
        Me.cmbRecepcionEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRecepcionEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRecepcionEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecepcionEstado.FormattingEnabled = True
        Me.cmbRecepcionEstado.ItemHeight = 40
        Me.cmbRecepcionEstado.Location = New System.Drawing.Point(206, 150)
        Me.cmbRecepcionEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbRecepcionEstado.MaxDropDownItems = 6
        Me.cmbRecepcionEstado.Name = "cmbRecepcionEstado"
        Me.cmbRecepcionEstado.Size = New System.Drawing.Size(348, 46)
        Me.cmbRecepcionEstado.TabIndex = 19
        '
        'lblNumRecepcion
        '
        Me.lblNumRecepcion.AutoSize = True
        Me.lblNumRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRecepcion.Location = New System.Drawing.Point(38, 150)
        Me.lblNumRecepcion.Name = "lblNumRecepcion"
        Me.lblNumRecepcion.Size = New System.Drawing.Size(120, 36)
        Me.lblNumRecepcion.TabIndex = 18
        Me.lblNumRecepcion.Text = "Nombre"
        '
        'ucRecepcionEstadoBloque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.Name = "ucRecepcionEstadoBloque"
        Me.Size = New System.Drawing.Size(1200, 900)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTipoRecepcion As Label
    Friend WithEvents lblTituloTipoRecepcion As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnVer As Button
    Friend WithEvents btnTerminarRecepcion As Button
    Friend WithEvents lbTituloRecepcion As Label
    Friend WithEvents lblIdRecepcion As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents cmbRecepcionEstado As ComboBox
    Friend WithEvents lblNumRecepcion As Label
End Class
