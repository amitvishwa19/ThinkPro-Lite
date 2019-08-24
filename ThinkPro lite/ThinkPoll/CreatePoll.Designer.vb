<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreatePoll
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPollTitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtQuestion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtoption1 = New System.Windows.Forms.TextBox()
        Me.txtoption2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtoption3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtoption4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dpDate
        '
        Me.dpDate.Location = New System.Drawing.Point(12, 63)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(196, 20)
        Me.dpDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Poll Date"
        '
        'txtPollTitle
        '
        Me.txtPollTitle.Location = New System.Drawing.Point(12, 107)
        Me.txtPollTitle.Multiline = True
        Me.txtPollTitle.Name = "txtPollTitle"
        Me.txtPollTitle.Size = New System.Drawing.Size(254, 41)
        Me.txtPollTitle.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Poll Title"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Poll Question"
        '
        'TxtQuestion
        '
        Me.TxtQuestion.Location = New System.Drawing.Point(12, 170)
        Me.TxtQuestion.Multiline = True
        Me.TxtQuestion.Name = "TxtQuestion"
        Me.TxtQuestion.Size = New System.Drawing.Size(254, 65)
        Me.TxtQuestion.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Poll Option 1"
        '
        'txtoption1
        '
        Me.txtoption1.Location = New System.Drawing.Point(15, 256)
        Me.txtoption1.Name = "txtoption1"
        Me.txtoption1.Size = New System.Drawing.Size(251, 20)
        Me.txtoption1.TabIndex = 7
        '
        'txtoption2
        '
        Me.txtoption2.Location = New System.Drawing.Point(12, 301)
        Me.txtoption2.Name = "txtoption2"
        Me.txtoption2.Size = New System.Drawing.Size(251, 20)
        Me.txtoption2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 285)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Poll Option 2"
        '
        'txtoption3
        '
        Me.txtoption3.Location = New System.Drawing.Point(12, 343)
        Me.txtoption3.Name = "txtoption3"
        Me.txtoption3.Size = New System.Drawing.Size(251, 20)
        Me.txtoption3.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 327)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Poll Option 3"
        '
        'txtoption4
        '
        Me.txtoption4.Location = New System.Drawing.Point(12, 384)
        Me.txtoption4.Name = "txtoption4"
        Me.txtoption4.Size = New System.Drawing.Size(251, 20)
        Me.txtoption4.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Poll Option 4"
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Location = New System.Drawing.Point(15, 409)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(248, 41)
        Me.cmdSubmit.TabIndex = 14
        Me.cmdSubmit.Text = "Create Poll"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(86, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 21)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Think Poll"
        '
        'CreatePoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(278, 462)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.txtoption4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtoption3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtoption2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtoption1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtQuestion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPollTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreatePoll"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Poll"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPollTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtQuestion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtoption1 As System.Windows.Forms.TextBox
    Friend WithEvents txtoption2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtoption3 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtoption4 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
