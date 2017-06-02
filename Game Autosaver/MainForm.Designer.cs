namespace GameAutosaver
{
    partial class MainForm
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GameListButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.MinimizeToTrayButton = new System.Windows.Forms.Button();
            this.ContainingButton1 = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.QuickSaveButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ChangeLimitButton = new System.Windows.Forms.Button();
            this.RoundRobinButton = new System.Windows.Forms.Button();
            this.ChangeCountButton = new System.Windows.Forms.Button();
            this.ContainingButton2 = new System.Windows.Forms.Button();
            this.CounterSwitchButton = new System.Windows.Forms.Button();
            this.SaveViewerButton = new System.Windows.Forms.Button();
            this.QuickLoadButton = new System.Windows.Forms.Button();
            this.Browse1 = new System.Windows.Forms.Button();
            this.Browse2 = new System.Windows.Forms.Button();
            this.OverwriteComboBox = new System.Windows.Forms.ComboBox();
            this.AutosaveF1TextBox = new System.Windows.Forms.TextBox();
            this.OpenImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveLimitTextBox = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.HotkeysTimer = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.SaveCountTextBox = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.AutosaveF1Label = new System.Windows.Forms.Label();
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentTimer = new System.Windows.Forms.Timer(this.components);
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveTimeLabel = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.GameListButton);
            this.Panel2.Controls.Add(this.SettingsButton);
            this.Panel2.Controls.Add(this.Label6);
            this.Panel2.Controls.Add(this.MinimizeToTrayButton);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Margin = new System.Windows.Forms.Padding(0);
            this.Panel2.MinimumSize = new System.Drawing.Size(827, 42);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(857, 42);
            this.Panel2.TabIndex = 104;
            // 
            // GameListButton
            // 
            this.GameListButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GameListButton.Location = new System.Drawing.Point(46, 0);
            this.GameListButton.Margin = new System.Windows.Forms.Padding(0);
            this.GameListButton.Name = "GameListButton";
            this.GameListButton.Size = new System.Drawing.Size(89, 42);
            this.GameListButton.TabIndex = 82;
            this.GameListButton.Text = "Game List";
            this.ToolTip1.SetToolTip(this.GameListButton, "Load and create new game save configs");
            this.GameListButton.UseVisualStyleBackColor = true;
            this.GameListButton.Click += new System.EventHandler(this.GameListButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SettingsButton.Location = new System.Drawing.Point(0, 0);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(46, 42);
            this.SettingsButton.TabIndex = 81;
            this.ToolTip1.SetToolTip(this.SettingsButton, "Change other settings");
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(157, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(522, 29);
            this.Label6.TabIndex = 13;
            this.Label6.Text = "GAME AUTOSAVER";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // MinimizeToTrayButton
            // 
            this.MinimizeToTrayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeToTrayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeToTrayButton.Location = new System.Drawing.Point(711, 0);
            this.MinimizeToTrayButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeToTrayButton.MaximumSize = new System.Drawing.Size(0, 42);
            this.MinimizeToTrayButton.MinimumSize = new System.Drawing.Size(146, 42);
            this.MinimizeToTrayButton.Name = "MinimizeToTrayButton";
            this.MinimizeToTrayButton.Size = new System.Drawing.Size(146, 42);
            this.MinimizeToTrayButton.TabIndex = 66;
            this.MinimizeToTrayButton.Text = "Minimize To Tray";
            this.ToolTip1.SetToolTip(this.MinimizeToTrayButton, "Click to minimize to tray");
            this.MinimizeToTrayButton.UseVisualStyleBackColor = true;
            this.MinimizeToTrayButton.Click += new System.EventHandler(this.MinimizeToTrayButton_Click);
            // 
            // ContainingButton1
            // 
            this.ContainingButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainingButton1.Location = new System.Drawing.Point(0, 100);
            this.ContainingButton1.Margin = new System.Windows.Forms.Padding(0);
            this.ContainingButton1.Name = "ContainingButton1";
            this.ContainingButton1.Size = new System.Drawing.Size(69, 27);
            this.ContainingButton1.TabIndex = 100;
            this.ContainingButton1.Text = "Open";
            this.ToolTip1.SetToolTip(this.ContainingButton1, "Open the directory");
            this.ContainingButton1.UseVisualStyleBackColor = true;
            this.ContainingButton1.Click += new System.EventHandler(this.ContainingButton1_Click);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 30000;
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // QuickSaveButton
            // 
            this.QuickSaveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.QuickSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickSaveButton.Location = new System.Drawing.Point(0, 0);
            this.QuickSaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.QuickSaveButton.MaximumSize = new System.Drawing.Size(137, 50);
            this.QuickSaveButton.MinimumSize = new System.Drawing.Size(137, 50);
            this.QuickSaveButton.Name = "QuickSaveButton";
            this.QuickSaveButton.Size = new System.Drawing.Size(137, 50);
            this.QuickSaveButton.TabIndex = 69;
            this.QuickSaveButton.Text = "Quick Save";
            this.ToolTip1.SetToolTip(this.QuickSaveButton, "Click to create a quick save");
            this.QuickSaveButton.UseVisualStyleBackColor = true;
            this.QuickSaveButton.Click += new System.EventHandler(this.QuickSaveButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(0, 0);
            this.StartButton.Margin = new System.Windows.Forms.Padding(0);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(857, 50);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start Autosaving";
            this.ToolTip1.SetToolTip(this.StartButton, "Start or stop autosaving periodically");
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ChangeLimitButton
            // 
            this.ChangeLimitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeLimitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeLimitButton.Location = new System.Drawing.Point(787, 215);
            this.ChangeLimitButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ChangeLimitButton.Name = "ChangeLimitButton";
            this.ChangeLimitButton.Size = new System.Drawing.Size(55, 22);
            this.ChangeLimitButton.TabIndex = 109;
            this.ChangeLimitButton.Text = "Change";
            this.ToolTip1.SetToolTip(this.ChangeLimitButton, "When the save limit is hit then the saving will start from 1 again");
            this.ChangeLimitButton.UseVisualStyleBackColor = true;
            this.ChangeLimitButton.Click += new System.EventHandler(this.ChangeLimitButton_Click);
            // 
            // RoundRobinButton
            // 
            this.RoundRobinButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoundRobinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundRobinButton.Location = new System.Drawing.Point(706, 269);
            this.RoundRobinButton.Name = "RoundRobinButton";
            this.RoundRobinButton.Size = new System.Drawing.Size(136, 33);
            this.RoundRobinButton.TabIndex = 106;
            this.RoundRobinButton.Text = "Disabled";
            this.ToolTip1.SetToolTip(this.RoundRobinButton, "Enable or disable the overwriting of saved autosaves or quick saves.\r\n");
            this.RoundRobinButton.UseVisualStyleBackColor = true;
            this.RoundRobinButton.Click += new System.EventHandler(this.RoundRobinButton_Click);
            // 
            // ChangeCountButton
            // 
            this.ChangeCountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeCountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeCountButton.Location = new System.Drawing.Point(787, 241);
            this.ChangeCountButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ChangeCountButton.Name = "ChangeCountButton";
            this.ChangeCountButton.Size = new System.Drawing.Size(55, 22);
            this.ChangeCountButton.TabIndex = 101;
            this.ChangeCountButton.Text = "Change";
            this.ToolTip1.SetToolTip(this.ChangeCountButton, "Change the autosave count to be affixed to the autosaves");
            this.ChangeCountButton.UseVisualStyleBackColor = true;
            this.ChangeCountButton.Click += new System.EventHandler(this.ChangeCountButton_Click);
            // 
            // ContainingButton2
            // 
            this.ContainingButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainingButton2.Location = new System.Drawing.Point(0, 174);
            this.ContainingButton2.Margin = new System.Windows.Forms.Padding(0);
            this.ContainingButton2.Name = "ContainingButton2";
            this.ContainingButton2.Size = new System.Drawing.Size(69, 27);
            this.ContainingButton2.TabIndex = 99;
            this.ContainingButton2.Text = "Open";
            this.ToolTip1.SetToolTip(this.ContainingButton2, "Open the directory");
            this.ContainingButton2.UseVisualStyleBackColor = true;
            this.ContainingButton2.Click += new System.EventHandler(this.ContainingButton2_Click);
            // 
            // CounterSwitchButton
            // 
            this.CounterSwitchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CounterSwitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CounterSwitchButton.Location = new System.Drawing.Point(646, 241);
            this.CounterSwitchButton.Name = "CounterSwitchButton";
            this.CounterSwitchButton.Size = new System.Drawing.Size(75, 22);
            this.CounterSwitchButton.TabIndex = 110;
            this.CounterSwitchButton.Text = "autosave";
            this.ToolTip1.SetToolTip(this.CounterSwitchButton, "Toggle to view and change next quick save or autosave count");
            this.CounterSwitchButton.UseVisualStyleBackColor = true;
            this.CounterSwitchButton.Click += new System.EventHandler(this.CounterSwitchButton_Click);
            // 
            // SaveViewerButton
            // 
            this.SaveViewerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveViewerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveViewerButton.Location = new System.Drawing.Point(0, 290);
            this.SaveViewerButton.Margin = new System.Windows.Forms.Padding(0);
            this.SaveViewerButton.Name = "SaveViewerButton";
            this.SaveViewerButton.Size = new System.Drawing.Size(137, 48);
            this.SaveViewerButton.TabIndex = 102;
            this.SaveViewerButton.Text = "Save List";
            this.ToolTip1.SetToolTip(this.SaveViewerButton, "Shows a list of your autosaves or quick saves to load, delete, or view");
            this.SaveViewerButton.UseVisualStyleBackColor = true;
            this.SaveViewerButton.Click += new System.EventHandler(this.SaveViewerButton_Click);
            // 
            // QuickLoadButton
            // 
            this.QuickLoadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.QuickLoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickLoadButton.Location = new System.Drawing.Point(720, 0);
            this.QuickLoadButton.Margin = new System.Windows.Forms.Padding(0);
            this.QuickLoadButton.MaximumSize = new System.Drawing.Size(137, 50);
            this.QuickLoadButton.MinimumSize = new System.Drawing.Size(137, 50);
            this.QuickLoadButton.Name = "QuickLoadButton";
            this.QuickLoadButton.Size = new System.Drawing.Size(137, 50);
            this.QuickLoadButton.TabIndex = 70;
            this.QuickLoadButton.Text = "Quick Load";
            this.ToolTip1.SetToolTip(this.QuickLoadButton, "Click to replace your game save with your last quick save");
            this.QuickLoadButton.UseVisualStyleBackColor = true;
            this.QuickLoadButton.Click += new System.EventHandler(this.QuickLoad);
            // 
            // Browse1
            // 
            this.Browse1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Browse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse1.Location = new System.Drawing.Point(754, 100);
            this.Browse1.Margin = new System.Windows.Forms.Padding(0);
            this.Browse1.Name = "Browse1";
            this.Browse1.Size = new System.Drawing.Size(103, 27);
            this.Browse1.TabIndex = 98;
            this.Browse1.Text = "Browse";
            this.ToolTip1.SetToolTip(this.Browse1, "Browse for directory to use");
            this.Browse1.UseVisualStyleBackColor = true;
            this.Browse1.Click += new System.EventHandler(this.Browse1_Click);
            // 
            // Browse2
            // 
            this.Browse2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Browse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse2.Location = new System.Drawing.Point(754, 174);
            this.Browse2.Margin = new System.Windows.Forms.Padding(0);
            this.Browse2.Name = "Browse2";
            this.Browse2.Size = new System.Drawing.Size(103, 27);
            this.Browse2.TabIndex = 97;
            this.Browse2.Text = "Browse";
            this.ToolTip1.SetToolTip(this.Browse2, "Browse for directory to use");
            this.Browse2.UseVisualStyleBackColor = true;
            this.Browse2.Click += new System.EventHandler(this.Browse2_Click);
            // 
            // OverwriteComboBox
            // 
            this.OverwriteComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OverwriteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OverwriteComboBox.Enabled = false;
            this.OverwriteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverwriteComboBox.FormattingEnabled = true;
            this.OverwriteComboBox.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.OverwriteComboBox.Location = new System.Drawing.Point(787, 308);
            this.OverwriteComboBox.Name = "OverwriteComboBox";
            this.OverwriteComboBox.Size = new System.Drawing.Size(55, 24);
            this.OverwriteComboBox.TabIndex = 92;
            this.ToolTip1.SetToolTip(this.OverwriteComboBox, "Enable or disable overwriting of existing saves of the same name");
            // 
            // AutosaveF1TextBox
            // 
            this.AutosaveF1TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AutosaveF1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutosaveF1TextBox.Location = new System.Drawing.Point(168, 260);
            this.AutosaveF1TextBox.Name = "AutosaveF1TextBox";
            this.AutosaveF1TextBox.ReadOnly = true;
            this.AutosaveF1TextBox.Size = new System.Drawing.Size(55, 22);
            this.AutosaveF1TextBox.TabIndex = 90;
            this.AutosaveF1TextBox.Text = "0";
            this.AutosaveF1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip1.SetToolTip(this.AutosaveF1TextBox, "An autosave was not saved due to a directory not existing or some other IO relate" +
        "d error");
            this.AutosaveF1TextBox.Visible = false;
            // 
            // OpenImageFileDialog
            // 
            this.OpenImageFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp, *.gif, *.tif, *.tiff, *.jpe, *.jp2, *.j" +
    "px, *.j2k, *.j2c)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.jpe;*.jp2;*.jpx;" +
    "*.j2k;*.j2c";
            // 
            // SaveLimitTextBox
            // 
            this.SaveLimitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLimitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLimitTextBox.Location = new System.Drawing.Point(722, 215);
            this.SaveLimitTextBox.Name = "SaveLimitTextBox";
            this.SaveLimitTextBox.ReadOnly = true;
            this.SaveLimitTextBox.Size = new System.Drawing.Size(62, 22);
            this.SaveLimitTextBox.TabIndex = 108;
            this.SaveLimitTextBox.Text = "None";
            this.SaveLimitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(616, 218);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(94, 16);
            this.Label7.TabIndex = 107;
            this.Label7.Text = "Autosave limit:";
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(616, 278);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(84, 16);
            this.Label4.TabIndex = 105;
            this.Label4.Text = "Round robin:";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.QuickLoadButton);
            this.Panel1.Controls.Add(this.QuickSaveButton);
            this.Panel1.Controls.Add(this.StartButton);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 338);
            this.Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.Panel1.MinimumSize = new System.Drawing.Size(821, 50);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(857, 50);
            this.Panel1.TabIndex = 103;
            // 
            // HotkeysTimer
            // 
            this.HotkeysTimer.Tick += new System.EventHandler(this.HotkeysTimer_Tick);
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.Text = "Game Autosaver";
            this.NotifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // Label11
            // 
            this.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(462, 239);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(54, 16);
            this.Label11.TabIndex = 96;
            this.Label11.Text = "Minutes";
            // 
            // Label10
            // 
            this.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(213, 235);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(136, 20);
            this.Label10.TabIndex = 95;
            this.Label10.Text = "Autosave Interval:";
            // 
            // SaveCountTextBox
            // 
            this.SaveCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCountTextBox.Location = new System.Drawing.Point(722, 241);
            this.SaveCountTextBox.Name = "SaveCountTextBox";
            this.SaveCountTextBox.ReadOnly = true;
            this.SaveCountTextBox.Size = new System.Drawing.Size(62, 22);
            this.SaveCountTextBox.TabIndex = 94;
            this.SaveCountTextBox.Text = "1";
            this.SaveCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(612, 244);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(35, 16);
            this.Label9.TabIndex = 93;
            this.Label9.Text = "Next";
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(616, 312);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(155, 16);
            this.Label8.TabIndex = 91;
            this.Label8.Text = "Overwrite existing saves:";
            // 
            // AutosaveF1Label
            // 
            this.AutosaveF1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AutosaveF1Label.AutoSize = true;
            this.AutosaveF1Label.BackColor = System.Drawing.Color.Red;
            this.AutosaveF1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutosaveF1Label.Location = new System.Drawing.Point(5, 262);
            this.AutosaveF1Label.Name = "AutosaveF1Label";
            this.AutosaveF1Label.Size = new System.Drawing.Size(161, 16);
            this.AutosaveF1Label.TabIndex = 89;
            this.AutosaveF1Label.Text = "Save failures (System IO):";
            this.AutosaveF1Label.Visible = false;
            // 
            // SaveTimer
            // 
            this.SaveTimer.Interval = 1000;
            this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // CurrentTimer
            // 
            this.CurrentTimer.Tick += new System.EventHandler(this.CurrentTimer_Tick);
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown1.Location = new System.Drawing.Point(388, 233);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            1380,
            0,
            0,
            0});
            this.NumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(68, 26);
            this.NumericUpDown1.TabIndex = 88;
            this.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(242, 298);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(107, 18);
            this.Label5.TabIndex = 87;
            this.Label5.Text = "Next Autosave:";
            // 
            // SaveTimeLabel
            // 
            this.SaveTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveTimeLabel.AutoSize = true;
            this.SaveTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveTimeLabel.Location = new System.Drawing.Point(378, 296);
            this.SaveTimeLabel.Name = "SaveTimeLabel";
            this.SaveTimeLabel.Size = new System.Drawing.Size(50, 20);
            this.SaveTimeLabel.TabIndex = 86;
            this.SaveTimeLabel.Text = "Never";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(256, 269);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(93, 18);
            this.Label3.TabIndex = 85;
            this.Label3.Text = "Current time:";
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeLabel.Location = new System.Drawing.Point(378, 269);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(78, 20);
            this.CurrentTimeLabel.TabIndex = 84;
            this.CurrentTimeLabel.Text = "Time Now";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(36, 148);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(313, 18);
            this.Label2.TabIndex = 83;
            this.Label2.Text = "Specify directory for autosaves to be stored in:";
            // 
            // TextBox2
            // 
            this.TextBox2.AllowDrop = true;
            this.TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox2.Location = new System.Drawing.Point(69, 175);
            this.TextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(685, 26);
            this.TextBox2.TabIndex = 3;
            this.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            this.TextBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Directory_DragDrop);
            this.TextBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Directory_DragEnter);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(36, 74);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(367, 18);
            this.Label1.TabIndex = 81;
            this.Label1.Text = "Specify game save directory contents to be autosaved:";
            // 
            // TextBox1
            // 
            this.TextBox1.AllowDrop = true;
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.Location = new System.Drawing.Point(69, 101);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(685, 26);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Directory_DragDrop);
            this.TextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Directory_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 388);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.ContainingButton1);
            this.Controls.Add(this.ChangeLimitButton);
            this.Controls.Add(this.RoundRobinButton);
            this.Controls.Add(this.ChangeCountButton);
            this.Controls.Add(this.ContainingButton2);
            this.Controls.Add(this.CounterSwitchButton);
            this.Controls.Add(this.SaveViewerButton);
            this.Controls.Add(this.SaveLimitTextBox);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Browse1);
            this.Controls.Add(this.Browse2);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.SaveCountTextBox);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.OverwriteComboBox);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.AutosaveF1TextBox);
            this.Controls.Add(this.AutosaveF1Label);
            this.Controls.Add(this.NumericUpDown1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.SaveTimeLabel);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3000, 3000);
            this.MinimumSize = new System.Drawing.Size(865, 418);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Autosaver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeBegin += new System.EventHandler(this.NewScreen_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.NewScreen_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button GameListButton;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Button SettingsButton;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button MinimizeToTrayButton;
        internal System.Windows.Forms.Button ContainingButton1;
        internal System.Windows.Forms.Button QuickSaveButton;
        internal System.Windows.Forms.Button StartButton;
        internal System.Windows.Forms.Button ChangeLimitButton;
        internal System.Windows.Forms.Button RoundRobinButton;
        internal System.Windows.Forms.Button ChangeCountButton;
        internal System.Windows.Forms.Button ContainingButton2;
        internal System.Windows.Forms.Button CounterSwitchButton;
        internal System.Windows.Forms.Button SaveViewerButton;
        internal System.Windows.Forms.Button QuickLoadButton;
        internal System.Windows.Forms.Button Browse1;
        internal System.Windows.Forms.Button Browse2;
        internal System.Windows.Forms.ComboBox OverwriteComboBox;
        internal System.Windows.Forms.TextBox AutosaveF1TextBox;
        internal System.Windows.Forms.OpenFileDialog OpenImageFileDialog;
        internal System.Windows.Forms.TextBox SaveLimitTextBox;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Timer HotkeysTimer;
        internal System.Windows.Forms.NotifyIcon NotifyIcon1;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox SaveCountTextBox;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label AutosaveF1Label;
        internal System.Windows.Forms.Timer SaveTimer;
        internal System.Windows.Forms.Timer CurrentTimer;
        internal System.Windows.Forms.NumericUpDown NumericUpDown1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Label SaveTimeLabel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox1;
    }
}

