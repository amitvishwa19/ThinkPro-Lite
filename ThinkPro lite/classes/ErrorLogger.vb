Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Npgsql
<CLSCompliant(True)>
Public Class ErrorLogger




    Public Sub WriteErrorLog(ByVal FormName As String, ByVal FunctionName As String, ByVal stkTrace As String)
        Dim conn As New pgConnect
        Try

            Dim value As String = Home.TP_UserID & "^" & Home.TP_ProcessID & "^" & Format(Now, "dd-MMM-yy hh:MM tt") & "^" & FormName & "^" & FunctionName & "^" & stkTrace
            conn.InsertRecord("think_error_log", "user_id,process_id,date,error_form,error_title,error_desc", value)

        Catch ex As IO.IOException

        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try
    End Sub


End Class
