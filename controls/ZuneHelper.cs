using System;
using System.Collections.Generic;
using System.Text;
using Doppler;
using Doppler.Properties;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WMPLib;
using ID3;

namespace DopplerControls
{
    /*
    public static class ZuneHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int CleanZunePlaylistRating(DownloadItem item, IWMPPlaylist playlist, WindowsMediaPlayer player)
        {
            int tracksremoved = 0;
            try
            {
                FeedItem feedItem = Settings.Default.Feeds[item.FeedGUID];
                if (feedItem.CleanRating > 0)
                {
                    ArrayList tracks = new ArrayList();
                    for (int q = 0; q < playlist.count; q++)
                    {
                        IWMPMedia wmpMedia = playlist.get_Item(q);
                        tracks.Add(wmpMedia);
                    }

                    for (int q = 0; q < tracks.Count; q++)
                    {
                        try
                        {
                            IWMPMedia track = (IWMPMedia)tracks[q];
                            //IITFileOrCDTrack track = (IITFileOrCDTrack)tracks[q];

                            string userRating = track.getItemInfo("UserRating");
                            if (userRating != "")
                            {
                                //1 star 1 1 to 12 
                                //2 stars 25 13 to 37 
                                //3 stars 50 38 to 62 
                                //4 stars 75 63 to 86 
                                //5 stars 99 87 to 99 

                                int userRatingValue = int.Parse(userRating);
                                int userRatingConvertedValue;
                                if (userRatingValue == 0)
                                {
                                    userRatingConvertedValue = 0;
                                } 
                                else if (userRatingValue > 0 && userRatingValue < 12)
                                {
                                    // 1 star
                                    userRatingConvertedValue = 1;
                                }
                                else if (userRatingValue > 12 && userRatingValue < 37)
                                {
                                    // 2 stars
                                    userRatingConvertedValue = 2;
                                }
                                else if (userRatingValue > 37 && userRatingValue < 62)
                                {
                                    // 3 stars
                                    userRatingConvertedValue = 3;
                                }
                                else if (userRatingValue > 62 && userRatingValue < 86)
                                {
                                    // 4 stars
                                    userRatingConvertedValue = 4;
                                }
                                else
                                {
                                    userRatingConvertedValue = 5;
                                }

                                if (userRatingConvertedValue == feedItem.Rating)
                                {
                                    playlist.removeItem(track);

                                    //string trackName = track.name;
                                    //int trackID = track.trackID;
                                    if (Settings.Default.LogLevel > 1) log.Info(String.Format("Track {0} has been listened to. Deleted", track.name));
                                    if (File.Exists(track.sourceURL))
                                    {
                                        tracksremoved++;
                                        File.Delete(track.sourceURL);
                                    }
                                    playlist.removeItem(track);
                                }
  
                            }
                        }
                        catch { }

                    }
                }
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Error while communicating with Windows Media Player", ex);
            }
            return tracksremoved;
        }


        public static int CleanZunePlaylistByPlayed(DownloadItem item, IWMPPlaylist playlist, WindowsMediaPlayer player)
        {
            int tracksremoved = 0;
            try
            {
                FeedItem feedItem = Settings.Default.Feeds[item.FeedGUID];
               
                    ArrayList tracks = new ArrayList();
                    for(int q = 0;q < playlist.count;q++)
                    {
                        IWMPMedia wmpMedia = playlist.get_Item(q);
                        tracks.Add(wmpMedia);
                    }

                    for (int q = 0; q < tracks.Count; q++)
                    {
                        try
                        {
                            IWMPMedia track = (IWMPMedia)tracks[q];
                            //IITFileOrCDTrack track = (IITFileOrCDTrack)tracks[q];

                            string userPlayCount = track.getItemInfo("UserPlayCount");
                            if (userPlayCount != "" && int.Parse(userPlayCount) == 1)
                            {
                                playlist.removeItem(track);
                                //string trackName = track.name;
                                //int trackID = track.trackID;
                                if (Settings.Default.LogLevel > 1) log.Info(String.Format("Track {0} has been listened to. Deleted", track.name));
                                if (File.Exists(track.sourceURL))
                                {
                                    tracksremoved++;
                                    File.Delete(track.sourceURL);
                                }
                                playlist.removeItem(track);

                             
                            }
                        }
                        catch { }

                    }
               
            }
            catch (Exception ex)
            {
                if (Settings.Default.LogLevel > 0) log.Error("Error while communicating with Windows Media Player", ex);
            }
            return tracksremoved;
        }

        public static IWMPPlaylist GetZunePlaylist(WindowsMediaPlayer player, string playlistName)
        {
            IWMPPlaylist returnPlaylist = null;
            IWMPPlaylistArray playlistArray = player.playlistCollection.getByName(playlistName);

            if (playlistArray.count > 0)
            {
                returnPlaylist = playlistArray.Item(0);
            }
            else
            {
                // non existing, create it
                returnPlaylist = player.playlistCollection.newPlaylist(playlistName);
            }
            return returnPlaylist;

        }

        public static void RewriteWMPTags(DownloadItem item, IWMPMedia wmpmedia)
        {
            string strLocalFile = item.Filename;

            if (System.IO.File.Exists(strLocalFile))
            {

               // WindowsMediaPlayer player = null;
                try
                {
                    //wmppplayer = new WindowsMediaPlayer();
                    //IWMPMedia wmpmedia = wmppplayer.newMedia(strLocalFile);

                    //for (int q = 0; q < wmpmedia.attributeCount; q++)
                    //{
                    //    MessageBox.Show(wmpmedia.getAttributeName(q) + " - " + wmpmedia.getItemInfo(wmpmedia.getAttributeName(q)));
                    //}
                    string strTitle = wmpmedia.getItemInfo("Title");
                    string strGenre = wmpmedia.getItemInfo("Genre");
                    if (strGenre == null || strGenre == "")
                    {
                        strGenre = wmpmedia.getItemInfo("WM/Genre");
                    }
                    string strArtist = wmpmedia.getItemInfo("WM/AlbumArtist");
                    if (strArtist == null || strArtist == "")
                    {
                        strArtist = wmpmedia.getItemInfo("Author");
                    }
                    string strAlbum = wmpmedia.getItemInfo("WM/AlbumTitle");
                    if (item.TagTitle != null && item.TagTitle != "") strTitle = ParseMediaTags(item.TagTitle, item, wmpmedia);
                    if (item.TagGenre != null && item.TagGenre != "") strGenre = ParseMediaTags(item.TagGenre, item, wmpmedia);
                    if (item.TagArtist != null && item.TagArtist != "") strArtist = ParseMediaTags(item.TagArtist, item, wmpmedia);
                    if (item.TagAlbum != null && item.TagAlbum != "") strAlbum = ParseMediaTags(item.TagAlbum, item, wmpmedia);

                    wmpmedia.setItemInfo("Title", strTitle);
                    wmpmedia.setItemInfo("WM/Genre", strGenre);
                    wmpmedia.setItemInfo("Author", strArtist);
                    wmpmedia.setItemInfo("WM/AlbumTitle", strAlbum);

                }
                catch (COMException ex)
                {
                    if (Settings.Default.LogLevel > 0) log.Error(ex);
                }
                //finally
                //{
                //    int left = 0;
                //    do
                //    {
                //        left = System.Runtime.InteropServices.Marshal.ReleaseComObject(wmppplayer);
                //    } while (left > 0);

                //}
            }
            else
            {
                if (Settings.Default.LogLevel > 0) log.Error("Cannot find file to rewrite tags");
            }
        }

        public static string ParseMediaTags(string strTag, DownloadItem item, IWMPMedia wmpmedia)
        {
            strTag = strTag.Replace("%feedname%", item.FeedTitle);
            strTag = strTag.Replace("%url%", item.FeedUrl);
            strTag = strTag.Replace("%playlist%", item.FeedPlaylist);
            strTag = strTag.Replace("%artist%", wmpmedia.getItemInfo("Author"));
            strTag = strTag.Replace("%album%", wmpmedia.getItemInfo("WM/AlbumTitle"));
            strTag = strTag.Replace("%genre%", wmpmedia.getItemInfo("WM/Genre"));
            strTag = strTag.Replace("%date%", DateTime.Now.ToString("yyyy-MM-dd"));
            strTag = strTag.Replace("%time%", DateTime.Now.ToString("HH:mm:ss"));
            strTag = strTag.Replace("%y%", DateTime.Now.Year.ToString());
            strTag = strTag.Replace("%m%", DateTime.Now.Month.ToString());
            strTag = strTag.Replace("%d%", DateTime.Now.Day.ToString());
            System.IO.FileInfo fileInfo = new FileInfo(wmpmedia.sourceURL);
            strTag = strTag.Replace("%file%", fileInfo.Name);
            return strTag;
        }
    }
     */
}
