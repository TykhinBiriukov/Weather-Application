using System;
using System.Text.Json;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Interfaces;

public interface IApiConnection
{
    WeatherResponse GetWeatherData(string cityName);
    List<Forecast> GetWeatherData5Days(string cityName);
}