namespace Doppler
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.buttonSelectDir = new System.Windows.Forms.Button();
            this.DownloadLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectDir
            // 
            this.buttonSelectDir.AccessibleDescription = null;
            this.buttonSelectDir.AccessibleName = null;
            resources.ApplyResources(this.buttonSelectDir, "buttonSelectDir");
            this.buttonSelectDir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelectDir.BackgroundImage = null;
            this.buttonSelectDir.Font = null;
            this.buttonSelectDir.Name = "buttonSelectDir";
            this.buttonSelectDir.UseVisualStyleBackColor = false;
            this.buttonSelectDir.Click += new System.EventHandler(this.buttonSelectDir_Click);
            // 
            // DownloadLocationTextBox
            // 
            this.DownloadLocationTextBox.AccessibleDescription = null;
            this.DownloadLocationTextBox.AccessibleName = null;
            resources.ApplyResources(this.DownloadLocationTextBox, "DownloadLocationTextBox");
            this.DownloadLocationTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DownloadLocationTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.DownloadLocationTextBox.BackgroundImage = null;
            this.DownloadLocationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Doppler.Properties.Settings.Default, "DownloadLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DownloadLocationTextBox.Font = null;
            this.DownloadLocationTextBox.Name = "DownloadLocationTextBox";
            this.DownloadLocationTextBox.Text = global::Doppler.Properties.Settings.Default.DownloadLocation;
            this.DownloadLocationTextBox.TextChanged += new System.EventHandler(this.textDownloadLocation_TextChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleDescription = null;
            this.buttonOK.AccessibleName = null;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.BackgroundImage = null;
            this.buttonOK.Font = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = null;
            this.pictureBox1.Font = null;
            this.pictureBox1.Image = global::Doppler.Properties.Resources.dopplerico_48;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // SetupForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = null;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSelectDir);
            this.Controls.Add(this.DownloadLocationTextBox);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectDir;
        private System.Windows.Forms.TextBox DownloadLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
    }
}