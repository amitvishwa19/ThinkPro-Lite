Imports System.IO
Imports Npgsql
Public Class IssueLogger
    Dim ProjectID As Integer = My.Settings.ProjectID
    Dim UserID As Integer = My.Settings.UserID

    Private Sub IssueLogger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call IssueLoggerGrid()
    End Sub

    Sub IssueLoggerGrid()
        Try
            Dim conn As New pgConnect

            If Home.TP_UserRole = "Associate" Then
                Dim value As String = UserID & "^" & ProjectID
                conn.GetRecordsGRID("think_logger", "log_id,log_date,log_type,log_title,log_description,log_solution,log_status", "user_id =@value1 AND process_id =@value2", value, "log_id DESC")

            ElseIf Home.TP_UserRole = "Process Lead" Then
                Dim value As String = ProjectID
                conn.GetRecordsGRID("think_logger", "log_id,log_date,log_type,log_title,log_description,log_solution,log_status", "process_id =@value1", value, "log_id DESC")

            Else
                conn.GetRecordsGRID("think_logger", "log_id,log_date,log_type,log_title,log_description,log_solution,log_status", , , "log_id DESC")
            End If


            gridIssueLogger.Columns.Clear()
            BindingSource1.DataSource = conn.DataTable
            gridIssueLogger.DataSource = BindingSource1
            gridformat(gridIssueLogger)
            'gridIssueLogger.Columns(0).Visible = False
            With gridIssueLogger
                .Columns(0).HeaderCell.Value = "Log Id"
                .Columns(1).HeaderCell.Value = "Date"
                .Columns(2).HeaderCell.Value = "Log Type"
                .Columns(3).HeaderCell.Value = "Log Title"
                .Columns(4).HeaderCell.Value = "Log Description"
                .Columns(5).HeaderCell.Value = "Log Solution"
                .Columns(6).HeaderCell.Value = "Log Status"
            End With
            gridIssueLogger.Columns(0).Visible = False
        Catch ex As IO.IOException

        End Try
    End Sub

    Private Sub gridformat(DGV)

        Dim DG As DataGridView
        DG = DGV
        DG.AllowUserToAddRows = False
        DG.DefaultCellStyle.Font = New Font("Verdana", 7, FontStyle.Regular, GraphicsUnit.Point)
        gridIssueLogger.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.ClearSelection()
        DG.DefaultCellStyle.SelectionForeColor = DG.DefaultCellStyle.ForeColor
        DG.DefaultCellStyle.BackColor = Color.Linen
        DG.EnableHeadersVisualStyles = True
        DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'DG.Columns("ID").Visible = False
        'DG.AutoResizeColumns()


    End Sub

    Public Sub gridShiftCom_FilterStringChanged(sender As Object, e As EventArgs) Handles gridIssueLogger.FilterStringChanged
        BindingSource1.Filter = gridIssueLogger.FilterString
        gridIssueLogger.DataSource = BindingSource1
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridIssueLogger.CellClick
        Dim i As Integer = gridIssueLogger.CurrentRow.Index
        gridIssueLogger.Rows(i).Selected = True
    End Sub

    Private Sub NewIssueLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewIssueLogToolStripMenuItem.Click
        NewIssueLog.Show()
        NewIssueLog.InputType = "NewLog"
    End Sub

    Private Sub CloneLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneLogToolStripMenuItem.Click
        NewIssueLog.Show()
        NewIssueLog.InputType = "LogClone"
        Dim i As Integer = gridIssueLogger.CurrentRow.Index
        NewIssueLog.LogID = gridIssueLogger.Item(0, i).Value

        NewIssueLog.cmbLogType.Text = gridIssueLogger.Item(2, i).Value
        NewIssueLog.txtlogTitle.Text = gridIssueLogger.Item(3, i).Value
        NewIssueLog.txtLogDesc.Text = gridIssueLogger.Item(4, i).Value
        NewIssueLog.txtLogSol.Text = ""

    End Sub
End Class