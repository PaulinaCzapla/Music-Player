using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class FileManagerModel
    {
        private string Filename;

        public FileManagerModel(string filename = "userplaylists")
        {
            Filename = filename;
        }

        public void ReadFile() { }

        public void SaveFile() { }
    }
}
