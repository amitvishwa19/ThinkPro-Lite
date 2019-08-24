<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewIssueLog
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
        Me.cmbLogType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtlogTitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLogDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLogSol = New System.Windows.Forms.TextBox()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbLogType
        '
        Me.cmbLogType.FormattingEnabled = True
        Me.cmbLogType.Items.AddRange(New Object() {"New Request", "Log Issue"})
        Me.cmbLogType.Location = New System.Drawing.Point(12, 50)
        Me.cmbLogType.Name = "cmbLogType"
        Me.cmbLogType.Size = New System.Drawing.Size(290, 21)
        Me.cmbLogType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Log Type"
        '
        'txtlogTitle
        '
        Me.txtlogTitle.Location = New System.Drawing.Point(12, 101)
        Me.txtlogTitle.Name = "txtlogTitle"
        Me.txtlogTitle.Size = New System.Drawing.Size(290, 20)
        Me.txtlogTitle.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Log Title"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Log Description"
        '
        'txtLogDesc
        '
        Me.txtLogDesc.Location = New System.Drawing.Point(12, 155)
        Me.txtLogDesc.Multiline = True
        Me.txtLogDesc.Name = "txtLogDesc"
        Me.txtLogDesc.Size = New System.Drawing.Size(290, 112)
        Me.txtLogDesc.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Log Solution"
        '
        'txtLogSol
        '
        Me.txtLogSol.Enabled = False
        Me.txtLogSol.Location = New System.Drawing.Point(12, 291)
        Me.txtLogSol.Multiline = True
        Me.txtLogSol.Name = "txtLogSol"
        Me.txtLogSol.Size = New System.Drawing.Size(290, 111)
        Me.txtLogSol.TabIndex = 6
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Location = New System.Drawing.Point(10, 408)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(293, 47)
        Me.cmdSubmit.TabIndex = 8
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'NewIssueLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(314, 462)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLogSol)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLogDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtlogTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLogType)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewIssueLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Issue Log"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbLogType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtlogTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLogDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLogSol As System.Windows.Forms.TextBox
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
End Class
