using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class WeatherBitEndpoint : Endpoint
    {
        //http://api.weatherbit.io/v2.0/current?key={your api key}&units=M&city{city name}&country={country code}
     
        //http://api.weatherbit.io/v2.0/forecast/daily?key={your api key}&units=M&city{city name}&country={country code}
    
        public WeatherBitEndpoint() : base("9f821d0ffc7145f693d26f40455b9fc6", "http://api.weatherbit.io",
                                new Dictionary<EndpointType, string> 
                                { { EndpointType.CURRENT, "current"},
                                    { EndpointType.FORECAST, "forecast" } },
                                "v2.0", "M") 
        { }

        public string getCurrentWeatherEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.CURRENT]}");
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);

            return stringBuilder.ToString();
        }
        public string getCurrentWeatherEndpoint(string cityName, string countryCode) 
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.CURRENT]}");
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&country=");
            stringBuilder.Append(countryCode);

            return stringBuilder.ToString();
        }

        public string getForecastEndpoint(string cityName)
        {
            
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);

            return stringBuilder.ToString();
        }

        public string getForecastEndpoint(string cityName, string countryCode)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&country=");
            stringBuilder.Append(countryCode);

            return stringBuilder.ToString();
        }
    }
}
