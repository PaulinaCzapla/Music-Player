using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Music_Player.Models;
using Music_Player.ViewModels.PlayerControls;

namespace Music_Player.Commands

{
    class UseThePlayerControlCommand : ICommand
    {


        private IPlayerControlViewModel PlayerControl;

        public UseThePlayerControlCommand()
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var param = (Tuple<PlayerActions, SongModel, PlaylistModel>)parameter;
            switch (param.Item1)
            {
                case PlayerActions.Play:

                    PlayerControl = new PlayViewModel( new Tuple<SongModel, PlaylistModel> (param.Item2, param.Item3) );

                    break;

                case PlayerActions.Pause:

                    PlayerControl = new PauseViewModel();

                    break;

                case PlayerActions.PlayPrevious:

                    PlayerControl = new PreviousViewModel(new Tuple<SongModel, PlaylistModel>(param.Item2, param.Item3));

                    break;

                case PlayerActions.PlayNext:

                    PlayerControl = new NextViewModel(new Tuple<SongModel, PlaylistModel>(param.Item2, param.Item3));

                    break;

                case PlayerActions.Shuffle:

                    PlayerControl = new ShuffleViewModel();

                    break;

                case PlayerActions.Loop:

                    PlayerControl = new LoopViewModel();

                    break;

                default:
                    break;
            }
        }
    }
}
