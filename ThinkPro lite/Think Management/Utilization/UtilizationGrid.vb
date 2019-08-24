Public Class UtilizationGrid

    Private Sub UtilizationGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    '#Region "Dashboard"

    '    Dim LevelNode As Integer
    '    Dim iBucket As String = Nothing



    '    Private Sub UtilizationTree()
    '        TreeUtilization.Nodes.Clear()
    '        Dim conn As New pgConnect
    '        Dim Bucket = New TreeNode
    '        Dim uActivity = New TreeNode
    '        Dim uSubActivity = New TreeNode
    '        Dim uTask = New TreeNode
    '        Dim SubSubChildnode = New TreeNode

    '        Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
    '        Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

    '        Dim value1 As String = Project & "^" & Process & "^" & SubProcess
    '        Dim iBucket As NpgsqlDataReader = conn.GetRecords("time_activity", "DISTINCT bucket", "project =@value1 AND process =@value2 AND sub_process=@value3", value1, "Bucket ASC")
    '        While iBucket.Read
    '            Bucket = New TreeNode(iBucket("bucket").ToString) 'iBucket("bucket").ToString
    '            'Bucket.Tag = iBucket("bucket").ToString
    '            TreeUtilization.Nodes.Add(Bucket)

    '            conn.Connect()
    '            Dim value2 As String = Project & "^" & Process & "^" & SubProcess & "^" & iBucket("bucket").ToString
    '            Dim iActivity As NpgsqlDataReader = conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process=@value3 AND bucket =@value4", value2, "activity ASC")
    '            While iActivity.Read
    '                uActivity = New TreeNode(iActivity("activity").ToString) 'iActivity("activity").ToString
    '                'uActivity.Tag = iActivity("activity").ToString
    '                Bucket.Nodes.Add(uActivity)

    '                conn.Connect()
    '                Dim value3 As String = Project & "^" & Process & "^" & SubProcess & "^" & iBucket("bucket").ToString & "^" & iActivity("activity").ToString
    '                Dim iSubActivity As NpgsqlDataReader = conn.GetRecords("time_activity", "DISTINCT sub_activity", "project =@value1 AND process =@value2 AND sub_process=@value3 AND bucket =@value4 AND activity =@value5", value3, "sub_activity ASC")
    '                While iSubActivity.Read
    '                    uSubActivity = New TreeNode(iSubActivity("sub_activity").ToString) 'iSubActivity("sub_activity").ToString
    '                    'uSubActivity.Tag = iSubActivity("sub_activity").ToString
    '                    uActivity.Nodes.Add(uSubActivity)



    '                    conn.Connect()
    '                    Dim value4 As String = Project & "^" & Process & "^" & SubProcess & "^" & iBucket("bucket").ToString & "^" & iActivity("activity").ToString & "^" & iSubActivity("sub_activity").ToString
    '                    Dim iTask As NpgsqlDataReader = conn.GetRecords("time_activity", "DISTINCT task", "project =@value1 AND process =@value2 AND sub_process=@value3 AND bucket =@value4 AND activity =@value5 AND sub_activity =@value6", value4, "task ASC")
    '                    While iTask.Read

    '                        uTask = New TreeNode(iTask("task").ToString)
    '                        uTask.Tag = iTask("task").ToString
    '                        uSubActivity.Nodes.Add(uTask)

    '                        'conn.Connect()
    '                        'Dim tvalue As String = Project & "^" & Process & "^" & SubProcess & "^" & iActivity("activity").ToString & "^" & iSubActivity("sub_activity").ToString & "^" & iTask("task").ToString & "^" & SDate & "^" & EDate
    '                        'Dim treader As NpgsqlDataReader = conn.GetRecords("time_view", "task,SUM(total_time) AS TTime,Sum(Volume) As TotCount", "project =@value1 AND process =@value2 AND sub_process=@value3 AND activity =@value4 AND sub_activity =@value5 AND task =@value6 AND date >=@value7 AND date<=@value8", tvalue, , "task")

    '                        'If treader.HasRows Then
    '                        '    While treader.Read
    '                        '        'MsgBox("Result")
    '                        '        uTask = New TreeNode(iTask("task").ToString)
    '                        '        uTask.Tag = Format(treader("TTime") / 60, "0.0")
    '                        '        uSubActivity.Nodes.Add(uTask)
    '                        '    End While
    '                        'Else
    '                        '    While treader.Read
    '                        '        'MsgBox("Result")
    '                        '        uTask = New TreeNode(iTask("task").ToString)
    '                        '        uTask.Tag = 0.0
    '                        '        uSubActivity.Nodes.Add(uTask)
    '                        '    End While
    '                        'End If





    '                    End While



    '                End While
    '            End While
    '        End While
    '    End Sub

    '    Private Sub TreeUtilization_AfterCollapse(sender As Object, e As TreeViewEventArgs)
    '        Call GetMaxLevel()
    '        LevelNode = LevelNode + 1
    '        'Panel3.Width = 25 + (20 * LevelNode)
    '        Call ViewUDGVRows()
    '    End Sub

    '    Private Sub TreeUtilization_AfterExpand(sender As Object, e As TreeViewEventArgs)
    '        Call GetMaxLevel()
    '        LevelNode = LevelNode + 1
    '        'Panel3.Width = 25 + (20 * LevelNode)
    '        Call ViewUDGVRows()
    '    End Sub

    '    Sub GetMaxLevel()
    '        LevelNode = -1

    '        For RowCount As Integer = 0 To TreeUtilization.Nodes.Count - 1
    '            If TreeUtilization.Nodes(RowCount).IsExpanded = True Then
    '                If TreeUtilization.Nodes(RowCount).Level > LevelNode Then
    '                    LevelNode = TreeUtilization.Nodes(RowCount).Level
    '                End If
    '                FindRecursive(TreeUtilization.Nodes(RowCount))
    '            End If
    '        Next

    '    End Sub

    '    Private Sub FindRecursive(tNode As TreeNode)
    '        Dim tn As TreeNode
    '        For Each tn In tNode.Nodes
    '            If tNode.IsExpanded = True Then
    '                If tn.Level > LevelNode Then
    '                    LevelNode = tn.Level
    '                End If
    '                FindRecursive(tn)
    '            End If
    '        Next
    '    End Sub

    '    Private Sub ViewUDGVRows()
    '        UDGV.Rows.Clear()

    '        For RowCount As Integer = 0 To TreeUtilization.Nodes.Count - 1
    '            UDGV.Rows.Add()
    '            iBucket = TreeUtilization.Nodes(RowCount).Tag
    '            UDGV(0, UDGV.RowCount - 1).Value = iBucket
    '            UDGV(0, UDGV.RowCount - 1).Style.BackColor = Color.CornflowerBlue



    '            If RowCount = 0 Then
    '                UDGV.Rows(UDGV.RowCount - 1).Height = UDGV.Rows(UDGV.RowCount - 1).Height - 1
    '            End If

    '            If TreeUtilization.Nodes(RowCount).IsExpanded = True Then
    '                FindRecrussiveColapse(TreeUtilization.Nodes(RowCount))
    '            End If

    '        Next

    '        UDGV.DefaultCellStyle.Font = New Font("Verdana", 7, FontStyle.Regular, GraphicsUnit.Point)

    '    End Sub

    '    Private Sub FindRecrussiveColapse(ByVal tNode As TreeNode)
    '        Dim tn As TreeNode
    '        For Each tn In tNode.Nodes
    '            UDGV.Rows.Add()
    '            'UDGV(1, UDGV.RowCount - 1).Value = iBucket
    '            UDGV(0, UDGV.RowCount - 1).Value = tn.Tag
    '            'UDGV(0, UDGV.RowCount - 1).Style.BackColor = Color.CornflowerBlue
    '            lblLevelNode.Text = LevelNode
    '            If LevelNode = 1 Then
    '                MsgBox("LevelNode = 1")
    '            ElseIf LevelNode = 2 Then
    '                UDGV(0, UDGV.RowCount - 1).Style.BackColor = Color.Red
    '            ElseIf LevelNode = 3 Then
    '                UDGV(0, UDGV.RowCount - 1).Style.BackColor = Color.LawnGreen
    '            ElseIf LevelNode = 4 Then
    '                UDGV(0, UDGV.RowCount - 1).Style.BackColor = Color.Gray
    '            End If

    '            If tn.IsExpanded Then
    '                FindRecrussiveColapse(tn)

    '                'If LevelNode = 1 Then
    '                '    MsgBox("LevelNode = 1")
    '                'ElseIf LevelNode = 2 Then
    '                '    MsgBox("LevelNode = 2")
    '                'ElseIf LevelNode = 3 Then
    '                '    MsgBox("LevelNode = 3")
    '                'ElseIf LevelNode = 4 Then
    '                '    MsgBox("LevelNode = 4")
    '                'End If



    '            End If
    '        Next
    '        UDGV.DefaultCellStyle.Font = New Font("Verdana", 7, FontStyle.Regular, GraphicsUnit.Point)

    '    End Sub

    '    Private Sub TreeUtilization_DrawNode(sender As Object, e As DrawTreeNodeEventArgs)
    '        'Dim p As New Pen(Brushes.Black)
    '        'e.Graphics.DrawLine(p, -20, e.Node.Bounds.Top, 1000, e.Node.Bounds.Top)

    '        'If e.Node.Index = TreeUtilization.Nodes.Count = 1 Then
    '        '    e.Graphics.DrawLine(p, -20, e.Node.Bounds.Bottom, 1000, e.Node.Bounds.Bottom)
    '        'End If

    '    End Sub


    '#End Region


End Class