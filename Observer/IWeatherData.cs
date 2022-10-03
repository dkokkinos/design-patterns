using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IWeatherData
    {
        int GetHumidity();
        int GetAirSpeed();
        int GetTemperature();
    }
}
