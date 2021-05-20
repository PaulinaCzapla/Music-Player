using Music_Player.Commands;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Music_Player.ViewModels
{
    class MusicLibraryViewModel : MusicPlayerViewModel
    {

        private Dictionary<string, PlaylistModel> Playlists;



        private void AddToPlaylists(string playlistName, PlaylistModel playlist)
        {
            bool isUnique = false;
            int i = 1;

            playlistName.Trim();

            do
            {
                if (Playlists.ContainsKey(playlistName))
                {
                    isUnique = false;
                    if(i!=1)
                    {
                        playlistName = playlistName.Remove(playlistName.Length - i/10 - 3);
                    }
                    playlistName += "(" + i + ")";
                    i++;
                }
                else
                {
                    isUnique = true;
                }

            } while (isUnique == false);

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
            List<SongModel> songs = new List<SongModel>();
            foreach (string path in songsPaths)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    string[] pathElements = path?.Split('\\');
                    SongModel song = new SongModel(path);
                    songs.Add(song);
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
                        if (song.Path != null)
                        {
                            var subItem = new TreeViewItem();
                            subItem.Header = song.Name;
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
                SongModel song = playlist.FindSong(title);

                if (song != null)
                {
                    PlaySong(title, song.Path, playlist);
                }
            }
        }

    }
}

