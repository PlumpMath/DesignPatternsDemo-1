using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherObservable station = new WeatherStation();
            StandardDisplay weatherDisplay = new StandardDisplay(station);
            FancyDisplay fancyWeatherDisplay = new FancyDisplay(station);

            station.SetMeasurments(new WeatherData(){Humidity = 69, Pressure = 90, RainQuantity = 46, Temperature = 28});
            station.Unsubscribe(fancyWeatherDisplay);
            Console.WriteLine("Fancy display unsubscribed");

            station.SetMeasurments(new WeatherData() { Humidity = 60, Pressure = 99, RainQuantity = 11, Temperature = 26 });
            
        }
    }
}
