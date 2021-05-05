using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class SongModel
    {
        public SongModel(string path)
        {
            Path = path;
        }

        private string _Path;

        public string Path
        {
            get
            {
                return _Path;
            }
            private set
            {
                _Path = value;
            }
        }

    }
}
