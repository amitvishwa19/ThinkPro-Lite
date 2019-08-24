<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Old_ThinkSetup
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Database Connection")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Database Tables")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Create DB Table")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("App Forms")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("App Task manager")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Project Details")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Old_ThinkSetup))
        Me.Tables = New System.Windows.Forms.TabPage()
        Me.tablelist = New System.Windows.Forms.ListBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.cmdSetDefault = New System.Windows.Forms.Button()
        Me.cmdTestConn = New System.Windows.Forms.Button()
        Me.Connection = New System.Windows.Forms.TabPage()
        Me.cmdCreateConf = New System.Windows.Forms.Button()
        Me.txtDatabasePass = New System.Windows.Forms.TextBox()
        Me.txtDatabaseID = New System.Windows.Forms.TextBox()
        Me.txtServerPort = New System.Windows.Forms.TextBox()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.browse = New System.Windows.Forms.Button()
        Me.txtconfpath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.Dashboard = New System.Windows.Forms.TabPage()
        Me.btnKill = New System.Windows.Forms.Button()
        Me.btnUpdateProcessList = New System.Windows.Forms.Button()
        Me.lblRAM = New System.Windows.Forms.Label()
        Me.lblCPU = New System.Windows.Forms.Label()
        Me.pbRAM = New System.Windows.Forms.ProgressBar()
        Me.pbCPU = New System.Windows.Forms.ProgressBar()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lstProcesses = New System.Windows.Forms.ListBox()
        Me.PannelSide = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblDatabasename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblServerAddress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblServerPort = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDatabaseid = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslProcessCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pcRAM = New System.Diagnostics.PerformanceCounter()
        Me.pcCPU = New System.Diagnostics.PerformanceCounter()
        Me.HelpProvider2 = New System.Windows.Forms.HelpProvider()
        Me.PerformanceTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TotalRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateDefaultSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tables.SuspendLayout()
        Me.Connection.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.Dashboard.SuspendLayout()
        Me.PannelSide.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.pcRAM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tables
        '
        Me.Tables.Controls.Add(Me.tablelist)
        Me.Tables.Controls.Add(Me.lblError)
        Me.Tables.Location = New System.Drawing.Point(4, 4)
        Me.Tables.Name = "Tables"
        Me.Tables.Padding = New System.Windows.Forms.Padding(3)
        Me.Tables.Size = New System.Drawing.Size(506, 349)
        Me.Tables.TabIndex = 1
        Me.Tables.Text = "DB Tables"
        Me.Tables.UseVisualStyleBackColor = True
        '
        'tablelist
        '
        Me.tablelist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablelist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablelist.FormattingEnabled = True
        Me.tablelist.Location = New System.Drawing.Point(3, 3)
        Me.tablelist.Name = "tablelist"
        Me.tablelist.Size = New System.Drawing.Size(500, 343)
        Me.tablelist.TabIndex = 23
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Maroon
        Me.lblError.Location = New System.Drawing.Point(136, 252)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 13)
        Me.lblError.TabIndex = 22
        Me.lblError.Visible = False
        '
        'cmdSetDefault
        '
        Me.cmdSetDefault.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdSetDefault.Location = New System.Drawing.Point(374, 189)
        Me.cmdSetDefault.Name = "cmdSetDefault"
        Me.cmdSetDefault.Size = New System.Drawing.Size(124, 25)
        Me.cmdSetDefault.TabIndex = 23
        Me.cmdSetDefault.Text = "Set Default"
        Me.cmdSetDefault.UseVisualStyleBackColor = False
        Me.cmdSetDefault.Visible = False
        '
        'cmdTestConn
        '
        Me.cmdTestConn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdTestConn.Location = New System.Drawing.Point(374, 158)
        Me.cmdTestConn.Name = "cmdTestConn"
        Me.cmdTestConn.Size = New System.Drawing.Size(124, 25)
        Me.cmdTestConn.TabIndex = 19
        Me.cmdTestConn.Text = "Test Connection"
        Me.cmdTestConn.UseVisualStyleBackColor = False
        '
        'Connection
        '
        Me.Connection.Controls.Add(Me.cmdCreateConf)
        Me.Connection.Controls.Add(Me.cmdSetDefault)
        Me.Connection.Controls.Add(Me.txtDatabasePass)
        Me.Connection.Controls.Add(Me.txtDatabaseID)
        Me.Connection.Controls.Add(Me.txtServerPort)
        Me.Connection.Controls.Add(Me.cmdTestConn)
        Me.Connection.Controls.Add(Me.txtDatabaseName)
        Me.Connection.Controls.Add(Me.txtServerAddress)
        Me.Connection.Controls.Add(Me.Label8)
        Me.Connection.Controls.Add(Me.Label9)
        Me.Connection.Controls.Add(Me.Label10)
        Me.Connection.Controls.Add(Me.Label11)
        Me.Connection.Controls.Add(Me.Label12)
        Me.Connection.Controls.Add(Me.Label7)
        Me.Connection.Controls.Add(Me.browse)
        Me.Connection.Controls.Add(Me.txtconfpath)
        Me.Connection.Controls.Add(Me.Label5)
        Me.Connection.Controls.Add(Me.RadioButton2)
        Me.Connection.Controls.Add(Me.RadioButton1)
        Me.Connection.Location = New System.Drawing.Point(4, 4)
        Me.Connection.Name = "Connection"
        Me.Connection.Padding = New System.Windows.Forms.Padding(3)
        Me.Connection.Size = New System.Drawing.Size(506, 349)
        Me.Connection.TabIndex = 0
        Me.Connection.Text = "DB Conn"
        Me.Connection.UseVisualStyleBackColor = True
        '
        'cmdCreateConf
        '
        Me.cmdCreateConf.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdCreateConf.Location = New System.Drawing.Point(374, 220)
        Me.cmdCreateConf.Name = "cmdCreateConf"
        Me.cmdCreateConf.Size = New System.Drawing.Size(124, 25)
        Me.cmdCreateConf.TabIndex = 31
        Me.cmdCreateConf.Text = "Create Conf. File"
        Me.cmdCreateConf.UseVisualStyleBackColor = False
        Me.cmdCreateConf.Visible = False
        '
        'txtDatabasePass
        '
        Me.txtDatabasePass.Enabled = False
        Me.txtDatabasePass.Location = New System.Drawing.Point(135, 267)
        Me.txtDatabasePass.Name = "txtDatabasePass"
        Me.txtDatabasePass.Size = New System.Drawing.Size(233, 20)
        Me.txtDatabasePass.TabIndex = 30
        Me.txtDatabasePass.UseSystemPasswordChar = True
        '
        'txtDatabaseID
        '
        Me.txtDatabaseID.Enabled = False
        Me.txtDatabaseID.Location = New System.Drawing.Point(135, 241)
        Me.txtDatabaseID.Name = "txtDatabaseID"
        Me.txtDatabaseID.Size = New System.Drawing.Size(233, 20)
        Me.txtDatabaseID.TabIndex = 29
        '
        'txtServerPort
        '
        Me.txtServerPort.Enabled = False
        Me.txtServerPort.Location = New System.Drawing.Point(135, 215)
        Me.txtServerPort.Name = "txtServerPort"
        Me.txtServerPort.Size = New System.Drawing.Size(233, 20)
        Me.txtServerPort.TabIndex = 28
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Enabled = False
        Me.txtDatabaseName.Location = New System.Drawing.Point(135, 159)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(233, 20)
        Me.txtDatabaseName.TabIndex = 26
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Enabled = False
        Me.txtServerAddress.Location = New System.Drawing.Point(135, 189)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(233, 20)
        Me.txtServerAddress.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Database Password"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Database ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Server Port"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Database Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Server Address"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(175, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Or"
        '
        'browse
        '
        Me.browse.Enabled = False
        Me.browse.Location = New System.Drawing.Point(326, 72)
        Me.browse.Name = "browse"
        Me.browse.Size = New System.Drawing.Size(65, 21)
        Me.browse.TabIndex = 14
        Me.browse.Text = "Browse"
        Me.browse.UseVisualStyleBackColor = True
        '
        'txtconfpath
        '
        Me.txtconfpath.Enabled = False
        Me.txtconfpath.Location = New System.Drawing.Point(39, 73)
        Me.txtconfpath.Name = "txtconfpath"
        Me.txtconfpath.Size = New System.Drawing.Size(281, 20)
        Me.txtconfpath.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(402, 35)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Create new Configuration file or connect with existing configuration file"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(19, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(214, 17)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.Text = "Connect With existing configuration File "
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(18, 126)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(162, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.Text = "Create new configuration  file"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl.Controls.Add(Me.Tables)
        Me.TabControl.Controls.Add(Me.Connection)
        Me.TabControl.Controls.Add(Me.Dashboard)
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Location = New System.Drawing.Point(160, 0)
        Me.TabControl.Multiline = True
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(514, 375)
        Me.TabControl.TabIndex = 2
        '
        'Dashboard
        '
        Me.Dashboard.Controls.Add(Me.btnKill)
        Me.Dashboard.Controls.Add(Me.btnUpdateProcessList)
        Me.Dashboard.Controls.Add(Me.lblRAM)
        Me.Dashboard.Controls.Add(Me.lblCPU)
        Me.Dashboard.Controls.Add(Me.pbRAM)
        Me.Dashboard.Controls.Add(Me.pbCPU)
        Me.Dashboard.Controls.Add(Me.Label39)
        Me.Dashboard.Controls.Add(Me.lstProcesses)
        Me.Dashboard.Location = New System.Drawing.Point(4, 4)
        Me.Dashboard.Name = "Dashboard"
        Me.Dashboard.Padding = New System.Windows.Forms.Padding(3)
        Me.Dashboard.Size = New System.Drawing.Size(506, 349)
        Me.Dashboard.TabIndex = 2
        Me.Dashboard.Text = "Application Dashboard"
        Me.Dashboard.UseVisualStyleBackColor = True
        '
        'btnKill
        '
        Me.btnKill.Location = New System.Drawing.Point(404, 53)
        Me.btnKill.Name = "btnKill"
        Me.btnKill.Size = New System.Drawing.Size(75, 23)
        Me.btnKill.TabIndex = 134
        Me.btnKill.Text = "Kill"
        Me.btnKill.UseVisualStyleBackColor = True
        '
        'btnUpdateProcessList
        '
        Me.btnUpdateProcessList.Location = New System.Drawing.Point(404, 24)
        Me.btnUpdateProcessList.Name = "btnUpdateProcessList"
        Me.btnUpdateProcessList.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateProcessList.TabIndex = 133
        Me.btnUpdateProcessList.Text = "Update"
        Me.btnUpdateProcessList.UseVisualStyleBackColor = True
        '
        'lblRAM
        '
        Me.lblRAM.AutoSize = True
        Me.lblRAM.Location = New System.Drawing.Point(12, 313)
        Me.lblRAM.Name = "lblRAM"
        Me.lblRAM.Size = New System.Drawing.Size(39, 13)
        Me.lblRAM.TabIndex = 132
        Me.lblRAM.Text = "Label9"
        '
        'lblCPU
        '
        Me.lblCPU.AutoSize = True
        Me.lblCPU.Location = New System.Drawing.Point(12, 284)
        Me.lblCPU.Name = "lblCPU"
        Me.lblCPU.Size = New System.Drawing.Size(39, 13)
        Me.lblCPU.TabIndex = 131
        Me.lblCPU.Text = "Label8"
        '
        'pbRAM
        '
        Me.pbRAM.Location = New System.Drawing.Point(15, 329)
        Me.pbRAM.Name = "pbRAM"
        Me.pbRAM.Size = New System.Drawing.Size(475, 11)
        Me.pbRAM.TabIndex = 130
        '
        'pbCPU
        '
        Me.pbCPU.Location = New System.Drawing.Point(15, 300)
        Me.pbCPU.Name = "pbCPU"
        Me.pbCPU.Size = New System.Drawing.Size(475, 10)
        Me.pbCPU.TabIndex = 129
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label39.Location = New System.Drawing.Point(12, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(107, 13)
        Me.Label39.TabIndex = 128
        Me.Label39.Text = "Running Applications"
        '
        'lstProcesses
        '
        Me.lstProcesses.FormattingEnabled = True
        Me.lstProcesses.Location = New System.Drawing.Point(15, 24)
        Me.lstProcesses.Name = "lstProcesses"
        Me.lstProcesses.Size = New System.Drawing.Size(383, 251)
        Me.lstProcesses.TabIndex = 127
        '
        'PannelSide
        '
        Me.PannelSide.Controls.Add(Me.TreeView1)
        Me.PannelSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.PannelSide.Location = New System.Drawing.Point(0, 0)
        Me.PannelSide.Name = "PannelSide"
        Me.PannelSide.Size = New System.Drawing.Size(160, 353)
        Me.PannelSide.TabIndex = 6
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ItemHeight = 20
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Database Connection"
        TreeNode2.Name = "Node1"
        TreeNode2.Text = "Database Tables"
        TreeNode3.Name = "Node2"
        TreeNode3.Text = "Create DB Table"
        TreeNode4.Name = "Node3"
        TreeNode4.Text = "App Forms"
        TreeNode5.Name = "Node4"
        TreeNode5.Text = "App Task manager"
        TreeNode6.Name = "Node0"
        TreeNode6.Text = "Project Details"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Me.TreeView1.Size = New System.Drawing.Size(160, 353)
        Me.TreeView1.TabIndex = 15
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDatabasename, Me.lblServerAddress, Me.lblServerPort, Me.lblDatabaseid, Me.tslProcessCount})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 353)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(674, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'lblDatabasename
        '
        Me.lblDatabasename.BackColor = System.Drawing.Color.Transparent
        Me.lblDatabasename.Name = "lblDatabasename"
        Me.lblDatabasename.Size = New System.Drawing.Size(98, 17)
        Me.lblDatabasename.Text = "Database Name:-"
        '
        'lblServerAddress
        '
        Me.lblServerAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(95, 17)
        Me.lblServerAddress.Text = "Server Address :-"
        '
        'lblServerPort
        '
        Me.lblServerPort.BackColor = System.Drawing.Color.Transparent
        Me.lblServerPort.Name = "lblServerPort"
        Me.lblServerPort.Size = New System.Drawing.Size(78, 17)
        Me.lblServerPort.Text = "Server Port :- "
        '
        'lblDatabaseid
        '
        Me.lblDatabaseid.BackColor = System.Drawing.Color.Transparent
        Me.lblDatabaseid.Name = "lblDatabaseid"
        Me.lblDatabaseid.Size = New System.Drawing.Size(80, 17)
        Me.lblDatabaseid.Text = "Database ID :-"
        '
        'tslProcessCount
        '
        Me.tslProcessCount.BackColor = System.Drawing.Color.Transparent
        Me.tslProcessCount.Name = "tslProcessCount"
        Me.tslProcessCount.Size = New System.Drawing.Size(80, 17)
        Me.tslProcessCount.Text = "ProcessCount"
        '
        'pcRAM
        '
        Me.pcRAM.CategoryName = "Thread"
        Me.pcRAM.CounterName = "% Processor Time"
        Me.pcRAM.InstanceName = "Idle/0"
        '
        'pcCPU
        '
        Me.pcCPU.CategoryName = "Thread"
        Me.pcCPU.CounterName = "% Processor Time"
        Me.pcCPU.InstanceName = "Idle/0"
        '
        'PerformanceTimer
        '
        Me.PerformanceTimer.Interval = 1000
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(506, 349)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "ListView"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView
        '
        Me.ListView.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.Location = New System.Drawing.Point(3, 3)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(500, 343)
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRowsToolStripMenuItem, Me.UpdateDefaultSettingToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(194, 70)
        '
        'TotalRowsToolStripMenuItem
        '
        Me.TotalRowsToolStripMenuItem.Name = "TotalRowsToolStripMenuItem"
        Me.TotalRowsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.TotalRowsToolStripMenuItem.Text = "Total Rows"
        '
        'UpdateDefaultSettingToolStripMenuItem
        '
        Me.UpdateDefaultSettingToolStripMenuItem.Name = "UpdateDefaultSettingToolStripMenuItem"
        Me.UpdateDefaultSettingToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.UpdateDefaultSettingToolStripMenuItem.Text = "Update Default Setting"
        '
        'Old_ThinkSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(674, 375)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.PannelSide)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Old_ThinkSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThinkPro Setup"
        Me.Tables.ResumeLayout(False)
        Me.Tables.PerformLayout()
        Me.Connection.ResumeLayout(False)
        Me.Connection.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.Dashboard.ResumeLayout(False)
        Me.Dashboard.PerformLayout()
        Me.PannelSide.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.pcRAM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcCPU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tables As System.Windows.Forms.TabPage
    Friend WithEvents cmdSetDefault As System.Windows.Forms.Button
    Friend WithEvents cmdTestConn As System.Windows.Forms.Button
    Friend WithEvents Connection As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents browse As Button
    Friend WithEvents txtconfpath As TextBox
    Friend WithEvents txtDatabasePass As TextBox
    Friend WithEvents txtDatabaseID As TextBox
    Friend WithEvents txtServerPort As TextBox
    Friend WithEvents txtDatabaseName As TextBox
    Friend WithEvents txtServerAddress As TextBox
    Friend WithEvents tablelist As ListBox
    Friend WithEvents PannelSide As System.Windows.Forms.Panel
    Friend WithEvents cmdCreateConf As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lblDatabasename As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblServerAddress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblServerPort As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDatabaseid As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Dashboard As System.Windows.Forms.TabPage
    Private WithEvents Label39 As System.Windows.Forms.Label
    Private WithEvents lstProcesses As System.Windows.Forms.ListBox
    Friend WithEvents lblRAM As System.Windows.Forms.Label
    Friend WithEvents lblCPU As System.Windows.Forms.Label
    Friend WithEvents pbRAM As System.Windows.Forms.ProgressBar
    Friend WithEvents pbCPU As System.Windows.Forms.ProgressBar
    Friend WithEvents pcRAM As System.Diagnostics.PerformanceCounter
    Friend WithEvents pcCPU As System.Diagnostics.PerformanceCounter
    Friend WithEvents HelpProvider2 As System.Windows.Forms.HelpProvider
    Friend WithEvents PerformanceTimer As System.Windows.Forms.Timer
    Friend WithEvents tslProcessCount As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents btnKill As System.Windows.Forms.Button
    Private WithEvents btnUpdateProcessList As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TotalRowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateDefaultSettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
