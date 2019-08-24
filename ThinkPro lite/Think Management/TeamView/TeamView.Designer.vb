<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeamView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TeamView))
        Me.gridTeamView = New ADGV.AdvancedDataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SSTeamView = New System.Windows.Forms.StatusStrip()
        Me.TotalUsers = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Active = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Locked = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Break = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoggedIn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoggedOut = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.gridTeamView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SSTeamView.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridTeamView
        '
        Me.gridTeamView.AllowUserToAddRows = False
        Me.gridTeamView.AllowUserToDeleteRows = False
        Me.gridTeamView.AutoGenerateContextFilters = True
        Me.gridTeamView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridTeamView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridTeamView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTeamView.DateWithTime = False
        Me.gridTeamView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridTeamView.Location = New System.Drawing.Point(0, 0)
        Me.gridTeamView.Name = "gridTeamView"
        Me.gridTeamView.RowHeadersVisible = False
        Me.gridTeamView.Size = New System.Drawing.Size(834, 440)
        Me.gridTeamView.TabIndex = 154
        Me.gridTeamView.TimeFilter = False
        '
        'SSTeamView
        '
        Me.SSTeamView.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SSTeamView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalUsers, Me.Active, Me.Locked, Me.Break, Me.LoggedIn, Me.LoggedOut})
        Me.SSTeamView.Location = New System.Drawing.Point(0, 440)
        Me.SSTeamView.Name = "SSTeamView"
        Me.SSTeamView.Size = New System.Drawing.Size(834, 22)
        Me.SSTeamView.TabIndex = 155
        Me.SSTeamView.Text = "StatusStrip1"
        '
        'TotalUsers
        '
        Me.TotalUsers.Name = "TotalUsers"
        Me.TotalUsers.Size = New System.Drawing.Size(68, 17)
        Me.TotalUsers.Text = "TotalUsers :"
        '
        'Active
        '
        Me.Active.Name = "Active"
        Me.Active.Size = New System.Drawing.Size(46, 17)
        Me.Active.Text = "Active :"
        '
        'Locked
        '
        Me.Locked.Name = "Locked"
        Me.Locked.Size = New System.Drawing.Size(51, 17)
        Me.Locked.Text = "Locked :"
        '
        'Break
        '
        Me.Break.Name = "Break"
        Me.Break.Size = New System.Drawing.Size(42, 17)
        Me.Break.Text = "Break :"
        '
        'LoggedIn
        '
        Me.LoggedIn.Name = "LoggedIn"
        Me.LoggedIn.Size = New System.Drawing.Size(66, 17)
        Me.LoggedIn.Text = "Logged In :"
        '
        'LoggedOut
        '
        Me.LoggedOut.Name = "LoggedOut"
        Me.LoggedOut.Size = New System.Drawing.Size(76, 17)
        Me.LoggedOut.Text = "Logged Out :"
        '
        'TeamView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.gridTeamView)
        Me.Controls.Add(Me.SSTeamView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TeamView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Team View"
        CType(Me.gridTeamView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SSTeamView.ResumeLayout(False)
        Me.SSTeamView.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridTeamView As ADGV.AdvancedDataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SSTeamView As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalUsers As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Active As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Locked As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Break As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LoggedIn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LoggedOut As System.Windows.Forms.ToolStripStatusLabel
End Class
