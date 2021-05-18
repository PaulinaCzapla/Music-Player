using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Music_Player.ViewModels
{

    class MusicPlayerViewModel : BaseViewModel
    {
        public static PlayerStateViewModel CurrentState { get; protected set; }


        static MusicPlayerViewModel()
        {
            Debug.WriteLine("static constructor");
            CurrentState = new PlayerStateViewModel();
        }

        protected void PlaySong(string name, string path, PlaylistModel currentPlaylist)
        {
            Tuple<PlayerActions, string, string> data = new Tuple<PlayerActions, string, string>(PlayerActions.Play, name, path);
            UseThePlayerControlCommand.Execute(data);

            CurrentState.CurrentSongPath = path;
            CurrentState.State = PlayerActions.Play;
            CurrentState.CurrentPlaylist = currentPlaylist;
        }

        public string GetCurrentPlaylistName()
        {
            string result = null;

            if(CurrentState.CurrentPlaylist != null)
            {
                result = CurrentState.CurrentPlaylist.PlaylistName;
            }

            return result;
        }

        public string GetCurrentSongName()
        {
            string result = null;
            if (CurrentState.CurrentSongPath!= null)
            {
                var pathInfo = CurrentState.CurrentSongPath.Split(@"\");
                result = pathInfo[pathInfo.Length - 1];
            }

            return result;
        }

    }
}
