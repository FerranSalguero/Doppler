
using System;
using System.Threading;
using System.IO;
using System.Xml;
using System.Net;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using Doppler.Properties;
using System.Resources;
using Doppler.languages;
using Rss;
using System.Globalization;


namespace Doppler
{
	/// <summary>
	/// Summary description for Retriever.
	/// </summary>
	///

	public delegate void RetrieveCompleteHandler( FeedItem feedItem, bool boolSuccess );
    public delegate void RetrieverSingleFileCompleteHandler (FeedItem feedItem, DownloadPackage downloadPackage);
	public delegate void RetrieverShowProgressHandler (string strGUID, int intImage, int intMinimum, int intMaximum, int intProgress, string strStatus);
	public delegate void RetrieverDownloadFinishedHandler (string strGUID, string strStatus, int intImageIndex);
	public delegate void RetrieverSetFeedStatusHandler (ListViewItem lvi, int intStatus, string strPubDate, string strStatus);
	public delegate void TorrentFoundHandler(FeedItem feedItem, string URL);
	public delegate void FileFoundHandler(FeedItem feedItem, string URL, long DownloadSize, string strFilename, Rss.RssItem rssItem, bool ByteRanging);

	public class Retriever : IDisposable
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Utils utils;
		public bool boolError;
        private ListViewItem lvi;
        public bool TemporaryFeed;
		FeedItem feedItem;
		const int BUFFER_SIZE = 2048;
     
        bool isDisposed;
		
		public event RetrieveCompleteHandler RetrieveCompleteCallback;
		public event RetrieverSetFeedStatusHandler SetFeedStatus;
		public event FileFoundHandler FileFound;
        private bool Scheduled;


