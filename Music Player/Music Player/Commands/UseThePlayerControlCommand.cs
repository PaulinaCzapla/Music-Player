using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
            var param = (Tuple<PlayerActions, string, string>)parameter;
            switch (param.Item1)
            {
                case PlayerActions.Play:

                    PlayerControl = new PlayViewModel( param.Item3);

                    break;

                case PlayerActions.Pause:

                    PlayerControl = new PauseViewModel();

                    break;

                case PlayerActions.PlayPrevious:

                    PlayerControl = new PreviousViewModel();

                    break;

                case PlayerActions.PlayNext:

                    PlayerControl = new NextViewModel();

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
