using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        [JsonPropertyName("weather")]
        public Weather[] ListWeather { get;  set; }

        [JsonPropertyName("main")]
        public Main Temperture { get;  set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get;  set; }

        [JsonPropertyName("name")]
        public string NameCity { get;  set; }

    
    }
}
