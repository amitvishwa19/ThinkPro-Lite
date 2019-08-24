


Public Class Changepwd

    Private Sub cmdChangePAss_Click(sender As Object, e As EventArgs) Handles cmdChangePAss.Click

        If txtEmplID.Text = Nothing Then
            Dim msg As MsgBoxResult = MsgBox("Please enter your User Id")
            txtEmplID.Focus()
            Exit Sub
        End If

        If txtOldpass.Text = Nothing Then
            Dim msg2 As MsgBoxResult = MsgBox("Please enter your old password")
            txtOldpass.Focus()
            Exit Sub
        End If

        If txtpass.Text = Nothing Then
            Dim msg3 As MsgBoxResult = MsgBox("Please enter your new password")
            txtpass.Focus()
            Exit Sub
        End If

        If txtconPass.Text = Nothing Then
            Dim msg4 As MsgBoxResult = MsgBox("Please enter your confirm password")
            txtconPass.Focus()
            Exit Sub
        End If

        If Trim(txtpass.Text) <> Trim(txtconPass.Text) Then
            Dim msg5 As MsgBoxResult = MsgBox("Confirm password not matched with password", vbInformation, "!Oops!")
            Exit Sub
        End If

        Dim Logn As New LoginReg
        If Logn.EmpIdCheck(txtEmplID.Text) = False Then
            If Logn.OldPasswordCheck(txtEmplID.Text, txtOldpass.Text) = True Then
                If Logn.PawordHistoryCheck(txtEmplID.Text, txtpass.Text) = True Then
                    If Logn.Change_Pasord(txtEmplID.Text, txtOldpass.Text, txtpass.Text) = True Then
                        Logn.PassToPassAudit(txtEmplID.Text, txtpass.Text)
                        Dim msg As MsgBoxResult = MsgBox("Password Changed Successfully", MsgBoxStyle.Information, "Hooray")
                        Home.txtID.Text = Nothing
                        Home.txtPass.Text = Nothing
                        Me.Close()
                    End If
                Else
                    Dim msg6 As MsgBoxResult = MsgBox("Unable to change password,Please refer TCS Password policy", vbInformation, "! Oops !")
                End If
            Else
                Dim msg6 As MsgBoxResult = MsgBox("Old password mismatch", vbInformation, "! Oops !")
                Exit Sub
            End If
        Else
            Dim msg7 As MsgBoxResult = MsgBox("You are not registered with ThinkPro,Please register", vbInformation, "! Oops !")
            Exit Sub
        End If



    End Sub

    Private Sub txtEmplID_TextChanged(sender As Object, e As EventArgs) Handles txtEmplID.TextChanged
        If AppFunctions.RegExCheck(txtEmplID.Text, "^[0-9]*$") = False Then
            lblemplid.Text = "Invalid Empolyee ID"
        Else
            lblemplid.Text = Nothing
        End If
    End Sub

    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged
        If AppFunctions.RegExCheck(txtpass.Text) = True Then
            lblnewpass.Text = Nothing
        Else
            lblnewpass.Text = "!!Please refer password policy !!"
        End If
    End Sub

    Private Sub txtconPass_TextChanged(sender As Object, e As EventArgs) Handles txtconPass.TextChanged
        If AppFunctions.RegExCheck(txtconPass.Text) = True Then
            lblconfirmpass.Text = Nothing
        Else
            lblconfirmpass.Text = "!!Please refer password policy !!"
        End If
    End Sub
End Class