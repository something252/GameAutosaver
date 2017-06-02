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
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }
        MainForm mainForm;
        private static About about;
        public static BackgroundImageDialog backgroundImageDialog;

        bool checkChanging = false;

        bool loading = true;
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon_256;
            if (Properties.Settings.Default.SimpleSaveOverwriting) {
                SimpleOverwritingCheckBox.Checked = true;
            } else { // default is false
                SimpleOverwritingCheckBox.Checked = false;
            }
            if (Properties.Settings.Default.SimpleSaveOverwritingPermaDelete == false) {
                RecycleDelete1RadioButton.Checked = true;
                PermaDelete1RadioButton.Checked = false;
            } else { // default is true
                RecycleDelete1RadioButton.Checked = false;
                PermaDelete1RadioButton.Checked = true;
            }
            if (SimpleOverwritingCheckBox.Checked) {
                GroupBox3.Enabled = true;
            } else {
                GroupBox3.Enabled = false;
            }

            if (Properties.Settings.Default.SaveListPermaDelete == false) {
                RecycleDelete2RadioButton.Checked = true;
                PermaDelete2RadioButton.Checked = false;
            } else {
                RecycleDelete2RadioButton.Checked = false;
                PermaDelete2RadioButton.Checked = true;
            }

            if (Properties.Settings.Default.ManualSaveResetInterval == false) {
                ResetIntervalCheckBox.Checked = false;
            } else { // default is true
                ResetIntervalCheckBox.Checked = true;
            }

            AltSaveNowLocCheckBox.Checked = MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled;
            AltSaveNowLocTextBox.Text = MainForm.Games.CurrentSettings.AlternateSaveNowLocation;

            QuickSaveHotkeyTextBox.Text = KeyStringDisplayForm(MainForm.Games.QuickSaveHotkey);
            QuickLoadHotkeyTextBox.Text = KeyStringDisplayForm(MainForm.Games.QuickLoadHotkey);

            BackupQuickLoadCheckBox.Checked = Properties.Settings.Default.BackupQuickLoad;

            loading = false;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.HotkeysTimer.Start();

            mainForm.SaveMySettings();
        }

        private void SimpleOverwritingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                if (SimpleOverwritingCheckBox.Checked == false) {
                    Properties.Settings.Default.SimpleSaveOverwriting = false;
                } else {
                    Properties.Settings.Default.SimpleSaveOverwriting = true;
                }
                if (SimpleOverwritingCheckBox.Checked) {
                    GroupBox3.Enabled = true;
                } else {
                    GroupBox3.Enabled = false;
                }
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }

        private void PermaDelete1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                Properties.Settings.Default.SimpleSaveOverwritingPermaDelete = true;
                PermaDelete1RadioButton.Checked = true;
                RecycleDelete1RadioButton.Checked = false;
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }
        private void RecycleDelete1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                Properties.Settings.Default.SimpleSaveOverwritingPermaDelete = false;
                PermaDelete1RadioButton.Checked = false;
                RecycleDelete1RadioButton.Checked = true;
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }

        private void PermaDelete2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                Properties.Settings.Default.SaveListPermaDelete = true;
                PermaDelete2RadioButton.Checked = true;
                RecycleDelete2RadioButton.Checked = false;
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }
        private void RecycleDelete2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                Properties.Settings.Default.SaveListPermaDelete = false;
                PermaDelete2RadioButton.Checked = false;
                RecycleDelete2RadioButton.Checked = true;
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }

        private void ResetIntervalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                if (ResetIntervalCheckBox.Checked == false) {
                    Properties.Settings.Default.ManualSaveResetInterval = false;
                } else {
                    Properties.Settings.Default.ManualSaveResetInterval = true;
                }
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }

        private void AltSaveNowLocCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                if (AltSaveNowLocCheckBox.Checked == false) {
                    MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled = false;
                } else {
                    MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled = true;
                }
                mainForm.SaveMySettings();

                if (MainForm.savesViewer != null && MainForm.savesViewer.Visible == true) {
                    MainForm.savesViewer.ToggleSavesViewerType(MainForm.savesViewer.ToggleTypeButton.Text, false);
                }

                checkChanging = false;
            }
        }

        private void BackupQuickLoadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChanging && loading == false) {
                checkChanging = true;

                if (BackupQuickLoadCheckBox.Checked == false) {
                    Properties.Settings.Default.BackupQuickLoad = false;
                } else {
                    Properties.Settings.Default.BackupQuickLoad = true;
                }
                Properties.Settings.Default.Save();

                checkChanging = false;
            }
        }

        private void AltSaveNowLocTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loading == false) {
                MainForm.Games.CurrentSettings.AlternateSaveNowLocation = AltSaveNowLocTextBox.Text;
                if (MainForm.savesViewer != null && MainForm.savesViewer.Visible == true) {
                    MainForm.savesViewer.ToggleSavesViewerType(MainForm.savesViewer.ToggleTypeButton.Text, false);
                }
            }
        }

        private void AltSaveNowLocBrowseButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(AltSaveNowLocTextBox.Text)) {
                FolderBrowserDialog1.SelectedPath = AltSaveNowLocTextBox.Text;
            }
            DialogResult result = FolderBrowserDialog1.ShowDialog();
            if (!(result == DialogResult.Cancel || result == DialogResult.Abort)) {
                if (!string.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath)) {
                    AltSaveNowLocTextBox.Text = FolderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void BackgroundImageButton_Click(object sender, EventArgs e)
        {
            if (backgroundImageDialog == null || backgroundImageDialog != null && !backgroundImageDialog.Visible) {
                backgroundImageDialog = new BackgroundImageDialog(mainForm);
                backgroundImageDialog.Show();
            } else {
                backgroundImageDialog.Activate();
            }
        }

        public bool IgnoreHotkeyOnce = false;
        private void HotkeyTextBoxes(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode.ToString() == "ControlKey") && !(e.KeyCode.ToString() == "ShiftKey") && !(e.KeyCode.ToString() == "Menu")) {
                TextBox senderTextBox = (TextBox)sender;

                string KeyPressed = KeyStringDisplayForm(e.KeyCode);


                if (KeyPressed == "Escape") {
                    if (senderTextBox.Name == "QuickSaveHotkeyTextBox") {
                        if (!(KeyPressed == QuickLoadHotkeyTextBox.Text)) {
                            QuickSaveHotkeyTextBox.Text = "None";
                            MainForm.Games.QuickSaveHotkey = new Keys();

                            mainForm.HotkeysChangeLock = true;
                            IgnoreHotkeyOnce = true;
                        } else {
                            SystemSounds.Exclamation.Play();
                        }
                    } else if (senderTextBox.Name == "QuickLoadHotkeyTextBox") {
                        if (!(KeyPressed == QuickSaveHotkeyTextBox.Text)) {
                            QuickLoadHotkeyTextBox.Text = "None";
                            MainForm.Games.QuickLoadHotkey = new Keys();

                            mainForm.HotkeysChangeLock = true;
                            IgnoreHotkeyOnce = true;
                        } else {
                            SystemSounds.Exclamation.Play();
                        }
                    }

                } else if (e.Modifiers.ToString() == "None") {
                    if (senderTextBox.Name == "QuickSaveHotkeyTextBox") {
                        if (!(KeyPressed == QuickLoadHotkeyTextBox.Text)) {
                            QuickSaveHotkeyTextBox.Text = KeyPressed;
                            MainForm.Games.QuickSaveHotkey = e.KeyCode;

                            mainForm.HotkeysChangeLock = true;
                            IgnoreHotkeyOnce = true;
                        } else {
                            SystemSounds.Exclamation.Play();
                        }
                    } else if (senderTextBox.Name == "QuickLoadHotkeyTextBox") {
                        if (!(KeyPressed == QuickSaveHotkeyTextBox.Text)) {
                            QuickLoadHotkeyTextBox.Text = KeyPressed;
                            MainForm.Games.QuickLoadHotkey = e.KeyCode;

                            mainForm.HotkeysChangeLock = true;
                            IgnoreHotkeyOnce = true;
                        } else {
                            SystemSounds.Exclamation.Play();
                        }
                    }

                } else {
                    //QuickSaveHotkeyTextBox.Text = e.Modifiers.ToString() & "+" & KeyPressed
                    //mainForm.QuickSaveHotKey = e.KeyCode
                    //mainForm.CurrentSave.QuickSaveHotKey = e.KeyCode
                }
            }
        }

        private static string KeyStringDisplayForm(Keys KyCode)
        {
            string key = KyCode.ToString();
            switch ((key)) {
                case "D0":
                case "D1":
                case "D2":
                case "D3":
                case "D4":
                case "D5":
                case "D6":
                case "D7":
                case "D8":
                case "D9":
                    return key.Substring(1);
                case "OemPeriod":
                    return ".";
                case "Oemcomma":
                    return ",";
                case "OemQuestion":
                    return "?";
                case "OemOpenBrackets":
                    return "[";
                case "Oem1":
                    return ";";
                case "Oem7":
                    return "'";
                case "Oem5":
                    return "\\";
                case "Oem6":
                    return "]";
                case "OemMinus":
                    return "-";
                case "Oemplus":
                    return "+";
                case "Oemtilde":
                    return "+";
                case "Escape":
                    return "Escape";
                default:
                    return key;
            }
        }

        private void HotkeyTextBox_Enter(object sender, EventArgs e)
        {
            mainForm.HotkeysTimer.Stop();
        }

        private void HotkeyTextBox_Leave(object sender, EventArgs e)
        {
            mainForm.HotkeysTimer.Start();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (about == null || about != null && !about.Visible) {
                about = new About();
                about.Show();
            } else {
                about.Activate();
            }
        }

        private void Directory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] directories = (string[])e.Data.GetData(DataFormats.FileDrop);

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
    }
}
