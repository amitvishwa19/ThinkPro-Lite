Imports Npgsql
Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Imports System.ComponentModel

Public Class App_Consent_Admin
    Public selected_app As String = Nothing

    Private Sub App_Consent_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Consent Management for " & Home.TP_Project & "-" & Home.TP_Process & "-" & Home.TP_SubProcess

        lblActiveUser.Text = get_user_count()

        lbl_app_count.Text = get_process_application()


    End Sub

    Private Sub NewApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NewApplication.Show()
    End Sub

    Private Sub PIFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PIFields.Show()
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NewUser.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        AppProcess.Show()
    End Sub

    Private Sub ConsentStatusExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            'Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            'Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = "assa" & "^" & "asas" & "^" & "TM_SubProcess" & "^" & "SDate" & "^" & "EDate"

            Dim conn As New dbconnect

            conn.GetRecordsGRID("user_application", "*")


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Timeview Extract")

            Dim dc As System.Data.DataColumn
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            Dim Nbligne As Integer = conn.DataTable.Rows.Count

            For Each dc In conn.DataTable.Columns
                colIndex = colIndex + 1
                ws.Cells(1, colIndex).Value = dc.ColumnName
                ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
            Next
            ws.Cells.AutoFitColumns()


            For Each dr In conn.DataTable.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In conn.DataTable.Columns
                    colIndex = colIndex + 1
                    ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "Timeview Extract" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            Dim msg As MsgBoxResult
            msg = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")


        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub ApplicationMappingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicationMappingToolStripMenuItem.Click
        MapApplications.Show()
    End Sub

    Private Sub ApplicationsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.Click
        NewApplication.Show()
    End Sub

    Private Sub PiFieldsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PiFieldsToolStripMenuItem.Click
        PIFields.Show()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        NewUser.Show()
    End Sub

    Private Sub cmd_users_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim crypt As New Encryption
        Dim name As String = crypt.decrypt("FzBVgq4gEb0tB6KF9Z/91A==")
        Dim msg As MsgBoxResult
        msg = MsgBox(name)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim crypt As New Encryption
        Dim name As String = crypt.EncryptNew("Chaudhari")
        Clipboard.SetText(name)
        Dim msg As MsgBoxResult
        msg = MsgBox(name)
    End Sub

End Class