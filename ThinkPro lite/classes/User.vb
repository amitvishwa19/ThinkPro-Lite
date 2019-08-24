
Namespace User

    Public Class User

#Region "Variables"

        Public Property Name As String
        Private EmplId As String
        Private UserID As Integer
        Private ProcessID As Integer
        Private Project As String
        Private Process As String
        Private SubProcess As String
        Private TimeViewType As String


#End Region





        Sub AppData()

            'Dim conn As New pgConnect
            'Dim value As String = Home.MyProject & "^" & Home.MyProcess & "^" & Home.MySubProcess
            'Dim TVT As NpgsqlDataReader = conn.GetRecords("project_details", "timeview_type", "project=@value1 AND process=@value2 AND sub_process=@value3", value)
            'While TVT.Read
            '    Home.TimeViewType = TVT("timeview_type").ToString
            'End While

        End Sub


    End Class
End Namespace