using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Output
{
    class Out
    {
        public void outputToConsole(string output)
        {
            Console.WriteLine(output);
        }

        public void debugOutput(string debugOutput)
        {
            System.Diagnostics.Debug.WriteLine(debugOutput + Environment.NewLine);
        }
    }
}
