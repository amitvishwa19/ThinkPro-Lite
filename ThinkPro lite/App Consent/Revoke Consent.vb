Imports Npgsql
Public Class Revoke_Consent

    Public userid As Integer = Nothing

    Private Sub Revoke_Consent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call consent_load()

    End Sub

    Private Sub consent_load()
        Consent_app.Clear()
        Consent_app.View = View.Details
        Consent_app.Columns.Add("", 30, HorizontalAlignment.Left)
        Consent_app.Columns.Add("Application Name", 150)
        Consent_app.Columns.Add("Application Description", 200)
        Consent_app.Columns.Add("PI Fields", 400)
        Consent_app.CheckBoxes = True
        'Consent_app.Columns(0).DisplayIndex = Consent_app.Columns.Count - 1

        Dim conn As New pgConnect
        Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1", userid)
        Dim row As String() = New String(4) {}
        Dim i As Integer = 0
        Dim item As ListViewItem
        While dr.Read


            Dim field_return As String = Nothing
            Dim app_con As New pgConnect
            Dim app As NpgsqlDataReader = app_con.GetRecords("applications", "*", "id=@value1", dr("application_id"))
            If app.HasRows Then
                While app.Read
                    row(1) = app("app_name")
                    row(2) = app("app_description")
                    row(3) = get_app_pi(app("id")).ToString


                End While
            End If

            item = New ListViewItem(row)

            Consent_app.Items.Add(item)
            Consent_app.Items(i).Tag = dr("application_id")
            Consent_app.Items(i).Checked = dr("application_consent")
            i += 1
        End While

        For i = 1 To Consent_app.Items.Count
            'Consent_app.Items(0).Checked = True
        Next i
    End Sub

    Private Function get_app_pi(app_id As Integer)
        Dim pi_fields As String = Nothing
        Dim position As Integer = 0
        Dim conn As New pgConnect
        Dim dr As NpgsqlDataReader = conn.GetRecords("application_pi", "*", "app_id=@value1", app_id)
        If dr.HasRows Then
            While dr.Read
                Dim pi_conn As New pgConnect
                Dim pi As NpgsqlDataReader = pi_conn.GetRecords("pi_fields", "*", "id=@value1", dr("pi_id"))
                If pi.HasRows Then
                    While pi.Read
                        If position = 0 Then
                            pi_fields += pi("pi_name")
                            position += 1
                        Else
                            pi_fields += ", " & pi("pi_name")
                            position += 1
                        End If
                    End While
                End If
            End While
        End If

        Return pi_fields

    End Function

    Private Sub sync_user_consent(user_id As Integer)

        Dim app_id As Integer = 0
        Dim comments As String = Nothing
        Dim u_comments As String = Nothing
        Dim msg As MsgBoxResult
        For i = 0 To Consent_app.Items.Count - 1
            app_id = Consent_app.Items(i).Tag
            If Consent_app.Items(i).Checked = False Then


                If on_revoke_check_for_supervisor_comment(user_id, Consent_app.Items(i).Tag) = False Then
                    comments = InputBox("Please provide a reason of revoking consent for " & Consent_app.Items(i).SubItems(1).Text, "Consent compliance")
                    If comments = "" Then
                        msg = MsgBox("Please proveide reason of revoking consent " & Consent_app.Items(i).SubItems(1).Text)
                        Exit Sub
                    End If
                Else
                    comments = get_supevisor_comment(user_id, app_id)
                End If

            End If

            Dim conn As New pgConnect
            Dim value As String = Consent_app.Items(i).Checked & "^" & comments & "^" & user_id & "^" & app_id
            conn.UpdateRecord("user_application", "application_consent=@value1,supervisor_comment=@value2", value, "user_id=@value3 and application_id=@value4")
            comments = Nothing

        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call sync_user_consent(userid)
        Call consent_load()
        Me.Close()
        NewUser.list_view_load()

    End Sub
End Class