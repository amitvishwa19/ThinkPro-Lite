Imports Npgsql
Imports System.IO
Public Class PIFields
    Dim selected_item As String = Nothing

    Private Sub PIFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call pi_fields_show()
    End Sub

    Public Sub pi_fields_show()
        Try
            Dim count As Integer = 0
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim Parent As NpgsqlDataReader = conn.GetRecords("pi_fields", "*", "pi_status=@value1", value)
            pi_lstbx.Items.Clear()
            While Parent.Read
                pi_lstbx.Items.Add(Parent("pi_name"))
                count += 1
            End While
            Parent.Dispose()
            piCount.Text = "Total Field Count : " & count
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Dim conn As New pgConnect
        Dim value As String = pi_lstbx.SelectedItem.ToString
        Dim Parent As NpgsqlDataReader = conn.GetRecords("pi_fields", "*", "pi_name=@value1", value)
        If Parent.HasRows Then
            While Parent.Read
                'MsgBox(Parent("pi_name"))
                txt_pi_name.Text = Parent("pi_name").ToString
                txt_pi_desc.Text = Parent("pi_description").ToString
                cmb_pi_status.Checked = Parent("pi_status")
            End While
        End If

        txt_pi_name.Enabled = True
        txt_pi_desc.Enabled = True
        cmb_pi_status.Enabled = True
        cmd_submit.Enabled = True
        cmd_submit.Text = "Update"

    End Sub

    Private Sub cmd_submit_Click(sender As Object, e As EventArgs) Handles cmd_submit.Click



        If cmd_submit.Text = "Add New" Then
            Dim conn As New pgConnect
            Dim value As String = txt_pi_name.Text & "^" & txt_pi_desc.Text & "^" & cmb_pi_status.CheckState
            conn.InsertRecord("pi_fields", "pi_name,pi_description,pi_status", value)
            Call pi_fields_show()
            Call reset_fields()
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Pi Field added successfully")
            '   MsgBox("Pi Field added successfully")

        Else
            Dim conn As New pgConnect
            Dim value As String = txt_pi_name.Text & "^" & txt_pi_desc.Text & "^" & cmb_pi_status.CheckState & "^" & selected_item
            conn.UpdateRecord("pi_fields", "pi_name =@value1,pi_description =@value2,pi_status =@value3", value, "pi_name =@value4")
            Call pi_fields_show()
            Call reset_fields()
            cmd_submit.Text = "Add New"
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Pi Field updated successfully")
            ' MsgBox("Pi Field updated successfully")
        End If
    End Sub

    Sub reset_fields()
        txt_pi_name.Text = Nothing
        txt_pi_desc.Text = Nothing
        cmb_pi_status.Checked = False
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim conn As New pgConnect
        conn.DeleteRecord("pi_fields", txt_pi_name.Text, "pi_name=@value1")
        Dim msg1 As MsgBoxResult
        msg1 = MsgBox("Pi Field deleted successfully")
        '  MsgBox("Pi Field deleted successfully")
    End Sub

    Private Sub cmb_pi_status_CheckedChanged(sender As Object, e As EventArgs) Handles cmb_pi_status.CheckedChanged
        If cmb_pi_status.Checked = True Then
            cmb_pi_status.Text = "Active"
        Else
            cmb_pi_status.Text = "InActive"
        End If
    End Sub

    Private Sub pi_lstbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pi_lstbx.SelectedIndexChanged
        selected_item = pi_lstbx.SelectedItem.ToString
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDataToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a upload file in CSV format"
        OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OFD.Filter = "CSV Files|*.csv;"

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
            Upload.upload_type = "pi_fields"
            Upload.Show()
        Catch ex As FileNotFoundException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try



    End Sub
End Class