using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.ForecastModel
{
    class OpenWeatherMapForecastModel
    {
       public List<UnnamedObject> list { get; set; }
    }
    class UnnamedObject
    {
        public Main main { get; set; }
        public long dt { get; set; }
    }

    class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }
        public float humidity { get; set; }
        public float temp_kf { get; set; }
    }
}
