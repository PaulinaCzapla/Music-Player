using Microsoft.Win32;
using Music_Player.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Music_Player.Views
{
    /// <summary>
    /// Interaction logic for MusicLibraryView.xaml
    /// </summary>
    public partial class MusicLibraryView : UserControl
    {
        private static MusicLibraryViewModel LibraryVM = new MusicLibraryViewModel();
        public MusicLibraryView()
        {
            InitializeComponent();
            Debug.WriteLine("libview");
            DataContext = LibraryVM;
            LibraryVM.DisplayPlaylist(FolderView);
        }

        private void ButtonLibrary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            CreateFolderDialogView inputDialog = new CreateFolderDialogView();

            if (inputDialog.ShowDialog() == true)
            {
                var data = OpenFileDialog();

                LibraryVM.CreatePlaylist(data.Item1, inputDialog.folderNameInput.Text, data.Item2);
            }

            LibraryVM.DisplayPlaylist(FolderView);
        }

        private (string[], string) OpenFileDialog()
        {
            string[] paths = null, files = null;
            string cover = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files (*.mp3;*.PNG;*.JPG;*JPEG)|*.mp3;*.PNG;*.JPG;*.JPEG";

            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                files = openFileDialog.SafeFileNames;
                paths = openFileDialog.FileNames;

                for (int i = 0; i < files.Length; i++)
                {
                    string[] file = files[i].Split('.');
                    if (file[1] == "png" || file[1] == "jpg" || file[1] == "jpeg")
                    {
                        cover = paths[i];
                        paths[i] = null;
                        files[i] = null;

                        continue;
                    }
                }
            }
            return (paths, cover);
        }

        private void FolderView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Debug.WriteLine("changed");
        }
    }
}
