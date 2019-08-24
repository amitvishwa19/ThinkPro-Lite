<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TimeView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeView))
        Me.lbltask = New System.Windows.Forms.Label()
        Me.lblsubactivity = New System.Windows.Forms.Label()
        Me.lblactivity = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstTask = New System.Windows.Forms.ListBox()
        Me.LstSubActivity = New System.Windows.Forms.ListBox()
        Me.lstActivity = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ActivitySelectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelfAllocator = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDateShow = New System.Windows.Forms.GroupBox()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.lblTime7 = New System.Windows.Forms.LinkLabel()
        Me.lblTime6 = New System.Windows.Forms.LinkLabel()
        Me.lblTime5 = New System.Windows.Forms.LinkLabel()
        Me.lblTime4 = New System.Windows.Forms.LinkLabel()
        Me.lblTime3 = New System.Windows.Forms.LinkLabel()
        Me.lblTime2 = New System.Windows.Forms.LinkLabel()
        Me.lblTime1 = New System.Windows.Forms.LinkLabel()
        Me.lblDate7 = New System.Windows.Forms.Label()
        Me.lblDate6 = New System.Windows.Forms.Label()
        Me.lblDate5 = New System.Windows.Forms.Label()
        Me.lblDate4 = New System.Windows.Forms.Label()
        Me.lblDate3 = New System.Windows.Forms.Label()
        Me.lblDate2 = New System.Windows.Forms.Label()
        Me.lblDate1 = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.txttime = New System.Windows.Forms.TextBox()
        Me.cmdEndday = New System.Windows.Forms.Button()
        Me.cmdBreak = New System.Windows.Forms.Button()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.TmrCurrentAct = New System.Windows.Forms.Timer(Me.components)
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.Ticker = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProviderWarning = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProviderok = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblActivityTime = New System.Windows.Forms.Label()
        Me.brkTime = New System.Windows.Forms.Label()
        Me.grpBreakDetails = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CurActTim = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ActStrtTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActLocTime = New System.Windows.Forms.ToolStripDropDownButton()
        Me.lblTotalLock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActBrkTime = New System.Windows.Forms.ToolStripDropDownButton()
        Me.lblTotalBreak = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActSUTime = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ActivityBreakTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.lblDateShow.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBreakDetails.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltask
        '
        Me.lbltask.AutoSize = True
        Me.lbltask.BackColor = System.Drawing.Color.Transparent
        Me.lbltask.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltask.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lbltask.Location = New System.Drawing.Point(450, 216)
        Me.lbltask.Name = "lbltask"
        Me.lbltask.Size = New System.Drawing.Size(31, 13)
        Me.lbltask.TabIndex = 77
        Me.lbltask.Text = "Task"
        Me.lbltask.Visible = False
        '
        'lblsubactivity
        '
        Me.lblsubactivity.AutoSize = True
        Me.lblsubactivity.BackColor = System.Drawing.Color.Transparent
        Me.lblsubactivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubactivity.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblsubactivity.Location = New System.Drawing.Point(228, 216)
        Me.lblsubactivity.Name = "lblsubactivity"
        Me.lblsubactivity.Size = New System.Drawing.Size(63, 13)
        Me.lblsubactivity.TabIndex = 76
        Me.lblsubactivity.Text = "Sub Activity"
        Me.lblsubactivity.Visible = False
        '
        'lblactivity
        '
        Me.lblactivity.AutoSize = True
        Me.lblactivity.BackColor = System.Drawing.Color.Transparent
        Me.lblactivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblactivity.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblactivity.Location = New System.Drawing.Point(15, 216)
        Me.lblactivity.Name = "lblactivity"
        Me.lblactivity.Size = New System.Drawing.Size(41, 13)
        Me.lblactivity.TabIndex = 75
        Me.lblactivity.Text = "Activity"
        Me.lblactivity.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(441, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Task"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(219, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Sub Activity"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(10, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Activity"
        '
        'lstTask
        '
        Me.lstTask.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTask.FormattingEnabled = True
        Me.lstTask.ItemHeight = 14
        Me.lstTask.Location = New System.Drawing.Point(444, 81)
        Me.lstTask.Name = "lstTask"
        Me.lstTask.Size = New System.Drawing.Size(216, 130)
        Me.lstTask.TabIndex = 71
        Me.lstTask.Visible = False
        '
        'LstSubActivity
        '
        Me.LstSubActivity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstSubActivity.FormattingEnabled = True
        Me.LstSubActivity.ItemHeight = 14
        Me.LstSubActivity.Location = New System.Drawing.Point(222, 81)
        Me.LstSubActivity.Name = "LstSubActivity"
        Me.LstSubActivity.Size = New System.Drawing.Size(216, 130)
        Me.LstSubActivity.TabIndex = 70
        Me.LstSubActivity.Visible = False
        '
        'lstActivity
        '
        Me.lstActivity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstActivity.FormattingEnabled = True
        Me.lstActivity.ItemHeight = 14
        Me.lstActivity.Location = New System.Drawing.Point(10, 81)
        Me.lstActivity.Name = "lstActivity"
        Me.lstActivity.Size = New System.Drawing.Size(203, 130)
        Me.lstActivity.TabIndex = 69
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivitySelectorToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 78
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ActivitySelectorToolStripMenuItem
        '
        Me.ActivitySelectorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelfAllocator})
        Me.ActivitySelectorToolStripMenuItem.Enabled = False
        Me.ActivitySelectorToolStripMenuItem.Name = "ActivitySelectorToolStripMenuItem"
        Me.ActivitySelectorToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.ActivitySelectorToolStripMenuItem.Text = "Capacity Planning"
        '
        'SelfAllocator
        '
        Me.SelfAllocator.Name = "SelfAllocator"
        Me.SelfAllocator.Size = New System.Drawing.Size(152, 22)
        Me.SelfAllocator.Text = "Self Allocation"
        '
        'lblDateShow
        '
        Me.lblDateShow.BackColor = System.Drawing.Color.Transparent
        Me.lblDateShow.Controls.Add(Me.lblCurTime)
        Me.lblDateShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateShow.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDateShow.Location = New System.Drawing.Point(676, 24)
        Me.lblDateShow.Name = "lblDateShow"
        Me.lblDateShow.Size = New System.Drawing.Size(150, 44)
        Me.lblDateShow.TabIndex = 79
        Me.lblDateShow.TabStop = False
        '
        'lblCurTime
        '
        Me.lblCurTime.AutoSize = True
        Me.lblCurTime.BackColor = System.Drawing.Color.Transparent
        Me.lblCurTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurTime.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblCurTime.Location = New System.Drawing.Point(38, 13)
        Me.lblCurTime.Name = "lblCurTime"
        Me.lblCurTime.Size = New System.Drawing.Size(62, 24)
        Me.lblCurTime.TabIndex = 80
        Me.lblCurTime.Text = "Clock"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DateTimePicker)
        Me.GroupBox1.Controls.Add(Me.lblTime7)
        Me.GroupBox1.Controls.Add(Me.lblTime6)
        Me.GroupBox1.Controls.Add(Me.lblTime5)
        Me.GroupBox1.Controls.Add(Me.lblTime4)
        Me.GroupBox1.Controls.Add(Me.lblTime3)
        Me.GroupBox1.Controls.Add(Me.lblTime2)
        Me.GroupBox1.Controls.Add(Me.lblTime1)
        Me.GroupBox1.Controls.Add(Me.lblDate7)
        Me.GroupBox1.Controls.Add(Me.lblDate6)
        Me.GroupBox1.Controls.Add(Me.lblDate5)
        Me.GroupBox1.Controls.Add(Me.lblDate4)
        Me.GroupBox1.Controls.Add(Me.lblDate3)
        Me.GroupBox1.Controls.Add(Me.lblDate2)
        Me.GroupBox1.Controls.Add(Me.lblDate1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(676, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 212)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Time Summary (Min)"
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker.Location = New System.Drawing.Point(6, 0)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(138, 21)
        Me.DateTimePicker.TabIndex = 140
        '
        'lblTime7
        '
        Me.lblTime7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime7.BackColor = System.Drawing.Color.Transparent
        Me.lblTime7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime7.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime7.Location = New System.Drawing.Point(100, 181)
        Me.lblTime7.Name = "lblTime7"
        Me.lblTime7.Size = New System.Drawing.Size(28, 14)
        Me.lblTime7.TabIndex = 148
        Me.lblTime7.TabStop = True
        Me.lblTime7.Text = "0.00"
        Me.lblTime7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime6
        '
        Me.lblTime6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime6.BackColor = System.Drawing.Color.Transparent
        Me.lblTime6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime6.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime6.Location = New System.Drawing.Point(100, 155)
        Me.lblTime6.Name = "lblTime6"
        Me.lblTime6.Size = New System.Drawing.Size(28, 14)
        Me.lblTime6.TabIndex = 147
        Me.lblTime6.TabStop = True
        Me.lblTime6.Text = "0.00"
        Me.lblTime6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime5
        '
        Me.lblTime5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime5.BackColor = System.Drawing.Color.Transparent
        Me.lblTime5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime5.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime5.Location = New System.Drawing.Point(100, 128)
        Me.lblTime5.Name = "lblTime5"
        Me.lblTime5.Size = New System.Drawing.Size(28, 14)
        Me.lblTime5.TabIndex = 146
        Me.lblTime5.TabStop = True
        Me.lblTime5.Text = "0.00"
        Me.lblTime5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime4
        '
        Me.lblTime4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime4.BackColor = System.Drawing.Color.Transparent
        Me.lblTime4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime4.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime4.Location = New System.Drawing.Point(100, 105)
        Me.lblTime4.Name = "lblTime4"
        Me.lblTime4.Size = New System.Drawing.Size(28, 14)
        Me.lblTime4.TabIndex = 145
        Me.lblTime4.TabStop = True
        Me.lblTime4.Text = "0.00"
        Me.lblTime4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime3
        '
        Me.lblTime3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime3.BackColor = System.Drawing.Color.Transparent
        Me.lblTime3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime3.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime3.Location = New System.Drawing.Point(100, 81)
        Me.lblTime3.Name = "lblTime3"
        Me.lblTime3.Size = New System.Drawing.Size(28, 14)
        Me.lblTime3.TabIndex = 144
        Me.lblTime3.TabStop = True
        Me.lblTime3.Text = "0.00"
        Me.lblTime3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime2
        '
        Me.lblTime2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime2.BackColor = System.Drawing.Color.Transparent
        Me.lblTime2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime2.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime2.Location = New System.Drawing.Point(100, 56)
        Me.lblTime2.Name = "lblTime2"
        Me.lblTime2.Size = New System.Drawing.Size(28, 14)
        Me.lblTime2.TabIndex = 143
        Me.lblTime2.TabStop = True
        Me.lblTime2.Text = "0.00"
        Me.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime1
        '
        Me.lblTime1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime1.BackColor = System.Drawing.Color.Transparent
        Me.lblTime1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblTime1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.lblTime1.Location = New System.Drawing.Point(100, 32)
        Me.lblTime1.Name = "lblTime1"
        Me.lblTime1.Size = New System.Drawing.Size(28, 14)
        Me.lblTime1.TabIndex = 142
        Me.lblTime1.TabStop = True
        Me.lblTime1.Tag = "lblTime1"
        Me.lblTime1.Text = "0.00"
        Me.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate7
        '
        Me.lblDate7.AutoSize = True
        Me.lblDate7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate7.Location = New System.Drawing.Point(25, 182)
        Me.lblDate7.Name = "lblDate7"
        Me.lblDate7.Size = New System.Drawing.Size(29, 14)
        Me.lblDate7.TabIndex = 120
        Me.lblDate7.Text = "Date"
        '
        'lblDate6
        '
        Me.lblDate6.AutoSize = True
        Me.lblDate6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate6.Location = New System.Drawing.Point(25, 156)
        Me.lblDate6.Name = "lblDate6"
        Me.lblDate6.Size = New System.Drawing.Size(29, 14)
        Me.lblDate6.TabIndex = 118
        Me.lblDate6.Text = "Date"
        '
        'lblDate5
        '
        Me.lblDate5.AutoSize = True
        Me.lblDate5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate5.Location = New System.Drawing.Point(25, 130)
        Me.lblDate5.Name = "lblDate5"
        Me.lblDate5.Size = New System.Drawing.Size(29, 14)
        Me.lblDate5.TabIndex = 116
        Me.lblDate5.Text = "Date"
        '
        'lblDate4
        '
        Me.lblDate4.AutoSize = True
        Me.lblDate4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate4.Location = New System.Drawing.Point(25, 106)
        Me.lblDate4.Name = "lblDate4"
        Me.lblDate4.Size = New System.Drawing.Size(29, 14)
        Me.lblDate4.TabIndex = 114
        Me.lblDate4.Text = "Date"
        '
        'lblDate3
        '
        Me.lblDate3.AutoSize = True
        Me.lblDate3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate3.Location = New System.Drawing.Point(25, 82)
        Me.lblDate3.Name = "lblDate3"
        Me.lblDate3.Size = New System.Drawing.Size(29, 14)
        Me.lblDate3.TabIndex = 112
        Me.lblDate3.Text = "Date"
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate2.Location = New System.Drawing.Point(25, 57)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(29, 14)
        Me.lblDate2.TabIndex = 110
        Me.lblDate2.Text = "Date"
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDate1.Location = New System.Drawing.Point(25, 33)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(29, 14)
        Me.lblDate1.TabIndex = 108
        Me.lblDate1.Text = "Date"
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.BackColor = System.Drawing.Color.Transparent
        Me.lbltime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbltime.Location = New System.Drawing.Point(338, 232)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(64, 15)
        Me.lbltime.TabIndex = 127
        Me.lbltime.Text = "Time(Min)"
        Me.lbltime.Visible = False
        '
        'txttime
        '
        Me.txttime.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txttime.Location = New System.Drawing.Point(406, 231)
        Me.txttime.Name = "txttime"
        Me.txttime.Size = New System.Drawing.Size(66, 20)
        Me.txttime.TabIndex = 126
        Me.txttime.Visible = False
        '
        'cmdEndday
        '
        Me.cmdEndday.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdEndday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEndday.FlatAppearance.BorderSize = 0
        Me.cmdEndday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEndday.Location = New System.Drawing.Point(496, 304)
        Me.cmdEndday.Name = "cmdEndday"
        Me.cmdEndday.Size = New System.Drawing.Size(105, 23)
        Me.cmdEndday.TabIndex = 125
        Me.cmdEndday.Text = "End Day"
        Me.cmdEndday.UseVisualStyleBackColor = False
        Me.cmdEndday.Visible = False
        '
        'cmdBreak
        '
        Me.cmdBreak.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdBreak.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdBreak.FlatAppearance.BorderSize = 0
        Me.cmdBreak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBreak.Location = New System.Drawing.Point(496, 269)
        Me.cmdBreak.Name = "cmdBreak"
        Me.cmdBreak.Size = New System.Drawing.Size(105, 23)
        Me.cmdBreak.TabIndex = 124
        Me.cmdBreak.Text = "Start Break"
        Me.cmdBreak.UseVisualStyleBackColor = False
        Me.cmdBreak.Visible = False
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.BackColor = System.Drawing.Color.Transparent
        Me.lblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblComments.Location = New System.Drawing.Point(23, 271)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(67, 15)
        Me.lblComments.TabIndex = 123
        Me.lblComments.Text = "Comments"
        Me.lblComments.Visible = False
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtComments.Location = New System.Drawing.Point(112, 266)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(360, 63)
        Me.txtComments.TabIndex = 122
        Me.txtComments.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblID.Location = New System.Drawing.Point(205, 232)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(19, 15)
        Me.lblID.TabIndex = 121
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtID.Location = New System.Drawing.Point(230, 231)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 120
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.Color.Transparent
        Me.lblVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolume.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblVolume.Location = New System.Drawing.Point(27, 233)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(49, 15)
        Me.lblVolume.TabIndex = 119
        Me.lblVolume.Text = "Volume"
        Me.lblVolume.Visible = False
        '
        'txtVolume
        '
        Me.txtVolume.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtVolume.Location = New System.Drawing.Point(112, 231)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(78, 20)
        Me.txtVolume.TabIndex = 118
        Me.txtVolume.Text = "0"
        Me.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVolume.Visible = False
        '
        'TmrCurrentAct
        '
        '
        'TimerClock
        '
        Me.TimerClock.Enabled = True
        '
        'Ticker
        '
        '
        'ErrorProviderWarning
        '
        Me.ErrorProviderWarning.ContainerControl = Me
        Me.ErrorProviderWarning.Icon = CType(resources.GetObject("ErrorProviderWarning.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderError
        '
        Me.ErrorProviderError.ContainerControl = Me
        Me.ErrorProviderError.Icon = CType(resources.GetObject("ErrorProviderError.Icon"), System.Drawing.Icon)
        '
        'ErrorProviderok
        '
        Me.ErrorProviderok.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderok.ContainerControl = Me
        Me.ErrorProviderok.Icon = CType(resources.GetObject("ErrorProviderok.Icon"), System.Drawing.Icon)
        '
        'lblActivityTime
        '
        Me.lblActivityTime.AutoSize = True
        Me.lblActivityTime.BackColor = System.Drawing.Color.Transparent
        Me.lblActivityTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivityTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblActivityTime.Location = New System.Drawing.Point(490, 61)
        Me.lblActivityTime.Name = "lblActivityTime"
        Me.lblActivityTime.Size = New System.Drawing.Size(111, 15)
        Me.lblActivityTime.TabIndex = 134
        Me.lblActivityTime.Text = "Activty Time 30 Min"
        Me.lblActivityTime.Visible = False
        '
        'brkTime
        '
        Me.brkTime.AutoSize = True
        Me.brkTime.BackColor = System.Drawing.Color.Transparent
        Me.brkTime.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brkTime.ForeColor = System.Drawing.SystemColors.Highlight
        Me.brkTime.Location = New System.Drawing.Point(71, 16)
        Me.brkTime.Name = "brkTime"
        Me.brkTime.Size = New System.Drawing.Size(52, 24)
        Me.brkTime.TabIndex = 144
        Me.brkTime.Text = "0.00"
        '
        'grpBreakDetails
        '
        Me.grpBreakDetails.BackColor = System.Drawing.Color.Transparent
        Me.grpBreakDetails.Controls.Add(Me.brkTime)
        Me.grpBreakDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBreakDetails.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.grpBreakDetails.Location = New System.Drawing.Point(11, 375)
        Me.grpBreakDetails.Name = "grpBreakDetails"
        Me.grpBreakDetails.Size = New System.Drawing.Size(185, 49)
        Me.grpBreakDetails.TabIndex = 81
        Me.grpBreakDetails.TabStop = False
        Me.grpBreakDetails.Text = "Break"
        Me.grpBreakDetails.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CurActTim, Me.ActLocTime, Me.ActBrkTime, Me.ActSUTime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 136
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CurActTim
        '
        Me.CurActTim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CurActTim.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActStrtTime})
        Me.CurActTim.Image = CType(resources.GetObject("CurActTim.Image"), System.Drawing.Image)
        Me.CurActTim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CurActTim.Name = "CurActTim"
        Me.CurActTim.Size = New System.Drawing.Size(157, 20)
        Me.CurActTim.Text = "Current Activty Time : -"
        '
        'ActStrtTime
        '
        Me.ActStrtTime.Name = "ActStrtTime"
        Me.ActStrtTime.Size = New System.Drawing.Size(176, 22)
        Me.ActStrtTime.Text = "Activity Started :-"
        '
        'ActLocTime
        '
        Me.ActLocTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ActLocTime.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalLock})
        Me.ActLocTime.Image = CType(resources.GetObject("ActLocTime.Image"), System.Drawing.Image)
        Me.ActLocTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ActLocTime.Name = "ActLocTime"
        Me.ActLocTime.Size = New System.Drawing.Size(139, 20)
        Me.ActLocTime.Text = "Activty Lock Time : -"
        '
        'lblTotalLock
        '
        Me.lblTotalLock.Name = "lblTotalLock"
        Me.lblTotalLock.Size = New System.Drawing.Size(178, 22)
        Me.lblTotalLock.Text = "Total Lock Time :-"
        '
        'ActBrkTime
        '
        Me.ActBrkTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ActBrkTime.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalBreak})
        Me.ActBrkTime.Image = CType(resources.GetObject("ActBrkTime.Image"), System.Drawing.Image)
        Me.ActBrkTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ActBrkTime.Name = "ActBrkTime"
        Me.ActBrkTime.Size = New System.Drawing.Size(150, 20)
        Me.ActBrkTime.Text = "Activity Break Time : -"
        '
        'lblTotalBreak
        '
        Me.lblTotalBreak.Name = "lblTotalBreak"
        Me.lblTotalBreak.Size = New System.Drawing.Size(190, 22)
        Me.lblTotalBreak.Text = "Total Break Time : -"
        '
        'ActSUTime
        '
        Me.ActSUTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ActSUTime.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivityBreakTimeToolStripMenuItem})
        Me.ActSUTime.Image = CType(resources.GetObject("ActSUTime.Image"), System.Drawing.Image)
        Me.ActSUTime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ActSUTime.Name = "ActSUTime"
        Me.ActSUTime.Size = New System.Drawing.Size(183, 20)
        Me.ActSUTime.Text = "Activity Switch User Time : -"
        Me.ActSUTime.Visible = False
        '
        'ActivityBreakTimeToolStripMenuItem
        '
        Me.ActivityBreakTimeToolStripMenuItem.Name = "ActivityBreakTimeToolStripMenuItem"
        Me.ActivityBreakTimeToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ActivityBreakTimeToolStripMenuItem.Text = "Total Switch User Time : -"
        '
        'TimeView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(834, 462)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpBreakDetails)
        Me.Controls.Add(Me.lblActivityTime)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.txttime)
        Me.Controls.Add(Me.cmdEndday)
        Me.Controls.Add(Me.cmdBreak)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblVolume)
        Me.Controls.Add(Me.txtVolume)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDateShow)
        Me.Controls.Add(Me.lbltask)
        Me.Controls.Add(Me.lblsubactivity)
        Me.Controls.Add(Me.lblactivity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstTask)
        Me.Controls.Add(Me.LstSubActivity)
        Me.Controls.Add(Me.lstActivity)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "TimeView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time View"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.lblDateShow.ResumeLayout(False)
        Me.lblDateShow.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProviderWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBreakDetails.ResumeLayout(False)
        Me.grpBreakDetails.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltask As System.Windows.Forms.Label
    Friend WithEvents lblsubactivity As System.Windows.Forms.Label
    Friend WithEvents lblactivity As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstTask As System.Windows.Forms.ListBox
    Friend WithEvents LstSubActivity As System.Windows.Forms.ListBox
    Friend WithEvents lstActivity As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents lblDateShow As System.Windows.Forms.GroupBox
    Friend WithEvents lblCurTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate7 As System.Windows.Forms.Label
    Friend WithEvents lblDate6 As System.Windows.Forms.Label
    Friend WithEvents lblDate5 As System.Windows.Forms.Label
    Friend WithEvents lblDate4 As System.Windows.Forms.Label
    Friend WithEvents lblDate3 As System.Windows.Forms.Label
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents txttime As System.Windows.Forms.TextBox
    Friend WithEvents cmdEndday As System.Windows.Forms.Button
    Friend WithEvents cmdBreak As System.Windows.Forms.Button
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblVolume As System.Windows.Forms.Label
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Friend WithEvents TmrCurrentAct As System.Windows.Forms.Timer
    Friend WithEvents TimerClock As System.Windows.Forms.Timer
    Friend WithEvents Ticker As System.Windows.Forms.Timer
    Friend WithEvents ErrorProviderWarning As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderError As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProviderok As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblActivityTime As System.Windows.Forms.Label
    Friend WithEvents lblTime6 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTime5 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTime4 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTime3 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTime2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTime1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Public WithEvents lblTime7 As System.Windows.Forms.LinkLabel
    Friend WithEvents grpBreakDetails As System.Windows.Forms.GroupBox
    Friend WithEvents brkTime As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ActivitySelectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelfAllocator As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActLocTime As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents lblTotalLock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CurActTim As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ActBrkTime As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents lblTotalBreak As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActStrtTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActSUTime As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ActivityBreakTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
