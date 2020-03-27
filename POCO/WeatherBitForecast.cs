using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class WeatherBitForecast
    {
        public DateTime dateTime { get; }
        public float temperature { get; }

        public WeatherBitForecast(DateTime dateTime, float temperature)
        {
            this.dateTime = dateTime;
            this.temperature = temperature;
        }
    }
}
