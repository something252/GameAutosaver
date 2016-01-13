<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.SimpleOverwritingCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ResetIntervalCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RecycleDelete1RadioButton = New System.Windows.Forms.RadioButton()
        Me.PermaDelete1RadioButton = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AltSaveNowLocCheckBox = New System.Windows.Forms.CheckBox()
        Me.AltSaveNowLocBrowseButton = New System.Windows.Forms.Button()
        Me.BackgroundImageButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.AltSaveNowLocTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'SimpleOverwritingCheckBox
        '
        Me.SimpleOverwritingCheckBox.AutoSize = True
        Me.SimpleOverwritingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SimpleOverwritingCheckBox.Location = New System.Drawing.Point(25, 15)
        Me.SimpleOverwritingCheckBox.Name = "SimpleOverwritingCheckBox"
        Me.SimpleOverwritingCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SimpleOverwritingCheckBox.Size = New System.Drawing.Size(211, 22)
        Me.SimpleOverwritingCheckBox.TabIndex = 1
        Me.SimpleOverwritingCheckBox.Text = "Simple autosave overwriting"
        Me.ToolTip1.SetToolTip(Me.SimpleOverwritingCheckBox, resources.GetString("SimpleOverwritingCheckBox.ToolTip"))
        Me.SimpleOverwritingCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ResetIntervalCheckBox)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 113)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(266, 60)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'ResetIntervalCheckBox
        '
        Me.ResetIntervalCheckBox.AutoSize = True
        Me.ResetIntervalCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ResetIntervalCheckBox.Checked = True
        Me.ResetIntervalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ResetIntervalCheckBox.Location = New System.Drawing.Point(43, 15)
        Me.ResetIntervalCheckBox.Name = "ResetIntervalCheckBox"
        Me.ResetIntervalCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ResetIntervalCheckBox.Size = New System.Drawing.Size(180, 40)
        Me.ResetIntervalCheckBox.TabIndex = 5
        Me.ResetIntervalCheckBox.Text = "Reset autosave interval" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when manually saving"
        Me.ToolTip1.SetToolTip(Me.ResetIntervalCheckBox, resources.GetString("ResetIntervalCheckBox.ToolTip"))
        Me.ResetIntervalCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SimpleOverwritingCheckBox)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 79)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RecycleDelete1RadioButton)
        Me.GroupBox3.Controls.Add(Me.PermaDelete1RadioButton)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(251, 40)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'RecycleDelete1RadioButton
        '
        Me.RecycleDelete1RadioButton.AutoSize = True
        Me.RecycleDelete1RadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecycleDelete1RadioButton.Location = New System.Drawing.Point(138, 14)
        Me.RecycleDelete1RadioButton.Name = "RecycleDelete1RadioButton"
        Me.RecycleDelete1RadioButton.Size = New System.Drawing.Size(107, 19)
        Me.RecycleDelete1RadioButton.TabIndex = 3
        Me.RecycleDelete1RadioButton.Text = "Recycle Delete"
        Me.ToolTip1.SetToolTip(Me.RecycleDelete1RadioButton, "Send overwritten autosave to recycle bin")
        Me.RecycleDelete1RadioButton.UseVisualStyleBackColor = True
        '
        'PermaDelete1RadioButton
        '
        Me.PermaDelete1RadioButton.AutoSize = True
        Me.PermaDelete1RadioButton.Checked = True
        Me.PermaDelete1RadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PermaDelete1RadioButton.Location = New System.Drawing.Point(7, 14)
        Me.PermaDelete1RadioButton.Name = "PermaDelete1RadioButton"
        Me.PermaDelete1RadioButton.Size = New System.Drawing.Size(125, 19)
        Me.PermaDelete1RadioButton.TabIndex = 2
        Me.PermaDelete1RadioButton.TabStop = True
        Me.PermaDelete1RadioButton.Text = "Permanent Delete"
        Me.ToolTip1.SetToolTip(Me.PermaDelete1RadioButton, "Permanently delete the overwritten autosave")
        Me.PermaDelete1RadioButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'AltSaveNowLocCheckBox
        '
        Me.AltSaveNowLocCheckBox.AutoSize = True
        Me.AltSaveNowLocCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AltSaveNowLocCheckBox.Location = New System.Drawing.Point(136, 19)
        Me.AltSaveNowLocCheckBox.Name = "AltSaveNowLocCheckBox"
        Me.AltSaveNowLocCheckBox.Size = New System.Drawing.Size(252, 22)
        Me.AltSaveNowLocCheckBox.TabIndex = 0
        Me.AltSaveNowLocCheckBox.Text = "Use alternate ""Save Now"" location"
        Me.ToolTip1.SetToolTip(Me.AltSaveNowLocCheckBox, "When activated, if you click ""Save Now"" it will create an autosave in a seperate " &
        "directory that you specify.")
        Me.AltSaveNowLocCheckBox.UseVisualStyleBackColor = True
        '
        'AltSaveNowLocBrowseButton
        '
        Me.AltSaveNowLocBrowseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AltSaveNowLocBrowseButton.Location = New System.Drawing.Point(455, 44)
        Me.AltSaveNowLocBrowseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AltSaveNowLocBrowseButton.Name = "AltSaveNowLocBrowseButton"
        Me.AltSaveNowLocBrowseButton.Size = New System.Drawing.Size(63, 24)
        Me.AltSaveNowLocBrowseButton.TabIndex = 2
        Me.AltSaveNowLocBrowseButton.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.AltSaveNowLocBrowseButton, "Browse for a directory to use")
        Me.AltSaveNowLocBrowseButton.UseVisualStyleBackColor = True
        '
        'BackgroundImageButton
        '
        Me.BackgroundImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackgroundImageButton.Location = New System.Drawing.Point(9, 126)
        Me.BackgroundImageButton.Margin = New System.Windows.Forms.Padding(0)
        Me.BackgroundImageButton.Name = "BackgroundImageButton"
        Me.BackgroundImageButton.Size = New System.Drawing.Size(521, 42)
        Me.BackgroundImageButton.TabIndex = 72
        Me.BackgroundImageButton.Text = "Background"
        Me.ToolTip1.SetToolTip(Me.BackgroundImageButton, "Set the background to an image")
        Me.BackgroundImageButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AboutButton)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(818, 212)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BackgroundImageButton)
        Me.GroupBox6.Controls.Add(Me.GroupBox5)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Location = New System.Drawing.Point(279, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(538, 203)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.AltSaveNowLocBrowseButton)
        Me.GroupBox5.Controls.Add(Me.AltSaveNowLocTextBox)
        Me.GroupBox5.Controls.Add(Me.AltSaveNowLocCheckBox)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(521, 77)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'AltSaveNowLocTextBox
        '
        Me.AltSaveNowLocTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AltSaveNowLocTextBox.Location = New System.Drawing.Point(3, 44)
        Me.AltSaveNowLocTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.AltSaveNowLocTextBox.Name = "AltSaveNowLocTextBox"
        Me.AltSaveNowLocTextBox.Size = New System.Drawing.Size(452, 24)
        Me.AltSaveNowLocTextBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(150, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Save Config Specific Settings"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Global Settings"
        '
        'AboutButton
        '
        Me.AboutButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutButton.Location = New System.Drawing.Point(0, 180)
        Me.AboutButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(67, 32)
        Me.AboutButton.TabIndex = 73
        Me.AboutButton.Text = "About"
        Me.ToolTip1.SetToolTip(Me.AboutButton, "Set the background to an image")
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 212)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SimpleOverwritingCheckBox As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RecycleDelete1RadioButton As RadioButton
    Friend WithEvents PermaDelete1RadioButton As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ResetIntervalCheckBox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents AltSaveNowLocTextBox As TextBox
    Friend WithEvents AltSaveNowLocCheckBox As CheckBox
    Friend WithEvents AltSaveNowLocBrowseButton As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents BackgroundImageButton As Button
    Friend WithEvents AboutButton As Button
End Class
