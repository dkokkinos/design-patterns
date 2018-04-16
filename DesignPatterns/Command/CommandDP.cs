using Comm = Command.Client.Command;
using Command.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Client;

namespace DesignPatterns.Command
{
    public class CommandDP : IDesignPattern
    {
        public void Run()
        {
            RCCar invoker = new RCCar();
            Comm moveCommand = new MoveCommand(5);
            Comm moveCommand2 = new MoveCommand(10);

            invoker.ExecuteCommand(moveCommand);
            invoker.ExecuteCommand(moveCommand2);

            invoker.Redo(3);

            invoker.Undo(3);

            invoker.Redo(2);

            invoker.Undo(1);

            invoker.ExecuteCommand(new MoveCommand(20));

            invoker.Undo(10);
        }
    }
}
