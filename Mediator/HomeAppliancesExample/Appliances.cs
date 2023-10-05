using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.HomeAppliancesExample
{
    public abstract class Appliance
    {
        public IApplianceMediator Mediator { get; set; }
    }

    public class Alarm : Appliance
    {
        public void StartRinging() {
            Console.WriteLine("Alarm starts ringing!");
            Mediator.StateChanged(this, "on");
        }
    }

    public class CoffeeMachine : Appliance
    {
        public void MakeCoffee() 
            => Console.WriteLine("CoffeeMachine: Start making coffee.");
    }

    public class Lights : Appliance
    {
        public void TurnOn() 
            => Console.WriteLine("Lights: Turn ON.");
    }
    
}
