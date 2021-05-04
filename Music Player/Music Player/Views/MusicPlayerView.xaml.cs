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

namespace Music_Player.Views
{
    /// <summary>
    /// Interaction logic for MusicPlayerView.xaml
    /// </summary>
    public partial class MusicPlayerView : UserControl
    {
        public MusicPlayerView()
        {
            InitializeComponent();
            DataContext = new Music_Player.ViewModels.MusicPlayerViewModel();
        }


        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            
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
        public void Initialize()
        {
            InitializeComponent();
        }

    }
}
