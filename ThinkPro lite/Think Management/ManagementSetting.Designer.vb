<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManagementSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtFolderPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdBackup = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.st1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.st2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.s3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.st3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFolderPath
        '
        Me.txtFolderPath.Enabled = False
        Me.txtFolderPath.Location = New System.Drawing.Point(25, 40)
        Me.txtFolderPath.Name = "txtFolderPath"
        Me.txtFolderPath.Size = New System.Drawing.Size(382, 20)
        Me.txtFolderPath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Backup Folder path"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(413, 38)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(56, 23)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdBackup)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.txtFolderPath)
        Me.GroupBox1.Controls.Add(Me.cmdBrowse)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 127)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Backup"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(475, 38)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 23)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdBackup
        '
        Me.cmdBackup.Location = New System.Drawing.Point(25, 78)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(506, 39)
        Me.cmdBackup.TabIndex = 4
        Me.cmdBackup.Text = "Backup Now"
        Me.cmdBackup.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.st1, Me.st2, Me.s3, Me.st3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'st1
        '
        Me.st1.BackColor = System.Drawing.Color.Transparent
        Me.st1.Name = "st1"
        Me.st1.Size = New System.Drawing.Size(0, 17)
        '
        'st2
        '
        Me.st2.BackColor = System.Drawing.Color.Transparent
        Me.st2.Name = "st2"
        Me.st2.Size = New System.Drawing.Size(0, 17)
        '
        's3
        '
        Me.s3.BackColor = System.Drawing.Color.Transparent
        Me.s3.Name = "s3"
        Me.s3.Size = New System.Drawing.Size(0, 17)
        '
        'st3
        '
        Me.st3.BackColor = System.Drawing.Color.Transparent
        Me.st3.Name = "st3"
        Me.st3.Size = New System.Drawing.Size(0, 17)
        '
        'ManagementSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ManagementSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFolderPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdBrowse As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdBackup As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents st1 As ToolStripStatusLabel
    Friend WithEvents st2 As ToolStripStatusLabel
    Friend WithEvents s3 As ToolStripStatusLabel
    Friend WithEvents st3 As ToolStripStatusLabel
End Class
