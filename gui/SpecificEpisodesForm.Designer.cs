namespace Doppler
{
    partial class SpecificEpisodesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecificEpisodesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.FeedTitleLabel = new System.Windows.Forms.Label();
            this.PostsListView = new System.Windows.Forms.ListView();
            this.StatusColumn = new System.Windows.Forms.ColumnHeader();
            this.TitleColumn = new System.Windows.Forms.ColumnHeader();
            this.DateColumn = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.QueueButton = new System.Windows.Forms.Button();
            this.CancelQueueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feed:";
            // 
            // FeedTitleLabel
            // 
            this.FeedTitleLabel.AutoSize = true;
            this.FeedTitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedTitleLabel.Location = new System.Drawing.Point(53, 9);
            this.FeedTitleLabel.Name = "FeedTitleLabel";
            this.FeedTitleLabel.Size = new System.Drawing.Size(0, 13);
            this.FeedTitleLabel.TabIndex = 1;
            // 
            // PostsListView
            // 
            this.PostsListView.CheckBoxes = true;
            this.PostsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatusColumn,
            this.TitleColumn,
            this.DateColumn});
            this.PostsListView.FullRowSelect = true;
            this.PostsListView.Location = new System.Drawing.Point(15, 25);
            this.PostsListView.Name = "PostsListView";
            this.PostsListView.Size = new System.Drawing.Size(504, 205);
            this.PostsListView.TabIndex = 2;
            this.PostsListView.UseCompatibleStateImageBehavior = false;
            this.PostsListView.View = System.Windows.Forms.View.Details;
            // 
            // StatusColumn
            // 
            this.StatusColumn.Text = "";
            this.StatusColumn.Width = 20;
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Date";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "buttontrans.gif");
            this.imageList1.Images.SetKeyName(1, "downloaded.gif");
            // 
            // QueueButton
            // 
            this.QueueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.QueueButton.Location = new System.Drawing.Point(363, 236);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(75, 28);
            this.QueueButton.TabIndex = 3;
            this.QueueButton.Text = "&Queue";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueButton_Click);
            // 
            // CancelQueueButton
            // 
            this.CancelQueueButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelQueueButton.Location = new System.Drawing.Point(444, 236);
            this.CancelQueueButton.Name = "CancelQueueButton";
            this.CancelQueueButton.Size = new System.Drawing.Size(75, 28);
            this.CancelQueueButton.TabIndex = 4;
            this.CancelQueueButton.Text = "&Cancel";
            this.CancelQueueButton.UseVisualStyleBackColor = true;
            this.CancelQueueButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SpecificEpisodesForm
            // 
            this.AcceptButton = this.QueueButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.CancelQueueButton;
            this.ClientSize = new System.Drawing.Size(531, 271);
            this.Controls.Add(this.CancelQueueButton);
            this.Controls.Add(this.QueueButton);
            this.Controls.Add(this.PostsListView);
            this.Controls.Add(this.FeedTitleLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SpecificEpisodesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download specific podcasts";
            this.Load += new System.EventHandler(this.SpecificEpisodesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FeedTitleLabel;
        private System.Windows.Forms.ListView PostsListView;
        private System.Windows.Forms.Button QueueButton;
        private System.Windows.Forms.Button CancelQueueButton;
        private System.Windows.Forms.ColumnHeader StatusColumn;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ImageList imageList1;
    }
}