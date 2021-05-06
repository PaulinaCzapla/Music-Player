using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Player.ViewModels.PlayerControls
{
    class PlayViewModel : IPlayerControlViewModel
    {
        public PlayViewModel(string param)
        {
            Execute(param);
        }
        public void Execute(object param) 
        {
            var song = param.ToString();
            MusicPlayerViewModel.Player.Open(new Uri(song));
            MusicPlayerViewModel.Player.Play();
        }
    }
}
