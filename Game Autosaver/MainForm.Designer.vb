<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.CurrentTimeLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CurrentTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SaveTimeLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.AutosaveF1Label = New System.Windows.Forms.Label()
        Me.AutosaveF1TextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OverwriteComboBox = New System.Windows.Forms.ComboBox()
        Me.SaveCountTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Browse2 = New System.Windows.Forms.Button()
        Me.Browse1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContainingButton2 = New System.Windows.Forms.Button()
        Me.ContainingButton1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.QuickSaveButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ChangeCountButton = New System.Windows.Forms.Button()
        Me.ChangeLimitButton = New System.Windows.Forms.Button()
        Me.RoundRobinButton = New System.Windows.Forms.Button()
        Me.MinimizeToTrayButton = New System.Windows.Forms.Button()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.GameListButton = New System.Windows.Forms.Button()
        Me.QuickLoadButton = New System.Windows.Forms.Button()
        Me.CounterSwitchButton = New System.Windows.Forms.Button()
        Me.SaveViewerButton = New System.Windows.Forms.Button()
        Me.OpenImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SaveLimitTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.HotkeysTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(69, 101)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(685, 26)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(367, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Specify game save directory contents to be autosaved:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(313, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Specify directory for autosaves to be stored in:"
        '
        'TextBox2
        '
        Me.TextBox2.AllowDrop = True
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(69, 175)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(685, 26)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentTimeLabel
        '
        Me.CurrentTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CurrentTimeLabel.AutoSize = True
        Me.CurrentTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentTimeLabel.Location = New System.Drawing.Point(378, 269)
        Me.CurrentTimeLabel.Name = "CurrentTimeLabel"
        Me.CurrentTimeLabel.Size = New System.Drawing.Size(78, 20)
        Me.CurrentTimeLabel.TabIndex = 8
        Me.CurrentTimeLabel.Text = "Time Now"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 269)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Current time:"
        '
        'SaveTimer
        '
        Me.SaveTimer.Interval = 1000
        '
        'CurrentTimer
        '
        '
        'SaveTimeLabel
        '
        Me.SaveTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.SaveTimeLabel.AutoSize = True
        Me.SaveTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveTimeLabel.Location = New System.Drawing.Point(378, 296)
        Me.SaveTimeLabel.Name = "SaveTimeLabel"
        Me.SaveTimeLabel.Size = New System.Drawing.Size(50, 20)
        Me.SaveTimeLabel.TabIndex = 11
        Me.SaveTimeLabel.Text = "Never"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(242, 298)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Next Autosave:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(388, 233)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1380, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(68, 26)
        Me.NumericUpDown1.TabIndex = 53
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'AutosaveF1Label
        '
        Me.AutosaveF1Label.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.AutosaveF1Label.AutoSize = True
        Me.AutosaveF1Label.BackColor = System.Drawing.Color.Red
        Me.AutosaveF1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutosaveF1Label.Location = New System.Drawing.Point(5, 262)
        Me.AutosaveF1Label.Name = "AutosaveF1Label"
        Me.AutosaveF1Label.Size = New System.Drawing.Size(161, 16)
        Me.AutosaveF1Label.TabIndex = 54
        Me.AutosaveF1Label.Text = "Save failures (System IO):"
        Me.AutosaveF1Label.Visible = False
        '
        'AutosaveF1TextBox
        '
        Me.AutosaveF1TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.AutosaveF1TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutosaveF1TextBox.Location = New System.Drawing.Point(168, 260)
        Me.AutosaveF1TextBox.Name = "AutosaveF1TextBox"
        Me.AutosaveF1TextBox.ReadOnly = True
        Me.AutosaveF1TextBox.Size = New System.Drawing.Size(55, 22)
        Me.AutosaveF1TextBox.TabIndex = 55
        Me.AutosaveF1TextBox.Text = "0"
        Me.AutosaveF1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.AutosaveF1TextBox, "An autosave was not saved due to a directory not existing or some other IO relate" &
        "d error")
        Me.AutosaveF1TextBox.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(616, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 16)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Overwrite existing saves:"
        '
        'OverwriteComboBox
        '
        Me.OverwriteComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OverwriteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OverwriteComboBox.Enabled = False
        Me.OverwriteComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverwriteComboBox.FormattingEnabled = True
        Me.OverwriteComboBox.Items.AddRange(New Object() {"No", "Yes"})
        Me.OverwriteComboBox.Location = New System.Drawing.Point(787, 308)
        Me.OverwriteComboBox.Name = "OverwriteComboBox"
        Me.OverwriteComboBox.Size = New System.Drawing.Size(55, 24)
        Me.OverwriteComboBox.TabIndex = 57
        Me.ToolTip1.SetToolTip(Me.OverwriteComboBox, "Enable or disable overwriting of existing saves of the same name")
        '
        'SaveCountTextBox
        '
        Me.SaveCountTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveCountTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveCountTextBox.Location = New System.Drawing.Point(722, 241)
        Me.SaveCountTextBox.Name = "SaveCountTextBox"
        Me.SaveCountTextBox.ReadOnly = True
        Me.SaveCountTextBox.Size = New System.Drawing.Size(62, 22)
        Me.SaveCountTextBox.TabIndex = 59
        Me.SaveCountTextBox.Text = "1"
        Me.SaveCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(612, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 16)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Next"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(213, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 20)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Autosave Interval:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(462, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 16)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Minutes"
        '
        'Browse2
        '
        Me.Browse2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Browse2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse2.Location = New System.Drawing.Point(754, 174)
        Me.Browse2.Margin = New System.Windows.Forms.Padding(0)
        Me.Browse2.Name = "Browse2"
        Me.Browse2.Size = New System.Drawing.Size(103, 27)
        Me.Browse2.TabIndex = 62
        Me.Browse2.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.Browse2, "Browse for directory to use")
        Me.Browse2.UseVisualStyleBackColor = True
        '
        'Browse1
        '
        Me.Browse1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Browse1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse1.Location = New System.Drawing.Point(754, 100)
        Me.Browse1.Margin = New System.Windows.Forms.Padding(0)
        Me.Browse1.Name = "Browse1"
        Me.Browse1.Size = New System.Drawing.Size(103, 27)
        Me.Browse1.TabIndex = 63
        Me.Browse1.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.Browse1, "Browse for directory to use")
        Me.Browse1.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "Game Autosaver"
        '
        'ContainingButton2
        '
        Me.ContainingButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainingButton2.Location = New System.Drawing.Point(0, 174)
        Me.ContainingButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.ContainingButton2.Name = "ContainingButton2"
        Me.ContainingButton2.Size = New System.Drawing.Size(69, 27)
        Me.ContainingButton2.TabIndex = 67
        Me.ContainingButton2.Text = "Open"
        Me.ToolTip1.SetToolTip(Me.ContainingButton2, "Open the directory")
        Me.ContainingButton2.UseVisualStyleBackColor = True
        '
        'ContainingButton1
        '
        Me.ContainingButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainingButton1.Location = New System.Drawing.Point(0, 100)
        Me.ContainingButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ContainingButton1.Name = "ContainingButton1"
        Me.ContainingButton1.Size = New System.Drawing.Size(69, 27)
        Me.ContainingButton1.TabIndex = 68
        Me.ContainingButton1.Text = "Open"
        Me.ToolTip1.SetToolTip(Me.ContainingButton1, "Open the directory")
        Me.ContainingButton1.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'QuickSaveButton
        '
        Me.QuickSaveButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.QuickSaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuickSaveButton.Location = New System.Drawing.Point(0, 0)
        Me.QuickSaveButton.Margin = New System.Windows.Forms.Padding(0)
        Me.QuickSaveButton.MaximumSize = New System.Drawing.Size(137, 50)
        Me.QuickSaveButton.MinimumSize = New System.Drawing.Size(137, 50)
        Me.QuickSaveButton.Name = "QuickSaveButton"
        Me.QuickSaveButton.Size = New System.Drawing.Size(137, 50)
        Me.QuickSaveButton.TabIndex = 69
        Me.QuickSaveButton.Text = "Quick Save"
        Me.ToolTip1.SetToolTip(Me.QuickSaveButton, "Click to create a quick save")
        Me.QuickSaveButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(0, 0)
        Me.StartButton.Margin = New System.Windows.Forms.Padding(0)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(857, 50)
        Me.StartButton.TabIndex = 6
        Me.StartButton.Text = "Start Autosaving"
        Me.ToolTip1.SetToolTip(Me.StartButton, "Start or stop autosaving periodically")
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ChangeCountButton
        '
        Me.ChangeCountButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeCountButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeCountButton.Location = New System.Drawing.Point(787, 241)
        Me.ChangeCountButton.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.ChangeCountButton.Name = "ChangeCountButton"
        Me.ChangeCountButton.Size = New System.Drawing.Size(55, 22)
        Me.ChangeCountButton.TabIndex = 70
        Me.ChangeCountButton.Text = "Change"
        Me.ToolTip1.SetToolTip(Me.ChangeCountButton, "Change the autosave count to be affixed to the autosaves")
        Me.ChangeCountButton.UseVisualStyleBackColor = True
        '
        'ChangeLimitButton
        '
        Me.ChangeLimitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeLimitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeLimitButton.Location = New System.Drawing.Point(787, 215)
        Me.ChangeLimitButton.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.ChangeLimitButton.Name = "ChangeLimitButton"
        Me.ChangeLimitButton.Size = New System.Drawing.Size(55, 22)
        Me.ChangeLimitButton.TabIndex = 78
        Me.ChangeLimitButton.Text = "Change"
        Me.ToolTip1.SetToolTip(Me.ChangeLimitButton, "When the save limit is hit then the saving will start from 1 again")
        Me.ChangeLimitButton.UseVisualStyleBackColor = True
        '
        'RoundRobinButton
        '
        Me.RoundRobinButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundRobinButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundRobinButton.Location = New System.Drawing.Point(706, 269)
        Me.RoundRobinButton.Name = "RoundRobinButton"
        Me.RoundRobinButton.Size = New System.Drawing.Size(136, 33)
        Me.RoundRobinButton.TabIndex = 75
        Me.RoundRobinButton.Text = "Disabled"
        Me.ToolTip1.SetToolTip(Me.RoundRobinButton, "Enable or disable the overwriting of saved autosaves or quick saves." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.RoundRobinButton.UseVisualStyleBackColor = True
        '
        'MinimizeToTrayButton
        '
        Me.MinimizeToTrayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinimizeToTrayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeToTrayButton.Location = New System.Drawing.Point(711, 0)
        Me.MinimizeToTrayButton.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimizeToTrayButton.MaximumSize = New System.Drawing.Size(0, 42)
        Me.MinimizeToTrayButton.MinimumSize = New System.Drawing.Size(146, 42)
        Me.MinimizeToTrayButton.Name = "MinimizeToTrayButton"
        Me.MinimizeToTrayButton.Size = New System.Drawing.Size(146, 42)
        Me.MinimizeToTrayButton.TabIndex = 66
        Me.MinimizeToTrayButton.Text = "Minimize To Tray"
        Me.ToolTip1.SetToolTip(Me.MinimizeToTrayButton, "Click to minimize to tray")
        Me.MinimizeToTrayButton.UseVisualStyleBackColor = True
        '
        'SettingsButton
        '
        Me.SettingsButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SettingsButton.Location = New System.Drawing.Point(0, 0)
        Me.SettingsButton.Margin = New System.Windows.Forms.Padding(0)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(46, 42)
        Me.SettingsButton.TabIndex = 81
        Me.ToolTip1.SetToolTip(Me.SettingsButton, "Change other settings")
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'GameListButton
        '
        Me.GameListButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.GameListButton.Location = New System.Drawing.Point(46, 0)
        Me.GameListButton.Margin = New System.Windows.Forms.Padding(0)
        Me.GameListButton.Name = "GameListButton"
        Me.GameListButton.Size = New System.Drawing.Size(89, 42)
        Me.GameListButton.TabIndex = 82
        Me.GameListButton.Text = "Game List"
        Me.ToolTip1.SetToolTip(Me.GameListButton, "Load and create new game save configs")
        Me.GameListButton.UseVisualStyleBackColor = True
        '
        'QuickLoadButton
        '
        Me.QuickLoadButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.QuickLoadButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuickLoadButton.Location = New System.Drawing.Point(720, 0)
        Me.QuickLoadButton.Margin = New System.Windows.Forms.Padding(0)
        Me.QuickLoadButton.MaximumSize = New System.Drawing.Size(137, 50)
        Me.QuickLoadButton.MinimumSize = New System.Drawing.Size(137, 50)
        Me.QuickLoadButton.Name = "QuickLoadButton"
        Me.QuickLoadButton.Size = New System.Drawing.Size(137, 50)
        Me.QuickLoadButton.TabIndex = 70
        Me.QuickLoadButton.Text = "Quick Load"
        Me.ToolTip1.SetToolTip(Me.QuickLoadButton, "Click to replace your game save with your last quick save")
        Me.QuickLoadButton.UseVisualStyleBackColor = True
        '
        'CounterSwitchButton
        '
        Me.CounterSwitchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CounterSwitchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CounterSwitchButton.Location = New System.Drawing.Point(646, 241)
        Me.CounterSwitchButton.Name = "CounterSwitchButton"
        Me.CounterSwitchButton.Size = New System.Drawing.Size(75, 22)
        Me.CounterSwitchButton.TabIndex = 79
        Me.CounterSwitchButton.Text = "autosave"
        Me.ToolTip1.SetToolTip(Me.CounterSwitchButton, "Toggle to view and change next quick save or autosave count")
        Me.CounterSwitchButton.UseVisualStyleBackColor = True
        '
        'SaveViewerButton
        '
        Me.SaveViewerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveViewerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveViewerButton.Location = New System.Drawing.Point(0, 290)
        Me.SaveViewerButton.Margin = New System.Windows.Forms.Padding(0)
        Me.SaveViewerButton.Name = "SaveViewerButton"
        Me.SaveViewerButton.Size = New System.Drawing.Size(137, 48)
        Me.SaveViewerButton.TabIndex = 71
        Me.SaveViewerButton.Text = "Save List"
        Me.ToolTip1.SetToolTip(Me.SaveViewerButton, "Shows a list of your autosaves or quick saves to load, delete, or view")
        Me.SaveViewerButton.UseVisualStyleBackColor = True
        '
        'OpenImageFileDialog
        '
        Me.OpenImageFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp, *.gif, *.tif, *.tiff, *.jpe, *.jp2, *.j" &
    "px, *.j2k, *.j2c)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.jpe;*.jp2;*.jpx;" &
    "*.j2k;*.j2c"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.QuickLoadButton)
        Me.Panel1.Controls.Add(Me.QuickSaveButton)
        Me.Panel1.Controls.Add(Me.StartButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 338)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(821, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(857, 50)
        Me.Panel1.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(616, 278)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Round robin:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(616, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 16)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Autosave limit:"
        '
        'SaveLimitTextBox
        '
        Me.SaveLimitTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveLimitTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveLimitTextBox.Location = New System.Drawing.Point(722, 215)
        Me.SaveLimitTextBox.Name = "SaveLimitTextBox"
        Me.SaveLimitTextBox.ReadOnly = True
        Me.SaveLimitTextBox.Size = New System.Drawing.Size(62, 22)
        Me.SaveLimitTextBox.TabIndex = 77
        Me.SaveLimitTextBox.Text = "None"
        Me.SaveLimitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(157, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(522, 29)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "GAME AUTOSAVER"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.GameListButton)
        Me.Panel2.Controls.Add(Me.SettingsButton)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.MinimizeToTrayButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.MinimumSize = New System.Drawing.Size(827, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(857, 42)
        Me.Panel2.TabIndex = 73
        '
        'HotkeysTimer
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 388)
        Me.Controls.Add(Me.SaveViewerButton)
        Me.Controls.Add(Me.CounterSwitchButton)
        Me.Controls.Add(Me.ChangeLimitButton)
        Me.Controls.Add(Me.SaveLimitTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RoundRobinButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ChangeCountButton)
        Me.Controls.Add(Me.ContainingButton1)
        Me.Controls.Add(Me.ContainingButton2)
        Me.Controls.Add(Me.Browse1)
        Me.Controls.Add(Me.Browse2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.SaveCountTextBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.OverwriteComboBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.AutosaveF1TextBox)
        Me.Controls.Add(Me.AutosaveF1Label)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SaveTimeLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CurrentTimeLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(3000, 3000)
        Me.MinimumSize = New System.Drawing.Size(865, 418)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Autosaver"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CurrentTimeLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveTimer As Timer
    Friend WithEvents CurrentTimer As Timer
    Friend WithEvents SaveTimeLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents AutosaveF1Label As Label
    Friend WithEvents AutosaveF1TextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents OverwriteComboBox As ComboBox
    Friend WithEvents SaveCountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Browse2 As System.Windows.Forms.Button
    Friend WithEvents Browse1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContainingButton2 As Button
    Friend WithEvents ContainingButton1 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents QuickSaveButton As Button
    Friend WithEvents StartButton As Button
    Friend WithEvents ChangeCountButton As Button
    Friend WithEvents OpenImageFileDialog As OpenFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents RoundRobinButton As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents SaveLimitTextBox As TextBox
    Friend WithEvents ChangeLimitButton As Button
    Private WithEvents Label2 As Label
    Friend WithEvents MinimizeToTrayButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SettingsButton As Button
    Friend WithEvents GameListButton As Button
    Friend WithEvents CounterSwitchButton As Button
    Friend WithEvents QuickLoadButton As Button
    Friend WithEvents HotkeysTimer As Timer
    Friend WithEvents SaveViewerButton As Button
End Class
