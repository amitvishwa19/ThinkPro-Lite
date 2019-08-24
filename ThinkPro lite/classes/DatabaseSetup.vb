Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class DatabaseSetup
    'Connection to DB
    Private connection As NpgsqlConnection
    Private AccessConn As OleDbConnection

    Public Sub New()
        PGConnect()
        AccessConnect()
        MsgBox("Public sub new")
    End Sub

    Public Sub PGConnect()

        Try
            connection = New NpgsqlConnection("Server=" & Old_Setup.txtServerAddress.Text &
                                          ";Port=" & Old_Setup.txtServerPort.Text &
                                          ";Database=" & Old_Setup.txtDatabaseName.Text &
                                          ";User Id=" & Old_Setup.txtDatabaseID.Text &
                                          ";Password=" & Old_Setup.txtDatabasePass.Text & ";")
            connection.Open()
        Catch ex As Exception
            MsgBox("Error while connectiong with database" & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)
            connection = Nothing
        End Try

    End Sub

    Public Sub PGConnectionClose()
        connection.Close()
    End Sub

    Public Sub AccessConnect()
        MsgBox("Access Connect proc")

        Try
            AccessConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Old_Setup.txtServerAddress.Text & ";Jet OLEDB:Database Password=" & Old_Setup.txtDatabasePass.Text & ""
            AccessConn.Open()
            MsgBox(AccessConn.State)
        Catch ex As Exception
            MsgBox("Error while connectiong with access database" & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)
            connection = Nothing
        End Try

    End Sub

    Public Sub AccessConnectionClose()
        AccessConn.Close()
    End Sub

    Public Function PGAllTables()

        Dim qry As String = "SELECT table_name FROM information_schema.tables WHERE table_schema='public';"

        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            Return cmd.ExecuteReader

        Catch ex As Exception
            MsgBox("Error while fetching data from data table" & vbNewLine &
                   "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)
        End Try


        Return Nothing

    End Function

    Public Function AccessAllTables()

        Dim qry As String = "SELECT * FROM TimeView "

        Try
            Dim cmd As New OleDbCommand(qry, AccessConn)
            Return cmd.ExecuteReader

        Catch ex As Exception
            MsgBox("Error while fetching data from data table" & vbNewLine &
                   "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)
        End Try


        Return Nothing
    End Function

    Public Function TableGridView()

        Dim qry As String = "select * From " & Old_Setup.DBTree.SelectedNode.Text & ";"

        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            Return cmd.ExecuteReader

        Catch ex As Exception
            MsgBox("Error while fetching data from data table" & vbNewLine &
                   "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)
        End Try

        Return Nothing
    End Function

    Public Sub AddTable(table As String)

        'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
        'CREATE TABLE nocolumn
        Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table & "(id BIGSERIAL PRIMARY KEY)"
        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            cmd.ExecuteNonQuery()
            MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
        Catch ex As Exception

            MsgBox("Error while creating table" & vbNewLine &
                    "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try

    End Sub

    Public Sub AddColumn(table As String, column As String, type As String, length As Integer)

        ', type As String, length As Integer
        'INSERT INTO <table> (<feilds>) VALUES (<values>)

        Dim qry As String = "ALTER TABLE " & table & " ADD COLUMN " & column & " " & type & " (" & length & ");"

        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception

            MsgBox("Error while inserting data into table" & table & vbNewLine &
                    "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try

    End Sub

    Public Sub DeleteColumn(table As String, column As String)
        'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
        'CREATE TABLE nocolumn
        Dim qry As String = "ALTER TABLE " & table & " DROP COLUMN " & column & " ;"
        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            cmd.ExecuteNonQuery()
            MsgBox("Column- " & column & " deleted successfully", vbInformation, "Deleted")
        Catch ex As Exception

            MsgBox("Error while creating table" & vbNewLine &
                    "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try

    End Sub

    Public Sub sqlquerywid(qry As String)
        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            cmd.ExecuteNonQuery()
            MsgBox("Query executed successfully", vbInformation, "Success")
        Catch ex As Exception

            MsgBox("Error while creating table" & vbNewLine &
                    "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try

    End Sub

    Public Sub DeleteTable(table As String)
        Dim qry As String = "DROP TABLE IF EXISTS " & table & " ;"

        Try
            Dim cmd As New NpgsqlCommand(qry, connection)
            cmd.ExecuteNonQuery()
            MsgBox(table & " Deleted successfully")
        Catch ex As Exception

            MsgBox("Error while inserting data into table" & table & vbNewLine &
                    "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try
    End Sub

End Class
