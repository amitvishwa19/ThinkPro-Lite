Imports System.IO
Imports Npgsql
Public Class NewIssueLog

    Public InputType As String = Nothing
    Public LogID As Integer = Nothing
    Public UserID As Integer = My.Settings.UserID
    Public ProjectId As Integer = My.Settings.ProjectID


    Private Sub NewIssueLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

       
    End Sub


    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try
            Dim conn As New pgConnect
            Dim IDate As String = Format(Now, "dd-MMM-yy")
            Dim value As String = IDate & "^" & UserID & "^" & ProjectId & "^" & cmbLogType.Text & "^" & txtlogTitle.Text & "^" & txtLogDesc.Text & "^" & txtLogSol.Text & "^" & "Open"
            conn.InsertRecord("think_logger", "log_date,user_id,process_id,log_type,log_title,log_description,log_solution,log_status", value)
            Me.Close()
            IssueLogger.IssueLoggerGrid()
            Dim msg As MsgBoxResult = MsgBox("Issue/Request logged successfully", vbInformation, "Success")

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub cmbLogType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLogType.SelectedIndexChanged

    End Sub
End Class