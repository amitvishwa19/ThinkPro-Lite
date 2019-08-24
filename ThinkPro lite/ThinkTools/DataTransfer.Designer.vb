<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTransfer
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
        Me.DataGridView = New ADGV.AdvancedDataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenDatabsePathOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TeamViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BreakLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusDatabasePath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FitColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenTransfer = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView
        '
        Me.DataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AutoGenerateContextFilters = True
        Me.DataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.DateWithTime = False
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.Size = New System.Drawing.Size(834, 416)
        Me.DataGridView.TabIndex = 147
        Me.DataGridView.TimeFilter = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.DataTransferToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 148
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DataTransferToolStripMenuItem
        '
        Me.DataTransferToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenDatabsePathOption, Me.TimeViewToolStripMenuItem, Me.TeamViewToolStripMenuItem, Me.BreakLogsToolStripMenuItem, Me.MenTransfer})
        Me.DataTransferToolStripMenuItem.Name = "DataTransferToolStripMenuItem"
        Me.DataTransferToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.DataTransferToolStripMenuItem.Text = "Data Transfer"
        '
        'MenDatabsePathOption
        '
        Me.MenDatabsePathOption.Name = "MenDatabsePathOption"
        Me.MenDatabsePathOption.Size = New System.Drawing.Size(152, 22)
        Me.MenDatabsePathOption.Text = "Database Path"
        '
        'TimeViewToolStripMenuItem
        '
        Me.TimeViewToolStripMenuItem.Name = "TimeViewToolStripMenuItem"
        Me.TimeViewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TimeViewToolStripMenuItem.Text = "TimeView"
        '
        'TeamViewToolStripMenuItem
        '
        Me.TeamViewToolStripMenuItem.Name = "TeamViewToolStripMenuItem"
        Me.TeamViewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TeamViewToolStripMenuItem.Text = "TeamView"
        '
        'BreakLogsToolStripMenuItem
        '
        Me.BreakLogsToolStripMenuItem.Name = "BreakLogsToolStripMenuItem"
        Me.BreakLogsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BreakLogsToolStripMenuItem.Text = "Break Logs"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusCount, Me.statusProgress, Me.StatusDatabasePath})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 149
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusCount
        '
        Me.StatusCount.BackColor = System.Drawing.Color.Transparent
        Me.StatusCount.Name = "StatusCount"
        Me.StatusCount.Size = New System.Drawing.Size(77, 17)
        Me.StatusCount.Text = "Total Items :-"
        '
        'statusProgress
        '
        Me.statusProgress.BackColor = System.Drawing.Color.Transparent
        Me.statusProgress.Name = "statusProgress"
        Me.statusProgress.Size = New System.Drawing.Size(85, 17)
        Me.statusProgress.Text = "Transferring : -"
        '
        'StatusDatabasePath
        '
        Me.StatusDatabasePath.BackColor = System.Drawing.Color.Transparent
        Me.StatusDatabasePath.Name = "StatusDatabasePath"
        Me.StatusDatabasePath.Size = New System.Drawing.Size(93, 17)
        Me.StatusDatabasePath.Text = "Database Path :-"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FitColumnsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'FitColumnsToolStripMenuItem
        '
        Me.FitColumnsToolStripMenuItem.Name = "FitColumnsToolStripMenuItem"
        Me.FitColumnsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FitColumnsToolStripMenuItem.Text = "Fit Columns"
        '
        'MenTransfer
        '
        Me.MenTransfer.Name = "MenTransfer"
        Me.MenTransfer.Size = New System.Drawing.Size(152, 22)
        Me.MenTransfer.Text = "Transfer"
        '
        'DataTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "DataTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Transfer"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView As ADGV.AdvancedDataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DataTransferToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenDatabsePathOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusDatabasePath As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimeViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeamViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BreakLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FitColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenTransfer As System.Windows.Forms.ToolStripMenuItem
End Class
