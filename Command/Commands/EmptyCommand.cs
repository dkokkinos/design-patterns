using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Commands
{
    public class EmptyCommand : IUndoableCommand
    {
        public void Execute()
        {

        }

        public void Undo()
        {

        }
    }
}
