<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MapApplications
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AddNewApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.app_list_box = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_sync_now = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewApplicationToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'AddNewApplicationToolStripMenuItem
        '
        Me.AddNewApplicationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.ImportApplicationToolStripMenuItem})
        Me.AddNewApplicationToolStripMenuItem.Name = "AddNewApplicationToolStripMenuItem"
        Me.AddNewApplicationToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.AddNewApplicationToolStripMenuItem.Text = "Applications"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AddNewToolStripMenuItem.Text = "Add New"
        '
        'ImportApplicationToolStripMenuItem
        '
        Me.ImportApplicationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportTemplateToolStripMenuItem, Me.ImportToolStripMenuItem})
        Me.ImportApplicationToolStripMenuItem.Name = "ImportApplicationToolStripMenuItem"
        Me.ImportApplicationToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ImportApplicationToolStripMenuItem.Text = "Import Applications"
        '
        'ImportTemplateToolStripMenuItem
        '
        Me.ImportTemplateToolStripMenuItem.Name = "ImportTemplateToolStripMenuItem"
        Me.ImportTemplateToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ImportTemplateToolStripMenuItem.Text = "Import Template"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'app_list_box
        '
        Me.app_list_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.app_list_box.ContextMenuStrip = Me.ContextMenuStrip1
        Me.app_list_box.Dock = System.Windows.Forms.DockStyle.Top
        Me.app_list_box.FormattingEnabled = True
        Me.app_list_box.Location = New System.Drawing.Point(0, 0)
        Me.app_list_box.Name = "app_list_box"
        Me.app_list_box.Size = New System.Drawing.Size(298, 362)
        Me.app_list_box.TabIndex = 17
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditApplicationToolStripMenuItem, Me.DeleteApplicationToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'EditApplicationToolStripMenuItem
        '
        Me.EditApplicationToolStripMenuItem.Name = "EditApplicationToolStripMenuItem"
        Me.EditApplicationToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditApplicationToolStripMenuItem.Text = "Edit"
        '
        'DeleteApplicationToolStripMenuItem
        '
        Me.DeleteApplicationToolStripMenuItem.Name = "DeleteApplicationToolStripMenuItem"
        Me.DeleteApplicationToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteApplicationToolStripMenuItem.Text = "Delete"
        '
        'cmd_sync_now
        '
        Me.cmd_sync_now.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmd_sync_now.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_sync_now.ForeColor = System.Drawing.Color.Black
        Me.cmd_sync_now.Location = New System.Drawing.Point(0, 360)
        Me.cmd_sync_now.Name = "cmd_sync_now"
        Me.cmd_sync_now.Size = New System.Drawing.Size(298, 47)
        Me.cmd_sync_now.TabIndex = 21
        Me.cmd_sync_now.Text = "Sync Now"
        Me.cmd_sync_now.UseVisualStyleBackColor = True
        '
        'MapApplications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(298, 407)
        Me.Controls.Add(Me.cmd_sync_now)
        Me.Controls.Add(Me.app_list_box)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MapApplications"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Application to map to your process"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents app_list_box As CheckedListBox
    Friend WithEvents AddNewApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteApplicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmd_sync_now As Button
End Class
