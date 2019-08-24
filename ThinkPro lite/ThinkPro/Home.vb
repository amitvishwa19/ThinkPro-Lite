Imports System.IO
Imports Npgsql
Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports System.Net
Imports System.Net.NetworkInformation.Ping

Public Class Home
    Public SystemSessionInfo As String

#Region "Variable"


    Public TimeViewStatus As Boolean = False
    Public RememberMe As Boolean = False
    Public PollView As Boolean = False
    Public NotifyView As Boolean = False
    Dim ULanID As String
    Public setkey As String = Nothing
    Public MachineLockStatus As Boolean = False

#End Region

#Region "New Variables"

    Public TP_UserName As String = Nothing
    Public TP_EmplID As Integer = Nothing
    Public TP_UserID As Integer = Nothing
    Public TP_ProcessID As Integer = Nothing
    Public TP_Project As String = Nothing
    Public TP_Process As String = Nothing
    Public TP_SubProcess As String = Nothing
    Public TP_UserRole As String = Nothing
    Public TP_LoginDate As String = Nothing

    Public TP_ActivityLoggerType As String = Nothing
    Public TP_SystemLockTime As Integer = Nothing
    Public TP_SystemLockCheck As Boolean = True
    Public TP_SystemSwitchCheck As Boolean = True
    Public TP_DBPooling As Boolean = True

    Dim LogoutStamp As Boolean = False

    Private Sub VariableSet()
        TP_UserName = My.Settings.Name
        TP_EmplID = My.Settings.EmplID
        TP_UserID = My.Settings.UserID
        TP_ProcessID = My.Settings.ProjectID
        TP_Project = My.Settings.Project
        TP_Process = My.Settings.Process
        TP_SubProcess = My.Settings.SubProcess
        TP_UserRole = My.Settings.Role
        TP_LoginDate = My.Settings.LoginDate
    End Sub

    Private Sub ProjectDetails()
        Dim conn As New pgConnect
        Try
            Dim value As String = TP_Project & "^" & TP_Process & "^" & TP_SubProcess
            Dim PD As NpgsqlDataReader = conn.GetRecords("app_config", "*", "project=@value1 AND process=@value2 AND sub_process=@value3", value)
            While PD.Read


                If PD("type") = "SystemLockCheck" Then
                    If PD("option") = "True" Then
                        TP_SystemLockCheck = True
                    ElseIf PD("option") = "False" Then
                        TP_SystemLockCheck = False
                    End If
                End If

                If PD("type") = "SystemLockTime" Then
                    TP_SystemLockTime = PD("option")
                End If

                If PD("type") = "SwitchUserCheck" Then
                    If PD("option") = "True" Then
                        TP_SystemSwitchCheck = True
                    ElseIf PD("option") = "False" Then
                        TP_SystemSwitchCheck = False
                    End If
                End If

                If PD("type") = "ActivityLoggerType" Then
                    TP_ActivityLoggerType = PD("option")
                End If


            End While
        Catch ex As IO.IOException
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        End Try
    End Sub

#End Region

    Private Function server_check()
        If My.Settings.db_name = Nothing Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub ThinkPro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If AppInit.application_initialization = True Then
                Call AppLoad()
            Else
                Dim msg2 As MsgBoxResult = MsgBox("Application initialization failed ! Make sure valid AppConfig file is avaliable on desktop ...", vbInformation, "Config file missing")
                Exit Sub
            End If

            lblVersion.Text = "Version: " & Application.ProductVersion
            If My.Application.IsNetworkDeployed Then
                lblPublishVersion.Text = "Publised Version: " & My.Application.Deployment.CurrentVersion.ToString()
            End If




        Catch ex As IO.IOException

        End Try



    End Sub

    'Public Function consent_check()


    '    Dim conn As New pgConnect
    '    Dim enc As New Encryption
    '    Dim consent As Boolean = False
    '    Try

    '        enc.Encrypt(TP_EmplID)

    '        Dim value As String = enc.encr
    '        Dim dr As NpgsqlDataReader = conn.GetRecords("user_details", "consent", "empl_id=@value1", value)

    '        If dr.HasRows Then
    '            While dr.Read
    '                consent = dr("consent")
    '            End While

    '            If consent = True Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Else
    '            Return False
    '        End If

    '    Catch ex As IO.IOException
    '        Return False
    '    End Try

    'End Function

    Sub AppLoad()

        Dim Logn As New LoginReg
        Dim enc As New Encryption


        Try
            If My.Settings.EmplID = Nothing Then
                Call LoginMenu()
                LoginPanel.Visible = True
                Me.Text = "ThinkPro " & Application.ProductVersion
            Else
                If My.Settings.RememberMe = True Then
                    If Logn.PwrsdChangeDay(My.Settings.EmplID, 30) = True Then

                        If Logn.PwsrdChangeDayLeft(My.Settings.EmplID) < 1 Then
                            Dim msg As MsgBoxResult = MsgBox("Your password is expired,Please change password  ", vbInformation, "Password Expired")
                            Call LoginMenu()
                            Exit Sub

                        ElseIf Logn.PwsrdChangeDayLeft(My.Settings.EmplID) <= 10 Then
                            Dim msg As MsgBoxResult = MsgBox("Your password will expire in " & Logn.PwsrdChangeDayLeft(My.Settings.EmplID) & " days,Kindly change your password", vbInformation, "Password Expired")
                            GoTo LoginProceed
                        End If
