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
Public Class ShiftCompliance
    Dim BS As New BindingSource

    Private Sub ShiftCompliance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ShiftCompliance()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#Region "Shift Compliance"

    Private Sub ShiftCompliance()
        Try
            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")

            Dim conn As New pgConnect
            Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
            conn.GetRecordsGRID("team_view", "name,empl_id,date,in_time,out_time", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date >=@value4 AND date <=@value5", value)
            gridShiftCom.Columns.Clear()
            BS.DataSource = conn.DataTable


            conn.DataTable.Columns.Add("Shift Type")
            conn.DataTable.Columns.Add("Shift Start")
            conn.DataTable.Columns.Add("Shift End")
            conn.DataTable.Columns.Add("In Time Compliance")
            conn.DataTable.Columns.Add("Out Time Compliance")
            gridShiftCom.DataSource = BS

            ThinkManagement.gridformat(gridShiftCom)
            gridShiftCom.Columns("empl_id").Visible = False
            With gridShiftCom
                .Columns(0).HeaderCell.Value = "User"
                .Columns(2).HeaderCell.Value = "Date"
                .Columns(3).HeaderCell.Value = "In Time"
                .Columns(3).HeaderCell.Value = "Out Time"
            End With




        Catch ex As IO.IOException

            'MsgBox("")

            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")

        End Try

    End Sub

    Private Sub Shift_compliance_Export()

        Dim FBD As New FolderBrowserDialog

        Dim xlPackage As New ExcelPackage()
        Dim oBook As ExcelWorkbook = xlPackage.Workbook
        Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Shift Compliance")
        Dim savepath As String
        Dim dt As New DataTable
        dt = TryCast(gridShiftCom.DataSource, DataTable)

        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0


        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1

                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)

            Next
        Next

        ws.Cells.AutoFitColumns()
        ws.Column(4).Style.Numberformat.Format = "hh:mm:ss AM/PM"
        ws.Column(5).Style.Numberformat.Format = "hh:mm:ss AM/PM"
        ws.Column(6).Style.Numberformat.Format = "hh:mm:ss AM/PM"

        If (FBD.ShowDialog() = DialogResult.OK) Then
            savepath = FBD.SelectedPath
            Dim excelFile As New FileInfo(savepath & "\" & "Shift Compliance" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")
        End If

    End Sub

    Public Sub gridShiftCom_FilterStringChanged(sender As Object, e As EventArgs)
        BS.Filter = gridShiftCom.FilterString
        gridShiftCom.DataSource = BS
    End Sub

#End Region

    
End Class