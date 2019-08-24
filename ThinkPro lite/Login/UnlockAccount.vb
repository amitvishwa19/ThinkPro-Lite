Public Class UnloAccount
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If txtEmplID.Text = Nothing Then
            Dim msg3 As MsgBoxResult = MsgBox("Please enter a valid employee id", vbInformation, "! Oops !")
            Exit Sub
        End If

        Dim Conn As New pgConnect
        Dim Var As New Encryption

        Dim EmpID As String = Var.EncryptNew(txtEmplID.Text)

        Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("user_details", "secret_ques1,secret_ques2,secret_ques3", "empl_id =@value1", EmpID)
        While reader.Read
            cmbquest.Items.Add(Var.decrypt(reader("secret_ques1")))
            cmbquest.Items.Add(Var.decrypt(reader("secret_ques2")))
            cmbquest.Items.Add(Var.decrypt(reader("secret_ques3")))
        End While

        cmbquest.Enabled = True
        txtsecans.Enabled = True
        cmdunlockaccount.Enabled = True
        cmdresetpass.Enabled = True
    End Sub

    Private Sub cmdunlockaccount_Click(sender As Object, e As EventArgs) Handles cmdunlockaccount.Click
        Dim logn As New LoginReg

        If logn.UnlockAccount(Trim(txtEmplID.Text), Trim(cmbquest.Text), Trim(txtsecans.Text)) = True Then
            Dim msg As MsgBoxResult = MsgBox("Account Unlocked Successfully", MsgBoxStyle.Information, "Hooray")
            Me.Close()
        Else
            Dim msg2 As MsgBoxResult = MsgBox("Secret answer is incorrect", MsgBoxStyle.Information, "Oops!")
        End If
    End Sub

    Private Sub txtEmplID_TextChanged(sender As Object, e As EventArgs) Handles txtEmplID.TextChanged
        If AppFunctions.RegExCheck(txtEmplID.Text, "^[0-9]*$") = False Then
            lblemplid.Text = "Invalid Empolyee ID"
        Else
            lblemplid.Text = Nothing
        End If
    End Sub

    Private Sub cmdresetpass_Click(sender As Object, e As EventArgs) Handles cmdresetpass.Click
        Dim logn As New LoginReg
        Dim TempPass As String
        TempPass = logn.RandomPaswrd()

        If txtsecans.Text = Nothing Then
            Dim msg As MsgBoxResult = MsgBox("Please provide secret answer", vbInformation, " Oops!")
            Exit Sub
        End If

        If logn.SecrectAnswerCheck(txtEmplID.Text, cmbquest.Text, txtsecans.Text) = True Then
            If logn.PawordReset(Trim(txtEmplID.Text), Trim(TempPass)) = True Then
                Dim msg2 As MsgBoxResult = MsgBox("Your Temproary pwd is:    " & TempPass & vbNewLine & vbNewLine &
                    "Temproary pwd is copied to clipboard", MsgBoxStyle.Information, "Hooray")
                Clipboard.SetText(TempPass)
                Me.Close()
            End If
        Else
            Dim msg3 As MsgBoxResult = MsgBox("Secret answer is incorrect", MsgBoxStyle.Information, "Oops!")
        End If

    End Sub
End Class