LoginProceed:
                        'LoadTimer.Start()
                        HomeProfile.Visible = True
                        My.Settings.LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString
                        My.Settings.Save()

                        'user details reload in case of remember pass
                        Logn.UserDetails(My.Settings.EmplID)

                        Call VariableSet()
                        Call FullMenu()
                        Call DisableLoginRegister()

                        LoadTimer.Enabled = True




                        Me.Text = "ThinkPro " & Application.ProductVersion & "    LoggedIn on : " & My.Settings.LoginDate
                        LogoutStamp = True


                    Else
                        Dim msg3 As MsgBoxResult = MsgBox("Your password is expired please change your password from password management window", vbInformation, "Password Expired")
                        Call LoginMenu()
                    End If

                Else
                    Call LoginMenu()
                    LoginPanel.Visible = True
                    Me.Text = "ThinkPro " & Application.ProductVersion
                End If
            End If

        Catch ex As IO.IOException
            '  Dim line As String = ex.StackTrace.ToString
            ' Dim LineNo() As String = Split(line, "line")
            '  Dim lg As New ErrorLogger
            '  lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally


        End Try
    End Sub

    Public Sub LoginMenu()


        Try
            Dim menu As MenuStrip = MainMenu
            MainMenu.Visible = True
            HomeProfile.Visible = False
            statusBar.Visible = False
            For i = 0 To menu.Items.Count - 1
                If menu.Items(i).ToString = "Home" Then
                    menu.Items(i).Visible = True
                Else
                    menu.Items(i).Visible = False
                End If
            Next


            For i = 0 To menu.Items.Count - 1
                For Each item As ToolStripMenuItem In MainMenu.Items
                    For j = 0 To item.DropDown.Items.Count - 1
                        If item.DropDown.Items(j).ToString = "Login" Or item.DropDown.Items(j).ToString = "Register" Or item.DropDown.Items(j).ToString = "Password Management" Or item.DropDown.Items(j).ToString = "Exit" Or item.DropDown.Items(j).ToString = "Setting" Then
                            item.DropDown.Items(j).Visible = True
                        Else
                            item.DropDown.Items(j).Visible = False
                        End If
                    Next
                Next
            Next

        Catch ex As IO.IOException

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally


        End Try


    End Sub 'Required

    Public Sub FullMenu()

        Try
            MainMenu.Visible = True
            Dim menu As MenuStrip = MainMenu
            For i = 0 To menu.Items.Count - 1
                If menu.Items(i).ToString = "Setup" Or menu.Items(i).ToString = "Home" Then
                    menu.Items(i).Visible = True
                Else
                    menu.Items(i).Visible = True
                End If
            Next


            For i = 0 To menu.Items.Count - 1
                For Each item As ToolStripMenuItem In MainMenu.Items
                    For j = 0 To item.DropDown.Items.Count - 1
                        If item.DropDown.Items(j).ToString <> "Login" And item.DropDown.Items(j).ToString <> "Register" Then
                            item.DropDown.Items(j).Visible = True
                        End If
                    Next
                Next
            Next

            If My.Settings.Role = "Associate" Then
                mThinkManagement.Visible = False
            Else
                mThinkManagement.Visible = True
            End If


            If My.Settings.Role = "Admin" Then

                MenuAdmin.Visible = True
            Else

                MenuAdmin.Visible = False

            End If

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '   Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally


        End Try


    End Sub 'Required

    Public Sub SettingMenu()
        Try
            Dim menu As MenuStrip = MainMenu
            MainMenu.Visible = True
            HomeProfile.Visible = False
            statusBar.Visible = False
            For i = 0 To menu.Items.Count - 1
                If menu.Items(i).ToString = "Setting" Then
                    menu.Items(i).Visible = True
                Else
                    menu.Items(i).Visible = False
                End If
            Next

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '  Dim lg As New ErrorLogger
            '   lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally


        End Try
    End Sub

