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
            List<SongModel> songs = new List<SongModel>();
            foreach (string path in songsPaths)
            {
                SongModel song = new SongModel(path);
                songs.Add(song);
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

                    foreach (SongModel song in playlist.Songs)
                    {
                        if (song.Path != null)
                        {
                            string[] pathElements = song.Path.Split('\\');
                            item.Items.Add(pathElements[pathElements.Length - 1]);
                        }
                    }
                } 
            }
        }
    }
}

            