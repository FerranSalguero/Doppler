using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;


namespace DopplerControls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class PostViewer : System.Windows.Forms.UserControl
    {
		public System.Windows.Forms.Label labelItemTitle;
		public object viewerTag;
		public string EnclosureURL;
        private System.Windows.Forms.Timer timerPlayer;
        private WebBrowser webBrowser1;
		private System.ComponentModel.IContainer components;
		public PostViewer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.labelItemTitle = new System.Windows.Forms.Label();
            this.timerPlayer = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // labelItemTitle
            // 
            this.labelItemTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemTitle.AutoSize = true;
            this.labelItemTitle.BackColor = System.Drawing.SystemColors.Control;
            this.labelItemTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemTitle.Location = new System.Drawing.Point(6, 8);
            this.labelItemTitle.Name = "labelItemTitle";
            this.labelItemTitle.Size = new System.Drawing.Size(124, 13);
            this.labelItemTitle.TabIndex = 12;
            this.labelItemTitle.Text = "                                       ";
            this.labelItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 30);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(311, 242);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // PostViewer
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.labelItemTitle);
            this.Name = "PostViewer";
            this.Size = new System.Drawing.Size(312, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void Clear()
		{
	        webBrowser1.DocumentText = "";
        }

		public void SetHTML(string HTML)
		{

            StringBuilder sb = new StringBuilder("<html>");
            sb.Append("<head>");
            sb.Append("<style type=\"text/css\">");
            sb.Append("body {font-family:Tahoma, Verdana,Sans-serif; font-size:9pt; margin:0; padding:0; background:#fff; color:#000}");
            sb.Append("td,form {font-family:Tahoma,Verdana,Sans-serif; font-size:9pt;}");
            sb.Append("A {color:#66c; text-decoration: none;}");
            sb.Append("A.black {color:#000; text-decoration: none;}");
            sb.Append("A:hover, A:active {text-decoration: underline;}");
            sb.Append("</style>");
            sb.Append("<base target=\"_blank\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<table width=\"100%\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\"><tr><td>");
            sb.Append(HTML);
            sb.Append("</td></tr></table>");
            sb.Append("</body>");
            sb.Append("</html>");
			
            webBrowser1.DocumentText = sb.ToString();
         
		}	

	}

}
