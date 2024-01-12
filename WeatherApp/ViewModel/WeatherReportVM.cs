using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModel
{
    public class WeatherReportVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private WeatherForecast _forecastModel;

        private static HttpClient _client;
        public string NameCity
        {
            get => _forecastModel.NameCity;
            set
            {
                _forecastModel.NameCity = value;
                OnPropertyChanged(nameof(NameCity));
            }
        }

        public float Temperature
        {
            get
            {
                if (_forecastModel.Temperture is not null)
                {
                    return _forecastModel.Temperture.Temp;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _forecastModel.Temperture.Temp = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }


        public string Description
        {
            get
            {
                if (_forecastModel.ListWeather is not null)
                {
                    return _forecastModel.ListWeather.FirstOrDefault().Description;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _forecastModel.ListWeather.FirstOrDefault().Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public float WindSpeed
        {
            get
            {
                if (_forecastModel.Wind is not null)
                {
                    return _forecastModel.Wind.Speed;
                }
                else { 
                    return 0; 
                }
            }
            set
            {
                _forecastModel.Wind.Speed = value;
                OnPropertyChanged(nameof(WindSpeed));
            }
        }



        static WeatherReportVM()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");

        }

        public async Task GetWeatherForecast(string nameCity)
        {
            _forecastModel = await _client.GetFromJsonAsync<WeatherForecast>($"{_client.BaseAddress}?q={nameCity}&lang=RU&units=metric&appid={App.apiKey}");
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
