Public Class MasterTimeUpdate
    Public ActID As Integer
    Dim EmplID As String = ThinkManagement.TreeEmplid
    Dim UserName As String = ThinkManagement.TreeUserName
    Dim project = ThinkManagement.TM_Project
    Dim process = ThinkManagement.TM_Process
    Dim subprocess = ThinkManagement.TM_SubProcess
    Public Activity As String
    Public SubActivity As String
    Public Task As String

    Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
    Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")


    Private Sub MasterTimeUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FillUser()
        Call FillActivity()
    End Sub

    Sub AfterLoad()

        txtActivity.Text = Activity
        'Call FillSubActivity()
        txtSubActivity.Text = SubActivity
        'Call FillTask()
        txtTask.Text = Task
    End Sub

    Public Sub FillUser()
        Try
            Dim Conn As New pgConnect
            Dim Enc As New Encryption
            Dim value As String = project & "^" & process & "^" & subprocess & "^" & "Active"
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("user_details", "first_name,last_name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND account_status=@value4", value)

            'Dim value As String = project & "^" & process & "^" & subprocess
            'Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("user_details", "first_name,last_name", "project =@value1 AND process =@value2 AND sub_process =@value3", value)


            While reader.Read
                txtUser.Items.Add(Enc.decrypt(reader("first_name")) & "," & Enc.decrypt(reader("last_name")))
            End While
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Public Sub FillActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            While reader.Read
                txtActivity.Items.Add(reader("activity"))
            End While
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Public Sub FillSubActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = project & "^" & process & "^" & subprocess & "^" & txtActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT sub_activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4", value)
            While reader.Read
                txtSubActivity.Items.Add(reader("sub_activity"))
            End While
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Public Sub FillTask()
        Try
            Dim Conn As New pgConnect
            Dim value As String = project & "^" & process & "^" & subprocess & "^" & txtActivity.Text & "^" & txtSubActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT task", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND sub_activity =@value5", value)
            While reader.Read
                txtTask.Items.Add(reader("task"))
            End While
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub txtSubActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSubActivity.SelectedIndexChanged
        FillTask()
        txtTask.Text = ""
    End Sub

    Private Sub txtActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtActivity.SelectedIndexChanged
        FillSubActivity()
        txtSubActivity.Text = ""
        txtTask.Text = ""
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        If cmdSubmit.Text = "Update" Then
            Dim conn As New pgConnect
            Dim value As String = txtActivity.Text & "^" & txtSubActivity.Text & "^" & txtTask.Text & "^" & txtTotalTime.Text & "^" & txtVolume.Text & "^" & txtActID.Text & "^" & txtcmnt.Text & "^" & ActID
            conn.UpdateRecord("time_view", "activity =@value1,sub_activity =@value2,task =@value3,total_time =@value4,volume =@value5,act_id =@value6,comment =@value7", value, "id =@value8")
            MasterUpdate.MasterUpdateGrid()
            Me.Close()
            Dim msg As MsgBoxResult
            msg = MsgBox("Activity updated successfully", vbInformation, "Updated")
            ' MsgBox("Activity updated successfully", vbInformation, "Updated")
            MasterUpdate.MasterUpdateGrid()
            Me.Close()
        ElseIf cmdSubmit.Text = "Add Activity" Then
            Dim conn As New pgConnect
            conn.InsertRecord("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,total_time,volume,act_id,comment,added_by",
                              "" & SDate &
                              "^" & EmplID &
                              "^" & UserName &
                              "^" & project &
                              "^" & process &
                              "^" & subprocess &
                              "^" & txtActivity.Text &
                              "^" & txtSubActivity.Text &
                              "^" & txtTask.Text &
                              "^" & txtTotalTime.Text &
                              "^" & txtVolume.Text &
                              "^" & txtActID.Text &
                              "^" & txtcmnt.Text &
                              "^" & My.Settings.Name & "")





            Dim msg As MsgBoxResult = MsgBox("Activity Added Successfully", vbInformation, "Success")
            Call MasterUpdate.MasterUpdateGrid()
            Me.Close()
        End If
       
    End Sub

    Private Sub txtTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtTask.SelectedIndexChanged

    End Sub

    Private Sub txtUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtUser.SelectedIndexChanged
        UserName = txtUser.Text
    End Sub

End Class
