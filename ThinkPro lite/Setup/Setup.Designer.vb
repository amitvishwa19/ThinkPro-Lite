<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setup))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.lblMessege = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.browse = New System.Windows.Forms.Button()
        Me.txtconfpath = New System.Windows.Forms.TextBox()
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.txtServerPort = New System.Windows.Forms.TextBox()
        Me.txtDatabaseID = New System.Windows.Forms.TextBox()
        Me.txtDatabasePass = New System.Windows.Forms.TextBox()
        Me.a = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.q = New System.Windows.Forms.Label()
        Me.w = New System.Windows.Forms.Label()
        Me.txtDatabasePassq = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.cmdTestConn = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.cmdConfFile = New System.Windows.Forms.Button()
        Me.TopPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopPanel
        '
        Me.TopPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TopPanel.Controls.Add(Me.lblMessege)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(539, 30)
        Me.TopPanel.TabIndex = 0
        '
        'lblMessege
        '
        Me.lblMessege.AutoSize = True
        Me.lblMessege.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessege.Location = New System.Drawing.Point(12, 9)
        Me.lblMessege.Name = "lblMessege"
        Me.lblMessege.Size = New System.Drawing.Size(138, 13)
        Me.lblMessege.TabIndex = 0
        Me.lblMessege.Text = "ThinkPro Setup Wizard"
        Me.lblMessege.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdNext)
        Me.Panel2.Controls.Add(Me.cmdBack)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 293)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(539, 35)
        Me.Panel2.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(275, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(81, 22)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(449, 6)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(81, 22)
        Me.cmdNext.TabIndex = 14
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(362, 6)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(81, 22)
        Me.cmdBack.TabIndex = 13
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
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
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(531, 237)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdConfFile)
        Me.TabPage1.Controls.Add(Me.cmdTestConn)
        Me.TabPage1.Controls.Add(Me.RadioButton1)
        Me.TabPage1.Controls.Add(Me.txtDatabasePassq)
        Me.TabPage1.Controls.Add(Me.w)
        Me.TabPage1.Controls.Add(Me.q)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.a)
        Me.TabPage1.Controls.Add(Me.txtDatabasePass)
        Me.TabPage1.Controls.Add(Me.txtDatabaseID)
        Me.TabPage1.Controls.Add(Me.txtServerPort)
        Me.TabPage1.Controls.Add(Me.txtDatabaseName)
        Me.TabPage1.Controls.Add(Me.txtServerAddress)
        Me.TabPage1.Controls.Add(Me.txtconfpath)
        Me.TabPage1.Controls.Add(Me.browse)
        Me.TabPage1.Controls.Add(Me.RadioButton2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(531, 237)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(13, 5)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(214, 17)
        Me.RadioButton2.TabIndex = 18
        Me.RadioButton2.Text = "Connect With existing configuration File "
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'browse
        '
        Me.browse.Enabled = False
        Me.browse.Location = New System.Drawing.Point(320, 32)
        Me.browse.Name = "browse"
        Me.browse.Size = New System.Drawing.Size(65, 21)
        Me.browse.TabIndex = 20
        Me.browse.Text = "Browse"
        Me.browse.UseVisualStyleBackColor = True
        '
        'txtconfpath
        '
        Me.txtconfpath.Enabled = False
        Me.txtconfpath.Location = New System.Drawing.Point(33, 33)
        Me.txtconfpath.Name = "txtconfpath"
        Me.txtconfpath.Size = New System.Drawing.Size(281, 20)
        Me.txtconfpath.TabIndex = 19
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Enabled = False
        Me.txtServerAddress.Location = New System.Drawing.Point(147, 119)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(262, 20)
        Me.txtServerAddress.TabIndex = 22
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Enabled = False
        Me.txtDatabaseName.Location = New System.Drawing.Point(147, 89)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabaseName.TabIndex = 21
        '
        'txtServerPort
        '
        Me.txtServerPort.Enabled = False
        Me.txtServerPort.Location = New System.Drawing.Point(147, 145)
        Me.txtServerPort.Name = "txtServerPort"
        Me.txtServerPort.Size = New System.Drawing.Size(262, 20)
        Me.txtServerPort.TabIndex = 23
        '
        'txtDatabaseID
        '
        Me.txtDatabaseID.Enabled = False
        Me.txtDatabaseID.Location = New System.Drawing.Point(147, 171)
        Me.txtDatabaseID.Name = "txtDatabaseID"
        Me.txtDatabaseID.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabaseID.TabIndex = 29
        '
        'txtDatabasePass
        '
        Me.txtDatabasePass.Enabled = False
        Me.txtDatabasePass.Location = New System.Drawing.Point(147, 197)
        Me.txtDatabasePass.Name = "txtDatabasePass"
        Me.txtDatabasePass.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabasePass.TabIndex = 30
        Me.txtDatabasePass.UseSystemPasswordChar = True
        '
        'a
        '
        Me.a.AutoSize = True
        Me.a.Location = New System.Drawing.Point(36, 122)
        Me.a.Name = "a"
        Me.a.Size = New System.Drawing.Size(79, 13)
        Me.a.TabIndex = 28
        Me.a.Text = "Server Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Database Name"
        '
        'q
        '
        Me.q.AutoSize = True
        Me.q.Location = New System.Drawing.Point(36, 148)
        Me.q.Name = "q"
        Me.q.Size = New System.Drawing.Size(60, 13)
        Me.q.TabIndex = 26
        Me.q.Text = "Server Port"
        '
        'w
        '
        Me.w.AutoSize = True
        Me.w.Location = New System.Drawing.Point(36, 174)
        Me.w.Name = "w"
        Me.w.Size = New System.Drawing.Size(67, 13)
        Me.w.TabIndex = 25
        Me.w.Text = "Database ID"
        '
        'txtDatabasePassq
        '
        Me.txtDatabasePassq.AutoSize = True
        Me.txtDatabasePassq.Location = New System.Drawing.Point(36, 200)
        Me.txtDatabasePassq.Name = "txtDatabasePassq"
        Me.txtDatabasePassq.Size = New System.Drawing.Size(102, 13)
        Me.txtDatabasePassq.TabIndex = 24
        Me.txtDatabasePassq.Text = "Database Password"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 62)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(182, 17)
        Me.RadioButton1.TabIndex = 31
        Me.RadioButton1.Text = "Create new database connection"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'cmdTestConn
        '
        Me.cmdTestConn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdTestConn.Location = New System.Drawing.Point(421, 86)
        Me.cmdTestConn.Name = "cmdTestConn"
        Me.cmdTestConn.Size = New System.Drawing.Size(98, 49)
        Me.cmdTestConn.TabIndex = 32
        Me.cmdTestConn.Text = "Test Connection"
        Me.cmdTestConn.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(539, 263)
        Me.TabControl1.TabIndex = 2
        '
        'cmdConfFile
        '
        Me.cmdConfFile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdConfFile.Enabled = False
        Me.cmdConfFile.Location = New System.Drawing.Point(421, 138)
        Me.cmdConfFile.Name = "cmdConfFile"
        Me.cmdConfFile.Size = New System.Drawing.Size(98, 49)
        Me.cmdConfFile.TabIndex = 33
        Me.cmdConfFile.Text = "Create Conf. File"
        Me.cmdConfFile.UseVisualStyleBackColor = False
        '
        'Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(539, 328)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TopPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThinkPro Setup Wizard"
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TopPanel As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents lblMessege As System.Windows.Forms.Label
    Friend WithEvents ErrorProviderok As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderError As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderWarning As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdTestConn As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtDatabasePassq As System.Windows.Forms.Label
    Friend WithEvents w As System.Windows.Forms.Label
    Friend WithEvents q As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents a As System.Windows.Forms.Label
    Friend WithEvents txtDatabasePass As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseID As System.Windows.Forms.TextBox
    Friend WithEvents txtServerPort As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents txtServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtconfpath As System.Windows.Forms.TextBox
    Friend WithEvents browse As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdConfFile As System.Windows.Forms.Button

End Class
