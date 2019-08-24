Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class TimeSummary
    Public SummaryClickedDate As Date = TimeView.SummaryClickedDate
    Public SummaryClickedItem As String = TimeView.SummaryClickedItem
    Private Sub TimeSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.UseWaitCursor = False
        Me.Text = "Time summary " & Format(SummaryClickedDate, "dd-MMM-yyyy")

        Call TimeSummary()
        Call TotalBreak()


    End Sub

    Sub Reserve()

        Dim Enc As New Encryption

        For i = 0 To DataGridView1.RowCount - 1
            For j = 0 To DataGridView1.ColumnCount - 1
                'If DataGridView1.Rows(i).Cells(j).Value <> Nothing Then


                If DataGridView1.Rows(i).Cells(j).Value.ToString <> "" Then
                    Dim inp = DataGridView1.Rows(i).Cells(j).Value
                    If Enc.CheckEncryprion(inp) = True Then
                        DataGridView1.Rows(i).Cells(j).Value = Enc.decrypt(inp)
                    Else
                        DataGridView1.Rows(i).Cells(j).Value = inp
                        'End If
                    End If

                End If
            Next
        Next


    End Sub

    Public Sub TimeSummary()

        Try
            Dim Var As New Encryption
            Var.Encrypt(My.Settings.EmplID)
            Dim Emp_id As String = Var.encr

            Dim FilDate As Date = SummaryClickedDate
            Dim IDate As String = Format(FilDate, "dd-MMM-yy")


            Dim Conn As New pgConnect
            Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & Emp_id & "^" & IDate
            Conn.GetRecordsGRID("time_view", "id,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND date =@value5", value, "id ASC")
            DataGridView1.Columns.Clear()
            BindingSource1.DataSource = Conn.DataTable


            DataGridView1.DataSource = BindingSource1

            With DataGridView1
                .Columns(0).HeaderCell.Value = "ID"
                .Columns(1).HeaderCell.Value = "Activity"
                .Columns(2).HeaderCell.Value = "Sub Activity"
                .Columns(3).HeaderCell.Value = "Task"
                .Columns(4).HeaderCell.Value = "Start Time"
                .Columns(5).HeaderCell.Value = "End Time"
                .Columns(6).HeaderCell.Value = "Total Time (Min)"
                .Columns(7).HeaderCell.Value = "Volume"
                .Columns(8).HeaderCell.Value = "Act. ID"
                .Columns(9).HeaderCell.Value = "Comment"
            End With
            Call AppFunctions.Grid_Format_Arternate(DataGridView1)
            Call TimeSummaryTotal()
        Catch ex As IO.IOException

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
        End Try

    End Sub

    Sub TimeSummaryTotal()
        Try
            Dim Ttime As Double = Nothing

            For i = 0 To DataGridView1.Rows.Count - 1
                Ttime += DataGridView1.Item(6, i).Value
            Next

            StatusTotalTime.Text = "Total Time :- " & Ttime & " Min "

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub TotalBreak()
        Try
            Dim Var As New Encryption
            Var.Encrypt(My.Settings.EmplID)
            Dim Emp_id As String = Var.encr

            Dim FilDate As Date = SummaryClickedDate
            Dim IDate As String = Format(FilDate, "dd-MMM-yy")


            Dim Conn As New pgConnect
            Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & Emp_id & "^" & IDate
            Conn.GetRecordsGRID("break_time_log", "status,start_time,end_time,total_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND empl_id =@value4 AND date =@value5", value, "id DESC")
            DataGridView2.Columns.Clear()
            DataGridView2.DataSource = Conn.DataTable

            Call AppFunctions.Grid_Format_Arternate(DataGridView2)
            'DataGridView2.AutoResizeColumns()
            'DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            With DataGridView2
                .Columns(1).HeaderCell.Value = "Start Time"
                .Columns(1).DefaultCellStyle.Format = "hh:mm tt"
                .Columns(2).HeaderCell.Value = "End Time"
                .Columns(2).DefaultCellStyle.Format = "hh:mm tt"
                .Columns(3).HeaderCell.Value = "Total Time"
            End With

            Call BreakSummaryTotal()

        Catch ex As IO.IOException

            '    Dim lg As New ErrorLogger
            '      lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            ' Catch ex As IO.IOExceptions
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Sub BreakSummaryTotal()
        Try
            Dim BreakTtime As Double = Nothing
            Dim LockTtime As Double = Nothing
            Dim SwitchkTtime As Double = Nothing

            For i = 0 To DataGridView2.Rows.Count - 1

                If DataGridView2.Item(0, i).Value = "Break" Then
                    BreakTtime += DataGridView2.Item(3, i).Value
                End If

                If DataGridView2.Item(0, i).Value = "System Locked" Then
                    LockTtime += DataGridView2.Item(3, i).Value
                End If

                If DataGridView2.Item(0, i).Value = "Switch User" Then
                    SwitchkTtime += DataGridView2.Item(3, i).Value
                End If


            Next

            statusTotalBreak.Text = "Total Break :- " & BreakTtime & " Min "
            statusTotalLock.Text = "Total Lock :- " & LockTtime & " Min "
            statusTotalSwitch.Text = "Total Switch :- " & SwitchkTtime & " Min "

            ' Catch ex As NullReferenceException

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        DataGridView1.Rows(i).Selected = True
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            DataGridView2.Rows(i).Selected = True
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub EditVolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditVolumeToolStripMenuItem.Click

        Dim i As Integer = DataGridView1.CurrentRow.Index
        Dim ival As Integer = DataGridView1.Item(0, i).Value
        Dim ivol = DataGridView1.Item(7, i).Value
        Dim iact = DataGridView1.Item(8, i).Value
        Dim icmnt = DataGridView1.Item(9, i).Value

        SummaryEdit.ActID = ival

        If Not IsDBNull(DataGridView1.Item(7, i).Value) Then
            SummaryEdit.iVol = DataGridView1.Item(7, i).Value
        End If
        
        If Not IsDBNull(DataGridView1.Item(8, i).Value) Then
            SummaryEdit.iActivity = DataGridView1.Item(8, i).Value
        End If

        If Not IsDBNull(DataGridView1.Item(9, i).Value) Then
            SummaryEdit.iCmnt = DataGridView1.Item(9, i).Value
        End If


        SummaryEdit.Show()

    End Sub

    Private Sub DataGridView1_FilterStringChanged(sender As Object, e As EventArgs)
        BindingSource1.Filter = DataGridView1.FilterString
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.L AndAlso e.Control AndAlso e.Shift = True Then
            BindingSource1.Filter = ""
            'lbl_dgvcount.Text = dgv_search_res.Rows.Count
        ElseIf e.KeyCode = Keys.C AndAlso e.Control = True Then
            Clipboard.Clear()
            Dim CopyText As String = String.Empty
            For Each ocell In DataGridView1.SelectedRows
                CopyText = CopyText & ocell.Cells("dValue").Value & vbCrLf
            Next
            Try
                Clipboard.SetText(CopyText)
            Catch
            End Try
        End If
    End Sub


End Class