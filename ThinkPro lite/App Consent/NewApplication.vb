Imports Npgsql
Imports System.IO
Public Class NewApplication
    Public selected_app As String = Nothing
    Dim app_ids As String()
    Dim array_id As Integer = 0

    Private Sub NewApplication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call application_data()
        Call pi_fields()

    End Sub


    Private Sub cmd_submit_Click(sender As Object, e As EventArgs) Handles cmd_submit.Click
        Dim app_status As String = Nothing

        If cmd_submit.Text = "Add New" Then

            If check_existing_app(app_name.Text) = True Then
                Dim msg2 As MsgBoxResult
                msg2 = MsgBox("Application with name " & app_name.Text & " is already exists, please enter a different name")

                Exit Sub
            End If

            If validate_pi() = False Then
                Exit Sub
            End If

            Dim conn As New pgConnect
            Dim value As String = app_name.Text & "^" & app_description.Text & "^" & app_owner.Text & "^" & app_purpose.Text
            conn.InsertRecord("applications", "app_name,app_description,app_owner,app_purpose", value)

            Call sync_app_pi(app_name.Text)

            application_data()
            GroupBox1.Enabled = False
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Application added successfully")

        Else

            If validate_pi() = False Then
                Exit Sub
            End If


            Dim conn As New pgConnect
            Dim value As String = app_name.Text & "^" & app_description.Text & "^" & app_purpose.Text & "^" & app_owner.Text & "^" & selected_app
            conn.UpdateRecord("applications", "app_name =@value1,app_description =@value2,app_purpose=@value3,app_owner =@value4", value, "id =@value5")

            Call sync_app_pi(app_name.Text)

            application_data()
            GroupBox1.Enabled = False
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Application name updated successfully")


        End If


    End Sub

    Private Function check_existing_app(app_name As String)
        Try
            Dim conn As New pgConnect
            Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*", "app_name=@value1", app_name)
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As IO.IOException
            Return True
        End Try
    End Function

    Public Sub application_data()
        Try
            Dim count As Integer = 0
            Dim app = New TreeNode
            Dim conn As New pgConnect
            TreeView1.Nodes.Clear()
            'Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*")

            Dim Parent As NpgsqlDataReader = conn.GetRecords("applications", "*",,, "created_at DESC")

            While Parent.Read
                app = New TreeNode(Parent("app_name").ToString)
                app.Tag = Parent("id")
                TreeView1.Nodes.Add(app)
                count += 1
            End While
            ToolStripStatusLabel1.Text = "Application count : " & count

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub pi_fields()
        Try
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim pi = New TreeNode
            Dim Parent As NpgsqlDataReader = conn.GetRecords("pi_fields", "*", "pi_status=@value1", value)
            While Parent.Read
                pilist_box.Items.Add(Parent("pi_name"))
            End While
        Catch ex As IO.IOException
            '      MsgBox(ex.Message)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Function validate_pi()

        Dim checked_item As Integer = 0

        If app_name.Text = "" Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please fill application name")

            app_name.Focus()
            Return False
            Exit Function
        End If

        If app_description.Text = "" Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please fill application description")

            app_description.Focus()
            Return False
        End If

        If app_owner.Text = "" Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please fill application owner name")

            app_owner.Focus()
            Return False
        End If

        For i = 0 To pilist_box.Items.Count - 1
            Dim chkstate As CheckState
            chkstate = pilist_box.GetItemCheckState(i)
            If (chkstate = CheckState.Checked) Then
                checked_item += 1
            End If
        Next

        If checked_item <= 0 Then
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("Please select PI fields")

            Return False
        End If

        Return True
    End Function

    Public Sub sync_app_pi(app_name As String)

        Dim app_id As Integer = get_app_id(app_name)

        For i = 0 To pilist_box.Items.Count - 1
            If pilist_box.GetItemChecked(i) Then

                Dim pi_id As Integer = get_pi_id(pilist_box.Items(i).ToString)
                Dim value As String = app_id & "^" & pi_id
                Dim conn As New pgConnect
                Dim dr As NpgsqlDataReader = conn.GetRecords("application_pi", "*", "app_id=@value1 and pi_id=@value2", value)
                If dr.HasRows Then
                Else
                    Dim add As New pgConnect
                    Dim value2 As String = app_id & "^" & pi_id
                    add.InsertRecord("application_pi", "app_id,pi_id", value2)
                End If



            Else

                Dim pi_id As Integer = get_pi_id(pilist_box.Items(i).ToString)
                Dim value As String = app_id & "^" & pi_id
                Dim conn As New pgConnect
                Dim dr As NpgsqlDataReader = conn.GetRecords("application_pi", "*", "app_id=@value1 and pi_id=@value2", value)
                If dr.HasRows Then
                    While dr.Read
                        Dim del As New pgConnect
                        del.DeleteRecord("application_pi", dr("id"), "id=@value1")
                    End While
                End If
            End If

        Next
        'MsgBox("Sync Complete")
    End Sub

    Function get_app_id(app_name As String)

        Try
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*", "app_name=@value1", app_name)
            If dr.HasRows Then
                While dr.Read
                    Return dr("id")
                End While
            End If
        Catch ex As IO.IOException
            Return 0
        End Try

        Return 0

    End Function

    Function get_pi_id(app As String)

        Try
            Dim conn As New pgConnect
            Dim value As String = "true"
            Dim dr As NpgsqlDataReader = conn.GetRecords("pi_fields", "*", "pi_name=@value1", app)
            If dr.HasRows Then
                While dr.Read
                    Return dr("id")
                End While
            End If
        Catch ex As IO.IOException
            Return 0
        End Try

        Return 0

    End Function

    Public Sub get_app_pi_fields(app_id As Integer)

        For i = 0 To pilist_box.Items.Count - 1
            pilist_box.SetItemChecked(i, False)
        Next

        Dim conn As New pgConnect
        Dim dr As NpgsqlDataReader = conn.GetRecords("application_pi", "*", "app_id=@value1", app_id)
        While dr.Read

            Dim picon As New pgConnect
            Dim pi As NpgsqlDataReader = picon.GetRecords("pi_fields", "*", "id=@value1", dr("pi_id"))
            While pi.Read

                For i = 0 To pilist_box.Items.Count - 1
                    If pilist_box.Items(i).ToString() = pi("pi_name") Then
                        pilist_box.SetItemChecked(i, True)
                    End If
                Next
            End While
        End While

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs)
        sync_app_pi(app_name.Text)
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click

        GroupBox1.Enabled = True
        app_name.Text = Nothing
        app_description.Text = Nothing
        app_purpose.Text = Nothing
        app_owner.Text = Nothing
        cmd_submit.Text = "Add New"
        For i = 0 To pilist_box.Items.Count - 1
            pilist_box.SetItemChecked(i, False)
        Next


    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Try
            If selected_app = Nothing Then
                Dim msg1 As MsgBoxResult
                msg1 = MsgBox("Please select an application to edit")

                Exit Sub
            End If

            GroupBox1.Enabled = True
            cmd_submit.Text = "Update"
            Dim conn As New pgConnect
            Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*", "id=@value1", selected_app)
            If dr.HasRows Then
                While dr.Read
                    app_name.Text = dr("app_name")
                    app_description.Text = dr("app_description")
                    app_owner.Text = dr("app_owner")
                    Call get_app_pi_fields(dr("id"))
                End While


            End If
        Catch ex As IO.IOException

            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        selected_app = TreeView1.SelectedNode.Tag

        If GroupBox1.Enabled = False Then
            get_app_details(selected_app)
        End If
    End Sub

    Private Sub get_app_details(selected_app As Integer)
        Try
            Dim conn As New pgConnect
            Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*", "id=@value1", selected_app)
            If dr.HasRows Then
                While dr.Read
                    app_name.Text = dr("app_name").ToString
                    app_description.Text = dr("app_description").ToString
                    app_purpose.Text = dr("app_purpose").ToString
                    app_owner.Text = dr("app_owner").ToString
                    Call get_app_pi_fields(dr("id"))
                End While
            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim result As Integer = MessageBox.Show("Do you want to delete " & TreeView1.SelectedNode.Text & " application", "Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim conn As New pgConnect
                conn.DeleteRecord("applications", selected_app, "id=@value1")
                Call application_data()
                Dim msg1 As MsgBoxResult
                msg1 = MsgBox("Application deleted successfully")

            End If

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDataToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a DB file"
        OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OFD.Filter = "Excel Files|*.csv;"

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
            Upload.upload_type = "application_upload"
            Upload.Show()

        Catch ex As IO.IOException
            ' MsgBox(ex.Message.ToString)
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
End Class