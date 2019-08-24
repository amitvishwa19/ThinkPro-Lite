Public Class TeamView

    Dim BS As New BindingSource

    Private Sub TeamView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call TeamViewGrid()

        Dim timer As New System.Windows.Forms.Timer
        timer.Enabled = True
        timer.Interval = 5000
        timer.Start()
        AddHandler timer.Tick, AddressOf Timer_tick


    End Sub

    Private Sub TeamViewGrid()

        Dim Var As New Encryption
        Var.Encrypt(ThinkManagement.TM_EmplID)
        Dim Emp_id As String = Var.encr

        Dim FilDate As Date = Now
        Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
        Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")

        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
        conn.GetRecordsGRID("team_view", "name,activity,activity_type,start_time,in_time,out_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
        gridTeamView.Columns.Clear()

        BS.DataSource = conn.DataTable

        gridTeamView.DataSource = BS

        conn.DataTable.Columns.Add("Net Time")
        conn.DataTable.Columns.Add("Total In Time")
        gridTeamView.Columns("Net Time").DisplayIndex = 4
        AppFunctions.Grid_Format_Arternate(gridTeamView)
        gridTeamView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With gridTeamView
            .Columns(0).HeaderCell.Value = "User"
            .Columns(1).HeaderCell.Value = "Activity"
            .Columns(2).HeaderCell.Value = "Activity Status"
            .Columns(3).HeaderCell.Value = "Start Time"
            .Columns(3).DefaultCellStyle.Format = "hh:mm tt"
            '.Columns(4).HeaderCell.Value = "Start Time"
            .Columns(4).HeaderCell.Value = "In Time"
            '.Columns(6).HeaderCell.Value = "Out Time"
            '.Columns(7).HeaderCell.Value = "Volume"
            '.Columns(8).HeaderCell.Value = "Act. ID"
            '.Columns(9).HeaderCell.Value = "Comment"
        End With

        For i = 0 To gridTeamView.Rows.Count - 1

            '''''''''Net Activity Time
            Dim istart, iend, istart2, iend2 As Date
            Dim istart1, iend22 As String
            Dim SecondsDifference, SecondsDifference2 As Integer
            istart1 = gridTeamView.Rows(i).Cells(3).Value.ToString

            If istart1 <> "" Then
                istart = gridTeamView.Rows(i).Cells(3).Value
                iend = Now
                SecondsDifference = DateDiff(DateInterval.Second, istart, iend)
                gridTeamView.Rows(i).Cells(6).Value = Format(SecondsDifference / 60, "0") & " Min"
            End If
            '''''''''Total In Time
            iend22 = gridTeamView.Rows(i).Cells(5).Value.ToString
            If iend22 <> "" Then
                'Else
                istart2 = gridTeamView.Rows(i).Cells(4).Value
                iend2 = gridTeamView.Rows(i).Cells(5).Value
                SecondsDifference2 = DateDiff(DateInterval.Second, istart2, iend2)
                gridTeamView.Rows(i).Cells(7).Value = Format(SecondsDifference2 / 60, "0") & " Min"
            End If

        Next i

    End Sub

    Private Sub gridTeamView_RowPrePaint1(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles gridTeamView.RowPrePaint

        Try
            If Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "LoggedIn" Or Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Logged In" Then
                Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.CornflowerBlue
                Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.CornflowerBlue

            ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Break" Then
                Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.FromArgb(123, 104, 238)
                Me.gridTeamView.Rows(e.RowIndex).Cells("name").Style.BackColor = Color.FromArgb(123, 104, 238)

            ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "System Locked" Then
                Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.FromArgb(255, 99, 71)
                Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.FromArgb(255, 99, 71)

            ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Logged Out" Then
                Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.FromArgb(218, 112, 214)
                Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.FromArgb(218, 112, 214)

            ElseIf Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Value = "Active" Then
                Me.gridTeamView.Rows(e.RowIndex).Cells("Activity").Style.BackColor = Color.FromArgb(60, 179, 113)
                Me.gridTeamView.Rows(e.RowIndex).Cells("Name").Style.BackColor = Color.FromArgb(60, 179, 113)
            End If
        Catch ex As IO.IOException
            '  MsgBox(ex.ToString)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub Timer_tick(sender As Object, e As System.EventArgs)
        Try
            Dim iTopRow As Integer
            Dim iTopCol As Integer

            iTopRow = gridTeamView.FirstDisplayedScrollingRowIndex '// get Top row.
            iTopCol = gridTeamView.FirstDisplayedScrollingColumnIndex
            Call TeamViewGrid()
            gridTeamView.FirstDisplayedScrollingRowIndex = iTopRow
            gridTeamView.FirstDisplayedScrollingColumnIndex = iTopCol


            Call StatusSummary()
            'Dim itotusr, iactive As Integer
            'itotusr = lbltotalUsers.Text
            'iactive = lblActive.Text
            'lbluti.Text = Format(iactive / itotusr * 100, "0.0") & " %"

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub StatusSummary()
        Dim iActive, iLock, iBreak, iLoogedIn, iLoggedOut As Integer


        For i As Integer = 0 To gridTeamView.RowCount - 1

            If gridTeamView.Rows(i).Cells(1).Value = "Active" Then
                iActive += 1
            End If

            If gridTeamView.Rows(i).Cells(1).Value = "System Locked" Then
                iLock += 1
            End If

            If gridTeamView.Rows(i).Cells(1).Value = "Break" Then
                iBreak += 1
            End If

            If gridTeamView.Rows(i).Cells(1).Value = "LoggedIn" Then
                iLoogedIn += 1
            End If

            If gridTeamView.Rows(i).Cells(1).Value = "Logged Out" Then
                iLoggedOut += 1
            End If

        Next

        TotalUsers.Text = "Total Users : " & gridTeamView.Rows.Count
        Active.Text = "Active : " & iActive
        Locked.Text = "Locked : " & iLock
        Break.Text = "Break : " & iBreak
        LoggedIn.Text = "Logged In : " & iLoogedIn
        LoggedOut.Text = "Logged Out : " & iLoggedOut


    End Sub

    Public Sub gridTeamView_FilterStringChanged(sender As Object, e As EventArgs) Handles gridTeamView.FilterStringChanged
        BS.Filter = gridTeamView.FilterString
        gridTeamView.DataSource = BS
    End Sub

    Private Sub gridTeamView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridTeamView.CellContentClick

    End Sub
End Class