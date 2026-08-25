<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdenRepesajeValidacion
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
        Me.txtBusquedaOrden = New System.Windows.Forms.TextBox()
        Me.dgvContenedoresOrden = New System.Windows.Forms.DataGridView()
        Me.dgvDisponiblesOrden = New System.Windows.Forms.DataGridView()
        Me.btnProcederPesajeOrden = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvContenedoresOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDisponiblesOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBusquedaOrden
        '
        Me.txtBusquedaOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaOrden.Location = New System.Drawing.Point(280, 77)
        Me.txtBusquedaOrden.Name = "txtBusquedaOrden"
        Me.txtBusquedaOrden.Size = New System.Drawing.Size(370, 38)
        Me.txtBusquedaOrden.TabIndex = 0
        '
        'dgvContenedoresOrden
        '
        Me.dgvContenedoresOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContenedoresOrden.Location = New System.Drawing.Point(87, 172)
        Me.dgvContenedoresOrden.Name = "dgvContenedoresOrden"
        Me.dgvContenedoresOrden.RowHeadersWidth = 51
        Me.dgvContenedoresOrden.RowTemplate.Height = 24
        Me.dgvContenedoresOrden.Size = New System.Drawing.Size(832, 105)
        Me.dgvContenedoresOrden.TabIndex = 1
        '
        'dgvDisponiblesOrden
        '
        Me.dgvDisponiblesOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDisponiblesOrden.Location = New System.Drawing.Point(22, 294)
        Me.dgvDisponiblesOrden.Name = "dgvDisponiblesOrden"
        Me.dgvDisponiblesOrden.RowHeadersWidth = 51
        Me.dgvDisponiblesOrden.RowTemplate.Height = 24
        Me.dgvDisponiblesOrden.Size = New System.Drawing.Size(910, 279)
        Me.dgvDisponiblesOrden.TabIndex = 2
        '
        'btnProcederPesajeOrden
        '
        Me.btnProcederPesajeOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcederPesajeOrden.Location = New System.Drawing.Point(301, 596)
        Me.btnProcederPesajeOrden.Name = "btnProcederPesajeOrden"
        Me.btnProcederPesajeOrden.Size = New System.Drawing.Size(315, 94)
        Me.btnProcederPesajeOrden.TabIndex = 3
        Me.btnProcederPesajeOrden.Text = "Pesar"
        Me.btnProcederPesajeOrden.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Número Bins"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(295, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(313, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "VALIDA ORDEN BINES"
        '
        'ucOrdenRepesajeValidacion
        '
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnProcederPesajeOrden)
        Me.Controls.Add(Me.dgvDisponiblesOrden)
        Me.Controls.Add(Me.dgvContenedoresOrden)
        Me.Controls.Add(Me.txtBusquedaOrden)
        Me.Name = "ucOrdenRepesajeValidacion"
        Me.Size = New System.Drawing.Size(950, 800)
        CType(Me.dgvContenedoresOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDisponiblesOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDisponibles As DataGridView
    Friend WithEvents dgvContenedores As DataGridView
    Friend WithEvents btnProcederPesaje As Button
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents lblContenedor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBusquedaOrden As TextBox
    Friend WithEvents dgvContenedoresOrden As DataGridView
    Friend WithEvents dgvDisponiblesOrden As DataGridView
    Friend WithEvents btnProcederPesajeOrden As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
