Public Class ThinkProPoll
    Dim BS As New BindingSource
    Public IRow As String = Nothing 'For Grid Row selection

    Private Sub ThinkProPoll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ThinkPollLoad()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#Region "Think Poll"

    Public Sub ThinkPollLoad()

        Try
            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")
            Dim Conn As New pgConnect

            Dim value As String = ThinkManagement.ProjectID & "^" & SDate & "^" & EDate
            Conn.GetRecordsGRID("think_poll", "poll_id,poll_title,poll_question,option_1,option_2,option_3,option_4,poll_status,owner,date", "process_id =@value1 AND date >=@value2 AND date <=@value3", value)
            ThinkPollgrid.Columns.Clear()


            BS.DataSource = Conn.DataTable
            ThinkPollgrid.DataSource = BS

            With ThinkPollgrid
                .Columns(0).HeaderCell.Value = "ID"
                .Columns(1).HeaderCell.Value = "Poll Title"
                .Columns(2).HeaderCell.Value = "Poll Question"
                .Columns(3).HeaderCell.Value = "Option 1"
                .Columns(4).HeaderCell.Value = "Option 2"
                .Columns(5).HeaderCell.Value = "Option 3"
                .Columns(6).HeaderCell.Value = "Option 4"
                .Columns(7).HeaderCell.Value = "Poll Status"
                .Columns(8).HeaderCell.Value = "Poll Owner"
                .Columns(9).HeaderCell.Value = "Poll Date"
            End With

            ThinkManagement.gridformat(ThinkPollgrid)
            ThinkPollgrid.Columns(0).Visible = False


        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")


        End Try


    End Sub

    Private Sub ThinkPollgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ThinkPollgrid.CellClick

        Dim i As Integer = ThinkPollgrid.CurrentRow.Index
        ThinkPollgrid.Rows(i).Selected = True
        IRow = ThinkPollgrid.Item(0, i).Value
    End Sub

    Private Sub CreatePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePollToolStripMenuItem.Click
        CreatePoll.Show()
    End Sub

    Private Sub ActivatePollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivatePollToolStripMenuItem.Click
        Try
            If IRow = Nothing Then
                Dim msg As MsgBoxResult = MsgBox("Please select one poll", vbInformation, "No item selected")
            Else
                Dim conn As New pgConnect
                Dim Value As String = "Active" & "^" & IRow
                conn.UpdateRecord("think_poll", "poll_status = @value1", Value, "poll_id=@value2")
                Dim msg1 As MsgBoxResult = MsgBox("Poll activated successfully", vbInformation, "Activation Success")
                Call ThinkPollLoad()
                IRow = Nothing
            End If
        Catch ex As IO.IOException

            'Dim msg As MsgBoxResult = MsgBox(ex.Message)

            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    'Private Sub NewPollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewPollToolStripMenuItem.Click
    '    CreatePoll.Show()
    '    CreatePoll.PollCreateFrom = "FromTree"
    'End Sub

    Public Sub ThinkPollgrid_FilterStringChanged(sender As Object, e As EventArgs)
        BS.Filter = ThinkPollgrid.FilterString
        ThinkPollgrid.DataSource = BS
    End Sub

    Private Sub ReloadPollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadPollToolStripMenuItem.Click

        Dim i As Integer = ThinkPollgrid.CurrentRow.Index
        Dim ival As Integer = ThinkPollgrid.Item(0, i).Value
        CreatePoll.Show()

        CreatePoll.txtPollTitle.Text = ThinkPollgrid.Item(1, i).Value.ToString
        CreatePoll.TxtQuestion.Text = ThinkPollgrid.Item(2, i).Value.ToString
        CreatePoll.txtoption1.Text = ThinkPollgrid.Item(3, i).Value.ToString
        CreatePoll.txtoption2.Text = ThinkPollgrid.Item(4, i).Value.ToString
        CreatePoll.txtoption3.Text = ThinkPollgrid.Item(5, i).Value.ToString
        CreatePoll.txtoption4.Text = ThinkPollgrid.Item(6, i).Value.ToString


    End Sub

#End Region

    Private Sub ThinkProPoll_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class