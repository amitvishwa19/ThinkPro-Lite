Imports Npgsql
Module cfunctions

    Public Function get_app_name_with_id(appid As Integer)

        Dim appname As String = Nothing
        Dim field_return As String = Nothing
        Dim app_con As New pgConnect
        Dim app As NpgsqlDataReader = app_con.GetRecords("applications", "*", "id=@value1", appid)
        If app.HasRows Then
            While app.Read
                appname = app("app_name")
            End While
        End If
        Return appname

    End Function

    Public Function on_revoke_check_for_supervisor_comment(userid As Integer, appid As Integer)

        Dim value As String = userid & "^" & appid
        Dim app_con As New pgConnect
        Dim app As NpgsqlDataReader = app_con.GetRecords("user_application", "supervisor_comment", "user_id=@value1 and application_id=@value2", value)
        If app.HasRows Then
            While app.Read
                If app("supervisor_comment").ToString = Nothing Then
                    Return False
                Else
                    Return True
                End If

            End While
        End If
        Return False

    End Function

    Public Function on_consent_check_for_user_comment(userid As Integer, appid As Integer)

        Dim value As String = userid & "^" & appid
        Dim app_con As New pgConnect
        Dim app As NpgsqlDataReader = app_con.GetRecords("user_application", "user_comment", "user_id=@value1 and application_id=@value2", value)
        If app.HasRows Then
            While app.Read
                If app("user_comment").ToString = Nothing Then
                    Return False
                Else
                    Return True
                End If

            End While
        End If
        Return False

    End Function

    Public Function get_user_comment(userid As Integer, appid As Integer)

        Dim value As String = userid & "^" & appid
        Dim app_con As New pgConnect
        Dim app As NpgsqlDataReader = app_con.GetRecords("user_application", "user_comment", "user_id=@value1 and application_id=@value2", value)
        If app.HasRows Then
            While app.Read
                Return app("user_comment").ToString
            End While
        End If
        Return Nothing

    End Function

    Public Function get_supevisor_comment(userid As Integer, appid As Integer)

        Dim value As String = userid & "^" & appid
        Dim app_con As New pgConnect
        Dim app As NpgsqlDataReader = app_con.GetRecords("user_application", "supervisor_comment", "user_id=@value1 and application_id=@value2", value)
        If app.HasRows Then
            While app.Read
                Return app("supervisor_comment").ToString
            End While
        End If
        Return Nothing

    End Function

    Public Function get_user_id()

        Dim crypt As New Encryption
        Dim emplid As String = crypt.EncryptNew(Home.TP_EmplID)
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("user_details", "*", "empl_id=@value1", emplid)
        If prid.HasRows Then
            While prid.Read
                Return prid("user_id")
            End While
        End If
        Return 0

    End Function

    Public Function get_user_id(emplid As String)

        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("user_details", "*", "empl_id=@value1", emplid)
        If prid.HasRows Then
            While prid.Read
                Return prid("user_id")
            End While
        End If
        Return 0

    End Function

    Public Function get_process_id()

        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("project_details", "*", "project=@value1 and process=@value2 and sub_process=@value3", value)
        If prid.HasRows Then
            While prid.Read
                Return prid("project_id")
            End While
        End If
        Return 0

    End Function

    Public Function get_process_id(emplid As String)

        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("user_details", "*", "empl_id=@value1", emplid)
        If prid.HasRows Then
            While prid.Read
                Return prid("project_id")
            End While
        End If
        Return 0

    End Function

    Public Function get_process_id(project As String, process As String, subprocess As String)

        Dim app_con As New pgConnect
        Dim value As String = project & "^" & process & "^" & subprocess
        Dim prid As NpgsqlDataReader = app_con.GetRecords("project_details", "*", "project=@value1 and process=@value2 and sub_process=@value3", value)
        If prid.HasRows Then
            While prid.Read
                Return prid("project_id")
            End While
        End If
        Return 0

    End Function

    Public Function get_application_id(appname As String)

        Dim value As String = ThinkManagement.TM_Process & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess
        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("applications", "*", "app_name=@value1", appname)
        If prid.HasRows Then
            While prid.Read
                Return prid("id")
            End While
        End If
        Return 0

    End Function

    Public Function get_user_count()

        Dim count As Integer = 0
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim app_con As New pgConnect
        Dim prid As NpgsqlDataReader = app_con.GetRecords("user_details", "*", "project=@value1 and process=@value2 and sub_process=@value3", value)
        If prid.HasRows Then
            While prid.Read
                count += 1
            End While
        End If
        Return count

    End Function

    Public Function get_process_application()

        Dim count As Integer = 0
        Dim processid As Integer = get_process_id()

        Dim picon As New pgConnect

        Dim prs_app As NpgsqlDataReader = picon.GetRecords("process_application", "*", "process_id=@value1", processid)
        If prs_app.HasRows Then
            While prs_app.Read
                count += 1
            End While
        End If
        Return count

    End Function

    Public Function consent_check()

        Dim consent_status As Boolean = False
        Dim conn As New pgConnect
        Dim enc As New Encryption
        Dim consent As Boolean = False
        Try

            Dim userid As Integer = get_user_id()
            Dim processid As Integer = get_process_id()
            Dim value As String = userid & "^" & processid
            Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1 and process_id=@value2", value)

            If dr.HasRows Then
                While dr.Read
                    'If dr("application_consent") = False And ((dr("user_comment") = Nothing) Or dr("user_comment") = vbNull) Then
                    If dr("application_consent") = False And dr("user_comment").ToString = "" Then
                        'If dr("application_consent") = False Then
                        Return False
                    Else
                        consent_status = True
                    End If
                End While
            End If
            dr.Dispose()
            Return consent_status
        Catch ex As IO.IOException
            Return False
        End Try

    End Function

    Public Function team_consent_accept_count()

        Dim consent_status As Boolean = False
        Dim conn As New pgConnect
        Dim enc As New Encryption
        Dim consent As Boolean = False
        Dim count As Integer = 0
        Try

            Dim userid As Integer = get_process_id()
            Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1", userid)

            If dr.HasRows Then
                While dr.Read
                    If dr("application_consent") = True Then
                        count += 1
                    End If
                End While
            End If
            dr.Dispose()
            Return count
        Catch ex As IO.IOException
            Return False
        End Try

    End Function

    Public Function team_consent_not_accept_count()

        Dim consent_status As Boolean = False
        Dim conn As New pgConnect
        Dim enc As New Encryption
        Dim consent As Boolean = False
        Dim count As Integer = 0
        Try

            Dim userid As Integer = get_process_id()
            Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1", userid)

            If dr.HasRows Then
                While dr.Read
                    If dr("application_consent") = False Then
                        count += 1
                    End If
                End While
            End If
            dr.Dispose()
            Return count
        Catch ex As IO.IOException
            Return False
        End Try

    End Function

    Public Sub map_new_user_for_consent(emplid As String, newprocessid As Integer)

        Dim userid As Integer = get_user_id(emplid)
        Dim processid As Integer = get_process_id(emplid)

        Dim app_con As New pgConnect
        Dim dr As NpgsqlDataReader = app_con.GetRecords("process_application", "*", "process_id=@value1", processid)
        If dr.HasRows Then
            While dr.Read
                Dim add As New pgConnect
                Dim value3 As String = userid & "^" & dr("application_id") & "^" & newprocessid
                add.InsertRecord("user_application", "user_id,application_id,process_id", value3)
            End While
        End If
        dr.Dispose()

    End Sub

    Public Sub remove_consent_for_old_process(userid, old_processid)

        Dim conn As New pgConnect
        Dim value As String = False & "^" & userid & "^" & old_processid
        conn.UpdateRecord("user_application", "application_consent=@value1", value, "user_id=@value2 and process_id=@value3")

    End Sub

    Public Sub add_apps_for_new_process(userid, new_processid, old_processid)
        Dim conn As New pgConnect

        Dim dr As NpgsqlDataReader = conn.GetRecords("process_application", "application_id", "process_id=@value1", new_processid)
        If dr.HasRows Then
            While dr.Read

                Dim cget As New pgConnect
                Dim gvalue As String = userid & "^" & dr("application_id") & "^" & new_processid
                Dim cdr As NpgsqlDataReader = cget.GetRecords("user_application", "user_id", "user_id=@value1 and application_id=@value2 and process_id=@value3", gvalue)
                If cdr.HasRows = False Then
                    'MsgBox("Application row is there")
                    Dim add As New pgConnect
                    Dim avalue As String = userid & "^" & dr("application_id") & "^" & new_processid
                    add.InsertRecord("user_application", "user_id,application_id,process_id", avalue)
                End If


            End While
        End If

    End Sub


    'Public Sub remove_old_process_consent(emplid As String)
    '    Dim userid As Integer = get_user_id(emplid)
    '    ''Dim process_id As Integer = get_process_id(emplid)

    '    Dim conn As New pgConnect
    '    Dim value As String = False & "^" & "Process Changed" & "^" & userid
    '    conn.UpdateRecord("user_application", "status=@value1,supervisor_comment=@value2", value, "user_id=@value3")


    'End Sub

    Public Function app_consent_status(userid, appid, processid)

        Dim picon As New pgConnect
        Dim value As String = userid & "^" & appid & "^" & processid
        Dim dr As NpgsqlDataReader = picon.GetRecords("user_application", "application_consent", "user_id=@value1 and application_id=@value2 and process_id=@value3", value)
        If dr.HasRows Then
            While dr.Read
                If dr("application_consent") = True Then
                    Return True
                Else
                    Return False
                End If
            End While
        End If


        Return False
    End Function

End Module
