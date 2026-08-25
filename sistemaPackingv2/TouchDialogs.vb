Imports System.Drawing
Imports System.Windows.Forms

Module TouchDialogs
    ' Enumeración para facilitar el uso de iconos
    Public Enum TouchIcon
        Informacion
        Advertencia
        ErrorCritico
        Pregunta
        Ninguno
    End Enum

    Public Function MsgBoxTouch(mensaje As String,
                               Optional titulo As String = "Aviso",
                               Optional soloOk As Boolean = True,
                               Optional icono As TouchIcon = TouchIcon.Informacion) As DialogResult

        Dim frm As New Form With {
            .Text = titulo,
            .Size = New Size(600, 250),
            .StartPosition = FormStartPosition.CenterScreen,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MaximizeBox = False, .MinimizeBox = False,
            .TopMost = True, .BackColor = Color.White
        }

        ' Contenedor horizontal para Icono + Texto
        Dim pnlContenido As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 1,
            .Padding = New Padding(20)
        }
        pnlContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 80)) ' Espacio icono
        pnlContenido.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100)) ' Espacio texto

        ' PictureBox para el Icono de Sistema
        Dim picIcono As New PictureBox With {
            .Size = New Size(44, 44),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Anchor = AnchorStyles.None
        }

        ' Asignar icono del sistema según la elección
        Select Case icono
            Case TouchIcon.Informacion : picIcono.Image = SystemIcons.Information.ToBitmap()
            Case TouchIcon.Advertencia : picIcono.Image = SystemIcons.Warning.ToBitmap()
            Case TouchIcon.ErrorCritico : picIcono.Image = SystemIcons.Error.ToBitmap()
            Case TouchIcon.Pregunta : picIcono.Image = SystemIcons.Question.ToBitmap()
            Case Else : picIcono.Visible = False
        End Select

        Dim lbl As New Label With {
            .Text = mensaje,
            .Font = New Font("Segoe UI", 13),
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleLeft
        }

        ' Panel de botones (Igual al anterior, optimizado touch)
        Dim pnlBotones As New Panel With {.Dock = DockStyle.Bottom, .Height = 100}
        Dim btnOk As New Button With {
            .Text = "ACEPTAR", .Size = New Size(180, 70), .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 12, FontStyle.Bold)
        }

        AddHandler btnOk.Click, Sub()
                                    frm.DialogResult = DialogResult.OK
                                    frm.Close()
                                End Sub

        If soloOk Then
            ' Centrar el botón OK si es el único
            btnOk.Location = New Point((frm.Width - btnOk.Width) \ 2 - 10, 10)
            pnlBotones.Controls.Add(btnOk)
        Else
            ' Configurar botón CANCELAR
            Dim btnCancel As New Button With {
                .Text = "CANCELAR",
                .Size = New Size(180, 70),
                .BackColor = Color.IndianRed,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .Location = New Point(280, 10) ' Cambiado de 'End Point' a 'New Point'
            }

            ' Posición del botón OK cuando hay dos botones
            btnOk.Location = New Point(50, 10)

            AddHandler btnCancel.Click, Sub()
                                            frm.DialogResult = DialogResult.Cancel
                                            frm.Close()
                                        End Sub

            pnlBotones.Controls.Add(btnOk)
            pnlBotones.Controls.Add(btnCancel)
        End If

        pnlContenido.Controls.Add(picIcono, 0, 0)
        pnlContenido.Controls.Add(lbl, 1, 0)
        frm.Controls.Add(pnlContenido)
        frm.Controls.Add(pnlBotones)

        Return frm.ShowDialog()
    End Function
End Module