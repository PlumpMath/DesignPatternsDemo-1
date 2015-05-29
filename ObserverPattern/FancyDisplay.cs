using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Interfaces;

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

        public void DisplayUpdatedMeasurments(object sender, EventArgs eventArgs)
        {
            WeatherDataEventArgs weatherEventArgs = (WeatherDataEventArgs)eventArgs;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} notifies FancyDisplay that weather data has changed. New measurments:", sender);
            Console.WriteLine("Temperature: {0}, humidity: {1}, pressure {2}, rain quantity {3} cm^3", weatherEventArgs.WeatherData.Temperature,
                weatherEventArgs.WeatherData.Humidity, weatherEventArgs.WeatherData.Pressure, weatherEventArgs.WeatherData.RainQuantity);
            Console.ResetColor();
        }

        public void GetWeatherData()
        {
            WeatherData data = WeatherStation.GetMeasurments();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Requested manually: temperature: {0}, humidity: {1}, pressure {2}, rain {3}", data.Temperature, data.Humidity, data.Pressure, data.RainQuantity);
            Console.ResetColor();
        }
    }
}
