/* RssChannel.cs
 * =============
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

namespace Rss
{
	/// <summary>Grouping of related content items on a site</summary>
	[Serializable()]
	public class RssChannel : RssElement
	{
		private string title = RssDefault.String;
		private string link = RssDefault.String;
		private string description = RssDefault.String;
		private DateTime pubDate = RssDefault.DateTime;
		private DateTime lastBuildDate = RssDefault.DateTime;
		private RssImage image = null;
		private RssItemCollection items = new RssItemCollection();
		/// <summary>Initialize a new instance of the RssChannel class.</summary>
		public RssChannel() {}
		/// <summary>Returns a string representation of the current Object.</summary>
		/// <returns>The channel's title, description, or "RssChannel" if the title and description are blank.</returns>
		public override string ToString()
		{
			if (title != null)
				return title;
			else
				if (description != null)
					return description;
				else
					return "RssChannel";
		}
		/// <summary>The name of the channel</summary>
		/// <remarks>Maximum length is 100 characters (For RSS 0.91)</remarks>
		public string Title
		{
			get { return title; }
			set { title = RssDefault.Check(value); }
		}
		/// <summary>URL of the website named in the title</summary>
		/// <remarks>Maximum length is 500 characters (For RSS 0.91)</remarks>
		public string Link
		{
			get { return link; }
			set { link = RssDefault.Check(value); }
		}
		/// <summary>Description of the channel</summary>
		/// <remarks>Maximum length is 500 characters (For RSS 0.91)</remarks>
		public string Description
		{
			get { return description; }
			set { description = RssDefault.Check(value); }
		}
		
		/// <summary>A link and description for a graphic icon that represent a channel</summary>
		public RssImage Image
		{
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>The publication date for the content in the channel, expressed as the coordinated universal time (UTC)</summary>
		public DateTime PubDate
		{
			get { return pubDate; }
			set { pubDate = value; }
		}
		/// <summary>The date-time the last time the content of the channel changed, expressed as the coordinated universal time (UTC)</summary>
		public DateTime LastBuildDate
		{
			get { return lastBuildDate; }
			set { lastBuildDate = value; }
		}
		/// <summary>All items within the channel</summary>
		public RssItemCollection Items
		{
			get { return items; }
		}
	}
}
