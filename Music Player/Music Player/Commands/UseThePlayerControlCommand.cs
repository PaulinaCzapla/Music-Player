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
            var param = (Tuple<string, string, string>)parameter;
            switch (param.Item1)
            {
                case "Play":

                    PlayerControl = new PlayViewModel( param.Item3);

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
