using System.Data.SQLite;
using Weather_Application.Interfaces;

namespace Weather_Application.Services;

public class DatabaseHelper : IDatabaseHelper
{
    private readonly string _connectionString = @"Data Source=D:\Programming\Projects\C#\Weather Application\Application\Files\Forecastdata.db;Version=3;";

    public void InitDatabase()
    {
        if (!File.Exists(@"D:\Programming\Projects\C#\Weather Application\Application\Files\Forecastdata.db"))
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string createCityInfoTableQuerty = @"
                    CREATE TABLE IF NOT EXISTS city (
                        id INTEGER PRIMARY KEY,
                        name TEXT NOT NULL,
                        country TEXT NOT NULL
                    );";

                string createForecastInfoTableQuerty = @"
                    CREATE TABLE IF NOT EXISTS forecast (
                        city_id INTEGER NOT NULL,
                        date TEXT NOT NULL,
                        temp REAL,
                        temp_min REAL,
                        temp_max REAL,
                        humidity INTEGER,
                        weather_main TEXT,
                        weather_description TEXT,
                        wind_speed REAL,
                        visibility INTEGER,
                        pop REAL,
                        rain REAL,
                        FOREIGN KEY(city_id) REFERENCES City(id),
                        UNIQUE(city_id, date)
                    );";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = createCityInfoTableQuerty;
                    command.ExecuteNonQuery();

                    command.CommandText = createForecastInfoTableQuerty;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}