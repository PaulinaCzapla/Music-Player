using Music_Player.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Music_Player.ViewModels
{
    class MusicPlayerViewModel : BaseViewModel
    {

        public static MediaPlayer Player = new MediaPlayer();

        private string CurrentSong;
        public  ICommand UseThePlayerControlCommand{ get; set; }
        public MusicPlayerViewModel()
        {
            Debug.WriteLine(" player ");
            UseThePlayerControlCommand = new UseThePlayerControlCommand();
        }

        public void PlaySong(string name, string path)
        {
            Tuple<string, string, string> data = new Tuple<string, string, string>("play", name, path);
            UseThePlayerControlCommand.Execute(data);
        }



    }
}
