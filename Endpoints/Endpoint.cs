using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    public enum EndpointType
    {
        LOCATION,
        CURRENT,
        FORECAST
    }
   abstract class Endpoint
    {
        protected string apiKey;
        protected string baseEndpoint;
        protected string units { get; set; }
        protected string version { get; }
        protected Dictionary<EndpointType, string> endpointTypeDictionary { get; }

        public Endpoint(string apiKey, string baseEndpoint, Dictionary<EndpointType, string> endpointTypeDictionary, string version="", string units="")
        {
            this.apiKey = apiKey;
            this.baseEndpoint = baseEndpoint;
            this.endpointTypeDictionary = endpointTypeDictionary;
            this.version = version;
            this.units = units;
        }

    }
}
