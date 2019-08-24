Imports Npgsql
Public Class ProjectSetting
    Private Sub ProjectSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "*", "project =@value1 and process=@value2 and sub_process=@value3", value)
        If dr.HasRows Then
            While dr.Read
                txtProcessOwner.Text = dr("process_owner").ToString
                txtProcessOwnerEmail.Text = dr("process_owner_email").ToString
                txtBackupPath.Text = dr("backup_path").ToString
                soft_del_days.Value = dr("soft_delete_days").ToString
                hard_del_days.Value = dr("hard_delete_days").ToString
            End While
        End If



    End Sub

    Private Sub cmdBackupBrowse_Click(sender As Object, e As EventArgs) Handles cmdBackupBrowse.Click
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog() = DialogResult.OK Then
            txtBackupPath.Text = FBD.SelectedPath
        End If
    End Sub

    Private Sub cmdupdate_Click(sender As Object, e As EventArgs) Handles cmdupdate.Click

        Dim conn As New pgConnect
        Dim value As String = txtProcessOwner.Text & "^" & txtProcessOwnerEmail.Text & "^" & txtBackupPath.Text & "^" & soft_del_days.Value & "^" & hard_del_days.Value & "^" & ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess
        conn.UpdateRecord("project_details", "process_owner=@value1,process_owner_email=@value2,backup_path=@value3,soft_delete_days=@value4,hard_delete_days=@value5", value, "project = @value6 AND process = @value7 AND sub_process = @value8")
        Me.Close()
        Dim msg As MsgBoxResult = MsgBox("Project settings updated successfully")
    End Sub
End Class