using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Music_Player.ViewModels
{
    class PlayerStateViewModel
    {
        public PlaylistModel CurrentPlaylist;
        public PlayerActions State { get; set; }
        public string CurrentSongPath { get; set; }
        public DispatcherTimer PlayTimer { get; set; }

        public event EventHandler PlayerTimerTicked;
        public event EventHandler<string> NewSongPlayed;
        public event EventHandler<string> StateChanged;
        public void PlayTimer_Tick(object sender, EventArgs e)
        {
            //progress bar and timer
        }

        public void NewSong_Play(object sender, string newPath)
        {
            CurrentSongPath = newPath;
            PlayTimer = new DispatcherTimer();
            PlayTimer.Interval = TimeSpan.FromMilliseconds(1000);
            PlayTimer.Tick += new EventHandler(PlayTimer_Tick);
            PlayTimer.Start();
        }

        public void State_Change(object sender, PlayerActions newState)
        {
            if (newState == PlayerActions.Pause)
            {
                PlayTimer.Stop();
            }
            else
             if (newState == PlayerActions.Play)
            {
                PlayTimer.Start();
            }
        }
    }
}
