<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Changepwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Changepwd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOldpass = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtconPass = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmplID = New System.Windows.Forms.TextBox()
        Me.cmdChangePAss = New System.Windows.Forms.Button()
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblemplid = New System.Windows.Forms.Label()
        Me.lbloldpass = New System.Windows.Forms.Label()
        Me.lblnewpass = New System.Windows.Forms.Label()
        Me.lblconfirmpass = New System.Windows.Forms.Label()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Old Password"
        '
        'txtOldpass
        '
        Me.txtOldpass.Location = New System.Drawing.Point(114, 54)
        Me.txtOldpass.Name = "txtOldpass"
        Me.txtOldpass.Size = New System.Drawing.Size(194, 20)
        Me.txtOldpass.TabIndex = 162
        Me.txtOldpass.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "Confirm Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "New Password"
        '
        'txtconPass
        '
        Me.txtconPass.Location = New System.Drawing.Point(114, 131)
        Me.txtconPass.Name = "txtconPass"
        Me.txtconPass.Size = New System.Drawing.Size(194, 20)
        Me.txtconPass.TabIndex = 164
        Me.txtconPass.UseSystemPasswordChar = True
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(114, 91)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(194, 20)
        Me.txtpass.TabIndex = 163
        Me.txtpass.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 169
        Me.Label2.Text = "Employe ID"
        '
        'txtEmplID
        '
        Me.txtEmplID.Location = New System.Drawing.Point(114, 17)
        Me.txtEmplID.Name = "txtEmplID"
        Me.txtEmplID.Size = New System.Drawing.Size(194, 20)
        Me.txtEmplID.TabIndex = 1
        '
        'cmdChangePAss
        '
        Me.cmdChangePAss.BackColor = System.Drawing.SystemColors.Highlight
        Me.cmdChangePAss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdChangePAss.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdChangePAss.FlatAppearance.BorderSize = 0
        Me.cmdChangePAss.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdChangePAss.Location = New System.Drawing.Point(114, 181)
        Me.cmdChangePAss.Name = "cmdChangePAss"
        Me.cmdChangePAss.Size = New System.Drawing.Size(116, 28)
        Me.cmdChangePAss.TabIndex = 170
        Me.cmdChangePAss.Text = "Change password"
        Me.cmdChangePAss.UseVisualStyleBackColor = False
        '
        'ErrorProviderok
        '
        Me.ErrorProviderok.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderok.ContainerControl = Me
        Me.ErrorProviderok.Icon = CType(resources.GetObject("ErrorProviderok.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderError
        '
        Me.ErrorProviderError.ContainerControl = Me
        Me.ErrorProviderError.Icon = CType(resources.GetObject("ErrorProviderError.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderWarning
        '
        Me.ErrorProviderWarning.ContainerControl = Me
        Me.ErrorProviderWarning.Icon = CType(resources.GetObject("ErrorProviderWarning.Icon"), System.Drawing.Icon)
        '
        'lblemplid
        '
        Me.lblemplid.AutoSize = True
        Me.lblemplid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemplid.ForeColor = System.Drawing.Color.IndianRed
        Me.lblemplid.Location = New System.Drawing.Point(113, 39)
        Me.lblemplid.Name = "lblemplid"
        Me.lblemplid.Size = New System.Drawing.Size(15, 12)
        Me.lblemplid.TabIndex = 171
        Me.lblemplid.Text = "     "
        '
        'lbloldpass
        '
        Me.lbloldpass.AutoSize = True
        Me.lbloldpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbloldpass.ForeColor = System.Drawing.Color.IndianRed
        Me.lbloldpass.Location = New System.Drawing.Point(113, 75)
        Me.lbloldpass.Name = "lbloldpass"
        Me.lbloldpass.Size = New System.Drawing.Size(15, 12)
        Me.lbloldpass.TabIndex = 172
        Me.lbloldpass.Text = "     "
        '
        'lblnewpass
        '
        Me.lblnewpass.AutoSize = True
        Me.lblnewpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnewpass.ForeColor = System.Drawing.Color.IndianRed
        Me.lblnewpass.Location = New System.Drawing.Point(113, 114)
        Me.lblnewpass.Name = "lblnewpass"
        Me.lblnewpass.Size = New System.Drawing.Size(15, 12)
        Me.lblnewpass.TabIndex = 173
        Me.lblnewpass.Text = "     "
        '
        'lblconfirmpass
        '
        Me.lblconfirmpass.AutoSize = True
        Me.lblconfirmpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconfirmpass.ForeColor = System.Drawing.Color.IndianRed
        Me.lblconfirmpass.Location = New System.Drawing.Point(113, 154)
        Me.lblconfirmpass.Name = "lblconfirmpass"
        Me.lblconfirmpass.Size = New System.Drawing.Size(15, 12)
        Me.lblconfirmpass.TabIndex = 174
        Me.lblconfirmpass.Text = "     "
        '
        'Changepwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(329, 217)
        Me.Controls.Add(Me.lblconfirmpass)
        Me.Controls.Add(Me.lblnewpass)
        Me.Controls.Add(Me.lbloldpass)
        Me.Controls.Add(Me.lblemplid)
        Me.Controls.Add(Me.cmdChangePAss)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmplID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOldpass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtconPass)
        Me.Controls.Add(Me.txtpass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Changepwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtOldpass As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtconPass As TextBox
    Friend WithEvents txtpass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmplID As TextBox
    Friend WithEvents cmdChangePAss As Button
    Friend WithEvents ErrorProviderok As ErrorProvider
    Friend WithEvents ErrorProviderError As ErrorProvider
    Friend WithEvents ErrorProviderWarning As ErrorProvider
    Friend WithEvents lblconfirmpass As Label
    Friend WithEvents lblnewpass As Label
    Friend WithEvents lbloldpass As Label
    Friend WithEvents lblemplid As Label
End Class
