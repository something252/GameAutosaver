using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAutosaver
{
    public partial class SavesViewer : Form
    {
        MainForm mainForm;

        public SavesViewer(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private class DataGridInfo
        {
            public List<KeyValuePair<string, string>> SaveNames = new List<KeyValuePair<string, string>>(); // file path, file name
            public List<System.DateTime> SaveLastModifiedDates = new List<System.DateTime>();
        }
        DataGridInfo DataList;

        string CurrentSaveText;
        private void SavesList_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon_256;

            CurrentSaveText = MainForm.AutoSaveFileString;
            LoadItems(mainForm.TextBox2.Text, CurrentSaveText);
        }

        private void SavesList_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileSystemWatcher1.Dispose();
        }

        /// <summary>
        /// Load items into DataGridView.
        /// </summary>
        /// <param name="SavePath">Main directory to use look in</param>
        /// <param name="SaveText">Text phrase at the start of every save to look for.</param>
        private bool LoadItems(string SavePath, string SaveText)
        {
            if (Directory.Exists(SavePath)) {
                FileSystemWatcher1.Path = SavePath;
                DataList = new DataGridInfo();
                SaveDataGridView.Rows.Clear();
                string[] TempList = Directory.GetDirectories(SavePath);

                if (TempList != null) {
                    bool foundBackupDir = false;
                    foreach (string dir in TempList) {
                        string name = MainForm.GetFileName(dir);
                        if (TestStringPartial(SaveText, name, true)) {
                            if (name.Length >= SaveText.Length + 1) {
                                string TestStr = name.Substring(SaveText.Length + 1);
                                if (TestStr != null && !string.IsNullOrEmpty(TestStr) && Information.IsNumeric(TestStr)) {
                                    int num1 = 0;
                                    if (int.TryParse(TestStr, out num1)) {
                                        DataList.SaveNames.Add(new KeyValuePair<string, string>(dir, name));
                                        DataList.SaveLastModifiedDates.Add(new Computer().FileSystem.GetFileInfo(dir).LastWriteTime); // last modified
                                    }
                                }

                            }
                        } else {
                            if (!foundBackupDir && TestStringPartial("Last Restore Temporary Backup", name, true)) {
                                foundBackupDir = true;
                                DataList.SaveNames.Add(new KeyValuePair<string, string>(dir, name));
                                DataList.SaveLastModifiedDates.Add(new Computer().FileSystem.GetFileInfo(dir).LastWriteTime); // last modified
                            }
                        }
                    }

                }

                for (int i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                    SaveDataGridView.Rows.Add(DataList.SaveNames[i].Value, DataList.SaveLastModifiedDates[i], "Load");
                }
                SaveDataGridView.Sort(SaveDataGridView.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                return true;
            } else {
                SaveDataGridView.Rows.Clear();
                return false;
            }
        }

        private void SaveDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) {
                switch (e.ColumnIndex) {
                    case 2: // Load Button
                        string Name = Convert.ToString(SaveDataGridView[0, e.RowIndex].Value);
                        int i = 0;
                        for (i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                            if (DataList.SaveNames[i].Value == Name) {
                                break;
                            }
                        }

                        LoadSave(DataList.SaveNames[i].Key, mainForm.TextBox1.Text);
                        break;
                }
            }
        }

        private void LoadSave(string savePath, string destinationPath)
        {
            if (!Directory.Exists(savePath)) {
                Interaction.MsgBox("Load failed!" + Constants.vbNewLine + Constants.vbNewLine + "Save does not exist: " + "\"" + savePath + "\"", MsgBoxStyle.Critical);
            } else {
                if (!Directory.Exists(destinationPath)) {
                    try {
                        Directory.CreateDirectory(destinationPath);
                    } catch (Exception ex) {
                        SystemSounds.Hand.Play();
                        Interaction.MsgBox(ex.Message);
                        return;
                    }
                }

                savePath = savePath.TrimEnd('\\');
                destinationPath = destinationPath.TrimEnd('\\');

                if (Properties.Settings.Default.ManualSaveResetInterval) {
                    lock (mainForm.timer1Lock) {
                        if (mainForm.StartButton.Text == "Stop Autosaving") { // currently autosaving
                            mainForm.SaveTimerPtr.Stop();
                            this.BackColor = Color.Gold;
                            mainForm.StartSaving(); // reset color
                        }
                    }
                }

                lock (mainForm.timer1Lock) {
                    try {
                        if (Properties.Settings.Default.BackupQuickLoad && MainForm.GetFileName(savePath) != "Last Restore Temporary Backup") { // if quick load backup enabled
                            mainForm.TextBox2.Text = mainForm.TextBox2.Text.TrimEnd('\\');
                            string BackupDestination = mainForm.TextBox2.Text + "\\" + "Last Restore Temporary Backup";
                            if (Directory.Exists(BackupDestination)) {
                                Directory.Delete(BackupDestination, true);
                            }
                            new Computer().FileSystem.CopyDirectory(destinationPath, BackupDestination);
                        }

                        Directory.Delete(destinationPath, true);// delete destination

                        new Computer().FileSystem.CopyDirectory(savePath, destinationPath);// copy to destination
                    } catch (Exception ex) {
                        SystemSounds.Hand.Play();
                        Interaction.MsgBox(ex.Message);
                    }
                }
                SystemSounds.Asterisk.Play();
            }
        }

        /// <summary>
        /// Test a partial string against another string (with partial string tested as aligned from start or end of other string)
        /// </summary>
        /// <param name="PartialStr">Partial string</param>
        /// <param name="AgainstStr">String to be tested against</param>
        /// <param name="fromStart">Determines whether to test against string from start (to right) or end (to left)</param>
        public static bool TestStringPartial(string partialStr, string againstStr, bool fromStart = true)
        {
            if (partialStr != null && againstStr != null && !(partialStr.Length > againstStr.Length)) {
                if (partialStr.Length == 0 && againstStr.Length == 0) {
                    return true;
                }
                if (fromStart) { // from start (left)
                    for (int i = 0; i <= partialStr.Length - 1; i++) {
                        if (partialStr[i] != againstStr[i]) {
                            return false;
                        }
                    }
                } else { // from end (right)
                    dynamic againstCount = againstStr.Length - 1;
                    for (int i = partialStr.Length - 1; i >= 0; i += -1) {
                        if (partialStr[i] != againstStr[againstCount]) {
                            return false;
                        }
                        againstCount -= 1;
                    }
                }
                return true;
            }
            return false;
        }

        public void ToggleTypeButton_Click(object sender, EventArgs e)
        {
            ToggleSavesViewerType(ToggleTypeButton.Text);
            this.ActiveControl = SaveDataGridView;
        }

        public void ToggleSavesViewerType(string type, bool toggle = true)
        {
            if (type == "Autosaves") {
                if (toggle) {
                    ViewQuickSaves();
                } else {
                    ViewAutoSaves();
                }
            } else if (type == "Quick Saves") {
                if (toggle) {
                    ViewAutoSaves();
                } else {
                    ViewQuickSaves();
                }
            }
        }

        private void ViewQuickSaves()
        {
            var _with1 = MainForm.Games.CurrentSettings;
            ToggleTypeButton.Text = "Quick Saves";
            CurrentSaveText = MainForm.QuickSaveFileString;
            if (_with1.AlternateSaveNowLocationEnabled && Directory.Exists(_with1.AlternateSaveNowLocation)) {
                LoadItems(_with1.AlternateSaveNowLocation, CurrentSaveText);
            } else {
                LoadItems(mainForm.TextBox2.Text, CurrentSaveText);
            }
        }

        private void ViewAutoSaves()
        {
            ToggleTypeButton.Text = "Autosaves";
            CurrentSaveText = MainForm.AutoSaveFileString;
            LoadItems(mainForm.TextBox2.Text, CurrentSaveText);
        }

        private void FileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            try {
                bool matched = false;
                if (TestStringPartial(CurrentSaveText, e.Name, true)) {
                    if (e.Name.Length >= CurrentSaveText.Length + 1) {
                        string TestStr = e.Name.Substring(CurrentSaveText.Length + 1);
                        if (TestStr != null && !string.IsNullOrEmpty(TestStr) && Information.IsNumeric(TestStr)) {
                            int num1 = 0;
                            if (int.TryParse(TestStr, out num1)) {
                                matched = true;
                            }
                        }
                    }
                } else if (TestStringPartial("Last Restore Temporary Backup", e.Name, true)) {
                    matched = true;
                }

                if (matched) {
                    DataList.SaveNames.Add(new KeyValuePair<string, string>(e.FullPath, e.Name));
                    System.DateTime lastWrite = new Computer().FileSystem.GetFileInfo(e.FullPath).LastWriteTime;
                    DataList.SaveLastModifiedDates.Add(lastWrite);
                    SaveDataGridView.Rows.Add(e.Name, lastWrite, "Load"); // last modified
                    ResortDataGridView();
                }
            } catch (Exception ex) {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            try {
                for (int i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                    if (e.Name == DataList.SaveNames[i].Value) {
                        for (int k = 0; k <= SaveDataGridView.RowCount - 1; k++) {
                            if (Convert.ToString(SaveDataGridView[0, k].Value) == e.Name) {
                                SaveDataGridView.Rows.RemoveAt(k);
                                break;
                            }
                        }
                        DataList.SaveNames.RemoveAt(i);
                        DataList.SaveLastModifiedDates.RemoveAt(i);
                        ResortDataGridView();
                        break;
                    }
                }
            } catch (Exception ex) {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void FileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            try {
                for (int i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                    if (e.OldName == DataList.SaveNames[i].Value) {
                        DataList.SaveNames[i] = new KeyValuePair<string, string>(e.FullPath, e.Name);
                        DataList.SaveLastModifiedDates[i] = new Computer().FileSystem.GetFileInfo(e.FullPath).LastWriteTime;
                        for (int k = 0; k <= SaveDataGridView.RowCount - 1; k++) { // last modified
                            if (Convert.ToString(SaveDataGridView[0, k].Value) == e.OldName) {
                                SaveDataGridView[0, k].Value = e.Name;
                                SaveDataGridView[1, k].Value = DataList.SaveLastModifiedDates[i];
                                ResortDataGridView();
                            }
                        }
                        break;
                    }
                }
            } catch (Exception ex) {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void ResortDataGridView()
        {
            if (SaveDataGridView.SortOrder != SortOrder.None && SaveDataGridView.SortedColumn != null) {
                System.ComponentModel.ListSortDirection Direction = System.ComponentModel.ListSortDirection.Ascending;
                if (SaveDataGridView.SortOrder == SortOrder.Descending) {
                    Direction = System.ComponentModel.ListSortDirection.Descending;
                }
                SaveDataGridView.Sort(SaveDataGridView.SortedColumn, Direction);
            }
        }

        private void RemoveSaveButton_Click(object sender, EventArgs e)
        {
            if (SaveDataGridView.SelectedCells.Count > 0) {
                SystemSounds.Exclamation.Play();
                MsgBoxResult result = Interaction.MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo);
                if (result == MsgBoxResult.Yes) {

                    for (int j = SaveDataGridView.SelectedCells.Count - 1; j >= 0; j += -1) {
                        string saveName = Convert.ToString(SaveDataGridView[0, SaveDataGridView.SelectedCells[j].RowIndex].Value);

                        for (int i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                            if (saveName == DataList.SaveNames[i].Value) {
                                try {
                                    if (Properties.Settings.Default.SaveListPermaDelete == false) {
                                        new Computer().FileSystem.DeleteDirectory(DataList.SaveNames[i].Key, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                    } else {
                                        Directory.Delete(DataList.SaveNames[i].Key, true);
                                    }

                                    SaveDataGridView.Rows.RemoveAt(SaveDataGridView.SelectedCells[j].RowIndex);
                                    DataList.SaveNames.RemoveAt(i);
                                    DataList.SaveLastModifiedDates.RemoveAt(i);
                                    //ResortDataGridView()
                                } catch (Exception ex) {
                                    SystemSounds.Hand.Play();
                                    Interaction.MsgBox(ex.Message);
                                }
                                break;
                            }
                        }
                    }

                }
                this.ActiveControl = null;
            } else {
                SystemSounds.Asterisk.Play();
            }
        }

        private void OpenContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDataGridView.SelectedCells.Count > 0) {
                string saveName = Convert.ToString(SaveDataGridView[0, SaveDataGridView.SelectedCells[0].RowIndex].Value);
                for (int i = 0; i <= DataList.SaveNames.Count - 1; i++) {
                    if (saveName == DataList.SaveNames[i].Value) {
                        MainForm.OpenDirectoryButton(DataList.SaveNames[i].Key);
                        break;
                    }
                }
            } else {
                SystemSounds.Asterisk.Play();
            }
        }

        private void SaveDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void SaveDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                RemoveSaveButton.PerformClick();
                this.ActiveControl = SaveDataGridView;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
