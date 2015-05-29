using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Interfaces;

namespace ObserverPattern
{
    public class WeatherStation : IWeatherObservable
    {
        private event EventHandler<WeatherDataEventArgs> MeasurmentsChanged;
        private readonly List<IWeatherObserver<WeatherData>> _observers;

        public float Temperature { get; private set; }
        public float Humidity { get; private set; }
        public float Pressure { get; private set; }
        public float RainQuantity { get; private set; }

        public WeatherStation()
        {
            this._observers = new List<IWeatherObserver<WeatherData>>();
        }

        public void Subscribe(IWeatherObserver<WeatherData> observer)
        {
            this._observers.Add(observer);
            this.MeasurmentsChanged += observer.DisplayUpdatedMeasurments;
        }

        public void Unsubscribe(IWeatherObserver<WeatherData> observer)
        {
            if (this._observers.Contains(observer))
            {
                this._observers.Remove(observer);
                this.MeasurmentsChanged -= observer.DisplayUpdatedMeasurments;
            }
        }
        
        public void SetMeasurments(WeatherData weatherData)
        {
            this.Temperature = weatherData.Temperature;
            this.Humidity = weatherData.Humidity;
            this.Pressure = weatherData.Pressure;
            this.RainQuantity = weatherData.RainQuantity;

            OnMeasurementChanged(new WeatherDataEventArgs(){ChangedOn = DateTime.Now, WeatherData = new WeatherData(){Humidity = Humidity, Pressure = Pressure, Temperature = Temperature, RainQuantity = RainQuantity}});
        }
        
        public WeatherData GetMeasurments()
        {
            return new WeatherData()
            {
                Humidity = Humidity,
                Pressure = Pressure,
                Temperature = Temperature,
                RainQuantity = RainQuantity
            };
        }

        private void OnMeasurementChanged(WeatherDataEventArgs eventArgs)
        {
            EventHandler<WeatherDataEventArgs> handler = MeasurmentsChanged;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

    }
}
