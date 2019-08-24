<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeViewActivityEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeViewActivityEditor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbLockExc = New System.Windows.Forms.CheckBox()
        Me.cbVolReq = New System.Windows.Forms.CheckBox()
        Me.cbActIDReq = New System.Windows.Forms.CheckBox()
        Me.cbCmntReq = New System.Windows.Forms.CheckBox()
        Me.txtUPT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.txtActivity = New System.Windows.Forms.ComboBox()
        Me.txtSubActivity = New System.Windows.Forms.ComboBox()
        Me.txtTask = New System.Windows.Forms.ComboBox()
        Me.txtBucket = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Activity"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sub Activity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Task"
        '
        'cbLockExc
        '
        Me.cbLockExc.AutoSize = True
        Me.cbLockExc.Location = New System.Drawing.Point(10, 224)
        Me.cbLockExc.Name = "cbLockExc"
        Me.cbLockExc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbLockExc.Size = New System.Drawing.Size(97, 17)
        Me.cbLockExc.TabIndex = 6
        Me.cbLockExc.Text = "Lock Excluded"
        Me.cbLockExc.UseVisualStyleBackColor = True
        '
        'cbVolReq
        '
        Me.cbVolReq.AutoSize = True
        Me.cbVolReq.Location = New System.Drawing.Point(10, 247)
        Me.cbVolReq.Name = "cbVolReq"
        Me.cbVolReq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVolReq.Size = New System.Drawing.Size(109, 17)
        Me.cbVolReq.TabIndex = 7
        Me.cbVolReq.Text = "Violume Required"
        Me.cbVolReq.UseVisualStyleBackColor = True
        '
        'cbActIDReq
        '
        Me.cbActIDReq.AutoSize = True
        Me.cbActIDReq.Location = New System.Drawing.Point(164, 224)
        Me.cbActIDReq.Name = "cbActIDReq"
        Me.cbActIDReq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbActIDReq.Size = New System.Drawing.Size(120, 17)
        Me.cbActIDReq.TabIndex = 8
        Me.cbActIDReq.Text = "Activity ID Required"
        Me.cbActIDReq.UseVisualStyleBackColor = True
        '
        'cbCmntReq
        '
        Me.cbCmntReq.AutoSize = True
        Me.cbCmntReq.Location = New System.Drawing.Point(164, 247)
        Me.cbCmntReq.Name = "cbCmntReq"
        Me.cbCmntReq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCmntReq.Size = New System.Drawing.Size(116, 17)
        Me.cbCmntReq.TabIndex = 9
        Me.cbCmntReq.Text = "Comment Required"
        Me.cbCmntReq.UseVisualStyleBackColor = True
        '
        'txtUPT
        '
        Me.txtUPT.Location = New System.Drawing.Point(9, 194)
        Me.txtUPT.Name = "txtUPT"
        Me.txtUPT.Size = New System.Drawing.Size(270, 20)
        Me.txtUPT.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "UPT"
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Location = New System.Drawing.Point(6, 273)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(278, 42)
        Me.cmdSubmit.TabIndex = 12
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'txtActivity
        '
        Me.txtActivity.FormattingEnabled = True
        Me.txtActivity.Location = New System.Drawing.Point(10, 65)
        Me.txtActivity.Name = "txtActivity"
        Me.txtActivity.Size = New System.Drawing.Size(270, 21)
        Me.txtActivity.TabIndex = 13
        '
        'txtSubActivity
        '
        Me.txtSubActivity.FormattingEnabled = True
        Me.txtSubActivity.Location = New System.Drawing.Point(10, 110)
        Me.txtSubActivity.Name = "txtSubActivity"
        Me.txtSubActivity.Size = New System.Drawing.Size(270, 21)
        Me.txtSubActivity.TabIndex = 14
        '
        'txtTask
        '
        Me.txtTask.FormattingEnabled = True
        Me.txtTask.Location = New System.Drawing.Point(10, 153)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(270, 21)
        Me.txtTask.TabIndex = 15
        '
        'txtBucket
        '
        Me.txtBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBucket.FormattingEnabled = True
        Me.txtBucket.Items.AddRange(New Object() {"DIRECT", "INDIRECT", "TCS INTERNAL", "VALIDATION"})
        Me.txtBucket.Location = New System.Drawing.Point(9, 25)
        Me.txtBucket.Name = "txtBucket"
        Me.txtBucket.Size = New System.Drawing.Size(270, 21)
        Me.txtBucket.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Bucket"
        '
        'TimeViewActivityEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(289, 327)
        Me.Controls.Add(Me.txtBucket)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTask)
        Me.Controls.Add(Me.txtSubActivity)
        Me.Controls.Add(Me.txtActivity)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.txtUPT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbCmntReq)
        Me.Controls.Add(Me.cbActIDReq)
        Me.Controls.Add(Me.cbVolReq)
        Me.Controls.Add(Me.cbLockExc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TimeViewActivityEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbLockExc As System.Windows.Forms.CheckBox
    Friend WithEvents cbVolReq As System.Windows.Forms.CheckBox
    Friend WithEvents cbActIDReq As System.Windows.Forms.CheckBox
    Friend WithEvents cbCmntReq As System.Windows.Forms.CheckBox
    Friend WithEvents txtUPT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents txtActivity As System.Windows.Forms.ComboBox
    Friend WithEvents txtSubActivity As System.Windows.Forms.ComboBox
    Friend WithEvents txtTask As System.Windows.Forms.ComboBox
    Friend WithEvents txtBucket As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
