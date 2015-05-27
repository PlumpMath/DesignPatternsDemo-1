﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class FancyDisplay : IWeatherObserver<WeatherData>
    {
        public IWeatherObservable WeatherStation { get; set; }
        public WeatherData WeatherData { get; set; }

        public FancyDisplay(IWeatherObservable station)
        {
            WeatherStation = station;
            WeatherStation.Subscribe(this);
        }

        public void DisplayUpdatedMeasurments(object sender, WeatherDataEventArgs eventArgs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} notifies FancyDisplay that weather data has changed. New measurments:", sender);
            Console.WriteLine("Temperature: {0}, humidity: {1}, pressure {2}, rain quantity {3} cm^3", eventArgs.WeatherData.Temperature,
                eventArgs.WeatherData.Humidity, eventArgs.WeatherData.Pressure, eventArgs.WeatherData.RainQuantity);
            Console.ResetColor();
        }
    }
}
