<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblNotStarted = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblLogOff = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblLocked = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblActiveUser = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBreak = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 115)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Not Started"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Logged Off"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Locked"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Active"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel4.Controls.Add(Me.lblNotStarted)
        Me.Panel4.Location = New System.Drawing.Point(337, 19)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(75, 72)
        Me.Panel4.TabIndex = 5
        '
        'lblNotStarted
        '
        Me.lblNotStarted.AutoSize = True
        Me.lblNotStarted.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotStarted.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblNotStarted.Location = New System.Drawing.Point(12, 20)
        Me.lblNotStarted.Name = "lblNotStarted"
        Me.lblNotStarted.Size = New System.Drawing.Size(53, 32)
        Me.lblNotStarted.TabIndex = 11
        Me.lblNotStarted.Text = "20"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orchid
        Me.Panel3.Controls.Add(Me.lblLogOff)
        Me.Panel3.Location = New System.Drawing.Point(256, 19)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(75, 72)
        Me.Panel3.TabIndex = 5
        '
        'lblLogOff
        '
        Me.lblLogOff.AutoSize = True
        Me.lblLogOff.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogOff.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblLogOff.Location = New System.Drawing.Point(14, 20)
        Me.lblLogOff.Name = "lblLogOff"
        Me.lblLogOff.Size = New System.Drawing.Size(53, 32)
        Me.lblLogOff.TabIndex = 11
        Me.lblLogOff.Text = "20"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Tomato
        Me.Panel2.Controls.Add(Me.lblLocked)
        Me.Panel2.Location = New System.Drawing.Point(94, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(75, 72)
        Me.Panel2.TabIndex = 5
        '
        'lblLocked
        '
        Me.lblLocked.AutoSize = True
        Me.lblLocked.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocked.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblLocked.Location = New System.Drawing.Point(11, 21)
        Me.lblLocked.Name = "lblLocked"
        Me.lblLocked.Size = New System.Drawing.Size(53, 32)
        Me.lblLocked.TabIndex = 11
        Me.lblLocked.Text = "20"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel1.Controls.Add(Me.lblActiveUser)
        Me.Panel1.Location = New System.Drawing.Point(13, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 72)
        Me.Panel1.TabIndex = 4
        '
        'lblActiveUser
        '
        Me.lblActiveUser.AutoSize = True
        Me.lblActiveUser.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblActiveUser.Location = New System.Drawing.Point(14, 20)
        Me.lblActiveUser.Name = "lblActiveUser"
        Me.lblActiveUser.Size = New System.Drawing.Size(53, 32)
        Me.lblActiveUser.TabIndex = 10
        Me.lblActiveUser.Text = "20"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(191, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Break"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Panel5.Controls.Add(Me.lblBreak)
        Me.Panel5.Location = New System.Drawing.Point(175, 19)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(75, 72)
        Me.Panel5.TabIndex = 10
        '
        'lblBreak
        '
        Me.lblBreak.AutoSize = True
        Me.lblBreak.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBreak.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblBreak.Location = New System.Drawing.Point(11, 21)
        Me.lblBreak.Name = "lblBreak"
        Me.lblBreak.Size = New System.Drawing.Size(53, 32)
        Me.lblBreak.TabIndex = 11
        Me.lblBreak.Text = "20"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblNotStarted As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblLogOff As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblLocked As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblActiveUser As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblBreak As Label
End Class
