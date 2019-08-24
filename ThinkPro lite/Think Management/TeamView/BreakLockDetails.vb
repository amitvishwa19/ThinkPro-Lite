Public Class BreakLockDetails

    Dim BS As New BindingSource

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub BreakDetails()

        Try
            Dim Var As New Encryption
            Var.Encrypt(My.Settings.EmplID)
            Dim Emp_id As String = Var.encr


            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")


            Dim Conn As New pgConnect
            Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
            Conn.GetRecordsGRID("break_time_log", "name,status,start_time,end_time,total_time", "project =@value1 AND process =@value2 AND sub_process =@value3  AND date >=@value4  AND date <=@value5", value)
            gridBreakDetails.Columns.Clear()
            BS.DataSource = Conn.DataTable
            gridBreakDetails.DataSource = BS


            AppFunctions.Grid_Format_Arternate(gridBreakDetails)
            gridBreakDetails.AutoResizeColumns()
            gridBreakDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            With gridBreakDetails
                '.Columns(0).HeaderCell.Value = "ID"
                .Columns(0).HeaderCell.Value = "Name"
                .Columns(1).HeaderCell.Value = "System Status"
                .Columns(2).HeaderCell.Value = "Start Time"
                .Columns(3).HeaderCell.Value = "End Time"
                .Columns(4).HeaderCell.Value = "Total Time"
            End With


            Call TotalCalculation()
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub
    Private Sub BreakLockDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call BreakDetails()
    End Sub
    Public Sub gridBreakDetails_FilterStringChanged(sender As Object, e As EventArgs) Handles gridBreakDetails.FilterStringChanged
        BS.Filter = gridBreakDetails.FilterString
        gridBreakDetails.DataSource = BS
        Call TotalCalculation()
    End Sub
    Sub TotalCalculation()
        Dim Totalmin As Double

        For i As Integer = 0 To gridBreakDetails.RowCount - 1
            Totalmin += gridBreakDetails.Rows(i).Cells(4).Value
            '        totalvolm += gridUtilization.Rows(i).Cells(2).Value

        Next

        Dim NewLabel As Label = New Label
        NewLabel.BackColor = Color.Transparent
        NewLabel.Text = "Total Time : " & Format(Totalmin, "0.00")
        StatusStrip1.Items.Add(New ToolStripControlHost(NewLabel))

    End Sub
    Private Sub ExportGridToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem1.Click
        Dim epp As New EppGridExport
        epp.EppGrdExport(gridBreakDetails, "Break-Lock Details")
    End Sub
End Class