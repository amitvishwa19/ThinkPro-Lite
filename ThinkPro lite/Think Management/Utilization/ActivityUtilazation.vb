Public Class ActivityUtilazation

    Private Sub ActivityUtilazation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call UtilizationGrid()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#Region "Utilization"

    Dim totalmin As Double = 0.0
    Dim totalhr As Double = 0.0
    Dim totalvolm As Integer = 0

    Public IRow As String = Nothing 'For Grid Row selection
    Dim UtilizationType As String = "Activity" ' On selection activity,subactivity,task level
    Public UserFilter As String = Nothing

    Dim BS As New BindingSource

    Private Sub UtilizationGrid()

        Try
            Dim Var As New Encryption
            Var.Encrypt(My.Settings.EmplID)
            Dim Emp_id As String = Var.encr



            Dim FilDate As Date = Now
            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")


            Dim conn As New pgConnect
            Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
            Dim valueuser As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate & "^" & UserFilter

            If UserFilter <> Nothing Then
                If UtilizationType = "Activity" Then
                    conn.GetRecordsGRIDGROUP("time_view", "activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "activity") 'AND date >=@value4 AND date <=@value5
                ElseIf UtilizationType = "SubActivity" Then
                    conn.GetRecordsGRIDGROUP("time_view", "sub_activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "sub_activity") 'AND date >=@value4 AND date <=@value5
                ElseIf UtilizationType = "Task" Then
                    conn.GetRecordsGRIDGROUP("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5 AND empl_id =@value6", valueuser, "task") 'AND date >=@value4 AND date <=@value5
                End If

            Else
                If UtilizationType = "Activity" Then
                    conn.GetRecordsGRIDGROUP("time_view", "activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "activity") 'AND date >=@value4 AND date <=@value5
                ElseIf UtilizationType = "SubActivity" Then
                    conn.GetRecordsGRIDGROUP("time_view", "sub_activity,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "sub_activity") 'AND date >=@value4 AND date <=@value5
                ElseIf UtilizationType = "Task" Then
                    conn.GetRecordsGRIDGROUP("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date<=@value5", value, "task") 'AND date >=@value4 AND date <=@value5
                End If

            End If

            gridUtilization.Columns.Clear()
            conn.DataTable.Columns.Add("UPT")
            conn.DataTable.Columns.Add("Utilization-FTE")
            conn.DataTable.Columns.Add("Utilization-%")

            BS.DataSource = conn.DataTable
            gridUtilization.DataSource = BS


            With gridUtilization
                .Columns(0).HeaderCell.Value = "Activity"
                .Columns(1).HeaderCell.Value = "Total Time(Min)"
                .Columns(2).HeaderCell.Value = "Total Volume"
            End With
            AppFunctions.Grid_Format_Arternate(gridUtilization)
            gridUtilization.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Call utilizationCalculation()



            For i = 0 To gridUtilization.Rows.Count - 1
                Dim iTime, iCount As Integer
                iTime = gridUtilization.Rows(i).Cells(1).Value
                iCount = gridUtilization.Rows(i).Cells(2).Value
                gridUtilization.Rows(i).Cells(3).Value = Format(iTime / iCount, "0.0") '----------UPT
                gridUtilization.Rows(i).Cells(4).Value = Format(iTime / 540, "0.0") '----------Utilization
                gridUtilization.Rows(i).Cells(5).Value = Format(iTime / totalmin * 100, "0") & "%" '----------UPT
            Next

            For i = 0 To gridUtilization.Rows.Count - 1
                If gridUtilization.Rows(i).Cells(3).Value = "Infinity" Then
                    gridUtilization.Rows(i).Cells(3).Value = "N/A"
                End If
                If gridUtilization.Rows(i).Cells(3).Value = "NaN" Then
                    gridUtilization.Rows(i).Cells(3).Value = "N/A"
                End If
            Next

            totalmin = 0.0
            totalhr = 0.0
            totalvolm = 0

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Sub utilizationCalculation()

        For i As Integer = 0 To gridUtilization.RowCount - 1
            totalmin += gridUtilization.Rows(i).Cells(1).Value
            totalvolm += gridUtilization.Rows(i).Cells(2).Value

        Next

        totalTimeMin.Text = "Total Time (Min): " & totalmin
        TotalTimeHr.Text = "Total Time (Hrs) : " & Format(totalmin / 60, "0.0")
        TotalVol.Text = "Total Vol : " & totalvolm
        TotalFTE.Text = "Utilization (FTE) : " & Format(totalmin / 540, "0.00")
    End Sub

    Private Sub ActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActivityToolStripMenuItem1.Click
        UtilizationType = "Activity"
        Call UtilizationGrid()
    End Sub

    Private Sub SubActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SubActivityToolStripMenuItem1.Click
        UtilizationType = "SubActivity"
        Call UtilizationGrid()
    End Sub

    Private Sub TaskToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TaskToolStripMenuItem1.Click
        UtilizationType = "Task"
        Call UtilizationGrid()
    End Sub



    Private Sub ShowAllDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllDataToolStripMenuItem.Click
        UserFilter = Nothing
        BS.Filter = ""
        Call UtilizationGrid()
    End Sub

    Public Sub gridUtilization_FilterStringChanged(sender As Object, e As EventArgs) Handles gridUtilization.FilterStringChanged
        BS.Filter = gridUtilization.FilterString
        gridUtilization.DataSource = BS
        Call utilizationCalculation()
    End Sub

#End Region

    Private Sub ExportGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportGridToolStripMenuItem.Click
        Dim epp As New EppGridExport
        epp.EppGrdExport(gridUtilization, "Utilization")
    End Sub

End Class