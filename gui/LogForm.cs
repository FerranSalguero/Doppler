using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Doppler
{
	/// <summary>
	/// Summary description for frmLog.
	/// </summary>
	public class LogForm : System.Windows.Forms.Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private System.Windows.Forms.Button buttonClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonClearLog;
        private ListView listLogs;
        private ColumnHeader columnTime;
        private ColumnHeader columnWhere;
        private ColumnHeader columnMessage;
        private ColumnHeader columnType;
        private ListBox DateListBox;
		private System.Windows.Forms.Button buttonCopyToClipboard;
		//private Settings set;
		public LogForm()
		{

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.listLogs = new System.Windows.Forms.ListView();
            this.columnWhere = new System.Windows.Forms.ColumnHeader();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnType = new System.Windows.Forms.ColumnHeader();
            this.columnMessage = new System.Windows.Forms.ColumnHeader();
            this.DateListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleDescription = null;
            this.buttonClose.AccessibleName = null;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.BackgroundImage = null;
            this.buttonClose.Font = null;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AccessibleDescription = null;
            this.buttonRefresh.AccessibleName = null;
            resources.ApplyResources(this.buttonRefresh, "buttonRefresh");
            this.buttonRefresh.BackgroundImage = null;
            this.buttonRefresh.Font = null;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.AccessibleDescription = null;
            this.buttonClearLog.AccessibleName = null;
            resources.ApplyResources(this.buttonClearLog, "buttonClearLog");
            this.buttonClearLog.BackgroundImage = null;
            this.buttonClearLog.Font = null;
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleDescription = null;
            this.buttonCopyToClipboard.AccessibleName = null;
            resources.ApplyResources(this.buttonCopyToClipboard, "buttonCopyToClipboard");
            this.buttonCopyToClipboard.BackgroundImage = null;
            this.buttonCopyToClipboard.Font = null;
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // listLogs
            // 
            this.listLogs.AccessibleDescription = null;
            this.listLogs.AccessibleName = null;
            resources.ApplyResources(this.listLogs, "listLogs");
            this.listLogs.BackgroundImage = null;
            this.listLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWhere,
            this.columnTime,
            this.columnType,
            this.columnMessage});
            this.listLogs.FullRowSelect = true;
            this.listLogs.GridLines = true;
            this.listLogs.Name = "listLogs";
            this.listLogs.ShowGroups = false;
            this.listLogs.ShowItemToolTips = true;
            this.listLogs.UseCompatibleStateImageBehavior = false;
            this.listLogs.View = System.Windows.Forms.View.Details;
            // 
            // columnWhere
            // 
            resources.ApplyResources(this.columnWhere, "columnWhere");
            // 
            // columnTime
            // 
            resources.ApplyResources(this.columnTime, "columnTime");
            // 
            // columnType
            // 
            resources.ApplyResources(this.columnType, "columnType");
            // 
            // columnMessage
            // 
            resources.ApplyResources(this.columnMessage, "columnMessage");
            // 
            // DateListBox
            // 
            this.DateListBox.AccessibleDescription = null;
            this.DateListBox.AccessibleName = null;
            resources.ApplyResources(this.DateListBox, "DateListBox");
            this.DateListBox.BackgroundImage = null;
            this.DateListBox.FormattingEnabled = true;
            this.DateListBox.Name = "DateListBox";
            this.DateListBox.Sorted = true;
            this.DateListBox.SelectedIndexChanged += new System.EventHandler(this.DateListBox_SelectedIndexChanged);
            // 
            // LogForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = null;
            this.Controls.Add(this.DateListBox);
            this.Controls.Add(this.listLogs);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonClose);
            this.Name = "LogForm";
            this.SizeChanged += new System.EventHandler(this.frmLog_SizeChanged);
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void LogForm_Load(object sender, System.EventArgs e)
		{
			ShowLogEntries(null);
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
		private void ShowLogEntries(String dateToShow)
		{
			DateListBox.SelectedIndexChanged -= new EventHandler(DateListBox_SelectedIndexChanged);
            ListViewItem lvi;
            DateListBox.Items.Clear();
            listLogs.BeginUpdate();
            listLogs.Items.Clear();
            string xml = "<log>";
            try
            {
                foreach (string filename in Directory.GetFiles(Utils.GetAppDataFolder(), "DopplerLog.xml*"))
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        xml += reader.ReadToEnd();
                    }
                }
                xml += "</log>";
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            try
            {
                XmlDocument docLog = new XmlDocument();
                docLog.LoadXml(xml);

                XmlNode root = docLog.DocumentElement;
                XmlNodeList logEntries = root.ChildNodes;
                foreach (XmlNode logEntry in logEntries)
                {
                    string logger = logEntry.Attributes["logger"].InnerText;
                    if (logger.StartsWith("Doppler.")) logger = logger.Substring("Doppler.".Length);
                    if (logger.StartsWith("Controls.")) logger = logger.Substring("Controls.".Length);
                    lvi = new ListViewItem(logger);
                    DateTime dt = DateTime.Parse(logEntry.Attributes["timestamp"].InnerText);
                    if (!DateListBox.Items.Contains(dt.ToString("yyyy-MM-dd")))
                    {
                        DateListBox.Items.Add(dt.ToString("yyyy-MM-dd"));
                    }
                }
                if (dateToShow == null)
                {
                    dateToShow = (string)DateListBox.Items[DateListBox.Items.Count - 1];
                    DateListBox.SelectedItem = DateListBox.Items[DateListBox.Items.Count - 1];
				}
				else
				{
					DateListBox.SelectedItem = dateToShow;
				}

                foreach (XmlNode logEntry in logEntries)
                {

                    DateTime dt = DateTime.Parse(logEntry.Attributes["timestamp"].InnerText);
                    if (dt.ToString("yyyy-MM-dd") == dateToShow)
                    {
                        string logger = logEntry.Attributes["logger"].InnerText;
                        if (logger.StartsWith("Doppler.")) logger = logger.Substring("Doppler.".Length);
                        if (logger.StartsWith("Controls.")) logger = logger.Substring("Controls.".Length);
                        lvi = new ListViewItem(logger);
                        lvi.SubItems.Add(dt.ToString("HH:mm"));
                        string level = logEntry.Attributes["level"].InnerText;
                        lvi.SubItems.Add(level);
                        string msg = logEntry.ChildNodes[0].InnerText;

                        if (level == "ERROR")
                        {
                            lvi.ForeColor = Color.Red;
                            foreach (XmlNode childNode in logEntry.ChildNodes)
                            {
                                if (childNode.Name == "exception")
                                {
                                    lvi.ToolTipText = childNode.InnerText;
                                    break;
                                }
                            }
                        }

                        lvi.SubItems.Add(msg);

                        lvi.Tag = logEntry.OuterXml;
                        listLogs.Items.Add(lvi);
                        listLogs.EnsureVisible(lvi.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            listLogs.Columns[0].Width = -2;
            listLogs.Columns[1].Width = -2;
            listLogs.Columns[2].Width = -2;
            listLogs.Columns[3].Width = -2;
            listLogs.EndUpdate();
			DateListBox.SelectedIndexChanged += new EventHandler(DateListBox_SelectedIndexChanged);
		}

		private void buttonRefresh_Click(object sender, System.EventArgs e)
		{
			ShowLogEntries(null);
		}

		private void buttonClearLog_Click(object sender, System.EventArgs e)
		{
           foreach(string logfilename in Directory.GetFiles(Utils.GetAppDataFolder(),"DopplerLog.xml*"))
           {
               if(!logfilename.EndsWith(".xml"))
               {
                   File.Delete(logfilename);
               }
           }
           ShowLogEntries(null);
		}

		private void listLogs_Click(object sender, System.EventArgs e)
		{
			
		}

		private void buttonCopyToClipboard_Click(object sender, System.EventArgs e)
		{
			string strText = "";
			if(listLogs.SelectedItems.Count > 0)
			{
				for(int q=0;q<listLogs.SelectedItems.Count;q++)
				{
					ListViewItem lvi = listLogs.SelectedItems[q];
					strText += (string)lvi.Tag +"\r\n";
				}
				Clipboard.SetDataObject(strText);
			}
		}

        private void frmLog_SizeChanged(object sender, EventArgs e)
        {
            listLogs.Columns[0].Width = -2;
            listLogs.Columns[1].Width = -2;
            listLogs.Columns[2].Width = -2;
        }

        private void DateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dateToShow = (string)DateListBox.SelectedItem;
            ShowLogEntries(dateToShow);
        }

        
	}
}
