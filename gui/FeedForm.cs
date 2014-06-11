using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Doppler.Properties;
using Doppler.languages;


namespace Doppler
{
	/// <summary>
	/// Summary description for frmFeed.
	/// </summary>
	public class FeedForm : System.Windows.Forms.Form
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Windows.Forms.Button CancelFeedButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        private FeedItem feedItem;
        private System.Windows.Forms.Button AddFeedButton;
        private TabPage tabFilters;
        private Label label7;
        public TextBox TextFilterTextBox;
        private Label label6;
        private TabPage tabID3;
        private Label label19;
        private TextBox TagTitleTextBox;
        private Panel panel1;
        private Label label14;
        private Label label3;
        private NumericUpDown TrackCounterNumeric;
        private Label labelStartAt;
        private CheckBox TrackCounterCheckBox;
        private TextBox TagArtistTextBox;
        private Label labelArtist;
        private TextBox TagAlbumTextBox;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox TagGenreTextBox;
        private TabPage tabSpaceSavers;
        private Label label12;
        public NumericUpDown RetrieveMaximumMBNumeric;
        public CheckBox RetrieveMaximumMBCheckBox;
        private Label label4;
        public NumericUpDown RetrieveLastNumeric;
        public CheckBox RetrieveOnlyLastCheckBox;
        private GroupBox SpaceSaversGroup;
        private Label labelRestrictDaysDays;
        private Label labelRestrictDays;
        public NumericUpDown SpaceSaverRestrictByDaysNumeric;
        public NumericUpDown SpaceSaverRestrictByFilesNumeric;
        private Label labelMaximumFiles;
        private Label labelMB;
        public NumericUpDown SpaceSaverRestrictBySizeNumeric;
        private Label labelTotalSize;
        private RadioButton RestrictDaysRadioButton;
        private RadioButton RestrictFilesRadioButton;
        private RadioButton RestrictSizeRadioButton;
        private GroupBox DefaultSpaceSaversGroup;
        private ComboBox RatingComboBox;
        private CheckBox RemoveByRatingCheckBox;
        private CheckBox SpaceSaversCheckBox;
        private TabPage tabMain;
        private TextBox PasswordTextBox;
        private Label label5;
        private Label label11;
        private TextBox UsernameTextBox;
        private CheckBox LoginCheckBox;
        private ComboBox CategoryComboBox;
        private Label label15;
        private Label label13;
        private TextBox PlaylistTextBox;
        public TextBox UrlTextBox;
        private Label label1;
        public TextBox NameTextBox;
        private Label label2;
        private TabControl tabControl1;
        private CheckBox KeepUnplayedCheckBox;
        private CheckBox DownloadsFolderCheckBox;
        private Button DownloadsFolderButton;
        private TextBox DownloadsFolderTextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label16;
        private Label label17;
        private TabPage tabAdvanced;
        private CheckBox AlwaysConvertToM4BCheckBox;
        private GroupBox groupBox1;
        private Button ClearCacheButton;
        private Label label20;
        private Label label18;
        private Label label21;
        private TextBox CacheFileSizeTextBox;
        private TextBox CacheFileDateTextBox;
        private TextBox CacheFileLocationTextBox;
        private PictureBox FeedPictureBox;
        private CheckBox checkUseTitleForFile;

		private bool boolNew;
		public FeedForm()
		{
			InitializeComponent();
			feedItem = new FeedItem();
			boolNew = true;
		}

		public FeedForm(FeedItem Item, bool IsNew)
		{
			InitializeComponent();
			boolNew = IsNew;
			feedItem = Item;
            if (!IsNew) { this.Text = "Properties of " + Item.Title; }
		}


