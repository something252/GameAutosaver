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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NewButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GameName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoadButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.RemoveButton = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NewButton
        '
        Me.NewButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.Location = New System.Drawing.Point(0, 666)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(514, 44)
        Me.NewButton.TabIndex = 1
        Me.NewButton.Text = "New"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GameName, Me.LoadButton, Me.RemoveButton})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(514, 710)
        Me.DataGridView1.TabIndex = 0
        '
        'GameName
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GameName.DefaultCellStyle = DataGridViewCellStyle1
        Me.GameName.HeaderText = "Name"
        Me.GameName.Name = "GameName"
        Me.GameName.Width = 300
        '
        'LoadButton
        '
        Me.LoadButton.HeaderText = ""
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LoadButton.Text = "Load"
        Me.LoadButton.UseColumnTextForButtonValue = True
        Me.LoadButton.Width = 110
        '
        'RemoveButton
        '
        Me.RemoveButton.HeaderText = ""
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseColumnTextForButtonValue = True
        '
        'GameList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 710)
        Me.Controls.Add(Me.NewButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximumSize = New System.Drawing.Size(522, 10000)
        Me.MinimumSize = New System.Drawing.Size(522, 177)
        Me.Name = "GameList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Games List"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewButton As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GameName As DataGridViewTextBoxColumn
    Friend WithEvents LoadButton As DataGridViewButtonColumn
    Friend WithEvents RemoveButton As DataGridViewButtonColumn
End Class
