<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDespachoServicio
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Despacho = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTIpoOperacion = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.UcCrearOrdenDespachoServicio1 = New sistemaPackingv2.ucCrearOrdenDespachoServicio()
        Me.Despacho.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Despacho Bines"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(95, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo"
        '
        'Despacho
        '
        Me.Despacho.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.Despacho.Controls.Add(Me.TabPage1)
        Me.Despacho.Controls.Add(Me.TabPage2)
        Me.Despacho.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.Despacho.Location = New System.Drawing.Point(3, 17)
        Me.Despacho.Multiline = True
        Me.Despacho.Name = "Despacho"
        Me.Despacho.SelectedIndex = 0
        Me.Despacho.Size = New System.Drawing.Size(1280, 867)
        Me.Despacho.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Despacho.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbTIpoOperacion)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(25, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1251, 859)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bines"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(350, 446)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 70)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(171, 446)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 70)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(171, 342)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 30)
        Me.DateTimePicker1.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(171, 249)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(353, 39)
        Me.ComboBox1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(173, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nueva Guía"
        '
        'cmbTIpoOperacion
        '
        Me.cmbTIpoOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIpoOperacion.FormattingEnabled = True
        Me.cmbTIpoOperacion.Location = New System.Drawing.Point(171, 173)
        Me.cmbTIpoOperacion.Name = "cmbTIpoOperacion"
        Me.cmbTIpoOperacion.Size = New System.Drawing.Size(353, 39)
        Me.cmbTIpoOperacion.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.UcCrearOrdenDespachoServicio1)
        Me.TabPage2.Location = New System.Drawing.Point(25, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1251, 859)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'UcCrearOrdenDespachoServicio1
        '
        Me.UcCrearOrdenDespachoServicio1.Location = New System.Drawing.Point(0, 0)
        Me.UcCrearOrdenDespachoServicio1.Name = "UcCrearOrdenDespachoServicio1"
        Me.UcCrearOrdenDespachoServicio1.Size = New System.Drawing.Size(1245, 900)
        Me.UcCrearOrdenDespachoServicio1.TabIndex = 0
        '
        'ucDespachoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Despacho)
        Me.Name = "ucDespachoServicio"
        Me.Size = New System.Drawing.Size(1300, 900)
        Me.Despacho.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Despacho As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbTIpoOperacion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents UcCrearOrdenDespachoServicio1 As ucCrearOrdenDespachoServicio
End Class
