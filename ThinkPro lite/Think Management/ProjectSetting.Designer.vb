<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectSetting
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtProcessOwnerEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcessOwner = New System.Windows.Forms.TextBox()
        Me.cmdBackupBrowse = New System.Windows.Forms.Button()
        Me.txtBackupPath = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.hard_del_days = New System.Windows.Forms.NumericUpDown()
        Me.soft_del_days = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmdupdate = New System.Windows.Forms.Button()
        CType(Me.hard_del_days, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soft_del_days, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(23, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "Process Owner Email"
        '
        'txtProcessOwnerEmail
        '
        Me.txtProcessOwnerEmail.Location = New System.Drawing.Point(24, 83)
        Me.txtProcessOwnerEmail.Name = "txtProcessOwnerEmail"
        Me.txtProcessOwnerEmail.Size = New System.Drawing.Size(265, 20)
        Me.txtProcessOwnerEmail.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(23, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Process Owner"
        '
        'txtProcessOwner
        '
        Me.txtProcessOwner.Location = New System.Drawing.Point(24, 37)
        Me.txtProcessOwner.Name = "txtProcessOwner"
        Me.txtProcessOwner.Size = New System.Drawing.Size(265, 20)
        Me.txtProcessOwner.TabIndex = 97
        '
        'cmdBackupBrowse
        '
        Me.cmdBackupBrowse.Location = New System.Drawing.Point(265, 126)
        Me.cmdBackupBrowse.Name = "cmdBackupBrowse"
        Me.cmdBackupBrowse.Size = New System.Drawing.Size(24, 23)
        Me.cmdBackupBrowse.TabIndex = 101
        Me.cmdBackupBrowse.Text = "..."
        Me.cmdBackupBrowse.UseVisualStyleBackColor = True
        '
        'txtBackupPath
        '
        Me.txtBackupPath.Location = New System.Drawing.Point(26, 128)
        Me.txtBackupPath.Name = "txtBackupPath"
        Me.txtBackupPath.Size = New System.Drawing.Size(227, 20)
        Me.txtBackupPath.TabIndex = 100
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(25, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Backup Path"
        '
        'hard_del_days
        '
        Me.hard_del_days.Location = New System.Drawing.Point(28, 225)
        Me.hard_del_days.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.hard_del_days.Name = "hard_del_days"
        Me.hard_del_days.Size = New System.Drawing.Size(261, 20)
        Me.hard_del_days.TabIndex = 105
        Me.hard_del_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.hard_del_days.Value = New Decimal(New Integer() {365, 0, 0, 0})
        '
        'soft_del_days
        '
        Me.soft_del_days.Location = New System.Drawing.Point(28, 180)
        Me.soft_del_days.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.soft_del_days.Name = "soft_del_days"
        Me.soft_del_days.Size = New System.Drawing.Size(261, 20)
        Me.soft_del_days.TabIndex = 104
        Me.soft_del_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.soft_del_days.Value = New Decimal(New Integer() {180, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(25, 209)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 103
        Me.Label12.Text = "Data Hard Delete Days"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(25, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 13)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "Data Soft Delete Days"
        '
        'cmdupdate
        '
        Me.cmdupdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdupdate.Location = New System.Drawing.Point(0, 273)
        Me.cmdupdate.Name = "cmdupdate"
        Me.cmdupdate.Size = New System.Drawing.Size(318, 44)
        Me.cmdupdate.TabIndex = 106
        Me.cmdupdate.Text = "Update"
        Me.cmdupdate.UseVisualStyleBackColor = True
        '
        'ProjectSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(318, 317)
        Me.Controls.Add(Me.cmdupdate)
        Me.Controls.Add(Me.hard_del_days)
        Me.Controls.Add(Me.soft_del_days)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdBackupBrowse)
        Me.Controls.Add(Me.txtBackupPath)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProcessOwner)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtProcessOwnerEmail)
        Me.Name = "ProjectSetting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Setting"
        Me.TopMost = True
        CType(Me.hard_del_days, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soft_del_days, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label13 As Label
    Friend WithEvents txtProcessOwnerEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcessOwner As TextBox
    Friend WithEvents cmdBackupBrowse As Button
    Friend WithEvents txtBackupPath As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents hard_del_days As NumericUpDown
    Friend WithEvents soft_del_days As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmdupdate As Button
End Class
