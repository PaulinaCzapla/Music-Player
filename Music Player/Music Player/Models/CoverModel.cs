using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.Models
{
    class CoverModel
    {
        public CoverModel(string path)
        {
            Path = path;
        }
        private string Path { get; }
    }
}
