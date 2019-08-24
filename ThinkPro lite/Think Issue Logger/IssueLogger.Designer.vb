<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IssueLogger
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
        Me.gridIssueLogger = New ADGV.AdvancedDataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewIssueLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloneLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.gridIssueLogger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridIssueLogger
        '
        Me.gridIssueLogger.AllowUserToDeleteRows = False
        Me.gridIssueLogger.AutoGenerateContextFilters = True
        Me.gridIssueLogger.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridIssueLogger.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridIssueLogger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridIssueLogger.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gridIssueLogger.DateWithTime = False
        Me.gridIssueLogger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridIssueLogger.Location = New System.Drawing.Point(0, 0)
        Me.gridIssueLogger.Name = "gridIssueLogger"
        Me.gridIssueLogger.RowHeadersVisible = False
        Me.gridIssueLogger.Size = New System.Drawing.Size(834, 462)
        Me.gridIssueLogger.TabIndex = 150
        Me.gridIssueLogger.TimeFilter = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewIssueLogToolStripMenuItem, Me.DeleteLogToolStripMenuItem, Me.CloneLogToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 92)
        '
        'NewIssueLogToolStripMenuItem
        '
        Me.NewIssueLogToolStripMenuItem.Name = "NewIssueLogToolStripMenuItem"
        Me.NewIssueLogToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewIssueLogToolStripMenuItem.Text = "New Issue Log"
        '
        'DeleteLogToolStripMenuItem
        '
        Me.DeleteLogToolStripMenuItem.Name = "DeleteLogToolStripMenuItem"
        Me.DeleteLogToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteLogToolStripMenuItem.Text = "Delete Log"
        '
        'CloneLogToolStripMenuItem
        '
        Me.CloneLogToolStripMenuItem.Name = "CloneLogToolStripMenuItem"
        Me.CloneLogToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloneLogToolStripMenuItem.Text = "Clone Log"
        '
        'IssueLogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridIssueLogger)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IssueLogger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Issue Logger"
        CType(Me.gridIssueLogger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridIssueLogger As ADGV.AdvancedDataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewIssueLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloneLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
