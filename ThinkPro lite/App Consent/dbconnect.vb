Imports Npgsql
Imports System.Data.SqlClient
Imports NpgsqlTypes
Public Class dbconnect

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

            connection = New NpgsqlConnection("Server=" & My.Settings.db_ip &
                                          ";Port=" & My.Settings.db_port &
                                          ";Database=" & My.Settings.db_name &
                                          ";User Id=" & My.Settings.db_id &
                                          ";Password=" & My.Settings.db_pass & ";")

            connection.Open()



        Catch ex As IO.IOException
            '  MsgBox("Error while connectiong with database" & vbNewLine &
            '   "Error Message" & ex.Message, vbCritical)
            connection = Nothing
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

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

            '  MsgBox("GetRecords : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
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
            '   MsgBox(ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
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

            '   MsgBox("Error Message : " & ex.Message, vbCritical)
            cmd.Dispose()
            ConnClose()
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
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

            '       MsgBox("Error Message : " & ex.Message, vbCritical)
            connection.Close()
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If connection.State = ConnectionState.Open Then
                ConnClose()
            End If
        End Try


    End Sub

    Public Function GetRecordsGRID(table As String,
                                Optional feild As String = "*",
                                Optional where As String = "",
                                Optional values As String = "",
                                Optional orderBy As String = ""
                                ) As NpgsqlDataReader

        'SELECT <feild> FROM <table> [WHERE <condition>] ORDER BY [feild] ASC|DESC 

        Dim da As New NpgsqlDataAdapter


        'Query string
        Dim qry As String = "select u.empl_id,u.first_name, u.last_name,ap.app_name,ua.application_consent,ua.supervisor_comment,ua.user_comment from user_application as ua inner join users as u on ua.user_id=u.id inner join applications as ap on ua.application_id  =ap.id"
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

            '   MsgBox("Error Message : " & ex.Message, vbCritical)
            If connection.State = ConnectionState.Open Then
                ConnClose()
                Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
            End If
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
