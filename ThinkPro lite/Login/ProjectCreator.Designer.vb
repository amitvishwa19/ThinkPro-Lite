<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectCreator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectCreator))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSubProcess = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_Process_owner = New System.Windows.Forms.ComboBox()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.timeViwtype = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBackupPath = New System.Windows.Forms.TextBox()
        Me.cmdBackupBrowse = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.soft_del_days = New System.Windows.Forms.NumericUpDown()
        Me.hard_del_days = New System.Windows.Forms.NumericUpDown()
        Me.cmb_Process_owner_email = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_process_address = New System.Windows.Forms.TextBox()
        CType(Me.soft_del_days, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hard_del_days, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(47, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Sub Process"
        '
        'cmbSubProcess
        '
        Me.cmbSubProcess.FormattingEnabled = True
        Me.cmbSubProcess.Location = New System.Drawing.Point(50, 139)
        Me.cmbSubProcess.Name = "cmbSubProcess"
        Me.cmbSubProcess.Size = New System.Drawing.Size(265, 21)
        Me.cmbSubProcess.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(49, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Project"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(47, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Process"
        '
        'cmbProcess
        '
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(50, 96)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(265, 21)
        Me.cmbProcess.TabIndex = 65
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(50, 56)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(265, 21)
        Me.cmbProject.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(48, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Process Owner"
        '
        'cmb_Process_owner
        '
        Me.cmb_Process_owner.FormattingEnabled = True
        Me.cmb_Process_owner.Location = New System.Drawing.Point(51, 184)
        Me.cmb_Process_owner.Name = "cmb_Process_owner"
        Me.cmb_Process_owner.Size = New System.Drawing.Size(265, 21)
        Me.cmb_Process_owner.TabIndex = 74
        '
        'cmdCreate
        '
        Me.cmdCreate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdCreate.Location = New System.Drawing.Point(0, 418)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(834, 44)
        Me.cmdCreate.TabIndex = 80
        Me.cmdCreate.Text = "Create"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(11, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(196, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Select from the dropdown or create new"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(491, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "TimeView Type"
        '
        'timeViwtype
        '
        Me.timeViwtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.timeViwtype.FormattingEnabled = True
        Me.timeViwtype.Items.AddRange(New Object() {"Default", "Self Allocation", "Central Allocation"})
        Me.timeViwtype.Location = New System.Drawing.Point(492, 56)
        Me.timeViwtype.Name = "timeViwtype"
        Me.timeViwtype.Size = New System.Drawing.Size(265, 21)
        Me.timeViwtype.TabIndex = 82
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(491, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "Backup Path"
        '
        'txtBackupPath
        '
        Me.txtBackupPath.Location = New System.Drawing.Point(492, 96)
        Me.txtBackupPath.Name = "txtBackupPath"
        Me.txtBackupPath.Size = New System.Drawing.Size(238, 20)
        Me.txtBackupPath.TabIndex = 85
        '
        'cmdBackupBrowse
        '
        Me.cmdBackupBrowse.Location = New System.Drawing.Point(733, 94)
        Me.cmdBackupBrowse.Name = "cmdBackupBrowse"
        Me.cmdBackupBrowse.Size = New System.Drawing.Size(24, 23)
        Me.cmdBackupBrowse.TabIndex = 86
        Me.cmdBackupBrowse.Text = "..."
        Me.cmdBackupBrowse.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(493, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 13)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Data Soft Delete Days"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(493, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Data Hard Delete Days"
        '
        'soft_del_days
        '
        Me.soft_del_days.Location = New System.Drawing.Point(496, 140)
        Me.soft_del_days.Name = "soft_del_days"
        Me.soft_del_days.Size = New System.Drawing.Size(261, 20)
        Me.soft_del_days.TabIndex = 91
        Me.soft_del_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.soft_del_days.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'hard_del_days
        '
        Me.hard_del_days.Location = New System.Drawing.Point(496, 185)
        Me.hard_del_days.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.hard_del_days.Name = "hard_del_days"
        Me.hard_del_days.Size = New System.Drawing.Size(261, 20)
        Me.hard_del_days.TabIndex = 92
        Me.hard_del_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.hard_del_days.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'cmb_Process_owner_email
        '
        Me.cmb_Process_owner_email.Location = New System.Drawing.Point(50, 232)
        Me.cmb_Process_owner_email.Name = "cmb_Process_owner_email"
        Me.cmb_Process_owner_email.Size = New System.Drawing.Size(265, 20)
        Me.cmb_Process_owner_email.TabIndex = 93
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(49, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Process Owner Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(49, 271)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Process Address"
        '
        'txt_process_address
        '
        Me.txt_process_address.Location = New System.Drawing.Point(50, 287)
        Me.txt_process_address.Multiline = True
        Me.txt_process_address.Name = "txt_process_address"
        Me.txt_process_address.Size = New System.Drawing.Size(265, 108)
        Me.txt_process_address.TabIndex = 95
        '
        'ProjectCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_process_address)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmb_Process_owner_email)
        Me.Controls.Add(Me.hard_del_days)
        Me.Controls.Add(Me.soft_del_days)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdBackupBrowse)
        Me.Controls.Add(Me.txtBackupPath)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.timeViwtype)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdCreate)
        Me.Controls.Add(Me.cmb_Process_owner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbSubProcess)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbProcess)
        Me.Controls.Add(Me.cmbProject)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProjectCreator"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Creator"
        Me.TopMost = True
        CType(Me.soft_del_days, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.hard_del_days, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSubProcess As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProcess As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_Process_owner As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As Label
    Friend WithEvents timeViwtype As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBackupPath As TextBox
    Friend WithEvents cmdBackupBrowse As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents soft_del_days As NumericUpDown
    Friend WithEvents hard_del_days As NumericUpDown
    Friend WithEvents cmb_Process_owner_email As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_process_address As TextBox
End Class
