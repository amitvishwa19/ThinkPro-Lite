Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Imports Npgsql
Imports System.ComponentModel
Public Class ThinkManagement

#Region "Variables"
    Public TreeEmplid As String = Nothing
    Public TreeUserName As String = Nothing
    Public TotalDays As Integer = Nothing
    Public TotalWorkDays As Integer = Nothing
    Public TotalUser As Integer = Nothing
    Public LoggedInUserCount As Integer = Nothing
    Public SWON As String = Nothing
    Public Project = Home.TP_Project
    Public Process = Home.TP_Process
    Public SubProcess = Home.TP_SubProcess
    Public EmplID = Home.TP_EmplID
    Public ProjectID = Home.TP_ProcessID
    Public IRow As String = Nothing 'For Grid Row selection
    Public UtilizationType As String = "Activity" ' On selection activity,subactivity,task level
    Public UserFilter As String = Nothing

#End Region

#Region "New Variables"
    Public TM_UserName As String = Nothing
    Public TM_EmplID As Integer = Nothing
    Public TM_UserID As Integer = Nothing
    Public TM_ProcessID As Integer = Nothing
    Public TM_Project As String = Nothing
    Public TM_Process As String = Nothing
    Public TM_SubProcess As String = Nothing
    Public TM_UserRole As String = Nothing


#End Region

    Private Sub ThinkManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '============Conn Pooling check=====================
        If My.Settings.ConnPooling = True Then
            CpEnabled.Checked = True
        Else
            CpDisabled.Checked = True
        End If


        '============Conn Pooling check=====================


        Dashboard.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        Dashboard.Dock = DockStyle.Fill
        Dashboard.Show()

        ''Me.Size = New Size(1000, 600)


        ProjectID = My.Settings.ProjectID

        TM_UserName = Home.TP_UserName
        TM_EmplID = Home.TP_EmplID
        TM_UserID = Home.TP_UserID
        TM_ProcessID = Home.TP_ProcessID
        TM_Project = Home.TP_Project
        TM_Process = Home.TP_Process
        TM_SubProcess = Home.TP_SubProcess
        TM_UserRole = Home.TP_UserRole


        If Home.lblAccount.Text = "Process Lead" Then
            Call ProcessTreeProcessLead()
        Else
            Call ProcessTree()
        End If

        'Call data_retention()
        Call TreeViewMenuActivator()
        Call SystemLockRetrive()
        Call SysLockCheckRetrive()
        Call SysSwitchRetrive()
        Call ProcessDetails()
        Call LoggedInUser()
        Call TeamStrength()
        Call TimeViewType()
        Call TotalKPIDay() 'For Workingday and Holiday's

    End Sub



    Sub data_retention()
        Dim sysfn As New SysFunctions
        Dim hhd As Integer = sysfn.hard_del_days

        If hhd = 0 Then
            Exit Sub
        Else

            If sysfn.oldest_data_check("time_view") = True Then 'This will check if old data is there or not

                Dim result As Integer = MessageBox.Show("Please Note: Data older than " & hhd & " day(s) will be deleted now" & vbNewLine &
                                                "In case of any issue press Cancel button" & vbNewLine,
                                                "Data Retention Policy",
                                                MessageBoxButtons.OKCancel)
                If result = DialogResult.Cancel Then

                    MessageBox.Show("As per Data Retention Policy,Data older than " & hhd & " day(s) should be deleted." & vbNewLine & "Please contact Administrator")
                    Me.Close()

                ElseIf result = DialogResult.OK Then

                    sysfn.hard_delete_data(sysfn.delete_start_date(), sysfn.delete_end_date(), "time_view")

                End If
            End If


        End If




    End Sub

    Sub TreeViewMenuActivator()

        If Home.lblAccount.Text = "Associate" Then


        ElseIf Home.lblAccount.Text = "Process Lead" Then
            RoleAssociate.Visible = True
            RoleProcessLead.Visible = True

        ElseIf Home.lblAccount.Text = "Admin" Then
            RoleAssociate.Visible = True
            RoleProcessLead.Visible = True
            'RoleDeliveryLead.Visible = True
            RoleAdmin.Visible = True

        End If

    End Sub

    Sub ProcessTree()

        TreeView1.Nodes.Clear()



        Dim conn As New pgConnect
        Dim Project = New TreeNode
        Dim Process = New TreeNode
        Dim SubProcess = New TreeNode
        Dim UName = New TreeNode
        Dim SubSubChildnode = New TreeNode

        Dim Parent As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT project")
        While Parent.Read
            Project = New TreeNode(Parent("project").ToString)
            TreeView1.Nodes.Add(Project)

            conn.Connect()
            Dim value As String = Parent("project")
            Dim child As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT process", "project =@value1", value)
            While child.Read
                Process = New TreeNode(child("process").ToString)
                Project.Nodes.Add(Process)

                conn.Connect()
                Dim value2 As String = Parent("project") & "^" & child("process")
                Dim subchild As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT sub_process,project_id", "project =@value1 AND process =@value2", value2)
                While subchild.Read
                    SubProcess = New TreeNode(subchild("sub_process"))
                    SubProcess.Tag = subchild("project_id")
                    Process.Nodes.Add(SubProcess)

                    conn.Connect()

                    Dim enc As New Encryption
                    Dim prjt As String = Parent("project")
                    Dim prcs As String = child("process")
                    Dim sprcs As String = subchild("sub_process")

                    Dim value3 As String = prjt & "^" & prcs & "^" & sprcs & "^" & "Active"
                    Dim namechild As NpgsqlDataReader = conn.GetRecords("user_details", "empl_id,first_name,last_name,account_type", "project =@value1 AND process =@value2 AND sub_process =@value3 AND account_status=@value4", value3, "first_name DESC")
                    While namechild.Read

                        If namechild("account_type") <> "Associate" Then
                            UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString) & " (" & namechild("account_type") & ")")
                        Else
                            UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString))
                        End If
                        'UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString))
                        'UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString) & " (" & enc.decrypt(namechild("empl_id")) & ")")
                        'UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString) & " (" & namechild("account_type") & ")")
                        SubProcess.Nodes.Add(UName)
                        UName.Tag = namechild("empl_id")


                    End While
                End While
            End While
        End While

        For Each tn As TreeNode In TreeView1.Nodes
            If tn.Level = 0 Then
                tn.Expand()
            End If
        Next


    End Sub

    Sub ProcessTreeProcessLead()



        TreeView1.Nodes.Clear()
        Dim conn As New pgConnect
        Dim TreeProject = New TreeNode
        Dim TreeProcess = New TreeNode
        Dim TreeSubProcess = New TreeNode
        Dim UName = New TreeNode
        Dim SubSubChildnode = New TreeNode


        TreeProject = New TreeNode(Project)
        TreeView1.Nodes.Add(TreeProject)

        TreeProcess = New TreeNode(Process)
        TreeProject.Nodes.Add(TreeProcess)

        TreeSubProcess = New TreeNode(SubProcess)
        TreeProcess.Nodes.Add(TreeSubProcess)

        Dim enc As New Encryption

        Dim value3 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "Released"
        Dim namechild As NpgsqlDataReader = conn.GetRecords("user_details", "empl_id,first_name,last_name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND account_status<>@value4", value3, "first_name")
        While namechild.Read
            UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString) & " (" & enc.decrypt(namechild("empl_id")) & ")")
            TreeSubProcess.Nodes.Add(UName)
            UName.Tag = namechild("empl_id")

        End While
        TreeView1.ExpandAll()
        For Each tn As TreeNode In TreeView1.Nodes
            If tn.Level = 2 Then
                tn.Expand()
            End If
        Next
    End Sub

    Sub ProcessDetails()
       
        prj.Text = TM_Project
        prc.Text = TM_Process
        sprc.Text = TM_SubProcess
        lblwon.Text = "WON : " & SWON
        lblTeamStrength.Text = "Total Strength : " & TeamStrength()
        lblLoginuser.Text = "LoggedIn Users : " & LoggedInUser()
        lblPrcID.Text = "Process ID : " & TM_ProcessID

    

    End Sub

    Function TeamStrength()
        Try
            Dim conn As New pgConnect
            Dim var As New Encryption

            TotalUser = Nothing
            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "Active"
            Dim reader As NpgsqlDataReader = conn.GetRecords("user_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND account_status =@value4", value)
            While reader.Read
                TotalUser += 1
            End While

            Return TotalUser
            'TotalUser = Nothing

        Catch ex As IO.IOException
            Return Nothing
        End Try

    End Function

    Function LoggedInUser()

        Try
            Dim conn As New pgConnect
            Dim var As New Encryption

            LoggedInUserCount = Nothing

            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            Dim reader As NpgsqlDataReader = conn.GetRecords("team_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 and date<=@value5", value)
            While reader.Read
                LoggedInUserCount += 1
            End While


            'lblLogedinUser.Text = LoggedInUserCount
            Return LoggedInUserCount
        Catch ex As IO.IOException
            Return Nothing
        End Try

    End Function

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim enc As New Encryption


        If TreeView1.SelectedNode.Level = 0 Then
            UserFilter = Nothing


        ElseIf TreeView1.SelectedNode.Level = 1 Then
            UserFilter = Nothing


        ElseIf TreeView1.SelectedNode.Level = 2 Then
            TM_Project = TreeView1.SelectedNode.Parent.Parent.Text
            TM_Process = TreeView1.SelectedNode.Parent.Text
            TM_SubProcess = TreeView1.SelectedNode.Text
            prj.Text = TM_Project
            prc.Text = TM_Process
            sprc.Text = TM_SubProcess
            TM_ProcessID = TreeView1.SelectedNode.Tag
            Call ProcessDetails()

            UserFilter = Nothing



        ElseIf TreeView1.SelectedNode.Level = 3 Then

            TM_Project = TreeView1.SelectedNode.Parent.Parent.Parent.Text
            TM_Process = TreeView1.SelectedNode.Parent.Parent.Text
            TM_SubProcess = TreeView1.SelectedNode.Parent.Text
            prj.Text = TM_Project
            prc.Text = TM_Process
            sprc.Text = TM_SubProcess
            TreeEmplid = TreeView1.SelectedNode.Tag
            TreeUserName = TreeView1.SelectedNode.Text
            UserFilter = TreeView1.SelectedNode.Tag
            TM_ProcessID = TreeView1.SelectedNode.Parent.Tag

            Call ProcessDetails()

            msMasterUpdate.Enabled = True
        Else
            msMasterUpdate.Enabled = False
        End If

        If TreeView1.SelectedNode.Level = 3 Then

        End If

    End Sub

    Private Sub TotalKPIDay()
        Try
            Dim SDate As Date = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As Date = Format(DateEnd.Value, "dd-MMM-yy")



            TotalDays = DateDiff(DateInterval.Day, SDate, EDate) + 1 'Format((LAEnd - LAstrt).ToString, "00")

            ''StartDate = lblLStart.Text
            ''EndDate = lblLend.Text

            Dim count = 0
            Dim Day = (SDate - EDate).Days

            For i = 0 To TotalDays - 1
                Dim weekday As DayOfWeek = SDate.AddDays(i).DayOfWeek
                If weekday <> DayOfWeek.Saturday AndAlso weekday <> DayOfWeek.Sunday Then
                    count += 1
                End If
            Next

            TotalWorkDays = count
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '  Dim line As String = ex.StackTrace.ToString
            ' Dim LineNo() As String = Split(line, "line")
            '  Dim lg As New ErrorLogger
            '       lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Catch ex As InvalidCastException
        End Try
    
    End Sub

#Region "Date Change"


    Private Sub DateStart_ValueChanged(sender As Object, e As EventArgs) Handles DateStart.ValueChanged

        Call TotalKPIDay()

        Dim msg As MsgBoxResult
        Dim dr As New DataRetention
        If dr.soft_delete_date_check(DateStart.Value) = False Then
            msg = MsgBox("Data for the selected date is not avaliable,please contact administrator for query")
            DateStart.Value = dr.soft_delete_date(DateStart.Value)
        End If

    End Sub

    Private Sub DateEnd_ValueChanged(sender As Object, e As EventArgs) Handles DateEnd.ValueChanged

        Dim msg As MsgBoxResult
        Call TotalKPIDay()

        Dim dr As New DataRetention

        If dr.soft_delete_date_check(DateEnd.Value) = False Then
            msg = MsgBox("Data for the selected date is not avaliable,please contact administrator for query")
            DateEnd.Value = dr.soft_delete_date(DateEnd.Value)
        End If

    End Sub

#End Region
#Region "Dashboard"

    

#End Region
#Region "Team View"

#Region "Team view tab"

    ''Private Sub TabControlTeamView_SelectedIndexChanged(sender As Object, e As EventArgs)

    ''    If TCTeamView.SelectedIndex = (0) Then 'TeamView
    ''        BindingSource.Filter = ""
    ''        Call TeamViewGrid()
    ''        TimerTeamView.Start()
    ''    ElseIf TCTeamView.SelectedIndex = (1) Then 'mASTERuPDATE
    ''        TimerTeamView.Stop()
    ''        BindingSource.Filter = ""
    ''        Call MasterUpdateGrid()
    ''    ElseIf TCTeamView.SelectedIndex = (2) Then 'bREAK AND LOCK 
    ''        TimerTeamView.Stop()
    ''        BindingSource.Filter = ""
    ''    End If

    ''End Sub

    'Private Sub TeamViewGrid()

    '    Dim Var As New Encryption
    '    Var.Encrypt(EmplID)
    '    Dim Emp_id As String = Var.encr

    '    Dim FilDate As Date = Now
    '    Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '    Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '    Dim conn As New pgConnect
    '    Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '    conn.GetRecordsGRID("team_view", "name,activity,activity_type,start_time,in_time,out_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
    '    gridTeamView.Columns.Clear()
    '    BindingSource.DataSource = conn.DataTable
    '    gridTeamView.DataSource = BindingSource

    '    conn.DataTable.Columns.Add("Net Time")
    '    conn.DataTable.Columns.Add("Total In Time")
    '    gridTeamView.Columns("Net Time").DisplayIndex = 4
    '    gridformat(gridTeamView)

    '    With gridTeamView
    '        .Columns(0).HeaderCell.Value = "User"
    '        .Columns(1).HeaderCell.Value = "Activity"
    '        .Columns(2).HeaderCell.Value = "Activity Status"
    '        .Columns(3).HeaderCell.Value = "Start Time"
    '        .Columns(3).DefaultCellStyle.Format = "hh:mm tt"
    '        '.Columns(4).HeaderCell.Value = "Start Time"
    '        .Columns(4).HeaderCell.Value = "In Time"
    '        '.Columns(6).HeaderCell.Value = "Out Time"
    '        '.Columns(7).HeaderCell.Value = "Volume"
    '        '.Columns(8).HeaderCell.Value = "Act. ID"
    '        '.Columns(9).HeaderCell.Value = "Comment"
    '    End With

    '    For i = 0 To gridTeamView.Rows.Count - 1

    '        '''''''''Net Activity Time
    '        Dim istart, iend, istart2, iend2 As Date
    '        Dim istart1, iend22 As String
    '        Dim SecondsDifference, SecondsDifference2 As Integer
    '        istart1 = gridTeamView.Rows(i).Cells(3).Value.ToString

    '        If istart1 <> "" Then
    '            istart = gridTeamView.Rows(i).Cells(3).Value
    '            iend = Now
    '            SecondsDifference = DateDiff(DateInterval.Second, istart, iend)
    '            gridTeamView.Rows(i).Cells(6).Value = Format(SecondsDifference / 60, "0") & " Min"
    '        End If
    '        '''''''''Total In Time
    '        iend22 = gridTeamView.Rows(i).Cells(5).Value.ToString
    '        If iend22 <> "" Then
    '            'Else
    '            istart2 = gridTeamView.Rows(i).Cells(4).Value
    '            iend2 = gridTeamView.Rows(i).Cells(5).Value
    '            SecondsDifference2 = DateDiff(DateInterval.Second, istart2, iend2)
    '            gridTeamView.Rows(i).Cells(7).Value = Format(SecondsDifference2 / 60, "0") & " Min"
    '        End If

    '    Next i

    'End Sub

    'Private Sub DataGridView1_RowPrePaint1(sender As Object, e As DataGridViewRowPrePaintEventArgs)

    '    Try
    '        If Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "LoggedIn" Then
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.CornflowerBlue
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.CornflowerBlue

    '        ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Break" Then
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.BurlyWood
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("name").Style.BackColor = Color.BurlyWood

    '        ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "System Locked" Then
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.DarkOrange
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.DarkOrange

    '        ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Logged Out" Then
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.Thistle
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.Thistle

    '        ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Active" Then
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.ForestGreen
    '            Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.ForestGreen
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub

    'Private Sub TimerTeamView_Tick(sender As Object, e As EventArgs) Handles TimerTeamView.Tick
    '    Try
    '        Dim iTopRow As Integer
    '        Dim iTopCol As Integer

    '        iTopRow = gridTeamView.FirstDisplayedScrollingRowIndex '// get Top row.
    '        iTopCol = gridTeamView.FirstDisplayedScrollingColumnIndex
    '        Call TeamViewGrid()
    '        gridTeamView.FirstDisplayedScrollingRowIndex = iTopRow
    '        gridTeamView.FirstDisplayedScrollingColumnIndex = iTopCol


    '        Call StatusSummary()
    '        'Dim itotusr, iactive As Integer
    '        'itotusr = lbltotalUsers.Text
    '        'iactive = lblActive.Text
    '        'lbluti.Text = Format(iactive / itotusr * 100, "0.0") & " %"

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub StatusSummary()
    '    Dim iActive, iLock, iBreak, iLoogedIn, iLoggedOut As Integer


    '    For i As Integer = 0 To gridTeamView.RowCount - 1

    '        If gridTeamView.Rows(i).Cells(1).Value = "Active" Then
    '            iActive += 1
    '        End If

    '        If gridTeamView.Rows(i).Cells(1).Value = "System Locked" Then
    '            iLock += 1
    '        End If

    '        If gridTeamView.Rows(i).Cells(1).Value = "Break" Then
    '            iBreak += 1
    '        End If

    '        If gridTeamView.Rows(i).Cells(1).Value = "LoggedIn" Then
    '            iLoogedIn += 1
    '        End If

    '        If gridTeamView.Rows(i).Cells(1).Value = "Logged Out" Then
    '            iLoggedOut += 1
    '        End If

    '    Next

    '    TotalUsers.Text = "Total Users : " & gridTeamView.Rows.Count
    '    Active.Text = "Active : " & iActive
    '    Locked.Text = "Locked : " & iLock
    '    Break.Text = "Break : " & iBreak
    '    LoggedIn.Text = "Logged In : " & iLoogedIn
    '    LoggedOut.Text = "Logged Out : " & iLoggedOut


    'End Sub

#End Region

#Region "Master Update tab"

    'Public Sub MasterUpdateGrid()
    '    Dim Var As New Encryption
    '    Var.Encrypt(My.Settings.EmplID)
    '    Dim Emp_id As String = Var.encr



    '    Dim FilDate As Date = Now
    '    Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '    Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '    Dim conn As New pgConnect
    '    Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '    Dim valueuser As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate & "^" & UserFilter

    '    If UserFilter <> Nothing Then

    '        conn.GetRecordsGRID("time_view", "id,date,name,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5 AND empl_id=@value6", valueuser)

    '    Else
    '        conn.GetRecordsGRID("time_view", "id,date,name,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)

    '    End If


    '    gridMasterUpdate.Columns.Clear()
    '    BindingSource.DataSource = conn.DataTable
    '    gridMasterUpdate.DataSource = BindingSource
    '    gridformat(gridMasterUpdate)


    '    With gridMasterUpdate
    '        .Columns(0).HeaderCell.Value = "ID"
    '        .Columns(1).HeaderCell.Value = "Date"
    '        .Columns(2).HeaderCell.Value = "Name"
    '        .Columns(3).HeaderCell.Value = "Activity"
    '        .Columns(4).HeaderCell.Value = "Sub Activity"
    '        .Columns(5).HeaderCell.Value = "Task"
    '        .Columns(6).HeaderCell.Value = "Start Time"
    '        .Columns(7).HeaderCell.Value = "End Time"
    '        .Columns(8).HeaderCell.Value = "Total Time"
    '        .Columns(9).HeaderCell.Value = "Volume"
    '        .Columns(10).HeaderCell.Value = "Act.ID"
    '        .Columns(11).HeaderCell.Value = "Comment"
    '        '.Columns(9).HeaderCell.Value = "Comment"
    '        '.Columns(9).HeaderCell.Value = "Comment"
    '    End With
    '    gridformat(gridTeamView)
    '    gridMasterUpdate.Columns(0).Visible = False

    '    Call TotalSummary()

    'End Sub

    'Private Sub gridMasterUpdate_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Dim i As Integer = gridMasterUpdate.CurrentRow.Index
    '    gridMasterUpdate.Rows(i).Selected = True
    '    IRow = gridMasterUpdate.Item(0, i).Value
    'End Sub

    'Private Sub DeleteActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteActivityToolStripMenuItem1.Click
    '    Try
    '        Dim conn As New pgConnect
    '        Dim Value As String = IRow
    '        conn.DeleteRecord("time_view", Value, "id =@value1")
    '        Dim msg As MsgBoxResult = MsgBox("Activity deleted Successfully", vbInformation, "Activity Deleted")
    '        Call MasterUpdateGrid()
    '    Catch ex As Exception
    '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub UpdateActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateActivityToolStripMenuItem.Click
    '    Dim i As Integer = gridMasterUpdate.CurrentRow.Index
    '    Dim ival As Integer = gridMasterUpdate.Item(0, i).Value

    '    MasterTimeUpdate.Show()
    '    MasterTimeUpdate.cmdSubmit.Text = "Update"
    '    MasterTimeUpdate.ActID = ival

    '    If Not IsDBNull(gridMasterUpdate.Item(3, i).Value) Then
    '        MasterTimeUpdate.Activity = gridMasterUpdate.Item(3, i).Value
    '    End If
    '    If Not IsDBNull(gridMasterUpdate.Item(4, i).Value) Then
    '        MasterTimeUpdate.SubActivity = gridMasterUpdate.Item(4, i).Value
    '    End If
    '    If Not IsDBNull(gridMasterUpdate.Item(5, i).Value) Then
    '        MasterTimeUpdate.Task = gridMasterUpdate.Item(5, i).Value
    '    End If

    '    If Not IsDBNull(gridMasterUpdate.Item(8, i).Value) Then
    '        MasterTimeUpdate.txtTotalTime.Text = gridMasterUpdate.Item(8, i).Value
    '    End If

    '    If Not IsDBNull(gridMasterUpdate.Item(9, i).Value) Then
    '        MasterTimeUpdate.txtVolume.Text = gridMasterUpdate.Item(9, i).Value
    '    End If

    '    If Not IsDBNull(gridMasterUpdate.Item(10, i).Value) Then
    '        MasterTimeUpdate.txtActID.Text = gridMasterUpdate.Item(10, i).Value
    '    End If

    '    If Not IsDBNull(gridMasterUpdate.Item(11, i).Value) Then
    '        MasterTimeUpdate.txtcmnt.Text = gridMasterUpdate.Item(11, i).Value
    '    End If

    '    Call MasterTimeUpdate.AfterLoad()


    'End Sub

    'Sub TotalSummary()
    '    Dim iTotalMin As Integer = Nothing
    '    Dim iTotalVolume As Integer = Nothing

    '    For i As Integer = 0 To gridMasterUpdate.RowCount - 1
    '        iTotalMin += gridMasterUpdate.Rows(i).Cells(8).Value
    '        iTotalVolume += gridMasterUpdate.Rows(i).Cells(9).Value

    '    Next

    '    lblTotalMin.Text = "Total Time (M) : " & iTotalMin
    '    lblTotalVol.Text = "Total Volume : " & iTotalVolume


    'End Sub

    'Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
    '    Dim epp As New EppGridExport
    '    epp.EppGrdExport(gridMasterUpdate, "Master Update")

    'End Sub

#End Region

#End Region
#Region "Utilization"

    'Dim totalmin As Double = 0.0
    'Dim totalhr As Double = 0.0
    'Dim totalvolm As Integer = 0


    'Private Sub UtilizationGrid()

    '    Try
    '        Dim Var As New Encryption
    '        Var.Encrypt(My.Settings.EmplID)
    '        Dim Emp_id As String = Var.encr



    '        Dim FilDate As Date = Now
    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")


    '        Dim conn As New pgConnect
    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        Dim valueuser As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate & "^" & UserFilter

    '        If UserFilter <> Nothing Then
    '            If UtilizationType = "Activity" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "activity") 'AND date >=@value4 AND date <=@value5
    '            ElseIf UtilizationType = "SubActivity" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "sub_activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "sub_activity") 'AND date >=@value4 AND date <=@value5
    '            ElseIf UtilizationType = "Task" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "task") 'AND date >=@value4 AND date <=@value5
    '            End If

    '        Else
    '            If UtilizationType = "Activity" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity") 'AND date >=@value4 AND date <=@value5
    '            ElseIf UtilizationType = "SubActivity" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "sub_activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "sub_activity") 'AND date >=@value4 AND date <=@value5
    '            ElseIf UtilizationType = "Task" Then
    '                conn.GetRecordsGRIDGROUP("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "task") 'AND date >=@value4 AND date <=@value5
    '            End If

    '        End If

    '        gridUtilization.Columns.Clear()
    '        conn.DataTable.Columns.Add("UPT")
    '        conn.DataTable.Columns.Add("Utilization-FTE")
    '        conn.DataTable.Columns.Add("Utilization-%")

    '        BindingSource.DataSource = conn.DataTable
    '        gridUtilization.DataSource = BindingSource


    '        With gridUtilization
    '            .Columns(0).HeaderCell.Value = "Activity"
    '            .Columns(1).HeaderCell.Value = "Total Time(Min)"
    '            .Columns(2).HeaderCell.Value = "Total Volume"
    '        End With
    '        gridformat(gridUtilization)
    '        gridUtilization.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        Call utilizationCalculation()



    '        For i = 0 To gridUtilization.Rows.Count - 1
    '            Dim iTime, iCount As Integer
    '            iTime = gridUtilization.Rows(i).Cells(1).Value
    '            iCount = gridUtilization.Rows(i).Cells(2).Value
    '            gridUtilization.Rows(i).Cells(3).Value = Format(iTime / iCount, "0.0") '----------UPT
    '            gridUtilization.Rows(i).Cells(4).Value = Format(iTime / 540, "0.0") '----------Utilization
    '            gridUtilization.Rows(i).Cells(5).Value = Format(iTime / totalmin * 100, "0") & "%" '----------UPT
    '        Next

    '        For i = 0 To gridUtilization.Rows.Count - 1
    '            If gridUtilization.Rows(i).Cells(3).Value = "Infinity" Then
    '                gridUtilization.Rows(i).Cells(3).Value = "N/A"
    '            End If
    '            If gridUtilization.Rows(i).Cells(3).Value = "NaN" Then
    '                gridUtilization.Rows(i).Cells(3).Value = "N/A"
    '            End If
    '        Next

    '        totalmin = 0.0
    '        totalhr = 0.0
    '        totalvolm = 0





    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Sub utilizationCalculation()

    '    For i As Integer = 0 To gridUtilization.RowCount - 1
    '        totalmin += gridUtilization.Rows(i).Cells(1).Value
    '        totalvolm += gridUtilization.Rows(i).Cells(2).Value

    '    Next

    '    totalTimeMin.Text = "Total Time (Min): " & totalmin
    '    TotalTimeHr.Text = "Total Time (Hrs) : " & Format(totalmin / 60, "0.0")
    '    TotalVol.Text = "Total Vol : " & totalvolm
    '    TotalFTE.Text = "Utilization (FTE) : " & Format(totalmin / 540, "0.00")
    'End Sub

    'Private Sub ActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActivityToolStripMenuItem1.Click
    '    UtilizationType = "Activity"
    '    Call UtilizationGrid()
    'End Sub

    'Private Sub SubActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SubActivityToolStripMenuItem1.Click
    '    UtilizationType = "SubActivity"
    '    Call UtilizationGrid()
    'End Sub

    'Private Sub TaskToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TaskToolStripMenuItem1.Click
    '    UtilizationType = "Task"
    '    Call UtilizationGrid()
    'End Sub

    'Private Sub ExportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem1.Click
    '    Dim epp As New EppGridExport
    '    epp.EppGrdExport(gridUtilization, "Utilization")
    'End Sub

    'Private Sub ShowAllDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllDataToolStripMenuItem.Click
    '    UserFilter = Nothing
    '    BindingSource.Filter = ""
    '    Call UtilizationGrid()
    'End Sub

#End Region
#Region "User Management"

    Private Sub SMActivateUser_Click_1(sender As Object, e As EventArgs) Handles SMActivateUser.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Active" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_status = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("User activated successfully", vbInformation, "Activation Success")
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
        End Try
    End Sub



    Private Sub SMReleaseUser_Click_1(sender As Object, e As EventArgs) Handles SMReleaseUser.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Released" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_status = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("User released successfully", vbInformation, "Activation Success")
            If Home.lblAccount.Text = "Process Lead" Then
                Call ProcessTreeProcessLead()
            Else
                Call ProcessTree()
            End If

            Dim userid As Integer = get_user_id(TreeEmplid)
            Dim old_processid As Integer = get_process_id(TreeEmplid)
            Call remove_consent_for_old_process(userid, old_processid)


        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub LockAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LockAccountToolStripMenuItem.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Locked" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_status = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("User released successfully", vbInformation, "Activation Success")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
            '    Dim msg1 As MsgBoxResult = MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub BilledToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Billed" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "billing = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("Updated successfully to Billed", vbInformation, "Success")
        Catch ex As IO.IOException

            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try
    End Sub

    Private Sub UnbilledToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Unbilled" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "billing = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("Updated successfully to Unbilled", vbInformation, "Success")
        Catch ex As IO.IOException

            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
        End Try
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoleAdmin.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Admin" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_type = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("Role updated successfully", vbInformation, "Success")
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
            '   Dim msg1 As MsgBoxResult = MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub SuperAdminToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Super Admin" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_type = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("Role updated successfully", vbInformation, "Success")
        Catch ex As IO.IOException

            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
        End Try
    End Sub



    Private Sub ProcessLeadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoleProcessLead.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Process Lead" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_type = @value1", Value, "empl_id=@value2")
            Dim msg As MsgBoxResult = MsgBox("Role updated successfully", vbInformation, "Success")

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Error ! Please contact administrator")
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try
    End Sub

    Private Sub AssociateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoleAssociate.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = "Associate" & "^" & TreeEmplid
            conn.UpdateRecord("user_details", "account_type = @value1", Value, "empl_id=@value2")
            Dim msg1 As MsgBoxResult = MsgBox("Role updated successfully", vbInformation, "Success")
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ResetPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPasswordToolStripMenuItem.Click
        Dim logn As New LoginReg
        Dim Enc As New Encryption
        logn.ResetPassword(TreeEmplid)
        Dim msg As MsgBoxResult
        msg = MsgBox("Passwort Sets to default password i.e. 'Tcs@123'  for Empl. id " & Enc.decrypt(TreeEmplid))
    End Sub


