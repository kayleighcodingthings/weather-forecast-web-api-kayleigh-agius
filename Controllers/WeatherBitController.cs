using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WeatherBitWeatherModel;
using WeatherForecastWebClient.WeatherForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class WeatherBitController : Controller
    {
        private WeatherBitEndpoint weatherBitEndpoint;

        public WeatherBitController() : base()
        {
            weatherBitEndpoint = new WeatherBitEndpoint();
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            restClient.endpoint = weatherBitEndpoint.getCurrentWeatherEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitCurrentWeatherModel> jsonParser = new JSONParser<WeatherBitCurrentWeatherModel>();

            WeatherBitCurrentWeatherModel deserializedWeatherBitCurrentWeatherModel = new WeatherBitCurrentWeatherModel();
            deserializedWeatherBitCurrentWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            temperature = deserializedWeatherBitCurrentWeatherModel.main.temp;

            return temperature;
        }

        public List<WeatherBitForecast> getForecastList(string cityName)
        {
            List<WeatherBitForecast> forecastList = new List<WeatherBitForecast>();

            restClient.endpoint = weatherBitEndpoint.getForecastEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitForecastModel> jsonParser = new JSONParser<WeatherBitForecastModel>();

            WeatherBitForecastModel deserializedWeatherBitForecastModel = new WeatherBitForecastModel();
            deserializedWeatherBitForecastModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (UnnamedObject forecastMain in deserializedWeatherBitForecastModel.list)
            {
                DateTime dateTime = DateTime.Parse(forecastMain.datetime);
                forecastList.Add(new WeatherBitForecast(dateTime, forecastMain.temp));
            }

            return forecastList;
        }
    }
}
