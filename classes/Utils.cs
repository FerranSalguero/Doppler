using System;
using iTunesLib;
using WMPLib;
using System.Net;
using System.Xml;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using Doppler.Properties;

using System.Resources;
using System.Globalization;
using Doppler.languages;
using System.Xml.Serialization;
using Rss;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing;
using Microsoft.Win32;
using DopplerControls;
using ID3;


namespace Doppler
{
	/// <summary>
	/// Summary description for doppler.
	/// </summary>
	/// 
	public delegate void RetrieverShowConversionProgressHandler (string strGUID, int intImage, int intMinimum, int intMaximum, int intProgress, string strStatus);
	public delegate void RetrieverConversionFinishedHandler (string strGUID, string strStatus, int intImageIndex);

	public class Utils : IDisposable
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public bool isDisposed = false;

        public static bool CheckForLatestVersion()
        {
            net.dopplerradio.update.Update updateWS = new global::Doppler.net.dopplerradio.update.Update();
            net.dopplerradio.update.DopplerVersion latestDopplerVersion = updateWS.GetLatestVersion();
            Version latestVersion = new Version(latestDopplerVersion.Major, latestDopplerVersion.Minor, latestDopplerVersion.Build, latestDopplerVersion.Revision);
            Version thisVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (latestVersion.CompareTo(thisVersion) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
        /// <summary>
        /// Create OPML from the existing feed subscriptions
        /// </summary>
        /// <param name="AddBlogBridgeTags">if true will add the BlogBridge specific tags</param>
        /// <returns>XmlDocument containing valid OPML</returns>
        ///
        public static XmlDocument GetOPML()
        {
            XmlNode xmlNode;
            // export the feeds as an OPML file including categories
            XmlDocument xmlDoc = new XmlDocument();

            xmlNode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDoc.AppendChild(xmlNode);

            XmlElement xmlOPML = xmlDoc.CreateElement("opml");
            XmlAttribute xmlOPMLVersion = xmlDoc.CreateAttribute("version");
            xmlOPMLVersion.Value = "1.1";
            xmlOPML.Attributes.Append(xmlOPMLVersion);
            xmlDoc.AppendChild(xmlOPML);

            XmlElement xmlHead = xmlDoc.CreateElement("head");
            XmlElement xmlHeaderTitle = xmlDoc.CreateElement("title");

            xmlHead.AppendChild(xmlHeaderTitle);
            xmlHeaderTitle.InnerText = "Doppler Subscribed Feeds";
            xmlOPML.AppendChild(xmlHead);

            XmlElement xmlBody = xmlDoc.CreateElement("body");

            // first get the uncategorized feeds
            foreach (FeedItem feedItem in Settings.Default.Feeds)
            {
                if (feedItem.Category == "" || feedItem.Category == null)
                {
                    XmlElement xmlFeed = xmlDoc.CreateElement("outline");

                    XmlAttribute xmlFeedType = xmlDoc.CreateAttribute("type");
                    xmlFeedType.Value = "rss";
                    XmlAttribute xmlFeedText = xmlDoc.CreateAttribute("text");
                    xmlFeedText.Value = feedItem.Title;
                    XmlAttribute xmlFeedUrl = xmlDoc.CreateAttribute("xmlUrl");
                    xmlFeedUrl.Value = feedItem.Url;
                    XmlAttribute xmlTitle = xmlDoc.CreateAttribute("title");
                    xmlTitle.Value = feedItem.Title;

                    xmlFeed.Attributes.Append(xmlFeedType);
                    xmlFeed.Attributes.Append(xmlFeedText);
                    xmlFeed.Attributes.Append(xmlFeedUrl);
                    xmlFeed.Attributes.Append(xmlTitle);
                    xmlBody.AppendChild(xmlFeed);
                }
            }

            foreach (string strCategory in Settings.Default.Feeds.OpmlCategories)
            {
                XmlElement xmlCategory = xmlDoc.CreateElement("outline");
                XmlAttribute xmlCategoryTitle = xmlDoc.CreateAttribute("text");
                xmlCategoryTitle.Value = strCategory;
                xmlCategory.Attributes.Append(xmlCategoryTitle);
                xmlBody.AppendChild(xmlCategory);
                foreach (FeedItem feedItem in Settings.Default.Feeds.Feeds(strCategory))
                {
                    XmlElement xmlFeed = xmlDoc.CreateElement("outline");

                    XmlAttribute xmlFeedType = xmlDoc.CreateAttribute("type");
                    xmlFeedType.Value = "rss";
                    XmlAttribute xmlFeedText = xmlDoc.CreateAttribute("text");
                    xmlFeedText.Value = feedItem.Title;
                    XmlAttribute xmlFeedUrl = xmlDoc.CreateAttribute("xmlUrl");
                    xmlFeedUrl.Value = feedItem.Url;
                    XmlAttribute xmlTitle = xmlDoc.CreateAttribute("title");
                    xmlTitle.Value = feedItem.Title;
                    
                    xmlFeed.Attributes.Append(xmlFeedType);
                    xmlFeed.Attributes.Append(xmlFeedText);
                    xmlFeed.Attributes.Append(xmlFeedUrl);
                    xmlFeed.Attributes.Append(xmlTitle);
                    xmlCategory.AppendChild(xmlFeed);

                }

            }
            xmlOPML.AppendChild(xmlBody);
            return xmlDoc;
        }

        /// <summary>
        /// Gets the supported itunes extensions.
        /// </summary>
        /// <value>The itunes extensions.</value>
        //public static string[] iTunesExtensions
        //{
        //    get
        //    {
        //        return new string[] { "mp3", "mp4", "wma", "m4a", "m4b", "wav" };
        //    }
        //}

        /// <summary>
        /// Gets the audio extensions.
        /// </summary>
        /// <value>The audio extensions.</value>
        public static string[] AudioExtensions
        {
            get
            {
                return Settings.Default.AudioExtensions.Split(',');
                //return new string[] { "mp3", "mp4", "au", "aac", "m4a", "m4b", "ogg", "wma", "wav", "ogg" };
            }
        }

        /// <summary>
        /// Gets the video extensions.
        /// </summary>
        /// <value>The video extensions.</value>
        public static string[] VideoExtensions
        {
            get
            {
                return Settings.Default.VideoExtensions.Split(',');
                //return new string[] { "mp4", "mpeg", "wmv", "avi", "mpg", "mpeg1" };
            }
        }

        public enum MediaAction
        {
            iTunes,
            WMP,
            Unknown,
            Zune
        }

        public static MediaAction GetMediaAction(string extension)
        {
            MediaAction action = MediaAction.Unknown;
            RegistryKey extensionKey = Registry.ClassesRoot.OpenSubKey(extension);
            if (extensionKey != null)
            {
                string programValue = (string)extensionKey.GetValue("", null);
                if (programValue != null)
                {
                    // find the program associated with it
                    RegistryKey programKey = Registry.ClassesRoot.OpenSubKey(programValue + "\\shell");
                    string defaultAction = (string)programKey.GetValue("", null);
                    if (defaultAction != null)
                    {
                        RegistryKey actionKey = programKey.OpenSubKey(defaultAction + "\\command");
                        string command = (string)actionKey.GetValue("", null);
                        if (command != null)
                        {
                            // iTunes in there?
                            if (command.ToLower().IndexOf("itunes.exe") > 0) action = MediaAction.iTunes;
                            // WMP in there?
                            if (command.ToLower().IndexOf("wmplayer.exe") > 0) action = MediaAction.WMP;
                        }
                    }
                    else
                    {
                        // we might have the Zune software installed
                        if (programKey.ToString().ToLower().IndexOf("zune") > 0) action = MediaAction.Zune;
                    }
                }
            }
            return action;
        }
            
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Utils"/> class.
        /// </summary>
		public Utils()
		{
            //// check if we need to instantiate a iTunes object
            //booliTunesUsed = false;
			
			

            //foreach(ExtensionItem extensionItem in Settings.Default.Extensions)
            //{
            //    if(extensionItem.ITunes)
            //    {
            //        booliTunesUsed = true;
            //    }				
            //}
            //if(booliTunesUsed)
            //{
            //    iitApp = new iTunesAppClass();
            //    iitApp.AppCommandMessageProcessingEnabled = true;
            //}

		}

		~Utils()
		{
			if(!isDisposed)
			{
				Dispose();
			}
			isDisposed = true;
		}


		
		public void Dispose()
		{
            //if(this.iitApp != null) 
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(this.iitApp);
            //    this.iitApp = null;
            //}
		}

		public struct TagItem
		{
			public string Title;
			public string Artist;
			public string Album;
			public string Genre;
			public int TrackCounter;
			public bool boolUseTrackCounter;
		}

        /// <summary>
        /// Gets the cache folder.
        /// </summary>
        /// <returns></returns>
        public static string GetCacheFolder()
        {

            string strCacheDir = GetApplicationFolder() + "\\.cache";
            if (!Directory.Exists(strCacheDir))
            {
                Directory.CreateDirectory(strCacheDir);
            }
            return strCacheDir;
        }

        /// <summary>
        /// Gets the application folder.
        /// </summary>
        /// <returns></returns>
		public static string GetApplicationFolder()
		{
            string strAppDir = Application.LocalUserAppDataPath;
          
			//string strAppDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Doppler";
			if(!Directory.Exists(strAppDir))
			{
				Directory.CreateDirectory(strAppDir);
			}
			return strAppDir;
		}

        public static string GetAppDataFolder()
        {
            string strAppDir = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Doppler";
            if (!Directory.Exists(strAppDir))
            {
                Directory.CreateDirectory(strAppDir);
            }
            return strAppDir;
        }

        /// <summary>
        /// Gets the valid folder path.
        /// </summary>
        /// <param name="strPath">The path.</param>
        /// <returns></returns>
		public static string GetValidFolderPath(string strPath)
		{
            if (strPath != null)
            {
                string strDir = strPath.Replace(":", " ");
                strDir = strDir.Replace("<", " ");
                strDir = strDir.Replace(">", " ");
                strDir = strDir.Replace("\\", " ");
                strDir = strDir.Replace("/", " ");
                strDir = strDir.Replace("*", " ");
                strDir = strDir.Replace("?", " ");
                strDir = strDir.Replace("\"", " ");
                strDir = strDir.Replace("|", " ");
                strDir = strDir.Replace("\n", "");
                strDir = strDir.Replace("\r", "");
                strDir = strDir.Replace(",", " ");
                strDir = strDir.Replace("-", " ");
                strDir = strDir.Replace(":", " ");
                return strDir;
            }
            else
            {
                return "";
            }
		}

        /// <summary>
        /// Gets the name of the valid file.
        /// </summary>
        /// <param name="strPath">The filepath.</param>
        /// <returns></returns>
		public static string GetValidFileName(string strPath)
		{
			string strDir = strPath.Replace(":","");
			strDir = strDir.Replace("<","");
			strDir = strDir.Replace(">","");
			strDir = strDir.Replace("\\","");
			strDir = strDir.Replace("/","");
			strDir = strDir.Replace("*","");
			strDir = strDir.Replace("?","");
			strDir = strDir.Replace("\"","");
			strDir = strDir.Replace("|","");
			strDir = strDir.Replace("\n","");
			strDir = strDir.Replace("\r","");
			strDir = strDir.Replace(",", "");
			strDir = strDir.Replace("-", "");
            strDir = strDir.Replace("?", "");
			return strDir;
		}

        /// <summary>
        /// Applies the space savers.
        /// </summary>
        /// <param name="feedItem">The feed item.</param>
		public void ApplySpaceSavers(FeedItem feedItem)
		{
			//Settings set = new Settings();
			string strDownloadlocation;
			string strPlaylistName;

			if(feedItem.PlaylistName != "")
			{
				strPlaylistName = feedItem.PlaylistName;
			} 
			else 
			{
				strPlaylistName = feedItem.Title;
			}
			strDownloadlocation = Settings.Default.DownloadLocation+"\\"+GetValidFolderPath(feedItem.Title);
			// spacesavers?
			try 
			{

				if(feedItem.UseSpaceSavers)
				{
					if(feedItem.Spacesaver_Size > 0)
					{
						#region spacesaver_maxMb code
						// apply the max Mb spacesaver
						// check the size of the folder
						System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strDownloadlocation);
						System.IO.FileInfo[] fileInfo = dirInfo.GetFiles();
						long longTotalSize = 0;
						foreach (System.IO.FileInfo fileInfoItem in fileInfo)
						{
							longTotalSize += fileInfoItem.Length;
						}
						while((longTotalSize / 1024 / 1024) > Convert.ToInt64(feedItem.Spacesaver_Files))
						{
							// folder grew to big
							System.IO.FileInfo oldestFile = null;
							foreach (System.IO.FileInfo fileInfoItem in fileInfo)
							{
								if(oldestFile == null)
								{
									oldestFile = fileInfoItem;
								} 
								else 
								{
									if(oldestFile.CreationTime > fileInfoItem.CreationTime)
									{
										oldestFile = fileInfoItem;
									}
								}
							}
							if(oldestFile != null)
							{
								// remove the oldest file
								//retr.RemoveFromPlaylist(strPlaylistName, oldestFile.FullName);
								System.IO.File.Delete(oldestFile.FullName);
							}
							fileInfo = dirInfo.GetFiles();
							longTotalSize = 0;
							foreach (System.IO.FileInfo fileInfoItem in fileInfo)
							{
								longTotalSize += fileInfoItem.Length;
							}
						}
						#endregion
					}
					if(feedItem.Spacesaver_Files > 0)
					{
						#region spacesaver_maxFiles code
						System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strDownloadlocation);
						System.IO.FileInfo[] fileInfo = dirInfo.GetFiles();
													
											
						while(fileInfo.Length > feedItem.Spacesaver_Files)
						{
							// folder grew to big
							System.IO.FileInfo oldestFile = null;
							foreach (System.IO.FileInfo fileInfoItem in fileInfo)
							{
								if(oldestFile == null)
								{
									oldestFile = fileInfoItem;
								} 
								else 
								{
									if(oldestFile.CreationTime > fileInfoItem.CreationTime)
									{
										oldestFile = fileInfoItem;
									}
								}
							}
							if(oldestFile != null)
							{
								// remove the oldest file
								//retr.RemoveFromPlaylist(strPlaylistName, oldestFile.FullName);
								System.IO.File.Delete(oldestFile.FullName);
							}
							fileInfo = dirInfo.GetFiles();
						}
						#endregion
					}	
					if(feedItem.Spacesaver_Days > 0)
					{
						#region spacesaver_ageDays code
						System.DateTime dateNow = DateTime.Now;
						System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strDownloadlocation);
						System.IO.FileInfo[] fileInfo = dirInfo.GetFiles();
						foreach (System.IO.FileInfo fileInfoItem in fileInfo)
						{
							DateTime dateAgo = dateNow.AddDays(-Convert.ToInt16(feedItem.Spacesaver_Days));
							DateTime dateFile = fileInfoItem.LastWriteTime;
															
							if(dateFile <= dateAgo)
							{
								//retr.RemoveFromPlaylist(strPlaylistName, fileInfoItem.FullName);
								System.IO.File.Delete(fileInfoItem.FullName);
							}
						}
													
												
						#endregion
					}
				}
			} 
			catch (Exception)
			{
				//	log.logMsg(e.Message,true,"Spacesaver");
			}
		}

        /// <summary>
        /// Gets the data folder.
        /// </summary>
        /// <value>The data folder.</value>
        public static string DataFolder
        {
         
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Doppler";
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public static Rss.RssFeed GetFeed(FeedItem feedItem)
        {
            return GetFeed(feedItem, false);
        }

        /// <summary>
        /// Gets the RSS feed.
        /// </summary>
        /// <param name="feedItem">The feed item.</param>
        /// <returns></returns>
        public static Rss.RssFeed GetFeed(FeedItem feedItem, bool OnlyCache)
        {
            Rss.RssFeed rssFeed = null;
            Rss.RssFeed rssExistingFeed = null;

            if (feedItem.FeedHashCode != "" && feedItem.FeedHashCode != null && File.Exists(DataFolder + "\\" + feedItem.FeedHashCode + ".bin"))
            {
                try
                {
                    //XmlSerializer ser = new XmlSerializer(typeof(Rss.RssFeed));
                    BinaryFormatter ser = new BinaryFormatter();
                    FileStream stream = File.Open(DataFolder + "\\" + feedItem.FeedHashCode + ".bin", FileMode.Open, FileAccess.Read);
                    rssExistingFeed = (Rss.RssFeed)ser.Deserialize(stream);
                    stream.Close();
                    if (OnlyCache == false)
                    {
                        if(feedItem.Authenticate == true)
                        {
                            rssFeed = Rss.RssFeed.Read(rssExistingFeed, feedItem.Username, feedItem.Password);
                        }
                        else
                        {
                            rssFeed = Rss.RssFeed.Read(rssExistingFeed);
                        }
                        SerializeFeed(rssFeed);
                    }
                    else
                    {
                        rssFeed = rssExistingFeed;
                    }
                }
                catch
                { // something went wrong
                    try
                    {
                        if (feedItem.Authenticate == true)
                        {
                            rssFeed = Rss.RssFeed.Read(feedItem.Url, feedItem.Username, feedItem.Password);
                        }
                        else
                        {
                            rssFeed = Rss.RssFeed.Read(feedItem.Url);
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        if (Settings.Default.LogLevel > 0) log.Error("GetFeed", ex);
                    }
                    SerializeFeed(rssFeed);
                }

            }
            else
            {
                try
                {
                    rssFeed = Rss.RssFeed.Read(feedItem.Url);
                    SerializeFeed(rssFeed);
                }
                catch (ApplicationException ex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error("GetFeed", ex);
                }
                try
                {
                    if (rssFeed != null && !File.Exists(Path.Combine(Utils.DataFolder, rssFeed.GetHashCode().ToString("X") + ".ico")))
                    {
                        GetFavIcon(new Uri(rssFeed.Channels[0].Link), rssFeed.GetHashCode().ToString("X"));
                    }
                }
                catch {  }
                try
                {
                    if (rssFeed != null && !File.Exists(Path.Combine(Utils.DataFolder, rssFeed.GetHashCode().ToString("X") + ".jpg")))
                    {
                        GetFeedImage(new Uri(rssFeed.Channels[0].Image.Url), rssFeed.GetHashCode().ToString("X"));
                    }
                }
                catch { }
                
            }
            if (rssFeed != null)
            {
                Settings.Default.Feeds[feedItem].FeedHashCode = rssFeed.GetHashCode().ToString("X");
            }
            return rssFeed;
        }

        /// <summary>
        /// Deserializes the feed.
        /// </summary>
        /// <param name="feedItem">The feed item.</param>
        /// <returns></returns>
        public static Rss.RssFeed DeserializeFeed(FeedItem feedItem)
        {
            Rss.RssFeed rssExistingFeed = null;
            try
            {
                //XmlSerializer ser = new XmlSerializer(typeof(Rss.RssFeed));
				string fileToOpen = String.Format("{0}\\{1}.bin", DataFolder, feedItem.FeedHashCode);

				if (File.Exists(fileToOpen))
				{
					BinaryFormatter ser = new BinaryFormatter();
					FileStream stream = File.Open(fileToOpen, FileMode.Open, FileAccess.Read);
					rssExistingFeed = (Rss.RssFeed)ser.Deserialize(stream);
					stream.Close();
				}
            }
            catch { }
            return rssExistingFeed;
        }

        /// <summary>
        /// Serializes the feed.
        /// </summary>
        /// <param name="rssFeed">The RSS feed.</param>
        public static void SerializeFeed(Rss.RssFeed rssFeed)
        {
            try
            {
                BinaryFormatter ser = new BinaryFormatter();

                //    XmlSerializer ser = new XmlSerializer(typeof(Rss.RssFeed));
                if (rssFeed != null)
                {
                    FileStream stream = File.Create(DataFolder + "\\" + rssFeed.GetHashCode().ToString("X") + ".bin");
                    ser.Serialize(stream, rssFeed);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("An error occurred while saving the feed to the local cache:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Gets the favicon.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="FeedHashCode">The feed hash code.</param>
        private static void GetFavIcon(Uri url, string FeedHashCode)
        {
            // string strReturn = null;
            // Icon icoReturn = null;
            Stream remoteStream = null;
            Stream localStream = null;
            HttpWebResponse resp = null;
            HttpWebRequest req;
            try
            {
                string strPath = Utils.DataFolder;
                req = (HttpWebRequest)WebRequest.Create(String.Format("http://{0}/favicon.ico", url.Host));
                resp = (HttpWebResponse)req.GetResponse();
                remoteStream = resp.GetResponseStream();
                localStream = File.Create(Path.Combine(strPath, FeedHashCode + ".ico"));
                byte[] buffer = new byte[resp.ContentLength];

                int bytesRead;
                do
                {
                    bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                    localStream.Write(buffer, 0, bytesRead);


                    remoteStream.Flush();

                } while (bytesRead > 0);
                localStream.Close();

            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
            finally
            {
                if (resp != null) resp.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
            //return icoReturn;
            //return bmpReturn;
        }


        private static bool ThumbnailCallback()
        {
            return false;
        }


        private static void GetFeedImage(Uri url, string FeedHashCode)
        {

            Stream remoteStream = null;
            HttpWebResponse resp = null;
            HttpWebRequest req;
            try
            {
                string strPath = Utils.DataFolder;
                req = (HttpWebRequest)WebRequest.Create(url.ToString());
                resp = (HttpWebResponse)req.GetResponse();
                remoteStream = resp.GetResponseStream();

                byte[] buffer = new byte[resp.ContentLength];


                //remoteStream.Read(buffer, 0, buffer.Length);
                Bitmap bitmap = new Bitmap(remoteStream);
                remoteStream.Close();
                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                Image thumb = bitmap.GetThumbnailImage(45, 45, myCallback, IntPtr.Zero);
                thumb.Save(Path.Combine(strPath, FeedHashCode + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception)
            {
            }
            finally
            {
                if (resp != null) resp.Close();
                if (remoteStream != null) remoteStream.Close();
            }
        }

        public static void RewriteMP3Tags(DownloadItem item)
        {
            string localFileName = item.Filename;

            if (File.Exists(localFileName))
            {
                try
                {
                    ID3Info id3Info = new ID3Info(localFileName, true);
                    string strTitle = id3Info.ID3v2Info.GetTextFrame("TIT2");
                    string strGenre = id3Info.ID3v2Info.GetTextFrame("TCON");
                    string strArtist = id3Info.ID3v2Info.GetTextFrame("TPE1");
                    string strAlbum = id3Info.ID3v2Info.GetTextFrame("TALB");
                    if (item.TagTitle != null && item.TagTitle != "") strTitle = ParseMediaTags(item.TagTitle, item, id3Info);
                    if (item.TagGenre != null && item.TagGenre != "") strGenre = ParseMediaTags(item.TagGenre, item, id3Info);
                    if (item.TagArtist != null && item.TagArtist != "") strArtist = ParseMediaTags(item.TagArtist, item, id3Info);
                    if (item.TagAlbum != null && item.TagAlbum != "") strAlbum = ParseMediaTags(item.TagAlbum, item, id3Info);
                    id3Info.ID3v2Info.HaveTag = true;
                    id3Info.ID3v2Info.SetMinorVersion(3);
         
                    id3Info.ID3v2Info.SetTextFrame("TIT2", strTitle);
                    id3Info.ID3v2Info.SetTextFrame("TCON", strGenre);
                    id3Info.ID3v2Info.SetTextFrame("TPE1", strArtist);
                    id3Info.ID3v2Info.SetTextFrame("TALB", strAlbum);
                    id3Info.Save();
                }
                catch (Exception ex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error(ex);
                }
            }
        }

        private static string ParseMediaTags(string strTag, DownloadItem item, ID3Info id3Info)
        {
            strTag = strTag.Replace("%feedname%", item.FeedTitle);
            strTag = strTag.Replace("%feedtitle%", item.FeedTitle);
            strTag = strTag.Replace("%url%", item.FeedUrl);
            strTag = strTag.Replace("%playlist%", item.FeedPlaylist);
            strTag = strTag.Replace("%artist%", id3Info.ID3v2Info.GetTextFrame("TPE1"));
            strTag = strTag.Replace("%album%", id3Info.ID3v2Info.GetTextFrame("TALB"));
            strTag = strTag.Replace("%genre%", id3Info.ID3v2Info.GetTextFrame("TCON"));
            strTag = strTag.Replace("%date%", DateTime.Now.ToString("yyyy-MM-dd"));
            strTag = strTag.Replace("%time%", DateTime.Now.ToString("HH:mm:ss"));
            strTag = strTag.Replace("%y%", DateTime.Now.Year.ToString());
            strTag = strTag.Replace("%m%", DateTime.Now.Month.ToString());
            strTag = strTag.Replace("%d%", DateTime.Now.Day.ToString());
            strTag = strTag.Replace("%posttitle%", item.PostTitle);
            System.IO.FileInfo fileInfo = new FileInfo(item.Filename);
            strTag = strTag.Replace("%file%", fileInfo.Name);
            return strTag;
        }
	}

	public struct W3CDateTime
	{
		private DateTime dtime;
		private TimeSpan ofs;

		public W3CDateTime (DateTime dt, TimeSpan off)
		{
			ofs = off;
			dtime = dt;
		}

		public DateTime UtcTime
		{
			get { return dtime; }
		}

		public DateTime DateTime
		{
			get { return dtime + ofs; }
		}

		public TimeSpan UtcOffset
		{
			get { return ofs; }
		}

		// Format is "R" (RFC822) or "W" (W3C)
		public string ToString(string format)
		{
			string strReturn = "";
			switch (format)
			{
				case "R" :
					strReturn = (dtime + ofs).ToString("ddd, dd MMM yyyy HH:mm:ss ") + FormatOffset(ofs, "");
					break;
				case "W" :
					strReturn = (dtime + ofs).ToString("yyyy-MM-ddTHH:mm:ss") + FormatOffset(ofs, ":");
					break;
				default:
					throw new ArgumentException("Unrecognized date format requested.");
					
			}
			return strReturn;
		}

		private static string FormatOffset(TimeSpan ofs, string separator)
		{
			string s = string.Empty;
			if (ofs >= TimeSpan.Zero)
				s = "+";
			return s + ofs.Hours.ToString("00") + separator + ofs.Minutes.ToString("00");
		}

		static public W3CDateTime Parse(string s)
		{
			const string Rfc822DateFormat = 
					  @"^((Mon|Tue|Wed|Thu|Fri|Sat|Sun), *)?(?<day>\d\d?) +" +
					  @"(?<month>Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec) +" +
					  @"(?<year>\d\d(\d\d)?) +" +
					  @"(?<hour>\d\d):(?<min>\d\d)(:(?<sec>\d\d))? +" +
					  @"(?<ofs>([+\-]?\d\d\d\d)|UT|GMT|EST|EDT|CST|CDT|MST|MDT|PST|PDT)$";
			const string W3CDateFormat = 
					  @"^(?<year>\d\d\d\d)" +
					  @"(-(?<month>\d\d)(-(?<day>\d\d)(T(?<hour>\d\d):(?<min>\d\d)(:(?<sec>\d\d)(?<ms>\.\d+)?)?" +
					  @"(?<ofs>(Z|[+\-]\d\d:\d\d)))?)?)?$"; 

			string combinedFormat = string.Format(
				@"(?<rfc822>{0})|(?<w3c>{1})", Rfc822DateFormat, W3CDateFormat);

			// try to parse it
			Regex reDate = new Regex(combinedFormat);
			Match m = reDate.Match(s);
			if (!m.Success)
			{
				// Didn't match either expression. Throw an exception.
				throw new FormatException("String is not a valid date time stamp.");
			}
			try
			{
				bool isRfc822 = m.Groups["rfc822"].Success;
				int year = int.Parse(m.Groups["year"].Value);
				// handle 2-digit and 3-digit years
				if (year < 1000)
				{
					if (year < 50) year = year + 2000; else year = year + 1999;
				}
    
				int month;
				if (isRfc822)
					month = ParseRfc822Month(m.Groups["month"].Value);
				else
					month = (m.Groups["month"].Success) ? int.Parse(m.Groups["month"].Value) : 1;

				int day = m.Groups["day"].Success ? int.Parse(m.Groups["day"].Value) : 1;
				int hour = m.Groups["hour"].Success ? int.Parse(m.Groups["hour"].Value) : 0;
				int min = m.Groups["min"].Success ? int.Parse(m.Groups["min"].Value) : 0;
				int sec = m.Groups["sec"].Success ? int.Parse(m.Groups["sec"].Value) : 0;
				int ms = m.Groups["ms"].Success ? (int)Math.Round((1000*double.Parse(m.Groups["ms"].Value))) : 0;

				TimeSpan ofs = TimeSpan.Zero;
				if (m.Groups["ofs"].Success)
				{
					if (isRfc822)
						ofs = ParseRfc822Offset(m.Groups["ofs"].Value);
					else
						ofs = ParseW3COffset(m.Groups["ofs"].Value);
				}
				// datetime is stored in UTC
				return new W3CDateTime(new DateTime(year, month, day, hour, min, sec, ms)-ofs, ofs);
			}
			catch (Exception ex)
			{
				throw new FormatException("String is not a valid date time stamp.", ex);
			}
		}

		private static readonly string[] MonthNames = new string[]
	{
		"Jan", "Feb", "Mar", "Apr", "May", "Jun", 
		"Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

		private static int ParseRfc822Month(string monthName)
		{
			for (int i = 0; i < 12; i++)
			{
				if (monthName == MonthNames[i])
				{
					return i+1;
				}
			}
			throw new ApplicationException("Invalid month name");
		}

		private static TimeSpan ParseRfc822Offset(string s)
		{
			if (s == string.Empty)
				return TimeSpan.Zero;
			int hours = 0;
			switch (s)
			{
				case "UT":
				case "GMT":
					break;
				case "EDT": hours = -4; break;
				case "EST": 
				case "CDT": hours = -5; break;
				case "CST": 
				case "MDT": hours = -6; break;
				case "MST":
				case "PDT": hours = -7; break;
				case "PST": hours = -8; break;
				default:
					if (s[0] == '+')
					{
						string sfmt = s.Substring(1, 2) + ":" + s.Substring(3, 2);
						return TimeSpan.Parse(sfmt);
					}
					else
						return TimeSpan.Parse(s.Insert(s.Length-2, ":"));
			}
			return TimeSpan.FromHours(hours);
		}

		private static TimeSpan ParseW3COffset(string s)
		{
			if (s == string.Empty || s == "Z")
				return TimeSpan.Zero;
			else
			{
				if (s[0] == '+')
					return TimeSpan.Parse(s.Substring(1));
				else
					return TimeSpan.Parse(s);
			}
		}
	}
	

}