#End Region
#Region "Time View Activity"

    Sub TimeViewActivity()
        'Try
        '    Dim conn As New pgConnect
        '    Dim value As String = Project & "^" & Process & "^" & SubProcess
        '    conn.GetRecordsGRID("time_activity", "act_id,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "act_id")
        '    gridActivity.Columns.Clear()
        '    BindingSource.DataSource = conn.DataTable
        '    gridActivity.DataSource = BindingSource
        '    gridformat(gridActivity)
        '    gridActivity.Columns(0).Visible = False
        '    With gridActivity
        '        .Columns(1).HeaderCell.Value = "Bucket"
        '        .Columns(2).HeaderCell.Value = "Activity"
        '        .Columns(3).HeaderCell.Value = "Sub Activity"
        '        .Columns(4).HeaderCell.Value = "Task"
        '        .Columns(5).HeaderCell.Value = "UPT"
        '        .Columns(6).HeaderCell.Value = "Lock Exclude"
        '        .Columns(7).HeaderCell.Value = "Volume Req."
        '        .Columns(8).HeaderCell.Value = "Act ID Req."
        '        .Columns(9).HeaderCell.Value = "Cmnt Req"
        '        .Columns(10).HeaderCell.Value = "Status"
        '    End With

        'Catch ex As Exception

        'End Try



    End Sub

    Private Sub gridActivity_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        '    Try
        '        Dim i As Integer = gridActivity.CurrentRow.Index
        '        gridActivity.Rows(i).Selected = True
        '        IRow = gridActivity.Item(0, i).Value
        '    Catch ex As Exception
        '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
        '    End Try
        'End Sub

        'Private Sub AddActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddActivityToolStripMenuItem1.Click
        '    TimeViewActivityEditor.Show()
        '    TimeViewActivityEditor.cmdSubmit.Text = "Add Activity"
        'End Sub

        'Private Sub ActivateActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateActivityToolStripMenuItem.Click
        '    Try
        '        Dim conn As New pgConnect
        '        Dim Value As String = "Active" & "^" & IRow
        '        conn.UpdateRecord("time_activity", "status = @value1", Value, "act_id=@value2")
        '        Call TimeViewActivity()
        '        Dim msg As MsgBoxResult = MsgBox("Activity activated successfully", vbInformation, "Activation Success")
        '    Catch ex As Exception
        '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
        '    End Try
    End Sub

    Private Sub DeleteActivityToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '    Try
        '        Dim conn As New pgConnect
        '        Dim Value As String = "InActive" & "^" & IRow
        '        conn.UpdateRecord("time_activity", "status = @value1", Value, "act_id=@value2")
        '        Call TimeViewActivity()
        '        Dim msg As MsgBoxResult = MsgBox("Activity deactivated successfully", vbInformation, "Deactivation Success")
        '    Catch ex As Exception
        '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
        '    End Try
    End Sub

    Private Sub EditActivityToolStripMenuItem_Click(sender As Object, e As EventArgs)


        '    Try
        '        Dim i As Integer
        '        Dim ival As Integer

        '        i = gridActivity.CurrentRow.Index

        '        If i = Nothing Then
        '            Dim msg As MsgBoxResult = MsgBox("Please select a activity to edit", vbInformation, "Select activity")
        '            Exit Sub
        '        End If

        '        ival = gridActivity.Item(0, i).Value


        '        TimeViewActivityEditor.Show()
        '        TimeViewActivityEditor.cmdSubmit.Text = "Update"
        '        TimeViewActivityEditor.ActID = ival

        '        If Not IsDBNull(gridActivity.Item(1, i).Value) Then
        '            TimeViewActivityEditor.txtBucket.Text = gridActivity.Item(1, i).Value
        '        End If

        '        If Not IsDBNull(gridActivity.Item(2, i).Value) Then
        '            TimeViewActivityEditor.txtActivity.Text = gridActivity.Item(2, i).Value
        '        End If
        '        If Not IsDBNull(gridActivity.Item(3, i).Value) Then

        '            TimeViewActivityEditor.txtSubActivity.Text = gridActivity.Item(3, i).Value
        '        End If
        '        If Not IsDBNull(gridActivity.Item(4, i).Value) Then
        '            TimeViewActivityEditor.txtTask.Text = gridActivity.Item(4, i).Value
        '        End If

        '        If Not IsDBNull(gridActivity.Item(5, i).Value) Then
        '            TimeViewActivityEditor.txtUPT.Text = gridActivity.Item(5, i).Value
        '        End If

        '        TimeViewActivityEditor.cbLockExc.CheckState = gridActivity.Item(6, i).Value
        '        TimeViewActivityEditor.cbVolReq.CheckState = gridActivity.Item(7, i).Value
        '        TimeViewActivityEditor.cbActIDReq.CheckState = gridActivity.Item(8, i).Value
        '        TimeViewActivityEditor.cbCmntReq.CheckState = gridActivity.Item(9, i).Value
        '    Catch ex As Exception
        '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
        '    End Try


    End Sub

    Private Sub AddActivityToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '    Try
        '        Dim i As Integer = gridActivity.CurrentRow.Index
        '        Dim ival As Integer = gridActivity.Item(0, i).Value

        '        TimeViewActivityEditor.Show()
        '        TimeViewActivityEditor.cmdSubmit.Text = "Add Activity"
        '    Catch ex As Exception

        '    End Try
    End Sub

    Private Sub ExportTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '    Try
        '        Dim xlPackage As New ExcelPackage()
        '        Dim oBook As ExcelWorkbook = xlPackage.Workbook
        '        Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Activity")
        '        Dim savepath As String


        '        ws.Cells.AutoFitColumns()
        '        ws.Cells(1, 1).Value = "Bucket"
        '        ws.Cells(1, 2).Value = "Activity"
        '        ws.Cells(1, 3).Value = "Sub Activity"
        '        ws.Cells(1, 4).Value = "Task"
        '        ws.Cells(1, 5).Value = "UPT"
        '        ws.Cells(1, 6).Value = "Lock Excluded"
        '        ws.Cells(1, 7).Value = "Volume Required"
        '        ws.Cells(1, 8).Value = "Activity ID Required"
        '        ws.Cells(1, 9).Value = "Comments Required"
        '        ws.Cells(1, 10).Value = "Activity Status"
        '        ws.Cells.AutoFitColumns()


        '        ws.Cells(1, 1).AddComment("DIRECT,INDIRECT,TCS INTERNAL,VALIDATION ACTIVITIES", "REF")
        '        ws.Cells(1, 2).AddComment("", "REF")
        '        ws.Cells(1, 3).AddComment("", "REF")
        '        ws.Cells(1, 4).AddComment("", "REF")
        '        ws.Cells(1, 5).AddComment("Unit processing time of activity(Numeric only)", "REF")
        '        ws.Cells(1, 6).AddComment("Put 1 if activity should be excluded from PC lock, else Put 0", "REF")
        '        ws.Cells(1, 7).AddComment("Put 1 to compel user to enter volume while changing the Activity, else put 0", "REF")
        '        ws.Cells(1, 8).AddComment("Put 1 to compel user to enter Activity ID while changing the Activity, else put 0", "REF")
        '        ws.Cells(1, 9).AddComment("Put 1 to compel user to enter Comments while changing the Activity, else put 0", "REF")
        '        ws.Cells(1, 10).AddComment("Keep dafault value as 'Active' ", "REF")

        '        For i = 1 To 10


        '        Next

        '        Dim FBD As New FolderBrowserDialog
        '        If (FBD.ShowDialog() = DialogResult.OK) Then
        '            savepath = FBD.SelectedPath
        '            Dim excelFile As New FileInfo(savepath & "\" & "TimeView Activity upload Template" & ".xlsx")
        '            xlPackage.SaveAs(excelFile)
        '            MsgBox("Template saved to " & savepath, MsgBoxStyle.Information, "Exported")
        '        End If

        '    Catch ex As Exception

        '    End Try
    End Sub

    Private Sub ImportCsv_Click(sender As Object, e As EventArgs)
        '    Try
        '        Dim FilePath As String
        '        Dim OpenFileDialog1 As New OpenFileDialog

        '        OpenFileDialog1.Title = "Please select a DB file"
        '        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        '        OpenFileDialog1.Filter = "Excel Files|*.csv;*.csv;*.csv;*.csv;*‌​.xml;"



        '        If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        '            FilePath = OpenFileDialog1.FileName
        '            Dim fi As New FileInfo(OpenFileDialog1.FileName)
        '            Dim FileName As String = OpenFileDialog1.FileName

        '            Dim items2 = (From line In IO.File.ReadAllLines(OpenFileDialog1.FileName) _
        '                Select Array.ConvertAll(line.Split(","c), Function(v) v.ToString.TrimStart(""" ".ToCharArray).TrimEnd(""" ".ToCharArray))).ToArray

        '            Dim Your_DT As New DataTable
        '            For x As Integer = 0 To items2(0).GetUpperBound(0)
        '                Your_DT.Columns.Add()

        '            Next

        '            For Each a In items2
        '                Dim dr As DataRow = Your_DT.NewRow
        '                dr.ItemArray = a
        '                Your_DT.Rows.Add(dr)
        '            Next




        '            gridActivity.DataSource = Your_DT
        '        End If

        '        UploadCsv.Enabled = True
        '    Catch ex As Exception

        '    End Try
    End Sub

    Private Sub ImportXlsx_Click(sender As Object, e As EventArgs)
        '    Try
        '        Dim conn As OleDbConnection
        '        Dim dta As OleDbDataAdapter
        '        Dim FilePath As String
        '        Dim dts As DataSet
        '        Dim excel As String
        '        Dim OpenFileDialog1 As New OpenFileDialog

        '        OpenFileDialog1.Title = "Please select a DB file"
        '        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        '        OpenFileDialog1.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls;*‌​.xml;"



        '        If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        '            FilePath = OpenFileDialog1.FileName
        '            Dim fi As New FileInfo(OpenFileDialog1.FileName)
        '            Dim FileName As String = OpenFileDialog1.FileName

        '            excel = fi.FullName
        '            conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
        '            dta = New OleDbDataAdapter("Select * From [Activity$]", conn)
        '            dts = New DataSet
        '            dta.Fill(dts, "[Activity$]")
        '            gridActivity.DataSource = dts
        '            gridActivity.DataMember = "[Activity$]"
        '            conn.Close()
        '        End If
        '        UploadXlxs.Enabled = True

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
    End Sub

    Private Sub UploadToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        '    Try

        '        For i = 0 To gridActivity.RowCount - 1

        '            Dim bucket As String = gridActivity.Rows(i).Cells(0).Value.ToString
        '            Dim activity As String = gridActivity.Rows(i).Cells(1).Value.ToString
        '            Dim subactivity As String = gridActivity.Rows(i).Cells(2).Value.ToString
        '            Dim task As String = gridActivity.Rows(i).Cells(3).Value.ToString
        '            Dim upt As String = gridActivity.Rows(i).Cells(4).Value.ToString
        '            Dim exlock As String = gridActivity.Rows(i).Cells(5).Value.ToString
        '            Dim volume As String = gridActivity.Rows(i).Cells(6).Value.ToString
        '            Dim aid As String = gridActivity.Rows(i).Cells(7).Value.ToString
        '            Dim cmnt As String = gridActivity.Rows(i).Cells(8).Value.ToString

        '            Dim conn As New pgConnect
        '            Dim value As String
        '            value = lblprocessid.Text & "^" & lblProject.Text & "^" & lblProcess.Text & "^" & lblSubProcess.Text & "^" & bucket & "^" & activity & "^" & subactivity & "^" & task & "^" & upt & "^" & exlock & "^" & volume & "^" & aid & "^" & cmnt & "^" & "Active"
        '            conn.InsertRecord("time_activity", "project_id,project,process,sub_process,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", value)

        '        Next

        '        Call TimeViewActivity()
        '        Dim Msg As MsgBoxResult = MsgBox("Activities imported successfully", vbInformation, "Success")

        '    Catch ex As Exception

        '    End Try
    End Sub

    Private Sub UploadCsv_Click(sender As Object, e As EventArgs)

        '    Try

        '        For i = 1 To gridActivity.RowCount

        '            Dim bucket As String = gridActivity.Rows(i).Cells(0).Value.ToString
        '            Dim activity As String = gridActivity.Rows(i).Cells(1).Value.ToString
        '            Dim subactivity As String = gridActivity.Rows(i).Cells(2).Value.ToString
        '            Dim task As String = gridActivity.Rows(i).Cells(3).Value.ToString
        '            Dim upt As String = gridActivity.Rows(i).Cells(4).Value.ToString
        '            Dim exlock As String = gridActivity.Rows(i).Cells(5).Value.ToString
        '            Dim volume As String = gridActivity.Rows(i).Cells(6).Value.ToString
        '            Dim aid As String = gridActivity.Rows(i).Cells(7).Value.ToString
        '            Dim cmnt As String = gridActivity.Rows(i).Cells(8).Value.ToString

        '            Dim conn As New pgConnect
        '            Dim value As String
        '            value = lblprocessid.Text & "^" & lblProject.Text & "^" & lblProcess.Text & "^" & lblSubProcess.Text & "^" & bucket & "^" & activity & "^" & subactivity & "^" & task & "^" & upt & "^" & exlock & "^" & volume & "^" & aid & "^" & cmnt & "^" & "Active"
        '            conn.InsertRecord("time_activity", "project_id,project,process,sub_process,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", value)

        '        Next

        '        Call TimeViewActivity()
        '        Dim Msg As MsgBoxResult = MsgBox("Activities imported successfully", vbInformation, "Success")

        '    Catch ex As Exception

        '    End Try


    End Sub

   

