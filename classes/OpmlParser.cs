using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Doppler
{
    public static class OPMLParser
    {
        /// <summary>
        /// Parses OPML 
        /// </summary>
        /// <param name="OPML"></param>
        /// <returns>FeedList containing found subscriptions</returns>
        public static FeedList Parse(string OPML)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.LoadXml(OPML);
            return Parse(docXml);
        }

        /// <summary>
        /// Parses OPML
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>FeedList containing found subscriptions</returns>
        public static FeedList Parse(XmlDocument doc)
        {
            FeedList feedCollection= new FeedList();


            XmlNodeList opmlCategories;
            XmlNodeList opmlEntries;


            XmlNode body = doc.DocumentElement.SelectSingleNode("body");

            opmlCategories = body.SelectNodes("outline[not(@type='rss')]");
            if (opmlCategories != null)
            {
                foreach (XmlNode category in opmlCategories)
                {
                    string strCat = category.Attributes["text"].InnerText;

                    opmlEntries = category.SelectNodes("outline[@type='rss']");
                    foreach (XmlNode opmlEntry in opmlEntries)
                    {

                        FeedItem feedItem = new FeedItem();
                      
                        string strTitle = "";
                        if (opmlEntry.Attributes["text"] != null)
                        {
                            strTitle = opmlEntry.Attributes["text"].InnerText;
                        }
                        else
                        {
                            if (opmlEntry.Attributes["title"] != null)
                            {
                                strTitle = opmlEntry.Attributes["title"].InnerText;
                            }
                            else
                            {
                                if (opmlEntry.Attributes["description"] != null)
                                {
                                    strTitle = opmlEntry.Attributes["description"].InnerText;
                                }
                                else
                                {
                                    strTitle = opmlEntry.Attributes["xmlUrl"].InnerText;
                                }
                            }
                        }
                        feedItem.Title = strTitle;
                        feedItem.Url = opmlEntry.Attributes["xmlUrl"].InnerText;
                        
                        //dopplerFeed.Title = strTitle;
                        //dopplerFeed.LastModified = DateTime.Now;
                        //dopplerFeed.UnRead = -1;
                        //dopplerFeed.Url = opmlEntry.Attributes["xmlUrl"].InnerText;

                        feedCollection.Add(feedItem);
                  //      feedCollection.Add(dopplerFeed);
                    }

                }

            }
            // check if there are items without categories
            opmlEntries = body.SelectNodes("outline[@type='rss']");
            if (opmlEntries != null)
            {
                foreach (XmlNode opmlEntry in opmlEntries)
                {

                    FeedItem dopplerFeed = new FeedItem();
                    string strTitle = "";
                    if (opmlEntry.Attributes["text"] != null)
                    {
                        strTitle = opmlEntry.Attributes["text"].InnerText;
                    }
                    else
                    {
                        if (opmlEntry.Attributes["title"] != null)
                        {
                            strTitle = opmlEntry.Attributes["title"].InnerText;
                        }
                        else
                        {
                            if (opmlEntry.Attributes["description"] != null)
                            {
                                strTitle = opmlEntry.Attributes["description"].InnerText;
                            }
                            else
                            {
                                strTitle = opmlEntry.Attributes["xmlUrl"].InnerText;
                            }
                        }
                    }
                    dopplerFeed.Title = strTitle;
                    dopplerFeed.Url = opmlEntry.Attributes["xmlUrl"].InnerText;
                    feedCollection.Add(dopplerFeed);
                }
            }
            return feedCollection;
        }
    }
}
