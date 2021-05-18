using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.ViewModels
{

    class MusicPlayerViewModel : BaseViewModel
    {
        protected static PlayerStateViewModel CurrentState = new PlayerStateViewModel();
        protected void PlaySong(string name, string path, PlaylistModel currentPlaylist)
        {
            Tuple<PlayerActions, string, string> data = new Tuple<PlayerActions, string, string>(PlayerActions.Play, name, path);
            UseThePlayerControlCommand.Execute(data);

            CurrentState.CurrentSongPath = path;
            CurrentState.State = PlayerActions.Play;
            CurrentState.CurrentPlaylist = currentPlaylist;
        }


    }
}