#End Region
#Region "Grid handeling"

    Public Sub gridformat(DGV)

        Dim DG As DataGridView
        DG = DGV
        DG.AllowUserToAddRows = False
        DG.DefaultCellStyle.Font = New Font("Verdana", 7, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 8, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.ClearSelection()
        DG.DefaultCellStyle.SelectionForeColor = DG.DefaultCellStyle.ForeColor
        'DG.DefaultCellStyle.BackColor = Color.Linen
        DG.EnableHeadersVisualStyles = True
        DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'DG.Columns("ID").Visible = False
        'DG.AutoResizeColumns()


    End Sub

    'Public Sub gridTeamView_FilterStringChanged(sender As Object, e As EventArgs)
    '    BindingSource.Filter = gridTeamView.FilterString
    '    gridTeamView.DataSource = BindingSource
    'End Sub

    Public Sub gridMasterUpdate_FilterStringChanged(sender As Object, e As EventArgs)
        'BindingSource.Filter = gridMasterUpdate.FilterString
        'gridMasterUpdate.DataSource = BindingSource

        'Call TotalSummary()

    End Sub








#End Region
#Region "Shift Compliance"

    'Private Sub ShiftCompliance()
    '    Try
    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '        Dim conn As New pgConnect
    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        conn.GetRecordsGRID("team_view", "name,empl_id,date,in_time,out_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
    '        gridShiftCom.Columns.Clear()
    '        BindingSource.DataSource = conn.DataTable


    '        conn.DataTable.Columns.Add("Shift Type")
    '        conn.DataTable.Columns.Add("Shift Start")
    '        conn.DataTable.Columns.Add("Shift End")
    '        conn.DataTable.Columns.Add("In Time Compliance")
    '        conn.DataTable.Columns.Add("Out Time Compliance")
    '        gridShiftCom.DataSource = BindingSource

    '        gridformat(gridShiftCom)
    '        gridShiftCom.Columns("empl_id").Visible = False
    '        With gridShiftCom
    '            .Columns(0).HeaderCell.Value = "User"
    '            .Columns(2).HeaderCell.Value = "Date"
    '            .Columns(3).HeaderCell.Value = "In Time"
    '            .Columns(3).HeaderCell.Value = "Out Time"
    '        End With




    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    'Private Sub Shift_compliance_Export()

    '    Dim FBD As New FolderBrowserDialog

    '    Dim xlPackage As New ExcelPackage()
    '    Dim oBook As ExcelWorkbook = xlPackage.Workbook
    '    Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Shift Compliance")
    '    Dim savepath As String
    '    Dim dt As New DataTable
    '    dt = TryCast(gridShiftCom.DataSource, DataTable)

    '    Dim dc As System.Data.DataColumn
    '    Dim dr As System.Data.DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0


    '    For Each dr In dt.Rows
    '        rowIndex = rowIndex + 1
    '        colIndex = 0
    '        For Each dc In dt.Columns
    '            colIndex = colIndex + 1

    '            ws.Cells(1, colIndex).Value = dc.ColumnName
    '            ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)

    '        Next
    '    Next

    '    ws.Cells.AutoFitColumns()
    '    ws.Column(4).Style.Numberformat.Format = "hh:mm:ss AM/PM"
    '    ws.Column(5).Style.Numberformat.Format = "hh:mm:ss AM/PM"
    '    ws.Column(6).Style.Numberformat.Format = "hh:mm:ss AM/PM"

    '    If (FBD.ShowDialog() = DialogResult.OK) Then
    '        savepath = FBD.SelectedPath
    '        Dim excelFile As New FileInfo(savepath & "\" & "Shift Compliance" & ".xlsx")
    '        xlPackage.SaveAs(excelFile)
    '        MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")
    '    End If

    'End Sub

#End Region
#Region "Extended Hours"
    'Dim totaltime As String

    'Private Sub ExtendedHours()

    '    Try
    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")
    '        Dim Conn As New pgConnect

    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        Conn.GetRecordsGRID("time_view", "DISTINCT name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
    '        GridExtendedHours.Columns.Clear()



    '        Dim dt11 As Date = SDate
    '        Dim dt21 As Date = EDate

    '        Dim ts As TimeSpan = dt21.Subtract(dt11)
    '        Dim days As Integer = Convert.ToInt32(ts.Days)
    '        Dim hday As String = Format(dt11, "ddd")

    '        For j = 0 To days - 1
    '            GridExtendedHours.EnableHeadersVisualStyles = False
    '            Conn.DataTable.Columns.Add(Format(dt11.AddDays(j), "dd-MMM-yy"))
    '        Next

    '        BindingSource.DataSource = Conn.DataTable
    '        GridExtendedHours.DataSource = BindingSource

    '        With GridExtendedHours
    '            .Columns(0).HeaderCell.Value = "Name"
    '        End With
    '        Call gridformat(GridExtendedHours)


    '        For i = 0 To GridExtendedHours.Rows.Count - 1
    '            Dim EEname As String = GridExtendedHours.Rows(i).Cells(0).Value
    '            For x = 1 To GridExtendedHours.Columns.Count - 1
    '                Dim EEdate As String = GridExtendedHours.Columns(x).HeaderText

    '                Call extend_hour_time(EEname, EEdate)

    '                If Format(totaltime / 60, "0.0") > 0 Then
    '                    GridExtendedHours.Rows(i).Cells(x).Value = Format(totaltime / 60, "0.0")
    '                ElseIf totaltime = 0 Then
    '                    If Format(EDate, "ddd") = "Sat" Or Format(EDate, "ddd") = "Sun" Then
    '                        GridExtendedHours.Rows(i).Cells(x).Value = 0
    '                    Else
    '                        GridExtendedHours.Rows(i).Cells(x).Value = 0
    '                    End If
    '                Else
    '                    GridExtendedHours.Rows(i).Cells(x).Value = 0
    '                End If
    '                totaltime = Nothing
    '            Next
    '        Next

    '        'Call extend_hour_summary()
    '        'Call ExtendedEmplID()

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    'Private Sub ExtendedEmplID()

    '    For i = 0 To GridExtendedHours.RowCount - 1
    '        GridExtendedHours.Rows(i).Cells(0).Tag = "Woha"
    '    Next


    'End Sub

    'Private Sub GridExtendedHours_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridExtendedHours.CellContentClick
    '    'Dim i As Integer = GridExtendedHours.CurrentRow.Index
    '    'GridExtendedHours.Rows(i).Selected = True
    '    'MsgBox(GridExtendedHours.Item(0, i).Tag)
    'End Sub

    'Sub extend_hour_time(EEname, EEdate)

    '    Dim icount2 As Integer

    '    Dim EDate As String = EEdate


    '    Dim conn As New pgConnect
    '    Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & EEname & "^" & EDate
    '    conn.GetRecordsGRIDGROUP("time_view", "SUM(total_time) AS SumOfTimeMin", "project =@value1 AND process =@value2 AND sub_process =@value3 AND name =@value4 AND date =@value5", value)

    '    icount2 = conn.DataTable.Rows.Count

    '    'MsgBox(conn.DataTable.Rows(0).Item("SumOfTimeMin").ToString)

    '    If icount2 = 0 Then
    '        totaltime = 0
    '    End If

    '    For x = 0 To icount2 - 1
    '        If Not IsDBNull(conn.DataTable.Rows(x).Item("SumOfTimeMin")) Then
    '            totaltime = conn.DataTable.Rows(x).Item("SumOfTimeMin")
    '        End If
    '    Next

    'End Sub

    'Private Sub extend_hour_summary()

    '    Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '    Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '    Dim dt11 As Date = SDate 'DateTime = Convert.ToDateTime(DateStart.Value.ToString("dd-MM-yy"))
    '    Dim dt21 As Date = EDate 'As DateTime = Convert.ToDateTime(DateEnd.Value.ToString("dd-MMM-yy"))
    '    Dim ts As TimeSpan = dt21.Subtract(dt11)
    '    Dim days As Integer = Convert.ToInt32(ts.Days)
    '    Dim WeekdaytimeExtended As Double
    '    Dim TotalTimeWeekDays, TotalTimeWeekend As Double
    '    Dim TotalWeekdays, TotalWeekends As Integer
    '    Dim SummaryColNo As Integer


    '    Dim conn As New pgConnect
    '    Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '    conn.GetRecordsGRID("time_view", "DISTINCT name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
    '    DataGridView11.Columns.Clear()

    '    Dim totcol As String = GridExtendedHours.Columns.Count - 1
    '    Dim i As Integer


    '    For i = 1 To totcol
    '        Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
    '        Dim hday As String = Format(hdate, "ddd")
    '        If hday = "Sun" Then
    '            conn.DataTable.Columns.Add(dt11.AddDays(i - 7) & " to " & dt11.AddDays(i - 1))
    '        End If
    '    Next

    '    'BindingSource.DataSource = conn.DataTable
    '    DataGridView11.DataSource = conn.DataTable



    '    With DataGridView11
    '        .Columns(0).HeaderCell.Value = "Name"
    '    End With

    '    gridformat(DataGridView11)


    '    For x = 0 To GridExtendedHours.Rows.Count - 1
    '        For i = 1 To totcol
    '            Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
    '            Dim hday As String = Format(hdate, "ddd")

    '            'Colour Sat and Sun--------------------------------------------------------------
    '            If hday = "Sat" Or hday = "Sun" Then
    '                GridExtendedHours.Rows(x).Cells(i).Style.BackColor = Color.Orange
    '                GridExtendedHours.ClearSelection()
    '            End If
    '            'Colour Sat and Sun--------------------------------------------------------------


    '        Next
    '    Next


    '    Dim workingdaywek As Integer = 0
    '    For x = 0 To GridExtendedHours.Rows.Count - 1
    '        For i = 1 To totcol
    '            Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
    '            Dim hday As String = Format(hdate, "ddd")
    '            Dim cellval As String = GridExtendedHours.Rows(x).Cells(i).Value

    '            ''Weekday Time Calculation
    '            If hday <> "Sat" And hday <> "Sun" Then
    '                If cellval <> "L" And cellval <> "W" Then
    '                    TotalTimeWeekDays = TotalTimeWeekDays + cellval
    '                    TotalWeekdays = TotalWeekdays + 1
    '                    'MsgBox("Weekday" & TotalWeekdays)
    '                Else
    '                    TotalTimeWeekDays = TotalTimeWeekDays + 0
    '                    TotalWeekdays = TotalWeekdays + 1
    '                    'MsgBox("Weekday" & TotalWeekdays)
    '                End If
    '            End If

    '            ''Weekend Time Calculation
    '            If hday = "Sat" Or hday = "Sun" Then
    '                If cellval <> "L" And cellval <> "W" Then
    '                    TotalTimeWeekend = TotalTimeWeekend + cellval
    '                    TotalWeekends = TotalWeekends + 1
    '                    'MsgBox("Weekday" & TotalWeekends)
    '                Else
    '                    TotalTimeWeekend = TotalTimeWeekend + 0
    '                    TotalWeekends = TotalWeekends + 1
    '                    'MsgBox("Weekday" & TotalWeekends)
    '                End If
    '            End If

    '            If hday = "Sun" Then

    '                'MsgBox(hdate)
    '                'MsgBox(hday)

    '                SummaryColNo = SummaryColNo + 1

    '                If TotalWeekdays = 5 Then
    '                    If TotalTimeWeekDays - 48 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 48
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 4 Then
    '                    If TotalTimeWeekDays - 38.4 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 38.4
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 3 Then
    '                    If TotalTimeWeekDays - 28.8 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 28.8
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 2 Then
    '                    If TotalTimeWeekDays - 19.2 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 19.2
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 1 Then
    '                    If TotalTimeWeekDays - 9.6 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 9.6
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                End If





    '                DataGridView11.Rows(x).Cells(SummaryColNo).Value = Format(TotalTimeWeekend + WeekdaytimeExtended, "0.00")

    '                TotalTimeWeekDays = 0
    '                TotalTimeWeekend = 0
    '                TotalWeekdays = 0
    '                TotalWeekends = 0
    '                WeekdaytimeExtended = 0
    '            End If


    '        Next
    '        SummaryColNo = 0
    '    Next

    'End Sub

    'Private Sub Extended_hours_report()

    '    Dim xlPackage As New ExcelPackage()
    '    Dim oBook As ExcelWorkbook = xlPackage.Workbook
    '    Dim ws1 As ExcelWorksheet = oBook.Worksheets.Add("Top 15 contributors")
    '    Dim ws2 As ExcelWorksheet = oBook.Worksheets.Add("Extended Hours")
    '    'Dim ws3 As ExcelWorksheet = oBook.Worksheets.Add("Summary")
    '    Dim savepath As String
    '    Dim gridvalue As Double
    '    Dim WeekdaytimeExtended As Double
    '    Dim dt11 As Date = DateStart.Text
    '    Dim dt12 As Date = DateEnd.Text
    '    Dim cell As New EPPClass

    '    Try

    '        Dim totalrow As Integer = GridExtendedHours.Rows.Count - 1
    '        Dim totalCol As Integer = GridExtendedHours.Columns.Count - 1
    '        Dim headdate As DateTime

    '        ws2.Cells("A1:E1").Merge = True
    '        ws2.Cells(1, 1).Value = "Extended hours payout_Nielsen MR BPS-  " & dt11 & "  to  " & dt12
    '        cell.ColorCell(ws2, 1, 1, 196, 215, 155)

    '        ws2.Cells(2, 1).Value = "Customer Lead"
    '        ws2.Cells(2, 2).Value = "Employee ID"
    '        ws2.Cells(2, 3).Value = "Employee Name"
    '        ws2.Cells(2, 4).Value = "WON Number"
    '        ws2.Cells(2, 5).Value = "BPS Grade"
    '        ws2.Cells(2, 6).Value = "Type of Day/ Total workeding hours"

    '        For j = 1 To totalCol
    '            headdate = GridExtendedHours.Columns(j).HeaderText
    '            ws2.Cells(1, j + 6).Value = Format(headdate, "ddd")
    '            ws2.Cells(2, j + 6).Value = headdate
    '            ws2.Cells(2, j + 6).Style.Numberformat.Format = "dd-MMM-yy"
    '        Next


    '        For i = 0 To totalrow
    '            For j = 1 To totalCol
    '                'ws2.Cells(i + 2, 3).Value = GridExtendedHours.Rows(i).Cells(0).Tag
    '                ws2.Cells(i + 3, 3).Value = GridExtendedHours.Rows(i).Cells(0).Value
    '                ws2.Cells(i + 3, 6).Value = "Total worked Hours"
    '                gridvalue = GridExtendedHours.Rows(i).Cells(j).Value
    '                ws2.Cells(i + 3, j + 6).Value = gridvalue
    '                ws2.Cells(i + 3, j + 6).Style.Numberformat.Format = "0.0"
    '            Next
    '        Next


    '        Dim weeknum As Integer = 1
    '        For i = 7 To 365
    '            If ws2.Cells(1, i).Value = "Sun" Then
    '                ws2.InsertColumn(i + 1, 1)
    '                ws2.Cells(1, i + 1).Value = "Week Summary"
    '                ws2.Cells(2, i + 1).Value = "Extended Hrs in week-" & weeknum
    '                weeknum = weeknum + 1
    '            End If
    '        Next

    '        Dim icol As Integer = ws2.Dimension.End.Column
    '        If ws2.Cells(1, ws2.Dimension.End.Column).Value <> "Sun" Then
    '            ws2.Cells(1, icol + 1).Value = "Week Summary"
    '            ws2.Cells(2, icol + 1).Value = "Extended Hrs in week-" & weeknum
    '            ws2.Cells(1, icol + 2).Value = "Total Extended Hours"
    '            ws2.Cells(2, icol + 2).Value = "Total Extended Hours"
    '            ws2.Cells(1, icol + 3).Value = "Total Extended Hours"
    '            ws2.Cells(2, icol + 3).Value = "Total Extended Hours(N)"
    '            ws2.Cells(1, icol + 4).Value = "Total Extended Hours"
    '            ws2.Cells(2, icol + 4).Value = "Total Extended Hours(W)"
    '            ws2.Cells(1, icol + 5).Value = "Total Extended Hours"
    '            ws2.Cells(2, icol + 5).Value = "Total Extended Hours(H)"
    '        End If

    '        'Check for the holiday
    '        Dim row As String = ws2.Dimension.End.Row + 1
    '        For i = 7 To ws2.Dimension.End.Column
    '            Dim hday As String = ws2.Cells(1, i).Value
    '            If hday <> "Sat" And hday <> "Sun" And hday <> "Week Summary" And hday <> "Total Extended Hours" Then
    '                Dim idate As Date = ws2.Cells(2, i).Value
    '                'If holidaylist(idate) = True Then
    '                'ws2.Cells(row, i).Value = 1
    '                'Else
    '                ws2.Cells(row, i).Value = 0
    '                'End If
    '            End If
    '        Next

    '        Dim TotalTimeWeekDays, TotalTimeWeekend, TotalTimeHoliday As Double
    '        Dim TotalWeekdays, TotalWeekends, TotalHoliday As Integer
    '        For j = 3 To ws2.Dimension.End.Row
    '            If j = 12 Then
    '                ' MsgBox(j)
    '            End If
    '            For i = 7 To ws2.Dimension.End.Column
    '                Dim hday As String = ws2.Cells(1, i).Value
    '                Dim dayTime As Double = ws2.Cells(j, i).Value




    '                If hday <> "Sat" And hday <> "Sun" And hday <> "Week Summary" And hday <> "Total Extended Hours" Then
    '                    Dim idate As Date = ws2.Cells(2, i).Value
    '                    If ws2.Cells(ws2.Dimension.End.Row, i).Value = 0 Then
    '                        TotalTimeWeekDays = TotalTimeWeekDays + dayTime
    '                        TotalWeekdays = TotalWeekdays + 1

    '                    ElseIf ws2.Cells(ws2.Dimension.End.Row, i).Value = 1 Then
    '                        TotalTimeHoliday = TotalTimeHoliday + dayTime
    '                        TotalHoliday = TotalHoliday + 1
    '                    End If
    '                End If

    '                If hday = "Sat" Or hday = "Sun" Then
    '                    TotalTimeWeekend = TotalTimeWeekend + dayTime
    '                    TotalWeekends = TotalWeekends + 1
    '                End If

    '                If TotalWeekdays = 5 Then
    '                    If TotalTimeWeekDays - 48 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 48
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 4 Then
    '                    If TotalTimeWeekDays - 38.4 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 38.4
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 3 Then
    '                    If TotalTimeWeekDays - 28.8 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 28.8
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 2 Then
    '                    If TotalTimeWeekDays - 19.2 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 19.2
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                ElseIf TotalWeekdays = 1 Then
    '                    If TotalTimeWeekDays - 9.6 > 0 Then
    '                        WeekdaytimeExtended = TotalTimeWeekDays - 9.6
    '                    Else
    '                        WeekdaytimeExtended = 0.0
    '                    End If
    '                End If

    '                Dim summary As Double
    '                If hday = "Week Summary" Then
    '                    summary = TotalTimeWeekend + WeekdaytimeExtended + TotalTimeHoliday
    '                    ws2.Cells(j, i).Value = summary
    '                    ws2.Cells(j, i).Style.Numberformat.Format = "0.0"
    '                End If

    '                If hday = "Week Summary" Then
    '                    TotalTimeWeekDays = 0
    '                    TotalTimeWeekend = 0
    '                    TotalTimeHoliday = 0
    '                    TotalWeekdays = 0
    '                    TotalWeekends = 0
    '                    TotalHoliday = 0
    '                    WeekdaytimeExtended = 0
    '                End If

    '            Next

    '            TotalTimeWeekDays = 0
    '            TotalTimeWeekend = 0
    '            TotalTimeHoliday = 0
    '            TotalWeekdays = 0
    '            TotalWeekends = 0
    '            TotalHoliday = 0
    '            WeekdaytimeExtended = 0
    '        Next


    '        'Total Extended hours
    '        Dim TimeSummary As Double
    '        Dim TotalTime As Double
    '        For i = 3 To ws2.Dimension.End.Row
    '            For j = 7 To ws2.Dimension.End.Column
    '                If ws2.Cells(1, j).Value = "Week Summary" Then
    '                    TimeSummary = ws2.Cells(i, j).Value
    '                    TotalTime = TotalTime + TimeSummary
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 3).Value = TotalTime
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 3).Style.Numberformat.Format = "0.0"
    '                End If
    '            Next
    '            TotalTime = 0
    '        Next

    '        'Weekend extended hours
    '        For i = 3 To ws2.Dimension.End.Row
    '            For j = 7 To ws2.Dimension.End.Column
    '                Dim hday As String = ws2.Cells(1, j).Value
    '                Dim hday2 As String = ws2.Cells(2, j).Value
    '                If hday = "Sat" Or hday = "Sun" Then
    '                    TimeSummary = ws2.Cells(i, j).Value
    '                    TotalTime = TotalTime + TimeSummary
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 1).Value = TotalTime
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 1).Style.Numberformat.Format = "0.0"
    '                End If
    '            Next
    '            TotalTime = 0
    '        Next

    '        'Holiday extended hour
    '        For i = 3 To ws2.Dimension.End.Row
    '            For j = 7 To ws2.Dimension.End.Column
    '                Dim hday As String = ws2.Cells(1, j).Value
    '                Dim hdate As String = ws2.Cells(2, j).Value
    '                If hday = "Mon" Or hday = "Tue" Or hday = "Wed" Or hday = "Thu" Or hday = "fri" Then
    '                    If ws2.Cells(ws2.Dimension.End.Row, j).Value = 1 Then
    '                        TimeSummary = ws2.Cells(i, j).Value
    '                        TotalTime = TotalTime + TimeSummary
    '                        ws2.Cells(i, ws2.Dimension.End.Column).Value = TotalTime
    '                        ws2.Cells(i, ws2.Dimension.End.Column).Style.Numberformat.Format = "0.0"
    '                    End If
    '                End If
    '            Next
    '            TotalTime = 0
    '        Next

    '        'Normal extended hours
    '        For i = 3 To ws2.Dimension.End.Row
    '            For j = 7 To ws2.Dimension.End.Column
    '                Dim hday2 As String = ws2.Cells(2, j).Value
    '                If hday2 = "Total Extended Hours" Then
    '                    Dim totalexthr As Double = ws2.Cells(i, ws2.Dimension.End.Column - 3).Value
    '                    Dim totalexthrWknd As Double = ws2.Cells(i, ws2.Dimension.End.Column - 1).Value
    '                    Dim totalexthrholiday As Double = ws2.Cells(i, ws2.Dimension.End.Column).Value
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 2).Value = totalexthr - totalexthrWknd - totalexthrholiday
    '                    ws2.Cells(i, ws2.Dimension.End.Column - 2).Style.Numberformat.Format = "0.0"
    '                End If
    '            Next
    '        Next




    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Color Formating
    '        For i = 1 To ws2.Dimension.End.Column
    '            Dim hday As String = ws2.Cells(1, i).Value
    '            cell.ColorCell(ws2, 1, i, 196, 215, 155)
    '            For j = 2 To ws2.Dimension.End.Row
    '                If hday = "Sat" Or hday = "Sun" Then
    '                    cell.ColorCell(ws2, j, i, 252, 213, 180)
    '                End If

    '                If hday = "Week Summary" Then
    '                    cell.ColorCell(ws2, j, i, 146, 205, 220)
    '                End If

    '                If hday = "Total Extended Hours" Then
    '                    cell.ColorCell(ws2, j, i, 196, 189, 151)
    '                End If
    '            Next
    '        Next
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Color Formating.

    '        'deleting bottom row
    '        ws2.DeleteRow(ws2.Dimension.End.Row)

    '        'Summession of all time
    '        Dim tottime As Double
    '        Dim itime As Double
    '        For i = 7 To ws2.Dimension.End.Column
    '            Dim hday As String = ws2.Cells(1, i).Value
    '            If hday = "Week Summary" Or hday = "Total Extended Hours" Then
    '                For j = 3 To ws2.Dimension.End.Row
    '                    itime = ws2.Cells(j, i).Value
    '                    tottime = tottime + itime
    '                    ws2.Cells(1, i).Value = tottime
    '                    cell.ColorCell(ws2, 1, i, 118, 147, 151)
    '                Next
    '            End If
    '            tottime = 0
    '        Next




    '        'ws2.View.FreezePanes(1, 7)
    '        ws2.Cells.AutoFitColumns(2)
    '        ws2.View.ZoomScale = 80
    '        ws2.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
    '        ws2.Select()

    '        Dim FBD As New FolderBrowserDialog
    '        If (FBD.ShowDialog() = DialogResult.OK) Then
    '            savepath = FBD.SelectedPath
    '            Dim excelFile As New FileInfo(savepath & "\" & "Extended Hours" & ".xlsx")
    '            xlPackage.SaveAs(excelFile)
    '            MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    ''Public Function holidaylist(idate)

    ''Dim holiday As New AccessConnect
    ''Dim qry As String = "Hdate=#" & Format(idate, "dd-MMM-yy") & "#"
    ''Dim hdr As OleDbDataReader = holiday.GetRecordsMaster("HolidayList", , qry)


    ''If hdr.HasRows Then
    ''    'MsgBox("Holiday")
    ''    Return True
    ''Else
    ''    Return False
    ''End If

    ' ''While dr.Read
    ' ''    MsgBox(dr("HolidayName"))
    ' ''End While

    ''holiday.masterconnClose()
    ''End Function

    'Private Sub ExportReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportReportToolStripMenuItem.Click

    'End Sub


