Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.ComponentModel
Public Class DataTransfer
    Dim TableName As String
    Dim BS As New BindingSource

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MenDatabsePathOption_Click(sender As Object, e As EventArgs) Handles MenDatabsePathOption.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        'Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "AccessDB Files|*.accdb;"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            StatusDatabasePath.Text = "Database Path :- " & fd.FileName
            My.Settings.AccessDBPath = fd.FileName
            My.Settings.Save()
        End If
    End Sub


    Private Sub TimeViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeViewToolStripMenuItem.Click
        TableName = "TimeView"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        DataGridView.Columns.Clear()
        BS.DataSource = table
        DataGridView.DataSource = BS
        AppFunctions.Grid_Format_Arternate(DataGridView)
        StatusCount.Text = "Total Count :- " & DataGridView.RowCount
    End Sub

    Private Sub TeamViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeamViewToolStripMenuItem.Click
        TableName = "TeamView"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        DataGridView.Columns.Clear()
        BS.DataSource = table
        DataGridView.DataSource = BS
        AppFunctions.Grid_Format_Arternate(DataGridView)
        StatusCount.Text = "Total Count :- " & DataGridView.RowCount
    End Sub

    Private Sub BreakLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BreakLogsToolStripMenuItem.Click
        TableName = "TimeLog"
        Dim Conn As New AccessConnect
        Dim reader As OleDbDataReader = Conn.GetRecord(TableName, "*")
        Dim table As New DataTable
        table.Load(reader)
        DataGridView.Columns.Clear()
        BS.DataSource = table
        DataGridView.DataSource = BS
        AppFunctions.Grid_Format_Arternate(DataGridView)
        StatusCount.Text = "Total Count :- " & DataGridView.RowCount
    End Sub

    Public Sub DataGridView_FilterStringChanged(sender As Object, e As EventArgs) Handles DataGridView.FilterStringChanged
        BS.Filter = DataGridView.FilterString
        DataGridView.DataSource = BS
        StatusCount.Text = "Total Count :- " & DataGridView.RowCount
    End Sub

    Private Sub FitColumnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FitColumnsToolStripMenuItem.Click
        DataGridView.AutoResizeColumns()
    End Sub

    Sub DataTransfer_timeView()

        Try
            Dim i As Integer
            Dim ival As Integer
            Dim var As New Encryption

            Dim con As New pgConnect
            Dim reader As NpgsqlDataReader = con.GetRecords("time_view", "*", , , "id desc limit 1")
            While reader.Read
                ival = reader("id")
            End While

            Dim Emplid As String = Nothing
            Dim startt As String = Nothing
            Dim endt As String = Nothing
            Dim tottime As Double = Nothing
            Dim volume As String = Nothing
            Dim actid As String = Nothing
            Dim comment As String = Nothing
            Dim Trandate As Date = Nothing

            If TableName = "TimeView" Then
                For i = 0 To DataGridView.RowCount - 1
                    Dim id As String = DataGridView.Rows(i).Cells(0).Value.ToString
                    Dim itemID As Integer = ival + i + 1

                    Dim sdate As Date = DataGridView.Rows(i).Cells(4).Value
                    Dim EntDate As String = Format(sdate, "dd-MMM-yy")
                    var.Encrypt(DataGridView.Rows(i).Cells(6).Value.ToString)
                    Emplid = var.encr
                    Dim name As String = DataGridView.Rows(i).Cells(5).Value.ToString
                    Dim project As String = DataGridView.Rows(i).Cells(1).Value.ToString
                    Dim process As String = DataGridView.Rows(i).Cells(2).Value.ToString
                    Dim subprocess As String = DataGridView.Rows(i).Cells(3).Value.ToString
                    Dim activity As String = DataGridView.Rows(i).Cells(9).Value.ToString
                    Dim sub_activity As String = DataGridView.Rows(i).Cells(10).Value.ToString
                    Dim task As String = DataGridView.Rows(i).Cells(11).Value.ToString
                    startt = DataGridView.Rows(i).Cells(13).Value.ToString
                    endt = DataGridView.Rows(i).Cells(14).Value.ToString
                    tottime = DataGridView.Rows(i).Cells(15).Value.ToString
                    volume = DataGridView.Rows(i).Cells(16).Value.ToString
                    actid = DataGridView.Rows(i).Cells(17).Value.ToString
                    comment = DataGridView.Rows(i).Cells(19).Value.ToString
                    Dim sdded As String = "Data Transfer"

                    Dim conn As New pgConnect
                    Dim value As String = EntDate & "^" & Emplid & "^" & name & "^" & project & "^" & process & "^" & subprocess & "^" & activity & "^" & sub_activity & "^" & task & "^" & startt & "^" & endt & "^" & tottime & "^" & volume & "^" & actid & "^" & comment & "^" & sdded
                    conn.InsertRecordTransfer("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment,added_by", value, id)

                    statusProgress.Text = "Transferring : " & i + 1

                Next
            End If
        Catch ex As IO.IOException
            ' Dim msg As MsgBoxResult
            'msg = MsgBox("Error while transfering data" & vbNewLine & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub MenTransfer_Click(sender As Object, e As EventArgs) Handles MenTransfer.Click

        Dim BGW As New BackgroundWorker
      
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True

        AddHandler BGW.DoWork, AddressOf WorkerDoWork
        AddHandler BGW.ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler BGW.RunWorkerCompleted, AddressOf WorkerCompleted
        BGW.RunWorkerAsync()
    End Sub

    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Call DataTransfer_timeView()
    End Sub

    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        ' I did something!
    End Sub

    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' I'm done!
    End Sub


    Private Sub DataTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatusDatabasePath.Text = My.Settings.AccessDBPath
    End Sub
End Class