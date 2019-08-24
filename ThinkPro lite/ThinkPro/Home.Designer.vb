<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.menHome = New System.Windows.Forms.ToolStripMenuItem()
        Me.msLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.msRegister = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThinkProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCurrentProfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnlockAccnt = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrowseConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.msExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mTimeView = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmTimeView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mThinkManagement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThinkManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsentManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectCreatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMyConsentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataRetentionPolicyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeProfile = New System.Windows.Forms.GroupBox()
        Me.lblProjectID = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblSubProcess = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEmplID = New System.Windows.Forms.Label()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LoadStamp = New System.Windows.Forms.Label()
        Me.LockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LoginPanel = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.chkRememberme = New System.Windows.Forms.CheckBox()
        Me.lblattempt = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.ThinkProfile = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DefaultProfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.Profile2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Profile3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Profile4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSystemUptime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblIdleTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPublishVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainMenu.SuspendLayout()
        Me.HomeProfile.SuspendLayout()
        Me.LoginPanel.SuspendLayout()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.BackColor = System.Drawing.Color.Transparent
        Me.MainMenu.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menHome, Me.mTimeView, Me.mThinkManagement, Me.MenuAdmin, Me.menHelp})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(834, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'menHome
        '
        Me.menHome.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msLogin, Me.msRegister, Me.ThinkProfileToolStripMenuItem, Me.MenuCurrentProfile, Me.PasswordManagementToolStripMenuItem, Me.SettingToolStripMenuItem, Me.MenuLogout, Me.msExit})
        Me.menHome.Name = "menHome"
        Me.menHome.Size = New System.Drawing.Size(52, 20)
        Me.menHome.Text = "Home"
        '
        'msLogin
        '
        Me.msLogin.Name = "msLogin"
        Me.msLogin.Size = New System.Drawing.Size(205, 22)
        Me.msLogin.Text = "Login"
        '
        'msRegister
        '
        Me.msRegister.Name = "msRegister"
        Me.msRegister.Size = New System.Drawing.Size(205, 22)
        Me.msRegister.Text = "Register"
        '
        'ThinkProfileToolStripMenuItem
        '
        Me.ThinkProfileToolStripMenuItem.Name = "ThinkProfileToolStripMenuItem"
        Me.ThinkProfileToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ThinkProfileToolStripMenuItem.Text = "ThinkProfile"
        '
        'MenuCurrentProfile
        '
        Me.MenuCurrentProfile.Name = "MenuCurrentProfile"
        Me.MenuCurrentProfile.Size = New System.Drawing.Size(205, 22)
        Me.MenuCurrentProfile.Text = "Current Profile"
        '
        'PasswordManagementToolStripMenuItem
        '
        Me.PasswordManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem1, Me.UnlockAccnt})
        Me.PasswordManagementToolStripMenuItem.Name = "PasswordManagementToolStripMenuItem"
        Me.PasswordManagementToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.PasswordManagementToolStripMenuItem.Text = "Password Management"
        '
        'ChangePasswordToolStripMenuItem1
        '
        Me.ChangePasswordToolStripMenuItem1.Name = "ChangePasswordToolStripMenuItem1"
        Me.ChangePasswordToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.ChangePasswordToolStripMenuItem1.Text = "Change Password"
        '
        'UnlockAccnt
        '
        Me.UnlockAccnt.Name = "UnlockAccnt"
        Me.UnlockAccnt.Size = New System.Drawing.Size(176, 22)
        Me.UnlockAccnt.Text = "Unlock Account"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseConfigFileToolStripMenuItem})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'BrowseConfigFileToolStripMenuItem
        '
        Me.BrowseConfigFileToolStripMenuItem.Name = "BrowseConfigFileToolStripMenuItem"
        Me.BrowseConfigFileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BrowseConfigFileToolStripMenuItem.Text = "Browse Config File"
        '
        'MenuLogout
        '
        Me.MenuLogout.Name = "MenuLogout"
        Me.MenuLogout.Size = New System.Drawing.Size(205, 22)
        Me.MenuLogout.Text = "Logout"
        '
        'msExit
        '
        Me.msExit.Name = "msExit"
        Me.msExit.Size = New System.Drawing.Size(205, 22)
        Me.msExit.Text = "Exit"
        '
        'mTimeView
        '
        Me.mTimeView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmTimeView})
        Me.mTimeView.Name = "mTimeView"
        Me.mTimeView.Size = New System.Drawing.Size(69, 20)
        Me.mTimeView.Text = "Thinkpro"
        '
        'tmTimeView
        '
        Me.tmTimeView.Name = "tmTimeView"
        Me.tmTimeView.Size = New System.Drawing.Size(159, 22)
        Me.tmTimeView.Text = "Activity Logger"
        '
        'mThinkManagement
        '
        Me.mThinkManagement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThinkManagementToolStripMenuItem, Me.ConsentManagementToolStripMenuItem})
        Me.mThinkManagement.Name = "mThinkManagement"
        Me.mThinkManagement.Size = New System.Drawing.Size(92, 20)
        Me.mThinkManagement.Text = "Management"
        '
        'ThinkManagementToolStripMenuItem
        '
        Me.ThinkManagementToolStripMenuItem.Name = "ThinkManagementToolStripMenuItem"
        Me.ThinkManagementToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ThinkManagementToolStripMenuItem.Text = "Think Management"
        '
        'ConsentManagementToolStripMenuItem
        '
        Me.ConsentManagementToolStripMenuItem.Name = "ConsentManagementToolStripMenuItem"
        Me.ConsentManagementToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConsentManagementToolStripMenuItem.Text = "Consent Management"
        '
        'MenuAdmin
        '
        Me.MenuAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ErrorLogToolStripMenuItem, Me.DataTransferToolStripMenuItem, Me.ProjectCreatorToolStripMenuItem})
        Me.MenuAdmin.Name = "MenuAdmin"
        Me.MenuAdmin.Size = New System.Drawing.Size(55, 20)
        Me.MenuAdmin.Text = "Admin"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ErrorLogToolStripMenuItem
        '
        Me.ErrorLogToolStripMenuItem.Name = "ErrorLogToolStripMenuItem"
        Me.ErrorLogToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ErrorLogToolStripMenuItem.Text = "Error log"
        '
        'DataTransferToolStripMenuItem
        '
        Me.DataTransferToolStripMenuItem.Name = "DataTransferToolStripMenuItem"
        Me.DataTransferToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.DataTransferToolStripMenuItem.Text = "Data Transfer"
        '
        'ProjectCreatorToolStripMenuItem
        '
        Me.ProjectCreatorToolStripMenuItem.Name = "ProjectCreatorToolStripMenuItem"
        Me.ProjectCreatorToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ProjectCreatorToolStripMenuItem.Text = "Project Creator"
        '
        'menHelp
        '
        Me.menHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewRequestToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ViewMyConsentToolStripMenuItem, Me.DataRetentionPolicyToolStripMenuItem})
        Me.menHelp.Name = "menHelp"
        Me.menHelp.Size = New System.Drawing.Size(44, 20)
        Me.menHelp.Text = "Help"
        '
        'NewRequestToolStripMenuItem
        '
        Me.NewRequestToolStripMenuItem.Enabled = False
        Me.NewRequestToolStripMenuItem.Name = "NewRequestToolStripMenuItem"
        Me.NewRequestToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.NewRequestToolStripMenuItem.Text = "Issue Logger"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ViewMyConsentToolStripMenuItem
        '
        Me.ViewMyConsentToolStripMenuItem.Name = "ViewMyConsentToolStripMenuItem"
        Me.ViewMyConsentToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ViewMyConsentToolStripMenuItem.Text = "View my Consent"
        '
        'DataRetentionPolicyToolStripMenuItem
        '
        Me.DataRetentionPolicyToolStripMenuItem.Name = "DataRetentionPolicyToolStripMenuItem"
        Me.DataRetentionPolicyToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.DataRetentionPolicyToolStripMenuItem.Text = "Data Retention Policy"
        '
        'HomeProfile
        '
        Me.HomeProfile.BackColor = System.Drawing.Color.Transparent
        Me.HomeProfile.Controls.Add(Me.lblProjectID)
        Me.HomeProfile.Controls.Add(Me.lblAccount)
        Me.HomeProfile.Controls.Add(Me.lblSubProcess)
        Me.HomeProfile.Controls.Add(Me.lblName)
        Me.HomeProfile.Controls.Add(Me.lblEmplID)
        Me.HomeProfile.Controls.Add(Me.lblProject)
        Me.HomeProfile.Controls.Add(Me.lblProcess)
        Me.HomeProfile.Cursor = System.Windows.Forms.Cursors.Default
        Me.HomeProfile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeProfile.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.HomeProfile.Location = New System.Drawing.Point(13, 27)
        Me.HomeProfile.Name = "HomeProfile"
        Me.HomeProfile.Size = New System.Drawing.Size(298, 78)
        Me.HomeProfile.TabIndex = 103
        Me.HomeProfile.TabStop = False
        Me.HomeProfile.Text = "My Details"
        Me.HomeProfile.Visible = False
        '
        'lblProjectID
        '
        Me.lblProjectID.AutoSize = True
        Me.lblProjectID.BackColor = System.Drawing.Color.Transparent
        Me.lblProjectID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProjectID.Location = New System.Drawing.Point(315, 12)
        Me.lblProjectID.Name = "lblProjectID"
        Me.lblProjectID.Size = New System.Drawing.Size(12, 13)
        Me.lblProjectID.TabIndex = 126
        Me.lblProjectID.Text = "-"
        Me.lblProjectID.Visible = False
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.BackColor = System.Drawing.Color.Transparent
        Me.lblAccount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAccount.Location = New System.Drawing.Point(17, 60)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(12, 13)
        Me.lblAccount.TabIndex = 114
        Me.lblAccount.Text = "-"
        '
        'lblSubProcess
        '
        Me.lblSubProcess.AutoSize = True
        Me.lblSubProcess.BackColor = System.Drawing.Color.Transparent
        Me.lblSubProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubProcess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSubProcess.Location = New System.Drawing.Point(181, 62)
        Me.lblSubProcess.Name = "lblSubProcess"
        Me.lblSubProcess.Size = New System.Drawing.Size(12, 13)
        Me.lblSubProcess.TabIndex = 111
        Me.lblSubProcess.Text = "-"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblName.Location = New System.Drawing.Point(17, 21)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(12, 13)
        Me.lblName.TabIndex = 113
        Me.lblName.Text = "-"
        '
        'lblEmplID
        '
        Me.lblEmplID.AutoSize = True
        Me.lblEmplID.BackColor = System.Drawing.Color.Transparent
        Me.lblEmplID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmplID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEmplID.Location = New System.Drawing.Point(17, 40)
        Me.lblEmplID.Name = "lblEmplID"
        Me.lblEmplID.Size = New System.Drawing.Size(12, 13)
        Me.lblEmplID.TabIndex = 112
        Me.lblEmplID.Text = "-"
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.BackColor = System.Drawing.Color.Transparent
        Me.lblProject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProject.Location = New System.Drawing.Point(181, 24)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(12, 13)
        Me.lblProject.TabIndex = 110
        Me.lblProject.Text = "-"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.BackColor = System.Drawing.Color.Transparent
        Me.lblProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess.Location = New System.Drawing.Point(181, 43)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(12, 13)
        Me.lblProcess.TabIndex = 109
        Me.lblProcess.Text = "-"
        '
        'LoadTimer
        '
        Me.LoadTimer.Interval = 200
        '
        'LoadStamp
        '
        Me.LoadStamp.AutoSize = True
        Me.LoadStamp.BackColor = System.Drawing.Color.Transparent
        Me.LoadStamp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadStamp.Location = New System.Drawing.Point(10, 387)
        Me.LoadStamp.Name = "LoadStamp"
        Me.LoadStamp.Size = New System.Drawing.Size(0, 13)
        Me.LoadStamp.TabIndex = 107
        '
        'LockTimer
        '
        Me.LockTimer.Interval = 1000
        '
        'LoginPanel
        '
        Me.LoginPanel.BackColor = System.Drawing.Color.Transparent
        Me.LoginPanel.Controls.Add(Me.LinkLabel2)
        Me.LoginPanel.Controls.Add(Me.chkRememberme)
        Me.LoginPanel.Controls.Add(Me.lblattempt)
        Me.LoginPanel.Controls.Add(Me.lblPass)
        Me.LoginPanel.Controls.Add(Me.Label4)
        Me.LoginPanel.Controls.Add(Me.CmdExit)
        Me.LoginPanel.Controls.Add(Me.cmdLogin)
        Me.LoginPanel.Controls.Add(Me.txtPass)
        Me.LoginPanel.Controls.Add(Me.txtID)
        Me.LoginPanel.Location = New System.Drawing.Point(221, 126)
        Me.LoginPanel.Name = "LoginPanel"
        Me.LoginPanel.Size = New System.Drawing.Size(394, 207)
        Me.LoginPanel.TabIndex = 123
        Me.LoginPanel.Visible = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.Location = New System.Drawing.Point(83, 173)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(86, 13)
        Me.LinkLabel2.TabIndex = 127
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Forgot Password"
        '
        'chkRememberme
        '
        Me.chkRememberme.AutoSize = True
        Me.chkRememberme.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkRememberme.Location = New System.Drawing.Point(145, 110)
        Me.chkRememberme.Name = "chkRememberme"
        Me.chkRememberme.Size = New System.Drawing.Size(111, 17)
        Me.chkRememberme.TabIndex = 3
        Me.chkRememberme.Text = "Remember me"
        Me.chkRememberme.UseVisualStyleBackColor = True
        '
        'lblattempt
        '
        Me.lblattempt.AutoSize = True
        Me.lblattempt.BackColor = System.Drawing.Color.Transparent
        Me.lblattempt.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblattempt.ForeColor = System.Drawing.Color.Red
        Me.lblattempt.Location = New System.Drawing.Point(131, 93)
        Me.lblattempt.Name = "lblattempt"
        Me.lblattempt.Size = New System.Drawing.Size(0, 12)
        Me.lblattempt.TabIndex = 39
        Me.lblattempt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.BackColor = System.Drawing.Color.Transparent
        Me.lblPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPass.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPass.Location = New System.Drawing.Point(66, 72)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(61, 13)
        Me.lblPass.TabIndex = 38
        Me.lblPass.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(72, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Empl. ID"
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.CmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdExit.FlatAppearance.BorderSize = 0
        Me.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdExit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdExit.Location = New System.Drawing.Point(246, 137)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 23)
        Me.CmdExit.TabIndex = 5
        Me.CmdExit.Text = "Cancel"
        Me.CmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'cmdLogin
        '
        Me.cmdLogin.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.cmdLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLogin.FlatAppearance.BorderSize = 0
        Me.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogin.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(86, 137)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(75, 23)
        Me.cmdLogin.TabIndex = 4
        Me.cmdLogin.Text = "Login"
        Me.cmdLogin.UseVisualStyleBackColor = False
        '
        'txtPass
        '
        Me.txtPass.BackColor = System.Drawing.Color.SteelBlue
        Me.txtPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPass.Location = New System.Drawing.Point(130, 69)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPass.Size = New System.Drawing.Size(166, 20)
        Me.txtPass.TabIndex = 2
        Me.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPass.UseSystemPasswordChar = True
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.SteelBlue
        Me.txtID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.txtID.Location = New System.Drawing.Point(130, 28)
        Me.txtID.MaxLength = 10
        Me.txtID.Name = "txtID"
        Me.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtID.Size = New System.Drawing.Size(166, 20)
        Me.txtID.TabIndex = 1
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ErrorProviderok
        '
        Me.ErrorProviderok.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderok.ContainerControl = Me
        Me.ErrorProviderok.Icon = CType(resources.GetObject("ErrorProviderok.Icon"), System.Drawing.Icon)
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
        'statusBar
        '
        Me.statusBar.BackColor = System.Drawing.Color.Transparent
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThinkProfile, Me.lblSystemUptime, Me.lblIdleTime, Me.lblVersion, Me.lblPublishVersion, Me.ToolStripStatusLabel1})
        Me.statusBar.Location = New System.Drawing.Point(0, 440)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(834, 22)
        Me.statusBar.TabIndex = 125
        Me.statusBar.Text = "StatusStrip1"
        '
        'ThinkProfile
        '
        Me.ThinkProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ThinkProfile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultProfile, Me.Profile2, Me.Profile3, Me.Profile4})
        Me.ThinkProfile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ThinkProfile.Image = CType(resources.GetObject("ThinkProfile.Image"), System.Drawing.Image)
        Me.ThinkProfile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ThinkProfile.Name = "ThinkProfile"
        Me.ThinkProfile.Size = New System.Drawing.Size(74, 20)
        Me.ThinkProfile.Text = "My Profile"
        '
        'DefaultProfile
        '
        Me.DefaultProfile.Name = "DefaultProfile"
        Me.DefaultProfile.Size = New System.Drawing.Size(149, 22)
        Me.DefaultProfile.Text = "Default Profile"
        '
        'Profile2
        '
        Me.Profile2.Name = "Profile2"
        Me.Profile2.Size = New System.Drawing.Size(149, 22)
        Me.Profile2.Text = "Profile 2"
        '
        'Profile3
        '
        Me.Profile3.Name = "Profile3"
        Me.Profile3.Size = New System.Drawing.Size(149, 22)
        Me.Profile3.Text = "Profile 3"
        '
        'Profile4
        '
        Me.Profile4.Name = "Profile4"
        Me.Profile4.Size = New System.Drawing.Size(149, 22)
        Me.Profile4.Text = "Profile 4"
        '
        'lblSystemUptime
        '
        Me.lblSystemUptime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSystemUptime.Name = "lblSystemUptime"
        Me.lblSystemUptime.Size = New System.Drawing.Size(90, 17)
        Me.lblSystemUptime.Text = "System Uptime:"
        '
        'lblIdleTime
        '
        Me.lblIdleTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIdleTime.Name = "lblIdleTime"
        Me.lblIdleTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIdleTime.Size = New System.Drawing.Size(59, 17)
        Me.lblIdleTime.Text = "Idle Time:"
        '
        'lblVersion
        '
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 17)
        Me.lblVersion.Text = "Version: "
        '
        'lblPublishVersion
        '
        Me.lblPublishVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblPublishVersion.Name = "lblPublishVersion"
        Me.lblPublishVersion.Size = New System.Drawing.Size(97, 17)
        Me.lblPublishVersion.Text = "Publised Version:"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.ThinkProlite.My.Resources.Resources.MainBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.MainMenu)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.LoginPanel)
        Me.Controls.Add(Me.LoadStamp)
        Me.Controls.Add(Me.HomeProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MainMenu
        Me.MaximizeBox = False
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThinkPro Lite"
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.HomeProfile.ResumeLayout(False)
        Me.HomeProfile.PerformLayout()
        Me.LoginPanel.ResumeLayout(False)
        Me.LoginPanel.PerformLayout()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents menHome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HomeProfile As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents lblSubProcess As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblEmplID As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
    Friend WithEvents menHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mTimeView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadStamp As System.Windows.Forms.Label
    Friend WithEvents tmTimeView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewRequestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LockTimer As System.Windows.Forms.Timer
    Friend WithEvents msExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mThinkManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginPanel As System.Windows.Forms.Panel
    Friend WithEvents chkRememberme As System.Windows.Forms.CheckBox
    Friend WithEvents lblattempt As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProviderok As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderError As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderWarning As System.Windows.Forms.ErrorProvider
    Friend WithEvents MenuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasswordManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblSystemUptime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblIdleTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPublishVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ThinkProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblProjectID As System.Windows.Forms.Label
    Friend WithEvents ThinkProfile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents DefaultProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Profile2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Profile3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Profile4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAdmin As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ErrorLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuCurrentProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataTransferToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectCreatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents ThinkManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UnlockAccnt As ToolStripMenuItem
    Friend WithEvents ViewMyConsentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataRetentionPolicyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BrowseConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsentManagementToolStripMenuItem As ToolStripMenuItem
End Class
