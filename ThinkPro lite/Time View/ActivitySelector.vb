Imports System.IO
Imports Npgsql
Public Class ActivitySelector

    Private Sub ActivitySelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeView.Enabled = False
        Call FillActivityUserAllocation()
        Call FillActivity()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        TimeView.Enabled = True
    End Sub

    Private Sub FillActivity()
        Dim str As String
        Try
            Dim Conn As New pgConnect
            Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & "Active"
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND status =@value4", value)
            ActivityList.Items.Clear()
            While reader.Read
                str = reader("activity").ToString
                If SelActList.FindString(str) = -1 Then ActivityList.Items.Add(str)
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Public Sub FillActivityUserAllocation()
        Try
            Dim Conn As New pgConnect
            Dim LDate As Date = My.Settings.LoginDate
            Dim iDate As String = Format(LDate, "dd-MMM-yy")
            Dim value As String = TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & iDate & "^" & TimeView.EmplID
            Dim reader As Npgsql.NpgsqlDataReader = Conn.GetRecords("time_activity_user", "DISTINCT activity", "project =@value1 AND process =@value2 AND sub_process =@value3 AND date =@value4 AND empl_id=@value5", value)
            SelActList.Items.Clear()
            While reader.Read
                SelActList.Items.Add(reader("activity"))
            End While
        Catch ex As IO.IOException
        End Try
    End Sub

    Private Sub ActivityList_DoubleClick(sender As Object, e As EventArgs) Handles ActivityList.DoubleClick
        Additem(ActivityList.SelectedItem)
        TimeView.FillActivityUserAllocation()
        SelActList.Items.Add(ActivityList.SelectedItem)
        ActivityList.Items.Remove(ActivityList.SelectedItem)
    End Sub

    Private Sub SelActList_DoubleClick(sender As Object, e As EventArgs) Handles SelActList.DoubleClick
        ActivityList.Items.Add(SelActList.SelectedItem)
        SelActList.Items.Remove(SelActList.SelectedItem)
    End Sub

    Private Sub cmdadd_Click(sender As Object, e As EventArgs) Handles cmdadd.Click
        For i = 0 To Me.ActivityList.SelectedItems.Count - 1
            Additem(ActivityList.SelectedItem)
            SelActList.Items.Add(ActivityList.SelectedItem)
            ActivityList.Items.Remove(ActivityList.SelectedItem)
        Next i
        TimeView.FillActivityUserAllocation()
    End Sub

    Private Sub cmdremove_Click(sender As Object, e As EventArgs) Handles cmdremove.Click
        For i = 0 To Me.SelActList.SelectedItems.Count - 1
            ActivityList.Items.Add(SelActList.SelectedItem)
            SelActList.Items.Remove(SelActList.SelectedItem)
        Next

    End Sub

    Sub Additem(Item As String)
        Dim conn As New pgConnect
        Try
            Dim value As String = Format(Now, "dd-MMM-yy") & "^" & TimeView.EmplID & "^" & TimeView.UName & "^" & TimeView.Project & "^" & TimeView.Process & "^" & TimeView.SubProcess & "^" & Item
            conn.InsertRecord("time_activity_user", "date,empl_id,empl_name,project,process,sub_process,activity", value)
        Catch ex As IO.IOException
            conn.ConnClose()
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally
            conn.ConnClose()
        End Try

    End Sub

    Sub RemoveItem()

    End Sub

   
End Class