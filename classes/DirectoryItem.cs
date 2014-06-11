using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Doppler
{
    [Serializable()]
    public class DirectoryItem
    {
        [XmlAttribute]
        public Guid GUID;
        public string Name;
        public string URL;

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// New directory item.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Url">The URL.</param>
        public DirectoryItem(string Name, string Url)
        {
            this.GUID = Guid.NewGuid();
            this.Name = Name;
            this.URL = Url;
        }

        public DirectoryItem()
        {
            this.GUID = Guid.NewGuid();
        }
    }
}
