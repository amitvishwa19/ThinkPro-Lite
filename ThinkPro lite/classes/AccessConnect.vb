Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class AccessConnect
    Private MDBConnection As OleDbConnection
    Private pDBConnection As OleDbConnection

    Public Sub New()

        ConnDB()
    End Sub


    Public Sub ConnDB()
        Dim DBSource As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        Dim DBPAth As String = My.Settings.AccessDBPath
        Dim str As String = ";Jet OLEDB:Database Password=" & "Computer@1981" & ""

        Try
            Dim msg As MsgBoxResult
            If DBSource = Nothing And DBPAth = Nothing And str = Nothing Then
                msg = MsgBox("Input paramenter is null value")
                Exit Sub
            End If

        Catch ex As IO.IOException

            pDBConnection.Open()

            '   Catch ex As Exception

            pDBConnection = Nothing
            Dim msg4 As MsgBoxResult = MsgBox("Error while connectiong with database" & vbNewLine & "Error Message" & vbCritical)

        End Try


    End Sub

    Public Sub connectionClose()
        PDBConnection.Close()
    End Sub
    'Public Sub InsertRecordMaster(table As String, feilds As String, values As String)

    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "INSERT INTO " & table & " (" & feilds & ") VALUES (" & values & ");"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

    '        MsgBox("Error while inserting data into table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    '    Dim msg As MsgBoxResult = MsgBox("Error while inserting data into table" &
    '             "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub
    'Public Sub InsertRecordProcess(table As String, feilds As String, values As String)

    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "INSERT INTO " & table & " (" & feilds & ") VALUES (" & values & ");"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception


    '        MsgBox("Error while inserting data into table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    '  Dim msg As MsgBoxResult = MsgBox("Error while inserting data into table" &
    '     "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub

    'Public Sub InsertRecordMaster(table As String, feilds As String, values As String)

    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "INSERT INTO " & table & " (" & feilds & ") VALUES (" & values & ");"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

  '        MsgBox("Error while inserting data into table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
          '    Dim msg As MsgBoxResult = MsgBox("Error while inserting data into table" &
            '             "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub
    'Public Sub InsertRecordProcess(table As String, feilds As String, values As String)

    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "INSERT INTO " & table & " (" & feilds & ") VALUES (" & values & ");"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

  '    Catch ex As Exception


   '        MsgBox("Error while inserting data into table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
           '  Dim msg As MsgBoxResult = MsgBox("Error while inserting data into table" &
            '     "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub

    Public Function GetRecord(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional orderBy As String = "") As OleDbDataReader

        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        'Query string
        Dim qry As String = "SELECT " & feild & " FROM " & table
        'Dim qry As String = "SELECT * FROM " & table & ";"

        'Check for where condition
        If where <> "" Then
            qry &= " WHERE " & where
        End If

        'Check for orderby condition
        If orderBy <> "" Then
            qry &= " ORDER BY " & orderBy
        End If

        qry &= ";"

        Try

            Dim cmd As New OleDbCommand(qry, pDBConnection)
            Return cmd.ExecuteReader

        Catch ex As SQlException

            MsgBox("Error while fetching data from data table" & vbNewLine &
                   "Query String: " & qry & vbNewLine &
                   "Error Message" & ex.Message, vbCritical)

        End Try

        Return Nothing



    End Function

    'Public Function GetRecordsProcess(table As String,
    '                            Optional feild As String = "*",
    '                            Optional where As String = "",
    '                            Optional orderBy As String = "") As OleDbDataReader

    '    'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

    '    'Query string
    '    Dim qry As String = "SELECT " & feild & " FROM " & table
    '    'Dim qry As String = "SELECT * FROM " & table & ";"

    '    'Check for where condition
    '    If where <> "" Then
    '        qry &= " WHERE " & where
    '    End If

    '    'Check for orderby condition
    '    If orderBy <> "" Then
    '        qry &= " ORDER BY " & orderBy
    '    End If

    '    qry &= ";"

    '    Try

    '        Dim cmd As New OleDbCommand(qry, PDBConnection)
    '        Return cmd.ExecuteReader

    '    Catch ex As Exception

    '        MsgBox("Error while fetching data from data table" & vbNewLine &
    '               "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    ' Dim msg As MsgBoxResult = MsgBox("Error while fetching data from data table" &
    '   "Error Message" & ex.Message, vbCritical)

    '    End Try

    '    Return Nothing



    'End Function
    'Public Sub DeleteRecordMaster(table As String, Optional where As String = "")
    
    '    Dim qry As String = "DELETE FROM " & table

    '    'Check for where condition
    '    If where <> "" Then
    '        qry &= " WHERE " & where
    '    End If

    '    qry &= ";"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception


    '        MsgBox("Error while deleting  record from table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)

    '    End Try
    '        Msg = MessageBox.Show("Error while deleting  record from table" &
    '              "Error Message" & ex.Message, "Info", MessageBoxButtons.OK)


    'End Sub
    'Public Sub AddColumnMaster(table As String, column As String, type As String, length As Integer)

    '    ', type As String, length As Integer
    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "ALTER TABLE " & table & " ADD COLUMN " & column & " " & type & " (" & length & ")"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

    '        MsgBox("Error while inserting table column into table " & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    '    Dim msg As MsgBoxResult = MsgBox("Error while inserting table column into table " &
    '   "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub
    'Public Sub AddColumnProcess(table As String, column As String, type As String, length As Integer)

    '    ', type As String, length As Integer
    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "ALTER TABLE " & table & " ADD COLUMN " & column & " " & type & ""

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

    '        MsgBox("Error while inserting table column into table " & table & vbNewLine &
    '               "Query String: " & qry & vbNewLine &
    '     Dim msg As MsgBoxResult = MsgBox("Error while inserting table column into table " &
    '          "Error Message" & ex.Message, vbCritical)

    '    End Try
    'End Sub
    'Public Sub AddTableMaster(table As String, tablefeild As String)

    '    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    '    'CREATE TABLE nocolumn
    '    Dim qry As String = "CREATE TABLE " & table & "(" & TableFeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()
    '        MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As Exception
    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    'CREATE TABLE nocolumn
    'Dim qry As String = "CREATE TABLE " & table & "(" & TableFeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()
    '        Dim msg As MsgBoxResult = MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As SqlException

    '        MsgBox("Error while creating table" & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    '    Dim msg1 As MsgBoxResult = MsgBox("Error while creating table" & vbNewLine &

    '    End Try

    'End Sub
    'Public Sub AddTableProcess(table As String, tablefeild As String)

    '    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    '    'CREATE TABLE nocolumn
    '    Dim qry As String = "CREATE TABLE " & table & "(" & tablefeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, PDBConnection)
    '        cmd.ExecuteNonQuery()
    '        MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As Exception
    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    'CREATE TABLE nocolumn
    'Dim qry As String = "CREATE TABLE " & table & "(" & tablefeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, PDBConnection)
    '        cmd.ExecuteNonQuery()
    '        Dim msg As MsgBoxResult = MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As Exception

    '        MsgBox("Error while creating table" & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    '   Dim msg1 As MsgBoxResult = MsgBox("Error while creating table" & vbNewLine &
    '     "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub

    'Public Function GetRecordsProcess(table As String,
    '                            Optional feild As String = "*",
    '                            Optional where As String = "",
    '                            Optional orderBy As String = "") As OleDbDataReader

    '    'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

    '    'Query string
    '    Dim qry As String = "SELECT " & feild & " FROM " & table
    '    'Dim qry As String = "SELECT * FROM " & table & ";"

    '    'Check for where condition
    '    If where <> "" Then
    '        qry &= " WHERE " & where
    '    End If

    '    'Check for orderby condition
    '    If orderBy <> "" Then
    '        qry &= " ORDER BY " & orderBy
    '    End If

    '    qry &= ";"

    '    Try

    '        Dim cmd As New OleDbCommand(qry, PDBConnection)
    '        Return cmd.ExecuteReader

    '    Catch ex As Exception

 '        MsgBox("Error while fetching data from data table" & vbNewLine &
    '               "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
    

    '    End Try

    '    Return Nothing



    'End Function
    
    '    Dim qry As String = "DELETE FROM " & table

    '    'Check for where condition
    '    If where <> "" Then
    '        qry &= " WHERE " & where
    '    End If

    '    qry &= ";"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

   '    Catch ex As Exception


   '        MsgBox("Error while deleting  record from table" & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)

  '    End Try
           '        Msg = MessageBox.Show("Error while deleting  record from table" &
            '              "Error Message" & ex.Message, "Info", MessageBoxButtons.OK)


    'End Sub
    'Public Sub AddColumnMaster(table As String, column As String, type As String, length As Integer)

    '    ', type As String, length As Integer
    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "ALTER TABLE " & table & " ADD COLUMN " & column & " " & type & " (" & length & ")"

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

   '        MsgBox("Error while inserting table column into table " & table & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
           '    Dim msg As MsgBoxResult = MsgBox("Error while inserting table column into table " &
            '   "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub
    'Public Sub AddColumnProcess(table As String, column As String, type As String, length As Integer)

    '    ', type As String, length As Integer
    '    'INSERT INTO <table> (<feilds>) VALUES (<values>)

    '    Dim qry As String = "ALTER TABLE " & table & " ADD COLUMN " & column & " " & type & ""

    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception

   '        MsgBox("Error while inserting table column into table " & table & vbNewLine &
    '               "Query String: " & qry & vbNewLine &
    '              "Error Message" & ex.Message, vbCritical)
           '     Dim msg As MsgBoxResult = MsgBox("Error while inserting table column into table " &
            '          "Error Message" & ex.Message, vbCritical)

    '    End Try
    'End Sub
    'Public Sub AddTableMaster(table As String, tablefeild As String)

    '    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    '    'CREATE TABLE nocolumn
    '    Dim qry As String = "CREATE TABLE " & table & "(" & TableFeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, MDBConnection)
    '        cmd.ExecuteNonQuery()
    '        MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As Exception
       'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
        'CREATE TABLE nocolumn
 '        "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
           '    Dim msg1 As MsgBoxResult = MsgBox("Error while creating table" & vbNewLine &
            '          "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub
    'Public Sub AddTableProcess(table As String, tablefeild As String)

   '    'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
    '    'CREATE TABLE nocolumn
    '    Dim qry As String = "CREATE TABLE " & table & "(" & tablefeild & ")"
    '    Try
    '        Dim cmd As New OleDbCommand(qry, PDBConnection)
    '        cmd.ExecuteNonQuery()
    '        MsgBox("Table- " & table & " created successfully", vbInformation, "Success")
    '    Catch ex As Exception
       'Dim qry As String = "CREATE TABLE IF NOT EXISTS " & table
        'CREATE TABLE nocolumn
          '        MsgBox("Error while creating table" & vbNewLine &
    '                "Query String: " & qry & vbNewLine &
    '               "Error Message" & ex.Message, vbCritical)
           '   Dim msg1 As MsgBoxResult = MsgBox("Error while creating table" & vbNewLine &
            '     "Error Message" & ex.Message, vbCritical)

    '    End Try

    'End Sub

   

    Public Sub masterconnClose()
        MDBConnection.Close()
    End Sub

End Class
