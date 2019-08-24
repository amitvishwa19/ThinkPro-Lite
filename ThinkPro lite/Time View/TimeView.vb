Imports System.ComponentModel
Imports Npgsql
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports ThinkProlite.TpTimer

Public Class TimeView


#Region "Variables"

    Private Declare Function LockWorkStation Lib "user32.dll" () As Long
    Public stime, stime1, etime, etime1, pstime, petime As Date
    Public ProjectID = Home.TP_ProcessID
    Public Project = Home.TP_Project
    Public Process = Home.TP_Process
    Public SubProcess = Home.TP_SubProcess
    Public UName = Home.TP_UserName
    Public EmplID = Home.TP_EmplID
    Public UserID = Home.TP_UserID
    Public LoginDate = Home.TP_LoginDate
    Public SummaryClickedDate As Date
    Public SummaryClickedItem As String
    Public SystemLockCheck As Boolean = Home.TP_SystemLockCheck
    Public SystemSwitchCheck As Boolean = Home.TP_SystemSwitchCheck
#End Region

#Region "Activity Time"
    Dim CurrentActivity As String = Nothing
    Dim ActivityStatus As String = Nothing
    Dim ActivityStart As Date = Nothing
    Dim ActivityEnd As Date = Nothing
    Dim TotalActivityTime As Double = Nothing
#End Region

#Region "Pc Lock Time"

#End Region

#Region "Break Time"
    Dim BreakStatus As Boolean = Nothing
    Dim BreakStart As Date = Nothing
    Dim BreakEnd As Date = Nothing
    Dim TotalBreak As Double = Nothing
    Dim OverallBreak As Double = Nothing
#End Region

#Region "Timeview Activity Variable"
    Dim ExLock As Boolean = Nothing
    Dim iVol As Boolean = Nothing
    Dim iActID As Boolean = Nothing
    Dim iCmnt As Boolean = Nothing
#End Region

#Region "Other Variable"
    Dim iLockStatus As String = Nothing
#End Region

