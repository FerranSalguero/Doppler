using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Doppler.Properties;

namespace Doppler
{
	/// <summary>
	/// Summary description for frmDirectory.
	/// </summary>
	public class OPMLDirectoryForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TextBox AddressTextBox;
		
		private DirectoryItem _directoryItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public DirectoryItem DirectoryItem
        {
            get { return _directoryItem; }
            set { _directoryItem = value; }
        }

		public OPMLDirectoryForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            _directoryItem = new DirectoryItem();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public OPMLDirectoryForm(DirectoryItem directoryItem)
		{
			//
			// Required for Windows Form Designer support
			//
            InitializeComponent();
			_directoryItem = directoryItem;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(329, 60);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "&Cancel";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOK.Location = new System.Drawing.Point(248, 60);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 25);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(56, 8);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(348, 20);
            this.NameTextBox.TabIndex = 13;
            this.NameTextBox.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AddressTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.AddressTextBox.Location = new System.Drawing.Point(56, 34);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(348, 20);
            this.AddressTextBox.TabIndex = 14;
            this.AddressTextBox.Text = "http://";
            this.AddressTextBox.TextChanged += new System.EventHandler(this.textAddress_TextChanged);
            // 
            // OPMLDirectoryForm
            // 
            this.AcceptButton = this.buttonOK;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(408, 90);
            this.ControlBox = false;
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPMLDirectoryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Directory";
            this.Load += new System.EventHandler(this.OPMLDirectoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void OPMLDirectoryForm_Load(object sender, System.EventArgs e)
		{
			if(_directoryItem.GUID != null)
			{
				NameTextBox.Text = _directoryItem.Name;
				AddressTextBox.Text = _directoryItem.URL;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
	    {
            _directoryItem.Name = NameTextBox.Text;
            _directoryItem.URL = AddressTextBox.Text;
        }

		private void textName_TextChanged(object sender, System.EventArgs e)
		{
			if(NameTextBox.Text != "" && AddressTextBox.Text.ToLower() != "http://")
			{
				buttonOK.Enabled = true;
			} 
			else 
			{
				buttonOK.Enabled = false;
			}
		}

		private void textAddress_TextChanged(object sender, System.EventArgs e)
		{
			if(NameTextBox.Text != "" && AddressTextBox.Text.ToLower() != "http://")
			{
				buttonOK.Enabled = true;
			} 
			else 
			{
				buttonOK.Enabled = false;
			}
		}
	}
}
