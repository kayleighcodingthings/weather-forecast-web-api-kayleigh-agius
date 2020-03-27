using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class AccuWeatherForecastModel
    {
        [DataMember]
        public List<DailyForecast> DailyForecasts;
    }

    [DataContract]
    class DailyForecast
    {
        [DataMember]
        public long EpochDate { get; set; }
        [DataMember]
        public ForecastTemperature Temperature;
    }

    [DataContract]
    class ForecastTemperature
    {
        [DataMember]
        public Metric Minimum;
        [DataMember]
        public Metric Maximum;
    }

    [DataContract]
    class Metric
    {
        [DataMember]
        public float Value { get; set; }
    }
}
