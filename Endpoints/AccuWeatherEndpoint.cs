using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class AccuWeatherEndpoint : Endpoint
    {
        public AccuWeatherEndpoint() : base("8WPKZuBP99FVCkkdFe2SLwRrr13c0Bzp", "http://dataservice.accuweather.com",
                                new Dictionary<EndpointType, string>
                                { {EndpointType.LOCATION, "locations"},
                                    { EndpointType.CURRENT, "currentconditions" },
                                        {EndpointType.FORECAST, "forecasts" } },
                                "v1")
        { }

        public string getLocationsEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.LOCATION]}");
            stringBuilder.Append($"/{version}");
            stringBuilder.Append("/cities");
            stringBuilder.Append("/search");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&q=");
            stringBuilder.Append(cityName);
            return stringBuilder.ToString();
        }

        public string getCurrentConditionsEndpoint(string locationKey)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.CURRENT]}");
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{locationKey}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            return stringBuilder.ToString();
        }

        public string getForecastEndpoint(string locationKey)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append($"/{version}");
            stringBuilder.Append("/daily");
            stringBuilder.Append("/5day");
            stringBuilder.Append($"/{locationKey}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&metric=true");
            return stringBuilder.ToString();
        }
    }
}
