<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThinkBot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ThinkBot))
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.BackColor = System.Drawing.SystemColors.Menu
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtInput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(0, 338)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(271, 14)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = "Type your response here"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlDisplay)
        Me.Panel1.Controls.Add(Me.txtInput)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 352)
        Me.Panel1.TabIndex = 2
        '
        'pnlDisplay
        '
        Me.pnlDisplay.AutoScroll = True
        Me.pnlDisplay.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlDisplay.Controls.Add(Me.Label1)
        Me.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDisplay.Location = New System.Drawing.Point(0, 27)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(271, 311)
        Me.pnlDisplay.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(271, 27)
        Me.Panel2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 85)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bunifu UI controls are DLL driven tools to help you build awesome desktop applica" & _
    "tion interfaces. It guarantees great user experience in your apps and reduces de" & _
    "velopment time."
        '
        'ThinkBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(275, 354)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ThinkBot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Think Bot"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlDisplay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
