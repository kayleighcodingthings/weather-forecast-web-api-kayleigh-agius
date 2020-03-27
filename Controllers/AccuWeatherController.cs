using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class AccuWeatherController : Controller
    {
        private AccuWeatherEndpoint accuweatherEndpoint;

        public AccuWeatherController() : base()
        {
            accuweatherEndpoint = new AccuWeatherEndpoint();
        }
        
        private string getLocationKey(string cityName)
        {
            string locationKey = string.Empty;

            restClient.endpoint = accuweatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherLocationModel>> jsonParser = new JSONParser<List<AccuWeatherLocationModel>>();

            List<AccuWeatherLocationModel> deserializedAccuWeatherModel = new List<AccuWeatherLocationModel>();
            deserializedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore3);
            locationKey = deserializedAccuWeatherModel[0].Key;

            return locationKey;
        }

        public float getLongitude(string cityName)
        {
            float longitude = 0f;

            restClient.endpoint = accuweatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();


            JSONParser<List<AccuWeatherLocationModel>> jsonParser = new JSONParser<List<AccuWeatherLocationModel>>();

            List<AccuWeatherLocationModel> deserializedAccuWeatherModel = new List<AccuWeatherLocationModel>();
            deserializedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            longitude = deserializedAccuWeatherModel[0].GeoPosition.Longitude;

            return longitude;
        }

        public float getLatitude(string cityName)
        {
            float latitude = 0f;

            restClient.endpoint = accuweatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();


            JSONParser<List<AccuWeatherLocationModel>> jsonParser = new JSONParser<List<AccuWeatherLocationModel>>();

            List<AccuWeatherLocationModel> deserializedAccuWeatherModel = new List<AccuWeatherLocationModel>();
            deserializedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            
            latitude = deserializedAccuWeatherModel[0].GeoPosition.Latitude;

            return latitude;
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            restClient.endpoint = accuweatherEndpoint.getCurrentConditionsEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherWeatherModel>> jsonParser = new JSONParser<List<AccuWeatherWeatherModel>>();

            List<AccuWeatherWeatherModel> deserialisedAccuWeatherModel = new List<AccuWeatherWeatherModel>();
            deserialisedAccuWeatherModel =  jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedAccuWeatherModel[0].Temperature.Metric.Value;

            return temperature;
        }

        public List<AccuWeatherForecast> getForecast(string cityName)
        {
            List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            restClient.endpoint = accuweatherEndpoint.getForecastEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();

            JSONParser<AccuWeatherForecastModel> jsonParser = new JSONParser<AccuWeatherForecastModel>();

            AccuWeatherForecastModel deserializedAccuWeatherModel = new AccuWeatherForecastModel();
            deserializedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach(DailyForecast dailyForecast in deserializedAccuWeatherModel.DailyForecasts)
            {
                forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            }

            return forecastList;
        }
    }
}
