using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAutoLockUnlock
{
    partial class LockScreenForm : Form
    {
        public LockScreenForm()
        {
            InitializeComponent();

            this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.TopMost = true;
        }

        private void LockScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ShowBlackScreenWhenLocked)
            {
                LockScreenLabel.Text = Properties.Settings.Default.BlackScreenText;
                LockScreenLabel.Visible = true;
            }
            else
            {
                LockScreenLabel.Visible = false;
            }
        }
    }
}
