using Music_Player.Commands;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        
        private MusicLibraryViewModel MusicLibraryViewModel;
        private MusicPlayerViewModel MusicPlayerViewModel;

        private BaseViewModel   _SelectedViewModel;
        public BaseViewModel  SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set 
            { 
                _SelectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            MusicLibraryViewModel = new MusicLibraryViewModel();
            MusicPlayerViewModel = new MusicPlayerViewModel();

            SelectedViewModel = MusicPlayerViewModel;
            UpdateViewCommand = new UpdateViewCommand(this,  MusicPlayerViewModel,  MusicLibraryViewModel);
        }
    }

}
