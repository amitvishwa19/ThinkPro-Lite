<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtendedHoursR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExtendedHoursR))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GridExtendedHours = New ADGV.AdvancedDataGridView()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.GridExtndSumary = New ADGV.AdvancedDataGridView()
        Me.ExtendedHour = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.GridExtendedHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage11.SuspendLayout()
        CType(Me.GridExtndSumary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExtendedHour.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage11)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(834, 416)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GridExtendedHours)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(826, 390)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Extended Hour"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'GridExtendedHours
        '
        Me.GridExtendedHours.AllowUserToAddRows = False
        Me.GridExtendedHours.AllowUserToDeleteRows = False
        Me.GridExtendedHours.AutoGenerateContextFilters = True
        Me.GridExtendedHours.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridExtendedHours.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridExtendedHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridExtendedHours.DateWithTime = False
        Me.GridExtendedHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridExtendedHours.Location = New System.Drawing.Point(3, 3)
        Me.GridExtendedHours.Name = "GridExtendedHours"
        Me.GridExtendedHours.RowHeadersVisible = False
        Me.GridExtendedHours.Size = New System.Drawing.Size(820, 384)
        Me.GridExtendedHours.TabIndex = 151
        Me.GridExtendedHours.TimeFilter = False
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.GridExtndSumary)
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(826, 390)
        Me.TabPage11.TabIndex = 1
        Me.TabPage11.Text = "Summary"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'GridExtndSumary
        '
        Me.GridExtndSumary.AllowUserToAddRows = False
        Me.GridExtndSumary.AllowUserToDeleteRows = False
        Me.GridExtndSumary.AutoGenerateContextFilters = True
        Me.GridExtndSumary.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridExtndSumary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridExtndSumary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridExtndSumary.DateWithTime = False
        Me.GridExtndSumary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridExtndSumary.Location = New System.Drawing.Point(3, 3)
        Me.GridExtndSumary.Name = "GridExtndSumary"
        Me.GridExtndSumary.RowHeadersVisible = False
        Me.GridExtndSumary.Size = New System.Drawing.Size(820, 384)
        Me.GridExtndSumary.TabIndex = 152
        Me.GridExtndSumary.TimeFilter = False
        '
        'ExtendedHour
        '
        Me.ExtendedHour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportReportToolStripMenuItem})
        Me.ExtendedHour.Name = "ExtendedHour"
        Me.ExtendedHour.Size = New System.Drawing.Size(146, 26)
        '
        'ExportReportToolStripMenuItem
        '
        Me.ExportReportToolStripMenuItem.Name = "ExportReportToolStripMenuItem"
        Me.ExportReportToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ExportReportToolStripMenuItem.Text = "Export Report"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ExportToolStripMenuItem.Text = "Reports"
        '
        'ExToolStripMenuItem
        '
        Me.ExToolStripMenuItem.Name = "ExToolStripMenuItem"
        Me.ExToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ExToolStripMenuItem.Text = "Extended Hour Report"
        '
        'ExtendedHoursR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ExtendedHoursR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended Hours"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        CType(Me.GridExtendedHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage11.ResumeLayout(False)
        CType(Me.GridExtndSumary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExtendedHour.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents GridExtendedHours As ADGV.AdvancedDataGridView
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents GridExtndSumary As ADGV.AdvancedDataGridView
    Friend WithEvents ExtendedHour As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
