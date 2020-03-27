using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{

    class AccuWeatherForecast

    {
        private DateTime dateTime;
        private float min;
        private float max;

        public AccuWeatherForecast(long epochDateTime, float min, float max)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.min = min;
            this.max = max;
        }

        public DateTime getDateTime()
        {
            return dateTime; 
        }

        public float getMinimum()
        {
            return min;
        }

        public float getMaximum()
        {
            return max;
        }
    }
}
