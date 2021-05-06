using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected ICommand UseThePlayerControlCommand { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void PlaySong(string name, string path)
        {
            Tuple<string, string, string> data = new Tuple<string, string, string>("Play", name, path);
            UseThePlayerControlCommand.Execute(data);
        }
    }
}
