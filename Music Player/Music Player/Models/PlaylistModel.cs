using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class PlaylistModel
    {
        public string PlaylistName;
        private List<SongModel> _Songs;
        public List<SongModel> Songs
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


        public PlaylistModel(string playlistName, List<SongModel> songs, string coverPath)
        {
            PlaylistName = playlistName;
            Songs = songs;
            if (!String.IsNullOrEmpty(coverPath))
            {
                Cover = new CoverModel(coverPath);
            }
            else
            {
                Cover = null;
            }
        }

        public SongModel FindSong(string name)
        {
            SongModel result = null;

            foreach (SongModel song in Songs)
            {
                if (song.Name == name)
                {
                    result = song;
                }
            }
            return result;
        }

        public SongModel FindNextSong(SongModel song)
        {
            SongModel result = null;

            if (Songs.Contains(song))
            {
                int index = Songs.IndexOf(song);
                if (index + 1 < Songs.Count)
                {
                    result = Songs[index + 1];
                }
            }
            return result;
        }

        public SongModel FindPrevSong(SongModel song)
        {
            SongModel result = null;

            if (Songs.Contains(song))
            {
                int index = Songs.IndexOf(song);
                if (index - 1 >=0)
                {
                    result = Songs[index - 1];
                }
            }
            return result;
        }
    }
}
