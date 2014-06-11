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
    public class History : CollectionBase
    {
        public HistoryItem this[int item]
        {
            get
            {
                return this.getItem(item);
            }
            set
            {
                this.setItem(item, value);
            }
        }

        /// <summary>
        /// Gets the <see cref="T:HistoryItem"/> with the specified hash code.
        /// </summary>
        /// <value></value>
        public HistoryItem this[string hashCode]
        {
            get
            {
                HistoryItem  historyItem = null;
                
                foreach (HistoryItem item in List)
                {
                    if (item.Hashcode == Convert.ToInt32(hashCode))
                    {
                        historyItem = item;
                        break;
                    }
                }
                return historyItem;
            }
        }

        /// <summary>
        /// Gets the items by feed GUID.
        /// </summary>
        /// <param name="GUID">The GUID.</param>
        /// <returns></returns>
        public ArrayList GetItemsByFeedGUID(string GUID)
        {
            ArrayList newlist = new ArrayList();
            foreach (HistoryItem item in List)
            {
                if (item.FeedGUID == GUID)
                {
                    newlist.Add(item);
                }
            }

            return newlist;
        }

        /// <summary>
        /// Adds an history item to the history list
        /// </summary>
        /// <param name="historyItem"></param>
        public void Add(HistoryItem historyItem)
        {
            List.Add(historyItem);
            //	Settings.Default.Save();
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(HistoryItem item)
        {
            List.Remove(item);
        }


        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns></returns>
        private HistoryItem getItem(int Index)
        {
            return (HistoryItem)List[Index];
        }

        /// <summary>
        /// Sets the item.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Item">The item.</param>
        private void setItem(int Index, HistoryItem Item)
        {
            List[Index] = Item;
        }
    }
}
