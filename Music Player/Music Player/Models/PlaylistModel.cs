using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class PlaylistModel
    {
        public string PlaylistName;
        private Dictionary<string, SongModel> _Songs;
        public Dictionary<string, SongModel> Songs
        {
            get { return _Songs; }
            private set
            {
                _Songs = value;
            }
        }

        private CoverModel _Cover;
        public CoverModel Cover
        {
            get { return _Cover; }
            private set
            {
                _Cover = value;
            }
        }


        public PlaylistModel(string playlistName, Dictionary<string, SongModel> songs, string coverPath)
        {
            PlaylistName = playlistName;
            Songs = songs;
            Cover = new CoverModel(coverPath);
        }


    }
}
