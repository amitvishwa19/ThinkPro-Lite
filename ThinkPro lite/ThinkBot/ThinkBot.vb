Public Class ThinkBot

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.OrangeRed, rect)
    End Sub

    Private Sub ThinkBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      

        Dim x As Integer
        Dim y As Integer

        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop



    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtInput_GotFocus(sender As Object, e As EventArgs) Handles txtInput.GotFocus
        txtInput.Text = Nothing
    End Sub

    Dim lTop As Integer = 40
    Dim lLeft As Integer = 10
    Dim i As Integer = 1

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ''Dim InpStr As String = txtInput.Text
            ''Dim ResStr As String = 'txtResponse.Text
            ' ''txtResponse.Text = ResStr & vbNewLine & "Me : " & InpStr
            ''txtInput.Text = Nothing

            Dim InpLbl As New Label
            InpLbl.Name = "input" & i
            InpLbl.Text = Trim(txtInput.Text)
            InpLbl.Location = New Point(lLeft, lTop)
            InpLbl.BackColor = Color.FromArgb(0, 164, 147)
            InpLbl.ForeColor = Color.White
            'InpLbl.Height = 40
            InpLbl.Enabled = False

            'InpLbl.Width = 100
            'InpLbl.TextAlign = ContentAlignment.MiddleLeft
            InpLbl.AutoSize = False
            'InpLbl.Margin = New Padding(10, 10, 10, 10)

            i = i + 1
            lTop = lTop + 20

            pnlDisplay.Controls.Add(InpLbl)

            Call BotResponse(Trim(txtInput.Text))

            txtInput.Text = Nothing


        End If
    End Sub


    Sub BotResponse(Response As String)
        Dim InpLbl As New Label
        InpLbl.Name = "output" & i
        InpLbl.Text = Response
        InpLbl.Location = New Point(lLeft + 150, lTop)
        InpLbl.BackColor = Color.LawnGreen
        InpLbl.ForeColor = Color.White
        'InpLbl.Height = 40
        InpLbl.Enabled = False

        'InpLbl.Width = 100
        'InpLbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        InpLbl.AutoSize = False
        'InpLbl.Margin = New Padding(10, 10, 10, 10)
        InpLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes


        i = i + 1
        lTop = lTop + 20

        pnlDisplay.Controls.Add(InpLbl)
        txtInput.Text = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class