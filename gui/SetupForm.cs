using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Doppler
{
    /// <summary>
    /// Form initially shown when Doppler finds no default download location
    /// </summary>
    public partial class SetupForm : Form
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SetupForm()
        {
            InitializeComponent();
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DownloadLocationTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
			folderBrowserDialog1.Dispose();
        }

		private void textDownloadLocation_TextChanged(object sender, EventArgs e)
		{
           
		}

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(DownloadLocationTextBox.Text))
            {
                if (MessageBox.Show("The download location you specified does not exist.\n\nCreate it?", "Folder does not exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.IO.Directory.CreateDirectory(DownloadLocationTextBox.Text);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            } else {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            string Path =  Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\My Podcasts";
            DownloadLocationTextBox.Text = Path;

        }
    }
}