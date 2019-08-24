<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivityUtilazation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivityUtilazation))
        Me.SSUtilization = New System.Windows.Forms.StatusStrip()
        Me.totalTimeMin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalTimeHr = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalVol = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalFTE = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gridUtilization = New ADGV.AdvancedDataGridView()
        Me.UtilizationMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubActivityToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSUtilization.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridUtilization, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UtilizationMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSUtilization
        '
        Me.SSUtilization.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.totalTimeMin, Me.TotalTimeHr, Me.TotalVol, Me.TotalFTE})
        Me.SSUtilization.Location = New System.Drawing.Point(0, 440)
        Me.SSUtilization.Name = "SSUtilization"
        Me.SSUtilization.Size = New System.Drawing.Size(834, 22)
        Me.SSUtilization.TabIndex = 149
        Me.SSUtilization.Text = "SSUtilization"
        '
        'totalTimeMin
        '
        Me.totalTimeMin.BackColor = System.Drawing.Color.Transparent
        Me.totalTimeMin.Name = "totalTimeMin"
        Me.totalTimeMin.Size = New System.Drawing.Size(99, 17)
        Me.totalTimeMin.Text = "Total Time (Min):"
        '
        'TotalTimeHr
        '
        Me.TotalTimeHr.BackColor = System.Drawing.Color.Transparent
        Me.TotalTimeHr.Name = "TotalTimeHr"
        Me.TotalTimeHr.Size = New System.Drawing.Size(99, 17)
        Me.TotalTimeHr.Text = "Total Time (Hrs) :"
        '
        'TotalVol
        '
        Me.TotalVol.BackColor = System.Drawing.Color.Transparent
        Me.TotalVol.Name = "TotalVol"
        Me.TotalVol.Size = New System.Drawing.Size(60, 17)
        Me.TotalVol.Text = "Total Vol :"
        '
        'TotalFTE
        '
        Me.TotalFTE.BackColor = System.Drawing.Color.Transparent
        Me.TotalFTE.Name = "TotalFTE"
        Me.TotalFTE.Size = New System.Drawing.Size(96, 17)
        Me.TotalFTE.Text = "Utilization (FTE) :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 150
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportGridToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'gridUtilization
        '
        Me.gridUtilization.AllowUserToDeleteRows = False
        Me.gridUtilization.AutoGenerateContextFilters = True
        Me.gridUtilization.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridUtilization.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridUtilization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridUtilization.ContextMenuStrip = Me.UtilizationMenu
        Me.gridUtilization.DateWithTime = False
        Me.gridUtilization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridUtilization.Location = New System.Drawing.Point(0, 24)
        Me.gridUtilization.Name = "gridUtilization"
        Me.gridUtilization.RowHeadersVisible = False
        Me.gridUtilization.Size = New System.Drawing.Size(834, 416)
        Me.gridUtilization.TabIndex = 151
        Me.gridUtilization.TimeFilter = False
        '
        'UtilizationMenu
        '
        Me.UtilizationMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivityToolStripMenuItem1, Me.SubActivityToolStripMenuItem1, Me.TaskToolStripMenuItem1, Me.ShowAllDataToolStripMenuItem})
        Me.UtilizationMenu.Name = "PollMenu"
        Me.UtilizationMenu.Size = New System.Drawing.Size(148, 92)
        '
        'ActivityToolStripMenuItem1
        '
        Me.ActivityToolStripMenuItem1.Name = "ActivityToolStripMenuItem1"
        Me.ActivityToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.ActivityToolStripMenuItem1.Text = "Activity"
        '
        'SubActivityToolStripMenuItem1
        '
        Me.SubActivityToolStripMenuItem1.Name = "SubActivityToolStripMenuItem1"
        Me.SubActivityToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.SubActivityToolStripMenuItem1.Text = "Sub Activity"
        '
        'TaskToolStripMenuItem1
        '
        Me.TaskToolStripMenuItem1.Name = "TaskToolStripMenuItem1"
        Me.TaskToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.TaskToolStripMenuItem1.Text = "Task"
        '
        'ShowAllDataToolStripMenuItem
        '
        Me.ShowAllDataToolStripMenuItem.Name = "ShowAllDataToolStripMenuItem"
        Me.ShowAllDataToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowAllDataToolStripMenuItem.Text = "Show All Data"
        '
        'ExportGridToolStripMenuItem
        '
        Me.ExportGridToolStripMenuItem.Name = "ExportGridToolStripMenuItem"
        Me.ExportGridToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExportGridToolStripMenuItem.Text = "Export Grid"
        '
        'ActivityUtilazation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridUtilization)
        Me.Controls.Add(Me.SSUtilization)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ActivityUtilazation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Utilazation"
        Me.SSUtilization.ResumeLayout(False)
        Me.SSUtilization.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridUtilization, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UtilizationMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SSUtilization As System.Windows.Forms.StatusStrip
    Friend WithEvents totalTimeMin As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalTimeHr As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalVol As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalFTE As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridUtilization As ADGV.AdvancedDataGridView
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtilizationMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActivityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubActivityToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaskToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
