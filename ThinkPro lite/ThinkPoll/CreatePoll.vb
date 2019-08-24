Public Class CreatePoll
    Dim PollTarget As String = Nothing
    Dim PollDate As String = Nothing
    Dim ProjectID As Integer = Nothing
    Public PollCreateFrom As String = Nothing

    Private Sub CreatePoll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProjectID = ThinkManagement.ProjectID
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtPollTitle.TextChanged
        If txtPollTitle.Text.Length > 20 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll title should be 20 word", vbInformation, "Length exceded")
            txtPollTitle.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TxtQuestion.TextChanged
        If TxtQuestion.Text.Length > 180 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll question should be 180 word", vbInformation, "Length exceded")
            TxtQuestion.Focus()
        End If
    End Sub

    Private Sub txtoption1_TextChanged(sender As Object, e As EventArgs) Handles txtoption1.TextChanged
        If txtoption1.Text.Length > 25 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll option should be 25 word", vbInformation, "Length exceded")
            txtoption1.Focus()
        End If
    End Sub

    Private Sub txtoption2_TextChanged(sender As Object, e As EventArgs) Handles txtoption2.TextChanged
        If txtoption2.Text.Length > 25 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll option should be 25 word", vbInformation, "Length exceded")
            txtoption2.Focus()
        End If
    End Sub

    Private Sub txtoption3_TextChanged(sender As Object, e As EventArgs) Handles txtoption3.TextChanged
        If txtoption3.Text.Length > 25 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll option should be 25 word", vbInformation, "Length exceded")
            txtoption3.Focus()
        End If
    End Sub

    Private Sub txtoption4_TextChanged(sender As Object, e As EventArgs) Handles txtoption4.TextChanged
        If txtoption4.Text.Length > 25 Then
            Dim msg As MsgBoxResult = MsgBox("Maximum length of poll option should be 25 word", vbInformation, "Length exceded")
            txtoption4.Focus()
        End If
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click

        If txtPollTitle.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a poll title", vbInformation, "Poll title missing")

            txtPollTitle.Focus()
            Exit Sub
        End If

        If TxtQuestion.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a poll question", vbInformation, "Poll question missing")

            TxtQuestion.Focus()
            Exit Sub
        End If

        If txtoption1.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a option 1", vbInformation, "Oops!")

            txtoption1.Focus()
            Exit Sub
        End If


        If txtoption2.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a option 2", vbInformation, "Oops!")

            txtoption2.Focus()
            Exit Sub
        End If

        If txtoption3.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a option 3", vbInformation, "Oops!")

            txtoption3.Focus()
            Exit Sub
        End If

        If txtoption4.Text = Nothing Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please set a option 4", vbInformation, "Oops!")

            txtoption4.Focus()
            Exit Sub
        End If

        PollDate = Format(dpDate.Value, "dd-MMM-yy")



        If PollCreateFrom = "FromTree" Then

            For Each item In ThinkManagement.TreeView1.Nodes
                For Each child In item.nodes
                    For Each subchild In child.nodes

                        Dim conn As New pgConnect
                        Dim value As String = PollDate & "^" & txtPollTitle.Text & "^" & TxtQuestion.Text & "^" & txtoption1.Text & "^" & txtoption2.Text & "^" & txtoption3.Text & "^" & txtoption4.Text & "^" & subchild.tag & "^" & "InActive" & "^" & My.Settings.Name
                        conn.InsertRecord("think_poll", "date,poll_title,poll_question,option_1,option_2,option_3,option_4,process_id,poll_status,Owner", value)

                    Next
                Next
            Next
            Me.Close()

        Else

            Dim conn As New pgConnect
            Dim value As String = PollDate & "^" & txtPollTitle.Text & "^" & TxtQuestion.Text & "^" & txtoption1.Text & "^" & txtoption2.Text & "^" & txtoption3.Text & "^" & txtoption4.Text & "^" & ThinkManagement.ProjectID & "^" & "InActive" & "^" & My.Settings.Name
            conn.InsertRecord("think_poll", "date,poll_title,poll_question,option_1,option_2,option_3,option_4,process_id,poll_status,Owner", value)
            Me.Close()

        End If




        
        ThinkProPoll.ThinkPollLoad()
        Dim msg As MsgBoxResult = MsgBox("Poll created", vbInformation, "Success")


    End Sub

    Private Sub dpDate_ValueChanged(sender As Object, e As EventArgs) Handles dpDate.ValueChanged
        PollDate = Format(dpDate.Value, "dd-MMM-yy")
        Dim Today As String = Format(Now, "dd-MMM-yy")

        If PollDate < Today Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Oops! you cant create poll for previous dates")

            Exit Sub
        End If



    End Sub


End Class