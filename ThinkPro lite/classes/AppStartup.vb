Imports Npgsql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class AppStartup
    Public DatabaseType As String = Nothing
    Public DatabaseName As String = Nothing
    Public ServerAddress As String = Nothing
    Public ServerPort As String = Nothing
    Public DatabaseID As String = Nothing
    Public DatabasePass As String = Nothing

    Public Function configfilecheck()
        Try
            Dim filepath As String = Application.UserAppDataPath & "\AppConfig.txt"
            If Not System.IO.File.Exists(filepath) Then
                File.Create(Application.UserAppDataPath & "\AppConfig.txt").Dispose()
                Call DisableMenu()
                Return False
            Else
                Return True
            End If
        Catch ex As IO.IOException
            Return False
        End Try
    End Function 'ok

    Private Sub DisableMenu()
        For Each t As ToolStripItem In Home.MainMenu.Items
            If t.Text = "Setup" Then
                t.Visible = True
            Else
                t.Visible = False
            End If
        Next
    End Sub

  
End Class
