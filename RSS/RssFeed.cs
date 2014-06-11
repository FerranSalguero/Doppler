/* RssFeed.cs
 * ==========
 * 
 * RSS.NET (http://rss-net.sf.net/)
 * Copyright © 2002, 2003 George Tsiokos. All Rights Reserved.
 * 
 * RSS 2.0 (http://blogs.law.harvard.edu/tech/rss)
 * RSS 2.0 is offered by the Berkman Center for Internet & Society at 
 * Harvard Law School under the terms of the Attribution/Share Alike 
 * Creative Commons license.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the 
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
*/
using System;
using System.IO;
using System.Net;
using System.Text;
using System.IO.Compression;

namespace Rss
{
	/// <summary>The contents of a RssFeed</summary>
	[Serializable()]
	public class RssFeed
	{
		private RssChannelCollection channels = new RssChannelCollection();
	
		private ExceptionCollection exceptions = null;
		private DateTime lastModified = RssDefault.DateTime;
		private RssVersion rssVersion = RssVersion.Empty;
		private bool cached = false;
		private string etag = RssDefault.String;
		private string url = RssDefault.String;
		private Encoding encoding = null;
    
		/// <summary>Initialize a new instance of the RssFeed class.</summary>
		public RssFeed() {}
		/// <summary>Initialize a new instance of the RssFeed class with a specified encoding.</summary>
		public RssFeed(Encoding encoding)
		{ 
			this.encoding = encoding;
		}
		/// <summary>Returns a string representation of the current Object.</summary>
		/// <returns>The Url of the feed</returns>
		public override string ToString()
		{
			return url;
		}
        /// <summary>
        /// Returns the hashcode representation for this feed
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            StringBuilder sb = new StringBuilder(64);
            sb.Append(this.Url).Append(this.rssVersion);
            return sb.ToString().GetHashCode();
        }

		/// <summary>The channels that are contained in the feed.</summary>
		public RssChannelCollection Channels
		{
			get { return channels; }
		}
		
		/// <summary>A collection of all exceptions encountered during the reading of the feed.</summary>
		public ExceptionCollection Exceptions
		{
			get { return exceptions == null ? new ExceptionCollection() : exceptions; }
		}
		/// <summary>The Version of the feed.</summary>
		public RssVersion Version
		{
			get { return rssVersion; }
			set { rssVersion = value; }
		}
		/// <summary>The server generated hash of the feed.</summary>
		public string ETag
		{
			get { return etag; }
		}
		/// <summary>The server generated last modfified date and time of the feed.</summary>
		public DateTime LastModified
		{
			get { return lastModified; }
		}
		/// <summary>Indicates this feed has not been changed on the server, and the local copy was returned.</summary>
		public bool Cached
		{
			get { return cached; }
		}
		/// <summary>Location of the feed</summary>
		public string Url
		{
			get { return url; }
		}
		/// <summary>Encoding of the feed</summary>
		public Encoding Encoding	
		{
			get { return encoding; }
			set { encoding = value; }
		}

        /// <summary>
        /// Reads the specified RSS feed
        /// </summary>
        /// <param name="url">The url or filename of the RSS feed</param>
        /// <param name="username">Username associated with the feed, null if none</param>
        /// <param name="password">Password associated with the username, null if none</param>
        /// <returns></returns>
        public static RssFeed Read(string url, string username,string password)
        {
            return read(url, null, null, username, password);
        }

