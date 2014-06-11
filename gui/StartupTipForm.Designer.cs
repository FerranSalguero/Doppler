namespace Doppler
{
    partial class StartupTipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowTipsOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TipRichTextBox = new System.Windows.Forms.RichTextBox();
            this.NextTipButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowTipsOnStartupCheckBox
            // 
            this.ShowTipsOnStartupCheckBox.AutoSize = true;
            this.ShowTipsOnStartupCheckBox.Location = new System.Drawing.Point(12, 290);
            this.ShowTipsOnStartupCheckBox.Name = "ShowTipsOnStartupCheckBox";
            this.ShowTipsOnStartupCheckBox.Size = new System.Drawing.Size(122, 17);
            this.ShowTipsOnStartupCheckBox.TabIndex = 1;
            this.ShowTipsOnStartupCheckBox.Text = "Show tips on startup";
            this.ShowTipsOnStartupCheckBox.UseVisualStyleBackColor = true;
            this.ShowTipsOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.DoNotShowCheckBox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Location = new System.Drawing.Point(258, 286);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TipRichTextBox
            // 
            this.TipRichTextBox.BackColor = System.Drawing.Color.White;
            this.TipRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.TipRichTextBox.Name = "TipRichTextBox";
            this.TipRichTextBox.ReadOnly = true;
            this.TipRichTextBox.Size = new System.Drawing.Size(321, 268);
            this.TipRichTextBox.TabIndex = 3;
            this.TipRichTextBox.Text = "";
            // 
            // NextTipButton
            // 
            this.NextTipButton.Location = new System.Drawing.Point(177, 286);
            this.NextTipButton.Name = "NextTipButton";
            this.NextTipButton.Size = new System.Drawing.Size(75, 23);
            this.NextTipButton.TabIndex = 4;
            this.NextTipButton.Text = "&Next tip";
            this.NextTipButton.UseVisualStyleBackColor = true;
            this.NextTipButton.Click += new System.EventHandler(this.NextTipButton_Click);
            // 
            // StartupTipForm
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(345, 315);
            this.ControlBox = false;
            this.Controls.Add(this.NextTipButton);
            this.Controls.Add(this.TipRichTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShowTipsOnStartupCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StartupTipForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tips";
            this.Load += new System.EventHandler(this.StartupTipForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowTipsOnStartupCheckBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.RichTextBox TipRichTextBox;
        private System.Windows.Forms.Button NextTipButton;
    }
}