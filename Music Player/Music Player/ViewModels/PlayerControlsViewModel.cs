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
                var pathInfo = CurrentState.CurrentSongPath.Split(@"\");
                var songInfo = pathInfo[pathInfo.Length - 1].Split(".");
                PlaySong(songInfo[0], CurrentState.CurrentSongPath, CurrentState.CurrentPlaylist);
            }

        }

        public void PlayNext()
        {
            var pathInfo = CurrentState.CurrentSongPath.Split(@"\");
            var songInfo = pathInfo[pathInfo.Length - 1].Split(".");
            var song = CurrentState.CurrentPlaylist.FindNextSong(songInfo[0]);
            if (song != null)
            {
                PlaySong(songInfo[0], song.Path, CurrentState.CurrentPlaylist);
            }
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
            TimeSpan result;
            if (Player.NaturalDuration.HasTimeSpan)
            {
                result = Player.NaturalDuration.TimeSpan;
            }
            else
            {
                result = TimeSpan.Zero;
            }

            return result;
        }
    }
}
