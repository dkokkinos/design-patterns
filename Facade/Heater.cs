using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Heater
    {
        public void On()
        {
            Console.WriteLine("Turning the heater on");
        }

        public void Off()
        {
            Console.WriteLine("Turning the heater off");
        }

        public void SetTemperature(int degrees)
        {
            Console.WriteLine($"Heating the water at {degrees} degrees");
        }
    }
}
