using Microsoft.Win32;
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
        public MusicLibraryView()
        {
            InitializeComponent();
            DataContext = new Music_Player.ViewModels.MusicLibraryViewModel();

           // var t = new TreeViewItem();


        }

        private void ButtonLibrary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            CreateFolderDialogView inputDialog = new CreateFolderDialogView();

            TreeViewItem item;
            if (inputDialog.ShowDialog() == true)
            {
                Debug.WriteLine("added new folder");

                item = new TreeViewItem();

                item.Header = inputDialog.folderNameInput.Text;
                FolderView.Items.Add(item);

                OpenFileDialog(item);
            }
        }

        private void OpenFileDialog(TreeViewItem item)
        {
            string[] paths, files;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                files = openFileDialog.SafeFileNames;
                paths = openFileDialog.FileNames;

                for (int i = 0; i < files.Length; i++)
                {
                    Debug.WriteLine("{1}", paths[i]);
                    item.Items.Add(files[i]);
                }

            }
        }
    }
}
