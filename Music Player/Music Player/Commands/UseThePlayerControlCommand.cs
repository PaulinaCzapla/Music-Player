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

        public UseThePlayerControlCommand(IPlayerControlViewModel playerControl)
        {
            PlayerControl = playerControl;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Play":

                    PlayerControl = new PlayViewModel();

                    break;

                case "Pause":

                    PlayerControl = new PauseViewModel();

                    break;

                case "Previous":

                    PlayerControl = new PreviousViewModel();

                    break;

                case "Next":

                    PlayerControl = new NextViewModel();

                    break;

                case "Shuffle":

                    PlayerControl = new ShuffleViewModel();

                    break;

                case "Loop":

                    PlayerControl = new LoopViewModel();

                    break;

                default:
                    break;
            }
        }
    }
}
