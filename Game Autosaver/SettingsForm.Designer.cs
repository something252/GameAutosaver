namespace GameAutosaver
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Label2 = new System.Windows.Forms.Label();
            this.AltSaveNowLocTextBox = new System.Windows.Forms.TextBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.AltSaveNowLocBrowseButton = new System.Windows.Forms.Button();
            this.AltSaveNowLocCheckBox = new System.Windows.Forms.CheckBox();
            this.QuickLoadHotkeyTextBox = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.QuickSaveHotkeyTextBox = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RecycleDelete2RadioButton = new System.Windows.Forms.RadioButton();
            this.PermaDelete2RadioButton = new System.Windows.Forms.RadioButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.RecycleDelete1RadioButton = new System.Windows.Forms.RadioButton();
            this.PermaDelete1RadioButton = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SimpleOverwritingCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.BackgroundImageButton = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.BackupQuickLoadCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetIntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.AboutButton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox5.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.LightGray;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(178, 14);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(184, 18);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Game Specific Settings";
            // 
            // AltSaveNowLocTextBox
            // 
            this.AltSaveNowLocTextBox.AllowDrop = true;
            this.AltSaveNowLocTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AltSaveNowLocTextBox.Location = new System.Drawing.Point(3, 44);
            this.AltSaveNowLocTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AltSaveNowLocTextBox.Name = "AltSaveNowLocTextBox";
            this.AltSaveNowLocTextBox.Size = new System.Drawing.Size(452, 24);
            this.AltSaveNowLocTextBox.TabIndex = 1;
            this.AltSaveNowLocTextBox.TextChanged += new System.EventHandler(this.AltSaveNowLocTextBox_TextChanged);
            this.AltSaveNowLocTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Directory_DragDrop);
            this.AltSaveNowLocTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Directory_DragEnter);
            // 
            // GroupBox5
            // 
            this.GroupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox5.Controls.Add(this.AltSaveNowLocBrowseButton);
            this.GroupBox5.Controls.Add(this.AltSaveNowLocTextBox);
            this.GroupBox5.Controls.Add(this.AltSaveNowLocCheckBox);
            this.GroupBox5.Location = new System.Drawing.Point(9, 33);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(521, 77);
            this.GroupBox5.TabIndex = 5;
            this.GroupBox5.TabStop = false;
            // 
            // AltSaveNowLocBrowseButton
            // 
            this.AltSaveNowLocBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AltSaveNowLocBrowseButton.Location = new System.Drawing.Point(455, 44);
            this.AltSaveNowLocBrowseButton.Margin = new System.Windows.Forms.Padding(0);
            this.AltSaveNowLocBrowseButton.Name = "AltSaveNowLocBrowseButton";
            this.AltSaveNowLocBrowseButton.Size = new System.Drawing.Size(63, 24);
            this.AltSaveNowLocBrowseButton.TabIndex = 2;
            this.AltSaveNowLocBrowseButton.Text = "Browse";
            this.ToolTip1.SetToolTip(this.AltSaveNowLocBrowseButton, "Browse for a directory to use");
            this.AltSaveNowLocBrowseButton.UseVisualStyleBackColor = true;
            this.AltSaveNowLocBrowseButton.Click += new System.EventHandler(this.AltSaveNowLocBrowseButton_Click);
            // 
            // AltSaveNowLocCheckBox
            // 
            this.AltSaveNowLocCheckBox.AutoSize = true;
            this.AltSaveNowLocCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AltSaveNowLocCheckBox.Location = new System.Drawing.Point(136, 19);
            this.AltSaveNowLocCheckBox.Name = "AltSaveNowLocCheckBox";
            this.AltSaveNowLocCheckBox.Size = new System.Drawing.Size(250, 22);
            this.AltSaveNowLocCheckBox.TabIndex = 0;
            this.AltSaveNowLocCheckBox.Text = "Use alternate Quick Save location";
            this.ToolTip1.SetToolTip(this.AltSaveNowLocCheckBox, "When activated, quick saving will create a save in a different specified director" +
        "y.");
            this.AltSaveNowLocCheckBox.UseVisualStyleBackColor = true;
            this.AltSaveNowLocCheckBox.CheckedChanged += new System.EventHandler(this.AltSaveNowLocCheckBox_CheckedChanged);
            // 
            // QuickLoadHotkeyTextBox
            // 
            this.QuickLoadHotkeyTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.QuickLoadHotkeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickLoadHotkeyTextBox.Location = new System.Drawing.Point(92, 67);
            this.QuickLoadHotkeyTextBox.Name = "QuickLoadHotkeyTextBox";
            this.QuickLoadHotkeyTextBox.ReadOnly = true;
            this.QuickLoadHotkeyTextBox.Size = new System.Drawing.Size(80, 21);
            this.QuickLoadHotkeyTextBox.TabIndex = 5;
            this.QuickLoadHotkeyTextBox.Enter += new System.EventHandler(this.HotkeyTextBox_Enter);
            this.QuickLoadHotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyTextBoxes);
            this.QuickLoadHotkeyTextBox.Leave += new System.EventHandler(this.HotkeyTextBox_Leave);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(14, 70);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 15);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Quick Load:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(179, 14);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 15);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "(Esc to clear)";
            // 
            // QuickSaveHotkeyTextBox
            // 
            this.QuickSaveHotkeyTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.QuickSaveHotkeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickSaveHotkeyTextBox.Location = new System.Drawing.Point(92, 40);
            this.QuickSaveHotkeyTextBox.Name = "QuickSaveHotkeyTextBox";
            this.QuickSaveHotkeyTextBox.ReadOnly = true;
            this.QuickSaveHotkeyTextBox.Size = new System.Drawing.Size(80, 21);
            this.QuickSaveHotkeyTextBox.TabIndex = 2;
            this.QuickSaveHotkeyTextBox.Enter += new System.EventHandler(this.HotkeyTextBox_Enter);
            this.QuickSaveHotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyTextBoxes);
            this.QuickSaveHotkeyTextBox.Leave += new System.EventHandler(this.HotkeyTextBox_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(15, 43);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 15);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Quick Save:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(99, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 18);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Hotkeys";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.QuickLoadHotkeyTextBox);
            this.GroupBox7.Controls.Add(this.Label6);
            this.GroupBox7.Controls.Add(this.Label5);
            this.GroupBox7.Controls.Add(this.QuickSaveHotkeyTextBox);
            this.GroupBox7.Controls.Add(this.Label4);
            this.GroupBox7.Controls.Add(this.Label3);
            this.GroupBox7.Location = new System.Drawing.Point(6, 231);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(266, 98);
            this.GroupBox7.TabIndex = 6;
            this.GroupBox7.TabStop = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(80, 7);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(117, 18);
            this.Label7.TabIndex = 9;
            this.Label7.Text = "Save list deleting";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RecycleDelete2RadioButton);
            this.GroupBox2.Controls.Add(this.PermaDelete2RadioButton);
            this.GroupBox2.Location = new System.Drawing.Point(7, 22);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(251, 40);
            this.GroupBox2.TabIndex = 8;
            this.GroupBox2.TabStop = false;
            // 
            // RecycleDelete2RadioButton
            // 
            this.RecycleDelete2RadioButton.AutoSize = true;
            this.RecycleDelete2RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecycleDelete2RadioButton.Location = new System.Drawing.Point(138, 14);
            this.RecycleDelete2RadioButton.Name = "RecycleDelete2RadioButton";
            this.RecycleDelete2RadioButton.Size = new System.Drawing.Size(107, 19);
            this.RecycleDelete2RadioButton.TabIndex = 3;
            this.RecycleDelete2RadioButton.Text = "Recycle Delete";
            this.ToolTip1.SetToolTip(this.RecycleDelete2RadioButton, "Send removed saves from save list to recycle bin");
            this.RecycleDelete2RadioButton.UseVisualStyleBackColor = true;
            this.RecycleDelete2RadioButton.CheckedChanged += new System.EventHandler(this.RecycleDelete2RadioButton_CheckedChanged);
            // 
            // PermaDelete2RadioButton
            // 
            this.PermaDelete2RadioButton.AutoSize = true;
            this.PermaDelete2RadioButton.Checked = true;
            this.PermaDelete2RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PermaDelete2RadioButton.Location = new System.Drawing.Point(7, 14);
            this.PermaDelete2RadioButton.Name = "PermaDelete2RadioButton";
            this.PermaDelete2RadioButton.Size = new System.Drawing.Size(125, 19);
            this.PermaDelete2RadioButton.TabIndex = 2;
            this.PermaDelete2RadioButton.TabStop = true;
            this.PermaDelete2RadioButton.Text = "Permanent Delete";
            this.ToolTip1.SetToolTip(this.PermaDelete2RadioButton, "Permanently delete saves removed from save list");
            this.PermaDelete2RadioButton.UseVisualStyleBackColor = true;
            this.PermaDelete2RadioButton.CheckedChanged += new System.EventHandler(this.PermaDelete2RadioButton_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.RecycleDelete1RadioButton);
            this.GroupBox3.Controls.Add(this.PermaDelete1RadioButton);
            this.GroupBox3.Location = new System.Drawing.Point(7, 22);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(251, 40);
            this.GroupBox3.TabIndex = 6;
            this.GroupBox3.TabStop = false;
            // 
            // RecycleDelete1RadioButton
            // 
            this.RecycleDelete1RadioButton.AutoSize = true;
            this.RecycleDelete1RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecycleDelete1RadioButton.Location = new System.Drawing.Point(138, 14);
            this.RecycleDelete1RadioButton.Name = "RecycleDelete1RadioButton";
            this.RecycleDelete1RadioButton.Size = new System.Drawing.Size(107, 19);
            this.RecycleDelete1RadioButton.TabIndex = 3;
            this.RecycleDelete1RadioButton.Text = "Recycle Delete";
            this.ToolTip1.SetToolTip(this.RecycleDelete1RadioButton, "Send overwritten saves to recycle bin");
            this.RecycleDelete1RadioButton.UseVisualStyleBackColor = true;
            this.RecycleDelete1RadioButton.CheckedChanged += new System.EventHandler(this.RecycleDelete1RadioButton_CheckedChanged);
            // 
            // PermaDelete1RadioButton
            // 
            this.PermaDelete1RadioButton.AutoSize = true;
            this.PermaDelete1RadioButton.Checked = true;
            this.PermaDelete1RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PermaDelete1RadioButton.Location = new System.Drawing.Point(7, 14);
            this.PermaDelete1RadioButton.Name = "PermaDelete1RadioButton";
            this.PermaDelete1RadioButton.Size = new System.Drawing.Size(125, 19);
            this.PermaDelete1RadioButton.TabIndex = 2;
            this.PermaDelete1RadioButton.TabStop = true;
            this.PermaDelete1RadioButton.Text = "Permanent Delete";
            this.ToolTip1.SetToolTip(this.PermaDelete1RadioButton, "Permanently delete overwritten saves");
            this.PermaDelete1RadioButton.UseVisualStyleBackColor = true;
            this.PermaDelete1RadioButton.CheckedChanged += new System.EventHandler(this.PermaDelete1RadioButton_CheckedChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.LightGray;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(79, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(123, 18);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Global Settings";
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.SimpleOverwritingCheckBox);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Location = new System.Drawing.Point(4, 27);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(266, 70);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Overwriting";
            // 
            // SimpleOverwritingCheckBox
            // 
            this.SimpleOverwritingCheckBox.AutoSize = true;
            this.SimpleOverwritingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SimpleOverwritingCheckBox.Location = new System.Drawing.Point(44, 6);
            this.SimpleOverwritingCheckBox.Name = "SimpleOverwritingCheckBox";
            this.SimpleOverwritingCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SimpleOverwritingCheckBox.Size = new System.Drawing.Size(182, 22);
            this.SimpleOverwritingCheckBox.TabIndex = 5;
            this.SimpleOverwritingCheckBox.Text = "Simple save overwriting";
            this.ToolTip1.SetToolTip(this.SimpleOverwritingCheckBox, resources.GetString("SimpleOverwritingCheckBox.ToolTip"));
            this.SimpleOverwritingCheckBox.UseVisualStyleBackColor = true;
            this.SimpleOverwritingCheckBox.CheckedChanged += new System.EventHandler(this.SimpleOverwritingCheckBox_CheckedChanged);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.BackgroundImageButton);
            this.GroupBox6.Controls.Add(this.GroupBox5);
            this.GroupBox6.Controls.Add(this.Label2);
            this.GroupBox6.Location = new System.Drawing.Point(279, 0);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(538, 364);
            this.GroupBox6.TabIndex = 8;
            this.GroupBox6.TabStop = false;
            // 
            // BackgroundImageButton
            // 
            this.BackgroundImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackgroundImageButton.Location = new System.Drawing.Point(9, 126);
            this.BackgroundImageButton.Margin = new System.Windows.Forms.Padding(0);
            this.BackgroundImageButton.Name = "BackgroundImageButton";
            this.BackgroundImageButton.Size = new System.Drawing.Size(521, 42);
            this.BackgroundImageButton.TabIndex = 72;
            this.BackgroundImageButton.Text = "Background";
            this.ToolTip1.SetToolTip(this.BackgroundImageButton, "Set or reset the background image");
            this.BackgroundImageButton.UseVisualStyleBackColor = true;
            this.BackgroundImageButton.Click += new System.EventHandler(this.BackgroundImageButton_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.BackupQuickLoadCheckBox);
            this.GroupBox4.Controls.Add(this.ResetIntervalCheckBox);
            this.GroupBox4.Location = new System.Drawing.Point(6, 143);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(266, 87);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            // 
            // BackupQuickLoadCheckBox
            // 
            this.BackupQuickLoadCheckBox.AutoSize = true;
            this.BackupQuickLoadCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BackupQuickLoadCheckBox.Checked = true;
            this.BackupQuickLoadCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackupQuickLoadCheckBox.Location = new System.Drawing.Point(27, 61);
            this.BackupQuickLoadCheckBox.Name = "BackupQuickLoadCheckBox";
            this.BackupQuickLoadCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackupQuickLoadCheckBox.Size = new System.Drawing.Size(209, 22);
            this.BackupQuickLoadCheckBox.TabIndex = 7;
            this.BackupQuickLoadCheckBox.Text = "Backup save before loading";
            this.ToolTip1.SetToolTip(this.BackupQuickLoadCheckBox, "When enabled, loading will backup the game\'s save to a folder in the autosave sto" +
        "rage directory before overwriting begins");
            this.BackupQuickLoadCheckBox.UseVisualStyleBackColor = true;
            this.BackupQuickLoadCheckBox.CheckedChanged += new System.EventHandler(this.BackupQuickLoadCheckBox_CheckedChanged);
            // 
            // ResetIntervalCheckBox
            // 
            this.ResetIntervalCheckBox.AutoSize = true;
            this.ResetIntervalCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResetIntervalCheckBox.Checked = true;
            this.ResetIntervalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResetIntervalCheckBox.Location = new System.Drawing.Point(15, 15);
            this.ResetIntervalCheckBox.Name = "ResetIntervalCheckBox";
            this.ResetIntervalCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResetIntervalCheckBox.Size = new System.Drawing.Size(221, 40);
            this.ResetIntervalCheckBox.TabIndex = 5;
            this.ResetIntervalCheckBox.Text = "      Reset autosave interval\r\nwhen manually saving/loading";
            this.ToolTip1.SetToolTip(this.ResetIntervalCheckBox, "Reset the autosave interval when quick saving/loading, or loading from save list." +
        "\r\n");
            this.ResetIntervalCheckBox.UseVisualStyleBackColor = true;
            this.ResetIntervalCheckBox.CheckedChanged += new System.EventHandler(this.ResetIntervalCheckBox_CheckedChanged);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 30000;
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(0, 42);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(274, 101);
            this.TabControl1.TabIndex = 73;
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage2.Controls.Add(this.Label7);
            this.TabPage2.Controls.Add(this.GroupBox2);
            this.TabPage2.Location = new System.Drawing.Point(4, 27);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(266, 70);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Deleting";
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.Location = new System.Drawing.Point(0, 332);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(0);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(67, 32);
            this.AboutButton.TabIndex = 73;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TabControl1);
            this.GroupBox1.Controls.Add(this.GroupBox7);
            this.GroupBox1.Controls.Add(this.AboutButton);
            this.GroupBox1.Controls.Add(this.GroupBox6);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(818, 364);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 364);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox AltSaveNowLocTextBox;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button AltSaveNowLocBrowseButton;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.CheckBox AltSaveNowLocCheckBox;
        internal System.Windows.Forms.TextBox QuickLoadHotkeyTextBox;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox QuickSaveHotkeyTextBox;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton RecycleDelete2RadioButton;
        internal System.Windows.Forms.RadioButton PermaDelete2RadioButton;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.RadioButton RecycleDelete1RadioButton;
        internal System.Windows.Forms.RadioButton PermaDelete1RadioButton;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.CheckBox SimpleOverwritingCheckBox;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button BackgroundImageButton;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.CheckBox BackupQuickLoadCheckBox;
        internal System.Windows.Forms.CheckBox ResetIntervalCheckBox;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button AboutButton;
        internal System.Windows.Forms.GroupBox GroupBox1;
    }
}