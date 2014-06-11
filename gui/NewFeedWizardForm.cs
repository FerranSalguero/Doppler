using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Doppler.Properties;
using Doppler.languages;
using System.Web;
using System.Net;

namespace Doppler
{
    public partial class NewFeedWizardForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FeedItem _feedItem;
        private bool _showAdvancedDialog;
        private string url = null;

        public NewFeedWizardForm(string Url)
        {
            InitializeComponent();
            url = Url;
            this.ActiveControl = UrlTextBox;
            ShowAdvancedCheckBox.Checked = Settings.Default.ShowAdvancedFeedDialog;
        }

        public NewFeedWizardForm()
        {
            InitializeComponent();
            this.ActiveControl = UrlTextBox;
            ShowAdvancedCheckBox.Checked = Settings.Default.ShowAdvancedFeedDialog;
        }

        private void NewFeedWizardForm_Load(object sender, EventArgs e)
        {
            FeedItem feedItem = new FeedItem();
            feedItem.GUID = Guid.NewGuid().ToString();
            string strClipboard = Clipboard.GetText();
            if (strClipboard.ToLower().StartsWith("http") && url == null)
            {
                feedItem.Url = strClipboard;
            }
            if (url != null) feedItem.Url = url;
            
            if (Settings.Default.DefaultItem != null)
            {
                feedItem.CleanRating = Settings.Default.DefaultItem.CleanRating;
                feedItem.PlaylistName = Settings.Default.DefaultItem.PlaylistName;
                feedItem.Pubdate = "-" + FormStrings.newfeed + "-";
                feedItem.MaxMb = Settings.Default.DefaultItem.MaxMb;
                feedItem.RetrieveNumberOfFiles = Settings.Default.DefaultItem.RetrieveNumberOfFiles;
                feedItem.Spacesaver_Days = Settings.Default.DefaultItem.Spacesaver_Days;
                feedItem.Spacesaver_Files = Settings.Default.DefaultItem.Spacesaver_Files;
                feedItem.Spacesaver_Files = Settings.Default.DefaultItem.Spacesaver_Files;
                feedItem.TagAlbum = Settings.Default.DefaultItem.TagAlbum;
                feedItem.TagGenre = Settings.Default.DefaultItem.TagGenre;
                feedItem.TagArtist = Settings.Default.DefaultItem.TagArtist;
                feedItem.Textfilter = Settings.Default.DefaultItem.Textfilter;
                feedItem.UseSpaceSavers = Settings.Default.DefaultItem.UseSpaceSavers;
                feedItem.RemoveFromPlaylist = Settings.Default.DefaultItem.RemoveFromPlaylist;
                feedItem.RemovePlayed = Settings.Default.DefaultItem.RemovePlayed;
                feedItem.IsChecked = true;
            }
            UrlTextBox.Text = feedItem.Url;
            if (UrlTextBox.Text == "")
            {
                UrlTextBox.Text = "http://";
                UrlTextBox.SelectionStart = 7;
            }
            _feedItem = feedItem;
        }

        public FeedItem FeedItem
        {
            get { return _feedItem; }
            set { _feedItem = value; }
        }

        public bool ShowAdvancedDialog
        {
            get { return _showAdvancedDialog; }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowAdvancedFeedDialog = ShowAdvancedCheckBox.Checked;

            _feedItem.Url = UrlTextBox.Text;
            _showAdvancedDialog = ShowAdvancedCheckBox.Checked;
            _feedItem.Authenticate = LoginCheckBox.Checked;
            if (LoginCheckBox.Checked)
            {
                _feedItem.Username = UsernameTextBox.Text;
                _feedItem.Password = PasswordTextBox.Text;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Rss.RssFeed feed = Utils.GetFeed(_feedItem);

                if (feed.Exceptions.Count == 0)
                {

                    char[] trimChars = new char[4];
                    trimChars[0] = ' ';
                    trimChars[1] = '\n';
                    trimChars[2] = '\r';
                    trimChars[3] = '\t';
                    string strTitle = feed.Channels[0].Title.Trim(trimChars);
                    int intCounter = 1;
                    while (IsTitleUnique(strTitle, _feedItem.GUID) == false)
                    {
                        strTitle = feed.Channels[0].Title.Trim(trimChars) + " (" + intCounter.ToString() + ")";
                        intCounter++;
                    }
                    _feedItem.Title = feed.Channels[0].Title.Trim(trimChars);
                    _feedItem.FeedHashCode = feed.GetHashCode().ToString("X");
                    if (feed.Channels[0].Description != null)
                    {
                        _feedItem.Description = feed.Channels[0].Description;
                    }

                    Settings.Default.Feeds.Add(_feedItem);
                }
                else
                {
                    MessageBox.Show(FormStrings.NotAValidFeedCheckTheLogForMoreInformation, FormStrings.ErrorAddingFeed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _feedItem = null;
                    if (Settings.Default.LogLevel > 0) log.Error("Add feed", feed.Exceptions.LastException);
                }
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(FormStrings.NotAValidFeedCheckTheLogForMoreInformation, FormStrings.ErrorAddingFeed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Settings.Default.LogLevel > 0) log.Error("Add feed", ex);
                _feedItem = null;
                Cursor.Current = Cursors.Default;
            }
        }

        private bool IsTitleUnique(string strTitle, string strGUID)
        {
            bool boolReturn = true;
            for (int q = 0; q < Settings.Default.Feeds.Count; q++)
            {
                if (Settings.Default.Feeds[q].Title == strTitle && Settings.Default.Feeds[q].GUID != strGUID)
                {
                    boolReturn = false;
                }
            }
            return boolReturn;
        }

        private void LoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LoginCheckBox.Checked == true)
            {
                UsernameTextBox.Enabled = true;
                PasswordTextBox.Enabled = true;
            }
            else
            {
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
            }
        }

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UrlTextBox.Text == "")
            {
                UrlTextBox.Text = "http://";
                UrlTextBox.SelectionStart = 7;
            }
        }
    }
}