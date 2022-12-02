using Command.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SteerCommand : ICommand
    {
        private readonly ServoMotor _servo;
        private readonly int _degrees;

        public SteerCommand(ServoMotor servo, int degrees)
        {
            this._servo = servo;
            this._degrees = degrees;
        }

        public void Execute()
        {
            _servo.Steer(_degrees);
        }
    }
}
