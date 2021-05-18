using Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Music_Player.Views
{
    /// <summary>
    /// Interaction logic for MusicPlayerView.xaml
    /// </summary>
    public partial class MusicPlayerView : UserControl
    {
        private bool IsPlaying;
        private DispatcherTimer playTimer;
        private static PlayerControlsViewModel PlayerVM = new PlayerControlsViewModel();
        public MusicPlayerView()
        {
            InitializeComponent();
            DataContext = PlayerVM;
            songProgressBar.Maximum = 1;
            progressStatus.Text = "00:00:00";
            songLength.Text = "00:00:00";

            

            playTimer = new DispatcherTimer();
            playTimer.Interval = TimeSpan.FromMilliseconds(1000); 
            playTimer.Tick += new EventHandler(playTimer_Tick);
            playTimer.Start();
        }

        public void playTimer_Tick(object sender, EventArgs e)
        {
            //if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            //{
            //    progressBar.Value = BackgroundAudioPlayer.Instance.Position.TotalSeconds;
            //    try
            //    {
            //        CurrentTime.Text = String.Format(@"{0:hh\:mm\:ss}",
            //        BackgroundAudioPlayer.Instance.Position).Remove(8);
            //    }
            //    catch
            //    {
            //        CurrentTime.Text = String.Format(@"{0:hh\:mm\:ss}",
            //        BackgroundAudioPlayer.Instance.Position);
            //    }
            //}
        }
        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            PlayerVM.PlayPause();
        }

        private void ButtonPreviousSong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSkip_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonShuffle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRepeat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void songProgressBar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {

        }

        private void songProgressBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {

        }

        private void songProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
