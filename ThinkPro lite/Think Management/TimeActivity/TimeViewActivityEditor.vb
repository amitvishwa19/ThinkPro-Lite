Imports Npgsql
Public Class TimeViewActivityEditor
    Public ActID As String = Nothing
    Dim project = ThinkManagement.TM_Project
    Dim process = ThinkManagement.TM_Process
    Dim subprocess = ThinkManagement.TM_SubProcess
    Private Sub TimeViewActivityEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Dim msg, msg1 As MsgBoxResult
        Try

            If txtBucket.Text = Nothing Or txtActivity.Text = Nothing Or txtSubActivity.Text = Nothing Or txtTask.Text = Nothing Then
                msg = MsgBox("Please fill all the feilds", vbInformation, "oops!")
                Exit Sub
            End If

            If cmdSubmit.Text = "Update" Then
                Dim conn As New pgConnect
                Dim value As String = txtActivity.Text & "^" & txtSubActivity.Text & "^" & txtTask.Text & "^" & txtUPT.Text & "^" & cbLockExc.CheckState & "^" & cbVolReq.CheckState & "^" & cbActIDReq.CheckState & "^" & cbCmntReq.CheckState & "^" & txtBucket.Text & "^" & ActID
                conn.UpdateRecord("time_activity", "activity =@value1,sub_activity =@value2,task =@value3,upt =@value4,ex_lock =@value5,volume =@value6,aid =@value7,cmnt =@value8,bucket =@value9", value, "act_id =@value10")

                ThinkManagement.IRow = Nothing
                msg1 = MsgBox("Activity updated successfully", vbInformation, "Updated")
                Me.Close()

            ElseIf cmdSubmit.Text = "Add Activity" Then
                Dim conn As New pgConnect
                Dim value As String = ThinkManagement.ProjectID & "^" & project & "^" & process & "^" & subprocess & "^" & txtBucket.Text & "^" & txtActivity.Text & "^" & txtSubActivity.Text & "^" & txtTask.Text & "^" & txtUPT.Text & "^" & cbLockExc.CheckState & "^" & cbVolReq.CheckState & "^" & cbActIDReq.CheckState & "^" & cbCmntReq.CheckState & "^" & "Active"

                conn.InsertRecord("time_activity", "project_id,project,process,sub_process,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", value)



            End If

            TimeViewActivityManager.TimeViewActivity()
            Me.Close()

        Catch ex As IO.IOException
            Dim msg5 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Sub AddActivity()
        Dim conn As New pgConnect
        Dim value As String = project & "^" & process & "^" & subprocess & "^" & txtBucket.Text
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND bucket =@value4", value)
        txtActivity.Items.Clear()
        If reader.HasRows Then
            While reader.Read
                txtActivity.Items.Add(reader("activity"))
            End While
        End If
    End Sub

    Sub AddSubActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = project & "^" & process & "^" & subprocess & "^" & txtActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT sub_activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4", value)
            txtSubActivity.Items.Clear()
            While reader.Read
                txtSubActivity.Items.Add(reader("sub_activity"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Sub AddTask()
        Try
            Dim Conn As New pgConnect
            Dim value As String = project & "^" & process & "^" & subprocess & "^" & txtActivity.Text & "^" & txtSubActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT task", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND sub_activity =@value5", value)
            txtTask.Items.Clear()
            While reader.Read
                txtTask.Items.Add(reader("task"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Sub Validation()



    End Sub

    Private Sub txtActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtActivity.SelectedIndexChanged
        Call AddSubActivity()
        txtSubActivity.Text = Nothing
        txtTask.Text = Nothing
    End Sub

    Private Sub txtSubActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSubActivity.SelectedIndexChanged
        Call AddTask()
        txtTask.Text = Nothing
    End Sub

    Private Sub txtBucket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtBucket.SelectedIndexChanged
        Call AddActivity()
        txtActivity.Text = Nothing
        txtSubActivity.Text = Nothing
        txtTask.Text = Nothing
    End Sub


End Class