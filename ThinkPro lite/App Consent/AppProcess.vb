Imports Npgsql
Imports System.Text.RegularExpressions
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Vml
Imports System.IO
Imports System.ComponentModel
Imports System.Data.OleDb
Public Class AppProcess
    Dim selectedprocess As Integer = Nothing
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub AppProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call process_data()
    End Sub

    Sub process_details()
        Dim conn As New dbconnect

        Dim dr As NpgsqlDataReader = conn.GetRecords("process", "*", "id=@value1", selectedprocess)
        If dr.HasRows Then
            While dr.Read
                txt_process.Text = dr("process")
                txt_subprocess.Text = dr("sub_process")
                txt_owner.Text = dr("process_owner")
                'chk_status.Checked = dr("user_status")
                'Call get_user_application(dr("id"))
            End While


        End If

    End Sub

    Public Sub process_data()
        Try
            Dim count As Integer = 0
            Dim app = New TreeNode
            Dim conn As New dbconnect
            TreeView1.Nodes.Clear()
            'Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*")

            Dim Parent As NpgsqlDataReader = conn.GetRecords("process", "*",,, "created_at DESC")

            While Parent.Read
                app = New TreeNode(Parent("process").ToString & "-" & Parent("sub_process").ToString)
                app.Tag = Parent("id")
                TreeView1.Nodes.Add(app)
                count += 1
            End While
            ToolStripStatusLabel1.Text = "Process count : " & count

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmd_submit.Click

        If cmd_submit.Text = "Add New" Then

            If validate_process() = False Then
                Exit Sub
            End If

            Dim conn As New dbconnect
            Dim value As String = txt_process.Text & "^" & txt_subprocess.Text & "^" & txt_owner.Text & "^" & txt_owneremail.Text
            conn.InsertRecord("process", "process,sub_process,process_owner,process_owner_email", value)
            GroupBox1.Enabled = False
            Call process_data()
        Else

            If validate_process() = False Then
                Exit Sub
            End If

            Dim conn As New dbconnect
            Dim value As String = txt_process.Text & "^" & txt_subprocess.Text & "^" & txt_owner.Text & "^" & txt_owneremail.Text & "^" & selectedprocess
            conn.UpdateRecord("process", "process =@value1,sub_process =@value2,process_owner =@value3,process_owner_email@value4", value, "id =@value5")
            GroupBox1.Enabled = False
            Call process_data()

        End If
    End Sub

    Private Function validate_process()

        Dim checked_item As Integer = 0

        If txt_process.Text = "" Then
            Dim msg As MsgBoxResult
            msg = MsgBox("Please fill Process name")
            txt_process.Focus()
            Return False
            Exit Function
        End If

        If txt_subprocess.Text = "" Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please fill subprocess name")
            txt_subprocess.Focus()
            Return False
        End If

        If txt_owner.Text = "" Then
            Dim msg2 As MsgBoxResult
            msg2 = MsgBox("Please fill Process owner name")
            txt_owner.Focus()
            Return False
        End If

        If txt_owneremail.Text = "" Then
            Dim msg3 As MsgBoxResult
            msg3 = MsgBox("Please fill Process owner email")
            txt_owneremail.Focus()
            Return False
        End If

        Return True
    End Function


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        selectedprocess = TreeView1.SelectedNode.Tag

        If GroupBox1.Enabled = False Then
            Call process_details()
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim result As Integer = MessageBox.Show("Do you want to delete " & TreeView1.SelectedNode.Text & " process", "Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim conn As New dbconnect
                conn.DeleteRecord("process", selectedprocess, "id=@value1")
                Call process_data()
                Dim msg As MsgBoxResult
                msg = MsgBox("Process deleted successfully")
                ' MsgBox("Process deleted successfully")
            End If

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        GroupBox1.Enabled = True
        cmd_submit.Text = "Update"
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        GroupBox1.Enabled = True
        cmd_submit.Text = "Add New"
        txt_process.Text = Nothing
        txt_subprocess.Text = Nothing
        txt_owner.Text = Nothing
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDataToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a DB file"
        OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OFD.Filter = "Excel Files|*.xls*;*.csv;"

        If (OFD.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            FilePath = OFD.FileName
        Else
            Exit Sub
        End If

        Try


            Dim SR As StreamReader = New StreamReader(FilePath)
            Dim line As String = SR.ReadLine()
            Dim strArray As String() = line.Split(","c)
            Dim dt As DataTable = New DataTable()
            Dim row As DataRow

            For Each s As String In strArray
                dt.Columns.Add(New DataColumn())
            Next

            Do
                line = SR.ReadLine
                If Not line = String.Empty Then
                    row = dt.NewRow()
                    row.ItemArray = line.Split(","c)
                    dt.Rows.Add(row)
                Else
                    Exit Do
                End If
            Loop


            Upload.DataGridView1.DataSource = dt
            Upload.upload_type = "process_upload"
            Upload.Show()

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub
End Class