Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Vml
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class TimeViewActivityManager

    Public IRow As String = Nothing 'For Grid Row selection
    Dim BS As New BindingSource
    Dim projectID = ThinkManagement.TM_ProcessID
    Dim Project = ThinkManagement.TM_Project
    Dim Process = ThinkManagement.TM_Process
    Dim SubProcess = ThinkManagement.TM_SubProcess

    Private Sub TimeViewActivityManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TimeViewActivity()
    End Sub

#Region "Time View Activity"

    Sub TimeViewActivity()
        Dim conn As New pgConnect
        Try

            Dim value As String = Project & "^" & Process & "^" & SubProcess
            conn.GetRecordsGRID("time_activity", "act_id,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", "project =@value1 AND process =@value2 AND sub_process =@value3", value, "act_id DESC")

            gridActivity.Columns.Clear()
            BS.DataSource = conn.DataTable
            gridActivity.DataSource = BS
            AppFunctions.Grid_Format_Arternate(gridActivity)
            gridActivity.Columns(0).Visible = False
            With gridActivity
                .Columns(1).HeaderCell.Value = "Bucket"
                .Columns(2).HeaderCell.Value = "Activity"
                .Columns(3).HeaderCell.Value = "Sub Activity"
                .Columns(4).HeaderCell.Value = "Task"
                .Columns(5).HeaderCell.Value = "UPT"
                .Columns(6).HeaderCell.Value = "Lock Exclude"
                .Columns(7).HeaderCell.Value = "Volume Req."
                .Columns(8).HeaderCell.Value = "Act ID Req."
                .Columns(9).HeaderCell.Value = "Cmnt Req"
                .Columns(10).HeaderCell.Value = "Status"
            End With


            ActivityCount()

        Catch ex As IO.IOException
            '  Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            ' Catch ex As IO.IOException
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try





    End Sub

    Sub ActivityCount()
       
        TotalCount.Text = "Total Count : " & gridActivity.Rows.Count

    End Sub

    Public Sub gridActivity_FilterStringChanged(sender As Object, e As EventArgs) Handles gridActivity.FilterStringChanged
        BS.Filter = gridActivity.FilterString
        gridActivity.DataSource = BS
        Call ActivityCount()
    End Sub

    Private Sub gridActivity_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridActivity.CellClick
        Try
            Dim i As Integer = gridActivity.CurrentRow.Index
            gridActivity.Rows(i).Selected = True
            IRow = gridActivity.Item(0, i).Value
        Catch ex As IO.IOException
            '   Dim msg As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ActivateActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateActivityToolStripMenuItem.Click
        Dim conn As New pgConnect
        Try
            Dim Value As String = "Active" & "^" & IRow
            conn.UpdateRecord("time_activity", "status = @value1", Value, "act_id=@value2")
            Call TimeViewActivity()
            Dim msg As MsgBoxResult = MsgBox("Activity activated successfully", vbInformation, "Activation Success")
        Catch ex As IO.IOException
            ' Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try
    End Sub

    Private Sub DeleteActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteActivityToolStripMenuItem.Click
        Dim conn As New pgConnect
        Try

            Dim Value As String = "InActive" & "^" & IRow
            conn.UpdateRecord("time_activity", "status = @value1", Value, "act_id=@value2")
            Call TimeViewActivity()
            Dim msg As MsgBoxResult = MsgBox("Activity deactivated successfully", vbInformation, "Deactivation Success")
        Catch ex As IO.IOException

            '   Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try
    End Sub

    Private Sub EditActivityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditActivityToolStripMenuItem.Click


        Try
            Dim i As Integer
            Dim ival As Integer

            i = gridActivity.CurrentRow.Index


            If gridActivity.Rows(i).Selected = False Then
                Dim msg As MsgBoxResult = MsgBox("Please select a activity to edit", vbInformation, "Select activity")
                Exit Sub
            End If

            ival = gridActivity.Item(0, i).Value


            TimeViewActivityEditor.Show()
            TimeViewActivityEditor.cmdSubmit.Text = "Update"
            TimeViewActivityEditor.ActID = ival

            If Not IsDBNull(gridActivity.Item(1, i).Value) Then
                TimeViewActivityEditor.txtBucket.Text = gridActivity.Item(1, i).Value
            End If

            If Not IsDBNull(gridActivity.Item(2, i).Value) Then
                TimeViewActivityEditor.txtActivity.Text = gridActivity.Item(2, i).Value
            End If
            If Not IsDBNull(gridActivity.Item(3, i).Value) Then

                TimeViewActivityEditor.txtSubActivity.Text = gridActivity.Item(3, i).Value
            End If
            If Not IsDBNull(gridActivity.Item(4, i).Value) Then
                TimeViewActivityEditor.txtTask.Text = gridActivity.Item(4, i).Value
            End If

            If Not IsDBNull(gridActivity.Item(5, i).Value) Then
                TimeViewActivityEditor.txtUPT.Text = gridActivity.Item(5, i).Value
            End If

            TimeViewActivityEditor.cbLockExc.CheckState = gridActivity.Item(6, i).Value
            TimeViewActivityEditor.cbVolReq.CheckState = gridActivity.Item(7, i).Value
            TimeViewActivityEditor.cbActIDReq.CheckState = gridActivity.Item(8, i).Value
            TimeViewActivityEditor.cbCmntReq.CheckState = gridActivity.Item(9, i).Value
        Catch ex As IO.IOException

            'Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub

    Private Sub AddActivityToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim i As Integer = gridActivity.CurrentRow.Index
            Dim ival As Integer = gridActivity.Item(0, i).Value

            TimeViewActivityEditor.Show()
            TimeViewActivityEditor.cmdSubmit.Text = "Add Activity"
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ExportActivityToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim epp As New EppGridExport
        epp.EppGrdExport(gridActivity, "TimeView Activity")
    End Sub

