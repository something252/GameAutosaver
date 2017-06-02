using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace GameAutosaver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static MainForm thisForm;
        public static SavesViewer savesViewer;
        public static SettingsForm settingsForm;
        public static GameList gameList;
        public static TrayMenu trayMenu;
        public const string AutoSaveFileString = "Autosave";
        public const string QuickSaveFileString = "Quick Save";
        bool shownComplete = false;
        DateTime SaveTime;
        public object accessLock = new object();
        public object timer1Lock = new object();
        public Timer SaveTimerPtr;
        public bool HotkeysChangeLock = false; // locks hotkey usage after hotkeys have been changed in settings

        /// <summary>
        /// Game specific save data
        /// </summary>
        public static GameData Games;

        // start button click
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Text == "Start Autosaving" && !Directory.Exists(TextBox1.Text)) {
                Interaction.MsgBox("Game save directory does not exist!", MsgBoxStyle.Exclamation, "Error");
            } else if (StartButton.Text == "Start Autosaving" && !Directory.Exists(TextBox2.Text)) {
                Interaction.MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Exclamation, "Error");
            } else {
                Games.CurrentSettings.AutoSaveIntervalMinutes = Convert.ToInt32(NumericUpDown1.Value);
                Games.CurrentSettings.GameSaveDirectory = TextBox1.Text;
                Games.CurrentSettings.AutoSaveStorageDirectory = TextBox2.Text;
                SaveMySettings();

                if (StartButton.Text == "Start Autosaving") {
                    TextBox1.ReadOnly = true;
                    TextBox2.ReadOnly = true;
                    StartSaving();
                } else if (StartButton.Text == "Stop Autosaving") {
                    TextBox1.ReadOnly = false;
                    TextBox2.ReadOnly = false;
                    SaveTimerPtr.Stop();
                    Reset(); // reset settings
                }
            }
        }

        public void StartSaving()
        {
            lock (timer1Lock) {
                DateTime tmp = DateTime.Now;
                SaveTime = tmp.AddMinutes(Convert.ToDouble(NumericUpDown1.Value)); // Set save timer to x minutes from now
                SaveTimeLabel.Text = SaveTime.ToLongTimeString();
                NumericUpDown1.Enabled = false;

                SaveTimerPtr.Start();
                StartButton.Text = "Stop Autosaving";
                ChangeMainFormColors(Color.Red);
                NumericUpDown1.Enabled = false;
            }
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon_256;
            NotifyIcon1.Icon = Properties.Resources.Icon_256;
            SettingsButton.Image = Properties.Resources.Cog_Wheel;

            SaveTimerPtr = this.SaveTimer;
            thisForm = this;

            if (Properties.Settings.Default.Saves != null && Properties.Settings.Default.Saves.Length > 0) {
                Games = JsonConvert.DeserializeObject<GameData>(Properties.Settings.Default.Saves);
                Games.FinishedLoading();

                Games.LoadSave(thisForm, Games.CurrentName, true);
            } else {
                Games = new GameData();
                Games.FinishedLoading();
                Games.StartupLoadBlankSave(thisForm);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null; // focus nothing
            shownComplete = true;
        }

        public void MainForm_FormClosing(object sender = null, FormClosingEventArgs e = null)
        {
            //endThread = true // stop thread(s)
            HotkeysTimer.Stop();

            SaveMySettings();

            this.Show();
            this.WindowState = FormWindowState.Normal; // Unminimize Window
        }

        public void SaveMySettings()
        {
            Games.SaveCurrentSettings(thisForm);
            Properties.Settings.Default.Saves = JsonConvert.SerializeObject(Games);
            Properties.Settings.Default.Save();
        }

        private void Directory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] directories = ((string[])e.Data.GetData(DataFormats.FileDrop));

                if (Directory.Exists(directories[0])) {
                    ((TextBox)sender).Text = directories[0];
                    this.ActiveControl = null;
                }
            }
        }

        private void Directory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.All;
            }
        }

        public void QuickLoad(object sender = null, EventArgs e = null)
        {
            if (!Directory.Exists(Games.CurrentSettings.LastQuickSavePath)) {
                Interaction.MsgBox("Quick load failed!" + Environment.NewLine + Environment.NewLine + "quick save does not exist: " + "\"" + Games.CurrentSettings.LastQuickSavePath + "\"", MsgBoxStyle.Critical);
            } else {
                if (Properties.Settings.Default.ManualSaveResetInterval) {
                    lock (timer1Lock) {
                        if (StartButton.Text == "Stop Autosaving") { // currently autosaving
                            SaveTimerPtr.Stop();
                            ChangeMainFormColors(Color.Gold); // reset color
                            StartSaving();
                        }
                    }
                }

                try {
                    lock (timer1Lock) {
                        if (Directory.Exists(TextBox1.Text)) {

                            if (Properties.Settings.Default.BackupQuickLoad) { // if quick load backup enabled
                                TextBox2.Text = TextBox2.Text.TrimEnd('\\');

                                string BackupDestination = TextBox2.Text + "\\" + "Last Restore Temporary Backup";
                                if (Directory.Exists(BackupDestination)) {
                                    Directory.Delete(BackupDestination, true);
                                }
                                new Computer().FileSystem.CopyDirectory(TextBox1.Text, BackupDestination);
                            }

                            Directory.Delete(TextBox1.Text, true); // delete destination
                        }
                        new Computer().FileSystem.CopyDirectory(Games.CurrentSettings.LastQuickSavePath, TextBox1.Text); // copy to destination
                    }
                } catch { // files in use so can't delete error
                    SystemSounds.Beep.Play();
                }
            }
        }

        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            CurrentTimeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            lock (timer1Lock) {
                if (DateTime.Compare(DateTime.Now, SaveTime) > -1) {
                    SaveTimerPtr.Stop(); // turn off this timer
                    ChangeMainFormColors(Color.Gold); // reset color
                    thisForm.SaveNow();
                }
            }
        }

        bool QuickSaveButtonFlag = false;
        public void QuickSaveButton_Click(object sender = null, EventArgs e = null)
        {
            if (!Directory.Exists(TextBox1.Text)) {
                Interaction.MsgBox("Game save directory does not exist.", MsgBoxStyle.Exclamation, "Error");
            } else if (!Directory.Exists(TextBox2.Text)) {
                Interaction.MsgBox("Autosave storage directory does not exist.", MsgBoxStyle.Exclamation, "Error");
            } else {
                if (Properties.Settings.Default.ManualSaveResetInterval == false) {
                    QuickSaveButtonFlag = true;
                    SaveNow();
                } else { // Properties.Settings.Default.ManualSaveResetInterval == true (default when nothing)
                    lock (timer1Lock) {
                        if (StartButton.Text == "Stop Autosaving") { // currently autosaving
                            SaveTimerPtr.Stop();
                            ChangeMainFormColors(Color.Gold); // reset color
                            QuickSaveButtonFlag = true;
                            SaveNow();
                        } else {
                            QuickSaveButtonFlag = true;
                            SaveNow();
                        }
                    }
                }
            }
        }

        string Source; // copy the game's save location
        string Destination;// autosave destination location
                           /// <summary>
                           /// Autosave primary saving work.
                           /// </summary>
        public void SaveNow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            lock (accessLock) {
                if (Directory.Exists(TextBox1.Text) && Directory.Exists(TextBox2.Text)) {

                    // To do:
                    // save from this folder (textbox1)
                    // and copy into TextBox2 folder (with counter affix)

                    Source = TextBox1.Text; // copy the game's save location

                    if (QuickSaveButtonFlag && Games.CurrentSettings.AlternateSaveNowLocationEnabled) {

                        if (!Directory.Exists(Games.CurrentSettings.AlternateSaveNowLocation)) {
                            MsgBoxResult result = Interaction.MsgBox("Alternate \"Save Now\" location does not exist!" + Environment.NewLine +
                            "Save to autosave directory instead?", MsgBoxStyle.OkCancel, "Error");
                            if (result == MsgBoxResult.Ok) {
                                Destination = TextBox2.Text; // autosave destination location
                            } else {
                                //endThread = false
                                return; // cancel/abort saving
                            }
                        } else {
                            Destination = Games.CurrentSettings.AlternateSaveNowLocation;
                        }
                    } else {
                        Destination = TextBox2.Text; // autosave destination location
                    }

                    Source = Source.TrimEnd('\\');

                    Games.CurrentSettings.GameSaveDirectory = Source;
                    Destination = Destination.TrimEnd('\\');
                    if (QuickSaveButtonFlag == false) {
                        Games.CurrentSettings.AutoSaveStorageDirectory = Destination;
                    }

                    if (Destination == Source) {
                        Interaction.MsgBox("Source and destination locations are the same!", MsgBoxStyle.Critical, "Error");
                        return;
                    }

                    // Check and set the value of overwrite directory flag.
                    bool overwriteFlag = false;
                    if (OverwriteComboBox.SelectedIndex == 0) { // false / Don't overwrite saves
                        overwriteFlag = false;
                    } else if (OverwriteComboBox.SelectedIndex == 1) { // true / Do overwrite saves
                        overwriteFlag = true;
                    }

                    // Create new directory to be saved to. (With counter)
                    if (QuickSaveButtonFlag) {
                        Destination = Destination + "\\" + QuickSaveFileString + " " + Convert.ToString(Games.CurrentSettings.QuickSaveCounter);
                    } else {
                        Destination = Destination + "\\" + AutoSaveFileString + " " + Convert.ToString(Games.CurrentSettings.AutoSaveCounter);
                    }

                    // Copy to the save location.
                    bool saveSuccess = CopyToSaveLocation(overwriteFlag);

                    // Increment the save count.
                    if (saveSuccess) {
                        if (QuickSaveButtonFlag) { // quick save
                            if (Games.CurrentSettings.QuickSaveLimit == 0) { // unlimited
                                if (Games.CurrentSettings.QuickSaveCounter == int.MaxValue) {
                                    Games.CurrentSettings.QuickSaveCounter = 1; // limit reached
                                } else {
                                    Games.CurrentSettings.QuickSaveCounter += 1; // increment count
                                }
                            } else { // limited
                                if (Games.CurrentSettings.QuickSaveCounter == Games.CurrentSettings.QuickSaveLimit) {
                                    Games.CurrentSettings.QuickSaveCounter = 1; // limit reached
                                } else {
                                    Games.CurrentSettings.QuickSaveCounter += 1; // increment count
                                }
                            }

                            if (CounterSwitchButton.Text == QuickSaveText) {
                                SaveCountTextBox.Text = Convert.ToString(Games.CurrentSettings.QuickSaveCounter); // update counter amount
                            }
                        } else { // autosave
                            if (Games.CurrentSettings.AutoSaveLimit == 0) { // unlimited
                                if (Games.CurrentSettings.AutoSaveCounter == int.MaxValue) {
                                    Games.CurrentSettings.AutoSaveCounter = 1; // limit reached
                                } else {
                                    Games.CurrentSettings.AutoSaveCounter += 1; // increment count
                                }
                            } else { // limited
                                if (Games.CurrentSettings.AutoSaveCounter == Games.CurrentSettings.AutoSaveLimit) {
                                    Games.CurrentSettings.AutoSaveCounter = 1; // limit reached
                                } else {
                                    Games.CurrentSettings.AutoSaveCounter += 1; // increment count
                                }
                            }

                            if (CounterSwitchButton.Text == AutoSaveText) {
                                SaveCountTextBox.Text = Convert.ToString(Games.CurrentSettings.AutoSaveCounter); // update counter amount
                            }
                        }
                    }

                    if (QuickSaveButtonFlag &&
                    StartButton.Text == "Stop Autosaving" && Properties.Settings.Default.ManualSaveResetInterval || QuickSaveButtonFlag == false) {

                        StartSaving(); // setup next autosave interval
                    }

                    QuickSaveButtonFlag = false;

                } else {
                    if (!Directory.Exists(TextBox1.Text)) {
                        Interaction.MsgBox("Game save directory does not exist!", MsgBoxStyle.Critical, "Error");
                    } else if (!Directory.Exists(TextBox2.Text)) {
                        Interaction.MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Critical, "Error");
                    }
                    AutosaveIOFailure(); // Autosave failure
                }

                SaveMySettings();

                //endThread = false
            }
        }

        /// <summary>
        /// Copy the source directory contents to the destination directory.
        /// </summary>
        /// <param name="overwriteFlag">Flag determining whether or not files/folders will be overridden at destination if they already exist.</param>
        private bool CopyToSaveLocation(bool overwriteFlag)
        {
            //string TopFolderName = GetFileName(Source)
            //string UpperDestination = Destination
            // Destination = Destination + "\\" + TopFolderName
            if (QuickSaveButtonFlag) {
                Games.CurrentSettings.LastQuickSavePath = Destination; // set new last quick save path
            }
            bool success = true;
            if (overwriteFlag) {
                if (Directory.Exists(Destination)) { // case 1
                    if (Properties.Settings.Default.SimpleSaveOverwriting) {
                        try {
                            if (Properties.Settings.Default.SimpleSaveOverwritingPermaDelete == false) {
                                new Computer().FileSystem.DeleteDirectory(Destination, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            } else {
                                Directory.Delete(Destination, true);
                            }
                            new Computer().FileSystem.CopyDirectory(Source, Destination, overwriteFlag);
                        } catch {
                            AutosaveIOFailure(); // Autosave failure
                        }
                    } else {
                        try {
                            new Computer().FileSystem.CopyDirectory(Source, Destination, overwriteFlag);
                        } catch {
                            AutosaveIOFailure(); // Autosave failure
                        }
                    }
                } else { // case 2
                    try {
                        Directory.CreateDirectory(Destination);
                        new Computer().FileSystem.CopyDirectory(Source, Destination, overwriteFlag);
                    } catch {
                        try {
                            Directory.Delete(Destination);
                        } catch { }
                        AutosaveIOFailure(); // Autosave failure
                        success = false;
                    }
                }
            } else { // Don't overwrite anything
                if (!Directory.Exists(Destination)) { // case 3
                    try {
                        Directory.CreateDirectory(Destination);
                        new Computer().FileSystem.CopyDirectory(Source, Destination, overwriteFlag);
                    } catch {
                        AutosaveIOFailure(); // Autosave failure
                        return false;
                    }
                } else { // case 4

                    // Initialization.
                    if (voidFiles != null) {
                        voidFiles.Clear();
                    } else {
                        voidFiles = new List<string>();
                    }
                    if (voidDirectories != null) {
                        voidDirectories.Clear();
                    } else {
                        voidDirectories = new List<string>();
                    }

                    // Preliminary populating.
                    string[] list = Directory.GetFiles(Source);
                    foreach (string FilePath in list) {
                        voidFiles.Add(FilePath);
                    }

                    // Perform file/directory adding on all subfolders found as well.
                    GenerateWhatToSaveList(ref list, ref Source);

                    // Create all the directories first.
                    foreach (string DirectoryTemp in voidDirectories) {
                        if (!Directory.Exists(Destination + DirectoryTemp)) {
                            try {
                                new Computer().FileSystem.CopyDirectory(Source + DirectoryTemp, Destination + DirectoryTemp);
                            } catch {
                                AutosaveIOFailure(); // Autosave failure
                            }
                        }
                    }

                    // Create all the files
                    foreach (string FileTemp in voidFiles) {
                        string[] tmp2 = FileTemp.Split(new[] { Source }, StringSplitOptions.None);
                        try {
                            if (!File.Exists(Destination + tmp2[1])) {
                                new Computer().FileSystem.CopyFile(FileTemp, Destination + tmp2[1]);
                            }
                        } catch {
                            AutosaveIOFailure(); // Autosave failure
                        }
                    }

                    voidFiles.Clear();
                    voidDirectories.Clear();
                }
            }
            return success;
        }

        List<string> voidFiles; // list of all files in source
        List<string> voidDirectories; // list of all directories in source (with source path cut out)
        private void GenerateWhatToSaveList(ref string[] list, ref string path)
        {
            list = Directory.GetDirectories(path);
            if (list.Length > 0) { // more folders found (links to folders don't count)
                foreach (string DirectoryTmp in list) {
                    // add this directory to directory list
                    string[] tmp1 = DirectoryTmp.Split(new[] { Source }, StringSplitOptions.None);
                    try {
                        voidDirectories.Add(tmp1[1]);
                    } catch {
                    }

                    // add all files in this directory to file list
                    string[] listTemp = Directory.GetFiles(DirectoryTmp);
                    foreach (string FilePath in listTemp) {
                        voidFiles.Add(FilePath);
                    }

                    // look for more directories to add more files/folders from using this directory
                    AddAllFromvoidFoldersRecursive(DirectoryTmp);
                }
            }
        }

        private void AddAllFromvoidFoldersRecursive(string path)
        {
            string[] List = Directory.GetDirectories(path);
            if (List.Length > 0) { // more folders found (links to folders don't count)
                foreach (string DirectoryTmp in List) {

                    // add this directory to directory list
                    string[] tmp1 = DirectoryTmp.Split(new[] { Source }, StringSplitOptions.None);
                    try {
                        voidDirectories.Add(tmp1[1]);
                    } catch {
                    }

                    // add all files in this directory to file list
                    string[] listTemp = Directory.GetFiles(DirectoryTmp);
                    foreach (string FilePath in listTemp) {
                        voidFiles.Add(FilePath);
                    }

                    // look for more directories to add more files/folders from using this directory
                    AddAllFromvoidFoldersRecursive(DirectoryTmp);
                }
            }
        }

        /// <summary>
        /// Get name of a given full path including its extension if present.
        /// </summary>
        public static string GetFileName(string str)
        {
            if (str != null) {
                int count = 0;
                for (int c = str.Length - 1; c >= 0; c--) {
                    if (str[c] == '\\') {
                        if (c != 0) { // doesn't have slash as last char ( Str.Length - c != Str.Length)
                            return str.Substring(c + 1, count);
                        }
                    }
                    count += 1;
                }
            }
            return str;
        }

        /// <summary>
        /// Get the containing folder of a given path as string.
        /// </summary>
        public static string GetContainingFolder(string path)
        {
            if (path != null) {
                int count = 0;
                for (int i = path.Length - 1; i >= 0; i--) {
                    if (path[i] == '\\') {
                        return path.Substring(0, path.Length - (count + 1));
                    }
                    count += 1;
                }
            }
            return "";
        }

        private void Reset()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            StartButton.Text = "Start Autosaving"; // reset button text
            SaveTimeLabel.Text = "Never"; // reset alarm set to text
            NumericUpDown1.Enabled = true;
            ChangeMainFormColors(System.Drawing.SystemColors.Control); // reset color
        }

        /// <summary>
        /// Change MainForm control colors.
        /// </summary>
        private void ChangeMainFormColors(Color newColor)
        {
            this.BackColor = newColor;
            Label6.BackColor = newColor;
        }

        private void Browse1_Click(object sender, EventArgs e)
        {
            Browse(TextBox1);
        }

        private void Browse2_Click(object sender, EventArgs e)
        {
            Browse(TextBox2);
        }

        private void Browse(TextBox obj)
        {
            if (Directory.Exists(obj.Text)) {
                FolderBrowserDialog1.SelectedPath = obj.Text;
            }
            DialogResult result = FolderBrowserDialog1.ShowDialog();
            if ((result != DialogResult.Cancel || result == DialogResult.Abort)) {
                if (!string.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath)) {
                    lock (accessLock) {
                        obj.Text = FolderBrowserDialog1.SelectedPath;
                    }
                }
            }
        }

        /// <summary>
        /// Tray icon mouse clicking related.
        /// </summary>
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { // right click
                trayMenu = new TrayMenu(this);
                trayMenu.Show();
                trayMenu.Activate();
                trayMenu.Width = 1; // it will be set behind the menu, so it's 1x1 pixels
                trayMenu.Height = 1;
            } else if (e.Button == MouseButtons.Left) { // left click
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// Main form minimizes to tray flag.
        /// </summary>
        bool MinimizeButtonFlag = false;
        private void MinimizeToTrayButton_Click(object sender, EventArgs e)
        {
            CurrentTimer.Stop();
            MinimizeButtonFlag = true; // button was just clicked
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (MinimizeButtonFlag) { // only when "minimize to tray" button is used and not standard minimizing
                MinimizeButtonFlag = false;
                NotifyIcon1.Visible = true;
                this.Hide();
                //NotifyIcon1.BalloonTipText = "Minimized To Tray"
                //NotifyIcon1.ShowBalloonTip(250)
            } else if (this.WindowState == FormWindowState.Normal) {
                CurrentTimer.Start();
                NotifyIcon1.Visible = false;
            }
        }

        private void ContainingButton1_Click(object sender, EventArgs e)
        {
            OpenDirectoryButton(TextBox1.Text);
        }

        private void ContainingButton2_Click(object sender, EventArgs e)
        {
            OpenDirectoryButton(TextBox2.Text);
        }

        /// <summary>
        /// Select in containing folder. (Explorer)
        /// </summary>
        /// <param name="path">Path to open containing folder of.</param>
        public static void OpenDirectoryButton(string path)
        {
            if (path != null) {
                if (string.IsNullOrEmpty(path)) {
                    Interaction.MsgBox("No path has been specified.", MsgBoxStyle.Information, "Error");
                } else if (!Directory.Exists(path)) {
                    Interaction.MsgBox("The directory does not exist.", MsgBoxStyle.Information, "Error");
                } else {
                    Process.Start("\"" + path + "\"");
                }
            }
        }

        public Image BackgroundPicture;
        /// <summary>
        /// Set the background of the form to a selected image file.
        /// </summary>
        public void BackgroundImageSelect()
        {
            // Set to current image path if one is in use
            if (Games.CurrentSettings.BackgroundImageLoc != null) {
                string path = GetDirectoryString(TextBox1.Text);
                if (Directory.Exists(path)) {
                    OpenImageFileDialog.InitialDirectory = path; // set initial path to currently used one where a file was selected in the past
                    if (File.Exists(TextBox1.Text)) {
                        OpenImageFileDialog.FileName = GetFileDisplayString(TextBox1.Text);
                    } else {
                        OpenImageFileDialog.FileName = "";
                    }
                }
            }

            if (OpenImageFileDialog.ShowDialog() == DialogResult.OK) {
                Games.CurrentSettings.BackgroundImageLoc = OpenImageFileDialog.FileName;
                SaveMySettings();
                BackgroundPicture = Image.FromFile(OpenImageFileDialog.FileName);
                RefreshBackgroundImage();
            }
        }

        /// <summary>
        /// refresh the background image by replacing it at the control's current dimensions
        /// </summary>
        public void RefreshBackgroundImage()
        {
            if (File.Exists(Games.CurrentSettings.BackgroundImageLoc)) { // if background image is something
                using (Bitmap bmp1 = new Bitmap(this.Width, this.Height - StartButton.Height)) { // stretch the background image to fit the new size
                    using (Graphics g1 = Graphics.FromImage(bmp1)) {
                        g1.DrawImage(BackgroundPicture, 0, 0, bmp1.Width, bmp1.Height);
                        this.BackgroundImage = ((Image)bmp1.Clone());
                    }
                }
            }
        }

        private void NewScreen_ResizeBegin(object sender, EventArgs e)
        {
            if (shownComplete) {
                resizeInProgress = true;
            }
        }

        private void NewScreen_ResizeEnd(object sender, EventArgs e)
        {
            if (shownComplete) {
                resizeInProgress = false;
                ResizeBackgroundImage();
            }
        }

        bool resizeInProgress = false;
        /// <summary>
        /// Resize the Main form's background image to its new size and replace it. (Stretch)
        /// </summary>
        public void ResizeBackgroundImage()
        {
            if (!resizeInProgress) {
                RefreshBackgroundImage();
            }
        }

        /// <summary>
        /// Gets a file display worthy string, without full path or file extension info.
        /// </summary>
        /// <param name="str">String to be altered</param>
        public static string GetFileDisplayString(string str)
        {
            string[] myStr = str.Split(new[] { "\\" }, StringSplitOptions.None);
            string newStr = myStr[myStr.Length - 1];
            string[] myStr2 = newStr.Split(new[] { "." }, StringSplitOptions.None);
            string constructName = myStr2[0];
            for (int i = 1; i <= myStr2.Length - 2; i++) { // don't add extension
                constructName = constructName + "." + myStr2[i];
            }
            return constructName;
        }

        /// <summary>
        /// Returns the containing directory of a given string. (Split on "\")
        /// </summary>
        /// <param name="str">File string to be checked</param>
        public static string GetDirectoryString(string str)
        {
            string[] myStr = str.Split(new[] { '\\' }, StringSplitOptions.None);
            string newStr = "";
            for (int i = 0; i <= myStr.Length - 2; i++) {
                newStr += myStr[i] + "\\";
            }
            return newStr;
        }

        /// <summary>
        /// Occurs when an IO failure happens, so it can be logged.
        /// </summary>
        private void AutosaveIOFailure()
        {
            AutosaveF1TextBox.Visible = true;
            AutosaveF1Label.Visible = true;

            SystemSounds.Exclamation.Play();
            AutosaveF1TextBox.Text = Convert.ToString(Convert.ToInt32(AutosaveF1TextBox.Text) + 1); // Autosave failure
        }

        private void ChangeCountButton_Click(object sender, EventArgs e)
        {
            string newCount = Interaction.InputBox("Input new count", "", SaveCountTextBox.Text);
            if (string.IsNullOrEmpty(newCount)) {
                //Interaction.MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error");
            } else if (!Information.IsNumeric(newCount)) {
                Interaction.MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error");
            } else { // success
                int tempNum;
                if (int.TryParse(newCount, out tempNum)) {
                    tempNum = Convert.ToInt32(newCount);
                } else {
                    Interaction.MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error");
                    return;
                }

                if (tempNum < 0) {
                    Interaction.MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error");
                } else if ((CounterSwitchButton.Text == AutoSaveText && Games.CurrentSettings.AutoSaveLimit != 0 && tempNum > Games.CurrentSettings.AutoSaveLimit) ||
                      (CounterSwitchButton.Text == QuickSaveText && Games.CurrentSettings.QuickSaveLimit != 0 && tempNum > Games.CurrentSettings.QuickSaveLimit)) {
                    Interaction.MsgBox("Entered value cannot be higher than the specified limit.", MsgBoxStyle.Exclamation, "Error");
                } else { // success
                    int newCounter = tempNum;
                    if (newCounter == 0) {
                        newCounter = 1;
                    }

                    lock (accessLock) {
                        if (CounterSwitchButton.Text == QuickSaveText) {
                            Games.CurrentSettings.QuickSaveCounter = newCounter;
                        } else if (CounterSwitchButton.Text == AutoSaveText) {
                            Games.CurrentSettings.AutoSaveCounter = newCounter;
                        }
                        SaveCountTextBox.Text = Convert.ToString(newCounter);

                        SaveMySettings();
                    }
                }
            }
        }

        bool roundRobinButtonWasClicked = false;
        /// <summary>
        /// Button that toggles round robin saving on or off.
        /// </summary>
        private void RoundRobinButton_Click(object sender, EventArgs e)
        {
            roundRobinButtonWasClicked = true;
            if (RoundRobinButton.Text == "Disabled") { // setting to enabled now
                if (SaveLimitTextBox.Text == "None") { // attempt to set limit (optional)
                    ChangeLimitButton_Click();
                }

                Games.CurrentSettings.OverwriteSaves = true;
                OverwriteComboBox.Enabled = true;
                OverwriteComboBox.SelectedIndex = 1; // true / Do overwrite saves
                OverwriteComboBox.Enabled = false;

                Games.CurrentSettings.RoundRobinEnabled = true;
                RoundRobinButton.Text = "Enabled";
            } else if (RoundRobinButton.Text == "Enabled") { // setting to disabled now

                Games.CurrentSettings.OverwriteSaves = false;
                OverwriteComboBox.Enabled = true;
                OverwriteComboBox.SelectedIndex = 0; // false / Don't overwrite saves
                OverwriteComboBox.Enabled = false;

                Games.CurrentSettings.RoundRobinEnabled = false;
                RoundRobinButton.Text = "Disabled";
            }
            roundRobinButtonWasClicked = false;

            SaveMySettings();
        }

        private void ChangeLimitButton_Click(object sender = null, EventArgs e = null)
        {
            string newVal;
            if (SaveLimitTextBox.Text == "None") {
                newVal = Interaction.InputBox("Input new limit or 0 for no limit", "", "0");
            } else {
                newVal = Interaction.InputBox("Input new limit or 0 for no limit", "", SaveLimitTextBox.Text);
            }

            if (string.IsNullOrEmpty(newVal)) {
                //Interaction.MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error")
            } else if (!Information.IsNumeric(newVal)) {
                Interaction.MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error");
            } else { // success
                int newValue;
                if (int.TryParse(newVal, out newValue)) {
                    newValue = Convert.ToInt32(newVal);
                } else {
                    Interaction.MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error");
                    return; // failure
                }

                if (newValue < 0) {
                    Interaction.MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error");
                } else { // success
                    lock (accessLock) {
                        int limit;
                        int counter;
                        if (CounterSwitchButton.Text == AutoSaveText) {
                            counter = Games.CurrentSettings.AutoSaveCounter;
                        } else { // quick save
                            counter = Games.CurrentSettings.QuickSaveCounter;
                        }


                        if (newValue == 0) { // unlimited
                            limit = 0;
                            SaveLimitTextBox.Text = "None";
                        } else { // limited
                            limit = newValue;
                            SaveLimitTextBox.Text = Convert.ToString(newValue);
                            if (OverwriteComboBox.SelectedIndex == 0 && roundRobinButtonWasClicked == false) { // false don't overwrite
                                Interaction.MsgBox("Please consider enabling round robin." + Environment.NewLine + "Otherwise once the autosaving starts from 1 again nothing will be overwritten.",
                                    MsgBoxStyle.Exclamation, "Warning");
                            }
                        }

                        // set counter to 1 if now above the new limit
                        if (limit != 0 && counter > limit) {
                            counter = 1;
                            SaveCountTextBox.Text = "1";
                        }


                        if (CounterSwitchButton.Text == AutoSaveText) {
                            Games.CurrentSettings.AutoSaveLimit = limit;
                            Games.CurrentSettings.AutoSaveCounter = counter;
                        } else { // quick save
                            Games.CurrentSettings.QuickSaveLimit = limit;
                            Games.CurrentSettings.QuickSaveCounter = counter;
                        }
                        SaveMySettings();
                    }

                    return; // success
                }
            }
            return; // failure
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            string Name = Interaction.InputBox("Specify the name.", "Rename", Label6.Text);
            if (!string.IsNullOrEmpty(Name)) {
                if (Games.RenameGameName(thisForm, Games.CurrentName, Name)) {
                    if (gameList != null && gameList.Visible)
                        gameList.Close();
                    SaveMySettings();
                } else {
                    Interaction.MsgBox("Name already exists.", MsgBoxStyle.Exclamation);
                }
            }
        }

        /// <summary>
        /// Settings button clicked.
        /// </summary>
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm != null && !settingsForm.Visible) {
                settingsForm = new SettingsForm(this);
                settingsForm.Show();
            } else {
                settingsForm.Activate();
            }
        }

        /// <summary>
        /// Show list of loadable game save configs
        /// </summary>
        private void GameListButton_Click(object sender, EventArgs e)
        {
            if (gameList == null || gameList != null && !gameList.Visible) {
                gameList = new GameList(this);
                gameList.Show();
            } else {
                gameList.Activate();
            }
        }

        public const string QuickSaveText = "quick save";
        public const string AutoSaveText = "autosave";
        public const string QuickSaveLimitText = "Quick save limit:";
        public const string AutoSaveLimitText = "Autosave limit:";

        /// <summary>
        /// Switches the text in the button to manual save or auto save, which will determine which counter is shown and editable.
        /// </summary>
        private void CounterSwitchButton_Click(object sender, EventArgs e)
        {
            if (CounterSwitchButton.Text == AutoSaveText) {
                CounterSwitchButton.Text = "quick save";
                SaveCountTextBox.Text = Convert.ToString(Games.CurrentSettings.QuickSaveCounter);
                if (Games.CurrentSettings.QuickSaveLimit == 0) {
                    SaveLimitTextBox.Text = "None";
                } else {
                    SaveLimitTextBox.Text = Convert.ToString(Games.CurrentSettings.QuickSaveLimit);
                }
                Label7.Text = QuickSaveLimitText;
            } else if (CounterSwitchButton.Text == QuickSaveText) {
                CounterSwitchButton.Text = "autosave";
                SaveCountTextBox.Text = Convert.ToString(Games.CurrentSettings.AutoSaveCounter);
                if (Games.CurrentSettings.AutoSaveLimit == 0) {
                    SaveLimitTextBox.Text = "None";
                } else {
                    SaveLimitTextBox.Text = Convert.ToString(Games.CurrentSettings.AutoSaveLimit);
                }
                Label7.Text = AutoSaveLimitText;
            }
        }

        [DllImport("user32")]
        public static extern int GetAsyncKeyState(int key);

        // prevents key from being held down and registering more than once before being unpressed
        bool QuickSaveKeyPressed = false;
        bool QuickLoadKeyPressed = false;
        private void HotkeysTimer_Tick(object sender, EventArgs e)
        {
            try {
                if (Convert.ToBoolean(GetAsyncKeyState(Convert.ToInt32(Games.QuickSaveHotkey)))) { // Quick save hotkey press
                    if (QuickSaveKeyPressed == false) {
                        QuickSaveKeyPressed = true;

                        if (HotkeysChangeLock == false) {
                            QuickSaveButton_Click(); // quick save button click
                        }
                    }
                } else {
                    QuickSaveKeyPressed = false; // key was not pressed
                }

                if (Convert.ToBoolean(GetAsyncKeyState(Convert.ToInt32(Games.QuickLoadHotkey)))) { // Quick load hotkey press
                    if (QuickLoadKeyPressed == false) {
                        QuickLoadKeyPressed = true;

                        if (HotkeysChangeLock == false) {
                            QuickLoad(); // Quick load
                        }
                    }
                } else {
                    QuickLoadKeyPressed = false; // key was not pressed
                }

                HotkeysChangeLock = false;
            } catch (DllNotFoundException) {
            } catch {
            }
        }

        private void SaveViewerButton_Click(object sender, EventArgs e)
        {
            if (savesViewer == null || savesViewer != null && !savesViewer.Visible) {
                savesViewer = new SavesViewer(this);
                savesViewer.Show();
            } else {
                savesViewer.Activate();
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (savesViewer != null && savesViewer.Visible == true) {
                savesViewer.ToggleSavesViewerType(savesViewer.ToggleTypeButton.Text, false);
            }
        }
    }
}
