using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.WeatherBitWeatherModel
{
    [DataContract]
    class WeatherBitCurrentWeatherModel
    {
        [DataMember]
        public Main main { get; set; }
    }

    [DataContract]
    class Main
    {
        [DataMember]
        public float temp { get; set; }
    }
}
