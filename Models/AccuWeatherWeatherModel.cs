using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class AccuWeatherWeatherModel
    {
        [DataMember]
        public CurrentTemperature Temperature;
    }
    [DataContract]
    class CurrentTemperature
    {
        [DataMember]
        public MetricUnit Metric;
    }
    [DataContract]
    class MetricUnit
    {
        [DataMember]
        public float Value { get; set; }
    }
}
