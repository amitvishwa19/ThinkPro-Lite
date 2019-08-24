Imports System.Data.OleDb
Imports System.IO
Imports System.Environment
Imports System.Net
Imports System.Net.Dns
Public Class MyDetails_del

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.SkyBlue, rect)
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs)
        'On Error Resume Next
        Me.Close()
    End Sub

    Private Sub txtFirstName_TextChanged_1(sender As Object, e As EventArgs)
        txtname.Text = txtFirstName.Text & " " & txtLastName.Text
    End Sub

    Private Sub txtLastName_TextChanged_1(sender As Object, e As EventArgs)
        txtname.Text = txtFirstName.Text & " " & txtLastName.Text
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs)
        Call DetailsUpdate()
    End Sub

    Private Sub MyDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If DBConn.State = True Then
            DBConn.Close()
        End If
    End Sub

    Public Sub Userlan()

        Dim parts() As String = Split(My.User.Name, "\")
        Dim username As String = parts(1)
        MsgBox(username)


    End Sub

    Private Sub MyDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        If DBConn.State = True Then
            DBConn.Close()
        Else
        End If

        lblEmplID.Text = Home.lblEmplID.Text
        lblName.Text = Home.lblName.Text
        FillProjectTree()


        Me.fillProject()
        Me.fillProcess()
        Me.fillSubProcess()
        Me.Secretquestion1()
        Me.secretquestion2()
        Me.secretquestion3()

        Call DetailsFill() '''''''''''''''''''''Getting All Details
        Call GetProfilePic() '''''''''''''''''''Getting My Pic
        Call FillProfileInfo() '''''''''''''''''Getting Profile Info
        Call filllogindetails() '''''''''''''''''Secret question and passwords
        ''''''''''''''Setting Background Image
        'If My.Settings.BackImage = "None" Then
        '    Exit Sub
        'Else
        '    Dim ResourceName As String = My.Settings.BackImage
        '    Me.BackgroundImage = My.Resources.ResourceManager.GetObject(ResourceName)
        '    Me.BackgroundImageLayout = ImageLayout.Stretch
        'End If


        'TabPage1.BackColor = Color.Transparent
        'TabControl.BackColor = Color.Transparent
        'TabPage2.BackgroundImage = My.Resources.GreayBAck



        txtAssetID.Text = System.Net.Dns.GetHostName()
        txtlanID.Text = Environment.UserName

    End Sub

    Sub fillProject()
        Try
            DBConnect.ConnectDB()
            strsql = "Select DISTINCT Project from ProjectDetails"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbProject.Items.Add(DBaccess("Project"))
            End While

            cmdinp.Dispose()
            DBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillProcess()
        Try
            DBConnect.ConnectDB()
            strsql = "Select DISTINCT Process from ProjectDetails"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbProcess.Items.Add(DBaccess("Process"))
            End While

            cmdinp.Dispose()
            DBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillSubProcess()
        Try
            DBConnect.ConnectDB()
            strsql = "Select DISTINCT SubProcess from ProjectDetails"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbSubProcess.Items.Add(DBaccess("SubProcess"))
            End While

            cmdinp.Dispose()
            DBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Secretquestion1()

        Try
            DBConnect.ConnectDB() '''''''''DB Connection Open
            strsql = "Select DISTINCT SecrecQuestion from Applist"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbquest1.Items.Add(DBaccess("SecrecQuestion"))
            End While

            DBConn.Close() ''''''''''''''''Db Connection Close
            cmdinp.Dispose()
            DBaccess.Close()
        Catch ex As Exception
            DBConn.Close() ''''''''''''''''Db Connection Close
        End Try

    End Sub

    Private Sub secretquestion2()
        Try
            DBConnect.ConnectDB() '''''''''DB Connection Open
            strsql = "Select DISTINCT SecrecQuestion from Applist"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbquest2.Items.Add(DBaccess("SecrecQuestion"))
            End While

            DBConn.Close() ''''''''''''''''Db Connection Close
            cmdinp.Dispose()
            DBaccess.Close()
        Catch ex As Exception
            DBConn.Close() ''''''''''''''''Db Connection Close
        End Try

    End Sub

    Private Sub secretquestion3()

        Try
            DBConnect.ConnectDB() '''''''''DB Connection Open
            strsql = "Select DISTINCT SecrecQuestion from Applist"
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())
                cmbquest3.Items.Add(DBaccess("SecrecQuestion"))
            End While

            DBConn.Close() ''''''''''''''''Db Connection Close
            cmdinp.Dispose()
            DBaccess.Close()
        Catch ex As Exception
            DBConn.Close() ''''''''''''''''Db Connection Close
        End Try

    End Sub


    Sub DetailsFill()

        Try
            DBConnect.ConnectDB()
            strsql = "Select * from UserDetails where EmplID=" & Home.lblEmplID.Text & ""
            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader


            While (DBaccess.Read())
                'Dim mPic As Byte = DBaccess("Picture")

                'Personal Details
                txtFirstName.Text = (DBaccess("FirstName").ToString)
                txtLastName.Text = (DBaccess("LastName").ToString)
                txtname.Text = (DBaccess("Name").ToString)
                txtDOB.Text = (DBaccess("DOB").ToString)
                txtGender.Text = (DBaccess("Gender").ToString)
                txtBloodGroup.Text = (DBaccess("BloodGroup").ToString)
                txtQualification.Text = (DBaccess("Qualification").ToString)
                txtPrimaryContact.Text = (DBaccess("ContactDetails").ToString)
                txtAddress.Text = (DBaccess("Address").ToString)

                txtemplID.Text = (DBaccess("EmplID").ToString)
                txtPassword.Text = (DBaccess("Password").ToString)


                'Work Details  
                txtBpoGrade.Text = (DBaccess("Grade").ToString)
                txtDesignation.Text = (DBaccess("Designation").ToString)
                txtlanID.Text = (DBaccess("LanID").ToString)
                txtDoj.Text = (DBaccess("DOJ").ToString)
                txtWorkExp.Text = (DBaccess("WorkExperience").ToString)
                txtCompnmail.Text = (DBaccess("CompanyMail").ToString)
                txtProjectMail.Text = (DBaccess("ProjectMail").ToString)
                txtRole.Text = (DBaccess("Role").ToString)
                txtStatus.Text = (DBaccess("Status").ToString)
                txtBilling.Text = (DBaccess("Billing").ToString)
                txtUtilization.Text = (DBaccess("Utilization").ToString)
                cmbProject.Text = (DBaccess("Project").ToString)
                cmbSubProcess.Text = (DBaccess("SubPRocess").ToString)
                cmbProcess.Text = (DBaccess("Process").ToString)
                txtProcLead.Text = (DBaccess("ProcessLead").ToString)
                txtPromanager.Text = (DBaccess("ProcessManager").ToString)
                txtShift.Text = (DBaccess("ShiftDetails").ToString)
                txtShiftstrtTime.Text = (DBaccess("ShiftStart").ToString)
                txtShiftEndTime.Text = (DBaccess("ShiftEnd").ToString)
                txtSwon.Text = (DBaccess("swon").ToString)

                'Asset Details
                txtaccesscard.Text = (DBaccess("AccessCardNo").ToString)
                txtAssetID.Text = (DBaccess("AssetID").ToString)
                txtIPadd.Text = (DBaccess("IPAddress").ToString)
                txtExtn.Text = (DBaccess("WorkPhone").ToString)
                txtDesk.Text = (DBaccess("DeskID").ToString)

                ''pic box fill
                ' ypicbox.Image = DBaccess("Picture")
                'Dim pictureData As Byte() = DirectCast(cmdinp.ExecuteScalar(), Byte())



            End While

            cmdinp.Dispose()
            DBConn.Close()
        Catch ex As Exception
            DBConn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub filllogindetails()
        Try
            DBConnect.ConnectDB()

            strsql = "Select * from UserDetails where EmplID=" & Home.lblEmplID.Text & ""

            Dim cmdinp As New OleDb.OleDbCommand
            cmdinp.CommandText = strsql
            cmdinp.Connection = DBConn

            DBaccess = cmdinp.ExecuteReader

            While (DBaccess.Read())


                cmbquest1.Text = (DBaccess("SecrecQuestion1").ToString)
                txtsecans1.Text = (DBaccess("SecrecAnswer1").ToString)
                cmbquest2.Text = (DBaccess("SecrecQuestion2").ToString)
                txtsecans2.Text = (DBaccess("SecrecAnswer2").ToString)
                cmbquest3.Text = (DBaccess("SecrecQuestion3").ToString)
                txtsecans3.Text = (DBaccess("SecrecAnswer3").ToString)


            End While

            cmdinp.Dispose()
            DBConn.Close()
        Catch ex As Exception
            DBConn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DetailsUpdate()



        'DBConnect.ConnectDB()
        'Dim fsreader As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
        'Dim breader As New BinaryReader(fsreader)
        'Dim imgbuffer(fsreader.Length) As Byte
        'breader.Read(imgbuffer, 0, fsreader.Length)
        'fsreader.Close()

        Dim ConnString As String
        ConnString = DBMain
        DBConn.ConnectionString = ConnString
        DBConn.Open()
        Dim str As String

        str = "update [UserDetails] set [FirstName] = '" & txtFirstName.Text &
                "',[LastName] = '" & txtLastName.Text &
                "',[Name] = '" & txtname.Text &
                "',[DOB] = '" & txtDOB.Text &
                "',[Gender] = '" & txtGender.Text &
                "',[BloodGroup] = '" & txtBloodGroup.Text &
                "',[Qualification] = '" & txtQualification.Text &
                "',[WorkExperience] = '" & txtWorkExp.Text &
                "',[ContactDetails] = '" & txtPrimaryContact.Text &
                "',[Address] = '" & txtAddress.Text &
                "',[Grade] = '" & txtBpoGrade.Text &
                "',[Designation] = '" & txtDesignation.Text &
                "',[LanID] = '" & txtlanID.Text &
                "',[swon] = '" & txtSwon.Text &
                "',[DOJ] = '" & txtDoj.Text &
                "',[CompanyMail] = '" & txtCompnmail.Text &
                "',[projectMail] = '" & txtProjectMail.Text &
                "',[Role] = '" & txtRole.Text &
                "',[Billing] = '" & txtBilling.Text &
                "',[Utilization] = '" & txtUtilization.Text &
                "',[Status] = '" & txtStatus.Text &
                "',[ShiftDetails] = '" & txtShift.Text &
                "',[ShiftStart] = '" & txtShiftstrtTime.Text &
                "',[ShiftEnd] = '" & txtShiftEndTime.Text &
                "',[Project] = '" & cmbProject.Text &
                "',[Process] = '" & cmbProcess.Text &
                "',[SubProcess] = '" & cmbSubProcess.Text &
                "',[ProcessLead] = '" & txtProcLead.Text &
                "',[ProcessManager] = '" & txtPromanager.Text &
                "',[AccessCardNo] = '" & txtaccesscard.Text &
                "',[AssetID] = '" & txtAssetID.Text &
                "',[IPAddress] = '" & txtIPadd.Text &
                "',[WorkPhone] = '" & txtExtn.Text &
                "',[DeskID] = '" & txtDesk.Text &
                "',[EmplID] = '" & txtemplID.Text &
                "',[Password] = '" & txtPassword.Text &
                "',[SecrecQuestion1] = '" & cmbquest1.Text &
                "',[SecrecQuestion2] = '" & cmbquest2.Text &
                "',[SecrecQuestion3] = '" & cmbquest3.Text &
                "',[SecrecAnswer1] = '" & txtsecans1.Text &
                "',[SecrecAnswer2] = '" & txtsecans2.Text &
                "',[SecrecAnswer3] = '" & txtsecans3.Text &
                "' Where [EmplID] = " & Home.lblEmplID.Text & ""

        Dim cmd As OleDbCommand = New OleDbCommand(str, DBConn)


        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            DBConn.Close()
            'DBaccess.Close()
            Call SaveMyPic()
            MsgBox("Details Saved ", vbInformation, "Saved")

        Catch ex As Exception
            DBConn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub SaveMyPic()

        On Error GoTo out

        Dim fsreader As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
        Dim breader As New BinaryReader(fsreader)


        Dim ms As New MemoryStream
        Dim arrimage(fsreader.Length) As Byte
        If (mypicbox.Image IsNot Nothing) Then
            mypicbox.Image.Save(ms, mypicbox.Image.RawFormat)
            arrimage = ms.GetBuffer
            ms.Close()
        End If


        Dim ConnString As String
        ConnString = DBMain
        DBConn.ConnectionString = ConnString
        DBConn.Open()
        Dim str As String
        ' str = "Insert into EmpDetails([Name],[EmplID],[Picture]) values(@1,@2,@3)"
        str = "Update UserDetails SET Picture=@3 where EmplID=" & Home.lblEmplID.Text & ""

        Dim cmd As OleDbCommand = New OleDbCommand(str, DBConn)
        'cmd.Parameters.Add(New OleDbParameter("name", CType(txtname.Text, String)))
        'cmd.Parameters.Add("@1", OleDbType.VarChar).Value = lblName.Text
        'cmd.Parameters.Add("@2", OleDbType.Integer).Value = lblEmplID.Text
        cmd.Parameters.Add("@3", OleDbType.Binary).Value = IIf(mypicbox.Image IsNot Nothing, arrimage, DBNull.Value)



        cmd.ExecuteNonQuery()
        cmd.Dispose()
        DBConn.Close()

        'MsgBox(OpenFileDialog1.FileName.ToString)
        'MsgBox("Details Saved ", vbInformation, "Saved")
        DBConn.Close()
