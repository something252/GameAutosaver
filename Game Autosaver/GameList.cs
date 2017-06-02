using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using System.Media;

namespace GameAutosaver
{
    public partial class GameList : Form
    {
        public GameList(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        MainForm mainForm;

        private void GameList_Load(object sender, EventArgs e1)
        {
            Icon = Properties.Resources.Icon_256;

            MainForm.Games.SaveCurrentSettings(MainForm.thisForm);

            if (MainForm.Games.GameList.Count > 0) {
                foreach (GameSettings e in MainForm.Games.GameList.Values) {
                    int NewRowIndex = DataGridView1.Rows.Add(e.Name, "Load", "Remove");

                    if (e.Name == mainForm.Label6.Text) { // currently open save
                        DataGridViewButtonCell CellBtn = new DataGridViewButtonCell();
                        CellBtn.Value = "Current";
                        DataGridView1[1, NewRowIndex] = CellBtn;
                    }
                    DataGridView1.Rows[NewRowIndex].Selected = false;
                }
                DataGridView1.Sort(DataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void GameList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) {
                switch (e.ColumnIndex) {
                    case 1: // Load Button
                        LoadGame(e.RowIndex);
                        break;
                    case 2: // Remove Button
                        RemoveGame(e.RowIndex);
                        break;
                }
            }
        }

        /// <summary>
        /// Load a corresponding row in the DataGridView.
        /// </summary>
        /// <param name="row">The corresponding row.</param>
        private void LoadGame(int row, bool dontSaveGameBeforeLoad = false)
        {
            if (row >= 0) {
                if (Convert.ToString(DataGridView1[1, row].Value) == "Current") {
                    Interaction.MsgBox("This is already active.", MsgBoxStyle.Information, "Error");
                } else {

                    string Name = Convert.ToString(DataGridView1[0, row].Value);
                    if (MainForm.Games.GameList.ContainsKey(Name)) {
                        StopAnyMainFormWork(); // stop any active elements

                        if (MainForm.Games.LoadSave(MainForm.thisForm, Name, dontSaveGameBeforeLoad)) {
                            mainForm.MainForm_FormClosing(); // update settings
                            mainForm.Activate();
                            this.Close();
                        } else {
                            Interaction.MsgBox("Could not find game data.", MsgBoxStyle.Exclamation, "Error");
                        }
                    } else {
                        Interaction.MsgBox("Could not find saved game with that name.", MsgBoxStyle.Exclamation, "Error");
                    }

                }
            }
        }


        private void ResortDataGridView()
        {
            if (DataGridView1.SortOrder != SortOrder.None && DataGridView1.SortedColumn != null) {
                System.ComponentModel.ListSortDirection Direction = System.ComponentModel.ListSortDirection.Ascending;
                if (DataGridView1.SortOrder == SortOrder.Descending) {
                    Direction = System.ComponentModel.ListSortDirection.Descending;
                }
                DataGridView1.Sort(DataGridView1.SortedColumn, Direction);
            }
        }

        /// <summary>
        /// Stop any active elements in the MainForm.
        /// </summary>
        private static void StopAnyMainFormWork()
        {
            lock (MainForm.thisForm.accessLock) {
                if (MainForm.thisForm.StartButton.Text == "Stop Autosaving") {
                    MainForm.thisForm.StartButton.PerformClick(); // stop autosaving
                }
            }
            if (MainForm.settingsForm != null && MainForm.settingsForm.Visible)
                MainForm.settingsForm.Close();
            if (SettingsForm.backgroundImageDialog != null && SettingsForm.backgroundImageDialog.Visible)
                SettingsForm.backgroundImageDialog.Close();
            if (MainForm.savesViewer != null && MainForm.savesViewer.Visible)
                MainForm.savesViewer.Close();
        }

        /// <summary>
        /// Remove a specified row and all it's data from settings.
        /// </summary>
        /// <param name="row">Corresponding row. (Name and settings data row)</param>
        private void RemoveGame(int row)
        {
            if (row >= 0) {
                if (DataGridView1.Rows.Count > 0) {
                    SystemSounds.Exclamation.Play();
                    MsgBoxResult result = Interaction.MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Warning");
                    if (result == MsgBoxResult.Yes) {
                        StopAnyMainFormWork(); // stop any active elements
                        if (MainForm.Games.GameList.Remove(Convert.ToString(DataGridView1[0, row].Value))) {
                            string txt = Convert.ToString(DataGridView1[1, row].Value);
                            DataGridView1.Rows.RemoveAt(row);
                            if (txt == "Current") {
                                const string name = "GAME AUTOSAVER";
                                bool found = false;
                                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                                    if (Convert.ToString(DataGridView1[0, i].Value) == name) {
                                        LoadGame(i, true);
                                        found = true;
                                    }
                                }
                                if (!found) {
                                    MainForm.Games.GameList.Add(name, new GameSettings());
                                    MainForm.Games.GameList[name].Name = name;
                                    int idx = DataGridView1.Rows.Add(name, "Load", "Remove");
                                    //ResortDataGridView();
                                    LoadGame(idx, true);
                                }
                            }
                        } else {
                            Interaction.MsgBox("Could not find data to delete!", MsgBoxStyle.Critical, "Error");
                        }
                    }
                }
            }
        }

        public const int GameNameCharLimit = 300;
        /// <summary>
        /// Create and add a new row to the DataGridView
        /// </summary>
        private void NewButton_Click(object sender, EventArgs e)
        {
            string NewGame = Interaction.InputBox("Enter a name", "New", "");

            if (string.IsNullOrEmpty(NewGame)) {
                //SystemSounds.Exclamation.Play();
            } else if (NewGame.Length >= GameNameCharLimit) {
                Interaction.MsgBox("Name cannot be longer than " + GameNameCharLimit + ".", MsgBoxStyle.Exclamation, "Error");
            } else {
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    if (Convert.ToString(DataGridView1[0, i].Value) == NewGame) {
                        Interaction.MsgBox("This name already exists!", MsgBoxStyle.Exclamation, "Error");
                        return;
                    }
                }

                MainForm.Games.GameList.Add(NewGame, new GameSettings());
                MainForm.Games.GameList[NewGame].Name = NewGame;
                DataGridView1.Rows.Add(NewGame, "Load", "Remove");
                ResortDataGridView();
            }
        }


        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // renaming row
            if (e.ColumnIndex == 0 && DataGridView1.SelectedCells.Count > 0) {
                string NewName = Convert.ToString(DataGridView1[e.ColumnIndex, EdittedRow].Value);
                if (!string.IsNullOrEmpty(NewName)) {
                    if (MainForm.Games.RenameGameName(MainForm.thisForm, OldName, NewName)) {
                        mainForm.SaveMySettings();
                    } else {
                        Interaction.MsgBox("Name already exists.", MsgBoxStyle.Exclamation);
                    }
                }
            }
        }

        private int EdittedRow = -1;
        private string OldName = "";
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            EdittedRow = e.RowIndex;
            OldName = Convert.ToString(DataGridView1[0, e.RowIndex].Value);
        }
    }
}
