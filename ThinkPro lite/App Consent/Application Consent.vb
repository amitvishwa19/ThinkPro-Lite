Imports Npgsql
Public Class Application_Consent
    Const str As String = "https://iqmskm.ultimatix.net/km/index.php?title=Privacy_Policy"
    Public userid As Integer = Nothing
    Public processid As Integer = Nothing
    Dim appid As Integer = Nothing

    Public openas As String = Nothing

    Private Sub Application_Consent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call list_view_load()
        Call load_color()

    End Sub
    Private Sub list_view_load()
        Try
            userid = get_user_id()
            processid = get_process_id()
            'MsgBox(userid)
            'MsgBox("✋ Hi! from Thinkpro")
            Consent_app.Clear()
            Consent_app.View = View.Details
            Consent_app.Columns.Add("", 30, HorizontalAlignment.Left)
            Consent_app.Columns.Add("Application Name", 150)
            Consent_app.Columns.Add("Application Description", 200)
            Consent_app.Columns.Add("Application Purpose", 200)
            Consent_app.Columns.Add("PI Fields", 400)
            Consent_app.CheckBoxes = True
            'Consent_app.Columns(0).DisplayIndex = Consent_app.Columns.Count - 1

            Dim conn As New pgConnect
            Dim str As String = userid & "^" & processid & "^" & True
            Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1 and process_id=@value2 and status=@value3", str)
            Dim row As String() = New String(4) {}
            Dim i As Integer = 0
            Dim item As ListViewItem
            While dr.Read


                Dim field_return As String = Nothing
                Dim app_con As New pgConnect
                Dim app As NpgsqlDataReader = app_con.GetRecords("applications", "*", "id=@value1", dr("application_id"))
                If app.HasRows Then
                    While app.Read
                        row(1) = app("app_name").ToString
                        row(2) = app("app_description").ToString
                        row(3) = app("app_purpose").ToString
                        row(4) = get_app_pi(app("id"))
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

            Call consent_text_praise()

            If openas = "view" Then
                Consent_app.CheckBoxes = False
                Consent_app.Columns.RemoveByKey(0)
                consentnote.Visible = False
                agree_checkbox.Visible = False
                cmd_continue.Visible = False
                Me.ControlBox = True
            End If
        Catch ex As IO.IOException
            '     Dim msg As MsgBoxResult
            '         msg = MsgBox(ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub load_color()
        For i As Integer = 0 To Consent_app.Items.Count - 1
            appid = Consent_app.Items(i).Tag
            Dim comment As String = get_user_comment(userid, appid)

            If Consent_app.Items(i).Checked = True Then
                Consent_app.Items(i).BackColor = Color.Green
            End If

            If Consent_app.Items(i).Checked = False And comment <> "" Then
                Consent_app.Items(i).BackColor = Color.Orange
            End If

            If Consent_app.Items(i).Checked = False And comment = "" Then
                Consent_app.Items(i).BackColor = Color.Red
            End If

            comment = Nothing
        Next
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

    Private Sub consent_text_praise()
        Dim consent_text As String = Nothing
        Dim consent_text_final As String = Nothing
        Dim app_user As String = Nothing
        Dim sup_name As String = Nothing
        Dim sup_email As String = Nothing
        Dim conn As New pgConnect
        Dim dr As NpgsqlDataReader = conn.GetRecords("consent", "*")
        While dr.Read
            consent_text = dr("consent_text")
        End While

        Dim crypt As New Encryption
        Dim uconn As New pgConnect
        Dim udr As NpgsqlDataReader = uconn.GetRecords("user_details", "*", "user_id=@value1", userid)
        While udr.Read
            app_user = crypt.decrypt(udr("first_name")) & "," & crypt.decrypt(udr("last_name"))
        End While

        app_consent_text.Text = consent_text.Replace("@user", app_user)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles agree_checkbox.CheckedChanged

        If agree_checkbox.Checked Then

            cmd_continue.Text = "Continue"
        Else
            cmd_continue.Text = "Decline"

        End If
    End Sub

    Private Sub sync_user_consent(user_id As Integer)
        Dim msg1 As MsgBoxResult
        Try
            Dim app_id As Integer = 0
            Dim processid As Integer = 0
            Dim comments As String = Nothing
            Dim s_comments As String = Nothing
            For i = 0 To Consent_app.Items.Count - 1
                app_id = Consent_app.Items(i).Tag

                If Consent_app.Items(i).Checked = False Then
                    If on_consent_check_for_user_comment(user_id, app_id) = False Then
                        comments = InputBox("Please provide a reason for non exceptance of consent for " & Consent_app.Items(i).SubItems(1).Text, "Consent compliance")
                        s_comments = get_supevisor_comment(user_id, app_id)
                        If comments = "" Then
                            msg1 = MsgBox("Please proveide reason of non Acceptance of consent for " & Consent_app.Items(i).SubItems(1).Text)
                            Exit Sub
                        End If
                    Else
                        comments = get_user_comment(user_id, app_id)
                        s_comments = get_supevisor_comment(user_id, app_id)
                    End If
                Else
                    s_comments = get_supevisor_comment(user_id, app_id)

                End If

                processid = get_process_id()
                Dim conn As New pgConnect
                Dim value As String = Consent_app.Items(i).Checked & "^" & comments & "^" & s_comments & "^" & user_id & "^" & app_id & "^" & processid
                conn.UpdateRecord("user_application", "application_consent=@value1,user_comment=@value2,supervisor_comment=@value3", value, "user_id=@value4 and application_id=@value5 and process_id=@value6")
                comments = Nothing


            Next

            Me.Close()
            Home.Enabled = True
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub cmdAccept_Click(sender As Object, e As EventArgs)
        sync_user_consent(userid)
        'NewUser.list_view_load()
    End Sub

    Private Sub cmdDecline_Click(sender As Object, e As EventArgs)
        sync_user_consent(userid)
        'NewUser.list_view_load()
        'Me.Close()
    End Sub

    Private Sub privacy_policy_link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles privacy_policy_link.LinkClicked

        System.Diagnostics.Process.Start(str)
    End Sub

    Private Sub cmd_continue_Click(sender As Object, e As EventArgs) Handles cmd_continue.Click
        Dim msg As New MsgBoxResult
        If agree_checkbox.Checked Then
            sync_user_consent(userid)
            Home.Activate()
        Else
            'cmdAccept.Enabled = False
            msg = MsgBox("You have not Accepted or Declined the consent,kindly provide consent for assigned application to you" & vbNewLine &
                "Application will close now and consent screen will visible again next time when you log in to this application")
            Application.Exit()
        End If


    End Sub
End Class