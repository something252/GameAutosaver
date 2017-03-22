<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SavesViewer
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SaveDataGridView = New System.Windows.Forms.DataGridView()
        Me.GameName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoadButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenContainingFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleTypeButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RemoveSaveButton = New System.Windows.Forms.Button()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        CType(Me.SaveDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveDataGridView
        '
        Me.SaveDataGridView.AllowUserToAddRows = False
        Me.SaveDataGridView.AllowUserToDeleteRows = False
        Me.SaveDataGridView.AllowUserToResizeRows = False
        Me.SaveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SaveDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GameName, Me.DateModified, Me.LoadButton})
        Me.SaveDataGridView.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SaveDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.SaveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveDataGridView.Location = New System.Drawing.Point(0, 36)
        Me.SaveDataGridView.Name = "SaveDataGridView"
        Me.SaveDataGridView.ReadOnly = True
        Me.SaveDataGridView.RowHeadersVisible = False
        Me.SaveDataGridView.Size = New System.Drawing.Size(513, 688)
        Me.SaveDataGridView.TabIndex = 1
        '
        'GameName
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GameName.DefaultCellStyle = DataGridViewCellStyle1
        Me.GameName.HeaderText = "Name"
        Me.GameName.Name = "GameName"
        Me.GameName.ReadOnly = True
        Me.GameName.Width = 220
        '
        'DateModified
        '
        Me.DateModified.HeaderText = "Date modified"
        Me.DateModified.Name = "DateModified"
        Me.DateModified.ReadOnly = True
        Me.DateModified.Width = 160
        '
        'LoadButton
        '
        Me.LoadButton.HeaderText = ""
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.ReadOnly = True
        Me.LoadButton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LoadButton.Text = "Load"
        Me.LoadButton.UseColumnTextForButtonValue = True
        Me.LoadButton.Width = 130
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenContainingFolderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 26)
        '
        'OpenContainingFolderToolStripMenuItem
        '
        Me.OpenContainingFolderToolStripMenuItem.Name = "OpenContainingFolderToolStripMenuItem"
        Me.OpenContainingFolderToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenContainingFolderToolStripMenuItem.Text = "Open"
        '
        'ToggleTypeButton
        '
        Me.ToggleTypeButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToggleTypeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToggleTypeButton.Location = New System.Drawing.Point(0, 0)
        Me.ToggleTypeButton.Name = "ToggleTypeButton"
        Me.ToggleTypeButton.Size = New System.Drawing.Size(513, 36)
        Me.ToggleTypeButton.TabIndex = 3
        Me.ToggleTypeButton.Text = "Autosaves"
        Me.ToolTip1.SetToolTip(Me.ToggleTypeButton, "Switch between autosave list and quick save list")
        Me.ToggleTypeButton.UseVisualStyleBackColor = True
        '
        'RemoveSaveButton
        '
        Me.RemoveSaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveSaveButton.Location = New System.Drawing.Point(379, 0)
        Me.RemoveSaveButton.Name = "RemoveSaveButton"
        Me.RemoveSaveButton.Size = New System.Drawing.Size(134, 36)
        Me.RemoveSaveButton.TabIndex = 4
        Me.RemoveSaveButton.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.RemoveSaveButton, "Switch between autosave list and quick save list")
        Me.RemoveSaveButton.UseVisualStyleBackColor = True
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.NotifyFilter = CType((System.IO.NotifyFilters.DirectoryName Or System.IO.NotifyFilters.LastWrite), System.IO.NotifyFilters)
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'SavesViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 724)
        Me.Controls.Add(Me.RemoveSaveButton)
        Me.Controls.Add(Me.SaveDataGridView)
        Me.Controls.Add(Me.ToggleTypeButton)
        Me.MaximumSize = New System.Drawing.Size(521, 10000)
        Me.MinimumSize = New System.Drawing.Size(521, 177)
        Me.Name = "SavesViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saves List"
        CType(Me.SaveDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveDataGridView As DataGridView
    Friend WithEvents ToggleTypeButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents GameName As DataGridViewTextBoxColumn
    Friend WithEvents DateModified As DataGridViewTextBoxColumn
    Friend WithEvents LoadButton As DataGridViewButtonColumn
    Friend WithEvents RemoveSaveButton As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents OpenContainingFolderToolStripMenuItem As ToolStripMenuItem
End Class
