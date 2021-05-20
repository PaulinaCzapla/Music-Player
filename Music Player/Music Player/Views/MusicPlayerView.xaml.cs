using Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
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
        private PlayerControlsViewModel PlayerControlVM;
        public MusicPlayerView()
        {
            InitializeComponent();
            PlayerControlVM = new PlayerControlsViewModel();
            DataContext = PlayerControlVM;
            songProgressBar.Maximum = 1;

            UpdateView();
            PlayerControlsViewModel.CurrentState.PlayerTimerTicked += PlayTimer_Tick;
        }

        private void UpdateView()
        {
            progressStatus.Text = PlayerControlsViewModel.CurrentState.Position.ToString(@"hh\:mm\:ss");
            songLength.Text = PlayerControlVM.GetCurrentSongDuration().ToString(@"hh\:mm\:ss");
            cover.ImageSource = PlayerControlVM.DisplayCover();
            textBlockPlaylist.Text = PlayerControlVM.GetCurrentPlaylistName();
            textBlockTitle.Text = PlayerControlVM.GetCurrentSongName();
        }
        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            PlayerControlVM.PlayPause();
        }

        private void ButtonPreviousSong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSkip_Click(object sender, RoutedEventArgs e)
        {
            PlayerControlVM.PlayNext();
            UpdateView();
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


        public void PlayTimer_Tick(object sender, string e)
        {              
            progressStatus.Text =e;

        }
    }
}
