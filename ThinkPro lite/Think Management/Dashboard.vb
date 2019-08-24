Imports Npgsql
Public Class Dashboard

    Public TM_UserName As String = Nothing
    Public TM_EmplID As Integer = Nothing
    Public TM_UserID As Integer = Nothing
    Public TM_ProcessID As Integer = Nothing
    Public TM_Project As String = Nothing
    Public TM_Process As String = Nothing
    Public TM_SubProcess As String = Nothing
    Public TM_UserRole As String = Nothing
    Dim TotalUser As Integer = Nothing
    Dim Active_user As Integer = Nothing
    Dim lock_user As Integer = Nothing
    Dim break_user As Integer = Nothing
    Dim logoff_user As Integer = Nothing
    Dim notstarted_user As Integer = Nothing


    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TM_UserName = Home.TP_UserName
        TM_EmplID = Home.TP_EmplID
        TM_UserID = Home.TP_UserID
        TM_ProcessID = Home.TP_ProcessID
        TM_Project = Home.TP_Project
        TM_Process = Home.TP_Process
        TM_SubProcess = Home.TP_SubProcess
        TM_UserRole = Home.TP_UserRole

        Call SystemDetails()

    End Sub
    Sub SystemDetails()
        Try
            Dim conn As New pgConnect

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "Active"
            Dim reader As NpgsqlDataReader = conn.GetRecords("user_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND account_status =@value4", value)
            While reader.Read
                TotalUser += 1
            End While

            conn.Connect()
            Dim SDate As String = Format(Now, "dd-MMM-yy")
            Dim value1 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate
            Dim reader1 As NpgsqlDataReader = conn.GetRecords("team_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date =@value4", value1)
            While reader1.Read

                If reader1("activity") = "Active" Then
                    Active_user += 1
                End If

                If reader1("activity") = "System Locked" Then
                    lock_user += 1
                End If

                If reader1("activity") = "Break" Then
                    break_user += 1
                End If

                If reader1("activity") = "Logged Out" Then
                    logoff_user += 1
                End If



            End While

            notstarted_user = TotalUser - Active_user - lock_user - break_user - logoff_user

            lblActiveUser.Text = Format(Active_user, "00")
            lblLocked.Text = Format(lock_user, "00")
            lblBreak.Text = Format(break_user, "00")
            lblLogOff.Text = Format(logoff_user, "00")
            lblNotStarted.Text = Format(notstarted_user, "00")

        Catch ex As IO.IOException

        End Try
    End Sub
End Class