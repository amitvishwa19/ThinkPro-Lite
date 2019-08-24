Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Vml
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class MasterUpdate

    Dim UserFilter As String = Nothing
    Public IRow As String = Nothing 'For Grid Row selection
    Dim BS As New BindingSource

    Private Sub MasterUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserFilter = ThinkManagement.UserFilter
        Call MasterUpdateGrid()
    End Sub

    Private Sub gridMasterUpdate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridMasterUpdate.CellClick
        Dim i As Integer = gridMasterUpdate.CurrentRow.Index
        gridMasterUpdate.Rows(i).Selected = True
        IRow = gridMasterUpdate.Item(0, i).Value
    End Sub

    Public Sub MasterUpdateGrid()
        Dim Var As New Encryption
        Dim sysfn As New SysFunctions

        Var.Encrypt(My.Settings.EmplID)
        Dim Emp_id As String = Var.encr


        ''Dim ndate As String
        ''ndate = Format(sysfn.soft_delete_date(ThinkManagement.DateStart.Value), "dd-MMM-yy")

        Dim FilDate As Date = Now
        Dim SDate As String = Format(sysfn.soft_delete_date(ThinkManagement.DateStart.Value), "dd-MMM-yy")
        Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")

        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
        Dim valueuser As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate & "^" & UserFilter

        If UserFilter <> Nothing Then

            conn.GetRecordsGRID("time_view", "id,date,name,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5 AND empl_id=@value6", valueuser, "id")
        Else
            conn.GetRecordsGRID("time_view", "id,date,name,activity,sub_activity,task,start_time,end_time,total_time,volume,act_id,comment", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value, "id")
        End If

        gridMasterUpdate.Columns.Clear()
        BS.DataSource = conn.DataTable
        gridMasterUpdate.DataSource = BS
        AppFunctions.Grid_Format_Arternate(gridMasterUpdate)

        With gridMasterUpdate
            .Columns(0).HeaderCell.Value = "ID"
            .Columns(1).HeaderCell.Value = "Date"
            .Columns(2).HeaderCell.Value = "Name"
            .Columns(3).HeaderCell.Value = "Activity"
            .Columns(4).HeaderCell.Value = "Sub Activity"
            .Columns(5).HeaderCell.Value = "Task"
            .Columns(6).HeaderCell.Value = "Start Time"
            .Columns(7).HeaderCell.Value = "End Time"
            .Columns(8).HeaderCell.Value = "Total Time"
            .Columns(9).HeaderCell.Value = "Volume"
            .Columns(10).HeaderCell.Value = "Act.ID"
            .Columns(11).HeaderCell.Value = "Comment"
            '.Columns(9).HeaderCell.Value = "Comment"
            '.Columns(9).HeaderCell.Value = "Comment"
        End With
        gridMasterUpdate.Columns(0).Visible = False

        Call TotalSummary()

    End Sub

    Sub TotalSummary()
        Dim iTotalMin As Integer = Nothing
        Dim iTotalVolume As Integer = Nothing

        For i As Integer = 0 To gridMasterUpdate.RowCount - 1
            iTotalMin += gridMasterUpdate.Rows(i).Cells(8).Value
            iTotalVolume += gridMasterUpdate.Rows(i).Cells(9).Value
        Next

        lblTotalMin.Text = "Total Time (M) : " & iTotalMin
        lblTotalVol.Text = "Total Volume : " & iTotalVolume

    End Sub

    Private Sub DeleteActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteActivityToolStripMenuItem1.Click
        Try
            Dim conn As New pgConnect
            Dim Value As String = IRow
            conn.DeleteRecord("time_view", Value, "id =@value1")
            Dim msg As MsgBoxResult = MsgBox("Activity deleted Successfully", vbInformation, "Activity Deleted")
            Call MasterUpdateGrid()
        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UpdateActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateActivityToolStripMenuItem.Click
        Dim i As Integer = gridMasterUpdate.CurrentRow.Index
        Dim ival As Integer = gridMasterUpdate.Item(0, i).Value
        MasterTimeUpdate.txtUser.Enabled = False

        MasterTimeUpdate.Show()
        MasterTimeUpdate.cmdSubmit.Text = "Update"
        MasterTimeUpdate.ActID = ival

        If Not IsDBNull(gridMasterUpdate.Item(2, i).Value) Then
            MasterTimeUpdate.txtUser.Text = gridMasterUpdate.Item(2, i).Value
        End If

        If Not IsDBNull(gridMasterUpdate.Item(3, i).Value) Then
            MasterTimeUpdate.Activity = gridMasterUpdate.Item(3, i).Value
        End If
        If Not IsDBNull(gridMasterUpdate.Item(4, i).Value) Then
            MasterTimeUpdate.SubActivity = gridMasterUpdate.Item(4, i).Value
        End If
        If Not IsDBNull(gridMasterUpdate.Item(5, i).Value) Then
            MasterTimeUpdate.Task = gridMasterUpdate.Item(5, i).Value
        End If

        If Not IsDBNull(gridMasterUpdate.Item(8, i).Value) Then
            MasterTimeUpdate.txtTotalTime.Text = gridMasterUpdate.Item(8, i).Value
        End If

        If Not IsDBNull(gridMasterUpdate.Item(9, i).Value) Then
            MasterTimeUpdate.txtVolume.Text = gridMasterUpdate.Item(9, i).Value
        End If

        If Not IsDBNull(gridMasterUpdate.Item(10, i).Value) Then
            MasterTimeUpdate.txtActID.Text = gridMasterUpdate.Item(10, i).Value
        End If

        If Not IsDBNull(gridMasterUpdate.Item(11, i).Value) Then
            MasterTimeUpdate.txtcmnt.Text = gridMasterUpdate.Item(11, i).Value
        End If

        Call MasterTimeUpdate.AfterLoad()

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim epp As New EppGridExport
        epp.EppGrdExport(gridMasterUpdate, "Master Update")

    End Sub

    Public Sub gridMasterUpdate_FilterStringChanged(sender As Object, e As EventArgs) Handles gridMasterUpdate.FilterStringChanged
        BS.Filter = gridMasterUpdate.FilterString
        gridMasterUpdate.DataSource = BS
        Call TotalSummary()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ShowAllDataToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowAllDataToolStripMenuItem1.Click
        UserFilter = Nothing
        Call MasterUpdateGrid()
    End Sub

    Private Sub AddActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddActivityToolStripMenuItem.Click
        MasterTimeUpdate.Show()
        MasterTimeUpdate.cmdSubmit.Text = "Add Activity"
    End Sub

    Private Sub ExportGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportGridToolStripMenuItem.Click
        Dim export As New EppGridExport
        export.EppGrdExport(gridMasterUpdate, "Time Details")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DownloadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        Dim msg As MsgBoxResult
        Try
            Dim FBD As New FolderBrowserDialog
            If (FBD.ShowDialog() = DialogResult.OK) Then
                Dim xlPackage As New ExcelPackage()
                Dim oBook As ExcelWorkbook = xlPackage.Workbook
                Dim ws As ExcelWorksheet = oBook.Worksheets.Add("TimeView Upload")
                Dim savepath As String

                ws.Cells.AutoFitColumns()
                ws.Cells(1, 1).Value = "Date"
                ws.Cells(1, 2).Value = "Empl. ID"
                ws.Cells(1, 3).Value = "Name"
                ws.Cells(1, 4).Value = "Activity"
                ws.Cells(1, 5).Value = "Sub Activity"
                ws.Cells(1, 6).Value = "Task"
                ws.Cells(1, 7).Value = "Total Time"
                ws.Cells(1, 8).Value = "Volume"
                ws.Cells(1, 9).Value = "Act. ID"
                ws.Cells(1, 10).Value = "Comment"
                ws.Cells.AutoFitColumns()

                savepath = FBD.SelectedPath
                Dim excelFile As New FileInfo(savepath & "\" & "TimeView Bulk Upload" & ".xlsx")
                xlPackage.SaveAs(excelFile)
                msg = MsgBox("Template saved to " & savepath, MsgBoxStyle.Information, "Exported")
            End If

        Catch ex As IO.IOException

            '   Dim lg As New ErrorLogger
            '   lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UploadTemplateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UploadTemplateToolStripMenuItem1.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a DB file"
        OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OFD.Filter = "Excel Files|*.xlsx;"

        If (OFD.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            FilePath = OFD.FileName
        Else
            Exit Sub
        End If

        Try
            Dim File As FileInfo = New FileInfo(FilePath)
            Dim globalPackage = New ExcelPackage(File)
            Dim Wb = globalPackage.Workbook
            Dim Ws = Wb.Worksheets.First()
            Dim dt As New DataTable(Ws.Name)
            Dim Dr As DataRow = Nothing

            If (Ws.Dimension Is Nothing) Then
                dt = New DataTable
            Else
                Dim totalRows As Integer = Ws.Dimension.End.Row
                Dim totalCols As Integer = Ws.Dimension.End.Column

                For i = 1 To totalCols
                    For j = 1 To totalRows
                        Dim cellVal = Ws.Cells(j, i).Value

                        If cellVal <> Nothing Then
                            cellVal = Regex.Replace(cellVal.ToString(), "[\u2013]", "-")
                            cellVal = Regex.Replace(cellVal.ToString(), "[\u2019]", "'")
                            cellVal = Regex.Replace(cellVal.ToString(), "[^\u0009^\u000A^\u000D^\u2019^\u0020-\u007E]", "")
                            Ws.Cells(j, i).Value = cellVal
                        End If
                    Next
                Next


                For i As Integer = 1 To totalCols
                    dt.Columns.Add(Ws.Cells(1, i).Value) 'adding custom column names
                    'to display in form
                Next

                For i As Integer = 2 To totalRows
                    Dr = dt.Rows.Add()
                    For j As Integer = 1 To totalCols
                        Dr(j - 1) = Ws.Cells(i, j).Value
                    Next
                Next
            End If

            gridMasterUpdate.Columns.Clear()
            gridMasterUpdate.DataSource = dt

            For x = 0 To dt.Rows.Count - 1
                Dim idate As Date = Nothing
                Dim empid As String = Nothing
                Dim iname As String = Nothing
                Dim iactivity As String = Nothing
                Dim isubactivity As String = Nothing
                Dim itask As String = Nothing
                Dim itottime As String = Nothing
                Dim ivol As String = Nothing
                Dim iactid As String = Nothing
                Dim icomment As String = Nothing



                Dim conn As New pgConnect
                Dim enc As New Encryption

                For y = 0 To dt.Columns.Count - 1

                    idate = dt.Rows(x)(0)
                    enc.Encrypt(dt.Rows(x)(1))
                    empid = enc.encr
                    iname = dt.Rows(x)(2).ToString
                    iactivity = dt.Rows(x)(3).ToString
                    isubactivity = dt.Rows(x)(4).ToString
                    itask = dt.Rows(x)(5).ToString
                    itottime = dt.Rows(x)(6)
                    ivol = dt.Rows(x)(7)
                    iactid = dt.Rows(x)(8).ToString
                    icomment = dt.Rows(x)(9).ToString


                Next
                Dim value As String = idate & "^" & empid & "^" & iname & "^" & ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & iactivity & "^" & isubactivity & "^" & itask & "^" & itottime & "^" & ivol & "^" & iactid & "^" & icomment & "^" & Home.TP_UserName
                conn.InsertRecord("time_view", "date,empl_id,name,project,process,sub_process,activity,sub_activity,task,total_time,volume,act_id,comment,added_by", value)

                UploadStatus.Text = "Uploading data :- " & x + 1 & " of " & dt.Rows.Count
            Next


            Dim msg As MsgBoxResult = MsgBox("Activity uploaded ! ", vbInformation, "Done")

        Catch ex As IO.IOException

            '  MsgBox(ex.Message)

            ' Dim msg As MsgBoxResult = MsgBox(ex.Message)

            '  Dim line As String = ex.StackTrace.ToString
            '  Dim LineNo() As String = Split(line, "line")

            '   Dim lg As New ErrorLogger
            '     lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub AddTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTimeToolStripMenuItem.Click
        'If ThinkManagement.TreeEmplid = Nothing Then
        '    MsgBox("Please select a user to add time", vbInformation, "No user selected")
        '    Exit Sub
        'End If

        MasterTimeUpdate.Show()
        MasterTimeUpdate.cmdSubmit.Text = "Add Activity"
        MasterTimeUpdate.txtUser.Text = ThinkManagement.TreeView1.SelectedNode.Text
    End Sub


End Class