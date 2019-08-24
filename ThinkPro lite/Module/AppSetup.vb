Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.ComponentModel
Module AppSetup

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

    Sub DatabaseTableSetup()

    End Sub
    Public Function ConnectionTest(iServerAddress As String, iPort As String, iDatabaseName As String, iDatabaseId As String, iDatabasePass As String)

        Dim pgTestconn As New NpgsqlConnection

        Try

            pgTestconn.ConnectionString = "Server=" & iServerAddress & ";Port=" & iPort & ";Database=" & iDatabaseName & ";User Id=" & iDatabaseId & ";Password=" & iDatabasePass & ";"
            pgTestconn.Open()

            If pgTestconn.State = 1 Then
                ServerAddress = iServerAddress
                ServerPort = iPort
                DatabaseName = iDatabaseName
                DatabaseID = iDatabaseId
                DatabasePass = iDatabasePass
                Return True
            Else
                Return False
            End If
            pgTestconn.Close()

        Catch ex As IO.IOException
            Return False
        End Try

    End Function 'Required
    Public Sub CreateDatabase()
        Try
            Call CreateTable("User_details", "user_id serial PRIMARY KEY,first_name VARCHAR (50) ,middle_name VARCHAR (50) ,last_name VARCHAR (50) ,gender VARCHAR (10) ,dob VARCHAR (50) ,blood_group VARCHAR (50) ,contact_details	VARCHAR (50) ,email VARCHAR (355),qualification	VARCHAR (355),work_experience VARCHAR (355),address VARCHAR (355),empl_id VARCHAR (50) ,project_id INT ,project VARCHAR (50) ,process VARCHAR (355),sub_process VARCHAR (355),designation VARCHAR (50) ,grade VARCHAR (50) ,doj	VARCHAR (50) ,shift_details   VARCHAR (50) ,shift_start	VARCHAR (50) ,shift_end	VARCHAR (50) ,role	        VARCHAR (50) ,billing	        VARCHAR (50) ,utilization     VARCHAR (50) ,lan_id	        VARCHAR (50) ,desk_id	        VARCHAR (50) ,asset_id        VARCHAR (50) ,ip_address      VARCHAR (50) ,access_card_no	VARCHAR (50) ,account_type	VARCHAR (355),account_status	VARCHAR (355),login_attempt	INT,password	VARCHAR (355),password_type	VARCHAR (50),password_change_date    timestamp,secret_ques1	VARCHAR (355),secret_answer1	VARCHAR (355),secret_ques2 VARCHAR (355),secret_answer2	VARCHAR (355),secret_ques3	VARCHAR (355),secret_answer3 VARCHAR (355)")
            Call CreateTable("project_details", "project_id serial PRIMARY KEY,project 	VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,project_lead VARCHAR (100) ,project_manager VARCHAR (100),delivery_manager VARCHAR (100),project_won     VARCHAR (50),project_nicename VARCHAR (200),timeview_type	VARCHAR (50),syslock_check	NUMERIC,syslock_time	NUMERIC,backup_path TEXT,status VARCHAR (10)")
            Call CreateTable("app_option", "id serial 	PRIMARY KEY,account     VARCHAR (100) ,status    	VARCHAR (100) ,role    	VARCHAR (100) ,billing   	VARCHAR (100) ,utilization	VARCHAR (100),leave_type	VARCHAR (100),secret_question	VARCHAR (100)")
            Call CreateTable("app_config", "id serial PRIMARY KEY,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,type VARCHAR (100) ,option VARCHAR (1000)")
            Call CreateTable("app_user_version", "id serial PRIMARY KEY,user_id  NUMERIC,process_id NUMERIC,app_version  VARCHAR(50)")
            Call CreateTable("app_setting", "id serial PRIMARY KEY,option_id NUMERIC,option_type	VARCHAR (200),option_name	VARCHAR (200)")
            Call CreateTable("time_activity", "act_id serial PRIMARY KEY,seq INT ,project_id  INT ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,bucket VARCHAR (100) ,activity VARCHAR (100) ,sub_activity VARCHAR (200) ,task VARCHAR (200),upt VARCHAR (200),ex_lock	INT,volume	INT,aid  INT,cmnt  	INT,readme	TEXT,status	VARCHAR (10)")
            Call CreateTable("think_profile", "id serial PRIMARY KEY,user_id  INT ,empl_id	VARCHAR (100) ,name VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,profile    	VARCHAR (100) ,profile_name   	VARCHAR (100) ")
            Call CreateTable("time_view", "id serial 	PRIMARY KEY,date	DATE ,user_id  INT ,empl_id	VARCHAR (100) ,name  VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,activity    	VARCHAR (100) ,sub_activity   	VARCHAR (200) ,task		VARCHAR (200),action		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time NUMERIC ,volume NUMERIC ,act_id VARCHAR (100) ,comment TEXT,added_by	VARCHAR (100),activity_id INT")
            Call CreateTable("team_view", "id serial PRIMARY KEY,act_id	VARCHAR (100) ,name    	VARCHAR (100) ,project_id  	INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,user_id  	INT ,empl_id		VARCHAR (100) ,date		VARCHAR (50) ,activity	VARCHAR (50) ,activity_type	VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,in_out		VARCHAR (100) ,in_time		VARCHAR (100) ,out_time	VARCHAR (100) ")
            Call CreateTable("break_time_log", "id serial PRIMARY KEY,name	VARCHAR (100) ,user_id  INT ,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,date		VARCHAR (50) ,status		VARCHAR (100) ,start_time	VARCHAR (100) ,end_time	VARCHAR (100) ,total_time NUMERIC,comments	TEXT ")
            Call CreateTable("leave_view", "id serial PRIMARY KEY,name    VARCHAR (100) ,user_id  INT,empl_id VARCHAR (100) ,project_id INT ,project    	VARCHAR (100) ,process    	VARCHAR (100) ,sub_process    	VARCHAR (100) ,leave_type	VARCHAR (100) ,date		VARCHAR (50) ,start_date	VARCHAR (100) ,end_date	VARCHAR (100) ,leave_count	VARCHAR (100) ,leave_time	VARCHAR (100) ,comments	TEXT,leave_status	VARCHAR (100) , approver	VARCHAR (100) ,approver_comment	TEXT ")
            Call CreateTable("think_poll", "poll_id serial PRIMARY KEY,target_group VARCHAR (100),target VARCHAR (50), date VARCHAR (50),process_id INT,poll_title TEXT,poll_question TEXT,option_1	TEXT,option_2	TEXT,option_3	TEXT,option_4 TEXT,poll_status VARCHAR (10),viewed INT,replied INT,comment	TEXT,owner VARCHAR (100) ")
            Call CreateTable("think_poll_response", "date VARCHAR (50),poll_id INT,user_id INT,process_id INT,poll_title TEXT,poll_question	TEXT,poll_response	TEXT")
            Call CreateTable("think_notify", "notify_id serial PRIMARY KEY,date	VARCHAR (50),process_id INT,title TEXT,body TEXT,viewed INT,replied	INT,owner VARCHAR (100)")
            Call CreateTable("think_holiday", "id serial PRIMARY KEY,process_id INT,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,h_date VARCHAR (50),holiday_name VARCHAR (200)")
            Call CreateTable("activity_tracker", "id serial PRIMARY KEY,user_id INT,process_id INT,empl_id VARCHAR (50) ,empl_name VARCHAR (100) ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process  VARCHAR (100) ,app_name VARCHAR (100) ,app_title TEXT ,start_time	VARCHAR (100) ,end_time	VARCHAR (100),total_time	NUMERIC ")
            Call CreateTable("time_activity_user", "id serial PRIMARY KEY,date DATE,seq INT ,empl_id VARCHAR (50) ,empl_name VARCHAR (100) ,project VARCHAR (100) ,process VARCHAR (100) ,sub_process VARCHAR (100) ,bucket VARCHAR (100) ,activity  VARCHAR (100) ,sub_activity  VARCHAR (200) ,task	VARCHAR (200),upt VARCHAR (200),ex_lock INT,volume	INT,aid  INT,cmnt  INT,readme TEXT,status	VARCHAR (10),project_id INT")
            Call CreateTable("think_issue_log", "id serial PRIMARY KEY,user_id  INT,process_id INT,date VARCHAR (50),log_type VARCHAR (50),log_title TEXT,log_description TEXT,logr_desc TEXT,logr_solution TEXT,log_status VARCHAR (50)")
            Call CreateTable("think_error_log", "id serial PRIMARY KEY,user_id INT,process_id INT,date VARCHAR (50),error_form	VARCHAR (100),error_title VARCHAR (200),error_desc TEXT")
            Call CreateTable("think_activity_log", "id serial PRIMARY KEY,act_id VARCHAR (100),user_id INT,process_id  INT,date VARCHAR (50),form_name	VARCHAR (50),form_title VARCHAR(50),open_time VARCHAR (100),close_time VARCHAR(100)")
            Call CreateTable("think_change_log", "id serial PRIMARY KEY,user_id INT,process_id INT,date VARCHAR (50),pre_value	TEXT,post_value	TEXT")
            Call CreateTable("pass_change_audit", "id serial PRIMARY KEY,empl_id VARCHAR (200),date VARCHAR (50),pass TEXT")
        Catch ex As SqlException
            '      MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '        Dim msg As MsgBoxResult = MsgBox(ex.Message)


        End Try
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
    Private Sub TableDefaultValues()
        Dim conn As New pgConnect
        conn.AlterTable("project_details", "syslock_check", 1)

        Dim conn2 As New pgConnect
        conn2.AlterTable("project_details", "syslock_time", 10)

        Dim conn3 As New pgConnect
        conn3.AlterTable("project_details", "total_time_min", 540)

        Dim conn4 As New pgConnect
        conn4.AlterTable("project_details", "timeview_type", "'Default'")

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

            '  MsgBox(ex.Message)

            '    MsgBox(ex.Message)

            ' Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub
    Sub ProjectDefaultValues(Project As String, Process As String, SubProcess As String, Type As String, iOption As String)
        Try
            Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
            Dim Conn As New NpgsqlConnection(ConString)
            Conn.Open()
            Dim cmd As New NpgsqlCommand("INSERT INTO app_config (project,process,sub_process,type,option) VALUES (" & Project & "," & Process & "," & SubProcess & "," & Type & "," & iOption & ")", Conn)
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As SqlException

            ' MsgBox(ex.Message)

            '  Dim msg As MsgBoxResult = MsgBox(ex.Message)

        End Try
    End Sub
    Public Sub DBTables(List As Object)

        Try
            Dim lst As ListBox
            lst = List
            Dim ConString As String = "Server=" & ServerAddress & ";Port=" & ServerPort & ";Database=" & DatabaseName & ";User Id=" & DatabaseID & ";Password=" & DatabasePass & ";"
            Dim Conn As New NpgsqlConnection(ConString)
            Conn.Open()
            Dim str As String = "SELECT table_name FROm information_schema.tables WHERE table_schema ='public'"
            Dim comm As New NpgsqlCommand(str, Conn)
            Dim reader As NpgsqlDataReader = comm.ExecuteReader
            lst.Items.Clear()
            While reader.Read
                lst.Items.Add(reader("table_name").ToString)
            End While
            Conn.Close()
        Catch ex As SqlException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '  MsgBox(ex.Message)

            '   Dim msg As MsgBoxResult = MsgBox(ex.Message)

        Finally

        End Try
    End Sub 'Required
    Sub SettingConnStringRead()
        Dim DbDetails As String = My.Settings.ConnDetails
        Dim ValArr = DbDetails.Split(",")

        DatabaseName = Trim(ValArr(1))
        ServerAddress = Trim(ValArr(2))
        ServerPort = Trim(ValArr(3))
        DatabaseID = Trim(ValArr(4))
        ConnectionStatus = Trim(ValArr(5))
    End Sub
    Sub CreateConfigFile(Path As String, iServerAddress As String, iPort As String, iDatabaseName As String, iDatabaseId As String, iDatabasePass As String)

        Try

            Dim DBvar As New Encryption
            Dim FILE_NAME As String = Path & "\AppConfig.txt"
            'My.Computer.FileSystem.DeleteFile(FILE_NAME)
            File.Create(FILE_NAME).Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt("PostgreSQL")
            aryText(0) = DBvar.encr
            DBvar.Encrypt(iDatabaseName)
            aryText(1) = DBvar.encr
            DBvar.Encrypt(iServerAddress)
            aryText(2) = DBvar.encr
            DBvar.Encrypt(iPort)
            aryText(3) = DBvar.encr
            DBvar.Encrypt(iDatabaseId)
            aryText(4) = DBvar.encr
            DBvar.Encrypt(iDatabasePass)
            aryText(5) = DBvar.encr

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()

            '  Catch ex As NullReferenceException
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
    Public Function ConfigurationFileCheck()

        If Not System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt") Then
            If Not System.IO.File.Exists(Application.UserAppDataPath & "\AppConfig.txt") Then
                If Not System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt") Then
                    'If Not System.IO.File.Exists("\\10.229.73.29\data_timesheet\ThinkproLite" & "\AppConfig.txt") Then
                    Return False
                    'Else
                    'Call CreateConfigFile("\\10.229.73.29\data_timesheet\ThinkproLite" & "\AppConfig.txt", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
                    'Return True
                    'End If
                Else
                    Call CreateConfigFileToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
                    Return True
                End If
            Else
                Call CreateConfigFileToFile(Application.UserAppDataPath & "\AppConfig.txt", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
                Return True
            End If
        Else
            ConfFileToSettings(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
            Return True
        End If


    End Function 'Ok
    Public Sub CreateConfigFileToFile(ReadFilePath As String, CreateFilePath As String)

        Try
            'Read Conf File
            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines(ReadFilePath)
            Dim DatabaseType As String = enc.decrypt(lines(0))
            Dim DatabaseName As String = enc.decrypt(lines(1))
            Dim ServerAddress As String = enc.decrypt(lines(2))
            Dim ServerPort As String = enc.decrypt(lines(3))
            Dim DatabaseID As String = enc.decrypt(lines(4))
            Dim DatabasePass As String = enc.decrypt(lines(5))

            Dim i As Integer
            Dim aryText(6) As String

            enc.Encrypt(DatabaseType)
            aryText(0) = enc.encr
            enc.Encrypt(DatabaseName)
            aryText(1) = enc.encr
            enc.Encrypt(ServerAddress)
            aryText(2) = enc.encr
            enc.Encrypt(ServerPort)
            aryText(3) = enc.encr
            enc.Encrypt(DatabaseID)
            aryText(4) = enc.encr
            enc.Encrypt(DatabasePass)
            aryText(5) = enc.encr

            Dim objWriter As New System.IO.StreamWriter(CreateFilePath, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()

            Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
            My.Settings.ConnDetails = DbDetails
            My.Settings.Save()

        Catch ex As IO.IOException

            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub 'Final Required
    Public Sub CreateConfigFileFromData(CreateFilePath As String, DatabaseName As String, ServerAddress As String, ServerPort As String, DatabaseID As String, DatabasePass As String)

        Try
            'Read Conf File
            'System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            Dim enc As New Encryption
            Dim FolderPath As String = CreateFilePath & "\ThinkPro"
            Dim FileName As String = FolderPath & "\Appconfig.txt"


            If (Not System.IO.Directory.Exists(CreateFilePath & "\ThinkPro")) Then
                System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro")
            End If


            File.Create(FileName).Dispose()


            Dim i As Integer
            Dim aryText(6) As String

            enc.Encrypt("Postgres")
            aryText(0) = enc.encr
            enc.Encrypt(DatabaseName)
            aryText(1) = enc.encr
            enc.Encrypt(ServerAddress)
            aryText(2) = enc.encr
            enc.Encrypt(ServerPort)
            aryText(3) = enc.encr
            enc.Encrypt(DatabaseID)
            aryText(4) = enc.encr
            enc.Encrypt(DatabasePass)
            aryText(5) = enc.encr

            Dim objWriter As New System.IO.StreamWriter(FileName, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()

            Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
            My.Settings.ConnDetails = DbDetails
            My.Settings.Save()
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub 'Final Required
    Public Sub ConfFileToSettings(ReadFilePath As String)

        Try
            'Read Conf File
            Dim enc As New Encryption
            Dim lines() As String = System.IO.File.ReadAllLines(ReadFilePath)
            Dim DatabaseType As String = enc.decrypt(lines(0))
            Dim DatabaseName As String = enc.decrypt(lines(1))
            Dim ServerAddress As String = enc.decrypt(lines(2))
            Dim ServerPort As String = enc.decrypt(lines(3))
            Dim DatabaseID As String = enc.decrypt(lines(4))
            Dim DatabasePass As String = enc.decrypt(lines(5))
            Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
            My.Settings.ConnDetails = DbDetails
            My.Settings.Save()
        Catch ex As IO.IOException
            ' msg = MsgBox("error-ConfFileToSettings", vbInformation)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub 'Final Required
    Sub ConfigurationFileCreate()

        Try
            Dim FolderPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro"
            Dim FileName As String = FolderPath & "\Appconfig.txt"

            If (Not System.IO.Directory.Exists(FolderPath)) Then
                System.IO.Directory.CreateDirectory(FolderPath)
            End If
            File.Create(FileName).Dispose()
            Setup.Show()

        Catch ex As IO.IOException
            '  msg = MsgBox("Unable to save configuration file", vbInformation)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub 'ok
    Public Sub ProjectDefaultSettings(Project As String, Process As String, SubProcess As String, Type As String, iOption As String)


        Try
            Dim conn As New pgConnect
            Dim value As String = Project & "^" & Process & "^" & SubProcess & "^" & Type & "^" & iOption
            conn.InsertRecord("app_config", "project,process,sub_process,type,option", value)
        Catch ex As IO.IOException
            '  msg = MsgBox("Unable to create default settting for project", vbInformation, "oops!")
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try

    End Sub

    '=============================================================


    Public Function SetupInit()
        Dim enc As New Encryption
        Dim FolderPath As String = "C:\Users\side7001\Desktop\TPTest" & "\ThinkPro"
        Dim FileName As String = FolderPath & "\Appconfig.txt"

        'If (Not System.IO.Directory.Exists(FolderPath)) Then
        '    System.IO.Directory.CreateDirectory(FolderPath)
        '    File.Create(FileName).Dispose()
        'Else

        'End If
        Return False
    End Function


    Public Function ConfigFileCheck()
        If System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt") Then
            Return True
        Else
            If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt") Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    Public Function AppStartupConfigCheck()
        If System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt") Then
            ConfFileToSettings(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
            Return True
        Else
            Return False
        End If
    End Function


End Module
