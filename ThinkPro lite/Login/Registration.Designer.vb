<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registration))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtname = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSubProcess = New System.Windows.Forms.ComboBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.cmdRegisterMe = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassWW = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmpID = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPasswordcnf = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtsecans3 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbquest3 = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtsecans2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbquest2 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtsecans1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbquest1 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ThinkLabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtname)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbSubProcess)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbProcess)
        Me.GroupBox1.Controls.Add(Me.cmbProject)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 391)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project Details"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(213, 131)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel1.TabIndex = 119
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Create Project"
        '
        'txtname
        '
        Me.txtname.AutoSize = True
        Me.txtname.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(154, 111)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(0, 13)
        Me.txtname.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(19, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Sub Process"
        '
        'cmbSubProcess
        '
        Me.cmbSubProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubProcess.FormattingEnabled = True
        Me.cmbSubProcess.Location = New System.Drawing.Point(22, 230)
        Me.cmbSubProcess.Name = "cmbSubProcess"
        Me.cmbSubProcess.Size = New System.Drawing.Size(265, 21)
        Me.cmbSubProcess.TabIndex = 62
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(22, 86)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(265, 20)
        Me.txtLastName.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(21, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Project"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(19, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(19, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Process"
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(22, 45)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(265, 20)
        Me.txtFirstName.TabIndex = 51
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(19, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Last Name"
        '
        'cmbProcess
        '
        Me.cmbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(22, 187)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(265, 21)
        Me.cmbProcess.TabIndex = 54
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(22, 147)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(265, 21)
        Me.cmbProject.TabIndex = 53
        '
        'cmdRegisterMe
        '
        Me.cmdRegisterMe.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdRegisterMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRegisterMe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRegisterMe.FlatAppearance.BorderSize = 0
        Me.cmdRegisterMe.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRegisterMe.Location = New System.Drawing.Point(341, 376)
        Me.cmdRegisterMe.Name = "cmdRegisterMe"
        Me.cmdRegisterMe.Size = New System.Drawing.Size(142, 32)
        Me.cmdRegisterMe.TabIndex = 63
        Me.cmdRegisterMe.Text = "Register Me"
        Me.cmdRegisterMe.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCancel.FlatAppearance.BorderSize = 0
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdCancel.Location = New System.Drawing.Point(341, 423)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(142, 32)
        Me.cmdCancel.TabIndex = 64
        Me.cmdCancel.Text = "Not Now"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'ErrorProviderWarning
        '
        Me.ErrorProviderWarning.ContainerControl = Me
        Me.ErrorProviderWarning.Icon = CType(resources.GetObject("ErrorProviderWarning.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderError
        '
        Me.ErrorProviderError.ContainerControl = Me
        Me.ErrorProviderError.Icon = CType(resources.GetObject("ErrorProviderError.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderok
        '
        Me.ErrorProviderok.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderok.ContainerControl = Me
        Me.ErrorProviderok.Icon = CType(resources.GetObject("ErrorProviderok.Icon"), System.Drawing.Icon)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(18, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Password"
        '
        'txtPassWW
        '
        Me.txtPassWW.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPassWW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassWW.Location = New System.Drawing.Point(21, 73)
        Me.txtPassWW.Name = "txtPassWW"
        Me.txtPassWW.Size = New System.Drawing.Size(264, 20)
        Me.txtPassWW.TabIndex = 61
        Me.txtPassWW.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Employee ID"
        '
        'txtEmpID
        '
        Me.txtEmpID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtEmpID.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtEmpID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpID.Location = New System.Drawing.Point(21, 35)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Size = New System.Drawing.Size(264, 20)
        Me.txtEmpID.TabIndex = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(18, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Confirm Password"
        '
        'txtPasswordcnf
        '
        Me.txtPasswordcnf.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPasswordcnf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordcnf.Location = New System.Drawing.Point(21, 112)
        Me.txtPasswordcnf.Name = "txtPasswordcnf"
        Me.txtPasswordcnf.Size = New System.Drawing.Size(264, 20)
        Me.txtPasswordcnf.TabIndex = 63
        Me.txtPasswordcnf.UseSystemPasswordChar = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblID)
        Me.GroupBox2.Controls.Add(Me.txtsecans3)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmbquest3)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtsecans2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.cmbquest2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtsecans1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmbquest1)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtPasswordcnf)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtEmpID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPassWW)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(500, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 392)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login Details"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblID.Location = New System.Drawing.Point(248, 16)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(28, 13)
        Me.lblID.TabIndex = 82
        Me.lblID.Text = "lblID"
        Me.lblID.Visible = False
        '
        'txtsecans3
        '
        Me.txtsecans3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtsecans3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsecans3.Location = New System.Drawing.Point(24, 360)
        Me.txtsecans3.Name = "txtsecans3"
        Me.txtsecans3.Size = New System.Drawing.Size(264, 20)
        Me.txtsecans3.TabIndex = 81
        Me.txtsecans3.UseSystemPasswordChar = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(23, 302)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Secret Question-3"
        '
        'cmbquest3
        '
        Me.cmbquest3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbquest3.FormattingEnabled = True
        Me.cmbquest3.Location = New System.Drawing.Point(25, 320)
        Me.cmbquest3.Name = "cmbquest3"
        Me.cmbquest3.Size = New System.Drawing.Size(263, 21)
        Me.cmbquest3.TabIndex = 78
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.Location = New System.Drawing.Point(23, 344)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Answer"
        '
        'txtsecans2
        '
        Me.txtsecans2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtsecans2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsecans2.Location = New System.Drawing.Point(23, 277)
        Me.txtsecans2.Name = "txtsecans2"
        Me.txtsecans2.Size = New System.Drawing.Size(264, 20)
        Me.txtsecans2.TabIndex = 77
        Me.txtsecans2.UseSystemPasswordChar = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(22, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 13)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Secret Question-2"
        '
        'cmbquest2
        '
        Me.cmbquest2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbquest2.FormattingEnabled = True
        Me.cmbquest2.Location = New System.Drawing.Point(24, 237)
        Me.cmbquest2.Name = "cmbquest2"
        Me.cmbquest2.Size = New System.Drawing.Size(263, 21)
        Me.cmbquest2.TabIndex = 74
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(22, 261)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Answer"
        '
        'txtsecans1
        '
        Me.txtsecans1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtsecans1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsecans1.Location = New System.Drawing.Point(22, 195)
        Me.txtsecans1.Name = "txtsecans1"
        Me.txtsecans1.Size = New System.Drawing.Size(264, 20)
        Me.txtsecans1.TabIndex = 73
        Me.txtsecans1.UseSystemPasswordChar = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(21, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Secret Question-1"
        '
        'cmbquest1
        '
        Me.cmbquest1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbquest1.FormattingEnabled = True
        Me.cmbquest1.Location = New System.Drawing.Point(23, 155)
        Me.cmbquest1.Name = "cmbquest1"
        Me.cmbquest1.Size = New System.Drawing.Size(263, 21)
        Me.cmbquest1.TabIndex = 64
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(21, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Answer"
        '
        'ThinkLabel
        '
        Me.ThinkLabel.AutoSize = True
        Me.ThinkLabel.BackColor = System.Drawing.Color.Transparent
        Me.ThinkLabel.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold)
        Me.ThinkLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ThinkLabel.Location = New System.Drawing.Point(306, 9)
        Me.ThinkLabel.Name = "ThinkLabel"
        Me.ThinkLabel.Size = New System.Drawing.Size(232, 37)
        Me.ThinkLabel.TabIndex = 116
        Me.ThinkLabel.Text = "User Registration"
        '
        'Registration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ThinkProlite.My.Resources.Resources.MainBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.ThinkLabel)
        Me.Controls.Add(Me.cmdRegisterMe)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Registration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbProcess As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRegisterMe As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSubProcess As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProviderWarning As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderError As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderok As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordcnf As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEmpID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassWW As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsecans3 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbquest3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtsecans2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbquest2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtsecans1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbquest1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.Label
    Friend WithEvents ThinkLabel As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
