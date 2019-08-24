Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.IO
Imports Npgsql
Public Class ThinkProfiles
    Dim Msg As MsgBoxResult
    Dim Project As String = Nothing
    Dim Process As String = Nothing
    Dim SubProcess As String = Nothing
    Dim ProjectID As Integer = Nothing

    Private Sub ThinkProfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call TreeLoad()
        Call ProfileLoad()
        Call user_detail_load()

    End Sub

    Sub ProfileLoad()
        Dim conn As New pgConnect
        Dim var As New Encryption

        var.Encrypt(My.Settings.EmplID)
        Dim eid As String = var.encr

        Dim reader As NpgsqlDataReader = conn.GetRecords("think_profile", "*", "empl_id=@value1", eid)
        While reader.Read

            If reader("profile").ToString = "Default" Then
                lblid1.Text = reader("project_id").ToString
                lblProjectp1.Text = reader("project").ToString
                lblProcessp1.Text = reader("process").ToString
                lblSubProcessp1.Text = reader("sub_process").ToString

            ElseIf reader("profile").ToString = "Profile-2" Then
                lblid2.Text = reader("project_id").ToString
                lblProjectp2.Text = reader("project").ToString
                lblProcessp2.Text = reader("process").ToString
                lblSubProcessp2.Text = reader("sub_process").ToString

            ElseIf reader("profile").ToString = "Profile-3" Then
                lblid3.Text = reader("project_id").ToString
                lblProjectp3.Text = reader("project").ToString
                lblProcessp3.Text = reader("process").ToString
                lblSubProcessp3.Text = reader("sub_process").ToString

            ElseIf reader("profile").ToString = "Profile-4" Then
                lblid4.Text = reader("project_id").ToString
                lblProjectp4.Text = reader("project").ToString
                lblProcessp4.Text = reader("process").ToString
                lblSubProcessp4.Text = reader("sub_process").ToString

            End If



        End While




    End Sub

    Sub user_detail_load()
        Dim conn As New pgConnect
        Dim var As New Encryption

        var.Encrypt(My.Settings.EmplID)
        Dim eid As String = var.encr

        Dim reader As NpgsqlDataReader = conn.GetRecords("user_details", "first_name,last_name", "empl_id=@value1", eid)
        While reader.Read
            txt_first_name.Text = var.decrypt(reader("first_name"))
            txt_last_name.Text = var.decrypt(reader("last_name"))
        End While



    End Sub


    Private Sub TreeLoad()
        TreeView1.Nodes.Clear()
        Dim conn As New pgConnect
        Dim Project = New TreeNode
        Dim Process = New TreeNode
        Dim SubProcess = New TreeNode
        Dim UName = New TreeNode
        Dim SubSubChildnode = New TreeNode

        Dim Parent As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT project")
        While Parent.Read
            Project = New TreeNode(Parent("project").ToString)
            TreeView1.Nodes.Add(Project)

            conn.Connect()
            Dim value As String = Parent("project")
            Dim child As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT process", "project =@value1", value)
            While child.Read
                Process = New TreeNode(child("process").ToString)
                Project.Nodes.Add(Process)

                conn.Connect()
                Dim value2 As String = Parent("project") & "^" & child("process")
                Dim subchild As NpgsqlDataReader = conn.GetRecords("project_details", "DISTINCT sub_process,project_id", "project =@value1 AND process =@value2", value2)
                While subchild.Read
                    SubProcess = New TreeNode(subchild("sub_process"))
                    SubProcess.Tag = subchild("project_id")
                    Process.Nodes.Add(SubProcess)

                    'conn.Connect()

                    'Dim enc As New Encryption
                    'Dim prjt As String = Parent("project")
                    'Dim prcs As String = child("process")
                    'Dim sprcs As String = subchild("sub_process")

                    'Dim value3 As String = prjt & "^" & prcs & "^" & sprcs
                    'Dim namechild As NpgsqlDataReader = conn.GetRecords("user_details", "empl_id,first_name,last_name", "project =@value1 AND process =@value2 AND sub_process =@value3", value3, "first_name DESC")
                    'While namechild.Read
                    '    UName = New TreeNode(enc.decrypt(namechild("first_name").ToString) & "," & enc.decrypt(namechild("last_name").ToString))
                    '    SubProcess.Nodes.Add(UName)
                    '    UName.Tag = namechild("empl_id")


                    'End While
                End While
            End While
        End While
    End Sub

    Private Sub SetProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetProfileToolStripMenuItem.Click
        Dim msg, msg1, msg2 As MsgBoxResult
        If ProfileCheck("Profile-2") = True Then
            msg = MsgBox("Profile already Exists", vbInformation, "Oops!")
            Exit Sub
        End If

        If SubProcess = Nothing Then
            msg1 = MsgBox("Please select Sub Process", vbInformation, "Oops!")
            Exit Sub
        End If


        Dim conn As New pgConnect
        Dim var As New Encryption
        var.Encrypt(My.Settings.EmplID)
        Dim eid As String = var.encr
        
        Dim value As String = eid & "^" & My.Settings.Name & "^" & ProjectID & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Process & "-" & SubProcess & "^" & "Profile-2"
        conn.InsertRecord("think_profile", "empl_id,name,project_id,project,process,sub_process,profile_name,profile", value)
        Call ProfileLoad()
        msg2 = MsgBox("Profile created successfully", vbInformation, "Success")

    End Sub 'Profile-2

    Private Sub SetProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SetProfileToolStripMenuItem1.Click
        Dim msg, msg1 As MsgBoxResult
        If ProfileCheck("Profile-3") = True Then
            msg = MsgBox("Profile already Exists", vbInformation, "Oops!")
            Exit Sub
        End If

        If SubProcess = Nothing Then
            msg1 = MsgBox("Please select Sub Process", vbInformation, "Oops!")
            Exit Sub
        End If

        Dim conn As New pgConnect
        Dim var As New Encryption
        var.Encrypt(My.Settings.EmplID)
        Dim eid As String = var.encr
      
        Dim value As String = eid & "^" & My.Settings.Name & "^" & ProjectID & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Process & "-" & SubProcess & "^" & "Profile-3"
        conn.InsertRecord("think_profile", "empl_id,name,project_id,project,process,sub_process,profile_name,profile", value)
        Call ProfileLoad()
        Dim msg2 As MsgBoxResult
        msg2 = MsgBox("Profile created successfully", vbInformation, "Success")

    End Sub 'profile-3

    Private Sub SetProfileToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SetProfileToolStripMenuItem2.Click
        Dim msg, msg1, msg2 As MsgBoxResult

        If ProfileCheck("Profile-4") = True Then
            msg = MsgBox("Profile already Exists", vbInformation, "Oops!")
            Exit Sub
        End If

        If SubProcess = Nothing Then
            msg1 = MsgBox("Please select Sub Process", vbInformation, "Oops!")
            Exit Sub
        End If

        Dim conn As New pgConnect
        Dim var As New Encryption
        var.Encrypt(My.Settings.EmplID)
        Dim eid As String = var.encr
     

        Dim value As String = eid & "^" & My.Settings.Name & "^" & ProjectID & "^" & Project & "^" & Process & "^" & SubProcess & "^" & Process & "-" & SubProcess & "^" & "Profile-4"
        conn.InsertRecord("think_profile", "empl_id,name,project_id,project,process,sub_process,profile_name,profile", value)
        Call ProfileLoad()
        msg2 = MsgBox("Profile created successfully", vbInformation, "Success")

    End Sub 'profile-4

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        If TreeView1.SelectedNode.Level = 2 Then
            Profile2ToolStripMenuItem.Enabled = True
            Profile3ToolStripMenuItem.Enabled = True
            Profile4ToolStripMenuItem.Enabled = True

            Project = TreeView1.SelectedNode.Parent.Parent.Text
            Process = TreeView1.SelectedNode.Parent.Text
            SubProcess = TreeView1.SelectedNode.Text
            ProjectID = TreeView1.SelectedNode.Tag

        Else
            Profile2ToolStripMenuItem.Enabled = False
            Profile3ToolStripMenuItem.Enabled = False
            Profile4ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Function ProfileCheck(ProfileName As String)
        Try
            Dim conn As New pgConnect
            Dim var As New Encryption

            var.Encrypt(My.Settings.EmplID)
            Dim eid As String = var.encr
            Dim value As String = eid & "^" & ProfileName
            Dim reader As NpgsqlDataReader = conn.GetRecords("think_profile", "*", "empl_id=@value1 AND profile =@value2", value)

            If reader.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As IO.IOException
            Return True
        End Try

    End Function

    Private Sub DeleteProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProfileToolStripMenuItem.Click

        Call DeleteProfile(My.Settings.EmplID, "Profile-2")


    End Sub

    Private Sub DeleteProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteProfileToolStripMenuItem1.Click

        Call DeleteProfile(My.Settings.EmplID, "Profile-3")


    End Sub

    Private Sub DeleteProfileToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteProfileToolStripMenuItem2.Click

        Call DeleteProfile(My.Settings.EmplID, "Profile-4")


    End Sub

    Sub DeleteProfile(Emplid As String, Profilename As String)

        Dim msg As MsgBoxResult
        Dim conn As New pgConnect
        Dim var As New Encryption
        var.Encrypt(Emplid)
        Dim eid As String = var.encr
        
        Dim value As String = eid & "^" & Profilename
        conn.DeleteRecord("think_profile", value, "empl_id =@value1 AND profile =@value2")
        Call ProfileLoad()
        msg = MsgBox("Profile deleted successfully", vbInformation, "Deleted")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim msg As MsgBoxResult = MsgBox(SubProcess)
    End Sub

    Private Sub cmd_update_Click(sender As Object, e As EventArgs) Handles cmd_update.Click
        Dim msg, msg1, msg2 As MsgBoxResult
        Try

            If txt_first_name.Text = "" Then
                msg = MsgBox("First name is missing")
                txt_first_name.Focus()
                Exit Sub
            End If
            If txt_first_name.Text = "" Then
                msg1 = MsgBox("Last name is missing")
                txt_last_name.Focus()
                Exit Sub
            End If

            Dim conn As New pgConnect
            Dim enc As New Encryption

            'enc.Encrypt(Home.TP_EmplID)
            'MsgBox(enc.EncryptNew(Home.TP_EmplID))

            Dim value As String = enc.EncryptNew(txt_first_name.Text) & "^" & enc.EncryptNew(txt_last_name.Text) & "^" & enc.EncryptNew(Home.TP_EmplID)

            'Dim value As String = enc.decrypt(reader("name").ToString) & "^" & reader("id")
            conn.UpdateRecord("user_details", "first_name=@value1,last_name=@value2", value, "empl_id=@value3")
            msg2 = MsgBox("Data updated successfully")

        Catch ex As Exception
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub
End Class