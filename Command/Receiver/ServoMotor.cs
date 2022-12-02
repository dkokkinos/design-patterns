using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receiver
{
    public class ServoMotor
    {
        public int Degrees { get; private set; }

        public void Steer(int degrees)
        {
            Console.WriteLine($"Servo motor turned {degrees} degrees.");
            Degrees = degrees;
        }
    }
}
