using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.WebClient;

namespace WeatherForecastWebClient.Controllers
{
    abstract class Controller
    {
        protected RestClient restClient;

        public Controller() {            
            restClient = new RestClient();
        }

    }
}
