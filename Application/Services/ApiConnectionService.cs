using System;
using System.Net.Http;
using System.Text.Json;
using Weather_Application.Interfaces;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Services;

public class ApiConnectionService : IApiConnection
{
    readonly string apiKey = "2cee8abef221c8d927bf2a345962fd6c";

    public WeatherResponse GetWeatherData(string cityName)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

        string jsonResult = SetUpClient(url);

        return JsonSerializer.Deserialize<WeatherResponse>(jsonResult)!;
    }

    public List<Forecast> GetWeatherData5Days(string cityName)
    {
        string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}&units=metric";

        string jsonResult = SetUpClient(url);

        WeatherForecast weatherData = JsonSerializer.Deserialize<WeatherForecast>(jsonResult)!;
        List<Forecast> forecasts = weatherData.list;
        return forecasts;
    }

    static string SetUpClient(string url)
    {
        var client = new HttpClient();
        return client.GetStringAsync(url).Result;
    }
}