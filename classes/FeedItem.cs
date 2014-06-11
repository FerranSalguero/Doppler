using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Doppler
{
    [Serializable()]
    public class FeedItem : ICloneable
    {
        /// <summary>
        /// Globally Unique identifier
        /// </summary>
        [XmlIgnore]
        private string guid;

        public String GUID
        {
            get { if (guid == null || guid == "") { guid = Guid.NewGuid().ToString(); return guid; } else { return guid; } }
            set { guid = value;}
        }

       
        private string title;

         /// <summary>
        /// The title of the item.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// The item url
        /// </summary
        private string url;
        public string Url
        {
           get { return url; }
           set { url = value; }
        }


        private string _playlistname;
        public string PlaylistName
        {
            get { return _playlistname; }
            set { _playlistname = value; }
        }

        [Obsolete("Use PlaylistName")]
        public string playlistname
        {
            get { return _playlistname; }
            set { _playlistname = value; }
        }
        /// <summary>
        /// is the feed checked for retrieval?
        /// </summary>
        private bool ischecked;
        public bool IsChecked
        {
            get { return ischecked; }
            set { ischecked = value; }
        }
        [Obsolete("Use IsChecked")]
        public bool isChecked
        {
            get { return ischecked; }
            set { ischecked = value; }
        }
        /// <summary>
        /// How many Mb's to download? 
        /// </summary>
        private int maxmb;
        public int MaxMb
        {
            get { return maxmb; }
            set { maxmb = value; }
        }

        [Obsolete("Use MaxMb")]
        public int maxMb
        {
            get { return maxmb; }
            set { maxmb = value; }
        }

       
        [XmlIgnore]
        private int numfiles;

         /// <summary>
        /// How many enclosures to download
        /// </summary>
        public int RetrieveNumberOfFiles
        {
            get { return numfiles; }
            set { numfiles = value; }
        }

        [Obsolete("Use RetrieveNumberOfFiles")]
        public int numFiles
        {
            get { return numfiles; }
            set { numfiles = value; }
        }

        /// <summary>
        /// Last publication date 
        /// </summary>
        private string pubdate;

        public string Pubdate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }


        //public bool UseExternal;
        private int source;

        public int Source
        {
            get { return source; }
            set { source = value; }
        }

        private bool removeFromPlaylist;

        public bool RemoveFromPlaylist
        {
            get { return removeFromPlaylist; }
            set { removeFromPlaylist = value; }
        }

        //public int Priority;
        private int cleanRating;

        public int CleanRating
        {
            get { return cleanRating; }
            set { cleanRating = value; }
        }

        private string readArticles;

        public string ReadArticles
        {
            get { return readArticles; }
            set { readArticles = value; }
        }
        /// <summary>
        /// Text filter
        /// </summary
        [XmlElementAttribute(IsNullable = false)]
        private string textfilter;

        public string Textfilter
        {
            get { return textfilter; }
            set { textfilter = value; }
        }

        [Obsolete("Use Textfilter")]
        public string textFilter
        {
            get { return textfilter; }
            set { textfilter = value; }
        }

       
        private bool usespacesavers;
        /// <summary>
        /// Use Space Saving functions
        /// </summary>
        public bool UseSpaceSavers
        {
            get { return usespacesavers; }
            set { usespacesavers = value; }
        }
        [Obsolete("Use UseSpaceSpavers")]
        public bool useSpaceSavers
        {
            get { return usespacesavers; }
            set { usespacesavers = value; }
        }

        /// <summary>
        /// Space saver: restrict size of feed allocation on disk
        /// </summary>
        /// 
        private int spacesaver_maxmb;

        public int Spacesaver_Size
        {
            get { return spacesaver_maxmb; }
            set { spacesaver_maxmb = value; }
        }

        [Obsolete("Use Spacesave_Size")]
        public int spacesaver_maxMb
        {
            get { return spacesaver_maxmb; }
            set { spacesaver_maxmb = value; }
        }

        private int spacesaver_maxfiles;
        /// <summary>
        /// Space saver: restrict maximum number of files in feed folder
        /// </summary>
        public int Spacesaver_Files
        {
            get { return spacesaver_maxfiles; }
            set { spacesaver_maxfiles = value; }
        }

        [Obsolete("Use Spacesaver_Files")]
        public int spacesaver_maxFiles
        {
            get { return spacesaver_maxfiles; }
            set { spacesaver_maxfiles = value; }
        }

        /// <summary>
        /// Space saver: restrict the number of files by age in days
        /// </summary>
        private int spacesaver_agedays;

        public int Spacesaver_Days
        {
            get { return spacesaver_agedays; }
            set { spacesaver_agedays = value; }
        }

        [Obsolete("Use Spacesaver_Days")]
        public int spacesaver_ageDays
        {
            get { return spacesaver_agedays; }
            set { spacesaver_agedays = value; }
        }
        /// <summary>
        /// Overrule ID3 tag : genre
        /// </summary>
       

        private string tagtitle;

        public string TagTitle
        {
            get { return tagtitle; }
            set { tagtitle = value; }
        }

        [Obsolete("Use TagTitle")]
        public string tagTitle
        {
            get { return tagtitle; }
            set { tagtitle = value; }
        }

        /// <summary>
        /// MP3 Tag rewrite: Genre
        /// </summary>
        [XmlElementAttribute(IsNullable = false)]
        private string taggenre;

        public string TagGenre
        {
            get { return taggenre; }
            set { taggenre = value; }
        }

        [Obsolete("Use TagGenre")]
        public string tagGenre
        {
            get { return taggenre; }
            set { taggenre = value; }
        }

        /// <summary>
        /// MP3 Tag rewrite: Artist
        /// </summary>
        [XmlElementAttribute(IsNullable = false)]
        private string tagartist;

        public string TagArtist
        {
            get { return tagartist; }
            set { tagartist = value; }
        }

        [Obsolete("Use TagArtist")]
        public string tagArtist
        {
            get { return tagartist; }
            set { tagartist = value; }
        }

        /// <summary>
        /// MP3 Tag rewrite: Album
        /// </summary>
        [XmlIgnore()]
        public string tagalbum;

        public string TagAlbum
        {
            get { return tagalbum; }
            set { tagalbum = value; }
        }

        [Obsolete("Use TagAlbum"), XmlIgnore()]
        public string tagAlbum
        {
            get { return tagalbum; }
            set { tagalbum = value; }
        }

        /// <summary>
        /// Contains the local list of read posts;
        /// </summary>
        private System.Collections.Specialized.StringCollection readposts;

        public System.Collections.Specialized.StringCollection ReadPosts
        {
            get { return readposts; }
            set { readposts = value; }
        }
        [Obsolete("Use ReadPosts")]
        public System.Collections.Specialized.StringCollection readPosts
        {
            get { return readposts; }
            set { readposts = value; }
        }
        

        /// <summary>
        /// Rating from 1 to 5
        /// </summary>
        private int rating;

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        //public int Flags = 0;
        private bool usetrackcounter;

        public bool UseTrackCounter
        {
            get { return usetrackcounter; }
            set { usetrackcounter = value; }
        }
        [Obsolete("Use UseTrackCounter")]
        public bool useTrackCounter
        {
            get { return usetrackcounter; }
            set { usetrackcounter = value; }
        }

        private int trackcounter;

        public int TrackCounter
        {
            get { return trackcounter; }
            set { trackcounter = value; }
        }
        [Obsolete("Use TrackCounter")]
        public int trackCounter
        {
            get { return trackcounter; }
            set { trackcounter = value; }
        }
        /// <summary>
        /// Category
        /// </summary>
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        /// <summary>
        /// Contains the URL pointing to the website containing the Feed
        /// </summary>
        //public string htmlUrl;
        private bool visible;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private string feedHashCode;

        public string FeedHashCode
        {
            get { return feedHashCode; }
            set { feedHashCode = value; }
        }

        private bool removePlayed;

        public bool RemovePlayed
        {
            get { return removePlayed; }
            set { removePlayed = value; }
        }
        private string downloadsFolder;
        private bool overrideDownloadsFolder;
        private string description;
        private string username;
        private string password;
        private bool authenticate;
        private bool deleted;
        private bool overrideAACConversion;

        public bool OverrideAACConversion
        {
            set { overrideAACConversion = value; }
            get { return overrideAACConversion; }
        }

        public bool OverrideDownloadsFolder
        {
            set { overrideDownloadsFolder = value; }
            get { return overrideDownloadsFolder; }
        }

        public string DownloadsFolder
        {
            get { return downloadsFolder; }
            set { downloadsFolder = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Authenticate
        {
            get { return authenticate; }
            set { authenticate = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        private bool useTitleForFiles = false;

        public bool UseTitleForFiles
        {
            get { return useTitleForFiles; }
            set { useTitleForFiles = value; }
        }


        #region ICloneable Members

        public object Clone()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            FeedItem newItem = new FeedItem();
            foreach (PropertyInfo propInfo in properties)
            {
                PropertyInfo newPropInfo = newItem.GetType().GetProperty(propInfo.Name);
                newPropInfo.SetValue(newItem,propInfo.GetValue(this,null), null);
            }
            FieldInfo[] fields = this.GetType().GetFields();
            foreach (FieldInfo fieldInfo in fields)
            {
                FieldInfo newFieldInfo = newItem.GetType().GetField(fieldInfo.Name);
                newFieldInfo.SetValue(newItem, fieldInfo.GetValue(this));
            }
            newItem.GUID = Guid.NewGuid().ToString();
            return newItem;
        }

        #endregion
    }

    public struct SpaceSavers
    {
        public int Days;
        public int Files;
        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}


