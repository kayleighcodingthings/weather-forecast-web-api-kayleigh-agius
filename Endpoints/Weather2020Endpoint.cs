using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class Weather2020Endpoint : Endpoint
    {
        //http://api.weather2020.com/YOURAPIKEY/LATITUDE,LONGITUDE

        public Weather2020Endpoint() : base("e8ecee8ff60c478f8a36280fea0524fe", "http://api.weather2020.com", new Dictionary<EndpointType, string>, "", "")
        {

        }

        public string getWeatherEndpoint(string cityName, float longitude, float latitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{apiKey}");
            stringBuilder.Append($"/{latitude},{longitude}");

            return stringBuilder.ToString();
        }
    }
}
