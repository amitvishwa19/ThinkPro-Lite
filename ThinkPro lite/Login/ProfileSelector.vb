Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.IO
Imports Npgsql
Public Class ProfileSelector

    Private Sub ProfileSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ProfileLoad()
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


    Private Sub Profile1_Click(sender As Object, e As EventArgs) Handles Profile1.Click
        Home.lblProjectID.Text = lblid1.Text
        Home.lblProject.Text = lblProjectp1.Text
        Home.lblProcess.Text = lblProcessp1.Text
        Home.lblSubProcess.Text = lblSubProcessp1.Text

        Home.TP_Project = lblProjectp1.Text
        Home.TP_Process = lblProcessp1.Text
        Home.TP_SubProcess = lblSubProcessp1.Text



        'Dim Load As New User
        'Load.AppData()
        Me.Close()



    End Sub

    Private Sub Profile2_Click(sender As Object, e As EventArgs) Handles Profile2.Click
        Home.lblProjectID.Text = lblid2.Text
        Home.lblProject.Text = lblProjectp2.Text
        Home.lblProcess.Text = lblProcessp2.Text
        Home.lblSubProcess.Text = lblSubProcessp2.Text

        Home.TP_Project = lblProjectp2.Text
        Home.TP_Process = lblProcessp2.Text
        Home.TP_SubProcess = lblSubProcessp2.Text

        'Dim Load As New User
        'Load.AppData()

        Me.Close()
    End Sub

    Private Sub Profile3_Click(sender As Object, e As EventArgs) Handles Profile3.Click
        Home.lblProjectID.Text = lblid3.Text
        Home.lblProject.Text = lblProjectp3.Text
        Home.lblProcess.Text = lblProcessp3.Text
        Home.lblSubProcess.Text = lblSubProcessp3.Text

        Home.TP_Project = lblProjectp3.Text
        Home.TP_Process = lblProcessp3.Text
        Home.TP_SubProcess = lblSubProcessp3.Text

        'Dim Load As New User
        'Load.AppData()
        Me.Close()
    End Sub

    Private Sub Profile4_Click(sender As Object, e As EventArgs) Handles Profile4.Click
        Home.lblProjectID.Text = lblid4.Text
        Home.lblProject.Text = lblProjectp4.Text
        Home.lblProcess.Text = lblProcessp4.Text
        Home.lblSubProcess.Text = lblSubProcessp4.Text

        Home.TP_Project = lblProjectp4.Text
        Home.TP_Process = lblProcessp4.Text
        Home.TP_SubProcess = lblSubProcessp4.Text


        'Dim Load As New User
        'Load.AppData()
        Me.Close()
    End Sub


    Private Sub Profile4_Enter(sender As Object, e As EventArgs) Handles Profile4.Enter

    End Sub
End Class