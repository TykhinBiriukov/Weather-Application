using System.Data.SQLite;
using Weather_Application.Models;

namespace Weather_Application.Interfaces;

public interface IDatabaseValidation
{
    int GetOrInsertCity(WeatherData5Days.CityInfo city, SQLiteConnection connnnection);
    bool ForecastExists(int cityId, DateTime date, SQLiteConnection connnnection);
}
