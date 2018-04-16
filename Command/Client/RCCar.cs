using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Client
{
    public class RCCar
    {
        ICollection<Command> Commands { get; set; }
        int _current = 0;

        public RCCar()
        {
            this.Commands = new List<Command>();
        }

        public void ExecuteCommand(Command c)
        {
            if(this._current < this.Commands.Count)
            {
                int times = this.Commands.Count - this._current;
                for (int i = 0; i < times; i++ )
                    this.Commands.Remove(this.Commands.Last());

            }

            this.Commands.Add(c);
            c.Execute();
            _current++;
        }

        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = this.Commands.ElementAt(--_current);
                    command.Undo();
                }
            }
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (_current < this.Commands.Count )
                {
                    Command command = this.Commands.ElementAt(_current++);
                    command.Redo();
                }
            }
        }

    }
}