#Region "Activie window status"
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Integer
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Dim ProcsID As Integer = Nothing
    Dim ProcsName As String = Nothing
    Private OldWindowName As String = Nothing
    Private CurrWindowName As String = Nothing
    Private FirstWindow As Boolean = True
    Private Stime As Date = Now


    Private Function WindowCaption() As String
        Dim CurrWindow As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, CurrWindow, CurrWindow.Capacity)
        Return CurrWindow.ToString()
    End Function

    Private Sub ActiveWindowCheck_Tick(sender As Object, e As EventArgs)

        'Dim conn As New pgConnect
        'Dim hWnd As IntPtr = GetForegroundWindow()
        'Dim SecondsDifference As Integer
        'Dim TotalTime As Double
        'Dim ProcID As Integer = 0
        'If hWnd = IntPtr.Zero Then Exit Sub
        'GetWindowThreadProcessId(hWnd, ProcID)
        'If ProcID = 0 Then Exit Sub
        'Dim proc As Process = Process.GetProcessById(ProcID)

        'CurrWindowName = proc.MainWindowTitle

        'Try

        '    If OldWindowName = Nothing Then
        '        OldWindowName = CurrWindowName
        '        ProcsID = ProcID.ToString
        '        ProcsName = proc.ProcessName
        '        Stime = Now
        '        Exit Sub
        '    End If


        '    If MachineLockStatus = False Then
        '        If OldWindowName <> CurrWindowName Then

        '            Dim Etime As Date = Now
        '            SecondsDifference = DateDiff(DateInterval.Second, Stime, Etime)
        '            TotalTime = Format(SecondsDifference / 60, "0.0")

        '            Dim value As String = TP_UserID & "^" & TP_ProcessID & "^" & TP_EmplID & "^" & TP_UserName & "^" & TP_Project & "^" & TP_Process & "^" & TP_SubProcess & "^" & Format(Now, "dd-MMM-yy") & "^" & ProcsID & "^" & ProcsName & "^" & OldWindowName & "^" & Stime & "^" & Etime & "^" & TotalTime
        '            conn.InsertRecord("activity_tracker", "user_id,process_id,empl_id,name,project,process,sub_process,date,app_id,app_name,app_title,start_time,end_time,total_time", value)

        '            OldWindowName = CurrWindowName
        '            ProcsID = ProcID.ToString
        '            ProcsName = proc.ProcessName
        '            CurrWindowName = proc.MainWindowTitle
        '            Stime = Now


        '        End If
        '    End If




        'Catch ex As Exception
        '    If conn.connection.State = ConnectionState.Open Then
        '        conn.ConnClose()
        '    End If

        '    Dim line As String = ex.StackTrace.ToString
        '    Dim LineNo() As String = Split(line, "line")
        '    Dim lg As New ErrorLogger
        '    lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)

        'Finally
        '    If conn.connection.State = ConnectionState.Open Then
        '        conn.ConnClose()
        '    End If
        'End Try

    End Sub 'required

#End Region

#Region "Think Poll"

    Private Sub ThinkPollPop()

        Dim Conn As New pgConnect
        Dim AnsConn As New pgConnect



        Try
            Dim mdate As String = Format(Now, "dd-MMM-yy")
            Dim value As String = "Active" & "^" & mdate & "^" & TP_ProcessID
            Dim reader As NpgsqlDataReader = Conn.GetRecords("think_poll", "*", "poll_status =@value1 AND date =@value2 AND process_id =@value3", value, "poll_id ASC")
            If reader.HasRows Then
                While reader.Read

                    If PollView = False Then



                        Dim AnsValue As String = mdate & "^" & My.Settings.UserID & "^" & reader("poll_id")
                        Dim AnsReader As NpgsqlDataReader = AnsConn.GetRecords("think_poll_response", "*", "date =@value1 AND user_id =@value2 AND poll_id=@value3", AnsValue)
                        If Not AnsReader.HasRows Then
                            ThinkPoll.Show()
                            PollView = True
                            ThinkPoll.lblPollTitle.Text = reader("poll_title")
                            ThinkPoll.lblPollQues.Text = reader("poll_question")
                            ThinkPoll.RadioButton1.Text = reader("option_1")
                            ThinkPoll.RadioButton2.Text = reader("option_2")
                            ThinkPoll.RadioButton3.Text = reader("option_3")
                            ThinkPoll.RadioButton4.Text = reader("option_4")
                            ThinkPoll.cmdPollSubmit.Tag = reader("poll_id")
                            ThinkPoll.pollid = reader("poll_id")

                            ThinkPoll.RadioButton1.Checked = False
                            ThinkPoll.RadioButton2.Checked = False
                            ThinkPoll.RadioButton3.Checked = False
                            ThinkPoll.RadioButton4.Checked = False


                            Exit Sub
                        End If

                    End If

                End While
            End If
        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If

            If AnsConn.connection.State = ConnectionState.Open Then
                AnsConn.ConnClose()
            End If


        End Try

    End Sub

