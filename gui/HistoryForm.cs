using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Doppler.Properties;

namespace Doppler
{
	/// <summary>
	/// Summary description for frmHistory.
	/// </summary>
	public class HistoryForm : System.Windows.Forms.Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Windows.Forms.Button buttonClearHistory;
        private System.Windows.Forms.Button buttonClose;
        private IContainer components;
        private System.Windows.Forms.Button buttonDelete;
        private ListView listHistory;
        private ColumnHeader columnDate;
        private ColumnHeader columnTitle;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteItemToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem openURLinbrowserToolStripMenuItem;
        private ColumnHeader columnFilename;
        private ToolStripMenuItem copyURLtoclipboardToolStripMenuItem;
		
		public HistoryForm(FeedItem feedItem)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            listHistory.BeginUpdate();
            foreach (HistoryItem historyItem in Settings.Default.History.GetItemsByFeedGUID(feedItem.GUID))
            {
                ListViewItem lvi = new ListViewItem(historyItem.ItemDate);

                lvi.SubItems.Add(historyItem.Title);
                if (historyItem.FileName != null)
                {
                    lvi.SubItems.Add(historyItem.FileName);
                }
                lvi.Tag = historyItem;
                listHistory.Items.Add(lvi);
            }
            foreach (ColumnHeader c in listHistory.Columns)
            {
                c.Width = -2;
            }
            listHistory.EndUpdate();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.buttonClearHistory = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listHistory = new System.Windows.Forms.ListView();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.columnTitle = new System.Windows.Forms.ColumnHeader();
            this.columnFilename = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openURLinbrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyURLtoclipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClearHistory
            // 
            this.buttonClearHistory.AccessibleDescription = null;
            this.buttonClearHistory.AccessibleName = null;
            resources.ApplyResources(this.buttonClearHistory, "buttonClearHistory");
            this.buttonClearHistory.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClearHistory.BackgroundImage = null;
            this.buttonClearHistory.Font = null;
            this.buttonClearHistory.Name = "buttonClearHistory";
            this.buttonClearHistory.UseVisualStyleBackColor = false;
            this.buttonClearHistory.Click += new System.EventHandler(this.buttonClearHistory_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleDescription = null;
            this.buttonClose.AccessibleName = null;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClose.BackgroundImage = null;
            this.buttonClose.Font = null;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AccessibleDescription = null;
            this.buttonDelete.AccessibleName = null;
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.BackgroundImage = null;
            this.buttonDelete.Font = null;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listHistory
            // 
            this.listHistory.AccessibleDescription = null;
            this.listHistory.AccessibleName = null;
            resources.ApplyResources(this.listHistory, "listHistory");
            this.listHistory.BackgroundImage = null;
            this.listHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnTitle,
            this.columnFilename});
            this.listHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.listHistory.Font = null;
            this.listHistory.FullRowSelect = true;
            this.listHistory.Name = "listHistory";
            this.listHistory.ShowGroups = false;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            this.listHistory.SelectedIndexChanged += new System.EventHandler(this.listHistory_SelectedIndexChanged);
            this.listHistory.SizeChanged += new System.EventHandler(this.listHistory_SizeChanged);
            // 
            // columnDate
            // 
            resources.ApplyResources(this.columnDate, "columnDate");
            // 
            // columnTitle
            // 
            resources.ApplyResources(this.columnTitle, "columnTitle");
            // 
            // columnFilename
            // 
            resources.ApplyResources(this.columnFilename, "columnFilename");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleDescription = null;
            this.contextMenuStrip1.AccessibleName = null;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.BackgroundImage = null;
            this.contextMenuStrip1.Font = null;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem,
            this.toolStripSeparator1,
            this.openURLinbrowserToolStripMenuItem,
            this.copyURLtoclipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.AccessibleDescription = null;
            this.deleteItemToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.deleteItemToolStripMenuItem, "deleteItemToolStripMenuItem");
            this.deleteItemToolStripMenuItem.BackgroundImage = null;
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // openURLinbrowserToolStripMenuItem
            // 
            this.openURLinbrowserToolStripMenuItem.AccessibleDescription = null;
            this.openURLinbrowserToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.openURLinbrowserToolStripMenuItem, "openURLinbrowserToolStripMenuItem");
            this.openURLinbrowserToolStripMenuItem.BackgroundImage = null;
            this.openURLinbrowserToolStripMenuItem.Name = "openURLinbrowserToolStripMenuItem";
            this.openURLinbrowserToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.openURLinbrowserToolStripMenuItem.Click += new System.EventHandler(this.openURLinbrowserToolStripMenuItem_Click);
            // 
            // copyURLtoclipboardToolStripMenuItem
            // 
            this.copyURLtoclipboardToolStripMenuItem.AccessibleDescription = null;
            this.copyURLtoclipboardToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyURLtoclipboardToolStripMenuItem, "copyURLtoclipboardToolStripMenuItem");
            this.copyURLtoclipboardToolStripMenuItem.BackgroundImage = null;
            this.copyURLtoclipboardToolStripMenuItem.Name = "copyURLtoclipboardToolStripMenuItem";
            this.copyURLtoclipboardToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.copyURLtoclipboardToolStripMenuItem.Click += new System.EventHandler(this.copyURLtoclipboardToolStripMenuItem_Click);
            // 
            // HistoryForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = null;
            this.Controls.Add(this.listHistory);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClearHistory);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = null;
            this.Name = "HistoryForm";
            this.ShowInTaskbar = false;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void buttonClearHistory_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			try 
			{
                if (Settings.Default.LogLevel > 1) log.Info("Clearing " + listHistory.Items.Count.ToString() + " from log");
                
				for(int q=0;q<listHistory.Items.Count;q++)
				{
                    
					HistoryItem historyItem = (HistoryItem) listHistory.Items[q].Tag;
					Settings.Default.History.Remove(historyItem);
					
				}
				listHistory.Items.Clear();
			} 
			catch (Exception ex)
			{
                if (Settings.Default.LogLevel > 0) log.Error(ex);
			} 
			finally 
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuOpenURLinBrowser_Click(object sender, System.EventArgs e)
		{
			
		}

		private void menuCopyURLtoClipboard_Click(object sender, System.EventArgs e)
		{
			string strText = "";
			if(listHistory.SelectedItems.Count > 0)
			{
				ListViewItem lvi = listHistory.SelectedItems[0];
				strText = lvi.SubItems[2].Text;
				Clipboard.SetDataObject(strText);
			}
		}

		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			
			if(listHistory.SelectedItems.Count > 0)
			{
				ListViewItem lvi = listHistory.SelectedItems[0];
                HistoryItem historyItem = (HistoryItem)lvi.Tag;

                Settings.Default.History.Remove(historyItem);

                listHistory.BeginUpdate();
                listHistory.Items.Remove(lvi);
                listHistory.EndUpdate();
			}
		}

        private void listHistory_SizeChanged(object sender, EventArgs e)
        {
            foreach (ColumnHeader c in listHistory.Columns)
            {
                c.Width = -2;
            }

        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listHistory.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listHistory.SelectedItems[0];
                HistoryItem historyItem = (HistoryItem)lvi.Tag;
                Settings.Default.History.Remove(historyItem);

                listHistory.BeginUpdate();
                listHistory.Items.Remove(lvi);
                listHistory.EndUpdate();


            }
        }

        private void openURLinbrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listHistory.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listHistory.SelectedItems[0];
                System.Diagnostics.Process.Start(lvi.SubItems[0].Text);
            }
        }

        private void copyURLtoclipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strText = "";
            if (listHistory.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listHistory.SelectedItems[0];
                strText = lvi.SubItems[1].Text;
                Clipboard.SetDataObject(strText);
            }
        }

        private void listHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listHistory.SelectedItems.Count > 0)
            {
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }
        }
	}
}
