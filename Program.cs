using System;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WebClient;
using WeatherForecastWebClient.Output;
using System.Text.Json;
using WeatherForecastWebClient.WeatherModel;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.Controllers;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;

            //OpenWeatherMap
            openWeatherMapAPI();

            Console.WriteLine("\n\n");

            openWeatherForecastAPI();

            Console.WriteLine("\n\n");

            //AccuWeather
          //  accuWeatherCurrentConditionsAPI();

            Console.WriteLine("\n\n");

      //      accuWeatherForecastAPI();

            Console.WriteLine("\n\n");

            //Weather Bit

            //weatherBitCurrentWeatherAPI();

            Console.WriteLine("\n\n");

            weatherBitForecastAPI();

            //DarkSky 

            Console.WriteLine("\n\n");

            //Weather2020

            weather2020WeatherAPI();

            Console.ReadKey();
        }

        static void openWeatherMapAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("*** Open Weather Map Current Weather ***");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");

            cityName = "London";

            output.outputToConsole($"Temperature {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");

        }

        static void openWeatherForecastAPI()
        {
            Out output = new Out();
            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();


            output.outputToConsole("*** Open Weather Map Forecast ***");

            string cityName = "Valletta";

            output.outputToConsole($"*** Forecast for: {cityName} ***");

            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecastList(cityName, EndpointType.FORECAST))
            {
                output.outputToConsole($"Date/Time: {forecast.dateTime} Temperature: {forecast.temperature}");
            }
        }

        static void accuWeatherCurrentConditionsAPI()
        {
            Out output = new Out();

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            output.outputToConsole("*** AccuWeather Current Conditions ***");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature {cityName}: {accuWeatherController.getCurrentWeather(cityName)}");
        }

        static void accuWeatherForecastAPI()
        {
            Out output = new Out();
            AccuWeatherController accuWeatherController = new AccuWeatherController();


            output.outputToConsole("*** AccuWeather Forecast ***");

            string cityName = "Valletta";

            output.outputToConsole($"*** Forecast for: {cityName} ***");

            foreach(AccuWeatherForecast forecast in accuWeatherController.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }

        static void weatherBitCurrentWeatherAPI()
        {
            Out output = new Out();
            WeatherBitController weatherBitController = new WeatherBitController();

            output.outputToConsole("*** WeatherBit Current Weather ***");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature {cityName}: {weatherBitController.getCurrentWeather(cityName)}");

        }

        static void weatherBitForecastAPI()
        {
            Out output = new Out();
            WeatherBitController weatherBitController = new WeatherBitController();

            output.outputToConsole("*** WeatherBit Forecast ***");

            string cityName = "Valletta";

            output.outputToConsole($"*** Forecast for: {cityName} ***");

            foreach (WeatherBitForecast forecast in weatherBitController.getForecastList(cityName))
            {
                output.outputToConsole($"Date: {forecast.dateTime} Temperature: {forecast.temperature}");
            }
        }

        static void weather2020WeatherAPI()
        {
            Out output = new Out();
            Weather2020Controller weather2020Controller = new Weather2020Controller();

            output.outputToConsole("*** Weather2020 Weather ***");

            string cityName = "Valletta";

            output.outputToConsole($"Weather for {cityName}: {weather2020Controller.getWeather(cityName)}");
        }
    }
}
