Imports Npgsql
Public Class DataRetention



    Function test()
        Return "Test"
    End Function

    Function soft_del_days()

        Dim conn As New pgConnect
        ''Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "soft_delete_days", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        If dr.HasRows Then
            While dr.Read
                Return dr("soft_delete_days")
            End While
        Else
            Return 0
        End If
        Return 0
    End Function

    Function hard_del_days()
        Dim conn As New pgConnect
        Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess
        Dim dr As NpgsqlDataReader = conn.GetRecords("project_details", "hard_delete_days", "project =@value1 AND process =@value2 AND sub_process =@value3", value)

        If dr.HasRows Then
            While dr.Read
                Return dr("hard_delete_days")
            End While
        Else
            Return 0
        End If
        Return 0
    End Function

    Function soft_delete_date(inpdate As Date)

        Try
            Dim inp_date As Date = inpdate

            If soft_del_days() = 0 Then
                Return inpdate
            Else
                Dim new_date As Date = DateTime.Now.AddDays(-soft_del_days())
                Return new_date
            End If
        Catch ex As IO.IOException
            Return inpdate
        End Try

    End Function

    Function soft_delete_date_check(idate As Date)

        Dim endday As Date = Format(idate, "dd-MMM-yy")
        Dim softdeletedate As Date = Format(soft_delete_date(Now), "dd-MMM-yy")

        If endday < softdeletedate Then
            Return False
        Else
            Return True
        End If

    End Function
End Class
