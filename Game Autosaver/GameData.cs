using GameAutosaver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameAutosaver
{
    public class GameData
    {
        public Dictionary<string, GameSettings> GameList = new Dictionary<string, GameSettings>(); // name, save settings

        public Keys QuickSaveHotkey = Keys.F5;
        public Keys QuickLoadHotkey = Keys.F8;

        private bool Loading = true;
        public void FinishedLoading()
        {
            Loading = false;
        }

        private string _CurrentName = "";
        /// <summary>
        /// Currently active game name
        /// </summary>
        public string CurrentName
        {
            get { return _CurrentName; }
            set {
                if (!Loading) {
                    if (GameList.ContainsKey(value)) {
                        _CurrentName = value;
                    }
                } else {
                    _CurrentName = value;
                }
            }
        }

        /// <summary>
        /// Currently active game settings
        /// </summary>
        public GameSettings CurrentSettings
        {
            get {
                if (GameList.ContainsKey(CurrentName)) {
                    return GameList[CurrentName];
                } else {
                    return null;
                }
            }
            set {
                if (!Loading) {
                    if (GameList.ContainsKey(CurrentName)) {
                        GameList[CurrentName] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Rename name from gamelist.
        /// </summary>
        public bool RenameGameName(MainForm mainForm, string oldName, string newName)
        {

            if (mainForm != null && newName != null && !string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(oldName) && newName.Length < 300 && !(mainForm.Label6.Text == newName) && GameList.ContainsKey(oldName) && !GameList.ContainsKey(newName)) {
                GameSettings tmp = GameList[oldName];
                tmp.Name = newName;
                if (CurrentName == oldName) {
                    UseNewSave(newName, tmp);
                    mainForm.Label6.Text = newName;
                } else {
                    GameList.Add(newName, tmp);
                }
                GameList.Remove(oldName);
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Add new game save or overwrite existing one using given name and setting, then set name as current save name.
        /// </summary>
        public void UseNewSave(string name, GameSettings settings = null)
        {
            if (settings == null) {
                settings = new GameSettings();
            }
            settings.Name = name;

            if (!GameList.ContainsKey(name)) {
                GameList.Add(name, settings);
                CurrentName = name;
            } else { // use already existing save and overwrite
                CurrentName = name;
                CurrentSettings = settings;
            }
        }

        /// <summary>
        /// Load save of given name.
        /// </summary>
        public bool LoadSave(MainForm mainForm, string name, bool startup = false)
        {
            if (!string.IsNullOrEmpty(name)) {
                if (GameList.ContainsKey(name)) {
                    if (!startup) {
                        SaveCurrentSettings(mainForm);
                    }
                    CurrentName = name;
                    LoadSettings(mainForm, GameList[name]);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Load blank save when gamelist is empty on main form startup.
        /// </summary>
        public void StartupLoadBlankSave(MainForm mainForm)
        {
            if (mainForm != null) {
                UseNewSave(mainForm.Label6.Text, new GameSettings());
                LoadSettings(mainForm, new GameSettings());
            }
        }

        private void LoadSettings(MainForm mainForm, GameSettings settings)
        {
            if (mainForm != null && settings != null) {

                if (!string.IsNullOrEmpty(settings.Name)) {
                    mainForm.Label6.Text = settings.Name;
                } else {
                    mainForm.Label6.Text = "GAME AUTOSAVER";
                }
                CurrentName = mainForm.Label6.Text;

                mainForm.CurrentTimer.Start(); // Start current time related timer
                mainForm.NumericUpDown1.Value = settings.AutoSaveIntervalMinutes;

                mainForm.TextBox1.Text = settings.GameSaveDirectory;
                mainForm.TextBox2.Text = settings.AutoSaveStorageDirectory;

                mainForm.CounterSwitchButton.Text = MainForm.AutoSaveText;
                if (settings.AutoSaveLimit != 0 && settings.AutoSaveCounter > settings.AutoSaveLimit) {
                    mainForm.SaveCountTextBox.Text = "1";
                } else {
                    mainForm.SaveCountTextBox.Text = Convert.ToString(settings.AutoSaveCounter);
                }
                mainForm.Label7.Text = MainForm.AutoSaveLimitText;
                if (settings.AutoSaveLimit == 0) {
                    mainForm.SaveLimitTextBox.Text = "None";
                } else {
                    mainForm.SaveLimitTextBox.Text = Convert.ToString(settings.AutoSaveLimit);
                }

                if (File.Exists(settings.BackgroundImageLoc)) {
                    try {
                        mainForm.BackgroundPicture = Image.FromFile(settings.BackgroundImageLoc);
                        mainForm.RefreshBackgroundImage();
                    } catch {
                    }
                } else {
                    mainForm.BackgroundImage = null;
                }

                if (settings.RoundRobinEnabled == false) { // exists and is false
                    if (settings.OverwriteSaves == false) {
                        mainForm.OverwriteComboBox.SelectedIndex = 0; // false / Don't overwrite saves
                    } else {
                        mainForm.OverwriteComboBox.SelectedIndex = 1; // true / Do overwrite saves
                    }
                    mainForm.RoundRobinButton.Text = "Disabled";
                } else {
                    mainForm.OverwriteComboBox.SelectedIndex = 1; // true / Do overwrite saves
                    mainForm.RoundRobinButton.Text = "Enabled";
                }

                mainForm.HotkeysTimer.Start();
            }
        }

        public void SaveCurrentSettings(MainForm mainForm)
        {
            if (mainForm != null && CurrentSettings != null) {
                CurrentSettings.Name = mainForm.Label6.Text;
                CurrentSettings.AutoSaveIntervalMinutes = Convert.ToInt32(mainForm.NumericUpDown1.Value);

                if (mainForm.OverwriteComboBox.SelectedIndex == 0) { // false / Don't overwrite saves
                    CurrentSettings.OverwriteSaves = false;
                } else if (mainForm.OverwriteComboBox.SelectedIndex == 1) {  // true / Do overwrite saves
                    CurrentSettings.OverwriteSaves = true;
                }
                CurrentSettings.GameSaveDirectory = mainForm.TextBox1.Text;
                CurrentSettings.AutoSaveStorageDirectory = mainForm.TextBox2.Text;
            }
        }
    }

    public class GameSettings
    {
        public string Name;
        public string GameSaveDirectory = "";
        public string AutoSaveStorageDirectory = "";

        public int AutoSaveIntervalMinutes = 5;
        private int _AutoSaveCounter = 1;
        public int AutoSaveCounter
        {
            get { return _AutoSaveCounter; }
            set { _AutoSaveCounter = value; }
        }

        public bool OverwriteSaves = false;
        public string BackgroundImageLoc = "";

        public bool RoundRobinEnabled = true;
        private int _AutoSaveLimit = 0;
        public int AutoSaveLimit
        {
            get { return _AutoSaveLimit; }
            set { _AutoSaveLimit = value; }
        }

        public bool AlternateSaveNowLocationEnabled = false;

        public string AlternateSaveNowLocation = "";
        private int _QuickSaveCounter = 1;
        public int QuickSaveCounter
        {
            get { return _QuickSaveCounter; }
            set { _QuickSaveCounter = value; }
        }

        private int _QuickSaveLimit = 0;
        public int QuickSaveLimit
        {
            get { return _QuickSaveLimit; }
            set { _QuickSaveLimit = value; }
        }
        
        public string LastQuickSavePath = "";
    }
}
