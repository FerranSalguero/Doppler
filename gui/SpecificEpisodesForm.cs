using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Doppler.Properties;

namespace Doppler
{
    public partial class SpecificEpisodesForm : Form
    {
        public Rss.RssFeed feed = new Rss.RssFeed();
        private FeedItem feedItem;
        public FeedItem feedItemToCheck;
        public SpecificEpisodesForm(FeedItem feedItem)
        {
            InitializeComponent();
            this.feedItem = feedItem;
            FillPosts(feedItem);
        }

        private void SpecificEpisodesForm_Load(object sender, EventArgs e)
        {
            FeedTitleLabel.Text = feedItem.Title;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            
        }

        private bool FillPosts(FeedItem feedItem)
        {
            Rss.RssChannel rssChannel = Utils.GetFeed(feedItem).Channels[0];
            bool boolRead = false;
            PostsListView.Items.Clear();

            PostsListView.BeginUpdate();

            rssChannel.Items.Sort();
            for (int q = 0; q < rssChannel.Items.Count; q++)
            {
                if (feedItem.ReadPosts != null)
                {
                    foreach (string hashRead in feedItem.ReadPosts)
                    {
                        boolRead = false;
                        string strHash = rssChannel.Items[q].GetHashCode().ToString();
                        if (hashRead == strHash)
                        {
                            boolRead = true;
                            break;
                        }
                    }
                }
                else
                {
                    boolRead = false;
                }
                Rss.RssItem rssItem = rssChannel.Items[q];

                if (rssItem.Enclosure != null)
                {
                    // RssItem rssItem = rssFeed.Items[q];
                    rssItem.Read = boolRead;
                    if (Settings.Default.History[rssItem.GetHashCode().ToString()] == null)
                    {
                        rssItem.EnclosureDownloaded = false;
                        ListViewItem lvi = new ListViewItem();
                     
                        lvi.SubItems.Add(rssItem.Title);
                        lvi.SubItems.Add(rssItem.PubDate.ToString("yyyy-MM-dd"));
                        lvi.Tag = rssItem;
                        PostsListView.Items.Add(lvi);
                    }
                   
                }
            }

            foreach (ColumnHeader c in PostsListView.Columns)
            {
                c.Width = -2;
            }
            PostsListView.EndUpdate();
            return boolRead;
        }

        private void QueueButton_Click(object sender, EventArgs e)
        {
            Rss.RssChannel channel = new Rss.RssChannel();
            channel.Description = languages.FormStrings.TemporaryDownloadChannel;
            feed.Channels.Add(channel);
            foreach (ListViewItem lvi in PostsListView.Items)
            {
                if (lvi.Checked == true)
                {
                    Rss.RssItem item = (Rss.RssItem)lvi.Tag;
                    channel.Items.Add(item);
                }
            }
        }
    }
}