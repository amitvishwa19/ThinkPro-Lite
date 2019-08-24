Imports System.IO
Imports Npgsql
Public Class ActivitySelector

    Private Sub ActivitySelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeView.Enabled = False
        Call FillActivityUserAllocation()
        Call ActivityTree()
        Call FillActivity()
        Call SelectedActivityTree()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        TimeView.Enabled = True
    End Sub

    Private Sub FillActivity()
        'Dim str As String
        'Try
        '    Dim Conn As New pgConnect
        '    Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & "Active"
        '    Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND status =@value4", value)
        '    ActivityList.Items.Clear()
        '    While reader.Read
        '        str = reader("activity").ToString
        '        ' SelActList.FindString(str) = -1 Then ActivityList.Items.Add(str
        '        ActivityList.Items.Add(reader("activity"))
        '    End While
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Public Sub FillActivityUserAllocation()
        'Try
        '    Dim Conn As New pgConnect
        '    Dim LDate As Date = My.Settings.LoginDate
        '    Dim iDate As String = Format(LDate, "dd-MMM-yy")
        '    Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & iDate & "^" & TimeView.EmplID
        '    Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date =@value4 AND empl_id=@value5", value)
        '    SelActList.Items.Clear()
        '    While reader.Read
        '        SelActList.Items.Add(reader("activity"))
        '    End While
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub ActivityList_DoubleClick(sender As Object, e As EventArgs)
        ''Additem(ActivityList.SelectedItem)
        'TimeView.FillActivityUserAllocation()
        'SelActList.Items.Add(ActivityList.SelectedItem)
        'ActivityList.Items.Remove(ActivityList.SelectedItem)
    End Sub

    Private Sub SelActList_DoubleClick(sender As Object, e As EventArgs)
        'ActivityList.Items.Add(SelActList.SelectedItem)
        'SelActList.Items.Remove(SelActList.SelectedItem)
    End Sub

    Private Sub cmdadd_Click(sender As Object, e As EventArgs) Handles cmdadd.Click
        'For i = 0 To Me.ActivityList.SelectedItems.Count - 1
        '    'Additem(ActivityList.SelectedItem)
        '    SelActList.Items.Add(ActivityList.SelectedItem)
        '    ActivityList.Items.Remove(ActivityList.SelectedItem)
        'Next i
        'TimeView.FillActivityUserAllocation()
    End Sub

    Private Sub cmdremove_Click(sender As Object, e As EventArgs) Handles cmdremove.Click
        'For i = 0 To Me.SelActList.SelectedItems.Count - 1
        '    ActivityList.Items.Add(SelActList.SelectedItem)
        '    SelActList.Items.Remove(SelActList.SelectedItem)
        'Next

    End Sub

    Sub Additem()
        Dim conn As New pgConnect
        Try
            Dim value As String = Format(Now, "dd-MMM-yy") & "^" & TimeView.EmplID & "^" & TimeView.UName & "^" & TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" &
                TreeView1.SelectedNode.Text & "^" & TreeView1.SelectedNode.Parent.Text & "^" & TreeView1.SelectedNode.Parent.Parent.Text & "^" & TimeView.ProjectID
            conn.InsertRecord("time_activity_user", "date,empl_id,empl_name,project,process,sub_process,task,sub_activity,activity,project_id", value)
        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If
        End Try

    End Sub

    Private Sub ActivityTree()
        Dim Activity = New TreeNode
        Dim SubActivity = New TreeNode
        Dim Task = New TreeNode
        Dim Conn As New pgConnect

        Try
            Dim value As String = TimeView.ProjectID & "^" & "Active"
            Dim Act As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project_id=@value1 AND status =@value2", value, "activity ASC")
            While Act.Read
                Activity = New TreeNode(Act("activity").ToString)
                TreeView1.Nodes.Add(Activity)


                Conn.Connect()
                Dim value1 As String = TimeView.ProjectID & "^" & "Active" & "^" & Act("activity")
                Dim SubAct As NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT sub_activity", "project_id=@value1 AND status=@value2 AND activity=@value3", value1)
                While SubAct.Read
                    SubActivity = New TreeNode(SubAct("sub_activity").ToString)
                    Activity.Nodes.Add(SubActivity)


                    Conn.Connect()
                    Dim value2 As String = TimeView.ProjectID & "^" & "Active" & "^" & Act("activity") & "^" & SubAct("sub_activity")
                    Dim tsk As NpgsqlDataReader = Conn.GetRecords("time_activity", "act_id,task,upt", "project_id=@value1 AND status=@value2 AND activity=@value3 AND sub_activity=@value4", value2)
                    While tsk.Read
                        Task = New TreeNode(tsk("task").ToString)
                        SubActivity.Nodes.Add(Task)

                        Task.Tag = tsk("act_id").ToString & "," & tsk("upt").ToString

                    End While
                End While
            End While

            Task.Checked = True

        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try

    End Sub

    Private Sub SelectedActivityTree()
        Dim Activity = New TreeNode
        Dim SubActivity = New TreeNode
        Dim Task = New TreeNode
        Dim Conn As New pgConnect
        TreeView2.Nodes.Clear()
        Try
            Dim value As String = TimeView.ProjectID
            Dim Act As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project_id=@value1", value, "activity ASC")

            While Act.Read
                Activity = New TreeNode(Act("activity").ToString)
                TreeView2.Nodes.Add(Activity)


                Conn.Connect()
                Dim value1 As String = TimeView.ProjectID & "^" & Act("activity")
                Dim SubAct As NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT sub_activity", "project_id=@value1  AND activity=@value2", value1)
                While SubAct.Read
                    SubActivity = New TreeNode(SubAct("sub_activity").ToString)
                    Activity.Nodes.Add(SubActivity)


                    Conn.Connect()
                    Dim value2 As String = TimeView.ProjectID & "^" & Act("activity") & "^" & SubAct("sub_activity")
                    Dim tsk As NpgsqlDataReader = Conn.GetRecords("time_activity_user", "task", "project_id=@value1  AND activity=@value2 AND sub_activity=@value3", value2)
                    While tsk.Read
                        Task = New TreeNode(tsk("task").ToString)
                        SubActivity.Nodes.Add(Task)
                    End While
                End While
            End While

            Task.Checked = True
            TreeView2.ExpandAll()

        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally
            If Conn.connection.State = ConnectionState.Open Then
                Conn.ConnClose()
            End If
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MsgBox(TimeView.ProjectID)
        'ActivityList.Items.Add(TimeView.ProjectID)
        FillActivity()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim totaltime As Integer
        Dim totalvol As Integer
        Dim UPT
        Dim ActID
        Dim conn As New pgConnect
        


        Try
            If TreeView1.SelectedNode.Level = 2 Then

                Dim tag As String = TreeView1.SelectedNode.Tag
                Dim valArr = tag.Split(",")
                ActID = valArr(0)
                UPT = valArr(1)

                Dim value As String = TreeView1.SelectedNode.Text
                conn.GetAVG("time_view", "SUM(total_time)", "task=@value1", value)
                totaltime = conn.AVG.ToString
                TotTime.Text = Format(totaltime, "0")

                conn.Connect()
                conn.GetAVG("time_view", "SUM(volume)", "task=@value1", value)
                totalvol = conn.AVG.ToString
                TotVol.Text = Format(totalvol, "0")

                AvgTime.Text = Format(totaltime / totalvol, "0.0")
                'MsgBox(TreeView1.SelectedNode.Tag)
                txtUPT.Text = UPT

                With TreeView1.SelectedNode
                    .BackColor = Color.Yellow
                End With
            End If

        Catch ex As Exception

            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)

        Finally
            If conn.connection.State = ConnectionState.Open Then
                conn.ConnClose()
            End If

        End Try


    End Sub

    Private Sub VolNotApp_CheckedChanged(sender As Object, e As EventArgs) Handles VolNotApp.CheckedChanged
        If VolNotApp.Checked = True Then
            txtVolume.Enabled = False
        Else
            txtVolume.Enabled = True
        End If
    End Sub

    Private Sub txtVolume_TextChanged(sender As Object, e As EventArgs) Handles txtVolume.TextChanged
        Try
            Dim avg As Integer = AvgTime.Text
            Dim vol As Integer = txtVolume.Text

            If vol = Nothing Then vol = 0

            ExpTime.Text = avg * vol
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ActivityList_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Try
            If TreeView1.SelectedNode.Level = 2 Then
                Call Additem()
                Call SelectedActivityTree()
            End If
        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally
          
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Try
            If TreeView1.SelectedNode.Level = 2 Then
                Call Additem()
                Call SelectedActivityTree()
            End If
        Catch ex As Exception
            Dim line As String = ex.StackTrace.ToString
            Dim LineNo() As String = Split(line, "line")
            Dim lg As New ErrorLogger
            lg.WriteErrorLog(Me.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "(" & LineNo(1) & ")" & ex.Message)
        Finally

        End Try
    End Sub

End Class