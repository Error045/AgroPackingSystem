<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdenDespachoRepesajeValidacion
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
        Me.btnProcederPesajeOrden = New System.Windows.Forms.Button()
        Me.dgvDisponiblesOrden = New System.Windows.Forms.DataGridView()
        Me.dgvContenedoresOrden = New System.Windows.Forms.DataGridView()
        Me.txtBusquedaOrden = New System.Windows.Forms.TextBox()
        CType(Me.dgvDisponiblesOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContenedoresOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(345, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(335, 32)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "VALIDA ORDEN PALLET"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 32)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Número Pallet"
        '
        'btnProcederPesajeOrden
        '
        Me.btnProcederPesajeOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcederPesajeOrden.Location = New System.Drawing.Point(351, 628)
        Me.btnProcederPesajeOrden.Name = "btnProcederPesajeOrden"
        Me.btnProcederPesajeOrden.Size = New System.Drawing.Size(315, 94)
        Me.btnProcederPesajeOrden.TabIndex = 9
        Me.btnProcederPesajeOrden.Text = "Pesar"
        Me.btnProcederPesajeOrden.UseVisualStyleBackColor = True
        '
        'dgvDisponiblesOrden
        '
        Me.dgvDisponiblesOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDisponiblesOrden.Location = New System.Drawing.Point(137, 326)
        Me.dgvDisponiblesOrden.Name = "dgvDisponiblesOrden"
        Me.dgvDisponiblesOrden.RowHeadersWidth = 51
        Me.dgvDisponiblesOrden.RowTemplate.Height = 24
        Me.dgvDisponiblesOrden.Size = New System.Drawing.Size(832, 279)
        Me.dgvDisponiblesOrden.TabIndex = 8
        '
        'dgvContenedoresOrden
        '
        Me.dgvContenedoresOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContenedoresOrden.Location = New System.Drawing.Point(137, 204)
        Me.dgvContenedoresOrden.Name = "dgvContenedoresOrden"
        Me.dgvContenedoresOrden.RowHeadersWidth = 51
        Me.dgvContenedoresOrden.RowTemplate.Height = 24
        Me.dgvContenedoresOrden.Size = New System.Drawing.Size(832, 105)
        Me.dgvContenedoresOrden.TabIndex = 7
        '
        'txtBusquedaOrden
        '
        Me.txtBusquedaOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaOrden.Location = New System.Drawing.Point(330, 109)
        Me.txtBusquedaOrden.Name = "txtBusquedaOrden"
        Me.txtBusquedaOrden.Size = New System.Drawing.Size(370, 38)
        Me.txtBusquedaOrden.TabIndex = 6
        '
        'ucOrdenDespachoRepesajeValidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnProcederPesajeOrden)
        Me.Controls.Add(Me.dgvDisponiblesOrden)
        Me.Controls.Add(Me.dgvContenedoresOrden)
        Me.Controls.Add(Me.txtBusquedaOrden)
        Me.Name = "ucOrdenDespachoRepesajeValidacion"
        Me.Size = New System.Drawing.Size(1100, 800)
        CType(Me.dgvDisponiblesOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContenedoresOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnProcederPesajeOrden As Button
    Friend WithEvents dgvDisponiblesOrden As DataGridView
    Friend WithEvents dgvContenedoresOrden As DataGridView
    Friend WithEvents txtBusquedaOrden As TextBox
End Class
