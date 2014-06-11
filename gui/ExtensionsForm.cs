using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Doppler
{
    public partial class ExtensionsForm : Form
    {
      
        public ExtensionsForm(string Extensions)
        {
            InitializeComponent();
            listExtensions.Items.AddRange(Extensions.Split(','));
            if (listExtensions.Items.Count > 0)
            {
                buttonRemove.Enabled = true;
                listExtensions.SelectedIndex = 0;
            }
           
        }

        public string Extensions
        {
            get
            {
                string Extensions = "";
                for (int q = 0; q < listExtensions.Items.Count; q++)
                {
                    Extensions += "," + listExtensions.Items[q];
                }
                return Extensions.Substring(1);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!listExtensions.Items.Contains(textExtension.Text))
            {
                listExtensions.Items.Add(textExtension.Text);

            }
            if (listExtensions.Items.Count > 0)
            {
                buttonRemove.Enabled = true;
            }
            else
            {
                buttonRemove.Enabled = false;
            }

        }

        private void textExtension_TextChanged(object sender, EventArgs e)
        {
            
                if (!listExtensions.Items.Contains(textExtension.Text) && textExtension.Text.IndexOf('.') == -1 && textExtension.Text != "")
                {
                    buttonAdd.Enabled = true;
                }
                else
                {
                    buttonAdd.Enabled = false;
                }
            
        }

        private void listExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listExtensions.SelectedIndex != -1)
            {
                buttonRemove.Enabled = true;
            }
            else
            {
                buttonRemove.Enabled = false;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listExtensions.SelectedIndex > -1)
            {
                listExtensions.Items.RemoveAt(listExtensions.SelectedIndex);
                if (listExtensions.Items.Count > 0)
                {
                    buttonRemove.Enabled = true;
                }
                else
                {
                    buttonRemove.Enabled = false;
                }
            }
            else
            {
                buttonRemove.Enabled = false;
            }
        }
    }
}