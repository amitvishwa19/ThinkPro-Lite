<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewUser
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
        Me.Consent_app = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RevokeConsentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReActivateConsentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsentStatusExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Consent_app
        '
        Me.Consent_app.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Consent_app.CheckBoxes = True
        Me.Consent_app.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Consent_app.FullRowSelect = True
        Me.Consent_app.GridLines = True
        Me.Consent_app.Location = New System.Drawing.Point(191, 50)
        Me.Consent_app.Name = "Consent_app"
        Me.Consent_app.Size = New System.Drawing.Size(625, 382)
        Me.Consent_app.TabIndex = 36
        Me.Consent_app.UseCompatibleStateImageBehavior = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RevokeConsentToolStripMenuItem1, Me.ReActivateConsentToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(178, 48)
        '
        'RevokeConsentToolStripMenuItem1
        '
        Me.RevokeConsentToolStripMenuItem1.Name = "RevokeConsentToolStripMenuItem1"
        Me.RevokeConsentToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.RevokeConsentToolStripMenuItem1.Text = "Revoke Consent"
        '
        'ReActivateConsentToolStripMenuItem
        '
        Me.ReActivateConsentToolStripMenuItem.Name = "ReActivateConsentToolStripMenuItem"
        Me.ReActivateConsentToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ReActivateConsentToolStripMenuItem.Text = "ReActivate Consent"
        '
        'TreeView2
        '
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView2.Location = New System.Drawing.Point(11, 50)
        Me.TreeView2.Margin = New System.Windows.Forms.Padding(20)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(166, 382)
        Me.TreeView2.TabIndex = 38
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUserToolStripMenuItem, Me.ConsentStatusExportToolStripMenuItem, Me.UploadDataToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 39
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AddUserToolStripMenuItem.Text = "Add User"
        '
        'ConsentStatusExportToolStripMenuItem
        '
        Me.ConsentStatusExportToolStripMenuItem.Name = "ConsentStatusExportToolStripMenuItem"
        Me.ConsentStatusExportToolStripMenuItem.Size = New System.Drawing.Size(134, 20)
        Me.ConsentStatusExportToolStripMenuItem.Text = "Consent Status Export"
        '
        'UploadDataToolStripMenuItem
        '
        Me.UploadDataToolStripMenuItem.Name = "UploadDataToolStripMenuItem"
        Me.UploadDataToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.UploadDataToolStripMenuItem.Text = "Upload Data"
        Me.UploadDataToolStripMenuItem.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbl})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 40
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(71, 17)
        Me.ToolStripStatusLabel1.Text = "Total Users :"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.SystemColors.Control
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(81, 17)
        Me.lbl.Text = "Selected Item "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(188, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(180, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Consent status of linked Applications"
        '
        'NewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Consent_app)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NewUser"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Consent_app As ListView
    Friend WithEvents Label7 As Label
    Friend WithEvents ConsentStatusExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents RevokeConsentToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReActivateConsentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lbl As ToolStripStatusLabel
End Class
