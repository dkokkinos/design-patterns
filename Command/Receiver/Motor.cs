using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receiver
{
    public class Motor
    {
        public void Stop()
        {
            Console.WriteLine($"Motor stopped.");
        }

        public void SetSpeed(int speed)
        {
            if(speed > 0)
                Console.WriteLine($"Moving forward at {speed} m/s");
            else if(speed < 0)
                Console.WriteLine($"Moving backwards at {speed} m/s");
            else
                Console.WriteLine($"Motor stopped.");
        }
    }
}
