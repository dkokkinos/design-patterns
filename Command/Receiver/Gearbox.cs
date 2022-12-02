using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receiver
{
    public class Gearbox
    {
        public enum Gear { FIRST, SECOND, THIRD}

        public Gear CurrentGear { get; private set; } = Gear.FIRST;

        public void Up()
        {
            switch (CurrentGear)
            {
                case Gear.FIRST:
                    CurrentGear = Gear.SECOND;
                    break;
                case Gear.SECOND:
                    CurrentGear = Gear.THIRD;
                    break;
            }
            Console.WriteLine($"Gearbox has {CurrentGear} gear.");
        }

        public void SetGear(Gear gear)
        {
            CurrentGear = gear;
            Console.WriteLine($"Gearbox has {CurrentGear} gear.");
        }

        public void Down()
        {
            switch (CurrentGear)
            {
                case Gear.THIRD:
                    CurrentGear = Gear.SECOND;
                    break;
                case Gear.SECOND:
                    CurrentGear = Gear.FIRST;
                    break;
            }
            Console.WriteLine($"Gearbox has {CurrentGear} gear.");
        }
    }
}