        public Retriever(FeedItem feedItemIn, ListViewItem lviIn, bool ScheduledIn)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Culture);
   
            feedItem = feedItemIn;
            
            boolError = false;
            lvi = lviIn;
            Scheduled = ScheduledIn;
        }

		public Retriever(FeedItem feedItemIn,  ListViewItem lviIn)
		{
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Culture);
            feedItem = feedItemIn;
            
            boolError = false;
            lvi = lviIn;
            Scheduled = false;
        }

		~Retriever()
		{
			if(!isDisposed)
			{
				Dispose();
			}
			
		}

		public void Dispose()
		{
			if(utils != null)
			{
				utils.Dispose();
				utils = null;
			}
			isDisposed = true;
			
			feedItem = null;
		}

		public class RequestState
		{
			// This class stores the state of the request.
			const int BUFFER_SIZE = 2048;
			
			public byte[] bufferRead;
			public WebRequest request;
			public WebResponse response;
			public Stream responseStream;
			public Stream writeStream;
			public RequestState()
			{
				bufferRead = new byte[BUFFER_SIZE];
				request = null;
				responseStream = null;
			}
		}

		
        public void ParseItem()
        {
            ParseItem(null);
        }

        public void ParseItem(Object stateInfo)
		{
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Culture);
            string strLocation = null;

			utils = new Utils();

			bool boolSuccess = true;

			try 
			{
                if(SetFeedStatus != null) SetFeedStatus(lvi,1,"","");
				
				string strURL = feedItem.Url;
				// \ / : * ? " < > |
				string strDir = Utils.GetValidFolderPath(feedItem.Title);

                if (feedItem.OverrideDownloadsFolder)
                {
                    strLocation = feedItem.DownloadsFolder;
                }
                else
                {
                    strLocation = Settings.Default.DownloadLocation + "\\" + strDir;
                }
                if (!Directory.Exists(strLocation))
                {
					try
					{
						Directory.CreateDirectory(strLocation);
					}
					catch (DirectoryNotFoundException ex)
					{
						if (Settings.Default.LogLevel > 1) log.Error("Error creating directory", ex);
						boolError = true;
						boolSuccess = false;
						return;
					}
                }
				string strPubdateOld = feedItem.Pubdate;
				
				if(feedItem.Url.ToLower().StartsWith("http://") || feedItem.Url.ToLower().StartsWith("https://"))
				{
						ParseRss(feedItem,strLocation);
				} 
				string strPlaylistName;
				if(feedItem.PlaylistName != null && feedItem.PlaylistName != "")
				{
					strPlaylistName = feedItem.PlaylistName;
				} 
				else 
				{
					strPlaylistName = feedItem.Title;
				}		
			} 
			catch (ThreadAbortException)
			{
                if (Settings.Default.LogLevel > 1) log.Info("Feed retrieval of " + feedItem.Title + " aborted");
				boolSuccess = false;
			}
			finally 
			{
				utils.Dispose();
				string strPubDate = "";
				string strStatus = "";
				int intStatus;
				int intImageIndex;
				if(feedItem.Pubdate != null && feedItem.Pubdate.Trim() != "")
				{
					strPubDate = feedItem.Pubdate;
				} 
				else 
				{
					strPubDate = "-new-";
				}
				
				if(boolError)
				{
					intStatus = 2;
					if(Settings.Default.LogLevel > 0)
					{
						//lvi.SubItems[4].Text = "An error occured. Please check the log file";
						strStatus = FormStrings.AnerroroccuredPleasecheckthelogfile;
					} 
					else 
					{

						strStatus = FormStrings.AnerroroccuredEnablelogginganddoanewretrieve;
						//lvi.SubItems[4].Text = "An error occured. Enable logging and do a new retrieve";
					}

				//	lvi.SubItems[4].ForeColor = System.Drawing.Color.Red;
				} 
				else 
				{
					intStatus = 3;
				}
				intImageIndex = feedItem.Source;
	
				Settings.Default.Feeds[feedItem.GUID] = feedItem;
				if(SetFeedStatus != null) SetFeedStatus(lvi,intStatus,strPubDate,strStatus);
				RetrieveCompleteCallback(feedItem, boolSuccess);
			}
		}

        public void ParseTemporaryRss(Object stateInfo)
        {
            DownloadPackage downloadPackage = new DownloadPackage();
            Rss.RssChannel rssChannel = (Rss.RssChannel)stateInfo;
            string strDir = Utils.GetValidFolderPath(feedItem.Title);

            string strDownloadlocation;
            if (feedItem.OverrideDownloadsFolder)
            {
                strDownloadlocation = feedItem.DownloadsFolder;
            }
            else
            {
                strDownloadlocation = Settings.Default.DownloadLocation + "\\" + strDir;
            }
            if (!Directory.Exists(strDownloadlocation))
            {
                Directory.CreateDirectory(strDownloadlocation);
            }
            try
            {
                try
                {
                    foreach (Rss.RssItem rssItem in rssChannel.Items)
                    {
                        if (rssItem.Enclosure != null)
                        {
                            bool validUri = false;
                            Uri uri = null;
                            try
                            {
                                uri = new Uri(rssItem.Enclosure.Url);
                                validUri = true;
                            }
                            catch (UriFormatException ex)
                            {
                                boolError = true;
                                if (Settings.Default.LogLevel > 0) log.Error(String.Format("Invalid enclosure url for {0} ({1})", feedItem.Title, rssItem.Enclosure.Url), ex);
                            }
                            if (validUri)
                            {
                                string strPath = GetValidFilename(uri.LocalPath.Substring(uri.LocalPath.LastIndexOf("/") + 1));
                                string strFilename = Path.Combine(strDownloadlocation, strPath);
                                if (!Directory.Exists(strDownloadlocation))
                                {
                                    Directory.CreateDirectory(strDownloadlocation);
                                }

                                downloadPackage = GetDownloadPackage(rssItem, feedItem, strDownloadlocation);
                                long longDownloadsize = downloadPackage.DownloadSize;
                                
                                if (downloadPackage.strFilename != null)
                                {
                                    strFilename = downloadPackage.strFilename;
                                }

                                if (longDownloadsize > 0)
                                {
                                    if (feedItem.Authenticate == true)
                                    {
                                        string strPassword = EncDec.Decrypt(feedItem.Password, feedItem.Username);
                                        FileFound(feedItem, rssItem.Enclosure.Url, longDownloadsize, downloadPackage.strFilename, rssItem,downloadPackage.ByteRanging);
                                    } else {
                                        FileFound(feedItem, rssItem.Enclosure.Url, longDownloadsize, downloadPackage.strFilename, rssItem,downloadPackage.ByteRanging);
                                    }
                                }
                            }
                        }
                        //RetrieverSingleFileComplete(feedItem, downloadPackage);
                        RetrieveCompleteCallback(feedItem, true);
                    }
                }
                catch (WebException wex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error("Retriever", wex);
                }

            }
            catch (ThreadAbortException)
            {
                //MessageBox.Show("TA");
            }

        }

        private void ParseRss(FeedItem feedItem, string strDownloadlocation)
        {
            log4net.NDC.Push("ParseRss");
            try
            {
                //RssReader rssReader = new RssReader(feedItem,false,null);

                //rssReader.RdfMode = false;

                if (SetFeedStatus != null) SetFeedStatus(lvi, 1, feedItem.Pubdate, FormStrings.RetrievingRSS);
                //RssFeed feed = rssReader.Retrieve();
                try
                {

                    Rss.RssFeed feed = Utils.GetFeed(feedItem);

                    if (feed != null)
                    {
                        // first clean up the history
                        CleanHistory(feedItem, feed);

                        // set the description of the feed


                        //if ( feed.ErrorMessage == null || feed.ErrorMessage == "" )
                        //{
                        if (feed.Exceptions.Count == 0)
                        {

                            //RssItems items = feed.Items;
                            //int intItems = items.Count;

                            int intItemCount = 0;
                            //for(int q=0;q<intItems;q++)
                            //{
                            feed.Channels[0].Items.Sort();
                            foreach (Rss.RssItem rssItem in feed.Channels[0].Items)
                            {
                                if (SetFeedStatus != null) SetFeedStatus(lvi, 1, feedItem.Pubdate, "Parsing items");
                                //hist.ReRead();
                                //Application.DoEvents();
                                //RssItem rssItem = items[q];


                                #region // Default : Enclosures
                                //if(rssItem.Enclosures != null)
                                //{
                                if (rssItem.Enclosure != null)
                                {
                                    if (intItemCount < feedItem.RetrieveNumberOfFiles || feedItem.RetrieveNumberOfFiles == 0)
                                    {
                                        intItemCount++;

                                        //    EnclosureItem enc = rssItem.Enclosures[y];
                                        bool validUri = false;
                                        System.Uri uri = null;
                                        try
                                        {

                                            uri = new Uri(rssItem.Enclosure.Url);
                                            validUri = true;
                                        }
                                        catch (UriFormatException ex)
                                        {
                                            boolError = true;
                                            if (Settings.Default.LogLevel > 0) log.Error(String.Format("Invalid enclosure url for {0} ({1})", feedItem.Title, rssItem.Enclosure.Url), ex);
                                        }
                                        if (validUri)
                                        {
                                            // check if the enclosure is already in the history
                                            if (Settings.Default.History[rssItem.GetHashCode().ToString()] == null)
                                            {
                                                string strPath = GetValidFilename(uri.LocalPath.Substring(uri.LocalPath.LastIndexOf("/") + 1));
                                                string strFilename = Path.Combine(strDownloadlocation, strPath);

                                                if (!Directory.Exists(strDownloadlocation))
                                                {
													try
													{
														Directory.CreateDirectory(strDownloadlocation);
													}
													catch (DirectoryNotFoundException ex)
													{
														if (Settings.Default.LogLevel > 1) log.Error("Error creating directory", ex);
														boolError = true;
														return;
													}
                                                }

                                                DownloadPackage downloadPackage = GetDownloadPackage(rssItem, feedItem, strDownloadlocation);
                                                long longDownloadsize = downloadPackage.DownloadSize;

                                                if (downloadPackage.strFilename != null)
                                                {
                                                    strFilename = downloadPackage.strFilename;
                                                }

                                                if (longDownloadsize > 0)
                                                {
                                                    if (feedItem.Authenticate == true)
                                                    {
                                                        string strPassword = EncDec.Decrypt(feedItem.Password, feedItem.Username);
                                                        FileFound(feedItem, rssItem.Enclosure.Url, longDownloadsize, downloadPackage.strFilename, rssItem,downloadPackage.ByteRanging);
                                                    }
                                                    else
                                                    {

                                                        FileFound(feedItem, rssItem.Enclosure.Url, longDownloadsize, downloadPackage.strFilename, rssItem,downloadPackage.ByteRanging);
                                                    }
                                                }

                                                // update the FeedItem with an last update date and the description
                                                feedItem.Pubdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                if (feed.Channels[0].Description != null)
                                                {
                                                    feedItem.Description = feed.Channels[0].Description;
                                                }
                                                Settings.Default.Feeds[feedItem.GUID] = feedItem;

                                            }
                                        }
                                    }
                                }

                                #endregion


                            }
                        }

                    }
                }
                catch (WebException wex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error("Retriever", wex);
                }

            }
            catch (ThreadAbortException)
            {
                //MessageBox.Show("TA");
            }
            log4net.NDC.Pop();
        }

		private static void CleanHistory(FeedItem feedItem, Rss.RssFeed feed)
		{
            if (feed != null)
            {
                if (feed.Channels.Count > 0)
                {
                    ArrayList arrayHistoryList = Settings.Default.History.GetItemsByFeedGUID(feedItem.GUID);
                    foreach (HistoryItem historyItem in arrayHistoryList)
                    {
                        bool boolFound = false;
                        foreach (Rss.RssItem rssItem in feed.Channels[0].Items)
                        {
                            if (rssItem.GetHashCode() == historyItem.Hashcode)
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        if (boolFound == false)
                        {
                            //remove the entry from the historylist
                            Settings.Default.History.Remove(historyItem);
                        }
                    }
                }
            }
		}

        private static string GetValidFilename(string strFilename)
        {
            char[] charInvalidPathChars = Path.GetInvalidPathChars();
            foreach (char charInvalid in charInvalidPathChars)
            {
                strFilename = strFilename.Replace(charInvalid, ' ');
            }
            char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
            foreach (char charInvalid in charInvalidFileChars)
            {
                strFilename = strFilename.Replace(charInvalid, ' ');
            }
            return strFilename;
        }


	
		private WebResponse GetWebResponseObjectHEAD(string remoteFilename, string strUsername, string strPassword)
		{
			HttpWebResponse response = null;
			HttpWebRequest request = null;
			
			if(SetFeedStatus != null) SetFeedStatus(lvi,1,feedItem.Pubdate,string.Format(FormStrings.Determiningsizeofx,remoteFilename));
					
			try 
			{
				request = WebRequest.Create(remoteFilename) as HttpWebRequest;
				if (request == null)
				{
					if (Settings.Default.LogLevel > 0) log.Error("Retrieving the size of " + remoteFilename);
					return response;
				}

				if(strUsername != "")
				{
					request.Credentials = new NetworkCredential(strUsername,strPassword);
				}
				request.Method = "HEAD";
				request.Pipelined = true;
	
				request.UserAgent = "Doppler " + Application.ProductVersion;
			
				if(Settings.Default.UseProxy)
				{
					
					if(Settings.Default.UseIEProxy == true)
					{
                        request.Proxy = WebRequest.DefaultWebProxy;
					} 
					else 
					{
                        
						WebProxy proxy = new WebProxy(Settings.Default.ProxyServer,int.Parse(Settings.Default.ProxyPort));

                       
						if(Settings.Default.ProxyAuthentication == true)
						{
							proxy.Credentials = new NetworkCredential(Settings.Default.ProxyUsername, Settings.Default.ProxyPassword);
						}
						request.Proxy = proxy;
					}
				}
				request.Timeout = Settings.Default.TimeOut;
				response = (HttpWebResponse) request.GetResponse();
				response.Close();
			} 
			catch (WebException ex)
			{
                if (Settings.Default.LogLevel > 0) log.Error("Retrieving the size of " + remoteFilename, ex);
			}
			finally 
			{
				if (response != null) response.Close();
			}
			
			return response;
		}

		private WebResponse GetWebResponseObjectGET(string remoteFilename, string strUsername, string strPassword)
		{
			Settings set = new Settings();
			HttpWebResponse response = null;
			HttpWebRequest request = null;
			
			if(SetFeedStatus != null) SetFeedStatus(lvi,1,feedItem.Pubdate,String.Format(FormStrings.Determiningsizeofx,remoteFilename));
					
			//ErrorLogWriter Err=new ErrorLogWriter(Directory.GetCurrentDirectory()+@"\DopplerError.xml");
			//Console.SetError(Err);
			//long longDownloadsize = 0;
			try 
			{
				request = WebRequest.Create(remoteFilename) as HttpWebRequest;
				if (request == null)
				{
					boolError = true;
					if (Settings.Default.LogLevel > 0) log.Error("Retrieving the size of " + remoteFilename);
					return response;
				}
				//	request.MaximumResponseHeadersLength = 4;
				
				if(strUsername != "")
				{
					request.Credentials = new NetworkCredential(strUsername,strPassword);
				}
				
				request.Method = "GET";
				request.Pipelined = true;
			//	request.MaximumAutomaticRedirections = 5;

				request.UserAgent = "Doppler " + Application.ProductVersion;
				
				//WebHeaderCollection webHeaderCollection = request.Headers;
				//webHeaderCollection.Add("Pragma","no-cache");
				//webHeaderCollection.Add("Cache-Control","no-cache");

				if(Settings.Default.UseProxy)
				{
					
					if(Settings.Default.UseIEProxy == true)
					{
						request.Proxy = WebRequest.DefaultWebProxy;
					} 
					else 
					{
						WebProxy proxy = new WebProxy(Settings.Default.ProxyServer,int.Parse(Settings.Default.ProxyPort));

						if(Settings.Default.ProxyAuthentication == true)
						{
							proxy.Credentials = new NetworkCredential(Settings.Default.ProxyUsername, Settings.Default.ProxyPassword);
						}
						request.Proxy = proxy;
					}
				}
				request.Timeout = Settings.Default.TimeOut;
				response = (HttpWebResponse) request.GetResponse();
				response.Close();
			} 
			catch (WebException ex)
			{
				boolError = true;
				//	response = new WebResponse();
                if (Settings.Default.LogLevel > 0) log.Error("Retrieving the size of " + remoteFilename, ex);
			} 
			finally 
			{
				if (response != null) response.Close();
			}
			
			return response;
		}
		

		private DownloadPackage GetDownloadPackage(Rss.RssItem rssItem, FeedItem feedItem, string strDownloadlocation)
		{
            bool boolAcceptableFile = false;
            bool byteRanging = true;
            string strFilenameWithoutExt = null;
            string strFilenameExt = null;
            string strPath = null;
            DirectoryInfo dirInfo = null;
            FileInfo[] fileInfo = null;
            long longReturn = 0;
            //bool boolGuid = false;

            string strFilename = null;

            // new 
            WebResponse response = null;

            // first try a HEAD call (less intrusive)
            if (feedItem.Authenticate == true)
            {

                string strPassword = EncDec.Decrypt(feedItem.Password, feedItem.Username);
                response = GetWebResponseObjectHEAD(rssItem.Enclosure.Url, feedItem.Username, strPassword);
            }
            else
            {
                response = GetWebResponseObjectHEAD(rssItem.Enclosure.Url, "", "");
            }
           

            // the HEAD call didn't seem to work. We'll use a GET now
            if (response == null)
            {
                if(feedItem.Authenticate == true)
                {
						string strPassword = EncDec.Decrypt(feedItem.Password,feedItem.Username);
						response = GetWebResponseObjectGET(rssItem.Enclosure.Url,feedItem.Username,strPassword);
					} 
					else 
					{
                        response = GetWebResponseObjectGET(rssItem.Enclosure.Url, "", "");
					}
				}
			
				if(response != null)
				{
					long longDownloadsize = response.ContentLength;
					if(longDownloadsize == -1)
					{
						longDownloadsize = 1;
					}

                    
					WebHeaderCollection responseHeaders = response.Headers;
                    string[] strAcceptRange = responseHeaders.GetValues("Accept-Ranges");
                    if (strAcceptRange != null && strAcceptRange[0] == "none")
                    {
                        // no byte ranging
                        byteRanging = false;
                    }

                    // check if there is content-disposition header
					string[] strContDisp = responseHeaders.GetValues("content-disposition");
					string strAttachment = "";
					string strHeader = "";
					if(strContDisp != null && strContDisp.Length > 0)
					{
						for(int l=0;l<strContDisp.Length;l++)
						{
							strHeader = strContDisp[l];
							if(strHeader.ToLower().StartsWith("attachment"))
							{
								// attachment header
                               
                                    strAttachment = strHeader.Substring(strHeader.ToLower().IndexOf("filename=") + 9);
                               
							}
						}
					}
					if(strAttachment != "")
					{
                        
                        if (feedItem.UseTitleForFiles)
                        {
                            FileInfo f = new FileInfo(strAttachment);
                            strPath = Utils.GetValidFileName(rssItem.Title + f.Extension);
                        }
                        else
                        {
                            strPath = strAttachment;
                            strPath = Utils.GetValidFileName(strPath);
                        }
						strFilename = strDownloadlocation + "\\" + strPath;
                        if (strFilename.IndexOf(".") > 0)
                        {
                            FileInfo f = new FileInfo(strFilename);
                            strFilenameWithoutExt = f.FullName.Substring(0, f.FullName.Length - f.Extension.Length);
                            //strFilenameWithoutExt = strFilename.Substring(0, strFilename.LastIndexOf("."));
                            strFilenameExt = f.Extension.Substring(1);
                            //strFilenameExt = strFilename.Substring(strFilename.LastIndexOf(".") + 1);
                        }
                        else
                        {
                            strFilenameWithoutExt = strFilename;
                            strFilenameExt = "";
                        }
						
					} 
					else 
					{
                        try
                        {
                            Uri uriEnclosure = new Uri(rssItem.Enclosure.Url);
                            string strEnclosureUrl = uriEnclosure.GetLeftPart(UriPartial.Path);

                            if (feedItem.UseTitleForFiles)
                            {
                                strPath = strEnclosureUrl.Substring(strEnclosureUrl.LastIndexOf("/") + 1);
                                FileInfo f = new FileInfo(strPath);
                                strPath = Utils.GetValidFileName(rssItem.Title + f.Extension);
                            }
                            else
                            {
                                strPath = strEnclosureUrl.Substring(strEnclosureUrl.LastIndexOf("/") + 1);
                            }
                            if (strPath == "")
                            {
                                // check the query
                                strEnclosureUrl = uriEnclosure.GetLeftPart(UriPartial.Query);
                                if (feedItem.UseTitleForFiles)
                                {
                                    strPath = strEnclosureUrl.Substring(strEnclosureUrl.LastIndexOf("/") + 1);
                                    FileInfo f = new FileInfo(strPath);
                                    strPath = Utils.GetValidFileName(rssItem.Title + f.Extension);
                                }
                                else
                                {
                                    strPath = strEnclosureUrl.Substring(strEnclosureUrl.LastIndexOf("/") + 1);
                                }
                            }
                                // empty path? not good. Generate one

                            //strPath = System.Web.HttpUtility.UrlDecode(strPath);
                            strFilename = strDownloadlocation + "\\" + strPath;
                            FileInfo fileInfo1 = new FileInfo(strFilename);
                            strFilenameWithoutExt = fileInfo1.FullName.Substring(0, fileInfo1.FullName.Length - fileInfo1.Extension.Length);
                            //strFilenameWithoutExt = strFilename.Substring(0, strFilename.LastIndexOf("."));
                            strFilenameExt = fileInfo1.Extension.Substring(1);
                            //strFilenameExt = strFilename.Substring(strFilename.LastIndexOf(".") + 1);
                            //strFilenameWithoutExt = strFilename.Substring(0, strFilename.LastIndexOf("."));
                            //strFilenameExt = strFilename.Substring(strFilename.LastIndexOf(".") + 1);
                        } catch
                        {
                            strFilename = "";
                            strFilenameExt = "";
                            strFilenameWithoutExt = "";
                            boolAcceptableFile = false;
                        }
					}

                    if (Settings.Default.DefaultMediaAction == 0)
                    {
                        boolAcceptableFile = true;
                    }
                    else
                    {

                        foreach (string extension in Utils.AudioExtensions)
                        {
                            if (extension.ToUpper() == strFilenameExt.ToUpper())
                            {
                                boolAcceptableFile = true;
                                break;
                            }
                        }
                        if (!boolAcceptableFile)
                        {
                            // check if it is a video file
                            foreach (string extension in Utils.VideoExtensions)
                            {
                                if (extension.ToUpper() == strFilenameExt.ToUpper())
                                {
                                    boolAcceptableFile = true;
                                    break;
                                }
                            }
                        }
                    }

                    if(boolAcceptableFile)
					{
						try
						{
							dirInfo = new System.IO.DirectoryInfo(strDownloadlocation);

							fileInfo = dirInfo.GetFiles(strPath);				
						} 
						catch (Exception fex)
						{
                            if (Settings.Default.LogLevel > 0) log.Error("Retriever", fex);
							strFilenameExt = "";
						}
				
				
						// check if the file is available on the filesystem
						bool boolContinue = true;
						if(fileInfo.Length > 0)
						{	
							if((fileInfo.Length > 0 && fileInfo[0].Length != longDownloadsize))
							{
								// there is a file with the same name
								switch(Settings.Default.DuplicateAction)
								{
									case 1 :
										strFilename = strFilenameWithoutExt + DateTime.Now.ToString("yyyyMMddTHHMMss")+ "." + strFilenameExt;
										boolContinue = true;
										break;
									default :
										boolContinue = false;
										break;
								}
							}
                            else if (fileInfo.Length > 0)
                            {
                                // add the item to the history
                                HistoryItem historyItem = new HistoryItem();
                                historyItem.FeedGUID = feedItem.GUID;
                                historyItem.FeedUrl = feedItem.Url;
                                historyItem.Title = rssItem.Title;
                                historyItem.Hashcode = rssItem.GetHashCode();
                                //historyItem.LocalFilename = fileInfo[0].FullName;
                                historyItem.ItemDate = fileInfo[0].CreationTime.ToString("yyyy-MM-dd HH:MM:ss");
                                historyItem.FileName = fileInfo[0].Name;
                                //historyItem.URL = enc.EnclosureURL;
                                Settings.Default.History.Add(historyItem);
                                boolContinue = false;
                            }
                            else
                            {
                                boolContinue = false;
                            }
						} 
						if(boolContinue)
						{			
							// did the user specify a text filter on the item?
							if(feedItem.Textfilter != null && feedItem.Textfilter != "")
							{				
								System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(feedItem.Textfilter);
								if(regEx.Match(rssItem.Description).Success || regEx.Match(rssItem.Title).Success)
								{
									//	if(rssItem.Description.ToUpper().IndexOf(feedItem.textFilter.ToUpper()) >= 0 || rssItem.Title.ToUpper().IndexOf(feedItem.textFilter.ToUpper()) >= 0)							
									//	{
									longReturn = longDownloadsize;
								} 
								else if(rssItem.Description.ToUpper().IndexOf(feedItem.Textfilter.ToUpper()) >= 0 || rssItem.Title.ToUpper().IndexOf(feedItem.Textfilter.ToUpper()) >= 0)
								{
									longReturn = longDownloadsize;
								}
							} 
							else 
							{
								longReturn = longDownloadsize;
							}
						}
					}
			}
			DownloadPackage downloadPackage = new DownloadPackage();
            downloadPackage.ByteRanging = byteRanging;
			downloadPackage.DownloadSize = longReturn;
			downloadPackage.strFilename = strFilename;
			return downloadPackage;
		}
	}

	public struct DownloadPackage
	{
		public long DownloadSize;
		public string strFilename;
        public bool ByteRanging;
	}

	
}
