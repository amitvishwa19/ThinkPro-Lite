Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.ComponentModel

Public Class Old_Setup
    Dim ConnName As String
    Dim DBType As String
    Dim DBName As String
    Dim SelectedTablename As String
    Dim CurrentPage As Integer

    'Private Workers() As BackgroundWorker
    'Private NumWorkers = 0

    Private Sub DBSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Home.setkey = Nothing

        MenuStrip1.BringToFront()
        Home.Visible = False
        ''App config file load setup
        'Dim AppConfig As New AppStartup
        'If AppConfig.configfilecheck = True Then
        '    AppConfig.ConnDetails()
        '    cmbDBType.Text = My.Settings.DatabaseType
        '    txtDatabaseName.Text = My.Settings.DatabaseName
        '    txtServerAddress.Text = My.Settings.ServerAddress
        '    txtServerPort.Text = My.Settings.ServerPort
        '    txtDatabaseID.Text = My.Settings.DatabaseID
        '    txtDatabasePass.Text = My.Settings.DatabasePass
        'End If

    End Sub

    Private Sub DBSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Home.Show()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If pgMyConn.State = 1 Then
            pgMyConn.Close()
        End If

        Home.Show()
    End Sub

#Region "App db connection"

    Private Sub app_db_connect()
        DBconnect.SQLDBConn()
        MsgBox(sqlMyConn.State)

        Dim dr As SqlDataReader
        Dim sql As String = "SELECT * FROM app_setting"
        Dim mycmd As SqlCommand = New SqlCommand(sql, sqlMyConn)
        dr = mycmd.ExecuteReader
        While dr.Read
            MsgBox(dr("database_name").ToString)
        End While
        sqlMyConn.Close()

    End Sub

    Private Sub DB_tree()

        Dim conn As New pgConnect
        Dim DB = New TreeNode
        Dim Table As New TreeNode
        Dim Columns As New TreeNode
        Dim Dtype As New TreeNode

        DBTree.Nodes.Clear()
        DB = New TreeNode("ThinkPro")
        DBTree.Nodes.Add(DB)

        Dim value As String = "public"
        Dim tbl As NpgsqlDataReader = conn.GetRecords("information_schema.tables", "table_schema,table_name", "table_schema =@value1", value)
        While tbl.Read
            Table = New TreeNode(tbl("table_name").ToString)
            DB.Nodes.Add(Table)

            conn.Connect()
            Dim value1 As String = tbl("table_name")
            Dim clmn As NpgsqlDataReader = conn.GetRecords("information_schema.columns", "column_name,data_type", "table_name =@value1", value1)
            While clmn.Read
                Columns = New TreeNode(clmn("column_name"))
                Table.Nodes.Add(Columns)

                'conn.Connect()
                'Dim value2 As String = clmn("column_name")
                'Dim dtyp As NpgsqlDataReader = conn.GetRecords("information_schema.columns", "column_name,data_type", "column_name =@value1", value2)
                'While dtyp.Read
                '    Dtype = New TreeNode(dtyp("data_type"))
                '    Columns.Nodes.Add(Dtype)
                'End While
            End While
        End While



        DBTree.TopNode.Expand()
    End Sub 'Required

    Private Sub DataGridView1_FilterStringChanged(sender As Object, e As EventArgs) Handles gridTable.FilterStringChanged
        BindingSource1.Filter = gridTable.FilterString
        gridTable.DataSource = BindingSource1
    End Sub



    'This will load all the variables to textbox after selections
    Private Sub ConnVariables()
        'Try
        '    DBconnect.pgDBConn()
        '    Dim dr As NpgsqlDataReader
        '    Dim sql As String = "SELECT * FROM db_details WHERE connection_name='" & TreeView1.SelectedNode.Text & "'"
        '    Dim mycmd As NpgsqlCommand = New NpgsqlCommand(sql, pgMyConn)
        '    dr = mycmd.ExecuteReader

        '    While dr.Read

        '        txtConName.Text = dr("connection_name").ToString
        '        cmbDBType.Text = dr("database_type").ToString
        '        txtDatabaseName.Text = dr("database_name").ToString
        '        txtServerAddress.Text = dr("server_address").ToString
        '        txtServerPort.Text = dr("server_port").ToString
        '        txtDatabaseID.Text = dr("server_id").ToString
        '        txtDatabasePass.Text = dr("server_pass").ToString
        '        cmdDefaultConn.Text = "Make Default Conn"
        '        cmdDefaultConn.Enabled = True

        '        If dr("default_connection").ToString = "True" Then
        '            cmdDefaultConn.Text = "Default Connection"
        '            cmdDefaultConn.Enabled = False
        '        End If

        '    End While
        '    pgMyConn.Close()

        '    'Select Case TabControl1.SelectedIndex
        '    '    Case 1 ' User clicks on Second Tab
        '    '        MsgBox(TreeView1.SelectedNode.Text)
        '    'End Select

        'Catch ex As Exception
        '    MsgBox("Database Table Tree after selection" & vbNewLine &
        '           ex.Message, vbCritical)
        'End Try
    End Sub

