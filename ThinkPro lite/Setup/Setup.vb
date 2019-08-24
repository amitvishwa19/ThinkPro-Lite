Imports System.Windows.Forms
Imports Npgsql
Imports System.IO
Public Class Setup
    Dim CurrentPage As Integer
    Dim ConnectionStatus As Boolean = False
#Region "Tab Control"

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click

        If ConnectionStatus = True Then
            Dim TotalPage As Integer = TabControl1.TabPages.Count
            If cmdNext.Text = "Next" Then
                CurrentPage = CurrentPage + 1
                TabControl1.SelectTab(CurrentPage)
                If CurrentPage = TotalPage - 1 Then
                    cmdNext.Text = "Finish"
                    'cmdNext.Enabled = False
                End If
                cmdBack.Enabled = True
            Else
                'Conf file save and setting file save
                AppSetup.CreateConfigFileFromData(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), txtDatabaseName.Text, txtServerAddress.Text, txtServerPort.Text, txtDatabaseID.Text, txtDatabasePass.Text)
                Me.Close()
                Application.Restart()
            End If
        Else
            Dim msg As MsgBoxResult = MsgBox("Connection not set,Please set a connection first!", vbInformation, "Oops!")
        End If

    End Sub
    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Dim TotalPage As Integer = TabControl1.TabPages.Count
        CurrentPage = CurrentPage - 1
        TabControl1.SelectTab(CurrentPage)
        If CurrentPage = 0 Then
            cmdBack.Enabled = False
        End If
        cmdNext.Enabled = True
        cmdNext.Text = "Next"
    End Sub
    Private Sub Setup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopPanel.BringToFront()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Home.Show()
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        cmdBack.Enabled = False
        cmdNext.Enabled = True
        TabControl1.SelectTab(0)
        CurrentPage = 0
    End Sub

#End Region

#Region "First Tab"
    Dim ConfPAth As String = Nothing

    Private Function ConnTest()

        Dim pgTestconn As New NpgsqlConnection
        Try

            pgTestconn.ConnectionString = "Server=" & txtServerAddress.Text & ";Port=" & txtServerPort.Text & ";Database=" & txtDatabaseName.Text & ";User Id=" & txtDatabaseID.Text & ";Password=" & txtDatabasePass.Text & ";"
            pgTestconn.Open()

            If pgTestconn.State = 1 Then
                Return True
            Else
                Return False
            End If
            pgTestconn.Close()

        Catch ex As IO.IOException

            Return False
        End Try

    End Function 'Required
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        txtconfpath.Enabled = True
        browse.Enabled = True

        txtDatabaseName.Enabled = False
        txtServerAddress.Enabled = False
        txtServerPort.Enabled = False
        txtDatabaseID.Enabled = False
        txtDatabasePass.Enabled = False
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        txtDatabaseName.Enabled = True
        txtServerAddress.Enabled = True
        txtServerPort.Enabled = True
        txtDatabaseID.Enabled = True
        txtDatabasePass.Enabled = True

        txtconfpath.Enabled = False
        browse.Enabled = False
    End Sub

#End Region

    Private Sub browse_Click(sender As Object, e As EventArgs) Handles browse.Click
        Try
            Dim OFD As New OpenFileDialog
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            OFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            Dim result As DialogResult = OFD.ShowDialog()


            If result = Windows.Forms.DialogResult.OK Then
                ConfPAth = OFD.FileName
                txtconfpath.Text = ConfPAth


                Dim enc As New Encryption
                Dim lines() As String = System.IO.File.ReadAllLines(ConfPAth)


                txtDatabaseName.Text = enc.decrypt(lines(1))
                txtServerAddress.Text = enc.decrypt(lines(2))
                txtServerPort.Text = enc.decrypt(lines(3))
                txtDatabaseID.Text = enc.decrypt(lines(4))
                txtDatabasePass.Text = enc.decrypt(lines(5))

            End If
        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
    Private Sub cmdTestConn_Click(sender As Object, e As EventArgs) Handles cmdTestConn.Click
        Try

            If AppSetup.ConnectionTest(txtServerAddress.Text, txtServerPort.Text, txtDatabaseName.Text, txtDatabaseID.Text, txtDatabasePass.Text) = True Then
                txtDatabaseName.BackColor = Color.DarkSeaGreen
                txtServerAddress.BackColor = Color.DarkSeaGreen
                txtServerPort.BackColor = Color.DarkSeaGreen
                txtDatabaseID.BackColor = Color.DarkSeaGreen
                txtDatabasePass.BackColor = Color.DarkSeaGreen
                ConnectionStatus = True
                cmdConfFile.Enabled = True
            Else
                txtDatabaseName.BackColor = Color.Orange
                txtServerAddress.BackColor = Color.Orange
                txtServerPort.BackColor = Color.Orange
                txtDatabaseID.BackColor = Color.Orange
                txtDatabasePass.BackColor = Color.Orange
            End If

        Catch ex As IO.IOException
            Dim msg As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdConfFile.Click
        Dim DBvar As New Encryption
        Dim savepath As String
        Dim FILE_NAME As String
        Dim FBD As New FolderBrowserDialog
        If (FBD.ShowDialog() = DialogResult.OK) Then
            savepath = FBD.SelectedPath
            FILE_NAME = savepath & "\AppConfig.txt"
            File.Create(FILE_NAME).Dispose()

            Dim i As Integer
            Dim aryText(6) As String

            DBvar.Encrypt("Postgres")
            aryText(0) = DBvar.encr
            DBvar.Encrypt(txtDatabaseName.Text)
            aryText(1) = DBvar.encr
            DBvar.Encrypt(txtServerAddress.Text)
            aryText(2) = DBvar.encr
            DBvar.Encrypt(txtServerPort.Text)
            aryText(3) = DBvar.encr
            DBvar.Encrypt(txtDatabaseID.Text)
            aryText(4) = DBvar.encr
            DBvar.Encrypt(txtDatabasePass.Text)
            aryText(5) = DBvar.encr

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To 5
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            Dim msg As MsgBoxResult
            msg = MsgBox("Config file saved to : " & savepath, MsgBoxStyle.Information, "Created")
            ' MsgBox("Config file saved to : " & savepath, MsgBoxStyle.Information, "Created")


        Else
            Exit Sub
        End If
    End Sub



End Class
