using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    /// <summary>
    /// Класс который используется при десериализации JSON. 
    /// Хранит информацию о температуре на улице.
    /// </summary>
    public class Main
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

    }
}
