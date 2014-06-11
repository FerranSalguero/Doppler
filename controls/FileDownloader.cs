using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections;
using Doppler.languages;
using DopplerControls;
using System.IO.Compression;
using Doppler.Properties;

namespace Doppler.Controls
{
    public delegate void DownloadCompleteHandler(DownloadItem item, ListViewItem lvi);
    public delegate void DownloadProgressHandler(DownloadItem item, int Min, int Max, int Value, string Status, string ETA, ListViewItem lvi);
    public delegate void DownloadErrorHandler(DownloadItem item, ListViewItem lvi, string Message, Exception ex);
    public delegate void DownloadAbortedHandler(DownloadItem item, ListViewItem lvi);

    /// <summary>
    /// Provides a FileDownloader
    /// </summary>
    class FileDownloader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event DownloadCompleteHandler DownloadComplete;
        public event DownloadProgressHandler DownloadProgress;
        public event DownloadErrorHandler DownloadError;
        public event DownloadAbortedHandler DownloadAborted;

        public bool boolAbort = false;
        public bool paused = false;
        DownloadItem downloadItem;
        ListViewItem listViewItem;
        private int intTimeoutRetry;
        private string filename;
        private Hashtable hashTags;
        /// <summary>
        /// Initializes the FileDownloader
        /// </summary>
        /// <param name="listViewItemIn">Reference to the ListViewItem which will be updated</param>
        /// <param name="downloadItemIn"></param>
        public FileDownloader(ListViewItem listViewItemIn, DownloadItem downloadItemIn)
        {
            listViewItem = listViewItemIn;
            hashTags = (Hashtable)listViewItem.Tag;
            downloadItem = downloadItemIn;
            filename = downloadItem.Filename;
            //strFilename = downloadItem.Filename;
        }

