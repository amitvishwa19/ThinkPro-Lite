Public Class SummaryEdit
    Public ActID As Integer
    Public iVol As Integer = Nothing
    Public iActid As String = Nothing
    Public iCmnt As String = Nothing
    Public iActivity As String = Nothing

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'TimeSummary.DataGridView1.Item(6, ActID).text = txtVolume.Text
        'TimeSummary.DataGridView1.Item(7, ActID).Value = txtActID.Text
        'TimeSummary.DataGridView1.Item(8, ActID).Value = txtcomment.Text
    End Sub


    Private Sub SummaryEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtVolume.Text = iVol
        txtActID.Text = iActid
        txtcomment.Text = iCmnt
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim conn As New pgConnect
        Dim value As String = txtVolume.Text & "^" & txtActID.Text & "^" & txtcomment.Text & "^" & ActID
        conn.UpdateRecord("time_view", "volume =@value1,act_id =@value2,comment =@value3", value, "id=@value4")
        Call TimeSummary.TimeSummary()
        Me.Close()
    End Sub
End Class