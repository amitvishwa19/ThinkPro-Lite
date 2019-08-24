Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System
Imports System.IO
Imports Npgsql
Imports System.Data.Odbc
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports ThinkPro_lite.User

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
    Dim TimeViewType As String = Home.TP_TimeViewType

    Dim Activity As String = Nothing
    Dim SubActivity As String
    Dim Task As String = Nothing

#End Region

#Region "Activity Time"
    Dim CurrentActivity As String = Nothing
    Dim ActivityStatus As String = Nothing
    Dim ActivityStart = Nothing
    Dim ActivityEnd = Nothing
    Dim TotalActivityTime As Double = Nothing
#End Region

#Region "Pc Lock Time"
    Dim LockStatus As Boolean = Nothing
    Dim LockStart = Nothing
    Dim LockEnd = Nothing
    Dim TotalLockTime As Double = Nothing
    Dim OverallLock As Double = Nothing
    Dim ActLockTime As Double = Nothing

#End Region

#Region "Switch User Var"
    Dim SwitchStart = Nothing
    Dim SwitchEnd = Nothing
    Public ActSwitchTime As Double = Nothing
    Public TotalSwitchTime As Double = Nothing
#End Region


#Region "Break Time"
    Dim BreakStatus As Boolean = Nothing
    Dim BreakStart = Nothing
    Dim BreakEnd = Nothing
    Dim TotalBreak As Double = Nothing
    Dim OverallBreak As Double = Nothing
#End Region