#End Region

    Public Sub DisableLoginRegister()
        Dim menu As MenuStrip = MainMenu
        For i = 0 To menu.Items.Count - 1
            For Each item As ToolStripMenuItem In MainMenu.Items
                For j = 0 To item.DropDown.Items.Count - 1
                    If item.DropDown.Items(j).ToString = "Login" Or item.DropDown.Items(j).ToString = "Register" Then
                        item.DropDown.Items(j).Visible = False
                    End If
                Next
            Next
        Next
    End Sub 'Required

    Public Sub AppMenuLoad()
        MainMenu.Visible = True
        Dim filecheck As New AppStartup
        If filecheck.configfilecheck = False Then

            HomeProfile.Visible = False


            Dim menu As MenuStrip = MainMenu
            For i = 0 To menu.Items.Count - 1
                If menu.Items(i).ToString <> "Setup" Then
                    menu.Items(i).Visible = False
                Else
                    menu.Items(i).Visible = True
                End If
            Next
        Else

            Dim menu As MenuStrip = MainMenu
            For i = 0 To menu.Items.Count - 1
                For Each item As ToolStripMenuItem In MainMenu.Items
                    For j = 0 To item.DropDown.Items.Count - 1
                        If item.DropDown.Items(j).ToString <> "Login" And item.DropDown.Items(j).ToString <> "Register" Then
                            item.DropDown.Items(j).Enabled = False
                        End If
                    Next
                Next
            Next
        End If

    End Sub 'Required

#Region "Menu and SubMenu Click"

    Private Sub smsDBSetup_Click(sender As Object, e As EventArgs)
        ' Old_Setup.Show()
    End Sub

    Private Sub msMyProfile_Click(sender As Object, e As EventArgs)
        'MyProfile.Show()
    End Sub

    Private Sub msLogout_Click(sender As Object, e As EventArgs)
        Call LoginMenu()
    End Sub

    Private Sub NewRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRequestToolStripMenuItem.Click
        IssueLogger.Show()
    End Sub

    Private Sub ThinkProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThinkProfileToolStripMenuItem.Click
        ThinkProfiles.Show()
    End Sub

    Private Sub HomeProfile_Click(sender As Object, e As EventArgs) Handles HomeProfile.Click
        'ProfileSelector.Show()
    End Sub

#End Region

#Region "Form Close events"

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If TimeViewStatus = True Then
            Dim msg As MsgBoxResult = MsgBox("TimeView is still running,Kindly Close TimeView before exiting the application", vbInformation, "LoggedIn")
            e.Cancel = True
            Exit Sub
        Else
            If LogoutStamp = True Then
                Call AppEvents.LogOutTimeStamp()
            End If
        End If


    End Sub

#End Region

    Private Sub LoadTimer_Tick(sender As Object, e As EventArgs) Handles LoadTimer.Tick

        LoadTimer.Stop()

        Call HomeProfileset()
        Call ProfileLoad()
        Call ProjectDetails()

        If consent_check() = False Then
            Me.Enabled = False
            Application_Consent.Show()
        End If

        MainMenu.Visible = True
        statusBar.Visible = True
        HomeProfile.Visible = True
        LoginPanel.Visible = False

        FullMenu()
        DisableLoginRegister()
        AppEvents.LoginTimeStamp()
        My.Settings.LogoutStamp = True
        LockTimer.Start()

    End Sub 'Required

