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
    /// Interaction logic for MusicLibraryView.xaml
    /// </summary>
    public partial class MusicLibraryView : Page
    {
        public MusicLibraryView()
        {
            InitializeComponent();
            DataContext = new Music_Player.ViewModels.MusicLibraryViewModel();
        }
    }
}
