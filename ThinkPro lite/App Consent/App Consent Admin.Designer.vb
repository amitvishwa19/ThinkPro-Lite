<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class App_Consent_Admin
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
        Me.app_edit_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.user_edit_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewConsentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ApplicationMappingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplicationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PiFieldsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblActiveUser = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_app_count = New System.Windows.Forms.Label()
        Me.app_edit_menu.SuspendLayout()
        Me.user_edit_menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'app_edit_menu
        '
        Me.app_edit_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.app_edit_menu.Name = "ContextMenuStrip1"
        Me.app_edit_menu.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'user_edit_menu
        '
        Me.user_edit_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem1, Me.DeleteToolStripMenuItem1, Me.ViewConsentToolStripMenuItem})
        Me.user_edit_menu.Name = "user_edit_menu"
        Me.user_edit_menu.Size = New System.Drawing.Size(147, 70)
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'ViewConsentToolStripMenuItem
        '
        Me.ViewConsentToolStripMenuItem.Name = "ViewConsentToolStripMenuItem"
        Me.ViewConsentToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ViewConsentToolStripMenuItem.Text = "View Consent"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(725, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Send Mail"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationMappingToolStripMenuItem, Me.ApplicationsToolStripMenuItem, Me.PiFieldsToolStripMenuItem, Me.UsersToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ApplicationMappingToolStripMenuItem
        '
        Me.ApplicationMappingToolStripMenuItem.Name = "ApplicationMappingToolStripMenuItem"
        Me.ApplicationMappingToolStripMenuItem.Size = New System.Drawing.Size(131, 20)
        Me.ApplicationMappingToolStripMenuItem.Text = "Application Mapping"
        '
        'ApplicationsToolStripMenuItem
        '
        Me.ApplicationsToolStripMenuItem.Name = "ApplicationsToolStripMenuItem"
        Me.ApplicationsToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.ApplicationsToolStripMenuItem.Text = "Applications"
        '
        'PiFieldsToolStripMenuItem
        '
        Me.PiFieldsToolStripMenuItem.Name = "PiFieldsToolStripMenuItem"
        Me.PiFieldsToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.PiFieldsToolStripMenuItem.Text = "Pi Fields"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 155)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consent Management"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mapped Applications"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Users"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel1.Controls.Add(Me.lblActiveUser)
        Me.Panel1.Location = New System.Drawing.Point(13, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(101, 96)
        Me.Panel1.TabIndex = 4
        '
        'lblActiveUser
        '
        Me.lblActiveUser.AutoSize = True
        Me.lblActiveUser.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblActiveUser.Location = New System.Drawing.Point(35, 30)
        Me.lblActiveUser.Name = "lblActiveUser"
        Me.lblActiveUser.Size = New System.Drawing.Size(34, 32)
        Me.lblActiveUser.TabIndex = 10
        Me.lblActiveUser.Text = "0"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orchid
        Me.Panel3.Controls.Add(Me.lbl_app_count)
        Me.Panel3.Location = New System.Drawing.Point(136, 19)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(95, 96)
        Me.Panel3.TabIndex = 5
        '
        'lbl_app_count
        '
        Me.lbl_app_count.AutoSize = True
        Me.lbl_app_count.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_app_count.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl_app_count.Location = New System.Drawing.Point(32, 30)
        Me.lbl_app_count.Name = "lbl_app_count"
        Me.lbl_app_count.Size = New System.Drawing.Size(34, 32)
        Me.lbl_app_count.TabIndex = 11
        Me.lbl_app_count.Text = "0"
        '
        'App_Consent_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "App_Consent_Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "App Consent Admin"
        Me.app_edit_menu.ResumeLayout(False)
        Me.user_edit_menu.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents app_edit_menu As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents user_edit_menu As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewConsentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ApplicationMappingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApplicationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PiFieldsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbl_app_count As Label
    Friend WithEvents lblActiveUser As Label
End Class