		public FeedForm(FeedItem Item)
		{

			InitializeComponent();
            this.Text = "Properties of " + Item.Title;
			feedItem = Item;
			boolNew = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedForm));
            this.AddFeedButton = new System.Windows.Forms.Button();
            this.CancelFeedButton = new System.Windows.Forms.Button();
            this.tabFilters = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.TextFilterTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabID3 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.TagTitleTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackCounterNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelStartAt = new System.Windows.Forms.Label();
            this.TrackCounterCheckBox = new System.Windows.Forms.CheckBox();
            this.TagArtistTextBox = new System.Windows.Forms.TextBox();
            this.labelArtist = new System.Windows.Forms.Label();
            this.TagAlbumTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TagGenreTextBox = new System.Windows.Forms.TextBox();
            this.tabSpaceSavers = new System.Windows.Forms.TabPage();
            this.SpaceSaversGroup = new System.Windows.Forms.GroupBox();
            this.labelRestrictDaysDays = new System.Windows.Forms.Label();
            this.labelRestrictDays = new System.Windows.Forms.Label();
            this.SpaceSaverRestrictByDaysNumeric = new System.Windows.Forms.NumericUpDown();
            this.SpaceSaverRestrictByFilesNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumFiles = new System.Windows.Forms.Label();
            this.labelMB = new System.Windows.Forms.Label();
            this.SpaceSaverRestrictBySizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelTotalSize = new System.Windows.Forms.Label();
            this.RestrictDaysRadioButton = new System.Windows.Forms.RadioButton();
            this.RestrictFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.RestrictSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.DefaultSpaceSaversGroup = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.KeepUnplayedCheckBox = new System.Windows.Forms.CheckBox();
            this.RetrieveMaximumMBNumeric = new System.Windows.Forms.NumericUpDown();
            this.RatingComboBox = new System.Windows.Forms.ComboBox();
            this.RetrieveMaximumMBCheckBox = new System.Windows.Forms.CheckBox();
            this.RetrieveLastNumeric = new System.Windows.Forms.NumericUpDown();
            this.RemoveByRatingCheckBox = new System.Windows.Forms.CheckBox();
            this.RetrieveOnlyLastCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SpaceSaversCheckBox = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.FeedPictureBox = new System.Windows.Forms.PictureBox();
            this.DownloadsFolderButton = new System.Windows.Forms.Button();
            this.DownloadsFolderTextBox = new System.Windows.Forms.TextBox();
            this.DownloadsFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.LoginCheckBox = new System.Windows.Forms.CheckBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PlaylistTextBox = new System.Windows.Forms.TextBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.checkUseTitleForFile = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CacheFileSizeTextBox = new System.Windows.Forms.TextBox();
            this.CacheFileDateTextBox = new System.Windows.Forms.TextBox();
            this.CacheFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ClearCacheButton = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.AlwaysConvertToM4BCheckBox = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabFilters.SuspendLayout();
            this.tabID3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackCounterNumeric)).BeginInit();
            this.tabSpaceSavers.SuspendLayout();
            this.SpaceSaversGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictByDaysNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictByFilesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictBySizeNumeric)).BeginInit();
            this.DefaultSpaceSaversGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrieveMaximumMBNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetrieveLastNumeric)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeedPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddFeedButton
            // 
            this.AddFeedButton.BackColor = System.Drawing.SystemColors.Control;
            this.AddFeedButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.AddFeedButton, "AddFeedButton");
            this.AddFeedButton.Name = "AddFeedButton";
            this.AddFeedButton.UseVisualStyleBackColor = false;
            this.AddFeedButton.Click += new System.EventHandler(this.AddFeedButton_Click);
            // 
            // CancelFeedButton
            // 
            this.CancelFeedButton.BackColor = System.Drawing.SystemColors.Control;
            this.CancelFeedButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CancelFeedButton, "CancelFeedButton");
            this.CancelFeedButton.Name = "CancelFeedButton";
            this.CancelFeedButton.UseVisualStyleBackColor = false;
            this.CancelFeedButton.Click += new System.EventHandler(this.CancelFeedButton_Click);
            // 
            // tabFilters
            // 
            this.tabFilters.BackColor = System.Drawing.Color.White;
            this.tabFilters.Controls.Add(this.label7);
            this.tabFilters.Controls.Add(this.TextFilterTextBox);
            this.tabFilters.Controls.Add(this.label6);
            resources.ApplyResources(this.tabFilters, "tabFilters");
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.UseVisualStyleBackColor = true;
            this.tabFilters.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Name = "label7";
            // 
            // TextFilterTextBox
            // 
            resources.ApplyResources(this.TextFilterTextBox, "TextFilterTextBox");
            this.TextFilterTextBox.Name = "TextFilterTextBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // tabID3
            // 
            this.tabID3.BackColor = System.Drawing.Color.Transparent;
            this.tabID3.Controls.Add(this.label19);
            this.tabID3.Controls.Add(this.TagTitleTextBox);
            this.tabID3.Controls.Add(this.panel1);
            this.tabID3.Controls.Add(this.TrackCounterNumeric);
            this.tabID3.Controls.Add(this.labelStartAt);
            this.tabID3.Controls.Add(this.TrackCounterCheckBox);
            this.tabID3.Controls.Add(this.TagArtistTextBox);
            this.tabID3.Controls.Add(this.labelArtist);
            this.tabID3.Controls.Add(this.TagAlbumTextBox);
            this.tabID3.Controls.Add(this.label10);
            this.tabID3.Controls.Add(this.label9);
            this.tabID3.Controls.Add(this.label8);
            this.tabID3.Controls.Add(this.TagGenreTextBox);
            resources.ApplyResources(this.tabID3, "tabID3");
            this.tabID3.Name = "tabID3";
            this.tabID3.UseVisualStyleBackColor = true;
            this.tabID3.Click += new System.EventHandler(this.tabID3_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // TagTitleTextBox
            // 
            resources.ApplyResources(this.TagTitleTextBox, "TagTitleTextBox");
            this.TagTitleTextBox.Name = "TagTitleTextBox";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // TrackCounterNumeric
            // 
            resources.ApplyResources(this.TrackCounterNumeric, "TrackCounterNumeric");
            this.TrackCounterNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TrackCounterNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrackCounterNumeric.Name = "TrackCounterNumeric";
            this.TrackCounterNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelStartAt
            // 
            this.labelStartAt.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelStartAt, "labelStartAt");
            this.labelStartAt.Name = "labelStartAt";
            // 
            // TrackCounterCheckBox
            // 
            this.TrackCounterCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.TrackCounterCheckBox, "TrackCounterCheckBox");
            this.TrackCounterCheckBox.Name = "TrackCounterCheckBox";
            this.TrackCounterCheckBox.UseVisualStyleBackColor = false;
            this.TrackCounterCheckBox.CheckedChanged += new System.EventHandler(this.checkTrackCounter_CheckedChanged);
            // 
            // TagArtistTextBox
            // 
            resources.ApplyResources(this.TagArtistTextBox, "TagArtistTextBox");
            this.TagArtistTextBox.Name = "TagArtistTextBox";
            this.TagArtistTextBox.TextChanged += new System.EventHandler(this.textTagArtist_TextChanged);
            // 
            // labelArtist
            // 
            this.labelArtist.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelArtist, "labelArtist");
            this.labelArtist.Name = "labelArtist";
            // 
            // TagAlbumTextBox
            // 
            resources.ApplyResources(this.TagAlbumTextBox, "TagAlbumTextBox");
            this.TagAlbumTextBox.Name = "TagAlbumTextBox";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // TagGenreTextBox
            // 
            resources.ApplyResources(this.TagGenreTextBox, "TagGenreTextBox");
            this.TagGenreTextBox.Name = "TagGenreTextBox";
            // 
            // tabSpaceSavers
            // 
            this.tabSpaceSavers.BackColor = System.Drawing.Color.Transparent;
            this.tabSpaceSavers.Controls.Add(this.SpaceSaversGroup);
            this.tabSpaceSavers.Controls.Add(this.DefaultSpaceSaversGroup);
            this.tabSpaceSavers.Controls.Add(this.SpaceSaversCheckBox);
            resources.ApplyResources(this.tabSpaceSavers, "tabSpaceSavers");
            this.tabSpaceSavers.Name = "tabSpaceSavers";
            this.tabSpaceSavers.UseVisualStyleBackColor = true;
            this.tabSpaceSavers.Click += new System.EventHandler(this.tabSpaceSavers_Click);
            // 
            // SpaceSaversGroup
            // 
            this.SpaceSaversGroup.Controls.Add(this.labelRestrictDaysDays);
            this.SpaceSaversGroup.Controls.Add(this.labelRestrictDays);
            this.SpaceSaversGroup.Controls.Add(this.SpaceSaverRestrictByDaysNumeric);
            this.SpaceSaversGroup.Controls.Add(this.SpaceSaverRestrictByFilesNumeric);
            this.SpaceSaversGroup.Controls.Add(this.labelMaximumFiles);
            this.SpaceSaversGroup.Controls.Add(this.labelMB);
            this.SpaceSaversGroup.Controls.Add(this.SpaceSaverRestrictBySizeNumeric);
            this.SpaceSaversGroup.Controls.Add(this.labelTotalSize);
            this.SpaceSaversGroup.Controls.Add(this.RestrictDaysRadioButton);
            this.SpaceSaversGroup.Controls.Add(this.RestrictFilesRadioButton);
            this.SpaceSaversGroup.Controls.Add(this.RestrictSizeRadioButton);
            resources.ApplyResources(this.SpaceSaversGroup, "SpaceSaversGroup");
            this.SpaceSaversGroup.Name = "SpaceSaversGroup";
            this.SpaceSaversGroup.TabStop = false;
            // 
            // labelRestrictDaysDays
            // 
            resources.ApplyResources(this.labelRestrictDaysDays, "labelRestrictDaysDays");
            this.labelRestrictDaysDays.Name = "labelRestrictDaysDays";
            // 
            // labelRestrictDays
            // 
            resources.ApplyResources(this.labelRestrictDays, "labelRestrictDays");
            this.labelRestrictDays.BackColor = System.Drawing.Color.Transparent;
            this.labelRestrictDays.Name = "labelRestrictDays";
            // 
            // SpaceSaverRestrictByDaysNumeric
            // 
            resources.ApplyResources(this.SpaceSaverRestrictByDaysNumeric, "SpaceSaverRestrictByDaysNumeric");
            this.SpaceSaverRestrictByDaysNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SpaceSaverRestrictByDaysNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceSaverRestrictByDaysNumeric.Name = "SpaceSaverRestrictByDaysNumeric";
            this.SpaceSaverRestrictByDaysNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SpaceSaverRestrictByFilesNumeric
            // 
            resources.ApplyResources(this.SpaceSaverRestrictByFilesNumeric, "SpaceSaverRestrictByFilesNumeric");
            this.SpaceSaverRestrictByFilesNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SpaceSaverRestrictByFilesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceSaverRestrictByFilesNumeric.Name = "SpaceSaverRestrictByFilesNumeric";
            this.SpaceSaverRestrictByFilesNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelMaximumFiles
            // 
            resources.ApplyResources(this.labelMaximumFiles, "labelMaximumFiles");
            this.labelMaximumFiles.Name = "labelMaximumFiles";
            // 
            // labelMB
            // 
            resources.ApplyResources(this.labelMB, "labelMB");
            this.labelMB.BackColor = System.Drawing.Color.Transparent;
            this.labelMB.Name = "labelMB";
            // 
            // SpaceSaverRestrictBySizeNumeric
            // 
            resources.ApplyResources(this.SpaceSaverRestrictBySizeNumeric, "SpaceSaverRestrictBySizeNumeric");
            this.SpaceSaverRestrictBySizeNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SpaceSaverRestrictBySizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceSaverRestrictBySizeNumeric.Name = "SpaceSaverRestrictBySizeNumeric";
            this.SpaceSaverRestrictBySizeNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelTotalSize
            // 
            resources.ApplyResources(this.labelTotalSize, "labelTotalSize");
            this.labelTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalSize.Name = "labelTotalSize";
            // 
            // RestrictDaysRadioButton
            // 
            resources.ApplyResources(this.RestrictDaysRadioButton, "RestrictDaysRadioButton");
            this.RestrictDaysRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictDaysRadioButton.Name = "RestrictDaysRadioButton";
            this.RestrictDaysRadioButton.UseVisualStyleBackColor = false;
            // 
            // RestrictFilesRadioButton
            // 
            resources.ApplyResources(this.RestrictFilesRadioButton, "RestrictFilesRadioButton");
            this.RestrictFilesRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictFilesRadioButton.Name = "RestrictFilesRadioButton";
            this.RestrictFilesRadioButton.UseVisualStyleBackColor = false;
            // 
            // RestrictSizeRadioButton
            // 
            resources.ApplyResources(this.RestrictSizeRadioButton, "RestrictSizeRadioButton");
            this.RestrictSizeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictSizeRadioButton.Checked = true;
            this.RestrictSizeRadioButton.Name = "RestrictSizeRadioButton";
            this.RestrictSizeRadioButton.TabStop = true;
            this.RestrictSizeRadioButton.UseVisualStyleBackColor = false;
            // 
            // DefaultSpaceSaversGroup
            // 
            this.DefaultSpaceSaversGroup.Controls.Add(this.label17);
            this.DefaultSpaceSaversGroup.Controls.Add(this.label16);
            this.DefaultSpaceSaversGroup.Controls.Add(this.label12);
            this.DefaultSpaceSaversGroup.Controls.Add(this.KeepUnplayedCheckBox);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RetrieveMaximumMBNumeric);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RatingComboBox);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RetrieveMaximumMBCheckBox);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RetrieveLastNumeric);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RemoveByRatingCheckBox);
            this.DefaultSpaceSaversGroup.Controls.Add(this.RetrieveOnlyLastCheckBox);
            this.DefaultSpaceSaversGroup.Controls.Add(this.label4);
            resources.ApplyResources(this.DefaultSpaceSaversGroup, "DefaultSpaceSaversGroup");
            this.DefaultSpaceSaversGroup.Name = "DefaultSpaceSaversGroup";
            this.DefaultSpaceSaversGroup.TabStop = false;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Name = "label12";
            // 
            // KeepUnplayedCheckBox
            // 
            resources.ApplyResources(this.KeepUnplayedCheckBox, "KeepUnplayedCheckBox");
            this.KeepUnplayedCheckBox.Name = "KeepUnplayedCheckBox";
            this.KeepUnplayedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RetrieveMaximumMBNumeric
            // 
            resources.ApplyResources(this.RetrieveMaximumMBNumeric, "RetrieveMaximumMBNumeric");
            this.RetrieveMaximumMBNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RetrieveMaximumMBNumeric.Name = "RetrieveMaximumMBNumeric";
            // 
            // RatingComboBox
            // 
            this.RatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.RatingComboBox, "RatingComboBox");
            this.RatingComboBox.FormattingEnabled = true;
            this.RatingComboBox.Items.AddRange(new object[] {
            resources.GetString("RatingComboBox.Items"),
            resources.GetString("RatingComboBox.Items1"),
            resources.GetString("RatingComboBox.Items2"),
            resources.GetString("RatingComboBox.Items3"),
            resources.GetString("RatingComboBox.Items4")});
            this.RatingComboBox.Name = "RatingComboBox";
            // 
            // RetrieveMaximumMBCheckBox
            // 
            resources.ApplyResources(this.RetrieveMaximumMBCheckBox, "RetrieveMaximumMBCheckBox");
            this.RetrieveMaximumMBCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RetrieveMaximumMBCheckBox.Name = "RetrieveMaximumMBCheckBox";
            this.RetrieveMaximumMBCheckBox.UseVisualStyleBackColor = false;
            this.RetrieveMaximumMBCheckBox.CheckedChanged += new System.EventHandler(this.RetrieveMaximumMBCheckBox_CheckedChanged);
            // 
            // RetrieveLastNumeric
            // 
            resources.ApplyResources(this.RetrieveLastNumeric, "RetrieveLastNumeric");
            this.RetrieveLastNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RetrieveLastNumeric.Name = "RetrieveLastNumeric";
            this.RetrieveLastNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RemoveByRatingCheckBox
            // 
            resources.ApplyResources(this.RemoveByRatingCheckBox, "RemoveByRatingCheckBox");
            this.RemoveByRatingCheckBox.Name = "RemoveByRatingCheckBox";
            this.RemoveByRatingCheckBox.CheckedChanged += new System.EventHandler(this.checkRemoveByRating_CheckedChanged);
            // 
            // RetrieveOnlyLastCheckBox
            // 
            resources.ApplyResources(this.RetrieveOnlyLastCheckBox, "RetrieveOnlyLastCheckBox");
            this.RetrieveOnlyLastCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RetrieveOnlyLastCheckBox.Name = "RetrieveOnlyLastCheckBox";
            this.RetrieveOnlyLastCheckBox.UseVisualStyleBackColor = false;
            this.RetrieveOnlyLastCheckBox.CheckedChanged += new System.EventHandler(this.RetrieveOnlyLastCheckBox_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // SpaceSaversCheckBox
            // 
            resources.ApplyResources(this.SpaceSaversCheckBox, "SpaceSaversCheckBox");
            this.SpaceSaversCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.SpaceSaversCheckBox.Name = "SpaceSaversCheckBox";
            this.SpaceSaversCheckBox.UseVisualStyleBackColor = false;
            this.SpaceSaversCheckBox.CheckedChanged += new System.EventHandler(this.checkSpaceSavers_CheckedChanged);
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.Controls.Add(this.FeedPictureBox);
            this.tabMain.Controls.Add(this.DownloadsFolderButton);
            this.tabMain.Controls.Add(this.DownloadsFolderTextBox);
            this.tabMain.Controls.Add(this.DownloadsFolderCheckBox);
            this.tabMain.Controls.Add(this.PasswordTextBox);
            this.tabMain.Controls.Add(this.label5);
            this.tabMain.Controls.Add(this.label11);
            this.tabMain.Controls.Add(this.UsernameTextBox);
            this.tabMain.Controls.Add(this.LoginCheckBox);
            this.tabMain.Controls.Add(this.CategoryComboBox);
            this.tabMain.Controls.Add(this.label15);
            this.tabMain.Controls.Add(this.label13);
            this.tabMain.Controls.Add(this.PlaylistTextBox);
            this.tabMain.Controls.Add(this.UrlTextBox);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.NameTextBox);
            this.tabMain.Controls.Add(this.label2);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.UseVisualStyleBackColor = true;
            this.tabMain.Enter += new System.EventHandler(this.tabMain_Enter);
            this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
            // 
            // FeedPictureBox
            // 
            resources.ApplyResources(this.FeedPictureBox, "FeedPictureBox");
            this.FeedPictureBox.Name = "FeedPictureBox";
            this.FeedPictureBox.TabStop = false;
            // 
            // DownloadsFolderButton
            // 
            resources.ApplyResources(this.DownloadsFolderButton, "DownloadsFolderButton");
            this.DownloadsFolderButton.Name = "DownloadsFolderButton";
            this.DownloadsFolderButton.UseVisualStyleBackColor = true;
            this.DownloadsFolderButton.Click += new System.EventHandler(this.DownloadsFolderButton_Click);
            // 
            // DownloadsFolderTextBox
            // 
            this.DownloadsFolderTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DownloadsFolderTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            resources.ApplyResources(this.DownloadsFolderTextBox, "DownloadsFolderTextBox");
            this.DownloadsFolderTextBox.Name = "DownloadsFolderTextBox";
            this.DownloadsFolderTextBox.TextChanged += new System.EventHandler(this.DownloadsFolderTextBox_TextChanged);
            // 
            // DownloadsFolderCheckBox
            // 
            resources.ApplyResources(this.DownloadsFolderCheckBox, "DownloadsFolderCheckBox");
            this.DownloadsFolderCheckBox.Name = "DownloadsFolderCheckBox";
            this.DownloadsFolderCheckBox.UseVisualStyleBackColor = true;
            this.DownloadsFolderCheckBox.Click += new System.EventHandler(this.DownloadsFolderCheckBox_Click);
            this.DownloadsFolderCheckBox.CheckedChanged += new System.EventHandler(this.DownloadsFolderCheckBox_CheckedChanged);
            // 
            // PasswordTextBox
            // 
            resources.ApplyResources(this.PasswordTextBox, "PasswordTextBox");
            this.PasswordTextBox.Name = "PasswordTextBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Name = "label11";
            // 
            // UsernameTextBox
            // 
            resources.ApplyResources(this.UsernameTextBox, "UsernameTextBox");
            this.UsernameTextBox.Name = "UsernameTextBox";
            // 
            // LoginCheckBox
            // 
            resources.ApplyResources(this.LoginCheckBox, "LoginCheckBox");
            this.LoginCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.LoginCheckBox.Name = "LoginCheckBox";
            this.LoginCheckBox.UseVisualStyleBackColor = false;
            this.LoginCheckBox.CheckedChanged += new System.EventHandler(this.LoginCheckBox_CheckChanged);
            // 
            // CategoryComboBox
            // 
            resources.ApplyResources(this.CategoryComboBox, "CategoryComboBox");
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Name = "CategoryComboBox";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // PlaylistTextBox
            // 
            resources.ApplyResources(this.PlaylistTextBox, "PlaylistTextBox");
            this.PlaylistTextBox.Name = "PlaylistTextBox";
            this.PlaylistTextBox.Enter += new System.EventHandler(this.textPlaylist_Enter);
            this.PlaylistTextBox.Leave += new System.EventHandler(this.textPlaylist_Leave);
            this.PlaylistTextBox.TextChanged += new System.EventHandler(this.textPlaylist_TextChanged);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.UrlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            resources.ApplyResources(this.UrlTextBox, "UrlTextBox");
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.TextChanged += new System.EventHandler(this.textUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NameTextBox
            // 
            resources.ApplyResources(this.NameTextBox, "NameTextBox");
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Enter += new System.EventHandler(this.textName_Enter);
            this.NameTextBox.Leave += new System.EventHandler(this.textName_Leave);
            this.NameTextBox.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSpaceSavers);
            this.tabControl1.Controls.Add(this.tabID3);
            this.tabControl1.Controls.Add(this.tabFilters);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.checkUseTitleForFile);
            this.tabAdvanced.Controls.Add(this.groupBox1);
            this.tabAdvanced.Controls.Add(this.AlwaysConvertToM4BCheckBox);
            resources.ApplyResources(this.tabAdvanced, "tabAdvanced");
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // checkUseTitleForFile
            // 
            resources.ApplyResources(this.checkUseTitleForFile, "checkUseTitleForFile");
            this.checkUseTitleForFile.Name = "checkUseTitleForFile";
            this.checkUseTitleForFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CacheFileSizeTextBox);
            this.groupBox1.Controls.Add(this.CacheFileDateTextBox);
            this.groupBox1.Controls.Add(this.CacheFileLocationTextBox);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.ClearCacheButton);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label18);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // CacheFileSizeTextBox
            // 
            this.CacheFileSizeTextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CacheFileSizeTextBox, "CacheFileSizeTextBox");
            this.CacheFileSizeTextBox.Name = "CacheFileSizeTextBox";
            this.CacheFileSizeTextBox.ReadOnly = true;
            // 
            // CacheFileDateTextBox
            // 
            this.CacheFileDateTextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CacheFileDateTextBox, "CacheFileDateTextBox");
            this.CacheFileDateTextBox.Name = "CacheFileDateTextBox";
            this.CacheFileDateTextBox.ReadOnly = true;
            // 
            // CacheFileLocationTextBox
            // 
            this.CacheFileLocationTextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CacheFileLocationTextBox, "CacheFileLocationTextBox");
            this.CacheFileLocationTextBox.Name = "CacheFileLocationTextBox";
            this.CacheFileLocationTextBox.ReadOnly = true;
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // ClearCacheButton
            // 
            resources.ApplyResources(this.ClearCacheButton, "ClearCacheButton");
            this.ClearCacheButton.Name = "ClearCacheButton";
            this.ClearCacheButton.UseVisualStyleBackColor = true;
            this.ClearCacheButton.Click += new System.EventHandler(this.ClearCacheButton_Click);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // AlwaysConvertToM4BCheckBox
            // 
            resources.ApplyResources(this.AlwaysConvertToM4BCheckBox, "AlwaysConvertToM4BCheckBox");
            this.AlwaysConvertToM4BCheckBox.Name = "AlwaysConvertToM4BCheckBox";
            this.AlwaysConvertToM4BCheckBox.UseVisualStyleBackColor = true;
            // 
            // FeedForm
            // 
            this.AcceptButton = this.AddFeedButton;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.CancelFeedButton;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CancelFeedButton);
            this.Controls.Add(this.AddFeedButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FeedForm_Load);
            this.tabFilters.ResumeLayout(false);
            this.tabFilters.PerformLayout();
            this.tabID3.ResumeLayout(false);
            this.tabID3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackCounterNumeric)).EndInit();
            this.tabSpaceSavers.ResumeLayout(false);
            this.tabSpaceSavers.PerformLayout();
            this.SpaceSaversGroup.ResumeLayout(false);
            this.SpaceSaversGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictByDaysNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictByFilesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceSaverRestrictBySizeNumeric)).EndInit();
            this.DefaultSpaceSaversGroup.ResumeLayout(false);
            this.DefaultSpaceSaversGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrieveMaximumMBNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetrieveLastNumeric)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeedPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.tabAdvanced.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		

       
		private void RefreshCategorylist()
		{
			CategoryComboBox.Items.Clear();
			CategoryComboBox.Items.Add("- " + FormStrings.Uncategorized + " -");
     
			for(int q=0;q<Settings.Default.Feeds.Count;q++)
			{
                FeedItem feedItem = Settings.Default.Feeds[q];
				if(feedItem.Category != null && feedItem.Category != "")
				{
					if(!CategoryComboBox.Items.Contains(feedItem.Category))
					{
						CategoryComboBox.Items.Add(feedItem.Category);
					}
				}
			}
		}
         

		private void FeedForm_Load(object sender, System.EventArgs e)
		{
			ToolTip toolTip = new ToolTip();
			toolTip.AutoPopDelay = 5000;
			toolTip.InitialDelay = 1000;
			toolTip.ReshowDelay = 500;
			toolTip.ShowAlways = true;

			toolTip.SetToolTip(this.RestrictSizeRadioButton,"The oldest file will be deleted when the maximum size has been reached");
			toolTip.SetToolTip(this.RestrictFilesRadioButton,"The oldest file will be delete when the maximum number of files has been reached");
			toolTip.SetToolTip(this.RestrictDaysRadioButton,"All files older than the specified number of days will be removed");
			
			this.ActiveControl = UrlTextBox;

            if (feedItem.Title != "")
            {
                NameTextBox.Text = feedItem.Title;
            }
			RefreshCategorylist();

            if (feedItem.Category != null)
            {
                for (int q = 0; q < CategoryComboBox.Items.Count; q++)
                {
                    if (CategoryComboBox.Items[q].ToString() == feedItem.Category)
                    {
                        CategoryComboBox.SelectedIndex = q;
                        break;
                    }
                }
            }

            if (feedItem.FeedHashCode != "")
            {
                if (File.Exists(Path.Combine(Utils.DataFolder, feedItem.FeedHashCode + ".jpg")))
                {
                    FeedPictureBox.Image = new Bitmap(Path.Combine(Utils.DataFolder, feedItem.FeedHashCode + ".jpg"));
                    FeedPictureBox.Visible = true;
                   
                }
                else
                {
                    FeedPictureBox.Image = null;
                    FeedPictureBox.Visible = false;

                }
            }
			if(boolNew)
			{
                AddFeedButton.Text = FormStrings.Addfeed;
                if (feedItem != null)
                {
                    UrlTextBox.Text = feedItem.Url;
                }
                UrlTextBox.SelectionStart = UrlTextBox.Text.Length;

			} else {
                AddFeedButton.Text = FormStrings.UpdateFeed;
				UrlTextBox.Text = feedItem.Url;
            }


            TextFilterTextBox.Text = feedItem.Textfilter;
            if (feedItem.TagTitle != null)
            {
                TagTitleTextBox.Text = feedItem.TagTitle;
            }
            if (feedItem.TagGenre != null)
            {
                TagGenreTextBox.Text = feedItem.TagGenre;
            }
            if (feedItem.TagArtist != null)
            {
                TagArtistTextBox.Text = feedItem.TagArtist;
            }
            if (feedItem.TagAlbum != null)
            {
                TagAlbumTextBox.Text = feedItem.TagAlbum;
            }
            checkUseTitleForFile.Checked = feedItem.UseTitleForFiles;
            if (feedItem.PlaylistName != null && feedItem.PlaylistName == "")
            {
                PlaylistTextBox.Text = FormStrings.LeaveEmptyToUseFeedName;
            }
            if (feedItem.RetrieveNumberOfFiles != 0)
            {
                RetrieveOnlyLastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
                RetrieveLastNumeric.Value = feedItem.RetrieveNumberOfFiles;
                RetrieveLastNumeric.Enabled = true;
            }
            else
            {
                RetrieveOnlyLastCheckBox.CheckState = System.Windows.Forms.CheckState.Unchecked;
                RetrieveLastNumeric.Value = 1;
                RetrieveLastNumeric.Enabled = false;
            }
            if (feedItem.MaxMb != 0)
            {
                RetrieveMaximumMBCheckBox.CheckState = CheckState.Checked;
                RetrieveMaximumMBNumeric.Value = feedItem.MaxMb;
                RetrieveMaximumMBNumeric.Enabled = true;
            }
            else
            {
                RetrieveMaximumMBCheckBox.CheckState = CheckState.Unchecked;
                RetrieveMaximumMBNumeric.Value = 1;
                RetrieveMaximumMBNumeric.Enabled = false;
            }
            if (feedItem.PlaylistName != null && feedItem.PlaylistName != "")
            {
                PlaylistTextBox.Text = feedItem.PlaylistName;
            }
            else
            {
                PlaylistTextBox.Text = FormStrings.LeaveEmptyToUseFeedName;
            }
            if (feedItem.CleanRating > 0)
            {
                RemoveByRatingCheckBox.Checked = true;
                RatingComboBox.Enabled = true;
                RatingComboBox.SelectedIndex = feedItem.CleanRating - 1;
            }
            AlwaysConvertToM4BCheckBox.Checked = feedItem.OverrideAACConversion;
            KeepUnplayedCheckBox.Checked = feedItem.RemovePlayed;
            if (feedItem.UseSpaceSavers == true)
            {
                SpaceSaversCheckBox.Checked = true;
                //	checkRemoveFromPlaylist.Checked = feedItem.RemoveFromPlaylist;
                if (feedItem.CleanRating > 0)
                {
                    RemoveByRatingCheckBox.Checked = true;
                    RatingComboBox.SelectedIndex = feedItem.CleanRating - 1;
                }
                if (feedItem.Spacesaver_Size > 0)
                {
                    RestrictFilesRadioButton.Checked = false;
                    RestrictDaysRadioButton.Checked = false;
                    SpaceSaverRestrictBySizeNumeric.Value = Convert.ToDecimal(feedItem.Spacesaver_Size);
                    RestrictSizeRadioButton.Checked = true;
                }
                if (feedItem.Spacesaver_Files > 0)
                {
                    RestrictSizeRadioButton.Checked = false;
                    RestrictDaysRadioButton.Checked = false;
                    SpaceSaverRestrictByFilesNumeric.Value = Convert.ToDecimal(feedItem.Spacesaver_Files);
                    RestrictFilesRadioButton.Checked = true;
                }
                if (feedItem.Spacesaver_Days > 0)
                {
                    RestrictSizeRadioButton.Checked = false;
                    RestrictSizeRadioButton.Checked = false;
                    SpaceSaverRestrictByDaysNumeric.Value = Convert.ToDecimal(feedItem.Spacesaver_Days);
                    RestrictDaysRadioButton.Checked = true;
                }
            }
            else
            {
                SpaceSaversCheckBox.Checked = false;
                RestrictSizeRadioButton.Checked = false;
                RestrictFilesRadioButton.Checked = false;

                SpaceSaverRestrictBySizeNumeric.Value = 1;
                SpaceSaverRestrictByDaysNumeric.Value = 1;
                SpaceSaverRestrictByFilesNumeric.Value = 1;
            }
            if (feedItem.OverrideDownloadsFolder)
            {
                DownloadsFolderCheckBox.Checked = true;
                DownloadsFolderTextBox.Text = feedItem.DownloadsFolder;
            }
            else
            {
                DownloadsFolderCheckBox.Checked = false;
                DownloadsFolderTextBox.Text = feedItem.DownloadsFolder;
            }
            LoginCheckBox.Checked = feedItem.Authenticate;
            UsernameTextBox.Text = feedItem.Username;
            if (feedItem.Password != null && feedItem.Username != null)
            {
                PasswordTextBox.Text = EncDec.Decrypt(feedItem.Password, feedItem.Username);
            }
            if (feedItem.FeedHashCode != "" && File.Exists(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".bin"))
            {
                FileInfo cacheFileInfo = new FileInfo(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".bin");
                string cacheFileName = Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".bin";
                CacheFileLocationTextBox.Text = cacheFileName;
                CacheFileDateTextBox.Text = cacheFileInfo.LastWriteTime.ToString();
                CacheFileSizeTextBox.Text = cacheFileInfo.Length.ToString() + " bytes";
                ClearCacheButton.Enabled = true;
            }
            else
            {
                CacheFileLocationTextBox.Text = "No cache file";
                ClearCacheButton.Enabled = false;
            }
		}

		private void RetrieveOnlyLastCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RetrieveOnlyLastCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				RetrieveLastNumeric.Enabled = true;
			} 
			else 
			{
				RetrieveLastNumeric.Enabled = false;
			}
		}

		private void RetrieveMaximumMBCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RetrieveMaximumMBCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				RetrieveMaximumMBNumeric.Enabled = true;
			} 
			else 
			{
				RetrieveMaximumMBNumeric.Enabled = false;
			}
		}

		private void tabPage2_Click(object sender, System.EventArgs e)
		{
		
		}


		private void textUrl_TextChanged(object sender, System.EventArgs e)
		{
			if(UrlTextBox.Text == "")
			{
                UrlTextBox.BackColor = Control.DefaultBackColor;
                UrlTextBox.ForeColor = Control.DefaultForeColor;
				AddFeedButton.Enabled = false;
			} 
			else 
			{
                try
                {
                    if (!UrlTextBox.Text.ToLower().StartsWith("http://") && !UrlTextBox.Text.ToLower().StartsWith("https://"))
                    {
                        Uri uri = new Uri("http://" + UrlTextBox.Text);
                    }
                    else
                    {
                        Uri uri = new Uri(UrlTextBox.Text);
                    }
                    UrlTextBox.BackColor = Control.DefaultBackColor;
                    UrlTextBox.ForeColor = Control.DefaultForeColor;
                    bool boolEnabled = true;
                    foreach (FeedItem feedItem in Settings.Default.Feeds)
                    {
                        if (feedItem.Url == UrlTextBox.Text && boolNew == true)
                        {
                            UrlTextBox.BackColor = Color.Yellow;
                            boolEnabled = false;
                            break;
                        }
                    }
                    if (boolEnabled == true)
                    {
                        UrlTextBox.BackColor = Color.White;
                    }
                    AddFeedButton.Enabled = boolEnabled;
                }
                catch
                {
                    if (UrlTextBox.Text != "http://")
                    {
                        UrlTextBox.BackColor = Color.Yellow;
                    }
                    AddFeedButton.Enabled = false;
                }
			} 
		}

		private void labelTotalSize_Click(object sender, System.EventArgs e)
		{
		
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void radioRestrictSize_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RestrictSizeRadioButton.Checked == true)
			{
				labelTotalSize.Enabled = true;
				labelMB.Enabled = true;
				SpaceSaverRestrictBySizeNumeric.Enabled = true;
				
			} 
			else 
			{
				labelTotalSize.Enabled = false;
				labelMB.Enabled = false;
				SpaceSaverRestrictBySizeNumeric.Enabled = false;
				
			}

		}

		private void tabSpaceSavers_Click(object sender, System.EventArgs e)
		{
		
		}

		private void radioRestrictFiles_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RestrictFilesRadioButton.Checked == true)
			{
				labelMaximumFiles.Enabled = true;
				SpaceSaverRestrictByFilesNumeric.Enabled = true;
			
			} 
			else 
			{
				labelMaximumFiles.Enabled = false;
				SpaceSaverRestrictByFilesNumeric.Enabled = false;
			
			}
		}

		private void radioRestrictDays_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RestrictDaysRadioButton.Checked == true)
			{
				labelRestrictDays.Enabled = true;
				labelRestrictDaysDays.Enabled = true;
				SpaceSaverRestrictByDaysNumeric.Enabled = true;
			} 
			else 
			{
				labelRestrictDays.Enabled = false;
				labelRestrictDaysDays.Enabled = false;
				SpaceSaverRestrictByDaysNumeric.Enabled = false;
			}
		}

		private void checkSpaceSavers_CheckedChanged(object sender, System.EventArgs e)
		{
			if(SpaceSaversCheckBox.Checked)
			{
                SpaceSaversGroup.Visible = true;
            } else {
                SpaceSaversGroup.Visible = false;
            }
		}

		private void label10_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tabID3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void LoginCheckBox_CheckChanged(object sender, System.EventArgs e)
		{
			if(LoginCheckBox.Checked == true)
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

		private void tabConnection_Click(object sender, System.EventArgs e)
		{
		
		}

		private void textTagArtist_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void textPlaylist_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void textPlaylist_Enter(object sender, System.EventArgs e)
		{
			if(PlaylistTextBox.Text == FormStrings.LeaveEmptyToUseFeedName)
			{
				PlaylistTextBox.Text = "";
			}
		
		}

		private void textName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void textName_Enter(object sender, System.EventArgs e)
		{
			if(NameTextBox.Text == FormStrings.LeaveEmptyToExtractNameFromTheFeed)
			{
				NameTextBox.Text = "";
			}
		}

		private void textName_Leave(object sender, System.EventArgs e)
		{
			if(NameTextBox.Text == "")
			{
				NameTextBox.Text = FormStrings.LeaveEmptyToExtractNameFromTheFeed;
			}
		}

		private void textPlaylist_Leave(object sender, System.EventArgs e)
		{
			if(PlaylistTextBox.Text == "")
			{
				PlaylistTextBox.Text = FormStrings.LeaveEmptyToUseFeedName;
			}
		}

		private void tabMain_Enter(object sender, System.EventArgs e)
		{
			UrlTextBox.SelectAll();
		}

		private void checkRemoveFromPlaylist_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void checkRemoveByRating_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RemoveByRatingCheckBox.Checked)
			{
				RatingComboBox.Enabled = true;
			} 
			else 
			{
				RatingComboBox.Enabled = false;
			}
		}

		private void checkTrackCounter_CheckedChanged(object sender, System.EventArgs e)
		{
			if(TrackCounterCheckBox.Checked)
			{
				labelStartAt.Enabled = true;
				TrackCounterNumeric.Enabled = true;
			} 
			else 
			{
				labelStartAt.Enabled = false;
				TrackCounterNumeric.Enabled = false;
			}
		}

		private void tabMain_Click(object sender, System.EventArgs e)
		{
		
		}

        private int GetFeedFlags(bool boolOverrideM4BConversion)
        {
            int intReturn = 0;
            if (boolOverrideM4BConversion)
            {
                intReturn = 1;
            }
            else
            {
                intReturn = 0;
            }
            return intReturn;
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


		private void AddFeedButton_Click(object sender, System.EventArgs e)
		{

			if(feedItem.GUID == null || feedItem.GUID == "")
			{
				feedItem.GUID = System.Guid.NewGuid().ToString();
			}
			feedItem.Textfilter = TextFilterTextBox.Text;

            feedItem.OverrideAACConversion = AlwaysConvertToM4BCheckBox.Checked;
			
            if (DownloadsFolderCheckBox.Checked)
            {
                feedItem.OverrideDownloadsFolder = true;
            }
            else
            {
                feedItem.OverrideDownloadsFolder = false;
            }
            feedItem.DownloadsFolder = DownloadsFolderTextBox.Text;
            
			if(CategoryComboBox.Text == "- " + FormStrings.Uncategorized + " -")
			{
				feedItem.Category = "";
			} 
			else 
			{
				feedItem.Category = CategoryComboBox.Text;
			}
			if(UrlTextBox.Text.ToUpper().StartsWith("\\") || UrlTextBox.Text.Substring(1,2) == ":\\" || UrlTextBox.Text.ToUpper().StartsWith("HTTP://") || UrlTextBox.Text.ToUpper().StartsWith("HTTPS://"))
			{
				feedItem.Url = UrlTextBox.Text;
			} 
			else 
			{
				feedItem.Url = "http://" + UrlTextBox.Text.ToLower();
			}
			if(RetrieveOnlyLastCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				feedItem.RetrieveNumberOfFiles = decimal.ToInt32(RetrieveLastNumeric.Value);
			} 
			else 
			{
				feedItem.RetrieveNumberOfFiles = 0;
			}
			if(RetrieveMaximumMBCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				feedItem.MaxMb = decimal.ToInt32(RetrieveMaximumMBNumeric.Value);
			} 
			else 
			{
				feedItem.MaxMb = 0;
			}
			if(SpaceSaversCheckBox.Checked == true)
			{
				feedItem.UseSpaceSavers = true;
				if(RestrictSizeRadioButton.Checked == true)
				{
					feedItem.Spacesaver_Size = Convert.ToInt32(SpaceSaverRestrictBySizeNumeric.Value);
					feedItem.Spacesaver_Files = 0;
					feedItem.Spacesaver_Days = 0;
				} 
				else 
				{
					feedItem.Spacesaver_Size = 0;
				}
				if(RestrictFilesRadioButton.Checked == true)
				{
					feedItem.Spacesaver_Files = Convert.ToInt32(SpaceSaverRestrictByFilesNumeric.Value);
					feedItem.Spacesaver_Size = 0;
					feedItem.Spacesaver_Days = 0;
				} 
				else 
				{
					feedItem.Spacesaver_Files = 0;
				}
				if(RestrictDaysRadioButton.Checked == true)
				{
					feedItem.Spacesaver_Days = Convert.ToInt32(SpaceSaverRestrictByDaysNumeric.Value);
					feedItem.Spacesaver_Size = 0;
					feedItem.Spacesaver_Files = 0;
				} 
				else 
				{
					feedItem.Spacesaver_Days = 0;
				}
			} 
			else 
			{
				feedItem.UseSpaceSavers = false;
			}
			if(feedItem.IsChecked)
			{
				feedItem.IsChecked = true;
			}
			if(TrackCounterCheckBox.Checked == true)
			{
				feedItem.UseTrackCounter = true;	
			} 
			else 
			{
				feedItem.UseTrackCounter = false;
			}
            feedItem.UseTitleForFiles = checkUseTitleForFile.Checked;
			feedItem.TrackCounter = Convert.ToInt32(TrackCounterNumeric.Value);
			feedItem.TagTitle = TagTitleTextBox.Text;
			feedItem.TagGenre = TagGenreTextBox.Text;
			feedItem.TagArtist = TagArtistTextBox.Text;
			feedItem.TagAlbum = TagAlbumTextBox.Text;
			if(RemoveByRatingCheckBox.Checked == true)
			{
				feedItem.CleanRating = RatingComboBox.Text.Length;
			} 
			else 
			{
				feedItem.CleanRating = 0;
			}
            feedItem.RemovePlayed = KeepUnplayedCheckBox.Checked;

			if(this.LoginCheckBox.Checked == true)
			{
                feedItem.Authenticate = true;
				feedItem.Username = UsernameTextBox.Text;
				if(PasswordTextBox.Text != "")
				{
					string strEncryptedPassword = EncDec.Encrypt(PasswordTextBox.Text, UsernameTextBox.Text);
					feedItem.Password = strEncryptedPassword;
				} 
				else 
				{
					feedItem.Password = "";
				}
			} 
			else 
			{
                feedItem.Authenticate = false;
			}
			if(NameTextBox.Text.Trim() == "" || NameTextBox.Text == FormStrings.LeaveEmptyToExtractNameFromTheFeed)
			{
				// new feed, or an empty feed title
                try 
                {
                    Rss.RssFeed feed = Utils.GetFeed(feedItem);
				
				    if(feed.Exceptions.Count == 0)
                    {
                        
						char[] trimChars = new char[4];
						trimChars[0] = ' ';
						trimChars[1] = '\n';
						trimChars[2] = '\r';
						trimChars[3] = '\t';
						string strTitle = feed.Channels[0].Title.Trim(trimChars);
						int intCounter = 1;
						while(IsTitleUnique(strTitle,feedItem.GUID) == false)
						{
							strTitle = feed.Channels[0].Title.Trim(trimChars) + " (" + intCounter.ToString() +")";
							intCounter++;
						}
						feedItem.Title = feed.Channels[0].Title.Trim(trimChars);
                        feedItem.FeedHashCode = feed.GetHashCode().ToString("X");
                        if (feed.Channels[0].Description != null)
                        {
                            feedItem.Description = feed.Channels[0].Description;
                        }
					//	feedItem.Title = feed.Title.Trim(trimChars);
					}
					else
					{
                        if (Settings.Default.LogLevel > 0) log.Error("Add feed", feed.Exceptions.LastException);
						feedItem.Title = "-" + FormStrings.Unknown +"-";
					}
				}
                catch (Exception) { feedItem.Title = "-" + FormStrings.Unknown + "-"; }	
			} 
			else 
			{
				string strTitle = NameTextBox.Text;
				int intCounter = 1;
				while(IsTitleUnique(strTitle,feedItem.GUID) == false)
				{
					strTitle = NameTextBox.Text + " (" + intCounter.ToString() +")";
					intCounter++;
				}
				feedItem.Title = strTitle;
			}
			if(PlaylistTextBox.Text == FormStrings.LeaveEmptyToUseFeedName)
			{
				feedItem.PlaylistName = "";
			} 
			else 
			{
				feedItem.PlaylistName = PlaylistTextBox.Text;
			}
			if(feedItem.Pubdate == "")
			{
				feedItem.Pubdate = "-new-";
            }
            if (Settings.Default.Feeds == null)
            {
                Settings.Default.Feeds = new FeedList();
            }
            feedItem.Visible = true;
           
            if (AddFeedButton.Text == FormStrings.Addfeed)
            {
                feedItem.IsChecked = true;     
                Settings.Default.Feeds.Add(feedItem);
            }
            else
            {
                Settings.Default.Feeds[feedItem.GUID] = feedItem;
            }
            
            Settings.Default.Save();
		}

		private void checkExternalTool_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

        private void DownloadsFolderCheckBox_Click(object sender, EventArgs e)
        {
            
        }

        private void DownloadsFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!DownloadsFolderCheckBox.Checked)
            {
                DownloadsFolderTextBox.Enabled = false;
                DownloadsFolderButton.Enabled = false;
            }
            else
            {
                DownloadsFolderTextBox.Enabled = true;
                DownloadsFolderButton.Enabled = true;
            }
        }

        private void DownloadsFolderButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DownloadsFolderTextBox.Text))
            {
                folderBrowserDialog1.SelectedPath = DownloadsFolderTextBox.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DownloadsFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
            folderBrowserDialog1.Dispose();
        }

        private void DownloadsFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(DownloadsFolderTextBox.Text))
            {
                DownloadsFolderTextBox.BackColor = Color.White;
                AddFeedButton.Enabled = true;
            }
            else
            {
                DownloadsFolderTextBox.BackColor = Color.Yellow;
                AddFeedButton.Enabled = false;
            }
        }

        private void CancelFeedButton_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void ClearCacheButton_Click(object sender, EventArgs e)
        {
            if (feedItem.FeedHashCode != "" && File.Exists(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".bin"))
            {
                try
                {
                    feedItem.FeedHashCode = null;
                    File.Delete(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".bin");
                    try { 
                        File.Delete(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".jpg"); 
                    }
                    catch { }
                    try
                    {
                        File.Delete(Utils.DataFolder + "\\" + feedItem.FeedHashCode + ".ico");
                    }
                    catch { }
                    CacheFileLocationTextBox.Text = "No cache file";
                    CacheFileDateTextBox.Text = "";
                    CacheFileSizeTextBox.Text = "";
                    ClearCacheButton.Enabled = false;
                }
                catch (Exception)
                { }
            }
        }

	}
}
