using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class SongModel
    {

        public string Name { get; }

        public string Path { get; }

        public SongModel(string path)
        {
            Path = path;
            var pathInfo = path.Split(@"\");
            var songInfo = pathInfo[pathInfo.Length - 1].Split(".");
            Name = songInfo[0];
        }

        public SongModel(SongModel otherSongModel)
        {
            if (otherSongModel != null)
            {
                Path = otherSongModel.Path;
                Name = otherSongModel.Name;
            }
        }

        public SongModel()
        {
            Path = null;
            Name = null;
        }
    }
}
