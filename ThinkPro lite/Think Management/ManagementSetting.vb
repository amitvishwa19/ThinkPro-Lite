Imports Npgsql
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Public Class ManagementSetting
    'Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    '    MyBase.OnPaintBackground(e)
    '    Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
    '    e.Graphics.DrawRectangle(Pens.OrangeRed, rect)
    'End Sub
    Dim backup_path As String = Nothing
    Dim project As String = ThinkManagement.TM_Project
    Dim process As String = ThinkManagement.TM_Process
    Dim sub_process As String = ThinkManagement.TM_SubProcess

    Private Sub ManagementSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & "BackupPath"
        Dim rdr As NpgsqlDataReader = conn.GetRecords("app_config", "option", "project=@value1 and process=@value2 and sub_process=@value3 and type=@value4", value)
        If rdr.HasRows Then
            While rdr.Read
                backup_path = rdr("option").ToString
                txtFolderPath.Text = backup_path
            End While
        End If


    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            txtFolderPath.Text = FBD.SelectedPath
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim conn As New pgConnect
        Dim msg As MsgBoxResult
        Dim values As String = txtFolderPath.Text & "^" & ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & "BackupPath"
        conn.UpdateRecord("app_config", "option=@value1", values, "project=@value2 and process=@value3 and sub_process=@value4 and type=@value5")
        msg = MsgBox("Backup path updated successfully", vbInformation, "Success")
    End Sub

    Private Sub cmdBackup_Click(sender As Object, e As EventArgs) Handles cmdBackup.Click
        st1.Text = "Backup Started....."
        Dim BGW As New BackgroundWorker

        AddHandler BGW.DoWork, AddressOf WorkerDoWork
        AddHandler BGW.ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler BGW.RunWorkerCompleted, AddressOf WorkerCompleted
        BGW.RunWorkerAsync()


    End Sub

    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)


        Dim timeviewrow As Integer = Nothing
        Dim teamviewrow As Integer = Nothing
        Dim breakviewrow As Integer = Nothing
        Dim userrow As Integer = Nothing
        Dim msg As MsgBoxResult
        Dim values As String = project & "^" & process & "^" & sub_process


        Dim conn1 As New pgConnect
        Dim tv_rdr As NpgsqlDataReader = conn1.GetRecords("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", values)
        If tv_rdr.HasRows Then
            While tv_rdr.Read
                timeviewrow += 1
            End While
        End If

        Dim conn2 As New pgConnect
        Dim tmv_rdr As NpgsqlDataReader = conn2.GetRecords("team_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", values)
        If tmv_rdr.HasRows Then
            While tmv_rdr.Read
                teamviewrow += 1
            End While
        End If

        Dim conn3 As New pgConnect
        Dim brk_rdr As NpgsqlDataReader = conn3.GetRecords("break_time_log", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", values)
        If brk_rdr.HasRows Then
            While brk_rdr.Read
                breakviewrow += 1
            End While
        End If

        Dim conn4 As New pgConnect
        Dim usr_rdr As NpgsqlDataReader = conn4.GetRecords("user_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", values)
        If usr_rdr.HasRows Then
            While usr_rdr.Read
                userrow += 1
            End While
        End If


        If txtFolderPath.Text = Nothing Or txtFolderPath.Text = "Null" Then
            msg = MsgBox("Please configure backup path!", vbInformation, "oops!")
            Exit Sub
        End If

        Try

            Dim value As String = project & "^" & process & "^" & sub_process
            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws1 As ExcelWorksheet = oBook.Worksheets.Add("TimeView")
            Dim ws2 As ExcelWorksheet = oBook.Worksheets.Add("TeamView")
            Dim ws3 As ExcelWorksheet = oBook.Worksheets.Add("Break/Lock Details")
            Dim ws4 As ExcelWorksheet = oBook.Worksheets.Add("UserDetails")
            Dim ws5 As ExcelWorksheet = oBook.Worksheets.Add("TimeActivities")
            Dim ws6 As ExcelWorksheet = oBook.Worksheets.Add("ProjectDetails")

            Dim dc As System.Data.DataColumn

            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0


            'Timeview 
            Dim nconn1 As New pgConnect
            Dim Nbligne1 As Integer = conn1.DataTable.Rows.Count
            ws1.Select()
            st2.Text = "Time View"
            nconn1.GetRecordsGRID("time_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne1 = nconn1.DataTable.Rows.Count
            colIndex = 0
            rowIndex = 0
            For Each dc In nconn1.DataTable.Columns
                colIndex = colIndex + 1
                ws1.Cells(1, colIndex).Value = dc.ColumnName
                ws1.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws1.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws1.Cells.AutoFitColumns()


            For Each dr In nconn1.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn1.DataTable.Columns
                    colIndex = colIndex + 1
                    ws1.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
                st3.Text = Format((rowIndex / timeviewrow) * 100, "0") & " % "
            Next

            'Teamview
            Dim nconn2 As New pgConnect
            Dim Nbligne2 As Integer = conn1.DataTable.Rows.Count
            ws2.Select()
            st2.Text = "Team View"
            nconn2.GetRecordsGRID("team_view", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne2 = nconn2.DataTable.Rows.Count

            colIndex = 0
            rowIndex = 0
            For Each dc In nconn2.DataTable.Columns
                colIndex = colIndex + 1
                ws2.Cells(1, colIndex).Value = dc.ColumnName
                ws2.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws2.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws2.Cells.AutoFitColumns()


            For Each dr In nconn2.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn2.DataTable.Columns
                    colIndex = colIndex + 1
                    ws2.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
                st3.Text = Format((rowIndex / teamviewrow) * 100, "0") & " % "
            Next

            'Break Log
            Dim nconn3 As New pgConnect
            Dim Nbligne3 As Integer = conn1.DataTable.Rows.Count
            ws3.Select()
            st2.Text = "Break Lock Record"
            nconn3.GetRecordsGRID("break_time_log", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne3 = nconn3.DataTable.Rows.Count

            colIndex = 0
            rowIndex = 0
            For Each dc In nconn3.DataTable.Columns
                colIndex = colIndex + 1
                ws3.Cells(1, colIndex).Value = dc.ColumnName
                ws3.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws3.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws3.Cells.AutoFitColumns()


            For Each dr In nconn3.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn3.DataTable.Columns
                    colIndex = colIndex + 1
                    ws3.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
                st3.Text = Format((rowIndex / breakviewrow) * 100, "0") & " % "
            Next

            'Break Log
            Dim nconn4 As New pgConnect
            Dim Nbligne4 As Integer = conn1.DataTable.Rows.Count
            ws4.Select()
            st2.Text = "User Details"
            nconn4.GetRecordsGRID("user_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne4 = nconn4.DataTable.Rows.Count

            colIndex = 0
            rowIndex = 0
            For Each dc In nconn4.DataTable.Columns
                colIndex = colIndex + 1
                ws4.Cells(1, colIndex).Value = dc.ColumnName
                ws4.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws4.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws4.Cells.AutoFitColumns()


            For Each dr In nconn4.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn4.DataTable.Columns
                    colIndex = colIndex + 1
                    ws4.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
                st3.Text = Format((rowIndex / userrow) * 100, "0") & " % "
            Next


            'TimeActivity
            Dim nconn5 As New pgConnect
            Dim Nbligne5 As Integer = conn1.DataTable.Rows.Count
            ws5.Select()
            st2.Text = "Time Activity"
            nconn5.GetRecordsGRID("time_activity", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne5 = nconn5.DataTable.Rows.Count

            colIndex = 0
            rowIndex = 0
            For Each dc In nconn5.DataTable.Columns
                colIndex = colIndex + 1
                ws5.Cells(1, colIndex).Value = dc.ColumnName
                ws5.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws5.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws5.Cells.AutoFitColumns()


            For Each dr In nconn5.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn5.DataTable.Columns
                    colIndex = colIndex + 1
                    ws5.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next

            Next


            'project details
            Dim nconn6 As New pgConnect
            Dim Nbligne6 As Integer = conn1.DataTable.Rows.Count
            ws6.Select()
            st2.Text = "Project Details"
            nconn6.GetRecordsGRID("project_details", "*", "project =@value1 AND process =@value2 AND sub_process =@value3", value)
            Nbligne6 = nconn6.DataTable.Rows.Count

            colIndex = 0
            rowIndex = 0
            For Each dc In nconn6.DataTable.Columns
                colIndex = colIndex + 1
                ws6.Cells(1, colIndex).Value = dc.ColumnName
                ws6.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws6.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws6.Cells.AutoFitColumns()


            For Each dr In nconn6.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In nconn6.DataTable.Columns
                    colIndex = colIndex + 1
                    ws6.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next

            Next

            Dim filePath As String = String.Empty
            If txtFolderPath.Text.Trim().Length > 0 And project.Trim().Length > 0 And process.Trim().Length > 0 And sub_process.Trim().Length > 0 Then

                filePath = txtFolderPath.Text & "\" & "ThinkPro_Backup_" &
                                          project & "_" &
                                          process & "_" &
                                          sub_process & "_" &
                                          Format(Now, "ddMMyy") & ".xlsx"


            End If




            If filePath.Trim().Length > 0 Then
                Dim excelFile As New FileInfo(filePath)
                xlPackage.SaveAs(excelFile)

                st1.Text = "Backup created successfully to :: " & txtFolderPath.Text
                st2.Text = ""
                st3.Text = ""
                Dim msg1 As MsgBoxResult = MsgBox("Backup created successfully to :: " & txtFolderPath.Text, MsgBoxStyle.Information, "Exported")

            End If


        Catch ex As IOException
            Dim msg1 As MsgBoxResult = MsgBox("Please Contact System Administrator")
        End Try

    End Sub

    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub

    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' I'm done!
    End Sub


    Private Sub thinkpro_backup()

    End Sub
End Class