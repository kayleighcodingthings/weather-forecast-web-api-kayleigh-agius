using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.WeatherModel;

namespace WeatherForecastWebClient.Controllers
{
    class OpenWeatherMapController : Controller
    {
        private OpenWeatherMapEndpoint openWeatherMapEndpoint;

        public OpenWeatherMapController() : base()
        {
            this.openWeatherMapEndpoint = new OpenWeatherMapEndpoint();
        }

        public float getCurrentTemperature(string city, EndpointType endpointType)
        {
            float temperature = 0f;

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint(city, endpointType);
            string response = restClient.makeRequest();

            JSONParser<OpenWeatherMapWeatherModel> jsonParser = new JSONParser<OpenWeatherMapWeatherModel>();

            OpenWeatherMapWeatherModel deserialisedOpenWeatherMapModel = new OpenWeatherMapWeatherModel();
            deserialisedOpenWeatherMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore3);

            temperature = deserialisedOpenWeatherMapModel.main.temp;

            return temperature;
        }

        public List<OpenWeatherMapForecast> getForecastList(string city, EndpointType endpoint)
        {
            List<OpenWeatherMapForecast> forecastList = new List<OpenWeatherMapForecast>();

            restClient.endpoint = openWeatherMapEndpoint.getByCityNameEndpoint(city, endpoint);
            string response = restClient.makeRequest();

            JSONParser<OpenWeatherMapForecastModel> jsonParser = new JSONParser<OpenWeatherMapForecastModel>();

            OpenWeatherMapForecastModel deserialisedOpenWeatherMapModel = new OpenWeatherMapForecastModel();
            deserialisedOpenWeatherMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore3);

            foreach (UnnamedObject forecastMain in deserialisedOpenWeatherMapModel.list)
            {
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(forecastMain.dt).UtcDateTime;
                forecastList.Add(new OpenWeatherMapForecast(dateTime, forecastMain.main.temp));
            }
            return forecastList;
        }
    }
}
