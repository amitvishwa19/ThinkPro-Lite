Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System
Imports System.IO
Imports Npgsql
Imports System.Data.Odbc
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms
Public Class MyProfile


#Region "On Load"

    Private Sub MyProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Var As New Encryption
        Var.Encrypt(My.Settings.EmplID)
        Dim Emp_id As String = Var.encr


        Dim conn As New pgConnect
        Dim reader As NpgsqlDataReader = conn.GetRecords("user_details", "*", "empl_id =@value1", Emp_id)
        While reader.Read
            txtFirstName.Text = Var.decrypt(reader("first_name"))
            txtLastName.Text = Var.decrypt(reader("last_name"))
            txtname.Text = Var.decrypt(reader("first_name")) & "," & Var.decrypt(reader("last_name"))
            txtDOB.Text = Var.decrypt(reader("dob"))

            txtBloodGroup.Text = Var.decrypt(reader("blood_group"))
            txtQualification.Text = Var.decrypt(reader("qualification"))
            txtWorkExp.Text = Var.decrypt(reader("work_experience"))
            txtPrimaryContact.Text = Var.decrypt(reader("contact_details"))




        End While

    End Sub

#End Region


#Region "Next and Previous Command Buttons"

    Dim i As Integer
    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        i = i + 1
        TabControl1.SelectTab(i)
        cmdBack.Enabled = True
        cmdCancel.Enabled = True

        If i = TabControl1.TabCount - 1 Then
            cmdNext.Enabled = False
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        TabControl1.SelectTab(0)
        cmdBack.Enabled = False
        cmdNext.Enabled = True
        cmdCancel.Enabled = False
        i = 0
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        i = i - 1
        TabControl1.SelectTab(i)
        cmdNext.Enabled = True
        If i = 0 Then
            cmdBack.Enabled = False
        End If


    End Sub

#End Region


End Class