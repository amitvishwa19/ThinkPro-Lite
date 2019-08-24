Imports Npgsql
Imports NpgsqlTypes
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.ComponentModel

Public Class Old_ThinkSetup
    Dim CurrentPage As Integer
    Dim SetupType As String = Nothing
    Dim ConfPAth As String = Nothing
    Dim CreateDatabaseTable As Boolean = False

    Dim ServerAddress As String
    Dim ServerPort As String
    Dim DatabaseName As String
    Dim DatabaseID As String
    Dim DatabasePass As String
    Dim ConnectionStatus As Boolean = False


    'Private Sub cmdNext_Click(sender As Object, e As EventArgs)
    '    Dim TotalPage As Integer = TabControl.TabPages.Count

    '    If cmdNext.Text = "Finish" Then

    '        My.Settings.DatabaseType = "PostgreSQL"
    '        My.Settings.DatabaseName = txtDatabaseName.Text
    '        My.Settings.ServerAddress = txtServerAddress.Text
    '        My.Settings.ServerPort = txtServerPort.Text
    '        My.Settings.DatabaseID = txtDatabaseID.Text
    '        My.Settings.DatabasePass = txtDatabasePass.Text
    '        My.Settings.Save()


    '        'If CreateDatabaseTable = True Then
    '        Call CreateDatabase()
    '        'End If


    '        Me.Close()
    '        Application.Restart()
    '        Exit Sub

    '    End If


    '    CurrentPage = CurrentPage + 1
    '    TabControl.SelectTab(CurrentPage)



    '    If CurrentPage = TotalPage - 1 Then
    '        cmdNext.Text = "Finish"
    '    End If
    '    cmdBack.Enabled = True
    '    cmdCancel.Enabled = True


    '    If CurrentPage = 1 Then
    '        lblProjType.ForeColor = Color.Green
    '    End If

    '    If SetupType = "NoConfigFile" Then
    '        If CurrentPage = 1 Then
    '            TabControl.SelectTab(2)
    '        End If

    '    Else
    '        If CurrentPage = 1 Then
    '            TabControl.SelectTab(1)
    '        End If
    '    End If


    '    If CurrentPage = 2 Then
    '        'If SetupType = "ConfigFile" Then
    '        '    Try
    '        '        Dim enc As New Encryption
    '        '        Dim lines() As String = System.IO.File.ReadAllLines(txtPath.Text)
    '        '        '"PostgreSQL" = enc.decrypt(lines(0))
    '        '        txtDatabaseName.Text = enc.decrypt(lines(1))
    '        '        txtServerAddress.Text = enc.decrypt(lines(2))
    '        '        txtServerPort.Text = enc.decrypt(lines(3))
    '        '        txtDatabaseID.Text = enc.decrypt(lines(4))
    '        '        txtDatabasePass.Text = enc.decrypt(lines(5))
    '        '    Catch ex As Exception
    '        '        MsgBox("Unable to retrive config info" & vbNewLine & ex.Message)
    '        '    End Try
    '        'End If
    '    End If





    'End Sub

    'Private Sub cmdBack_Click(sender As Object, e As EventArgs)
    '    Dim TotalPage As Integer = TabControl.TabPages.Count
    '    CurrentPage = CurrentPage - 1
    '    TabControl.SelectTab(CurrentPage)
    '    If CurrentPage = 0 Then
    '        cmdBack.Enabled = False
    '    End If
    '    cmdNext.Enabled = True
    '    cmdNext.Text = "Next"
    'End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs)
        'TabControl.SelectTab(0)
        'cmdBack.Enabled = False
        'cmdCancel.Enabled = False
        'cmdNext.Enabled = True
        'CurrentPage = 0
    End Sub

    Private Sub cmdbrowse_Click(sender As Object, e As EventArgs)
        Dim OFD As New OpenFileDialog

        Dim result As DialogResult = OFD.ShowDialog()


        If result = Windows.Forms.DialogResult.OK Then
            ConfPAth = OFD.FileName
            'txtPath.Text = ConfPAth
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        txtDatabaseName.Enabled = True
        txtServerAddress.Enabled = True
        txtServerPort.Enabled = True
        txtDatabaseID.Enabled = True
        txtDatabasePass.Enabled = True

        txtconfpath.Enabled = False
        browse.Enabled = False


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        txtconfpath.Enabled = True
        browse.Enabled = True

        txtDatabaseName.Enabled = False
        txtServerAddress.Enabled = False
        txtServerPort.Enabled = False
        txtDatabaseID.Enabled = False
        txtDatabasePass.Enabled = False

    End Sub

    Private Sub cmdTestConn_Click(sender As Object, e As EventArgs) Handles cmdTestConn.Click
        If ConnTest() = True Then
            cmdTestConn.BackColor = Color.DarkSeaGreen
            lblError.Visible = True
            lblError.Text = "Connection Successfull"
            cmdSetDefault.Visible = True
            cmdCreateConf.Visible = True
            ConnectionStatus = True

        Else
            cmdTestConn.BackColor = Color.LightSalmon
            lblError.Visible = True
            lblError.Text = "Unable to cnnect to database, Please enter correct input"
        End If
    End Sub

    Private Sub ConfFileCreate(Path As String)

        Try

            Dim DBvar As New Encryption
            Dim FILE_NAME As String = path & "\AppConfig.txt"
            'My.Computer.FileSystem.DeleteFile(FILE_NAME)
            File.Create(FILE_NAME).Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt("PostgreSQL")
            aryText(0) = DBvar.encr
            DBvar.Encrypt(txtDatabaseName.Text)
            aryText(1) = DBvar.encr
            DBvar.Encrypt(txtServerAddress.Text)
            aryText(2) = DBvar.encr
            DBvar.Encrypt(txtServerPort.Text)
            aryText(3) = DBvar.encr
            DBvar.Encrypt(txtDatabaseID.Text)
            aryText(4) = DBvar.encr
            DBvar.Encrypt(txtDatabasePass.Text)
            aryText(5) = DBvar.encr

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            Dim msgr As MsgBoxResult = MsgBox("Config file created and saved to : " & Path, MsgBoxStyle.Information, "Created")
        Catch ex As IO.IOException
            ' Dim line As String = ex.StackTrace.ToString
            ' Dim LineNo() As String = Split(line, "line")

            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Required

    Private Sub cmdSetDefault_Click(sender As Object, e As EventArgs) Handles cmdSetDefault.Click
        Call ConfFileCreate(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        Dim msgr As MsgBoxResult = MsgBox("Confugration file setup success", vbInformation, "Success")
        lblError.Visible = False
        'cmdNext.Enabled = True
        'cmdCancel.Enabled = True

    End Sub

    Private Sub cmdConfigFile_Click(sender As Object, e As EventArgs)
        Dim DBvar As New Encryption
        Dim savepath As String
        Dim FILE_NAME As String
        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            savepath = FBD.SelectedPath
            FILE_NAME = savepath & "\AppConfig.txt"
            File.Create(FILE_NAME).Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt("PostgreSQL")
            aryText(0) = DBvar.encr
            DBvar.Encrypt(txtDatabaseName.Text)
            aryText(1) = DBvar.encr
            DBvar.Encrypt(txtServerAddress.Text)
            aryText(2) = DBvar.encr
            DBvar.Encrypt(txtServerPort.Text)
            aryText(3) = DBvar.encr
            DBvar.Encrypt(txtDatabaseID.Text)
            aryText(4) = DBvar.encr
            DBvar.Encrypt(txtDatabasePass.Text)
            aryText(5) = DBvar.encr

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            Dim msgr As MsgBoxResult = MsgBox("Config file saved to : " & savepath, MsgBoxStyle.Information, "Created")


        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim msgr As MsgBoxResult = MsgBox(CreateDatabaseTable)
    End Sub

    Private Sub ThinkSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Home.Visible = False
        TabControl.SendToBack()
        TabControl.SelectTab(1)
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Home.Visible = True
    End Sub

#Region "New Setup"

    Private Function ConnTest()

        Dim pgTestconn As New NpgsqlConnection

        Try

            pgTestconn.ConnectionString = "Server=" & txtServerAddress.Text & ";Port=" & txtServerPort.Text & ";Database=" & txtDatabaseName.Text & ";User Id=" & txtDatabaseID.Text & ";Password=" & txtDatabasePass.Text & ";"
            pgTestconn.Open()

            If pgTestconn.State = 1 Then
                ServerAddress = txtServerAddress.Text
                ServerPort = txtServerPort.Text
                DatabaseName = txtDatabaseName.Text
                DatabaseID = txtDatabaseID.Text
                DatabasePass = txtDatabasePass.Text

                lblDatabasename.Text = "Database Name :- " & DatabaseName
                lblServerAddress.Text = "Server Address :- " & ServerAddress
                lblServerPort.Text = "Server Port :- " & ServerPort
                lblDatabaseid.Text = "Database ID :- " & DatabaseID


                Return True
            Else
                Return False
            End If
            pgTestconn.Close()

        Catch ex As SqlException
            Return False
        End Try

    End Function 'Required

    Sub SettingTree()
        Dim conn As New pgConnect
        Dim Setting = New TreeNode
        Dim Options = New TreeNode



        Dim setng As NpgsqlDataReader = conn.GetRecords("app_setting", "option_name", "option_type=@value1", "Setting", "id ASC")
        While setng.Read
            Setting = New TreeNode(setng("option_name").ToString)
            'TreeView.Nodes.Add(Setting)



        End While
        'TreeView.ExpandAll()





    End Sub

    Private Sub browse_Click(sender As Object, e As EventArgs) Handles browse.Click
        Dim OFD As New OpenFileDialog

        Dim result As DialogResult = OFD.ShowDialog()


        If result = Windows.Forms.DialogResult.OK Then
            ConfPAth = OFD.FileName
            txtconfpath.Text = ConfPAth


            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines(ConfPAth)


            txtDatabaseName.Text = enc.decrypt(lines(1))
            txtServerAddress.Text = enc.decrypt(lines(2))
            txtServerPort.Text = enc.decrypt(lines(3))
            txtDatabaseID.Text = enc.decrypt(lines(4))
            txtDatabasePass.Text = enc.decrypt(lines(5))

        End If

    End Sub 'Required

#Region "Create Database Table"


#End Region

#End Region

    Private Sub cmdCreateConf_Click(sender As Object, e As EventArgs) Handles cmdCreateConf.Click
        Dim path As String = Nothing
        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            path = FBD.SelectedPath
        Else
            Exit Sub
        End If

        Call ConfFileCreate(path)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        If TreeView1.SelectedNode.Text = "Database Connection" Then
            Call DatabaseConnection()

        ElseIf TreeView1.SelectedNode.Text = "Database Tables" Then
            Call DatabaseTables()


        ElseIf TreeView1.SelectedNode.Text = "Create DB Table" Then
            Try
                If ConnectionStatus = False Then
                    Dim msg As MsgBoxResult = MsgBox("Database connection is not set", vbInformation, "oops!")
                    Exit Sub

                Else
                    Call CreateDB()
                    Call AlterTables()

                End If
            Catch ex As SqlException
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End Try

        ElseIf TreeView1.SelectedNode.Text = "App Forms" Then

            TabControl.SelectTab(0)
            tablelist.Items.Clear()
            Call AppForms()


        ElseIf TreeView1.SelectedNode.Text = "App Task manager" Then
            TabControl.SelectTab(2)
            PerformanceTimer.Start()
            Call UpdateProcessList()


        ElseIf TreeView1.SelectedNode.Text = "Project Details" Then
            If ConnectionStatus = False Then
                Dim msg As MsgBoxResult = MsgBox("Database connection is not set", vbInformation, "oops!")
                Exit Sub
            End If

            TabControl.SelectTab(3)
            Call AllProjects()
            End If



    End Sub

    Private Sub AlterTables()
        Dim conn As New pgConnect
        conn.AlterTable("project_details", "syslock_check", 1)

        Dim conn2 As New pgConnect
        conn2.AlterTable("project_details", "syslock_time", 10)

        Dim conn3 As New pgConnect
        conn3.AlterTable("project_details", "total_time_min", 540)

        Dim conn4 As New pgConnect
        conn4.AlterTable("project_details", "timeview_type", "'Default'")

    End Sub
    Private Sub ProcessDefaultValues()

    End Sub


#Region "Database Tables"

    Sub DatabaseTables()
        If ConnectionStatus = False Then
            Dim msg As MsgBoxResult = MsgBox("Database connection is not set", vbInformation, "oops!")
            Exit Sub
        End If

        TabControl.SelectTab(0)

        Dim conn As New pgConnect
        If conn.TableCount() < 1 Then
            Dim result As Integer = MessageBox.Show("Database not confugred ! ,Like to configure?", "Database not configured", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                Call CreateDatabase()
            End If

        Else
            Call DBTables()
        End If
    End Sub

    Public Sub DBTables()

        Try

            Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
            Dim Conn As New NpgsqlConnection(ConString)
            Conn.Open()
            Dim str As String = "SELECT table_name FROm information_schema.tables WHERE table_schema ='public'"
            Dim comm As New NpgsqlCommand(str, Conn)
            Dim reader As NpgsqlDataReader = comm.ExecuteReader
            tablelist.Items.Clear()
            While reader.Read
                tablelist.Items.Add(reader("table_name").ToString)
            End While
            Conn.Close()



        Catch ex As SqlException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '     Dim msg As MsgBoxResult = MsgBox(ex.Message)
        Finally

        End Try
    End Sub 'Required

    Private Sub CreateDatabase()

        Try
            Call CreateTable("User_details", "user_id serial PRIMARY KEY,first_name VARCHAR (50) ,last_name VARCHAR (50),empl_id VARCHAR (50) ,project_id INT ,project VARCHAR (50) ,process VARCHAR (355),sub_process VARCHAR (355),shift_details VARCHAR (50) ,shift_start	VARCHAR (50) ,shift_end	VARCHAR (50),account_type VARCHAR (355),account_status VARCHAR (355),login_attempt INT,password	VARCHAR (355),password_type	VARCHAR (50),password_change_date timestamp,secret_ques1 VARCHAR (355),secret_answer1 VARCHAR (355),secret_ques2 VARCHAR (355),secret_answer2	VARCHAR (355),secret_ques3	VARCHAR (355),secret_answer3 VARCHAR (355) ,consent bool NOT NULL DEFAULT false")
            Call CreateTable("project_details", "project_id serial PRIMARY KEY,project 	VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,project_lead VARCHAR (100) ,project_manager VARCHAR (100),delivery_manager VARCHAR (100),project_won     VARCHAR (50),project_nicename VARCHAR (200),timeview_type	VARCHAR (50),syslock_check INT,syslock_time INT,backup_path TEXT,status VARCHAR (10)syslock_time INT NOT NULL DEFAULT 10,syslock_check numeric NULL DEFAULT 1,soft_delete_days INT NOT NULL DEFAULT 0,hard_delete_days INT NOT NULL DEFAULT 0")
            Call CreateTable("app_option", "id serial 	PRIMARY KEY,account     VARCHAR (100) ,status    	VARCHAR (100) ,role    	VARCHAR (100) ,billing   	VARCHAR (100) ,utilization	VARCHAR (100),leave_type	VARCHAR (100),secret_question	VARCHAR (100)")
            Call CreateTable("app_config", "id serial PRIMARY KEY,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,type VARCHAR (100) ,option VARCHAR (1000)")
            Call CreateTable("app_user_version", "id serial PRIMARY KEY,user_id  NUMERIC,process_id NUMERIC,app_version  VARCHAR(50)")
            Call CreateTable("time_activity", "act_id serial PRIMARY KEY,seq INT ,project_id  INT ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,bucket VARCHAR (100) ,activity VARCHAR (100) ,sub_activity VARCHAR (200) ,task VARCHAR (200),upt VARCHAR (200),ex_lock	INT,volume	INT,aid  INT,cmnt  	INT,readme	TEXT,status	VARCHAR (10)")
            Call CreateTable("think_profile", "id serial PRIMARY KEY,user_id  INT ,empl_id	VARCHAR (100) ,name VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,profile    	VARCHAR (100) ,profile_name   	VARCHAR (100) ")
            Call CreateTable("time_view", "id serial 	PRIMARY KEY,date	DATE ,user_id  INT ,empl_id	VARCHAR (100) ,name  VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,activity    	VARCHAR (100) ,sub_activity   	VARCHAR (200) ,task		VARCHAR (200),action		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time NUMERIC ,volume NUMERIC ,act_id VARCHAR (100) ,comment TEXT,added_by	VARCHAR (100),activity_id INT")
            Call CreateTable("team_view", "id serial PRIMARY KEY,act_id	VARCHAR (100) ,name    	VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,user_id  	INT ,empl_id		VARCHAR (100) ,date		DATE ,activity	VARCHAR (50) ,activity_type	VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,in_out		VARCHAR (100) ,in_time		VARCHAR (100) ,out_time	VARCHAR (100) ")
            Call CreateTable("break_time_log", "id serial PRIMARY KEY,name	VARCHAR (100) ,user_id  INT ,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,date	DATE ,status		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time NUMERIC,comments	TEXT ")
            'Call CreateTable("leave_view", "id serial PRIMARY KEY,name    VARCHAR (100) ,user_id  INT,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,leave_type	VARCHAR (100) ,date		VARCHAR (50) ,start_date	VARCHAR (100) ,end_date	VARCHAR (100) ,leave_count	VARCHAR (100) ,leave_time	VARCHAR (100) ,comments	TEXT,leave_status	VARCHAR (100) , approver	VARCHAR (100) ,approver_comment	TEXT ")
            'Call CreateTable("think_poll", "poll_id serial PRIMARY KEY,target_group VARCHAR (100),target VARCHAR (50), date VARCHAR (50),process_id INT,poll_title TEXT,poll_question TEXT,option_1	TEXT,option_2	TEXT,option_3	TEXT,option_4 TEXT,poll_status VARCHAR (10),viewed INT,replied INT,comment	TEXT,owner VARCHAR (100) ")
            'Call CreateTable("think_poll_response", "date VARCHAR (50),poll_id INT,user_id INT,process_id INT,poll_title TEXT,poll_question	TEXT,poll_response	TEXT")
            'Call CreateTable("think_notify", "notify_id serial PRIMARY KEY,date	VARCHAR (50),process_id INT,title TEXT,body TEXT,viewed INT,replied	INT,owner VARCHAR (100)")
            'Call CreateTable("think_holiday", "id serial PRIMARY KEY,process_id INT,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,h_date VARCHAR (50),holiday_name VARCHAR (200)")
            'Call CreateTable("activity_tracker", "id serial PRIMARY KEY,user_id INT,process_id INT,empl_id VARCHAR (50) ,empl_name VARCHAR (100) ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process  VARCHAR (100) ,app_name VARCHAR (100) ,app_title TEXT ,start_time	VARCHAR (100) ,end_time	VARCHAR (100),total_time	NUMERIC ")
            Call CreateTable("time_activity_user", "id serial PRIMARY KEY,date DATE,seq INT ,empl_id VARCHAR (50) ,empl_name VARCHAR (100) ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,bucket VARCHAR (100) ,activity  VARCHAR (100) ,sub_activity  VARCHAR (200) ,task	VARCHAR (200),upt VARCHAR (200),ex_lock INT,volume	INT,aid  INT,cmnt  INT,readme TEXT,status	VARCHAR (10),project_id INT")
            Call CreateTable("think_issue_log", "id serial PRIMARY KEY,user_id  INT,process_id INT,date VARCHAR (50),log_type VARCHAR (50),log_title TEXT,log_description TEXT,logr_desc TEXT,logr_solution TEXT,log_status VARCHAR (50)")
            Call CreateTable("think_error_log", "id serial PRIMARY KEY,user_id INT,process_id INT,date VARCHAR (50),error_form	VARCHAR (100),error_title VARCHAR (200),error_desc TEXT")
            Call CreateTable("think_activity_log", "id serial PRIMARY KEY,act_id VARCHAR (100),user_id INT,process_id  INT,date VARCHAR (50),form_name	VARCHAR (50),form_title VARCHAR(50),open_time VARCHAR (100),close_time VARCHAR(100)")
            Call CreateTable("think_change_log", "id serial PRIMARY KEY,user_id INT,process_id INT,date VARCHAR (50),pre_value	TEXT,post_value	TEXT")
            Call CreateTable("pass_change_audit", "id serial PRIMARY KEY,empl_id VARCHAR (200),date VARCHAR (50),pass TEXT")



        Catch ex As SqlException
            ' Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'Required



    Sub CreateDB()
        Dim BG As New BackgroundWorker

        BG.WorkerReportsProgress = True
        BG.WorkerSupportsCancellation = True

        AddHandler BG.DoWork, AddressOf WorkerDoWork
        AddHandler BG.ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler BG.RunWorkerCompleted, AddressOf WorkerCompleted
        BG.RunWorkerAsync()
    End Sub

    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Call CreateDatabase()
        Call SecretQuestions()
    End Sub

    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        ' I did something!
    End Sub

    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim msg As MsgBoxResult = MsgBox("DatabaseID Created Successfully")
    End Sub

    Public Sub CreateTable(tablename As String, tablequery As String)
        Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
        Dim Conn As New NpgsqlConnection(ConString)
        Conn.Open()
        Dim str As String = "CREATE TABLE IF NOT EXISTS " & tablename & " ( " & tablequery & " )"
        Dim cmd As New NpgsqlCommand(str, Conn)
        cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub

    Sub SecretQuestions()

        Try
            Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
            Dim Conn As New NpgsqlConnection(ConString)
            Conn.Open()

            Dim Ques As String() = {"What is your favorite color?",
                                    "In what city were you born?",
                                    "What is the name of your favorite pet?",
                                    "What is the name of your first school?",
                                    "What high school did you attend?",
                                    "What is your mothers maiden name?",
                                    "What is your favorite movie?",
                                    "When is your anniversary?",
                                    "What was the make of your first car?",
                                    "Which is your favorite web browser?"}


            For i = 0 To Ques.Length - 1

                Dim cmd As New NpgsqlCommand("INSERT INTO app_option (secret_question) VALUES ('" & Ques(i) & "')", Conn)
                cmd.ExecuteNonQuery()
            Next

            Conn.Close()

        Catch ex As SqlException
            '    Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub



#End Region

#Region "Database Connection"
    Sub DatabaseConnection()
        TabControl.SelectTab(1)
        Dim DbDetails As String = My.Settings.ConnDetails
        Dim ValArr = DbDetails.Split(",")

        txtDatabaseName.Text = Trim(ValArr(1))
        txtServerAddress.Text = Trim(ValArr(2))
        txtServerPort.Text = Trim(ValArr(3))
        txtDatabaseID.Text = Trim(ValArr(4))
        txtDatabasePass.Text = Trim(ValArr(5))
    End Sub
#End Region
#Region "AppForms"
    Sub AppForms()
        Try
            tablelist.Items.Clear()
            Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim types As Type() = myAssembly.GetTypes()
            For Each myType In types

                If myType.BaseType.FullName = "System.Windows.Forms.Form" Then
                    tablelist.Items.Add(myType.Name)
                End If
            Next
        Catch ex As IO.IOException
            'Catch ex As NullReferenceException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
#End Region
#Region "Application Dashboard"

    Private Sub btnUpdateProcessList_Click(ByVal sender As System.Object, _
                                           ByVal e As System.EventArgs) _
                                           Handles btnUpdateProcessList.Click
        UpdateProcessList()

    End Sub

    Private Sub UpdateProcessList()

        ' clear the existing list of any items
        lstProcesses.Items.Clear()

        ' loop through the running processes and add
        'each to the list
        Dim p As System.Diagnostics.Process

        For Each p In System.Diagnostics.Process.GetProcesses()
            lstProcesses.Items.Add(p.ProcessName & " - " & p.Id.ToString())
        Next

        lstProcesses.Sorted = True

        ' display the number of running processes in
        ' a status message at the bottom of the page
        tslProcessCount.Text = "Processes running: " & _
        lstProcesses.Items.Count.ToString()

    End Sub

    Private Sub PerformanceTimer_Tick(sender As Object, e As EventArgs) Handles PerformanceTimer.Tick
        Try
            Dim cpuLoad As Integer = CDec(pcCPU.NextValue.ToString())
            cpuLoad = 100 - cpuLoad
            lblCPU.Text = "CPU usage " & cpuLoad.ToString() & "%"
            'On Error <span id="IL_AD1" class="IL_AD">Resume</span> Next
            pbCPU.Value = cpuLoad.ToString


            Dim ramLoad As Integer = CDec(pcRAM.NextValue.ToString())
            ramLoad = 100 - cpuLoad
            lblRAM.Text = "RAM Usage " & ramLoad.ToString() & "%"
            'On Error <span id="IL_AD1" class="IL_AD">Resume</span> Next
            pbRAM.Value = ramLoad.ToString
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub btnKill_Click(sender As Object, e As EventArgs) Handles btnKill.Click
        Try
            If lstProcesses.SelectedItems.Count <= 0 Then
                Dim result As Integer = MessageBox.Show("Click on a process name to select it.", "No Process Selected")
                Return
            End If

            ' loop through the running processes looking for a match
            ' by comparing process name to the name selected in the listbox
            Dim p As System.Diagnostics.Process

            For Each p In System.Diagnostics.Process.GetProcesses()

                Dim arr() As String =
                lstProcesses.SelectedItem.ToString().Split("-")

                Dim sProcess As String = arr(0).Trim()
                Dim iId As Integer = Convert.ToInt32(arr(1).Trim())

                If p.ProcessName = sProcess And p.Id = iId Then
                    p.Kill()
                End If

            Next

            ' update the list to show the killed process
            ' has been removed
            UpdateProcessList()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

#End Region
#Region "Project Details"

    Private Sub AllProjects()
        Dim lv As ListView = ListView
        lv.Columns.Clear()
        lv.Items.Clear()
        lv.FullRowSelect = True
        lv.AllowColumnReorder = True
        'lv.CheckBoxes = True
        With lv
            .View = View.Details
            '.FullRowSelect = True
            .Columns.Add("Project")
            .Columns.Add("Process")
            .Columns.Add("Sub Process")
        End With

        lv.GridLines = True


        Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
        Dim Conn As New NpgsqlConnection(ConString)
        Conn.Open()
        Dim str As String = "SELECT * FROM project_details"
        Dim comm As New NpgsqlCommand(str, Conn)
        Dim reader As NpgsqlDataReader = comm.ExecuteReader
        While reader.Read       
            lv.Items.Add(New ListViewItem({reader("project"), reader("process"), reader("sub_process")}))
        End While
        Conn.Close()
        lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        lv.LabelEdit = True
        Dim ival As Double = ListView.Width
        Dim icol As Integer = ListView.Columns.Count
        Dim iwidth As Integer = (ival / icol) - 2

        For i = 0 To ListView.Columns.Count - 1
            lv.Columns(i).Width = iwidth
        Next



    End Sub

    Private Sub TotalRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalRowsToolStripMenuItem.Click
      
        'For i = 0 To ListView.Items.Count - 1
        'MsgBox(ListView.su)
        Dim itm As ListViewItem
        itm = ListView.SelectedItems(0)
        Dim msg As MsgBoxResult = MsgBox(itm.SubItems(2).Text)
        itm.SubItems(2).BackColor = Color.Red
        ' Next
        'MsgBox(ListView.Columns.Count)
        'For Each column As ColumnHeader In Me.ListView.Columns
        '    column.Width = -2
        'Next
        Dim ival As Double = ListView.Width
        Dim msg2 As MsgBoxResult = MsgBox(ival)
        ListView.SelectedItems(0).BackColor = Color.LightGreen
        ListView.Columns(1).Width = 100
    End Sub

    Private Sub UpdateDefaultSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDefaultSettingToolStripMenuItem.Click
        Dim project As String = Nothing
        Dim process As String = Nothing
        Dim subprocess As String = Nothing

        For i = 0 To ListView.Items.Count - 1
            project = ListView.Items(i).SubItems(0).Text
            process = ListView.Items(i).SubItems(1).Text
            subprocess = ListView.Items(i).SubItems(2).Text
            Call AppSetup.ProjectDefaultSettings(project, process, subprocess, "BackupPath", "Null")
            Call AppSetup.ProjectDefaultSettings(project, process, subprocess, "SystemLockTime", "10")
            Call AppSetup.ProjectDefaultSettings(project, process, subprocess, "SwitchUserCheck", "True")
            Call AppSetup.ProjectDefaultSettings(project, process, subprocess, "SystemLockCheck", "True")
            Call AppSetup.ProjectDefaultSettings(project, process, subprocess, "ActivityLoggerType", "Default")
        Next

    End Sub

#End Region


End Class