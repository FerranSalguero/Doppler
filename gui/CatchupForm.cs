using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Doppler.Properties;

namespace Doppler
{
    /// <summary>
    /// 
    /// </summary>
    public class CatchupForm : System.Windows.Forms.Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.ProgressBar progressBar1;

        private FeedItem feedItem;
        
        private HelpProvider helpProvider1;
        private Label label3;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CatchupForm(FeedItem feedItem)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
           
            this.feedItem = feedItem;

        }

        public CatchupForm()
        {
            InitializeComponent();
          
            this.feedItem = null;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatchupForm));
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.AccessibleDescription = null;
            this.buttonGo.AccessibleName = null;
            resources.ApplyResources(this.buttonGo, "buttonGo");
            this.buttonGo.BackgroundImage = null;
            this.buttonGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGo.Font = null;
            this.helpProvider1.SetHelpKeyword(this.buttonGo, null);
            this.helpProvider1.SetHelpNavigator(this.buttonGo, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("buttonGo.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.buttonGo, null);
            this.buttonGo.Name = "buttonGo";
            this.helpProvider1.SetShowHelp(this.buttonGo, ((bool)(resources.GetObject("buttonGo.ShowHelp"))));
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleDescription = null;
            this.buttonCancel.AccessibleName = null;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackgroundImage = null;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = null;
            this.helpProvider1.SetHelpKeyword(this.buttonCancel, null);
            this.helpProvider1.SetHelpNavigator(this.buttonCancel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("buttonCancel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.buttonCancel, null);
            this.buttonCancel.Name = "buttonCancel";
            this.helpProvider1.SetShowHelp(this.buttonCancel, ((bool)(resources.GetObject("buttonCancel.ShowHelp"))));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.helpProvider1.SetHelpKeyword(this.label1, null);
            this.helpProvider1.SetHelpNavigator(this.label1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.label1, null);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // numericValue
            // 
            this.numericValue.AccessibleDescription = null;
            this.numericValue.AccessibleName = null;
            resources.ApplyResources(this.numericValue, "numericValue");
            this.numericValue.Font = null;
            this.helpProvider1.SetHelpKeyword(this.numericValue, null);
            this.helpProvider1.SetHelpNavigator(this.numericValue, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("numericValue.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.numericValue, null);
            this.numericValue.Name = "numericValue";
            this.helpProvider1.SetShowHelp(this.numericValue, ((bool)(resources.GetObject("numericValue.ShowHelp"))));
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.helpProvider1.SetHelpKeyword(this.label2, null);
            this.helpProvider1.SetHelpNavigator(this.label2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.label2, null);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = null;
            this.progressBar1.AccessibleName = null;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.BackgroundImage = null;
            this.progressBar1.Font = null;
            this.helpProvider1.SetHelpKeyword(this.progressBar1, null);
            this.helpProvider1.SetHelpNavigator(this.progressBar1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("progressBar1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.progressBar1, null);
            this.progressBar1.Name = "progressBar1";
            this.helpProvider1.SetShowHelp(this.progressBar1, ((bool)(resources.GetObject("progressBar1.ShowHelp"))));
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = null;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.helpProvider1.SetHelpKeyword(this.label3, null);
            this.helpProvider1.SetHelpNavigator(this.label3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.label3, null);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // CatchupForm
            // 
            this.AcceptButton = this.buttonGo;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = null;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGo);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, null);
            this.helpProvider1.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this, resources.GetString("$this.HelpString"));
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatchupForm";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void buttonGo_Click(object sender, System.EventArgs e)
        {
            if (feedItem == null)
            {
                CatchUpAll();
            }
            else
            {
                CatchUpOne();
            }
            Settings.Default.Save();
        }

        private void CatchUpAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                progressBar1.Maximum = Settings.Default.Feeds.Count;
                progressBar1.Minimum = 0;
                for (int y = 0; y < Settings.Default.Feeds.Count; y++)
                {
                    FeedItem feedItem = Settings.Default.Feeds[y];
                    if (feedItem.IsChecked)
                    {
                        progressBar1.Value = y;
                        Rss.RssFeed rssFeed = Utils.GetFeed(Settings.Default.Feeds[y]);
                        if (rssFeed != null)
                        {

                            int Start = Convert.ToInt32(numericValue.Value);
                            
                            for (int q = Start; q < rssFeed.Channels[0].Items.Count; q++)
                            {

                                Rss.RssItem rssItem = rssFeed.Channels[0].Items[q];
                                if (Settings.Default.History[rssItem.GetHashCode().ToString()] == null)
                                {
                                    HistoryItem historyItem = new HistoryItem();
                                    historyItem.FeedGUID = feedItem.GUID;
                                    historyItem.Hashcode = rssItem.GetHashCode();
                                    historyItem.Title = rssItem.Title;
                                    historyItem.ItemDate = rssItem.PubDate.ToString();
                                    historyItem.FeedUrl = feedItem.Url;
                                    
                                    Settings.Default.History.Add(historyItem);
                                }
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error("Error during catch-up", ex);
                Cursor.Current = Cursors.Default;
                
                MessageBox.Show(ex.Message, languages.FormStrings.ErrorDuringCatchUp, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void CatchUpOne()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Rss.RssFeed rssFeed = Utils.GetFeed(feedItem);
                if (rssFeed != null)
                {
                    progressBar1.Maximum = rssFeed.Channels[0].Items.Count;
                    progressBar1.Minimum = 0;
                    
                    int Start = Convert.ToInt32(numericValue.Value);
                    
                    for (int q = Start; q < rssFeed.Channels[0].Items.Count; q++)
                    {
                        progressBar1.Value = q;
                        Rss.RssItem rssItem = rssFeed.Channels[0].Items[q];
                        if (Settings.Default.History[rssItem.GetHashCode().ToString()] == null)
                        {
                            HistoryItem historyItem = new HistoryItem();
                            historyItem.FeedGUID = feedItem.GUID;
                            historyItem.Hashcode = rssItem.GetHashCode();
                            historyItem.Title = rssItem.Title;
                            historyItem.ItemDate = rssItem.PubDate.ToString();
                            historyItem.FeedUrl = feedItem.Url;
                            
                            Settings.Default.History.Add(historyItem);
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error("Error during catch-up", ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, languages.FormStrings.ErrorDuringCatchUp, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
