<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GameName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoadButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.RemoveButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GameSaveDirectory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AutosaveStorageDirectory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AutosaveInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveCounter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OverwriteSaves = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BackgroundImageLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoundRobinEnabled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AutosaveLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlternateSaveNowLocationEnabled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AlternateSaveNowLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuickSaveCounter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastQuickSavePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GameName, Me.LoadButton, Me.RemoveButton, Me.GameSaveDirectory, Me.AutosaveStorageDirectory, Me.AutosaveInterval, Me.SaveCounter, Me.OverwriteSaves, Me.BackgroundImageLoc, Me.RoundRobinEnabled, Me.AutosaveLimit, Me.AlternateSaveNowLocationEnabled, Me.AlternateSaveNowLocation, Me.QuickSaveCounter, Me.LastQuickSavePath})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(464, 596)
        Me.DataGridView1.TabIndex = 0
        '
        'GameName
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GameName.DefaultCellStyle = DataGridViewCellStyle2
        Me.GameName.HeaderText = "Name"
        Me.GameName.Name = "GameName"
        Me.GameName.ReadOnly = True
        Me.GameName.Width = 300
        '
        'LoadButton
        '
        Me.LoadButton.HeaderText = ""
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LoadButton.Text = "Load"
        Me.LoadButton.UseColumnTextForButtonValue = True
        Me.LoadButton.Width = 90
        '
        'RemoveButton
        '
        Me.RemoveButton.HeaderText = ""
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseColumnTextForButtonValue = True
        Me.RemoveButton.Width = 70
        '
        'GameSaveDirectory
        '
        Me.GameSaveDirectory.HeaderText = "Game Save Directory"
        Me.GameSaveDirectory.Name = "GameSaveDirectory"
        Me.GameSaveDirectory.Visible = False
        Me.GameSaveDirectory.Width = 250
        '
        'AutosaveStorageDirectory
        '
        Me.AutosaveStorageDirectory.HeaderText = "Autosave Storage Directory"
        Me.AutosaveStorageDirectory.Name = "AutosaveStorageDirectory"
        Me.AutosaveStorageDirectory.Visible = False
        Me.AutosaveStorageDirectory.Width = 250
        '
        'AutosaveInterval
        '
        Me.AutosaveInterval.HeaderText = "Interval"
        Me.AutosaveInterval.Name = "AutosaveInterval"
        Me.AutosaveInterval.Visible = False
        Me.AutosaveInterval.Width = 50
        '
        'SaveCounter
        '
        Me.SaveCounter.HeaderText = "Counter"
        Me.SaveCounter.Name = "SaveCounter"
        Me.SaveCounter.Visible = False
        Me.SaveCounter.Width = 50
        '
        'OverwriteSaves
        '
        Me.OverwriteSaves.HeaderText = "Overwrite Saves"
        Me.OverwriteSaves.Name = "OverwriteSaves"
        Me.OverwriteSaves.Visible = False
        Me.OverwriteSaves.Width = 50
        '
        'BackgroundImageLoc
        '
        Me.BackgroundImageLoc.HeaderText = "Background Image Location"
        Me.BackgroundImageLoc.Name = "BackgroundImageLoc"
        Me.BackgroundImageLoc.Visible = False
        Me.BackgroundImageLoc.Width = 250
        '
        'RoundRobinEnabled
        '
        Me.RoundRobinEnabled.HeaderText = "Round Robin"
        Me.RoundRobinEnabled.Name = "RoundRobinEnabled"
        Me.RoundRobinEnabled.Visible = False
        Me.RoundRobinEnabled.Width = 50
        '
        'AutosaveLimit
        '
        Me.AutosaveLimit.HeaderText = "Autosave Limit"
        Me.AutosaveLimit.Name = "AutosaveLimit"
        Me.AutosaveLimit.Visible = False
        '
        'AlternateSaveNowLocationEnabled
        '
        Me.AlternateSaveNowLocationEnabled.HeaderText = "Alternate ""Save Now"" Location Enabled"
        Me.AlternateSaveNowLocationEnabled.Name = "AlternateSaveNowLocationEnabled"
        Me.AlternateSaveNowLocationEnabled.Visible = False
        '
        'AlternateSaveNowLocation
        '
        Me.AlternateSaveNowLocation.HeaderText = "Alternate ""Save Now"" Location"
        Me.AlternateSaveNowLocation.Name = "AlternateSaveNowLocation"
        Me.AlternateSaveNowLocation.Visible = False
        '
        'QuickSaveCounter
        '
        Me.QuickSaveCounter.HeaderText = "QuickSaveCounter"
        Me.QuickSaveCounter.Name = "QuickSaveCounter"
        Me.QuickSaveCounter.Visible = False
        '
        'LastQuickSavePath
        '
        Me.LastQuickSavePath.HeaderText = "LastQuickSavePath"
        Me.LastQuickSavePath.Name = "LastQuickSavePath"
        Me.LastQuickSavePath.Visible = False
        '
        'NewButton
        '
        Me.NewButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.Location = New System.Drawing.Point(0, 552)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(464, 44)
        Me.NewButton.TabIndex = 1
        Me.NewButton.Text = "New"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'GameList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 596)
        Me.Controls.Add(Me.NewButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "GameList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Games List"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NewButton As Button
    Friend WithEvents LastQuickSavePath As DataGridViewTextBoxColumn
    Friend WithEvents QuickSaveCounter As DataGridViewTextBoxColumn
    Friend WithEvents AlternateSaveNowLocation As DataGridViewTextBoxColumn
    Friend WithEvents AlternateSaveNowLocationEnabled As DataGridViewCheckBoxColumn
    Friend WithEvents AutosaveLimit As DataGridViewTextBoxColumn
    Friend WithEvents RoundRobinEnabled As DataGridViewCheckBoxColumn
    Friend WithEvents BackgroundImageLoc As DataGridViewTextBoxColumn
    Friend WithEvents OverwriteSaves As DataGridViewCheckBoxColumn
    Friend WithEvents SaveCounter As DataGridViewTextBoxColumn
    Friend WithEvents AutosaveInterval As DataGridViewTextBoxColumn
    Friend WithEvents AutosaveStorageDirectory As DataGridViewTextBoxColumn
    Friend WithEvents GameSaveDirectory As DataGridViewTextBoxColumn
    Friend WithEvents RemoveButton As DataGridViewButtonColumn
    Friend WithEvents LoadButton As DataGridViewButtonColumn
    Friend WithEvents GameName As DataGridViewTextBoxColumn
End Class
