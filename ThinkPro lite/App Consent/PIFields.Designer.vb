<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PIFields
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_pi_name = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.piCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pi_lstbx = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_pi_desc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_pi_status = New System.Windows.Forms.CheckBox()
        Me.cmd_submit = New System.Windows.Forms.Button()
        Me.UploadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pi Field"
        '
        'txt_pi_name
        '
        Me.txt_pi_name.Location = New System.Drawing.Point(222, 50)
        Me.txt_pi_name.Name = "txt_pi_name"
        Me.txt_pi_name.Size = New System.Drawing.Size(189, 20)
        Me.txt_pi_name.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadDataToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(432, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.piCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 281)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(432, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'piCount
        '
        Me.piCount.Name = "piCount"
        Me.piCount.Size = New System.Drawing.Size(0, 17)
        '
        'pi_lstbx
        '
        Me.pi_lstbx.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pi_lstbx.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pi_lstbx.Dock = System.Windows.Forms.DockStyle.Left
        Me.pi_lstbx.FormattingEnabled = True
        Me.pi_lstbx.Location = New System.Drawing.Point(0, 24)
        Me.pi_lstbx.Name = "pi_lstbx"
        Me.pi_lstbx.Size = New System.Drawing.Size(195, 257)
        Me.pi_lstbx.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeactivateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeactivateToolStripMenuItem
        '
        Me.DeactivateToolStripMenuItem.Name = "DeactivateToolStripMenuItem"
        Me.DeactivateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DeactivateToolStripMenuItem.Text = "Deactivate"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'txt_pi_desc
        '
        Me.txt_pi_desc.Location = New System.Drawing.Point(222, 102)
        Me.txt_pi_desc.Multiline = True
        Me.txt_pi_desc.Name = "txt_pi_desc"
        Me.txt_pi_desc.Size = New System.Drawing.Size(189, 88)
        Me.txt_pi_desc.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Description"
        '
        'cmb_pi_status
        '
        Me.cmb_pi_status.AutoSize = True
        Me.cmb_pi_status.Location = New System.Drawing.Point(223, 205)
        Me.cmb_pi_status.Name = "cmb_pi_status"
        Me.cmb_pi_status.Size = New System.Drawing.Size(56, 17)
        Me.cmb_pi_status.TabIndex = 8
        Me.cmb_pi_status.Text = "Status"
        Me.cmb_pi_status.UseVisualStyleBackColor = True
        '
        'cmd_submit
        '
        Me.cmd_submit.Location = New System.Drawing.Point(223, 228)
        Me.cmd_submit.Name = "cmd_submit"
        Me.cmd_submit.Size = New System.Drawing.Size(188, 42)
        Me.cmd_submit.TabIndex = 9
        Me.cmd_submit.Text = "Add New"
        Me.cmd_submit.UseVisualStyleBackColor = True
        '
        'UploadDataToolStripMenuItem
        '
        Me.UploadDataToolStripMenuItem.Name = "UploadDataToolStripMenuItem"
        Me.UploadDataToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.UploadDataToolStripMenuItem.Text = "Upload Data"
        '
        'PIFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 303)
        Me.Controls.Add(Me.cmd_submit)
        Me.Controls.Add(Me.cmb_pi_status)
        Me.Controls.Add(Me.txt_pi_desc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pi_lstbx)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txt_pi_name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PIFields"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add PI Fields"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt_pi_name As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pi_lstbx As ListBox
    Friend WithEvents txt_pi_desc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_pi_status As CheckBox
    Friend WithEvents cmd_submit As Button
    Friend WithEvents piCount As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeactivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadDataToolStripMenuItem As ToolStripMenuItem
End Class
