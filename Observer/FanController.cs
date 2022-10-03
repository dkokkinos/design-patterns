using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class FanController : IObserver
    {
        public void Update(IWeatherData state)
        {
            int temperature = state.GetTemperature();
            if (temperature > 30)
                Console.WriteLine($"{nameof(FanController)} => Turning fan ON");
            else
                Console.WriteLine($"{nameof(FanController)} => Turning fan OFF");
        }
    }
}
