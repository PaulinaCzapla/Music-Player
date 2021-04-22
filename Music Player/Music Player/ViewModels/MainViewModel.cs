using Music_Player.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _SelectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set { _SelectedViewModel = value; }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            SelectedViewModel = new MusicPlayerViewModel();
            UpdateViewCommand = new UpdateViewCommand(this);

        }
    }

}
