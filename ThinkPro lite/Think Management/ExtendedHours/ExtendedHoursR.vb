Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Vml
Imports System
Imports System.IO
Imports Npgsql
Imports System.Data.Odbc
'Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms
Public Class ExtendedHoursR
    Dim BS1, BS2 As New BindingSource


    Private Sub ExtendedHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ExtendedHours()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#Region "Extended Hours"
    Dim totaltime As String

    Private Sub ExtendedHours()

        Try
            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")
            Dim Conn As New pgConnect

            Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
            Conn.GetRecordsGRID("time_view", "DISTINCT name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
            GridExtendedHours.Columns.Clear()



            Dim dt11 As Date = SDate
            Dim dt21 As Date = EDate

            Dim ts As TimeSpan = dt21.Subtract(dt11)
            Dim days As Integer = Convert.ToInt32(ts.Days)
            Dim hday As String = Format(dt11, "ddd")

            For j = 0 To days - 1
                GridExtendedHours.EnableHeadersVisualStyles = False
                Conn.DataTable.Columns.Add(Format(dt11.AddDays(j), "dd-MMM-yy"))
            Next

            BS1.DataSource = Conn.DataTable
            GridExtendedHours.DataSource = BS1

            With GridExtendedHours
                .Columns(0).HeaderCell.Value = "Name"
            End With
            Call ThinkManagement.gridformat(GridExtendedHours)


            For i = 0 To GridExtendedHours.Rows.Count - 1
                Dim EEname As String = GridExtendedHours.Rows(i).Cells(0).Value
                For x = 1 To GridExtendedHours.Columns.Count - 1
                    Dim EEdate As String = GridExtendedHours.Columns(x).HeaderText

                    Call extend_hour_time(EEname, EEdate)

                    If Format(totaltime / 60, "0.0") > 0 Then
                        GridExtendedHours.Rows(i).Cells(x).Value = Format(totaltime / 60, "0.0")
                    ElseIf totaltime = 0 Then
                        If Format(EDate, "ddd") = "Sat" Or Format(EDate, "ddd") = "Sun" Then
                            GridExtendedHours.Rows(i).Cells(x).Value = 0
                        Else
                            GridExtendedHours.Rows(i).Cells(x).Value = 0
                        End If
                    Else
                        GridExtendedHours.Rows(i).Cells(x).Value = 0
                    End If
                    totaltime = Nothing
                Next
            Next

            Call extend_hour_summary()
            'Call ExtendedEmplID()


        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub ExtendedEmplID()

        For i = 0 To GridExtendedHours.RowCount - 1
            GridExtendedHours.Rows(i).Cells(0).Tag = "Woha"
        Next


    End Sub

    Public Sub GridExtendedHours_FilterStringChanged(sender As Object, e As EventArgs) Handles GridExtendedHours.FilterStringChanged
        BS1.Filter = GridExtendedHours.FilterString
        GridExtendedHours.DataSource = BS1
    End Sub

    Public Sub GridExtndSumary_FilterStringChanged(sender As Object, e As EventArgs) Handles GridExtndSumary.FilterStringChanged
        BS2.Filter = GridExtndSumary.FilterString
        GridExtndSumary.DataSource = BS2
    End Sub

    Private Sub GridExtendedHours_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridExtendedHours.CellContentClick
        'Dim i As Integer = GridExtendedHours.CurrentRow.Index
        'GridExtendedHours.Rows(i).Selected = True
        'MsgBox(GridExtendedHours.Item(0, i).Tag)
    End Sub

    Sub extend_hour_time(EEname, EEdate)

        Dim icount2 As Integer

        Dim EDate As String = EEdate


        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & EEname & "^" & EDate
        conn.GetRecordsGRIDGROUP("time_view", "SUM(total_time) AS SumOfTimeMin", "project =@value1 AND process =@value2 AND sub_process =@value3 AND name =@value4 AND date =@value5", value)

        icount2 = conn.DataTable.Rows.Count

        '   Dim msg As MsgBoxResult = MsgBox(conn.DataTable.Rows(0).Item("SumOfTimeMin").ToString)

        If icount2 = 0 Then
            totaltime = 0
        End If

        For x = 0 To icount2 - 1
            If Not IsDBNull(conn.DataTable.Rows(x).Item("SumOfTimeMin")) Then
                totaltime = conn.DataTable.Rows(x).Item("SumOfTimeMin")
            End If
        Next

    End Sub

    Private Sub extend_hour_summary()

        Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
        Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")

        Dim dt11 As Date = SDate 'DateTime = Convert.ToDateTime(DateStart.Value.ToString("dd-MM-yy"))
        Dim dt21 As Date = EDate 'As DateTime = Convert.ToDateTime(DateEnd.Value.ToString("dd-MMM-yy"))
        Dim ts As TimeSpan = dt21.Subtract(dt11)
        Dim days As Integer = Convert.ToInt32(ts.Days)
        Dim WeekdaytimeExtended As Double
        Dim TotalTimeWeekDays, TotalTimeWeekend As Double
        Dim TotalWeekdays, TotalWeekends As Integer
        Dim SummaryColNo As Integer


        Dim conn As New pgConnect
        Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
        conn.GetRecordsGRID("time_view", "DISTINCT name", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
        GridExtndSumary.Columns.Clear()

        Dim totcol As String = GridExtendedHours.Columns.Count - 1
        Dim i As Integer


        For i = 1 To totcol
            Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
            Dim hday As String = Format(hdate, "ddd")
            If hday = "Sun" Then
                conn.DataTable.Columns.Add(dt11.AddDays(i - 7) & " to " & dt11.AddDays(i - 1))
            End If
        Next

        BS2.DataSource = conn.DataTable
        GridExtndSumary.DataSource = BS2



        With GridExtndSumary
            .Columns(0).HeaderCell.Value = "Name"
        End With

        ThinkManagement.gridformat(GridExtndSumary)


        For x = 0 To GridExtendedHours.Rows.Count - 1
            For i = 1 To totcol
                Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
                Dim hday As String = Format(hdate, "ddd")

                'Colour Sat and Sun--------------------------------------------------------------
                If hday = "Sat" Or hday = "Sun" Then
                    GridExtendedHours.Rows(x).Cells(i).Style.BackColor = Color.Orange
                    GridExtendedHours.ClearSelection()
                End If
                'Colour Sat and Sun--------------------------------------------------------------


            Next
        Next


        Dim workingdaywek As Integer = 0
        For x = 0 To GridExtendedHours.Rows.Count - 1
            For i = 1 To totcol
                Dim hdate As Date = GridExtendedHours.Columns(i).HeaderText
                Dim hday As String = Format(hdate, "ddd")
                Dim cellval As String = GridExtendedHours.Rows(x).Cells(i).Value

                ''Weekday Time Calculation
                If hday <> "Sat" And hday <> "Sun" Then
                    If cellval <> "L" And cellval <> "W" Then
                        TotalTimeWeekDays = TotalTimeWeekDays + cellval
                        TotalWeekdays = TotalWeekdays + 1
                        '   Dim msg As MsgBoxResult = MsgBox("Weekday" & TotalWeekdays)
                    Else
                        TotalTimeWeekDays = TotalTimeWeekDays + 0
                        TotalWeekdays = TotalWeekdays + 1

                    End If
                End If

                ''Weekend Time Calculation
                If hday = "Sat" Or hday = "Sun" Then
                    If cellval <> "L" And cellval <> "W" Then
                        TotalTimeWeekend = TotalTimeWeekend + cellval
                        TotalWeekends = TotalWeekends + 1

                    Else
                        TotalTimeWeekend = TotalTimeWeekend + 0
                        TotalWeekends = TotalWeekends + 1

                    End If
                End If

                If hday = "Sun" Then



                    SummaryColNo = SummaryColNo + 1

                    If TotalWeekdays = 5 Then
                        If TotalTimeWeekDays - 48 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 48
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 4 Then
                        If TotalTimeWeekDays - 38.4 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 38.4
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 3 Then
                        If TotalTimeWeekDays - 28.8 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 28.8
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 2 Then
                        If TotalTimeWeekDays - 19.2 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 19.2
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 1 Then
                        If TotalTimeWeekDays - 9.6 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 9.6
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    End If





                    GridExtndSumary.Rows(x).Cells(SummaryColNo).Value = Format(TotalTimeWeekend + WeekdaytimeExtended, "0.00")

                    TotalTimeWeekDays = 0
                    TotalTimeWeekend = 0
                    TotalWeekdays = 0
                    TotalWeekends = 0
                    WeekdaytimeExtended = 0
                End If


            Next
            SummaryColNo = 0
        Next

    End Sub

    Private Sub Extended_hours_report()

        Dim xlPackage As New ExcelPackage()
        Dim oBook As ExcelWorkbook = xlPackage.Workbook
        Dim ws1 As ExcelWorksheet = oBook.Worksheets.Add("Top 15 contributors")
        Dim ws2 As ExcelWorksheet = oBook.Worksheets.Add("Extended Hours")
        'Dim ws3 As ExcelWorksheet = oBook.Worksheets.Add("Summary")
        Dim savepath As String
        Dim gridvalue As Double
        Dim WeekdaytimeExtended As Double
        Dim dt11 As Date = ThinkManagement.DateStart.Text
        Dim dt12 As Date = ThinkManagement.DateEnd.Text
        Dim cell As New EPPClass

        Try

            Dim totalrow As Integer = GridExtendedHours.Rows.Count - 1
            Dim totalCol As Integer = GridExtendedHours.Columns.Count - 1
            Dim headdate As DateTime

            ws2.Cells("A1:E1").Merge = True
            ws2.Cells(1, 1).Value = "Extended hours payout_Nielsen MR BPS-  " & dt11 & "  to  " & dt12
            cell.ColorCell(ws2, 1, 1, 196, 215, 155)

            ws2.Cells(2, 1).Value = "Customer Lead"
            ws2.Cells(2, 2).Value = "Employee ID"
            ws2.Cells(2, 3).Value = "Employee Name"
            ws2.Cells(2, 4).Value = "WON Number"
            ws2.Cells(2, 5).Value = "BPS Grade"
            ws2.Cells(2, 6).Value = "Type of Day/ Total workeding hours"

            For j = 1 To totalCol
                headdate = GridExtendedHours.Columns(j).HeaderText
                ws2.Cells(1, j + 6).Value = Format(headdate, "ddd")
                ws2.Cells(2, j + 6).Value = headdate
                ws2.Cells(2, j + 6).Style.Numberformat.Format = "dd-MMM-yy"
            Next


            For i = 0 To totalrow
                For j = 1 To totalCol
                    'ws2.Cells(i + 2, 3).Value = GridExtendedHours.Rows(i).Cells(0).Tag
                    ws2.Cells(i + 3, 3).Value = GridExtendedHours.Rows(i).Cells(0).Value
                    ws2.Cells(i + 3, 6).Value = "Total worked Hours"
                    gridvalue = GridExtendedHours.Rows(i).Cells(j).Value
                    ws2.Cells(i + 3, j + 6).Value = gridvalue
                    ws2.Cells(i + 3, j + 6).Style.Numberformat.Format = "0.0"
                Next
            Next


            Dim weeknum As Integer = 1
            For i = 7 To 365
                If ws2.Cells(1, i).Value = "Sun" Then
                    ws2.InsertColumn(i + 1, 1)
                    ws2.Cells(1, i + 1).Value = "Week Summary"
                    ws2.Cells(2, i + 1).Value = "Extended Hrs in week-" & weeknum
                    weeknum = weeknum + 1
                End If
            Next

            Dim icol As Integer = ws2.Dimension.End.Column
            If ws2.Cells(1, ws2.Dimension.End.Column).Value <> "Sun" Then
                ws2.Cells(1, icol + 1).Value = "Week Summary"
                ws2.Cells(2, icol + 1).Value = "Extended Hrs in week-" & weeknum
                ws2.Cells(1, icol + 2).Value = "Total Extended Hours"
                ws2.Cells(2, icol + 2).Value = "Total Extended Hours"
                ws2.Cells(1, icol + 3).Value = "Total Extended Hours"
                ws2.Cells(2, icol + 3).Value = "Total Extended Hours(N)"
                ws2.Cells(1, icol + 4).Value = "Total Extended Hours"
                ws2.Cells(2, icol + 4).Value = "Total Extended Hours(W)"
                ws2.Cells(1, icol + 5).Value = "Total Extended Hours"
                ws2.Cells(2, icol + 5).Value = "Total Extended Hours(H)"
            End If

            'Check for the holiday
            Dim row As String = ws2.Dimension.End.Row + 1
            For i = 7 To ws2.Dimension.End.Column
                Dim hday As String = ws2.Cells(1, i).Value
                If hday <> "Sat" And hday <> "Sun" And hday <> "Week Summary" And hday <> "Total Extended Hours" Then
                    Dim idate As Date = ws2.Cells(2, i).Value
                    'If holidaylist(idate) = True Then
                    'ws2.Cells(row, i).Value = 1
                    'Else
                    ws2.Cells(row, i).Value = 0
                    'End If
                End If
            Next

            Dim TotalTimeWeekDays, TotalTimeWeekend, TotalTimeHoliday As Double
            Dim TotalWeekdays, TotalWeekends, TotalHoliday As Integer
            For j = 3 To ws2.Dimension.End.Row
                If j = 12 Then

                End If
                For i = 7 To ws2.Dimension.End.Column
                    Dim hday As String = ws2.Cells(1, i).Value
                    Dim dayTime As Double = ws2.Cells(j, i).Value




                    If hday <> "Sat" And hday <> "Sun" And hday <> "Week Summary" And hday <> "Total Extended Hours" Then
                        Dim idate As Date = ws2.Cells(2, i).Value
                        If ws2.Cells(ws2.Dimension.End.Row, i).Value = 0 Then
                            TotalTimeWeekDays = TotalTimeWeekDays + dayTime
                            TotalWeekdays = TotalWeekdays + 1

                        ElseIf ws2.Cells(ws2.Dimension.End.Row, i).Value = 1 Then
                            TotalTimeHoliday = TotalTimeHoliday + dayTime
                            TotalHoliday = TotalHoliday + 1
                        End If
                    End If

                    If hday = "Sat" Or hday = "Sun" Then
                        TotalTimeWeekend = TotalTimeWeekend + dayTime
                        TotalWeekends = TotalWeekends + 1
                    End If

                    If TotalWeekdays = 5 Then
                        If TotalTimeWeekDays - 48 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 48
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 4 Then
                        If TotalTimeWeekDays - 38.4 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 38.4
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 3 Then
                        If TotalTimeWeekDays - 28.8 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 28.8
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 2 Then
                        If TotalTimeWeekDays - 19.2 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 19.2
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    ElseIf TotalWeekdays = 1 Then
                        If TotalTimeWeekDays - 9.6 > 0 Then
                            WeekdaytimeExtended = TotalTimeWeekDays - 9.6
                        Else
                            WeekdaytimeExtended = 0.0
                        End If
                    End If

                    Dim summary As Double
                    If hday = "Week Summary" Then
                        summary = TotalTimeWeekend + WeekdaytimeExtended + TotalTimeHoliday
                        ws2.Cells(j, i).Value = summary
                        ws2.Cells(j, i).Style.Numberformat.Format = "0.0"
                    End If

                    If hday = "Week Summary" Then
                        TotalTimeWeekDays = 0
                        TotalTimeWeekend = 0
                        TotalTimeHoliday = 0
                        TotalWeekdays = 0
                        TotalWeekends = 0
                        TotalHoliday = 0
                        WeekdaytimeExtended = 0
                    End If

                Next

                TotalTimeWeekDays = 0
                TotalTimeWeekend = 0
                TotalTimeHoliday = 0
                TotalWeekdays = 0
                TotalWeekends = 0
                TotalHoliday = 0
                WeekdaytimeExtended = 0
            Next


            'Total Extended hours
            Dim TimeSummary As Double
            Dim TotalTime As Double
            For i = 3 To ws2.Dimension.End.Row
                For j = 7 To ws2.Dimension.End.Column
                    If ws2.Cells(1, j).Value = "Week Summary" Then
                        TimeSummary = ws2.Cells(i, j).Value
                        TotalTime = TotalTime + TimeSummary
                        ws2.Cells(i, ws2.Dimension.End.Column - 3).Value = TotalTime
                        ws2.Cells(i, ws2.Dimension.End.Column - 3).Style.Numberformat.Format = "0.0"
                    End If
                Next
                TotalTime = 0
            Next

            'Weekend extended hours
            For i = 3 To ws2.Dimension.End.Row
                For j = 7 To ws2.Dimension.End.Column
                    Dim hday As String = ws2.Cells(1, j).Value
                    Dim hday2 As String = ws2.Cells(2, j).Value
                    If hday = "Sat" Or hday = "Sun" Then
                        TimeSummary = ws2.Cells(i, j).Value
                        TotalTime = TotalTime + TimeSummary
                        ws2.Cells(i, ws2.Dimension.End.Column - 1).Value = TotalTime
                        ws2.Cells(i, ws2.Dimension.End.Column - 1).Style.Numberformat.Format = "0.0"
                    End If
                Next
                TotalTime = 0
            Next

            'Holiday extended hour
            For i = 3 To ws2.Dimension.End.Row
                For j = 7 To ws2.Dimension.End.Column
                    Dim hday As String = ws2.Cells(1, j).Value
                    Dim hdate As String = ws2.Cells(2, j).Value
                    If hday = "Mon" Or hday = "Tue" Or hday = "Wed" Or hday = "Thu" Or hday = "fri" Then
                        If ws2.Cells(ws2.Dimension.End.Row, j).Value = 1 Then
                            TimeSummary = ws2.Cells(i, j).Value
                            TotalTime = TotalTime + TimeSummary
                            ws2.Cells(i, ws2.Dimension.End.Column).Value = TotalTime
                            ws2.Cells(i, ws2.Dimension.End.Column).Style.Numberformat.Format = "0.0"
                        End If
                    End If
                Next
                TotalTime = 0
            Next

            'Normal extended hours
            For i = 3 To ws2.Dimension.End.Row
                For j = 7 To ws2.Dimension.End.Column
                    Dim hday2 As String = ws2.Cells(2, j).Value
                    If hday2 = "Total Extended Hours" Then
                        Dim totalexthr As Double = ws2.Cells(i, ws2.Dimension.End.Column - 3).Value
                        Dim totalexthrWknd As Double = ws2.Cells(i, ws2.Dimension.End.Column - 1).Value
                        Dim totalexthrholiday As Double = ws2.Cells(i, ws2.Dimension.End.Column).Value
                        ws2.Cells(i, ws2.Dimension.End.Column - 2).Value = totalexthr - totalexthrWknd - totalexthrholiday
                        ws2.Cells(i, ws2.Dimension.End.Column - 2).Style.Numberformat.Format = "0.0"
                    End If
                Next
            Next




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Color Formating
            For i = 1 To ws2.Dimension.End.Column
                Dim hday As String = ws2.Cells(1, i).Value
                cell.ColorCell(ws2, 1, i, 196, 215, 155)
                For j = 2 To ws2.Dimension.End.Row
                    If hday = "Sat" Or hday = "Sun" Then
                        cell.ColorCell(ws2, j, i, 252, 213, 180)
                    End If

                    If hday = "Week Summary" Then
                        cell.ColorCell(ws2, j, i, 146, 205, 220)
                    End If

                    If hday = "Total Extended Hours" Then
                        cell.ColorCell(ws2, j, i, 196, 189, 151)
                    End If
                Next
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Color Formating.

            'deleting bottom row
            ws2.DeleteRow(ws2.Dimension.End.Row)

            'Summession of all time
            Dim tottime As Double
            Dim itime As Double
            For i = 7 To ws2.Dimension.End.Column
                Dim hday As String = ws2.Cells(1, i).Value
                If hday = "Week Summary" Or hday = "Total Extended Hours" Then
                    For j = 3 To ws2.Dimension.End.Row
                        itime = ws2.Cells(j, i).Value
                        tottime = tottime + itime
                        ws2.Cells(1, i).Value = tottime
                        cell.ColorCell(ws2, 1, i, 118, 147, 151)
                    Next
                End If
                tottime = 0
            Next




            'ws2.View.FreezePanes(1, 7)
            ws2.Cells.AutoFitColumns(2)
            ws2.View.ZoomScale = 80
            ws2.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            ws2.Select()

            Dim FBD As New FolderBrowserDialog
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
                Dim excelFile As New FileInfo(savepath & "\" & "Extended Hours" & ".xlsx")
                xlPackage.SaveAs(excelFile)
                Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")
            End If
            '  Catch ex As NullReferenceException
            'Dim msg1 As MsgBoxResult = MsgBox(ex.Message)

        Catch ex As IO.IOException
            '   Dim msg2 As MsgBoxResult = MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    'Public Function holidaylist(idate)

    'Dim holiday As New AccessConnect
    'Dim qry As String = "Hdate=#" & Format(idate, "dd-MMM-yy") & "#"
    'Dim hdr As OleDbDataReader = holiday.GetRecordsMaster("HolidayList", , qry)


    'If hdr.HasRows Then
    '    'MsgBox("Holiday")
    '    Return True
    'Else
    '    Return False
    'End If

    ''While dr.Read
    ''    MsgBox(dr("HolidayName"))
    ''End While

    'holiday.masterconnClose()
    'End Function

    Private Sub ExportReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportReportToolStripMenuItem.Click

    End Sub


#End Region



    Private Sub ExToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExToolStripMenuItem.Click
        Call Extended_hours_report()
    End Sub
End Class