out:
    End Sub

    Private Sub GetProfilePic()
        Try
            Dim ConnString As String
            ConnString = DBMain
            DBConn.ConnectionString = ConnString
            DBConn.Open()

            Dim strn As String
            strn = "select Picture From Userdetails where EmplID=" & Home.lblEmplID.Text & ""
            Dim cmd As OleDbCommand = New OleDbCommand(strn, DBConn)

            Using cmd
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strn

                Using oleDbReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
                    oleDbReader.Read()

                    Dim ImageBytes As Byte() = CType(oleDbReader(0), Byte())
                    Dim ms As New MemoryStream(ImageBytes)
                    Dim img As Image = Image.FromStream(ms)
                    Me.mypicbox.Image = img
                    Me.MyProfilePic.Image = img

                End Using
            End Using
            DBConn.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub FillProjectTree()
        TreeView1.Nodes.Clear()

        Try
            DBConnect.ConnectDB()

            ''''''''''''''''''''''''''''''ParentNode----Project
            Dim DSP As New DataSet
            Dim DAP As New OleDbDataAdapter("SELECT Distinct Project FROM ProjectDetails", DBConn)
            DSP.Clear()
            DAP.Fill(DSP)

            Dim i As Integer
            For i = 0 To DSP.Tables(0).Rows.Count - 1
                Dim Parentnode = New TreeNode
                Parentnode = New TreeNode(DSP.Tables(0).Rows(i).Item(0).ToString)
                TreeView1.Nodes.Add(Parentnode)

                ''''''''''''''''''''''''''''''Childnode1----Process
                Dim DSC1 As New DataSet
                Dim DAC1 As New OleDbDataAdapter("SELECT Distinct Process FROM ProjectDetails where Project='" & Parentnode.Text & "'", DBConn)
                DSC1.Clear()
                DAC1.Fill(DSC1)

                Dim ii As Integer
                For ii = 0 To DSC1.Tables(0).Rows.Count - 1
                    Dim Childnode1 = New TreeNode
                    Childnode1 = New TreeNode(DSC1.Tables(0).Rows(ii).Item(0).ToString)
                    'TreeView1.Nodes.Add(Parentnode)
                    Parentnode.Nodes.Add(Childnode1)

                    ''''''''''''''''''''''''''''''Childnode2----SubProcess
                    Dim DSC2 As New DataSet
                    Dim DAC2 As New OleDbDataAdapter("SELECT Distinct SubProcess,ProjectID FROM ProjectDetails where Project='" & Parentnode.Text & "' And Process='" & Childnode1.Text & "'", DBConn)
                    DSC2.Clear()
                    DAC2.Fill(DSC2)

                    Dim iii As Integer
                    For iii = 0 To DSC2.Tables(0).Rows.Count - 1
                        Dim Childnode2 = New TreeNode
                        Childnode2 = New TreeNode(DSC2.Tables(0).Rows(iii).Item(0).ToString)
                        Childnode1.Nodes.Add(Childnode2)

                        ''''''''''''''''''''''''''''''Childnode3----USers
                        Dim DSC3 As New DataSet
                        Dim DAC3 As New OleDbDataAdapter("SELECT Distinct Name FROM UserDetails where Project='" & Parentnode.Text & "' And Process='" & Childnode1.Text & "' And SubProcess='" & Childnode2.Text & "' And Status='" & "Active" & "'", DBConn)
                        DSC3.Clear()
                        DAC3.Fill(DSC3)


                    Next '''''''''''''''''''Childnode2----SubProcess
                Next '''''''''''''''''''''''Childnode1----Process
            Next '''''''''''''''''''''''''''Parentnode----Project

            DBConn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdEditP1_Click(sender As Object, e As EventArgs) Handles cmdEditP1.Click

        TreeView1.Visible = True

        Profile1.BackColor = Color.SkyBlue
        Profile2.BackColor = Color.Transparent
        Profile3.BackColor = Color.Transparent

        profilepic1.Enabled = True

        CheckBox1.Checked = True
        CheckBox2.Checked = False
        CheckBox3.Checked = False



        If lblProjectp1.Text = "Project" Then
            cmdAdd1.Visible = True
            cmdSavep1.Visible = False
        Else
            cmdAdd1.Visible = False
            cmdSavep1.Visible = True
        End If

        cmdEditP1.Visible = False


        lblProfile.Text = "Default Profile"
        lblProfilename.Text = Profile1.Text
        lblProject.Text = lblProjectp1.Text
        lblProcess.Text = lblProcessp1.Text
        lblSubProcess.Text = lblSubProcessp1.Text
        lblID.Text = lblid1.Text


    End Sub

    Private Sub cmdEditP2_Click(sender As Object, e As EventArgs) Handles cmdEditP2.Click

        TreeView1.Visible = True
        Profile1.BackColor = Color.Transparent
        Profile2.BackColor = Color.SkyBlue
        Profile3.BackColor = Color.Transparent

        profilepic2.Enabled = True

        CheckBox1.Checked = False
        CheckBox2.Checked = True
        CheckBox3.Checked = False

        cmdEditP2.Visible = False
        If lblProjectp2.Text = "Project" Then
            cmdAdd2.Visible = True
            cmdSavep2.Visible = False
        Else
            cmdAdd2.Visible = False
            cmdSavep2.Visible = True
        End If

        lblProfile.Text = "Profile 2"
        lblProfilename.Text = Profile2.Text
        lblProject.Text = lblProjectp2.Text
        lblProcess.Text = lblProcessp2.Text
        lblSubProcess.Text = lblSubProcessp2.Text
        lblID.Text = lblid2.Text

    End Sub

    Private Sub cmdEditP3_Click(sender As Object, e As EventArgs) Handles cmdEditP3.Click

        TreeView1.Visible = True
        Profile1.BackColor = Color.Transparent
        Profile2.BackColor = Color.Transparent
        Profile3.BackColor = Color.SkyBlue

        profilepic3.Enabled = True

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = True


        If lblProjectp3.Text = "Project" Then
            cmdAdd3.Visible = True
            cmdSavep3.Visible = False
        Else
            cmdAdd3.Visible = False
            cmdSavep3.Visible = True
        End If

        lblProfile.Text = "Profile 3"
        lblProfilename.Text = Profile3.Text
        lblProject.Text = lblProjectp3.Text
        lblProcess.Text = lblProcessp3.Text
        lblSubProcess.Text = lblSubProcessp3.Text
        lblID.Text = lblid3.Text

    End Sub

    Private Sub cmdEditP4_Click(sender As Object, e As EventArgs) Handles cmdEditP4.Click

        TreeView1.Visible = True
        Profile1.BackColor = Color.Transparent
        Profile2.BackColor = Color.Transparent
        Profile3.BackColor = Color.Transparent
        Profile4.BackColor = Color.SkyBlue

        profilepic4.Enabled = True

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = True


        If lblProjectp4.Text = "Project" Then
            cmdAdd4.Visible = True
            cmdSavep4.Visible = False
        Else
            cmdAdd4.Visible = False
            cmdSavep4.Visible = True
        End If

        lblProfile.Text = "Profile 4"
        lblProfilename.Text = Profile4.Text
        lblProject.Text = lblProjectp4.Text
        lblProcess.Text = lblProcessp4.Text
        lblSubProcess.Text = lblSubProcessp4.Text
        lblID.Text = lblid4.Text

    End Sub

    Private Sub UpdateProfile()
        DBConnect.ConnectDB()
        Dim str As String

        'str = "UPDATE EmpDetails([FirstName])"
        str = "update [ThinkProfile] set [EmplID] = '" & lblEmplID.Text &
                "',[UserName] = '" & lblName.Text &
                "',[Project] = '" & lblProject.Text &
                "',[Process] = '" & lblProcess.Text &
                "',[SubProcess] = '" & lblSubProcess.Text &
                "',[Profile] = '" & lblProfile.Text &
                "',[ProfileName] = '" & lblProfilename.Text &
                "' Where [EmplID] = " & lblEmplID.Text & " and [ID]=" & lblID.Text & ""

        Dim cmd As OleDbCommand = New OleDbCommand(str, DBConn)
        'cmd.Parameters.Add(New OleDbParameter("Picture", mypicbox.Image))

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            DBConn.Close()
            MsgBox("Details Saved ", vbInformation, "Saved")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddProfile()

        Dim DBConn As New OleDbConnection
        Dim ConnString As String
        ConnString = DBMain

        DBConn.ConnectionString = ConnString
        DBConn.Open()

        Dim str As String
        str = "Insert into ThinkProfile([EmplID],[USerName],[Project],[Process],[SubProcess],[Profile],[ProfileName]) values(?,?,?,?,?,?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, DBConn)

        cmd.Parameters.Add(New OleDbParameter("EmplID", CType(Home.lblEmplID.Text, Integer)))
        cmd.Parameters.Add(New OleDbParameter("UserName", CType(Home.lblName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Project", CType(lblProject.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Process", CType(lblProcess.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("SubProcess", CType(lblSubProcess.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Profile", CType(lblProfile.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("ProfileName", CType(lblProfilename.Text, String)))



        cmd.ExecuteNonQuery()
        cmd.Dispose()
        DBConn.Close()
        MsgBox("Profile Added", vbInformation, "Success")

    End Sub

    Private Sub FillProfileInfo()

        'On Error Resume Next
        Dim i, icount As Integer
        DBConnect.ConnectDB()
        strsql = "select ID,EmplID,Username,Project,Process,SubProcess,Profile,ProfileName from ThinkProfile where EmplID=" & Home.lblEmplID.Text & ""

        Dim da As New OleDb.OleDbDataAdapter(strsql, DBConn)
        Dim ds As New DataSet

        da.Fill(ds)



        icount = ds.Tables(0).Rows.Count


        For i = 1 To icount
            ' MsgBox("Profile" & icount)

        Next

        If icount = 1 Then
            lblid1.Text = ds.Tables(0).Rows(0).Item("ID")
            lblProjectp1.Text = ds.Tables(0).Rows(0).Item("Project")
            lblProcessp1.Text = ds.Tables(0).Rows(0).Item("Process")
            lblSubProcessp1.Text = ds.Tables(0).Rows(0).Item("SubProcess")
            Profile1.Text = ds.Tables(0).Rows(0).Item("ProfileName")
        End If


        If icount = 2 Then
            lblid1.Text = ds.Tables(0).Rows(0).Item("ID")
            lblProjectp1.Text = ds.Tables(0).Rows(0).Item("Project")
            lblProcessp1.Text = ds.Tables(0).Rows(0).Item("Process")
            lblSubProcessp1.Text = ds.Tables(0).Rows(0).Item("SubProcess")
            Profile1.Text = ds.Tables(0).Rows(0).Item("ProfileName")

            lblid2.Text = ds.Tables(0).Rows(1).Item("ID")
            lblProjectp2.Text = ds.Tables(0).Rows(1).Item("Project")
            lblProcessp2.Text = ds.Tables(0).Rows(1).Item("Process")
            lblSubProcessp2.Text = ds.Tables(0).Rows(1).Item("SubProcess")
            Profile2.Text = ds.Tables(0).Rows(1).Item("ProfileName")
        End If


        If icount = 3 Then
            lblid1.Text = ds.Tables(0).Rows(0).Item("ID")
            lblProjectp1.Text = ds.Tables(0).Rows(0).Item("Project")
            lblProcessp1.Text = ds.Tables(0).Rows(0).Item("Process")
            lblSubProcessp1.Text = ds.Tables(0).Rows(0).Item("SubProcess")
            Profile1.Text = ds.Tables(0).Rows(0).Item("ProfileName")


            lblid2.Text = ds.Tables(0).Rows(1).Item("ID")
            lblProjectp2.Text = ds.Tables(0).Rows(1).Item("Project")
            lblProcessp2.Text = ds.Tables(0).Rows(1).Item("Process")
            lblSubProcessp2.Text = ds.Tables(0).Rows(1).Item("SubProcess")
            Profile2.Text = ds.Tables(0).Rows(1).Item("ProfileName")

            lblid3.Text = ds.Tables(0).Rows(2).Item("ID")
            lblProjectp3.Text = ds.Tables(0).Rows(2).Item("Project")
            lblProcessp3.Text = ds.Tables(0).Rows(2).Item("Process")
            lblSubProcessp3.Text = ds.Tables(0).Rows(2).Item("SubProcess")
            Profile3.Text = ds.Tables(0).Rows(2).Item("ProfileName")
        End If

        If icount = 4 Then
            lblid1.Text = ds.Tables(0).Rows(0).Item("ID")
            lblProjectp1.Text = ds.Tables(0).Rows(0).Item("Project")
            lblProcessp1.Text = ds.Tables(0).Rows(0).Item("Process")
            lblSubProcessp1.Text = ds.Tables(0).Rows(0).Item("SubProcess")
            Profile1.Text = ds.Tables(0).Rows(0).Item("ProfileName")

            lblid2.Text = ds.Tables(0).Rows(1).Item("ID")
            lblProjectp2.Text = ds.Tables(0).Rows(1).Item("Project")
            lblProcessp2.Text = ds.Tables(0).Rows(1).Item("Process")
            lblSubProcessp2.Text = ds.Tables(0).Rows(1).Item("SubProcess")
            Profile2.Text = ds.Tables(0).Rows(1).Item("ProfileName")

            lblid3.Text = ds.Tables(0).Rows(2).Item("ID")
            lblProjectp3.Text = ds.Tables(0).Rows(2).Item("Project")
            lblProcessp3.Text = ds.Tables(0).Rows(2).Item("Process")
            lblSubProcessp3.Text = ds.Tables(0).Rows(2).Item("SubProcess")
            Profile3.Text = ds.Tables(0).Rows(2).Item("ProfileName")

            lblid4.Text = ds.Tables(0).Rows(3).Item("ID")
            lblProjectp4.Text = ds.Tables(0).Rows(3).Item("Project")
            lblProcessp4.Text = ds.Tables(0).Rows(3).Item("Process")
            lblSubProcessp4.Text = ds.Tables(0).Rows(3).Item("SubProcess")
            Profile4.Text = ds.Tables(0).Rows(3).Item("ProfileName")
        End If




        'For i = 0 To icount - 1
        '    j = i + 1

        'Next



        DBConn.Close()
    End Sub

    Private Sub cmdSavep1_Click(sender As Object, e As EventArgs) Handles cmdSavep1.Click

        Try
            Call UpdateProfile()
            cmdSavep1.Visible = False
            cmdEditP1.Visible = True
            TreeView1.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdSavep2_Click(sender As Object, e As EventArgs) Handles cmdSavep2.Click
        Try
            Call UpdateProfile()
            cmdSavep2.Visible = False
            cmdEditP2.Visible = True
            TreeView1.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdSavep3_Click(sender As Object, e As EventArgs) Handles cmdSavep3.Click
        Try

            If lblProject.Text = "Project" Then
                Call AddProfile()
            Else
                Call UpdateProfile()
            End If

            cmdSavep3.Visible = False
            cmdEditP3.Visible = True
            TreeView1.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdSavep4_Click(sender As Object, e As EventArgs) Handles cmdSavep4.Click
        Try

            If lblProject.Text = "Project" Then
                Call AddProfile()
            Else
                Call UpdateProfile()
            End If

            cmdSavep4.Visible = False
            cmdEditP4.Visible = True
            TreeView1.Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdSaveMy_Click(sender As Object, e As EventArgs) Handles cmdSaveMy.Click
        Call DetailsUpdate()
        Call GetProfilePic() '''''''''''''''''''Getting My Pic
    End Sub

    Private Sub cmdSaveWork_Click(sender As Object, e As EventArgs) Handles cmdSaveWork.Click
        Call DetailsUpdate()
    End Sub

    Private Sub cmdSaveWorkD_Click(sender As Object, e As EventArgs) Handles cmdSaveWorkD.Click
        Call DetailsUpdate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TabControl.TabPages.Remove(TabPage1)
    End Sub

    Private Sub mypicbox_Click(sender As Object, e As EventArgs) Handles mypicbox.Click
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png| all files (*.*) | *.*"
        'OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            mypicbox.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub cmdAdd4_Click(sender As Object, e As EventArgs) Handles cmdAdd4.Click
        Call AddProfile()
        cmdAdd4.Visible = False
        cmdEditP4.Visible = True
    End Sub

    Private Sub cmdAdd3_Click(sender As Object, e As EventArgs) Handles cmdAdd3.Click
        Call AddProfile()
        cmdAdd3.Visible = False
        cmdEditP3.Visible = True
    End Sub

    Private Sub cmdAdd2_Click(sender As Object, e As EventArgs) Handles cmdAdd2.Click
        Call AddProfile()
        cmdAdd2.Visible = False
        cmdEditP2.Visible = True
    End Sub

    Private Sub cmdAdd1_Click(sender As Object, e As EventArgs) Handles cmdAdd1.Click
        Call AddProfile()
        cmdAdd1.Visible = False
        cmdEditP1.Visible = True
    End Sub

    Private Sub profilepic1_Click(sender As Object, e As EventArgs) Handles profilepic1.Click
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            profilepic1.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub profilepic2_Click(sender As Object, e As EventArgs) Handles profilepic2.Click
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            profilepic2.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub profilepic3_Click(sender As Object, e As EventArgs) Handles profilepic3.Click
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            profilepic3.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub profilepic4_Click(sender As Object, e As EventArgs) Handles profilepic4.Click
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            profilepic4.Image = Image.FromFile(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            If CheckBox1.Checked = True Then

                lblProjectp1.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcessp1.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcessp1.Text = TreeView1.SelectedNode.Text
                Profile1.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text

                lblProfilename.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text
                lblProject.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcess.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcess.Text = TreeView1.SelectedNode.Text


            ElseIf CheckBox2.Checked = True Then

                lblProjectp2.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcessp2.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcessp2.Text = TreeView1.SelectedNode.Text
                Profile2.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text

                lblProfilename.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text
                lblProject.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcess.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcess.Text = TreeView1.SelectedNode.Text

            ElseIf CheckBox3.Checked = True Then

                lblProjectp3.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcessp3.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcessp3.Text = TreeView1.SelectedNode.Text
                Profile3.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text

                lblProfilename.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text
                lblProject.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcess.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcess.Text = TreeView1.SelectedNode.Text

            ElseIf CheckBox4.Checked = True Then

                lblProjectp4.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcessp4.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcessp4.Text = TreeView1.SelectedNode.Text
                Profile4.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text

                lblProfilename.Text = TreeView1.SelectedNode.Parent.Text & "-" & TreeView1.SelectedNode.Text
                lblProject.Text = TreeView1.SelectedNode.Parent.Parent.Text
                lblProcess.Text = TreeView1.SelectedNode.Parent.Text
                lblSubProcess.Text = TreeView1.SelectedNode.Text



            End If
        Catch ex As Exception
            MsgBox("Please select Project details properly", vbInformation, "Project details not selected")
        End Try
    End Sub

    Private Sub cmdClose_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub txtShiftstrtTime_LostFocus(sender As Object, e As EventArgs) Handles txtShiftstrtTime.LostFocus
        If Not IsDate(txtShiftstrtTime.Text) Then
            MsgBox("Please enter a Valid Time Format, MUST BE AS 07:30:00,Value has been defaulted to 00:00:00")
            txtShiftstrtTime.Focus()
        End If
    End Sub

    Private Sub txtShiftEndTime_LostFocus(sender As Object, e As EventArgs) Handles txtShiftEndTime.LostFocus
        If Not IsDate(txtShiftEndTime.Text) Then
            MsgBox("Please enter a Valid Time Format, MUST BE AS 07:30:00,Value has been defaulted to 00:00:00")
            txtShiftEndTime.Focus()
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

End Class