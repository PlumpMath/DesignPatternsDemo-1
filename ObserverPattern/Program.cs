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
            WeatherStation station = new WeatherStation();
            StandardDisplay weatherDisplay = new StandardDisplay(station);
            FancyDisplay fancyWeatherDisplay = new FancyDisplay(station);

            station.SetMeasurments(43,200,36, 6);
            station.Unsubscribe(fancyWeatherDisplay);
            Console.WriteLine("Fancy display unsubscribed");

            station.SetMeasurments(40, 213, 60, 9);
            
        }
    }
}
