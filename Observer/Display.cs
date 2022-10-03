using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Display : IObserver
    {
        public void Update(IWeatherData state)
        {
            Console.WriteLine("---------- DISPLAY ----------");
            Console.WriteLine($"Temperature: {state.GetTemperature()} degrees Celsius" );
            Console.WriteLine($"Airspeed: {state.GetAirSpeed()} m/s");
            Console.WriteLine($"Humidity: {state.GetHumidity()} g/m3 (grams of moisture per cubic meter of air)");
            Console.WriteLine("-----------------------------");
        }
    }
}
