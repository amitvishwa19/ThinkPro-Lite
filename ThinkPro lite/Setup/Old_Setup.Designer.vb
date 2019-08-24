<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Old_Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Old_Setup))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetConfigInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdConfigFile = New System.Windows.Forms.Button()
        Me.cmdSetDefault = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.cmdbrowse = New System.Windows.Forms.Button()
        Me.cmdTestConn = New System.Windows.Forms.Button()
        Me.cmbDBType = New System.Windows.Forms.ComboBox()
        Me.txtDatabasePassq = New System.Windows.Forms.Label()
        Me.w = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.q = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.a = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDatabasePass = New System.Windows.Forms.TextBox()
        Me.txtDatabaseID = New System.Windows.Forms.TextBox()
        Me.txtServerPort = New System.Windows.Forms.TextBox()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.txtServerAddress = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gridTable = New ADGV.AdvancedDataGridView()
        Me.DBTree = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLQueryWizardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AccessToPostgreSQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTDatabasePAth = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TeamViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BreakLockDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferData = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedDataGridView1 = New ADGV.AdvancedDataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Count = New System.Windows.Forms.ToolStripStatusLabel()
        Me.transf = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.AdvancedDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetConfigInfoToolStripMenuItem})
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.ConnectionToolStripMenuItem.Text = "Connection"
        '
        'GetConfigInfoToolStripMenuItem
        '
        Me.GetConfigInfoToolStripMenuItem.Name = "GetConfigInfoToolStripMenuItem"
        Me.GetConfigInfoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.GetConfigInfoToolStripMenuItem.Text = "Get Config Info"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdBack)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 411)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 51)
        Me.Panel1.TabIndex = 13
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Location = New System.Drawing.Point(489, 10)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(106, 29)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        Me.cmdCancel.Visible = False
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.Location = New System.Drawing.Point(606, 10)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(106, 29)
        Me.cmdBack.TabIndex = 10
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(721, 10)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(106, 29)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.Text = "Next"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 24)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(834, 387)
        Me.TabControl.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.cmdConfigFile)
        Me.TabPage1.Controls.Add(Me.cmdSetDefault)
        Me.TabPage1.Controls.Add(Me.lblError)
        Me.TabPage1.Controls.Add(Me.cmdbrowse)
        Me.TabPage1.Controls.Add(Me.cmdTestConn)
        Me.TabPage1.Controls.Add(Me.cmbDBType)
        Me.TabPage1.Controls.Add(Me.txtDatabasePassq)
        Me.TabPage1.Controls.Add(Me.w)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.q)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.a)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDatabasePass)
        Me.TabPage1.Controls.Add(Me.txtDatabaseID)
        Me.TabPage1.Controls.Add(Me.txtServerPort)
        Me.TabPage1.Controls.Add(Me.txtDatabaseName)
        Me.TabPage1.Controls.Add(Me.txtServerAddress)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(826, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Connection Setup"
        '
        'cmdConfigFile
        '
        Me.cmdConfigFile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdConfigFile.Location = New System.Drawing.Point(407, 280)
        Me.cmdConfigFile.Name = "cmdConfigFile"
        Me.cmdConfigFile.Size = New System.Drawing.Size(130, 29)
        Me.cmdConfigFile.TabIndex = 11
        Me.cmdConfigFile.Text = "Create Config File"
        Me.cmdConfigFile.UseVisualStyleBackColor = False
        Me.cmdConfigFile.Visible = False
        '
        'cmdSetDefault
        '
        Me.cmdSetDefault.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdSetDefault.Location = New System.Drawing.Point(271, 280)
        Me.cmdSetDefault.Name = "cmdSetDefault"
        Me.cmdSetDefault.Size = New System.Drawing.Size(130, 29)
        Me.cmdSetDefault.TabIndex = 10
        Me.cmdSetDefault.Text = "Set Default Connection"
        Me.cmdSetDefault.UseVisualStyleBackColor = False
        Me.cmdSetDefault.Visible = False
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Maroon
        Me.lblError.Location = New System.Drawing.Point(139, 326)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 13)
        Me.lblError.TabIndex = 9
        Me.lblError.Visible = False
        '
        'cmdbrowse
        '
        Me.cmdbrowse.Location = New System.Drawing.Point(687, 175)
        Me.cmdbrowse.Name = "cmdbrowse"
        Me.cmdbrowse.Size = New System.Drawing.Size(20, 21)
        Me.cmdbrowse.TabIndex = 4
        Me.cmdbrowse.Text = "..."
        Me.cmdbrowse.UseVisualStyleBackColor = True
        '
        'cmdTestConn
        '
        Me.cmdTestConn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdTestConn.Location = New System.Drawing.Point(139, 280)
        Me.cmdTestConn.Name = "cmdTestConn"
        Me.cmdTestConn.Size = New System.Drawing.Size(124, 29)
        Me.cmdTestConn.TabIndex = 8
        Me.cmdTestConn.Text = "Test Connection"
        Me.cmdTestConn.UseVisualStyleBackColor = False
        '
        'cmbDBType
        '
        Me.cmbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDBType.FormattingEnabled = True
        Me.cmbDBType.Items.AddRange(New Object() {"PostgreSQL", "Access Database"})
        Me.cmbDBType.Location = New System.Drawing.Point(139, 116)
        Me.cmbDBType.Name = "cmbDBType"
        Me.cmbDBType.Size = New System.Drawing.Size(538, 21)
        Me.cmbDBType.TabIndex = 1
        '
        'txtDatabasePassq
        '
        Me.txtDatabasePassq.AutoSize = True
        Me.txtDatabasePassq.Location = New System.Drawing.Point(28, 257)
        Me.txtDatabasePassq.Name = "txtDatabasePassq"
        Me.txtDatabasePassq.Size = New System.Drawing.Size(102, 13)
        Me.txtDatabasePassq.TabIndex = 6
        Me.txtDatabasePassq.Text = "Database Password"
        '
        'w
        '
        Me.w.AutoSize = True
        Me.w.Location = New System.Drawing.Point(28, 231)
        Me.w.Name = "w"
        Me.w.Size = New System.Drawing.Size(67, 13)
        Me.w.TabIndex = 6
        Me.w.Text = "Database ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(267, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(242, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "ThinkPro Setup Manager"
        '
        'q
        '
        Me.q.AutoSize = True
        Me.q.Location = New System.Drawing.Point(28, 205)
        Me.q.Name = "q"
        Me.q.Size = New System.Drawing.Size(60, 13)
        Me.q.TabIndex = 6
        Me.q.Text = "Server Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Database Name"
        '
        'a
        '
        Me.a.AutoSize = True
        Me.a.Location = New System.Drawing.Point(28, 179)
        Me.a.Name = "a"
        Me.a.Size = New System.Drawing.Size(79, 13)
        Me.a.TabIndex = 6
        Me.a.Text = "Server Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Database Type"
        '
        'txtDatabasePass
        '
        Me.txtDatabasePass.Location = New System.Drawing.Point(139, 254)
        Me.txtDatabasePass.Name = "txtDatabasePass"
        Me.txtDatabasePass.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabasePass.TabIndex = 7
        Me.txtDatabasePass.UseSystemPasswordChar = True
        '
        'txtDatabaseID
        '
        Me.txtDatabaseID.Location = New System.Drawing.Point(139, 228)
        Me.txtDatabaseID.Name = "txtDatabaseID"
        Me.txtDatabaseID.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabaseID.TabIndex = 6
        '
        'txtServerPort
        '
        Me.txtServerPort.Location = New System.Drawing.Point(139, 202)
        Me.txtServerPort.Name = "txtServerPort"
        Me.txtServerPort.Size = New System.Drawing.Size(262, 20)
        Me.txtServerPort.TabIndex = 5
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(139, 146)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(262, 20)
        Me.txtDatabaseName.TabIndex = 2
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(139, 176)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(262, 20)
        Me.txtServerAddress.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.gridTable)
        Me.TabPage2.Controls.Add(Me.DBTree)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(826, 358)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Database Setup"
        '
        'gridTable
        '
        Me.gridTable.AllowUserToAddRows = False
        Me.gridTable.AllowUserToDeleteRows = False
        Me.gridTable.AutoGenerateContextFilters = True
        Me.gridTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridTable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTable.DateWithTime = False
        Me.gridTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridTable.Location = New System.Drawing.Point(227, 3)
        Me.gridTable.Name = "gridTable"
        Me.gridTable.RowHeadersVisible = False
        Me.gridTable.Size = New System.Drawing.Size(594, 350)
        Me.gridTable.TabIndex = 147
        Me.gridTable.TimeFilter = False
        '
        'DBTree
        '
        Me.DBTree.BackColor = System.Drawing.SystemColors.Menu
        Me.DBTree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBTree.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DBTree.Dock = System.Windows.Forms.DockStyle.Left
        Me.DBTree.Location = New System.Drawing.Point(3, 3)
        Me.DBTree.Name = "DBTree"
        Me.DBTree.Size = New System.Drawing.Size(224, 350)
        Me.DBTree.TabIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddTableToolStripMenuItem, Me.DeleteTableToolStripMenuItem, Me.AddColumnToolStripMenuItem, Me.DeleteColumnToolStripMenuItem, Me.SQLQueryWizardToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(170, 114)
        '
        'AddTableToolStripMenuItem
        '
        Me.AddTableToolStripMenuItem.Name = "AddTableToolStripMenuItem"
        Me.AddTableToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AddTableToolStripMenuItem.Text = "Add Table"
        '
        'DeleteTableToolStripMenuItem
        '
        Me.DeleteTableToolStripMenuItem.Name = "DeleteTableToolStripMenuItem"
        Me.DeleteTableToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DeleteTableToolStripMenuItem.Text = "Delete Table"
        '
        'AddColumnToolStripMenuItem
        '
        Me.AddColumnToolStripMenuItem.Name = "AddColumnToolStripMenuItem"
        Me.AddColumnToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AddColumnToolStripMenuItem.Text = "Add Column"
        '
        'DeleteColumnToolStripMenuItem
        '
        Me.DeleteColumnToolStripMenuItem.Name = "DeleteColumnToolStripMenuItem"
        Me.DeleteColumnToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DeleteColumnToolStripMenuItem.Text = "Delete Column"
        '
        'SQLQueryWizardToolStripMenuItem
        '
        Me.SQLQueryWizardToolStripMenuItem.Name = "SQLQueryWizardToolStripMenuItem"
        Me.SQLQueryWizardToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SQLQueryWizardToolStripMenuItem.Text = "SQL Query Wizard"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.ContextMenuStrip = Me.ContextMenuStrip2
        Me.TabPage3.Controls.Add(Me.AdvancedDataGridView1)
        Me.TabPage3.Controls.Add(Me.StatusStrip1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(826, 358)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "DB Transfer"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccessToPostgreSQLToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(189, 26)
        '
        'AccessToPostgreSQLToolStripMenuItem
        '
        Me.AccessToPostgreSQLToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DTDatabasePAth, Me.TimeViewToolStripMenuItem, Me.TeamViewToolStripMenuItem, Me.BreakLockDetailsToolStripMenuItem, Me.TransferData})
        Me.AccessToPostgreSQLToolStripMenuItem.Name = "AccessToPostgreSQLToolStripMenuItem"
        Me.AccessToPostgreSQLToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.AccessToPostgreSQLToolStripMenuItem.Text = "Access to PostgreSQL"
        '
        'DTDatabasePAth
        '
        Me.DTDatabasePAth.Name = "DTDatabasePAth"
        Me.DTDatabasePAth.Size = New System.Drawing.Size(171, 22)
        Me.DTDatabasePAth.Text = "DatabasePath"
        '
        'TimeViewToolStripMenuItem
        '
        Me.TimeViewToolStripMenuItem.Name = "TimeViewToolStripMenuItem"
        Me.TimeViewToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.TimeViewToolStripMenuItem.Text = "Time View"
        '
        'TeamViewToolStripMenuItem
        '
        Me.TeamViewToolStripMenuItem.Name = "TeamViewToolStripMenuItem"
        Me.TeamViewToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.TeamViewToolStripMenuItem.Text = "Team View"
        '
        'BreakLockDetailsToolStripMenuItem
        '
        Me.BreakLockDetailsToolStripMenuItem.Name = "BreakLockDetailsToolStripMenuItem"
        Me.BreakLockDetailsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.BreakLockDetailsToolStripMenuItem.Text = "Break/Lock Details"
        '
        'TransferData
        '
        Me.TransferData.Name = "TransferData"
        Me.TransferData.Size = New System.Drawing.Size(171, 22)
        Me.TransferData.Text = "Transfer Data"
        '
        'AdvancedDataGridView1
        '
        Me.AdvancedDataGridView1.AllowUserToAddRows = False
        Me.AdvancedDataGridView1.AllowUserToDeleteRows = False
        Me.AdvancedDataGridView1.AutoGenerateContextFilters = True
        Me.AdvancedDataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.AdvancedDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AdvancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdvancedDataGridView1.DateWithTime = False
        Me.AdvancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedDataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.AdvancedDataGridView1.Name = "AdvancedDataGridView1"
        Me.AdvancedDataGridView1.RowHeadersVisible = False
        Me.AdvancedDataGridView1.Size = New System.Drawing.Size(824, 334)
        Me.AdvancedDataGridView1.TabIndex = 150
        Me.AdvancedDataGridView1.TimeFilter = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Count, Me.transf})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 334)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(824, 22)
        Me.StatusStrip1.TabIndex = 149
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Count
        '
        Me.Count.BackColor = System.Drawing.Color.Transparent
        Me.Count.Name = "Count"
        Me.Count.Size = New System.Drawing.Size(72, 17)
        Me.Count.Text = "Total Items :"
        '
        'transf
        '
        Me.transf.BackColor = System.Drawing.Color.Transparent
        Me.transf.Name = "transf"
        Me.transf.Size = New System.Drawing.Size(83, 17)
        Me.transf.Text = "Transferring :  "
        '
        'Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Setup Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gridTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.AdvancedDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdbrowse As System.Windows.Forms.Button
    Friend WithEvents cmdTestConn As System.Windows.Forms.Button
    Friend WithEvents cmbDBType As System.Windows.Forms.ComboBox
    Friend WithEvents txtDatabasePassq As System.Windows.Forms.Label
    Friend WithEvents w As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents q As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents a As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDatabasePass As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseID As System.Windows.Forms.TextBox
    Friend WithEvents txtServerPort As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents txtServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DBTree As System.Windows.Forms.TreeView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents gridTable As ADGV.AdvancedDataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQLQueryWizardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GetConfigInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSetDefault As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AccessToPostgreSQLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeamViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BreakLockDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTDatabasePAth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancedDataGridView1 As ADGV.AdvancedDataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Count As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents transf As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdConfigFile As System.Windows.Forms.Button
End Class
