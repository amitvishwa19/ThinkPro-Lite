Imports Npgsql
Public Class ThinkPoll
    Public pollid As Integer = Nothing
    Public processid As Integer = Nothing


#Region "Form Startup Border"

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.OrangeRed, rect)
    End Sub

#End Region


    Private Sub ThinkPoll_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim x As Integer
        Dim y As Integer

        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop

        processid = My.Settings.ProjectID
        'Home.PollContainer()
        Home.PollView = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
       
        If cmdClose.Text = "Close" Then
            Home.PollView = False
            Me.Close()
        Else
            Dim mdate As String = Format(Now, "dd-MMM-yy")
            Dim conn As New pgConnect
            Dim value As String = mdate & "^" & cmdPollSubmit.Tag & "^" & My.Settings.UserID & "^" & Home.lblProjectID.Text & "^" & lblPollQues.Text & "^" & "No Response"
            conn.InsertRecord("think_poll_response", "date,poll_id,user_id,process_id,poll_question,poll_response", value)
            Home.PollView = False
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim msg As MsgBoxResult = MsgBox(lblPollQues.Text.Length)
        'MsgBox(lblPollQues.Text.Length)
    End Sub

    Private Sub cmdPollSubmit_Click(sender As Object, e As EventArgs) Handles cmdPollSubmit.Click
        Try
            Dim mdate As String = Format(Now, "dd-MMM-yy")
            Dim ans As String = Nothing

            If RadioButton1.Checked Then
                ans = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                ans = RadioButton2.Text
            ElseIf RadioButton3.Checked Then
                ans = RadioButton3.Text
            ElseIf RadioButton4.Checked Then
                ans = RadioButton4.Text
            Else
                Dim msg As MsgBoxResult = MsgBox("Please select a response before submitting", vbInformation, "Input missing")
                Exit Sub
            End If


            Dim conn As New pgConnect
            Dim value As String = mdate & "^" & cmdPollSubmit.Tag & "^" & My.Settings.UserID & "^" & Home.lblProjectID.Text & "^" & lblPollTitle.Text & "^" & lblPollQues.Text & "^" & ans
            conn.InsertRecord("think_poll_response", "date,poll_id,user_id,process_id,poll_title,poll_question,poll_response", value)
            'Dim msg2 As MsgBoxResult = MsgBox("Response submitted successfully", vbInformation, "Wow!")

            cmdPollSubmit.Enabled = False
            Call PollResults()
            'Home.PollView = False
            cmdClose.Text = "Close"

        Catch ex As IO.IOException
            '  Dim er As MsgBoxResult = MsgBox("Error Poll response" & vbNewLine & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub PollResults()

        Dim polldate As String = Format(Now, "dd-MMM-yy")
        Dim TotalCnt As Integer = Nothing
        Dim a As Integer = Nothing
        Dim b As Integer = Nothing
        Dim c As Integer = Nothing
        Dim d As Integer = Nothing


        Dim Conn As New pgConnect
        Dim value As String = polldate & "^" & cmdPollSubmit.Tag & "^" & processid
        Dim reader As NpgsqlDataReader = Conn.GetRecords("think_poll_response", "*", "date =@value1 AND poll_id =@value2 AND process_id=@value3", value)
        While reader.Read
            TotalCnt += 1
        End While

        Dim value1 As String = polldate & "^" & cmdPollSubmit.Tag & "^" & processid & "^" & RadioButton1.Text
        Conn.Connect()
        Dim reader1 As NpgsqlDataReader = Conn.GetRecords("think_poll_response", "*", "date =@value1 AND poll_id =@value2 AND process_id=@value3 AND poll_response =@value4", value1)
        While reader1.Read
            a += 1
        End While

        Dim value2 As String = polldate & "^" & cmdPollSubmit.Tag & "^" & processid & "^" & RadioButton2.Text
        Conn.Connect()
        Dim reader2 As NpgsqlDataReader = Conn.GetRecords("think_poll_response", "*", "date =@value1 AND poll_id =@value2 AND process_id=@value3 AND poll_response =@value4", value2)
        While reader2.Read
            b += 1
        End While

        Dim value3 As String = polldate & "^" & cmdPollSubmit.Tag & "^" & processid & "^" & RadioButton3.Text
        Conn.Connect()
        Dim reader3 As NpgsqlDataReader = Conn.GetRecords("think_poll_response", "*", "date =@value1 AND poll_id =@value2 AND process_id=@value3 AND poll_response =@value4", value3)
        While reader3.Read
            c += 1
        End While

        Dim value4 As String = polldate & "^" & cmdPollSubmit.Tag & "^" & processid & "^" & RadioButton4.Text
        Conn.Connect()
        Dim reader4 As NpgsqlDataReader = Conn.GetRecords("think_poll_response", "*", "date =@value1 AND poll_id =@value2 AND process_id=@value3 AND poll_response =@value4", value4)
        While reader4.Read
            d += 1
        End While

        Bar1.Visible = True
        Bar2.Visible = True
        Bar3.Visible = True
        Bar4.Visible = True

        BarLabel1.Visible = True
        BarLabel2.Visible = True
        BarLabel3.Visible = True
        BarLabel4.Visible = True

        Dim increment As Integer = 40

        Bar1.Minimum = 0
        Bar1.Maximum = 100
        Bar2.Minimum = 0
        Bar2.Maximum = 100
        Bar3.Minimum = 0
        Bar3.Maximum = 100
        Bar4.Minimum = 0
        Bar4.Maximum = 100


        Bar1.Value = a / TotalCnt * 100
        BarLabel1.Text = Format(a / TotalCnt * 100, "0") & "%"

        Bar2.Value = b / TotalCnt * 100
        BarLabel2.Text = Format(b / TotalCnt * 100, "0") & "%"

        Bar3.Value = c / TotalCnt * 100
        BarLabel3.Text = Format(c / TotalCnt * 100, "0") & "%"

        Bar4.Value = d / TotalCnt * 100
        BarLabel4.Text = Format(d / TotalCnt * 100, "0") & "%"


    End Sub

    Private Sub lblPollQues_Click(sender As Object, e As EventArgs) Handles lblPollQues.Click
        
    End Sub
End Class