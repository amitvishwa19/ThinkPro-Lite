<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Revoke_Consent
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
        Me.Consent_app = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Consent_app
        '
        Me.Consent_app.Dock = System.Windows.Forms.DockStyle.Top
        Me.Consent_app.FullRowSelect = True
        Me.Consent_app.GridLines = True
        Me.Consent_app.Location = New System.Drawing.Point(0, 0)
        Me.Consent_app.Name = "Consent_app"
        Me.Consent_app.Size = New System.Drawing.Size(800, 246)
        Me.Consent_app.TabIndex = 4
        Me.Consent_app.UseCompatibleStateImageBehavior = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(273, 252)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(248, 47)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Revoke Consent"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Revoke_Consent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 305)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Consent_app)
        Me.Name = "Revoke_Consent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revoke Consent"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Consent_app As ListView
    Friend WithEvents Button1 As Button
End Class
