using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IWeatherObservable
    {
        void Subscribe(IWeatherObserver<WeatherData> observer);
        void Unsubscribe(IWeatherObserver<WeatherData> observer);
        void SetMeasurments(WeatherData weatherData);
    }
}
