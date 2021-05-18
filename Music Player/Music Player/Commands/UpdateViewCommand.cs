using Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Music_Player.Commands
{


    class UpdateViewCommand : ICommand
    {


        private MainViewModel MainViewModel;
        private MusicLibraryViewModel MusicLibraryViewModel;
        private PlayerControlsViewModel MusicPlayerViewModel;

        public UpdateViewCommand(MainViewModel viewModel, PlayerControlsViewModel musicPlayerViewModel, MusicLibraryViewModel musicLibraryViewModel)
        {
            MainViewModel = viewModel;
            MusicLibraryViewModel = musicLibraryViewModel;
            MusicPlayerViewModel = musicPlayerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "MusicLibrary")
            {
                MainViewModel.SelectedViewModel =  MusicLibraryViewModel;

            } else if (parameter.ToString() == "MusicPlayer")
            {
                MainViewModel.SelectedViewModel =  MusicPlayerViewModel;
            }
        }
    }
}
