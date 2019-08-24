<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivitySelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivitySelector))
        Me.ActivityList = New System.Windows.Forms.ListBox()
        Me.SelActList = New System.Windows.Forms.ListBox()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SuspendLayout()
        '
        'ActivityList
        '
        Me.ActivityList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActivityList.Dock = System.Windows.Forms.DockStyle.Left
        Me.ActivityList.FormattingEnabled = True
        Me.ActivityList.Location = New System.Drawing.Point(0, 0)
        Me.ActivityList.Name = "ActivityList"
        Me.ActivityList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ActivityList.Size = New System.Drawing.Size(206, 289)
        Me.ActivityList.TabIndex = 0
        '
        'SelActList
        '
        Me.SelActList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelActList.Dock = System.Windows.Forms.DockStyle.Right
        Me.SelActList.FormattingEnabled = True
        Me.SelActList.Location = New System.Drawing.Point(316, 0)
        Me.SelActList.Name = "SelActList"
        Me.SelActList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.SelActList.Size = New System.Drawing.Size(206, 289)
        Me.SelActList.TabIndex = 1
        '
        'cmdadd
        '
        Me.cmdadd.Location = New System.Drawing.Point(223, 114)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(75, 23)
        Me.cmdadd.TabIndex = 2
        Me.cmdadd.Text = ">>>>"
        Me.cmdadd.UseVisualStyleBackColor = True
        '
        'cmdremove
        '
        Me.cmdremove.Location = New System.Drawing.Point(223, 150)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(75, 23)
        Me.cmdremove.TabIndex = 3
        Me.cmdremove.Text = "<<<<"
        Me.cmdremove.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 289)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(522, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ActivitySelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(522, 311)
        Me.Controls.Add(Me.SelActList)
        Me.Controls.Add(Me.ActivityList)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdremove)
        Me.Controls.Add(Me.cmdadd)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ActivitySelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Selector"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActivityList As System.Windows.Forms.ListBox
    Friend WithEvents SelActList As System.Windows.Forms.ListBox
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
End Class
