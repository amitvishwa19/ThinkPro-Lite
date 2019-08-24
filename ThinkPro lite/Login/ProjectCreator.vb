Imports System.IO
Imports Npgsql
Public Class ProjectCreator

    Public OpenType As String = Nothing

    Private Sub ProjectCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim conn As New pgConnect
            Dim reader As NpgsqlDataReader

            reader = conn.GetRecords("project_details", "DISTINCT project")
            cmbProject.Items.Clear()
            While reader.Read
                cmbProject.Items.Add(reader("project"))
            End While
            reader.Dispose()

            conn.Connect()
            reader = conn.GetRecords("project_details", "DISTINCT process")
            cmbProcess.Items.Clear()
            While reader.Read
                cmbProcess.Items.Add(reader("process"))
            End While
            reader.Dispose()

            conn.Connect()
            reader = conn.GetRecords("project_details", "DISTINCT sub_process")
            cmbSubProcess.Items.Clear()
            While reader.Read
                cmbSubProcess.Items.Add(reader("sub_process"))
            End While
            reader.Dispose()

            conn.Connect()
            reader = conn.GetRecords("project_details", "DISTINCT project_lead")
            cmb_Process_owner.Items.Clear()
            While reader.Read
                cmb_Process_owner.Items.Add(reader("project_lead"))
            End While
            reader.Dispose()

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try



    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        Dim Msg As MsgBoxResult
        Try
            If ValidateField() = True Then

                If ProjectProcessCheck() = True Then
                    Dim conn As New pgConnect
                    Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text & "^" & cmb_Process_owner.Text & "^" & cmb_Process_owner_email.Text & "^" & txt_process_address.Text & "^" & timeViwtype.Text & "^" & txtBackupPath.Text & "^" & soft_del_days.Text & "^" & hard_del_days.Text
                    conn.InsertRecord("project_details", "project,process,sub_process,process_owner,process_owner_email,process_address,timeview_type,backup_path,soft_delete_days,hard_delete_days", value)

                    If OpenType = "ProjectAdd" Then GoTo SkipRegistration
                    Registration.fillProject()
                    Registration.cmbProject.Text = cmbProject.Text
                    Registration.cmbProject.Enabled = False
                    Registration.fillProcess()
                    Registration.cmbProcess.Text = cmbProcess.Text
                    Registration.cmbProcess.Enabled = False
                    Registration.fillSubProcess()
                    Registration.cmbSubProcess.Text = cmbSubProcess.Text
                    Registration.cmbSubProcess.Enabled = False
                    Registration.RegistrationType = "Process Lead"

SkipRegistration:
                    Msg = MsgBox("Project created sucessfully", vbInformation, "Success")
                    AppSetup.ProjectDefaultSettings(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "BackupPath", "Null")
                    AppSetup.ProjectDefaultSettings(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "SystemLockTime", "10")
                    AppSetup.ProjectDefaultSettings(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "ActivityLoggerType", "Default")
                    AppSetup.ProjectDefaultSettings(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "SwitchUserCheck", "False")
                    AppSetup.ProjectDefaultSettings(cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "SystemLockCheck", "False")
                    Me.Close()
                Else
                    Msg = MsgBox("Project, Process, Sub Process already exists", vbInformation, "Oops!")
                    Registration.fillProject()
                    Registration.cmbProject.Text = cmbProject.Text
                    Registration.fillProcess()
                    Registration.cmbProcess.Text = cmbProcess.Text
                    Registration.fillSubProcess()
                    Registration.cmbSubProcess.Text = cmbSubProcess.Text
                    Me.Close()

                End If


            Else

                Exit Sub
            End If

        Catch ex As IO.IOException
            Msg = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Function ValidateField()
        Dim Msg As MsgBoxResult


        If cmbProject.Text = Nothing Then
            Msg = MsgBox("Please define a Project name", vbInformation)
            cmbProject.Focus()
            Return False
            Exit Function
        End If
        If cmbProcess.Text = Nothing Then
            Msg = MsgBox("Please define a Process name", vbInformation)
            cmbProcess.Focus()
            Return False
            Exit Function
        End If
        If cmbSubProcess.Text = Nothing Then
            Msg = MsgBox("Please define a Sub Process name", vbInformation)
            cmbSubProcess.Focus()
            Return False
            Exit Function
        End If

        If cmb_Process_owner.Text = Nothing Then
            Msg = MsgBox("Please define Process Owner name", vbInformation)
            cmb_Process_owner.Focus()
            Return False
            Exit Function
        End If

        If cmb_Process_owner_email.Text = Nothing Then
            Msg = MsgBox("Please define Process Owner email", vbInformation)
            cmb_Process_owner_email.Focus()
            Return False
            Exit Function
        End If

        If txt_process_address.Text = Nothing Then
            Msg = MsgBox("Please define Process location Address", vbInformation)
            txt_process_address.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function

    Function ProjectProcessCheck()

        Dim conn As New pgConnect
        'Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text
        'Dim reader As NpgsqlDataReader = conn.GetRecords("project_details", "*", "process =@value1 AND process =@value2 AND sub_process =@value3", value)

        Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text
        Dim reader As NpgsqlDataReader = conn.GetRecords("project_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)


        If reader.HasRows Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub cmdBackupBrowse_Click(sender As Object, e As EventArgs) Handles cmdBackupBrowse.Click
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog() = DialogResult.OK Then
            txtBackupPath.Text = FBD.SelectedPath
        End If
    End Sub

    




End Class