<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeTeam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeTeam))
        Me.Project = New System.Windows.Forms.Label()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.cmbProcess = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSubProcess = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Project
        '
        Me.Project.AutoSize = True
        Me.Project.Location = New System.Drawing.Point(12, 9)
        Me.Project.Name = "Project"
        Me.Project.Size = New System.Drawing.Size(40, 13)
        Me.Project.TabIndex = 0
        Me.Project.Text = "Project"
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(12, 31)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(203, 21)
        Me.cmbProject.TabIndex = 1
        '
        'cmbProcess
        '
        Me.cmbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(12, 81)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(203, 21)
        Me.cmbProcess.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Process"
        '
        'cmbSubProcess
        '
        Me.cmbSubProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubProcess.FormattingEnabled = True
        Me.cmbSubProcess.Location = New System.Drawing.Point(12, 131)
        Me.cmbSubProcess.Name = "cmbSubProcess"
        Me.cmbSubProcess.Size = New System.Drawing.Size(203, 21)
        Me.cmbSubProcess.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sub Process"
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdSubmit.Location = New System.Drawing.Point(0, 175)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(230, 38)
        Me.cmdSubmit.TabIndex = 6
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'ChangeTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 213)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.cmbSubProcess)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbProcess)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.Project)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChangeTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Team"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Project As Label
    Friend WithEvents cmbProject As ComboBox
    Friend WithEvents cmbProcess As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSubProcess As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdSubmit As Button
End Class