		/// <summary>Reads the specified RSS feed</summary>
		/// <param name="url">The url or filename of the RSS feed</param>
		/// <returns>The contents of the feed</returns>
        /// 
		public static RssFeed Read(string url)
		{
			return read(url, null, null,null,null);
		}
		/// <summary>Reads the specified RSS feed</summary>
		/// <param name="Request">The specified way to connect to the web server</param>
        /// <param name="username">Username associated with the feed, null if none</param>
        /// <param name="password">Password associated with the username, null if none</param>
		/// <returns>The contents of the feed</returns>
		public static RssFeed Read(HttpWebRequest Request, string username, string password)
		{
			return read(Request.RequestUri.ToString(), Request, null, username, password);
		}
		/// <summary>Reads the specified RSS feed</summary>
		/// <param name="oldFeed">The cached version of the feed</param>
        /// <param name="username">Username associated with the feed, null if none</param>
        /// <param name="password">Password associated with the username, null if none</param>
		/// <returns>The current contents of the feed</returns>
		/// <remarks>Will not download the feed if it has not been modified</remarks>
		public static RssFeed Read(RssFeed oldFeed, string username, string password)
		{
			return read(oldFeed.url, null, oldFeed, username, password);
		}
        /// <summary>Reads the specified RSS feed</summary>
        /// <param name="oldFeed">The cached version of the feed</param>
        /// <returns>The current contents of the feed</returns>
        /// <remarks>Will not download the feed if it has not been modified</remarks>
        public static RssFeed Read(RssFeed oldFeed)
        {
            return read(oldFeed.url, null, oldFeed, null,null);
        }
		/// <summary>Reads the specified RSS feed</summary>
		/// <param name="Request">The specified way to connect to the web server</param>
		/// <param name="oldFeed">The cached version of the feed</param>
        /// <param name="username">Username associated with the feed, null if none</param>
        /// <param name="password">Password associated with the username, null if none</param>
		/// <returns>The current contents of the feed</returns>
		/// <remarks>Will not download the feed if it has not been modified</remarks>
		public static RssFeed Read(HttpWebRequest Request, RssFeed oldFeed, string username, string password)
		{
			return read(oldFeed.url, Request, oldFeed, username, password);
		}
		private static RssFeed read(string url, HttpWebRequest request, RssFeed oldFeed, string username, string password)
		{
			// ***** Marked for substantial improvement
			RssFeed feed = new RssFeed();
			RssElement element = null;
			Stream stream = null;
			Uri uri = new Uri(url);
			feed.url = url;
            string ErrorMessage = null;
			switch (uri.Scheme)
			{	
				case "file":
					feed.lastModified = File.GetLastWriteTime(url);
					if ((oldFeed != null) && (feed.LastModified == oldFeed.LastModified))
					{
						oldFeed.cached = true;
						return oldFeed;
					}
					stream = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					break;
				case "https":
					goto case "http";
				case "http":
					if (request == null)
						request = (HttpWebRequest)WebRequest.Create(uri);
					if (oldFeed != null)
					{
						request.IfModifiedSince = oldFeed.LastModified;
						request.Headers.Add("If-None-Match", oldFeed.ETag);
                        request.Headers.Add("Accept-Encoding", "gzip, deflate");
					}
					try
					{
                        if (username != null && password != null)
                        {
                            request.Credentials = new System.Net.NetworkCredential(username, password);
                        }
						HttpWebResponse response = (HttpWebResponse)request.GetResponse();
						feed.lastModified = response.LastModified;
						feed.etag = response.Headers["ETag"];
						try 
						{ 
							if (response.ContentEncoding != "")
								feed.encoding = Encoding.GetEncoding(response.ContentEncoding); 
						}
						catch {}
						//stream = response.GetResponseStream();
                        stream = GetResponseStream(response);
					}
					catch (WebException we)
					{

                        if (oldFeed != null)
                        {
                            oldFeed.cached = true;
                            return oldFeed;
                        }
                        else
                        {
                            ErrorMessage = we.Message;
                        }
                        //else throw we; // bad
					}
					break;
			}
            if (ErrorMessage == null)
            {
                if (stream != null)
                {
                    RssReader reader = null;
                    try
                    {
                        reader = new RssReader(stream);
                        //do
                        //{
                            element = reader.ReadXPath();
                            //element = reader.Read();
                            if (element is RssChannel)
                                feed.Channels.Add((RssChannel)element);
                        //}
                        //while (element != null);
                        feed.rssVersion = reader.Version;
                    }
                    finally
                    {
                        feed.exceptions = reader.Exceptions;
                        reader.Close();
                    }
                }
                else
                    if (ErrorMessage != null)
                    {
                        throw new ApplicationException(ErrorMessage);
                    }
                    else
                    {
                        throw new ApplicationException("Invalid Url");
                    }
            }
            else
            {
                throw new ApplicationException(ErrorMessage);
            }
			return feed;
		}
		
        //public void Write(Stream stream)
        //{
        //    RssWriter writer;
			
        //    if (encoding == null)
        //        writer = new RssWriter(stream);
        //    else
        //        writer = new RssWriter(stream, encoding);
        //    write(writer);
        //}
		
        //public void Write(string fileName)
        //{
        //    RssWriter writer = new RssWriter(fileName);
        //    write(writer);
        //}
        //private void write(RssWriter writer)
        //{
        //    try
        //    {
        //        if (channels.Count == 0)
        //            throw new InvalidOperationException("Feed must contain at least one channel.");
			
        //        writer.Version = rssVersion;

        //        writer.Modules = modules;

        //        foreach(RssChannel channel in channels)
        //        {
        //            if (channel.Items.Count == 0)
        //                throw new InvalidOperationException("Channel must contain at least one item.");

        //            writer.Write(channel);
        //        }
        //    }
        //    finally
        //    {
        //        if (writer != null)
        //            writer.Close();
        //    }
        //}

        /// <summary>
        /// Returns a response stream, optionally decompressed
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static Stream GetResponseStream(HttpWebResponse response)
        {
            Stream compressedStream = null;

            // select right decompression stream (or null if content is not compressed)
            if (response.ContentEncoding == "gzip")
            {
                compressedStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            }
            else if (response.ContentEncoding == "deflate")
            {
                compressedStream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
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
