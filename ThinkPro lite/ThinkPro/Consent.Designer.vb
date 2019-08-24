<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppConsent
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdAccept = New System.Windows.Forms.Button()
        Me.cmdDecline = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.consent_text = New System.Windows.Forms.RichTextBox()
        Me.privacy_policy_link = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(319, 380)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(177, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "I Agree with terms and condition"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdAccept
        '
        Me.cmdAccept.Enabled = False
        Me.cmdAccept.Location = New System.Drawing.Point(303, 417)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(75, 23)
        Me.cmdAccept.TabIndex = 1
        Me.cmdAccept.Text = "Accept"
        Me.cmdAccept.UseVisualStyleBackColor = True
        '
        'cmdDecline
        '
        Me.cmdDecline.Enabled = False
        Me.cmdDecline.Location = New System.Drawing.Point(435, 417)
        Me.cmdDecline.Name = "cmdDecline"
        Me.cmdDecline.Size = New System.Drawing.Size(75, 23)
        Me.cmdDecline.TabIndex = 2
        Me.cmdDecline.Text = "Decline"
        Me.cmdDecline.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(268, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tata Consultancy Service"
        '
        'consent_text
        '
        Me.consent_text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.consent_text.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consent_text.Location = New System.Drawing.Point(12, 87)
        Me.consent_text.Name = "consent_text"
        Me.consent_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.consent_text.Size = New System.Drawing.Size(810, 287)
        Me.consent_text.TabIndex = 4
        Me.consent_text.Text = ""
        '
        'privacy_policy_link
        '
        Me.privacy_policy_link.AutoSize = True
        Me.privacy_policy_link.Location = New System.Drawing.Point(23, 30)
        Me.privacy_policy_link.Name = "privacy_policy_link"
        Me.privacy_policy_link.Size = New System.Drawing.Size(130, 13)
        Me.privacy_policy_link.TabIndex = 5
        Me.privacy_policy_link.TabStop = True
        Me.privacy_policy_link.Text = "TCS Global Privacy Policy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(240, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Consent for Think Pro Lite Application"
        '
        'Consent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.privacy_policy_link)
        Me.Controls.Add(Me.consent_text)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDecline)
        Me.Controls.Add(Me.cmdAccept)
        Me.Controls.Add(Me.CheckBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Consent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Consent"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cmdAccept As Button
    Friend WithEvents cmdDecline As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents consent_text As RichTextBox
    Friend WithEvents privacy_policy_link As LinkLabel
    Friend WithEvents Label2 As Label
End Class
