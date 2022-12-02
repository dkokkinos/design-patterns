using Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class RemoteControl
    {
        readonly ICommand[] onCommands;
        readonly ICommand[] offCommands;

        IUndoableCommand undoCommand;

        public RemoteControl()
        {
            var emptyCommand = new EmptyCommand();
            onCommands = new ICommand[6];
            offCommands = new ICommand[6];
            for (int i = 0; i < 6; i++)
            {
                onCommands[i] = emptyCommand;
                offCommands[i] = emptyCommand;
            }

            undoCommand = emptyCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void ButtonPushed(int slot)
        {
            onCommands[slot].Execute();
            if (onCommands[slot] is IUndoableCommand undoableCmd)
                undoCommand = undoableCmd;
        }

        public void ButtonReleased(int slot)
            => offCommands[slot].Execute();

        public void UndoPressed()
            => undoCommand.Undo();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------- REMOTE CONTROL ---------");
            for(int i = 0; i < 6; i++)
            {
                sb.AppendLine($"slot[{i}] -> Pressed:{onCommands[i].GetType().Name} Released:{offCommands[i].GetType().Name}");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
