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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivitySelector))
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivitySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TotTime = New System.Windows.Forms.Label()
        Me.TotVol = New System.Windows.Forms.Label()
        Me.AvgTime = New System.Windows.Forms.Label()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VolNotApp = New System.Windows.Forms.CheckBox()
        Me.ExpTime = New System.Windows.Forms.Label()
        Me.txtUPT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdadd
        '
        Me.cmdadd.Location = New System.Drawing.Point(450, 106)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(75, 23)
        Me.cmdadd.TabIndex = 2
        Me.cmdadd.Text = ">>>>"
        Me.cmdadd.UseVisualStyleBackColor = True
        '
        'cmdremove
        '
        Me.cmdremove.Location = New System.Drawing.Point(450, 142)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(75, 23)
        Me.cmdremove.TabIndex = 3
        Me.cmdremove.Text = "<<<<"
        Me.cmdremove.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 290)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(251, 290)
        Me.TreeView1.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivitySummaryToolStripMenuItem, Me.AddToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(169, 70)
        '
        'ActivitySummaryToolStripMenuItem
        '
        Me.ActivitySummaryToolStripMenuItem.Name = "ActivitySummaryToolStripMenuItem"
        Me.ActivitySummaryToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ActivitySummaryToolStripMenuItem.Text = "Activity Summary"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(459, 206)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TotTime
        '
        Me.TotTime.AutoSize = True
        Me.TotTime.Location = New System.Drawing.Point(336, 22)
        Me.TotTime.Name = "TotTime"
        Me.TotTime.Size = New System.Drawing.Size(57, 13)
        Me.TotTime.TabIndex = 7
        Me.TotTime.Text = "Total Time"
        '
        'TotVol
        '
        Me.TotVol.AutoSize = True
        Me.TotVol.Location = New System.Drawing.Point(336, 46)
        Me.TotVol.Name = "TotVol"
        Me.TotVol.Size = New System.Drawing.Size(69, 13)
        Me.TotVol.TabIndex = 8
        Me.TotVol.Text = "Total Volume"
        '
        'AvgTime
        '
        Me.AvgTime.AutoSize = True
        Me.AvgTime.Location = New System.Drawing.Point(336, 66)
        Me.AvgTime.Name = "AvgTime"
        Me.AvgTime.Size = New System.Drawing.Size(52, 13)
        Me.AvgTime.TabIndex = 9
        Me.AvgTime.Text = "Avg Time"
        '
        'txtVolume
        '
        Me.txtVolume.Location = New System.Drawing.Point(327, 132)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(100, 20)
        Me.txtVolume.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(327, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Volume"
        '
        'VolNotApp
        '
        Me.VolNotApp.AutoSize = True
        Me.VolNotApp.Location = New System.Drawing.Point(327, 158)
        Me.VolNotApp.Name = "VolNotApp"
        Me.VolNotApp.Size = New System.Drawing.Size(95, 17)
        Me.VolNotApp.TabIndex = 13
        Me.VolNotApp.Text = "Not Applicable"
        Me.VolNotApp.UseVisualStyleBackColor = True
        '
        'ExpTime
        '
        Me.ExpTime.AutoSize = True
        Me.ExpTime.Location = New System.Drawing.Point(327, 206)
        Me.ExpTime.Name = "ExpTime"
        Me.ExpTime.Size = New System.Drawing.Size(78, 13)
        Me.ExpTime.TabIndex = 14
        Me.ExpTime.Text = "Expected Time"
        '
        'txtUPT
        '
        Me.txtUPT.AutoSize = True
        Me.txtUPT.Location = New System.Drawing.Point(336, 89)
        Me.txtUPT.Name = "txtUPT"
        Me.txtUPT.Size = New System.Drawing.Size(29, 13)
        Me.txtUPT.TabIndex = 15
        Me.txtUPT.Text = "UPT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "UPT :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Avg Time :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Total Volume :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Total Time :"
        '
        'TreeView2
        '
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TreeView2.Location = New System.Drawing.Point(583, 0)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(251, 290)
        Me.TreeView2.TabIndex = 20
        '
        'ActivitySelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 312)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUPT)
        Me.Controls.Add(Me.ExpTime)
        Me.Controls.Add(Me.VolNotApp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVolume)
        Me.Controls.Add(Me.AvgTime)
        Me.Controls.Add(Me.TotVol)
        Me.Controls.Add(Me.TotTime)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TreeView1)
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
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TotTime As System.Windows.Forms.Label
    Friend WithEvents TotVol As System.Windows.Forms.Label
    Friend WithEvents AvgTime As System.Windows.Forms.Label
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VolNotApp As System.Windows.Forms.CheckBox
    Friend WithEvents ExpTime As System.Windows.Forms.Label
    Friend WithEvents txtUPT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActivitySummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
End Class
