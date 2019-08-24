Public Class WinActivityViewer

    Dim BS As New BindingSource

    Private Sub WinActivityViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call WinActivityViewerGrid()
    End Sub

    Sub WinActivityViewerGrid()

        Dim Var As New Encryption
        Var.Encrypt(ThinkManagement.EmplID)
        Dim Emp_id As String = Var.encr


        Dim FilDate As Date = Now
        Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
        Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")

        Dim conn As New pgConnect
        'Dim value As String = ThinkManagement.Project & "^" & ThinkManagement.Process & "^" & ThinkManagement.SubProcess & "^" & SDate & "^" & EDate
        'conn.GetRecordsGRID("activity_tracker", "name,date,app_name,app_title,start_time,end_time,total_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)

        Dim value As String = SDate & "^" & EDate
        conn.GetRecordsGRID("activity_tracker", "name,date,app_name,app_title,start_time,end_time,total_time", "date >=@value1 AND date <=@value2", value)

        WinActView.Columns.Clear()
        BS.DataSource = conn.DataTable
        WinActView.DataSource = BS
        ThinkManagement.gridformat(WinActView)
        WinActView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        With WinActView
            .Columns(0).HeaderCell.Value = "Name"
            .Columns(1).HeaderCell.Value = "Date"
            .Columns(2).HeaderCell.Value = "App Name"
            .Columns(3).HeaderCell.Value = "App Title"
            .Columns(4).HeaderCell.Value = "Start Time"
            .Columns(4).DefaultCellStyle.Format = "hh:mm tt"
            .Columns(5).HeaderCell.Value = "End Time"
            .Columns(5).DefaultCellStyle.Format = "hh:mm tt"
            .Columns(6).HeaderCell.Value = "Total Time"
        End With

        Call StatusSummary()

    End Sub

    Private Sub StatusSummary()
        Dim TTime As Integer


        For i As Integer = 0 To WinActView.RowCount - 1
            TTime += WinActView.Rows(i).Cells(6).Value
        Next


        lblTotalTime.Text = "Tiotal Time (Min) : " & TTime
       


    End Sub

    Public Sub WinActView_FilterStringChanged(sender As Object, e As EventArgs) Handles WinActView.FilterStringChanged
        BS.Filter = WinActView.FilterString
        WinActView.DataSource = BS
        Call StatusSummary()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim epp As New EppGridExport
        epp.EppGrdExport(WinActView, "Window Activity Viewer")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class