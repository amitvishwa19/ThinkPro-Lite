Imports System.IO
Imports Npgsql
Imports Microsoft.Win32
Public Class SysFunctions


    Public Sub SysEventUpdate(UserID As Integer, iDate As String, SystemStatus As String, StartTime As String, EndTime As String, TotalTime As String, Optional UserName As String = "", Optional EmplID As String = "", Optional Project As String = "", Optional Process As String = "", Optional SubProcess As String = "")
        Dim lDate As Date = iDate
        Dim conn As New pgConnect
        Dim Var As New Encryption

        Var.Encrypt(EmplID)
        Dim Emp_id As String = Var.encr


        Try
            conn.InsertRecord("break_time_log", "name,user_id,empl_id,project,process,sub_process,date,status,start_time,end_time,total_time",
                              "" & UserName & "^" & UserID & "^" & Emp_id & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Format(lDate, "dd-MMM-yy") & "^" & SystemStatus & "^" & StartTime & "^" & EndTime & "^" & TotalTime & "")

        Catch ex As IO.IOException
            '  Dim lg As New ErrorLogger
            ' lg.WriteErrorLog("SysFunction LockUpdate", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try

    End Sub

    Public Sub DBSettingSave(Path As String)
        Try
            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines(Path & "\AppConfig.txt")
            Dim DbDetails As String = "PostgreSQL" & "," & enc.decrypt(lines(1)) & "," & enc.decrypt(lines(2)) & "," & enc.decrypt(lines(3)) & "," & enc.decrypt(lines(4)) & "," & enc.decrypt(lines(5))
            My.Settings.ConnDetails = DbDetails
            My.Settings.Save()


        Catch ex As IO.IOException

            '   Dim lg As New ErrorLogger
            '     lg.WriteErrorLog("SysFunctions DBSetting", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally


        End Try
    End Sub

    Public Function soft_del_days()

        Dim conn As New pgConnect
        ''Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "soft_delete_days", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        If dr.HasRows Then
            While dr.Read
                Return dr("soft_delete_days")
            End While
        Else
            Return 0
        End If
        Return 0
    End Function

    Public Function hard_del_days()
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "hard_delete_days", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        If dr.HasRows Then
            While dr.Read
                Return dr("hard_delete_days")
            End While
        Else
            Return 0
        End If
        Return 0
    End Function

    Public Function hard_delete_data(start_date As Date, end_date As Date, table_name As String)
        Try
            Dim conn As New pgConnect
            Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess & "^" & start_date & "^" & end_date
            conn.DeleteRecord(table_name, value, "project=@value1 AND process =@value2 AND sub_process=@value3 AND date >=@value4 AND date<=@value5")
            Return True
        Catch ex As IO.IOException
            Return False
        End Try
    End Function

    Public Function soft_delete_date(inpdate As Date)

        Try
            Dim inp_date As Date = inpdate

            If soft_del_days() = 0 Then
                Return inpdate
            Else
                Dim new_date As Date = DateTime.Now.AddDays(-soft_del_days())
                Return new_date
            End If
        Catch ex As IO.IOException
            Return inpdate
        End Try


    End Function


    Public Function delete_start_date()
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("time_view", "date", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        Dim i_date As Date = Today
        Dim dr_date As Date = Nothing

        If dr.HasRows Then
            While dr.Read
                dr_date = dr("date")
                If dr_date < i_date Then
                    i_date = dr_date
                End If
            End While
        End If
        Return i_date
    End Function

    Function delete_end_date()
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "hard_delete_days", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        Dim days As Integer = 0

        If dr.HasRows Then
            While dr.Read
                days = dr("hard_delete_days")
            End While
        End If

        Dim end_date As Date = Today.AddDays(-days)
        Return end_date
    End Function

    Public Function oldest_data_check(table_name As String)
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("time_view", "date", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        Dim i_date As Date = Today
        Dim dr_date As Date = Nothing

        If dr.HasRows Then
            While dr.Read
                dr_date = dr("date")
                If dr_date < i_date Then
                    i_date = dr_date
                End If
            End While
        End If
        'MsgBox(i_date)
        Dim days As Int32 = Today.Subtract(i_date).Days

        'MsgBox(days)

        If hard_del_days() < days Then
            Return True
        Else
            Return False
        End If


    End Function

End Class