#End Region

#Region "CSV Import"
    'Dim TableName As String
    Private Workers() As BackgroundWorker
    Private NumWorkers = 0

    Private Sub ImportCsv_Click(sender As Object, e As EventArgs)
        Try
            Dim FilePath As String
            Dim OpenFileDialog1 As New OpenFileDialog

            OpenFileDialog1.Title = "Please select a DB file"
            OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            OpenFileDialog1.Filter = "Excel Files|*.csv;*.csv;*.csv;*.csv;*‌​.xml;"



            If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                FilePath = OpenFileDialog1.FileName
                Dim fi As New FileInfo(OpenFileDialog1.FileName)
                Dim FileName As String = OpenFileDialog1.FileName

                Dim items2 = (From line In IO.File.ReadAllLines(OpenFileDialog1.FileName)
                              Select Array.ConvertAll(line.Split(","c), Function(v) v.ToString.TrimStart(""" ".ToCharArray).TrimEnd(""" ".ToCharArray))).ToArray

                Dim Your_DT As New DataTable
                For x As Integer = 0 To items2(0).GetUpperBound(0)
                    Your_DT.Columns.Add()

                Next

                For Each a In items2
                    Dim dr As DataRow = Your_DT.NewRow
                    dr.ItemArray = a
                    Your_DT.Rows.Add(dr)
                Next




                gridActivity.DataSource = Your_DT
                AppFunctions.Grid_Format_Arternate(gridActivity)
            End If


            Call ActivityCount()

            Dim msg As MsgBoxResult = MsgBox("Activity imported ! Please validate and click upload to upload the activity to application", vbInformation, "Done")
        Catch ex As IO.IOException

            'Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")

            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UploadCsv_Click_1(sender As Object, e As EventArgs)

        Try
            NumWorkers = NumWorkers + 1
            ReDim Workers(NumWorkers)

            Workers(NumWorkers) = New BackgroundWorker
            Workers(NumWorkers).WorkerReportsProgress = True
            Workers(NumWorkers).WorkerSupportsCancellation = True

            AddHandler Workers(NumWorkers).DoWork, AddressOf WorkerDoWork
            'AddHandler Workers(NumWorkers).ProgressChanged, AddressOf WorkerProgressChanged
            AddHandler Workers(NumWorkers).RunWorkerCompleted, AddressOf WorkerCompleted
            Workers(NumWorkers).RunWorkerAsync()
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            Call GridActivityUpload()
        Catch ex As IO.IOException
            '  Dim line As String = ex.StackTrace.ToString
            ' Dim LineNo() As String = Split(line, "line")
            ' Dim lg As New ErrorLogger
            ' lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Call TimeViewActivity()
        Dim Msg As MsgBoxResult = MsgBox("Activities imported successfully", vbInformation, "Success")
    End Sub

    

#End Region

#Region "XLSX import"

    Private Sub UploadXlx_Click(sender As Object, e As EventArgs) Handles UploadXlx.Click
        NumWorkers = NumWorkers + 1
        ReDim Workers(NumWorkers)

        Workers(NumWorkers) = New BackgroundWorker
        Workers(NumWorkers).WorkerReportsProgress = True
        Workers(NumWorkers).WorkerSupportsCancellation = True

        AddHandler Workers(NumWorkers).DoWork, AddressOf XLXSWorkerDoWork
        AddHandler Workers(NumWorkers).RunWorkerCompleted, AddressOf XLXWorkerCompleted
        Workers(NumWorkers).RunWorkerAsync()
    End Sub

    Private Sub XLXSWorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            Call GridActivityUpload()
        Catch ex As IO.IOException
            '  Dim line As String = ex.StackTrace.ToString
            '  Dim LineNo() As String = Split(line, "line")
            '  Dim lg As New ErrorLogger
            '  lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub XLXWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Call TimeViewActivity()
        Dim Msg As MsgBoxResult = MsgBox("Activities imported successfully", vbInformation, "Success")
        transf.Text = "Uploading completed"
    End Sub

    Sub GridActivityUpload()
        Try

            For i = 0 To gridActivity.RowCount - 1

                Dim bucket As String = gridActivity.Rows(i).Cells(0).Value.ToString
                Dim activity As String = gridActivity.Rows(i).Cells(1).Value.ToString
                Dim subactivity As String = gridActivity.Rows(i).Cells(2).Value.ToString
                Dim task As String = gridActivity.Rows(i).Cells(3).Value.ToString
                Dim upt As String = gridActivity.Rows(i).Cells(4).Value.ToString
                Dim exlock As String = gridActivity.Rows(i).Cells(5).Value.ToString
                Dim volume As String = gridActivity.Rows(i).Cells(6).Value.ToString
                Dim aid As String = gridActivity.Rows(i).Cells(7).Value.ToString
                Dim cmnt As String = gridActivity.Rows(i).Cells(8).Value.ToString

                If exlock = Nothing Then exlock = 0
                If volume = Nothing Then volume = 0
                If aid = Nothing Then aid = 0
                If cmnt = Nothing Then cmnt = 0

                Dim conn As New pgConnect
                Dim value As String
                value = projectID & "^" & Project & "^" & Process & "^" & SubProcess & "^" & bucket & "^" & activity & "^" & subactivity & "^" & task & "^" & upt & "^" & exlock & "^" & volume & "^" & aid & "^" & cmnt & "^" & "Active"
                conn.InsertRecord("time_activity", "project_id,project,process,sub_process,bucket,activity,sub_activity,task,upt,ex_lock,volume,aid,cmnt,status", value)
                transf.Text = "Uploading : " & i + 1

            Next

        Catch ex As IO.IOException

            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")

            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally

        End Try
    End Sub

#End Region

 

    Public Shared Function encode(ByVal str As String) As String
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        Dim encodedString() As Byte
        encodedString = utf8Encoding.GetBytes(str)
        Return utf8Encoding.GetString(encodedString)
    End Function

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddActivityToolStripMenuItem1.Click
        TimeViewActivityEditor.Show()
        TimeViewActivityEditor.cmdSubmit.Text = "Add Activity"
    End Sub

    Private Sub ActivityIimportTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivityIimportTemplateToolStripMenuItem.Click
        Dim msg As MsgBoxResult
        Try
            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Activity")
            Dim savepath As String


            ws.Cells.AutoFitColumns()
            ws.Cells(1, 1).Value = "Bucket"
            ws.Cells(1, 2).Value = "Activity"
            ws.Cells(1, 3).Value = "Sub Activity"
            ws.Cells(1, 4).Value = "Task"
            ws.Cells(1, 5).Value = "UPT"
            ws.Cells(1, 6).Value = "Lock Excluded"
            ws.Cells(1, 7).Value = "Volume Required"
            ws.Cells(1, 8).Value = "Activity ID Required"
            ws.Cells(1, 9).Value = "Comments Required"
            ws.Cells(1, 10).Value = "Activity Status"
            ws.Cells.AutoFitColumns()


            ws.Cells(1, 1).AddComment("DIRECT,INDIRECT,TCS INTERNAL,VALIDATION ACTIVITIES", "REF")
            ws.Cells(1, 2).AddComment("", "REF")
            ws.Cells(1, 3).AddComment("", "REF")
            ws.Cells(1, 4).AddComment("", "REF")
            ws.Cells(1, 5).AddComment("Unit processing time of activity(Numeric only)", "REF")
            ws.Cells(1, 6).AddComment("Put 1 if activity should be excluded from PC lock, else Put 0", "REF")
            ws.Cells(1, 7).AddComment("Put 1 to compel user to enter volume while changing the Activity, else put 0", "REF")
            ws.Cells(1, 8).AddComment("Put 1 to compel user to enter Activity ID while changing the Activity, else put 0", "REF")
            ws.Cells(1, 9).AddComment("Put 1 to compel user to enter Comments while changing the Activity, else put 0", "REF")
            ws.Cells(1, 10).AddComment("Keep dafault value as 'Active' ", "REF")

            For i = 1 To 10


            Next

            Dim FBD As New FolderBrowserDialog
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
                Dim excelFile As New FileInfo(savepath & "\" & "TimeView Activity upload Template" & ".xlsx")
                xlPackage.SaveAs(excelFile)
                msg = MsgBox("Template saved to " & savepath, MsgBoxStyle.Information, "Exported")
            End If

        Catch ex As IO.IOException

            ' Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ImportActivityCSVToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ImportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem1.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a DB file"
        OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OFD.Filter = "Excel Files|*.xls*;"

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

            gridActivity.DataSource = dt
            AppFunctions.Grid_Format_Arternate(gridActivity)

            UploadXlx.Enabled = True

            Call ActivityCount()

            Dim msg As MsgBoxResult = MsgBox("Activity imported ! Please validate and click upload to upload the activity to application", vbInformation, "Done")

        Catch ex As IO.IOException

            'Dim line As String = ex.StackTrace.ToString
            'Dim LineNo() As String = Split(line, "line")

            'Dim lg As New ErrorLogger
            'lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    
    Private Sub ExportActivityToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExportActivityToolStripMenuItem1.Click
        Dim epp As New EppGridExport
        epp.EppGrdExport(gridActivity, "TimeView Activity")
    End Sub
End Class