using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Doppler
{
    public partial class SkipRetryMessageBox : Form
    {
        public static DialogResult Show(string Title, string Message, int DefaultButton)
        {
            SkipRetryMessageBox box = new SkipRetryMessageBox(Title, Message, DefaultButton);
            DialogResult returnValue = box.ShowDialog();
            box.Dispose();
            return returnValue;
        }

        public SkipRetryMessageBox(string Title, string Message, int DefaultButton)
        {
            InitializeComponent();
            this.Text = Title;
            MessageLabel.Text = Message;
            this.StartPosition = FormStartPosition.CenterParent;
            switch (DefaultButton)
            {
                case 1:
                    this.AcceptButton = SkipButton;
                    SkipButton.DialogResult = DialogResult.OK;
                    this.CancelButton = CancelNowButton;
                    CancelNowButton.DialogResult = DialogResult.Cancel;
                    break;
                case 2:
                    this.AcceptButton = CancelNowButton;
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    this.CancelButton = SkipButton;
                    CancelNowButton.DialogResult = DialogResult.OK;
                    break;
                default:
                    this.AcceptButton = SkipButton;
                    SkipButton.DialogResult = DialogResult.OK;
                    this.CancelButton = CancelNowButton;
                    CancelNowButton.DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}