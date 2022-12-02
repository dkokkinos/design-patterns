using Command.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Commands
{
    public class StopCommand : ICommand
    {
        private readonly Motor _motor;

        public StopCommand(Motor motor)
        {
            _motor = motor;
        }

        public void Execute()
        {
            _motor.Stop();
        }
    }
}