#End Region


    Dim i As Integer

    Private Sub cmdTestConn_Click(sender As Object, e As EventArgs) Handles cmdTestConn.Click


        If ConnTest() = True Then
            cmdTestConn.Text = "Set as defalult Connection"
            cmdTestConn.BackColor = Color.DarkSeaGreen
            lblError.Visible = True
            lblError.Text = "Connection Successfull"
            cmdSetDefault.Visible = True
            cmdConfigFile.Visible = True
        Else
            cmdTestConn.BackColor = Color.LightSalmon
            lblError.Visible = True
            lblError.Text = "Unable to cnnect to database, Please enter correct input"
        End If



    End Sub

    Private Function ConnTest()

        Dim pgTestconn As New NpgsqlConnection

        Dim AccessConn As New OleDbConnection
        Try




            If cmbDBType.Text = "PostgreSQL" Then
                pgTestconn.ConnectionString = "Server=" & txtServerAddress.Text & ";Port=" & txtServerPort.Text & ";Database=" & txtDatabaseName.Text & ";User Id=" & txtDatabaseID.Text & ";Password=" & txtDatabasePass.Text & ";"
                pgTestconn.Open()

                If pgTestconn.State = 1 Then
                    'cmdCancel.Enabled = True
                    'cmdNext.Enabled = True
                    'txtServerAddress.Enabled = False
                    'txtDatabasePass.Enabled = False
                    'cmdbrowse.Enabled = False
                    Return True
                Else
                    Return False
                End If
                pgTestconn.Close()



            ElseIf cmbDBType.Text = "Access Database" Then

                AccessConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtServerAddress.Text & ";Jet OLEDB:Database Password=" & txtDatabasePass.Text & ""
                AccessConn.Open()
                If AccessConn.State = 1 Then
                    cmdCancel.Enabled = True
                    cmdNext.Enabled = True
                    'txtServerAddress.Enabled = False
                    'txtDatabasePass.Enabled = False
                    'cmdbrowse.Enabled = False
                    Return True
                Else
                    Return False
                End If
                AccessConn.Close()
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function 'Required


    Private Sub ConfFileCreate()

        Try
            Dim DBvar As New Encryption
            Dim FILE_NAME As String = Application.UserAppDataPath & "\AppConfig.txt"
            My.Computer.FileSystem.DeleteFile(FILE_NAME)
            File.Create(Application.UserAppDataPath & "\AppConfig.txt").Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt(cmbDBType.Text)
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
        Catch ex As Exception
            MsgBox("Error while creating App Configuration file " & vbNewLine & ex.Message)
        End Try

    End Sub 'Required

    Private Sub remove_default_conn()
        DBconnect.pgDBConn()
        Dim qry As String = "UPDATE app_setting SET default_connection=0"
        Dim mycmd As NpgsqlCommand = New NpgsqlCommand(qry, pgMyConn)
        mycmd.ExecuteNonQuery()
        sqlMyConn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        DBconnect.pgDBConn()

        Try
            Dim dr As Npgsql.NpgsqlDataReader
            Dim sql As String = "SELECT table_schema,table_name FROM information_schema.tables ORDER BY table_schema,table_name;;"
            Dim mycmd As NpgsqlCommand = New NpgsqlCommand(sql, pgMyConn)
            dr = mycmd.ExecuteReader


            If dr.HasRows Then
                While dr.Read
                    MsgBox(dr("full_name").ToString)

                End While
            Else
                pgMyConn.Close()
            End If
            pgMyConn.Close()
            If pgMyConn.State = 1 Then pgMyConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MsgBox(db_name)
        MsgBox(db_address)
        MsgBox(db_port)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim db As New pgConnect
        'db.InsertRecord("user_details", "first_name,last_name,full_name,emplid", "'test','test','test,test','232323'")
        'db.UpdateRecord("user_details", "first_name", "wola", 6)
        db.DeleteRecord("user_details", "id=5")
        Dim reader As NpgsqlDataReader = db.GetRecords("user_details")

        While reader.Read
            MsgBox(reader("full_name"))
        End While

    End Sub

    Private Sub cmdDelCon_Click(sender As Object, e As EventArgs)
        'DBconnect.pgDBConn()
        'Dim qry As String = "DELETE FROM db_details WHERE connection_name='" & txtConName.Text & "'"
        'Dim mycmd As NpgsqlCommand = New NpgsqlCommand(qry, pgMyConn)
        'mycmd.ExecuteNonQuery()
        'pgMyConn.Close()
        'Call Conn_tree()
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged


        If TabControl.SelectedIndex = (0) Then

        ElseIf TabControl.SelectedIndex = (1) Then
            Call DB_tree()
            Call CreateDatabase()
        ElseIf TabControl.SelectedIndex = (2) Then

        End If


    End Sub 'Required

