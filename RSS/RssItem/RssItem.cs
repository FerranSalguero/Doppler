/* RssItem.cs
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
using System.Collections;
using System.Text;

namespace Rss
{
	/// <summary>A channel may contain any number of items, each of which links to more information about the item, with an optional description</summary>
	[Serializable()]
	public class RssItem : RssElement, IComparable
	{
		private string title = RssDefault.String;
		private string link = RssDefault.String;
		private string description = RssDefault.String;
		private string author = RssDefault.String;
        private string content = RssDefault.String;
	
		private string comments = RssDefault.String;
		private RssEnclosure enclosure = null;
		private RssGuid guid = null;
		private DateTime pubDate = RssDefault.DateTime;
        private DateTime dcDate = RssDefault.DateTime;
		private RssSource source = null;
        private bool read;
        private bool enclosureDownloaded;
		/// <summary>Initialize a new instance of the RssItem class</summary>
		public RssItem() {}
		/// <summary>Returns a string representation of the current Object.</summary>
		/// <returns>The item's title, description, or "RssItem" if the title and description are blank.</returns>
		public override string ToString()
		{
			if (title != null)
				return title;
			else
				if (description != null)
				return description;
			else
				return "RssItem";
		}
		/// <summary>Title of the item</summary>
		/// <remarks>Maximum length is 100 (For RSS 0.91)</remarks>
		public string Title
		{
			get { return title; }
			set { title = RssDefault.Check(value); }
		}
		/// <summary>URL of the item</summary>
		/// <remarks>Maximum length is 500 (For RSS 0.91)</remarks>
		public string Link
		{
			get { return link; }
			set { link = RssDefault.Check(value); }
		}
        /// <summary>Content:encoded</summary>
        /// <remarks>Contains formatted content</remarks>
        public string Content
        {
            get { return content; }
            set { content = RssDefault.Check(value); }
        }

		/// <summary>Item synopsis</summary>
		/// <remarks>Maximum length is 500 (For RSS 0.91)</remarks>
		public string Description
		{
			get { return description; }
			set { description = RssDefault.Check(value); }
		}
		/// <summary>Email address of the author of the item</summary>
		public string Author
		{
			get { return author; }
			set { author = RssDefault.Check(value); }
		}

        public int CompareTo(object obj)
        {
            return this.pubDate.CompareTo(((RssItem)obj).pubDate);
        }
		/// <summary>URL of a page for comments relating to the item</summary>
		public string Comments
		{
			get { return comments; }
			set { comments = RssDefault.Check(value); }
		}
		/// <summary>Describes an items source</summary>
		public RssSource Source
		{
			get { return source; }
			set { source = value; }
		}
		/// <summary>A reference to an attachment to the item</summary>
		public RssEnclosure Enclosure
		{
			get { return enclosure; }
			set { enclosure = value; }
		}
		/// <summary>A string that uniquely identifies the item</summary>
		public RssGuid Guid
		{
			get { return guid; }
			set { guid = value; }
		}
		/// <summary>Indicates when the item was published</summary>
		public DateTime PubDate
		{
			get { return pubDate; }
			set { pubDate = value; }
		}

        public DateTime DcDate
        {
            get { return dcDate; }
            set { dcDate = value; }
        }
        /// <summary>
        /// Indicates if the item was read
        /// </summary>
        public bool Read
        {
            get { return read; }
            set { read = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enclosure downloaded].
        /// </summary>
        /// <value><c>true</c> if [enclosure downloaded]; otherwise, <c>false</c>.</value>
        public bool EnclosureDownloaded
        {
            get { return enclosureDownloaded; }
            set { enclosureDownloaded = value; }
        }

        /// <summary>
        /// Returns a hash code representing a unique identief for this RssItem
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            StringBuilder sb = new StringBuilder(128);
            sb.Append(this.Title).Append(this.Description).Append(this.Link).Append(this.PubDate.ToString());
            return sb.ToString().GetHashCode();
        }
	}
}
