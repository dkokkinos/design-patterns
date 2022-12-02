using Command.Receiver;

namespace Command
{
    public class MoveCommand: ICommand
    {
        protected readonly Motor _motor;
        protected readonly int _speed;

        public MoveCommand(Motor motor, int speed)
        {
            this._motor = motor;
            this._speed = speed;
        }

        public void Execute()
        {
            _motor.SetSpeed(_speed);
        }
    }
}
