using Music_Player.Commands;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    class MusicLibraryViewModel : BaseViewModel
    {

        private Dictionary<string, PlaylistModel> Playlists;



        private void AddToPlaylists(string playlistName, PlaylistModel playlist)
        {
            Playlists.Add(playlistName, playlist);
        }
        public MusicLibraryViewModel()
        {
            UseThePlayerControlCommand = new UseThePlayerControlCommand();
            Playlists = new Dictionary<string, PlaylistModel>();
            //reading playlists from file

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
            Dictionary<string, SongModel> songs = new Dictionary<string, SongModel>();
            foreach (string path in songsPaths)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    string[] pathElements = path?.Split('\\');
                    SongModel song = new SongModel(path);
                    songs.Add(pathElements[pathElements.Length - 1], song);
                }
            }
            PlaylistModel newPlaylist = new PlaylistModel(playlistName, songs, coverPath);
            AddToPlaylists(playlistName, newPlaylist);
        }

        public void DisplayPlaylist(TreeView tree)
        {
            tree.Items.Clear();

            if (Playlists.Count != 0)
            {
                Debug.WriteLine(" display");
                foreach (var playlist in Playlists)
                {
                    TreeViewItem item = new TreeViewItem();

                    item.Header = playlist.Key;
                    tree.Items.Add(item);

                    foreach (var song in playlist.Value.Songs)
                    {
                        if (song.Value != null)
                        {
                            var subItem = new TreeViewItem();
                            subItem.Header = song.Key;
                            item.Items.Add(subItem);
                        }
                    }
                }
            }
        }

        public void PlaySelectedSong(string playlistName, string title)
        {
            if (Playlists.ContainsKey(playlistName))
            {
                var playlist = Playlists.GetValueOrDefault(playlistName);
               if( playlist.Songs.ContainsKey(title))
                {
                    PlaySong(title, playlist.Songs.GetValueOrDefault(title).Path);
                }
            }
        }
    }
}

