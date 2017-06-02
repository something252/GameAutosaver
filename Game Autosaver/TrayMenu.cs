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
    public partial class TrayMenu : Form
    {
        MainForm mainForm;

        public TrayMenu(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void TrayMenu_Load(object sender, EventArgs e)
        {
            ContextMenuStrip1.Show(Cursor.Position);
            this.Left = ContextMenuStrip1.Left + 1; // put form behind context menu 
            this.Top = ContextMenuStrip1.Top + 1; // put form behind context menu 
        }

        private void TrayMenu_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// terminate the program
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.Close();
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
            this.Close();
        }
    }
}
