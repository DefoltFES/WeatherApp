using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WeatherApp.Models;

namespace WeatherApp.ViewModel
{
    /// <summary>
    /// ViewModel для отчета по погоде в этом классе. 
    /// Находятся все свойства и методы для получения ответа от API и отображения его
    /// </summary>
    public class WeatherReportVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _nameCity;
        private int _temperature;
        private float _windSpeed;
        private string _description;

        private static HttpClient _client;
        public string NameCity
        {
            get => _nameCity;
            set
            {
                _nameCity = value;
                OnPropertyChanged(nameof(NameCity));
            }
        }

        public int Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }


        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public float WindSpeed
        {
            get => _windSpeed;
            set
            {
                _windSpeed = value;
                OnPropertyChanged(nameof(WindSpeed));
            }
        }


        /// <summary>
        /// Конструктор ViewModel
        /// При создании класса создается HTTP клиент
        /// </summary>
        static WeatherReportVM()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");

        }


        public async Task GetWeatherForecast(string nameCity)
        {
            if (nameCity == String.Empty)
            {
                MessageBox.Show("Вы ввели пустую строку");
                return;

            }
            HttpResponseMessage response = await _client.GetAsync($"{_client.BaseAddress}?q={nameCity}&lang=RU&units=metric&appid={App.apiKey}");
            if (CanGetWeather(response.StatusCode))
            {
                WeatherForecast content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
                NameCity = content.NameCity;
                WindSpeed = content.Wind.Speed;
                Temperature = Convert.ToInt32(content.Temperture.Temp);
                Description = content.ListWeather.FirstOrDefault().Description;
            }

        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Метод для проверки корректности выполнения запроса
        /// </summary>
        /// <param name="response">
        /// Передаем код статуса запроса и в зависимости от него будет отображено окно с ошибкой или программа будет работать дальше
        /// </param>
        private Boolean CanGetWeather(HttpStatusCode response)
        {

            switch (response)
            {
                case HttpStatusCode.Unauthorized:
                    {
                        MessageBox.Show("Неправильный ключ Api","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                        return false;
                    }
                case HttpStatusCode.NotFound:
                    {
                        MessageBox.Show("Город не найден","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                case HttpStatusCode.OK:
                    {
                        return true;
                    }
                default:
                    {
                        MessageBox.Show(response.ToString(),"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        throw new NotImplementedException(response.ToString());
                    }

            }


        }

    }
}
