<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucValidacionPalletDespacho
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDisponibles = New System.Windows.Forms.DataGridView()
        Me.dgvContenedores = New System.Windows.Forms.DataGridView()
        Me.btnProcederPesaje = New System.Windows.Forms.Button()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.lblContenedor = New System.Windows.Forms.Label()
        CType(Me.dgvDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 29)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "VALIDAR PALLET DESPACHO"
        '
        'dgvDisponibles
        '
        Me.dgvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDisponibles.Location = New System.Drawing.Point(37, 437)
        Me.dgvDisponibles.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDisponibles.Name = "dgvDisponibles"
        Me.dgvDisponibles.RowHeadersWidth = 51
        Me.dgvDisponibles.RowTemplate.Height = 24
        Me.dgvDisponibles.Size = New System.Drawing.Size(1033, 187)
        Me.dgvDisponibles.TabIndex = 16
        '
        'dgvContenedores
        '
        Me.dgvContenedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContenedores.Location = New System.Drawing.Point(37, 189)
        Me.dgvContenedores.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvContenedores.Name = "dgvContenedores"
        Me.dgvContenedores.RowHeadersWidth = 51
        Me.dgvContenedores.RowTemplate.Height = 24
        Me.dgvContenedores.Size = New System.Drawing.Size(1033, 187)
        Me.dgvContenedores.TabIndex = 15
        '
        'btnProcederPesaje
        '
        Me.btnProcederPesaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcederPesaje.Location = New System.Drawing.Point(460, 653)
        Me.btnProcederPesaje.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcederPesaje.Name = "btnProcederPesaje"
        Me.btnProcederPesaje.Size = New System.Drawing.Size(207, 118)
        Me.btnProcederPesaje.TabIndex = 14
        Me.btnProcederPesaje.Text = "Pesaje"
        Me.btnProcederPesaje.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(192, 93)
        Me.txtBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(341, 38)
        Me.txtBusqueda.TabIndex = 13
        '
        'lblContenedor
        '
        Me.lblContenedor.AutoSize = True
        Me.lblContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContenedor.Location = New System.Drawing.Point(32, 102)
        Me.lblContenedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContenedor.Name = "lblContenedor"
        Me.lblContenedor.Size = New System.Drawing.Size(114, 25)
        Me.lblContenedor.TabIndex = 12
        Me.lblContenedor.Text = "N° PALLET"
        '
        'ucValidacionPalletDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDisponibles)
        Me.Controls.Add(Me.dgvContenedores)
        Me.Controls.Add(Me.btnProcederPesaje)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.lblContenedor)
        Me.Name = "ucValidacionPalletDespacho"
        Me.Size = New System.Drawing.Size(1100, 800)
        CType(Me.dgvDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContenedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDisponibles As DataGridView
    Friend WithEvents dgvContenedores As DataGridView
    Friend WithEvents btnProcederPesaje As Button
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents lblContenedor As Label
End Class