        public void DownloadFile(Object stateInfo)
        {
            long maxBytes = downloadItem.MaxBytes;
            int intStep = 100 * 1024;
            int intCounter = 0;

            int bytesProcessed = 0;

            string ProgressStatus = "";
            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;

            WebResponse response = null;
            bool boolRetry = true;
            while (boolRetry && intTimeoutRetry < 10)
            {

                boolRetry = false;
                // Use a try/catch/finally block as both the WebRequest and Stream
                // classes throw exceptions upon error
                try
                {
                    // Create a request for the specified remote file name

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(downloadItem.Url);
                    request.ProtocolVersion = HttpVersion.Version11;


                    //	WebRequest request = WebRequest.Create(remoteFilename);

                    if (downloadItem.Username != "")
                    {
                        request.Credentials = new NetworkCredential(downloadItem.Username, downloadItem.Password);
                    }
                    ((HttpWebRequest)request).UserAgent = "Doppler " + Application.ProductVersion;
                    if (downloadItem.UseProxy)
                    {

                        if (downloadItem.UseIEProxy == true)
                        {
                            request.Proxy = WebRequest.DefaultWebProxy;
                        }
                        else
                        {
                            WebProxy proxy = new WebProxy(downloadItem.ProxyServer, int.Parse(downloadItem.ProxyPort));

                            if (downloadItem.ProxyAuthentication == true)
                            {
                                proxy.Credentials = new NetworkCredential(downloadItem.ProxyUsername, downloadItem.ProxyPassword);
                            }
                            request.Proxy = proxy;
                        }
                    }

                    WebHeaderCollection webHeaderCollection = request.Headers;
                    webHeaderCollection.Add("Pragma", "no-cache");
                    webHeaderCollection.Add("Cache-Control", "no-cache");
                    webHeaderCollection.Add("Accept-Encoding", "gzip, deflate");
                    request.Pipelined = true;
                    request.KeepAlive = true;
                    int intLength = 0;

                    if ((System.IO.File.Exists(filename) || System.IO.File.Exists(filename + ".incomplete")) && downloadItem.DownloadSize > 0)
                    {
                        System.IO.FileInfo fileInfo;
                        // file exists try byte-ranging
                        if (System.IO.File.Exists(filename))
                        {
                            fileInfo = new System.IO.FileInfo(filename);
                        }
                        else
                        {
                            fileInfo = new System.IO.FileInfo(filename + ".incomplete");
                        }
                        intLength = Convert.ToInt32(fileInfo.Length);

                        int intRange = Convert.ToInt32(downloadItem.DownloadSize) - intLength;

                        //MessageBox.Show(intRange.ToString());
                        if (downloadItem.ByteRanging)
                        {
                            request.AddRange(-intRange);
                        }
                        //request.AddRange(intLength,Convert.ToInt32(longDownloadsize));
                        //((HttpWebRequest)request).AddRange(intLength,Convert.ToInt32(longDownloadsize));
                    }


                    request.Timeout = downloadItem.TimeOut;

                    if (request != null)
                    {
                        request.Method = "GET";
                        response = request.GetResponse();
                        
                        if (response != null)
                        {
                            // Once the WebResponse object has been retrieved,
                            // get the stream object associated with the response's data

                            if (maxBytes == 0)
                            {
                                maxBytes = response.ContentLength;
                            }

                            if (maxBytes <= response.ContentLength)
                            {
                                remoteStream = GetResponseStream((HttpWebResponse)response);

                                //remoteStream = response.GetResponseStream()
                                // Create the local file
                                try
                                {

                                    if (intLength > 0 && maxBytes <= response.ContentLength)
                                    {
                                        localStream = File.OpenWrite(filename + ".incomplete");
                                        localStream.Seek(Convert.ToInt64(intLength), System.IO.SeekOrigin.Begin);
                                    }
                                    else
                                    {
                                        localStream = File.Create(filename + ".incomplete");
                                    }
                                }

                                catch (Exception)
                                {
                                    //Console.Error.WriteLine(ex.Message);
                                    //log.logMsg(ex.Message + ", while downloading " + remoteFilename, true, "Retriever");
                                    localStream.Close();
                                    localStream = File.Create(filename + ".incomplete");
                                }

                                // Allocate a 1k buffer or a buffer of a different size if set
                                byte[] buffer;
                                if (downloadItem.BufferSize == 0)
                                {
                                    buffer = new byte[1024*10];
                                }
                                else
                                {
                                    buffer = new byte[downloadItem.BufferSize];
                                }


                                string strFile = (new System.IO.FileInfo(filename)).Name;

                                long longKb = (response.ContentLength + Convert.ToInt64(intLength)) / 1024;

                                string strDecodedFile = System.Web.HttpUtility.UrlDecode(strFile);

                                int bytesProcessedKb = 0;
                                int bytesRead;
                                if (intLength > 0 && maxBytes <= response.ContentLength)
                                {
                                    bytesProcessed = intLength;
                                }
                                if (downloadItem.ByteRanging == false)
                                {
                                    bytesProcessed = 0;
                                }
                                int intImageCounter = 0;

                                if (Settings.Default.LogLevel > 1)
                                {
                                    if (bytesProcessed > 0)
                                    {
                                        log.Info("Continueing download: " + downloadItem.Filename);
                                    }
                                    else
                                    {
                                       log.Info("Starting download: " + downloadItem.Filename);
                                    }
                                }
                                long startTicks = DateTime.Now.Ticks;
                                int currentBytesProcessed = 0;
                                do
                                {
                                    while (paused)
                                    { // do nothing, just pause
                                        
                                    }
                                    bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                                    localStream.Write(buffer, 0, bytesRead);

                                    bytesProcessed += bytesRead;
                                    currentBytesProcessed += bytesRead;
                                    if (intCounter > intStep)
                                    {
                                        if (intImageCounter < 9)
                                        {
                                            intImageCounter++;
                                        }
                                        else
                                        {
                                            intImageCounter = 0;
                                        }
                                        intCounter = 0;
                                        
                                        if (response.ContentLength > 0)
                                        {
                                            //string strStatus = bytesProcessedKb.ToString() + " / " + longKb.ToString() + " KB - " + strDecodedFile;

                                            string finishedIn = "UNK";
                                            try
                                            {
                                                long currentTicks = DateTime.Now.Ticks;
                                                long ticksPerBlock = currentTicks - startTicks;
                                                long ticksPerByte = ticksPerBlock / Convert.ToInt64(currentBytesProcessed);
                                                long totalTicks = startTicks + (ticksPerByte * (response.ContentLength));
                                                TimeSpan timeSpan = new TimeSpan(totalTicks - currentTicks);
                                                finishedIn = String.Format("{0}:{1}{2}", timeSpan.Minutes, ((timeSpan.Seconds < 10) ? "0" : ""), (timeSpan.Seconds > 0) ? timeSpan.Seconds : 0);
                                            }
                                            catch { }

											ProgressStatus = GetStatusText(longKb, bytesProcessedKb);
                                           
                                            DownloadProgress(downloadItem, 0, Convert.ToInt32(response.ContentLength) + intLength, bytesProcessed, ProgressStatus, finishedIn, listViewItem);
                                        }
                                    }
                                    else
                                    {
                                        intCounter += bytesRead;
                                    }
                                    bytesProcessedKb = bytesProcessed / 1024;
                                    remoteStream.Flush();
                                } while (bytesRead > 0 && boolAbort == false);
                                if (Settings.Default.LogLevel > 1) log.Info("Finished download: " + downloadItem.Filename);

                                if (response != null) response.Close();
                                if (remoteStream != null) remoteStream.Close();
                                if (localStream != null) localStream.Close();
                                // remove the '.incomplete' extension if it wasn't aborted
                                if (boolAbort == false)
                                {
                                    System.IO.File.Move(filename + ".incomplete", filename);
                                }
                            }
                        }

                    }

                    if (boolAbort == false)
                    {
                        DownloadComplete(downloadItem, listViewItem);
                    }
                    else
                    {
                        DownloadAborted(downloadItem, listViewItem);
                    }

                }
                catch (ThreadAbortException)
                {
                    // thread aborted
                    if (Thread.CurrentThread.ThreadState != System.Threading.ThreadState.AbortRequested)
                    {
                        DownloadAborted(downloadItem, listViewItem);
                    }
                }
                catch (WebException e)
                {
                    //Console.Error.WriteLine(e.Message);
                    if (e.Status == System.Net.WebExceptionStatus.Timeout || e.Message.ToLower().StartsWith("parameter name: count") || e.Message.ToLower().StartsWith("Non-negative number"))
                    {
                        // retry the download
                        boolRetry = true;
                        intTimeoutRetry++;

                        maxBytes = 0;
                        Thread.Sleep(new System.TimeSpan(0, 0, 5 * intTimeoutRetry));
                        int intRetrySeconds = intTimeoutRetry * 5;
                        //log.logMsg(e.Message + ", while downloading " + remoteFilename +". Retry " + timeoutRetry.ToString() + " of 10 after " + intRetrySeconds.ToString() + " seconds.", true, "Retriever");
                       // Thread.Sleep(new System.TimeSpan(0, 0, 0, 5 * intTimeoutRetry, 0));
                    }
                    else
                    {
                        if (e.Status == WebExceptionStatus.ProtocolError)
                        {
                            log.Error("Protocol error, removing temporary file and retrying", e);
                            boolRetry = true;
                            intTimeoutRetry++;
                            Thread.Sleep(new System.TimeSpan(0, 0, 5 * intTimeoutRetry));
                            if (File.Exists(filename + ".incomplete"))
                            {
                                File.Delete(filename + ".incomplete");
                            }
                        }
                        else
                        {

                            DownloadError(downloadItem, listViewItem, String.Format(FormStrings.xWhileDownloadingy, e.Message, downloadItem.Url),e);
                        }
                        //	boolError = true;
                        //log.logMsg(e.Message + ", while downloading " + remoteFilename, true, "Retriever");
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.ToLower().StartsWith("parameter: count") || e.Message.ToLower().StartsWith("non-negative number"))
                    {
                        boolRetry = true;
                        intTimeoutRetry++;

                        maxBytes = 0;
                        Thread.Sleep(new System.TimeSpan(0, 0, 5 * intTimeoutRetry));
                        int intRetrySeconds = intTimeoutRetry & 5;
                    }
                    else
                    {
                        if (Settings.Default.LogLevel > 0) log.Error("Error while downloading from " + downloadItem.Url, e);
                        DownloadError(downloadItem, listViewItem, String.Format(FormStrings.xWhileDownloadingy, e.Message, downloadItem.Url),e);
                        //Console.Error.WriteLine(e.Message);
                        //boolError = true;
                        //log.logMsg(e.Message + ", while downloading " + remoteFilename, true, "Retriever");
                    }
                }
                finally
                {
                    //	fMain.notifyIcon1.Icon = new Icon(typeof(frmMain), "SystemTray.ico");
                    // Close the response and streams objects here 
                    // to make sure they're closed even if an exception
                    // is thrown at some point
                    if (response != null) response.Close();
                    if (remoteStream != null) remoteStream.Close();
                    if (localStream != null) localStream.Close();

                    //	fMain.notifyIcon1.Icon = new Icon(typeof(frmMain), "SystemTray.ico");
                    //	lvi.SubItems[1].ImageIndex = intOldImage;
                    //	lvi.SubItems[3].ForceText = true;
                    //	lvi.SubItems[4].Text = "";
                }
            }
            // Return total bytes processed to caller.

            //return bytesProcessed;

        }

