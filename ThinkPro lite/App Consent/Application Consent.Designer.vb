<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Application_Consent
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Consent_app = New System.Windows.Forms.ListView()
        Me.app_consent_text = New System.Windows.Forms.RichTextBox()
        Me.agree_checkbox = New System.Windows.Forms.CheckBox()
        Me.privacy_policy_link = New System.Windows.Forms.LinkLabel()
        Me.cmd_continue = New System.Windows.Forms.Button()
        Me.consentnote = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(22, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consent for :-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(87, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(632, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "+++ PUBLIC RELEASE SUBJECT TO PRIOR LEGAL AND DPO REVIEW AND CONFIRMATION +++"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Consent_app
        '
        Me.Consent_app.FullRowSelect = True
        Me.Consent_app.GridLines = True
        Me.Consent_app.Location = New System.Drawing.Point(25, 61)
        Me.Consent_app.Name = "Consent_app"
        Me.Consent_app.Size = New System.Drawing.Size(777, 183)
        Me.Consent_app.TabIndex = 3
        Me.Consent_app.UseCompatibleStateImageBehavior = False
        '
        'app_consent_text
        '
        Me.app_consent_text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.app_consent_text.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.app_consent_text.Location = New System.Drawing.Point(25, 250)
        Me.app_consent_text.Name = "app_consent_text"
        Me.app_consent_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.app_consent_text.Size = New System.Drawing.Size(777, 102)
        Me.app_consent_text.TabIndex = 5
        Me.app_consent_text.Text = ""
        '
        'agree_checkbox
        '
        Me.agree_checkbox.AutoSize = True
        Me.agree_checkbox.Location = New System.Drawing.Point(309, 404)
        Me.agree_checkbox.Name = "agree_checkbox"
        Me.agree_checkbox.Size = New System.Drawing.Size(177, 17)
        Me.agree_checkbox.TabIndex = 6
        Me.agree_checkbox.Text = "I Agree with terms and condition"
        Me.agree_checkbox.UseVisualStyleBackColor = True
        '
        'privacy_policy_link
        '
        Me.privacy_policy_link.AutoSize = True
        Me.privacy_policy_link.Location = New System.Drawing.Point(672, 42)
        Me.privacy_policy_link.Name = "privacy_policy_link"
        Me.privacy_policy_link.Size = New System.Drawing.Size(130, 13)
        Me.privacy_policy_link.TabIndex = 9
        Me.privacy_policy_link.TabStop = True
        Me.privacy_policy_link.Text = "TCS Global Privacy Policy"
        '
        'cmd_continue
        '
        Me.cmd_continue.Location = New System.Drawing.Point(358, 427)
        Me.cmd_continue.Name = "cmd_continue"
        Me.cmd_continue.Size = New System.Drawing.Size(75, 23)
        Me.cmd_continue.TabIndex = 10
        Me.cmd_continue.Text = "Decline"
        Me.cmd_continue.UseVisualStyleBackColor = True
        '
        'consentnote
        '
        Me.consentnote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.consentnote.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consentnote.ForeColor = System.Drawing.Color.Firebrick
        Me.consentnote.Location = New System.Drawing.Point(25, 358)
        Me.consentnote.Name = "consentnote"
        Me.consentnote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.consentnote.Size = New System.Drawing.Size(789, 40)
        Me.consentnote.TabIndex = 11
        Me.consentnote.Text = "Note:-Click the checkbox  on application grid to accept the consent. In case if y" &
    "ou are not agree to give consent for application(s),keep the checkbox blank and " &
    "click agree and continue."
        '
        'Application_Consent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.consentnote)
        Me.Controls.Add(Me.cmd_continue)
        Me.Controls.Add(Me.privacy_policy_link)
        Me.Controls.Add(Me.agree_checkbox)
        Me.Controls.Add(Me.app_consent_text)
        Me.Controls.Add(Me.Consent_app)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Application_Consent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Application Consent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Consent_app As ListView
    Friend WithEvents app_consent_text As RichTextBox
    Friend WithEvents agree_checkbox As CheckBox
    Friend WithEvents privacy_policy_link As LinkLabel
    Friend WithEvents cmd_continue As Button
    Friend WithEvents consentnote As RichTextBox
End Class
