Imports System.IO
Imports Npgsql
Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports System.Net
Imports System.Net.NetworkInformation.Ping
Imports ThinkProlite.Functions
Namespace AppEvents

    Module AppEvents

        'Login Stamp
        Public Sub LoginTimeStamp()
            Dim conn As New pgConnect
            Dim Var As New Encryption

            Try
                Dim tdate As String
                tdate = Format(Now, "ddMMyyyy")

                Var.Encrypt(Home.TP_EmplID)
                Dim Emplid As String = Var.encr


                If My.Settings.EmplID = Nothing Then
                    Exit Sub
                End If



                Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("team_view", "*", "act_id =@value1", Home.TP_EmplID & tdate)
                Dim value As String = "LoggedIn" & "^" & "No Activity Selected" & "^" & Home.TP_EmplID & tdate
                If reader.HasRows Then
                    conn.Connect()
                    conn.UpdateRecord("team_view", "activity =@value1,activity_type =@value2", value, "act_id =@value3")
                Else
                    conn.Connect()
                    conn.InsertRecord("team_view", "act_id,in_time,name,project,process,sub_process,empl_id,date,activity,activity_type",
                                        "" & Home.TP_EmplID & tdate &
                                        "^" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString &
                                        "^" & Home.TP_UserName &
                                        "^" & Home.TP_Project &
                                        "^" & Home.TP_Process &
                                        "^" & Home.TP_SubProcess &
                                        "^" & Emplid &
                                        "^" & Format(Now, "dd-MMM-yy") &
                                        "^" & "LoggedIn" &
                                        "^" & "No Activity Selected" & "")
                End If
            Catch ex As Exception
                Dim lg As New ErrorLogger
                lg.WriteErrorLog("LoginTimeStamp", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Finally
                If conn.connection.State = ConnectionState.Open Then
                    conn.ConnClose()
                End If
            End Try


        End Sub

        'Logout Stamp
        Public Sub LogOutTimeStamp()

            Try
                If My.Settings.LogoutStamp = False Then
                    Exit Sub
                End If

                Dim conn As New pgConnect
                Dim Var As New Encryption

                Dim tdate As String
                Dim Logoutdate As Date = My.Settings.LoginDate
                tdate = Format(Logoutdate, "ddMMyyyy")

                Var.Encrypt(Home.TP_EmplID & tdate)
                Dim ActId As String = Var.encr
                Dim value As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & "Logged Out" & "^" & "Logged Out" & "^" & Home.TP_EmplID & tdate

                conn.UpdateRecord("team_view", "out_time =@value1,activity =@value2,activity_type =@value3", value, "act_id =@value4")

            Catch ex As Exception

                Dim lg As New ErrorLogger
                lg.WriteErrorLog("LogOutTimeStamp", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

            Finally

            End Try

        End Sub

        'Activity time to database
        Public Sub activity_time_to_database(EmplID As Object,
                                             Name As Object,
                                             Project As Object,
                                             Process As Object,
                                             SubProcess As Object,
                                             ProjectID As Object,
                                             Activity As Object,
                                             SubActivity As Object,
                                             Task As Object,
                                             StartTime As Object,
                                             EndTime As Object,
                                             TotalTime As Object,
                                             Volume As Object,
                                             ActID As Object,
                                             Comment As Object)


            Dim Conn As New pgConnect

            Try
                Dim LDate As Date = My.Settings.LoginDate
                Dim ival As String = Format(LDate, "dd-MMM-yy")



                Conn.InsertRecord("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,start_time,end_time,total_time,volume,project_id,act_id,comment,added_by",
                              "" & Format(LDate, "dd-MMM-yy") &
                              "^" & Crypto.Encrypt(EmplID) &
                              "^" & Crypto.Encrypt(Name) &
                              "^" & Project &
                              "^" & Process &
                              "^" & SubProcess &
                              "^" & Activity &
                              "^" & SubActivity &
                              "^" & Task &
                              "^" & StartTime &
                              "^" & EndTime &
                              "^" & TotalTime &
                              "^" & Volume &
                              "^" & ProjectID &
                              "^" & ActID &
                              "^" & Comment &
                              "^" & "System" & "")


            Catch ex As Exception
                Dim lg As New ErrorLogger
                lg.WriteErrorLog("AppEvents-activity_time_to_database", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

            Finally
                If Conn.connection.State = ConnectionState.Open Then
                    Conn.ConnClose()
                End If

            End Try

        End Sub









    End Module
End Namespace


