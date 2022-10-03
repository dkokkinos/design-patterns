﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Program
    {
        public static void Main()
        {
            ArduinoWeatherStation weatherStation = new ArduinoWeatherStation();

            Display display = new Display();
            FanController fanController = new FanController();

            weatherStation.AddObserver(display);
            weatherStation.AddObserver(fanController);

            weatherStation.DataReceivedFromArduino(10, 20, 25);
            weatherStation.DataReceivedFromArduino(12, 22, 32);
        }


    }
}
