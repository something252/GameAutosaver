namespace GameAutosaver
{
    partial class SavesViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SaveDataGridView = new System.Windows.Forms.DataGridView();
            this.GameName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleTypeButton = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveSaveButton = new System.Windows.Forms.Button();
            this.FileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.SaveDataGridView)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveDataGridView
            // 
            this.SaveDataGridView.AllowUserToAddRows = false;
            this.SaveDataGridView.AllowUserToDeleteRows = false;
            this.SaveDataGridView.AllowUserToResizeRows = false;
            this.SaveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SaveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameName,
            this.DateModified,
            this.LoadButton});
            this.SaveDataGridView.ContextMenuStrip = this.ContextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SaveDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveDataGridView.Location = new System.Drawing.Point(0, 36);
            this.SaveDataGridView.Name = "SaveDataGridView";
            this.SaveDataGridView.ReadOnly = true;
            this.SaveDataGridView.RowHeadersVisible = false;
            this.SaveDataGridView.Size = new System.Drawing.Size(513, 688);
            this.SaveDataGridView.TabIndex = 5;
            this.SaveDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SaveDataGridView_CellClick);
            this.SaveDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SaveDataGridView_CellMouseDown);
            this.SaveDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveDataGridView_KeyDown);
            // 
            // GameName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GameName.DefaultCellStyle = dataGridViewCellStyle1;
            this.GameName.HeaderText = "Name";
            this.GameName.Name = "GameName";
            this.GameName.ReadOnly = true;
            this.GameName.Width = 220;
            // 
            // DateModified
            // 
            this.DateModified.HeaderText = "Date modified";
            this.DateModified.Name = "DateModified";
            this.DateModified.ReadOnly = true;
            this.DateModified.Width = 160;
            // 
            // LoadButton
            // 
            this.LoadButton.HeaderText = "";
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.ReadOnly = true;
            this.LoadButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseColumnTextForButtonValue = true;
            this.LoadButton.Width = 130;
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenContainingFolderToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // OpenContainingFolderToolStripMenuItem
            // 
            this.OpenContainingFolderToolStripMenuItem.Name = "OpenContainingFolderToolStripMenuItem";
            this.OpenContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenContainingFolderToolStripMenuItem.Text = "Open";
            this.OpenContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenContainingFolderToolStripMenuItem_Click);
            // 
            // ToggleTypeButton
            // 
            this.ToggleTypeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToggleTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToggleTypeButton.Location = new System.Drawing.Point(0, 0);
            this.ToggleTypeButton.Name = "ToggleTypeButton";
            this.ToggleTypeButton.Size = new System.Drawing.Size(513, 36);
            this.ToggleTypeButton.TabIndex = 6;
            this.ToggleTypeButton.Text = "Autosaves";
            this.ToolTip1.SetToolTip(this.ToggleTypeButton, "Switch between autosave list and quick save list");
            this.ToggleTypeButton.UseVisualStyleBackColor = true;
            this.ToggleTypeButton.Click += new System.EventHandler(this.ToggleTypeButton_Click);
            // 
            // RemoveSaveButton
            // 
            this.RemoveSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSaveButton.Location = new System.Drawing.Point(379, 0);
            this.RemoveSaveButton.Name = "RemoveSaveButton";
            this.RemoveSaveButton.Size = new System.Drawing.Size(134, 36);
            this.RemoveSaveButton.TabIndex = 7;
            this.RemoveSaveButton.Text = "Remove";
            this.ToolTip1.SetToolTip(this.RemoveSaveButton, "Switch between autosave list and quick save list");
            this.RemoveSaveButton.UseVisualStyleBackColor = true;
            this.RemoveSaveButton.Click += new System.EventHandler(this.RemoveSaveButton_Click);
            // 
            // FileSystemWatcher1
            // 
            this.FileSystemWatcher1.EnableRaisingEvents = true;
            this.FileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.DirectoryName | System.IO.NotifyFilters.LastWrite)));
            this.FileSystemWatcher1.SynchronizingObject = this;
            this.FileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Created);
            this.FileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Deleted);
            this.FileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.FileSystemWatcher1_Renamed);
            // 
            // SavesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 724);
            this.Controls.Add(this.RemoveSaveButton);
            this.Controls.Add(this.SaveDataGridView);
            this.Controls.Add(this.ToggleTypeButton);
            this.MaximumSize = new System.Drawing.Size(521, 10000);
            this.MinimumSize = new System.Drawing.Size(521, 177);
            this.Name = "SavesViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saves List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SavesList_FormClosing);
            this.Load += new System.EventHandler(this.SavesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaveDataGridView)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView SaveDataGridView;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GameName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DateModified;
        internal System.Windows.Forms.DataGridViewButtonColumn LoadButton;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem OpenContainingFolderToolStripMenuItem;
        internal System.Windows.Forms.Button ToggleTypeButton;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Button RemoveSaveButton;
        internal System.IO.FileSystemWatcher FileSystemWatcher1;
    }
}