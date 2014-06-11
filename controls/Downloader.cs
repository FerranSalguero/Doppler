using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Drawing.Drawing2D;
using Doppler.Properties;
using Doppler;
using Doppler.Controls;
using WMPLib;
using System.Xml;
using System.Runtime.InteropServices;
using iTunesLib;
using Microsoft.Win32;
using Doppler.languages;

namespace DopplerControls
{
    /// <summary>
    /// Summary description for Downloader.
    /// </summary>
    /// 

    public delegate void FileDownloadCompleteHandler(DownloadItem item, ListViewItem lvi);
    public delegate void FileDownloadAbortedHandler(DownloadItem item, ListViewItem lvi);
    public delegate void FileDownloadErrorHandler(DownloadItem item, string Error, Exception ex);
    public delegate void SetInformationLabelHandler(string message, bool visible);
    public delegate void AllAbortedHandler();
    
    public class Downloader : System.Windows.Forms.UserControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event FileDownloadCompleteHandler FileDownloadComplete;
        public event FileDownloadAbortedHandler FileDownloadAborted;
        public event FileDownloadErrorHandler FileDownloadError;
        public event SetInformationLabelHandler SetInformationLabel;
        public event AllAbortedHandler AllAborted;
  
        private System.Windows.Forms.ImageList listIcons;
        private System.ComponentModel.IContainer components;
        private Doppler.classes.ListViewNF listEntries;
        private ColumnHeader columnFile;
        private ColumnHeader columnProgress;
        private ColumnHeader columnFeed;
        private Hashtable hashTags;
        private ContextMenuStrip contextMenuDownloader;
        private ToolStripMenuItem canceldownloadToolStripMenuItem;
        private ColumnHeader columnETA;

        private bool iTunesBusy = false;
        //private ArrayList queue = new ArrayList();
        private RetrieverPool _retrieverPool;

