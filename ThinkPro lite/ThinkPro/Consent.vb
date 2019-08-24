Imports System.Runtime.InteropServices
Imports Npgsql

Public Class AppConsent
    Const str As String = "https://iqmskm.ultimatix.net/km/index.php?title=Privacy_Policy"
    Dim consent_content As String = Nothing
    Dim privacy_policy As String = Nothing
    Dim user_name As String = Home.TP_UserName
    Dim supevisor_name As String = supervisor()

    Private Sub Consent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim conn As New pgConnect
            Dim dr As NpgsqlDataReader = conn.GetRecords("app_consent", "*")
            If dr.HasRows Then
                While dr.Read
                    consent_content = dr("consent_content")
                    privacy_policy = dr("privacy_policy")
                End While
            End If

            Dim value2 As String = consent_content.Replace("@user", user_name)
            Dim value3 As String = value2.Replace("@superviser", supevisor_name)
            consent_text.Text = value3
        Catch ex As IO.IOException

            ' MsgBox(ex.Message)

            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            cmdAccept.Enabled = True
            cmdDecline.Enabled = True
        Else
            cmdAccept.Enabled = False
            cmdDecline.Enabled = False
        End If
    End Sub

    Private Sub cmdDecline_Click(sender As Object, e As EventArgs) Handles cmdDecline.Click
        Dim msg As MsgBoxResult
        msg = MsgBox("As you have declined the Consent,You will be not able to use the application" & vbNewLine & "In case of any concern or doubt please connect with your supervisor(s)")
        Application.Exit()
    End Sub

    Private Sub cmdAccept_Click(sender As Object, e As EventArgs) Handles cmdAccept.Click
        Dim msg As MsgBoxResult
        msg = MsgBox("By agreeing you will be able to use the application")

        Dim conn As New pgConnect
        Dim enc As New Encryption

        enc.Encrypt(Home.TP_EmplID)
        Dim value As String = True & "^" & enc.encr



        'Dim value As String = enc.decrypt(reader("name").ToString) & "^" & reader("id")
        conn.UpdateRecord("user_details", "consent=@value1", value, "empl_id=@value2")
        Home.Enabled = True

        Me.Close()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles consent_text.TextChanged

    End Sub

    Public Function supervisor()
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim supervi As String = Nothing

        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "*", "project=@value1 AND process=@value2 AND sub_process=@value3", value)
        If dr.HasRows Then
            While dr.Read
                supervi = dr("project_lead")
            End While
        End If
        Return supervi

    End Function

    Private Sub privacy_policy_link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles privacy_policy_link.LinkClicked

        System.Diagnostics.Process.Start(str)
    End Sub
End Class