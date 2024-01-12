using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }
    }
}
