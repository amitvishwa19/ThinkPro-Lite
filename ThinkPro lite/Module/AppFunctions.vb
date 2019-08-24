Imports System.Text.RegularExpressions
Module AppFunctions

#Region "Grid formating"

    Public Sub Grid_Format_Simple(DGV)

        Dim DG As DataGridView
        DG = DGV
        DG.AllowUserToAddRows = False
        DG.DefaultCellStyle.Font = New Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.ClearSelection()
        DG.DefaultCellStyle.SelectionForeColor = DG.DefaultCellStyle.ForeColor
        DG.DefaultCellStyle.BackColor = Color.Linen
        DG.EnableHeadersVisualStyles = True
        DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'DG.AutoResizeColumns()
        'DG.Columns("ID").Visible = False

    End Sub
    Public Sub Grid_Format_Arternate(DGV)

        Dim DG As DataGridView
        DG = DGV
        DG.AllowUserToAddRows = False
        DG.DefaultCellStyle.Font = New Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.ClearSelection()
        DG.DefaultCellStyle.SelectionForeColor = DG.DefaultCellStyle.ForeColor
        DG.DefaultCellStyle.BackColor = Color.Linen
        DG.EnableHeadersVisualStyles = True
        DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'DG.AutoResizeColumns()

        DG.RowsDefaultCellStyle.BackColor = Color.White
        DG.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

    End Sub

#End Region

#Region "Datatable To Listview"
    Public Sub DatatableToListView(ByVal DT As DataTable, ByVal LV As ListView)
        Try

            LV.View = View.Details
            LV.GridLines = True
            LV.FullRowSelect = True
            LV.AllowColumnReorder = True
            LV.LabelEdit = True
            LV.Columns.Clear()
            LV.Items.Clear()


            Dim iColCount As Integer = DT.Columns.Count
            Dim iRowCount As Integer = DT.Rows.Count


            For Each col As DataColumn In DT.Columns
                LV.Columns.Add(col.ToString.ToUpper)
            Next

            For Each row As DataRow In DT.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To DT.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next


            Next

            'LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

            'Dim ival As Double = LV.Width
            'Dim icol As Integer = LV.Columns.Count
            'Dim iwidth As Integer = (ival / icol)

            'For i = 0 To LV.Columns.Count - 1
            '    LV.Columns(i).Width = iwidth - 1
            'Next


        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

#End Region

    Public Function RegExCheck(Input As String, Optional RegexString As String = Nothing)



        Dim Expression As String = "^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%&+=*]).*$"
        'Dim Expression As String = "^[a-zA-Z0-9]*$"


        'Dim match As Match = Regex.Match(Input, Expression, RegexOptions.IgnoreCase)


        'If match.Success Then
        '    Return True
        'Else
        '    Return False
        'End If

        If RegexString = Nothing Then
            Return Regex.IsMatch(Input, Expression)
        Else
            Return Regex.IsMatch(Input, RegexString)
        End If



    End Function

End Module
