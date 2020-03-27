using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using WeatherForecastWebClient.WeatherModel;

namespace WeatherForecastWebClient.Parser
{
    public enum Version
    {
        NETCore2, 
        NETCore3
    }
    class JSONParser<T>
    {
        public T parseJSON(string json, Version version)
        {
            var deserializedModel = Activator.CreateInstance(typeof(T));

            switch (version)
            {
                case Version.NETCore3:
                    deserializedModel = JsonSerializer.Deserialize<T>(json);
                    break;
                case Version.NETCore2:
                    var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    deserializedModel = serializer.ReadObject(memoryStream);
                    break;
            }

            return (T) deserializedModel;
        }
    }
}
