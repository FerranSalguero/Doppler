using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography;
using Doppler.Properties;
using Doppler.languages;

namespace Doppler
{
	public class OptionsForm : System.Windows.Forms.Form
	{

		private string strOldLocation;
		private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private IContainer components;
        private TabPage tabAdvanced;
        private GroupBox groupBox5;
        private Label label2;
        private NumericUpDown numericMaxThreads;
        private GroupBox groupBox3;
        private RadioButton radioDupDateTime;
        private Label label12;
        private RadioButton radioDupSkip;
        private GroupBox groupBox2;
        private Label labelLogMessage;
        private Button buttonOpenLog;
        private RadioButton radioLogLevelAll;
        private RadioButton radioLogLevelErrors;
        private CheckBox checkLog;
        private TabPage tabDirectories;
        private Button DeleteDirectoryButton;
        private Button AddDirectoryButton;
        private ListView DirectoriesListView;
        private ColumnHeader columnName;
        private ColumnHeader columnURL;
        private Label label18;
        private TabPage tabDefaultFeedSettings;
        private TabControl tabControl2;
        private TabPage tabFeedMain;
        private Label label13;
        private TextBox PlaylistTextBox;
        private TabPage tabFeedFilters;
        private Label label9;
        public TextBox textFilter;
        private Label label14;
        private TabPage tabFeedTags;
        private Label label19;
        private TextBox TagTitleTextBox;
        private Panel panel1;
        private Label label11;
        private Label label17;
        private TextBox TagArtistTextBox;
        private Label labelArtist;
        private TextBox TagAlbumTextBox;
        private Label label10;
        private Label label15;
        private Label label16;
        private TextBox TagGenreTextBox;
        private Label label5;
        private TabPage tabFileTypes;
        private TabPage tabScheduling;
        private GroupBox groupBox1;
        private DateTimePicker Check3DateTimePicker;
        private DateTimePicker Check2DateTimePicker;
        private DateTimePicker Check1DateTimePicker;
        private RadioButton CheckSpecificRadioButton;
        private RadioButton CheckIntervalRadioButton;
        private ComboBox CheckIntervalComboBox;
        private CheckBox ScheduleRetrieveCheckBox;
        private TabPage tabMain;
        private Button CheckForUpdateNowButton;
        private Label LastCheckedLabel;
        private Label label23;
        private CheckBox CheckForUpdatesCheckBoxUpdate;
        private Button SelectFolderButton;
        private TextBox DownloadsFolderTextBox;
        private Label label1;
        private CheckBox MinimizeToSystemTrayCheckBox;
        private CheckBox PopupNotificationCheckBox;
        private CheckBox MinimizeOnCloseCheckBox;
        private CheckBox StartMinimizedCheckBox;
        private TabControl tabControl1;
        private GroupBox VideoGroupBox;
        private GroupBox AudioGroupBox;
        private RadioButton AudioNothingRadioButton;
        private RadioButton AudioCustomRadioButton;
        private RadioButton AudioWMPRadioButton;
        private RadioButton AudioItunesRadioButton;
        private RadioButton VideoNothingRadioButton;
        private RadioButton VideoCustomRadioButton;
        private RadioButton VideoWMPRadioButton;
        private RadioButton VideoItunesRadioButton;
        private Button AudioAdvancedButton;
        private Button VideoCustomApplicationButton;
        private TextBox VideoCustomApplicationTextBox;
        private Button AudioCustomApplicationButton;
        private TextBox AudioCustomApplicationTextBox;
        private OpenFileDialog openFileDialog1;
        private Button VideoAdvancedButton;
        private CheckBox ShowFavIconsCheckBox;
        private CheckBox ConvertToBookmarkableCheckBox;
        private TabPage tabFeedSpaceSavers;
        private GroupBox AdditionalSpaceSaversGroupBox;
        private Label labelMB;
        public NumericUpDown RestrictBySizeNumeric;
        private Label labelTotalSize;
        private RadioButton RestrictBySizeRadioButton;
        private CheckBox SpaceSaversCheckBox;
        private GroupBox DefaultSpaceSaversGroupBox;
        private Label label6;
        public NumericUpDown numericMaxMB;
        public CheckBox RetrieveMaximumMBCheckBox;
        private Label label7;
        public NumericUpDown numericLastPosts;
        public CheckBox RetrieveOnlyLastCheckBox;
        private CheckBox checkKeepUnplayed;
        private ComboBox comboRating;
        private CheckBox RemoveByRatingCheckBox;
        private Label labelRestrictDaysDays;
        private Label labelRestrictDays;
        public NumericUpDown RestrictByDaysNumeric;
        private RadioButton RestrictByDaysRadioButton;
        public NumericUpDown RestrictByFilesNumeric;
        private Label labelMaximumFiles;
        private RadioButton RestrictByFilesRadioButton;
        private Label label3;
        private CheckBox checkBox1;
        private RadioButton AudioM3URadioButton;
        private RadioButton VideoM3URadioButton;
        private Button ClearCacheButton;
        private RadioButton MediaPlayerAutomaticRadioButton;
        private RadioButton MediaPlayerManualRadioButton;
        private Label label8;
        private Label FileTypeLabel;
        private Label IntroLabel;
        private Label FileAssociationLabel;
        private GroupBox groupBox4;
        private CheckBox ConfirmDeleteCheckBox;
		private HelpProvider helpProvider1;
		//public Settings set;
		public OptionsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeSettings();
		}

		/// <summary>
		/// When opened the options dialog will show the selected tab
		/// </summary>
		/// <param name="selectedTab"></param>
		public OptionsForm(string selectedTab)
		{
			InitializeComponent();
			InitializeSettings();
			tabControl1.SelectedTab = tabControl1.TabPages[selectedTab];
		}

