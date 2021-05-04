using Microsoft.Win32;
using Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Music_Player.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private MainViewModel CurrentViewModel;
        private MusicPlayerViewModel MusicPlayerView;
        private MusicLibraryViewModel MusicLibraryView;

        public MainView()
        {
            InitializeComponent();
            CurrentViewModel =  new MainViewModel();
            DataContext = CurrentViewModel;
            MusicPlayerView = new MusicPlayerViewModel();
            MusicLibraryView = new MusicLibraryViewModel();
          //  MusicPlayer = currentModel.SelectedViewModel;

        }
        private void ButtonMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Question.Play();
            this.Close();
        }

        private void ButtonLibrary_Click(object sender, RoutedEventArgs e)
        {
            // MusicLibraryView.Initialize();
            CurrentViewModel.SelectedViewModel = MusicLibraryView;
            
        }

        private void ButtonMusicPlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentViewModel.SelectedViewModel = MusicPlayerView;
        }
        //   private ICommand _changePageCommand;

        //private IPageViewModel _currentPageViewModel;
        //  private List<IPageViewModel> _pageViewModels;


    }
}