#Region "Switch User"

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
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND status =@value4", value)
            lstActivity.Items.Clear()
            While reader.Read
                lstActivity.Items.Add(reader("activity"))
            End While
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FillActivityUserAllocation()
        Try
            Dim Conn As New pgConnect
            Dim LDate As Date = My.Settings.LoginDate
            Dim iDate As String = Format(LDate, "dd-MMM-yy")
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & iDate & "^" & EmplID
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date =@value4 AND empl_id=@value5", value)
            lstActivity.Items.Clear()
            While reader.Read
                lstActivity.Items.Add(reader("activity"))
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillSubActivity()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & lstActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT sub_activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4", value)
            LstSubActivity.Items.Clear()
            While reader.Read
                LstSubActivity.Items.Add(reader("sub_activity"))
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillTask()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & lstActivity.Text & "^" & LstSubActivity.Text
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "act_id,task", "project =@value1 AND process =@value2 AND sub_process =@value3 AND activity =@value4 AND sub_activity =@value5", value)
            lstTask.Items.Clear()
            While reader.Read
                lstTask.Items.Add(reader("task"))
            End While
        Catch ex As Exception
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
            My.Settings.ActivityStatus = "Closed"
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

        ''''''''''''''''''''For Pc Lock Time''''''''''''''''''''''
        AddHandler SystemEvents.SessionSwitch, AddressOf SessionSwitch_Event


        If TimeViewType = "Default" Then
            FillActivity()
        ElseIf TimeViewType = "SelfAllocation" Then
            If ActivityCheck() = False Then
                Home.TimeViewStatus = True
                Call FillActivityUserAllocation()
                ActivitySelector.Show()
            Else
                Call FillActivityUserAllocation()
            End If
        ElseIf TimeViewType = "LeadAllocation" Then
            FillActivityUserAllocation()

            If lstActivity.Items.Count < 1 Then
                MsgBox("No activity is allocated to you,Kindly ask Process Lead to allocate activities", vbInformation, "Oops!")
            End If

        End If


        TimerClock.Start()
        'lblDate.Text = Home.lblDate.Text
        Home.TimeViewStatus = True

        DateTimePicker.Format = DateTimePickerFormat.Custom
        DateTimePicker.CustomFormat = "dd-MMM-yy"
        Dim idate As Date = LoginDate
        lblDateShow.Text = Format(idate, "dd-MMMM-yyyy")

        ''''''''''''''''''Generating default value of various calculation txtbox
        'lblCurLock.Text = 0
        'lblCurBreak.Text = 0
        'lblCurActTime.Text = 0
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Call LastActivityCheck()



    End Sub

    Private Sub LastActivityCheck()
        If My.Settings.ActivityStatus = "Running" Then

            'Last Activity Details
            Dim LastActivity As String = Nothing
            Dim ActivitySTime As Date = My.Settings.ActivityStartTime
            Dim ActivityETime As Date = Now
            Dim SecondsDifference As Integer
            SecondsDifference = DateDiff(DateInterval.Second, ActivitySTime, ActivityETime)
            Dim TotalTime As Double = Format(SecondsDifference / 60, "0.0")

            LastActivity = "Activity Started @ :- " & Format(ActivitySTime, "dd-MM-yy hh:mm tt") & vbNewLine &
                           "Total Time :- " & TotalTime


            Dim result As Integer = MessageBox.Show("ThinkPro was not closed properly,do you want to restore last activity" & vbNewLine & vbNewLine & LastActivity, "Actvity restore!", MessageBoxButtons.YesNo)
            
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                lstActivity.SetSelected(My.Settings.Activity, True)
                LstSubActivity.SetSelected(My.Settings.SubActivity, True)
                lstTask.SetSelected(My.Settings.Task, True)
                Dim ival As Date = My.Settings.ActivityStartTime
                ActivityStart = ival
                TmrCurrentAct.Start()
                lblVolume.Visible = True
                lblID.Visible = True
                lblComments.Visible = True
                txtVolume.Visible = True
                txtID.Visible = True
                txtComments.Visible = True
                cmdBreak.Visible = True
                cmdEndday.Visible = True
                ActivityStatus = "Running"
                Call TotalBreakLog()
                Call TotalLockLog()
                Call TimeTickerPreview()
                Call DoubleClickUpdate()
                Call TimeGroupFill()
            End If

        End If

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
        Try
            lblCurTime.Text = DateTime.Now.ToString("hh:mm:ss")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstTask_DoubleClick(sender As Object, e As EventArgs) Handles lstTask.DoubleClick
        Call DubClick()
        Call TimeGroupFill()
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        Call TimeGroupFill()
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
                MsgBox("Kindly select Task Properly", vbCritical, "Select Task")
                Exit Sub
            End If
            '------------------------------------------------------------------

            '----------------------Starting Activity---------------------------
            If MsgBox("" & vbCrLf & vbCrLf & "Do you want to start new Activity?", vbYesNo, "New Activity") = vbYes Then

                TmrCurrentAct.Start()
                My.Settings.ActivityStatus = "Running"
                My.Settings.ActivityStartTime = Now
                My.Settings.Activity = lstActivity.SelectedIndex
                My.Settings.SubActivity = LstSubActivity.SelectedIndex
                My.Settings.Task = lstTask.SelectedIndex
                My.Settings.Save()
                CurrentActivity = lstActivity.Text & "-" & LstSubActivity.Text & "-" & lstTask.Text

                Activity = lstActivity.SelectedItem.ToString
                SubActivity = LstSubActivity.SelectedItem.ToString
                Task = lstTask.SelectedItem.ToString

                ' ''''''''''''''''For volume or ActID IF UPT is defined------------------------
                If iVol = True And txtVolume.Text = Nothing Then
                    MsgBox("Please enter valid Volume for your last activity", vbInformation, "Volume missing")
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
                    MsgBox("Please enter valid activity ID for your last activity", vbInformation, "Activity ID Missing")
                    ErrorProviderError.SetError(txtID, "")
                    ErrorProviderok.SetError(txtID, "")
                    ErrorProviderWarning.SetError(txtID, "Please enter valid activity ID for your last activity")
                    txtID.Focus()
                    Exit Sub
                End If
                ''---------------------------------------------------------------------------------

                ' ''''''''''''''''For Indirect and Tcs internal Activities------------------------
                If iCmnt = True And txtComments.Text = Nothing Then
                    MsgBox("Please enter valid comment for your last activity", vbInformation, "Comments missing")
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
                       & "  Activity Started @ " & DateTime.Now.ToString("hh:mm")

                Else

                    ActivityEnd = Now
                    Call TimeViewTimeUpdate()
                    ActivityStart = Now
                    TotalLockTime = Nothing
                    OverallLock = Nothing
                    TotalBreak = Nothing
                    OverallBreak = Nothing
                    TotalActivityTime = Nothing
                    lblactivity.Text = lstActivity.Text
                    lblsubactivity.Text = LstSubActivity.Text
                    lbltask.Text = lstTask.Text
                    Me.Text = lbltask.Text & "---" & lblactivity.Text & "---" & lblsubactivity.Text _
                       & "       Activity Started @ " & DateTime.Now.ToString("hh:mm tt") _
                       & "  Last Activity total time =>" & TotalActivityTime
                    txtComments.Text = ""
                    txtID.Text = ""
                    txtVolume.Text = ""
                End If

                'TmrCurrentAct.Start() ''''''''''''''''''Timer for Current Activity
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

                'lblCurLock.Text = 0
                'lblCurBreak.Text = 0
                'txtVolume.Text = 0

                My.Settings.ActivityLock = 0
                My.Settings.ActivityBreak = 0
                My.Settings.Save()


                Call TimeTickerPreview()
                Call TimeGroupFill()
                Call DoubleClickUpdate()
                'Call TeamViewStatusUpdate("Active", CurrentActivity)


            Else

            End If

            ErrorProviderWarning.SetError(txtVolume, "")
            ErrorProviderWarning.SetError(txtID, "")
            ErrorProviderWarning.SetError(txtComments, "")

            TotalLockTime = Nothing
            TotalSwitchTime = Nothing

        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)

        End Try

    End Sub '

#Region "On Double click background work"
    Dim DayTotalBreak As Double = Nothing
    ' Dim DayTotalLock As Double = Nothing
    Dim DayTotalLock2 As Double = Nothing
    Dim WkDy1, WkDy2, WkDy3, WkDy4, WkDy5, WkDy6, WkDy7 As Double

    Sub DoubleClickUpdate()
        Dim BG_Worker As New BackgroundWorker
        BG_Worker.WorkerReportsProgress = True
        BG_Worker.WorkerSupportsCancellation = True

        AddHandler BG_Worker.DoWork, AddressOf BG_Dowork
        AddHandler BG_Worker.ProgressChanged, AddressOf BG_ProgressChange
        AddHandler BG_Worker.RunWorkerCompleted, AddressOf BG_WorkCompleted
        BG_Worker.RunWorkerAsync()
    End Sub

    Private Sub BG_Dowork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Call TotalBreakLog()
        Call TotalLockLog()
        'Call TimeGroupFill()
        Call GetSequencesVariables()
        Call TeamViewStatusUpdate("Active", CurrentActivity)
    End Sub

    Private Sub BG_ProgressChange(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub

    Private Sub BG_WorkCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'Day total Lock and break record fetch
        lblTotalLock.Text = "Total Lock (M) : " & DayTotalLock2
        lblTotalBreak.Text = "Total Break (M) : " & DayTotalBreak

        'Time summary group fill
        'lblTime7.Text = WkDy7
        'lblTime6.Text = WkDy6
        'lblTime5.Text = WkDy5
        'lblTime4.Text = WkDy4
        'lblTime3.Text = WkDy3
        'lblTime2.Text = WkDy2
        'lblTime1.Text = WkDy1

    End Sub


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
            Conn.GetSUM("break_time_log", "SUM(total_time)", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND status =@value5 AND date =@value6", value)
            DayTotalBreak = Conn.SUM

        Catch ex As Exception
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
            Conn.GetSUM("break_time_log", "SUM(total_time)", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND status =@value5 AND date =@value6", value)
            DayTotalLock2 = Conn.SUM

        Catch ex As Exception
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub
    Private Sub GetSequencesVariables()
        Dim conn As New pgConnect

        Try


            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & Activity & "^" & SubActivity & "^" & Task
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


        Catch ex As Exception

            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)


        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If

        End Try
    End Sub
    Private Sub TimeGroupFill()
        Dim i As Integer
        Dim Var As New Encryption

        Var.Encrypt(EmplID)
        Dim Emp_id As String = Var.encr

        Dim FilDate As Date = DateTimePicker.Value
        Dim IDate As String = Format(FilDate, "dd-MMM-yy")

        Dim ITime As Double = Nothing
        Dim TTime As Double = Nothing

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
                    lblTime7.Text = TTime
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


        Catch ex As Exception
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        Finally

        End Try

    End Sub
    Private Sub TeamViewStatusUpdate(Status As String, Activity As String)
        Try

            Dim tdate As String = Format(Now, "ddMMyyyy")
            Dim ActID As String = EmplID & tdate

            Dim value As String = Status & "^" & Activity & "^" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString & "^" & ActID
            Dim conn As New pgConnect
            conn.UpdateRecord("team_view", "activity =@value1,activity_type =@value2,start_time =@value3", value, "act_id =@value4")

        Catch ex As Exception
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub 'Updated

#End Region

#Region "System Lock Switch Event"

    Private Sub SessionSwitch_Event(ByVal sender As Object, ByVal e As SessionSwitchEventArgs)
        'Try


        '    If BreakStatus = True Or ExLock = True Then
        '        Exit Sub
        '    End If



        '    'Pc Lock 
        '    If e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLock Then
        '        LockStart = Now

        '    ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionUnlock Then

        '        LockEnd = Now

        '        Dim STime As Date = LockStart
        '        Dim ETime As Date = LockEnd
        '        Dim SecondsDifference As Integer
        '        SecondsDifference = DateDiff(DateInterval.Second, STime, ETime)
        '        ActLockTime = Format(SecondsDifference / 60, "0.00")
        '        TotalLockTime += ActLockTime

        '        Dim Fun As New SysFunctions
        '        Fun.SysEventUpdate(UserID, LoginDate, "System Locked", LockStart, LockEnd, ActLockTime, UName, EmplID, Project, Process, SubProcess)


        '        ActLocTime.Text = "Activty Lock (M) : " & TotalLockTime


        '    End If

        '    ''Remote Connection
        '    If e.Reason = Microsoft.Win32.SessionSwitchReason.RemoteDisconnect Then

        '    ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.RemoteDisconnect Then

        '    End If


        '    'Switch User
        '    If e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleDisconnect Then
        '        SwitchStart = Now

        '    ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleConnect Then
        '        SwitchEnd = Now
        '        Dim STime As Date = SwitchStart
        '        Dim ETime As Date = SwitchEnd
        '        Dim SecondsDifference As Integer
        '        SecondsDifference = DateDiff(DateInterval.Second, STime, ETime)
        '        ActSwitchTime = Format(SecondsDifference / 60, "0.00")
        '        TotalSwitchTime += ActSwitchTime

        '        Dim Fun As New SysFunctions
        '        Fun.SysEventUpdate(UserID, LoginDate, "Switch User", LockStart, LockEnd, ActLockTime, UName, EmplID, Project, Process, SubProcess)


        '    End If

        'Catch ex As Exception
        '    MsgBox("Error !- " & ex.Message)
        '    Dim line As String = ex.StackTrace.ToString
        '    Dim LineNo() As String = Split(line, "line")

        '    Dim lg As New ErrorLogger
        '    lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        'End Try

    End Sub

#End Region


    Sub TimeViewTimeUpdate()

        Dim Conn As New pgConnect
        Dim TotalLockTime As Double = TotalLockTime
        Dim TotalSwitchTime As Double = TotalSwitchTime

        Try
            Dim LDate As Date = Home.TP_LoginDate
            Dim ival As String = Format(LDate, "dd-MMM-yy")

            Dim Var As New Encryption
            Var.Encrypt(EmplID)
            Dim Emp_id As String = Var.encr

            Var.Encrypt(UName)
            Dim name As String = Var.encr

            Var.Encrypt(Project)
            Dim prjt As String = Var.encr

            Var.Encrypt(Process)
            Dim prcs As String = Var.encr

            Var.Encrypt(SubProcess)
            Dim sprcs As String = Var.encr

            If ActivityStart = Nothing Then Exit Sub

            Dim ActSTime As Date = ActivityStart
            Dim ActETime As Date = ActivityEnd
            Dim SecondsDifference As Integer
            SecondsDifference = DateDiff(DateInterval.Second, ActSTime, ActETime)
            Dim TotalTime As Double = Format(SecondsDifference / 60, "0.0")
            Dim NetTime As Double = TotalTime - OverallBreak - TotalLockTime - TotalSwitchTime
            Dim ivol As Integer

            If txtVolume.Text = Nothing Then ivol = 0


            Conn.InsertRecord("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment,project_id,added_by",
                              "" & Format(LDate, "dd-MMM-yy") &
                              "^" & Emp_id &
                              "^" & UName &
                              "^" & Project &
                              "^" & Process &
                              "^" & SubProcess &
                              "^" & lblactivity.Text &
                              "^" & lblsubactivity.Text &
                              "^" & lbltask.Text &
                              "^" & ActivityStart &
                              "^" & ActivityEnd &
                              "^" & Format(NetTime, "0.0") &
                              "^" & ivol &
                              "^" & txtID.Text &
                              "^" & txtComments.Text &
                              "^" & ProjectID &
                              "^" & "System" & "")


        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)

        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If

        End Try
    End Sub 'Required

#Region "Break and Lock total update"

#End Region

    Private Sub TmrCurrentAct_Tick(sender As Object, e As EventArgs) Handles TmrCurrentAct.Tick
        Try

            '''''''''''''''''''Current Activity Time'''''''''''''''''''''''''''''''''''''''''''''

            stime = ActivityStart
            ActStrtTime.Text = "Activity Started @ : " & Format(ActivityStart, "hh:mm tt")
            etime = Now
            Dim SecondsDifference, PSecondsDifference As Integer



            SecondsDifference = DateDiff(DateInterval.Second, stime, etime)
            CurActTim.Text = "Current Activty (M) : " & Format(SecondsDifference / 60, "0.00")


            pstime = ActivityStart
            petime = Now
            PSecondsDifference = DateDiff(DateInterval.Second, pstime, petime)
            lblActivityTime.Text = Format(PSecondsDifference / 60, "0.00")
            brkTime.Text = Format(DateDiff(DateInterval.Second, BreakStart, Now) / 60, "0.00")


        Catch ex As Exception
            'Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")

            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)

        End Try

    End Sub 'Required

