<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThinkProPoll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ThinkProPoll))
        Me.SSThinkPoll = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThinkPollgrid = New ADGV.AdvancedDataGridView()
        Me.PollMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreatePollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadPollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivatePollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeativatePollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ThinkPollgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PollMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSThinkPoll
        '
        Me.SSThinkPoll.Location = New System.Drawing.Point(0, 440)
        Me.SSThinkPoll.Name = "SSThinkPoll"
        Me.SSThinkPoll.Size = New System.Drawing.Size(834, 22)
        Me.SSThinkPoll.TabIndex = 152
        Me.SSThinkPoll.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 153
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ThinkPollgrid
        '
        Me.ThinkPollgrid.AllowUserToAddRows = False
        Me.ThinkPollgrid.AllowUserToDeleteRows = False
        Me.ThinkPollgrid.AutoGenerateContextFilters = True
        Me.ThinkPollgrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ThinkPollgrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ThinkPollgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ThinkPollgrid.ContextMenuStrip = Me.PollMenu
        Me.ThinkPollgrid.DateWithTime = False
        Me.ThinkPollgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThinkPollgrid.Location = New System.Drawing.Point(0, 24)
        Me.ThinkPollgrid.Name = "ThinkPollgrid"
        Me.ThinkPollgrid.RowHeadersVisible = False
        Me.ThinkPollgrid.Size = New System.Drawing.Size(834, 416)
        Me.ThinkPollgrid.TabIndex = 154
        Me.ThinkPollgrid.TimeFilter = False
        '
        'PollMenu
        '
        Me.PollMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreatePollToolStripMenuItem, Me.DeletePollToolStripMenuItem, Me.ReloadPollToolStripMenuItem, Me.ActivatePollToolStripMenuItem, Me.DeativatePollToolStripMenuItem})
        Me.PollMenu.Name = "PollMenu"
        Me.PollMenu.Size = New System.Drawing.Size(136, 114)
        '
        'CreatePollToolStripMenuItem
        '
        Me.CreatePollToolStripMenuItem.Name = "CreatePollToolStripMenuItem"
        Me.CreatePollToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CreatePollToolStripMenuItem.Text = "Create New"
        '
        'DeletePollToolStripMenuItem
        '
        Me.DeletePollToolStripMenuItem.Name = "DeletePollToolStripMenuItem"
        Me.DeletePollToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeletePollToolStripMenuItem.Text = "Delete"
        '
        'ReloadPollToolStripMenuItem
        '
        Me.ReloadPollToolStripMenuItem.Name = "ReloadPollToolStripMenuItem"
        Me.ReloadPollToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ReloadPollToolStripMenuItem.Text = "Clone Poll"
        '
        'ActivatePollToolStripMenuItem
        '
        Me.ActivatePollToolStripMenuItem.Name = "ActivatePollToolStripMenuItem"
        Me.ActivatePollToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ActivatePollToolStripMenuItem.Text = "Activate"
        '
        'DeativatePollToolStripMenuItem
        '
        Me.DeativatePollToolStripMenuItem.Name = "DeativatePollToolStripMenuItem"
        Me.DeativatePollToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeativatePollToolStripMenuItem.Text = "Deactivate"
        '
        'ThinkProPoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.ThinkPollgrid)
        Me.Controls.Add(Me.SSThinkPoll)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ThinkProPoll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Think Poll"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ThinkPollgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PollMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SSThinkPoll As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThinkPollgrid As ADGV.AdvancedDataGridView
    Friend WithEvents PollMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CreatePollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletePollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadPollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivatePollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeativatePollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
