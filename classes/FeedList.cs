using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Threading;
using Doppler.Properties;

namespace Doppler
{

	[Serializable()]
	public class FeedList : CollectionBase
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the <see cref="T:FeedItem"/> with the specified item.
        /// </summary>
        /// <value></value>
		public FeedItem this[int item]
		{
			get
			{
				return this.getItem(item);
			}
			set
			{
				this.setItem(item,value);
			}
		}


        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public ArrayList Categories
        {
            get
            {
                ArrayList arrReturn = new ArrayList();

                for (int q = 0; q < this.Count; q++)
                {
                    string Category = this[q].Category;
                    if (Category == null || Category == "")
                    {
                        Category = "- not categorized -";
                    }
                    if (!arrReturn.Contains(Category))
                    {
                        arrReturn.Add(Category);
                    }
                }
                arrReturn.Sort();
                return arrReturn;
            }
        }

        /// <summary>
        /// Gets the opml categories.
        /// </summary>
        /// <value>The opml categories.</value>
        public ArrayList OpmlCategories
        {
            get
            {
                ArrayList arrReturn = new ArrayList();

                for (int q = 0; q < this.Count; q++)
                {
                    string Category = this[q].Category;
                    if (Category != null && Category != "")
                    {

                        if (!arrReturn.Contains(Category))
                        {
                            arrReturn.Add(Category);
                        }
                    }
                }
                arrReturn.Sort();
                return arrReturn;
            }
        }

        /// <summary>
        /// returns a list of feeds for a specific category
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        public ArrayList Feeds(string Category)
        {
            ArrayList arrReturn = new ArrayList();
            foreach(FeedItem feedItem in this)
            {
                if (feedItem.Category == Category)
                {
                    arrReturn.Add(feedItem);
                }
            }
            return arrReturn;
        }

        /// <summary>
        /// Arrays the list.
        /// </summary>
        /// <returns></returns>
        public ArrayList ArrayList()
        {
            ArrayList arrReturn = new ArrayList();
            foreach (FeedItem feedItem in this)
            {
                arrReturn.Add(feedItem);

            }
            return arrReturn;
        }

        /// <summary>
        /// Adds the specified feed item.
        /// </summary>
        /// <param name="feedItem">The feed item.</param>
		public void Add(FeedItem feedItem)
		{
			if(feedItem.GUID == null)
			{
				feedItem.GUID = System.Guid.NewGuid().ToString();
			}
            bool boolFound = false;
            foreach (FeedItem f in List)
            {
                if (f.Url == feedItem.Url)
                {
                    boolFound = true;
                    break;
                }
            }
            if (boolFound == false)
            {
                List.Add(feedItem);
                //Settings.Default.Save();
            }
			//List.Add(feedItem);
		}

		public bool Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{	
				return false;
			}
			else
			{
				List.RemoveAt(index);
				return true;
			}
		}



		public bool Remove(string strUrl)
		{
			for(int q=0;q<List.Count;q++)
			{
				FeedItem fi = (FeedItem) List[q];
				if(fi.Url == strUrl)
				{
					List.RemoveAt(q);
					return true;
				}
			}
			return false;
		}

        public FeedItem[] ToArray()
        {
            FeedItem[] items = new FeedItem[List.Count];
            List.CopyTo(items, 0);
            return items;
        }

        public bool Remove(FeedItem value)
        {
        
            bool deleted = false;
            for (int q = 0; q < List.Count; q++)
            {
                FeedItem feed = (FeedItem)List[q];
                if (feed.GUID == value.GUID || feed.Url == value.Url)
                {
                    List.RemoveAt(q);
                    log.Info("User deleted feed" + value.Title);
                    deleted = true;
                    break;
                }
            }
            return deleted;
        }

        /// <summary>
        /// Gets the feeditem by URL.
        /// </summary>
        /// <param name="Url">The URL.</param>
        /// <returns></returns>
		public FeedItem GetFeeditemByUrl(string Url)
		{
			for(int q=0;q<List.Count;q++)
			{
				FeedItem fi = (FeedItem) List[q];
				if(fi.Url == Url)
				{
					return (FeedItem) List[q];
				}
			}
			return null;
		}


        /// <summary>
        /// Gets or sets the <see cref="T:FeedItem"/> with the specified GUID.
        /// </summary>
        /// <value></value>
        public FeedItem this[string strGUID]
        {
            get
            {
                for (int q = 0; q < List.Count; q++)
                {
                    FeedItem fi = (FeedItem)List[q];
                    if (fi.GUID == strGUID)
                    {
                        return (FeedItem)List[q];
                    }
                }
                return new FeedItem();
            }
            set
            {
                for (int q = 0; q < List.Count; q++)
                {
                    FeedItem fi = (FeedItem)List[q];
                    if (fi.GUID == strGUID)
                    {
                        List[q] = value;
                        break;
                    }
                }
            }
        }

        public FeedItem this[FeedItem feedItem]
        {
            
            get
            {
                for (int q = 0; q < List.Count; q++)
                {
                    FeedItem fi = (FeedItem)List[q];
                    if (fi.GUID == feedItem.GUID)
                    {
                        return (FeedItem)List[q];
                    }
                }
                return new FeedItem();
            }
            set
            {
                for (int q = 0; q < List.Count; q++)
                {
                    FeedItem fi = (FeedItem)List[q];
                    if (fi.GUID == feedItem.GUID)
                    {
                        List[q] = value;
                        break;
                    }
                }
            }
        }

        public bool Contains(FeedItem value)
        {
            bool found = false;
            foreach (FeedItem feedItem in List)
            {
                if (feedItem.GUID == value.GUID || feedItem.Url == value.Url)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
                 

		private FeedItem getItem(int Index)
		{
			return (FeedItem) List[Index];
		}

		private void setItem(int Index, FeedItem Item)
		{
			List[Index] = Item;
		}
	}

	
	
}
