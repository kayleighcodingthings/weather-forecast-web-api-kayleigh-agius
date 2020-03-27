using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    
    class OpenWeatherMapEndpoint : Endpoint
    {
        public OpenWeatherMapEndpoint() : base("80ec9ecd7c76904bb7d8d1989f3210fd", "http://api.openweathermap.org/data",
                                        new Dictionary<EndpointType, string> 
                                        { { EndpointType.CURRENT, "weather" },
                                        {EndpointType.FORECAST, "forecast" } },
                                         "2.5", "metric")
        { }



        public string getByCityNameEndpoint(string cityName, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string countryCode, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }
        public string getByCityNameEndpoint(string cityName, string stateName, string countryCode, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(stateName);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }

    }
}
