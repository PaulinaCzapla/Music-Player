using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;
using System.Windows.Threading;

namespace Music_Player.ViewModels
{
    class PlayerStateViewModel
    {
        public TimeSpan Position { get; set; }

        public PlaylistModel CurrentPlaylist;
        public TimeSpan Duration { get; set; }

        public event EventHandler <string> PlayerTimerTicked;
        private event EventHandler<string> NewSongPlayed;
        private event EventHandler<PlayerActions> StateChanged;

        private PlayerActions _State;
        public PlayerActions State
        {
            get { return _State; }
            set
            {
                StateChanged?.Invoke(this, value);
                _State = value;
            }
        }

        private SongModel _CurrentSong;
        public SongModel CurrentSong
        {
            get { return _CurrentSong; }
            set
            {
                Debug.WriteLine("new song");
                if (value != _CurrentSong || State == PlayerActions.PlayPrevious)
                {
                    NewSongPlayed?.Invoke(this, value.Path);
                }
                _CurrentSong = value;
            }
        }

        
        private Timer PlayTimer { get; set; }



        public PlayerStateViewModel()
        {
            CurrentPlaylist = null;
            State = PlayerActions.NotPlaying;
            CurrentSong = null;
            PlayTimer = null;
            Position = TimeSpan.Zero;
            NewSongPlayed += NewSong_Play;
            StateChanged += State_Change;
        }  

        private void NewSong_Play(object sender, string newPath)
        {
            PlayTimer = new System.Timers.Timer(1000);
            PlayTimer.Elapsed += OnElapsed;
            OnElapsed(null, null);
            //PlayTimer.Start();
            State = PlayerActions.Play;

        }
        private void OnElapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Windows.Application.Current?.Dispatcher.Invoke((Action)delegate ()
            {
                Position = PlayerControlsViewModel.Player.Position;
                PlayerTimerTicked.Invoke(sender, Position.ToString(@"hh\:mm\:ss"));
            });
        }
        private void State_Change(object sender, PlayerActions newState)
        {
            if (newState == PlayerActions.Pause)
            {
                PlayTimer?.Stop();
                Position = PlayerControlsViewModel.Player.Position;
                Debug.WriteLine("stop");
            }
            else
             if (newState == PlayerActions.Play)
            {
                PlayTimer?.Start();
                PlayerControlsViewModel.Player.Position = Position;
                Debug.WriteLine("start");
            }
        }

        public void SetDefaultValues()
        {
            CurrentPlaylist = null;
            State = PlayerActions.NotPlaying;
            CurrentSong = null;
            PlayTimer = null;
            Position = TimeSpan.Zero;
        }
    }
}
