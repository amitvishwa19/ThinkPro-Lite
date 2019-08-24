Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Public Class EPPClass


    Public Sub ColorCell(wsn As ExcelWorksheet, row As Integer, col As Integer, r As Integer, g As Integer, b As Integer)
        wsn.Cells(row, col).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        wsn.Cells(row, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(r, g, b))
    End Sub


    Public Sub CellColor(wsn As ExcelWorksheet, Range As String, Color As Object)
        wsn.Cells(Range).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        wsn.Cells(Range).Style.Fill.BackgroundColor.SetColor(Color)
    End Sub

    Public Sub CellColorRGB(wsn As ExcelWorksheet, Range As String, r As Integer, g As Integer, b As Integer)
        wsn.Cells(Range).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        wsn.Cells(Range).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(r, g, b))
    End Sub

    Public Sub CellBorder(wsn As ExcelWorksheet, Range As String, BorderPlacement As String, Color As Object)

        If BorderPlacement = "Top" Then
            wsn.Cells(Range).Style.Border.Top.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Top.Color.SetColor(Color)

        ElseIf BorderPlacement = "Bottom" Then
            wsn.Cells(Range).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Bottom.Color.SetColor(Color)

        ElseIf BorderPlacement = "Right" Then
            wsn.Cells(Range).Style.Border.Right.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Right.Color.SetColor(Color)

        ElseIf BorderPlacement = "Left" Then
            wsn.Cells(Range).Style.Border.Left.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Left.Color.SetColor(Color)

        ElseIf BorderPlacement = "All" Then
            wsn.Cells(Range).Style.Border.Top.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Top.Color.SetColor(Color)
            wsn.Cells(Range).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Bottom.Color.SetColor(Color)
            wsn.Cells(Range).Style.Border.Right.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Right.Color.SetColor(Color)
            wsn.Cells(Range).Style.Border.Left.Style = ExcelBorderStyle.Thin
            wsn.Cells(Range).Style.Border.Left.Color.SetColor(Color)

        End If


    End Sub

End Class
