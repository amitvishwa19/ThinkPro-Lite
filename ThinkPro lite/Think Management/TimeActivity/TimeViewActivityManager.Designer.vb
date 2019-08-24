<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeViewActivityManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeViewActivityManager))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.TotalCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.transf = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ActivityManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddActivityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivityImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivityIimportTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadXlx = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportActivityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridActivity = New ADGV.AdvancedDataGridView()
        Me.TimeActMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivateActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.gridActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TimeActMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalCount, Me.transf})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'TotalCount
        '
        Me.TotalCount.BackColor = System.Drawing.Color.Transparent
        Me.TotalCount.Name = "TotalCount"
        Me.TotalCount.Size = New System.Drawing.Size(76, 17)
        Me.TotalCount.Text = "Total Count :"
        '
        'transf
        '
        Me.transf.BackColor = System.Drawing.Color.Transparent
        Me.transf.Name = "transf"
        Me.transf.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivityManagementToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'ActivityManagementToolStripMenuItem
        '
        Me.ActivityManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivityToolStripMenuItem, Me.ActivityImportToolStripMenuItem, Me.ExportActivityToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.ActivityManagementToolStripMenuItem.Name = "ActivityManagementToolStripMenuItem"
        Me.ActivityManagementToolStripMenuItem.Size = New System.Drawing.Size(133, 20)
        Me.ActivityManagementToolStripMenuItem.Text = "Activity Management"
        '
        'ActivityToolStripMenuItem
        '
        Me.ActivityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddActivityToolStripMenuItem1})
        Me.ActivityToolStripMenuItem.Name = "ActivityToolStripMenuItem"
        Me.ActivityToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ActivityToolStripMenuItem.Text = "Activity"
        '
        'AddActivityToolStripMenuItem1
        '
        Me.AddActivityToolStripMenuItem1.Name = "AddActivityToolStripMenuItem1"
        Me.AddActivityToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.AddActivityToolStripMenuItem1.Text = "Add Activity"
        '
        'ActivityImportToolStripMenuItem
        '
        Me.ActivityImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivityIimportTemplateToolStripMenuItem, Me.ImportToolStripMenuItem1, Me.UploadXlx})
        Me.ActivityImportToolStripMenuItem.Name = "ActivityImportToolStripMenuItem"
        Me.ActivityImportToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ActivityImportToolStripMenuItem.Text = "Activity Import"
        '
        'ActivityIimportTemplateToolStripMenuItem
        '
        Me.ActivityIimportTemplateToolStripMenuItem.Name = "ActivityIimportTemplateToolStripMenuItem"
        Me.ActivityIimportTemplateToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ActivityIimportTemplateToolStripMenuItem.Text = "Activity Import Template"
        '
        'ImportToolStripMenuItem1
        '
        Me.ImportToolStripMenuItem1.Name = "ImportToolStripMenuItem1"
        Me.ImportToolStripMenuItem1.Size = New System.Drawing.Size(206, 22)
        Me.ImportToolStripMenuItem1.Text = "Import "
        '
        'UploadXlx
        '
        Me.UploadXlx.Enabled = False
        Me.UploadXlx.Name = "UploadXlx"
        Me.UploadXlx.Size = New System.Drawing.Size(206, 22)
        Me.UploadXlx.Text = "Upload"
        '
        'ExportActivityToolStripMenuItem1
        '
        Me.ExportActivityToolStripMenuItem1.Name = "ExportActivityToolStripMenuItem1"
        Me.ExportActivityToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.ExportActivityToolStripMenuItem1.Text = "Export Activity"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'gridActivity
        '
        Me.gridActivity.AllowUserToAddRows = False
        Me.gridActivity.AllowUserToDeleteRows = False
        Me.gridActivity.AutoGenerateContextFilters = True
        Me.gridActivity.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridActivity.ContextMenuStrip = Me.TimeActMenu
        Me.gridActivity.DateWithTime = False
        Me.gridActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridActivity.Location = New System.Drawing.Point(0, 24)
        Me.gridActivity.Name = "gridActivity"
        Me.gridActivity.RowHeadersVisible = False
        Me.gridActivity.Size = New System.Drawing.Size(834, 416)
        Me.gridActivity.TabIndex = 149
        Me.gridActivity.TimeFilter = False
        '
        'TimeActMenu
        '
        Me.TimeActMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditActivityToolStripMenuItem, Me.ActivateActivityToolStripMenuItem, Me.DeleteActivityToolStripMenuItem})
        Me.TimeActMenu.Name = "CntxMenuTimeViewActivity"
        Me.TimeActMenu.Size = New System.Drawing.Size(173, 70)
        '
        'EditActivityToolStripMenuItem
        '
        Me.EditActivityToolStripMenuItem.Name = "EditActivityToolStripMenuItem"
        Me.EditActivityToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.EditActivityToolStripMenuItem.Text = "Edit Activity"
        '
        'ActivateActivityToolStripMenuItem
        '
        Me.ActivateActivityToolStripMenuItem.Name = "ActivateActivityToolStripMenuItem"
        Me.ActivateActivityToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ActivateActivityToolStripMenuItem.Text = "Activate Activity"
        '
        'DeleteActivityToolStripMenuItem
        '
        Me.DeleteActivityToolStripMenuItem.Name = "DeleteActivityToolStripMenuItem"
        Me.DeleteActivityToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.DeleteActivityToolStripMenuItem.Text = "Deactivate Activity"
        '
        'TimeViewActivityManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridActivity)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "TimeViewActivityManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimeView Activity Manager"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.gridActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimeActMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents gridActivity As ADGV.AdvancedDataGridView
    Friend WithEvents TimeActMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivateActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents transf As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ActivityManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddActivityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivityImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivityIimportTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportActivityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadXlx As System.Windows.Forms.ToolStripMenuItem
End Class
