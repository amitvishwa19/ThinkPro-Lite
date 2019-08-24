Imports Npgsql
Imports System.Data.SqlClient
Imports NpgsqlTypes

Public Class pgConnect

    'Connection to DB
    Public connection As NpgsqlConnection
    Public DataTable As New DataTable
    Public ItemCount As String = Nothing
    Public Count As Integer = Nothing
    Public AVG As Double = Nothing
    Public SUM As Double = Nothing

    Public Sub New()
        Connect()
    End Sub
    Public Sub Connect()

        Try
            Dim DbDetails As String = My.Settings.ConnDetails
            Dim ValArr = DbDetails.Split(",")

            connection = New NpgsqlConnection("Server=" & Trim(ValArr(2)) &
                                          ";Port=" & Trim(ValArr(3)) &
                                          ";Database=" & Trim(ValArr(1)) &
                                          ";User Id=" & Trim(ValArr(4)) &
                                          ";Password=" & Trim(ValArr(5)) & ";")

            connection.Open()



        Catch ex As IO.IOException
            '  Dim msg As MsgBoxResult
            'msg = MsgBox("Error while connectiong with database" & vbNewLine &
            '   "Error Message" & ex.Message, vbCritical)

            connection = Nothing
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub
    Public Function TableCount()
        Dim qry As String = "SELECT table_schema,table_name FROM information_schema.tables WHERE table_schema='public';"
        Dim cmd As New NpgsqlCommand(qry, connection)
        cmd.ExecuteNonQuery()
        Dim reader As NpgsqlDataReader = cmd.ExecuteReader
        While reader.Read
            Count += 1
        End While
        Return Count
        Count = Nothing
    End Function
    Public Function GetAVG(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = "") As NpgsqlDataReader



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

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            'AVG = cmd.ExecuteNonQuery()

            If IsDBNull(cmd.ExecuteScalar) Then
                AVG = 0
            Else
                AVG = cmd.ExecuteScalar
            End If
            Return cmd.ExecuteReader

        Catch ex As SqlException

            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If

        End Try

        Return Nothing



    End Function
    Public Function GetSUM(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = "") As NpgsqlDataReader



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

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            'AVG = cmd.ExecuteNonQuery()

            If IsDBNull(cmd.ExecuteScalar) Then
                SUM = 0
            Else
                SUM = cmd.ExecuteScalar
            End If
            Return cmd.ExecuteReader



        Catch ex As SqlException

            ' Dim msg As MsgBoxResult = MsgBox("GetRecordsCOUNT :" & ex.Message, vbCritical)
            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If

        End Try

        Return Nothing



    End Function
    Public Function GetRecordsCOUNT(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = "") As NpgsqlDataReader



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

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            ItemCount = cmd.ExecuteNonQuery()
            Return cmd.ExecuteReader



        Catch ex As IO.IOException

            ' Dim msg As MsgBoxResult = MsgBox("GetRecordsCOUNT :" & ex.Message, vbCritical)
            ConnClose()
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If

        End Try

        Return Nothing



    End Function
    Public Function GetRecords(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = "",
                                Optional groupBy As String = "") As NpgsqlDataReader

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

        'Check for groupBy condition
        If groupBy <> "" Then
            qry &= " GROUP BY " & groupBy
        End If

        qry &= ";"

        Try

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            Return cmd.ExecuteReader



        Catch ex As SqlException

            ' Dim msg As MsgBoxResult = MsgBox("GetRecords : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

        Return Nothing



    End Function
    Public Function GetRecordsLimit(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = "",
                                Optional groupBy As String = "",
                                Optional limit As String = "") As NpgsqlDataReader

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

        'Check for groupBy condition
        If groupBy <> "" Then
            qry &= " GROUP BY " & groupBy
        End If

        'Check for limit
        If limit <> "" Then
            qry &= " LIMIT " & limit
        End If


        qry &= ";"

        Try

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            Return cmd.ExecuteReader



        Catch ex As SqlException

            '  Dim msg As MsgBoxResult = MsgBox("GetRecords : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

        Return Nothing



    End Function
    Public Function GetRecordsGRID(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = ""
                                ) As NpgsqlDataReader

        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        Dim da As New NpgsqlDataAdapter


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

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            'cmd.ExecuteNonQuery()
            da.SelectCommand = cmd
            DataTable.Clear()
            da.Fill(DataTable)

        Catch ex As IO.IOException

            'Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

        Return Nothing



    End Function
    Public Function GetRecordsqryGRID(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = ""
                                ) As NpgsqlDataReader

        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        Dim da As New NpgsqlDataAdapter


        'Query string
        Dim qry As String = "select u.empl_id,u.first_name, u.last_name,ap.app_name,ua.application_consent,ua.supervisor_comment,ua.user_comment from user_application as ua inner join user_details as u on ua.user_id=u.user_id inner join applications as ap on ua.application_id  =ap.id"
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

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            'cmd.ExecuteNonQuery()
            da.SelectCommand = cmd
            DataTable.Clear()
            da.Fill(DataTable)

        Catch ex As SqlException

            '      Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

        Return Nothing



    End Function
    Public Function GetRecordsGRIDGROUP(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional groupBy As String = "",
                                Optional orderBy As String = ""
                                ) As NpgsqlDataReader

        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        Dim da As New NpgsqlDataAdapter


        'Query string
        Dim qry As String = "SELECT " & feild & " FROM " & table
        'Dim qry As String = "SELECT * FROM " & table & ";"

        'Check for where condition
        If where <> "" Then
            qry &= " WHERE " & where
        End If

        'Check for groupBy condition
        If groupBy <> "" Then
            qry &= " GROUP BY " & groupBy
        End If



        'Check for orderby condition
        If orderBy <> "" Then
            qry &= " ORDER BY " & orderBy
        End If




        qry &= ";"

        Try

            Dim cmd As New NpgsqlCommand(qry, connection)

            'Check for Values condition when "Where" exits
            Dim param = "value"
            If where <> "" Then
                If values <> "" Then
                    Dim valArr = values.Split("^")
                    For i = 0 To valArr.Length - 1
                        Dim paramTemp = "@" & param & i + 1
                        cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                        cmd.Parameters(i).Value = valArr(i)
                    Next
                End If
            End If

            'cmd.ExecuteNonQuery()
            da.SelectCommand = cmd
            DataTable.Clear()
            da.Fill(DataTable)

        Catch ex As IO.IOException

            Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

        Return Nothing



    End Function
    Public Function GetRelatedRecords(table1 As String, table2 As String,
                                     onfeild1 As String, onfeild2 As String,
                                     Optional feild As String = "*",
                                     Optional where As String = "",
                                     Optional orderBy As String = "") As NpgsqlDataReader

        'SELECT <feild> FROM <table1> INNER JOIN <Table2> ON <feild1>=<feild2> [WHERE <Condition>] [ORDER BY <ASC|DESC>]

        Dim qry As String = "SELECT " & feild & " FROM " & table1 & " INNER JOIN " & table2 & " ON " & onfeild1 & " = " & onfeild2

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
            Dim cmd As New NpgsqlCommand(qry, connection)
            Return cmd.ExecuteReader

            cmd.Dispose()
            ConnClose()

        Catch ex As SqlException

            '     Dim msg As MsgBoxResult = MsgBox("Error while fetching data from data table" & table1 & vbNewLine &
            '              "Query String: " & qry & vbNewLine &
            '     "Error Message" & ex.Message, vbCritical)

            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally

            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If

        End Try


        Return Nothing

    End Function
    Public Sub InsertRecord(table As String, feilds As String, values As Object)

        'INSERT INTO <table> (<feilds>) VALUES (<values>)

        Dim val_feild() As String = Split(feilds, "^")
        Dim val_value() As String = Split(values, "^")
        Dim qry As String



        Dim param = ""
        Dim paramTemp = "value"

        For i = 1 To val_value.Length

            If i = val_value.Length Then
                param = param & "@" & paramTemp & i
            Else
                param = param & "@" & paramTemp & i & ","
            End If

        Next

        qry = "INSERT INTO " & table & " (" & feilds & ") "
        qry &= " VALUES (" & param & ");"


        Dim cmd As New NpgsqlCommand(qry, connection)

        For i = 1 To val_value.Length

            Dim ival As String
            ival = NpgsqlDbType.Text

            param = "@" & paramTemp & i

            cmd.Parameters.Add(New NpgsqlParameter(param, ival))
            cmd.Parameters(i - 1).Value = val_value(i - 1)
        Next


        Try
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            '    Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            cmd.Dispose()
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try


    End Sub
    Public Sub InsertRecordTransfer(table As String, feilds As String, values As Object, id As String)

        'INSERT INTO <table> (<feilds>) VALUES (<values>)

        Dim val_feild() As String = Split(feilds, "^")
        Dim val_value() As String = Split(values, "^")
        Dim qry As String



        Dim param = ""
        Dim paramTemp = "value"

        For i = 1 To val_value.Length

            If i = val_value.Length Then
                param = param & "@" & paramTemp & i
            Else
                param = param & "@" & paramTemp & i & ","
            End If

        Next

        qry = "INSERT INTO " & table & " (" & feilds & ") "
        qry &= " VALUES (" & param & ");"


        Dim cmd As New NpgsqlCommand(qry, connection)

        For i = 1 To val_value.Length

            Dim ival As String
            ival = NpgsqlDbType.Text

            param = "@" & paramTemp & i

            cmd.Parameters.Add(New NpgsqlParameter(param, ival))
            cmd.Parameters(i - 1).Value = val_value(i - 1)
        Next


        Try
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            'Dim msg As MsgBoxResult = MsgBox("Error while inserting data into table" & table & "Data ID" & id & vbNewLine &
            '        "Query String: " & qry & vbNewLine &
            '       "Error Message" & ex.Message, vbCritical)
            cmd.Dispose()
            ConnClose()
        Finally
            cmd.Dispose()
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try


    End Sub
    Public Sub UpdateRecord(table As String, feild As String, values As String, Optional where As String = "")

        'UPDATE <table> SET <feild>=<value> WHERE  id=<id>
        Dim val_feild() As String = Split(feild, "^")
        Dim val_value() As String = Split(values, "^")





        Dim qry As String = "UPDATE " & table & " SET " & feild


        'Check for where condition
        If where <> "" Then
            qry &= " WHERE " & where
        End If

        Dim cmd As New NpgsqlCommand(qry, connection)


        Dim param = "value"
        Dim valArr = values.Split("^")
        For i = 0 To valArr.Length - 1
            Dim paramTemp = "@" & param & i + 1
            cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
            cmd.Parameters(i).Value = valArr(i)

        Next


        Try

            cmd.ExecuteNonQuery()

        Catch ex As SqlException

            '   Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            cmd.Dispose()
            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            cmd.Dispose()
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

    End Sub
    Public Sub DeleteRecord(table As String, values As String, Optional where As String = "")

        Dim qry As String = "DELETE FROM " & table

        'Check for where condition
        If where <> "" Then
            qry &= " WHERE " & where
        End If

        qry &= ";"

        Try
            Dim cmd As New NpgsqlCommand(qry, connection)

            Dim param = "value"
            Dim valArr = values.Split("^")
            For i = 0 To valArr.Length - 1
                Dim paramTemp = "@" & param & i + 1
                cmd.Parameters.Add(New NpgsqlParameter(paramTemp, NpgsqlDbType.Text))
                cmd.Parameters(i).Value = valArr(i)

            Next

            cmd.ExecuteNonQuery()

        Catch ex As SqlException

            '  Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            connection.Close()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try


    End Sub
    Public Sub CreateTable(tablename As String, tablequery As String)
        Dim sql As String = "CREATE TABLE IF NOT EXISTS " & tablename & " ( " & tablequery & " )"
        Try
            Dim cmd As New NpgsqlCommand(sql, connection)
            cmd.ExecuteNonQuery()
        Catch ex As SqlException

            '   Dim msg As MsgBoxResult = MsgBox("Error Message" & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
        Finally

        End Try

    End Sub
    Public Sub AlterTable(table, Column, DefaultValue)

        Dim qry As String = "ALTER TABLE " & table & " ALTER COLUMN " & Column & " set default " & DefaultValue & ";"




        Dim cmd As New NpgsqlCommand(qry, connection)

        Try

            cmd.ExecuteNonQuery()

        Catch ex As SqlException

            '   Dim msg As MsgBoxResult = MsgBox("Error Message : " & ex.Message, vbCritical)
            cmd.Dispose()
            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            cmd.Dispose()
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try

    End Sub
    Public Function TotalConn() As NpgsqlDataReader



        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        'Query string
        Dim qry As String = "select * from pg_stat_activity"
        'Dim qry As String = "SELECT * FROM " & table & ";"

        'Check for where condition


        qry &= ";"

        Try

            Dim cmd As New NpgsqlCommand(qry, connection)



            ItemCount = cmd.ExecuteNonQuery()
            Return cmd.ExecuteReader



        Catch ex As SqlException

            Dim msg As MsgBoxResult = MsgBox("GetRecordsCOUNT :" & ex.Message, vbCritical)
            ConnClose()
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If

        End Try

        Return Nothing



    End Function
    Public Sub ConnClose()
        connection.Close()
        If My.Settings.ConnPooling = True Then
            connection.ClearPool()
        End If
    End Sub
    Public Sub PoolClear()
        connection.ClearPool()
    End Sub

End Class
