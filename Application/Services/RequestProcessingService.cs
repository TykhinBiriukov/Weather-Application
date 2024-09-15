using System.Linq;
using Weather_Application.Interfaces;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Services;

public class RequestProcessingService : IRequestProcessing
{
    private readonly IApiConnection _connection;

    public RequestProcessingService(IApiConnection connection)
    {
        _connection = connection;
    }
    public string PrintWeatherData(string cityName)
    {
        WeatherResponse weatherData = _connection.GetWeatherData(cityName);

        string resultMessage = $"\nWeather: {weatherData.weather[0]!.main} - {weatherData.weather[0]!.description}" +
                $"\nTemperature: {weatherData.main!.temp}°C - Feels like: {weatherData.main!.feels_like}°C" +
                $"\n\tMin temperature: {weatherData.main!.temp_min}°C" +
                $"\n\tMax temperature: {weatherData.main!.temp_max}°C" +
                $"\nCloudiness: {weatherData.clouds.all}%" +
                $"\nHumidity: {weatherData.main!.humidity}%" +
                $"\nWind speed: {weatherData.wind!.speed}m/s";
        return resultMessage;
    }

    public string PrintWeatherData5Days(string cityName)
    {
        List<Forecast> forcasts = _connection.GetWeatherData5Days(cityName);
        string resultMessage = null!;

        foreach (Forecast forcast in forcasts)
        {
            string message = $"\nDate: {forcast.dt_txt}" +
                $"\nWeather: {forcast.weather[0]!.main} - {forcast.weather[0]!.description}" +
                $"\n\tProbability of precipitation: {forcast.pop *100}%" +
                $"\nTemperature: {forcast.main!.temp}°C - Feels like: {forcast.main!.feels_like}°C" +
                $"\n\tMin temperature: {forcast.main!.temp_min}°C" +
                $"\n\tMax temperature: {forcast.main!.temp_max}°C" +
                $"\nCloudiness: {forcast.clouds.all}%" +
                $"\nHumidity: {forcast.main!.humidity}%" +
                $"\nWind speed: {forcast.wind!.speed}m/s";
            resultMessage = resultMessage + "\n\n-----------------------------------\n" + message;
        }
        return resultMessage;
    }
}