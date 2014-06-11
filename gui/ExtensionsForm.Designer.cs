namespace Doppler
{
    partial class ExtensionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtensionsForm));
            this.listExtensions = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textExtension = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listExtensions
            // 
            this.listExtensions.AccessibleDescription = null;
            this.listExtensions.AccessibleName = null;
            resources.ApplyResources(this.listExtensions, "listExtensions");
            this.listExtensions.BackgroundImage = null;
            this.listExtensions.Font = null;
            this.listExtensions.FormattingEnabled = true;
            this.listExtensions.Name = "listExtensions";
            this.listExtensions.Sorted = true;
            this.listExtensions.SelectedIndexChanged += new System.EventHandler(this.listExtensions_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleDescription = null;
            this.buttonAdd.AccessibleName = null;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.BackgroundImage = null;
            this.buttonAdd.Font = null;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textExtension
            // 
            this.textExtension.AccessibleDescription = null;
            this.textExtension.AccessibleName = null;
            resources.ApplyResources(this.textExtension, "textExtension");
            this.textExtension.BackgroundImage = null;
            this.textExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textExtension.Font = null;
            this.textExtension.Name = "textExtension";
            this.textExtension.TextChanged += new System.EventHandler(this.textExtension_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleDescription = null;
            this.buttonOK.AccessibleName = null;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.BackgroundImage = null;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.AccessibleDescription = null;
            this.buttonRemove.AccessibleName = null;
            resources.ApplyResources(this.buttonRemove, "buttonRemove");
            this.buttonRemove.BackgroundImage = null;
            this.buttonRemove.Font = null;
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleDescription = null;
            this.buttonCancel.AccessibleName = null;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackgroundImage = null;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ExtensionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = null;
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textExtension);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listExtensions);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "ExtensionsForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listExtensions;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textExtension;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCancel;
    }
}