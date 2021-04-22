using System;
using System.Collections.Generic;
using System.Text;

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
    }

}
