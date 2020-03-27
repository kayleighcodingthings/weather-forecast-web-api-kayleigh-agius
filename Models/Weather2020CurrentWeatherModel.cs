using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class Weather2020CurrentWeatherModel
    {
        [DataMember]
        public Main main { get; set; }
    }

    [DataContract]
    class Main
    {
        [DataMember]
        public string regionAffected { get; set; }

        [DataMember]
        public int temperatureHighCelcius { get; set; }

        [DataMember]
        public int temperatureLowCelcius { get; set; }
    }
}
