using Command.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Commands
{
    public class GearDownCommand : IUndoableCommand
    {
        private readonly Gearbox _gearbox;
        Gearbox.Gear prevGear;

        public GearDownCommand(Gearbox gearbox)
        {
            _gearbox = gearbox;
        }

        public void Execute()
        {
            prevGear = _gearbox.CurrentGear;
            _gearbox.Down();
        }

        public void Undo()
            => _gearbox.SetGear(prevGear);
        
    }
}
