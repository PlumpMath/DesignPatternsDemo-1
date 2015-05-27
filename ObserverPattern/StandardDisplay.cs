using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class StandardDisplay : IWeatherObserver<WeatherData>
    {
        public IWeatherObservable WeatherStation { get; set; }
        public WeatherData WeatherData { get; set; }

        public StandardDisplay(IWeatherObservable station)
        {
            WeatherStation = station;
            WeatherStation.Subscribe(this);
        }

        public void DisplayUpdatedMeasurments(object sender, EventArgs eventArgs)
        {
            WeatherDataEventArgs weatherEventArgs = (WeatherDataEventArgs)eventArgs;
            Console.WriteLine("{0} notifies StandardDisplay that weather data has changed. New measurments:", sender);
            Console.WriteLine("Temperature: {0}, humidity: {1}, pressure {2}", weatherEventArgs.WeatherData.Temperature, weatherEventArgs.WeatherData.Humidity, weatherEventArgs.WeatherData.Pressure);
        }
    }
}