        /// <summary>
        /// Doppler downloader component
        /// </summary>
        public Downloader()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint,true); 

            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _retrieverPool = new RetrieverPool(Settings.Default.MaxThreads);
        }

        //public void AddTorrent(DownloadItem item)
        //{

        //    if (item.Url != null && item.Url != "")
        //    {
        //        hashTags = new Hashtable();

        //        ListViewItem lvi = new ListViewItem();
        //        lvi.Group = listEntries.Groups["BitTorrent downloads"];
        //        lvi.SubItems.Add("");
        //        lvi.SubItems.Add("");
        //        listEntries.Invoke(new AddListViewItem(listEntries.Items.Add), new object[] { lvi });
        //        TorrentDownloader torrentDownloader = new TorrentDownloader(item, lvi);

        //        torrentDownloader.DownloadProgress += new TorrentDownloadProgressHandler(torrentDownloader_DownloadProgress);
        //        torrentDownloader.DownloadComplete += new TorrentDownloadCompleteHandler(torrentDownloader_DownloadComplete);
        //        torrentDownloader.DownloadStatusChanged += new TorrentDownloadStatusChanged(torrentDownloader_DownloadStatusChanged);

        //        ThreadPool.QueueUserWorkItem(new WaitCallback(torrentDownloader.DownloadFile));
        //       // Thread oThread = new Thread(new ThreadStart(torrentDownloader.DownloadFile));
        //        //hashTags.Add("TorrentThread", oThread);
        //        lvi.Tag = hashTags;
        //        //oThread.IsBackground = true;
        //        //oThread.Start();
        //    }

        //}

        delegate void SetValueDelegate(Object obj, Object val, Object[] index);


        public void SetControlProperty(ListViewItem ctrl, String propName, Object val)
        {

            //Control cltr = (Control)glctrl;
            PropertyInfo propInfo = ctrl.GetType().GetProperty(propName);
            Delegate dgtSetValue = new SetValueDelegate(propInfo.SetValue);

            listEntries.Invoke(dgtSetValue, new Object[3] { ctrl, val, /*index*/null });
        }
        public void SetSubControlProperty(ListViewItem.ListViewSubItem ctrl, String propName, Object val)
        {

            //Control cltr = (Control)glctrl;
            PropertyInfo propInfo = ctrl.GetType().GetProperty(propName);
            Delegate dgtSetValue = new SetValueDelegate(propInfo.SetValue);

            listEntries.Invoke(dgtSetValue, new Object[3] { ctrl, val, /*index*/null });
        }

        private delegate ListViewItem AddListViewItem(ListViewItem lvi);
        private delegate ListViewItem GetListViewItem(int intIndex);

        public bool AddFile(DownloadItem item)
        {
            bool NewDownload = true;
            //if (!cancelled)
            //{
                // first loop through the list of downloads
                
                for (int q = 0; q < listEntries.Items.Count; q++)
                {
                    ListViewItem lviExisting = listEntries.Items[q];
                    Hashtable hashExisting = (Hashtable)lviExisting.Tag;
                    DownloadItem downloadItemExisting = (DownloadItem)hashExisting["DownloadItem"];
                    if (downloadItemExisting.Url == item.Url)
                    {
                        NewDownload = false;
                        break;
                    }
                }
                if (NewDownload)
                {

                    SetInformationLabel(Doppler.languages.FormStrings.DoubleClickAnEntryToCancelOrSkipTheDownload, true);
                    //ThreadPool.SetMaxThreads(Settings.Default.MaxThreads, Settings.Default.MaxThreads);
                    ListViewItem lvi = new ListViewItem(item.Url.Substring(item.Url.LastIndexOf("/") + 1));
                    //lvi.Group = listEntries.Groups["File downloads"];
                    lvi.SubItems.Add(Doppler.languages.FormStrings.Scheduled);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(item.FeedTitle);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");

                    //lvi.SubItems[0].Text = item.Url.Substring(item.Url.LastIndexOf("/")+1);
                    hashTags = new Hashtable();
                    hashTags.Add("DownloadItem", item);

                    lvi.Tag = hashTags;


                    FileDownloader fileDownloader = new FileDownloader(lvi, item);
                    fileDownloader.DownloadProgress += new DownloadProgressHandler(fileDownloader_DownloadProgress);
                    fileDownloader.DownloadComplete += new DownloadCompleteHandler(fileDownloader_DownloadComplete);
                    fileDownloader.DownloadError += new DownloadErrorHandler(fileDownloader_DownloadError);
                    fileDownloader.DownloadAborted += new DownloadAbortedHandler(fileDownloader_DownloadAborted);

                    hashTags.Add("Thread", fileDownloader);
                    lvi.Tag = hashTags;
                    listEntries.Invoke(new AddListViewItem(listEntries.Items.Add), new object[] { lvi });

                    //ThreadPool.QueueUserWorkItem(new WaitCallback(fileDownloader.DownloadFile));
                    _retrieverPool.QueueUserWorkItem(new WaitCallback(fileDownloader.DownloadFile), null);
                }
                
            //}
            return NewDownload;
        }

        public void RewriteTags(DownloadItem item)
        {
            FileInfo fileInfo = new FileInfo(item.Filename);

			if (fileInfo.Extension.ToLower() == ".mp3")
				Utils.RewriteMP3Tags(item);
        }

        private void ApplySpaceSavers(DownloadItem item)
        {
            // spacesavers?
            try
            {
                if (item.spacesaver_maxMb > 0)
                {
                    #region spacesaver_maxMb code
                    // apply the max Mb spacesaver
                    // check the size of the folder
                    FileInfo fileDownloaded = new FileInfo(item.Filename);
                    DirectoryInfo dirInfo = fileDownloaded.Directory;
                    FileInfo[] fileInfo = dirInfo.GetFiles();
                    long longTotalSize = 0;
                    foreach (FileInfo fileInfoItem in fileInfo)
                    {
						if (fileInfoItem.Extension.ToLower() != ".incomplete")
						{
							longTotalSize += fileInfoItem.Length;
						}
                    }

                    while ((longTotalSize / 1024 / 1024) > Convert.ToInt64(item.spacesaver_maxMb))
                    {
                        // folder grew to big
                        FileInfo oldestFile = null;
                        foreach (System.IO.FileInfo fileInfoItem in fileInfo)
                        {
							if (fileInfoItem.Extension.ToLower() != ".incomplete")
							{
								if (oldestFile == null)
								{
									oldestFile = fileInfoItem;
								}
								else
								{
									if (oldestFile.CreationTime > fileInfoItem.CreationTime)
									{
										oldestFile = fileInfoItem;
									}
								}
							}
                        }
                        if (oldestFile != null && oldestFile.Extension.ToLower() != ".incomplete")
                        {
                            // remove the oldest file
                            if (Settings.Default.LogLevel > 1) log.Info("SpaceSaver MaxMb - Deleting " + oldestFile.Name);
                            //RemoveFromPlaylist(strPlaylistName, oldestFile.FullName);
                            System.IO.File.Delete(oldestFile.FullName);
                        }
						else // Unable to find any files to delete so exit loop
						{
							break;
						}
                        fileInfo = dirInfo.GetFiles();
                        longTotalSize = 0;
                        foreach (System.IO.FileInfo fileInfoItem in fileInfo)
                        {
							if (fileInfoItem.Extension.ToLower() != ".incomplete")
							{
								longTotalSize += fileInfoItem.Length;
							}
                        }
                    }
                    #endregion
                }
                if (item.spacesaver_maxFiles > 0)
                {
                    #region spacesaver_maxFiles code
                    FileInfo fileDownloaded = new System.IO.FileInfo(item.Filename);
                    DirectoryInfo dirInfo = fileDownloaded.Directory;
                    FileInfo[] fileInfo = dirInfo.GetFiles();

                    while (fileInfo.Length > item.spacesaver_maxFiles)
                    {
                        // folder grew to big
                        System.IO.FileInfo oldestFile = null;
                        foreach (System.IO.FileInfo fileInfoItem in fileInfo)
                        {
                            if (oldestFile == null)
                            {
                                oldestFile = fileInfoItem;
                            }
                            else
                            {
                                if (oldestFile.CreationTime > fileInfoItem.CreationTime)
                                {
                                    oldestFile = fileInfoItem;
                                }
                            }
                        }
                        if (oldestFile != null && oldestFile.Extension.ToLower() != ".incomplete")
                        {
                            // remove the oldest file
                            if (Settings.Default.LogLevel > 1) log.Info("SpaceSaver MaxFiles, Deleting " + oldestFile.Name);
                            System.IO.File.Delete(oldestFile.FullName);
                        }
                        fileInfo = dirInfo.GetFiles();
                    }
                    #endregion
                }
                if (item.spacesaver_ageDays > 0)
                {
                    #region spacesaver_ageDays code
                    System.DateTime dateNow = DateTime.Now;
                    DateTime dateAgo = dateNow.AddDays(-Convert.ToInt16(item.spacesaver_ageDays));
                    //log.logMsg("Starting ageDays > " + dateAgo.ToString(),false,"SpaceSaver");

                    System.IO.FileInfo fileDownloaded = new System.IO.FileInfo(item.Filename);
                    System.IO.DirectoryInfo dirInfo = fileDownloaded.Directory;

                    System.IO.FileInfo[] fileInfo = dirInfo.GetFiles();
                    foreach (System.IO.FileInfo fileInfoItem in fileInfo)
                    {
                        DateTime dateFile = fileInfoItem.LastWriteTime;
                        if (dateFile <= dateAgo && fileInfoItem.Extension.ToLower() != ".incomplete")
                        {
                            if (Settings.Default.LogLevel > 1) log.Info("SpaceSaver AgeDays, Deleting " + fileInfoItem.Name + " - " + dateFile.ToString() + " <= " + dateAgo.ToString());
                            //RemoveFromPlaylist(strPlaylistName, fileInfoItem.FullName);
                            System.IO.File.Delete(fileInfoItem.FullName);
                        }
                    }
                    //log.logMsg("Ending ageDays - " + dateNow.ToString(),false,"SpaceSaver");

                    #endregion
                }

            }
            catch (Exception e)
            {
                if (Settings.Default.LogLevel > 0) log.Error("SpaceSavers", e);
            }
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.listIcons = new System.Windows.Forms.ImageList(this.components);
            this.listEntries = new Doppler.classes.ListViewNF();
            this.columnFile = new System.Windows.Forms.ColumnHeader();
            this.columnProgress = new System.Windows.Forms.ColumnHeader();
            this.columnETA = new System.Windows.Forms.ColumnHeader();
            this.columnFeed = new System.Windows.Forms.ColumnHeader();
            this.contextMenuDownloader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.canceldownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDownloader.SuspendLayout();
            this.SuspendLayout();
            // 
            // listIcons
            // 
            this.listIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listIcons.ImageStream")));
            this.listIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.listIcons.Images.SetKeyName(0, "");
            this.listIcons.Images.SetKeyName(1, "");
            this.listIcons.Images.SetKeyName(2, "");
            this.listIcons.Images.SetKeyName(3, "");
            this.listIcons.Images.SetKeyName(4, "");
            this.listIcons.Images.SetKeyName(5, "");
            this.listIcons.Images.SetKeyName(6, "");
            this.listIcons.Images.SetKeyName(7, "");
            this.listIcons.Images.SetKeyName(8, "");
            this.listIcons.Images.SetKeyName(9, "");
            this.listIcons.Images.SetKeyName(10, "");
            // 
            // listEntries
            // 
            this.listEntries.AccessibleDescription = null;
            this.listEntries.AccessibleName = null;
            resources.ApplyResources(this.listEntries, "listEntries");
            this.listEntries.BackgroundImage = null;
            this.listEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFile,
            this.columnProgress,
            this.columnETA,
            this.columnFeed});
            this.listEntries.ContextMenuStrip = this.contextMenuDownloader;
            this.listEntries.Font = null;
            this.listEntries.FullRowSelect = true;
            this.listEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEntries.Name = "listEntries";
            this.listEntries.OwnerDraw = true;
            this.listEntries.ShowGroups = false;
            this.listEntries.UseCompatibleStateImageBehavior = false;
            this.listEntries.View = System.Windows.Forms.View.Details;
            this.listEntries.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listEntries_DrawItem);
            this.listEntries.DoubleClick += new System.EventHandler(this.listEntries_DoubleClick);
            this.listEntries.SizeChanged += new System.EventHandler(this.listEntries_SizeChanged);
            this.listEntries.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listEntries_DrawSubItem);
            this.listEntries.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listEntries_DrawColumnHeader);
            // 
            // columnFile
            // 
            resources.ApplyResources(this.columnFile, "columnFile");
            // 
            // columnProgress
            // 
            resources.ApplyResources(this.columnProgress, "columnProgress");
            // 
            // columnETA
            // 
            resources.ApplyResources(this.columnETA, "columnETA");
            // 
            // columnFeed
            // 
            resources.ApplyResources(this.columnFeed, "columnFeed");
            // 
            // contextMenuDownloader
            // 
            this.contextMenuDownloader.AccessibleDescription = null;
            this.contextMenuDownloader.AccessibleName = null;
            resources.ApplyResources(this.contextMenuDownloader, "contextMenuDownloader");
            this.contextMenuDownloader.BackgroundImage = null;
            this.contextMenuDownloader.Font = null;
            this.contextMenuDownloader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canceldownloadToolStripMenuItem});
            this.contextMenuDownloader.Name = "contextMenuDownloader";
            this.contextMenuDownloader.ShowImageMargin = false;
            this.contextMenuDownloader.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuDownloader_Opening);
            // 
            // canceldownloadToolStripMenuItem
            // 
            this.canceldownloadToolStripMenuItem.AccessibleDescription = null;
            this.canceldownloadToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.canceldownloadToolStripMenuItem, "canceldownloadToolStripMenuItem");
            this.canceldownloadToolStripMenuItem.BackgroundImage = null;
            this.canceldownloadToolStripMenuItem.Name = "canceldownloadToolStripMenuItem";
            this.canceldownloadToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.canceldownloadToolStripMenuItem.Click += new System.EventHandler(this.canceldownloadToolStripMenuItem_Click);
            // 
            // Downloader
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.listEntries);
            this.Font = null;
            this.Name = "Downloader";
            this.contextMenuDownloader.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        #region Inner Classes : SysTrayNavigator, ProgressHandler, FileDownloader, Feeditem



        //private class ProgressHandler
        //{
        // //   private TorrentInfo torInfo;
        //    private DownloadItem item;
        //    private ListViewItem lvi;
        //    private ListView listEntries;
        //    //private int intImage;

        //    delegate void SetValueDelegate(Object obj, Object val, Object[] index);

        //    public void SetControlProperty(ListViewItem.ListViewSubItem ctrl, String propName, Object val)
        //    {
        //     //   PropertyInfo propInfo = ctrl.GetType().GetProperty(propName);
        //     //   Delegate dgtSetValue = new SetValueDelegate(propInfo.SetValue);
        //     //   ctrl.Parent.Invoke(dgtSetValue, new Object[3] { ctrl, val, /*index*/null });
        //    }


        //    public ProgressHandler(TorrentInfo torInfoIn, DownloadItem itemIn, ListView listEntriesIn, ListViewItem lviIn)
        //    {
        //        //intImage = 0;
        //        torInfo = torInfoIn;
        //        item = itemIn;
        //        listEntries = listEntriesIn;
        //        lvi = lviIn;
        //    }

        //    public void Error(object source, TorrentErrorEventArgs e)
        //    {
        //        ////Console.WriteLine(e.Exception.Message);
        //        //SetSubControlProperty(lvi.SubItems[2],"ForeColor",Color.Red);
        //        //SetSubControlProperty(lvi.SubItems[2],"Text",e.Exception.Message);
        //        ////lvi.SubItems[2].ForeColor = System.Drawing.Color.Red;
        //        ////lvi.SubItems[2].Text = e.Exception.Message;
        //    }

        //    public void StatusChanged(object source, TorrentStatusEventArgs e)
        //    {
        //        //SetControlProperty(lvi.SubItems[2],"ForeColor",Color.Black);
        //        //SetControlProperty(lvi.SubItems[2],"Text",e.Status.ToString());
        //        ////lvi.SubItems[2].ForeColor = System.Drawing.Color.Black;
        //        ////lvi.SubItems[2].Text = e.Status.ToString();

        //    }
        //    public void MessageAlert(object source, TorrentMessageEventArgs e)
        //    {
        //        //SetControlProperty(lvi.SubItems[2],"ForeColor",Color.Red);
        //        //SetControlProperty(lvi.SubItems[2],"Text",e.Message);
        //        ////lvi.SubItems[2].ForeColor = System.Drawing.Color.Red;
        //        ////lvi.SubItems[2].Text = e.Message;
        //    }

        //    public void PieceUpdated(object source, TorrentPieceEventArgs e)
        //    {
        //        //intImage++;
        //        //if(intImage == 11)
        //        //{
        //        //    intImage = 1;
        //        //}
        //        //lvi.ImageIndex = intImage;

        //        //if(e.IsComplete)
        //        //{
        //        //    DopplerProgress progress = (DopplerProgress)lvi.SubItems[1].Control;
        //        //    int intProgressValue = (int)lvi.SubItems[1].Tag;
        //        //    intProgressValue++;
        //        //    SetControlProperty(lvi.SubItems[2],"Tag",intProgressValue);

        //        //    //lvi.SubItems[2].Tag = intProgressValue;
        //        //    progress.Value = intProgressValue;
        //        //}
        //    }

        //    public void Complete(object source, EventArgs e)
        //    {
        //        //Hashtable hashTags;
        //        //for (int q = 0; q < listEntries.Items.Count; q++)
        //        //{
        //        //    hashTags = (Hashtable)listEntries.Items[q].Tag;
        //        //    string strGUID = (string)hashTags["GUID"];
        //        //    if (strGUID == item.GUID)
        //        //    {
        //        //        DopplerProgress progress = (DopplerProgress)listEntries.Items[q].SubItems[1].Control;
        //        //        int intProgressValue = (int)listEntries.Items[q].SubItems[1].Tag;
        //        //        intProgressValue++;
        //        //    }
        //        //}
        //    }
        //}


        //public class FeedItem
        //{
        //    public string GUID;

        //    //		[XmlAttribute]
        //    //		public int Index;
        //    /// <summary>
        //    /// The title of the item.
        //    /// </summary>
        //    public string Title;
        //    /// <summary>
        //    /// The item url
        //    /// </summary>
        //    public string Url;
        //    /// <summary>
        //    /// Add enclosures from this feed to iTunes?
        //    /// </summary>
        //    public bool addToiTunes;
        //    public string playlistname;
        //    public string username = "";
        //    public string password = "";
        //    /// <summary>
        //    /// Add enclosures from this feed to Windows Media Player?
        //    /// </summary>
        //    public bool addToWMP;
        //    /// <summary>
        //    /// is the feed checked for retrieval?
        //    /// </summary>
        //    public bool isChecked;
        //    /// <summary>
        //    /// How many Mb's to download? 
        //    /// </summary>
        //    public int maxMb;
        //    /// <summary>
        //    /// How many enclosures to download
        //    /// </summary>
        //    public int numFiles;
        //    /// <summary>
        //    /// Last publication date 
        //    /// </summary>
        //    public string Pubdate;
        //    public string LastModified;
        //    public string ETag;
        //    public bool UseExternal;
        //    public int Source;
        //    public bool RemoveFromPlaylist;
        //    public int Priority;
        //    public int CleanRating;
        //    /// <summary>
        //    /// Text filter
        //    /// </summary
        //    public string textFilter;

        //    /// <summary>
        //    /// Use Space Saving functions
        //    /// </summary>
        //    public bool useSpaceSavers;
        //    /// <summary>
        //    /// Space saver: restrict size of feed allocation on disk
        //    /// </summary>
        //    public int spacesaver_maxMb;
        //    /// <summary>
        //    /// Space saver: restrict maximum number of files in feed folder
        //    /// </summary>
        //    public int spacesaver_maxFiles;
        //    /// <summary>
        //    /// Space saver: restrict the number of files by age in days
        //    /// </summary>
        //    public int spacesaver_ageDays;
        //    /// <summary>
        //    /// Overrule ID3 tag : genre
        //    /// </summary>
        //    /// 

        //    public string tagTitle;


        //    public string tagGenre;


        //    public string tagArtist;


        //    public string tagAlbum;


        //    public int flags = 0;
        //    public bool useTrackCounter;
        //    public int trackCounter;
        //    public string Category;
        //}

        public struct TagItem
        {
            public string Title;
            public string Artist;
            public string Album;
            public string Genre;
            public int TrackCounter;
            public bool boolUseTrackCounter;
        }






        #endregion inner classes


        private void progress_PositionChangedCallBack(int intValue)
        {
            //
        }

        public void CancelAll()
        {
            // Abort the running ones
            _retrieverPool.AbortAll();

            // clear the ones which have been scheduled
            foreach (ListViewItem lvi in listEntries.Items)
            {
                if (lvi.SubItems[1].Text == Doppler.languages.FormStrings.Scheduled) lvi.Remove();
            }
            AllAborted();
            
        }

        private delegate void DeleteListViewItem(ListViewItem Nodes);

        private void menuCancelDownload_Click(object sender, System.EventArgs e)
        {
            ListViewItem lvi = listEntries.SelectedItems[0];
            hashTags = (Hashtable)lvi.Tag;
            DownloadItem item = (DownloadItem)hashTags["DownloadItem"];
            //if (item.IsTorrent)
            //{
            //    TorrentInfo torInfo = (TorrentInfo)lvi.SubItems[1].Tag;
            //    torInfo.Close();
            //}
            //else
            //{
            Thread thread = (Thread)lvi.SubItems[1].Tag;
            if (thread.IsAlive)
            {
                thread.Abort();
            }
            //}

            listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });
            //listEntries.Items.Remove(lvi);
        }

        private void menuStartDownload_Click(object sender, System.EventArgs e)
        {
            /*
			GLItem lvi = (GLItem) listEntriesOld.SelectedItems[0];
			DownloadItem item = (DownloadItem) lvi.SubItems[2].Tag;
			if(item.IsTorrent)
			{
				TorrentInfo torInfo = (TorrentInfo) lvi.Tag;
				torInfo.BeginTorrent();
			} 
			else 
			{
				Thread thread = (Thread) lvi.Tag;

				try 
				{

					thread.Resume();
				} 
				catch (Exception)
				{
					thread.Start();
				}
			}
             */
        }

        private void fileDownloader_DownloadProgress(DownloadItem item, int Min, int Max, int Value, string Status, string ETA, ListViewItem lvi)
        {
            //int intImageIndex = lvi.ImageIndex;
            //if (intImageIndex < 10)
            //{
            //   intImageIndex++;
            //}
            //else
            //{
            //    intImageIndex = 1;
            //}
            //SetControlProperty(lvi, "ImageIndex", intImageIndex);

            double dblPercentage = Convert.ToDouble(Value) / Convert.ToDouble(Max) * 100;
            //listEntries.Invoke(new MethodInvoker(listEntries.BeginUpdate));
            SetSubControlProperty(lvi.SubItems[1], "Tag", Convert.ToInt32(dblPercentage));
            SetSubControlProperty(lvi.SubItems[1], "Text", Status);
            SetSubControlProperty(lvi.SubItems[2], "Text", ETA);
            //SetSubControlProperty(lvi.SubItems[3], "Text", item.FeedTitle);
            //this.Invoke(new MethodInvoker(SetColumnWidths));
            //listEntries.Invoke(new MethodInvoker(listEntries.EndUpdate));
            //SetSubControlProperty(lvi.SubItems[2], "Text", Status);
        }

        private void fileDownloader_DownloadComplete(DownloadItem item, ListViewItem lvi)
        {

            try
            {
                // check if we need to convert

                FileInfo fileInfo = new FileInfo(item.Filename);
                string strExtension = fileInfo.Extension;

                if (item.UseSpaceSavers)
                {
                    ApplySpaceSavers(item);
                }


                RewriteTags(item);

                AddToPlaylist(Settings.Default.Feeds[item.FeedGUID], item, lvi);

                listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });

                FileDownloadComplete(item, lvi);
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Downloader:downloadcomplete", ex);
            }

        }

        private void AddToPlaylist(FeedItem feedItem, DownloadItem downloadItem, ListViewItem lvi)
        {
            //ProgramAction action = ProgramAction.Unknown;
            FileInfo fileInfo = new FileInfo(downloadItem.Filename);

            switch (Settings.Default.DefaultMediaAction)
            {
                case 0:

                    Utils.MediaAction action = Utils.GetMediaAction(fileInfo.Extension);

                    switch (action)
                    {
                        case Utils.MediaAction.iTunes:
                            if (Settings.Default.LogLevel > 1) log.Info("Adding " + downloadItem.Filename + " to iTunes");
                            AddToiTunes(downloadItem, feedItem, lvi);
                            break;
                        case Utils.MediaAction.WMP:
                            if (Settings.Default.LogLevel > 1) log.Info("Adding " + downloadItem.Filename + " to Windows Media Player");
                            AddToWMP(downloadItem, feedItem);
                            break;
                        case Utils.MediaAction.Zune:
                            if (Settings.Default.LogLevel > 1) log.Info("Adding " + downloadItem.Filename + " to Zune Player");
                            AddToWMP(downloadItem, feedItem);
                            break;
                        case Utils.MediaAction.Unknown:
                            break;
                    }
                    break;
                case 1:


                    foreach (string extension in Utils.AudioExtensions)
                    {
                        if (fileInfo.Extension.ToLower() == "." + extension)
                        {
                            switch (Settings.Default.AudioFile)
                            {
                                case 1: // Add to iTunes
                                    AddToiTunes(downloadItem, feedItem, lvi);
                                    break;
                                case 2: // Add to WMP

                                    AddToWMP(downloadItem, feedItem);
                                    break;
                                case 3:
                                    // Custom Launch
                                    string strWithoutExtension = downloadItem.Filename.Substring(0, downloadItem.Filename.Length - fileInfo.Extension.Length);
                                    string strCommand = Settings.Default.AudioCustomApp;
                                    strCommand = strCommand.Replace("{f}", downloadItem.Filename);
                                    strCommand = strCommand.Replace("{n}", downloadItem.Filename);
                                    strCommand = strCommand.Replace("{t}", System.IO.Path.GetTempFileName());
                                    System.Diagnostics.Process.Start(strCommand);
                                    break;
                                case 4: // Add to M3U
                                    AddToM3U(downloadItem, feedItem);
                                    break;
                            }
                            break;
                        }

                    }
                    foreach (string extension in Utils.VideoExtensions)
                    {
                        if (fileInfo.Extension.ToLower() == "." + extension)
                        {
                            switch (Settings.Default.VideoFile)
                            {
                                case 1:
                                    AddToiTunes(downloadItem, feedItem, lvi);
                                    break;
                                case 2:
                                    //AddToM3U(downloadItem, feedItem);
                                    AddToWMP(downloadItem, feedItem);
                                    break;
                                case 3:
                                    string strWithoutExtension = downloadItem.Filename.Substring(0, downloadItem.Filename.Length - fileInfo.Extension.Length);
                                    string strCommand = Settings.Default.AudioCustomApp;
                                    strCommand = strCommand.Replace("{f}", downloadItem.Filename);
                                    strCommand = strCommand.Replace("{n}", downloadItem.Filename);
                                    strCommand = strCommand.Replace("{t}", System.IO.Path.GetTempFileName());
                                    System.Diagnostics.Process.Start(strCommand);
                                    break;
                            }
                            break;
                        }


                    }
                    break;
            }
        }

        private void AddToM3U(DownloadItem downloadItem, FeedItem feedItem)
        {
            string strDir = Utils.GetValidFolderPath(feedItem.Title);
            string strLocation = Path.Combine(Settings.Default.DownloadLocation, strDir);
            string m3ufile = strLocation + "\\" + strDir + ".m3u";
            //string M3UFile = (new FileInfo(downloadItem.Filename)).DirectoryName + "\\" + Utils.GetValidFileName(feedItem.Title + ".m3u");

            bool written = false;
            WindowsMediaPlayer wmp = null;
            try
            {
                wmp = new WindowsMediaPlayer();
                StreamWriter streamWriter = new StreamWriter(m3ufile, false);
                streamWriter.WriteLine("#EXTM3U");

                DirectoryInfo dirInfo = new FileInfo(m3ufile).Directory;

                foreach (FileInfo fileInfo in dirInfo.GetFiles("*.*"))
                {
                    if (fileInfo.Extension == ".mp3" || fileInfo.Extension == ".wav" || fileInfo.Extension == ".wma" || fileInfo.Extension == ".avi")
                    {
                        written = true;
                        IWMPMedia media = wmp.newMedia(fileInfo.FullName);
                        WMPHelper.RewriteWMPTags(downloadItem, media);
                        streamWriter.WriteLine("#EXTINF:{0},{1}", Convert.ToInt32(media.duration), media.name);
                        streamWriter.WriteLine(fileInfo.FullName);
                    }
                }
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Downloader:WriteM3UPlaylist", ex);
            }
            finally
            {
                if (!written)
                {
                    try
                    {
                        File.Delete(m3ufile);
                    }
                    catch { };
                }
                int left = 0;
                do
                {
                    left = System.Runtime.InteropServices.Marshal.ReleaseComObject(wmp);
                } while (left > 0);

            }
        }

        /// <summary>
        /// Adds a file to a specific playlist as defined by the feeditem object
        /// </summary>
        /// <param name="fileName">The filename on the filesystem</param>
        /// <param name="feedItem">A feeditem object containing a playlistname</param>
        private void AddToWMP(DownloadItem downloadItem, FeedItem feedItem)
        {
            /*
             * <?wpl version="1.0"?>
<smil>
	<head>
		<meta name="Generator" content="Doppler 3.0"/>
		<title>Test playlist testing</title>
	</head>
	<body>
		<seq>
			<media src="c:\test.mp3"/>
		</seq>
	</body>
</smil
             */
            WindowsMediaPlayer player = null;
            try
            {
                player = new WindowsMediaPlayer();

                int tracksremoved = 0;
  
                // keep only unplayed?
                string playlistName = feedItem.PlaylistName;
                if (playlistName == null || playlistName == "")
                {
                    playlistName = feedItem.Title;
                }
                IWMPPlaylist pl = WMPHelper.GetWMPPlaylist(player, playlistName);

                tracksremoved = WMPHelper.CleanWMPPlaylistRating(downloadItem, pl, player);

                if (feedItem.RemovePlayed)
                {
                    tracksremoved += WMPHelper.CleanWMPPlaylistByPlayed(downloadItem, pl, player);
                }

                IWMPMedia track = player.newMedia(downloadItem.Filename);

                //WMPHelper.RewriteWMPTags(downloadItem, track);

                // add the track to the playlist

                pl.appendItem(track);              

                // string WPLFile = (new FileInfo(downloadItem.Filename)).DirectoryName + "\\" + feedItem.Title + ".wpl";
                //WriteWMPPlaylist(WPLFile, feedItem.Title, downloadItem);

                //WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();


                //IWMPPlaylistArray playlistArray = null;
                //if (wmplayer.playlistCollection != null)
                //{

                //   playlistArray = wmplayer.playlistCollection.getByName(strPlayList);
                //}
                //IWMPPlaylist playlist = null;
                //if (playlistArray != null && playlistArray.count > 0)
                //{
                //    // yes, it exists
                //    playlist = playlistArray.Item(0);
                //}
                //else
                //{
                //     //it's a new one

                //    playlist = wmplayer.playlistCollection.newPlaylist(strPlayList);
                //playlist = wmplayer.newPlaylist(strPlayList,"");
                //}
                // //create a new mediaitem
                //IWMPMedia wmpmedia = wmplayer.newMedia(downloadItem.Filename);
                //playlist.appendItem(wmpmedia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Doppler.languages.FormStrings.ErrorWhileAddingFileToPlaylistInWindowsMediaPlayer, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                int left = 0;
                do
                {
                    left = System.Runtime.InteropServices.Marshal.ReleaseComObject(player);
                } while (left > 0);

            }
        }

        private void AddToiTunes(DownloadItem downloadItem, FeedItem feedItem, ListViewItem lvi)
        {
            int tracksremoved = 0;
            string M4BName = null;

            iTunesLib.iTunesApp iitApp = new iTunesLib.iTunesAppClass();
            iitApp.OnCOMCallsDisabledEvent += new _IiTunesEvents_OnCOMCallsDisabledEventEventHandler(iitApp_OnCOMCallsDisabledEvent);
            iitApp.OnCOMCallsEnabledEvent += new _IiTunesEvents_OnCOMCallsEnabledEventEventHandler(iitApp_OnCOMCallsEnabledEvent);
            
            try
            {
                string strPlaylist = feedItem.PlaylistName;
                if (strPlaylist == null || strPlaylist == "")
                {
                    strPlaylist = feedItem.Title;
                }
                lock (iitApp)
                {
                    try
                    {
                        FileInfo fileOriginal = new FileInfo(downloadItem.Filename);
                        IITUserPlaylist pl = iTunesHelper.GetiTunesPlaylist(iitApp, strPlaylist);

                        IITConvertOperationStatus status = null;
                        IITOperationStatus opstatus = null;

                        while (iTunesBusy)
                        {
                            fileDownloader_DownloadProgress(downloadItem, 0, 0, 0, Doppler.languages.FormStrings.ITunesIsBusyPleaseCloseAllDialogboxesInITunes, "", lvi);
                        }
                        //  clean up by rating first

                        tracksremoved = iTunesHelper.CleaniTunesPlaylistByRating(downloadItem, pl, iitApp);

                        // keep only unplayed?
                        if (feedItem.RemovePlayed)
                        {
                            tracksremoved += iTunesHelper.CleaniTunesPlaylistByPlayed(downloadItem, pl, iitApp);
                        }

                        // check if the extension is not m4b or m4a because then we don't have to convert it
                        bool doConvert = true;
                        if (fileOriginal.Extension.ToLower() == ".m4b" || fileOriginal.Extension.ToLower() == ".m4a")
                        {
                            doConvert = false;
                        }
                        if ((Settings.Default.AudioConvertM4B && doConvert) || (feedItem.OverrideAACConversion && doConvert))
                        {
                            IITEncoder currentEncoder = iitApp.CurrentEncoder;

                            iitApp.CurrentEncoder = GetAACEncoder(iitApp);
                            fileDownloader_DownloadProgress(downloadItem, 0, 100, 100, "Queued for conversion", "", lvi);
                            Mutex mut = new Mutex(false, "iTunesConversion");
                            mut.WaitOne();

                            status = iitApp.ConvertFile2(downloadItem.Filename);
                            while (status.InProgress)
                            {
                                while (iTunesBusy)
                                {
                                    fileDownloader_DownloadProgress(downloadItem, 0, 0, 0, Doppler.languages.FormStrings.ITunesIsBusyPleaseCloseAllDialogboxesInITunes, "", lvi);
                                }
                                fileDownloader_DownloadProgress(downloadItem, 0, status.maxProgressValue, status.progressValue, "Converting to bookmarkable AAC", "", lvi);
                            }
                            iitApp.CurrentEncoder = currentEncoder;

                            // get a handle to the strack it converted
                            IITFileOrCDTrack convertedTrack = (IITFileOrCDTrack)status.Tracks[1];

                            // after conversion, move the file back to it's original location

                            FileInfo fileNew = new FileInfo(convertedTrack.Location);
                            File.Move(fileNew.FullName, fileOriginal.DirectoryName + "\\" + fileNew.Name);

                            // and rename it to M4B if needed
                            FileInfo fileM4A = new FileInfo(fileOriginal.DirectoryName + "\\" + fileNew.Name);

                            if (fileM4A.Extension.ToLower() == ".m4a")
                            {
                                int extensionPosition = fileM4A.FullName.ToLower().IndexOf(".m4a");
                                M4BName = fileM4A.FullName.Substring(0, extensionPosition) + ".m4b";
                                File.Move(fileM4A.FullName, M4BName);
                                opstatus = pl.AddFile(M4BName);
                            }
                            else
                            {
                                opstatus = pl.AddFile(fileM4A.FullName);
                                IITFileOrCDTrack track = (IITFileOrCDTrack)opstatus.Tracks[1];
                                track.RememberBookmark = true;
                                track.ExcludeFromShuffle = true;
                            }

                            // Remove the original filename
                            File.Delete(fileOriginal.FullName);
                            mut.ReleaseMutex();
                        }
                        else
                        {
                            opstatus = pl.AddFile(downloadItem.Filename);
                            IITFileOrCDTrack track = (IITFileOrCDTrack)opstatus.Tracks[1];
                            track.RememberBookmark = true;
                            track.ExcludeFromShuffle = true;
                        }



                        // we have a track now, rewrite the tags
                        //if (opstatus != null)
                        //{
                        //    iTunesHelper.RewriteiTunesTags(downloadItem, (IITFileOrCDTrack)opstatus.Tracks[1]);
                        //}
                        //else
                        //{
                        //    iTunesHelper.RewriteiTunesTags(downloadItem, (IITFileOrCDTrack)status.Tracks[1]);
                        //}
                    }
                    catch (Exception ex)
                    {
                        if (Settings.Default.LogLevel > 0) log.Error("Downloader:AddToiTunes", ex);
                        //MessageBox.Show(ex.Message);
                    }
                    //iitApp.CurrentEncoder = currentEncoder;
                }
            }
            catch (Exception e)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Downloader:AddToiTunes", e);
            }
            finally
            {
                int left = 0;
                do
                {
                    left = System.Runtime.InteropServices.Marshal.ReleaseComObject(iitApp);
                } while (left > 0);

            }

            //throw new Exception("The method or operation is not implemented.");
        }

        void iitApp_OnCOMCallsEnabledEvent()
        {
            iTunesBusy = false;
        }

        void iitApp_OnCOMCallsDisabledEvent(ITCOMDisabledReason reason)
        {
            iTunesBusy = true;
        }

        private IITEncoder GetAACEncoder(IiTunes iitApp)
        {
            IITEncoder returnEncoder = null;
            foreach (IITEncoder encoder in iitApp.Encoders)
            {
                if (encoder.Name == "AAC Encoder")
                {
                    returnEncoder = encoder;
                    break;
                }
            }
            return returnEncoder;
        }

        void converter_conversionFinished(ListViewItem lvi, string strStatus, DownloadItem item)
        {

            listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });

            // the file has been downloaded, now rename it and add the renamed item

            // now looping through the main library and trying to find the file
            FileInfo fileInfo = new FileInfo(item.Filename);


            if (fileInfo.Extension.ToLower() == ".m4a")
            {
                // yup, rename it
                fileInfo.MoveTo(item.Filename.Substring(0, item.Filename.Length - fileInfo.Extension.Length) + ".m4b");

                // modify the download item to reflect the new name
                item.Filename = item.Filename.Substring(0, item.Filename.Length - fileInfo.Extension.Length) + ".m4b";

            }

            //System.IO.FileInfo downloadFile = new System.IO.FileInfo(item.Filename);
            //if (downloadFile.Extension.ToLower() == ".torrent")
            //{
            //    item.Url = downloadFile.FullName;
            //    item.Path = downloadFile.DirectoryName;
            //    item.IsTorrent = true;
            //    AddTorrent(item);
            //}
            //Utils.ProcessDownload(Settings.Default.Feeds[item.FeedGUID], item.Filename);
            AddToPlaylist(Settings.Default.Feeds[item.FeedGUID], item, lvi);

            FileDownloadComplete(item, lvi);
        }

        void converter_conversionProgress(ListViewItem lvi, int Minimum, int Maximum, int Progress, string Status)
        {
            double dblPercentage = Convert.ToDouble(Progress) / Convert.ToDouble(Maximum) * 100;
            SetSubControlProperty(lvi.SubItems[1], "Tag", Convert.ToInt32(dblPercentage));
            SetSubControlProperty(lvi.SubItems[2], "Text", Status);
        }

        private void fileDownloader_DownloadAborted(DownloadItem item, ListViewItem lvi)
        {
            listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });
            //frmPopMessageXP.ShowMessage("Canceled", item.Url, "");
            FileDownloadAborted(item, lvi);
            //QueueItems();
        }

        private void fileDownloader_DownloadError(DownloadItem item, ListViewItem lvi, string Message, Exception ex)
        {
            listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });
            //frmPopMessageXP.ShowMessage("Error", Message, "");
            if (Settings.Default.LogLevel > 0) log.Error(Message,ex);

            FileDownloadError(item, Message,ex);
            //QueueItems();

        }





        //private void torrentDownloader_DownloadProgress(DownloadItem item, ListViewItem lvi, TorrentInfo torrentInfo, int intPieces)
        //{
        //    //DopplerProgress progress = (DopplerProgress)lvi.SubItems[1].Control;
        //    //progress.ProgressForeColor = System.Drawing.Color.FromArgb(251,151,31);
        //    //progress.Minimum = 0;
        //    //progress.Maximum = 100;
        //    SetSubControlProperty(lvi.SubItems[1], "Tag", Convert.ToInt32(torrentInfo.Progess * 100));
        //    //progress.Value = Convert.ToInt32(torrentInfo.Progess * 100);
        //    double rateKBS = torrentInfo.DownloadRate / 1024;
        //    string strKBS = String.Format("{0:F}", rateKBS);
        //    string strProgress = String.Format("{0:F1}", torrentInfo.Progess * 100);
        //    SetSubControlProperty(lvi.SubItems[2], "Text", strKBS + " KB/s - " + torrentInfo.Peers.Count.ToString() + " peers");
        //}

        //private void torrentDownloader_DownloadComplete(DownloadItem item, ListViewItem lvi, TorrentInfo torrentInfo)
        //{
        //    listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });
        //    ReWriteTags(item.Filename, item);

        //        if (item.UseSpaceSavers)
        //        {
        //            ApplySpaceSavers(item);
        //        }
        //    //frmPopMessageXP.ShowMessage("Download complete", torrentInfo.Name, "");
        //    FileDownloadComplete(item, lvi);
        //}

        //private void torrentDownloader_DownloadStatusChanged(DownloadItem item, ListViewItem lvi, TorrentInfo torrentInfo)
        //{
        //    SetControlProperty(lvi, "Text", torrentInfo.Name);
        //    SetSubControlProperty(lvi.SubItems[2], "Text", torrentInfo.Status.ToString());
        //    //lvi.SubItems[1].Text = torrentInfo.Status.ToString();
        //}

        private void listEntries_SizeChanged(object sender, System.EventArgs e)
        {

            SetColumnWidths();
        }

        private void SetColumnWidths()
        {
            listEntries.Columns[2].Width = -2;
            int intWidth = this.Width - listEntries.Columns[2].Width - 4;
            listEntries.Columns[0].Width = intWidth / 3;
            listEntries.Columns[1].Width = intWidth / 3;
            listEntries.Columns[3].Width = intWidth / 3;
        }

        private void listEntries_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Graphics g = e.Graphics;
           
            //Console.WriteLine(e.ColumnIndex.ToString());
            if (e.Header.DisplayIndex == 1 & e.SubItem.Tag != null)
            {
                int intPercentage = (int)e.SubItem.Tag;
                //Console.WriteLine(intPercentage.ToString());
                if (intPercentage > 0)
                {
                    int intWidth = e.Bounds.Width;
                    //Rectangle recFull = new Rectangle(e.Bounds.X,e.Bounds.Y,e.Bounds.Width,e.Bounds.Height);

                    double dblPercentageWidth = Convert.ToDouble(intWidth) / 100 * intPercentage;
                    //Rectangle recLeft = new Rectangle(e.Bounds.X, e.Bounds.Y, intPercentage, e.Bounds.Height);

                    Rectangle recProgressTop = new Rectangle(e.Bounds.X, e.Bounds.Y, Convert.ToInt32(dblPercentageWidth), e.Bounds.Height / 2);
                    LinearGradientBrush brushTop = new LinearGradientBrush(recProgressTop, Color.AntiqueWhite, Color.Orange, LinearGradientMode.Vertical);
                    Rectangle recProgressBottom = new Rectangle(e.Bounds.X, e.Bounds.Y + (e.Bounds.Height / 2), Convert.ToInt32(dblPercentageWidth), e.Bounds.Height / 2);
                    LinearGradientBrush brushBottom = new LinearGradientBrush(recProgressBottom, Color.DarkOrange, Color.Orange, LinearGradientMode.Vertical);

                    g.FillRectangle(brushTop, recProgressTop);
                    g.FillRectangle(brushBottom, recProgressBottom);
                    g.FillRectangle(Brushes.White, e.Bounds.X + Convert.ToInt32(dblPercentageWidth), e.Bounds.Y, e.Bounds.Width - Convert.ToInt32(dblPercentageWidth), e.Bounds.Height);
                   
                    string itemText = e.SubItem.Text;
                    SizeF sizeF = e.Graphics.MeasureString(itemText, e.SubItem.Font);
                    int leftPosition = (e.Bounds.Width - Convert.ToInt32(sizeF.Width)) / 2;
                    g.DrawString(itemText, e.SubItem.Font, Brushes.Black, e.Bounds.X + leftPosition, e.Bounds.Y);
      
                }
                else
                {
                    g.FillRectangle(Brushes.White, e.Bounds);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }


        private void listEntries_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                //    // Draw the background for an unselected item.
                e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);
            }
        }

        public FileInfo[] GetDownloadingFiles()
        {
            FileInfo[] returnValue = null;
            ArrayList arr = new ArrayList();
            foreach (ListViewItem lvi in listEntries.Items)
            {
                hashTags = (Hashtable)lvi.Tag;
                DownloadItem item = (DownloadItem)hashTags["DownloadItem"];

                FileInfo downloadingFile = new FileInfo(item.Filename);
                arr.Add(downloadingFile);
            }
            if (arr.Count > 0)
            {
                returnValue = new FileInfo[arr.Count];
                arr.CopyTo(returnValue);
            }
            return returnValue;
        }

        private void listEntries_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void canceldownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listEntries.SelectedItems)
            {
                CancelDownload(lvi);
            }
        }

        private void CancelDownload(ListViewItem lvi)
        {
            hashTags = (Hashtable)lvi.Tag;
            DownloadItem item = (DownloadItem)hashTags["DownloadItem"];
          
            FileDownloader fileDownloader = (FileDownloader)hashTags["Thread"];
            fileDownloader.boolAbort = true;
            if (Settings.Default.LogLevel > 1) log.Info("Download of " + item.FeedTitle + ": " + item.Filename + " cancelled");
        
            FileInfo downloadingFile = new FileInfo(item.Filename);
            string shortFileName = downloadingFile.Name;
            string Message = String.Format(Doppler.languages.FormStrings.DoYouWantToRetrieve0From1Later,shortFileName,Settings.Default.Feeds[item.FeedGUID].Title);
            if (SkipRetryMessageBox.Show("Skip?", Message, 1) == DialogResult.OK)
            {
                HistoryItem historyItem = new HistoryItem();
                historyItem.FeedGUID = item.FeedGUID;
                historyItem.FeedUrl = item.FeedUrl;
                historyItem.Hashcode = item.RssItemHashcode;
                historyItem.ItemDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                historyItem.Title = item.PostTitle;
                FileInfo fileInfo = new FileInfo(item.Filename);
                historyItem.FileName = fileInfo.Name;
                Settings.Default.History.Add(historyItem);
                try
                {
                    if (File.Exists(item.Filename + ".incomplete"))
                    {
                        File.Delete(item.Filename + ".incomplete");
                    }
                }
                catch (Exception ex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error("Cancel download", ex);
                }
            }
            listEntries.Invoke(new DeleteListViewItem(listEntries.Items.Remove), new object[] { lvi });
        }

        private void contextMenuDownloader_Opening(object sender, CancelEventArgs e)
        {
            if (listEntries.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void listEntries_DoubleClick(object sender, EventArgs e)
        {
            if (listEntries.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listEntries.SelectedItems)
                {
                    CancelDownload(lvi);
                }
            }

        }

        private void pauseDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listEntries.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listEntries.SelectedItems)
                {
                    PauseDownload(lvi);
                }
            }
        }

        private void PauseDownload(ListViewItem lvi)
        {
            hashTags = (Hashtable)lvi.Tag;
            DownloadItem item = (DownloadItem)hashTags["DownloadItem"];

            FileDownloader fileDownloader = (FileDownloader)hashTags["Thread"];
            fileDownloader.paused = !fileDownloader.paused;
        }

      

        private void cancelAllDownloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelAll();
        }

    }

    public struct DownloadItem
    {
        public string GUID;
        public string FeedGUID;
        public string FeedTitle;
        public string FeedPlaylist;
        public string FeedUrl;
        public string TagTitle;
        public string TagArtist;
        public string TagAlbum;
        public string TagGenre;
        /// <summary>
        /// Contains the Title of the post
        /// </summary>
        public string PostTitle;
        /// <summary>
        /// Contains the Hashcode return by the RssItem
        /// </summary>
        public int RssItemHashcode;
        public int TagTrackCounter;
        public bool TagUseTrackCounter;
        public bool IsTorrent;
        public string Url;
        public string Path;
        public bool UseProxy;
        public bool UseIEProxy;
        public string ProxyServer;
        public string ProxyPort;
        public bool ProxyAuthentication;
        public string ProxyUsername;
        public string ProxyPassword;
        public bool Authenticate;
        public string Username;
        public string Password;
        public long DownloadSize;
        //    public TorrentInfo TorrentInfo;
        public int TimeOut;
        public long MaxBytes;
        public int BufferSize;
        public string Filename;
        public bool IsStarted;
        public bool UseSpaceSavers;
        public int spacesaver_maxMb;
        public int spacesaver_maxFiles;
        public int spacesaver_ageDays;
        public bool ByteRanging;
    }

}