using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAutosaver
{
    public partial class BackgroundImageDialog : Form
    {
        public BackgroundImageDialog(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }
        MainForm mainForm;

        private void BackgroundImageDialog_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_256;
        }

        /// <summary>
        /// Change background.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            mainForm.BackgroundImageSelect();

            this.Close();
        }

        /// <summary>
        /// Reset/clear background.
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {
            MainForm.Games.CurrentSettings.BackgroundImageLoc = "";
            mainForm.SaveMySettings();
            mainForm.BackgroundImage = null;

            this.Close();
        }
    }
}
