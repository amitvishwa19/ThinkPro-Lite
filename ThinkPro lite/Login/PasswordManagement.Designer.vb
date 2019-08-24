<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordManagement
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordManagement))
        Me.lblemplID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOldpass = New System.Windows.Forms.TextBox()
        Me.cmdChangePAss = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtconPass = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.txtsecans = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmdunlockaccount = New System.Windows.Forms.Button()
        Me.cmbquest = New System.Windows.Forms.ComboBox()
        Me.id = New System.Windows.Forms.Label()
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpUnlockAccount = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rdChange_Pasord = New System.Windows.Forms.RadioButton()
        Me.rdUnlockAccount = New System.Windows.Forms.RadioButton()
        Me.rdResetPassword = New System.Windows.Forms.RadioButton()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUnlockAccount.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblemplID
        '
        Me.lblemplID.AutoSize = True
        Me.lblemplID.BackColor = System.Drawing.Color.Transparent
        Me.lblemplID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblemplID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblemplID.Location = New System.Drawing.Point(54, 16)
        Me.lblemplID.Name = "lblemplID"
        Me.lblemplID.Size = New System.Drawing.Size(47, 13)
        Me.lblemplID.TabIndex = 29
        Me.lblemplID.Text = "Empl. ID"
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.SteelBlue
        Me.txtID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.txtID.Location = New System.Drawing.Point(103, 13)
        Me.txtID.Name = "txtID"
        Me.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtID.Size = New System.Drawing.Size(166, 20)
        Me.txtID.TabIndex = 1
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdGo
        '
        Me.cmdGo.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdGo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdGo.FlatAppearance.BorderSize = 0
        Me.cmdGo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdGo.Location = New System.Drawing.Point(125, 39)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(119, 21)
        Me.cmdGo.TabIndex = 2
        Me.cmdGo.Text = "Proceed"
        Me.cmdGo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Old Password"
        '
        'txtOldpass
        '
        Me.txtOldpass.Location = New System.Drawing.Point(120, 126)
        Me.txtOldpass.Name = "txtOldpass"
        Me.txtOldpass.Size = New System.Drawing.Size(194, 20)
        Me.txtOldpass.TabIndex = 6
        Me.txtOldpass.UseSystemPasswordChar = True
        '
        'cmdChangePAss
        '
        Me.cmdChangePAss.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdChangePAss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdChangePAss.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdChangePAss.FlatAppearance.BorderSize = 0
        Me.cmdChangePAss.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdChangePAss.Location = New System.Drawing.Point(212, 289)
        Me.cmdChangePAss.Name = "cmdChangePAss"
        Me.cmdChangePAss.Size = New System.Drawing.Size(116, 28)
        Me.cmdChangePAss.TabIndex = 9
        Me.cmdChangePAss.Text = "Change password"
        Me.cmdChangePAss.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Confirm Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "New Password"
        '
        'txtconPass
        '
        Me.txtconPass.Location = New System.Drawing.Point(120, 192)
        Me.txtconPass.Name = "txtconPass"
        Me.txtconPass.Size = New System.Drawing.Size(194, 20)
        Me.txtconPass.TabIndex = 8
        Me.txtconPass.UseSystemPasswordChar = True
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(120, 158)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(194, 20)
        Me.txtpass.TabIndex = 7
        Me.txtpass.UseSystemPasswordChar = True
        '
        'txtsecans
        '
        Me.txtsecans.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtsecans.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsecans.Location = New System.Drawing.Point(20, 83)
        Me.txtsecans.Name = "txtsecans"
        Me.txtsecans.Size = New System.Drawing.Size(294, 20)
        Me.txtsecans.TabIndex = 4
        Me.txtsecans.UseSystemPasswordChar = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(19, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 157
        Me.Label12.Text = "Answer"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(18, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Secret Question-1"
        '
        'cmdunlockaccount
        '
        Me.cmdunlockaccount.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdunlockaccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdunlockaccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdunlockaccount.FlatAppearance.BorderSize = 0
        Me.cmdunlockaccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdunlockaccount.Location = New System.Drawing.Point(6, 289)
        Me.cmdunlockaccount.Name = "cmdunlockaccount"
        Me.cmdunlockaccount.Size = New System.Drawing.Size(102, 28)
        Me.cmdunlockaccount.TabIndex = 5
        Me.cmdunlockaccount.Text = "Unlock Account"
        Me.cmdunlockaccount.UseVisualStyleBackColor = False
        '
        'cmbquest
        '
        Me.cmbquest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbquest.FormattingEnabled = True
        Me.cmbquest.Location = New System.Drawing.Point(20, 40)
        Me.cmbquest.Name = "cmbquest"
        Me.cmbquest.Size = New System.Drawing.Size(294, 21)
        Me.cmbquest.TabIndex = 3
        '
        'id
        '
        Me.id.AutoSize = True
        Me.id.Location = New System.Drawing.Point(9, 9)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(18, 13)
        Me.id.TabIndex = 71
        Me.id.Text = "ID"
        Me.id.Visible = False
        '
        'ErrorProviderError
        '
        Me.ErrorProviderError.ContainerControl = Me
        Me.ErrorProviderError.Icon = CType(resources.GetObject("ErrorProviderError.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderWarning
        '
        Me.ErrorProviderWarning.ContainerControl = Me
        Me.ErrorProviderWarning.Icon = CType(resources.GetObject("ErrorProviderWarning.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderok
        '
        Me.ErrorProviderok.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderok.ContainerControl = Me
        Me.ErrorProviderok.Icon = CType(resources.GetObject("ErrorProviderok.Icon"), System.Drawing.Icon)
        '
        'grpUnlockAccount
        '
        Me.grpUnlockAccount.Controls.Add(Me.Label1)
        Me.grpUnlockAccount.Controls.Add(Me.Button1)
        Me.grpUnlockAccount.Controls.Add(Me.txtOldpass)
        Me.grpUnlockAccount.Controls.Add(Me.Label5)
        Me.grpUnlockAccount.Controls.Add(Me.cmdunlockaccount)
        Me.grpUnlockAccount.Controls.Add(Me.Label4)
        Me.grpUnlockAccount.Controls.Add(Me.cmdChangePAss)
        Me.grpUnlockAccount.Controls.Add(Me.txtconPass)
        Me.grpUnlockAccount.Controls.Add(Me.cmbquest)
        Me.grpUnlockAccount.Controls.Add(Me.txtpass)
        Me.grpUnlockAccount.Controls.Add(Me.txtsecans)
        Me.grpUnlockAccount.Controls.Add(Me.Label11)
        Me.grpUnlockAccount.Controls.Add(Me.Label12)
        Me.grpUnlockAccount.Enabled = False
        Me.grpUnlockAccount.Location = New System.Drawing.Point(12, 99)
        Me.grpUnlockAccount.Name = "grpUnlockAccount"
        Me.grpUnlockAccount.Size = New System.Drawing.Size(334, 323)
        Me.grpUnlockAccount.TabIndex = 155
        Me.grpUnlockAccount.TabStop = False
        Me.grpUnlockAccount.Text = "Unlock Account"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(111, 289)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 28)
        Me.Button1.TabIndex = 158
        Me.Button1.Text = "Reset password"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'rdChange_Pasord
        '
        Me.rdChange_Pasord.AutoSize = True
        Me.rdChange_Pasord.Enabled = False
        Me.rdChange_Pasord.Location = New System.Drawing.Point(22, 76)
        Me.rdChange_Pasord.Name = "rdChange_Pasord"
        Me.rdChange_Pasord.Size = New System.Drawing.Size(111, 17)
        Me.rdChange_Pasord.TabIndex = 156
        Me.rdChange_Pasord.TabStop = True
        Me.rdChange_Pasord.Text = "Change Password"
        Me.rdChange_Pasord.UseVisualStyleBackColor = True
        '
        'rdUnlockAccount
        '
        Me.rdUnlockAccount.AutoSize = True
        Me.rdUnlockAccount.Enabled = False
        Me.rdUnlockAccount.Location = New System.Drawing.Point(143, 76)
        Me.rdUnlockAccount.Name = "rdUnlockAccount"
        Me.rdUnlockAccount.Size = New System.Drawing.Size(102, 17)
        Me.rdUnlockAccount.TabIndex = 157
        Me.rdUnlockAccount.TabStop = True
        Me.rdUnlockAccount.Text = "Unlock Account"
        Me.rdUnlockAccount.UseVisualStyleBackColor = True
        '
        'rdResetPassword
        '
        Me.rdResetPassword.AutoSize = True
        Me.rdResetPassword.Enabled = False
        Me.rdResetPassword.Location = New System.Drawing.Point(242, 76)
        Me.rdResetPassword.Name = "rdResetPassword"
        Me.rdResetPassword.Size = New System.Drawing.Size(101, 17)
        Me.rdResetPassword.TabIndex = 158
        Me.rdResetPassword.TabStop = True
        Me.rdResetPassword.Text = "Reset password"
        Me.rdResetPassword.UseVisualStyleBackColor = True
        '
        'PasswordManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(357, 427)
        Me.Controls.Add(Me.rdResetPassword)
        Me.Controls.Add(Me.rdUnlockAccount)
        Me.Controls.Add(Me.rdChange_Pasord)
        Me.Controls.Add(Me.grpUnlockAccount)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.lblemplID)
        Me.Controls.Add(Me.txtID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PasswordManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password Management"
        Me.TopMost = True
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUnlockAccount.ResumeLayout(False)
        Me.grpUnlockAccount.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblemplID As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtconPass As System.Windows.Forms.TextBox
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents id As System.Windows.Forms.Label
    Friend WithEvents ErrorProviderError As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderWarning As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderok As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdunlockaccount As System.Windows.Forms.Button
    Friend WithEvents cmdChangePAss As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbquest As System.Windows.Forms.ComboBox
    Friend WithEvents txtsecans As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOldpass As System.Windows.Forms.TextBox
    Friend WithEvents grpUnlockAccount As System.Windows.Forms.GroupBox
    Friend WithEvents rdUnlockAccount As System.Windows.Forms.RadioButton
    Friend WithEvents rdChange_Pasord As System.Windows.Forms.RadioButton
    Friend WithEvents rdResetPassword As RadioButton
    Friend WithEvents Button1 As Button
End Class
