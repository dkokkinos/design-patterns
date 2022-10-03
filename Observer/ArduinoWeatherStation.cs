using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class ArduinoWeatherStation : ISubject
    {
        private IWeatherData _state;

        public List<IObserver> _observers;

        public ArduinoWeatherStation()
        {
            _observers = new();
        }

        public void AddObserver(IObserver observer)
            => _observers.Add(observer);

        public void RemoveObserver(IObserver observer)
            => _observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.Update(_state);
        }

        public void DataReceivedFromSensors(int humidity, int airspeed, int temperature)
        {
            _state = new ArduinoWeatherStationData(humidity, airspeed, temperature);
            NotifyObservers();
        }
    }

    public class ArduinoWeatherStationData : IWeatherData
    {
        private readonly int _humidity;
        private readonly int _airspeed;
        private readonly int _temperature;

        public ArduinoWeatherStationData(int humidity, int airspeed, int temperature)
        {
            _humidity = humidity;
            _airspeed = airspeed;
            _temperature = temperature;
        }

        public int GetAirSpeed()
            => _airspeed;

        public int GetHumidity()
            => _humidity;

        public int GetTemperature()
            => _temperature;
    }
}
