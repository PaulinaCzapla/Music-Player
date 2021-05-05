using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;

namespace Music_Player.ViewModels
{
    class MusicLibraryViewModel : BaseViewModel
    {

        private List<PlaylistModel> Playlists;



        private void AddToPlaylists(PlaylistModel playlist)
        {
            Playlists.Add(playlist);
        }
        public MusicLibraryViewModel()
        {
            Debug.WriteLine("librart");

            //reading playlists from file

            Playlists = new List<PlaylistModel>();
        }

        public void AddToPlaylist(string playlistName, string songPath)
        {
            //to implement in VIew
        }

        public void AddCoverToPlaylist(string playlistName, string coverPath)
        {
            //to implement in View
        }

        public void CreatePlaylist(string[] songsPaths, string playlistName, string coverPath)
        {
            Dictionary<string, SongModel> songs = new Dictionary<string, SongModel> ();
            foreach (string path in songsPaths)
            {
                string[] pathElements = path.Split('\\');
                SongModel song = new SongModel(path);
                songs.Add(pathElements[pathElements.Length - 1], song);
            }
            PlaylistModel newPlaylist = new PlaylistModel(playlistName, songs, coverPath);
            AddToPlaylists(newPlaylist);
        }

        public void DisplayPlaylist(TreeView tree)
        {
            tree.Items.Clear();

            if (Playlists.Count != 0)
            {
                Debug.WriteLine(" display");
                foreach (PlaylistModel playlist in Playlists)
                {
                    TreeViewItem item = new TreeViewItem();

                    item.Header = playlist.PlaylistName;
                    tree.Items.Add(item);

                    foreach (var song in playlist.Songs)
                    {
                        if (song.Value != null)
                        {

                            item.Items.Add(song.Key);
                        }
                    }
                } 
            }
        }
    }
}

            