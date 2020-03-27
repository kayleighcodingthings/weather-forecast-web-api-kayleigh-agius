using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.WeatherForecastModel
{
    [DataContract]
    class WeatherBitForecastModel
    {
        [DataMember]
        public List<UnnamedObject> list { get; set; }
    }


    [DataContract]
    class UnnamedObject
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public string datetime { get; set; }
        [DataMember]
        public float min_temp { get; set; }
        [DataMember]
        public float max_temp { get; set; }
    }
}
