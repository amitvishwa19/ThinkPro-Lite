<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnloAccount
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
        Me.cmbquest = New System.Windows.Forms.ComboBox()
        Me.txtsecans = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdresetpass = New System.Windows.Forms.Button()
        Me.cmdunlockaccount = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmplID = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblemplid = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbquest
        '
        Me.cmbquest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbquest.Enabled = False
        Me.cmbquest.FormattingEnabled = True
        Me.cmbquest.Location = New System.Drawing.Point(109, 58)
        Me.cmbquest.Name = "cmbquest"
        Me.cmbquest.Size = New System.Drawing.Size(194, 21)
        Me.cmbquest.TabIndex = 158
        '
        'txtsecans
        '
        Me.txtsecans.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtsecans.Enabled = False
        Me.txtsecans.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsecans.Location = New System.Drawing.Point(109, 97)
        Me.txtsecans.Name = "txtsecans"
        Me.txtsecans.Size = New System.Drawing.Size(194, 20)
        Me.txtsecans.TabIndex = 159
        Me.txtsecans.UseSystemPasswordChar = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(9, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "Secret Question"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(12, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "Answer"
        '
        'cmdresetpass
        '
        Me.cmdresetpass.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdresetpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdresetpass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdresetpass.Enabled = False
        Me.cmdresetpass.FlatAppearance.BorderSize = 0
        Me.cmdresetpass.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdresetpass.Location = New System.Drawing.Point(248, 142)
        Me.cmdresetpass.Name = "cmdresetpass"
        Me.cmdresetpass.Size = New System.Drawing.Size(95, 28)
        Me.cmdresetpass.TabIndex = 163
        Me.cmdresetpass.Text = "Reset password"
        Me.cmdresetpass.UseVisualStyleBackColor = False
        '
        'cmdunlockaccount
        '
        Me.cmdunlockaccount.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdunlockaccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdunlockaccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdunlockaccount.Enabled = False
        Me.cmdunlockaccount.FlatAppearance.BorderSize = 0
        Me.cmdunlockaccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdunlockaccount.Location = New System.Drawing.Point(39, 142)
        Me.cmdunlockaccount.Name = "cmdunlockaccount"
        Me.cmdunlockaccount.Size = New System.Drawing.Size(102, 28)
        Me.cmdunlockaccount.TabIndex = 162
        Me.cmdunlockaccount.Text = "Unlock Account"
        Me.cmdunlockaccount.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Employe ID"
        '
        'txtEmplID
        '
        Me.txtEmplID.Location = New System.Drawing.Point(109, 21)
        Me.txtEmplID.Name = "txtEmplID"
        Me.txtEmplID.Size = New System.Drawing.Size(194, 20)
        Me.txtEmplID.TabIndex = 170
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(320, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(42, 23)
        Me.Button2.TabIndex = 172
        Me.Button2.Text = "Go"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblemplid
        '
        Me.lblemplid.AutoSize = True
        Me.lblemplid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemplid.ForeColor = System.Drawing.Color.IndianRed
        Me.lblemplid.Location = New System.Drawing.Point(111, 43)
        Me.lblemplid.Name = "lblemplid"
        Me.lblemplid.Size = New System.Drawing.Size(15, 12)
        Me.lblemplid.TabIndex = 173
        Me.lblemplid.Text = "     "
        '
        'UnloAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(374, 182)
        Me.Controls.Add(Me.lblemplid)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmplID)
        Me.Controls.Add(Me.cmdresetpass)
        Me.Controls.Add(Me.cmdunlockaccount)
        Me.Controls.Add(Me.cmbquest)
        Me.Controls.Add(Me.txtsecans)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnloAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unlock Account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbquest As ComboBox
    Friend WithEvents txtsecans As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdresetpass As Button
    Friend WithEvents cmdunlockaccount As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmplID As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents lblemplid As Label
End Class
