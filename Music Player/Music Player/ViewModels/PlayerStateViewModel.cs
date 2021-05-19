using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Threading;

namespace Music_Player.ViewModels
{
    class PlayerStateViewModel
    {
        public PlaylistModel CurrentPlaylist;

        private PlayerActions _State;
        public PlayerActions State 
        { 
            get  { return _State; }
            set 
            {
                StateChanged?.Invoke(this, value);
                _State = value;
            } 
        }

        private string _CurrentSongPath;
        public string CurrentSongPath 
        { 
            get { return _CurrentSongPath; }
            set
            {
                Debug.WriteLine("new song");
                if (value != _CurrentSongPath)
                {
                   NewSongPlayed?.Invoke(this, value);
                }
                    _CurrentSongPath = value;
            }
        }
        public DispatcherTimer PlayTimer { get; set; }

        public event EventHandler PlayerTimerTicked;
        private event EventHandler<string> NewSongPlayed;
        private event EventHandler<PlayerActions> StateChanged;

        public PlayerStateViewModel()
        {
            CurrentPlaylist = null;
            State = PlayerActions.NotPlaying;
            CurrentSongPath = null;
            PlayTimer = null;

           NewSongPlayed += NewSong_Play;
            StateChanged += State_Change;

        }
        public void PlayTimer_Tick(object sender, EventArgs e)
        {
            //progress bar and timer handling
            Debug.WriteLine(PlayerControlsViewModel.Player.Position.ToString(@"mm\:ss"));
        }

        public void NewSong_Play(object sender, string newPath)
        {
            PlayTimer = new DispatcherTimer();
            PlayTimer.Interval = TimeSpan.FromSeconds(1);
            PlayTimer.Tick += PlayTimer_Tick;
            PlayTimer.Start();
            Debug.WriteLine("startnew");

            

        }

        public void State_Change(object sender, PlayerActions newState)
        {
            if (newState == PlayerActions.Pause)
            {
                PlayTimer?.Stop();
                Debug.WriteLine("stop");
            }
            else
             if (newState == PlayerActions.Play)
            {
                PlayTimer?.Start();
                Debug.WriteLine("start");
            }
        }
    }
}
