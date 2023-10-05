using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.HomeAppliancesExample
{
    public interface IApplianceMediator
    {
        void StateChanged(Appliance appliance, string state);
    }

    public class DailyApplianceMediator : IApplianceMediator
    {
        private readonly Alarm _alarm;
        private readonly CoffeeMachine _coffeeMachine;
        private readonly Lights _lights;

        public DailyApplianceMediator(Alarm alarm,
            CoffeeMachine coffeeMachine,
            Lights lights)
        {
            _alarm = alarm;
            _coffeeMachine = coffeeMachine;
            _lights = lights;

            _alarm.Mediator = this;
            _coffeeMachine.Mediator = this;
            _lights.Mediator = this;
        }

        public void StateChanged(Appliance appliance, string state)
        {
            if(appliance.GetType() == typeof(Alarm) && state == "on") 
            {
                // The Mediator coordinates the behavior in case the alarm
                // is set off.
                Console.WriteLine("DailyMediator: The alarm is set. Time to turn on the lights and make some coffee.");
                _coffeeMachine.MakeCoffee();
                _lights.TurnOn();
            }
        }
    }
}
