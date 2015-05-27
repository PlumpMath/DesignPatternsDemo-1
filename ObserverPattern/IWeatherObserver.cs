using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IWeatherObserver<T> where T : WeatherData
    {
        void DisplayUpdatedMeasurments(object sender, EventArgs eventArgs);
    }
}
