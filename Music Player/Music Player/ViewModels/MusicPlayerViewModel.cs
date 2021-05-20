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
            CurrentState = new PlayerStateViewModel();
        }

        protected void PlaySong(SongModel song, PlaylistModel currentPlaylist)
        {
            UseThePlayerControlCommand.Execute(new Tuple<PlayerActions, SongModel, PlaylistModel>(PlayerActions.Play, song, currentPlaylist));
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
            if (CurrentState.CurrentSong!= null)
            {
                result = CurrentState.CurrentSong.Name;
            }

            return result;
        }

    }
}
