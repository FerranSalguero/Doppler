using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Doppler.Properties;

namespace Doppler
{
    [Serializable()]
    public class HistoryItem
    {
        /// <summary>
        /// The URL of the feed
        /// </summary>
		[XmlElementAttribute(IsNullable = false)]
        public string FeedUrl;
        /// <summary>
        /// The GUID assigned to the feed when it was added
        /// </summary>
        public string FeedGUID;
        /// <summary>
        /// Contains the Hashcode of the RSS Item, used to check for duplicates
        /// </summary>
		[XmlAttribute]
        public int Hashcode;
        /// <summary>
        /// The date the file was downloaded
        /// </summary>
        public string ItemDate;
        /// <summary>
        /// The title of the post
        /// </summary>
        public string Title;
        /// <summary>
        /// The file name of the downloaded file
        /// </summary>
        public string FileName;
   }

}