#Region "App Session"
    Private Declare Function LockWorkStation Lib "user32.dll" () As Long
    <DllImport("user32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function
    Friend Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub LockTimer_Tick(sender As Object, e As EventArgs) Handles LockTimer.Tick

        Try
            Dim Hours, Minutes, Seconds As Integer
            Dim systemUptime As Integer = Environment.TickCount
            Dim LastInputTicks As Integer = 0
            Dim IdleTicks As Integer = 0
            Dim IdleTime As Integer = 0
            Dim LastInputInfo As New LASTINPUTINFO()
            LastInputInfo.cbSize = CUInt(Marshal.SizeOf(LastInputInfo))
            LastInputInfo.dwTime = 0

            If GetLastInputInfo(LastInputInfo) Then
                LastInputTicks = CInt(LastInputInfo.dwTime)
                IdleTicks = systemUptime - LastInputTicks
            End If

            lblSystemUptime.Text = "System Uptime: " & Format((systemUptime / 1000) / 60, "0") & "(Min)    "
            lblIdleTime.Text = "Idle Time: " & Format((IdleTicks / 1000), "0") & " (Sec)   "
            IdleTime = Format((IdleTicks / 1000), "0.00")

            Seconds = Integer.Parse(IdleTime)
            Hours = Seconds / 3600
            Seconds = Seconds Mod 3600
            Minutes = Seconds / 60
            Seconds = Seconds Mod 60



            lblIdleTime.Text = "Idle Time: " & Hours.ToString.PadLeft(2, "0"c) & ":" & Minutes.ToString.PadLeft(2, "0"c) & ":" & Seconds.ToString.PadLeft(2, "0"c)

            If TP_SystemLockTime <> 0 Then
                If Format((IdleTicks / 1000), "0") >= TP_SystemLockTime * 60 Then
                    LockWorkStation()
                End If
            End If



        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

#End Region

#Region "App Login"

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Try
            Dim iID As String
            iID = txtID.Text

            If txtID.Text <> "" Then
                If IsNumeric(iID) Then
                    ErrorProviderError.SetError(txtID, "")
                    ErrorProviderWarning.SetError(txtID, "")
                    ErrorProviderok.SetError(txtID, "")
                    cmdLogin.Enabled = True

                    If txtID.TextLength > 10 Then
                        ErrorProviderError.SetError(txtID, "")
                        ErrorProviderWarning.SetError(txtID, "")
                        ErrorProviderError.SetError(txtID, "Enter valid Employee ID")
                        cmdLogin.Enabled = False
                    End If

                Else
                    ErrorProviderok.SetError(txtID, "")
                    ErrorProviderError.SetError(txtID, "Enter valid Employee ID")
                    cmdLogin.Enabled = False
                End If
            Else
                ErrorProviderError.SetError(txtID, "")
                ErrorProviderWarning.SetError(txtID, "")
                ErrorProviderok.SetError(txtID, "")

            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                txtPass.Focus()
            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Private Sub txtID_LostFocus(sender As Object, e As EventArgs) Handles txtID.LostFocus
        'picload1.Visible = False


        Try
            Dim iID As String
            iID = txtID.Text

            If txtID.TextLength > 10 Then
                ErrorProviderError.SetError(txtID, "Enter Valid Employee ID")
                cmdLogin.Enabled = False
                Exit Sub
            Else
            End If

            If IsNumeric(iID) Then
                ErrorProviderError.SetError(txtID, "")
                ErrorProviderWarning.SetError(txtID, "")
                ErrorProviderok.SetError(txtID, "")
                cmdLogin.Enabled = True
            Else
                ErrorProviderError.SetError(txtID, "Enter Valid Employee ID")
                cmdLogin.Enabled = False
            End If


            If txtID.Text = String.Empty Then
                ErrorProviderError.SetError(txtID, "")
                ErrorProviderok.SetError(txtID, "")
                ErrorProviderWarning.SetError(txtID, "Enter Valid User ID")
            End If

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Required

    Private Sub txtPass_GotFocus(sender As Object, e As EventArgs) Handles txtPass.GotFocus
        ErrorProviderok.SetError(txtPass, "")
        ErrorProviderWarning.SetError(txtPass, "")
        ErrorProviderError.SetError(txtPass, "")
    End Sub 'Required

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            chkRememberme.Focus()
            'Call Loginclick()
        End If
    End Sub 'Required

    Private Sub chkRememberme_KeyPress(sender As Object, e As KeyPressEventArgs) Handles chkRememberme.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Call Loginclick()
        End If
    End Sub 'Required

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Call Loginclick()
    End Sub 'Required

    Private Sub Loginclick()

        Try
            If txtID.Text = "" Then
                Dim msg1 As MsgBoxResult = MsgBox("Please enter user ID", vbInformation, "User Id Missing")
                txtID.Focus()
                Exit Sub
            End If


            If txtPass.Text = "" Then
                Dim msg2 As MsgBoxResult = MsgBox("Please enter password", vbInformation, "Password Missing")
                txtPass.Focus()
                Exit Sub
            End If


            App_Login()
        Catch ex As IO.IOException

        End Try

    End Sub 'Required

    Private Sub App_Login()

        Try
            Dim username = txtID.Text
            Dim passWOR = txtPass.Text

            Dim attempt As Integer
            Dim Logn As New LoginReg

            If Logn.EmpIdCheck(username) = False Then  'Check for user existence
                If Logn.AccountStatus(username, "Active") = True Then 'Check for if account is active or not
                    If Logn.PwrsdChangeDay(username, 30) = True Then


                        Dim DayLeft As Integer = Logn.PwsrdChangeDayLeft(username)

                        If DayLeft < 1 Then
                            Dim msg As MsgBoxResult = MsgBox("Your password is expired,Please change password  ", vbInformation, "Password Expired")
                            Call LoginMenu()
                            Exit Sub
                        ElseIf DayLeft <= 10 Then

                            Dim msg As MsgBoxResult = MsgBox("Your password will expire in " & Logn.PwsrdChangeDayLeft(username) & " days,Kindly change your password", vbInformation, "Password Expired")

                            Dim msg5 As MsgBoxResult = MsgBox("Your password will expire in " & Logn.PwsrdChangeDayLeft(username) & " days,Kindly change your password", vbInformation, "Password Expired")

                            Dim msg1 As MsgBoxResult = MsgBox("Your password will expire in " & Logn.PwsrdChangeDayLeft(username) & " days,Kindly change your password", vbInformation, "Password Expired")

                            GoTo LoginProceed
                        Else
LoginProceed:
                            If Logn.AppLogin(username, passWOR) = True Then
                                If Logn.PasswordType(username) = True Then
                                    Logn.UpdateLoginAttempt(username, 0)
                                    Call Logn.UserDetails(username)

                                    Call VariableSet()

                                    LoadTimer.Enabled = True

                                    LoginPanel.Visible = False
                                    txtID.Text = Nothing
                                    txtPass.Text = Nothing
                                    lblattempt.Text = Nothing

                                    If chkRememberme.Checked = True Then
                                        My.Settings.RememberMe = True
                                        My.Settings.Save()
                                    End If

                                    chkRememberme.CheckState = False
                                    LogoutStamp = True
                                    Me.Text = "ThinkPro " & Application.ProductVersion & "    LoggedIn on : " & My.Settings.LoginDate

                                Else
                                    Dim msg2 As MsgBoxResult = MsgBox("Please change your default password, You will be redirected to password management window", vbInformation, "Oops!")
                                    Changepwd.Show()
                                    Changepwd.txtOldpass.Text = Clipboard.GetText
                                End If
                            Else
                                attempt = Logn.GetLoginAttempt(username)
                                attempt = attempt + 1
                                If attempt > 3 Then
                                    Logn.LockAccount(username)
                                    lblattempt.Text = "Account Locked"
                                Else
                                    Logn.UpdateLoginAttempt(username, attempt)
                                    lblattempt.Text = "Invalid username or password ! Try again" & attempt
                                End If
                            End If

                        End If

                    Else
                        lblattempt.Text = "Password expired !"
                    End If


                Else
                    If Logn.AccountStatus(username, "Locked") = True Then
                        lblattempt.Text = "Your Account is Locked,Unlock your account"
                    ElseIf Logn.AccountStatus(username, "InActive") = True Then
                        lblattempt.Text = "Account is not active, Contact Administrator"
                    ElseIf Logn.AccountStatus(username, "Released") = True Then
                        lblattempt.Text = "Account Status is released ,Please contact Admin"
                    End If
                End If
            Else
                lblattempt.Text = "User account not Exists, Please register!"
            End If
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '   Catch ex As IO.IOException
        End Try

    End Sub 'Required

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        LoginPanel.Visible = False
        txtID.Text = Nothing
        txtPass.Text = Nothing
        lblattempt.Text = Nothing
    End Sub


#End Region

#Region "Profile Selector"

    Private Sub DefaultProfile_Click(sender As Object, e As EventArgs) Handles DefaultProfile.Click
        Try
            ThinkProfile.Text = DefaultProfile.Text
            ThinkProfile.Tag = DefaultProfile.Tag
            ProfileChanger(DefaultProfile.Text, DefaultProfile.Tag)
            Call HomeProfileset()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub Profile2_Click(sender As Object, e As EventArgs) Handles Profile2.Click
        Try
            ThinkProfile.Text = Profile2.Text
            ThinkProfile.Tag = Profile2.Tag
            ProfileChanger(Profile2.Text, Profile2.Tag)
            Call HomeProfileset()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub Profile3_Click(sender As Object, e As EventArgs) Handles Profile3.Click
        Try
            ThinkProfile.Text = Profile3.Text
            ThinkProfile.Tag = Profile3.Tag
            ProfileChanger(Profile3.Text, Profile3.Tag)
            Call HomeProfileset()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub Profile4_Click(sender As Object, e As EventArgs) Handles Profile4.Click
        Try
            ThinkProfile.Text = Profile4.Text
            ThinkProfile.Tag = Profile4.Tag
            ProfileChanger(Profile4.Text, Profile4.Tag)
            Call HomeProfileset()
        Catch ex As IO.IOException
            '  Catch ex As NullReferenceException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Sub ProfileChanger(Profile As String, ID As Integer)
        Try
            Dim value As String = Profile
            Dim valArr = value.Split("::")
            TP_Project = Trim(valArr(0))
            TP_Process = Trim(valArr(2))
            TP_SubProcess = Trim(valArr(4))
            TP_ProcessID = ID
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Sub ProfileLoad()
        Try
            Dim conn As New pgConnect
            Dim var As New Encryption

            var.Encrypt(My.Settings.EmplID)
            Dim eid As String = var.encr

            Dim reader As NpgsqlDataReader = conn.GetRecords("think_profile", "*", "empl_id=@value1", eid)
            While reader.Read

                If reader("profile").ToString = "Default" Then
                    DefaultProfile.Text = reader("project").ToString & " :: " & reader("process").ToString & " :: " & reader("sub_process").ToString
                    DefaultProfile.Tag = reader("project_id")
                    DefaultProfile.Checked = True
                ElseIf reader("profile").ToString = "Profile-2" Then
                    Profile2.Text = reader("project").ToString & " :: " & reader("process").ToString & " :: " & reader("sub_process").ToString
                    Profile2.Tag = reader("project_id")

                ElseIf reader("profile").ToString = "Profile-3" Then
                    Profile3.Text = reader("project").ToString & " :: " & reader("process").ToString & " :: " & reader("sub_process").ToString
                    Profile3.Tag = reader("project_id")
                ElseIf reader("profile").ToString = "Profile-4" Then
                    Profile4.Text = reader("project").ToString & " :: " & reader("process").ToString & " :: " & reader("sub_process").ToString
                    Profile4.Tag = reader("project_id")
                End If

            End While
        Catch ex As IO.IOException
            '   Dim line As String = ex.StackTrace.ToString
            '    Dim LineNo() As String = Split(line, "line")
            '    Dim lg As New ErrorLogger
            '   lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub HomeProfileset()

        Try
            lblName.Text = TP_UserName
            lblEmplID.Text = TP_EmplID
            lblAccount.Text = TP_UserRole
            lblProject.Text = TP_Project
            lblProcess.Text = TP_Process
            lblSubProcess.Text = TP_SubProcess
            lblProjectID.Text = TP_ProcessID

            ThinkProfile.Text = TP_Project & " :: " & TP_Process & " :: " & TP_SubProcess
            ThinkProfile.Tag = TP_ProcessID
        Catch ex As IO.IOException

            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        End Try


    End Sub 'Required


#End Region

#Region "Option Cliks"

    Private Sub TimeViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tmTimeView.Click
        TimeView.Show()
    End Sub

    Private Sub SMSetup_Click(sender As Object, e As EventArgs)
        'Old_Setup.Show()
    End Sub 'required

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Old_ThinkSetup.Show()
    End Sub
    Private Sub MenuErrorLog_Click(sender As Object, e As EventArgs)
        ErrorLog.Show()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        ThinkBot.Show()

    End Sub

    Private Sub ErrorLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ErrorLogToolStripMenuItem.Click
        ErrorLog.Show()
    End Sub

    Private Sub Button2_Click_5(sender As Object, e As EventArgs)
        ProjectCreator.Show()
    End Sub
    Private Sub DataTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataTransferToolStripMenuItem.Click
        DataTransfer.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dv As New Old_ThinkSetup
        dv.Show()
    End Sub

    Private Sub ThinkManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThinkManagementToolStripMenuItem.Click
        ThinkManagement.Show()
    End Sub

    Private Sub ProjectCreatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectCreatorToolStripMenuItem.Click
        ProjectCreator.Show()
        ProjectCreator.OpenType = "ProjectAdd"
    End Sub

    Private Sub menSetup_Click(sender As Object, e As EventArgs)
        Me.Hide()
        'Old_Setup.Show()
    End Sub

    Private Sub msRegister_Click(sender As Object, e As EventArgs) Handles msRegister.Click
        Me.Hide()
        Registration.Show()
    End Sub

    Private Sub msLogin_Click(sender As Object, e As EventArgs) Handles msLogin.Click
        LoginPanel.Visible = True
        txtID.Focus()
    End Sub

    Private Sub msExit_Click(sender As Object, e As EventArgs) Handles msExit.Click

        If TimeViewStatus = True Then
            Dim msg As MsgBoxResult = MsgBox("TimeView is still running,Kindly Close TimeView before exiting the application", vbInformation, "LoggedIn")
            Exit Sub
        Else
            Call AppEvents.LogOutTimeStamp()
            'Notify.Visible = False
            'Notify.Dispose()
            Me.Close()
        End If

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuLogout.Click

        Try
            If TimeViewStatus = True Then
                Dim msg As MsgBoxResult = MsgBox("TimeView is still running,Kindly Close TimeView ", vbInformation, "LoggedIn")

                Exit Sub
            Else
                My.Settings.RememberMe = False
                My.Settings.Save()
                Call LoginMenu()
                Call AppEvents.LogOutTimeStamp()
                HomeProfile.Visible = False
                LoginPanel.Visible = True
                TimeViewStatus = False
            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try



    End Sub 'required

    Private Sub Button2_Click_6(sender As Object, e As EventArgs)
        Dim conn As New pgConnect
        Dim Dt As DataTable = Nothing
        conn.GetRecordsGRID("user_details", "user_id,empl_id,project_id,password_change_date,password")
        Dt = conn.DataTable


        For Each row In Dt.Rows
            Dim con As New pgConnect
            Dim value As String = row("user_id") & "^" & row("empl_id") & "^" & row("project_id") & "^" & row("password_change_date") & "^" & row("password")
            con.InsertRecord("pass_change_audit", "user_id,empl_id,process_id,date,pass", value)
        Next

    End Sub

    Private Sub MenuCurrentProfile_Click(sender As Object, e As EventArgs) Handles MenuCurrentProfile.Click
        Try
            Dim msg2 As MsgBoxResult = MsgBox("Project-ID : " & TP_ProcessID & vbNewLine &
                    "User-ID : " & TP_UserID & vbNewLine &
                    "Project : " & TP_Project & vbNewLine &
                    "Process : " & TP_Process & vbNewLine &
                    "Sub Process : " & TP_SubProcess)
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub


    Private Sub ConfFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Setup.Show()
    End Sub

    Private Sub Button1_Click_6(sender As Object, e As EventArgs)
        Old_ThinkSetup.Show()
    End Sub
    Private Sub Button1_Click_9(sender As Object, e As EventArgs)
        Changepwd.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem1.Click
        Changepwd.Show()
    End Sub

    Private Sub PasswordManagementToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        PasswordManagement.Show()
    End Sub

    Private Sub UnlockAccount_Click(sender As Object, e As EventArgs) Handles UnlockAccnt.Click
        UnloAccount.Show()
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        UnloAccount.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim conn As New pgConnect
        Dim enc As New Encryption
        Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("break_time_log", "*",,, "id Desc")

        While reader.Read
            'MsgBox(reader("name").ToString)
            If CheckEncryprion(reader("name").ToString) = True Then
                'MsgBox(reader("name").ToString)
                'MsgBox(enc.decrypt(reader("name").ToString))

                Dim updt As New pgConnect

                Dim value As String = enc.decrypt(reader("name").ToString) & "^" & reader("id")
                updt.UpdateRecord("break_time_log", "name=@value1", value, "id=@value2")

            End If
        End While

    End Sub

    Dim consent_content As String = Nothing
    Dim privacy_policy As String = Nothing
    Dim user_name As String = My.Settings.Name


    Private Sub ViewMyConsentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMyConsentToolStripMenuItem.Click


        'If consent_check() = False Then
        '    Me.Enabled = False
        '    AppConsent.Show()
        'Else
        '    Dim conn As New pgConnect
        '    Dim dr As NpgsqlDataReader = conn.GetRecords("app_consent", "*")
        '    Dim supevisor_name As String = supervisor()

        '    If dr.HasRows Then
        '        While dr.Read
        '            consent_content = dr("consent_content")
        '            privacy_policy = dr("privacy_policy")
        '        End While
        '    End If

        '    Dim value2 As String = consent_content.Replace("@user", user_name)
        '    Dim value3 As String = value2.Replace("@superviser", supevisor_name)
        '    Dim msg2 As MsgBoxResult = MsgBox(value3,, "Consent for Think Pro Lite Application")

        'End If
        Application_Consent.openas = "view"
        Application_Consent.Show()
        Application_Consent.Activate()

    End Sub

    Public Function supervisor()
        Dim conn As New pgConnect
        Dim value As String = My.Settings.Project & "^" & My.Settings.Process & "^" & My.Settings.SubProcess
        Dim supervi As String = Nothing

        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "*", "project=@value1 AND process=@value2 AND sub_process=@value3", value)
        If dr.HasRows Then
            While dr.Read
                supervi = dr("project_lead")
            End While
        End If
        Return supervi

    End Function

    Private Sub DataRetentionPolicyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataRetentionPolicyToolStripMenuItem.Click
        Dim conn As New pgConnect
        Dim value As String = My.Settings.Project & "^" & My.Settings.Process & "^" & My.Settings.SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
        Dim sdd As Integer = 0
        Dim hdd As Integer = 0

        If dr.HasRows Then
            While dr.Read
                sdd = dr("soft_delete_days")
                hdd = dr("hard_delete_days")
            End While
        End If

        Dim msg2 As MsgBoxResult = MsgBox("As per data retention policy of your process data will not visible after " & sdd & " day(s) and will be deleted after " & hdd & " day(s)", vbInformation, "Data Retention Policy")
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim dv As New Old_ThinkSetup
        dv.Show()
    End Sub

    Private Sub SettingToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

    End Sub

    Private Sub BrowseConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseConfigFileToolStripMenuItem.Click
        Dim ConfPAth As String = Nothing
        Try
            Dim OFD As New OpenFileDialog
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            OFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            Dim result As DialogResult = OFD.ShowDialog()


            If result = Windows.Forms.DialogResult.OK Then
                ConfPAth = OFD.FileName

                Dim enc As New Encryption
                Dim lines() As String = System.IO.File.ReadAllLines(ConfPAth)


                My.Settings.db_name = enc.decrypt(lines(1))
                My.Settings.db_ip = enc.decrypt(lines(2))
                My.Settings.db_port = enc.decrypt(lines(3))
                My.Settings.db_id = enc.decrypt(lines(4))
                My.Settings.db_pass = enc.decrypt(lines(5))

            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ConsentManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsentManagementToolStripMenuItem.Click
        App_Consent_Admin.Show()
    End Sub

    Private Sub msDataMigration_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClearTemp_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LoginPanel_Paint(sender As Object, e As PaintEventArgs) Handles LoginPanel.Paint

    End Sub





#End Region




End Class
