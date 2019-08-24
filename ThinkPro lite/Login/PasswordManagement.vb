Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class PasswordManagement
#Region "Login Border"

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.SkyBlue, rect)
    End Sub

#End Region
    Private Sub Forgotpassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As EventArgs) Handles cmdGo.Click

        Dim iID As String

        iID = txtID.Text

        If IsNumeric(iID) Then
            ErrorProviderError.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "Valid Username")
            cmdGo.Enabled = True
        Else
            ErrorProviderError.SetError(txtID, "Invalid Username,Enter Employee ID")

            Exit Sub
        End If


        If txtID.Text = String.Empty Then
            ErrorProviderError.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtID, "Enter Valid User ID")
        End If

        Try

            Dim Var As New Encryption
            Var.Encrypt(txtID.Text)
            Dim eid As String = Var.encr

            Dim Conn As New pgConnect
            Dim Logn As New LoginReg
            If Logn.EmpIdCheck(txtID.Text) = False Then

            Else
                ErrorProviderok.SetError(txtID, "")
                ErrorProviderWarning.SetError(txtID, "")
                ErrorProviderError.SetError(txtID, "User account not found, Check username")
                Exit Sub
            End If


            Conn.Connect()
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("user_details", "secret_ques1,secret_ques2,secret_ques3", "empl_id =@value1", eid)
            While reader.Read
                cmbquest.Items.Add(Var.decrypt(reader("secret_ques1")))
                cmbquest.Items.Add(Var.decrypt(reader("secret_ques2")))
                cmbquest.Items.Add(Var.decrypt(reader("secret_ques3")))
            End While


            rdChange_Pasord.Enabled = True
            rdUnlockAccount.Enabled = True
        Catch ex As IO.IOException
            '  msg = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Private Sub cmdunlockaccount_Click(sender As Object, e As EventArgs) Handles cmdunlockaccount.Click

        If cmbquest.Text = "" Then
            cmbquest.Focus()
            Dim msg As MsgBoxResult = MsgBox("Please select secret question", MsgBoxStyle.OkOnly, "Secret question")
            Exit Sub
        End If



        If txtsecans.Text = "" Then
            txtsecans.Focus()
            Dim msg2 As MsgBoxResult = MsgBox("Secret answer is blank", MsgBoxStyle.OkOnly, "Secret answer")
            Exit Sub
        End If


        Dim logn As New LoginReg

        If logn.UnlockAccount(txtID.Text, cmbquest.Text, txtsecans.Text) = True Then
            Dim msg3 As MsgBoxResult = MsgBox("Account Unlocked Successfully", MsgBoxStyle.Information, "Hooray")
            Me.Close()
        Else
            Dim msg4 As MsgBoxResult = MsgBox("Secret answer is incorrect", MsgBoxStyle.Information, "Oops!")
        End If

    End Sub 'Required

    Private Sub txtpass_LostFocus(sender As Object, e As EventArgs) Handles txtpass.LostFocus
        Dim MatchNumberPattern As String = "^.*(?=.{10,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=*]).*$"
        If txtpass.Text.Trim <> "" Then
            If Not Regex.IsMatch(txtpass.Text, MatchNumberPattern) Then

                ErrorProviderok.SetError(txtpass, "")
                ErrorProviderWarning.SetError(txtpass, "")
                ErrorProviderError.SetError(txtpass, "!! Entered password did not comply with TCS Password policy,Kindly refer to TCS password policy!!" & vbNewLine & vbNewLine &
                "**Password Policy**" & vbNewLine &
                "=>Your password should have" & vbNewLine &
                "Atleast 8 characters nad not more than 15 characters" & vbNewLine &
                "Atleast one uppercase character (A-Z)" & vbNewLine &
                "Atleast one lowercase character (a-z)" & vbNewLine &
                "Atleast one number (0-9)" & vbNewLine &
                "Atleast one special character out of this (!,@,#,$,^,&,*,~)" & "")
                cmdunlockaccount.Enabled = False
                cmdChangePAss.Enabled = False

                'txtpass.Focus()
            Else
                ErrorProviderWarning.SetError(txtpass, "")
                ErrorProviderError.SetError(txtpass, "")
                ErrorProviderok.SetError(txtpass, "ok")
                cmdunlockaccount.Enabled = True
                cmdChangePAss.Enabled = True

            End If
        End If
    End Sub

    Private Sub txtconPass_GotFocus(sender As Object, e As EventArgs) Handles txtconPass.GotFocus
        If txtpass.Text = "" Then
            ErrorProviderok.SetError(txtpass, "")
            ErrorProviderWarning.SetError(txtpass, "")
            ErrorProviderError.SetError(txtpass, "Enter Password")
            cmdunlockaccount.Enabled = False
            cmdChangePAss.Enabled = False
        Else
            ErrorProviderWarning.SetError(txtpass, "")
            ErrorProviderError.SetError(txtpass, "")
            ErrorProviderok.SetError(txtpass, "")
            cmdunlockaccount.Enabled = True
            cmdChangePAss.Enabled = True
        End If
    End Sub

    Private Sub txtconPass_LostFocus(sender As Object, e As EventArgs) Handles txtconPass.LostFocus


        If txtpass.Text <> txtconPass.Text Then
            ErrorProviderok.SetError(txtconPass, "")
            ErrorProviderWarning.SetError(txtconPass, "")
            ErrorProviderError.SetError(txtconPass, "!! Password mismatch,Confirm Password!!")
            cmdunlockaccount.Enabled = False
            cmdChangePAss.Enabled = False
        Else
            ErrorProviderWarning.SetError(txtconPass, "")
            ErrorProviderError.SetError(txtconPass, "")
            ErrorProviderok.SetError(txtconPass, "")
            cmdunlockaccount.Enabled = True
            cmdChangePAss.Enabled = True
        End If
    End Sub

    Private Sub cmdChangePAss_Click(sender As Object, e As EventArgs) Handles cmdChangePAss.Click

        Dim msg1, msg3 As MsgBoxResult
        If txtpass.Text = "" Then
            txtpass.Focus()
            msg3 = MsgBox("Password field is blank", MsgBoxStyle.OkOnly, "Password")
            Exit Sub
        End If

        If txtconPass.Text = "" Then
            txtconPass.Focus()
            msg1 = MsgBox("Confirm Password field is blank", MsgBoxStyle.OkOnly, "Confirm Password")
            Exit Sub
        End If


        If txtpass.Text <> txtconPass.Text Then
            ErrorProviderok.SetError(txtpass, "")
            ErrorProviderWarning.SetError(txtpass, "")
            ErrorProviderError.SetError(txtpass, "!! Password mismatch,Confirm Password!!")
            Exit Sub
        Else
            ErrorProviderWarning.SetError(txtpass, "")
            ErrorProviderError.SetError(txtpass, "")
            ErrorProviderok.SetError(txtpass, "Password Matched")

            Dim conn As New LoginReg
            If conn.Change_PasordCheck(txtID.Text, txtpass.Text) = False Then
                Dim msg As MsgBoxResult = MsgBox("Please refer TCS password policy,Please enter password which is not used before for last 3 times", MsgBoxStyle.Critical, "Oops")
                Exit Sub
            Else
                Dim Logn As New LoginReg
                If Logn.Change_Pasord(txtID.Text, txtOldpass.Text, txtpass.Text) = True Then
                    Dim lgn As New LoginReg
                    lgn.PassToPassAudit(txtID.Text, txtpass.Text)
                    Dim msg4 As MsgBoxResult = MsgBox("Password Changed Successfully", MsgBoxStyle.Information, "Hooray")
                Else
                    Dim msg5 As MsgBoxResult = MsgBox("Incorrect Old Password", MsgBoxStyle.Information, "Oops")
                End If
            End If

        End If

    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdGo.Focus()
        End If
    End Sub 'Required

    Private Sub txtID_LostFocus(sender As Object, e As EventArgs) Handles txtID.LostFocus
        Dim iID As String
        iID = txtID.Text

        If IsNumeric(iID) Then
            ErrorProviderError.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "Valid Username")
            cmdGo.Enabled = True
        Else
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "")
            ErrorProviderError.SetError(txtID, "Invalid Username,Enter Employee ID")
            cmdGo.Enabled = False
        End If


        If txtID.Text = String.Empty Then
            ErrorProviderError.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtID, "Enter Valid User ID")
        End If

    End Sub

    Private Sub txtID_StyleChanged(sender As Object, e As EventArgs) Handles txtID.StyleChanged

    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Dim iID As String
        iID = txtID.Text

        If IsNumeric(iID) Then
            ErrorProviderError.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "Valid Username")
            cmdGo.Enabled = True
        Else
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderok.SetError(txtID, "")
            ErrorProviderError.SetError(txtID, "Invalid Username,Enter Employee ID")
            cmdGo.Enabled = False
        End If
    End Sub





    Private Sub rdUnlockAccount_CheckedChanged(sender As Object, e As EventArgs) Handles rdUnlockAccount.CheckedChanged
        If rdUnlockAccount.Checked = True Then
            'grppass.Enabled = True
            grpUnlockAccount.Enabled = True

        Else
            'grppass.Enabled = True
            grpUnlockAccount.Enabled = False

        End If
    End Sub

    Private Sub rdResetPassword_CheckedChanged(sender As Object, e As EventArgs) Handles rdResetPassword.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class