<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotBubble
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
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblMsg.Location = New System.Drawing.Point(9, 9)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(353, 60)
        Me.lblMsg.TabIndex = 0
        Me.lblMsg.Text = "If this is your first visit, be sure to check out the FAQ by clicking the link ab" & _
    "ove. You may have to register before you can post: click the register link above" & _
    " to proceed. "
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(374, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mon 2:50 PM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BotBubble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(374, 143)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMsg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BotBubble"
        Me.Text = "BotBubble"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
