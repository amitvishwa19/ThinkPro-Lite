Imports Npgsql
Public Class MapApplications
    Dim processid As Integer = Nothing
    Private Sub MapApplications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call application_list()
        processid = get_process_id()
        Call get_process_app_fields(processid)
    End Sub


    Private Sub application_list()
        Try
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim Parent As NpgsqlDataReader = conn.GetRecords("applications", "*")
            While Parent.Read
                app_list_box.Items.Add(Parent("app_name"))
            End While
            Parent.Dispose()
        Catch ex As IO.IOException
            '    MsgBox(ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Public Sub get_process_app_fields(process_id As Integer)

        For i = 0 To app_list_box.Items.Count - 1
            'app_list_box.SetItemChecked(i, False)
            Dim app_id As Integer = get_application_id(app_list_box.Items(i).ToString)
            Dim picon As New pgConnect
            Dim value As String = process_id & "^" & app_id
            Dim prs_app As NpgsqlDataReader = picon.GetRecords("process_application", "*", "process_id=@value1 and application_id=@value2", value)
            If prs_app.HasRows Then
                app_list_box.SetItemChecked(i, True)
            Else
                app_list_box.SetItemChecked(i, False)
            End If

        Next


    End Sub

    Private Sub cmd_sync_now_Click(sender As Object, e As EventArgs) Handles cmd_sync_now.Click
        Dim msg As New MsgBoxResult
        Call submit_data()
        Call user_application_sync()
        Me.Close()
        msg = MsgBox("Sync Complete")
    End Sub



    Private Sub submit_data()
        Try
            Dim process_id As Integer = get_process_id()


            For i = 0 To app_list_box.Items.Count - 1
                If app_list_box.GetItemChecked(i) Then

                    Dim app_id As Integer = get_application_id(app_list_box.Items(i).ToString)
                    Dim value As String = process_id & "^" & app_id
                    Dim conn As New pgConnect
                    Dim dr As NpgsqlDataReader = conn.GetRecords("process_application", "*", "process_id=@value1 and application_id=@value2", value)
                    If dr.HasRows Then
                    Else
                        Dim add As New pgConnect
                        Dim value2 As String = process_id & "^" & app_id
                        add.InsertRecord("process_application", "process_id,application_id", value2)
                    End If

                Else

                    Dim app_id As Integer = get_application_id(app_list_box.Items(i).ToString)
                    Dim value As String = process_id & "^" & app_id
                    Dim conn As New pgConnect
                    Dim dr As NpgsqlDataReader = conn.GetRecords("process_application", "*", "process_id=@value1 and application_id=@value2", value)
                    If dr.HasRows Then
                        While dr.Read
                            Dim del As New pgConnect
                            del.DeleteRecord("process_application", dr("id"), "id=@value1")
                        End While
                    End If
                End If

            Next


        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub user_application_sync()

        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess

        For i = 0 To app_list_box.Items.Count - 1

            Dim app_id As Integer = get_application_id(app_list_box.Items(i).ToString)
            Dim process_id As Integer = get_process_id()


            Dim conn As New pgConnect
            Dim rdr As NpgsqlDataReader = conn.GetRecords("user_details", "*", "project=@value1 and process=@value2 and sub_process=@value3", value)
            If rdr.HasRows Then
                While rdr.Read
                    Dim user_id As Integer = rdr("user_id")
                    Dim value2 As String = user_id & "^" & app_id & "^" & process_id

                    If app_list_box.GetItemChecked(i) Then
                        Dim conn2 As New pgConnect
                        Dim dr As NpgsqlDataReader = conn2.GetRecords("user_application", "*", "user_id=@value1 and application_id=@value2 and process_id=@value3", value2)
                        If dr.HasRows Then
                        Else
                            Dim add As New pgConnect
                            Dim value3 As String = user_id & "^" & app_id & "^" & process_id
                            add.InsertRecord("user_application", "user_id,application_id,process_id", value3)
                        End If
                    Else
                        Dim conn3 As New pgConnect
                        Dim dr As NpgsqlDataReader = conn3.GetRecords("user_application", "*", "user_id=@value1 and application_id=@value2 and process_id=@value3", value2)
                        If dr.HasRows Then
                            While dr.Read
                                Dim del As New pgConnect
                                del.DeleteRecord("user_application", dr("id"), "id=@value1")
                            End While
                        End If

                    End If

                End While
            End If


        Next


    End Sub

    Function get_pi_id(app As String)

        Try
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim dr As NpgsqlDataReader = conn.GetRecords("pi_fields", "*", "pi_name=@value1", app)
            If dr.HasRows Then
                While dr.Read
                    Return dr("id")
                End While
            End If
        Catch ex As IO.IOException
            Return 0
        End Try

        Return 0

    End Function



End Class