		private static string GetStatusText(long longKb, int bytesProcessedKb)
		{
			string status = String.Empty;
			double bytesProcessedMB, longMB;

			if (bytesProcessedKb > 1024)
			{
				bytesProcessedMB = (double)bytesProcessedKb / 1024;
				longMB = longKb / 1024;
				status = String.Format("{0:0.0} MB / {1:0.0} MB", bytesProcessedMB, longMB);
			}
			else if (longKb > 1024)
			{
				longMB = (double)longKb / 1024;
				status = String.Format("{0} KB / {1:0.0} MB", bytesProcessedKb, longMB);
			}
			else
			{
				status = String.Format("{0} KB / {1} KB", bytesProcessedKb.ToString(), longKb.ToString());
			}
			return status;
		}



		private static Stream GetResponseStream(HttpWebResponse response)
        {
            Stream compressedStream = null;

            // select right decompression stream (or null if content is not compressed)
            if (response.ContentEncoding == "gzip")
            {
                compressedStream = new GZipStream(response.GetResponseStream(),CompressionMode.Decompress);
            }
            else if (response.ContentEncoding == "deflate")
            {
                compressedStream = new DeflateStream(response.GetResponseStream(),CompressionMode.Decompress);
            }

            if (compressedStream != null)
            {
                // decompress
                MemoryStream decompressedStream = new MemoryStream();

                int size = 2048;
                byte[] writeData = new byte[2048];
                while (true)
                {
                    size = compressedStream.Read(writeData, 0, size);
                    if (size > 0)
                    {
                        decompressedStream.Write(writeData, 0, size);
                    }
                    else
                    {
                        break;
                    }
                }
                decompressedStream.Seek(0, SeekOrigin.Begin);
                return decompressedStream;
            }
            else
                return response.GetResponseStream();
        }
    }
}
