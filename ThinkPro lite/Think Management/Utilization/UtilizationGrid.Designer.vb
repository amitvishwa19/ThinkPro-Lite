<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtilizationGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UtilizationGrid))
        Me.UDGV = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TreeUtilization = New System.Windows.Forms.TreeView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.UDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UDGV
        '
        Me.UDGV.AllowUserToAddRows = False
        Me.UDGV.AllowUserToDeleteRows = False
        Me.UDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.UDGV.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.UDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.UDGV.ColumnHeadersHeight = 20
        Me.UDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.UDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.UDGV.Location = New System.Drawing.Point(580, 108)
        Me.UDGV.Name = "UDGV"
        Me.UDGV.RowHeadersWidth = 4
        Me.UDGV.Size = New System.Drawing.Size(201, 280)
        Me.UDGV.TabIndex = 159
        Me.UDGV.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Type"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Time(Hrs)"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Count"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "UPT"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Utilization%"
        Me.Column5.Name = "Column5"
        '
        'TreeUtilization
        '
        Me.TreeUtilization.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TreeUtilization.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeUtilization.ItemHeight = 22
        Me.TreeUtilization.Location = New System.Drawing.Point(21, 141)
        Me.TreeUtilization.Name = "TreeUtilization"
        Me.TreeUtilization.Size = New System.Drawing.Size(233, 236)
        Me.TreeUtilization.TabIndex = 161
        Me.TreeUtilization.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(21, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(233, 20)
        Me.Button1.TabIndex = 160
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Location = New System.Drawing.Point(301, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(233, 256)
        Me.Panel3.TabIndex = 162
        Me.Panel3.Visible = False
        '
        'UtilizationGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TreeUtilization)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UDGV)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UtilizationGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utilization Grid"
        CType(Me.UDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TreeUtilization As System.Windows.Forms.TreeView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
