using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using Doppler.Properties;
using System.Threading;
using Doppler.languages;

namespace Doppler
{
	/// <summary>
	/// Summary description for frmBrowseOpml.
	/// </summary>
	public class BrowseOPMLForm : System.Windows.Forms.Form
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Tree containing the OPML Feeds
        /// </summary>
		public System.Windows.Forms.TreeView OPMLTreeView;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Button SubscribeButton;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox DirectoryDropDown;
        private Button AddNewDirectoryButton;
        private TextBox UrlTextBox;
		
        /// <summary>
        /// FeedList containing the feeds selected from the OPML Feed selection box
        /// </summary>
		public FeedList selectedFeeds;
		
        /// <summary>
        /// Form to Browse an OPML directory
        /// </summary>
		public BrowseOPMLForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseOPMLForm));
            this.OPMLTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.SubscribeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectoryDropDown = new System.Windows.Forms.ComboBox();
            this.AddNewDirectoryButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OPMLTreeView
            // 
            resources.ApplyResources(this.OPMLTreeView, "OPMLTreeView");
            this.OPMLTreeView.ImageList = this.imageList1;
            this.OPMLTreeView.Name = "OPMLTreeView";
            this.OPMLTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OPMLTreeView_AfterCheck);
            this.OPMLTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OPMLTreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SubscribeButton
            // 
            resources.ApplyResources(this.SubscribeButton, "SubscribeButton");
            this.SubscribeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SubscribeButton.Name = "SubscribeButton";
            this.SubscribeButton.Click += new System.EventHandler(this.SubscribeButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DirectoryDropDown
            // 
            resources.ApplyResources(this.DirectoryDropDown, "DirectoryDropDown");
            this.DirectoryDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectoryDropDown.Name = "DirectoryDropDown";
            this.DirectoryDropDown.Sorted = true;
            this.DirectoryDropDown.SelectedIndexChanged += new System.EventHandler(this.DirectoryDropDown_SelectedIndexChanged);
            // 
            // AddNewDirectoryButton
            // 
            resources.ApplyResources(this.AddNewDirectoryButton, "AddNewDirectoryButton");
            this.AddNewDirectoryButton.Name = "AddNewDirectoryButton";
            this.AddNewDirectoryButton.UseVisualStyleBackColor = true;
            this.AddNewDirectoryButton.Click += new System.EventHandler(this.AddNewDirectoryButton_Click);
            // 
            // UrlTextBox
            // 
            resources.ApplyResources(this.UrlTextBox, "UrlTextBox");
            this.UrlTextBox.BackColor = System.Drawing.Color.White;
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.ReadOnly = true;
            // 
            // BrowseOPMLForm
            // 
            this.AcceptButton = this.SubscribeButton;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.CloseButton;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.AddNewDirectoryButton);
            this.Controls.Add(this.DirectoryDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubscribeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OPMLTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowseOPMLForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.BrowseOPMLForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void BrowseOPMLForm_Load(object sender, System.EventArgs e)
		{
			this.selectedFeeds = new FeedList();
            FillDirectoryList();
		}

        private void FillDirectoryList()
        {
            DirectoryDropDown.Items.Clear();
            DirectoryDropDown.Items.Add("- " + FormStrings.SelectDirectory + " -");
            DirectoryDropDown.SelectedIndex = 0;
            if (Settings.Default.DirectoryList != null)
            {
                for (int q = 0; q < Settings.Default.DirectoryList.Count; q++)
                {
                    if (Settings.Default.DirectoryList[q].Name != null && Settings.Default.DirectoryList[q].Name != "")
                    {
                        DirectoryDropDown.Items.Add(Settings.Default.DirectoryList[q]);
                    }
                }

                DirectoryDropDown.Text = FormStrings.SelectDirectory;
            }
            else
            {
                MessageBox.Show(FormStrings.PleaseaddsomeOPMLdirectoriesfirstintheoptions, FormStrings.Nodirectoriesavailable, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

		private void populateTree()
		{
			Cursor.Current = Cursors.WaitCursor;
			OPMLTreeView.Nodes.Clear();
			OPMLTreeView.BeginUpdate();
			System.Net.WebClient Client = new WebClient();
			System.IO.Stream strm = null; 
			string opmlUrl = "";
		
			try
			{
				DirectoryItem dirItem = (DirectoryItem) DirectoryDropDown.SelectedItem;
				opmlUrl = dirItem.URL;
				
				strm = Client.OpenRead(opmlUrl);

				XmlNodeList opmlCategories = null;
				XmlDocument doc = new XmlDocument();
				
				doc.Load(opmlUrl);
		
				XmlNode body = doc.DocumentElement.SelectSingleNode("body");
				
				opmlCategories = body.SelectNodes("outline[not(@type='link')]");
				if(opmlCategories != null)
				{
					foreach(XmlNode category in opmlCategories)
					{
						string strCat = "";
						if(category.Attributes["title"] != null)
						{
							strCat = category.Attributes["title"].InnerText;
						} 
						else 
						{
							strCat = category.Attributes["text"].InnerText;
						}
						TreeNode catNode = OPMLTreeView.Nodes.Add(strCat);
						catNode.ImageIndex = 0;
						catNode.SelectedImageIndex = 2;
						// check if we have items at this level
						XmlNodeList opmlEntries = category.SelectNodes("outline[(@type='link')]");
						foreach(XmlNode opmlEntry in opmlEntries)
						{
							string strTitle = "";
							if(opmlEntry.Attributes["title"] != null)
							{
								strTitle = opmlEntry.Attributes["title"].InnerText;
							} 
							else 
							{
								strTitle = opmlEntry.Attributes["text"].InnerText;
							}
							TreeNode entry = new TreeNode(strTitle);
							
							string strXmlUrl = "";
							if(opmlEntry.Attributes["xmlUrl"] != null)
							{
								strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
							} 
							else 
							{
								strXmlUrl = opmlEntry.Attributes["url"].InnerText;
							}
							entry.Tag = strXmlUrl;
							if(strXmlUrl.Substring(strXmlUrl.LastIndexOf(".")+1).ToLower() == "opml")
							{
								entry.ImageIndex = 0;
								entry.SelectedImageIndex = 2;
							} 
							else 
							{
								entry.ImageIndex = 1;
								entry.SelectedImageIndex = 1;
							}
							catNode.Nodes.Add(entry);
						}


						
						GetCategories(category, catNode);
						

					}

					// check for root level items
					XmlNodeList opmlOutlineEntries = body.SelectNodes("outline[@type='link']");
					foreach(XmlNode opmlEntry in opmlOutlineEntries)
					{
						string strTitle = "";
						if(opmlEntry.Attributes["title"] != null)
						{
							strTitle = opmlEntry.Attributes["title"].InnerText;
						} 
						else 
						{
							strTitle = opmlEntry.Attributes["text"].InnerText;
						}
						TreeNode entry = new TreeNode(strTitle);
						string strXmlUrl = "";
						if(opmlEntry.Attributes["xmlUrl"] != null)
						{
							strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
						} 
						else 
						{
							strXmlUrl = opmlEntry.Attributes["url"].InnerText;
						}
						entry.Tag = strXmlUrl;
						if(strXmlUrl.Substring(strXmlUrl.LastIndexOf(".")+1).ToLower() == "opml")
						{
							entry.ImageIndex = 0;
							entry.SelectedImageIndex = 2;
						} 
						else 
						{
							entry.ImageIndex = 1;
							entry.SelectedImageIndex = 1;
						}
						OPMLTreeView.Nodes.Add(entry);
					}
					// end check
				}
			} 
			catch (Exception ex)
			{
                log.Error(ex);
				MessageBox.Show("Error\n\n"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
			} 
			finally 
			{
			if(strm != null) strm.Close();
			OPMLTreeView.EndUpdate();
			Cursor.Current = Cursors.Default;
			}

		}

		private void GetCategories(XmlNode node, TreeNode treeNode)
		{
			Cursor.Current = Cursors.WaitCursor;
			string strCat = "";
			if(node.Attributes["title"] != null)
			{
				strCat = node.Attributes["title"].InnerText;
			} 
			else 
			{
				strCat = node.Attributes["text"].InnerText;
			}
			XmlNodeList categories = node.SelectNodes("outline[not(@type='link')]");

			if(categories != null)
			{
			
						
				foreach(XmlNode category in categories)
				{	
								
					string strCatTitle = "";
					if(category.Attributes["title"] != null)
					{
						strCatTitle = category.Attributes["title"].InnerText;
					} 
					else 
					{
						strCatTitle = category.Attributes["text"].InnerText;
					}
							
					TreeNode catNode = treeNode.Nodes.Add(strCatTitle);
							
					catNode.ImageIndex = 0;
					catNode.SelectedImageIndex = 2;
					XmlNodeList opmlEntries = category.SelectNodes("outline[@type='link']");
					foreach(XmlNode opmlEntry in opmlEntries)
					{
						string strTitle = "";
						if(opmlEntry.Attributes["title"] != null)
						{
							strTitle = opmlEntry.Attributes["title"].InnerText;
						} 
						else 
						{
							strTitle = opmlEntry.Attributes["text"].InnerText;
						}
						TreeNode entry = new TreeNode(strTitle);
						string strXmlUrl = "";
						if(opmlEntry.Attributes["xmlUrl"] != null)
						{
							strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
						} 
						else 
						{
							strXmlUrl = opmlEntry.Attributes["url"].InnerText;
						}
						entry.Tag = strXmlUrl;
						if(strXmlUrl.Substring(strXmlUrl.LastIndexOf(".")+1).ToLower() == "opml")
						{
							entry.ImageIndex = 0;
							entry.SelectedImageIndex = 2;
						} 
						else 
						{
							entry.ImageIndex = 1;
							entry.SelectedImageIndex = 1;
						}
						catNode.Nodes.Add(entry);
					}

					GetCategories(category, catNode);
				}
				
		
			}
			Cursor.Current = Cursors.Default;
		}

		private void OPMLTreeView_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Checked == true)
			{
				if(e.Node.Tag != null)
				{
					if(this.selectedFeeds.GetFeeditemByUrl(e.Node.Tag.ToString()) == null)
					{
						FeedItem fi = new FeedItem();
						fi.Title = e.Node.Text;
						fi.Url = e.Node.Tag.ToString();
						this.selectedFeeds.Add(fi);
					}
				}

				for(int q=0;q<e.Node.Nodes.Count;q++)
				{
					e.Node.Nodes[q].Checked = true;
					
				}
			} 
			else 
			{
				if(e.Node.Tag != null)
				{
					this.selectedFeeds.Remove(e.Node.Tag.ToString());
				}
				for(int q=0;q<e.Node.Nodes.Count;q++)
				{
					e.Node.Nodes[q].Checked = false;
			
				}
			}
		}

		private void OPMLTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			
			if(e.Node.Tag != null)
			{
				string strUrl = e.Node.Tag.ToString();
				if(strUrl.Substring(strUrl.LastIndexOf(".")+1).ToLower() == "opml")
				{
					if(e.Node.Nodes.Count == 0)
					{
						// only retrieve them once during this session
						System.Net.WebClient Client = new WebClient();
						Stream strm = Client.OpenRead(strUrl);

						XmlDocument doc = new XmlDocument();
							
						doc.Load(strm);

						XmlNode body = doc.DocumentElement.SelectSingleNode("body");
						XmlNodeList opmlCategories = body.SelectNodes("outline[not(@type='link')]");
						if(opmlCategories != null)
						{
							foreach(XmlNode category in opmlCategories)
							{
								string strCat = "";
								if(category.Attributes["title"] != null)
								{
									strCat = category.Attributes["title"].InnerText;
								} 
								else 
								{
									strCat = category.Attributes["text"].InnerText;
								}
								TreeNode catNode = e.Node.Nodes.Add(strCat);
								catNode.ImageIndex = 0;
								catNode.SelectedImageIndex = 2;
								// check if we have items at this level
								XmlNodeList opmlEntries = category.SelectNodes("outline[(@type='link')]");
								foreach(XmlNode opmlEntry in opmlEntries)
								{
									string strTitle = "";
									if(opmlEntry.Attributes["title"] != null)
									{
										strTitle = opmlEntry.Attributes["title"].InnerText;
									} 
									else 
									{
										strTitle = opmlEntry.Attributes["text"].InnerText;
									}
									TreeNode entry = new TreeNode(strTitle);
							
									string strXmlUrl = "";
									if(opmlEntry.Attributes["xmlUrl"] != null)
									{
										strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
									} 
									else 
									{
										strXmlUrl = opmlEntry.Attributes["url"].InnerText;
									}
									entry.Tag = strXmlUrl;
									if(strXmlUrl.Substring(strXmlUrl.LastIndexOf(".")+1).ToLower() == "opml")
									{
										entry.ImageIndex = 0;
										entry.SelectedImageIndex = 2;
									} 
									else 
									{
										entry.ImageIndex = 1;
										entry.SelectedImageIndex = 1;
									}
									catNode.Nodes.Add(entry);
								}
						
								GetCategories(category, catNode);
						

							}
						}
					}
				} 
				else 
				{
					UrlTextBox.Text = e.Node.Tag.ToString();
				}	

			} 
			else 
			{
				UrlTextBox.Text = "";
			}
		}

		private void CloseButton_Click(object sender, System.EventArgs e)
		{
		
		}

		private void SubscribeButton_Click(object sender, System.EventArgs e)
		{
           
            NewFeedWizardForm newFeedWizardForm = new NewFeedWizardForm(UrlTextBox.Text);
            
            if (newFeedWizardForm.ShowDialog() == DialogResult.OK)
            {
                FeedItem feedItem = newFeedWizardForm.FeedItem;
                if (feedItem != null)
                {
                    Settings.Default.Feeds.Add(feedItem);
                }
            }
			newFeedWizardForm.Dispose();
		}

		private void DirectoryDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			if(DirectoryDropDown.Text != "- " + FormStrings.SelectDirectory + " -")
			{
                OPMLTreeView.Nodes.Clear();
                DirectoryItem dirItem = (DirectoryItem)DirectoryDropDown.SelectedItem;
                OPMLRetriever opmlRetriever = new OPMLRetriever(dirItem);
                opmlRetriever.AddNode += new AddNodeHandler(opmlRetriever_AddNode);
                opmlRetriever.AddNodeToNode += new AddNodeToNodeHandler(opmlRetriever_AddNodeToNode);
                opmlRetriever.AddNodeToNodeWithText += new AddNodeToNodeWithTextHandler(opmlRetriever_AddNodeToNodeWithText);
                opmlRetriever.AddNodeWithText += new AddNodeWithTextHandler(opmlRetriever_AddNodeWithText);
                Thread oThread = new Thread(new ThreadStart(opmlRetriever.populateTree));
                oThread.IsBackground = true;
                oThread.Start();
			} 
			else 
			{
				OPMLTreeView.Nodes.Clear();
			}
		}

        
        private delegate int AddTreeNode(TreeNode treeNode);
        private delegate TreeNode AddTreeNodeWithText(string strNode);
           

        TreeNode opmlRetriever_AddNodeToNodeWithText(TreeNode treeNode, string strNode)
        {
            return (TreeNode)OPMLTreeView.Invoke(new AddTreeNodeWithText(treeNode.Nodes.Add), new object[] { strNode });
        }


        TreeNode opmlRetriever_AddNodeWithText(string strNode)
        {
            return (TreeNode)OPMLTreeView.Invoke(new AddTreeNodeWithText(OPMLTreeView.Nodes.Add), new object[] { strNode });
        }

        int opmlRetriever_AddNodeToNode(TreeNode treeNode1, TreeNode treeNode2)
        {
            return (int) OPMLTreeView.Invoke(new AddTreeNode(treeNode1.Nodes.Add), new object[] { treeNode2 });
        }

        int opmlRetriever_AddNode(TreeNode treeNode)
        {
            return (int) OPMLTreeView.Invoke(new AddTreeNode(OPMLTreeView.Nodes.Add), new object[] { treeNode });
        }

        private void AddNewDirectoryButton_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm("tabDirectories");
            optionsForm.ShowDialog();
            optionsForm.Dispose();
            FillDirectoryList();
        }
	}
}
