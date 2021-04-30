using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Music_Player.Models;

namespace Music_Player.ViewModels
{
    class FileDialogViewModel
    {

        void OpenFileDialog(PlaylistModel playlist)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
               // mediaPlayer.Open(new Uri(openFileDialog.FileName));
               // mediaPlayer.Play();
            }
        }
    }
}
