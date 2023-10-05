using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.RCCar_Example
{
    internal class RCCar
    {
        public void Move(int speed)
            => Console.WriteLine("Moving at speed: " + speed);

        public void Stop()
            => Console.WriteLine("Stoped");

        public void Steer(int direction)
            => Console.WriteLine($"Steered {(direction == 0 ? "Left" : "Right")}");
    }
}
