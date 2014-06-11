namespace Doppler
{
    partial class SkipRetryMessageBox
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
            this.SkipButton = new System.Windows.Forms.Button();
            this.CancelNowButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SkipButton
            // 
            this.SkipButton.Location = new System.Drawing.Point(108, 90);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(98, 23);
            this.SkipButton.TabIndex = 0;
            this.SkipButton.Text = "Skip";
            this.SkipButton.UseVisualStyleBackColor = true;
            // 
            // CancelNowButton
            // 
            this.CancelNowButton.Location = new System.Drawing.Point(212, 90);
            this.CancelNowButton.Name = "CancelNowButton";
            this.CancelNowButton.Size = new System.Drawing.Size(100, 23);
            this.CancelNowButton.TabIndex = 1;
            this.CancelNowButton.Text = "Never download";
            this.CancelNowButton.UseVisualStyleBackColor = true;
            // 
            // MessageLabel
            // 
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MessageLabel.Location = new System.Drawing.Point(71, 9);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(338, 78);
            this.MessageLabel.TabIndex = 2;
            this.MessageLabel.Text = "MessageLabel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Doppler.Properties.Resources.dopplerico_48;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 56);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // SkipRetryMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(421, 122);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.CancelNowButton);
            this.Controls.Add(this.SkipButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkipRetryMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SkipRetryMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Button CancelNowButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}