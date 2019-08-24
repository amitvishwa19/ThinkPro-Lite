Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Drawing
Imports OfficeOpenXml.Drawing.Vml
Imports System
Imports System.IO
Imports Npgsql
Imports System.Data.Odbc
'Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms
Public Class ErrorLog
    Dim Project As String = Home.TP_Project
    Dim Process As String = Home.TP_Process
    Dim SubProcess As String = Home.TP_SubProcess
    Dim ProcessID As String = Home.TP_ProcessID
    Dim BS As New BindingSource

    Private Sub ErrorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ErrorLog()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ErrorLog()

        Try
            Dim Var As New Encryption
            Var.Encrypt(My.Settings.EmplID)
            Dim Emp_id As String = Var.encr


            Dim SDate As String = Format(ThinkManagement.DateStart.Value, "dd-MMM-yy")
            Dim EDate As String = Format(ThinkManagement.DateEnd.Value, "dd-MMM-yy")


            Dim Conn As New pgConnect
            Dim value As String = ThinkManagement.TM_Project & "^" & ThinkManagement.TM_Process & "^" & ThinkManagement.TM_SubProcess & "^" & SDate & "^" & EDate
            Conn.GetRecordsGRID("think_error_log", "*", , , "id DESC")
            GridErrorLog.Columns.Clear()
            BS.DataSource = Conn.DataTable
            GridErrorLog.DataSource = BS
            AppFunctions.Grid_Format_Arternate(GridErrorLog)

            With GridErrorLog
                .Columns(0).HeaderCell.Value = "ID"
                .Columns(1).HeaderCell.Value = "User"
                .Columns(2).HeaderCell.Value = "Process"
                .Columns(3).HeaderCell.Value = "Date"
                .Columns(4).HeaderCell.Value = "Form Name"
                .Columns(5).HeaderCell.Value = "Error Title"
                .Columns(6).HeaderCell.Value = "Error Description"
            End With


            statusCount.Text = "Count :- " & GridErrorLog.Rows.Count

        Catch ex As IO.IOException
            ' MsgBox("Error while retriving data from server" & vbNewLine & ex.Message)

            '    Dim msg As MsgBoxResult = MsgBox("Error while retriving data from server" & vbNewLine & ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        End Try


    End Sub
    Public Sub GridErrorLog_FilterStringChanged(sender As Object, e As EventArgs) Handles GridErrorLog.FilterStringChanged
        BS.Filter = GridErrorLog.FilterString
        GridErrorLog.DataSource = BS
        statusCount.Text = "Count :- " & GridErrorLog.Rows.Count
    End Sub

End Class