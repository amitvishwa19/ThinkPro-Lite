<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterUpdate))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadDataToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadTemplateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridMasterUpdate = New ADGV.AdvancedDataGridView()
        Me.MasterUpdMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteActivityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllDataToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTotalMin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalVol = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSMasterUpdate = New System.Windows.Forms.StatusStrip()
        Me.UploadStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridMasterUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MasterUpdMenu.SuspendLayout()
        Me.SSMasterUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterUpdateToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterUpdateToolStripMenuItem
        '
        Me.MasterUpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddTimeToolStripMenuItem, Me.ExportGridToolStripMenuItem, Me.UploadDataToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.MasterUpdateToolStripMenuItem.Name = "MasterUpdateToolStripMenuItem"
        Me.MasterUpdateToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.MasterUpdateToolStripMenuItem.Text = "Master Update"
        '
        'AddTimeToolStripMenuItem
        '
        Me.AddTimeToolStripMenuItem.Name = "AddTimeToolStripMenuItem"
        Me.AddTimeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddTimeToolStripMenuItem.Text = "Add Time"
        '
        'ExportGridToolStripMenuItem
        '
        Me.ExportGridToolStripMenuItem.Name = "ExportGridToolStripMenuItem"
        Me.ExportGridToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExportGridToolStripMenuItem.Text = "Export Grid"
        '
        'UploadDataToolStripMenuItem1
        '
        Me.UploadDataToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadTemplateToolStripMenuItem, Me.UploadTemplateToolStripMenuItem1})
        Me.UploadDataToolStripMenuItem1.Name = "UploadDataToolStripMenuItem1"
        Me.UploadDataToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.UploadDataToolStripMenuItem1.Text = "Upload Data"
        '
        'DownloadTemplateToolStripMenuItem
        '
        Me.DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        Me.DownloadTemplateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DownloadTemplateToolStripMenuItem.Text = "Download Template"
        '
        'UploadTemplateToolStripMenuItem1
        '
        Me.UploadTemplateToolStripMenuItem1.Name = "UploadTemplateToolStripMenuItem1"
        Me.UploadTemplateToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.UploadTemplateToolStripMenuItem1.Text = "Upload Template"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'gridMasterUpdate
        '
        Me.gridMasterUpdate.AllowUserToAddRows = False
        Me.gridMasterUpdate.AllowUserToDeleteRows = False
        Me.gridMasterUpdate.AutoGenerateContextFilters = True
        Me.gridMasterUpdate.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridMasterUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridMasterUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMasterUpdate.ContextMenuStrip = Me.MasterUpdMenu
        Me.gridMasterUpdate.DateWithTime = False
        Me.gridMasterUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMasterUpdate.Location = New System.Drawing.Point(0, 24)
        Me.gridMasterUpdate.Name = "gridMasterUpdate"
        Me.gridMasterUpdate.RowHeadersVisible = False
        Me.gridMasterUpdate.Size = New System.Drawing.Size(834, 416)
        Me.gridMasterUpdate.TabIndex = 154
        Me.gridMasterUpdate.TimeFilter = False
        '
        'MasterUpdMenu
        '
        Me.MasterUpdMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddActivityToolStripMenuItem, Me.UpdateActivityToolStripMenuItem, Me.DeleteActivityToolStripMenuItem1, Me.ExportToolStripMenuItem, Me.ShowAllDataToolStripMenuItem1})
        Me.MasterUpdMenu.Name = "MasterUpdMenu"
        Me.MasterUpdMenu.Size = New System.Drawing.Size(151, 114)
        '
        'AddActivityToolStripMenuItem
        '
        Me.AddActivityToolStripMenuItem.Name = "AddActivityToolStripMenuItem"
        Me.AddActivityToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AddActivityToolStripMenuItem.Text = "Add Activity"
        '
        'UpdateActivityToolStripMenuItem
        '
        Me.UpdateActivityToolStripMenuItem.Name = "UpdateActivityToolStripMenuItem"
        Me.UpdateActivityToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UpdateActivityToolStripMenuItem.Text = "Edit Activity"
        '
        'DeleteActivityToolStripMenuItem1
        '
        Me.DeleteActivityToolStripMenuItem1.Name = "DeleteActivityToolStripMenuItem1"
        Me.DeleteActivityToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.DeleteActivityToolStripMenuItem1.Text = "Delete Activity"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ShowAllDataToolStripMenuItem1
        '
        Me.ShowAllDataToolStripMenuItem1.Name = "ShowAllDataToolStripMenuItem1"
        Me.ShowAllDataToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.ShowAllDataToolStripMenuItem1.Text = "Show all data"
        '
        'lblTotalMin
        '
        Me.lblTotalMin.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMin.Name = "lblTotalMin"
        Me.lblTotalMin.Size = New System.Drawing.Size(99, 17)
        Me.lblTotalMin.Text = "Total Time (M) :"
        '
        'lblTotalVol
        '
        Me.lblTotalVol.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalVol.Name = "lblTotalVol"
        Me.lblTotalVol.Size = New System.Drawing.Size(91, 17)
        Me.lblTotalVol.Text = "Total Volume :"
        '
        'labelStatus
        '
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(0, 17)
        '
        'SSMasterUpdate
        '
        Me.SSMasterUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSMasterUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalMin, Me.lblTotalVol, Me.labelStatus, Me.UploadStatus})
        Me.SSMasterUpdate.Location = New System.Drawing.Point(0, 440)
        Me.SSMasterUpdate.Name = "SSMasterUpdate"
        Me.SSMasterUpdate.Size = New System.Drawing.Size(834, 22)
        Me.SSMasterUpdate.TabIndex = 153
        Me.SSMasterUpdate.Text = "StatusStrip1"
        '
        'UploadStatus
        '
        Me.UploadStatus.BackColor = System.Drawing.Color.Transparent
        Me.UploadStatus.Name = "UploadStatus"
        Me.UploadStatus.Size = New System.Drawing.Size(11, 17)
        Me.UploadStatus.Text = " "
        '
        'MasterUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridMasterUpdate)
        Me.Controls.Add(Me.SSMasterUpdate)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MasterUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Update"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridMasterUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MasterUpdMenu.ResumeLayout(False)
        Me.SSMasterUpdate.ResumeLayout(False)
        Me.SSMasterUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents gridMasterUpdate As ADGV.AdvancedDataGridView
    Friend WithEvents MasterUpdMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteActivityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllDataToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddActivityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTotalMin As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalVol As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents labelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SSMasterUpdate As System.Windows.Forms.StatusStrip
    Friend WithEvents UploadStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MasterUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadDataToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadTemplateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
