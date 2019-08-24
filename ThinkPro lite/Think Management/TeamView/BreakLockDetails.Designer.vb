<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BreakLockDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BreakLockDetails))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.gridBreakDetails = New ADGV.AdvancedDataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BreakLockDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridBreakDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BreakLockDetailsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'gridBreakDetails
        '
        Me.gridBreakDetails.AllowUserToAddRows = False
        Me.gridBreakDetails.AllowUserToDeleteRows = False
        Me.gridBreakDetails.AutoGenerateContextFilters = True
        Me.gridBreakDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridBreakDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridBreakDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBreakDetails.DateWithTime = False
        Me.gridBreakDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBreakDetails.Location = New System.Drawing.Point(0, 24)
        Me.gridBreakDetails.Name = "gridBreakDetails"
        Me.gridBreakDetails.RowHeadersVisible = False
        Me.gridBreakDetails.Size = New System.Drawing.Size(834, 416)
        Me.gridBreakDetails.TabIndex = 148
        Me.gridBreakDetails.TimeFilter = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BreakLockDetailsToolStripMenuItem
        '
        Me.BreakLockDetailsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.BreakLockDetailsToolStripMenuItem.Name = "BreakLockDetailsToolStripMenuItem"
        Me.BreakLockDetailsToolStripMenuItem.Size = New System.Drawing.Size(116, 20)
        Me.BreakLockDetailsToolStripMenuItem.Text = "Break/Lock Details"
        '
        'ExportToolStripMenuItem1
        '
        Me.ExportToolStripMenuItem1.Name = "ExportToolStripMenuItem1"
        Me.ExportToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExportToolStripMenuItem1.Text = "Export"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'BreakLockDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridBreakDetails)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BreakLockDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Break/Lock Details"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridBreakDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents gridBreakDetails As ADGV.AdvancedDataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BreakLockDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