		private void InitializeSettings()
		{
			Check1DateTimePicker.Checked = Settings.Default.CheckHour1Enabled;
			Check2DateTimePicker.Checked = Settings.Default.CheckHour2Enabled;
			Check3DateTimePicker.Checked = Settings.Default.CheckHour3Enabled;

			ArrayList scheduleIntervals = new ArrayList();
			scheduleIntervals.Add(new ScheduleInterval("12 " + FormStrings.hours, 960));
			scheduleIntervals.Add(new ScheduleInterval("8 " + FormStrings.hours, 480));
			scheduleIntervals.Add(new ScheduleInterval("4 " + FormStrings.hours, 240));
			scheduleIntervals.Add(new ScheduleInterval("2 " + FormStrings.hours, 120));
			scheduleIntervals.Add(new ScheduleInterval("60 " + FormStrings.minutes, 60));
			//scheduleIntervals.Add(new ScheduleInterval("45 " + FormStrings.minutes, 45));
			scheduleIntervals.Add(new ScheduleInterval("30 " + FormStrings.minutes, 30));
			CheckIntervalComboBox.DataSource = scheduleIntervals;
			CheckIntervalComboBox.DisplayMember = "Name";
			CheckIntervalComboBox.ValueMember = "Minutes";
			CheckIntervalComboBox.SelectedValue = Settings.Default.IntervalMinutes;
			//dataGridExtensions.DataSource = Settings.Default.Extensions;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.OKButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ConfirmDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearCacheButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericMaxThreads = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioDupDateTime = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.radioDupSkip = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelLogMessage = new System.Windows.Forms.Label();
            this.buttonOpenLog = new System.Windows.Forms.Button();
            this.radioLogLevelAll = new System.Windows.Forms.RadioButton();
            this.radioLogLevelErrors = new System.Windows.Forms.RadioButton();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.tabDirectories = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.DeleteDirectoryButton = new System.Windows.Forms.Button();
            this.AddDirectoryButton = new System.Windows.Forms.Button();
            this.DirectoriesListView = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnURL = new System.Windows.Forms.ColumnHeader();
            this.label18 = new System.Windows.Forms.Label();
            this.tabDefaultFeedSettings = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFeedMain = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.PlaylistTextBox = new System.Windows.Forms.TextBox();
            this.tabFeedSpaceSavers = new System.Windows.Forms.TabPage();
            this.DefaultSpaceSaversGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericMaxMB = new System.Windows.Forms.NumericUpDown();
            this.RetrieveMaximumMBCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericLastPosts = new System.Windows.Forms.NumericUpDown();
            this.RetrieveOnlyLastCheckBox = new System.Windows.Forms.CheckBox();
            this.checkKeepUnplayed = new System.Windows.Forms.CheckBox();
            this.comboRating = new System.Windows.Forms.ComboBox();
            this.RemoveByRatingCheckBox = new System.Windows.Forms.CheckBox();
            this.AdditionalSpaceSaversGroupBox = new System.Windows.Forms.GroupBox();
            this.labelRestrictDaysDays = new System.Windows.Forms.Label();
            this.labelRestrictDays = new System.Windows.Forms.Label();
            this.RestrictByDaysNumeric = new System.Windows.Forms.NumericUpDown();
            this.RestrictByDaysRadioButton = new System.Windows.Forms.RadioButton();
            this.RestrictByFilesNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelMaximumFiles = new System.Windows.Forms.Label();
            this.RestrictByFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.labelMB = new System.Windows.Forms.Label();
            this.RestrictBySizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelTotalSize = new System.Windows.Forms.Label();
            this.RestrictBySizeRadioButton = new System.Windows.Forms.RadioButton();
            this.SpaceSaversCheckBox = new System.Windows.Forms.CheckBox();
            this.tabFeedTags = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.TagTitleTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TagArtistTextBox = new System.Windows.Forms.TextBox();
            this.labelArtist = new System.Windows.Forms.Label();
            this.TagAlbumTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TagGenreTextBox = new System.Windows.Forms.TextBox();
            this.tabFeedFilters = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabFileTypes = new System.Windows.Forms.TabPage();
            this.FileAssociationLabel = new System.Windows.Forms.Label();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.IntroLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MediaPlayerManualRadioButton = new System.Windows.Forms.RadioButton();
            this.MediaPlayerAutomaticRadioButton = new System.Windows.Forms.RadioButton();
            this.VideoGroupBox = new System.Windows.Forms.GroupBox();
            this.VideoM3URadioButton = new System.Windows.Forms.RadioButton();
            this.VideoAdvancedButton = new System.Windows.Forms.Button();
            this.VideoCustomApplicationButton = new System.Windows.Forms.Button();
            this.VideoCustomApplicationTextBox = new System.Windows.Forms.TextBox();
            this.VideoNothingRadioButton = new System.Windows.Forms.RadioButton();
            this.VideoCustomRadioButton = new System.Windows.Forms.RadioButton();
            this.VideoWMPRadioButton = new System.Windows.Forms.RadioButton();
            this.VideoItunesRadioButton = new System.Windows.Forms.RadioButton();
            this.AudioGroupBox = new System.Windows.Forms.GroupBox();
            this.AudioM3URadioButton = new System.Windows.Forms.RadioButton();
            this.ConvertToBookmarkableCheckBox = new System.Windows.Forms.CheckBox();
            this.AudioCustomApplicationButton = new System.Windows.Forms.Button();
            this.AudioCustomApplicationTextBox = new System.Windows.Forms.TextBox();
            this.AudioAdvancedButton = new System.Windows.Forms.Button();
            this.AudioNothingRadioButton = new System.Windows.Forms.RadioButton();
            this.AudioCustomRadioButton = new System.Windows.Forms.RadioButton();
            this.AudioWMPRadioButton = new System.Windows.Forms.RadioButton();
            this.AudioItunesRadioButton = new System.Windows.Forms.RadioButton();
            this.tabScheduling = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Check3DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Check2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Check1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CheckSpecificRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckIntervalRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.ScheduleRetrieveCheckBox = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ShowFavIconsCheckBox = new System.Windows.Forms.CheckBox();
            this.CheckForUpdateNowButton = new System.Windows.Forms.Button();
            this.LastCheckedLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.CheckForUpdatesCheckBoxUpdate = new System.Windows.Forms.CheckBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.DownloadsFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MinimizeToSystemTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.PopupNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.StartMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabAdvanced.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxThreads)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDirectories.SuspendLayout();
            this.tabDefaultFeedSettings.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabFeedMain.SuspendLayout();
            this.tabFeedSpaceSavers.SuspendLayout();
            this.DefaultSpaceSaversGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLastPosts)).BeginInit();
            this.AdditionalSpaceSaversGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictByDaysNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictByFilesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictBySizeNumeric)).BeginInit();
            this.tabFeedTags.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabFeedFilters.SuspendLayout();
            this.tabFileTypes.SuspendLayout();
            this.VideoGroupBox.SuspendLayout();
            this.AudioGroupBox.SuspendLayout();
            this.tabScheduling.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.SystemColors.Control;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.helpProvider1.SetShowHelp(this.OKButton, ((bool)(resources.GetObject("OKButton.ShowHelp"))));
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.helpProvider1.SetShowHelp(this.buttonCancel, ((bool)(resources.GetObject("buttonCancel.ShowHelp"))));
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.tabAdvanced.Controls.Add(this.groupBox4);
            this.tabAdvanced.Controls.Add(this.groupBox5);
            this.tabAdvanced.Controls.Add(this.groupBox3);
            this.tabAdvanced.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabAdvanced, "tabAdvanced");
            this.tabAdvanced.Name = "tabAdvanced";
            this.helpProvider1.SetShowHelp(this.tabAdvanced, ((bool)(resources.GetObject("tabAdvanced.ShowHelp"))));
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ConfirmDeleteCheckBox);
            this.groupBox4.Controls.Add(this.ClearCacheButton);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.helpProvider1.SetShowHelp(this.groupBox4, ((bool)(resources.GetObject("groupBox4.ShowHelp"))));
            this.groupBox4.TabStop = false;
            // 
            // ConfirmDeleteCheckBox
            // 
            resources.ApplyResources(this.ConfirmDeleteCheckBox, "ConfirmDeleteCheckBox");
            this.ConfirmDeleteCheckBox.Name = "ConfirmDeleteCheckBox";
            this.helpProvider1.SetShowHelp(this.ConfirmDeleteCheckBox, ((bool)(resources.GetObject("ConfirmDeleteCheckBox.ShowHelp"))));
            this.ConfirmDeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearCacheButton
            // 
            resources.ApplyResources(this.ClearCacheButton, "ClearCacheButton");
            this.ClearCacheButton.Name = "ClearCacheButton";
            this.helpProvider1.SetShowHelp(this.ClearCacheButton, ((bool)(resources.GetObject("ClearCacheButton.ShowHelp"))));
            this.ClearCacheButton.UseVisualStyleBackColor = true;
            this.ClearCacheButton.Click += new System.EventHandler(this.ClearCacheButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.numericMaxThreads);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.helpProvider1.SetShowHelp(this.groupBox5, ((bool)(resources.GetObject("groupBox5.ShowHelp"))));
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // numericMaxThreads
            // 
            resources.ApplyResources(this.numericMaxThreads, "numericMaxThreads");
            this.numericMaxThreads.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMaxThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxThreads.Name = "numericMaxThreads";
            this.helpProvider1.SetShowHelp(this.numericMaxThreads, ((bool)(resources.GetObject("numericMaxThreads.ShowHelp"))));
            this.numericMaxThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.radioDupDateTime);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.radioDupSkip);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.helpProvider1.SetShowHelp(this.groupBox3, ((bool)(resources.GetObject("groupBox3.ShowHelp"))));
            this.groupBox3.TabStop = false;
            // 
            // radioDupDateTime
            // 
            resources.ApplyResources(this.radioDupDateTime, "radioDupDateTime");
            this.radioDupDateTime.BackColor = System.Drawing.Color.Transparent;
            this.radioDupDateTime.Name = "radioDupDateTime";
            this.helpProvider1.SetShowHelp(this.radioDupDateTime, ((bool)(resources.GetObject("radioDupDateTime.ShowHelp"))));
            this.radioDupDateTime.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.helpProvider1.SetShowHelp(this.label12, ((bool)(resources.GetObject("label12.ShowHelp"))));
            // 
            // radioDupSkip
            // 
            resources.ApplyResources(this.radioDupSkip, "radioDupSkip");
            this.radioDupSkip.BackColor = System.Drawing.Color.Transparent;
            this.radioDupSkip.Checked = true;
            this.radioDupSkip.Name = "radioDupSkip";
            this.helpProvider1.SetShowHelp(this.radioDupSkip, ((bool)(resources.GetObject("radioDupSkip.ShowHelp"))));
            this.radioDupSkip.TabStop = true;
            this.radioDupSkip.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.labelLogMessage);
            this.groupBox2.Controls.Add(this.buttonOpenLog);
            this.groupBox2.Controls.Add(this.radioLogLevelAll);
            this.groupBox2.Controls.Add(this.radioLogLevelErrors);
            this.groupBox2.Controls.Add(this.checkLog);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.helpProvider1.SetShowHelp(this.groupBox2, ((bool)(resources.GetObject("groupBox2.ShowHelp"))));
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // labelLogMessage
            // 
            resources.ApplyResources(this.labelLogMessage, "labelLogMessage");
            this.labelLogMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelLogMessage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelLogMessage.Name = "labelLogMessage";
            this.helpProvider1.SetShowHelp(this.labelLogMessage, ((bool)(resources.GetObject("labelLogMessage.ShowHelp"))));
            // 
            // buttonOpenLog
            // 
            resources.ApplyResources(this.buttonOpenLog, "buttonOpenLog");
            this.buttonOpenLog.Name = "buttonOpenLog";
            this.helpProvider1.SetShowHelp(this.buttonOpenLog, ((bool)(resources.GetObject("buttonOpenLog.ShowHelp"))));
            this.buttonOpenLog.Click += new System.EventHandler(this.buttonOpenLog_Click);
            // 
            // radioLogLevelAll
            // 
            resources.ApplyResources(this.radioLogLevelAll, "radioLogLevelAll");
            this.radioLogLevelAll.BackColor = System.Drawing.Color.Transparent;
            this.radioLogLevelAll.Name = "radioLogLevelAll";
            this.helpProvider1.SetShowHelp(this.radioLogLevelAll, ((bool)(resources.GetObject("radioLogLevelAll.ShowHelp"))));
            this.radioLogLevelAll.UseVisualStyleBackColor = false;
            // 
            // radioLogLevelErrors
            // 
            resources.ApplyResources(this.radioLogLevelErrors, "radioLogLevelErrors");
            this.radioLogLevelErrors.BackColor = System.Drawing.Color.Transparent;
            this.radioLogLevelErrors.Checked = true;
            this.radioLogLevelErrors.Name = "radioLogLevelErrors";
            this.helpProvider1.SetShowHelp(this.radioLogLevelErrors, ((bool)(resources.GetObject("radioLogLevelErrors.ShowHelp"))));
            this.radioLogLevelErrors.TabStop = true;
            this.radioLogLevelErrors.UseVisualStyleBackColor = false;
            // 
            // checkLog
            // 
            resources.ApplyResources(this.checkLog, "checkLog");
            this.checkLog.BackColor = System.Drawing.Color.Transparent;
            this.checkLog.Name = "checkLog";
            this.helpProvider1.SetShowHelp(this.checkLog, ((bool)(resources.GetObject("checkLog.ShowHelp"))));
            this.checkLog.UseVisualStyleBackColor = false;
            this.checkLog.CheckedChanged += new System.EventHandler(this.checkLog_CheckedChanged);
            // 
            // tabDirectories
            // 
            this.tabDirectories.BackColor = System.Drawing.SystemColors.Control;
            this.tabDirectories.Controls.Add(this.label3);
            this.tabDirectories.Controls.Add(this.DeleteDirectoryButton);
            this.tabDirectories.Controls.Add(this.AddDirectoryButton);
            this.tabDirectories.Controls.Add(this.DirectoriesListView);
            this.tabDirectories.Controls.Add(this.label18);
            resources.ApplyResources(this.tabDirectories, "tabDirectories");
            this.tabDirectories.Name = "tabDirectories";
            this.helpProvider1.SetShowHelp(this.tabDirectories, ((bool)(resources.GetObject("tabDirectories.ShowHelp"))));
            this.tabDirectories.Click += new System.EventHandler(this.tabDirectories_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // DeleteDirectoryButton
            // 
            resources.ApplyResources(this.DeleteDirectoryButton, "DeleteDirectoryButton");
            this.DeleteDirectoryButton.Name = "DeleteDirectoryButton";
            this.helpProvider1.SetShowHelp(this.DeleteDirectoryButton, ((bool)(resources.GetObject("DeleteDirectoryButton.ShowHelp"))));
            this.DeleteDirectoryButton.Click += new System.EventHandler(this.DeleteDirectoryButton_Click);
            // 
            // AddDirectoryButton
            // 
            resources.ApplyResources(this.AddDirectoryButton, "AddDirectoryButton");
            this.AddDirectoryButton.Name = "AddDirectoryButton";
            this.helpProvider1.SetShowHelp(this.AddDirectoryButton, ((bool)(resources.GetObject("AddDirectoryButton.ShowHelp"))));
            this.AddDirectoryButton.Click += new System.EventHandler(this.buttonNewDirectory_Click);
            // 
            // DirectoriesListView
            // 
            this.DirectoriesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnURL});
            this.DirectoriesListView.FullRowSelect = true;
            resources.ApplyResources(this.DirectoriesListView, "DirectoriesListView");
            this.DirectoriesListView.Name = "DirectoriesListView";
            this.helpProvider1.SetShowHelp(this.DirectoriesListView, ((bool)(resources.GetObject("DirectoriesListView.ShowHelp"))));
            this.DirectoriesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DirectoriesListView.UseCompatibleStateImageBehavior = false;
            this.DirectoriesListView.View = System.Windows.Forms.View.Details;
            this.DirectoriesListView.DoubleClick += new System.EventHandler(this.listDirectories_DoubleClick);
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            // 
            // columnURL
            // 
            resources.ApplyResources(this.columnURL, "columnURL");
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            this.helpProvider1.SetShowHelp(this.label18, ((bool)(resources.GetObject("label18.ShowHelp"))));
            // 
            // tabDefaultFeedSettings
            // 
            this.tabDefaultFeedSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tabDefaultFeedSettings.Controls.Add(this.tabControl2);
            this.tabDefaultFeedSettings.Controls.Add(this.label5);
            resources.ApplyResources(this.tabDefaultFeedSettings, "tabDefaultFeedSettings");
            this.tabDefaultFeedSettings.Name = "tabDefaultFeedSettings";
            this.helpProvider1.SetShowHelp(this.tabDefaultFeedSettings, ((bool)(resources.GetObject("tabDefaultFeedSettings.ShowHelp"))));
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabFeedMain);
            this.tabControl2.Controls.Add(this.tabFeedSpaceSavers);
            this.tabControl2.Controls.Add(this.tabFeedTags);
            this.tabControl2.Controls.Add(this.tabFeedFilters);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.helpProvider1.SetShowHelp(this.tabControl2, ((bool)(resources.GetObject("tabControl2.ShowHelp"))));
            // 
            // tabFeedMain
            // 
            this.tabFeedMain.BackColor = System.Drawing.SystemColors.Control;
            this.tabFeedMain.Controls.Add(this.label13);
            this.tabFeedMain.Controls.Add(this.PlaylistTextBox);
            resources.ApplyResources(this.tabFeedMain, "tabFeedMain");
            this.tabFeedMain.Name = "tabFeedMain";
            this.helpProvider1.SetShowHelp(this.tabFeedMain, ((bool)(resources.GetObject("tabFeedMain.ShowHelp"))));
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.helpProvider1.SetShowHelp(this.label13, ((bool)(resources.GetObject("label13.ShowHelp"))));
            // 
            // PlaylistTextBox
            // 
            resources.ApplyResources(this.PlaylistTextBox, "PlaylistTextBox");
            this.PlaylistTextBox.Name = "PlaylistTextBox";
            this.helpProvider1.SetShowHelp(this.PlaylistTextBox, ((bool)(resources.GetObject("PlaylistTextBox.ShowHelp"))));
            this.PlaylistTextBox.Enter += new System.EventHandler(this.textPlaylist_Enter);
            this.PlaylistTextBox.Leave += new System.EventHandler(this.textPlaylist_Leave);
            // 
            // tabFeedSpaceSavers
            // 
            this.tabFeedSpaceSavers.BackColor = System.Drawing.SystemColors.Control;
            this.tabFeedSpaceSavers.Controls.Add(this.DefaultSpaceSaversGroupBox);
            this.tabFeedSpaceSavers.Controls.Add(this.AdditionalSpaceSaversGroupBox);
            this.tabFeedSpaceSavers.Controls.Add(this.SpaceSaversCheckBox);
            resources.ApplyResources(this.tabFeedSpaceSavers, "tabFeedSpaceSavers");
            this.tabFeedSpaceSavers.Name = "tabFeedSpaceSavers";
            this.helpProvider1.SetShowHelp(this.tabFeedSpaceSavers, ((bool)(resources.GetObject("tabFeedSpaceSavers.ShowHelp"))));
            this.tabFeedSpaceSavers.Click += new System.EventHandler(this.tabSpaceSavers_Click);
            // 
            // DefaultSpaceSaversGroupBox
            // 
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.label6);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.numericMaxMB);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.RetrieveMaximumMBCheckBox);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.label7);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.numericLastPosts);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.RetrieveOnlyLastCheckBox);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.checkKeepUnplayed);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.comboRating);
            this.DefaultSpaceSaversGroupBox.Controls.Add(this.RemoveByRatingCheckBox);
            resources.ApplyResources(this.DefaultSpaceSaversGroupBox, "DefaultSpaceSaversGroupBox");
            this.DefaultSpaceSaversGroupBox.Name = "DefaultSpaceSaversGroupBox";
            this.helpProvider1.SetShowHelp(this.DefaultSpaceSaversGroupBox, ((bool)(resources.GetObject("DefaultSpaceSaversGroupBox.ShowHelp"))));
            this.DefaultSpaceSaversGroupBox.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // numericMaxMB
            // 
            resources.ApplyResources(this.numericMaxMB, "numericMaxMB");
            this.numericMaxMB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMaxMB.Name = "numericMaxMB";
            this.helpProvider1.SetShowHelp(this.numericMaxMB, ((bool)(resources.GetObject("numericMaxMB.ShowHelp"))));
            // 
            // RetrieveMaximumMBCheckBox
            // 
            resources.ApplyResources(this.RetrieveMaximumMBCheckBox, "RetrieveMaximumMBCheckBox");
            this.RetrieveMaximumMBCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RetrieveMaximumMBCheckBox.Name = "RetrieveMaximumMBCheckBox";
            this.helpProvider1.SetShowHelp(this.RetrieveMaximumMBCheckBox, ((bool)(resources.GetObject("RetrieveMaximumMBCheckBox.ShowHelp"))));
            this.RetrieveMaximumMBCheckBox.UseVisualStyleBackColor = false;
            this.RetrieveMaximumMBCheckBox.CheckedChanged += new System.EventHandler(this.RetrieveMaximumMBCheckBox_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            this.helpProvider1.SetShowHelp(this.label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // numericLastPosts
            // 
            resources.ApplyResources(this.numericLastPosts, "numericLastPosts");
            this.numericLastPosts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLastPosts.Name = "numericLastPosts";
            this.helpProvider1.SetShowHelp(this.numericLastPosts, ((bool)(resources.GetObject("numericLastPosts.ShowHelp"))));
            this.numericLastPosts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RetrieveOnlyLastCheckBox
            // 
            resources.ApplyResources(this.RetrieveOnlyLastCheckBox, "RetrieveOnlyLastCheckBox");
            this.RetrieveOnlyLastCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RetrieveOnlyLastCheckBox.Name = "RetrieveOnlyLastCheckBox";
            this.helpProvider1.SetShowHelp(this.RetrieveOnlyLastCheckBox, ((bool)(resources.GetObject("RetrieveOnlyLastCheckBox.ShowHelp"))));
            this.RetrieveOnlyLastCheckBox.UseVisualStyleBackColor = false;
            this.RetrieveOnlyLastCheckBox.CheckedChanged += new System.EventHandler(this.RetrieveOnlyLastCheckBox_CheckedChanged);
            // 
            // checkKeepUnplayed
            // 
            resources.ApplyResources(this.checkKeepUnplayed, "checkKeepUnplayed");
            this.checkKeepUnplayed.Name = "checkKeepUnplayed";
            this.helpProvider1.SetShowHelp(this.checkKeepUnplayed, ((bool)(resources.GetObject("checkKeepUnplayed.ShowHelp"))));
            this.checkKeepUnplayed.UseVisualStyleBackColor = true;
            // 
            // comboRating
            // 
            this.comboRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboRating, "comboRating");
            this.comboRating.FormattingEnabled = true;
            this.comboRating.Items.AddRange(new object[] {
            resources.GetString("comboRating.Items"),
            resources.GetString("comboRating.Items1"),
            resources.GetString("comboRating.Items2"),
            resources.GetString("comboRating.Items3"),
            resources.GetString("comboRating.Items4")});
            this.comboRating.Name = "comboRating";
            this.helpProvider1.SetShowHelp(this.comboRating, ((bool)(resources.GetObject("comboRating.ShowHelp"))));
            // 
            // RemoveByRatingCheckBox
            // 
            this.RemoveByRatingCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.RemoveByRatingCheckBox, "RemoveByRatingCheckBox");
            this.RemoveByRatingCheckBox.Name = "RemoveByRatingCheckBox";
            this.helpProvider1.SetShowHelp(this.RemoveByRatingCheckBox, ((bool)(resources.GetObject("RemoveByRatingCheckBox.ShowHelp"))));
            this.RemoveByRatingCheckBox.UseVisualStyleBackColor = false;
            this.RemoveByRatingCheckBox.CheckedChanged += new System.EventHandler(this.RemoveByRatingCheckBox_CheckedChanged);
            // 
            // AdditionalSpaceSaversGroupBox
            // 
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.labelRestrictDaysDays);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.labelRestrictDays);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictByDaysNumeric);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictByDaysRadioButton);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictByFilesNumeric);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.labelMaximumFiles);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictByFilesRadioButton);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.labelMB);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictBySizeNumeric);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.labelTotalSize);
            this.AdditionalSpaceSaversGroupBox.Controls.Add(this.RestrictBySizeRadioButton);
            resources.ApplyResources(this.AdditionalSpaceSaversGroupBox, "AdditionalSpaceSaversGroupBox");
            this.AdditionalSpaceSaversGroupBox.Name = "AdditionalSpaceSaversGroupBox";
            this.helpProvider1.SetShowHelp(this.AdditionalSpaceSaversGroupBox, ((bool)(resources.GetObject("AdditionalSpaceSaversGroupBox.ShowHelp"))));
            this.AdditionalSpaceSaversGroupBox.TabStop = false;
            this.AdditionalSpaceSaversGroupBox.EnabledChanged += new System.EventHandler(this.AdditionalSpaceSaversGroupBox_EnabledChanged);
            // 
            // labelRestrictDaysDays
            // 
            resources.ApplyResources(this.labelRestrictDaysDays, "labelRestrictDaysDays");
            this.labelRestrictDaysDays.BackColor = System.Drawing.Color.Transparent;
            this.labelRestrictDaysDays.Name = "labelRestrictDaysDays";
            this.helpProvider1.SetShowHelp(this.labelRestrictDaysDays, ((bool)(resources.GetObject("labelRestrictDaysDays.ShowHelp"))));
            // 
            // labelRestrictDays
            // 
            resources.ApplyResources(this.labelRestrictDays, "labelRestrictDays");
            this.labelRestrictDays.BackColor = System.Drawing.Color.Transparent;
            this.labelRestrictDays.Name = "labelRestrictDays";
            this.helpProvider1.SetShowHelp(this.labelRestrictDays, ((bool)(resources.GetObject("labelRestrictDays.ShowHelp"))));
            // 
            // RestrictByDaysNumeric
            // 
            resources.ApplyResources(this.RestrictByDaysNumeric, "RestrictByDaysNumeric");
            this.RestrictByDaysNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RestrictByDaysNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RestrictByDaysNumeric.Name = "RestrictByDaysNumeric";
            this.helpProvider1.SetShowHelp(this.RestrictByDaysNumeric, ((bool)(resources.GetObject("RestrictByDaysNumeric.ShowHelp"))));
            this.RestrictByDaysNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RestrictByDaysRadioButton
            // 
            resources.ApplyResources(this.RestrictByDaysRadioButton, "RestrictByDaysRadioButton");
            this.RestrictByDaysRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictByDaysRadioButton.Name = "RestrictByDaysRadioButton";
            this.helpProvider1.SetShowHelp(this.RestrictByDaysRadioButton, ((bool)(resources.GetObject("RestrictByDaysRadioButton.ShowHelp"))));
            this.RestrictByDaysRadioButton.UseVisualStyleBackColor = false;
            // 
            // RestrictByFilesNumeric
            // 
            resources.ApplyResources(this.RestrictByFilesNumeric, "RestrictByFilesNumeric");
            this.RestrictByFilesNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RestrictByFilesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RestrictByFilesNumeric.Name = "RestrictByFilesNumeric";
            this.helpProvider1.SetShowHelp(this.RestrictByFilesNumeric, ((bool)(resources.GetObject("RestrictByFilesNumeric.ShowHelp"))));
            this.RestrictByFilesNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelMaximumFiles
            // 
            resources.ApplyResources(this.labelMaximumFiles, "labelMaximumFiles");
            this.labelMaximumFiles.BackColor = System.Drawing.Color.Transparent;
            this.labelMaximumFiles.Name = "labelMaximumFiles";
            this.helpProvider1.SetShowHelp(this.labelMaximumFiles, ((bool)(resources.GetObject("labelMaximumFiles.ShowHelp"))));
            // 
            // RestrictByFilesRadioButton
            // 
            resources.ApplyResources(this.RestrictByFilesRadioButton, "RestrictByFilesRadioButton");
            this.RestrictByFilesRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictByFilesRadioButton.Name = "RestrictByFilesRadioButton";
            this.helpProvider1.SetShowHelp(this.RestrictByFilesRadioButton, ((bool)(resources.GetObject("RestrictByFilesRadioButton.ShowHelp"))));
            this.RestrictByFilesRadioButton.UseVisualStyleBackColor = false;
            // 
            // labelMB
            // 
            resources.ApplyResources(this.labelMB, "labelMB");
            this.labelMB.BackColor = System.Drawing.Color.Transparent;
            this.labelMB.Name = "labelMB";
            this.helpProvider1.SetShowHelp(this.labelMB, ((bool)(resources.GetObject("labelMB.ShowHelp"))));
            // 
            // RestrictBySizeNumeric
            // 
            resources.ApplyResources(this.RestrictBySizeNumeric, "RestrictBySizeNumeric");
            this.RestrictBySizeNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RestrictBySizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RestrictBySizeNumeric.Name = "RestrictBySizeNumeric";
            this.helpProvider1.SetShowHelp(this.RestrictBySizeNumeric, ((bool)(resources.GetObject("RestrictBySizeNumeric.ShowHelp"))));
            this.RestrictBySizeNumeric.Value = new decimal(new int[] {
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
            this.helpProvider1.SetShowHelp(this.labelTotalSize, ((bool)(resources.GetObject("labelTotalSize.ShowHelp"))));
            // 
            // RestrictBySizeRadioButton
            // 
            resources.ApplyResources(this.RestrictBySizeRadioButton, "RestrictBySizeRadioButton");
            this.RestrictBySizeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.RestrictBySizeRadioButton.Checked = true;
            this.RestrictBySizeRadioButton.Name = "RestrictBySizeRadioButton";
            this.helpProvider1.SetShowHelp(this.RestrictBySizeRadioButton, ((bool)(resources.GetObject("RestrictBySizeRadioButton.ShowHelp"))));
            this.RestrictBySizeRadioButton.TabStop = true;
            this.RestrictBySizeRadioButton.UseVisualStyleBackColor = false;
            // 
            // SpaceSaversCheckBox
            // 
            resources.ApplyResources(this.SpaceSaversCheckBox, "SpaceSaversCheckBox");
            this.SpaceSaversCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.SpaceSaversCheckBox.Name = "SpaceSaversCheckBox";
            this.helpProvider1.SetShowHelp(this.SpaceSaversCheckBox, ((bool)(resources.GetObject("SpaceSaversCheckBox.ShowHelp"))));
            this.SpaceSaversCheckBox.UseVisualStyleBackColor = false;
            this.SpaceSaversCheckBox.CheckedChanged += new System.EventHandler(this.SpaceSaversCheckBox_CheckedChanged);
            // 
            // tabFeedTags
            // 
            this.tabFeedTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabFeedTags.Controls.Add(this.label19);
            this.tabFeedTags.Controls.Add(this.TagTitleTextBox);
            this.tabFeedTags.Controls.Add(this.panel1);
            this.tabFeedTags.Controls.Add(this.TagArtistTextBox);
            this.tabFeedTags.Controls.Add(this.labelArtist);
            this.tabFeedTags.Controls.Add(this.TagAlbumTextBox);
            this.tabFeedTags.Controls.Add(this.label10);
            this.tabFeedTags.Controls.Add(this.label15);
            this.tabFeedTags.Controls.Add(this.label16);
            this.tabFeedTags.Controls.Add(this.TagGenreTextBox);
            resources.ApplyResources(this.tabFeedTags, "tabFeedTags");
            this.tabFeedTags.Name = "tabFeedTags";
            this.helpProvider1.SetShowHelp(this.tabFeedTags, ((bool)(resources.GetObject("tabFeedTags.ShowHelp"))));
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            this.helpProvider1.SetShowHelp(this.label19, ((bool)(resources.GetObject("label19.ShowHelp"))));
            // 
            // TagTitleTextBox
            // 
            resources.ApplyResources(this.TagTitleTextBox, "TagTitleTextBox");
            this.TagTitleTextBox.Name = "TagTitleTextBox";
            this.helpProvider1.SetShowHelp(this.TagTitleTextBox, ((bool)(resources.GetObject("TagTitleTextBox.ShowHelp"))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label17);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.helpProvider1.SetShowHelp(this.panel1, ((bool)(resources.GetObject("panel1.ShowHelp"))));
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.helpProvider1.SetShowHelp(this.label11, ((bool)(resources.GetObject("label11.ShowHelp"))));
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            this.helpProvider1.SetShowHelp(this.label17, ((bool)(resources.GetObject("label17.ShowHelp"))));
            // 
            // TagArtistTextBox
            // 
            resources.ApplyResources(this.TagArtistTextBox, "TagArtistTextBox");
            this.TagArtistTextBox.Name = "TagArtistTextBox";
            this.helpProvider1.SetShowHelp(this.TagArtistTextBox, ((bool)(resources.GetObject("TagArtistTextBox.ShowHelp"))));
            // 
            // labelArtist
            // 
            this.labelArtist.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelArtist, "labelArtist");
            this.labelArtist.Name = "labelArtist";
            this.helpProvider1.SetShowHelp(this.labelArtist, ((bool)(resources.GetObject("labelArtist.ShowHelp"))));
            // 
            // TagAlbumTextBox
            // 
            resources.ApplyResources(this.TagAlbumTextBox, "TagAlbumTextBox");
            this.TagAlbumTextBox.Name = "TagAlbumTextBox";
            this.helpProvider1.SetShowHelp(this.TagAlbumTextBox, ((bool)(resources.GetObject("TagAlbumTextBox.ShowHelp"))));
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.helpProvider1.SetShowHelp(this.label10, ((bool)(resources.GetObject("label10.ShowHelp"))));
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            this.helpProvider1.SetShowHelp(this.label15, ((bool)(resources.GetObject("label15.ShowHelp"))));
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            this.helpProvider1.SetShowHelp(this.label16, ((bool)(resources.GetObject("label16.ShowHelp"))));
            // 
            // TagGenreTextBox
            // 
            resources.ApplyResources(this.TagGenreTextBox, "TagGenreTextBox");
            this.TagGenreTextBox.Name = "TagGenreTextBox";
            this.helpProvider1.SetShowHelp(this.TagGenreTextBox, ((bool)(resources.GetObject("TagGenreTextBox.ShowHelp"))));
            // 
            // tabFeedFilters
            // 
            this.tabFeedFilters.BackColor = System.Drawing.SystemColors.Control;
            this.tabFeedFilters.Controls.Add(this.label9);
            this.tabFeedFilters.Controls.Add(this.textFilter);
            this.tabFeedFilters.Controls.Add(this.label14);
            resources.ApplyResources(this.tabFeedFilters, "tabFeedFilters");
            this.tabFeedFilters.Name = "tabFeedFilters";
            this.helpProvider1.SetShowHelp(this.tabFeedFilters, ((bool)(resources.GetObject("tabFeedFilters.ShowHelp"))));
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.DarkOrange;
            this.label9.Name = "label9";
            this.helpProvider1.SetShowHelp(this.label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            // 
            // textFilter
            // 
            resources.ApplyResources(this.textFilter, "textFilter");
            this.textFilter.Name = "textFilter";
            this.helpProvider1.SetShowHelp(this.textFilter, ((bool)(resources.GetObject("textFilter.ShowHelp"))));
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            this.helpProvider1.SetShowHelp(this.label14, ((bool)(resources.GetObject("label14.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // tabFileTypes
            // 
            this.tabFileTypes.BackColor = System.Drawing.SystemColors.Control;
            this.tabFileTypes.Controls.Add(this.FileAssociationLabel);
            this.tabFileTypes.Controls.Add(this.FileTypeLabel);
            this.tabFileTypes.Controls.Add(this.IntroLabel);
            this.tabFileTypes.Controls.Add(this.label8);
            this.tabFileTypes.Controls.Add(this.MediaPlayerManualRadioButton);
            this.tabFileTypes.Controls.Add(this.MediaPlayerAutomaticRadioButton);
            this.tabFileTypes.Controls.Add(this.VideoGroupBox);
            this.tabFileTypes.Controls.Add(this.AudioGroupBox);
            resources.ApplyResources(this.tabFileTypes, "tabFileTypes");
            this.tabFileTypes.Name = "tabFileTypes";
            this.helpProvider1.SetShowHelp(this.tabFileTypes, ((bool)(resources.GetObject("tabFileTypes.ShowHelp"))));
            // 
            // FileAssociationLabel
            // 
            resources.ApplyResources(this.FileAssociationLabel, "FileAssociationLabel");
            this.FileAssociationLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileAssociationLabel.Name = "FileAssociationLabel";
            this.helpProvider1.SetShowHelp(this.FileAssociationLabel, ((bool)(resources.GetObject("FileAssociationLabel.ShowHelp"))));
            // 
            // FileTypeLabel
            // 
            resources.ApplyResources(this.FileTypeLabel, "FileTypeLabel");
            this.FileTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.helpProvider1.SetShowHelp(this.FileTypeLabel, ((bool)(resources.GetObject("FileTypeLabel.ShowHelp"))));
            this.FileTypeLabel.Click += new System.EventHandler(this.label21_Click);
            // 
            // IntroLabel
            // 
            resources.ApplyResources(this.IntroLabel, "IntroLabel");
            this.IntroLabel.BackColor = System.Drawing.Color.Transparent;
            this.IntroLabel.Name = "IntroLabel";
            this.helpProvider1.SetShowHelp(this.IntroLabel, ((bool)(resources.GetObject("IntroLabel.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            this.helpProvider1.SetShowHelp(this.label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // MediaPlayerManualRadioButton
            // 
            resources.ApplyResources(this.MediaPlayerManualRadioButton, "MediaPlayerManualRadioButton");
            this.MediaPlayerManualRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.MediaPlayerManualRadioButton.Name = "MediaPlayerManualRadioButton";
            this.helpProvider1.SetShowHelp(this.MediaPlayerManualRadioButton, ((bool)(resources.GetObject("MediaPlayerManualRadioButton.ShowHelp"))));
            this.MediaPlayerManualRadioButton.UseVisualStyleBackColor = false;
            // 
            // MediaPlayerAutomaticRadioButton
            // 
            resources.ApplyResources(this.MediaPlayerAutomaticRadioButton, "MediaPlayerAutomaticRadioButton");
            this.MediaPlayerAutomaticRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.MediaPlayerAutomaticRadioButton.Checked = true;
            this.MediaPlayerAutomaticRadioButton.Name = "MediaPlayerAutomaticRadioButton";
            this.helpProvider1.SetShowHelp(this.MediaPlayerAutomaticRadioButton, ((bool)(resources.GetObject("MediaPlayerAutomaticRadioButton.ShowHelp"))));
            this.MediaPlayerAutomaticRadioButton.TabStop = true;
            this.MediaPlayerAutomaticRadioButton.UseVisualStyleBackColor = false;
            this.MediaPlayerAutomaticRadioButton.CheckedChanged += new System.EventHandler(this.MediaPlayerAutomaticRadioButton_CheckedChanged);
            // 
            // VideoGroupBox
            // 
            this.VideoGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.VideoGroupBox.Controls.Add(this.VideoM3URadioButton);
            this.VideoGroupBox.Controls.Add(this.VideoAdvancedButton);
            this.VideoGroupBox.Controls.Add(this.VideoCustomApplicationButton);
            this.VideoGroupBox.Controls.Add(this.VideoCustomApplicationTextBox);
            this.VideoGroupBox.Controls.Add(this.VideoNothingRadioButton);
            this.VideoGroupBox.Controls.Add(this.VideoCustomRadioButton);
            this.VideoGroupBox.Controls.Add(this.VideoWMPRadioButton);
            this.VideoGroupBox.Controls.Add(this.VideoItunesRadioButton);
            resources.ApplyResources(this.VideoGroupBox, "VideoGroupBox");
            this.VideoGroupBox.Name = "VideoGroupBox";
            this.helpProvider1.SetShowHelp(this.VideoGroupBox, ((bool)(resources.GetObject("VideoGroupBox.ShowHelp"))));
            this.VideoGroupBox.TabStop = false;
            // 
            // VideoM3URadioButton
            // 
            resources.ApplyResources(this.VideoM3URadioButton, "VideoM3URadioButton");
            this.VideoM3URadioButton.Name = "VideoM3URadioButton";
            this.helpProvider1.SetShowHelp(this.VideoM3URadioButton, ((bool)(resources.GetObject("VideoM3URadioButton.ShowHelp"))));
            this.VideoM3URadioButton.UseVisualStyleBackColor = true;
            this.VideoM3URadioButton.CheckedChanged += new System.EventHandler(this.VideoM3URadioButton_CheckedChanged);
            // 
            // VideoAdvancedButton
            // 
            resources.ApplyResources(this.VideoAdvancedButton, "VideoAdvancedButton");
            this.VideoAdvancedButton.Name = "VideoAdvancedButton";
            this.helpProvider1.SetShowHelp(this.VideoAdvancedButton, ((bool)(resources.GetObject("VideoAdvancedButton.ShowHelp"))));
            this.VideoAdvancedButton.UseVisualStyleBackColor = true;
            this.VideoAdvancedButton.Click += new System.EventHandler(this.VideoAdvancedButton_Click);
            // 
            // VideoCustomApplicationButton
            // 
            resources.ApplyResources(this.VideoCustomApplicationButton, "VideoCustomApplicationButton");
            this.VideoCustomApplicationButton.Name = "VideoCustomApplicationButton";
            this.helpProvider1.SetShowHelp(this.VideoCustomApplicationButton, ((bool)(resources.GetObject("VideoCustomApplicationButton.ShowHelp"))));
            this.VideoCustomApplicationButton.UseVisualStyleBackColor = true;
            this.VideoCustomApplicationButton.Click += new System.EventHandler(this.buttonVideoCustomApp_Click);
            // 
            // VideoCustomApplicationTextBox
            // 
            this.VideoCustomApplicationTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VideoCustomApplicationTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.VideoCustomApplicationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Doppler.Properties.Settings.Default, "VideoCustomApp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.VideoCustomApplicationTextBox, "VideoCustomApplicationTextBox");
            this.VideoCustomApplicationTextBox.Name = "VideoCustomApplicationTextBox";
            this.helpProvider1.SetShowHelp(this.VideoCustomApplicationTextBox, ((bool)(resources.GetObject("VideoCustomApplicationTextBox.ShowHelp"))));
            this.VideoCustomApplicationTextBox.Text = global::Doppler.Properties.Settings.Default.VideoCustomApp;
            // 
            // VideoNothingRadioButton
            // 
            resources.ApplyResources(this.VideoNothingRadioButton, "VideoNothingRadioButton");
            this.VideoNothingRadioButton.Name = "VideoNothingRadioButton";
            this.helpProvider1.SetShowHelp(this.VideoNothingRadioButton, ((bool)(resources.GetObject("VideoNothingRadioButton.ShowHelp"))));
            this.VideoNothingRadioButton.UseVisualStyleBackColor = true;
            this.VideoNothingRadioButton.CheckedChanged += new System.EventHandler(this.VideoNothingRadioButton_CheckedChanged);
            // 
            // VideoCustomRadioButton
            // 
            resources.ApplyResources(this.VideoCustomRadioButton, "VideoCustomRadioButton");
            this.VideoCustomRadioButton.Name = "VideoCustomRadioButton";
            this.helpProvider1.SetShowHelp(this.VideoCustomRadioButton, ((bool)(resources.GetObject("VideoCustomRadioButton.ShowHelp"))));
            this.VideoCustomRadioButton.UseVisualStyleBackColor = true;
            this.VideoCustomRadioButton.CheckedChanged += new System.EventHandler(this.VideoCustomRadioButton_CheckedChanged);
            // 
            // VideoWMPRadioButton
            // 
            resources.ApplyResources(this.VideoWMPRadioButton, "VideoWMPRadioButton");
            this.VideoWMPRadioButton.Name = "VideoWMPRadioButton";
            this.helpProvider1.SetShowHelp(this.VideoWMPRadioButton, ((bool)(resources.GetObject("VideoWMPRadioButton.ShowHelp"))));
            this.VideoWMPRadioButton.UseVisualStyleBackColor = true;
            this.VideoWMPRadioButton.CheckedChanged += new System.EventHandler(this.VideoWMPRadio_CheckedChanged);
            // 
            // VideoItunesRadioButton
            // 
            resources.ApplyResources(this.VideoItunesRadioButton, "VideoItunesRadioButton");
            this.VideoItunesRadioButton.Name = "VideoItunesRadioButton";
            this.helpProvider1.SetShowHelp(this.VideoItunesRadioButton, ((bool)(resources.GetObject("VideoItunesRadioButton.ShowHelp"))));
            this.VideoItunesRadioButton.UseVisualStyleBackColor = true;
            this.VideoItunesRadioButton.CheckedChanged += new System.EventHandler(this.VideoItunesRadioButton_CheckedChanged);
            // 
            // AudioGroupBox
            // 
            this.AudioGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.AudioGroupBox.Controls.Add(this.AudioM3URadioButton);
            this.AudioGroupBox.Controls.Add(this.ConvertToBookmarkableCheckBox);
            this.AudioGroupBox.Controls.Add(this.AudioCustomApplicationButton);
            this.AudioGroupBox.Controls.Add(this.AudioCustomApplicationTextBox);
            this.AudioGroupBox.Controls.Add(this.AudioAdvancedButton);
            this.AudioGroupBox.Controls.Add(this.AudioNothingRadioButton);
            this.AudioGroupBox.Controls.Add(this.AudioCustomRadioButton);
            this.AudioGroupBox.Controls.Add(this.AudioWMPRadioButton);
            this.AudioGroupBox.Controls.Add(this.AudioItunesRadioButton);
            resources.ApplyResources(this.AudioGroupBox, "AudioGroupBox");
            this.AudioGroupBox.Name = "AudioGroupBox";
            this.helpProvider1.SetShowHelp(this.AudioGroupBox, ((bool)(resources.GetObject("AudioGroupBox.ShowHelp"))));
            this.AudioGroupBox.TabStop = false;
            // 
            // AudioM3URadioButton
            // 
            resources.ApplyResources(this.AudioM3URadioButton, "AudioM3URadioButton");
            this.AudioM3URadioButton.Name = "AudioM3URadioButton";
            this.helpProvider1.SetShowHelp(this.AudioM3URadioButton, ((bool)(resources.GetObject("AudioM3URadioButton.ShowHelp"))));
            this.AudioM3URadioButton.UseVisualStyleBackColor = true;
            this.AudioM3URadioButton.CheckedChanged += new System.EventHandler(this.AudioM3URadioButton_CheckedChanged);
            // 
            // ConvertToBookmarkableCheckBox
            // 
            resources.ApplyResources(this.ConvertToBookmarkableCheckBox, "ConvertToBookmarkableCheckBox");
            this.ConvertToBookmarkableCheckBox.Checked = global::Doppler.Properties.Settings.Default.AudioConvertM4B;
            this.ConvertToBookmarkableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "AudioConvertM4B", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ConvertToBookmarkableCheckBox.Name = "ConvertToBookmarkableCheckBox";
            this.helpProvider1.SetShowHelp(this.ConvertToBookmarkableCheckBox, ((bool)(resources.GetObject("ConvertToBookmarkableCheckBox.ShowHelp"))));
            this.ConvertToBookmarkableCheckBox.UseVisualStyleBackColor = true;
            // 
            // AudioCustomApplicationButton
            // 
            resources.ApplyResources(this.AudioCustomApplicationButton, "AudioCustomApplicationButton");
            this.AudioCustomApplicationButton.Name = "AudioCustomApplicationButton";
            this.helpProvider1.SetShowHelp(this.AudioCustomApplicationButton, ((bool)(resources.GetObject("AudioCustomApplicationButton.ShowHelp"))));
            this.AudioCustomApplicationButton.UseVisualStyleBackColor = true;
            this.AudioCustomApplicationButton.Click += new System.EventHandler(this.buttonAudioCustomApp_Click);
            // 
            // AudioCustomApplicationTextBox
            // 
            this.AudioCustomApplicationTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AudioCustomApplicationTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.AudioCustomApplicationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Doppler.Properties.Settings.Default, "AudioCustomApp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.AudioCustomApplicationTextBox, "AudioCustomApplicationTextBox");
            this.AudioCustomApplicationTextBox.Name = "AudioCustomApplicationTextBox";
            this.helpProvider1.SetShowHelp(this.AudioCustomApplicationTextBox, ((bool)(resources.GetObject("AudioCustomApplicationTextBox.ShowHelp"))));
            this.AudioCustomApplicationTextBox.Text = global::Doppler.Properties.Settings.Default.AudioCustomApp;
            // 
            // AudioAdvancedButton
            // 
            resources.ApplyResources(this.AudioAdvancedButton, "AudioAdvancedButton");
            this.AudioAdvancedButton.Name = "AudioAdvancedButton";
            this.helpProvider1.SetShowHelp(this.AudioAdvancedButton, ((bool)(resources.GetObject("AudioAdvancedButton.ShowHelp"))));
            this.AudioAdvancedButton.UseVisualStyleBackColor = true;
            this.AudioAdvancedButton.Click += new System.EventHandler(this.AudioAdvancedButton_Click);
            // 
            // AudioNothingRadioButton
            // 
            resources.ApplyResources(this.AudioNothingRadioButton, "AudioNothingRadioButton");
            this.AudioNothingRadioButton.Name = "AudioNothingRadioButton";
            this.helpProvider1.SetShowHelp(this.AudioNothingRadioButton, ((bool)(resources.GetObject("AudioNothingRadioButton.ShowHelp"))));
            this.AudioNothingRadioButton.TabStop = true;
            this.AudioNothingRadioButton.UseVisualStyleBackColor = true;
            this.AudioNothingRadioButton.CheckedChanged += new System.EventHandler(this.radioAudioNothing_CheckedChanged);
            // 
            // AudioCustomRadioButton
            // 
            resources.ApplyResources(this.AudioCustomRadioButton, "AudioCustomRadioButton");
            this.AudioCustomRadioButton.Name = "AudioCustomRadioButton";
            this.helpProvider1.SetShowHelp(this.AudioCustomRadioButton, ((bool)(resources.GetObject("AudioCustomRadioButton.ShowHelp"))));
            this.AudioCustomRadioButton.UseVisualStyleBackColor = true;
            this.AudioCustomRadioButton.CheckedChanged += new System.EventHandler(this.AudioCustomRadioButton_CheckedChanged);
            // 
            // AudioWMPRadioButton
            // 
            resources.ApplyResources(this.AudioWMPRadioButton, "AudioWMPRadioButton");
            this.AudioWMPRadioButton.Name = "AudioWMPRadioButton";
            this.helpProvider1.SetShowHelp(this.AudioWMPRadioButton, ((bool)(resources.GetObject("AudioWMPRadioButton.ShowHelp"))));
            this.AudioWMPRadioButton.UseVisualStyleBackColor = true;
            this.AudioWMPRadioButton.CheckedChanged += new System.EventHandler(this.AudioWMPRadioButton_CheckedChanged);
            // 
            // AudioItunesRadioButton
            // 
            resources.ApplyResources(this.AudioItunesRadioButton, "AudioItunesRadioButton");
            this.AudioItunesRadioButton.Checked = true;
            this.AudioItunesRadioButton.Name = "AudioItunesRadioButton";
            this.helpProvider1.SetShowHelp(this.AudioItunesRadioButton, ((bool)(resources.GetObject("AudioItunesRadioButton.ShowHelp"))));
            this.AudioItunesRadioButton.TabStop = true;
            this.AudioItunesRadioButton.UseVisualStyleBackColor = true;
            this.AudioItunesRadioButton.CheckedChanged += new System.EventHandler(this.AudioItunesRadioButton_CheckedChanged);
            // 
            // tabScheduling
            // 
            this.tabScheduling.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabScheduling, "tabScheduling");
            this.tabScheduling.Name = "tabScheduling";
            this.helpProvider1.SetShowHelp(this.tabScheduling, ((bool)(resources.GetObject("tabScheduling.ShowHelp"))));
            this.tabScheduling.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Check3DateTimePicker);
            this.groupBox1.Controls.Add(this.Check2DateTimePicker);
            this.groupBox1.Controls.Add(this.Check1DateTimePicker);
            this.groupBox1.Controls.Add(this.CheckSpecificRadioButton);
            this.groupBox1.Controls.Add(this.CheckIntervalRadioButton);
            this.groupBox1.Controls.Add(this.CheckIntervalComboBox);
            this.groupBox1.Controls.Add(this.ScheduleRetrieveCheckBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.helpProvider1.SetShowHelp(this.groupBox1, ((bool)(resources.GetObject("groupBox1.ShowHelp"))));
            this.groupBox1.TabStop = false;
            // 
            // Check3DateTimePicker
            // 
            this.Check3DateTimePicker.Checked = false;
            resources.ApplyResources(this.Check3DateTimePicker, "Check3DateTimePicker");
            this.Check3DateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Doppler.Properties.Settings.Default, "CheckHour3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Check3DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Check3DateTimePicker.Name = "Check3DateTimePicker";
            this.Check3DateTimePicker.ShowCheckBox = true;
            this.helpProvider1.SetShowHelp(this.Check3DateTimePicker, ((bool)(resources.GetObject("Check3DateTimePicker.ShowHelp"))));
            this.Check3DateTimePicker.ShowUpDown = true;
            this.Check3DateTimePicker.Value = global::Doppler.Properties.Settings.Default.CheckHour3;
            // 
            // Check2DateTimePicker
            // 
            this.Check2DateTimePicker.Checked = false;
            resources.ApplyResources(this.Check2DateTimePicker, "Check2DateTimePicker");
            this.Check2DateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Doppler.Properties.Settings.Default, "CheckHour2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Check2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Check2DateTimePicker.Name = "Check2DateTimePicker";
            this.Check2DateTimePicker.ShowCheckBox = true;
            this.helpProvider1.SetShowHelp(this.Check2DateTimePicker, ((bool)(resources.GetObject("Check2DateTimePicker.ShowHelp"))));
            this.Check2DateTimePicker.ShowUpDown = true;
            this.Check2DateTimePicker.Value = global::Doppler.Properties.Settings.Default.CheckHour2;
            // 
            // Check1DateTimePicker
            // 
            this.Check1DateTimePicker.Checked = false;
            resources.ApplyResources(this.Check1DateTimePicker, "Check1DateTimePicker");
            this.Check1DateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Doppler.Properties.Settings.Default, "CheckHour1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Check1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Check1DateTimePicker.Name = "Check1DateTimePicker";
            this.Check1DateTimePicker.ShowCheckBox = true;
            this.helpProvider1.SetShowHelp(this.Check1DateTimePicker, ((bool)(resources.GetObject("Check1DateTimePicker.ShowHelp"))));
            this.Check1DateTimePicker.ShowUpDown = true;
            this.Check1DateTimePicker.Value = global::Doppler.Properties.Settings.Default.CheckHour1;
            // 
            // CheckSpecificRadioButton
            // 
            resources.ApplyResources(this.CheckSpecificRadioButton, "CheckSpecificRadioButton");
            this.CheckSpecificRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.CheckSpecificRadioButton.Name = "CheckSpecificRadioButton";
            this.helpProvider1.SetShowHelp(this.CheckSpecificRadioButton, ((bool)(resources.GetObject("CheckSpecificRadioButton.ShowHelp"))));
            this.CheckSpecificRadioButton.TabStop = true;
            this.CheckSpecificRadioButton.UseVisualStyleBackColor = false;
            this.CheckSpecificRadioButton.CheckedChanged += new System.EventHandler(this.radioCheckSpecific_CheckedChanged);
            // 
            // CheckIntervalRadioButton
            // 
            resources.ApplyResources(this.CheckIntervalRadioButton, "CheckIntervalRadioButton");
            this.CheckIntervalRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.CheckIntervalRadioButton.Name = "CheckIntervalRadioButton";
            this.helpProvider1.SetShowHelp(this.CheckIntervalRadioButton, ((bool)(resources.GetObject("CheckIntervalRadioButton.ShowHelp"))));
            this.CheckIntervalRadioButton.TabStop = true;
            this.CheckIntervalRadioButton.UseVisualStyleBackColor = false;
            this.CheckIntervalRadioButton.CheckedChanged += new System.EventHandler(this.radioCheckEvery_CheckedChanged);
            // 
            // CheckIntervalComboBox
            // 
            this.CheckIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckIntervalComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.CheckIntervalComboBox, "CheckIntervalComboBox");
            this.CheckIntervalComboBox.Name = "CheckIntervalComboBox";
            this.helpProvider1.SetShowHelp(this.CheckIntervalComboBox, ((bool)(resources.GetObject("CheckIntervalComboBox.ShowHelp"))));
            // 
            // ScheduleRetrieveCheckBox
            // 
            resources.ApplyResources(this.ScheduleRetrieveCheckBox, "ScheduleRetrieveCheckBox");
            this.ScheduleRetrieveCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ScheduleRetrieveCheckBox.Checked = global::Doppler.Properties.Settings.Default.CheckAutomatic;
            this.ScheduleRetrieveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "CheckAutomatic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScheduleRetrieveCheckBox.Name = "ScheduleRetrieveCheckBox";
            this.helpProvider1.SetShowHelp(this.ScheduleRetrieveCheckBox, ((bool)(resources.GetObject("ScheduleRetrieveCheckBox.ShowHelp"))));
            this.ScheduleRetrieveCheckBox.UseVisualStyleBackColor = false;
            this.ScheduleRetrieveCheckBox.CheckedChanged += new System.EventHandler(this.checkSchedule_CheckedChanged_1);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.checkBox1);
            this.tabMain.Controls.Add(this.ShowFavIconsCheckBox);
            this.tabMain.Controls.Add(this.CheckForUpdateNowButton);
            this.tabMain.Controls.Add(this.LastCheckedLabel);
            this.tabMain.Controls.Add(this.label23);
            this.tabMain.Controls.Add(this.CheckForUpdatesCheckBoxUpdate);
            this.tabMain.Controls.Add(this.SelectFolderButton);
            this.tabMain.Controls.Add(this.DownloadsFolderTextBox);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.MinimizeToSystemTrayCheckBox);
            this.tabMain.Controls.Add(this.PopupNotificationCheckBox);
            this.tabMain.Controls.Add(this.MinimizeOnCloseCheckBox);
            this.tabMain.Controls.Add(this.StartMinimizedCheckBox);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.helpProvider1.SetShowHelp(this.tabMain, ((bool)(resources.GetObject("tabMain.ShowHelp"))));
            this.tabMain.UseVisualStyleBackColor = true;
            this.tabMain.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::Doppler.Properties.Settings.Default.ForceRetrieveOnStartup;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "ForceRetrieveOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Name = "checkBox1";
            this.helpProvider1.SetShowHelp(this.checkBox1, ((bool)(resources.GetObject("checkBox1.ShowHelp"))));
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ShowFavIconsCheckBox
            // 
            resources.ApplyResources(this.ShowFavIconsCheckBox, "ShowFavIconsCheckBox");
            this.ShowFavIconsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ShowFavIconsCheckBox.Checked = global::Doppler.Properties.Settings.Default.ShowFavIcons;
            this.ShowFavIconsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFavIconsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "ShowFavIcons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.helpProvider1.SetHelpString(this.ShowFavIconsCheckBox, resources.GetString("ShowFavIconsCheckBox.HelpString"));
            this.ShowFavIconsCheckBox.Name = "ShowFavIconsCheckBox";
            this.helpProvider1.SetShowHelp(this.ShowFavIconsCheckBox, ((bool)(resources.GetObject("ShowFavIconsCheckBox.ShowHelp"))));
            this.ShowFavIconsCheckBox.UseVisualStyleBackColor = false;
            // 
            // CheckForUpdateNowButton
            // 
            resources.ApplyResources(this.CheckForUpdateNowButton, "CheckForUpdateNowButton");
            this.CheckForUpdateNowButton.Name = "CheckForUpdateNowButton";
            this.helpProvider1.SetShowHelp(this.CheckForUpdateNowButton, ((bool)(resources.GetObject("CheckForUpdateNowButton.ShowHelp"))));
            this.CheckForUpdateNowButton.UseVisualStyleBackColor = true;
            this.CheckForUpdateNowButton.Click += new System.EventHandler(this.buttonUpdateCheck_Click);
            // 
            // LastCheckedLabel
            // 
            resources.ApplyResources(this.LastCheckedLabel, "LastCheckedLabel");
            this.LastCheckedLabel.BackColor = System.Drawing.Color.Transparent;
            this.LastCheckedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Doppler.Properties.Settings.Default, "UpdateCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LastCheckedLabel.Enabled = global::Doppler.Properties.Settings.Default.UpdateCheck;
            this.LastCheckedLabel.Name = "LastCheckedLabel";
            this.helpProvider1.SetShowHelp(this.LastCheckedLabel, ((bool)(resources.GetObject("LastCheckedLabel.ShowHelp"))));
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::Doppler.Properties.Settings.Default, "UpdateCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label23.Enabled = global::Doppler.Properties.Settings.Default.UpdateCheck;
            this.label23.Name = "label23";
            this.helpProvider1.SetShowHelp(this.label23, ((bool)(resources.GetObject("label23.ShowHelp"))));
            // 
            // CheckForUpdatesCheckBoxUpdate
            // 
            resources.ApplyResources(this.CheckForUpdatesCheckBoxUpdate, "CheckForUpdatesCheckBoxUpdate");
            this.CheckForUpdatesCheckBoxUpdate.BackColor = System.Drawing.Color.Transparent;
            this.CheckForUpdatesCheckBoxUpdate.Checked = global::Doppler.Properties.Settings.Default.UpdateCheck;
            this.CheckForUpdatesCheckBoxUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckForUpdatesCheckBoxUpdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "UpdateCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CheckForUpdatesCheckBoxUpdate.Name = "CheckForUpdatesCheckBoxUpdate";
            this.helpProvider1.SetShowHelp(this.CheckForUpdatesCheckBoxUpdate, ((bool)(resources.GetObject("CheckForUpdatesCheckBoxUpdate.ShowHelp"))));
            this.CheckForUpdatesCheckBoxUpdate.UseVisualStyleBackColor = false;
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.SelectFolderButton, "SelectFolderButton");
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.helpProvider1.SetShowHelp(this.SelectFolderButton, ((bool)(resources.GetObject("SelectFolderButton.ShowHelp"))));
            this.SelectFolderButton.UseVisualStyleBackColor = false;
            this.SelectFolderButton.Click += new System.EventHandler(this.buttonSelectDir_Click);
            // 
            // DownloadsFolderTextBox
            // 
            this.DownloadsFolderTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DownloadsFolderTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.helpProvider1.SetHelpString(this.DownloadsFolderTextBox, resources.GetString("DownloadsFolderTextBox.HelpString"));
            resources.ApplyResources(this.DownloadsFolderTextBox, "DownloadsFolderTextBox");
            this.DownloadsFolderTextBox.Name = "DownloadsFolderTextBox";
            this.helpProvider1.SetShowHelp(this.DownloadsFolderTextBox, ((bool)(resources.GetObject("DownloadsFolderTextBox.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // MinimizeToSystemTrayCheckBox
            // 
            resources.ApplyResources(this.MinimizeToSystemTrayCheckBox, "MinimizeToSystemTrayCheckBox");
            this.MinimizeToSystemTrayCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeToSystemTrayCheckBox.Checked = global::Doppler.Properties.Settings.Default.MinimizeToSystemTray;
            this.MinimizeToSystemTrayCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "MinimizeToSystemTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.helpProvider1.SetHelpString(this.MinimizeToSystemTrayCheckBox, resources.GetString("MinimizeToSystemTrayCheckBox.HelpString"));
            this.MinimizeToSystemTrayCheckBox.Name = "MinimizeToSystemTrayCheckBox";
            this.helpProvider1.SetShowHelp(this.MinimizeToSystemTrayCheckBox, ((bool)(resources.GetObject("MinimizeToSystemTrayCheckBox.ShowHelp"))));
            this.MinimizeToSystemTrayCheckBox.UseVisualStyleBackColor = false;
            // 
            // PopupNotificationCheckBox
            // 
            resources.ApplyResources(this.PopupNotificationCheckBox, "PopupNotificationCheckBox");
            this.PopupNotificationCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.helpProvider1.SetHelpString(this.PopupNotificationCheckBox, resources.GetString("PopupNotificationCheckBox.HelpString"));
            this.PopupNotificationCheckBox.Name = "PopupNotificationCheckBox";
            this.helpProvider1.SetShowHelp(this.PopupNotificationCheckBox, ((bool)(resources.GetObject("PopupNotificationCheckBox.ShowHelp"))));
            this.PopupNotificationCheckBox.UseVisualStyleBackColor = false;
            // 
            // MinimizeOnCloseCheckBox
            // 
            resources.ApplyResources(this.MinimizeOnCloseCheckBox, "MinimizeOnCloseCheckBox");
            this.MinimizeOnCloseCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeOnCloseCheckBox.Checked = global::Doppler.Properties.Settings.Default.MinimizeOnClose;
            this.MinimizeOnCloseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "MinimizeOnClose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.helpProvider1.SetHelpString(this.MinimizeOnCloseCheckBox, resources.GetString("MinimizeOnCloseCheckBox.HelpString"));
            this.MinimizeOnCloseCheckBox.Name = "MinimizeOnCloseCheckBox";
            this.helpProvider1.SetShowHelp(this.MinimizeOnCloseCheckBox, ((bool)(resources.GetObject("MinimizeOnCloseCheckBox.ShowHelp"))));
            this.MinimizeOnCloseCheckBox.UseVisualStyleBackColor = false;
            // 
            // StartMinimizedCheckBox
            // 
            resources.ApplyResources(this.StartMinimizedCheckBox, "StartMinimizedCheckBox");
            this.StartMinimizedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.StartMinimizedCheckBox.Checked = global::Doppler.Properties.Settings.Default.StartMinimized;
            this.StartMinimizedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Doppler.Properties.Settings.Default, "StartMinimized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.helpProvider1.SetHelpString(this.StartMinimizedCheckBox, resources.GetString("StartMinimizedCheckBox.HelpString"));
            this.StartMinimizedCheckBox.Name = "StartMinimizedCheckBox";
            this.helpProvider1.SetShowHelp(this.StartMinimizedCheckBox, ((bool)(resources.GetObject("StartMinimizedCheckBox.ShowHelp"))));
            this.StartMinimizedCheckBox.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabScheduling);
            this.tabControl1.Controls.Add(this.tabFileTypes);
            this.tabControl1.Controls.Add(this.tabDefaultFeedSettings);
            this.tabControl1.Controls.Add(this.tabDirectories);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.helpProvider1.SetShowHelp(this.tabControl1, ((bool)(resources.GetObject("tabControl1.ShowHelp"))));
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.buttonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabAdvanced.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxThreads)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabDirectories.ResumeLayout(false);
            this.tabDirectories.PerformLayout();
            this.tabDefaultFeedSettings.ResumeLayout(false);
            this.tabDefaultFeedSettings.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabFeedMain.ResumeLayout(false);
            this.tabFeedMain.PerformLayout();
            this.tabFeedSpaceSavers.ResumeLayout(false);
            this.tabFeedSpaceSavers.PerformLayout();
            this.DefaultSpaceSaversGroupBox.ResumeLayout(false);
            this.DefaultSpaceSaversGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLastPosts)).EndInit();
            this.AdditionalSpaceSaversGroupBox.ResumeLayout(false);
            this.AdditionalSpaceSaversGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictByDaysNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictByFilesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestrictBySizeNumeric)).EndInit();
            this.tabFeedTags.ResumeLayout(false);
            this.tabFeedTags.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabFeedFilters.ResumeLayout(false);
            this.tabFeedFilters.PerformLayout();
            this.tabFileTypes.ResumeLayout(false);
            this.tabFileTypes.PerformLayout();
            this.VideoGroupBox.ResumeLayout(false);
            this.VideoGroupBox.PerformLayout();
            this.AudioGroupBox.ResumeLayout(false);
            this.AudioGroupBox.PerformLayout();
            this.tabScheduling.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            #region Main Tab
            Settings.Default.DownloadLocation = DownloadsFolderTextBox.Text;
            Settings.Default.ShowPopup = PopupNotificationCheckBox.Checked;
            #endregion

            #region Scheduling Tab

            Settings.Default.CheckHour1Enabled = Check1DateTimePicker.Checked;
            Settings.Default.CheckHour2Enabled = Check1DateTimePicker.Checked;
            Settings.Default.CheckHour3Enabled = Check3DateTimePicker.Checked;
            Settings.Default.IntervalMinutes = (short)CheckIntervalComboBox.SelectedValue;

            #endregion

            #region Advanced Tab
            if (radioDupSkip.Checked == true)
            {
                Settings.Default.DuplicateAction = 0;
            }
            else if (radioDupDateTime.Checked == true)
            {
                Settings.Default.DuplicateAction = 1;
            }

            if (checkLog.Checked)
            {
                if (radioLogLevelAll.Checked)
                {
                    Settings.Default.LogLevel = 2;
                }
                else
                {
                    Settings.Default.LogLevel = 1;
                }
            }
            else
            {
                Settings.Default.LogLevel = 0;
            }

            Settings.Default.MaxThreads = Convert.ToInt32(numericMaxThreads.Value);
            Settings.Default.ConfirmFileDelete = ConfirmDeleteCheckBox.Checked; 
            #endregion

            #region Media Player Tab
            Settings.Default.DefaultMediaAction = (MediaPlayerAutomaticRadioButton.Checked) ? 0 : 1;

            #endregion

            #region Default Feed Settings Tab

            if (RetrieveOnlyLastCheckBox.CheckState == CheckState.Checked)
            {
                Settings.Default.MaxFiles = decimal.ToInt32(numericLastPosts.Value);
            }
            else
            {
                Settings.Default.MaxFiles = 0;
            }
            if (RetrieveMaximumMBCheckBox.CheckState == CheckState.Checked)
            {
                Settings.Default.MaxSize = decimal.ToInt32(numericMaxMB.Value);
            }
            else
            {
                Settings.Default.MaxSize = 0;
            }
            FeedItem fi = new FeedItem();

            if (RetrieveOnlyLastCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                fi.RetrieveNumberOfFiles = decimal.ToInt32(numericLastPosts.Value);
            }
            else
            {
                fi.RetrieveNumberOfFiles = 0;
            }
            if (RetrieveMaximumMBCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                fi.MaxMb = decimal.ToInt32(numericMaxMB.Value);
            }
            else
            {
                fi.MaxMb = 0;
            }
            if (RemoveByRatingCheckBox.Checked == true)
            {
                fi.CleanRating = comboRating.Text.Length;
            }
            else
            {
                fi.CleanRating = 0;
            }
            fi.RemovePlayed = checkKeepUnplayed.Checked;

            if (SpaceSaversCheckBox.Checked == true)
            {
                fi.UseSpaceSavers = true;
                if (RestrictBySizeRadioButton.Checked == true)
                {
                    fi.Spacesaver_Files = Convert.ToInt32(RestrictBySizeNumeric.Value);
                    fi.Spacesaver_Files = 0;
                    fi.Spacesaver_Days = 0;
                }
                else
                {
                    fi.Spacesaver_Files = 0;
                }
                if (RestrictByFilesRadioButton.Checked == true)
                {
                    fi.Spacesaver_Files = Convert.ToInt32(RestrictByFilesNumeric.Value);
                    fi.Spacesaver_Files = 0;
                    fi.Spacesaver_Days = 0;
                }
                else
                {
                    fi.Spacesaver_Files = 0;
                }
                if (RestrictByDaysRadioButton.Checked == true)
                {
                    fi.Spacesaver_Days = Convert.ToInt32(RestrictByDaysNumeric.Value);
                    fi.Spacesaver_Files = 0;
                    fi.Spacesaver_Files = 0;
                }
                else
                {
                    fi.Spacesaver_Days = 0;
                }
                //fi.RemoveFromPlaylist = checkRemoveFromPlaylist.Checked;
            }
            else
            {
                fi.UseSpaceSavers = false;

            }

            fi.Textfilter = textFilter.Text;
            fi.TagTitle = TagTitleTextBox.Text;
            fi.TagGenre = TagGenreTextBox.Text;
            fi.TagArtist = TagArtistTextBox.Text;
            fi.TagAlbum = TagAlbumTextBox.Text;
            if (PlaylistTextBox.Text == "<leave empty to use feed name>")
            {
                fi.PlaylistName = "";
            }
            else
            {
                fi.PlaylistName = PlaylistTextBox.Text;
            }

            Settings.Default.DefaultItem = fi;
            #endregion
    		
			Settings.Default.Save();
		}

		private void OptionsForm_Load(object sender, System.EventArgs e)
        {

            #region Main Tab

            if (Settings.Default.LastUpdateCheck.Year == 1 && Settings.Default.LastUpdateCheck.Month == 1 && Settings.Default.LastUpdateCheck.Day == 1)
            {
                LastCheckedLabel.Text = "never";
            } else {
                LastCheckedLabel.Text = Settings.Default.LastUpdateCheck.ToString();
            }
            
        
			DownloadsFolderTextBox.Text = (string)Properties.Settings.Default["DownloadLocation"];
			strOldLocation = (string)Properties.Settings.Default["DownloadLocation"];

			PopupNotificationCheckBox.Checked = Settings.Default.ShowPopup;

            #endregion

            #region Scheduling Tab

            if (Settings.Default.CheckAutomatic)
            {
                CheckSpecificRadioButton.Enabled = true;
                CheckIntervalRadioButton.Enabled = true;
                switch (Settings.Default.CheckType)
                {
                    case 0:
                        // every x minutes
                        CheckIntervalRadioButton.Checked = true;
                        CheckIntervalComboBox.Enabled = true;
                        Check1DateTimePicker.Enabled = false;
                        Check2DateTimePicker.Enabled = false;
                        Check3DateTimePicker.Enabled = false;
                        break;
                    case 1:
                        // specific
                        CheckSpecificRadioButton.Checked = true;
                        CheckIntervalComboBox.Enabled = false;
                        Check1DateTimePicker.Enabled = true;
                        Check2DateTimePicker.Enabled = true;
                        Check3DateTimePicker.Enabled = true;
                        break;
                }
            }
            else
            {
                CheckIntervalRadioButton.Enabled = false;
                CheckSpecificRadioButton.Enabled = false;
                CheckIntervalComboBox.Enabled = false;
                Check1DateTimePicker.Enabled = false;
                Check2DateTimePicker.Enabled = false;
                Check3DateTimePicker.Enabled = false;
            }

            #endregion

            #region Default Feed Settings Tab

            // default item
            // are we using version 2 of Doppler xml?
            if (Settings.Default.DefaultItem != null)
            {
                // yup we are
                // retrieve everything from the defaultitem object
                FeedItem def = Settings.Default.DefaultItem;
                if (def.RetrieveNumberOfFiles > 0)
                {
                    RetrieveOnlyLastCheckBox.Checked = true;
                    numericLastPosts.Value = def.RetrieveNumberOfFiles;
                }
                if (def.MaxMb > 0)
                {
                    RetrieveMaximumMBCheckBox.Checked = true;
                    numericMaxMB.Value = def.MaxMb;
                }
                if (def.Textfilter != null && def.Textfilter != "")
                {
                    textFilter.Text = def.Textfilter;
                }
                if (def.TagTitle != null && def.TagTitle != "")
                {
                    TagTitleTextBox.Text = def.TagTitle;
                }
                if (def.TagGenre != null && def.TagGenre != "")
                {
                    TagGenreTextBox.Text = def.TagGenre;
                }
                if (def.TagArtist != null && def.TagArtist != "")
                {
                    TagArtistTextBox.Text = def.TagArtist;
                }
                if (def.TagAlbum != null && def.TagAlbum != "")
                {
                    TagAlbumTextBox.Text = def.TagAlbum;
                }
                if (def.PlaylistName != null && def.PlaylistName != "")
                {
                    PlaylistTextBox.Text = def.PlaylistName;
                }
                if (def.UseSpaceSavers == true)
                {
                    SpaceSaversCheckBox.Checked = true;
                    if (def.Spacesaver_Size > 0)
                    {
                        RestrictBySizeRadioButton.Checked = true;
                        RestrictBySizeNumeric.Value = def.Spacesaver_Size;
                        RestrictByDaysNumeric.Value = 1;
                        RestrictByFilesNumeric.Value = 1;
                    }
                    if (def.Spacesaver_Files > 0)
                    {
                        RestrictByFilesRadioButton.Checked = true;
                        RestrictBySizeNumeric.Value = 1;
                        RestrictByDaysNumeric.Value = 1;
                        RestrictByFilesNumeric.Value = def.Spacesaver_Files;
                    }
                    if (def.Spacesaver_Days > 0)
                    {
                        RestrictByDaysRadioButton.Checked = true;
                        RestrictBySizeNumeric.Value = 1;
                        RestrictByDaysNumeric.Value = def.Spacesaver_Days;
                        RestrictByFilesNumeric.Value = 1;
                        FeedItem f = new FeedItem();
                    }
                }
                else
                {
                    SpaceSaversCheckBox.Checked = false;
                }
                //checkRemoveFromPlaylist.Checked = def.RemoveFromPlaylist;
                if (def.CleanRating > 0)
                {
                    RemoveByRatingCheckBox.Checked = true;
                    comboRating.SelectedIndex = def.CleanRating - 1;
                }
                checkKeepUnplayed.Checked = def.RemovePlayed;
            }
            else
            {
                if (Properties.Settings.Default.MaxFiles > 0)
                {
                    RetrieveOnlyLastCheckBox.Checked = true;
                    numericLastPosts.Value = Properties.Settings.Default.MaxFiles;
                }
                if (Properties.Settings.Default.MaxSize > 0)
                {
                    RetrieveMaximumMBCheckBox.Checked = true;
                    numericMaxMB.Value = Properties.Settings.Default.MaxSize;
                }
            }

            #endregion

            #region OPML Directories Tab

            FillDirectoryList();

            #endregion

            #region Media Player Tab

            // Position a few labels
            IntroLabel.Location = AudioGroupBox.Location;
            IntroLabel.Text = "Shown below are the applications associated with a few of the most common file types";
            FileTypeLabel.Location = new Point(IntroLabel.Location.X, IntroLabel.Location.Y + IntroLabel.Height + 2);
            FileAssociationLabel.Location = new Point(IntroLabel.Location.X + 50, IntroLabel.Location.Y + IntroLabel.Height + 2);
            // check if iTunes is installed
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Apple Computer, Inc.\\iTunes", false);
            if (key == null)
            {
                AudioItunesRadioButton.Enabled = false;
                VideoItunesRadioButton.Enabled = false;
            }

            // fill the default media types stuff

            Utils.MediaAction action = Utils.GetMediaAction(".mp3");
            FileTypeLabel.Text = "*.mp3: ";
            FileAssociationLabel.Text = action.ToString();
            action = Utils.GetMediaAction(".wma");
            FileTypeLabel.Text += "\n*.wma: ";
            FileAssociationLabel.Text += "\n" + action.ToString();
            action = Utils.GetMediaAction(".m4a");
            FileTypeLabel.Text += "\n*.m4a: ";
            FileAssociationLabel.Text += "\n" + action.ToString();
            action = Utils.GetMediaAction(".m4v");
            FileTypeLabel.Text += "\n*.m4v: ";
            FileAssociationLabel.Text += "\n" + action.ToString();
            action = Utils.GetMediaAction(".wmv");
            FileTypeLabel.Text += "\n*.wmv: ";
            FileAssociationLabel.Text += "\n" + action.ToString();

            if (Settings.Default.DefaultMediaAction == 0)
            {
                MediaPlayerAutomaticRadioButton.Checked = true;
            }
            else
            {
                //                MediaPlayerAutomaticRadioButton.Checked = false;
                MediaPlayerManualRadioButton.Checked = true;
            }

            // set the file types radio buttons
            AudioCustomApplicationTextBox.Enabled = false;
            AudioCustomApplicationButton.Enabled = false;
            switch (Settings.Default.AudioFile)
            {
                case 0:
                    AudioNothingRadioButton.Checked = true;
                    break;
                case 1:

                    AudioItunesRadioButton.Checked = true;
                    break;
                case 2:
                    AudioWMPRadioButton.Checked = true;
                    break;
                case 3:
                    AudioCustomRadioButton.Checked = true;
                    AudioCustomApplicationTextBox.Enabled = true;
                    AudioCustomApplicationButton.Enabled = true;
                    break;
                case 4:
                    AudioM3URadioButton.Checked = true;
                    break;

            }

            // set the file types radio buttons
            VideoCustomApplicationTextBox.Enabled = false;
            VideoCustomApplicationButton.Enabled = false;
            switch (Settings.Default.VideoFile)
            {
                case 0:
                    VideoNothingRadioButton.Checked = true;
                    break;
                case 1:
                    VideoItunesRadioButton.Checked = true;
                    break;
                case 2:
                    VideoWMPRadioButton.Checked = true;
                    break;
                case 3:
                    VideoCustomRadioButton.Checked = true;
                    VideoCustomApplicationTextBox.Enabled = true;
                    VideoCustomApplicationButton.Enabled = true;
                    break;
                case 4:
                    VideoM3URadioButton.Checked = true;
                    break;
            }

            #endregion

            #region Advanced Tab

            numericMaxThreads.Value = Settings.Default.MaxThreads;
            if (Settings.Default.LogLevel > 0)
            {
                checkLog.Checked = true;
                if (Settings.Default.LogLevel > 1)
                {
                    radioLogLevelAll.Checked = true;
                }
                else
                {
                    radioLogLevelErrors.Checked = true;
                }
            }

            switch (Properties.Settings.Default.DuplicateAction)
            {
                case 0:
                    radioDupSkip.Checked = true;
                    break;
                case 1:
                    radioDupDateTime.Checked = true;
                    break;
            }

            ConfirmDeleteCheckBox.Checked = Settings.Default.ConfirmFileDelete;

            #endregion
        }

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{

		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void buttonSelectDir_Click(object sender, System.EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				DownloadsFolderTextBox.Text = folderBrowserDialog1.SelectedPath;

			}
			folderBrowserDialog1.Dispose();
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void checkSchedule_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ScheduleRetrieveCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				CheckIntervalRadioButton.Enabled = true;
				CheckSpecificRadioButton.Enabled = true;
			}
			else
			{
				CheckIntervalRadioButton.Enabled = false;
				CheckSpecificRadioButton.Enabled = false;
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		
		
		private void tabPage1_Click(object sender, System.EventArgs e)
		{

		}

		private void textDownloadLocation_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void label1_Click(object sender, System.EventArgs e)
		{

		}

		private void RetrieveOnlyLastCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RetrieveOnlyLastCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				numericLastPosts.Enabled = true;
			}
			else
			{
				numericLastPosts.Enabled = false;
			}
		}

		private void RetrieveMaximumMBCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RetrieveMaximumMBCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
			{
				numericMaxMB.Enabled = true;
			}
			else
			{
				numericMaxMB.Enabled = false;
			}
		}

		private void radioRestrictSize_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RestrictBySizeRadioButton.Checked == true)
			{
				labelTotalSize.Visible = true;
				labelMB.Visible = true;
				RestrictBySizeNumeric.Visible = true;
			}
			else
			{
				labelTotalSize.Visible = false;
				labelMB.Visible = false;
				RestrictBySizeNumeric.Visible = false;
			}
		}

		private void radioRestrictFiles_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RestrictByFilesRadioButton.Checked == true)
			{
				labelMaximumFiles.Visible = true;
				RestrictByFilesNumeric.Visible = true;
			}
			else
			{
				labelMaximumFiles.Visible = false;
				RestrictByFilesNumeric.Visible = false;

			}
		}

		private void radioRestrictDays_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RestrictByDaysRadioButton.Checked == true)
			{
				labelRestrictDays.Visible = true;
				labelRestrictDaysDays.Visible = true;
				RestrictByDaysNumeric.Visible = true;
			}
			else
			{
				labelRestrictDays.Visible = false;
				labelRestrictDaysDays.Visible = false;
				RestrictByDaysNumeric.Visible = false;
			}
		}

		private void SpaceSaversCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
            if (SpaceSaversCheckBox.Checked)
            {
                AdditionalSpaceSaversGroupBox.Enabled = true;
               
            }
            else
            {
                AdditionalSpaceSaversGroupBox.Enabled = false;

            }
		}


		

		private void label3_Click(object sender, System.EventArgs e)
		{

		}

		private void label4_Click(object sender, System.EventArgs e)
		{

		}

		private void tabSpaceSavers_Click(object sender, System.EventArgs e)
		{

		}

		private void radioCheckEvery_CheckedChanged(object sender, System.EventArgs e)
		{
            if (CheckIntervalRadioButton.Checked)
            {
                Settings.Default.CheckType = 0;
                CheckIntervalComboBox.Enabled = true;
            }
            else
            {
                Settings.Default.CheckType = 1;
                CheckIntervalComboBox.Enabled = false;
            }
		}

		private void checkSchedule_CheckedChanged_1(object sender, System.EventArgs e)
		{
			if (ScheduleRetrieveCheckBox.Checked)
			{
				CheckIntervalRadioButton.Enabled = true;
				CheckSpecificRadioButton.Enabled = true;
                if (Settings.Default.CheckType == 0)
                {
                    CheckIntervalRadioButton.Checked = true;
                    CheckIntervalComboBox.Enabled = true;
                    Check1DateTimePicker.Enabled = false;
                    Check2DateTimePicker.Enabled = false;
                    Check3DateTimePicker.Enabled = false;
                }
                else
                {
                    CheckSpecificRadioButton.Checked = true;
                    CheckIntervalComboBox.Enabled = false;
                    Check1DateTimePicker.Enabled = true;
                    Check2DateTimePicker.Enabled = true;
                    Check3DateTimePicker.Enabled = true;
                }
			}
			else
			{
				CheckIntervalRadioButton.Enabled = false;
				CheckSpecificRadioButton.Enabled = false;
                CheckIntervalComboBox.Enabled = false;
                Check1DateTimePicker.Enabled = false;
                Check2DateTimePicker.Enabled = false;
                Check3DateTimePicker.Enabled = false;

			}
		}

		private void radioCheckEvery_EnabledChanged(object sender, System.EventArgs e)
		{
			if (CheckIntervalRadioButton.Enabled == true)
			{
				CheckIntervalComboBox.Enabled = true;
			}
			else
			{
				CheckIntervalComboBox.Enabled = false;
			}
		}

		private void checkLog_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkLog.Checked)
			{
				radioLogLevelErrors.Enabled = true;
				radioLogLevelAll.Enabled = true;
				buttonOpenLog.Enabled = true;
				labelLogMessage.Visible = true;
			}
			else
			{
				radioLogLevelErrors.Enabled = false;
				radioLogLevelAll.Enabled = false;
				buttonOpenLog.Enabled = false;
				labelLogMessage.Visible = false;
			}
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{

		}

		private void buttonOpenLog_Click(object sender, System.EventArgs e)
		{
			LogForm fLog = new LogForm();
			fLog.Show();
		}

    	private void radioCheckSpecific_EnabledChanged(object sender, System.EventArgs e)
		{
			if (CheckSpecificRadioButton.Enabled && CheckSpecificRadioButton.Checked)
			{
				Check1DateTimePicker.Enabled = true;
				Check2DateTimePicker.Enabled = true;
				Check3DateTimePicker.Enabled = true;
			}
			else
			{

				Check1DateTimePicker.Enabled = false;
				Check2DateTimePicker.Enabled = false;
				Check3DateTimePicker.Enabled = false;
			}

		}

		private void RemoveByRatingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RemoveByRatingCheckBox.Checked == true)
			{
				comboRating.Enabled = true;
				if (comboRating.SelectedIndex == 0) comboRating.SelectedIndex = 1;
			}
			else
			{
				comboRating.Enabled = false;
			}
		}

		private void textPlaylist_Enter(object sender, System.EventArgs e)
		{
			if (PlaylistTextBox.Text == "<leave empty to use feed name>")
			{
				PlaylistTextBox.Text = "";
			}
		}

		private void textPlaylist_Leave(object sender, System.EventArgs e)
		{
			if (PlaylistTextBox.Text == "")
			{
				PlaylistTextBox.Text = "<leave empty to use feed name>";
			}
		}

		private void tabDirectories_Click(object sender, System.EventArgs e)
		{

		}

		private void buttonNewDirectory_Click(object sender, System.EventArgs e)
		{
			
				if (Settings.Default.DirectoryList == null)
				{
					Settings.Default.DirectoryList = new DirectoryList();
				}
                OPMLDirectoryForm fDirectory = new OPMLDirectoryForm();
                if (fDirectory.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.DirectoryList.Add(fDirectory.DirectoryItem);
                    ListViewItem lvi = new ListViewItem(fDirectory.DirectoryItem.Name);
                    lvi.Tag = fDirectory.DirectoryItem.GUID;
                    lvi.SubItems.Add(fDirectory.DirectoryItem.URL);
                    FillDirectoryList();
                }
			
			
		}

		private void FillDirectoryList()
		{
			// Directory tab
			DirectoriesListView.BeginUpdate();
			DirectoriesListView.Items.Clear();
			if (Settings.Default.DirectoryList != null)
			{
				for (int q = 0; q < Settings.Default.DirectoryList.Count; q++)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Tag = Settings.Default.DirectoryList[q].GUID;
					lvi.Text = Settings.Default.DirectoryList[q].Name;
					lvi.SubItems.Add(Settings.Default.DirectoryList[q].URL);
					DirectoriesListView.Items.Add(lvi);
				}
			}
			DirectoriesListView.EndUpdate();
		}

		private void DeleteDirectoryButton_Click(object sender, System.EventArgs e)
		{
			if (DirectoriesListView.SelectedIndices.Count > 0)
			{
				ListViewItem lvi = DirectoriesListView.Items[DirectoriesListView.SelectedIndices[0]];
				if (lvi != null)
				{
					if (Settings.Default.DirectoryList.Remove((Guid)lvi.Tag))
					{
						lvi.Remove();
					}
				}
			}
		}

		private void listDirectories_DoubleClick(object sender, System.EventArgs e)
		{
			Guid GUID = (Guid)DirectoriesListView.Items[DirectoriesListView.SelectedIndices[0]].Tag;
			DirectoryItem dirItem = Settings.Default.DirectoryList[GUID];
            ListViewItem lvi = DirectoriesListView.FocusedItem;

            OPMLDirectoryForm fDirectory = new OPMLDirectoryForm(dirItem);

            if (fDirectory.ShowDialog() == DialogResult.OK)
            {
                lvi.Text = fDirectory.DirectoryItem.Name;
                lvi.SubItems[1].Text = fDirectory.DirectoryItem.URL;
                Settings.Default.DirectoryList[dirItem.GUID] = dirItem;
            }
			fDirectory.Dispose();
		}

        private void radioAudioNothing_CheckedChanged(object sender, EventArgs e)
        {
            SetAudioFileTypes();
        }

        private void SetAudioFileTypes()
        {
            if (AudioNothingRadioButton.Checked)
            {
                Settings.Default.AudioFile = 0;
            }
            else if (AudioItunesRadioButton.Checked)
            {
                Settings.Default.AudioFile = 1;
            }
            else if (AudioWMPRadioButton.Checked)
            {
                Settings.Default.AudioFile = 2;
            }
            else if (AudioCustomRadioButton.Checked)
            {
                Settings.Default.AudioFile = 3;
            }
            else
            {
                Settings.Default.AudioFile = 4;
            }
        }

        private void SetVideoFileTypes()
        {
            if (VideoNothingRadioButton.Checked)
            {
                Settings.Default.VideoFile = 0;
            }
            else if (VideoItunesRadioButton.Checked)
            {
                Settings.Default.VideoFile = 1;
            }
            else if (VideoWMPRadioButton.Checked)
            {
                Settings.Default.VideoFile = 2;
            }
            else if (VideoCustomRadioButton.Checked)
            {
                Settings.Default.VideoFile = 3;
            }
            else
            {
                Settings.Default.VideoFile = 4;
            }
        }

        private void AudioItunesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetAudioFileTypes();
            if (AudioItunesRadioButton.Checked)
            {
                ConvertToBookmarkableCheckBox.Enabled = true;
            }
            else
            {
                ConvertToBookmarkableCheckBox.Enabled = false;
            }
        }

        private void AudioWMPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetAudioFileTypes();
        }

        private void AudioCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetAudioFileTypes();
            if (AudioCustomRadioButton.Checked)
            {
                AudioCustomApplicationTextBox.Enabled = true;
                AudioCustomApplicationButton.Enabled = true;
            }
            else
            {
                AudioCustomApplicationTextBox.Enabled = false;
                AudioCustomApplicationButton.Enabled = false;
            }
        }

        private void buttonAudioCustomApp_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = AudioCustomApplicationTextBox.Text;
            openFileDialog1.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AudioCustomApplicationTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void buttonVideoCustomApp_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = VideoCustomApplicationTextBox.Text;
            openFileDialog1.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                VideoCustomApplicationTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void VideoNothingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVideoFileTypes();
        }

        private void VideoCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVideoFileTypes();
            if (VideoCustomRadioButton.Checked)
            {
                VideoCustomApplicationTextBox.Enabled = true;
                VideoCustomApplicationButton.Enabled = true;
            }
            else
            {
                VideoCustomApplicationTextBox.Enabled = false;
                VideoCustomApplicationButton.Enabled = false;
            }
        }

        private void VideoItunesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVideoFileTypes();
        }

        private void VideoWMPRadio_CheckedChanged(object sender, EventArgs e)
        {
            SetVideoFileTypes();
        }

        private void AudioAdvancedButton_Click(object sender, EventArgs e)
        {
            ExtensionsForm fExtensions = new ExtensionsForm(Settings.Default.AudioExtensions);
            if (fExtensions.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AudioExtensions = fExtensions.Extensions;
            }
            fExtensions.Dispose();
        }

        private void VideoAdvancedButton_Click(object sender, EventArgs e)
        {
            ExtensionsForm fExtensions = new ExtensionsForm(Settings.Default.VideoExtensions);
            if (fExtensions.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.VideoExtensions = fExtensions.Extensions;
            }
            fExtensions.Dispose();
        }

        private void radioCheckSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSpecificRadioButton.Checked)
            {
                Settings.Default.CheckType = 1;     
                Check1DateTimePicker.Enabled = true;
                Check2DateTimePicker.Enabled = true;
                Check3DateTimePicker.Enabled = true;
            }
            else
            {
                Settings.Default.CheckType = 0;
                Check1DateTimePicker.Enabled = false;
                Check2DateTimePicker.Enabled = false;
                Check3DateTimePicker.Enabled = false;
            }
        }

        private void buttonUpdateCheck_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                bool newVersion = Utils.CheckForLatestVersion();
                Settings.Default.LastUpdateCheck = DateTime.Now;
                Cursor.Current = Cursors.Default;
                if (newVersion)
                {
                    if (MessageBox.Show(FormStrings.NewVersionOfDopplerAvailable, FormStrings.NewVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://www.dopplerradio.net");
                    }
                }
                else
                {
                    MessageBox.Show(FormStrings.YouAreRunningTheLatestVersionOfDoppler, FormStrings.NoNewVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LastCheckedLabel.Text = Settings.Default.LastUpdateCheck.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(FormStrings.AnErrorOccuredWhileCheckingForTheLatestVersion + ex.Message, FormStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdditionalSpaceSaversGroupBox_EnabledChanged(object sender, EventArgs e)
        {
            if (AdditionalSpaceSaversGroupBox.Enabled == true)
            {
                RestrictBySizeRadioButton.Enabled = true;
                RestrictBySizeNumeric.Enabled = true;
                RestrictByFilesRadioButton.Enabled = true;
                RestrictByFilesNumeric.Enabled = true;
                RestrictByDaysRadioButton.Enabled = true;
                RestrictByDaysNumeric.Enabled = true;
            }
            else
            {
                RestrictBySizeRadioButton.Enabled = false;
                RestrictBySizeNumeric.Enabled = false;
                RestrictByFilesRadioButton.Enabled = false;
                RestrictByFilesNumeric.Enabled = false;
                RestrictByDaysRadioButton.Enabled = false;
                RestrictByDaysNumeric.Enabled = false;
            }
        }

        private void AudioM3URadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetAudioFileTypes();
        }

        private void VideoM3URadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetVideoFileTypes();
        }

        private void ClearCacheButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo cacheDirectoryInfo = new DirectoryInfo(Utils.DataFolder);
            int succesCounter = 0;
            int failedCounter = 0;
            FileInfo[] cacheFiles = cacheDirectoryInfo.GetFiles("*.*");
            if(cacheFiles.Length > 0)
            {
                foreach (FileInfo cacheFile in cacheFiles)
                {
                    try
                    {
                        cacheFile.Delete();
                        succesCounter++;
                    }
                    catch (Exception)
                    {
                        failedCounter++;
                    }
                }
                string message = String.Format(FormStrings.SuccesfullyDeletedCacheFiles,succesCounter);
                if (failedCounter > 0)
                {
                    message = String.Format("Succesfully deleted {0} cache file(s), and failed to delete {1} file(s)",succesCounter,failedCounter);
                }
                MessageBox.Show(message, "Cache", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            // loop through the feeds and clear the feed hashcodes
            foreach (FeedItem feedItem in Settings.Default.Feeds)
            {
                feedItem.FeedHashCode = null;
                Settings.Default.Save();
            }
        }

        private void MediaPlayerAutomaticRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MediaPlayerAutomaticRadioButton.Checked)
            {
                AudioGroupBox.Visible = false;
                VideoGroupBox.Visible = false;
                IntroLabel.Visible = true;
                FileTypeLabel.Visible = true;
                FileAssociationLabel.Visible = true;
            }
            else
            {
                AudioGroupBox.Visible = true;
                VideoGroupBox.Visible = true;
                IntroLabel.Visible = false;
                FileTypeLabel.Visible = false;
                FileAssociationLabel.Visible = false;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

       

         

    
	}

	public class ScheduleInterval
	{
		private string _name;
		private short _minutes;

		/// <summary>
		/// Provides a helper class for the schedule interval dropdown
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="Minutes"></param>
		public ScheduleInterval(string Name, short Minutes)
		{
			this._name = Name;
			this._minutes = Minutes;
		}
		public string Name
		{
            get { return _name; }
			set { _name = value; }
		}
		public short Minutes
		{
			get { return _minutes; }
			set { _minutes = value; }
		}
	}

}
