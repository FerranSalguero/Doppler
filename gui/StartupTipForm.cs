using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Doppler.Properties;

namespace Doppler
{
    public partial class StartupTipForm : Form
    {
        public StartupTipForm()
        {
            InitializeComponent();
            ShowTipsOnStartupCheckBox.Checked = Settings.Default.ShowTips;
        }

        private void StartupTipForm_Load(object sender, EventArgs e)
        {
            ShowNextTip();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoNotShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowTips = ShowTipsOnStartupCheckBox.Checked;
        }

        private void NextTipButton_Click(object sender, EventArgs e)
        {
            ShowNextTip();
        }

        private void ShowNextTip()
        {
            int CurrentTip = Settings.Default.CurrentTip;
            CurrentTip++;
            string tip = "";
            try
            {
                tip = tips.Tips.ResourceManager.GetString("Tip" + CurrentTip.ToString());
                if (tip == null)
                {
                    CurrentTip = 1;
                    tip = tips.Tips.ResourceManager.GetString("Tip" + CurrentTip.ToString());

                }
            }
            catch
            {
                CurrentTip = 1;
                tip = tips.Tips.ResourceManager.GetString("Tip" + CurrentTip.ToString());
            }
            Settings.Default.CurrentTip = CurrentTip;
            TipRichTextBox.Text = tip;
        }
    }
}