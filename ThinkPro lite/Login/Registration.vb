Imports System.Data.OleDb
Imports System.Text.RegularExpressions


Public Class Registration
    Dim loginerror As String
    Public UnameDB As String  '-------------------Employee Name
    Public EmpDB As String  '---------------------Employee ID
    Dim ProjectID As Integer
    Public RegistrationType As String = "Associate"

#Region "Form Startup Border"

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.SkyBlue, rect)
    End Sub

#End Region

    Private Sub FrmRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.fillProject()
        Me.Secretquestion1()
        Me.secretquestion2()
        Me.secretquestion3()

    End Sub

    Sub fillProject()
        Try
            Dim conn As New pgConnect
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT project")
            cmbProject.Items.Clear()
            While reader.Read
                cmbProject.Items.Add(reader("project"))
            End While
            reader.Dispose()

        Catch ex As IO.IOException

        End Try
    End Sub 'Required

    Sub fillProcess()
        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT process", "project =@value1", value)
            cmbProcess.Items.Clear()
            While reader.Read
                cmbProcess.Items.Add(reader("process"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException

        End Try
    End Sub 'Required

    Sub fillSubProcess()

        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text & "^" & cmbProcess.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT sub_process", "project =@value1 AND process=@value2", value)
            cmbSubProcess.Items.Clear()
            While reader.Read
                cmbSubProcess.Items.Add(reader("sub_process"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException

        End Try
    End Sub 'Required

    Private Sub Secretquestion1()

        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("app_option", "DISTINCT secret_question")
            cmbquest1.Items.Clear()
            While reader.Read
                cmbquest1.Items.Add(reader("secret_question"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException

        End Try

    End Sub 'Required

    Private Sub secretquestion2()
        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("app_option", "DISTINCT secret_question")
            cmbquest2.Items.Clear()
            While reader.Read
                cmbquest2.Items.Add(reader("secret_question"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException

        End Try

    End Sub 'Required

    Private Sub secretquestion3()

        Try
            Dim conn As New pgConnect
            Dim value As String = cmbProject.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("app_option", "DISTINCT secret_question")
            cmbquest3.Items.Clear()
            While reader.Read
                cmbquest3.Items.Add(reader("secret_question"))
            End While
            reader.Dispose()
        Catch ex As IO.IOException

        End Try

    End Sub 'Required

    Sub cmdRegisterMe_Click(sender As Object, e As EventArgs) Handles cmdRegisterMe.Click

        If txtEmpID.Text = Nothing Then
            Dim res As MsgBoxResult = MsgBox("Employee id missing")
            txtEmpID.Focus()
            Exit Sub
        End If

        If Int(txtEmpID.Text) Then
            Dim emp As Integer = txtEmpID.Text
            Dim login As New LoginReg
            If login.EmpIdCheck(emp) = True Then
                Call Registerme()

            Else
                Dim res1 As MsgBoxResult = MsgBox("!! Dear user you are already Registered!! Please Login " & vbNewLine &
                "If you forget your password then Kindly contact Administrator to reset password")
            End If
        Else
            Dim res2 As MsgBoxResult = MsgBox("Employee id is not valid, kindly check")
        End If


        

    End Sub 'Required

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged

        If Charcheck(txtFirstName.Text) = False Then
            CharError(txtFirstName)
        Else
            CharOk(txtFirstName)
        End If
       
        txtname.Text = txtFirstName.Text & "," & txtLastName.Text
    End Sub

    Function Charcheck(Str As String) As Boolean

        If Regex.IsMatch(Str, "^[a-zA-Z0-9]+$") Then
            cmdRegisterMe.Enabled = True
            Return True
        ElseIf Str.Length > 20 Then
            cmdRegisterMe.Enabled = False
            Return True
        Else
            cmdRegisterMe.Enabled = False
            Return False
        End If

    End Function

    Sub CharError(cont As Control)

        If cont.Text = "" Then
            ErrorProviderok.SetError(cont, "")
            ErrorProviderWarning.SetError(cont, "")
            ErrorProviderError.SetError(cont, "")

        Else
            ErrorProviderok.SetError(cont, "")
            ErrorProviderWarning.SetError(cont, "")
            ErrorProviderError.SetError(cont, "Please enter only alphanumeric character i.e. a-z,A-Z,0-9")

        End If

    End Sub

    Sub CharOk(cont As Control)
        ErrorProviderok.SetError(cont, "")
        ErrorProviderWarning.SetError(cont, "")
        ErrorProviderError.SetError(cont, "")
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged

        If Charcheck(txtLastName.Text) = False Then
            CharError(txtLastName)
        Else
            CharOk(txtLastName)
        End If

        txtname.Text = txtFirstName.Text & "," & txtLastName.Text
    End Sub

    Public Function IDCheck()


        Dim conn As New pgConnect
        Dim emplid As Integer = txtEmpID.Text
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "empl_id", "empl_id =@value1", emplid)
        If reader.HasRows Then
            ErrorProviderok.SetError(txtEmpID, "")
            ErrorProviderWarning.SetError(txtEmpID, "")
            ErrorProviderError.SetError(txtEmpID, "!! Dear " & emplid & " you are already Registered!! Please Login " & vbNewLine & _
            "If you forget your password then Kindly contact Administrator to reset password")
            cmdRegisterMe.Enabled = False
            Return True
        Else
            cmdRegisterMe.Enabled = True
            ErrorProviderWarning.SetError(txtEmpID, "")
            ErrorProviderError.SetError(txtEmpID, "")
            ErrorProviderok.SetError(txtEmpID, txtEmpID.Text)
            Return False
        End If

    End Function 'Required

    Sub Registerme()

        Dim login As New LoginReg


        'Check All Fields
        If txtEmpID.Text = "" Then
            txtEmpID.Focus()
            Dim msg1 As MsgBoxResult = MsgBox("Employee ID is Missing,", MsgBoxStyle.OkOnly, "Employee ID")
            Exit Sub
        ElseIf txtFirstName.Text = "" Then
            txtFirstName.Focus()
            Dim msg2 As MsgBoxResult = MsgBox("First Name is Missing,", MsgBoxStyle.OkOnly, "First Name")
            Exit Sub
        ElseIf txtLastName.Text = "" Then
            txtLastName.Focus()
            Dim msg3 As MsgBoxResult = MsgBox("Last Name is Missing,", MsgBoxStyle.OkOnly, "Last Name")
            Exit Sub
        ElseIf cmbProject.Text = "" Then
            cmbProject.Focus()
            Dim msg4 As MsgBoxResult = MsgBox("Project not Selected,", MsgBoxStyle.OkOnly, "Project")
            Exit Sub
        ElseIf cmbProcess.Text = "" Then
            cmbProcess.Focus()
            Dim msg5 As MsgBoxResult = MsgBox("Process not Selected,", MsgBoxStyle.OkOnly, "Process")
            Exit Sub
        ElseIf cmbSubProcess.Text = "" Then
            cmbProcess.Focus()
            Dim msg6 As MsgBoxResult = MsgBox("Sub Process not Selected,", MsgBoxStyle.OkOnly, "Sub Process")
            Exit Sub
        ElseIf txtPassWW.Text = "" Then
            txtPassWW.Focus()
            Dim msg8 As MsgBoxResult = MsgBox("Password not Mentioned,", MsgBoxStyle.OkOnly, "Password")
            Exit Sub
        ElseIf txtPassWW.Text <> txtPasswordcnf.Text Then
            Dim msg7 As MsgBoxResult = MsgBox("Password not match,", MsgBoxStyle.OkOnly, "Password Mismatch")
            txtPasswordcnf.Text = ""
            txtPasswordcnf.Focus()
            Exit Sub
        ElseIf cmbquest1.Text = "" Then
            cmbquest1.Focus()
            Dim msg9 As MsgBoxResult = MsgBox("Secret question 1 not selected", MsgBoxStyle.OkOnly, "Secret question 1")
            Exit Sub
        ElseIf cmbquest2.Text = "" Then
            cmbquest2.Focus()
            Dim msg10 As MsgBoxResult = MsgBox("Secret question 2 not selected", MsgBoxStyle.OkOnly, "Secret question 2")
            Exit Sub
        ElseIf cmbquest3.Text = "" Then
            cmbquest3.Focus()
            Dim msg11 As MsgBoxResult = MsgBox("Secret question 3 not selected", MsgBoxStyle.OkOnly, "Secret question 3")
            Exit Sub
        ElseIf txtsecans1.Text = "" Then
            txtsecans1.Focus()
            Dim msg12 As MsgBoxResult = MsgBox("Secret answer 1 is blank", MsgBoxStyle.OkOnly, "Secret answer 1")
            Exit Sub
        ElseIf txtsecans2.Text = "" Then
            txtsecans2.Focus()
            Dim msg13 As MsgBoxResult = MsgBox("Secret answer 2 is blank", MsgBoxStyle.OkOnly, "Secret answer 2")
            Exit Sub
        ElseIf txtsecans3.Text = "" Then
            txtsecans3.Focus()
            Dim msg14 As MsgBoxResult = MsgBox("Secret answer 3 is blank", MsgBoxStyle.OkOnly, "Secret answer 3")
            Exit Sub
        End If

        Try
            login.register(txtFirstName.Text,
                           txtLastName.Text,
                           ProjectID,
                           cmbProject.Text,
                           cmbProcess.Text,
                           cmbSubProcess.Text,
                           txtEmpID.Text,
                           txtPassWW.Text,
                           cmbquest1.Text,
                           cmbquest2.Text,
                           cmbquest3.Text,
                           txtsecans1.Text,
                           txtsecans2.Text,
                           txtsecans3.Text)
            login.ProfileCreator(txtEmpID.Text, txtFirstName.Text & "," & txtLastName.Text, ProjectID, cmbProject.Text, cmbProcess.Text, cmbSubProcess.Text, "Default", cmbProcess.Text & "-" & cmbSubProcess.Text)

            Dim msg15 As MsgBoxResult = MsgBox("Welcome " & txtname.Text & ", Registration Successfull,Please Complete your profile", vbInformation, "Registration Success")
            Me.Close()
        Catch ex As IO.IOException
            '     Dim msg16 As MsgBoxResult = MsgBox(ex.Message)
            'Call Errorlog.Errorlog()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Required

    Private Sub txtEmpID_LostFocus(sender As Object, e As EventArgs) Handles txtEmpID.LostFocus

        If IDLengthCheck() = True Then
            Exit Sub
        End If

        If txtEmpID.Text <> "" Then
            Call IDCheck()
        End If

        IDLengthCheck()

    End Sub 'Required

    Private Sub cmbquest1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbquest1.SelectedIndexChanged

        Try



            'For i = 0 To cmbquest2.Items.Count - 1
            '    If cmbquest2.Items(i).ToString = cmbquest1.SelectedItem.ToString Then
            '        'cmbquest2.Items.Remove(cmbquest1.SelectedItem.ToString)
            '        'cmbquest3.Items.Remove(cmbquest1.SelectedItem.ToString)

            '    End If
            'Next

            cmbquest2.Items.Remove(cmbquest1.SelectedItem.ToString)
            cmbquest3.Items.Remove(cmbquest1.SelectedItem.ToString)


        Catch ex As Exception
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try



    End Sub 'Required

    Private Sub cmbquest2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbquest2.SelectedIndexChanged

        Try
            'For i = 0 To cmbquest3.Items.Count - 1
            '    If cmbquest3.Items(i).ToString = cmbquest2.SelectedItem.ToString Then
            '        cmbquest3.Items.Remove(cmbquest2.SelectedItem.ToString)
            '        cmbquest1.Items.Remove(cmbquest2.SelectedItem.ToString)
            '    End If
            'Next
            cmbquest3.Items.Remove(cmbquest2.SelectedItem.ToString)
            cmbquest1.Items.Remove(cmbquest2.SelectedItem.ToString)
        Catch ex As Exception
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub 'Required

    Private Sub cmbquest3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbquest3.SelectedIndexChanged

        ''''After selecting combobox it will remove selected item form other twoo combo box

        Try
            'For i = 0 To cmbquest1.Items.Count - 1
            '    If cmbquest1.Items(i).ToString = cmbquest3.SelectedItem.ToString Then
            '        cmbquest1.Items.Remove(cmbquest3.SelectedItem.ToString)
            '        cmbquest2.Items.Remove(cmbquest3.SelectedItem.ToString)
            '    End If
            'Next
            cmbquest1.Items.Remove(cmbquest3.SelectedItem.ToString)
            cmbquest2.Items.Remove(cmbquest3.SelectedItem.ToString)
        Catch ex As Exception
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassWW.LostFocus
        Dim MatchNumberPattern As String = "^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=*]).*$"
        If txtPassWW.Text.Trim <> "" Then
            If Not Regex.IsMatch(txtPassWW.Text, MatchNumberPattern) Then

                ErrorProviderok.SetError(txtPassWW, "")
                ErrorProviderWarning.SetError(txtPassWW, "")
                ErrorProviderError.SetError(txtPassWW, "!! Entered password did not comply with TCS Password policy,Kindly refer to TCS password policy!!" & vbNewLine & vbNewLine &
                "**Password Policy**" & vbNewLine &
                "=>Your password should have" & vbNewLine &
                "Atleast 8 characters nad not more than 15 characters" & vbNewLine &
                "Atleast one uppercase character (A-Z)" & vbNewLine &
                "Atleast one lowercase character (a-z)" & vbNewLine &
                "Atleast one number (0-9)" & vbNewLine &
                "Atleast one special character out of this (!,@,#,$,^,&,*,~)" & "")

                txtPassWW.Focus()
            Else
                ErrorProviderWarning.SetError(txtPassWW, "")
                ErrorProviderError.SetError(txtPassWW, "")
                ErrorProviderok.SetError(txtPassWW, "ok")

            End If
        End If
    End Sub

    Private Sub txtPasswordcnf_LostFocus(sender As Object, e As EventArgs) Handles txtPasswordcnf.LostFocus

        If txtPassWW.Text <> txtPasswordcnf.Text Then
            ErrorProviderok.SetError(txtPasswordcnf, "")
            ErrorProviderWarning.SetError(txtPasswordcnf, "")
            ErrorProviderError.SetError(txtPasswordcnf, "!! Password mismatch,Confirm Password!!")
        Else
            ErrorProviderWarning.SetError(txtPasswordcnf, "")
            ErrorProviderError.SetError(txtPasswordcnf, "")
            ErrorProviderok.SetError(txtPasswordcnf, "Password Matched")
        End If

    End Sub 'Required

    Private Sub txtEmpID_TextChanged(sender As Object, e As EventArgs) Handles txtEmpID.TextChanged
        Dim iID As String
        iID = txtEmpID.Text


        If txtEmpID.TextLength > 8 Then
            ErrorProviderError.SetError(txtEmpID, "")
            ErrorProviderok.SetError(txtEmpID, "")
            ErrorProviderWarning.SetError(txtEmpID, "Enter Valid Employee ID,Length 8 digits")
            cmdRegisterMe.Enabled = False
            Exit Sub
            cmdRegisterMe.Enabled = True
        Else
        End If

        If IsNumeric(iID) Then
            ErrorProviderError.SetError(txtEmpID, "")
            ErrorProviderWarning.SetError(txtEmpID, "")
            ErrorProviderok.SetError(txtEmpID, "Valid Username")
            cmdRegisterMe.Enabled = True
        Else
            ErrorProviderok.SetError(txtEmpID, "")
            ErrorProviderWarning.SetError(txtEmpID, "")
            ErrorProviderError.SetError(txtEmpID, "Invalid Username,Enter Employee ID")
            cmdRegisterMe.Enabled = False
        End If


    End Sub

    Function IDLengthCheck()
        If txtEmpID.TextLength > 8 Then
            ErrorProviderError.SetError(txtEmpID, "")
            ErrorProviderok.SetError(txtEmpID, "")
            ErrorProviderWarning.SetError(txtEmpID, "Enter Valid Employee ID,Length 8 digits")
            Return True
        End If

        Return False
        Exit Function

    End Function 'Required

    Private Sub txtsecans1_TextChanged(sender As Object, e As EventArgs) Handles txtsecans1.TextChanged
        If Charcheck(txtsecans1.Text) = False Then
            CharError(txtsecans1)
        Else
            CharOk(txtsecans1)
        End If
    End Sub

    Private Sub txtsecans2_TextChanged(sender As Object, e As EventArgs) Handles txtsecans2.TextChanged
        If Charcheck(txtsecans2.Text) = False Then
            CharError(txtsecans2)
        Else
            CharOk(txtsecans2)
        End If
    End Sub

    Private Sub txtsecans3_TextChanged(sender As Object, e As EventArgs) Handles txtsecans3.TextChanged
        If Charcheck(txtsecans3.Text) = False Then
            CharError(txtsecans3)
        Else
            CharOk(txtsecans3)
        End If
    End Sub

    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        cmbProcess.Items.Clear()
        Call fillProcess()
    End Sub

    Private Sub cmbProcess_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcess.SelectedIndexChanged
        cmbSubProcess.Items.Clear()
        Call fillSubProcess()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Home.Show()
    End Sub

    Private Sub txtPassWW_TextChanged(sender As Object, e As EventArgs) Handles txtPassWW.TextChanged
        Dim Logn As New LoginReg
        If Logn.Pa_wordCheck(txtPassWW.Text) = False Then
            ErrorProviderok.SetError(txtPassWW, "")
            ErrorProviderWarning.SetError(txtPassWW, "")
            ErrorProviderError.SetError(txtPassWW, "!! Entered password did not comply with TCS Password policy,Kindly refer to TCS password policy!!" & vbNewLine & vbNewLine &
            "**Password Policy**" & vbNewLine &
            "=>Your password should have" & vbNewLine &
            "Atleast 8 characters nad not more than 15 characters" & vbNewLine &
            "Atleast one uppercase character (A-Z)" & vbNewLine &
            "Atleast one lowercase character (a-z)" & vbNewLine &
            "Atleast one number (0-9)" & vbNewLine &
            "Atleast one special character out of this (!,@,#,$,^,&,*,~)" & "")
        Else

            ErrorProviderWarning.SetError(txtPassWW, "")
            ErrorProviderError.SetError(txtPassWW, "")
            ErrorProviderok.SetError(txtPassWW, "ok")
        End If

    End Sub

    Private Sub cmbSubProcess_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubProcess.SelectedIndexChanged

        Dim conn As New pgConnect
        Dim value As String = cmbProject.Text & "^" & cmbProcess.Text & "^" & cmbSubProcess.Text
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("project_details", "project_id", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
        While reader.Read
            ProjectID = reader("project_id")
        End While

    End Sub 'Required



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ProjectCreator.Show()
    End Sub

    Private Sub txtPasswordcnf_TextChanged(sender As Object, e As EventArgs) Handles txtPasswordcnf.TextChanged

    End Sub
End Class