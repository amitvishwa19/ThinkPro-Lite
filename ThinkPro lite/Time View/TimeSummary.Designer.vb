<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeSummary))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New ADGV.AdvancedDataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New ADGV.AdvancedDataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusTotalTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusTotalBreak = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusTotalLock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusTotalSwitch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(834, 440)
        Me.TabControl1.TabIndex = 147
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(826, 414)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Time Summary"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateContextFilters = True
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.DateWithTime = False
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(820, 408)
        Me.DataGridView1.TabIndex = 149
        Me.DataGridView1.TimeFilter = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(826, 414)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Breal/Lock Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateContextFilters = True
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.DateWithTime = False
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(820, 408)
        Me.DataGridView2.TabIndex = 148
        Me.DataGridView2.TimeFilter = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteRowToolStripMenuItem, Me.EditVolumeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(134, 48)
        '
        'DeleteRowToolStripMenuItem
        '
        Me.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem"
        Me.DeleteRowToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DeleteRowToolStripMenuItem.Text = "Delete Row"
        '
        'EditVolumeToolStripMenuItem
        '
        Me.EditVolumeToolStripMenuItem.Name = "EditVolumeToolStripMenuItem"
        Me.EditVolumeToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EditVolumeToolStripMenuItem.Text = "Edit Detail"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusTotalTime, Me.statusTotalBreak, Me.statusTotalLock, Me.statusTotalSwitch})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 150
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusTotalTime
        '
        Me.StatusTotalTime.BackColor = System.Drawing.Color.Transparent
        Me.StatusTotalTime.Name = "StatusTotalTime"
        Me.StatusTotalTime.Size = New System.Drawing.Size(75, 17)
        Me.StatusTotalTime.Text = "Total Time :-"
        '
        'statusTotalBreak
        '
        Me.statusTotalBreak.BackColor = System.Drawing.Color.Transparent
        Me.statusTotalBreak.Name = "statusTotalBreak"
        Me.statusTotalBreak.Size = New System.Drawing.Size(77, 17)
        Me.statusTotalBreak.Text = "Total Break :-"
        '
        'statusTotalLock
        '
        Me.statusTotalLock.BackColor = System.Drawing.Color.Transparent
        Me.statusTotalLock.Name = "statusTotalLock"
        Me.statusTotalLock.Size = New System.Drawing.Size(73, 17)
        Me.statusTotalLock.Text = "Total Lock :-"
        '
        'statusTotalSwitch
        '
        Me.statusTotalSwitch.BackColor = System.Drawing.Color.Transparent
        Me.statusTotalSwitch.Name = "statusTotalSwitch"
        Me.statusTotalSwitch.Size = New System.Drawing.Size(83, 17)
        Me.statusTotalSwitch.Text = "Total Switch :-"
        '
        'TimeSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TimeSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Summary"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditVolumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As ADGV.AdvancedDataGridView
    Friend WithEvents DataGridView2 As ADGV.AdvancedDataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusTotalTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusTotalBreak As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusTotalLock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusTotalSwitch As System.Windows.Forms.ToolStripStatusLabel
End Class
