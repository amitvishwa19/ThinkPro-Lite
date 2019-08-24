Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Public Class EppGridExport


    Sub EppGrdExport(GridName As Object, ExportName As String)
        Dim FBD As New FolderBrowserDialog
        Dim savepath As String
        If (FBD.ShowDialog() = DialogResult.OK) Then
            savepath = FBD.SelectedPath
        Else
            Exit Sub
        End If




        Dim GRD As New DataGridView
        GRD = GridName

        Dim dset As New DataSet
        dset.Tables.Add()
        For i As Integer = 0 To GRD.ColumnCount - 1
            dset.Tables(0).Columns.Add(GRD.Columns(i).HeaderText)
        Next

        Dim dr1 As DataRow
        For i As Integer = 0 To GRD.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j As Integer = 0 To GRD.Columns.Count - 1
                dr1(j) = GRD.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next




        Dim xlPackage As New ExcelPackage()
        Dim oBook As ExcelWorkbook = xlPackage.Workbook
        Dim ws As ExcelWorksheet = oBook.Worksheets.Add(ExportName)

        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim msg As MsgBoxResult

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            ws.Cells(1, colIndex).Value = dc.ColumnName
            ws.Cells(1, colIndex).Style.Fill.PatternType = ExcelFillStyle.Solid
            ws.Cells(1, colIndex).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                ws.Cells(rowIndex + 1, colIndex).Value = dr(dc.ColumnName)

            Next
        Next


        ws.Cells.AutoFitColumns()

        Dim excelFile As New FileInfo(savepath & "\" & ExportName & ".xlsx")
        xlPackage.SaveAs(excelFile)
        msg = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")



    End Sub

    Sub DataTableExport()


    End Sub

End Class
