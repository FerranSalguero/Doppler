namespace Doppler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.FeedsListView = new global::Doppler.classes.ListViewNF();
			this.columnName = new System.Windows.Forms.ColumnHeader();
			this.columnLastUpdated = new System.Windows.Forms.ColumnHeader();
			this.columnStatus = new System.Windows.Forms.ColumnHeader();
			this.FeedsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.propertiesProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.retrievethisfeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.refreshFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDownloadfolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.opendownloadhistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.catchupfeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.deletethisfeedsubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelTopBar = new System.Windows.Forms.Panel();
			this.HeaderLabel = new System.Windows.Forms.Label();
			this.ExpandCollapseButton = new System.Windows.Forms.Button();
			this.downloader = new DopplerControls.Downloader();
			this.splitPostsFilesViewer = new System.Windows.Forms.SplitContainer();
			this.tabPostFiles = new System.Windows.Forms.TabControl();
			this.tabPosts = new System.Windows.Forms.TabPage();
			this.splitContainerPosts = new System.Windows.Forms.SplitContainer();
			this.PostsListView = new System.Windows.Forms.ListBox();
			this.PostsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.downloadThisPodcastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshPostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
			this.addToHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFromHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.postViewer1 = new DopplerControls.PostViewer();
			this.tabFiles = new System.Windows.Forms.TabPage();
			this.FilesListView = new global::Doppler.classes.ListViewNF();
			this.columnFilename = new System.Windows.Forms.ColumnHeader();
			this.columnSize = new System.Windows.Forms.ColumnHeader();
			this.columnDate = new System.Windows.Forms.ColumnHeader();
			this.FilesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.DeleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openLocalFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playSelectedFile = new System.Windows.Forms.ToolStripMenuItem();
			this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			this.panelMain = new System.Windows.Forms.Panel();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.FeedPictureBox = new System.Windows.Forms.PictureBox();
			this.InformationLabel = new System.Windows.Forms.Label();
			this.AddButton = new System.Windows.Forms.Button();
			this.RetrieveButton = new System.Windows.Forms.Button();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.importfrompodcastdirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.retrievefeedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.addFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.selectallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deselectallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSearchText = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripDropDownSearch = new System.Windows.Forms.ToolStripDropDownButton();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openDopplerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.retrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.addFeedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundRssRetriever = new System.ComponentModel.BackgroundWorker();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromPodcastDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.retrieveSelectedFeedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.importOPMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportOPMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addFeedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.editFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.markAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unmarkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.catchupAllFeedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.embeddedMediaPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.schedulingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.nederlandsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.svenskaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.francaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.slovenskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.FeedCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.backgroundCatchupper = new System.ComponentModel.BackgroundWorker();
			this.UpdateCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.FeedsContextMenu.SuspendLayout();
			this.panelTopBar.SuspendLayout();
			this.splitPostsFilesViewer.Panel1.SuspendLayout();
			this.splitPostsFilesViewer.Panel2.SuspendLayout();
			this.splitPostsFilesViewer.SuspendLayout();
			this.tabPostFiles.SuspendLayout();
			this.tabPosts.SuspendLayout();
			this.splitContainerPosts.Panel1.SuspendLayout();
			this.splitContainerPosts.Panel2.SuspendLayout();
			this.splitContainerPosts.SuspendLayout();
			this.PostsContextMenu.SuspendLayout();
			this.tabFiles.SuspendLayout();
			this.FilesContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
			this.panelMain.SuspendLayout();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FeedPictureBox)).BeginInit();
			this.NotifyIconContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(151)))), ((int)(((byte)(31)))));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.helpProvider1.SetShowHelp(this.splitContainer1.Panel1, ((bool)(resources.GetObject("splitContainer1.Panel1.ShowHelp"))));
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(146)))), ((int)(((byte)(203)))));
			this.splitContainer1.Panel2.Controls.Add(this.splitPostsFilesViewer);
			this.helpProvider1.SetShowHelp(this.splitContainer1.Panel2, ((bool)(resources.GetObject("splitContainer1.Panel2.ShowHelp"))));
			this.helpProvider1.SetShowHelp(this.splitContainer1, ((bool)(resources.GetObject("splitContainer1.ShowHelp"))));
			this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
			// 
			// splitContainer2
			// 
			this.splitContainer2.BackColor = System.Drawing.SystemColors.ControlDark;
			resources.ApplyResources(this.splitContainer2, "splitContainer2");
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.FeedsListView);
			this.splitContainer2.Panel1.Controls.Add(this.panelTopBar);
			this.helpProvider1.SetShowHelp(this.splitContainer2.Panel1, ((bool)(resources.GetObject("splitContainer2.Panel1.ShowHelp"))));
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.downloader);
			this.helpProvider1.SetShowHelp(this.splitContainer2.Panel2, ((bool)(resources.GetObject("splitContainer2.Panel2.ShowHelp"))));
			this.helpProvider1.SetShowHelp(this.splitContainer2, ((bool)(resources.GetObject("splitContainer2.ShowHelp"))));
			// 
			// FeedsListView
			// 
			this.FeedsListView.AllowDrop = true;
			this.FeedsListView.AutoArrange = false;
			this.FeedsListView.CheckBoxes = true;
			this.FeedsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLastUpdated,
            this.columnStatus});
			this.FeedsListView.ContextMenuStrip = this.FeedsContextMenu;
			resources.ApplyResources(this.FeedsListView, "FeedsListView");
			this.FeedsListView.FullRowSelect = true;
			this.FeedsListView.HideSelection = false;
			this.FeedsListView.MultiSelect = false;
			this.FeedsListView.Name = "FeedsListView";
			this.helpProvider1.SetShowHelp(this.FeedsListView, ((bool)(resources.GetObject("FeedsListView.ShowHelp"))));
			this.FeedsListView.ShowItemToolTips = true;
			this.FeedsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.FeedsListView.UseCompatibleStateImageBehavior = false;
			this.FeedsListView.View = System.Windows.Forms.View.Details;
			this.FeedsListView.SelectedIndexChanged += new System.EventHandler(this.FeedsListView_SelectedIndexChanged);
			this.FeedsListView.SizeChanged += new System.EventHandler(this.FeedsListView_SizeChanged);
			this.FeedsListView.DoubleClick += new System.EventHandler(this.FeedsListView_DoubleClick);
			this.FeedsListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FeedsListView_ItemCheck);
			this.FeedsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FeedsListView_DragDrop);
			this.FeedsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FeedsListView_ColumnClick);
			this.FeedsListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FeedsListView_DragEnter);
			// 
			// columnName
			// 
			resources.ApplyResources(this.columnName, "columnName");
			// 
			// columnLastUpdated
			// 
			resources.ApplyResources(this.columnLastUpdated, "columnLastUpdated");
			// 
			// columnStatus
			// 
			resources.ApplyResources(this.columnStatus, "columnStatus");
			// 
			// FeedsContextMenu
			// 
			this.FeedsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesProperties,
            this.retrievethisfeedToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshFeedToolStripMenuItem,
            this.openDownloadfolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.opendownloadhistoryToolStripMenuItem,
            this.catchupfeedToolStripMenuItem,
            this.toolStripSeparator3,
            this.deletethisfeedsubscriptionToolStripMenuItem});
			this.FeedsContextMenu.Name = "contextMenuStripListFeeds";
			this.helpProvider1.SetShowHelp(this.FeedsContextMenu, ((bool)(resources.GetObject("FeedsContextMenu.ShowHelp"))));
			this.FeedsContextMenu.ShowImageMargin = false;
			resources.ApplyResources(this.FeedsContextMenu, "FeedsContextMenu");
			this.FeedsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FeedsContextMenu_Opening);
			// 
			// propertiesProperties
			// 
			this.propertiesProperties.Name = "propertiesProperties";
			resources.ApplyResources(this.propertiesProperties, "propertiesProperties");
			this.propertiesProperties.Click += new System.EventHandler(this.propertiesProperties_Click);
			// 
			// retrievethisfeedToolStripMenuItem
			// 
			this.retrievethisfeedToolStripMenuItem.Image = global::Doppler.Properties.Resources.dopplerico_16;
			this.retrievethisfeedToolStripMenuItem.Name = "retrievethisfeedToolStripMenuItem";
			resources.ApplyResources(this.retrievethisfeedToolStripMenuItem, "retrievethisfeedToolStripMenuItem");
			this.retrievethisfeedToolStripMenuItem.Click += new System.EventHandler(this.retrievethisfeedToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// refreshFeedToolStripMenuItem
			// 
			this.refreshFeedToolStripMenuItem.Name = "refreshFeedToolStripMenuItem";
			resources.ApplyResources(this.refreshFeedToolStripMenuItem, "refreshFeedToolStripMenuItem");
			this.refreshFeedToolStripMenuItem.Click += new System.EventHandler(this.refreshFeedToolStripMenuItem_Click);
			// 
			// openDownloadfolderToolStripMenuItem
			// 
			this.openDownloadfolderToolStripMenuItem.Name = "openDownloadfolderToolStripMenuItem";
			resources.ApplyResources(this.openDownloadfolderToolStripMenuItem, "openDownloadfolderToolStripMenuItem");
			this.openDownloadfolderToolStripMenuItem.Click += new System.EventHandler(this.openDownloadfolderToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// opendownloadhistoryToolStripMenuItem
			// 
			this.opendownloadhistoryToolStripMenuItem.Name = "opendownloadhistoryToolStripMenuItem";
			resources.ApplyResources(this.opendownloadhistoryToolStripMenuItem, "opendownloadhistoryToolStripMenuItem");
			this.opendownloadhistoryToolStripMenuItem.Click += new System.EventHandler(this.opendownloadhistoryToolStripMenuItem_Click);
			// 
			// catchupfeedToolStripMenuItem
			// 
			this.catchupfeedToolStripMenuItem.Name = "catchupfeedToolStripMenuItem";
			resources.ApplyResources(this.catchupfeedToolStripMenuItem, "catchupfeedToolStripMenuItem");
			this.catchupfeedToolStripMenuItem.Click += new System.EventHandler(this.catchupfeedToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			// 
			// deletethisfeedsubscriptionToolStripMenuItem
			// 
			this.deletethisfeedsubscriptionToolStripMenuItem.Name = "deletethisfeedsubscriptionToolStripMenuItem";
			resources.ApplyResources(this.deletethisfeedsubscriptionToolStripMenuItem, "deletethisfeedsubscriptionToolStripMenuItem");
			this.deletethisfeedsubscriptionToolStripMenuItem.Click += new System.EventHandler(this.deletethisfeedsubscriptionToolStripMenuItem_Click);
			// 
			// panelTopBar
			// 
			this.panelTopBar.BackColor = System.Drawing.Color.Orange;
			this.panelTopBar.Controls.Add(this.HeaderLabel);
			this.panelTopBar.Controls.Add(this.ExpandCollapseButton);
			resources.ApplyResources(this.panelTopBar, "panelTopBar");
			this.panelTopBar.Name = "panelTopBar";
			this.helpProvider1.SetShowHelp(this.panelTopBar, ((bool)(resources.GetObject("panelTopBar.ShowHelp"))));
			this.panelTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopBar_Paint);
			// 
			// HeaderLabel
			// 
			resources.ApplyResources(this.HeaderLabel, "HeaderLabel");
			this.HeaderLabel.BackColor = System.Drawing.Color.Transparent;
			this.HeaderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HeaderLabel.Name = "HeaderLabel";
			this.helpProvider1.SetShowHelp(this.HeaderLabel, ((bool)(resources.GetObject("HeaderLabel.ShowHelp"))));
			// 
			// ExpandCollapseButton
			// 
			resources.ApplyResources(this.ExpandCollapseButton, "ExpandCollapseButton");
			this.ExpandCollapseButton.BackColor = System.Drawing.Color.Transparent;
			this.ExpandCollapseButton.FlatAppearance.BorderSize = 0;
			this.ExpandCollapseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
			this.ExpandCollapseButton.Name = "ExpandCollapseButton";
			this.helpProvider1.SetShowHelp(this.ExpandCollapseButton, ((bool)(resources.GetObject("ExpandCollapseButton.ShowHelp"))));
			this.ExpandCollapseButton.UseVisualStyleBackColor = false;
			this.ExpandCollapseButton.Click += new System.EventHandler(this.ExpandCollapseButton_Click);
			// 
			// downloader
			// 
			resources.ApplyResources(this.downloader, "downloader");
			this.downloader.Name = "downloader";
			this.helpProvider1.SetShowHelp(this.downloader, ((bool)(resources.GetObject("downloader.ShowHelp"))));
			// 
			// splitPostsFilesViewer
			// 
			resources.ApplyResources(this.splitPostsFilesViewer, "splitPostsFilesViewer");
			this.splitPostsFilesViewer.Name = "splitPostsFilesViewer";
			// 
			// splitPostsFilesViewer.Panel1
			// 
			this.splitPostsFilesViewer.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitPostsFilesViewer.Panel1.Controls.Add(this.tabPostFiles);
			this.helpProvider1.SetShowHelp(this.splitPostsFilesViewer.Panel1, ((bool)(resources.GetObject("splitPostsFilesViewer.Panel1.ShowHelp"))));
			this.splitPostsFilesViewer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitPostsFilesViewer_Panel1_Paint);
			// 
			// splitPostsFilesViewer.Panel2
			// 
			this.splitPostsFilesViewer.Panel2.Controls.Add(this.axWindowsMediaPlayer1);
			this.helpProvider1.SetShowHelp(this.splitPostsFilesViewer.Panel2, ((bool)(resources.GetObject("splitPostsFilesViewer.Panel2.ShowHelp"))));
			this.splitPostsFilesViewer.Panel2Collapsed = true;
			this.helpProvider1.SetShowHelp(this.splitPostsFilesViewer, ((bool)(resources.GetObject("splitPostsFilesViewer.ShowHelp"))));
			// 
			// tabPostFiles
			// 
			resources.ApplyResources(this.tabPostFiles, "tabPostFiles");
			this.tabPostFiles.Controls.Add(this.tabPosts);
			this.tabPostFiles.Controls.Add(this.tabFiles);
			this.tabPostFiles.Name = "tabPostFiles";
			this.tabPostFiles.SelectedIndex = 0;
			this.helpProvider1.SetShowHelp(this.tabPostFiles, ((bool)(resources.GetObject("tabPostFiles.ShowHelp"))));
			this.tabPostFiles.SelectedIndexChanged += new System.EventHandler(this.tabPostFiles_SelectedIndexChanged);
			// 
			// tabPosts
			// 
			this.tabPosts.Controls.Add(this.splitContainerPosts);
			resources.ApplyResources(this.tabPosts, "tabPosts");
			this.tabPosts.Name = "tabPosts";
			this.helpProvider1.SetShowHelp(this.tabPosts, ((bool)(resources.GetObject("tabPosts.ShowHelp"))));
			this.tabPosts.UseVisualStyleBackColor = true;
			this.tabPosts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabPosts_MouseClick);
			// 
			// splitContainerPosts
			// 
			this.splitContainerPosts.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			resources.ApplyResources(this.splitContainerPosts, "splitContainerPosts");
			this.splitContainerPosts.Name = "splitContainerPosts";
			// 
			// splitContainerPosts.Panel1
			// 
			this.splitContainerPosts.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.splitContainerPosts.Panel1.Controls.Add(this.PostsListView);
			this.helpProvider1.SetShowHelp(this.splitContainerPosts.Panel1, ((bool)(resources.GetObject("splitContainerPosts.Panel1.ShowHelp"))));
			// 
			// splitContainerPosts.Panel2
			// 
			this.splitContainerPosts.Panel2.Controls.Add(this.postViewer1);
			this.helpProvider1.SetShowHelp(this.splitContainerPosts.Panel2, ((bool)(resources.GetObject("splitContainerPosts.Panel2.ShowHelp"))));
			this.helpProvider1.SetShowHelp(this.splitContainerPosts, ((bool)(resources.GetObject("splitContainerPosts.ShowHelp"))));
			// 
			// PostsListView
			// 
			this.PostsListView.ContextMenuStrip = this.PostsContextMenu;
			resources.ApplyResources(this.PostsListView, "PostsListView");
			this.PostsListView.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.PostsListView.FormattingEnabled = true;
			this.PostsListView.Name = "PostsListView";
			this.helpProvider1.SetShowHelp(this.PostsListView, ((bool)(resources.GetObject("PostsListView.ShowHelp"))));
			this.PostsListView.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PostsListView_DrawItem);
			this.PostsListView.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.PostsListView_MeasureItem);
			this.PostsListView.SelectedIndexChanged += new System.EventHandler(this.PostsListView_SelectedIndexChanged);
			this.PostsListView.DoubleClick += new System.EventHandler(this.PostsListView_DoubleClick);
			// 
			// PostsContextMenu
			// 
			this.PostsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadThisPodcastToolStripMenuItem,
            this.refreshPostsToolStripMenuItem,
            this.toolStripMenuItem10,
            this.addToHistoryToolStripMenuItem,
            this.removeFromHistoryToolStripMenuItem});
			this.PostsContextMenu.Name = "contextMenuPosts";
			this.helpProvider1.SetShowHelp(this.PostsContextMenu, ((bool)(resources.GetObject("PostsContextMenu.ShowHelp"))));
			resources.ApplyResources(this.PostsContextMenu, "PostsContextMenu");
			this.PostsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PostsContextMenu_Opening);
			// 
			// downloadThisPodcastToolStripMenuItem
			// 
			this.downloadThisPodcastToolStripMenuItem.Name = "downloadThisPodcastToolStripMenuItem";
			resources.ApplyResources(this.downloadThisPodcastToolStripMenuItem, "downloadThisPodcastToolStripMenuItem");
			this.downloadThisPodcastToolStripMenuItem.Click += new System.EventHandler(this.downloadThisPodcastToolStripMenuItem_Click);
			// 
			// refreshPostsToolStripMenuItem
			// 
			this.refreshPostsToolStripMenuItem.Name = "refreshPostsToolStripMenuItem";
			resources.ApplyResources(this.refreshPostsToolStripMenuItem, "refreshPostsToolStripMenuItem");
			this.refreshPostsToolStripMenuItem.Click += new System.EventHandler(this.refreshPostsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
			// 
			// addToHistoryToolStripMenuItem
			// 
			this.addToHistoryToolStripMenuItem.Name = "addToHistoryToolStripMenuItem";
			resources.ApplyResources(this.addToHistoryToolStripMenuItem, "addToHistoryToolStripMenuItem");
			this.addToHistoryToolStripMenuItem.Click += new System.EventHandler(this.addToHistoryToolStripMenuItem_Click);
			// 
			// removeFromHistoryToolStripMenuItem
			// 
			this.removeFromHistoryToolStripMenuItem.Name = "removeFromHistoryToolStripMenuItem";
			resources.ApplyResources(this.removeFromHistoryToolStripMenuItem, "removeFromHistoryToolStripMenuItem");
			this.removeFromHistoryToolStripMenuItem.Click += new System.EventHandler(this.removeFromHistoryToolStripMenuItem_Click);
			// 
			// postViewer1
			// 
			this.postViewer1.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.postViewer1, "postViewer1");
			this.postViewer1.Name = "postViewer1";
			this.helpProvider1.SetShowHelp(this.postViewer1, ((bool)(resources.GetObject("postViewer1.ShowHelp"))));
			// 
			// tabFiles
			// 
			this.tabFiles.BackColor = System.Drawing.Color.Transparent;
			this.tabFiles.Controls.Add(this.FilesListView);
			resources.ApplyResources(this.tabFiles, "tabFiles");
			this.tabFiles.Name = "tabFiles";
			this.helpProvider1.SetShowHelp(this.tabFiles, ((bool)(resources.GetObject("tabFiles.ShowHelp"))));
			this.tabFiles.UseVisualStyleBackColor = true;
			// 
			// FilesListView
			// 
			this.FilesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.FilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnSize,
            this.columnDate});
			this.FilesListView.ContextMenuStrip = this.FilesContextMenu;
			resources.ApplyResources(this.FilesListView, "FilesListView");
			this.FilesListView.FullRowSelect = true;
			this.FilesListView.Name = "FilesListView";
			this.helpProvider1.SetShowHelp(this.FilesListView, ((bool)(resources.GetObject("FilesListView.ShowHelp"))));
			this.FilesListView.UseCompatibleStateImageBehavior = false;
			this.FilesListView.View = System.Windows.Forms.View.Details;
			this.FilesListView.SelectedIndexChanged += new System.EventHandler(this.FilesListView_SelectedIndexChanged);
			this.FilesListView.DoubleClick += new System.EventHandler(this.FilesListView_DoubleClick);
			this.FilesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FilesListView_ColumnClick);
			// 
			// columnFilename
			// 
			resources.ApplyResources(this.columnFilename, "columnFilename");
			// 
			// columnSize
			// 
			resources.ApplyResources(this.columnSize, "columnSize");
			// 
			// columnDate
			// 
			resources.ApplyResources(this.columnDate, "columnDate");
			// 
			// FilesContextMenu
			// 
			this.FilesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteFileToolStripMenuItem,
            this.OpenFileToolStripMenuItem,
            this.openLocalFolderToolStripMenuItem,
            this.playSelectedFile});
			this.FilesContextMenu.Name = "contextMenuFiles";
			this.helpProvider1.SetShowHelp(this.FilesContextMenu, ((bool)(resources.GetObject("FilesContextMenu.ShowHelp"))));
			this.FilesContextMenu.ShowImageMargin = false;
			resources.ApplyResources(this.FilesContextMenu, "FilesContextMenu");
			this.FilesContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FilesContextMenu_Opening);
			// 
			// DeleteFileToolStripMenuItem
			// 
			this.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem";
			resources.ApplyResources(this.DeleteFileToolStripMenuItem, "DeleteFileToolStripMenuItem");
			this.DeleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
			// 
			// OpenFileToolStripMenuItem
			// 
			this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
			resources.ApplyResources(this.OpenFileToolStripMenuItem, "OpenFileToolStripMenuItem");
			this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// openLocalFolderToolStripMenuItem
			// 
			this.openLocalFolderToolStripMenuItem.Name = "openLocalFolderToolStripMenuItem";
			resources.ApplyResources(this.openLocalFolderToolStripMenuItem, "openLocalFolderToolStripMenuItem");
			this.openLocalFolderToolStripMenuItem.Click += new System.EventHandler(this.openLocalFolderToolStripMenuItem_Click);
			// 
			// playSelectedFile
			// 
			this.playSelectedFile.Name = "playSelectedFile";
			resources.ApplyResources(this.playSelectedFile, "playSelectedFile");
			this.playSelectedFile.Click += new System.EventHandler(this.playSelectedFile_Click);
			// 
			// axWindowsMediaPlayer1
			// 
			resources.ApplyResources(this.axWindowsMediaPlayer1, "axWindowsMediaPlayer1");
			this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
			this.helpProvider1.SetShowHelp(this.axWindowsMediaPlayer1, ((bool)(resources.GetObject("axWindowsMediaPlayer1.ShowHelp"))));
			this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
			// 
			// panelMain
			// 
			resources.ApplyResources(this.panelMain, "panelMain");
			this.panelMain.Controls.Add(this.splitContainer1);
			this.panelMain.Name = "panelMain";
			this.helpProvider1.SetShowHelp(this.panelMain, ((bool)(resources.GetObject("panelMain.ShowHelp"))));
			// 
			// panelBottom
			// 
			this.panelBottom.BackColor = System.Drawing.Color.Gainsboro;
			this.panelBottom.Controls.Add(this.FeedPictureBox);
			this.panelBottom.Controls.Add(this.InformationLabel);
			this.panelBottom.Controls.Add(this.AddButton);
			this.panelBottom.Controls.Add(this.RetrieveButton);
			resources.ApplyResources(this.panelBottom, "panelBottom");
			this.panelBottom.Name = "panelBottom";
			this.helpProvider1.SetShowHelp(this.panelBottom, ((bool)(resources.GetObject("panelBottom.ShowHelp"))));
			this.panelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottom_Paint);
			// 
			// FeedPictureBox
			// 
			resources.ApplyResources(this.FeedPictureBox, "FeedPictureBox");
			this.FeedPictureBox.Name = "FeedPictureBox";
			this.helpProvider1.SetShowHelp(this.FeedPictureBox, ((bool)(resources.GetObject("FeedPictureBox.ShowHelp"))));
			this.FeedPictureBox.TabStop = false;
			// 
			// InformationLabel
			// 
			this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.InformationLabel, "InformationLabel");
			this.InformationLabel.Name = "InformationLabel";
			this.helpProvider1.SetShowHelp(this.InformationLabel, ((bool)(resources.GetObject("InformationLabel.ShowHelp"))));
			// 
			// AddButton
			// 
			resources.ApplyResources(this.AddButton, "AddButton");
			this.AddButton.BackColor = System.Drawing.Color.Transparent;
			this.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.AddButton.Image = global::Doppler.Properties.Resources.add;
			this.AddButton.Name = "AddButton";
			this.helpProvider1.SetShowHelp(this.AddButton, ((bool)(resources.GetObject("AddButton.ShowHelp"))));
			this.AddButton.UseVisualStyleBackColor = false;
			this.AddButton.MouseLeave += new System.EventHandler(this.buttonAdd_MouseLeave);
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			this.AddButton.MouseHover += new System.EventHandler(this.buttonAdd_MouseHover);
			// 
			// RetrieveButton
			// 
			resources.ApplyResources(this.RetrieveButton, "RetrieveButton");
			this.RetrieveButton.BackColor = System.Drawing.Color.Transparent;
			this.RetrieveButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.RetrieveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.RetrieveButton.Image = global::Doppler.Properties.Resources.dopplerico_32;
			this.RetrieveButton.Name = "RetrieveButton";
			this.helpProvider1.SetShowHelp(this.RetrieveButton, ((bool)(resources.GetObject("RetrieveButton.ShowHelp"))));
			this.RetrieveButton.UseVisualStyleBackColor = false;
			this.RetrieveButton.MouseLeave += new System.EventHandler(this.buttonRetrieve_MouseLeave);
			this.RetrieveButton.Click += new System.EventHandler(this.RetrieveButton_Click);
			this.RetrieveButton.MouseHover += new System.EventHandler(this.buttonRetrieve_MouseHover);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importfrompodcastdirectoryToolStripMenuItem,
            this.retrievefeedsToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
			resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.ShowDropDownArrow = false;
			// 
			// importfrompodcastdirectoryToolStripMenuItem
			// 
			this.importfrompodcastdirectoryToolStripMenuItem.Name = "importfrompodcastdirectoryToolStripMenuItem";
			resources.ApplyResources(this.importfrompodcastdirectoryToolStripMenuItem, "importfrompodcastdirectoryToolStripMenuItem");
			this.importfrompodcastdirectoryToolStripMenuItem.Click += new System.EventHandler(this.importfrompodcastdirectoryToolStripMenuItem_Click);
			// 
			// retrievefeedsToolStripMenuItem
			// 
			this.retrievefeedsToolStripMenuItem.Image = global::Doppler.Properties.Resources.dopplerico_16;
			this.retrievefeedsToolStripMenuItem.Name = "retrievefeedsToolStripMenuItem";
			resources.ApplyResources(this.retrievefeedsToolStripMenuItem, "retrievefeedsToolStripMenuItem");
			this.retrievefeedsToolStripMenuItem.Click += new System.EventHandler(this.retrievefeedsToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFeedToolStripMenuItem,
            this.toolStripSeparator6,
            this.selectallToolStripMenuItem,
            this.deselectallToolStripMenuItem});
			resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.ShowDropDownArrow = false;
			// 
			// addFeedToolStripMenuItem
			// 
			this.addFeedToolStripMenuItem.Image = global::Doppler.Properties.Resources.add_16;
			this.addFeedToolStripMenuItem.Name = "addFeedToolStripMenuItem";
			resources.ApplyResources(this.addFeedToolStripMenuItem, "addFeedToolStripMenuItem");
			this.addFeedToolStripMenuItem.Click += new System.EventHandler(this.addFeedToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
			// 
			// selectallToolStripMenuItem
			// 
			this.selectallToolStripMenuItem.Name = "selectallToolStripMenuItem";
			resources.ApplyResources(this.selectallToolStripMenuItem, "selectallToolStripMenuItem");
			this.selectallToolStripMenuItem.Click += new System.EventHandler(this.markallToolStripMenuItem_Click);
			// 
			// deselectallToolStripMenuItem
			// 
			this.deselectallToolStripMenuItem.Name = "deselectallToolStripMenuItem";
			resources.ApplyResources(this.deselectallToolStripMenuItem, "deselectallToolStripMenuItem");
			this.deselectallToolStripMenuItem.Click += new System.EventHandler(this.unmarkallToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(this.toolStripDropDownButton3, "toolStripDropDownButton3");
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.ShowDropDownArrow = false;
			// 
			// toolStripDropDownButton4
			// 
			this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
			resources.ApplyResources(this.toolStripDropDownButton4, "toolStripDropDownButton4");
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
			// 
			// toolStripDropDownButton5
			// 
			this.toolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.testToolStripMenuItem});
			resources.ApplyResources(this.toolStripDropDownButton5, "toolStripDropDownButton5");
			this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
			this.toolStripDropDownButton5.ShowDropDownArrow = false;
			this.toolStripDropDownButton5.Click += new System.EventHandler(this.toolStripDropDownButton5_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
			// 
			// toolStripSearchText
			// 
			this.toolStripSearchText.Name = "toolStripSearchText";
			resources.ApplyResources(this.toolStripSearchText, "toolStripSearchText");
			// 
			// toolStripDropDownSearch
			// 
			this.toolStripDropDownSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.toolStripDropDownSearch, "toolStripDropDownSearch");
			this.toolStripDropDownSearch.Name = "toolStripDropDownSearch";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.NotifyIconContextMenu;
			resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
			this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// NotifyIconContextMenu
			// 
			this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDopplerToolStripMenuItem,
            this.retrieveToolStripMenuItem,
            this.toolStripMenuItem5,
            this.addFeedToolStripMenuItem1,
            this.optionsToolStripMenuItem1,
            this.toolStripSeparator4,
            this.toolStripMenuItemExit});
			this.NotifyIconContextMenu.Name = "contextMenuStripNotifyIcon";
			this.helpProvider1.SetShowHelp(this.NotifyIconContextMenu, ((bool)(resources.GetObject("NotifyIconContextMenu.ShowHelp"))));
			resources.ApplyResources(this.NotifyIconContextMenu, "NotifyIconContextMenu");
			// 
			// openDopplerToolStripMenuItem
			// 
			resources.ApplyResources(this.openDopplerToolStripMenuItem, "openDopplerToolStripMenuItem");
			this.openDopplerToolStripMenuItem.Name = "openDopplerToolStripMenuItem";
			this.openDopplerToolStripMenuItem.Click += new System.EventHandler(this.openDopplerToolStripMenuItem_Click);
			// 
			// retrieveToolStripMenuItem
			// 
			this.retrieveToolStripMenuItem.Image = global::Doppler.Properties.Resources.dopplerico_16;
			this.retrieveToolStripMenuItem.Name = "retrieveToolStripMenuItem";
			resources.ApplyResources(this.retrieveToolStripMenuItem, "retrieveToolStripMenuItem");
			this.retrieveToolStripMenuItem.Click += new System.EventHandler(this.retrieveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
			// 
			// addFeedToolStripMenuItem1
			// 
			this.addFeedToolStripMenuItem1.Image = global::Doppler.Properties.Resources.add_16;
			this.addFeedToolStripMenuItem1.Name = "addFeedToolStripMenuItem1";
			resources.ApplyResources(this.addFeedToolStripMenuItem1, "addFeedToolStripMenuItem1");
			this.addFeedToolStripMenuItem1.Click += new System.EventHandler(this.addFeedToolStripMenuItem1_Click);
			// 
			// optionsToolStripMenuItem1
			// 
			this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
			resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
			this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			// 
			// toolStripMenuItemExit
			// 
			this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
			resources.ApplyResources(this.toolStripMenuItemExit, "toolStripMenuItemExit");
			this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
			// 
			// backgroundRssRetriever
			// 
			this.backgroundRssRetriever.WorkerSupportsCancellation = true;
			this.backgroundRssRetriever.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundRssRetriever_DoWork);
			this.backgroundRssRetriever.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundRssRetriever_RunWorkerCompleted);
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
			this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
			this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
			this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			resources.ApplyResources(this.MainMenu, "MainMenu");
			this.MainMenu.Name = "MainMenu";
			this.helpProvider1.SetShowHelp(this.MainMenu, ((bool)(resources.GetObject("MainMenu.ShowHelp"))));
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromPodcastDirectoryToolStripMenuItem1,
            this.retrieveSelectedFeedsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.importOPMLToolStripMenuItem,
            this.exportOPMLToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem2});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// importFromPodcastDirectoryToolStripMenuItem1
			// 
			this.importFromPodcastDirectoryToolStripMenuItem1.Name = "importFromPodcastDirectoryToolStripMenuItem1";
			resources.ApplyResources(this.importFromPodcastDirectoryToolStripMenuItem1, "importFromPodcastDirectoryToolStripMenuItem1");
			this.importFromPodcastDirectoryToolStripMenuItem1.Click += new System.EventHandler(this.importfrompodcastdirectoryToolStripMenuItem_Click);
			// 
			// retrieveSelectedFeedsToolStripMenuItem
			// 
			this.retrieveSelectedFeedsToolStripMenuItem.Image = global::Doppler.Properties.Resources.dopplerico_16;
			this.retrieveSelectedFeedsToolStripMenuItem.Name = "retrieveSelectedFeedsToolStripMenuItem";
			resources.ApplyResources(this.retrieveSelectedFeedsToolStripMenuItem, "retrieveSelectedFeedsToolStripMenuItem");
			this.retrieveSelectedFeedsToolStripMenuItem.Click += new System.EventHandler(this.retrievefeedsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
			// 
			// importOPMLToolStripMenuItem
			// 
			this.importOPMLToolStripMenuItem.Name = "importOPMLToolStripMenuItem";
			resources.ApplyResources(this.importOPMLToolStripMenuItem, "importOPMLToolStripMenuItem");
			this.importOPMLToolStripMenuItem.Click += new System.EventHandler(this.importOPMLFileToolStripMenuItem_Click);
			// 
			// exportOPMLToolStripMenuItem
			// 
			this.exportOPMLToolStripMenuItem.Name = "exportOPMLToolStripMenuItem";
			resources.ApplyResources(this.exportOPMLToolStripMenuItem, "exportOPMLToolStripMenuItem");
			this.exportOPMLToolStripMenuItem.Click += new System.EventHandler(this.exportOPMLFileToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			// 
			// exitToolStripMenuItem2
			// 
			this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
			resources.ApplyResources(this.exitToolStripMenuItem2, "exitToolStripMenuItem2");
			this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFeedToolStripMenuItem2,
            this.editFeedToolStripMenuItem,
            this.deleteFeedToolStripMenuItem,
            this.toolStripMenuItem7,
            this.markAllToolStripMenuItem,
            this.unmarkAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.catchupAllFeedsToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
			// 
			// addFeedToolStripMenuItem2
			// 
			this.addFeedToolStripMenuItem2.Image = global::Doppler.Properties.Resources.add_16;
			this.addFeedToolStripMenuItem2.Name = "addFeedToolStripMenuItem2";
			resources.ApplyResources(this.addFeedToolStripMenuItem2, "addFeedToolStripMenuItem2");
			this.addFeedToolStripMenuItem2.Click += new System.EventHandler(this.addFeedToolStripMenuItem_Click);
			// 
			// editFeedToolStripMenuItem
			// 
			this.editFeedToolStripMenuItem.Name = "editFeedToolStripMenuItem";
			resources.ApplyResources(this.editFeedToolStripMenuItem, "editFeedToolStripMenuItem");
			this.editFeedToolStripMenuItem.Click += new System.EventHandler(this.editFeedToolStripMenuItem_Click);
			// 
			// deleteFeedToolStripMenuItem
			// 
			this.deleteFeedToolStripMenuItem.Name = "deleteFeedToolStripMenuItem";
			resources.ApplyResources(this.deleteFeedToolStripMenuItem, "deleteFeedToolStripMenuItem");
			this.deleteFeedToolStripMenuItem.Click += new System.EventHandler(this.deleteFeedToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
			// 
			// markAllToolStripMenuItem
			// 
			this.markAllToolStripMenuItem.Name = "markAllToolStripMenuItem";
			resources.ApplyResources(this.markAllToolStripMenuItem, "markAllToolStripMenuItem");
			this.markAllToolStripMenuItem.Click += new System.EventHandler(this.markallToolStripMenuItem_Click);
			// 
			// unmarkAllToolStripMenuItem
			// 
			this.unmarkAllToolStripMenuItem.Name = "unmarkAllToolStripMenuItem";
			resources.ApplyResources(this.unmarkAllToolStripMenuItem, "unmarkAllToolStripMenuItem");
			this.unmarkAllToolStripMenuItem.Click += new System.EventHandler(this.unmarkallToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			// 
			// catchupAllFeedsToolStripMenuItem
			// 
			this.catchupAllFeedsToolStripMenuItem.Name = "catchupAllFeedsToolStripMenuItem";
			resources.ApplyResources(this.catchupAllFeedsToolStripMenuItem, "catchupAllFeedsToolStripMenuItem");
			this.catchupAllFeedsToolStripMenuItem.Click += new System.EventHandler(this.catchupAllFeedsToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.showSelectedToolStripMenuItem,
            this.embeddedMediaPlayerToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
			this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolStripView_DropDownOpening);
			// 
			// categoriesToolStripMenuItem
			// 
			this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
			resources.ApplyResources(this.categoriesToolStripMenuItem, "categoriesToolStripMenuItem");
			this.categoriesToolStripMenuItem.DropDownOpening += new System.EventHandler(this.categoriesToolStripMenuItem_DropDownOpening);
			this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.showFilteredSubscriptionsToolStripMenuItem_Click);
			// 
			// showSelectedToolStripMenuItem
			// 
			this.showSelectedToolStripMenuItem.CheckOnClick = true;
			this.showSelectedToolStripMenuItem.Name = "showSelectedToolStripMenuItem";
			resources.ApplyResources(this.showSelectedToolStripMenuItem, "showSelectedToolStripMenuItem");
			this.showSelectedToolStripMenuItem.Click += new System.EventHandler(this.showSelectedToolStripMenuItem_Click);
			// 
			// embeddedMediaPlayerToolStripMenuItem
			// 
			this.embeddedMediaPlayerToolStripMenuItem.Checked = true;
			this.embeddedMediaPlayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.embeddedMediaPlayerToolStripMenuItem.Name = "embeddedMediaPlayerToolStripMenuItem";
			resources.ApplyResources(this.embeddedMediaPlayerToolStripMenuItem, "embeddedMediaPlayerToolStripMenuItem");
			this.embeddedMediaPlayerToolStripMenuItem.Click += new System.EventHandler(this.embeddedMediaPlayerToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogToolStripMenuItem1,
            this.schedulingToolStripMenuItem,
            this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem,
            this.toolStripMenuItem8,
            this.languageToolStripMenuItem1,
            this.toolStripMenuItem9,
            this.optionsToolStripMenuItem2});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
			this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
			// 
			// viewLogToolStripMenuItem1
			// 
			this.viewLogToolStripMenuItem1.Name = "viewLogToolStripMenuItem1";
			resources.ApplyResources(this.viewLogToolStripMenuItem1, "viewLogToolStripMenuItem1");
			this.viewLogToolStripMenuItem1.Click += new System.EventHandler(this.viewlogToolStripMenuItem_Click);
			// 
			// schedulingToolStripMenuItem
			// 
			this.schedulingToolStripMenuItem.Name = "schedulingToolStripMenuItem";
			resources.ApplyResources(this.schedulingToolStripMenuItem, "schedulingToolStripMenuItem");
			this.schedulingToolStripMenuItem.Click += new System.EventHandler(this.schedToolStripMenuItem_Click);
			// 
			// applyDefaultFeedSettingsToAllFeedsToolStripMenuItem
			// 
			this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem.Name = "applyDefaultFeedSettingsToAllFeedsToolStripMenuItem";
			resources.ApplyResources(this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem, "applyDefaultFeedSettingsToAllFeedsToolStripMenuItem");
			this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem.Click += new System.EventHandler(this.applyDefaultFeedSettingsToAllFeedsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
			// 
			// languageToolStripMenuItem1
			// 
			this.languageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1,
            this.nederlandsToolStripMenuItem1,
            this.svenskaToolStripMenuItem,
            this.francaisToolStripMenuItem,
            this.slovenskyToolStripMenuItem,
            this.polskiToolStripMenuItem});
			this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
			resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
			// 
			// englishToolStripMenuItem1
			// 
			this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
			resources.ApplyResources(this.englishToolStripMenuItem1, "englishToolStripMenuItem1");
			this.englishToolStripMenuItem1.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
			// 
			// nederlandsToolStripMenuItem1
			// 
			this.nederlandsToolStripMenuItem1.Name = "nederlandsToolStripMenuItem1";
			resources.ApplyResources(this.nederlandsToolStripMenuItem1, "nederlandsToolStripMenuItem1");
			this.nederlandsToolStripMenuItem1.Click += new System.EventHandler(this.nederlandsToolStripMenuItem_Click);
			// 
			// svenskaToolStripMenuItem
			// 
			this.svenskaToolStripMenuItem.Name = "svenskaToolStripMenuItem";
			resources.ApplyResources(this.svenskaToolStripMenuItem, "svenskaToolStripMenuItem");
			this.svenskaToolStripMenuItem.Click += new System.EventHandler(this.svenskaToolStripMenuItem_Click);
			// 
			// francaisToolStripMenuItem
			// 
			this.francaisToolStripMenuItem.Name = "francaisToolStripMenuItem";
			resources.ApplyResources(this.francaisToolStripMenuItem, "francaisToolStripMenuItem");
			this.francaisToolStripMenuItem.Click += new System.EventHandler(this.francaisToolStripMenuItem_Click);
			// 
			// slovenskyToolStripMenuItem
			// 
			this.slovenskyToolStripMenuItem.Name = "slovenskyToolStripMenuItem";
			resources.ApplyResources(this.slovenskyToolStripMenuItem, "slovenskyToolStripMenuItem");
			this.slovenskyToolStripMenuItem.Click += new System.EventHandler(this.slovenskyToolStripMenuItem_Click);
			// 
			// polskiToolStripMenuItem
			// 
			this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
			resources.ApplyResources(this.polskiToolStripMenuItem, "polskiToolStripMenuItem");
			this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
			// 
			// optionsToolStripMenuItem2
			// 
			this.optionsToolStripMenuItem2.Name = "optionsToolStripMenuItem2";
			resources.ApplyResources(this.optionsToolStripMenuItem2, "optionsToolStripMenuItem2");
			this.optionsToolStripMenuItem2.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTipsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem1});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			// 
			// showTipsToolStripMenuItem
			// 
			this.showTipsToolStripMenuItem.Name = "showTipsToolStripMenuItem";
			resources.ApplyResources(this.showTipsToolStripMenuItem, "showTipsToolStripMenuItem");
			this.showTipsToolStripMenuItem.Click += new System.EventHandler(this.showTipsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// FeedCheckTimer
			// 
			this.FeedCheckTimer.Enabled = true;
			this.FeedCheckTimer.Interval = 60000;
			this.FeedCheckTimer.Tick += new System.EventHandler(this.FeedCheckTimer_Tick);
			// 
			// backgroundCatchupper
			// 
			this.backgroundCatchupper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundCatchupper_DoWork);
			// 
			// UpdateCheckTimer
			// 
			this.UpdateCheckTimer.Interval = 60000;
			this.UpdateCheckTimer.Tick += new System.EventHandler(this.UpdateCheckTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelMain);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.FeedsContextMenu.ResumeLayout(false);
			this.panelTopBar.ResumeLayout(false);
			this.splitPostsFilesViewer.Panel1.ResumeLayout(false);
			this.splitPostsFilesViewer.Panel2.ResumeLayout(false);
			this.splitPostsFilesViewer.ResumeLayout(false);
			this.tabPostFiles.ResumeLayout(false);
			this.tabPosts.ResumeLayout(false);
			this.splitContainerPosts.Panel1.ResumeLayout(false);
			this.splitContainerPosts.Panel2.ResumeLayout(false);
			this.splitContainerPosts.ResumeLayout(false);
			this.PostsContextMenu.ResumeLayout(false);
			this.tabFiles.ResumeLayout(false);
			this.FilesContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
			this.panelMain.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			this.panelBottom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FeedPictureBox)).EndInit();
			this.NotifyIconContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLastUpdated;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.Panel panelBottom;
       // private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripTextBox toolStripSearchText;
        private System.Windows.Forms.ContextMenuStrip FeedsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem propertiesProperties;
        private System.Windows.Forms.ToolStripMenuItem retrievethisfeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openDownloadfolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem opendownloadhistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catchupfeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deletethisfeedsubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RetrieveButton;
        private System.Windows.Forms.ToolStripMenuItem retrievefeedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem addFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem selectallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectallToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem importfrompodcastdirectoryToolStripMenuItem;
        private System.Windows.Forms.Button ExpandCollapseButton;
        private System.ComponentModel.BackgroundWorker backgroundRssRetriever;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownSearch;
        private System.Windows.Forms.ContextMenuStrip FilesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromPodcastDirectoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem retrieveSelectedFeedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem importOPMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOPMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFeedToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem markAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmarkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem schedulingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nederlandsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.SplitContainer splitPostsFilesViewer;
        private System.Windows.Forms.TabControl tabPostFiles;
        private System.Windows.Forms.TabPage tabPosts;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnDate;
        //private WMPLib.WindowsMediaPlayer axWindowsMediaPlayer1;
        //private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.SplitContainer splitContainerPosts;
        private System.Windows.Forms.ListBox PostsListView;
        private DopplerControls.PostViewer postViewer1;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer FeedCheckTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem catchupAllFeedsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundCatchupper;
        private System.Windows.Forms.Timer UpdateCheckTimer;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem svenskaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyDefaultFeedSettingsToAllFeedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem retrieveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PostsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshPostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem addToHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embeddedMediaPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocalFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDopplerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFeedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.Label InformationLabel;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem showTipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private DopplerControls.Downloader downloader;
        private System.Windows.Forms.PictureBox FeedPictureBox;
        private System.Windows.Forms.ToolStripMenuItem francaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slovenskyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
        private global::Doppler.classes.ListViewNF FeedsListView;
        private global::Doppler.classes.ListViewNF FilesListView;
        private System.Windows.Forms.ToolStripMenuItem downloadThisPodcastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshFeedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playSelectedFile;

    }
}