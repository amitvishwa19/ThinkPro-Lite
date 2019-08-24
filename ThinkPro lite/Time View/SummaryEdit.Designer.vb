<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryEdit
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
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcomment = New System.Windows.Forms.TextBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtVolume
        '
        Me.txtVolume.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtVolume.Location = New System.Drawing.Point(82, 15)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(193, 20)
        Me.txtVolume.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Volume"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Activity ID"
        '
        'txtActID
        '
        Me.txtActID.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtActID.Location = New System.Drawing.Point(82, 41)
        Me.txtActID.Name = "txtActID"
        Me.txtActID.Size = New System.Drawing.Size(193, 20)
        Me.txtActID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(13, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Comment"
        '
        'txtcomment
        '
        Me.txtcomment.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcomment.Location = New System.Drawing.Point(82, 67)
        Me.txtcomment.Multiline = True
        Me.txtcomment.Name = "txtcomment"
        Me.txtcomment.Size = New System.Drawing.Size(193, 55)
        Me.txtcomment.TabIndex = 4
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(6, 128)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(271, 23)
        Me.cmdUpdate.TabIndex = 6
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'SummaryEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 157)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcomment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SummaryEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Info"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtActID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcomment As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
End Class
