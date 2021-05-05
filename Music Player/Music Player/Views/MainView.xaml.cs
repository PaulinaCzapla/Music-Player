using Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private MainViewModel MainVM;  

        public MainView()
        {
            InitializeComponent();
            MainVM = new MainViewModel();
            DataContext = MainVM;
        }
        private void ButtonMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLibrary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMusicPlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        //   private ICommand _changePageCommand;

        //private IPageViewModel _currentPageViewModel;
        //  private List<IPageViewModel> _pageViewModels;


    }
}
