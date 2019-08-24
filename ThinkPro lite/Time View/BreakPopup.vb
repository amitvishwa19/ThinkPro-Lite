Public Class BreakPopup
    Public stime, etime As Date
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        e.Graphics.DrawRectangle(Pens.OrangeRed, rect)
    End Sub

    Private Sub BreakPopup_Click(sender As Object, e As EventArgs) Handles Me.Click
        TimeView.Show()
        TimeView.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BreakPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()


        Dim x As Integer
        Dim y As Integer

        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop

        stime = Now

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        etime = Now
        Dim SecondsDifference As Integer
        SecondsDifference = DateDiff(DateInterval.Second, stime, etime)

        TotalTime.Text = GetTime(SecondsDifference)

    End Sub

    Public Function GetTime(Time As Integer) As String
        Dim Hrs As Integer
        Dim Min As Integer
        Dim Sec As Integer

        Sec = Time Mod 60
        Min = ((Time - Sec) / 60) Mod 60
        Hrs = ((Time - (Sec + (Min * 60))) / 3600) Mod 60
        Return Format(Hrs, "00") & ":" & Format(Min, "00") & ":" & Format(Sec, "00")

    End Function


End Class