#Region "Activity Scrolling ticker"

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


    Private Sub Ticker_Tick(sender As Object, e As EventArgs) Handles Ticker.Tick
        Try
            Dim TextIScroll As String = "Current  Activity started @ " & Format(ActivityStart, "hh:mm tt") & "   " &
       "Activity  " & lblactivity.Text & "-- " & lblsubactivity.Text & "-- " & lbltask.Text

            Static count As Integer = 0
            Me.Text = scrollingTextSelector.Substring(count, numberOfCharactersToDisplay)

            count += 1
            If count > TextIScroll.Length Then
                count = 0
            End If
        Catch ex As Exception

        End Try
    End Sub


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

                    txtVolume.Enabled = False
                    txtID.Enabled = False
                    txtComments.Enabled = False
                    lstActivity.Enabled = False
                    LstSubActivity.Enabled = False
                    lstTask.Enabled = False
                    cmdEndday.Enabled = False
                    grpBreakDetails.Visible = True
                    grpBreakDetails.Text = "Break started @ " & Format(Now, "hh:mm:tt")

                    Call TeamViewStatusUpdate("Break", CurrentActivity)
                    BreakPopup.Show()

                Else
                    BreakStatus = False
                    BreakEnd = Now
                    BreakPopup.Close()

                    cmdBreak.Text = "Start Break"
                    cmdBreak.BackColor = Color.Gainsboro

                    txtVolume.Enabled = True
                    txtID.Enabled = True
                    txtComments.Enabled = True
                    lstActivity.Enabled = True
                    LstSubActivity.Enabled = True
                    lstTask.Enabled = True
                    cmdEndday.Enabled = True

                    Dim BSTime As Date = BreakStart
                    Dim BETime As Date = BreakEnd
                    Dim SecondsDifference As Integer
                    SecondsDifference = DateDiff(DateInterval.Second, BSTime, BETime)
                    TotalBreak = Format(SecondsDifference / 60, "0.00")
                    OverallBreak = OverallBreak + TotalBreak
                    'lblCurBreak.Text = OverallBreak
                    ActBrkTime.Text = "Activty Break (M) : " & OverallBreak
                    grpBreakDetails.Visible = False

                    My.Settings.ActivityBreak = OverallBreak
                    My.Settings.Save()

                    Call BreakUpdate()
                    Call TotalBreakLog()
                    Call TeamViewStatusUpdate("Active", CurrentActivity)

                End If
            End With

        Catch ex As Exception
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub

    Private Sub BreakUpdate()
        Dim lDate As Date = LoginDate
        Dim Var As New Encryption

        Var.Encrypt(EmplID)
        Dim Emp_id As String = Var.encr

        Var.Encrypt(UName)
        Dim name As String = Var.encr


        Try

            Dim Fun As New SysFunctions
            Fun.SysEventUpdate(UserID, Format(lDate, "dd-MMM-yy"), "Break", BreakStart, BreakEnd, TotalBreak, UName, EmplID, Project, Process, SubProcess)


        Catch ex As Exception
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub

#End Region 'Required

#Region "Day Lock and Break Retriving"
    Dim MasterLockTime As Double = Nothing
    Dim MasterBreakTime As Double = Nothing


#End Region 'Required

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

    Private Sub SelfAllocator_Click(sender As Object, e As EventArgs) Handles SelfAllocator.Click

        If TimeViewType = "SelfAllocation" Then
            ActivitySelector.Show()
        Else
            MsgBox("Self Allocation not activated for your process", vbInformation, "Oops!")
        End If

    End Sub

End Class
