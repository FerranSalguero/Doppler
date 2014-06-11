using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
using Doppler;
using Doppler.Properties;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DopplerControls
{
    public static class iTunesHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int CleaniTunesPlaylistByPlayed(DownloadItem item, IITPlaylist playlist, IiTunes iitApp)
        {
            int tracksremoved = 0;
            try
            {
                FeedItem feedItem = Settings.Default.Feeds[item.FeedGUID];

                ArrayList tracks = new ArrayList();
                foreach (IITFileOrCDTrack track in playlist.Tracks)
                {
                    tracks.Add(track);
                }

                for (int q = 0; q < tracks.Count; q++)
                {
                    try
                    {
                        IITFileOrCDTrack track = (IITFileOrCDTrack)tracks[q];

                        if (track.PlayedCount == 1)
                        {
                            string trackName = track.Name;
                            int trackID = track.trackID;
                            if (Settings.Default.LogLevel > 0) log.Info(String.Format("Track {0} has been listened to. Deleted", track.Name));
                            if (File.Exists(track.Location))
                            {
                                tracksremoved++;
                                File.Delete(track.Location);
                            }
                            track.Delete();

                            // remove the entry completely from the library, it's dead anyway
                            try
                            {
                                IITFileOrCDTrack libraryTrack = (IITFileOrCDTrack)iitApp.LibraryPlaylist.Tracks.get_ItemByName(trackName);
                                while (libraryTrack != null && libraryTrack.Location != "")
                                {
                                    libraryTrack.Delete();
                                    libraryTrack = (IITFileOrCDTrack)iitApp.LibraryPlaylist.Tracks.get_ItemByName(trackName);
                                }
                            }
                            catch (Exception ex)
                            {
                                if (Settings.Default.LogLevel > 0) log.Error(ex);
                            }
                        }
                    }
                    catch { }

                }
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Error while communicating with iTunes", ex);
            }
            return tracksremoved;
        }

        public static iTunesLib.IITUserPlaylist GetiTunesPlaylist(iTunesLib.IiTunes iitApp, string strPlaylist)
        {

            IITUserPlaylist returnPlaylist = null;
            IITPlaylistCollection playlists = iitApp.LibrarySource.Playlists;
            int numPlaylists = playlists.Count;

            Object podcastfolder = null;
            // find the Dopppler Podcasts folder in iTunes
            foreach (IITPlaylist folder in iitApp.LibrarySource.Playlists)
            {
                if (folder.Name == "Doppler Podcasts")
                {
                    podcastfolder = folder;
                    break;
                }
            }
            if (podcastfolder == null)
            {
                podcastfolder = iitApp.CreateFolder("Doppler Podcasts");
            }


            while (numPlaylists != 0)
            {
                Object currPlaylist = playlists[numPlaylists];
                IITPlaylist tempPlaylist = (IITPlaylist)currPlaylist;
                // is this a user playlist?
                if (tempPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser)
                {
                    IITUserPlaylist thisPlaylist = (IITUserPlaylist)currPlaylist;

                    if (thisPlaylist.Name == strPlaylist)
                    {
                        returnPlaylist = thisPlaylist;
                        break;
                    }
                }
                numPlaylists--;
            }
            if (returnPlaylist == null)
            {

                returnPlaylist = (IITUserPlaylist)iitApp.CreatePlaylist(strPlaylist);
                returnPlaylist.set_Parent(ref podcastfolder);
                //returnPlaylist = GetiTunesPlaylist(iitApp, strPlaylist);
            }

            return returnPlaylist;

        }

        public static int CleaniTunesPlaylistByRating(DownloadItem item, IITPlaylist playlist, IiTunes iitApp)
        {
            int tracksremoved = 0;
            try
            {
                FeedItem feedItem = Settings.Default.Feeds[item.FeedGUID];
                if (feedItem.CleanRating > 0)
                {
                    ArrayList tracks = new ArrayList();
                    foreach (IITFileOrCDTrack track in playlist.Tracks)
                    {
                        tracks.Add(track);
                    }
                    int Rating = feedItem.CleanRating * 20;

                    for (int q = 0; q < tracks.Count; q++)
                    {
                        try
                        {
                            IITFileOrCDTrack track = (IITFileOrCDTrack)tracks[q];

                            if (track.Rating == Rating)
                            {
                                string trackName = track.Name;
                                int trackID = track.trackID;
                                if (Settings.Default.LogLevel > 1) log.Info(String.Format("Track {0} matching rating {1}. Deleted", track.Name, Rating));
                                if (File.Exists(track.Location))
                                {
                                    tracksremoved++;
                                    File.Delete(track.Location);
                                }
                                track.Delete();

                                // remove the entry completely from the library, it's dead anyway
                                try
                                {
                                    IITFileOrCDTrack libraryTrack = (IITFileOrCDTrack)iitApp.LibraryPlaylist.Tracks.get_ItemByName(trackName);
                                    while (libraryTrack != null && libraryTrack.Location != "")
                                    {
                                        libraryTrack.Delete();
                                        libraryTrack = (IITFileOrCDTrack)iitApp.LibraryPlaylist.Tracks.get_ItemByName(trackName);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (Settings.Default.LogLevel > 0) log.Error(ex);
                                }
                            }
                        }
                        catch { }

                    }
                }
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Error while communicating with iTunes", ex);
            }
            return tracksremoved;
        }

        public static void RewriteiTunesTags(DownloadItem item, IITFileOrCDTrack track)
        {
            string strLocalFile = track.Location;
            if (System.IO.File.Exists(strLocalFile))
            {
                try
                {
                    string strTitle = track.Name;
                    string strGenre = track.Genre;

                    string strArtist = track.Artist;

                    string strAlbum = track.Album;
                    if (item.TagTitle != null && item.TagTitle != "") strTitle = ParseiTunesTags(item.TagTitle, item, track);
                    if (item.TagGenre != null && item.TagGenre != "") strGenre = ParseiTunesTags(item.TagGenre, item, track);
                    if (item.TagArtist != null && item.TagArtist != "") strArtist = ParseiTunesTags(item.TagArtist, item, track);
                    if (item.TagAlbum != null && item.TagAlbum != "") strAlbum = ParseiTunesTags(item.TagAlbum, item, track);

                    track.Name = strTitle;
                    track.Genre = strGenre;
                    track.Artist = strArtist;
                    track.Album = strAlbum;
                }
                catch (COMException ex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error("RewriteiTunesTags", ex);
                }
                finally
                {

                }
            }
            else
            {
                if (Settings.Default.LogLevel > 0) log.Error("Cannot find file to rewrite tags");
            }
        }

        public static string ParseiTunesTags(string strTag, DownloadItem item, IITFileOrCDTrack track)
        {
            strTag = strTag.Replace("%feedname%", item.FeedTitle);
            strTag = strTag.Replace("%url%", item.FeedUrl);
            strTag = strTag.Replace("%playlist%", item.FeedPlaylist);
            strTag = strTag.Replace("%artist%", track.Artist);
            strTag = strTag.Replace("%album%", track.Album);
            strTag = strTag.Replace("%genre%", track.Genre);
            strTag = strTag.Replace("%date%", DateTime.Now.ToString("yyyy-MM-dd"));
            strTag = strTag.Replace("%time%", DateTime.Now.ToString("HH:mm:ss"));
            strTag = strTag.Replace("%y%", DateTime.Now.Year.ToString());
            strTag = strTag.Replace("%m%", DateTime.Now.Month.ToString());
            strTag = strTag.Replace("%d%", DateTime.Now.Day.ToString());
            System.IO.FileInfo fileInfo = new FileInfo(track.Location);
            strTag = strTag.Replace("%file%", fileInfo.Name);
            return strTag;
        }
    }
}
