using Music_Player.Commands;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Music_Player.ViewModels
{
    class PlayerControlsViewModel : MusicPlayerViewModel
    {

        public static MediaPlayer Player = new MediaPlayer();

        public PlayerControlsViewModel()
        {
            UseThePlayerControlCommand = new UseThePlayerControlCommand();

        }


        public void PlayPause()
        {
            if (CurrentState.State == PlayerActions.Play)
            {
                UseThePlayerControlCommand.Execute(new Tuple<PlayerActions, SongModel, PlaylistModel>(PlayerActions.Pause, null, null));
            }
            else
                if (CurrentState.State == PlayerActions.Pause)
            {
                PlaySong(CurrentState.CurrentSong, CurrentState.CurrentPlaylist);
            }

        }

        public void PlayNext()
        {
            //var song = CurrentState.CurrentPlaylist?.FindNextSong(CurrentState.CurrentSong);
            //if (song != null)
            //{
            //    PlaySong(song, CurrentState.CurrentPlaylist);
            //}

            UseThePlayerControlCommand.Execute(new Tuple<PlayerActions, SongModel, PlaylistModel>(PlayerActions.PlayNext, CurrentState.CurrentSong, CurrentState.CurrentPlaylist));

        }

        public void PlayPrev()
        {
                UseThePlayerControlCommand.Execute(new Tuple<PlayerActions, SongModel, PlaylistModel>(PlayerActions.PlayPrevious, CurrentState.CurrentSong, CurrentState.CurrentPlaylist));
        }


        public BitmapImage DisplayCover()
        {
            Uri resourceUri;
            resourceUri = new Uri(@"C:\Users\pauli\Documents\GitHub\Music-Player\Music Player\Music Player\cover.png", UriKind.Relative);

            if (CurrentState.State != PlayerActions.NotPlaying)
            {
                if (CurrentState.CurrentPlaylist.Cover != null)
                {
                    resourceUri = new Uri(CurrentState.CurrentPlaylist.Cover.Path, UriKind.Relative);
                }
            }
            return new BitmapImage(resourceUri);
        }

        public TimeSpan GetCurrentSongDuration ()
        {
            return CurrentState.Duration;
        }
    }
}
