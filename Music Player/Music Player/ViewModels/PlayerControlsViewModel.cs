using Music_Player.Commands;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Music_Player.ViewModels
{
    class PlayerControlsViewModel : MusicPlayerViewModel
    {

        public static MediaPlayer Player = new MediaPlayer();
        
        public PlayerControlsViewModel()
        {
            UseThePlayerControlCommand = new UseThePlayerControlCommand();
            
        }

        private void Pause()
        {
            Tuple<PlayerActions, string, string> data = new Tuple<PlayerActions, string, string>(PlayerActions.Pause, null, null);
            UseThePlayerControlCommand.Execute(data);

            CurrentState.State = PlayerActions.Pause;
        }
        public void PlayPause()
        {
            if (CurrentState.State == PlayerActions.Play)
            {
                Pause();
            }
            else
                if (CurrentState.State == PlayerActions.Pause)
            {
                var pathInfo = CurrentState.CurrentSongPath.Split("//");
                PlaySong(pathInfo[pathInfo.Length - 1], CurrentState.CurrentSongPath, CurrentState.CurrentPlaylist);
            }
        }




    }
}
