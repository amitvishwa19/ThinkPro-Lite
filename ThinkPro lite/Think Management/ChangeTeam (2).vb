Public Class ChangeTeam
    Public EmplID As String = Nothing

    Private Sub ChangeTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call fillProject()

        Dim enc As New Encryption
        EmplID = enc.decrypt(ThinkManagement.TreeEmplid)

        If EmplID = Nothing Then
            MsgBox("No user is selected !Please select user to change process")
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

        Catch ex As Exception

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
        Try

            If cmbProject.Text = Nothing Then
                cmbProject.Focus()
                MsgBox("Please select Project")
                Exit Sub
            End If

            If cmbProcess.Text = Nothing Then
                cmbProcess.Focus()
                MsgBox("Please select Precess")
                Exit Sub
            End If

            If cmbSubProcess.Text = Nothing Then
                cmbSubProcess.Focus()
                MsgBox("Please select Sub Process")
                Exit Sub
            End If



            Dim enc As New Encryption

            enc.Encrypt(EmplID)
            Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text & "^" & ThinkManagement.TreeEmplid

            Dim conn As New pgConnect
            conn.UpdateRecord("user_details", "project=@value1,process=@value2,sub_process=@value3", value, "empl_id=@value4")

            'Dim conn2 As New pgConnect
            'conn2.UpdateRecord("think_profile", "project=@value1,process=@value2,sub_process=@value3", value, "empl_id=@value4")

            Me.Close()
            MsgBox("Process change updated successfully")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class