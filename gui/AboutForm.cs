using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Doppler
{
	/// <summary>
	/// Summary description for frmAbout.
	/// </summary>
	public class AboutForm : System.Windows.Forms.Form
    {
        private PictureBox pictureRetrieve;
        private PictureBox pictureLogo;
        private Button buttonDonate;
        private Label label5;
        private Label labelVersion;
        private Button buttonOK;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private LinkLabel FrenchLinkLabel;
        private Label label8;
        private LinkLabel SlovakLinkLabel;
        private Label SlovakLabel;
        private Label label9;
        private LinkLabel PolishLinkLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureRetrieve = new System.Windows.Forms.PictureBox();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.buttonDonate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FrenchLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.SlovakLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SlovakLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PolishLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRetrieve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureRetrieve
            // 
            this.pictureRetrieve.AccessibleDescription = null;
            this.pictureRetrieve.AccessibleName = null;
            resources.ApplyResources(this.pictureRetrieve, "pictureRetrieve");
            this.pictureRetrieve.BackColor = System.Drawing.Color.Transparent;
            this.pictureRetrieve.BackgroundImage = null;
            this.pictureRetrieve.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureRetrieve.Font = null;
            this.pictureRetrieve.ImageLocation = null;
            this.pictureRetrieve.Name = "pictureRetrieve";
            this.pictureRetrieve.TabStop = false;
            // 
            // pictureLogo
            // 
            this.pictureLogo.AccessibleDescription = null;
            this.pictureLogo.AccessibleName = null;
            resources.ApplyResources(this.pictureLogo, "pictureLogo");
            this.pictureLogo.BackColor = System.Drawing.Color.White;
            this.pictureLogo.BackgroundImage = null;
            this.pictureLogo.Font = null;
            this.pictureLogo.ImageLocation = null;
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.TabStop = false;
            // 
            // buttonDonate
            // 
            this.buttonDonate.AccessibleDescription = null;
            this.buttonDonate.AccessibleName = null;
            resources.ApplyResources(this.buttonDonate, "buttonDonate");
            this.buttonDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDonate.Font = null;
            this.buttonDonate.Name = "buttonDonate";
            this.buttonDonate.Click += new System.EventHandler(this.buttonDonate_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.buttonDonate_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AccessibleDescription = null;
            this.labelVersion.AccessibleName = null;
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.BackColor = System.Drawing.Color.White;
            this.labelVersion.Name = "labelVersion";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleDescription = null;
            this.buttonOK.AccessibleName = null;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOK.BackgroundImage = null;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AccessibleDescription = null;
            this.linkLabel1.AccessibleName = null;
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.Font = null;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = null;
            this.label7.Name = "label7";
            // 
            // FrenchLinkLabel
            // 
            this.FrenchLinkLabel.AccessibleDescription = null;
            this.FrenchLinkLabel.AccessibleName = null;
            resources.ApplyResources(this.FrenchLinkLabel, "FrenchLinkLabel");
            this.FrenchLinkLabel.Font = null;
            this.FrenchLinkLabel.Name = "FrenchLinkLabel";
            this.FrenchLinkLabel.TabStop = true;
            this.FrenchLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FrenchLinkLabel_LinkClicked);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = null;
            this.label8.Name = "label8";
            // 
            // SlovakLinkLabel
            // 
            this.SlovakLinkLabel.AccessibleDescription = null;
            this.SlovakLinkLabel.AccessibleName = null;
            resources.ApplyResources(this.SlovakLinkLabel, "SlovakLinkLabel");
            this.SlovakLinkLabel.Font = null;
            this.SlovakLinkLabel.Name = "SlovakLinkLabel";
            this.SlovakLinkLabel.TabStop = true;
            this.SlovakLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SlovakLinkLabel_LinkClicked);
            // 
            // SlovakLabel
            // 
            this.SlovakLabel.AccessibleDescription = null;
            this.SlovakLabel.AccessibleName = null;
            resources.ApplyResources(this.SlovakLabel, "SlovakLabel");
            this.SlovakLabel.BackColor = System.Drawing.Color.White;
            this.SlovakLabel.Font = null;
            this.SlovakLabel.Name = "SlovakLabel";
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = null;
            this.label9.Name = "label9";
            // 
            // PolishLinkLabel
            // 
            this.PolishLinkLabel.AccessibleDescription = null;
            this.PolishLinkLabel.AccessibleName = null;
            resources.ApplyResources(this.PolishLinkLabel, "PolishLinkLabel");
            this.PolishLinkLabel.Font = null;
            this.PolishLinkLabel.Name = "PolishLinkLabel";
            this.PolishLinkLabel.TabStop = true;
            this.PolishLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PolishLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = null;
            this.ControlBox = false;
            this.Controls.Add(this.PolishLinkLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SlovakLinkLabel);
            this.Controls.Add(this.SlovakLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FrenchLinkLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureRetrieve);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.buttonDonate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRetrieve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
		
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.dopplerradio.net");
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void AboutForm_Load(object sender, System.EventArgs e)
		{
			labelVersion.Text = "Version " + Application.ProductVersion;
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		

		private void buttonDonate_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.paypal.com/xclick/business=donations%40dopplerradio.net&no_shipping=0&no_note=1&tax=0");
		}

		private void pictureClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void FrenchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:pouts@msn.com");
        }

        private void SlovakLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mojepreklady.net/");

        }

        private void PolishLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:bercik1337@gmail.com");
        }

     
	}
}
