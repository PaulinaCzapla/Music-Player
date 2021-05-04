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
    /// Interaction logic for CreateFolderDialogView.xaml
    /// </summary>
    public partial class CreateFolderDialogView : Window
    {
        public CreateFolderDialogView(string _folderName = "playlist")
        {
            InitializeComponent();
            // folderName.Text = _folderName;
            Debug.WriteLine(" dialog created");
        }

        private void buttonDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            if(string.IsNullOrEmpty(folderNameInput.Text))
            {
                folderNameInput.Text = "playlist";
            }
            //calling method that creates a new folder
        }
    }
}
