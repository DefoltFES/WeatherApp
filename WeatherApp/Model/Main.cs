using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    /// <summary>
    /// Класс который используется при десериализации JSON. 
    /// Хранит информацию о температуре на улице.
    /// </summary>
    public class Main : INotifyPropertyChanged
    {
        private float temp;

        [JsonPropertyName("temp")]
        public float Temp { get => temp; set { temp = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
