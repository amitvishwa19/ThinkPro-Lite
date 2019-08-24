Public Class ChangeTeam
    Public EmplID As String = Nothing

    Private Sub ChangeTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call fillProject()

        Dim enc As New Encryption
        EmplID = enc.decrypt(ThinkManagement.TreeEmplid)

        If EmplID = Nothing Then
            Dim msg As MsgBoxResult = MsgBox("No user is selected !Please select user to change process")
            Me.Close()
            Exit Sub
        End If


    End Sub

    Sub fillProject()
        Try
            Dim conn As New pgConnect
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT project")
            cmbProject.Items.Clear()
            While reader.Read
                cmbProject.Items.Add(reader("project"))
            End While
            reader.Dispose()

        Catch ex As IO.IOException

        End Try
    End Sub 'Required

    Sub fillProcess()
        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT process", "project =@value1", value)
            cmbProcess.Items.Clear()
            While reader.Read
                cmbProcess.Items.Add(reader("process"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Sub fillSubProcess()

        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text & "^" & cmbProcess.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT sub_process", "project =@value1 AND process=@value2", value)
            cmbSubProcess.Items.Clear()
            While reader.Read
                cmbSubProcess.Items.Add(reader("sub_process"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubProcess.SelectedIndexChanged

    End Sub

    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        cmbProcess.Items.Clear()
        Call fillProcess()
    End Sub

    Private Sub cmbProcess_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcess.SelectedIndexChanged
        cmbSubProcess.Items.Clear()
        Call fillSubProcess()
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Dim msg As MsgBoxResult
        Dim msg1 As MsgBoxResult
        Dim msg2 As MsgBoxResult
        Dim msg3 As MsgBoxResult



        Try

            If cmbProject.Text = Nothing Then
                cmbProject.Focus()
                msg = MsgBox("Please select Project")
                Exit Sub
            End If

            If cmbProcess.Text = Nothing Then
                cmbProcess.Focus()
                msg1 = MsgBox("Please select Precess")
                Exit Sub
            End If

            If cmbSubProcess.Text = Nothing Then
                cmbSubProcess.Focus()
                msg2 = MsgBox("Please select Sub Process")
                Exit Sub
            End If








            ''''''''''''Consent management'''''''''''''''''''

            Dim userid As Integer = get_user_id(ThinkManagement.TreeEmplid)
            Dim old_processid As Integer = get_process_id(ThinkManagement.TreeEmplid)
            Dim new_processid As Integer = get_process_id(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text)

            Call remove_consent_for_old_process(userid, old_processid)
            Call add_apps_for_new_process(userid, new_processid, old_processid)

            ''''''''''''Consent management'''''''''''''''''''


            'Call map_new_user_for_consent(ThinkManagement.TreeEmplid, prcsid)
            Dim enc As New Encryption
            enc.Encrypt(EmplID)
            Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text & "^" & ThinkManagement.TreeEmplid & "^" & new_processid

            Dim conn As New pgConnect
            conn.UpdateRecord("user_details", "project=@value1,process=@value2,sub_process=@value3,project_id=@value5", value, "empl_id=@value4")

            Me.Close()
            msg3 = MsgBox("Process change updated successfully")

        Catch ex As IO.IOException
            Dim msg5 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '     MsgBox(ex.Message)


            '     msg4 = MsgBox(ex.Message)

        End Try
    End Sub
End Class