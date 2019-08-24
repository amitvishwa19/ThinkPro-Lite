Public Class Upload
    Public upload_type As String = Nothing
    Private Sub Upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If upload_type = Nothing Then
            cmdUpload.Enabled = False
        Else
            cmdUpload.Enabled = True
        End If
    End Sub

    Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        If upload_type = "process_upload" Then
            Call process_data_upload()

        ElseIf upload_type = "pi_fields" Then
            Call pi_fields_upload_data()

        ElseIf upload_type = "application_upload" Then
            Call application_data_upload()
        ElseIf upload_type = "user_upload" Then
            Call user_upload_data()
        End If
    End Sub

    Private Sub process_data_upload()

        Try

            For i = 0 To DataGridView1.RowCount - 1

                Dim process As String = DataGridView1.Rows(i).Cells(0).Value.ToString
                Dim subprocess As String = DataGridView1.Rows(i).Cells(1).Value.ToString
                Dim ownername As String = DataGridView1.Rows(i).Cells(2).Value.ToString
                Dim owneremail As String = DataGridView1.Rows(i).Cells(3).Value.ToString

                Dim conn As New pgConnect
                Dim value As String
                value = process & "^" & subprocess & "^" & ownername & "^" & owneremail
                conn.InsertRecord("process", "process,sub_process,process_owner,process_owner_email", value)


            Next

            AppProcess.process_data()
            Me.Close()
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("File uploaded successfully")
            ' MsgBox("File uploaded successfully")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            ' MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub pi_fields_upload_data()
        Try

            For i = 0 To DataGridView1.RowCount - 1

                Dim pi_name As String = DataGridView1.Rows(i).Cells(0).Value.ToString
                Dim pi_description As String = DataGridView1.Rows(i).Cells(1).Value.ToString
                Dim pi_status As String = DataGridView1.Rows(i).Cells(2).Value.ToString


                Dim conn As New pgConnect
                Dim value As String
                value = pi_name & "^" & pi_description & "^" & pi_status
                conn.InsertRecord("pi_fields", "pi_name,pi_description,pi_status", value)


            Next

            PIFields.pi_fields_show()
            Me.Close()
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("File uploaded successfully")
            'MsgBox("File uploaded successfully")

        Catch ex As IO.IOException
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
            '   MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub application_data_upload()
        Try

            For i = 0 To DataGridView1.RowCount - 1

                Dim app_name As String = DataGridView1.Rows(i).Cells(0).Value.ToString
                Dim app_description As String = DataGridView1.Rows(i).Cells(1).Value.ToString
                Dim app_owner As String = DataGridView1.Rows(i).Cells(2).Value.ToString
                Dim app_status As String = DataGridView1.Rows(i).Cells(3).Value.ToString


                Dim conn As New pgConnect
                Dim value As String
                value = app_name & "^" & app_description & "^" & app_owner & "^" & app_status
                conn.InsertRecord("applications", "app_name,app_description,app_owner,app_status", value)


            Next

            NewApplication.application_data()
            Me.Close()
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("File uploaded successfully")

            'MsgBox("File uploaded successfully")

        Catch ex As IO.IOException
            '   MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally

        End Try
    End Sub

    Private Sub user_upload_data()
        Try

            For i = 0 To DataGridView1.RowCount - 1

                Dim empl_id As String = DataGridView1.Rows(i).Cells(0).Value.ToString
                Dim first_name As String = DataGridView1.Rows(i).Cells(1).Value.ToString
                Dim last_name As String = DataGridView1.Rows(i).Cells(2).Value.ToString
                Dim user_status As String = DataGridView1.Rows(i).Cells(3).Value.ToString

                Dim conn As New pgConnect
                Dim value As String
                value = empl_id & "^" & first_name & "^" & last_name & "^" & user_status
                conn.InsertRecord("users", "empl_id,first_name,last_name,user_status", value)


            Next

            NewUser.user_data()
            Me.Close()
            Dim msg1 As MsgBoxResult
            msg1 = MsgBox("File uploaded successfully")
            'MsgBox("File uploaded successfully")

        Catch ex As IO.IOException
            ' MsgBox(ex.Message)
            Dim msg4 As MsgBoxResult = MsgBox("Please Connect System Administrator")
        Finally

        End Try
    End Sub

End Class