#End Region
#Region "Think Poll"

    'Public Sub ThinkPollLoad()

    '    Try
    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")
    '        Dim Conn As New pgConnect

    '        Dim value As String = ProjectID & "^" & SDate & "^" & EDate
    '        Conn.GetRecordsGRID("think_poll", "poll_id,poll_title,poll_question,option_1,option_2,option_3,option_4,poll_status,owner,date", "process_id =@value1 AND date >=@value2 AND date <=@value3", value)
    '        ThinkPollgrid.Columns.Clear()


    '        BindingSource.DataSource = Conn.DataTable
    '        ThinkPollgrid.DataSource = BindingSource

    '        With ThinkPollgrid
    '            .Columns(0).HeaderCell.Value = "ID"
    '            .Columns(1).HeaderCell.Value = "Poll Title"
    '            .Columns(2).HeaderCell.Value = "Poll Question"
    '            .Columns(3).HeaderCell.Value = "Option 1"
    '            .Columns(4).HeaderCell.Value = "Option 2"
    '            .Columns(5).HeaderCell.Value = "Option 3"
    '            .Columns(6).HeaderCell.Value = "Option 4"
    '            .Columns(7).HeaderCell.Value = "Poll Status"
    '            .Columns(8).HeaderCell.Value = "Poll Owner"
    '            .Columns(9).HeaderCell.Value = "Poll Date"
    '        End With

    '        gridformat(ThinkPollgrid)
    '        ThinkPollgrid.Columns(0).Visible = False


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    'End Sub

    'Private Sub ThinkPollgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Dim i As Integer = ThinkPollgrid.CurrentRow.Index
    '    ThinkPollgrid.Rows(i).Selected = True
    '    IRow = ThinkPollgrid.Item(0, i).Value
    'End Sub

    'Private Sub CreatePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePollToolStripMenuItem.Click
    '    CreatePoll.Show()
    'End Sub

    'Private Sub ActivatePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivatePollToolStripMenuItem.Click
    '    Try
    '        If IRow = Nothing Then
    '            Dim msg As MsgBoxResult = MsgBox("Please select one poll", vbInformation, "No item selected")
    '        Else
    '            Dim conn As New pgConnect
    '            Dim Value As String = "Active" & "^" & IRow
    '            conn.UpdateRecord("think_poll", "poll_status = @value1", Value, "poll_id=@value2")
    '            Dim msg As MsgBoxResult = MsgBox("Poll activated successfully", vbInformation, "Activation Success")
    '            Call ThinkPollLoad()
    '            IRow = Nothing
    '        End If
    '    Catch ex As Exception
    '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub DeativatePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeativatePollToolStripMenuItem.Click
    '    Try
    '        Dim conn As New pgConnect
    '        Dim Value As String = "InActive" & "^" & IRow
    '        conn.UpdateRecord("think_poll", "poll_status = @value1", Value, "poll_id=@value2")
    '        Dim msg As MsgBoxResult = MsgBox("Poll activated successfully", vbInformation, "Activation Success")
    '        Call ThinkPollLoad()
    '    Catch ex As Exception
    '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub DeletePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePollToolStripMenuItem.Click
    '    Try
    '        Dim conn As New pgConnect
    '        Dim Value As String = IRow
    '        conn.DeleteRecord("think_poll", Value, "poll_id =@value1")
    '        Dim msg As MsgBoxResult = MsgBox("Poll deleted Successfully", vbInformation, "Poll Deleted")
    '        Call ThinkPollLoad()
    '    Catch ex As Exception
    '        Dim msg As MsgBoxResult = MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub NewPollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewPollToolStripMenuItem.Click
    '    CreatePoll.Show()
    '    CreatePoll.PollCreateFrom = "FromTree"
    'End Sub

