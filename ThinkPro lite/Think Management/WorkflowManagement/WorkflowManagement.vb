Imports System.IO
Imports Npgsql
Public Class WorkflowManagement

    Dim User As String() = {"A", "b", "c", "d"}
    Dim Time As String() = {"500", "480", "540", "530"}


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub WorkflowManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadChart()
    End Sub


    Sub LoadChart()
        Chart.BackGradientStyle = DataVisualization.Charting.GradientStyle.None

        Chart.Series.Add("User")
        Chart.Series("User").Points.Add()
        Chart.Series.Add("Total Time")
        Chart.Series("User").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart.Series("Total Time").ChartType = DataVisualization.Charting.SeriesChartType.Line

        For i = 0 To User.Length
            Chart.Series("User").Points.AddXY(User(i).ToString, Time(i).ToString)

        Next
    End Sub



End Class