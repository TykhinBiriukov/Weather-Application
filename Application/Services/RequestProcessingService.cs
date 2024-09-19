using System.Linq;
using Weather_Application.Interfaces;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Services;

public class RequestProcessingService : IRequestProcessing
{
    private readonly IApiConnection _connection;
    private readonly IDatabase _database;

    public RequestProcessingService(IApiConnection connection, IDatabase database)
    {
        _connection = connection;
        _database = database;
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
        WeatherForecast weatherData = _connection.GetWeatherData5Days(cityName);
        _database.InsertOrUpdateForecast(weatherData);
        List<Forecast> forecasts = weatherData.list;
        CityInfo cityInfo = weatherData.city;

        string resultMessage = $"\n{cityInfo.name}";

        foreach (Forecast forecast in forecasts)
        {
            string message = $"\nDate: {forecast.dt_txt}" +
                $"\nWeather: {forecast.weather[0]!.main} - {forecast.weather[0]!.description}" +
                $"\n\tProbability of precipitation: {forecast.pop *100}%" +
                $"\nTemperature: {forecast.main!.temp}°C - Feels like: {forecast.main!.feels_like}°C" +
                $"\n\tMin temperature: {forecast.main!.temp_min}°C" +
                $"\n\tMax temperature: {forecast.main!.temp_max}°C" +
                $"\nCloudiness: {forecast.clouds.all}%" +
                $"\nHumidity: {forecast.main!.humidity}%" +
                $"\nWind speed: {forecast.wind!.speed}m/s";
            resultMessage = resultMessage + "\n\n-----------------------------------\n" + message;
        }
        return resultMessage;
    }
}