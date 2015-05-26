﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class WeatherStation
    {
        private event EventHandler<WeatherDataEventArgs> MeasurmentsChanged;

        public float Temperature { get; private set; }
        public float Humidity { get; private set; }
        public float Pressure { get; private set; }
        public float RainQuantity { get; private set; }

        public List<IWeatherObserver<WeatherData>> Observers { get; private set; }

        public WeatherStation()
        {
            this.Observers = new List<IWeatherObserver<WeatherData>>();
        }

        public void Subscribe(IWeatherObserver<WeatherData> observer)
        {
            this.Observers.Add(observer);
            this.MeasurmentsChanged += observer.DisplayUpdatedMeasurments;
        }

        public void Unsubscribe(IWeatherObserver<WeatherData> observer)
        {
            if (this.Observers.Contains(observer))
            {
                this.Observers.Remove(observer);
                this.MeasurmentsChanged -= observer.DisplayUpdatedMeasurments;
            }
        }

        private void OnMeasurementChanged(WeatherDataEventArgs eventArgs)
        {
            EventHandler<WeatherDataEventArgs> handler = MeasurmentsChanged;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        public void SetMeasurments(float temperature, float humidity, float pressure, float rain)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Pressure = pressure;
            this.RainQuantity = rain;

            OnMeasurementChanged(new WeatherDataEventArgs(){ChangedOn = DateTime.Now, WeatherData = new WeatherData(){Humidity = humidity, Pressure = pressure, Temperature = temperature, RainQuantity = rain}});
        }

    }
}
