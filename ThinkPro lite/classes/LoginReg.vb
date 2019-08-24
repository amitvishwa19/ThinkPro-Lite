Imports Npgsql
Imports NpgsqlTypes
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Public Class LoginReg


    Public Function EmpIdCheck(EmplID As String)
        Dim conn As New pgConnect
        Try
            Dim Var As New Encryption
            Var.Encrypt(EmplID)
            Dim eid As String = Var.encr


            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "empl_id", "empl_id =@value1", eid)
            If reader.HasRows Then
                Return False
            Else
                Return True
            End If
        Catch ex As IO.IOException
            Return False
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try
    End Function
    Sub register(firstname As String,
                 lastname As String,
                 projectID As Integer,
                 project As String,
                 process As String,
                 subprocess As String,
                 emplid As Integer,
                 passWo As String,
                 secretques1 As String,
                 secretques2 As String,
                 secretques3 As String,
                 secretans1 As String,
                 secretans2 As String,
                 secretans3 As String)

        Dim mTS As DateTime = DateTime.Now


        Dim Var As New Encryption
        Var.Encrypt(firstname)
        Dim FName As String = Var.encr
        Var.Encrypt(lastname)
        Dim LName As String = Var.encr
        Var.Encrypt(emplid)
        Dim eid As String = Var.encr
        Var.Encrypt(passWo)
        Dim pwd As String = Var.encr
        Var.Encrypt(secretques1)
        Dim sq1 As String = Var.encr
        Var.Encrypt(secretques2)
        Dim sq2 As String = Var.encr
        Var.Encrypt(secretques3)
        Dim sq3 As String = Var.encr
        Var.Encrypt(secretans1)
        Dim sa1 As String = Var.encr
        Var.Encrypt(secretans2)
        Dim sa2 As String = Var.encr
        Var.Encrypt(secretans3)
        Dim sa3 As String = Var.encr

        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pwd)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim sb64 As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        If Registration.RegistrationType = "Associate" Then

            conn.InsertRecord("user_details",
                          "first_name,last_name,project_id,project,process,sub_process,account_type,account_status,login_attempt,empl_id,password,password_type,password_change_date,secret_ques1,secret_answer1,secret_ques2,secret_answer2,secret_ques3,secret_answer3",
                          "" & FName & "^" & LName & "^" & projectID & "^" & project & "^" & process & "^" & subprocess & "^Associate^InActive^" & 0 & "^" & eid & "^" & sb64 & "^user^" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & sq1 & "^" & sa1 & "^" & sq2 & "^" & sa2 & "^" & sq3 & "^" & sa3 & "")


        ElseIf Registration.RegistrationType = "Process Lead" Then
            'Dim conn As New pgConnect
            conn.InsertRecord("user_details",
                          "first_name,last_name,project_id,project,process,sub_process,account_type,account_status,login_attempt,empl_id,password,password_type,password_change_date,secret_ques1,secret_answer1,secret_ques2,secret_answer2,secret_ques3,secret_answer3",
                          "" & FName & "^" & LName & "^" & projectID & "^" & project & "^" & process & "^" & subprocess & "^Process Lead^Active^" & 0 & "^" & eid & "^" & sb64 & "^user^" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & sq1 & "^" & sa1 & "^" & sq2 & "^" & sa2 & "^" & sq3 & "^" & sa3 & "")

        End If

        conn.Connect()
        conn.InsertRecord("pass_change_audit", "empl_id,date,pass", "" & eid & "^" & Now & "^" & sb64 & "")


        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Sub ProfileCreator(emplid As Integer, Name As String, projectID As Integer, project As String, process As String, subprocess As String, profile As String, profilename As String)
        Dim Var As New Encryption
        Dim conn As New pgConnect

        Var.Encrypt(emplid)
        Dim eid As String = Var.encr

        conn.InsertRecord("think_profile",
                          "empl_id,name,project_id,project,process,sub_process,profile,profile_name",
                          "" & eid & "^" & Name & "^" & projectID & "^" & project & "^" & process & "^" & subprocess & "^" & profile & "^" & profilename & "")

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Public Function AppLogin(username As String, password As String)

        Dim Enc As New Encryption
        Enc.Encrypt(username)
        Dim uname As String = Enc.encr
        If password.Trim().Length >= 8 Then
            Enc.Encrypt(password)
        Else
            Dim msg As MsgBoxResult = MsgBox("Invalid Login Details")
        End If



        Dim pass As String = Enc.encr
        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pass)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim pwd As String = System.Convert.ToBase64String(hashBytes)


        Dim conn As New pgConnect
        Dim value As String = uname & "^" & pwd
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "first_name,last_name", "empl_id =@value1 and password =@value2", value)

        If login.HasRows Then
            Return True
        Else
            Return False
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function AccountStatus(username As String, status As String)

        Dim Enc As New Encryption
        Enc.Encrypt(username)
        Dim uname As String = Enc.encr


        Dim conn As New pgConnect
        Dim value As String = uname & "^" & status
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "account_status", "empl_id =@value1 and account_status =@value2", value)



        If login.HasRows Then
            Return True
        Else
            Return False
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function LockedStatus(username As String)

        Dim Enc As New Encryption
        Enc.Encrypt(username)
        Dim uname As String = Enc.encr


        Dim conn As New pgConnect
        Dim value As String = uname & "^" & "Locked"
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "account_status", "empl_id =@value1 and account_status =@value2", value)



        If login.HasRows Then
            Return False
        Else
            Return True
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function PwrsdChangeDay(EmplID As String, days As Integer)
        Dim dt1, dt2 As Date

        Dim Enc As New Encryption
        Enc.Encrypt(EmplID)
        Dim uname As String = Enc.encr
        Dim day As Integer


        Dim conn As New pgConnect
        Dim value As String = uname
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "password_change_date", "empl_id =@value1", value)

        While login.Read
            dt1 = DateTime.Parse(login("password_change_date"))
            dt2 = DateTime.Parse(Now)
            Dim ts As TimeSpan = dt2.Subtract(dt1)
            day = Convert.ToInt32(ts.Days)
        End While

        If day > days Then
            Return False
        Else
            Return True
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function PwsrdChangeDayLeft(EmplID As String)
        Dim dt1, dt2 As Date

        Dim Enc As New Encryption
        Enc.Encrypt(EmplID)
        Dim uname As String = Enc.encr
        Dim day As Integer
        Dim RemainigDays As Integer

        Dim conn As New pgConnect
        Dim value As String = uname
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "password_change_date", "empl_id =@value1", value)

        While login.Read
            dt1 = DateTime.Parse(login("password_change_date"))
            dt2 = DateTime.Parse(Now)
            Dim ts As TimeSpan = dt2.Subtract(dt1)
            day = Convert.ToInt32(ts.Days)
        End While


        RemainigDays = 30 - day

        'If RemainigDays >= 5 Then
        'Return False
        'Else
        Return RemainigDays
        'End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function Pa_wordCheck(pa_wword As String)
        Dim MatchNumberPattern As String = "^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=*]).*$"
        If Not Regex.IsMatch(pa_wword, MatchNumberPattern) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function GetLoginAttempt(EmplID As String)
        Dim attempt As Integer
        Dim Enc As New Encryption
        Enc.Encrypt(EmplID)
        Dim uname As String = Enc.encr

        Dim conn As New pgConnect
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "login_attempt", "empl_id =@value1", uname)
        If reader.HasRows Then
            While reader.Read
                attempt = reader("login_attempt")
            End While
            Return attempt
        Else
            Return True
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Sub UpdateLoginAttempt(EmplID As String, attempt As Integer)
        Dim Var As New Encryption
        Var.Encrypt(EmplID)
        Dim uname As String = Var.encr


        Dim value As String = attempt & "^" & uname

        Dim conn As New pgConnect
        conn.UpdateRecord("user_details", "login_attempt=@value1", value, "empl_id =@value2")

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Public Sub LockAccount(EmplID As String)
        Dim Var As New Encryption
        Var.Encrypt(EmplID)
        Dim uname As String = Var.encr

        Dim value As String = "Locked" & "^" & uname

        Dim conn As New pgConnect
        conn.UpdateRecord("user_details", "account_status=@value1", value, "empl_id =@value2")

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Public Sub UserDetails(EmplID As String)
        Dim Var As New Encryption
        Var.Encrypt(EmplID)
        Dim uname As String = Var.encr

        Dim conn As New pgConnect
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "*", "empl_id =@value1", uname)
        If reader.HasRows Then
            While reader.Read
                My.Settings.EmplID = EmplID
                My.Settings.Name = Var.decrypt(reader("first_name")) & "," & Var.decrypt(reader("last_name"))
                My.Settings.Project = Var.decrypt(reader("project"))
                My.Settings.Process = Var.decrypt(reader("process"))
                My.Settings.SubProcess = Var.decrypt(reader("sub_process"))
                My.Settings.Role = reader("account_type")
                My.Settings.LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString
                My.Settings.ProjectID = reader("project_id")
                My.Settings.UserID = reader("user_id")
            End While
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Public Function UnlockAccount(EmployeID As String, SecretQuestion As String, SecretAnswer As String)

        Dim q1 As String = Nothing
        Dim q2 As String = Nothing
        Dim q3 As String = Nothing
        Dim a1 As String = Nothing
        Dim a2 As String = Nothing
        Dim a3 As String = Nothing

        Dim Var As New Encryption
        Var.Encrypt(EmployeID)
        Dim uname As String = Var.encr

        Var.Encrypt(SecretQuestion)
        Dim ques As String = Var.encr

        Var.Encrypt(SecretAnswer)
        Dim ans As String = Var.encr




        Dim conn As New pgConnect
        Dim value As String = uname & "^" & ques & "^" & ans
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "*", "empl_id =@value1", uname)

        If login.HasRows Then
            While login.Read
                q1 = login("secret_ques1")
                q2 = login("secret_ques2")
                q3 = login("secret_ques3")
                a1 = login("secret_answer1")
                a2 = login("secret_answer2")
                a3 = login("secret_answer3")
            End While

            If ques = q1 Or ques = q2 Or ques = q3 Then
                If ans = a1 Or ans = a2 Or ans = a3 Then
                    conn.Connect()
                    Dim value2 As String = "Active" & "^" & uname & "^" & 0
                    conn.UpdateRecord("user_details", "account_status =@value1,login_attempt=@value3", value2, "empl_id =@value2")
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Else
            Return False
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function Change_Pasord(EmployeID As String, OldPassord As String, NewPasord As String)
        Dim Var As New Encryption
        Dim Enc As New Encryption

        Var.Encrypt(EmployeID)
        Dim uname As String = Var.encr

        Enc.Encrypt(OldPassord)
        Dim pass As String = Enc.encr
        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pass)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim pwd As String = System.Convert.ToBase64String(hashBytes)

        Enc.Encrypt(NewPasord)
        Dim Npass As String = Enc.encr
        Dim NbArry() As Byte = System.Text.Encoding.UTF8.GetBytes(Npass)
        Dim NhashType As HashAlgorithm = New SHA512Managed()
        Dim NhashBytes As Byte() = NhashType.ComputeHash(NbArry)
        Dim Npwd As String = System.Convert.ToBase64String(NhashBytes)

        Dim conn As New pgConnect
        Dim value As String = uname & "^" & pwd
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "first_name,last_name", "empl_id =@value1 and password =@value2", value)


        If login.HasRows Then
            conn.Connect()
            Dim value2 As String = Npwd & "^" & "user" & "^" & DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & uname
            conn.UpdateRecord("user_details", "password =@value1,password_type =@value2,password_change_date =@value3", value2, "empl_id =@value4")
            Return True
        Else
            Return False
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Function PasswordType(EmployeID As String)

        Dim Enc As New Encryption
        Enc.Encrypt(EmployeID)
        Dim uname As String = Enc.encr
        Dim passtype As String = Nothing


        Dim conn As New pgConnect
        Dim value As String = uname
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "password_type", "empl_id =@value1", value)


        While login.Read
            passtype = login("password_type")
        End While

        If passtype = "user" Then
            Return True
        Else
            Return False
        End If

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Function
    Public Sub ResetPassword(EmployeID As String)
        Dim Var As New Encryption
        Dim Enc As New Encryption

        Var.Encrypt(EmployeID)
        Dim uname As String = Var.encr

        Enc.Encrypt("Tcs@123")
        Dim pass As String = Enc.encr
        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pass)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim pwd As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        Dim value As String = pwd & "^" & "default" & "^" & "Active" & "^" & 0 & "^" & Now & "^" & EmployeID
        conn.UpdateRecord("user_details", "password =@value1 , password_type =@value2,account_status =@value3,login_attempt =@value4,password_change_date =@value5", value, "empl_id =@value6")

        If conn.connection.State = ConnectionState.Open Then
            conn.ConnClose()
        End If

    End Sub
    Public Function Change_PasordCheck(EmplID As String, Pasord As String)

        Dim Enc As New Encryption
        Enc.Encrypt(EmplID)
        Dim uname As String = Enc.encr

        Enc.Encrypt(Pasord)
        Dim pwd As String = Enc.encr

        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pwd)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim sb64 As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        Dim value As String = uname & "^" & sb64
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecordsLimit("pass_change_audit", "*", "empl_id =@value1 AND pass =@value2", value)

        If login.HasRows Then
            Return False
        Else
            Return True
        End If
        hashType.Clear()


    End Function
    Public Sub PassToPassAudit(EmplID As String, Passord As String)

        Dim Enc As New Encryption
        Enc.Encrypt(EmplID)
        Dim uname As String = Enc.encr

        Enc.Encrypt(Passord)
        Dim pwd As String = Enc.encr

        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pwd)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()

        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim sb64 As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        conn.InsertRecord("pass_change_audit", "empl_id,date,pass", "" & uname & "^" & Now & "^" & sb64 & "")
        hashType.Clear()





    End Sub
    Function OldPasswordCheck(EmplId As String, PasrWd As String)
        Dim Enc As New Encryption
        Dim uname As String = Enc.EncryptNew(EmplId)

        Enc.Encrypt(PasrWd)
        Dim pwd As String = Enc.encr

        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pwd)
        Dim hashType As HashAlgorithm
        hashType = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim sb64 As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        Dim value As String = uname & "^" & sb64
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecordsLimit("user_details", "*", "empl_id =@value1 AND password =@value2", value)

        If login.HasRows Then
            Return True
        Else
            Return False
        End If
        hashType.Clear()
    End Function
    Function PawordHistoryCheck(EmplId As String, PasrWd As String)
        Dim Enc As New Encryption
        Dim uname As String = Enc.EncryptNew(EmplId)
        If PasrWd.Trim().Length >= 8 Then
            Enc.Encrypt(PasrWd)
        Else
            Dim msg As MsgBoxResult = MsgBox("Invalid Login Details")
        End If

        Dim pwd As String = Enc.encr

        Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pwd)
        Dim hashType As HashAlgorithm = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
        Dim sb64 As String = System.Convert.ToBase64String(hashBytes)

        Dim conn As New pgConnect
        Dim value As String = uname
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecordsLimit("pass_change_audit", "*", "empl_id =@value1 ", value, "id DESC",, 3)

        Dim pass1 As String = Nothing
        Dim pass2 As String = Nothing
        Dim pass3 As String = Nothing

        Dim passfound As Boolean = False

        If reader.HasRows Then
            While reader.Read
                If reader("pass") = sb64 Then
                    passfound = True
                End If
            End While

            If passfound = True Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
        hashType.Clear()


    End Function
    Function PawordReset(EmployeID As String, Passrd As String)
        Dim Var As New Encryption
        Dim conn As New pgConnect

        Try
            Dim uname As String = Var.EncryptNew(EmployeID)

            Dim pass As String = Nothing

            If Passrd.Trim().Length >= 8 Then
                pass = Var.EncryptNew(Passrd)
            Else
                Dim msg As MsgBoxResult = MsgBox("Invalid login details")
            End If



            Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(pass)
            Dim hashType As HashAlgorithm
            hashType = New SHA512Managed()
            Dim hashBytes As Byte() = hashType.ComputeHash(bArry)
            Dim pwd As String = System.Convert.ToBase64String(hashBytes)


            Dim value As String = pwd & "^" & "default" & "^" & "Active" & "^" & 0 & "^" & Now & "^" & uname
            conn.UpdateRecord("user_details", "password =@value1 , password_type =@value2,account_status =@value3,login_attempt =@value4,password_change_date =@value5", value, "empl_id =@value6")

            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
            hashType.Clear()
            Return True
        Catch ex As IO.IOException
            Return False
        End Try

    End Function
    Public Function RandomPaswrd()
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789?!"
        Dim r As New Random
        Const passwrdLength As Integer = 20
        Dim passwChars() As Char = New Char(passwrdLength - 1) {}
        Dim charIndex As Integer

        For i As Integer = 0 To passwrdLength - 1
            charIndex = r.Next(s.Length)
            passwChars(i) = s(charIndex)
        Next

        Dim passwd As New String(passwChars)
        Return passwd
    End Function
    Function SecrectAnswerCheck(EmployeID As String, SecretQuestion As String, SecretAnswer As String)
        Dim Var As New Encryption
        Dim conn As New pgConnect

        Dim q1 As String = Nothing
        Dim q2 As String = Nothing
        Dim q3 As String = Nothing
        Dim a1 As String = Nothing
        Dim a2 As String = Nothing
        Dim a3 As String = Nothing

        Dim uname As String = Var.EncryptNew(EmployeID)
        Dim sques As String = Var.EncryptNew(SecretQuestion)
        Dim sans As String = Var.EncryptNew(SecretAnswer)
        Dim value As String = uname & "^" & sques & "^" & sans
        Dim login As Npgsql.NpgsqlDataReader = conn.GetRecords("user_details", "*", "empl_id =@value1", uname)

        If login.HasRows Then
            While login.Read
                q1 = login("secret_ques1")
                q2 = login("secret_ques2")
                q3 = login("secret_ques3")
                a1 = login("secret_answer1")
                a2 = login("secret_answer2")
                a3 = login("secret_answer3")
            End While

            If sques = q1 Or sques = q2 Or sques = q3 Then
                If sans = a1 Or sans = a2 Or sans = a3 Then

                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Else
            Return False
        End If

    End Function

End Class
