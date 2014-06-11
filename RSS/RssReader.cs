/* RssReader.cs
 * ============
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
using System.Xml;
using System.Text;
using System.IO;

namespace Rss
{
    /// <summary>Reads an RSS file.</summary>
    /// <remarks>Provides fast, non-cached, forward-only access to RSS data.</remarks>
    public class RssReader
    {
        // TODO: Add support for modules

        private Stack xmlNodeStack = new Stack();
        private StringBuilder elementText = new StringBuilder();
        private XmlTextReader reader = null;
        private bool wroteChannel = false;
        private RssVersion rssVersion = RssVersion.Empty;
        private ExceptionCollection exceptions = new ExceptionCollection();
        private RssImage image = null;
        private RssChannel channel = null;
        private RssEnclosure enclosure = null;
        private RssGuid guid = null;
        private RssItem item = null;

        private void InitReader()
        {
            reader.WhitespaceHandling = WhitespaceHandling.None;
            reader.XmlResolver = null;
        }

        #region Constructors

        /// <summary>Initializes a new instance of the RssReader class with the specified URL or filename.</summary>
        /// <param name="url">The URL or filename for the file containing the RSS data.</param>
        /// <exception cref="ArgumentException">Occures when unable to retrieve file containing the RSS data.</exception>
        public RssReader(string url)
        {
            try
            {
                reader = new XmlTextReader(url);
                InitReader();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to retrieve file containing the RSS data.", e);
            }
        }

        /// <summary>Creates an instance of the RssReader class using the specified TextReader.</summary>
        /// <param name="textReader">specified TextReader</param>
        /// <exception cref="ArgumentException">Occures when unable to retrieve file containing the RSS data.</exception>
        public RssReader(TextReader textReader)
        {
            try
            {
                reader = new XmlTextReader(textReader);
                InitReader();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to retrieve file containing the RSS data.", e);
            }
        }

        /// <summary>Creates an instance of the RssReader class using the specified Stream.</summary>
        /// <exception cref="ArgumentException">Occures when unable to retrieve file containing the RSS data.</exception>
        /// <param name="stream">Stream to read from</param>
        public RssReader(Stream stream)
        {
            try
            {
                reader = new XmlTextReader(stream);
                InitReader();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Unable to retrieve file containing the RSS data.", e);
            }
        }

        #endregion

        /// <summary>
        /// Read the feed using XPath()
        /// </summary>
        public RssElement ReadXPath()
        {
            try
            {
                // find the rss channel in this feed
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                //  XmlNode body = doc.ChildNodes;

                //if (body != null)
                //{
                foreach (XmlNode feedNode in doc.ChildNodes)
                {
                    switch (feedNode.Name.ToLower())
                    {
                        case "rss":
                            ParseRssTag(feedNode.Attributes);
                            channel = ParseChannel(feedNode.ChildNodes);
                            break;
                    }
                }
                //}
                
            }
            catch (Exception ex)
            {
                string strText = reader.ReadString();
                exceptions.Add(ex);
            }
            return channel;
        }

        
        private RssChannel ParseChannel(XmlNodeList channelBody)
        {
            channel = new RssChannel();
            try
            {
                XmlNodeList channelNodes = channelBody.Item(0).ChildNodes;
                // find the rss channel in this feed
                //XmlDocument doc = new XmlDocument();
                //doc.Load(reader);
                //XmlNode body = doc.DocumentElement.SelectSingleNode("channel");

                //if (body != null)
                //{

                // loop through the items and pick the important ones
                foreach (XmlNode channelItemNode in channelNodes)
                {
                    switch (channelItemNode.Name.ToLower())
                    {
                        case "title":
                            channel.Title = channelItemNode.InnerText;
                            break;
                        case "link":
                            channel.Link = channelItemNode.InnerText;
                            break;
                        case "description":
                            channel.Description = channelItemNode.InnerText;
                            break;
                        case "pubdate":
                            channel.PubDate = ParseDate(channelItemNode.InnerText);
                            break;
                        case "lastbuilddate":
                            channel.LastBuildDate = ParseDate(channelItemNode.InnerText);
                            break;
                        case "image" :
                            if (channelItemNode.ChildNodes.Count > 0)
                            {
                                channel.Image = ParseImage(channelItemNode.ChildNodes);
                            }
                            else
                            {
                                if (channelItemNode.InnerText != null && channelItemNode.InnerText != "")
                                {
                                    RssImage rssImage = new RssImage();
                                    rssImage.Url = channelItemNode.InnerText;
                                    channel.Image = rssImage;
                                }
                            }
                            break;
                        case "item":
                            RssItem item = ParseItem(channelItemNode.ChildNodes);
                            channel.Items.Add(item);
                            break;
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            return channel;
               
        }

        private RssImage ParseImage(XmlNodeList itemNodes)
        {
            RssImage rssImage = new RssImage();
            foreach (XmlNode itemNode in itemNodes)
            {
                switch (itemNode.Name.ToLower())
                {
                    case "link":
                        rssImage.Link = itemNode.InnerText;
                        break;
                    case "url":
                        rssImage.Url = itemNode.InnerText;
                        break;
                    case "title":
                        rssImage.Title = itemNode.InnerText;
                        break;
                    case "description":
                        rssImage.Description = itemNode.InnerText;
                        break;
                    case "height":
                        rssImage.Height = int.Parse(itemNode.InnerText);
                        break;
                    case "width":
                        rssImage.Width = int.Parse(itemNode.InnerText);
                        break;
                }
            }
            return rssImage;
        }

        private void ParseRssTag(XmlAttributeCollection xmlAttributes)
        {
            if (xmlAttributes != null)
            {
                foreach (XmlAttribute itemNode in xmlAttributes)
                {
                    switch (itemNode.Name.ToLower())
                    {
                        case "version":
                            switch (itemNode.InnerText)
                            {
                                case "0.91":
                                    rssVersion = RssVersion.RSS091;
                                    break;
                                case "0.92":
                                    rssVersion = RssVersion.RSS092;
                                    break;
                                case "2.0":
                                    rssVersion = RssVersion.RSS20;
                                    break;
                                default:
                                    rssVersion = RssVersion.NotSupported;
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private RssItem ParseItem(XmlNodeList itemNodes)
        {
            RssItem item = new RssItem();
            foreach (XmlNode itemNode in itemNodes)
            {
                switch (itemNode.Name.ToLower())
                {
                    case "title":
                        item.Title = itemNode.InnerText;
                        break;
                    case "link":
                        item.Link = itemNode.InnerText;
                        break;
                    case "description":
                        item.Description = itemNode.InnerText;
                        break;
                    case "content:encoded":
                        item.Description = itemNode.InnerText;
                        break;
                    case "guid" :
                        item.Guid = ParseGuid(itemNode.Attributes);
                        break;
                    case "pubdate":
                        item.PubDate = ParseDate(itemNode.InnerText);
                        break;
                    case "enclosure":
                        item.Enclosure = ParseEnclosure(itemNode.Attributes);
                        break;
                    case "dc:date":
                        item.PubDate = ParseDcDate(itemNode.InnerText);
                        break;
                }
            }
            return item;
        }

        private RssEnclosure ParseEnclosure(XmlAttributeCollection attributes)
        {
            RssEnclosure enclosure = new RssEnclosure();
            foreach (XmlAttribute itemNode in attributes)
            {
                switch (itemNode.Name.ToLower())
                {
                    case "url":
                        enclosure.Url = itemNode.InnerText;
                        break;
                    case "type":
                        enclosure.Type = itemNode.InnerText;
                        break;
                    case "length":
                        try
                        {
                            enclosure.Length = int.Parse(itemNode.InnerText);
                        }
                        catch (Exception)
                        {
                            enclosure.Length = 0;
                        }
                        break;
                }
            }
            return enclosure;       
        }

        private RssGuid ParseGuid(XmlAttributeCollection attributes)
        {
            RssGuid rssGuid = new RssGuid();
            foreach(XmlAttribute itemNode in attributes)
            {
                switch (itemNode.Name.ToLower())
                {
                    case "permalink" :
                        rssGuid.PermaLink = bool.Parse(itemNode.InnerText);
                        break;
                    case "name" :
                        rssGuid.Name = itemNode.InnerText;
                        break;
                }
            }
             return rssGuid;         
        }

        private DateTime ParseDcDate(string p)
        {
            DateTime date = new DateTime();
            date = new DateTime(int.Parse(p.Substring(0, 4)), int.Parse(p.Substring(5, 2)), int.Parse(p.Substring(8, 2)),0,0,0);
            return date;
        }

        private DateTime ParseDate(string p)
        {
            DateTime date = new DateTime();
            try
            {
                date = W3CDateTime.Parse(p.ToString()).DateTime;
            }
            catch (Exception)
            {
                if (p.ToString() == "")
                {
                    date = DateTime.Now;
                }
                else
                {
                    try
                    {
                        date = DateTime.Parse(p.ToString());
                    }
                    catch (Exception)
                    {
                        try
                        {
                            string tmp = p.ToString();
                            tmp = tmp.Substring(0, tmp.LastIndexOf(" "));
                            tmp += " GMT";
                            date = DateTime.Parse(tmp);
                        }
                        catch {
                            // we have a serious date problem
                            date = DateTime.Now;
                            //exceptions.Add(e);
                        }
                        
                    }
                }
            }
            return date;
        }
        /// <summary>Reads the next RssElement from the stream.</summary>
        /// <returns>An RSS Element</returns>
        /// <exception cref="InvalidOperationException">RssReader has been closed, and can not be read.</exception>
        /// <exception cref="System.IO.FileNotFoundException">RSS file not found.</exception>
        /// <exception cref="System.Xml.XmlException">Invalid XML syntax in RSS file.</exception>
        /// <exception cref="System.IO.EndOfStreamException">Unable to read an RssElement. Reached the end of the stream.</exception>
        public RssElement Read()
        {
            bool readData = false;
            bool pushElement = true;
            RssElement rssElement = null;
            int lineNumber = -1;
            int linePosition = -1;

            if (reader == null)
                throw new InvalidOperationException("RssReader has been closed, and can not be read.");

            do
            {
                pushElement = true;
                try
                {
                    readData = reader.Read();
                }
                catch (System.IO.EndOfStreamException e)
                {
                    throw new System.IO.EndOfStreamException("Unable to read an RssElement. Reached the end of the stream.", e);
                }
                catch (System.Xml.XmlException e)
                {
                    if (lineNumber != -1 || linePosition != -1)
                        if (reader.LineNumber == lineNumber && reader.LinePosition == linePosition)
                            throw exceptions.LastException;

                    lineNumber = reader.LineNumber;
                    linePosition = reader.LinePosition;

                    exceptions.Add(e); // just add to list of exceptions and continue :)
                }
                if (readData)
                {
                    string readerName = reader.Name.ToLower();
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                if (reader.IsEmptyElement && reader.AttributeCount == 0)
                                    break;
                                elementText = new StringBuilder();

                                switch (readerName)
                                {
                                    case "item":
                                        // is this the end of the channel element? (absence of </channel> before <item>)
                                        if (!wroteChannel)
                                        {
                                            wroteChannel = true;
                                            rssElement = channel; // return RssChannel
                                            readData = false;
                                        }
                                        item = new RssItem(); // create new RssItem
                                        channel.Items.Add(item);
                                        break;
                                    //case "source":
                                    //    source = new RssSource();
                                    //    item.Source = source;
                                    //    for (int i = 0; i < reader.AttributeCount; i++)
                                    //    {
                                    //        reader.MoveToAttribute(i);
                                    //        switch (reader.Name.ToLower())
                                    //        {
                                    //            case "url":
                                    //                try
                                    //                {
                                    //                    source.Url = reader.Value;
                                    //                }
                                    //                catch (Exception e)
                                    //                {
                                    //                    exceptions.Add(e);
                                    //                }
                                    //                break;
                                    //        }
                                    //    }
                                    //    break;
                                    //case "pubdate":
                                    //    try
                                    //    {
                                    //        item.PubDate = W3CDateTime.Parse(elementText.ToString()).DateTime;
                                    //    }
                                    //    catch (Exception e)
                                    //    {
                                    //        try
                                    //        {
                                    //            string tmp = elementText.ToString();
                                    //            tmp = tmp.Substring(0, tmp.LastIndexOf(" "));
                                    //            tmp += " GMT";
                                    //            item.PubDate = DateTime.Parse(tmp);
                                    //        }
                                    //        catch
                                    //        {
                                    //            exceptions.Add(e);
                                    //        }
                                    //    }
                                    //    break;
                                    case "enclosure":
                                        enclosure = new RssEnclosure();
                                        item.Enclosure = enclosure;
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            switch (reader.Name.ToLower())
                                            {
                                                case "url":
                                                    try
                                                    {
                                                        enclosure.Url = reader.Value;
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        exceptions.Add(e);
                                                    }
                                                    break;
                                                case "length":
                                                    try
                                                    {
                                                        enclosure.Length = int.Parse(reader.Value);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        enclosure.Length = 0;
                                                        //exceptions.Add(e);
                                                    }
                                                    break;
                                                case "type":
                                                    enclosure.Type = reader.Value;
                                                    break;
                                            }
                                        }
                                        break;
                                    case "guid":
                                        guid = new RssGuid();
                                        item.Guid = guid;
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            switch (reader.Name.ToLower())
                                            {
                                                case "ispermalink":
                                                    try
                                                    {
                                                        guid.PermaLink = bool.Parse(reader.Value);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        exceptions.Add(e);
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "channel":
                                        channel = new RssChannel();
                                        image = null;
                                        enclosure = null;
                                        item = null;
                                        break;
                                    case "image":
                                        image = new RssImage();
                                        channel.Image = image;
                                        break;
                                    case "rss":
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name.ToLower() == "version")
                                                switch (reader.Value)
                                                {
                                                    case "0.91":
                                                        rssVersion = RssVersion.RSS091;
                                                        break;
                                                    case "0.92":
                                                        rssVersion = RssVersion.RSS092;
                                                        break;
                                                    case "2.0":
                                                        rssVersion = RssVersion.RSS20;
                                                        break;
                                                    default:
                                                        rssVersion = RssVersion.NotSupported;
                                                        break;
                                                }
                                        }
                                        break;
                                    case "rdf":
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name.ToLower() == "version")
                                                switch (reader.Value)
                                                {
                                                    case "0.90":
                                                        rssVersion = RssVersion.RSS090;
                                                        break;
                                                    case "1.0":
                                                        rssVersion = RssVersion.RSS10;
                                                        break;
                                                    default:
                                                        rssVersion = RssVersion.NotSupported;
                                                        break;
                                                }
                                        }
                                        break;

                                }
                                if (pushElement)
                                    xmlNodeStack.Push(readerName);
                                break;
                            }
                        case XmlNodeType.EndElement:
                            {
                                if (xmlNodeStack.Count == 1)
                                    break;
                                string childElementName = (string)xmlNodeStack.Pop();
                                string parentElementName = (string)xmlNodeStack.Peek();
                                switch (childElementName) // current element
                                {
                                    // item classes
                                    case "item":
                                        rssElement = item;
                                        readData = false;
                                        break;
                                    //case "source":
                                    //    source.Name = elementText.ToString();
                                    //    rssElement = source;
                                    //    readData = false;
                                    //    break;
                                    case "enclosure":
                                        rssElement = enclosure;
                                        readData = false;
                                        break;
                                    case "guid":
                                        guid.Name = elementText.ToString();
                                        rssElement = guid;
                                        readData = false;
                                        break;
                                    case "pubdate":
                                        rssElement = channel;
                                        readData = false;
                                        break;
                                    case "channel":
                                        if (wroteChannel)
                                            wroteChannel = false;
                                        else
                                        {
                                            wroteChannel = true;
                                            rssElement = channel;
                                            readData = false;
                                        }
                                        break;
                                }
                                switch (parentElementName) // parent element
                                {
                                    case "item":
                                        switch (childElementName)
                                        {
                                            case "pubdate":
                                                try
                                                {
                                                    item.PubDate = W3CDateTime.Parse(elementText.ToString()).DateTime;
                                                }
                                                catch (Exception e)
                                                {
                                                    try
                                                    {
                                                        string tmp = elementText.ToString();
                                                        tmp = tmp.Substring(0, tmp.LastIndexOf(" "));
                                                        tmp += " GMT";
                                                        item.PubDate = DateTime.Parse(tmp);
                                                    }
                                                    catch
                                                    {
                                                        exceptions.Add(e);
                                                    }
                                                }
                                                break;
                                            case "title":
                                                item.Title = elementText.ToString();
                                                break;
                                            case "link":
                                                item.Link = elementText.ToString();
                                                break;
                                            case "description":
                                                item.Description = elementText.ToString();
                                                break;
                                        }
                                        break;
                                    case "channel":
                                        switch (childElementName)
                                        {
                                            case "title":
                                                channel.Title = elementText.ToString();
                                                break;
                                            case "link":
                                                try
                                                {
                                                    channel.Link = elementText.ToString();
                                                }
                                                catch (Exception e)
                                                {
                                                    exceptions.Add(e);
                                                }
                                                break;
                                            case "description":
                                                channel.Description = elementText.ToString();
                                                break;
                                            case "pubdate":
                                                try
                                                {
                                                    channel.PubDate = W3CDateTime.Parse(elementText.ToString()).DateTime;
                                                }
                                                catch (Exception)
                                                {
                                                    if (elementText.ToString() == "")
                                                    {
                                                        channel.PubDate = DateTime.Now;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            channel.PubDate = DateTime.Parse(elementText.ToString());
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            try
                                                            {
                                                                string tmp = elementText.ToString();
                                                                tmp = tmp.Substring(0, tmp.LastIndexOf(" "));
                                                                tmp += " GMT";
                                                                channel.PubDate = DateTime.Parse(tmp);
                                                            }
                                                            catch
                                                            {
                                                                exceptions.Add(e);
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                            case "lastbuilddate":
                                                try
                                                {
                                                    channel.LastBuildDate = W3CDateTime.Parse(elementText.ToString()).DateTime;
                                                    //channel.LastBuildDate = DateTime.Parse(elementText.ToString());
                                                }
                                                catch (Exception)
                                                {
                                                    if (elementText.ToString() == "")
                                                    {
                                                        channel.LastBuildDate = DateTime.Now;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            channel.LastBuildDate = DateTime.Parse(elementText.ToString());
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            try
                                                            {
                                                                string tmp = elementText.ToString();
                                                                tmp = tmp.Substring(0, tmp.LastIndexOf(" "));
                                                                tmp += " GMT";
                                                                channel.LastBuildDate = DateTime.Parse(tmp);
                                                            }
                                                            catch
                                                            {
                                                                exceptions.Add(e);
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                        }
                                        break;
                                    case "image":
                                        switch (childElementName)
                                        {
                                            case "url":
                                                try
                                                {
                                                    image.Url = elementText.ToString();
                                                }
                                                catch (Exception e)
                                                {
                                                    exceptions.Add(e);
                                                }
                                                break;
                                            case "title":
                                                image.Title = elementText.ToString();
                                                break;
                                            case "link":
                                                try
                                                {
                                                    image.Link = elementText.ToString();
                                                }
                                                catch (Exception e)
                                                {
                                                    exceptions.Add(e);
                                                }
                                                break;
                                            case "content:encoded":
                                                item.Content = elementText.ToString();
                                                break;
                                            case "description":
                                                image.Description = elementText.ToString();
                                                break;
                                        }
                                        break;
                                }
                                break;
                            }
                        case XmlNodeType.Text:
                            elementText.Append(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            elementText.Append(reader.Value);
                            break;
                    }
                }
            }
            while (readData);
            return rssElement;
        }
        /// <summary>A collection of all exceptions the RssReader class has encountered.</summary>
        public ExceptionCollection Exceptions
        {
            get { return exceptions; }
        }
        /// <summary>Gets the RSS version of the stream.</summary>
        /// <value>One of the <see cref="RssVersion"/> values.</value>
        public RssVersion Version
        {
            get { return rssVersion; }
        }
        /// <summary>Closes connection to file.</summary>
        /// <remarks>This method also releases any resources held while reading.</remarks>
        public void Close()
        {
            image = null;
            channel = null;
            enclosure = null;
            item = null;
            if (reader != null)
            {
                reader.Close();
                reader = null;
            }
            elementText = null;
            xmlNodeStack = null;
        }
    }
}
