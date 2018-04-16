using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Plugins
{
    public class MoveCommand : Client.Command
    {
        int Meters { get; set; }
        public MoveCommand(int meters)
        {
            this.Meters = meters;
        }
        public override void Execute()
        {
            Console.WriteLine($"moving {this.Meters} meters");
        }

        public override void Redo()
        {
            Console.WriteLine($"again moving {this.Meters} meters");
        }

        public override void Undo()
        {
            Console.WriteLine($"back {this.Meters} meters");
        }
    }
}
