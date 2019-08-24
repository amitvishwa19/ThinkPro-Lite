<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterTimeUpdate
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
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtActID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcmnt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalTime = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtActivity = New System.Windows.Forms.ComboBox()
        Me.txtSubActivity = New System.Windows.Forms.ComboBox()
        Me.txtTask = New System.Windows.Forms.ComboBox()
        Me.txtUser = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Location = New System.Drawing.Point(12, 320)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(274, 42)
        Me.cmdSubmit.TabIndex = 7
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'txtVolume
        '
        Me.txtVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolume.Location = New System.Drawing.Point(93, 203)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(61, 20)
        Me.txtVolume.TabIndex = 4
        Me.txtVolume.Text = "0"
        Me.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Volume"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Task"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Sub Activity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Activity"
        '
        'txtActID
        '
        Me.txtActID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActID.Location = New System.Drawing.Point(175, 203)
        Me.txtActID.Name = "txtActID"
        Me.txtActID.Size = New System.Drawing.Size(109, 20)
        Me.txtActID.TabIndex = 5
        Me.txtActID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(172, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Activity ID"
        '
        'txtcmnt
        '
        Me.txtcmnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmnt.Location = New System.Drawing.Point(12, 248)
        Me.txtcmnt.Multiline = True
        Me.txtcmnt.Name = "txtcmnt"
        Me.txtcmnt.Size = New System.Drawing.Size(273, 66)
        Me.txtcmnt.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Comment"
        '
        'txtTotalTime
        '
        Me.txtTotalTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTime.Location = New System.Drawing.Point(12, 203)
        Me.txtTotalTime.Name = "txtTotalTime"
        Me.txtTotalTime.Size = New System.Drawing.Size(59, 20)
        Me.txtTotalTime.TabIndex = 3
        Me.txtTotalTime.Text = "0"
        Me.txtTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Total Time"
        '
        'txtActivity
        '
        Me.txtActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtActivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActivity.FormattingEnabled = True
        Me.txtActivity.Location = New System.Drawing.Point(11, 74)
        Me.txtActivity.Name = "txtActivity"
        Me.txtActivity.Size = New System.Drawing.Size(273, 21)
        Me.txtActivity.TabIndex = 0
        '
        'txtSubActivity
        '
        Me.txtSubActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSubActivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubActivity.FormattingEnabled = True
        Me.txtSubActivity.Location = New System.Drawing.Point(12, 119)
        Me.txtSubActivity.Name = "txtSubActivity"
        Me.txtSubActivity.Size = New System.Drawing.Size(272, 21)
        Me.txtSubActivity.TabIndex = 1
        '
        'txtTask
        '
        Me.txtTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTask.FormattingEnabled = True
        Me.txtTask.Location = New System.Drawing.Point(12, 163)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(272, 21)
        Me.txtTask.TabIndex = 2
        '
        'txtUser
        '
        Me.txtUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.FormattingEnabled = True
        Me.txtUser.Location = New System.Drawing.Point(12, 26)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(273, 21)
        Me.txtUser.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "User"
        '
        'MasterTimeUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 374)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTask)
        Me.Controls.Add(Me.txtSubActivity)
        Me.Controls.Add(Me.txtActivity)
        Me.Controls.Add(Me.txtTotalTime)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcmnt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtActID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.txtVolume)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MasterTimeUpdate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Update"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtActID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcmnt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTime As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtActivity As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubActivity As System.Windows.Forms.ComboBox
    Friend WithEvents txtTask As System.Windows.Forms.ComboBox
    Friend WithEvents txtUser As ComboBox
    Friend WithEvents Label8 As Label
End Class
