using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;

namespace WeatherForecastWebClient.Controllers
{
    class Weather2020Controller : Controller
    {
        private Weather2020Endpoint weather2020Endpoint;
        private AccuWeatherController accuWeatherController;
        public Weather2020Controller() : base()
        {
            weather2020Endpoint = new Weather2020Endpoint();
        }

        public string getWeather(string cityName)
        {
            string weather = string.Empty;
            float longitude = accuWeatherController.getLongitude(cityName);
            float latitude = accuWeatherController.getLatitude(cityName);

            restClient.endpoint = weather2020Endpoint.getWeatherEndpoint(cityName, latitude, longitude);
            string response = restClient.makeRequest();

            JSONParser<Weather2020CurrentWeatherModel> jsonParser = new JSONParser<Weather2020CurrentWeatherModel>();

            Weather2020CurrentWeatherModel deserializedWeather2020Model = new Weather2020CurrentWeatherModel();
            deserializedWeather2020Model = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            weather = deserializedWeather2020Model.main.regionAffected + " " + deserializedWeather2020Model.main.temperatureHighCelcius + " " + deserializedWeather2020Model.main.temperatureLowCelcius;
       
            return weather;
        }
    }
}
