using System.Data.SQLite;
using Weather_Application.Interfaces;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Services;

public class DatabaseService : IDatabase
{
    private static readonly string _connectionString = @"Data Source=D:\Programming\Projects\C#\Weather Application\Application\Files\Forecastdata.db;Version=3;";
    private readonly IDatabaseValidation _databaseValidation;

    public DatabaseService(IDatabaseValidation databaseValidation)
    {
        _databaseValidation = databaseValidation;
}

    public void InsertOrUpdateForecast(WeatherForecast weatherData)
    {
        var city = weatherData.city;

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            foreach (var forecast in weatherData.list)
            {
                int cityId = _databaseValidation.GetOrInsertCity(city, connection);

                var forecastDate = DateTime.Parse(forecast.dt_txt).Date;
                if (!_databaseValidation.ForecastExists(cityId, forecastDate, connection))
                {
                    InsertForecast(cityId, forecast, forecastDate, connection);
                }
            }
        }
    }

    public void InsertForecast(int cityId, Forecast forecast, DateTime forecastDate, SQLiteConnection connnnection)
    {
        string insertQuerty = @"INSERT INTO Forecast (city_id, date, temp, temp_min, temp_max, humidity, weather_main, weather_description, wind_speed, visibility, pop, rain) 
            VALUES (@cityId, @date, @temp, @tempMin, @tempMax, @humidity, @weatherMain, @weatherDescription, @windSpeed, @visibility, @pop, @rain)";

        using (var cmd = new SQLiteCommand(insertQuerty, connnnection))
        {
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.Parameters.AddWithValue("@date", forecast.dt_txt);
            cmd.Parameters.AddWithValue("@temp", forecast.main.temp);
            cmd.Parameters.AddWithValue("@tempMin", forecast.main.temp_min);
            cmd.Parameters.AddWithValue("@tempMax", forecast.main.temp_max);
            cmd.Parameters.AddWithValue("@humidity", forecast.main.humidity);
            cmd.Parameters.AddWithValue("@weatherMain", forecast.weather[0].main);
            cmd.Parameters.AddWithValue("@weatherDescription", forecast.weather[0].description);
            cmd.Parameters.AddWithValue("@windSpeed", forecast.wind.speed);
            cmd.Parameters.AddWithValue("@visibility", forecast.visibility);
            cmd.Parameters.AddWithValue("@pop", forecast.pop);
            cmd.Parameters.AddWithValue("@rain", forecast.rain);

            cmd.ExecuteNonQuery();
        }
    }
}