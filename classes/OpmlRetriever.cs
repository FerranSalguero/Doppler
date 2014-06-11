using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace Doppler
{
    public delegate TreeNode AddNodeToNodeWithTextHandler(TreeNode treeNode, string strNode);
    public delegate int AddNodeToNodeHandler(TreeNode treeNode1, TreeNode treeNode2);
    public delegate int AddNodeHandler(TreeNode treeNode);
    public delegate TreeNode AddNodeWithTextHandler(string strNode);

    class OPMLRetriever
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public event AddNodeHandler AddNode;
        public event AddNodeToNodeWithTextHandler AddNodeToNodeWithText;
        public event AddNodeWithTextHandler AddNodeWithText;
        public event AddNodeToNodeHandler AddNodeToNode;
        DirectoryItem dirItem;
        public OPMLRetriever(DirectoryItem itemIn)
        {
            dirItem = itemIn;
        }
       
        public void populateTree()
        {
            //Cursor.Current = Cursors.WaitCursor;
            //treeOPML.Nodes.Clear();
            //treeOPML.BeginUpdate();
            System.Net.WebClient Client = new WebClient();
            System.IO.Stream strm = null;
            string opmlUrl = "";

            try
            {
                //DirectoryItem dirItem = (DirectoryItem)comboDirectory.SelectedItem;
                opmlUrl = dirItem.URL;
                // opmlUrl = feedHandler.directoryList[comboDirectory.SelectedIndex-1].URL;
                /*
                switch(comboDirectory.Text)
                {
			
                    case "allpodcasts.com" : 
                        opmlUrl = "http://www.allpodcasts.com/Directory/AllOpml.aspx";
                        break;
                    default :
                        opmlUrl = "http://homepage.mac.com/dailysourcecode/DSC/ipodderDirectory.opml";
                        //opmlUrl = "http://www.ipodder.org/discuss/reader$4.opml";
                        break;
                }
                */
                //	XmlTextReader xmltextreader = new XmlTextReader(opmlUrl,null,System.Xml.XmlParserContext);

                strm = Client.OpenRead(opmlUrl);

                XmlNodeList opmlCategories = null;
                XmlDocument doc = new XmlDocument();

                doc.Load(opmlUrl);

                //	doc.Load(strm);
                //	doc.Load(xmltextreader);

                XmlNode body = doc.DocumentElement.SelectSingleNode("body");

                opmlCategories = body.SelectNodes("outline[not(@type='link')]");
                if (opmlCategories != null)
                {
                    foreach (XmlNode category in opmlCategories)
                    {
                        string strCat = "";
                        if (category.Attributes["title"] != null)
                        {
                            strCat = category.Attributes["title"].InnerText;
                        }
                        else
                        {
                            strCat = category.Attributes["text"].InnerText;
                        }
                        TreeNode catNode = AddNodeWithText(strCat);

                        //TreeNode catNode = treeOPML.Nodes.Add(strCat);
                        //catNode.ImageIndex = 0;
                        //catNode.SelectedImageIndex = 2;
                        // check if we have items at this level
                        XmlNodeList opmlEntries = category.SelectNodes("outline[(@type='link')]");
                        foreach (XmlNode opmlEntry in opmlEntries)
                        {
                            string strTitle = "";
                            if (opmlEntry.Attributes["title"] != null)
                            {
                                strTitle = opmlEntry.Attributes["title"].InnerText;
                            }
                            else
                            {
                                strTitle = opmlEntry.Attributes["text"].InnerText;
                            }
                            TreeNode entry = new TreeNode(strTitle);

                            string strXmlUrl = "";
                            if (opmlEntry.Attributes["xmlUrl"] != null)
                            {
                                strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
                            }
                            else
                            {
                                strXmlUrl = opmlEntry.Attributes["url"].InnerText;
                            }
                            entry.Tag = strXmlUrl;
                            if (strXmlUrl.Substring(strXmlUrl.LastIndexOf(".") + 1).ToLower() == "opml")
                            {
                                entry.ImageIndex = 0;
                                entry.SelectedImageIndex = 2;
                            }
                            else
                            {
                                entry.ImageIndex = 1;
                                entry.SelectedImageIndex = 1;
                            }
                            AddNodeToNode(catNode, entry);
                            //catNode.Nodes.Add(entry);
                        }



                        getCategories(category, catNode);


                    }

                    // check for root level items
                    XmlNodeList opmlOutlineEntries = body.SelectNodes("outline[@type='link']");
                    foreach (XmlNode opmlEntry in opmlOutlineEntries)
                    {
                        string strTitle = "";
                        if (opmlEntry.Attributes["title"] != null)
                        {
                            strTitle = opmlEntry.Attributes["title"].InnerText;
                        }
                        else
                        {
                            strTitle = opmlEntry.Attributes["text"].InnerText;
                        }
                        TreeNode entry = new TreeNode(strTitle);
                        string strXmlUrl = "";
                        if (opmlEntry.Attributes["xmlUrl"] != null)
                        {
                            strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
                        }
                        else
                        {
                            strXmlUrl = opmlEntry.Attributes["url"].InnerText;
                        }
                        entry.Tag = strXmlUrl;
                        if (strXmlUrl.Substring(strXmlUrl.LastIndexOf(".") + 1).ToLower() == "opml")
                        {
                            entry.ImageIndex = 0;
                            entry.SelectedImageIndex = 2;
                        }
                        else
                        {
                            entry.ImageIndex = 1;
                            entry.SelectedImageIndex = 1;
                        }
                        AddNode(entry);
                        //treeOPML.Nodes.Add(entry);
                    }
                    // end check
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show("Error while retrieving OPML:\n\n"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (strm != null) strm.Close();
               // treeOPML.EndUpdate();
               // Cursor.Current = Cursors.Default;
            }
                
        }

        private void getCategories(XmlNode node, TreeNode treeNode)
        {
            //Cursor.Current = Cursors.WaitCursor;
            string strCat = "";
            if (node.Attributes["title"] != null)
            {
                strCat = node.Attributes["title"].InnerText;
            }
            else
            {
                strCat = node.Attributes["text"].InnerText;
            }
            XmlNodeList categories = node.SelectNodes("outline[not(@type='link')]");

            if (categories != null)
            {


                foreach (XmlNode category in categories)
                {

                    string strCatTitle = "";
                    if (category.Attributes["title"] != null)
                    {
                        strCatTitle = category.Attributes["title"].InnerText;
                    }
                    else
                    {
                        strCatTitle = category.Attributes["text"].InnerText;
                    }

                    TreeNode catNode = AddNodeToNodeWithText(treeNode, strCatTitle);
                    //TreeNode catNode = treeNode.Nodes.Add(strCatTitle);

                    //catNode.ImageIndex = 0;
                    //catNode.SelectedImageIndex = 2;
                    XmlNodeList opmlEntries = category.SelectNodes("outline[@type='link']");
                    foreach (XmlNode opmlEntry in opmlEntries)
                    {
                        string strTitle = "";
                        if (opmlEntry.Attributes["title"] != null)
                        {
                            strTitle = opmlEntry.Attributes["title"].InnerText;
                        }
                        else
                        {
                            strTitle = opmlEntry.Attributes["text"].InnerText;
                        }
                        TreeNode entry = new TreeNode(strTitle);
                        string strXmlUrl = "";
                        if (opmlEntry.Attributes["xmlUrl"] != null)
                        {
                            strXmlUrl = opmlEntry.Attributes["xmlUrl"].InnerText;
                        }
                        else
                        {
                            strXmlUrl = opmlEntry.Attributes["url"].InnerText;
                        }
                        entry.Tag = strXmlUrl;
                        if (strXmlUrl.Substring(strXmlUrl.LastIndexOf(".") + 1).ToLower() == "opml")
                        {
                            entry.ImageIndex = 0;
                            entry.SelectedImageIndex = 2;
                        }
                        else
                        {
                            entry.ImageIndex = 1;
                            entry.SelectedImageIndex = 1;
                        }
                        AddNodeToNode(catNode, entry);
                        //catNode.Nodes.Add(entry);
                    }

                    getCategories(category, catNode);
                }


            }
            //Cursor.Current = Cursors.Default;
        }
    }

}