#Region "Tab Change Events"

    Private Sub DatabseTableTree()
        Try

            If cmbDBType.Text = "PostgreSQL" Then

                Dim DBS As New DatabaseSetup
                Dim reader As NpgsqlDataReader = DBS.PGAllTables

                DBTree.Nodes.Clear()
                Dim Parentnode = New TreeNode
                Parentnode = New TreeNode("Database (" & txtDatabaseName.Text & ")")
                DBTree.Nodes.Add(Parentnode)

                While reader.Read
                    Dim Childnode = New TreeNode
                    Childnode = New TreeNode(reader("table_name").ToString)
                    Parentnode.Nodes.Add(Childnode)
                End While
                DBTree.ExpandAll()
                DBS.PGConnectionClose()
            ElseIf cmbDBType.Text = "Access Database" Then

                Dim DBS As New DatabaseSetup
                Dim reader As OleDbDataReader = DBS.AccessAllTables

                DBTree.Nodes.Clear()
                Dim Parentnode = New TreeNode
                Parentnode = New TreeNode("Database (" & txtDatabaseName.Text & ")")
                DBTree.Nodes.Add(Parentnode)

                While reader.Read
                    Dim Childnode = New TreeNode
                    Childnode = New TreeNode(reader("Name").ToString)
                    Parentnode.Nodes.Add(Childnode)
                End While
                DBTree.ExpandAll()
                DBS.AccessConnectionClose()


            End If



        Catch ex As Exception
            MsgBox("Database Table Tree error" & vbNewLine &
                   ex.Message, vbCritical)
        End Try

    End Sub



    Sub TabletoGrid()
        'Try
        '    Dim DBS As New DatabaseSetup
        '    Dim reader As NpgsqlDataReader = DBS.TableGridView
        '    Dim table As New DataTable

        '    table.Load(reader)
        '    dgvDBTableData.DataSource = table
        '    'DBS.ConnectionClose()
        'Catch ex As Exception

        'End Try
    End Sub



    Private Sub DatabaseSetupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'TabControl.SelectTab(1)
    End Sub

    Private Sub TSAccToPG_Click(sender As Object, e As EventArgs)
        TabControl.SelectTab(2)
    End Sub

#End Region

    Private Sub cmdDeleteTable_Click(sender As Object, e As EventArgs)
        Dim db As New DatabaseSetup
        db.DeleteTable(SelectedTablename)

        'This will refresh all table tree
        Call DatabseTableTree()
        'Clead datagrid view
        'dgvDBTableData.Columns.Clear()
    End Sub

    Private Sub cmdCreateTable_Click(sender As Object, e As EventArgs)

        Dim table As String

        table = InputBox("Please enter a table name" & vbNewLine & vbNewLine &
                       "Note:- Make sure table name not contain a space")

        Dim db As New DatabaseSetup
        db.AddTable(table)

        'This will refresh all table tree
        Call DatabseTableTree()
    End Sub


#Region "Coonnection"







