using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Commands
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public MacroCommand(params ICommand[] commands)
        {
            _commands = commands.ToList();
        }

        public void Execute()
        {
            foreach (var cmd in _commands)
                cmd.Execute();
        }
    }
}
