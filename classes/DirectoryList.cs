using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Doppler
{
    [Serializable()]
    public class DirectoryList : CollectionBase
    {
        /// <summary>
        /// Gets or sets the <see cref="T:DirectoryItem"/> with the specified item.
        /// </summary>
        /// <value></value>
        public DirectoryItem this[int item]
        {
            get
            {
                return this.GetItem(item);
            }
            set
            {
                this.SetItem(item, value);
            }
        }

        /// <summary>
        /// Adds the specified directory item.
        /// </summary>
        /// <param name="directoryItem">The directory item.</param>
        public void Add(DirectoryItem directoryItem)
        {

            directoryItem.GUID = System.Guid.NewGuid();

            List.Add(directoryItem);
        }

        /// <summary>
        /// Removes the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes the specified GUID.
        /// </summary>
        /// <param name="Guid">The GUID.</param>
        /// <returns></returns>
        public bool Remove(Guid GUID)
        {
            for (int q = 0; q < Count; q++)
            {
                DirectoryItem ei = (DirectoryItem)List[q];
                if (ei.GUID == GUID)
                {
                    List.RemoveAt(q);
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Gets or sets the <see cref="T:DirectoryItem"/> with the specified GUID.
        /// </summary>
        /// <value></value>
        public DirectoryItem this[Guid Guid]
        {
            get
            {
                for (int q = 0; q < List.Count; q++)
                {
                    DirectoryItem ei = (DirectoryItem)List[q];
                    if (ei.GUID == Guid)
                    {
                        return (DirectoryItem)List[q];
                    }
                }
                return new DirectoryItem();
            }
            set
            {
                for (int q = 0; q < List.Count; q++)
                {
                    DirectoryItem ei = (DirectoryItem)List[q];
                    if (ei.GUID == Guid)
                    {
                        List[q] = value;
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <returns></returns>
        private DirectoryItem GetItem(int Index)
        {
            return (DirectoryItem)List[Index];
        }

        /// <summary>
        /// Sets the item.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="Item">The item.</param>
        private void SetItem(int Index, DirectoryItem Item)
        {
            List[Index] = Item;
        }
    }
}