#End Region

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs)
        SelectedTablename = DBTree.SelectedNode.Text

        If DBTree.TopNode.Text Like "*Database*" Then
            Call TabletoGrid()
        End If

    End Sub

    Private Sub cmdbrowse_Click(sender As Object, e As EventArgs) Handles cmdbrowse.Click

        'If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
        '    txtServerAddress.Text = FolderBrowserDialog1.SelectedPath
        'End If

        Dim fd As OpenFileDialog = New OpenFileDialog()
        'Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            txtServerAddress.Text = fd.FileName
        End If




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim AccessConn As New OleDbConnection
        AccessConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtServerAddress.Text & ";Jet OLEDB:Database Password=" & txtDatabasePass.Text & ""
        AccessConn.Open()



        Dim db As New DatabaseSetup
        Dim rd As OleDbDataReader = db.AccessAllTables

        While rd.Read

            MsgBox(rd("Table_name"))

        End While

    End Sub

    Shared Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

    Shared Function CheckHash(newInput As String) As Boolean
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(newInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Private Sub cmbDBType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDBType.SelectedIndexChanged

        'If cmbDBType.SelectedItem = "Access Database" Then
        '    txtDatabaseName.Enabled = False
        '    txtServerPort.Enabled = False
        '    txtDatabaseID.Enabled = False
        '    cmdTestConn.Enabled = True

        'Else
        '    txtDatabaseName.Enabled = True
        '    txtServerPort.Enabled = True
        '    txtDatabaseID.Enabled = True
        '    cmdTestConn.Enabled = True
        'End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        cmbDBType.Text = Nothing
        cmdCancel.Enabled = False
        cmdNext.Enabled = False
        cmdBack.Enabled = False
        cmdTestConn.Visible = True
        txtServerAddress.Enabled = True
        txtServerAddress.Text = Nothing
        txtDatabasePass.Enabled = True
        txtDatabasePass.Text = Nothing
        cmdbrowse.Enabled = True
        cmdbrowse.Text = Nothing
        txtDatabaseName.Enabled = True
        txtDatabaseName.Text = Nothing
        txtServerPort.Enabled = True
        txtServerPort.Text = Nothing
        txtDatabaseID.Enabled = True
        txtDatabaseID.Text = Nothing
        TabControl.SelectTab(0)

    End Sub 'Required

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Dim TotalPage As Integer = TabControl.TabPages.Count
        CurrentPage = CurrentPage + 1
        TabControl.SelectTab(CurrentPage)
        If CurrentPage = TotalPage - 1 Then
            cmdNext.Enabled = False
        End If
        cmdBack.Enabled = True

    End Sub 'Required

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Dim TotalPage As Integer = TabControl.TabPages.Count
        CurrentPage = CurrentPage - 1
        TabControl.SelectTab(CurrentPage)
        If CurrentPage = 0 Then
            cmdBack.Enabled = False
        End If
        cmdNext.Enabled = True
    End Sub 'Required

    Private Sub DBTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles DBTree.AfterSelect
        If DBTree.SelectedNode.Level = 1 Then
            Dim conn As New pgConnect
            conn.GetRecordsGRID(DBTree.SelectedNode.Text, "*")
            gridTable.Columns.Clear()
            BindingSource1.DataSource = conn.DataTable
            gridTable.DataSource = BindingSource1
            'Dim i As Integer
            Dim Enc As New Encryption
            'For i = 0 To gridTable.RowCount - 1
            '    For j = 0 To gridTable.ColumnCount - 1
            '        'If DataGridView1.Rows(i).Cells(j).Value <> Nothing Then


            '        If gridTable.Rows(i).Cells(j).Value.ToString <> "" Then
            '            Dim inp = gridTable.Rows(i).Cells(j).Value
            '            If Enc.CheckEncryprion(inp) = True Then
            '                gridTable.Rows(i).Cells(j).Value = Enc.decrypt(inp)
            '            Else
            '                gridTable.Rows(i).Cells(j).Value = inp
            '                'End If
            '            End If

            '        End If
            '    Next
            'Next

        End If
    End Sub

    Private Sub GetConfigInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetConfigInfoToolStripMenuItem.Click
        Try
            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt")

            cmbDBType.Text = enc.decrypt(lines(0))
            txtDatabaseName.Text = enc.decrypt(lines(1))
            txtServerAddress.Text = enc.decrypt(lines(2))
            txtServerPort.Text = enc.decrypt(lines(3))
            txtDatabaseID.Text = enc.decrypt(lines(4))
            txtDatabasePass.Text = enc.decrypt(lines(5))
        Catch ex As Exception
            MsgBox("Unable to retrive config info" & vbNewLine & ex.Message)
        End Try



    End Sub

    Private Sub cmdConfig_Click(sender As Object, e As EventArgs)
        Try
            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines("\\10.229.73.29\data_timesheet\ThinkproLite\AppConfig.txt")

            cmbDBType.Text = enc.decrypt(lines(0))
            txtDatabaseName.Text = enc.decrypt(lines(1))
            txtServerAddress.Text = enc.decrypt(lines(2))
            txtServerPort.Text = enc.decrypt(lines(3))
            txtDatabaseID.Text = enc.decrypt(lines(4))
            txtDatabasePass.Text = enc.decrypt(lines(5))
        Catch ex As Exception
            MsgBox("Unable to retrive config info" & vbNewLine & ex.Message)
        End Try
    End Sub

    Private Sub cmdSetDefault_Click(sender As Object, e As EventArgs) Handles cmdSetDefault.Click
        Call ConfFileCreate()
        MsgBox("Confugration file setup success", vbInformation, "Success")
        lblError.Visible = False
        cmdNext.Enabled = True
        cmdCancel.Enabled = True
    End Sub 'Required

    Private Sub CreateDatabase()
        Dim conn As New pgConnect

        conn.CreateTable("User_details", "user_id serial PRIMARY KEY,first_name VARCHAR (50) ,middle_name VARCHAR (50) ,last_name VARCHAR (50) ,gender VARCHAR (10) ,dob VARCHAR (50) ,blood_group VARCHAR (50) ,contact_details	VARCHAR (50) ,email VARCHAR (355),qualification	VARCHAR (355),work_experience VARCHAR (355),address VARCHAR (355),empl_id VARCHAR (50) ,project_id INT ,project VARCHAR (50) ,process VARCHAR (355),sub_process VARCHAR (355),designation VARCHAR (50) ,grade VARCHAR (50) ,doj	VARCHAR (50) ,shift_details   VARCHAR (50) ,shift_start	VARCHAR (50) ,shift_end	VARCHAR (50) ,role	        VARCHAR (50) ,billing	        VARCHAR (50) ,utilization     VARCHAR (50) ,lan_id	        VARCHAR (50) ,desk_id	        VARCHAR (50) ,asset_id        VARCHAR (50) ,ip_address      VARCHAR (50) ,access_card_no	VARCHAR (50) ,account_type	VARCHAR (355),account_status	VARCHAR (355),login_attempt	INT,password	VARCHAR (355),password_type	VARCHAR (50),password_change_date    timestamp,secret_ques1	VARCHAR (355),secret_answer1	VARCHAR (355),secret_ques2 VARCHAR (355),secret_answer2	VARCHAR (355),secret_ques3	VARCHAR (355),secret_answer3 VARCHAR (355)")
        conn.CreateTable("project_details", "project_id serial PRIMARY KEY,project 	VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,project_lead VARCHAR (100) ,project_manager VARCHAR (100),delivery_manager VARCHAR (100),project_won     VARCHAR (50),project_nicename VARCHAR (200),status VARCHAR (10)")
        conn.CreateTable("app_option", "id serial 	PRIMARY KEY,account     VARCHAR (100) ,status    	VARCHAR (100) ,role    	VARCHAR (100) ,billing   	VARCHAR (100) ,utilization	VARCHAR (100),leave_type	VARCHAR (100),secret_question	VARCHAR (100)")
        conn.CreateTable("time_activity", "act_id serial PRIMARY KEY,seq INT ,project_id  INT ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,bucket VARCHAR (100) ,activity VARCHAR (100) ,sub_activity VARCHAR (200) ,task VARCHAR (200),upt VARCHAR (200),ex_lock	INT,volume	INT,aid  INT,cmnt  	INT,readme	TEXT,status	VARCHAR (10)")
        conn.CreateTable("think_profile", "id serial PRIMARY KEY,user_id  INT ,empl_id	VARCHAR (100) ,name VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,profile    	VARCHAR (100) ,profile_name   	VARCHAR (100) ")
        conn.CreateTable("time_view", "id serial 	PRIMARY KEY,date	DATE ,user_id  INT ,empl_id	VARCHAR (100) ,name  VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,activity    	VARCHAR (100) ,sub_activity   	VARCHAR (200) ,task		VARCHAR (200),action		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time	INT ,volume INT ,act_id VARCHAR (100) ,comment TEXT,added_by	VARCHAR (100)")
        conn.CreateTable("team_view", "id serial PRIMARY KEY,act_id	VARCHAR (100) ,name    	VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,user_id  	INT ,empl_id		VARCHAR (100) ,date		VARCHAR (50) ,activity	VARCHAR (50) ,activity_type	VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,in_out		VARCHAR (100) ,in_time		VARCHAR (100) ,out_time	VARCHAR (100) ")
        conn.CreateTable("break_time_log", "id serial PRIMARY KEY,name	VARCHAR (100) ,user_id  INT ,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,date		VARCHAR (50) ,status		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time	VARCHAR (100) ,comments	TEXT ")
        conn.CreateTable("leave_view", "id serial PRIMARY KEY,name    VARCHAR (100) ,user_id  INT ,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,leave_type	VARCHAR (100) ,date		VARCHAR (50) ,start_date	VARCHAR (100) ,end_date	VARCHAR (100) ,leave_count	VARCHAR (100) ,leave_time	VARCHAR (100) ,comments	TEXT,leave_status	VARCHAR (100) , approver	VARCHAR (100) ,approver_comment	TEXT ")
        conn.CreateTable("think_poll", "poll_id serial PRIMARY KEY,target_group VARCHAR (100),target VARCHAR (50), date VARCHAR (50),process_id INT,poll_title TEXT,poll_question TEXT,option_1	TEXT,option_2	TEXT,option_3	TEXT,option_4 TEXT,poll_status VARCHAR (10),viewed INT,replied INT,comment	TEXT,owner VARCHAR (100) ")
        conn.CreateTable("think_poll_response", "date VARCHAR (50),poll_id INT,user_id INT,process_id INT,poll_title TEXT,poll_question	TEXT,poll_response	TEXT")
        conn.CreateTable("think_notify", "notify_id serial PRIMARY KEY,date	VARCHAR (50),process_id INT,title TEXT,body TEXT,viewed INT,replied	INT,owner VARCHAR (100)")

        Call DB_tree()

        conn.Connect()
        conn.InsertRecord("app_option", "secret_question", "Your Mother maiden Name")

        conn.Connect()
        conn.InsertRecord("app_option", "secret_question", "First School")

        conn.Connect()
        conn.InsertRecord("app_option", "secret_question", "favorite Pet")


    End Sub 'Required



#Region "Data transfer"
    Dim TableName As String
    Private Workers() As BackgroundWorker
    Private NumWorkers = 0

    Private Sub TransferData_Click(sender As Object, e As EventArgs) Handles TransferData.Click
        NumWorkers = NumWorkers + 1
        ReDim Workers(NumWorkers)

        Workers(NumWorkers) = New BackgroundWorker
        Workers(NumWorkers).WorkerReportsProgress = True
        Workers(NumWorkers).WorkerSupportsCancellation = True

        AddHandler Workers(NumWorkers).DoWork, AddressOf WorkerDoWork
        AddHandler Workers(NumWorkers).ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler Workers(NumWorkers).RunWorkerCompleted, AddressOf WorkerCompleted
        Workers(NumWorkers).RunWorkerAsync()

    End Sub

    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        DataTransfer()
    End Sub

    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        ' I did something!
    End Sub

    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' I'm done!
    End Sub

    Sub DataTransfer()

        Try
            Dim i As Integer
            Dim ival As Integer
            Dim var As New Encryption

            Dim con As New pgConnect
            Dim reader As NpgsqlDataReader = con.GetRecords("time_view", "*", , , "id desc limit 1")
            While reader.Read
                ival = reader("id")
            End While

            Dim Emplid As String = Nothing
            Dim startt As String = Nothing
            Dim endt As String = Nothing
            Dim tottime As Double = Nothing
            Dim volume As String = Nothing
            Dim actid As String = Nothing
            Dim comment As String = Nothing
            Dim Trandate As Date = Nothing

            If TableName = "TimeView" Then
                For i = 0 To AdvancedDataGridView1.RowCount - 1
                    Dim id As String = AdvancedDataGridView1.Rows(i).Cells(0).Value.ToString
                    Dim itemID As Integer = ival + i + 1

                    Dim sdate As Date = AdvancedDataGridView1.Rows(i).Cells(4).Value
                    Dim EntDate As String = Format(sdate, "dd-MMM-yy")
                    var.Encrypt(AdvancedDataGridView1.Rows(i).Cells(6).Value.ToString)
                    Emplid = var.encr
                    Dim name As String = AdvancedDataGridView1.Rows(i).Cells(5).Value.ToString
                    Dim project As String = AdvancedDataGridView1.Rows(i).Cells(1).Value.ToString
                    Dim process As String = AdvancedDataGridView1.Rows(i).Cells(2).Value.ToString
                    Dim subprocess As String = AdvancedDataGridView1.Rows(i).Cells(3).Value.ToString
                    Dim activity As String = AdvancedDataGridView1.Rows(i).Cells(9).Value.ToString
                    Dim sub_activity As String = AdvancedDataGridView1.Rows(i).Cells(10).Value.ToString
                    Dim task As String = AdvancedDataGridView1.Rows(i).Cells(11).Value.ToString
                    startt = AdvancedDataGridView1.Rows(i).Cells(13).Value.ToString
                    endt = AdvancedDataGridView1.Rows(i).Cells(14).Value.ToString
                    tottime = AdvancedDataGridView1.Rows(i).Cells(15).Value.ToString
                    volume = AdvancedDataGridView1.Rows(i).Cells(16).Value.ToString
                    actid = AdvancedDataGridView1.Rows(i).Cells(17).Value.ToString
                    comment = AdvancedDataGridView1.Rows(i).Cells(19).Value.ToString
                    Dim sdded As String = "Data Transfer"

                    Dim conn As New pgConnect
                    Dim value As String = EntDate & "^" & Emplid & "^" & name & "^" & project & "^" & process & "^" & subprocess & "^" & activity & "^" & sub_activity & "^" & task & "^" & startt & "^" & endt & "^" & tottime & "^" & volume & "^" & actid & "^" & comment & "^" & sdded
                    conn.InsertRecordTransfer("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment,added_by", value, id)

                    transf.Text = "Transferring : " & i + 1

                Next
            End If
        Catch ex As Exception
            MsgBox("Error while transfering data" & vbNewLine & ex.Message)
        End Try
    End Sub

#End Region


    Private Sub DTDatabasePAth_Click(sender As Object, e As EventArgs) Handles DTDatabasePAth.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        'Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            My.Settings.AccessDBPath = fd.FileName
            My.Settings.Save()
        End If

    End Sub 'Required

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If My.Settings.AccessDBPath <> Nothing Then
            DTDatabasePAth.Text = My.Settings.AccessDBPath
        End If
    End Sub

    Private Sub TimeViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeViewToolStripMenuItem.Click
        TableName = "TimeView"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        AdvancedDataGridView1.Columns.Clear()
        BindingSource1.DataSource = table
        AdvancedDataGridView1.DataSource = BindingSource1
        Count.Text = "Total Count : " & AdvancedDataGridView1.RowCount
    End Sub

    Private Sub TeamViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeamViewToolStripMenuItem.Click

        TableName = "TeamView"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        AdvancedDataGridView1.Columns.Clear()
        BindingSource1.DataSource = table
        AdvancedDataGridView1.DataSource = BindingSource1
        Count.Text = "Total Count : " & AdvancedDataGridView1.RowCount
    End Sub

    Private Sub BreakLockDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BreakLockDetailsToolStripMenuItem.Click
        TableName = "TimeLog"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        AdvancedDataGridView1.Columns.Clear()
        BindingSource1.DataSource = table
        AdvancedDataGridView1.DataSource = BindingSource1
        Count.Text = "Total Count : " & AdvancedDataGridView1.RowCount
    End Sub

    Public Sub gridTeamView_FilterStringChanged(sender As Object, e As EventArgs) Handles AdvancedDataGridView1.FilterStringChanged
        BindingSource1.Filter = AdvancedDataGridView1.FilterString
        AdvancedDataGridView1.DataSource = BindingSource1
        Count.Text = "Total Count : " & AdvancedDataGridView1.RowCount
    End Sub

    Private Sub cmdConfigFile_Click(sender As Object, e As EventArgs) Handles cmdConfigFile.Click


        Dim DBvar As New Encryption
        Dim savepath As String
        Dim FILE_NAME As String
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            savepath = FolderBrowserDialog1.SelectedPath
            FILE_NAME = savepath & "\AppConfig.txt"
            File.Create(FILE_NAME).Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt(cmbDBType.Text)
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
            MsgBox("Config file saved to : " & savepath, MsgBoxStyle.Information, "Created")


        Else
            Exit Sub
        End If








    End Sub


End Class