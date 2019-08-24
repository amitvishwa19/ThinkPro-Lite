Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Module DBconnect
    Public pgMyConn As New NpgsqlConnection
    Public sqlMyConn As New SqlConnection


#Region "PG Connection strings"

    Public db_name As String = "ThinkPro"
    Public db_address As String = "localhost"
    Public db_port As String = "5432"
    Public db_id As String = "postgres"
    Public db_pass As String = "admin1234"

#End Region
    
    Sub app_conn_details()
        Dim dr As SqlDataReader
        Dim sql As String = "SELECT * FROM app_setting WHERE default_connection='True'"
        Dim mycmd As SqlCommand = New SqlCommand(sql, sqlMyConn)
        dr = mycmd.ExecuteReader

        While dr.Read
            db_name = dr("database_name").ToString
            db_address = dr("server_address").ToString
            db_port = dr("server_port").ToString
            db_id = dr("server_id").ToString
            db_pass = dr("server_pass").ToString
        End While
        sqlMyConn.Close()

    End Sub

    Sub pgDBConn()
        textfileReader()
        pgMyConn.ConnectionString = "Server=" & db_address & ";Port=" & db_port & ";Database=" & db_name & ";User Id=" & db_id & ";Password=" & db_pass & ";"
        pgMyConn.Open()
    End Sub

    Sub SQLDBConn()

        sqlMyConn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AppDB.mdf;Integrated Security=True"
        sqlMyConn.Open()

    End Sub

#Region "Old ThinkPro Access Connection"

    ''=======================================================================================Old DB Connect
    Public DBConn, DBSConn, PDBConn, MPDBConn, CNnwind, CHConn, KPIDBConn As New OleDb.OleDbConnection
    Public SQLMConn As New SqlConnection


    Public DBaccess As OleDbDataReader
    Public strsql As String
    Public DBSource As String
    Public DBPAth, DBMain, MDBpath As String
    Public PDBsource, PDBPath, PDBMain As String
    Public MPDBsource, MPDBPath, MPDBMain As String
    Public KPIDBsource, KPIDBPath, KPIDBMain As String
    Public SQLDBsource, SQLDBPath, SQLDBMain As String
    ''=======================================================================================Old DB Connect

    Sub ConnectDB() '''''''''''MAin DB Connection
        Try
            DBSource = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="

            ' MDBpath = My.Settings.TPMasterDBpath & "\Error Log\"
            'DBPAth = My.Settings.TPMasterDBpath & "\MasterDB\ThinkPro.accdb"

            'Dim path As String
            'path = textfileReader()

            'MDBpath = path & "\Error Log\"
            'DBPAth = path & "\MasterDB\ThinkPro.accdb"


            DBMain = DBSource & DBPAth & ";Jet OLEDB:Database Password=Computer@1981"
            DBConn.ConnectionString = DBMain
            DBConn.Open()
        Catch ex As Exception

        End Try
    End Sub

    Sub ConnectProcessDB()


        Try
            'PDBsource = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            'PDBPath = My.Settings.TPMasterDBpath & "\ProcessDB\NL\ThinkPro.accdb"

            'Dim path As String
            'path = textfileReader()
            'PDBPath = Path & "\ProcessDB\NL\ThinkPro.accdb"

            PDBMain = PDBsource & PDBPath & ";Jet OLEDB:Database Password=Computer@1981"
            PDBConn.ConnectionString = PDBMain
            PDBConn.Open()
        Catch ex As Exception

        End Try
    End Sub

    Sub ConnectProcessMDB()
        'MsgBox(TimeManagement.lblDBpath.Text)
        Try
            'MPDBsource = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            ''DBPAth = "C:\Users\vishwa\Desktop\Think Pro\Server\ThinkPro.accdb"
            'MPDBPath = ThinkManagement.lblDBpath.Text
            'MPDBMain = MPDBsource & MPDBPath & ";Jet OLEDB:Database Password=Computer@1981"
            'MPDBConn.ConnectionString = MPDBMain
            'MPDBConn.Open()
        Catch ex As Exception

        End Try
    End Sub

    Sub ConnectKPI()
        Try
            'KPIDBsource = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            'KPIDBPath = ThinkManagement.Testdbpath
            'KPIDBMain = KPIDBsource & KPIDBPath & ";Jet OLEDB:Database Password=Computer@1981"
            'KPIDBConn.ConnectionString = KPIDBMain
            'KPIDBConn.Open()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub chat()
        'Try
        '    Dim DBChSource As String
        '    Dim DBChPAth As String
        '    Dim DBCHMain As String

        '    DBChSource = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        '    'DBChPAth = "\\10.229.73.50\data_timesheet\Think Pro\Think Pro\Production\MasterDB\ThinkChat.accdb"
        '    DBChPAth = "0.229.73.50\Pacific\NEW_Time Sheet\MasterDB\ThinkChat.accdb"
        '    DBCHMain = DBChSource & DBChPAth & ";Jet OLEDB:Database Password=Computer@1981"
        '    CHConn.ConnectionString = DBCHMain

        '    CHConn.Open()
        'Catch ex As Exception
        '    CHConn.Close()

        'End Try
    End Sub

    

#End Region

    Sub textfileReader()
        Try
            Dim sr As New StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\TPAppConfig.txt")
 
            'My.Settings.TPMasterDBpath = sr.ReadToEnd()
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Thinkpro App Config file not found" & vbNewLine &
                       "Make sure directory < " & My.Computer.FileSystem.SpecialDirectories.MyDocuments & " > contains the app config file" & vbNewLine & vbNewLine &
                       "Application will close now", vbCritical, "oops....App Config file missing")
            Application.Exit()
        End Try


    End Sub

End Module