#End Region
#Region "Utilization report"

    ''Private Workers As BackgroundWorker

    'Public Enum constants
    '    xlAbove = 0  '&H0
    '    xlRight = -4152  '&HFFFFEFC8
    'End Enum

    'Dim ExcelS As Object 'Excel.Application
    'Dim ExcelSst As Object 'Excel.Workbook
    'Dim ESheet As Object ' Excel.Worksheet
    Dim C1 As String
    'Dim Blue As String = "8DB4E2"
    'Dim Green As String = "D8E4BC"
    'Dim Gray As String = "BFBFBF"
    'Dim LGray As String = "D9D9D9"
    'Dim InteriorColor, InteriorColor1, InteriorColor2 As String
    'Dim proc, sproc, fName As String
    'Dim path As String
    'Dim PrsDBPath As String


    'Sub createExel()
    '    'Start Excel and get Application object.
    '    ExcelS = CreateObject("Excel.Application")
    '    ExcelS.Visible = True

    '    ' Get a new workbook.
    '    ExcelSst = ExcelS.Workbooks.Add
    '    ESheet = ExcelS.ActiveSheet

    '    ExcelS.Sheets(1).name = "KPI"
    '    ExcelS.Sheets(2).name = "Summary"
    '    ExcelS.Sheets(3).name = "Temp"
    '    ExcelS.Application.Worksheets.Add(After:=ExcelS.Application.Sheets(ExcelS.Application.Sheets.Count)).Name = "Date_Wise_Team_Utilization"
    '    ExcelS.Application.Worksheets.Add(After:=ExcelS.Application.Sheets(ExcelS.Application.Sheets.Count)).Name = "Activity_Wise_Team_Utilization"
    '    ExcelS.Application.Worksheets.Add(After:=ExcelS.Application.Sheets(ExcelS.Application.Sheets.Count)).Name = "Sub_Activity_Wise_Utilization"
    '    ExcelS.Application.Worksheets.Add(After:=ExcelS.Application.Sheets(ExcelS.Application.Sheets.Count)).Name = "Detail_Data"

    '    ExcelS.ActiveWorkbook.Sheets("KPI").Tab.Color = 25145
    '    ExcelS.ActiveWorkbook.Sheets("Summary").Tab.Color = Color.Blue
    '    ExcelS.ActiveWorkbook.Sheets("Temp").Tab.Color = Color.Aqua
    '    ExcelS.ActiveWorkbook.Sheets("Date_Wise_Team_Utilization").Tab.Color = Color.Aqua
    '    ExcelS.ActiveWorkbook.Sheets("Activity_Wise_Team_Utilization").Tab.Color = Color.Aqua
    '    ExcelS.ActiveWorkbook.Sheets("Sub_Activity_Wise_Utilization").Tab.Color = Color.Aqua
    '    ExcelS.ActiveWorkbook.Sheets("Detail_Data").Tab.Color = Color.Aqua
    'End Sub

    'Sub KPIActivitytoSheet()

    '    Dim i, icount As Integer
    '    Dim tp As String
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0

    '    ExcelS.Sheets("KPI").select()

    '    Dim conn As New pgConnect
    '    Dim value As String = Project & "^" & Process & "^" & SubProcess
    '    conn.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "bucket,activity,sub_activity,task")
    '    icount = conn.DataTable.Rows.Count - 1
    '    Dim ii As Integer = 10
    '    ExcelS.Application.ActiveWindow.Zoom = 80
    '    ExcelS.Application.Range("A9:K9").Interior.Color = RGB(31, 73, 125)

    '    For i = 0 To icount
    '        tp = conn.DataTable.Rows(i).Item("Bucket")

    '        If ExcelS.Application.Range("D" & ii - 1).Value <> tp Then
    '            ExcelS.Application.Range("A" & ii).Value = tp
    '            'Blue Color
    '            ExcelS.Application.Range("A" & ii & ":K" & ii).Interior.Color = RGB(141, 180, 226)
    '            ExcelS.Application.Selection.Font.Bold = True
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("D" & ii).Value = tp
    '            ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
    '                "-" & conn.DataTable.Rows(i).Item("sub_activity") &
    '                "-" & conn.DataTable.Rows(i).Item("task")
    '            ii = ii + 1
    '        End If

    '        If ExcelS.Application.Range("C" & ii - 1).Value <> conn.DataTable.Rows(i).Item("activity") Or ExcelS.Application.Range("B" & ii - 1).Value = "" Or ii = 3 Then

    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            'Green Color
    '            ExcelS.Application.Range("A" & ii & ":K" & ii).Interior.Color = RGB(216, 228, 188)
    '            ExcelS.Application.Selection.Font.Bold = False
    '            ExcelS.Application.Range("B" & ii).Value = tp
    '            ExcelS.Application.Range("B" & ii).Select()
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("D" & ii).Value = tp
    '            ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
    '                "-" & conn.DataTable.Rows(i).Item("sub_activity") &
    '                "-" & conn.DataTable.Rows(i).Item("task")
    '            ii = ii + 1


    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            'Gray Color
    '            ExcelS.Application.Range("A" & ii & ":K" & ii).Interior.Color = RGB(191, 191, 191)
    '            ExcelS.Application.Selection.Font.Bold = False
    '            ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("D" & ii).Value = tp
    '            ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
    '                "-" & conn.DataTable.Rows(i).Item("sub_activity") &
    '                "-" & conn.DataTable.Rows(i).Item("task")
    '            ii = ii + 1

    '        ElseIf ExcelS.Application.Range("B" & ii - 1).Value <> conn.DataTable.Rows(i).Item("sub_activity") Then
    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            'Gray Color
    '            ExcelS.Application.Range("A" & ii & ":K" & ii).Interior.Color = RGB(191, 191, 191)
    '            ExcelS.Application.Selection.Font.Bold = False
    '            ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("D" & ii).Value = tp
    '            ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
    '                "-" & conn.DataTable.Rows(i).Item("sub_activity") &
    '                "-" & conn.DataTable.Rows(i).Item("task")
    '            ii = ii + 1
    '        End If


    '        ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '        ExcelS.Application.Range("A" & ii).Select()
    '        ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '        'Light Gray for Next Column
    '        ExcelS.Application.Range("B" & ii).Interior.Color = RGB(217, 217, 217)
    '        ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '        ExcelS.Application.Range("D" & ii).Value = tp
    '        ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '        ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '        ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
    '            "-" & conn.DataTable.Rows(i).Item("sub_activity") &
    '            "-" & conn.DataTable.Rows(i).Item("task")
    '        ii = ii + 1

    '        ExcelS.Application.Application.StatusBar = "Generating KPI Format  " & Format(i / icount * 100, "0") & "%"



    '    Next

    '    ExcelS.Application.Range("A9:K" & ii - 1).Borders.LineStyle = BorderStyle.FixedSingle
    '    C1 = Int(ii - 2)

    'End Sub

    'Sub ActivityGroup()


    '    Dim i As Integer
    '    Dim InteriorColorSet As String
    '    Dim ColorCode(0 To 2) As String
    '    'Dim InteriorColor, InteriorColor1, InteriorColor2 As String
    '    'Dim style7, style8, style9 As String
    '    Dim GroupStartAdr, GroupEndAdr As Integer
    '    Dim GroupStartAdrCell As Integer = 0
    '    Dim GroupEndAdrCell As Integer = 0

    '    'Defined Colors to define the Groups
    '    ColorCode(0) = 14857357 'Blue
    '    ColorCode(1) = 12379352 'Green
    '    ColorCode(2) = 12566463 'Gray

    '    For ii = 0 To UBound(ColorCode) 'Loop for 3 Different Colors defined above

    '        For i = 10 To C1 'Loop for Grouping by checking all generated Lines

    '            InteriorColorSet = Int(ColorCode(ii)) 'Color Code Defined to take it as a base for loop

    '            'Check the Color Code of cell address on the basis of loop
    '            InteriorColor = ExcelS.Application.Range("A" & i).Interior.Color

    '            'Set ColorCode for PreviousCell (-1) for checking purpose
    '            InteriorColor1 = ExcelS.Application.Range("A" & i - 1).Interior.Color

    '            If i > 2 Then
    '                'Set ColorCode for PreviousCell (-2) for checking purpose
    '                InteriorColor2 = ExcelS.Application.Range("A" & i - 2).Interior.Color
    '            End If
    '            If InteriorColorSet = InteriorColor Or i = C1 Then 'Check if the Color Code is as per the Base Color
    '                'Identify Group Start Cell Address-START
    '                If InteriorColor1 <> InteriorColorSet Then
    '                    If GroupStartAdrCell = 0 Then
    '                        GroupStartAdr = ExcelS.Application.Range("A" & i).Row
    '                        GroupStartAdrCell = GroupStartAdr 'Set the Start Cell Address
    '                    End If
    '                End If
    '                'Identify Group Start Cell Address-END


    '                If InteriorColor1 <> InteriorColorSet And GroupStartAdrCell <> i Then 'Check if the color Code is as per the Base color and the Loop no is the last Value of the Loop or not
    '                    'Identify Group End Cell Address-START
    '                    GroupEndAdr = ExcelS.Application.Range("A" & i).Row
    '                    GroupEndAdrCell = GroupEndAdr

    '                    'Set the Cell Address as per the Previous Cells' Color to set Exact EndCell Adress Grouping-START
    '                    If i <> C1 Then GroupEndAdrCell = GroupEndAdrCell - 1
    '                    If i = C1 Then GroupEndAdrCell = C1 + 1
    '                    If InteriorColorSet = ColorCode(1) And InteriorColor1 = ColorCode(0) Then GroupEndAdrCell = GroupEndAdrCell - 1
    '                    If InteriorColorSet = ColorCode(2) And InteriorColor1 = ColorCode(1) And InteriorColor2 <> ColorCode(0) Then GroupEndAdrCell = GroupEndAdrCell - 1
    '                    If InteriorColorSet = ColorCode(2) And InteriorColor1 = ColorCode(1) And InteriorColor2 = ColorCode(0) Then GroupEndAdrCell = GroupEndAdrCell - 2
    '                    'Set the Cell Address as per the Previous Cells' Color to set Exact EndCell Adress Grouping-END
    '                    'Identify Group End Cell Address-END

    '                    'Select the Range on the bases of START and END Cells on the basis of above Codes
    '                    ExcelS.Application.Range("A" & GroupStartAdrCell + 1 & ":D" & GroupEndAdrCell).Select()
    '                    Call GroupPattern() 'Set the Group Pattern
    '                    ExcelS.Application.Selection.Rows.Group()
    '                    ExcelS.Application.Range("A1").Select()
    '                    GroupStartAdrCell = 0
    '                    GroupEndAdrCell = 0
    '                    If i = C1 Then Exit For
    '                    i = i - 2
    '                End If
    '            End If
    '        Next
    '    Next

    '    'Heading
    '    'ExcelS.Cells(1, 1) = "Bucket"
    '    'ExcelS.Cells(1, 2) = "Activity"
    '    'ExcelS.Cells(1, 3) = "Sub Activity"
    '    'ExcelS.Cells(1, 4) = "Task"

    'End Sub

    'Sub GroupPattern()
    '    '=======================================================Summary=======================================================
    '    'This will set Grouping [+] Sign on Title of the Grouped Data.
    '    'On Click of [+] will drill data below it instead of above it which is always set to default.
    '    '=======================================================Summary=======================================================
    '    With ExcelS.Application.ActiveSheet.Outline
    '        .AutomaticStyles = False
    '        .SummaryRow = constants.xlAbove
    '        .SummaryColumn = constants.xlRight
    '    End With
    '    'Summary Columsn Right to detail=Flagged
    '    ''''Summary Rows Below detail=NotFlagged
    '    '''''''''''''Sutomatic Styles=NotFlagged

    'End Sub

    'Sub KPiMainData_RD()

    '    Try

    '        Dim i, icount, C2 As Integer

    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '        Dim conn As New pgConnect
    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        conn.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity,sub_activity,task") 'AND date >=@value4 AND date <=@value5


    '        icount = conn.DataTable.Rows.Count - 1
    '        ExcelS.Application.ActiveWindow.Zoom = 80
    '        Dim ii As Integer = 2


    '        ExcelS.Sheets("Summary").select()
    '        ExcelS.Application.Range("B1").Value = "Activity"
    '        ExcelS.Application.Range("C1").Value = "Sub Activity"
    '        ExcelS.Application.Range("D1").Value = "Task"
    '        ExcelS.Application.Range("E1").Value = "Total Time (Hrs)"
    '        ExcelS.Application.Range("F1").Value = "Total Count"


    '        For i = 0 To icount
    '            ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("D" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("E" & ii).Value = Format((conn.DataTable.Rows(i).Item("TTime")) / 60, "0.00")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("TotCount")
    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("activity") & "-" & conn.DataTable.Rows(i).Item("sub_activity") & "-" & conn.DataTable.Rows(i).Item("task")
    '            'MsgBox(ds.Tables(0).Rows(i).Item("Activity"))
    '            ii = ii + 1
    '        Next

    '        ExcelS.Application.Sheets("KPI").Select()
    '        ExcelS.Application.ActiveWindow.Zoom = 80

    '        C2 = ExcelS.Application.WorksheetFunction.CountA(ExcelS.Application.Range("A:A"))


    '        For i = 10 To C2 + 9

    '            'If ExcelS.Application.Range("C" & i).Value = "CHANGE REQUEST" Or _
    '            '   ExcelS.Application.Range("C" & i).Value = "CLIENT INQUIRY" Or _
    '            '   ExcelS.Application.Range("C" & i).Value = "NEW SETUP" Then

    '            '    'Getting Weekly unique data of ID as Per Sub activity
    '            '    'Normal wala
    '            '    ExcelS.Application.Range("H" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-1],Summary!C[-7]:C[-3],5,0)),0)"
    '            '    ExcelS.Application.Range("I" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-2],Summary!C[-8]:C[-3],6,0)),0)"
    '            '    ExcelS.Application.Range("J" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"

    '            'Else

    '            'Normal CIPO Query
    '            'Monthly wala
    '            ExcelS.Application.Range("H" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-1],Summary!C[-7]:C[-3],5,0)),0)"
    '            ExcelS.Application.Range("I" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-2],Summary!C[-8]:C[-3],6,0)),0)"
    '            ExcelS.Application.Range("J" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"
    '            'ExcelS.Application.Range("J" & i).Value = Format(ExcelS.Application.Range("J" & i).value, "0.0")
    '            ExcelS.Application.Range("J" & i).NumberFormat = "0.0"
    '        Next

    '    Catch ex As Exception
    '        KPIDBConn.Close()
    '        MsgBox("Error in KPI main data copy" & vbNewLine & vbNewLine & ex.ToString)
    '    End Try



    'End Sub

    'Sub KPiMainData_CIPO()
    '    Try

    '        Dim i, icount, C2 As Integer

    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")


    '        Dim conn As New pgConnect
    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        conn.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity,sub_activity,task", ) 'AND date >=@value4 AND date <=@value5

    '        icount = conn.DataTable.Rows.Count - 1
    '        ExcelS.Application.ActiveWindow.Zoom = 80
    '        Dim ii As Integer = 2


    '        ExcelS.Sheets("Summary").select()
    '        ExcelS.Application.Range("B1").Value = "Activity"
    '        ExcelS.Application.Range("C1").Value = "Sub Activity"
    '        ExcelS.Application.Range("D1").Value = "Task"
    '        ExcelS.Application.Range("E1").Value = "Total Time (Hrs)"
    '        ExcelS.Application.Range("F1").Value = "Total Count"


    '        For i = 0 To icount
    '            ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("D" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            ExcelS.Application.Range("E" & ii).Value = Format((conn.DataTable.Rows(i).Item("TTime")) / 60, "0.00")
    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("TotCount")
    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("activity") & "-" & conn.DataTable.Rows(i).Item("sub_activity") & "-" & conn.DataTable.Rows(i).Item("task")
    '            'MsgBox(ds.Tables(0).Rows(i).Item("Activity"))
    '            ii = ii + 1
    '        Next

    '        ExcelS.Application.Sheets("KPI").Select()
    '        ExcelS.Application.ActiveWindow.Zoom = 80

    '        C2 = ExcelS.Application.WorksheetFunction.CountA(ExcelS.Application.Range("A:A"))


    '        For i = 10 To C2 + 9

    '            'If ExcelS.Application.Range("C" & i).Value = "CHANGE REQUEST" Or _
    '            '   ExcelS.Application.Range("C" & i).Value = "CLIENT INQUIRY" Or _
    '            '   ExcelS.Application.Range("C" & i).Value = "NEW SETUP" Then

    '            '    'Getting Weekly unique data of ID as Per Sub activity
    '            '    'Normal wala
    '            '    ExcelS.Application.Range("H" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-1],Summary!C[-7]:C[-3],5,0)),0)"
    '            '    ExcelS.Application.Range("I" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-2],Summary!C[-8]:C[-3],6,0)),0)"
    '            '    ExcelS.Application.Range("J" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"

    '            'Else

    '            'Normal CIPO Query
    '            'Monthly wala
    '            ExcelS.Application.Range("H" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-1],Summary!C[-7]:C[-3],5,0)),0)"
    '            ExcelS.Application.Range("I" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(RC[-2],Summary!C[-8]:C[-3],6,0)),0)"
    '            ExcelS.Application.Range("J" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"
    '            'ExcelS.Application.Range("J" & i).Value = Format(ExcelS.Application.Range("J" & i).value, "0.0")
    '            ExcelS.Application.Range("J" & i).NumberFormat = "0.0"
    '        Next

    '    Catch ex As Exception
    '        KPIDBConn.Close()
    '        MsgBox("Error in KPI main data copy" & vbNewLine & vbNewLine & ex.ToString)
    '    End Try

    'End Sub

    'Sub Detaildata()

    '    Try

    '        Dim i, icount As Integer

    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '        Dim conn As New pgConnect
    '        Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate
    '        conn.GetRecordsGRID("time_view", "date,name,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date  <=@value5", value)

    '        icount = conn.DataTable.Rows.Count - 1

    '        ExcelS.Application.ActiveWindow.Zoom = 80
    '        Dim ii As Integer = 2


    '        ExcelS.Sheets("Detail_Data").select()
    '        ExcelS.Application.ActiveWindow.Zoom = 80
    '        ExcelS.Application.Range("A1").Value = "Date"
    '        ExcelS.Application.Range("B1").Value = "Name"
    '        ExcelS.Application.Range("C1").Value = "Activity"
    '        ExcelS.Application.Range("D1").Value = "Sub Activity"
    '        ExcelS.Application.Range("E1").Value = "Task"
    '        ExcelS.Application.Range("F1").Value = "Activity Start Time"
    '        ExcelS.Application.Range("G1").Value = "Activity End Tim"
    '        ExcelS.Application.Range("H1").Value = "Time(Min)"
    '        ExcelS.Application.Range("I1").Value = "Volume"
    '        ExcelS.Application.Range("J1").Value = "Act ID"
    '        ExcelS.Application.Range("K1").Value = "Comments"



    '        For i = 0 To icount
    '            ExcelS.Application.Range("A" & ii).Value = conn.DataTable.Rows(i).Item("date")
    '            ExcelS.Application.Range("B" & ii).Value = conn.DataTable.Rows(i).Item("name")
    '            ExcelS.Application.Range("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
    '            ExcelS.Application.Range("D" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
    '            ExcelS.Application.Range("E" & ii).Value = conn.DataTable.Rows(i).Item("task")
    '            'Dim stime As Date = conn.DataTable.Rows(i).Item("start_time")
    '            'Dim etime As Date = conn.DataTable.Rows(i).Item("end_time")

    '            ExcelS.Application.Range("F" & ii).Value = conn.DataTable.Rows(i).Item("start_time")
    '            ExcelS.Application.Range("G" & ii).Value = conn.DataTable.Rows(i).Item("end_time")

    '            ExcelS.Application.Range("H" & ii).Value = conn.DataTable.Rows(i).Item("total_time")
    '            ExcelS.Application.Range("I" & ii).Value = conn.DataTable.Rows(i).Item("Volume")
    '            ExcelS.Application.Range("J" & ii).Value = conn.DataTable.Rows(i).Item("act_id")
    '            ExcelS.Application.Range("K" & ii).Value = conn.DataTable.Rows(i).Item("comment")

    '            'ExcelS.Application.Range("A" & ii).Value = ds.Tables(0).Rows(i).Item("Activity") & "-" & ds.Tables(0).Rows(i).Item("SubActivity") & "-" & ds.Tables(0).Rows(i).Item("Task")
    '            'MsgBox(ds.Tables(0).Rows(i).Item("Activity"))
    '            ii = ii + 1
    '            ExcelS.Application.Application.StatusBar = "Fetching Detail Deta  " & Format(i / icount * 100, "0") & "%"
    '        Next


    '    Catch ex As Exception

    '        MsgBox(ex.Message)
    '    End Try


    'End Sub

    'Sub GeneratingPivot()


    '    'Try

    '    ExcelS.Application.Application.StatusBar = "Pivoting Data "
    '    ExcelS.Application.Sheets("Detail_Data").Select()
    '    ExcelS.Application.ActiveWindow.Zoom = 80
    '    C1 = ExcelS.Application.WorksheetFunction.CountA(ExcelS.Application.Range("A:A"))

    '    '----------------------------------------Pivot1
    '    Dim xlWorkSheetDetail As Excel.Worksheet
    '    Dim FinalRow As Integer = Nothing
    '    Dim pivotTable As Excel.PivotTable = Nothing
    '    Dim pivotData As Excel.Range = Nothing
    '    Dim pivotDestination As Excel.Range = Nothing
    '    Dim f1 As Excel.PivotField = Nothing
    '    Dim f2 As Excel.PivotField = Nothing
    '    Dim f3 As Excel.PivotField = Nothing
    '    Dim fsum As Excel.PivotField = Nothing
    '    Dim fsum2 As Excel.PivotField = Nothing
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim pivotTableName As String
    '    xlWorkBook = ExcelSst
    '    xlWorkSheetDetail = ExcelS.Sheets("Detail_Data")



    '    '''''''Pivot 1
    '    FinalRow = xlWorkSheetDetail.Cells(ExcelS.Rows.Count, 1).end(Excel.XlDirection.xlUp).row
    '    pivotData = xlWorkSheetDetail.Range("A1:K" & FinalRow.ToString)
    '    pivotTableName = "QSTPivotTable"
    '    pivotDestination = ExcelS.sheets("Date_Wise_Team_Utilization").Range("A1")

    '    xlWorkBook.PivotTableWizard(Excel.XlPivotTableSourceType.xlDatabase,
    '    pivotData, pivotDestination, pivotTableName, True, True,
    '    True, True, , , False, False, Excel.XlOrder.xlDownThenOver, 0)

    '    pivotTable = xlWorkBook.ActiveSheet.PivotTables(pivotTableName)
    '    f1 = pivotTable.PivotFields(2)
    '    fsum = pivotTable.PivotFields(8)


    '    pivotTable.Format(Excel.XlPivotFormatType.xlReport9)

    '    f1.Orientation = Excel.XlPivotFieldOrientation.xlRowField
    '    fsum.Orientation = Excel.XlPivotFieldOrientation.xlDataField
    '    fsum.Function = Excel.XlConsolidationFunction.xlSum

    '    ExcelS.Application.ActiveWindow.Zoom = 80


    '    '''''''Pivot 2
    '    ExcelS.sheets("Detail_Data").select()
    '    FinalRow = xlWorkSheetDetail.Cells(ExcelS.Rows.Count, 1).end(Excel.XlDirection.xlUp).row
    '    pivotData = xlWorkSheetDetail.Range("A1:K" & FinalRow.ToString)
    '    pivotTableName = "QSTPivotTable"
    '    pivotDestination = ExcelS.sheets("Activity_Wise_Team_Utilization").Range("A1")

    '    xlWorkBook.PivotTableWizard(Excel.XlPivotTableSourceType.xlDatabase,
    '    pivotData, pivotDestination, pivotTableName, True, True,
    '    True, True, , , False, False, Excel.XlOrder.xlDownThenOver, 0)

    '    pivotTable = xlWorkBook.ActiveSheet.PivotTables(pivotTableName)
    '    f1 = pivotTable.PivotFields(3)
    '    f2 = pivotTable.PivotFields(2)
    '    f3 = pivotTable.PivotFields(1)
    '    fsum = pivotTable.PivotFields(8)


    '    pivotTable.Format(Excel.XlPivotFormatType.xlReport9)

    '    f1.Orientation = Excel.XlPivotFieldOrientation.xlRowField
    '    f2.Orientation = Excel.XlPivotFieldOrientation.xlRowField
    '    f3.Orientation = Excel.XlPivotFieldOrientation.xlColumnField
    '    fsum.Orientation = Excel.XlPivotFieldOrientation.xlDataField
    '    fsum.Function = Excel.XlConsolidationFunction.xlSum

    '    ExcelS.Application.ActiveWindow.Zoom = 80

    '    '''''''Pivot 3
    '    ExcelS.sheets("Detail_Data").select()
    '    FinalRow = xlWorkSheetDetail.Cells(ExcelS.Rows.Count, 1).end(Excel.XlDirection.xlUp).row
    '    pivotData = xlWorkSheetDetail.Range("A1:K" & FinalRow.ToString)
    '    pivotTableName = "QSTPivotTable"
    '    pivotDestination = ExcelS.sheets("Sub_Activity_Wise_Utilization").Range("A1")

    '    xlWorkBook.PivotTableWizard(Excel.XlPivotTableSourceType.xlDatabase,
    '    pivotData, pivotDestination, pivotTableName, True, True,
    '    True, True, , , False, False, Excel.XlOrder.xlDownThenOver, 0)

    '    pivotTable = xlWorkBook.ActiveSheet.PivotTables(pivotTableName)
    '    f1 = pivotTable.PivotFields(3)
    '    f2 = pivotTable.PivotFields(2)
    '    'f3 = pivotTable.PivotFields(10)
    '    fsum = pivotTable.PivotFields(8)
    '    fsum2 = pivotTable.PivotFields(9)

    '    pivotTable.Format(Excel.XlPivotFormatType.xlReport9)

    '    f2.Orientation = Excel.XlPivotFieldOrientation.xlRowField
    '    f1.Orientation = Excel.XlPivotFieldOrientation.xlColumnField
    '    'f3.Orientation = Excel.XlPivotFieldOrientation.xlColumnField
    '    fsum.Orientation = Excel.XlPivotFieldOrientation.xlDataField
    '    fsum2.Orientation = Excel.XlPivotFieldOrientation.xlDataField
    '    fsum.Function = Excel.XlConsolidationFunction.xlSum
    '    fsum2.Function = Excel.XlConsolidationFunction.xlSum

    '    ExcelS.Application.ActiveWindow.Zoom = 80



    'End Sub

    'Sub FormattingKPI()

    '    Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '    Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")


    '    ExcelS.sheets("KPI").select()
    '    ExcelS.Application.Range("H:I").Select()
    '    ExcelS.Application.Selection.Copy()
    '    ExcelS.Application.Range("H:I").PasteSpecial(Paste:=-4163) ' xlValu
    '    ExcelS.Application.Columns("C:G").Select()
    '    ExcelS.Application.Selection.Delete()

    '    ExcelS.Application.Range("A1:F1").Interior.Color = Color.Black
    '    'ExcelS.Application.Range("A1:F1").Selection.HorizontalAlignment = ExcelS.xlCenter
    '    ExcelS.Application.Range("A1:B1").Select()
    '    ExcelS.Application.Selection.Merge()
    '    ExcelS.Application.Range("C1:F1").Select()
    '    ExcelS.Application.Selection.Merge()

    '    ExcelS.Application.Range("A9").Value = "Activity"
    '    ExcelS.Application.Range("B9").Value = "Sub Activity"
    '    ExcelS.Application.Range("C9").Value = "Total Hours"
    '    ExcelS.Application.Range("D9").Value = "Total Count"
    '    ExcelS.Application.Range("E9").Value = "UPT"
    '    ExcelS.Application.Range("F9").Value = "Utilisation (%)"


    '    ExcelS.Application.Range("A2:F2,A4:F4,A6:F6,A8:F8").Interior.Color = Color.Gainsboro
    '    ExcelS.Application.Range("A1:C1").Font.Color = Color.Gainsboro

    '    ExcelS.Application.Range("A2").Value = "No. Of Working Days"
    '    ExcelS.Application.Range("A3").Value = "No. Of Holidays"
    '    ExcelS.Application.Range("A4").Value = "No. of FTE"
    '    ExcelS.Application.Range("A5").Value = "Total Available Hours"
    '    ExcelS.Application.Range("A6").Value = "Total Hours spent on Direct Activity (%)"
    '    ExcelS.Application.Range("A7").Value = "Total Hours spent on InDirect Activity (%)"
    '    ExcelS.Application.Range("A8").Value = "Total Hours spent on Validation Activity (%)"
    '    ExcelS.Application.Range("B6").Value = "[DIRECT/TOTAL AVAILABLE]"
    '    ExcelS.Application.Range("B7").Value = "[INDIRECT/TOTAL AVAILABLE]"
    '    ExcelS.Application.Range("B8").Value = "[VALIDATION/TOTAL AVAILABLE]"

    '    ExcelS.Application.Range("F2").Value = TotalWorkDays 'lblworkdays.Text
    '    ExcelS.Application.Range("F3").Value = TotalDays - TotalWorkDays
    '    ExcelS.Application.Range("F4").Value = TotalUser 'lblBillUser.Text
    '    ExcelS.Application.Range("F5").FormulaR1C1 = "=R[-1]C*(R[-3]C-R[-2]C)*8"
    '    ExcelS.Application.ActiveWindow.DisplayGridlines = False
    '    ExcelS.Application.Range("A8").Columns.AutoFit()
    '    ExcelS.Application.Range("B8").Columns.AutoFit()
    '    ExcelS.Application.Cells.WrapText = False
    '    ExcelS.Application.ActiveSheet.Outline.ShowLevels(3)
    '    ExcelS.Application.ActiveSheet.Outline.ShowLevels(2)
    '    ExcelS.Application.Range("A1").Value = prj.Text & " :: " & prc.Text & " ::Resource Utilization"
    '    ExcelS.Application.Range("C1").Value = SDate & " - to - " & EDate
    '    ExcelS.Application.Columns("C:F").Select()
    '    ExcelS.Application.Selection.ColumnWidth = 15
    '    ExcelS.Application.Columns("C:F").Select()
    '    ExcelS.Application.Selection.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
    '    'ExcelS.Sheets("Temp").Select()
    '    'ExcelS.ActiveWindow.SelectedSheets.Visible = False

    '    ExcelS.Application.Range("A2:F2,A4:F4,A6:F6,A8:F8").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A2:F2,A4:F4,A6:F6,A8:F8").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A2:F2,A4:F4,A6:F6,A8:F8").Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A2:F2,A4:F4,A6:F6,A8:F8").Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

    '    ExcelS.Application.Range("A3:F3,A5:F5,A7:F7").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A3:F3,A5:F5,A7:F7").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A3:F3,A5:F5,A7:F7").Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A3:F3,A5:F5,A7:F7").Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '    ExcelS.Application.Range("A1:F1").Font.size = 16



    'End Sub

    'Sub GettingUtilization()

    '    Dim c, r As Integer
    '    c = ExcelS.Application.WorksheetFunction.CountA(ExcelS.Application.Range("A:A"))
    '    r = 5

    '    For i = 10 To c
    '        ExcelS.Application.Range("F" & i).FormulaR1C1 = "=IFERROR(RC[-3]/R[-" & r & "]C,0)"
    '        r = r + 1
    '    Next
    '    ExcelS.Application.Range("F10:F" & c).Select()
    '    ExcelS.Application.Selection.NumberFormat = "0.0%"

    '    '--------------Time Summation

    '    For i = 10 To c
    '        If ExcelS.Application.Range("A" & i).Interior.ColorIndex <> -4142 Then
    '            ExcelS.Application.Range("C" & i).Value = "=SUMIF(R[1]C[-1]:R[" & c & "]C[-1],RC[-2],R[1]C:R[" & c & "]C)"
    '            ExcelS.Application.Range("D" & i).Value = "=SUMIF(R[1]C[-2]:R[" & c & "]C[-2],RC[-3],R[1]C:R[" & c & "]C)"
    '        End If
    '    Next

    '    ExcelS.Application.Range("A1").Select()
    '    '------------Utilization heading Update

    '    Dim sp1, sp2, sp3 As String
    '    Dim LastRow1 As Long
    '    LastRow1 = ExcelS.Application.WorksheetFunction.CountA(ExcelS.Application.Range("A:A"))
    '    For i = 1 To LastRow1

    '        If ExcelS.Application.Range("A" & i).text = "DIRECT" Then
    '            sp1 = ExcelS.Application.Range("F" & i).text
    '            ExcelS.Application.Range("F" & 6).value = sp1
    '        ElseIf ExcelS.Application.Range("A" & i).text = "INDIRECT" Then
    '            sp2 = ExcelS.Application.Range("F" & i).text
    '            ExcelS.Application.Range("F" & 7).value = sp2
    '        ElseIf ExcelS.Application.Range("A" & i).text = "VALIDATION" Then
    '            sp3 = ExcelS.Application.Range("F" & i).text
    '            ExcelS.Application.Range("F" & 8).value = sp3
    '        End If


    '    Next

    '    ExcelS.Application.Range("F6:F8").NumberFormat = "0.0%"
    '    ExcelS.Application.Range("A1").Select()

    'End Sub

    'Sub TemptoKPi()

    '    ExcelS.Application.Sheets("Temp").Select()
    '    ExcelS.Application.Cells.Select()
    '    ExcelS.Application.Selection.Cut()
    '    ExcelS.Application.Sheets("KPI").Select()
    '    ExcelS.Application.ActiveWindow.Zoom = 80
    '    ExcelS.Application.Application.Range("A1").Select()
    '    ExcelS.Application.ActiveSheet.Paste()
    '    ExcelS.Application.Application.Range("A1").Select()
    '    'ExcelS.Worksheets("KPI").Outline.SummaryRow = Excel.XlSummaryRow.xlSummaryAbove
    '    ExcelS.Application.Sheets("Temp").Select()
    '    ExcelS.Application.Application.Range("A2").Select()
    '    ExcelS.Application.Cells.Select()
    '    ExcelS.Application.Cells.Select()
    '    ExcelS.Application.Selection.Delete()
    '    ExcelS.Application.Sheets("KPI").Select()
    '    ExcelS.Application.Range("A8").Columns.AutoFit()
    '    ExcelS.Application.Range("B8").Columns.AutoFit()
    '    ExcelS.Application.Range("C9").Select()
    '    ExcelS.Application.ActiveWindow.FreezePanes = True
    '    ExcelS.Application.ActiveWindow.DisplayGridlines = False


    'End Sub

    'Sub save_excel()
    '    Dim xlPackage As New ExcelPackage()
    '    Dim savepath As String
    '    Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '    Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '    savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    '    Dim excelFile As New FileInfo(savepath & "\" & "Utilization report " & SDate & " - " & EDate & ".xlsx")
    '    ExcelSst.SaveAs(excelFile)
    '    ExcelSst.Close()
    '    ExcelS.Quit()
    '    Dim msg As MsgBoxResult = MsgBox("Utilization report saved to " & savepath)
    'End Sub


#End Region
#Region "Utilization report EPP"
    Dim BG As New BackgroundWorker
    Dim FilePath As String = Nothing
    Dim Epp As New EPPClass


    'Dim C1 As String

    Private Sub UtilizationReport_Click(sender As Object, e As EventArgs) Handles UtilizationReport.Click
      
        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            FilePath = FBD.SelectedPath
        Else
            Exit Sub
        End If

        BG.WorkerReportsProgress = True
        BG.WorkerSupportsCancellation = True

        AddHandler BG.DoWork, AddressOf UtilizationReportWorkerDoWork
        AddHandler BG.ProgressChanged, AddressOf UtilizationReportWorkerProgressChanged
        AddHandler BG.RunWorkerCompleted, AddressOf UtilizationReportWorkerCompleted
        BG.RunWorkerAsync()
    End Sub

    Private Sub UtilizationReportWorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Utilization()
    End Sub

    Private Sub UtilizationReportWorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        Dim message As String = e.UserState
        ssWorkCompleted.Text = message & vbCrLf
    End Sub

    Private Sub UtilizationReportWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim Msg As MsgBoxResult = MsgBox("Report saved to : " & FilePath)
    End Sub
    Private Sub showTest()
        BG.ReportProgress(0, "This shows on the main form.")
    End Sub

    Sub Utilization()
        'Call BrowseFilePath()
        Call EPP_Createexcel()
        Call epp_KPIActivitytoSheet()
        Call Epp_KPiMainData_RD()
        Call Epp_Detail_Data()
        Call Epp_Data_Mapping()
        Call Epp_Grouping()
        Call Epp_Pivot_1()
        Call Epp_Pivot_2()
        Call Epp_Pivot_3()
        Call Epp_FormattingKPI()
        Call Epp_save_excel()
    End Sub

    Dim ExcelPkg As New ExcelPackage()
    'Dim WorkBook As ExcelWorkbook = ExcelPkg.Workbook
    Dim Wb = ExcelPkg.Workbook
    Dim WS, ws1, ws2, ws3, ws4, ws5, ws6 As ExcelWorksheet
    Dim pivotRangeName, Detail_Data As String

   

    Sub BrowseFilePath()


        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            FilePath = FBD.SelectedPath
        Else
            Exit Sub
        End If
    End Sub

    Sub EPP_Createexcel()

        Try

            ws1 = ExcelPkg.Workbook.Worksheets.Add("KPI")
            ws2 = ExcelPkg.Workbook.Worksheets.Add("Summary")
            ws3 = ExcelPkg.Workbook.Worksheets.Add("Date_Wise_Team_Utilization")
            ws4 = ExcelPkg.Workbook.Worksheets.Add("Activity_Wise_Team_Utilization")
            ws5 = ExcelPkg.Workbook.Worksheets.Add("Sub_Activity_Wise_Utilization")
            ws6 = ExcelPkg.Workbook.Worksheets.Add("Detail_Data")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '   MsgBox(ex.Message)
            ' Dim msg As MsgBoxResult
            'msg = MsgBox(ex.Message)

        End Try





    End Sub

    Sub epp_KPIActivitytoSheet()



        Dim i, icount As Integer
        Dim tp As String
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0


        ws1.Select()

        Dim conn As New pgConnect
        Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
        conn.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "bucket,activity,sub_activity,task")
        icount = conn.DataTable.Rows.Count - 1



        icount = conn.DataTable.Rows.Count - 1
        Dim ii As Integer = 10
        ws1.View.ZoomScale = 80
        ws1.Cells("A9:K9").Style.Font.Color.SetColor(Color.White)
        Epp.CellColorRGB(ws1, "A9:K9", 31, 73, 125)

        ws1.Cells("A1:C1").Style.Font.Bold = True

        For i = 0 To icount
            tp = conn.DataTable.Rows(i).Item("Bucket")

            If ws1.Cells("D" & ii - 1).Value <> tp Then
                ws1.Cells("A" & ii).Value = tp
                'Blue Color
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue)
                ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = True
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1
            End If

            If ws1.Cells("C" & ii - 1).Value <> conn.DataTable.Rows(i).Item("activity") Or ws1.Cells("B" & ii - 1).Value = "" Or ii = 3 Then

                ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ''''''Green Color

                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.MediumAquamarine)
                ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                ws1.Cells("B" & ii).Value = tp
                ''''''ws3.Cells("B" & ii).Select()
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1


                ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ''''''Gray Color
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1

            ElseIf ws1.Cells("B" & ii - 1).Value <> conn.DataTable.Rows(i).Item("sub_activity") Then
                ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ''''''Gray Color
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1
            End If

            ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("task")
            ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
            '''''''Light Gray for Next Column
            ws1.Cells("B" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
            ws1.Cells("B" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
            ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
            ws1.Cells("D" & ii).Value = tp
            ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
            ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
            ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                "-" & conn.DataTable.Rows(i).Item("task")
            ii = ii + 1


        Next

        Epp.CellBorder(ws1, "A9:K" & ii - 1, "All", Color.Black)

        C1 = Int(ii - 2)

    End Sub

    Sub Epp_KPiMainData_RD()

        Try

            Dim i, icount, C2 As Integer

            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim conn As New pgConnect
            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity,sub_activity,task") 'AND date >=@value4 AND date <=@value5


            icount = conn.DataTable.Rows.Count - 1
            ws2.View.ZoomScale = 80
            Dim ii As Integer = 2


            'ws2.Sheets("Summary").select()
            ws2.Cells("B1").Value = "Activity"
            ws2.Cells("C1").Value = "Sub Activity"
            ws2.Cells("D1").Value = "Task"
            ws2.Cells("E1").Value = "Total Time (Hrs)"
            ws2.Cells("F1").Value = "Total Count"


            For i = 0 To icount
                ws2.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws2.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws2.Cells("D" & ii).Value = conn.DataTable.Rows(i).Item("task")
                Dim time As Double = Format((conn.DataTable.Rows(i).Item("TTime")) / 60, "0.00")
                ws2.Cells("E" & ii).Value = time
                ws2.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("TotCount")
                ws2.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("activity") & "-" & conn.DataTable.Rows(i).Item("sub_activity") & "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1
            Next


            C2 = ws1.Dimension.End.Row


            For i = 10 To C2
                ws1.Cells("C" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:E,5,0)),0)"
                ws1.Cells("D" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:F,6,0)),0)"
                ws1.Cells("E" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"
                ws1.Cells("F" & i).Value = Nothing

            Next

            ws1.Cells.Calculate()


        Catch ex As IO.IOException

            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            'MsgBox("Error in KPI main data copy" & vbNewLine & vbNewLine & ex.ToString)

            'Dim msg As MsgBoxResult
            '    msg = MsgBox("Error in KPI main data copy" & vbNewLine & vbNewLine & ex.ToString)

        End Try



    End Sub

    Sub Epp_Detail_Data()


        Try
            Dim enc As New Encryption
            Dim i, icount As Integer
            Dim conn As New pgConnect
            Dim ii As Integer = 2

            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")


            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn.GetRecordsGRID("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value)
            icount = conn.DataTable.Rows.Count - 1


            ws6.Cells("A1").Value = "Date"
            ws6.Cells("B1").Value = "Name"
            ws6.Cells("C1").Value = "Empl.ID"
            ws6.Cells("D1").Value = "Activity"
            ws6.Cells("E1").Value = "Sub Activity"
            ws6.Cells("F1").Value = "Task"
            ws6.Cells("G1").Value = "Total Time (Min)"
            ws6.Cells("H1").Value = "Volume"
            ws6.Cells("I1").Value = "Act.ID"
            ws6.Cells("J1").Value = "Comment"
            ws6.Cells("K1").Value = "Created By"


            For i = 0 To icount
                ws6.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("date")
                ws6.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("name")
                Dim empid As Integer = enc.decrypt(conn.DataTable.Rows(i).Item("empl_id"))
                ws6.Cells("C" & ii).Value = empid
                ws6.Cells("D" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws6.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws6.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws6.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("total_time")
                ws6.Cells("H" & ii).Value = conn.DataTable.Rows(i).Item("volume")
                ws6.Cells("I" & ii).Value = conn.DataTable.Rows(i).Item("act_id")
                ws6.Cells("J" & ii).Value = conn.DataTable.Rows(i).Item("comment")
                ws6.Cells("K" & ii).Value = conn.DataTable.Rows(i).Item("added_by")
                ii = ii + 1
            Next

            ws6.Cells.AutoFitColumns()
            ws6.View.ZoomScale = 80

        Catch ex As IO.IOException

            '   MsgBox("Error in detail data copy" & vbNewLine & vbNewLine & ex.ToString)

            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try




    End Sub

    Sub Epp_Data_Mapping()

        Dim C1 As Integer = ws1.Dimension.End.Row
        Dim C2 As Integer = ws2.Dimension.End.Row
        Dim r As Integer
        r = 5


        For i = 10 To C1

            ws1.Cells("C" & i).Value = ws1.Cells("C" & i).Value
            ws1.Cells("D" & i).Value = ws1.Cells("D" & i).Value

            ws1.Cells("F" & i).FormulaR1C1 = "=IFERROR(RC[-3]/R[-" & r & "]C,0)"
            r = r + 1

            ws1.Cells("E" & i).Style.Numberformat.Format = "0.0"
            ws1.Cells("F" & i).Style.Numberformat.Format = "0.0%"

        Next


        'MsgBox("Blue : " & ws1.Cells("C10").Style.Fill.BackgroundColor.Rgb)
        'MsgBox("Green : " & ws1.Cells("C11").Style.Fill.BackgroundColor.Rgb)
        'MsgBox("Grey : " & ws1.Cells("C12").Style.Fill.BackgroundColor.Rgb)
        'MsgBox("White : " & ws1.Cells("C13").Style.Fill.BackgroundColor.Rgb)

        Dim iGRid As Integer
        Dim iTime As Double = Nothing
        Dim iVol As Integer = Nothing
        Dim FirstGreay As Boolean = True


        'Sum to grey
        For i = 10 To C1
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                iGRid = i
                iTime = Nothing
                iVol = Nothing

            End If
            'white
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = Nothing Then

                iTime += ws1.Cells("C" & i).Value
                iVol += ws1.Cells("D" & i).Value
                ws1.Cells("C" & iGRid).Value = iTime
                ws1.Cells("D" & iGRid).Value = iVol


            End If
        Next



        'Sum to green
        For i = 10 To C1
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                iGRid = i
                iTime = Nothing
                iVol = Nothing
            End If
            'grey
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                iTime += ws1.Cells("C" & i).Value
                iVol += ws1.Cells("D" & i).Value
                ws1.Cells("C" & iGRid).Value = iTime
                ws1.Cells("D" & iGRid).Value = iVol
            End If
        Next

        'Sum to blue
        For i = 10 To C1
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF6495ED" Then
                iGRid = i
                iTime = Nothing
                iVol = Nothing
            End If
            'green
            If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                iTime += ws1.Cells("C" & i).Value
                iVol += ws1.Cells("D" & i).Value
                ws1.Cells("C" & iGRid).Value = iTime
                ws1.Cells("D" & iGRid).Value = iVol
            End If
        Next


        For i = 10 To C1
            If ws1.Cells("A" & i).Value = "DIRECT" Then
                Dim nval1 As Integer = ws1.Cells("F5").Value
                Dim nval2 As Integer = ws1.Cells("C" & i).Value

                ws1.Cells("F6").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-1]C"
                ws1.Cells("F6").Style.Numberformat.Format = "0.0%"

            ElseIf ws1.Cells("A" & i).Value = "INDIRECT" Then

                ws1.Cells("F7").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-2]C"
                ws1.Cells("F7").Style.Numberformat.Format = "0.0%"

            ElseIf ws1.Cells("A" & i).Value = "VALIDATION" Then

                ws1.Cells("F8").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-3]C"
                ws1.Cells("F8").Style.Numberformat.Format = "0.0%"

            End If
        Next

        ws1.DeleteColumn(7)
        ws1.DeleteColumn(7)
        ws1.DeleteColumn(7)
        ws1.DeleteColumn(7)
        ws1.DeleteColumn(7)

    End Sub

    Sub Epp_Grouping()

        'Dim C1 As Integer = ws1.Dimension.End.Row
        'Dim GStrt As Integer = Nothing
        'Dim GEnd As Integer = Nothing
        'Dim Fgreen As Integer = Nothing

        'For i = 10 To C1

        '    If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF6495ED" Then 'blue

        '    End If

        '    'green
        '    If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then 'green
        '        Fgreen += 1
        '        If GStrt = Nothing Then GStrt = i + 1
        '        If GStrt <> Nothing Then GEnd = i - 1


        '    End If

        '    If Fgreen = 2 Then
        '        MsgBox("R-Start : " & GStrt & vbNewLine &
        '       "R-End : " & GEnd)
        '        GStrt = i + 1
        '        Fgreen = 1
        '    End If

        'Next



        ''If GEnd <> Nothing Then
        ''    For j = GStrt To GEnd
        ''        ws1.Row(j).OutlineLevel = 1
        ''        ws1.Row(j).Collapsed = True
        ''    Next
        ''    GStrt = Nothing
        ''    GEnd = Nothing
        ''End If

        'For i = 20 To 50
        '    ws1.Row(i).OutlineLevel = 1
        '    ws1.Row(i).Collapsed = True
        'Next

    End Sub

    Sub Epp_Pivot_1()



        Try
            Dim dataRange1 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable1 = ws3.PivotTables.Add(ws3.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Name"))
            pivotTable1.DataOnRows = True

            ''The data fields
            Dim field1 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field1.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws3.View.ZoomScale = 80


        Catch ex As IO.IOException


            '  MsgBox("Pivot creation error : " & ex.Message)

            '     Dim msg As MsgBoxResult
            '    msg = MsgBox("Pivot creation error : " & ex.Message)

        End Try
    End Sub

    Sub Epp_Pivot_2()

        Try

            Dim dataRange1 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable1 = ws4.PivotTables.Add(ws4.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Activity"))
            pivotTable1.DataOnRows = True

            ''The data fields
            Dim field2 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field2.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws4.View.ZoomScale = 80

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Sub Epp_Pivot_3()

        Try

            Dim dataRange1 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable1 = ws5.PivotTables.Add(ws5.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Name"))
            pivotTable1.DataOnRows = False

            ''The label row field
            pivotTable1.ColumnFields.Add(pivotTable1.Fields("Sub Activity"))
            pivotTable1.DataOnRows = False

            ''The data fields
            Dim field2 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field2.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws5.View.ZoomScale = 80

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Sub Epp_FormattingKPI()

        '        ExcelS.Application.Range("H:I").Select()
        '        ExcelS.Application.Selection.Copy()
        '        ExcelS.Application.Range("H:I").PasteSpecial(Paste:=-4163) ' xlValu
        '        ExcelS.Application.Columns("C:G").Select()
        '        ExcelS.Application.Selection.Delete()





        ws1.Cells("A1:F1").Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        ws1.Cells("A1:F1").Merge = True

        ws1.Cells("A9").Value = "Activity"
        ws1.Cells("B9").Value = "Sub Activity"
        ws1.Cells("C9").Value = "Total Hours"
        ws1.Cells("D9").Value = "Total Count"
        ws1.Cells("E9").Value = "UPT"
        ws1.Cells("F9").Value = "Utilisation (%)"


        Epp.CellColor(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", Color.Gainsboro)
        Epp.CellColor(ws1, "A1:C1", Color.Gainsboro)
        Epp.CellColor(ws1, "A1", Color.Black)
        ws1.Cells("A1").Style.Font.Color.SetColor(Color.White)

        ws1.Cells("A1").Style.Font.Size = 16

        ws1.Cells("A2").Value = "No. Of Working Days"
        ws1.Cells("A3").Value = "No. Of Holidays"
        ws1.Cells("A4").Value = "No. of FTE"
        ws1.Cells("A5").Value = "Total Available Hours"
        ws1.Cells("A6").Value = "Total Hours spent on Direct Activity (%)"
        ws1.Cells("A7").Value = "Total Hours spent on InDirect Activity (%)"
        ws1.Cells("A8").Value = "Total Hours spent on Validation Activity (%)"
        ws1.Cells("B6").Value = "[DIRECT/TOTAL AVAILABLE]"
        ws1.Cells("B7").Value = "[INDIRECT/TOTAL AVAILABLE]"
        ws1.Cells("B8").Value = "[VALIDATION/TOTAL AVAILABLE]"

        Dim TotalDays As Integer = TotalWorkDays
        Dim Strength As Integer = TotalUser

        ws1.Cells("F2").Value = TotalDays
        ws1.Cells("F3").Value = 0
        ws1.Cells("F4").Value = Strength
        ws1.Cells("F5").FormulaR1C1 = "=R[-1]C*(R[-3]C-R[-2]C)*8"
        ws1.View.ShowGridLines = False
        ws1.Cells("A8").AutoFitColumns()
        ws1.Cells("B8").AutoFitColumns()
        ws1.Cells.Style.WrapText = True = False
        ws1.Cells("A1").Value = sprc.Text & " :: " & prc.Text & " ::Resource Utilization " & Format(DateStart.Value, "dd-MMM-yy") & " - " & Format(DateEnd.Value, "dd-MMM-yy")

        Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Bottom", Color.Black)
        Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Top", Color.Black)
        Epp.CellBorder(ws1, "F2:F8", "Right", Color.Black)

        ws1.Column(3).Width = 15
        ws1.Column(4).Width = 15
        ws1.Column(5).Width = 15
        ws1.Column(6).Width = 15

        'ws1.Cells("A2:F2,A4:F4,A6:F6,A8:F8").Style.Border.Left.Style = ExcelBorderStyle.Thin
        'ws1.Cells("A2:F2,A4:F4,A6:F6,A8:F8").Style.Border.Left.Color.SetColor(Color.Black)



        'ws1.Cells("A2:F2,A4:F4,A6:F6,A8:F8").Style.Border.Right.Style = ExcelBorderStyle.Thin
        'ws1.Cells("A2:F2,A4:F4,A6:F6,A8:F8").Style.Border.Right.Color.SetColor(Color.Black)


    End Sub

    Sub Epp_save_excel()
        'ws7.TabColor = Color.Blue
        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

        'Dim savepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        'Dim excelFile As New FileInfo(savepath & "\" & "Utilizaaaaaaaaaaaa" & ".xlsx")
        'ExcelPkg.SaveAs(excelFile)


        'Dim excelFile As New FileInfo(FilePath & "\" & "Utilization report " & SDate & " - " & EDate & ".xlsx")
        Dim excelFile As New FileInfo(FilePath & "\" & TM_Process & "_" & TM_SubProcess & "_Utilization report " & SDate & " - " & EDate & ".xlsx")
        'Dim excelFile As New FileInfo(FilePath & "\" & "Utilization report " & SDate & " - " & EDate & ".xlsx")
        ExcelPkg.SaveAs(excelFile)


        ws1.Dispose()
        ws2.Dispose()
        ws3.Dispose()
        ws4.Dispose()
        ws5.Dispose()
        ws6.Dispose()
        'WorkBook.Dispose()
        ExcelPkg.Dispose()


    End Sub

    Sub UtilizationReport_Epp()
        Dim conn As New pgConnect
        Dim ExcelPkg As New ExcelPackage()
        Dim Wb = ExcelPkg.Workbook
        Dim ws1, ws2, ws3, ws4, ws5, ws6 As ExcelWorksheet
        'Dim pivotRangeName, Detail_Data As String

        Try


            'Create Excel Sheet
            ws1 = ExcelPkg.Workbook.Worksheets.Add("KPI")
            ws2 = ExcelPkg.Workbook.Worksheets.Add("Summary")
            ws3 = ExcelPkg.Workbook.Worksheets.Add("Date_Wise_Team_Utilization")
            ws4 = ExcelPkg.Workbook.Worksheets.Add("Activity_Wise_Team_Utilization")
            ws5 = ExcelPkg.Workbook.Worksheets.Add("Sub_Activity_Wise_Utilization")
            ws6 = ExcelPkg.Workbook.Worksheets.Add("Detail_Data")


            '=========================KPI Activity to Sheet==========================
            Dim i, icount As Integer
            Dim tp As String
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            ws1.Select()
            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            conn.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "bucket,activity,sub_activity,task")
            icount = conn.DataTable.Rows.Count - 1

            icount = conn.DataTable.Rows.Count - 1
            Dim ii As Integer = 10
            ws1.View.ZoomScale = 80
            ws1.Cells("A9:K9").Style.Font.Color.SetColor(Color.White)
            Epp.CellColorRGB(ws1, "A9:K9", 31, 73, 125)

            ws1.Cells("A1:C1").Style.Font.Bold = True

            For i = 0 To icount
                tp = conn.DataTable.Rows(i).Item("Bucket")

                If ws1.Cells("D" & ii - 1).Value <> tp Then
                    ws1.Cells("A" & ii).Value = tp
                    'Blue Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = True
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1
                End If

                If ws1.Cells("C" & ii - 1).Value <> conn.DataTable.Rows(i).Item("activity") Or ws1.Cells("B" & ii - 1).Value = "" Or ii = 3 Then

                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ''''''Green Color

                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.MediumAquamarine)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = tp
                    ''''''ws3.Cells("B" & ii).Select()
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1


                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ''''''Gray Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1

                ElseIf ws1.Cells("B" & ii - 1).Value <> conn.DataTable.Rows(i).Item("sub_activity") Then
                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ''''''Gray Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1
                End If

                ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                '''''''Light Gray for Next Column
                ws1.Cells("B" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("B" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1


            Next

            Epp.CellBorder(ws1, "A9:K" & ii - 1, "All", Color.Black)

            C1 = Int(ii - 2)


            '===================================Main Data to sheet===========================================
            Dim C2 As Integer

            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            conn.Connect()
            Dim value1 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value1, "activity,sub_activity,task") 'AND date >=@value4 AND date <=@value5

            icount = conn.DataTable.Rows.Count - 1
            ws2.View.ZoomScale = 80
            ii = 2


            'ws2.Sheets("Summary").select()
            ws2.Cells("B1").Value = "Activity"
            ws2.Cells("C1").Value = "Sub Activity"
            ws2.Cells("D1").Value = "Task"
            ws2.Cells("E1").Value = "Total Time (Hrs)"
            ws2.Cells("F1").Value = "Total Count"


            For i = 0 To icount
                ws2.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws2.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws2.Cells("D" & ii).Value = conn.DataTable.Rows(i).Item("task")
                Dim time As Double = Format((conn.DataTable.Rows(i).Item("TTime")) / 60, "0.00")
                ws2.Cells("E" & ii).Value = time
                ws2.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("TotCount")
                ws2.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("activity") & "-" & conn.DataTable.Rows(i).Item("sub_activity") & "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1
            Next


            C2 = ws1.Dimension.End.Row


            For i = 10 To C2
                ws1.Cells("C" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:E,5,0)),0)"
                ws1.Cells("D" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:F,6,0)),0)"
                ws1.Cells("E" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"
                ws1.Cells("F" & i).Value = Nothing

            Next

            ws1.Cells.Calculate()


            '====================================Detail Data to sheet===================================================
            Dim enc As New Encryption
            ii = 2



            conn.Connect()
            Dim value2 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn.GetRecordsGRID("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value2)
            icount = conn.DataTable.Rows.Count - 1


            ws6.Cells("A1").Value = "Date"
            ws6.Cells("B1").Value = "Name"
            ws6.Cells("C1").Value = "Empl.ID"
            ws6.Cells("D1").Value = "Activity"
            ws6.Cells("E1").Value = "Sub Activity"
            ws6.Cells("F1").Value = "Task"
            ws6.Cells("G1").Value = "Total Time (Min)"
            ws6.Cells("H1").Value = "Volume"
            ws6.Cells("I1").Value = "Act.ID"
            ws6.Cells("J1").Value = "Comment"
            ws6.Cells("K1").Value = "Created By"


            For i = 0 To icount
                ws6.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("date")
                ws6.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("name")
                Dim empid As Integer = enc.decrypt(conn.DataTable.Rows(i).Item("empl_id"))
                ws6.Cells("C" & ii).Value = empid
                ws6.Cells("D" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws6.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws6.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws6.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("total_time")
                ws6.Cells("H" & ii).Value = conn.DataTable.Rows(i).Item("volume")
                ws6.Cells("I" & ii).Value = conn.DataTable.Rows(i).Item("act_id").ToString
                ws6.Cells("J" & ii).Value = conn.DataTable.Rows(i).Item("comment")
                ws6.Cells("K" & ii).Value = conn.DataTable.Rows(i).Item("added_by")
                ii = ii + 1
            Next

            ws6.Cells.AutoFitColumns()
            ws6.View.ZoomScale = 80


            '============================================Data Mapping======================================================
            C1 = ws1.Dimension.End.Row
            C2 = ws2.Dimension.End.Row
            Dim r As Integer
            r = 5


            For i = 10 To C1

                ws1.Cells("C" & i).Value = ws1.Cells("C" & i).Value
                ws1.Cells("D" & i).Value = ws1.Cells("D" & i).Value

                ws1.Cells("F" & i).FormulaR1C1 = "=IFERROR(RC[-3]/R[-" & r & "]C,0)"
                r = r + 1

                ws1.Cells("E" & i).Style.Numberformat.Format = "0.0"
                ws1.Cells("F" & i).Style.Numberformat.Format = "0.0%"

            Next


            'MsgBox("Blue : " & ws1.Cells("C10").Style.Fill.BackgroundColor.Rgb)
            'MsgBox("Green : " & ws1.Cells("C11").Style.Fill.BackgroundColor.Rgb)
            'MsgBox("Grey : " & ws1.Cells("C12").Style.Fill.BackgroundColor.Rgb)
            'MsgBox("White : " & ws1.Cells("C13").Style.Fill.BackgroundColor.Rgb)

            Dim iGRid As Integer
            Dim iTime As Double = Nothing
            Dim iVol As Integer = Nothing
            Dim FirstGreay As Boolean = True


            'Sum to grey
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing

                End If
                'white
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = Nothing Then

                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol


                End If
            Next



            'Sum to green
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing
                End If
                'grey
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol
                End If
            Next

            'Sum to blue
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF6495ED" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing
                End If
                'green
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol
                End If
            Next


            For i = 10 To C1
                If ws1.Cells("A" & i).Value = "DIRECT" Then
                    Dim nval1 As Integer = ws1.Cells("F5").Value
                    Dim nval2 As Integer = ws1.Cells("C" & i).Value

                    ws1.Cells("F6").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-1]C"
                    ws1.Cells("F6").Style.Numberformat.Format = "0.0%"

                ElseIf ws1.Cells("A" & i).Value = "INDIRECT" Then

                    ws1.Cells("F7").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-2]C"
                    ws1.Cells("F7").Style.Numberformat.Format = "0.0%"

                ElseIf ws1.Cells("A" & i).Value = "VALIDATION" Then

                    ws1.Cells("F8").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-3]C"
                    ws1.Cells("F8").Style.Numberformat.Format = "0.0%"

                End If
            Next

            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)

            'Data Grouping
            'Code will go here


            'Pivot-1
            Dim dataRange1 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable1 = ws3.PivotTables.Add(ws3.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Name"))
            pivotTable1.DataOnRows = True

            ''The data fields
            Dim field1 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field1.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws3.View.ZoomScale = 80



            'Pivot-2
            dataRange1 = ws6.Cells(ws6.Dimension.Address)
            pivotTable1 = ws4.PivotTables.Add(ws4.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Activity"))
            pivotTable1.DataOnRows = True

            ''The data fields
            Dim field2 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field2.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws4.View.ZoomScale = 80


            'Pivot-3
            dataRange1 = ws6.Cells(ws6.Dimension.Address)
            pivotTable1 = ws5.PivotTables.Add(ws5.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Name"))
            pivotTable1.DataOnRows = False

            ''The label row field
            pivotTable1.ColumnFields.Add(pivotTable1.Fields("Sub Activity"))
            pivotTable1.DataOnRows = False

            ''The data fields
            field2 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field2.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws5.View.ZoomScale = 80


            'Formating KPI
            ws1.Cells("A1:F1").Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            ws1.Cells("A1:F1").Merge = True

            ws1.Cells("A9").Value = "Activity"
            ws1.Cells("B9").Value = "Sub Activity"
            ws1.Cells("C9").Value = "Total Hours"
            ws1.Cells("D9").Value = "Total Count"
            ws1.Cells("E9").Value = "UPT"
            ws1.Cells("F9").Value = "Utilisation (%)"


            Epp.CellColor(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", Color.Gainsboro)
            Epp.CellColor(ws1, "A1:C1", Color.Gainsboro)
            Epp.CellColor(ws1, "A1", Color.Black)
            ws1.Cells("A1").Style.Font.Color.SetColor(Color.White)

            ws1.Cells("A1").Style.Font.Size = 16

            ws1.Cells("A2").Value = "No. Of Working Days"
            ws1.Cells("A3").Value = "No. Of Holidays"
            ws1.Cells("A4").Value = "No. of FTE"
            ws1.Cells("A5").Value = "Total Available Hours"
            ws1.Cells("A6").Value = "Total Hours spent on Direct Activity (%)"
            ws1.Cells("A7").Value = "Total Hours spent on InDirect Activity (%)"
            ws1.Cells("A8").Value = "Total Hours spent on Validation Activity (%)"
            ws1.Cells("B6").Value = "[DIRECT/TOTAL AVAILABLE]"
            ws1.Cells("B7").Value = "[INDIRECT/TOTAL AVAILABLE]"
            ws1.Cells("B8").Value = "[VALIDATION/TOTAL AVAILABLE]"

            Dim TotalDays As Integer = TotalWorkDays
            Dim Strength As Integer = TotalUser

            ws1.Cells("F2").Value = TotalDays
            ws1.Cells("F3").Value = 0
            ws1.Cells("F4").Value = Strength
            ws1.Cells("F5").FormulaR1C1 = "=R[-1]C*(R[-3]C-R[-2]C)*8"
            ws1.View.ShowGridLines = False
            ws1.Cells("A8").AutoFitColumns()
            ws1.Cells("B8").AutoFitColumns()
            ws1.Cells.Style.WrapText = True = False
            ws1.Cells("A1").Value = sprc.Text & " :: " & prc.Text & " ::Resource Utilization " & Format(DateStart.Value, "dd-MMM-yy") & " - " & Format(DateEnd.Value, "dd-MMM-yy")

            Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Bottom", Color.Black)
            Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Top", Color.Black)
            Epp.CellBorder(ws1, "F2:F8", "Right", Color.Black)

            ws1.Column(3).Width = 15
            ws1.Column(4).Width = 15
            ws1.Column(5).Width = 15
            ws1.Column(6).Width = 15


            'Saving Excel

            'Dim excelFile As New FileInfo(FilePath & "\" & "Utilization report " & SDate & " - " & EDate & ".xlsx")
            Dim excelFile As New FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & "Utilization report " & SDate & " - " & EDate & ".xlsx")
            ExcelPkg.SaveAs(excelFile)

            Dim Msg As MsgBoxResult = MsgBox("Report saved to : " & Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            ws1.Dispose()
            ws2.Dispose()
            ws3.Dispose()
            ws4.Dispose()
            ws5.Dispose()
            ws6.Dispose()
            'WorkBook.Dispose()
            ExcelPkg.Dispose()
        Catch ex As IO.IOException
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

#End Region

    Private Sub UtilizationReportNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilizationReportNewToolStripMenuItem.Click
        UtilizationReport_New()
    End Sub
    Private Sub UtilizationReport_New()
        Dim ExcelPkg As New ExcelPackage()
        Dim enc As New Encryption
        Dim SavePath As String = Nothing
        Dim Wb = ExcelPkg.Workbook
        Dim ws1, ws2, ws3, ws4, ws5, ws6 As ExcelWorksheet


        Dim C1 As Integer = Nothing
        Dim C2 As Integer = Nothing
        Dim C3 As Integer = Nothing

        Try

            '===============================Folder Browse======================================
            'Dim FBD As New FolderBrowserDialog
            'If (FBD.ShowDialog() = DialogResult.OK) Then
            '    SavePath = FBD.SelectedPath




            '===============================Create Excel File==================================
            ws1 = ExcelPkg.Workbook.Worksheets.Add("KPI")
            ws2 = ExcelPkg.Workbook.Worksheets.Add("Summary")
            ws3 = ExcelPkg.Workbook.Worksheets.Add("Date_Wise_Team_Utilization")
            ws4 = ExcelPkg.Workbook.Worksheets.Add("Activity_Wise_Team_Utilization")
            ws5 = ExcelPkg.Workbook.Worksheets.Add("Sub_Activity_Wise_Utilization")
            ws6 = ExcelPkg.Workbook.Worksheets.Add("Detail_Data")


            '===============================Kpi Activity to sheet=============================
            Dim i, icount As Integer
            Dim tp As String
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            ws1.Select()
            Dim conn As New pgConnect
            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            conn.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "bucket,activity,sub_activity,task")
            icount = conn.DataTable.Rows.Count - 1

            Dim ii As Integer = 10
            ws1.View.ZoomScale = 80
            ws1.Cells("A9:K9").Style.Font.Color.SetColor(Color.White)
            Epp.CellColorRGB(ws1, "A9:K9", 31, 73, 125)

            ws1.Cells("A1:C1").Style.Font.Bold = True

            For i = 0 To icount
                tp = conn.DataTable.Rows(i).Item("Bucket")

                If ws1.Cells("D" & ii - 1).Value <> tp Then
                    ws1.Cells("A" & ii).Value = tp
                    'Blue Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = True
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1
                End If

                If ws1.Cells("C" & ii - 1).Value <> conn.DataTable.Rows(i).Item("activity") Or ws1.Cells("B" & ii - 1).Value = "" Or ii = 3 Then

                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ''''''Green Color

                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.MediumAquamarine)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = tp
                    ''''''ws3.Cells("B" & ii).Select()
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1


                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ''''''Gray Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1

                ElseIf ws1.Cells("B" & ii - 1).Value <> conn.DataTable.Rows(i).Item("sub_activity") Then
                    ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ''''''Gray Color
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws1.Cells("A" & ii & ":K" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                    ws1.Cells("A" & ii & ":K" & ii).Style.Font.Bold = False
                    ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                    ws1.Cells("D" & ii).Value = tp
                    ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                    ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                    ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                        "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                        "-" & conn.DataTable.Rows(i).Item("task")
                    ii = ii + 1
                End If

                ws1.Cells("A" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("B" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                '''''''Light Gray for Next Column
                ws1.Cells("B" & ii).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells("B" & ii).Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                ws1.Cells("C" & ii).Value = conn.DataTable.Rows(i).Item("activity")
                ws1.Cells("D" & ii).Value = tp
                ws1.Cells("E" & ii).Value = conn.DataTable.Rows(i).Item("sub_activity")
                ws1.Cells("F" & ii).Value = conn.DataTable.Rows(i).Item("task")
                ws1.Cells("G" & ii).Value = conn.DataTable.Rows(i).Item("activity") &
                    "-" & conn.DataTable.Rows(i).Item("sub_activity") &
                    "-" & conn.DataTable.Rows(i).Item("task")
                ii = ii + 1


            Next

            Epp.CellBorder(ws1, "A9:K" & ii - 1, "All", Color.Black)
            C1 = Int(ii - 2)


            '=================KPI Main Data===========================


            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim conn2 As New pgConnect
            Dim value2 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn2.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value2, "activity,sub_activity,task") 'AND date >=@value4 AND date <=@value5
            icount = conn2.DataTable.Rows.Count - 1
            ws2.View.ZoomScale = 80
            ii = 2

            'ws2.Sheets("Summary").select()
            ws2.Cells("B1").Value = "Activity"
            ws2.Cells("C1").Value = "Sub Activity"
            ws2.Cells("D1").Value = "Task"
            ws2.Cells("E1").Value = "Total Time (Hrs)"
            ws2.Cells("F1").Value = "Total Count"

            For i = 0 To icount
                ws2.Cells("B" & ii).Value = conn2.DataTable.Rows(i).Item("activity")
                ws2.Cells("C" & ii).Value = conn2.DataTable.Rows(i).Item("sub_activity")
                ws2.Cells("D" & ii).Value = conn2.DataTable.Rows(i).Item("task")
                Dim time As Double = Format((conn2.DataTable.Rows(i).Item("TTime")) / 60, "0.00")
                ws2.Cells("E" & ii).Value = time
                ws2.Cells("F" & ii).Value = conn2.DataTable.Rows(i).Item("TotCount")
                ws2.Cells("A" & ii).Value = conn2.DataTable.Rows(i).Item("activity") & "-" & conn2.DataTable.Rows(i).Item("sub_activity") & "-" & conn2.DataTable.Rows(i).Item("task")
                ii = ii + 1
            Next

            C2 = ws1.Dimension.End.Row
            C3 = ws2.Dimension.End.Row

            For i = 10 To C2

                ws1.Cells("C" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:E,5,0)),0)"
                ws1.Cells("D" & i).FormulaR1C1 = "=IFERROR((VLOOKUP(G" & i & ",Summary!A:F,6,0)),0)"

                ws1.Cells("E" & i).FormulaR1C1 = "=IFERROR(((RC[-2]*60/RC[-1])),0)"
                ws1.Cells("F" & i).Value = Nothing

            Next

            For i = 10 To C2
                Dim ival1 = ws1.Cells("G" & i).Value
                For j = 2 To C3
                    Dim ival2 = ws2.Cells("A" & j).Value
                    Dim ival3 = ws2.Cells("E" & j).Value
                    Dim ival4 = ws2.Cells("F" & j).Value

                    If ival1 = ival2 Then
                        ws1.Cells("C" & i).Value = ival3
                        ws1.Cells("D" & i).Value = ival4
                    End If
                Next
            Next
            ws1.Cells.Calculate()


            '======================================Detail Data========================================
            Dim conn3 As New pgConnect
            Dim value3 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            conn3.GetRecordsGRID("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value3)
            icount = conn3.DataTable.Rows.Count - 1


            ws6.Cells("A1").Value = "Date"
            ws6.Cells("B1").Value = "Name"
            ws6.Cells("C1").Value = "Empl.ID"
            ws6.Cells("D1").Value = "Activity"
            ws6.Cells("E1").Value = "Sub Activity"
            ws6.Cells("F1").Value = "Task"
            ws6.Cells("G1").Value = "Total Time (Min)"
            ws6.Cells("H1").Value = "Volume"
            ws6.Cells("I1").Value = "Act.ID"
            ws6.Cells("J1").Value = "Comment"

            ii = 2
            For i = 0 To icount
                ws6.Cells("A" & ii).Value = conn3.DataTable.Rows(i).Item("date")
                ws6.Cells("B" & ii).Value = conn3.DataTable.Rows(i).Item("name")
                Dim empid As Integer = enc.decrypt(conn3.DataTable.Rows(i).Item("empl_id"))
                ws6.Cells("C" & ii).Value = empid
                ws6.Cells("D" & ii).Value = conn3.DataTable.Rows(i).Item("activity")
                ws6.Cells("E" & ii).Value = conn3.DataTable.Rows(i).Item("sub_activity")
                ws6.Cells("F" & ii).Value = conn3.DataTable.Rows(i).Item("task")
                ws6.Cells("G" & ii).Value = conn3.DataTable.Rows(i).Item("total_time")
                ws6.Cells("H" & ii).Value = conn3.DataTable.Rows(i).Item("volume")
                ws6.Cells("I" & ii).Value = conn3.DataTable.Rows(i).Item("act_id")
                ws6.Cells("J" & ii).Value = conn3.DataTable.Rows(i).Item("comment")
                ii = ii + 1
            Next

            ws6.Cells.AutoFitColumns()
            ws6.View.ZoomScale = 80


            ''====================================Data Mapping=======================================
            C1 = ws1.Dimension.End.Row
            C2 = ws2.Dimension.End.Row
            Dim r As Integer = Nothing
            r = 5
            ws1.Calculate()

            For i = 10 To C1

                ws1.Cells("C" & i).Value = ws1.Cells("C" & i).Value
                ws1.Cells("D" & i).Value = ws1.Cells("D" & i).Value

                ws1.Cells("F" & i).FormulaR1C1 = "=IFERROR(RC[-3]/R[-" & r & "]C,0)"
                r = r + 1

                ws1.Cells("E" & i).Style.Numberformat.Format = "0.0"
                ws1.Cells("F" & i).Style.Numberformat.Format = "0.0%"

            Next

            Dim iGRid As Integer = Nothing
            Dim iTime As Double = Nothing
            Dim iVol As Integer = Nothing
            Dim FirstGreay As Boolean = True


            'Sum to grey
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing

                End If
                'white
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = Nothing Then

                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol


                End If
            Next



            'Sum to green
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing
                End If
                'grey
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FFD3D3D3" Then
                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol
                End If
            Next

            'Sum to blue
            For i = 10 To C1
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF6495ED" Then
                    iGRid = i
                    iTime = Nothing
                    iVol = Nothing
                End If
                'green
                If ws1.Cells("C" & i).Style.Fill.BackgroundColor.Rgb = "FF66CDAA" Then
                    iTime += ws1.Cells("C" & i).Value
                    iVol += ws1.Cells("D" & i).Value
                    ws1.Cells("C" & iGRid).Value = iTime
                    ws1.Cells("D" & iGRid).Value = iVol
                End If
            Next


            For i = 10 To C1
                If ws1.Cells("A" & i).Value = "DIRECT" Then
                    Dim nval1 As Integer = ws1.Cells("F5").Value
                    Dim nval2 As Integer = ws1.Cells("C" & i).Value

                    ws1.Cells("F6").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-1]C"
                    ws1.Cells("F6").Style.Numberformat.Format = "0.0%"

                ElseIf ws1.Cells("A" & i).Value = "INDIRECT" Then

                    ws1.Cells("F7").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-2]C"
                    ws1.Cells("F7").Style.Numberformat.Format = "0.0%"

                ElseIf ws1.Cells("A" & i).Value = "VALIDATION" Then

                    ws1.Cells("F8").FormulaR1C1 = "=R[" & i - 6 & "]C[-3]/R[-3]C"
                    ws1.Cells("F8").Style.Numberformat.Format = "0.0%"

                End If
            Next




            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)
            ws1.DeleteColumn(7)


            '===============================Pivot=========================================
            Dim dataRange1 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable1 = ws3.PivotTables.Add(ws3.Cells("A1"), dataRange1, "ProdUsagePivot")

            ''The label row field
            pivotTable1.RowFields.Add(pivotTable1.Fields("Name"))
            pivotTable1.DataOnRows = True

            ''The data fields
            Dim field1 = pivotTable1.DataFields.Add(pivotTable1.Fields("Total Time (Min)"))
            field1.Name = "Total Time (Min)"

            dataRange1.AutoFitColumns()
            ws3.View.ZoomScale = 80


            Dim dataRange2 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable2 = ws4.PivotTables.Add(ws4.Cells("A1"), dataRange2, "ProdUsagePivot")

            ''The label row field
            pivotTable2.RowFields.Add(pivotTable2.Fields("Activity"))
            pivotTable2.DataOnRows = True

            ''The data fields
            Dim field2 = pivotTable2.DataFields.Add(pivotTable2.Fields("Total Time (Min)"))
            field2.Name = "Total Time (Min)"

            dataRange2.AutoFitColumns()
            ws4.View.ZoomScale = 80


            Dim dataRange3 = ws6.Cells(ws6.Dimension.Address)
            Dim pivotTable3 = ws5.PivotTables.Add(ws5.Cells("A1"), dataRange3, "ProdUsagePivot")

            ''The label row field
            pivotTable3.RowFields.Add(pivotTable3.Fields("Name"))
            pivotTable3.DataOnRows = False

            ''The label row field
            pivotTable3.ColumnFields.Add(pivotTable3.Fields("Sub Activity"))
            pivotTable3.DataOnRows = False

            ''The data fields
            Dim field3 = pivotTable3.DataFields.Add(pivotTable3.Fields("Total Time (Min)"))
            field3.Name = "Total Time (Min)"

            dataRange3.AutoFitColumns()
            ws5.View.ZoomScale = 80


            '============================Formatting KPI==============================
            ws1.Cells("A1:F1").Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            ws1.Cells("A1:F1").Merge = True

            ws1.Cells("A9").Value = "Activity"
            ws1.Cells("B9").Value = "Sub Activity"
            ws1.Cells("C9").Value = "Total Hours"
            ws1.Cells("D9").Value = "Total Count"
            ws1.Cells("E9").Value = "UPT"
            ws1.Cells("F9").Value = "Utilisation (%)"


            Epp.CellColor(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", Color.Gainsboro)
            Epp.CellColor(ws1, "A1:C1", Color.Gainsboro)
            Epp.CellColor(ws1, "A1", Color.Black)
            ws1.Cells("A1").Style.Font.Color.SetColor(Color.White)

            ws1.Cells("A1").Style.Font.Size = 16

            ws1.Cells("A2").Value = "No. Of Working Days"
            ws1.Cells("A3").Value = "No. Of Holidays"
            ws1.Cells("A4").Value = "No. of FTE"
            ws1.Cells("A5").Value = "Total Available Hours"
            ws1.Cells("A6").Value = "Total Hours spent on Direct Activity (%)"
            ws1.Cells("A7").Value = "Total Hours spent on InDirect Activity (%)"
            ws1.Cells("A8").Value = "Total Hours spent on Validation Activity (%)"
            ws1.Cells("B6").Value = "[DIRECT/TOTAL AVAILABLE]"
            ws1.Cells("B7").Value = "[INDIRECT/TOTAL AVAILABLE]"
            ws1.Cells("B8").Value = "[VALIDATION/TOTAL AVAILABLE]"

            Dim TotalDays As Integer = TotalWorkDays
            Dim Strength As Integer = TotalUser

            ws1.Cells("F2").Value = TotalDays
            ws1.Cells("F3").Value = 0
            ws1.Cells("F4").Value = Strength
            ws1.Cells("F5").FormulaR1C1 = "=R[-1]C*(R[-3]C-R[-2]C)*8"
            ws1.View.ShowGridLines = False
            ws1.Cells("A8").AutoFitColumns()
            ws1.Cells("B8").AutoFitColumns()
            ws1.Cells.Style.WrapText = True = False
            ws1.Cells("A1").Value = sprc.Text & " :: " & prc.Text & " ::Resource Utilization " & Format(DateStart.Value, "dd-MMM-yy") & " - " & Format(DateEnd.Value, "dd-MMM-yy")

            Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Bottom", Color.Black)
            Epp.CellBorder(ws1, "A2:F2,A4:F4,A6:F6,A8:F8", "Top", Color.Black)
            Epp.CellBorder(ws1, "F2:F8", "Right", Color.Black)

            ws1.Column(3).Width = 15
            ws1.Column(4).Width = 15
            ws1.Column(5).Width = 15
            ws1.Column(6).Width = 15

            '=====================Save Excel File====================================
            Dim filename As String = TM_Process & "_" & TM_SubProcess & "_Utilization report " & SDate & " - " & EDate & ".xlsx"
            Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            'Dim excelFile As New FileInfo(SavePath & "\" & TM_Process & "_" & TM_SubProcess & "_Utilization report " & SDate & " - " & EDate & ".xlsx")
            Dim excelFile As New FileInfo(desktop & "\" & filename)
            ExcelPkg.SaveAs(excelFile)


            ws1.Dispose()
            ws2.Dispose()
            ws3.Dispose()
            ws4.Dispose()
            ws5.Dispose()
            ws6.Dispose()
            ExcelPkg.Dispose()

            Dim Msg As MsgBoxResult = MsgBox("Report saved to : " & Environment.GetFolderPath(Environment.SpecialFolder.Desktop))

            'Else
            '    Exit Sub
            'End If

        Catch ex As IO.IOException
            ' Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")
            'Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            '      Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally

        End Try



    End Sub

    Private Sub AddTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTimeToolStripMenuItem.Click
        MasterTimeUpdate.Show()
        MasterTimeUpdate.cmdSubmit.Text = "Add Activity"
        MasterTimeUpdate.txtUser.Text = TreeView1.SelectedNode.Text

    End Sub

    Private Sub cmdUpdateDetails_Click(sender As Object, e As EventArgs)
        Dim conn As New pgConnect
        Dim value As String = ""
        conn.UpdateRecord("user_details", "billing =@value1,utilization =@value2", value, "empl_id=")
        Dim msg4 As MsgBoxResult = MsgBox("Record updated successfully", vbInformation, "Success")

        ' MsgBox("Record updated successfully", vbInformation, "Success")
    End Sub


#Region "Extracts"

    Private Sub BreakLog_Click(sender As Object, e As EventArgs) Handles BreakLog.Click
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate
            Dim conn As New pgConnect

            conn.GetRecordsGRID("break_time_log", "name,date,status,start_time,end_time,total_time", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4 AND date<=@value5", value)


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Break/Lock Extract")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            Dim Nbligne As Integer = conn.DataTable.Rows.Count

            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws.Cells.AutoFitColumns()


            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "Break Extract" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ChangeLog_Click(sender As Object, e As EventArgs) Handles ChangeLog.Click
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate & "^" & "System"
            Dim conn As New pgConnect

            conn.GetRecordsGRID("time_view", "name,date,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment,added_by", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4 AND date<=@value5 AND added_by <>@value6", value)


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Timeview Change Log")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            Dim Nbligne As Integer = conn.DataTable.Rows.Count

            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws.Cells.AutoFitColumns()


            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "Timeview Change Log" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub TimeView_Click(sender As Object, e As EventArgs) Handles TimeView.Click
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate

            Dim conn As New pgConnect

            conn.GetRecordsGRID("time_view", "name,date,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4 AND date<=@value5", value)


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Timeview Extract")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            Dim Nbligne As Integer = conn.DataTable.Rows.Count

            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws.Cells.AutoFitColumns()


            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "Timeview Extract" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UtilizationExtractToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilizationExtractToolStripMenuItem.Click
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & SDate & "^" & EDate


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Utilization")
            Dim ws1 As ExcelWorksheet = oBook.Worksheets.Add("Utilization Activity Wise")
            Dim ws2 As ExcelWorksheet = oBook.Worksheets.Add("Utilization Sub-Activity Wise")
            Dim ws3 As ExcelWorksheet = oBook.Worksheets.Add("Utilization Task Wise")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            'Dim Nbligne As Integer = conn.DataTable.Rows.Count

            Dim conn As New pgConnect
            conn.GetRecordsGRIDGROUP("time_view", "activity,sub_activity,task,SUM(total_time) AS Total_Time,Sum(Volume) As Total_Count", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4 AND date<=@value5", value, "activity,sub_activity,task")
            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next

            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next
            ws.Cells.AutoFitColumns()
            colIndex = 0
            rowIndex = 0

            Dim conn1 As New pgConnect
            conn1.GetRecordsGRIDGROUP("time_view", "activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity")
            For Each dc In conn1.DataTable.Columns
                colIndex = colIndex + 1
                ws1.Cells(1, colIndex).Value = dc.ColumnName
                ws1.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next

            For Each dr In conn1.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn1.DataTable.Columns
                    colIndex = colIndex + 1
                    ws1.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next
            ws1.Cells.AutoFitColumns()
            colIndex = 0
            rowIndex = 0

            Dim conn2 As New pgConnect
            conn2.GetRecordsGRIDGROUP("time_view", "sub_activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "sub_activity")
            For Each dc In conn2.DataTable.Columns
                colIndex = colIndex + 1
                ws2.Cells(1, colIndex).Value = dc.ColumnName
                ws2.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws2.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next

            For Each dr In conn2.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn2.DataTable.Columns
                    colIndex = colIndex + 1
                    ws2.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next
            ws2.Cells.AutoFitColumns()
            colIndex = 0
            rowIndex = 0

            Dim conn3 As New pgConnect
            conn3.GetRecordsGRIDGROUP("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "task")
            For Each dc In conn3.DataTable.Columns
                colIndex = colIndex + 1
                ws3.Cells(1, colIndex).Value = dc.ColumnName
                ws3.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws3.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next

            For Each dr In conn3.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn3.DataTable.Columns
                    colIndex = colIndex + 1
                    ws3.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next
            ws3.Cells.AutoFitColumns()
            colIndex = 0
            rowIndex = 0

            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If

            Dim excelFile As New FileInfo(savepath & "\" & "Utilization Report" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub



#End Region

#Region "Reports"

#End Region

#Region "Click Control"

    Private Sub TeamViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TeamViewToolStripMenuItem1.Click
        TeamView.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        TeamView.Dock = DockStyle.Fill
        TeamView.Show()
        TeamView.BringToFront()
    End Sub
    Private Sub MasterUpdateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MasterUpdateToolStripMenuItem1.Click
        'MasterUpdate.Show()
        MasterUpdate.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        MasterUpdate.Dock = DockStyle.Fill
        MasterUpdate.MenuStrip1.Visible = False
        MasterUpdate.Show()
        MasterUpdate.BringToFront()
    End Sub
    Private Sub TimeViewActivityManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeViewActivityManagerToolStripMenuItem.Click
        TimeViewActivityManager.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        TimeViewActivityManager.Dock = DockStyle.Fill
        TimeViewActivityManager.MenuStrip.Visible = False
        TimeViewActivityManager.StatusStrip.Visible = False
        TimeViewActivityManager.Show()
    End Sub 'required
    Private Sub ActivityUtilizationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivityUtilizationToolStripMenuItem.Click
        ActivityUtilazation.Show()
    End Sub 'required
    Private Sub BreakLockDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BreakLockDetailsToolStripMenuItem.Click

        BreakLockDetails.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        BreakLockDetails.Dock = DockStyle.Fill
        BreakLockDetails.MenuStrip1.Visible = False
        BreakLockDetails.Show()
        BreakLockDetails.BringToFront()
    End Sub
    Private Sub WorkFlowManagmentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WorkflowManagement.Show()
    End Sub
    Private Sub ExtendedHoursToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendedHoursToolStripMenuItem.Click
        ExtendedHoursR.Show()
    End Sub

#Region "Backup"

    Private Sub BackupNowToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Call Backup()
    End Sub

    Private Sub Backup()
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim BackupPath As String = Nothing
            Dim BConn As New pgConnect
            Dim BValue As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "BackupPath"
            Dim Breader As NpgsqlDataReader = BConn.GetRecords("project_details", "*", "project=@value1 AND process=@value2 AND sub_process=@value3 AND type=@value4", BValue)
            If Breader.HasRows Then
                While Breader.Read
                    If Breader("option") = "Null" Then
                        BackupPath = Breader("option")
                    Else
                        Exit Sub
                    End If
                End While
            Else
                Exit Sub
            End If



            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws1 As ExcelWorksheet = oBook.Worksheets.Add("user Details")
            Dim ws2 As ExcelWorksheet = oBook.Worksheets.Add("Error Log")
            Dim ws3 As ExcelWorksheet = oBook.Worksheets.Add("Break Log")
            Dim ws4 As ExcelWorksheet = oBook.Worksheets.Add("TeamView")
            Dim ws5 As ExcelWorksheet = oBook.Worksheets.Add("TimeView")
            Dim ws6 As ExcelWorksheet = oBook.Worksheets.Add("Timesheet Activity")


            'User Dateils
            ws1.Select()
            Dim value1 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            Dim conn1 As New pgConnect
            conn1.GetRecordsGRID("user_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value1)


            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0


            For Each dc In conn1.DataTable.Columns
                colIndex = colIndex + 1
                ws1.Cells(1, colIndex).Value = dc.ColumnName
                ws1.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws1.Cells.AutoFitColumns()


            For Each dr In conn1.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn1.DataTable.Columns
                    colIndex = colIndex + 1
                    ws1.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            'Time View
            ws5.Select()
            Dim value5 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            Dim conn5 As New pgConnect
            conn5.GetRecordsGRID("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value5)


            Dim dc5 As System.Data.DataColumn
            Dim colIndex5 As Integer = 0
            Dim rowIndex5 As Integer = 0


            For Each dc5 In conn5.DataTable.Columns
                colIndex5 = colIndex5 + 1
                ws5.Cells(1, colIndex5).Value = dc5.ColumnName
                ws5.Cells(1, colIndex5).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws5.Cells(1, colIndex5).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws5.Cells.AutoFitColumns()


            For Each dr In conn5.DataTable.Rows
                rowIndex5 = rowIndex5 + 1
                colIndex5 = 0
                For Each dc5 In conn5.DataTable.Columns
                    colIndex5 = colIndex5 + 1
                    ws5.Cells(rowIndex5 + 1, colIndex5).Value = dr(dc5.ColumnName)
                Next
            Next


            'Break Details
            ws3.Select()
            Dim value3 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            Dim conn3 As New pgConnect
            conn3.GetRecordsGRID("break_time_log", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value3)


            Dim dc3 As System.Data.DataColumn
            Dim colIndex3 As Integer = 0
            Dim rowIndex3 As Integer = 0


            For Each dc3 In conn3.DataTable.Columns
                colIndex3 = colIndex3 + 1
                ws3.Cells(1, colIndex3).Value = dc3.ColumnName
                ws3.Cells(1, colIndex3).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws3.Cells(1, colIndex3).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws3.Cells.AutoFitColumns()


            For Each dr In conn3.DataTable.Rows
                rowIndex3 = rowIndex3 + 1
                colIndex3 = 0
                For Each dc3 In conn3.DataTable.Columns
                    colIndex3 = colIndex3 + 1
                    ws3.Cells(rowIndex3 + 1, colIndex3).Value = dr(dc3.ColumnName)
                Next
            Next


            'TeamView
            ws4.Select()
            Dim value4 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            Dim conn4 As New pgConnect
            conn4.GetRecordsGRID("team_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value4)


            Dim dc4 As System.Data.DataColumn
            Dim colIndex4 As Integer = 0
            Dim rowIndex4 As Integer = 0


            For Each dc4 In conn4.DataTable.Columns
                colIndex4 = colIndex4 + 1
                ws4.Cells(1, colIndex4).Value = dc4.ColumnName
                ws4.Cells(1, colIndex4).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws4.Cells(1, colIndex4).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws4.Cells.AutoFitColumns()


            For Each dr In conn4.DataTable.Rows
                rowIndex4 = rowIndex4 + 1
                colIndex4 = 0
                For Each dc4 In conn4.DataTable.Columns
                    colIndex4 = colIndex4 + 1
                    ws4.Cells(rowIndex4 + 1, colIndex4).Value = dr(dc4.ColumnName)
                Next
            Next

            'Time Activity
            ws6.Select()
            Dim value6 As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess
            Dim conn6 As New pgConnect
            conn6.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value6)


            Dim dc6 As System.Data.DataColumn
            Dim colIndex6 As Integer = 0
            Dim rowIndex6 As Integer = 0


            For Each dc6 In conn6.DataTable.Columns
                colIndex6 = colIndex6 + 1
                ws6.Cells(1, colIndex6).Value = dc6.ColumnName
                ws6.Cells(1, colIndex6).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws6.Cells(1, colIndex6).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws6.Cells.AutoFitColumns()


            For Each dr In conn6.DataTable.Rows
                rowIndex6 = rowIndex6 + 1
                colIndex6 = 0
                For Each dc6 In conn6.DataTable.Columns
                    colIndex6 = colIndex6 + 1
                    ws6.Cells(rowIndex6 + 1, colIndex6).Value = dr(dc6.ColumnName)
                Next
            Next



            Dim excelFile As New FileInfo(BackupPath & "\" & "ThinkPro Backup_" & Format(Now, "dd_MM_yy_HH_mm_tt") & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & BackupPath, MsgBoxStyle.Information, "Exported")



        Catch ex As IO.IOException

            'Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")
            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, "Backup", "(" & LineNo(1) & ")" & ex.Message)

        End Try
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim msg As MsgBoxResult = MsgBox("This is under maintainence,will be back soon", vbInformation)
    End Sub

#End Region

    Private Sub ShiftComplianceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftComplianceToolStripMenuItem.Click
        ShiftCompliance.Show()
    End Sub
    Private Sub ThinkPollToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ThinkProPoll.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ViewTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTimeToolStripMenuItem.Click
        MasterUpdate.Show()
    End Sub
    Private Sub UserActivityDetailToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WinActivityViewer.Show()
    End Sub


#End Region


    Private Sub CurrentProfile_Click(sender As Object, e As EventArgs) Handles CurrentProfile.Click

        Try
            Dim msg As MsgBoxResult = MsgBox("Project-ID : " & TM_ProcessID & vbNewLine &
                    "User-ID : " & TM_UserID & vbNewLine &
                    "Project : " & TM_Project & vbNewLine &
                    "Process : " & TM_Process & vbNewLine &
                    "Sub Process : " & TM_SubProcess)
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub 'Required

    Private Sub InOutLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InOutLogToolStripMenuItem.Click
        Try
            Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & SDate & "^" & EDate

            Dim conn As New pgConnect

            conn.GetRecordsGRID("team_view", "name,date,in_time,out_time", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4 AND date<=@value5", value)


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("In-Out Log")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            Dim Nbligne As Integer = conn.DataTable.Rows.Count

            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws.Cells.AutoFitColumns()


            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "In-Out Extract" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult
            msg = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")


        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try
    End Sub


#Region "Activity Logger Type"

    Sub TimeViewType()
        Dim Conn As New pgConnect
        Dim TvType As String = Nothing
        Try
            Dim value As String = TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "ActivityLoggerType"
            Dim reader As NpgsqlDataReader = Conn.GetRecords("app_config", "option", "project=@value1 AND process=@value2 AND sub_process=@value3 AND type=@value4", value)
            While reader.Read
                TvType = reader("option").ToString
            End While

            If TvType = "Default" Then
                TVDevault.Checked = True
                TVSelfAllocation.Checked = False
                TVLeadAllocation.Checked = False
                Home.TP_ActivityLoggerType = "Default"
            ElseIf TvType = "SelfAllocation" Then
                TVSelfAllocation.Checked = True
                TVDevault.Checked = False
                TVLeadAllocation.Checked = False
                Home.TP_ActivityLoggerType = "SelfAllocation"
            ElseIf TvType = "LeadAllocation" Then
                TVLeadAllocation.Checked = True
                TVDevault.Checked = False
                TVSelfAllocation.Checked = False
                Home.TP_ActivityLoggerType = "CentralAllocation"
            End If

        Catch ex As IO.IOException
            ' Dim lg As New ErrorLogger
            '  lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try

    End Sub
    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TVDevault.Click

        Dim Conn As New pgConnect
        Try

            Dim value As String = "Default" & "^" & TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "ActivityLoggerType"
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")
            TimeViewType()

        Catch ex As IO.IOException
            '  Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try

    End Sub
    Private Sub TVSelfAllocation_Click(sender As Object, e As EventArgs) Handles TVSelfAllocation.Click
        Dim Conn As New pgConnect
        Try

            Dim value As String = "SelfAllocation" & "^" & TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "ActivityLoggerType"
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")
            TimeViewType()

        Catch ex As IO.IOException
            '   Dim lg As New ErrorLogger
            '   lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try
    End Sub
    Private Sub TVLeadAllocation_Click(sender As Object, e As EventArgs) Handles TVLeadAllocation.Click
        Dim Conn As New pgConnect
        Try



            Dim value As String = "CentralAllocation" & "^" & TM_Project & "^" & TM_Process & "^" & TM_SubProcess & "^" & "ActivityLoggerType"
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")
            TimeViewType()

        Catch ex As IO.IOException
            'Dim lg As New ErrorLogger
            '   lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try
    End Sub

#End Region
#Region "System Lock time"

    Private Sub MinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinToolStripMenuItem.Click
        SystemLockTimeSet(5, Project, Process, SubProcess, "SystemLockTime")
        SystemLockRetrive()
    End Sub

    Private Sub MinToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MinToolStripMenuItem1.Click
        SystemLockTimeSet(10, Project, Process, SubProcess, "SystemLockTime")
        SystemLockRetrive()
    End Sub

    Private Sub MinToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MinToolStripMenuItem2.Click
        SystemLockTimeSet(15, Project, Process, SubProcess, "SystemLockTime")
        SystemLockRetrive()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim mag As MsgBoxResult = MsgBox("Apllication will autolocked if system is idle", vbInformation)
    End Sub

    Private Sub MinToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles MinToolStripMenuItem3.Click
        SystemLockTimeSet(20, Project, Process, SubProcess, "SystemLockTime")
        SystemLockRetrive()
    End Sub

    Private Sub SystemLockTimeSet(Time As Integer, Project As String, Process As String, SubProcess As String, Type As String)
        Dim Conn As New pgConnect
        Try

            Dim value As String = Time & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Type
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")
        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try
    End Sub

    Private Sub SystemLockRetrive()
        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & "SystemLockTime"
            Dim reader As NpgsqlDataReader = Conn.GetRecords("app_config", "option", "Project=@value1 AND process=@value2 AND sub_process=@value3 AND type=@value4", value)
            If reader.HasRows Then
                While reader.Read

                    If reader("option") = 5 Then
                        MinToolStripMenuItem.Checked = True
                        MinToolStripMenuItem1.Checked = False
                        MinToolStripMenuItem2.Checked = False
                        MinToolStripMenuItem3.Checked = False

                    ElseIf reader("option") = 10 Then
                        MinToolStripMenuItem.Checked = False
                        MinToolStripMenuItem1.Checked = True
                        MinToolStripMenuItem2.Checked = False
                        MinToolStripMenuItem3.Checked = False
                    ElseIf reader("option") = 15 Then
                        MinToolStripMenuItem.Checked = False
                        MinToolStripMenuItem1.Checked = False
                        MinToolStripMenuItem2.Checked = True
                        MinToolStripMenuItem3.Checked = False
                    ElseIf reader("option") = 20 Then
                        MinToolStripMenuItem.Checked = False
                        MinToolStripMenuItem1.Checked = False
                        MinToolStripMenuItem2.Checked = False
                        MinToolStripMenuItem3.Checked = True
                    End If




                End While
            End If

        Catch ex As IO.IOException

        End Try
    End Sub

#End Region
#Region "System Lock Check"
    Private Sub syslockcheckactivate_Click(sender As Object, e As EventArgs) Handles syslockcheckactivate.Click
        Call SysLockCheck("True", Project, Process, SubProcess, "SystemLockCheck")
        Call SysLockCheckRetrive()
    End Sub

    Private Sub syslockcheckdeactivate_Click(sender As Object, e As EventArgs) Handles syslockcheckdeactivate.Click
        Call SysLockCheck("False", Project, Process, SubProcess, "SystemLockCheck")
        Call SysLockCheckRetrive()
    End Sub

    Private Sub SysLockCheck(Status As String, Project As String, Process As String, SubProcess As String, Type As String)
        Dim Conn As New pgConnect
        Try

            Dim value As String = Status & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Type
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")

        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try

    End Sub

    Private Sub SysLockCheckRetrive()

        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & "SystemLockCheck"
            Dim reader As NpgsqlDataReader = Conn.GetRecords("app_config", "option", "Project=@value1 AND process=@value2 AND sub_process=@value3 AND type=@value4", value)
            If reader.HasRows Then
                While reader.Read

                    If reader("option") = "True" Then
                        syslockcheckactivate.Checked = True
                        syslockcheckdeactivate.Checked = False
                        MenuLockCheck.ForeColor = Color.Green

                    ElseIf reader("option") = "False" Then
                        syslockcheckactivate.Checked = False
                        syslockcheckdeactivate.Checked = True
                        MenuLockCheck.ForeColor = Color.Red
                    End If

                End While
            End If

        Catch ex As IO.IOException

        End Try

    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Dashboard.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        Dashboard.Dock = DockStyle.Fill
        Dashboard.Show()
        Dashboard.BringToFront()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ManagementSetting.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        ManagementSetting.Dock = DockStyle.Fill
        ManagementSetting.Show()
        ManagementSetting.BringToFront()
    End Sub

    Private Sub ChangeProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeProcessToolStripMenuItem.Click
        ChangeTeam.Show()
        ChangeTeam.EmplID = TreeView1.SelectedNode.Tag
    End Sub



    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Dim mag As MsgBoxResult = MsgBox("Activity logger will check if system is locked during activity", vbInformation)
    End Sub



#End Region
#Region "Conn Pooling"
    Private Sub CpEnabled_Click(sender As Object, e As EventArgs) Handles CpEnabled.Click
        My.Settings.ConnPooling = True
        My.Settings.Save()
        CpEnabled.Checked = True
        CpDisabled.Checked = False
    End Sub

    Private Sub ClearJunkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearJunkToolStripMenuItem.Click

        Try
            Dim result As DialogResult = MessageBox.Show("Are you sure ?", "Title", MessageBoxButtons.YesNo)

            If result = MsgBoxResult.Yes Then
                Dim conn As New pgConnect
                Dim value As String = "Activity" & "^" & "Sub Activity" & "^" & "Task"
                Dim reader As NpgsqlDataReader = conn.GetRecords("time_view", "*", "activity=@value1 AND Sub_activity=@value2 AND task=@value3", value)
                If reader.HasRows Then
                    While reader.Read

                        Dim delconn As New pgConnect
                        Dim delvalue As String = reader("id")
                        delconn.DeleteRecord("time_view", delvalue, "id=@value1")

                    End While
                End If
                Dim msg As MsgBoxResult = MsgBox("Junk data cleared successfully", vbInformation, "Junk cleared !")
            End If

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            ' MsgBox(ex.Message)

            '  Dim msg1 As MsgBoxResult = MsgBox(ex.Message)

        Finally

        End Try


    End Sub

    Private Sub SettingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem1.Click
        ManagementSetting.MdiParent = Me
        Me.LayoutMdi(MdiLayout.Cascade)
        ManagementSetting.Dock = DockStyle.Fill
        ManagementSetting.Show()
        ManagementSetting.BringToFront()
    End Sub

    Private Sub ProjectSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectSettingToolStripMenuItem.Click
        ProjectSetting.Show()

    End Sub

    Private Sub CpDisabled_Click(sender As Object, e As EventArgs) Handles CpDisabled.Click
        My.Settings.ConnPooling = False
        My.Settings.Save()
        CpEnabled.Checked = False
        CpDisabled.Checked = True
    End Sub

#End Region
#Region "System Switch Check"

    Private Sub sysswitchActivate_Click(sender As Object, e As EventArgs) Handles sysswitchActivate.Click
        Call SysLockCheck("True", Project, Process, SubProcess, "SwitchUserCheck")
        Call SysSwitchRetrive()
    End Sub

    Private Sub sysswitchdeactivate_Click(sender As Object, e As EventArgs) Handles sysswitchdeactivate.Click
        Call SysLockCheck("False", Project, Process, SubProcess, "SwitchUserCheck")
        Call SysSwitchRetrive()
    End Sub

    Private Sub sysswitchhelp_Click(sender As Object, e As EventArgs) Handles sysswitchhelp.Click
        Dim mag1 As MsgBoxResult = MsgBox("This will check for system switch event", vbInformation)
    End Sub

    Private Sub SysSwitchCheck(Status As String, Project As String, Process As String, SubProcess As String, Type As String)
        Dim Conn As New pgConnect
        Try

            Dim value As String = Status & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Type
            Conn.UpdateRecord("app_config", "option=@value1", value, "project = @value2 AND process = @value3 AND sub_process = @value4 AND type = @value5")
        Catch ex As IO.IOException
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try
    End Sub

    Private Sub SysSwitchRetrive()

        Try
            Dim Conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & "SwitchUserCheck"
            Dim reader As NpgsqlDataReader = Conn.GetRecords("app_config", "option", "Project=@value1 AND process=@value2 AND sub_process=@value3 AND type=@value4", value)
            If reader.HasRows Then
                While reader.Read

                    If reader("option") = "True" Then
                        sysswitchActivate.Checked = True
                        sysswitchdeactivate.Checked = False
                        MenuSwitchUserCheck.ForeColor = Color.Green

                    ElseIf reader("option") = "False" Then
                        sysswitchActivate.Checked = False
                        sysswitchdeactivate.Checked = True
                        MenuSwitchUserCheck.ForeColor = Color.Red
                    End If

                End While
            End If

        Catch ex As IO.IOException

        End Try

    End Sub

#End Region


    Sub app_config_setting()

        Dim value As String = TM_Project & "" & TM_Process & "" & TM_SubProcess & "" & ""
        Dim conn1 As New pgConnect
        Dim rdr1 As NpgsqlDataReader = conn1.GetRecords("app_config", "option", "project=@value1 and process=@value2 and sub_process=@value3", value)
        If rdr1.HasRows Then

        End If


    End Sub

End Class

   






    
    