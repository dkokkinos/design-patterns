using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class CoffeeMachineFacade
    {
        Pump pump;
        Heater heater;
        Grinder grinder;

        public CoffeeMachineFacade(Pump pump, Heater heater, Grinder grinder)
        {
            this.pump = pump;
            this.heater = heater;
            this.grinder = grinder;
        }

        public void MakeEspresso()
        {
            heater.On();
            heater.SetTemperature(92); // prepare the right temperature

            grinder.Grind();

            pump.PumpWater();

            heater.Off();
        }
    }
}
