Imports Npgsql
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Public Class NewUser
    Dim selected_user As Integer = Nothing
    Dim userid As Integer = Nothing
    Dim appid As Integer = Nothing
    Dim processid As Integer = Nothing


    Function get_user_id(empl_id As String)

        Try
            Dim conn As New dbconnect
            Dim value As String = "true"
            Dim dr As NpgsqlDataReader = conn.GetRecords("users", "*", "empl_id=@value1", empl_id)
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

    Function get_application_id(app As String)

        Try
            Dim conn As New dbconnect
            Dim value As String = "true"
            Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*", "app_name=@value1", app)
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

    Private Sub NewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call user_data()

        'Call list_view_load()



    End Sub

    Public Sub list_view_load()
        userid = TreeView2.SelectedNode.Tag
        processid = get_process_id()

        Consent_app.Clear()
        Consent_app.View = View.Details
        Consent_app.Columns.Add("Consent Status", 100, HorizontalAlignment.Left)
        Consent_app.Columns.Add("Application Name", 100)
        Consent_app.Columns.Add("User Comments", 200)
        Consent_app.Columns.Add("Supervisor/Revoker Comments", 200)
        Consent_app.CheckBoxes = True

        'Consent_app.Columns(0).DisplayIndex = Consent_app.Columns.Count - 1

        Dim conn As New pgConnect
        Dim str As String = selected_user & "^" & True & "^" & processid
        Dim dr As NpgsqlDataReader = conn.GetRecords("user_application", "*", "user_id=@value1 and status=@value2 and process_id=@value3", str)
        Dim row As String() = New String(4) {}
        Dim i As Integer = 0
        Dim item As ListViewItem
        While dr.Read


            'MsgBox(cfunctions.get_app_name_with_id(dr("application_id")))

            Dim field_return As String = Nothing
            Dim app_con As New pgConnect
            Dim app As NpgsqlDataReader = app_con.GetRecords("applications", "*", "id=@value1", dr("application_id"), "created_at Desc")
            If app.HasRows Then
                While app.Read
                    row(1) = app("app_name")
                    row(2) = app("app_description")
                    row(3) = get_app_pi(app("id")).ToString
                End While
            End If
            row(1) = cfunctions.get_app_name_with_id(dr("application_id"))
            row(2) = dr("user_comment").ToString
            row(3) = dr("supervisor_comment").ToString
            item = New ListViewItem(row)
            Consent_app.Items.Add(item)
            Consent_app.Items(i).Tag = dr("application_id")
            Consent_app.Items(i).Checked = dr("application_consent")
            i += 1
        End While

        For i = 1 To Consent_app.Items.Count
            'Consent_app.Items(0).Checked = True
        Next i






    End Sub

    Private Function get_app_pi(app_id As Integer)
        Dim pi_fields As String = Nothing
        Dim position As Integer = 0
        Dim conn As New pgConnect
        Dim dr As NpgsqlDataReader = conn.GetRecords("application_pi", "*", "app_id=@value1", app_id)
        If dr.HasRows Then
            While dr.Read
                Dim pi_conn As New pgConnect
                Dim pi As NpgsqlDataReader = pi_conn.GetRecords("pi_fields", "*", "id=@value1", dr("pi_id"))
                If pi.HasRows Then
                    While pi.Read
                        If position = 0 Then
                            pi_fields += pi("pi_name")
                            position += 1
                        Else
                            pi_fields += ", " & pi("pi_name")
                            position += 1
                        End If
                    End While
                End If
            End While
        End If

        Return pi_fields

    End Function

    Public Sub user_data()

        Try
            Dim count As Integer = 0
            Dim app = New TreeNode
            Dim crypt As New Encryption
            Dim conn As New pgConnect
            TreeView2.Nodes.Clear()
            'Dim dr As NpgsqlDataReader = conn.GetRecords("applications", "*")
            Dim value As String = Home.TP_Project & "^" & Home.TP_Process & "^" & Home.TP_SubProcess & "^" & "Active"
            Dim Parent As NpgsqlDataReader = conn.GetRecords("user_details", "*", "project=@value1 and process=@value2 and sub_process=@value3 and account_status=@value4", value, "user_id DESC")

            While Parent.Read
                app = New TreeNode(crypt.decrypt(Parent("first_name").ToString) & "," & crypt.decrypt(Parent("last_name").ToString))
                app.Tag = Parent("user_id")
                TreeView2.Nodes.Add(app)
                count += 1
            End While
            ToolStripStatusLabel1.Text = "Users count : " & count

        Catch ex As IO.IOException
            ' msg = MsgBox(ex.Message)
            Dim msg5 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Function check_existing_user(emplid As String)
        Try
            Dim conn As New dbconnect
            Dim dr As NpgsqlDataReader = conn.GetRecords("users", "*", "empl_id=@value1", emplid)
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As IO.IOException
            Return True
        End Try
    End Function


    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect
        selected_user = TreeView2.SelectedNode.Tag
        Me.Text = TreeView2.SelectedNode.Text
        Call list_view_load()
        Call row_color()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim msg As MsgBoxResult
        Try
            Dim result As Integer = MessageBox.Show("Do you want to delete " & TreeView2.SelectedNode.Text, "Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim conn As New dbconnect
                conn.DeleteRecord("users", selected_user, "id=@value1")
                Call user_data()
                msg = MsgBox("User deleted successfully")
            End If

        Catch ex As IO.IOException
            Dim msg3 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            ' msg = MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ViewConsentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application_Consent.userid = TreeView2.SelectedNode.Tag
        Application_Consent.Show()
    End Sub

    Private Sub first_name_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub chk_status_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RevokeConsentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Revoke_Consent.userid = TreeView2.SelectedNode.Tag
        'revoke_consent.Show()
    End Sub

    Private Sub ConsentStatusExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsentStatusExportToolStripMenuItem.Click
        Dim msg As MsgBoxResult
        Try
            'Dim SDate As String = Format(DateStart.Value, "dd-MMM-yy")
            'Dim EDate As String = Format(DateEnd.Value, "dd-MMM-yy")

            Dim value As String = "assa" & "^" & "asas" & "^" & "TM_SubProcess" & "^" & "SDate" & "^" & "EDate"

            Dim conn As New pgConnect
            Dim crypt As New Encryption

            conn.GetRecordsqryGRID("user_application", "*")


            Dim xlPackage As New ExcelPackage()
            Dim oBook As ExcelWorkbook = xlPackage.Workbook
            Dim ws As ExcelWorksheet = oBook.Worksheets.Add("Consent Status")

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
                    Dim str As String = dr(dc.ColumnName).ToString
                    If crypt.CheckEncryprion(str) = True Then
                        ws.Cells(rowIndex + 1, colIndex).Value = crypt.decrypt(str)
                    Else
                        ws.Cells(rowIndex + 1, colIndex).Value = str
                    End If
                Next
            Next


            Dim FBD As New FolderBrowserDialog
            Dim savepath As String
            If (FBD.ShowDialog() = DialogResult.OK) Then
                savepath = FBD.SelectedPath
            Else
                Exit Sub
            End If


            Dim excelFile As New FileInfo(savepath & "\" & "Consent Status Export" & ".xlsx")
            xlPackage.SaveAs(excelFile)
            msg = MsgBox("Data successfully exported to " & savepath, MsgBoxStyle.Information, "Exported")


        Catch ex As FileNotFoundException
            Dim msg2 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDataToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        Dim FilePath As String = Nothing

        OFD.Title = "Please select a input file"
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
            Upload.upload_type = "user_upload"
            Upload.Show()

        Catch ex As FileNotFoundException
            'msg = MsgBox(ex.Message.ToString)
            Dim msg3 As MsgBoxResult = MsgBox("Please Connect System Administrator")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
    Dim sss As String = Nothing

    Private Sub row_color()
        For i As Integer = 0 To Consent_app.Items.Count - 1
            'MsgBox(Consent_app.Items(i).SubItems(0).Tag)
            If Consent_app.Items(i).Checked = True Then
                Consent_app.Items(i).BackColor = Color.Green
            End If

            If Consent_app.Items(i).Checked = False And Consent_app.Items(i).SubItems(2).Text <> "" Then
                Consent_app.Items(i).BackColor = Color.Orange
            End If

            If Consent_app.Items(i).Checked = False And Consent_app.Items(i).SubItems(2).Text = "" Then
                Consent_app.Items(i).BackColor = Color.Red
            End If


        Next
    End Sub

    Private Sub Consent_app_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Consent_app.SelectedIndexChanged

        For aa As Integer = 0 To Consent_app.SelectedItems.Count - 1
            appid = Consent_app.Items(Consent_app.FocusedItem.Index).Tag
        Next
        lbl.Text = appid

        processid = get_process_id()

        If app_consent_status(userid, appid, processid) = True Then
            ReActivateConsentToolStripMenuItem.Enabled = False
            RevokeConsentToolStripMenuItem1.Enabled = True
        Else
            ReActivateConsentToolStripMenuItem.Enabled = True
            RevokeConsentToolStripMenuItem1.Enabled = False
        End If

    End Sub

    Private Sub RevokeConsentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RevokeConsentToolStripMenuItem1.Click
        Call revoke_consent()
        Call list_view_load()
        Call row_color()
    End Sub

    Private Sub ReActivateConsentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReActivateConsentToolStripMenuItem.Click
        Call reactivate_consent()
        Call list_view_load()
        Call row_color()
    End Sub

    Private Sub revoke_consent()
        Dim msg As MsgBoxResult
        Dim comments As String = Nothing
        Dim u_comments As String = Nothing

        'If on_revoke_check_for_supervisor_comment(userid, appid) = False Then
        '    comments = InputBox("Please provide a reason of revoking consent for " & Consent_app.SelectedItems(0).SubItems(1).Text, "Consent compliance")
        '    If comments = "" Then
        '        msg = MsgBox("Please proveide reason of revoking consent " & Consent_app.SelectedItems(0).SubItems(1).Text)
        '        Exit Sub
        '    End If
        'Else
        '    comments = get_supevisor_comment(userid, appid)
        'End If

        comments = InputBox("Please provide a reason of revoking consent for " & Consent_app.SelectedItems(0).SubItems(1).Text, "Consent compliance")
        If comments = "" Then
            msg = MsgBox("Please proveide reason of revoking consent " & Consent_app.SelectedItems(0).SubItems(1).Text)
            Exit Sub
        End If

        'End If

        Dim conn As New pgConnect
        Dim value As String = False & "^" & comments & "^" & userid & "^" & appid
        conn.UpdateRecord("user_application", "application_consent=@value1,supervisor_comment=@value2", value, "user_id=@value3 and application_id=@value4")
        comments = Nothing

        'Next
    End Sub

    Private Sub reactivate_consent()
        Dim comments As String = Nothing
        Dim u_comments As String = Nothing

        'If on_revoke_check_for_supervisor_comment(userid, appid) = False Then
        '    comments = InputBox("Please provide a reason of revoking consent for " & Consent_app.SelectedItems(0).SubItems(1).Text, "Consent compliance")
        '    If comments = "" Then
        '        MsgBox("Please proveide reason of revoking consent " & Consent_app.SelectedItems(0).SubItems(1).Text)
        '        Exit Sub
        '    End If
        'Else
        '    comments = get_supevisor_comment(userid, appid)
        'End If

        'End If
        comments = InputBox("Please provide a reason reactivation consent for " & Consent_app.SelectedItems(0).SubItems(1).Text, "Consent compliance")
        If comments = "" Then
            MsgBox("Please provide a reason reactivation consent " & Consent_app.SelectedItems(0).SubItems(1).Text)
            Exit Sub
        End If

        Dim conn As New pgConnect
        Dim value As String = False & "^" & Nothing & "^" & comments & "^" & userid & "^" & appid
        conn.UpdateRecord("user_application", "application_consent=@value1,user_comment=@value2,supervisor_comment=@value3", value, "user_id=@value4 and application_id=@value5")
        comments = Nothing


    End Sub


    'Private Sub Consent_app_Click(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles Consent_app.Click
    '    'MsgBox(Consent_app.Items(Consent_app.FocusedItem.Index).Tag.ToString)
    'End Sub

    'Private Sub Consent_app_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    'For i = 0 To Consent_app.Items.Count - 1
    '    '    lbl.Text = Consent_app.SelectedIndices(i)
    '    '    'tag = Consent_app.SelectedItems(i).Tag.ToString
    '    'Next
    '    MsgBox(Consent_app.SelectedItems(0).Text)

    '    For aa As Integer = 0 To Consent_app.SelectedItems.Count - 1

    '    Next
    '    'lbl.Text = Consent_app.SelectedIndices(aa)
    '    'MsgBox(Consent_app.Items(Consent_app.FocusedItem.Index).Tag.ToString)
    '    'MsgBox(Consent_app.Items(Consent_app.FocusedItem.Index).Tag.ToString)
    '    'sss = Consent_app.SelectedItems(0).Text 'Consent_app.Items(Consent_app.FocusedItem.Index).Tag.ToString
    '    'lbl.Text = sss
    'End Sub

    'Private Sub Consent_app_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Consent_app.SelectedIndexChanged

    'End Sub
End Class