using System.Data.SQLite;
using Weather_Application.Models;
using static Weather_Application.Models.WeatherData5Days;

namespace Weather_Application.Services
{
    public interface IDatabase
    {
        void InsertOrUpdateForecast(WeatherForecast weatherData);
        void InsertForecast(int cityId, Forecast forecast, DateTime date, SQLiteConnection connnnection);
    }
}
