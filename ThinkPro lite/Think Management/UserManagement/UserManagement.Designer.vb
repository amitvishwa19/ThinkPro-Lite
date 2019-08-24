<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserManagement))
        Me.cmdUpdateDetails = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbShiftType = New System.Windows.Forms.ComboBox()
        Me.grpProject = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.cmbSubProcess = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.grpBill = New System.Windows.Forms.GroupBox()
        Me.cmbUtilization = New System.Windows.Forms.ComboBox()
        Me.lblUtilization = New System.Windows.Forms.Label()
        Me.cmbBilling = New System.Windows.Forms.ComboBox()
        Me.lblbilling = New System.Windows.Forms.Label()
        Me.grpAcc = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmbaccountStatus = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbaccount = New System.Windows.Forms.ComboBox()
        Me.GroupBox6.SuspendLayout()
        Me.grpProject.SuspendLayout()
        Me.grpBill.SuspendLayout()
        Me.grpAcc.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdUpdateDetails
        '
        Me.cmdUpdateDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.cmdUpdateDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpdateDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdUpdateDetails.FlatAppearance.BorderSize = 0
        Me.cmdUpdateDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateDetails.ForeColor = System.Drawing.Color.White
        Me.cmdUpdateDetails.Location = New System.Drawing.Point(0, 412)
        Me.cmdUpdateDetails.Name = "cmdUpdateDetails"
        Me.cmdUpdateDetails.Size = New System.Drawing.Size(834, 50)
        Me.cmdUpdateDetails.TabIndex = 158
        Me.cmdUpdateDetails.Text = "Update Details"
        Me.cmdUpdateDetails.UseVisualStyleBackColor = False
        Me.cmdUpdateDetails.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.cmbShiftType)
        Me.GroupBox6.Location = New System.Drawing.Point(135, 289)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(173, 70)
        Me.GroupBox6.TabIndex = 163
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Shift Details"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label36.Location = New System.Drawing.Point(15, 21)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(55, 14)
        Me.Label36.TabIndex = 138
        Me.Label36.Text = "Shift Type"
        '
        'cmbShiftType
        '
        Me.cmbShiftType.FormattingEnabled = True
        Me.cmbShiftType.Items.AddRange(New Object() {"General", "Morning", "Noon", "Evening", "Night"})
        Me.cmbShiftType.Location = New System.Drawing.Point(18, 38)
        Me.cmbShiftType.Name = "cmbShiftType"
        Me.cmbShiftType.Size = New System.Drawing.Size(142, 21)
        Me.cmbShiftType.TabIndex = 139
        '
        'grpProject
        '
        Me.grpProject.Controls.Add(Me.Label35)
        Me.grpProject.Controls.Add(Me.cmbProject)
        Me.grpProject.Controls.Add(Me.cmbSubProcess)
        Me.grpProject.Controls.Add(Me.Label37)
        Me.grpProject.Controls.Add(Me.Label38)
        Me.grpProject.Controls.Add(Me.cmbProcess)
        Me.grpProject.Location = New System.Drawing.Point(332, 127)
        Me.grpProject.Name = "grpProject"
        Me.grpProject.Size = New System.Drawing.Size(173, 146)
        Me.grpProject.TabIndex = 162
        Me.grpProject.TabStop = False
        Me.grpProject.Text = "Project Details"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label35.Location = New System.Drawing.Point(15, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(40, 14)
        Me.Label35.TabIndex = 138
        Me.Label35.Text = "Project"
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(18, 36)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(142, 21)
        Me.cmbProject.TabIndex = 139
        '
        'cmbSubProcess
        '
        Me.cmbSubProcess.FormattingEnabled = True
        Me.cmbSubProcess.Location = New System.Drawing.Point(18, 118)
        Me.cmbSubProcess.Name = "cmbSubProcess"
        Me.cmbSubProcess.Size = New System.Drawing.Size(142, 21)
        Me.cmbSubProcess.TabIndex = 143
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label37.Location = New System.Drawing.Point(15, 60)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(47, 14)
        Me.Label37.TabIndex = 140
        Me.Label37.Text = "Process"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label38.Location = New System.Drawing.Point(15, 101)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(69, 14)
        Me.Label38.TabIndex = 142
        Me.Label38.Text = "Sub Process"
        '
        'cmbProcess
        '
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(18, 77)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(142, 21)
        Me.cmbProcess.TabIndex = 141
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblUsername.Location = New System.Drawing.Point(138, 104)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(45, 19)
        Me.lblUsername.TabIndex = 161
        Me.lblUsername.Text = "User"
        '
        'grpBill
        '
        Me.grpBill.Controls.Add(Me.cmbUtilization)
        Me.grpBill.Controls.Add(Me.lblUtilization)
        Me.grpBill.Controls.Add(Me.cmbBilling)
        Me.grpBill.Controls.Add(Me.lblbilling)
        Me.grpBill.Location = New System.Drawing.Point(135, 127)
        Me.grpBill.Name = "grpBill"
        Me.grpBill.Size = New System.Drawing.Size(173, 146)
        Me.grpBill.TabIndex = 160
        Me.grpBill.TabStop = False
        Me.grpBill.Text = "Billing /Utilization"
        '
        'cmbUtilization
        '
        Me.cmbUtilization.FormattingEnabled = True
        Me.cmbUtilization.Location = New System.Drawing.Point(18, 78)
        Me.cmbUtilization.Name = "cmbUtilization"
        Me.cmbUtilization.Size = New System.Drawing.Size(142, 21)
        Me.cmbUtilization.TabIndex = 145
        '
        'lblUtilization
        '
        Me.lblUtilization.AutoSize = True
        Me.lblUtilization.BackColor = System.Drawing.Color.Transparent
        Me.lblUtilization.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilization.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUtilization.Location = New System.Drawing.Point(15, 60)
        Me.lblUtilization.Name = "lblUtilization"
        Me.lblUtilization.Size = New System.Drawing.Size(52, 14)
        Me.lblUtilization.TabIndex = 144
        Me.lblUtilization.Text = "Utilization"
        '
        'cmbBilling
        '
        Me.cmbBilling.FormattingEnabled = True
        Me.cmbBilling.Items.AddRange(New Object() {"Billable", "Unbilled", "Non Billable"})
        Me.cmbBilling.Location = New System.Drawing.Point(18, 36)
        Me.cmbBilling.Name = "cmbBilling"
        Me.cmbBilling.Size = New System.Drawing.Size(142, 21)
        Me.cmbBilling.TabIndex = 143
        '
        'lblbilling
        '
        Me.lblbilling.AutoSize = True
        Me.lblbilling.BackColor = System.Drawing.Color.Transparent
        Me.lblbilling.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbilling.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblbilling.Location = New System.Drawing.Point(15, 19)
        Me.lblbilling.Name = "lblbilling"
        Me.lblbilling.Size = New System.Drawing.Size(34, 14)
        Me.lblbilling.TabIndex = 142
        Me.lblbilling.Text = "Billing"
        '
        'grpAcc
        '
        Me.grpAcc.Controls.Add(Me.Label33)
        Me.grpAcc.Controls.Add(Me.cmbaccountStatus)
        Me.grpAcc.Controls.Add(Me.Label34)
        Me.grpAcc.Controls.Add(Me.cmbaccount)
        Me.grpAcc.Location = New System.Drawing.Point(526, 127)
        Me.grpAcc.Name = "grpAcc"
        Me.grpAcc.Size = New System.Drawing.Size(173, 109)
        Me.grpAcc.TabIndex = 159
        Me.grpAcc.TabStop = False
        Me.grpAcc.Text = "User Account Type"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label33.Location = New System.Drawing.Point(15, 61)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 14)
        Me.Label33.TabIndex = 148
        Me.Label33.Text = "Account Status"
        '
        'cmbaccountStatus
        '
        Me.cmbaccountStatus.FormattingEnabled = True
        Me.cmbaccountStatus.Items.AddRange(New Object() {"Active", "InActive", "Released", "Locked"})
        Me.cmbaccountStatus.Location = New System.Drawing.Point(17, 78)
        Me.cmbaccountStatus.Name = "cmbaccountStatus"
        Me.cmbaccountStatus.Size = New System.Drawing.Size(143, 21)
        Me.cmbaccountStatus.TabIndex = 147
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label34.Location = New System.Drawing.Point(16, 18)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(74, 14)
        Me.Label34.TabIndex = 146
        Me.Label34.Text = "Account Type"
        '
        'cmbaccount
        '
        Me.cmbaccount.FormattingEnabled = True
        Me.cmbaccount.Items.AddRange(New Object() {"General", "SubProcess"})
        Me.cmbaccount.Location = New System.Drawing.Point(18, 35)
        Me.cmbaccount.Name = "cmbaccount"
        Me.cmbaccount.Size = New System.Drawing.Size(143, 21)
        Me.cmbaccount.TabIndex = 128
        '
        'UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.grpProject)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.grpBill)
        Me.Controls.Add(Me.grpAcc)
        Me.Controls.Add(Me.cmdUpdateDetails)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UserManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.grpProject.ResumeLayout(False)
        Me.grpProject.PerformLayout()
        Me.grpBill.ResumeLayout(False)
        Me.grpBill.PerformLayout()
        Me.grpAcc.ResumeLayout(False)
        Me.grpAcc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdUpdateDetails As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbShiftType As System.Windows.Forms.ComboBox
    Friend WithEvents grpProject As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubProcess As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbProcess As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents grpBill As System.Windows.Forms.GroupBox
    Friend WithEvents cmbUtilization As System.Windows.Forms.ComboBox
    Friend WithEvents lblUtilization As System.Windows.Forms.Label
    Friend WithEvents cmbBilling As System.Windows.Forms.ComboBox
    Friend WithEvents lblbilling As System.Windows.Forms.Label
    Friend WithEvents grpAcc As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmbaccountStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmbaccount As System.Windows.Forms.ComboBox
End Class