#Region "Activity-subact-task fill"

    Private Sub FillActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & "Active"
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND status =@value4", value, "activity asc")
            lstActivity.Items.Clear()
            While reader.Read
                lstActivity.Items.Add(reader("activity"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Public Sub FillActivityUserAllocation()
        Try
            Dim Conn As New pgConnect
            Dim LDate As Date = My.Settings.LoginDate
            Dim iDate As String = Format(LDate, "dd-MMM-yy")
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & iDate & "^" & EmplID
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date =@value4 AND empl_id=@value5", value, "activity asc")
            lstActivity.Items.Clear()
            While reader.Read
                lstActivity.Items.Add(reader("activity"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Private Sub FillSubActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & lstActivity.Text & "^" & "Active"
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT sub_activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND status =@value5", value, "sub_activity asc")
            LstSubActivity.Items.Clear()
            While reader.Read
                LstSubActivity.Items.Add(reader("sub_activity"))
            End While
        Catch ex As IO.IOException

        End Try
    End Sub

    Private Sub FillTask()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & lstActivity.Text & "^" & LstSubActivity.Text & "^" & "Active"
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT task", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND sub_activity =@value5 AND status =@value6", value, "task asc")
            lstTask.Items.Clear()
            While reader.Read
                lstTask.Items.Add(reader("task"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Function ActivityCheck()
        Dim Conn As New pgConnect
        Dim LDate As Date = My.Settings.LoginDate
        Dim iDate As String = Format(LDate, "dd-MMM-yy")
        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & iDate
        Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date =@value4", value)
        If reader.HasRows Then
            Return True
        Else
            Return False
        End If
    End Function 'This will chec if activity is already there or not

#End Region

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As MsgBoxResult
        response = MsgBox("Are you sure you want to Close", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Confirm")
        If response = MsgBoxResult.Yes Then

            ActivityEnd = Now
            Call TimeViewTimeUpdate()
            Call TeamViewStatusUpdate("Logged In", "No Activity selected")
            Home.TimeViewStatus = False
            Home.Show()
            Home.Visible = True

        ElseIf response = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdEndday_Click(sender As Object, e As EventArgs) Handles cmdEndday.Click
        Me.Close()
    End Sub 'Required

    Private Sub TimeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.ActivityTicker = True Then
            ATEnabled.Checked = True
            ATDisabled.Checked = False
        ElseIf My.Settings.ActivityTicker = False Then
            ATDisabled.Checked = True
            ATEnabled.Checked = False
        End If

        AddHandler SystemEvents.SessionSwitch, AddressOf SessionSwitch_Event
        Home.TimeViewStatus = True

        FillActivity()
        TimerClock.Start()
        'lblDate.Text = Home.lblDate.Text

        DateTimePicker.Format = DateTimePickerFormat.Custom
        DateTimePicker.CustomFormat = "dd-MMM-yy"
        Dim idate As Date = LoginDate
        lblDateShow.Text = Format(idate, "dd-MMMM-yyyy")

    End Sub

    Private Sub lstActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstActivity.SelectedIndexChanged
        LstSubActivity.Items.Clear()
        lstTask.Items.Clear()
        FillSubActivity()
        LstSubActivity.Refresh()
        Label2.Visible = True
        LstSubActivity.Visible = True
    End Sub

    Private Sub LstSubActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstSubActivity.SelectedIndexChanged
        'lblSubActivity.Text = LstSubActivity.Text
        lstTask.Items.Clear()
        FillTask()
        lstTask.Refresh()
        Label3.Visible = True
        lstTask.Visible = True
    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick
        lblCurTime.Text = DateTime.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub lstTask_DoubleClick(sender As Object, e As EventArgs) Handles lstTask.DoubleClick
        Call DubClick()
        Call TimeGroupFill()
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        TimeDetailsSummary()
    End Sub

    Private Sub lblTime1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblTime1.LinkClicked, lblTime2.LinkClicked, lblTime3.LinkClicked, lblTime4.LinkClicked, lblTime5.LinkClicked, lblTime6.LinkClicked, lblTime7.LinkClicked
        SummaryClickedDate = CType(sender, LinkLabel).Tag
        SummaryClickedItem = "TimeSummary"
        TimeSummary.Show()
    End Sub 'Required

    Private Sub lblTotalLock_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        SummaryClickedDate = CType(sender, LinkLabel).Tag
        SummaryClickedItem = "TotalLock"
    End Sub 'Required

    Private Sub lblTotalBreak_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        SummaryClickedDate = CType(sender, LinkLabel).Tag
        SummaryClickedItem = "TotalBreak"
    End Sub 'Required

    Sub DubClick()
        Try

            '-------Checking Task is selected properley or not-----------------
            If lstTask.SelectedItem = "" Then
                Dim response As MsgBoxResult = MsgBox("Kindly select Task Properly", vbCritical, "Select Task")
                Exit Sub
            End If
            '------------------------------------------------------------------

            '----------------------Starting Activity---------------------------
            Dim response2 As MsgBoxResult = MsgBox("" & vbCrLf & vbCrLf & "Do you want to start new Activity?", vbYesNo, "New Activity")
            If response2 = vbYes Then


                CurrentActivity = lstActivity.Text & "-" & LstSubActivity.Text & "-" & lstTask.Text

                ' ''''''''''''''''For volume or ActID IF UPT is defined------------------------
                If iVol = True And txtVolume.Text = 0 Or txtVolume.Text = Nothing Then
                    Dim response3 As MsgBoxResult = MsgBox("Please enter valid Volume for your last activity", vbInformation, "Volume missing")
                    ErrorProviderError.SetError(txtComments, "")
                    ErrorProviderok.SetError(txtComments, "")
                    ErrorProviderWarning.SetError(txtComments, "")
                    ErrorProviderWarning.SetError(txtVolume, "Please enter valid Volume for your last activity")
                    txtVolume.Focus()
                    Exit Sub
                End If
                ''---------------------------------------------------------------------------------

                ' ''''''''''''''''For ActID feild Validation------------------------
                If iActID = True And txtID.Text = Nothing Then
                    Dim response3 As MsgBoxResult = MsgBox("Please enter valid activity ID for your last activity", vbInformation, "Activity ID Missing")
                    ErrorProviderError.SetError(txtID, "")
                    ErrorProviderok.SetError(txtID, "")
                    ErrorProviderWarning.SetError(txtID, "Please enter valid activity ID for your last activity")
                    txtID.Focus()
                    Exit Sub
                End If
                ''---------------------------------------------------------------------------------

                ' ''''''''''''''''For Indirect and Tcs internal Activities------------------------
                If iCmnt = True And txtComments.Text = Nothing Then
                    Dim response4 As MsgBoxResult = MsgBox("Please enter valid comment for your last activity", vbInformation, "Comments missing")
                    ErrorProviderError.SetError(txtComments, "")
                    ErrorProviderok.SetError(txtComments, "")
                    ErrorProviderWarning.SetError(txtComments, "")
                    ErrorProviderWarning.SetError(txtComments, "Please enter valid comment for your last activity")
                    txtComments.Focus()
                    Exit Sub
                End If


                If ActivityStatus = Nothing Then
                    ActivityStatus = "Running"

                    ActivityStart = Now

                    lblactivity.Text = lstActivity.Text
                    lblsubactivity.Text = LstSubActivity.Text
                    lbltask.Text = lstTask.Text

                    Me.Text = lbltask.Text & "---" & lblactivity.Text & "---" & lblsubactivity.Text _
                       & "  Activity Started @ " & DateTime.Now.ToString("HH:mm tt")

                Else

                    ActivityEnd = Now
                    Call TimeViewTimeUpdate()
                    ActivityStart = Now
                    ActivityLockTime = Nothing
                    TotallLockTime = Nothing
                    TotalBreak = Nothing
                    OverallBreak = Nothing
                    TotalActivityTime = Nothing
                    ActivitySwitchTime = Nothing
                    lblactivity.Text = lstActivity.Text
                    lblsubactivity.Text = LstSubActivity.Text
                    lbltask.Text = lstTask.Text
                    Me.Text = lbltask.Text & "---" & lblactivity.Text & "---" & lblsubactivity.Text _
                       & "       Activity Started @ " & DateTime.Now.ToString("HH:mm tt") _
                       & "  Last Activity total time =>" & TotalActivityTime
                    txtComments.Text = ""
                    txtID.Text = ""
                    txtVolume.Text = 0
                End If

                TmrCurrentAct.Start() ''''''''''''''''''Timer for Current Activity
                lblVolume.Visible = True
                lblID.Visible = True
                lblComments.Visible = True
                txtVolume.Visible = True
                txtID.Visible = True
                txtComments.Visible = True
                cmdBreak.Visible = True
                cmdEndday.Visible = True
                ActLocTime.Text = "Activty Lock (M) : " & 0
                ActBrkTime.Text = "Activty Break (M) : " & 0

                txtVolume.Text = 0

                Call Sequence()
                Call TotalBreakLog()
                Call TotalLockLog()

                If My.Settings.ActivityTicker = True Then
                    Call TimeTickerPreview()
                End If

                Call TimeDetailsSummary()
                Call TeamViewStatusUpdate("Active", CurrentActivity)


            Else

            End If

            ErrorProviderWarning.SetError(txtVolume, "")
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtComments, "")


        Catch ex As IO.IOException
            ' Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")
            '   Dim lg As New ErrorLogger
            '    lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Required

    Sub TimeViewTimeUpdate()

        Dim Conn As New pgConnect

        Try
            Dim LDate As Date = My.Settings.LoginDate
            Dim ival As String = Format(LDate, "dd-MMM-yy")


            Dim SecondsDifference As Double = Format(DateDiff(DateInterval.Second, ActivityStart, ActivityEnd), "0.0")
            Dim TotalTime As Double = Format(SecondsDifference / 60, "0.0")

            If OverallBreak < 0 Then
                OverallBreak = 0
            End If

            If TotallLockTime < 0 Then
                TotallLockTime = 0
            End If

            If ActivitySwitchTime < 0 Then
                ActivitySwitchTime = 0
            End If


            Dim NetTime As Double = TotalTime - OverallBreak - TotallLockTime - ActivitySwitchTime


            If NetTime < 0 Then
                NetTime = TotalTime
            End If

            Conn.InsertRecord("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,start_time,end_time,total_time,volume,project_id,act_id,comment,added_by",
                              "" & Format(LDate, "dd-MMM-yy") &
                              "^" & Crypto.Encrypt(EmplID) &
                              "^" & UName &
                              "^" & Project &
                              "^" & Process &
                              "^" & SubProcess &
                              "^" & lblactivity.Text &
                              "^" & lblsubactivity.Text &
                              "^" & lbltask.Text &
                              "^" & Format(ActivityStart, "dd-MM-yyyy HH:mm tt") &
                              "^" & Format(ActivityEnd, "dd-MM-yyyy HH:mm tt") &
                              "^" & NetTime &
                              "^" & txtVolume.Text &
                              "^" & ProjectID &
                              "^" & txtID.Text &
                              "^" & txtComments.Text &
                              "^" & "System" & "")


        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If

        End Try
    End Sub 'Required

    Private Sub Sequence()

        Dim conn As New pgConnect

        Try


            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & lstActivity.Text & "^" & LstSubActivity.Text & "^" & lstTask.Text
            Dim reader As Npgsql.NpgsqlDataReader = conn.GetRecords("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND sub_activity =@value5 AND task =@value6", value)

            While reader.Read

                If reader("ex_lock") = 1 Then
                    ExLock = True
                Else
                    ExLock = False
                End If

                If reader("volume") = 1 Then
                    iVol = True
                Else
                    iVol = False
                End If

                If reader("aid") = 1 Then
                    iActID = True
                Else
                    iActID = False
                End If

                If reader("cmnt") = 1 Then
                    iCmnt = True
                Else
                    iCmnt = False
                End If

            End While


        Catch ex As IO.IOException


            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If

        End Try

    End Sub 'Required

#Region "Time Summary Details"

    Private Sub TimeDetailsSummary()

        Try
            lblDate1.Text = Format(DateTimePicker.Value.AddDays(0), "dd-MMM-yy")
            lblTime1.Tag = Format(DateTimePicker.Value.AddDays(0), "dd-MMM-yy")

            lblDate2.Text = Format(DateTimePicker.Value.AddDays(-1), "dd-MMM-yy")
            lblTime2.Tag = Format(DateTimePicker.Value.AddDays(-1), "dd-MMM-yy")

            lblDate3.Text = Format(DateTimePicker.Value.AddDays(-2), "dd-MMM-yy")
            lblTime3.Tag = Format(DateTimePicker.Value.AddDays(-2), "dd-MMM-yy")

            lblDate4.Text = Format(DateTimePicker.Value.AddDays(-3), "dd-MMM-yy")
            lblTime4.Tag = Format(DateTimePicker.Value.AddDays(-3), "dd-MMM-yy")

            lblDate5.Text = Format(DateTimePicker.Value.AddDays(-4), "dd-MMM-yy")
            lblTime5.Tag = Format(DateTimePicker.Value.AddDays(-4), "dd-MMM-yy")

            lblDate6.Text = Format(DateTimePicker.Value.AddDays(-5), "dd-MMM-yy")
            lblTime6.Tag = Format(DateTimePicker.Value.AddDays(-5), "dd-MMM-yy")

            lblDate7.Text = Format(DateTimePicker.Value.AddDays(-6), "dd-MMM-yy")
            lblTime7.Tag = Format(DateTimePicker.Value.AddDays(-6), "dd-MMM-yy")


            Call TimeGroupFill()

        Catch ex As InvalidCastException

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)

        Finally


        End Try


    End Sub 'Required

    Private Sub TimeGroupFill()
        Dim i As Integer

        Dim Var As New Encryption


        Var.Encrypt(EmplID)
        Dim Emp_id As String = Var.encr

        Dim FilDate As Date = DateTimePicker.Value
        Dim IDate As String = Format(FilDate, "dd-MMM-yy")

        Dim ITime As Double = Nothing
        Dim TTime As Double = Nothing

        Try

            For i = -6 To 0

                Dim Conn As New pgConnect
                Dim ival As String = Format(FilDate.AddDays(i), "dd-MMM-yy")



                Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & Emp_id & "^" & Format(FilDate.AddDays(i), "dd-MMM-yy")
                Dim reader As NpgsqlDataReader = Conn.GetRecords("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND date =@value5", value)



                While reader.Read
                    ITime = reader("total_time")
                    TTime = TTime + ITime
                End While


                If i = -6 Then
                    lblTime7.Text = Format(TTime, "0.00")
                End If
                If i = -5 Then
                    lblTime6.Text = TTime
                End If
                If i = -4 Then
                    lblTime5.Text = TTime
                End If
                If i = -3 Then
                    lblTime4.Text = TTime
                End If
                If i = -2 Then
                    lblTime3.Text = TTime
                End If
                If i = -1 Then
                    lblTime2.Text = TTime
                End If
                If i = 0 Then
                    lblTime1.Text = TTime
                End If

                TTime = Nothing
                ITime = Nothing


            Next


        Catch ex As IO.IOException
            '  Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            'Catch ex As NullReferenceException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally

        End Try


    End Sub 'Required


#End Region

    Private Sub TmrCurrentAct_Tick(sender As Object, e As EventArgs) Handles TmrCurrentAct.Tick
        Try

            '''''''''''''''''''Current Activity Time'''''''''''''''''''''''''''''''''''''''''''''

            'stime = ActivityStart
            'etime = Now
            stime = System.TimeZoneInfo.ConvertTime(ActivityStart, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"))
            etime = System.TimeZoneInfo.ConvertTime(Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"))


            Dim SecondsDifference, PSecondsDifference As Integer



            SecondsDifference = DateDiff(DateInterval.Second, stime, etime)
            CurActTim.Text = "Current Activty (M) : " & Format(SecondsDifference / 60, "0.00")


            pstime = System.TimeZoneInfo.ConvertTime(ActivityStart, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"))
            petime = System.TimeZoneInfo.ConvertTime(Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"))
            PSecondsDifference = DateDiff(DateInterval.Second, pstime, petime)
            lblActivityTime.Text = Format(PSecondsDifference / 60, "0.00")



        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Required

#Region "Time Ticker"

    Dim numberOfCharactersToDisplay As Integer = 250
    Dim scrollingTextSelector As String
    Public TextIScroll As String

    Private Sub TimeTickerPreview()

        Dim x As Integer
        Dim y As Integer

        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        TextIScroll = "Current  Activity started @ " & Format(ActivityStart, "hh:mm tt") & "   " &
       "Activity  " & lblactivity.Text & "-- " & lblsubactivity.Text & "-- " & lbltask.Text

        Ticker.Enabled = True
        scrollingTextSelector = TextIScroll
        Do Until scrollingTextSelector.Length > (TextIScroll.Length + numberOfCharactersToDisplay)
            scrollingTextSelector &= "                 " & TextIScroll
        Loop

    End Sub

    Public Function MarqueeLeft(ByVal Text As String)
        Dim Str1 As String = Text.Remove(0, 1)
        Dim Str2 As String = Text(0)
        Return Str1 & Str2
    End Function

    Private Sub Ticker_Tick(sender As Object, e As EventArgs) Handles Ticker.Tick
        Dim TextIScroll As String = "Current  Activity started @ " & Format(ActivityStart, "hh:mm tt") & "   " &
       "Activity  " & lblactivity.Text & "-- " & lblsubactivity.Text & "-- " & lbltask.Text

        Static count As Integer = 0
        Me.Text = scrollingTextSelector.Substring(count, numberOfCharactersToDisplay)

        count += 1
        If count > TextIScroll.Length Then
            count = 0
        End If

    End Sub

#End Region 'Required

#Region "System Lock and Switch user event "
    Dim SwitchUserStart As Date = Nothing
    Dim SwitchUserEnd As Date = Nothing
    Dim SwitchTime As Double = Nothing
    Dim ActivitySwitchTime As Double = Nothing
    Dim TotalSwitchTime As Double = Nothing

    Dim LockStatus As Boolean = Nothing
    Dim LockStart As Date = Nothing
    Dim LockEnd As Date = Nothing
    Dim ActivityLockTime As Double = Nothing
    Dim TotallLockTime As Double = Nothing

    Private Sub SessionSwitch_Event(ByVal sender As Object, ByVal e As SessionSwitchEventArgs)

        Try

            If SystemLockCheck = False Then
                Exit Sub
            End If

            If BreakStatus = True Or ExLock = True Then
                Exit Sub
            End If


            'System Switch check
            If SystemSwitchCheck = True Then
                If e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleDisconnect Then
                    SwitchUserStart = Now
                    Call TeamViewStatusUpdate("Switch User", CurrentActivity)
                ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleConnect Then
                    SwitchUserEnd = Now
                    Dim SecondsDifference As Integer
                    SecondsDifference = DateDiff(DateInterval.Second, SwitchUserStart, SwitchUserEnd)
                    SwitchTime = Format(SecondsDifference / 60, "0.00")
                    ActivitySwitchTime += SwitchTime
                    TotalSwitchTime += SwitchTime
                    TotalSwitchTime = Format(TotalSwitchTime, "0.0")
                    Call TeamViewStatusUpdate("Active", CurrentActivity)
                    Call StatusUpdate("Switch user", SwitchUserStart, SwitchUserEnd, SwitchTime)
                End If
            End If


            'System Lock Check
            If SystemLockCheck = True Then
                If e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLock Then
                    LockStatus = True
                    LockStart = Now
                    Call TeamViewStatusUpdate("System Locked", CurrentActivity)
                ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionUnlock Then
                    LockStatus = False
                    LockEnd = Now

                    Dim SecondsDifference As Double
                    SecondsDifference = DateDiff(DateInterval.Second, LockStart, LockEnd)
                    ActivityLockTime = Format(SecondsDifference / 60, "0.00")
                    TotallLockTime += ActivityLockTime
                    TotallLockTime = Format(TotallLockTime, "0.0")
                    ActLocTime.Text = "Activty Lock (M) : " & TotallLockTime

                    Call StatusUpdate("System Locked", LockStart, LockEnd, ActivityLockTime)
                    Call TotalLockLog()
                    Call TeamViewStatusUpdate("Active", CurrentActivity)

                End If
            End If

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, "SessionSwitch_Event", ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Updated

    Private Sub StatusUpdate(Status As String, StartTime As String, EndTime As String, TotalTime As Double)
        Dim lDate As Date = LoginDate
        Dim Var As New Encryption

        Try

            Dim conn As New pgConnect
            conn.InsertRecord("break_time_log", "name,empl_id,project,process,sub_process,date,status,start_time,end_time,total_time,user_id",
                              "" & UName & "^" & Crypto.Encrypt(EmplID) & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Format(lDate, "dd-MMM-yyyy") & "^" & Status & "^" & StartTime & "^" & EndTime & "^" & TotalTime & "^" & UserID & "")

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, "StatusUpdate", ex.Message)
        End Try

    End Sub 'Updated

#End Region 'Required

#Region "Break Click and Update"

    Private Sub cmdBreak_Click(sender As Object, e As EventArgs) Handles cmdBreak.Click

        Try
            With cmdBreak
                If cmdBreak.Text = "Start Break" Then
                    cmdBreak.Text = "End Break"

                    BreakStatus = True
                    BreakStart = Now

                    cmdBreak.BackColor = Color.OrangeRed
                    BreakPopup.Show()
                    txtVolume.Enabled = False
                    txtID.Enabled = False
                    txtComments.Enabled = False
                    lstActivity.Enabled = False
                    LstSubActivity.Enabled = False
                    lstTask.Enabled = False
                    cmdEndday.Enabled = False


                    Call TeamViewStatusUpdate("Break", CurrentActivity)


                Else
                    BreakStatus = False
                    BreakEnd = Now
                    cmdBreak.Text = "Start Break"
                    cmdBreak.BackColor = Color.Gainsboro
                    BreakPopup.Close()
                    txtVolume.Enabled = True
                    txtID.Enabled = True
                    txtComments.Enabled = True
                    lstActivity.Enabled = True
                    LstSubActivity.Enabled = True
                    lstTask.Enabled = True
                    cmdEndday.Enabled = True


                    Dim SecondsDifference As Integer
                    SecondsDifference = DateDiff(DateInterval.Second, BreakStart, BreakEnd)
                    TotalBreak = Format(SecondsDifference / 60, "0.00")
                    OverallBreak = Format(OverallBreak + TotalBreak, "0.0")
                    OverallBreak = Format(OverallBreak, "0.0")
                    ActBrkTime.Text = "Activty Break (M) : " & OverallBreak


                    Call BreakUpdate()
                    Call TotalBreakLog()
                    Call TeamViewStatusUpdate("Active", CurrentActivity)

                End If
            End With

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub BreakUpdate()
        Dim lDate As Date = LoginDate

        Try

            Dim conn As New pgConnect
            conn.InsertRecord("break_time_log", "name,empl_id,project,process,sub_process,date,status,start_time,end_time,total_time",
                              "" & UName & "^" & Crypto.Encrypt(EmplID) & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Format(lDate, "dd-MMM-yy") & "^" & "Break" & "^" & BreakStart & "^" & BreakEnd & "^" & TotalBreak & "")

        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub

#End Region 'Required

#Region "Day Lock and Break Retriving"
    Dim MasterLockTime As Double = Nothing
    Dim MasterBreakTime As Double = Nothing

    Private Sub TotalBreakLog()
        Try
            Dim BreakTime As Double = Nothing

            Dim Var As New Encryption
            Var.Encrypt(EmplID)
            Dim Emp_id As String = Var.encr

            Dim FilDate As Date = My.Settings.LoginDate
            Dim IDate As String = Format(FilDate, "dd-MMM-yy")

            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & Emp_id & "^" & "Break" & "^" & IDate
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("break_time_log", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND status =@value5 AND date =@value6", value)
            While reader.Read
                BreakTime = reader("total_time")
                MasterBreakTime = MasterBreakTime + BreakTime
            End While
            lblTotalBreak.Text = "Total Break (M) : " & MasterBreakTime

            MasterBreakTime = Nothing
        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try
    End Sub

    Private Sub TotalLockLog()

        Try
            Dim LockTime As Double = Nothing

            Dim Var As New Encryption
            Var.Encrypt(EmplID)
            Dim Emp_id As String = Var.encr

            Dim FilDate As Date = My.Settings.LoginDate
            Dim IDate As String = Format(FilDate, "dd-MMM-yy")


            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & Emp_id & "^" & "System Locked" & "^" & IDate
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("break_time_log", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND status =@value5 AND date =@value6", value)
            While reader.Read
                LockTime = reader("total_time")
                MasterLockTime = MasterLockTime + LockTime
            End While
            lblTotalLock.Text = "Total Lock (M) : " & MasterLockTime
            MasterLockTime = Nothing

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub

#End Region 'Required

#Region "Current Activity To Team View"

    Private Sub TeamViewStatusUpdate(Status As String, Activity As String)

        Try

            Dim tdate As String = Format(Now, "ddMMyyyy")
            Dim ActID As String = EmplID & tdate
            Dim ActivityType = Activity

            Dim value As String = Status & "^" & ActivityType & "^" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & ActID
            Dim conn As New pgConnect
            conn.UpdateRecord("team_view", "activity =@value1,activity_type =@value2,start_time =@value3", value, "act_id =@value4")

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub 'Update

#End Region

    Private Sub txtVolume_TextChanged(sender As Object, e As EventArgs) Handles txtVolume.TextChanged
        If Charcheck(txtVolume.Text) = False Then
            CharError(txtVolume)
        Else
            CharOk(txtVolume)
        End If
    End Sub

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim response2 As MsgBoxResult
        response2 = MsgBox(BreakStatus)
        If BreakStatus = True Or ExLock = True Then
            response2 = MsgBox(BreakStatus)
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim response2 As MsgBoxResult = MsgBox(activity_timer_Tick())
    End Sub

    Private Sub ATEnabled_Click(sender As Object, e As EventArgs) Handles ATEnabled.Click
        My.Settings.ActivityTicker = True
        My.Settings.Save()
        ATEnabled.Checked = True
        ATDisabled.Checked = False
    End Sub

    Private Sub ATDisabled_Click(sender As Object, e As EventArgs) Handles ATDisabled.Click
        My.Settings.ActivityTicker = False
        My.Settings.Save()
        ATEnabled.Checked = False
        ATDisabled.Checked = True
    End Sub

    Sub CharOk(cont As Control)
        ErrorProviderok.SetError(cont, "")
        ErrorProviderWarning.SetError(cont, "")
        ErrorProviderError.SetError(cont, "")
    End Sub

    Function Charcheck(Str As String) As Boolean

        If Regex.IsMatch(Str, "^[a-zA-Z0-9-_@()/ ""]+$") Then
            'lstTask.Enabled = True
            Return True
        Else
            'lstTask.Enabled = False
            Return False
        End If

    End Function

    Private Sub txtComments_TextChanged(sender As Object, e As EventArgs) Handles txtComments.TextChanged
        If Charcheck(txtComments.Text) = False Then
            CharError(txtComments)
        Else
            CharOk(txtComments)
        End If
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        If Charcheck(txtID.Text) = False Then
            CharError(txtID)
        Else
            CharOk(txtID)
        End If
    End Sub

    Private Sub ActivitySelectorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivitySelectorToolStripMenuItem.Click
        ActivitySelector.Show()
    End Sub


End Class