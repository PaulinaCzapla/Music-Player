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
            var pathInfo = path.Split("\\");
            Name = pathInfo[pathInfo.Length - 1];
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
