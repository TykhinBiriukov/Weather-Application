using System.Data.SQLite;
using Weather_Application.Interfaces;
using Weather_Application.Models;

namespace Weather_Application.Services
{
    public class DatabaseValidationService : IDatabaseValidation
    {
        public int GetOrInsertCity(WeatherData5Days.CityInfo city, SQLiteConnection connection)
        {
            string cityQuerty = "SELECT id FROM City WHERE id = @id";

            using (var cmd = new SQLiteCommand(cityQuerty, connection))
            {
                cmd.Parameters.AddWithValue("@id", city.id);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(city.id);
                }
                else
                {
                    string insertCityQuerty = "INSERT INTO City (id, name, country) VALUES (@id, @name, @country)";

                    using (var insertConnection = new SQLiteCommand(insertCityQuerty, connection))
                    {
                        insertConnection.Parameters.AddWithValue("@id", city.id);
                        insertConnection.Parameters.AddWithValue("@name", city.name);
                        insertConnection.Parameters.AddWithValue("@country", city.country);

                        insertConnection.ExecuteNonQuery();
                    }
                    return city.id;
                }
            }
        }

        public bool ForecastExists(int cityId, DateTime date, SQLiteConnection connection)
        {
            string forecastQuerty = "SELECT COUNT(1) FROM Forecast WHERE city_id = @cityId AND date = @date";

            using ( var cmd = new SQLiteCommand(forecastQuerty, connection))
            {
                cmd.Parameters.AddWithValue("@cityId", cityId);
                cmd.Parameters.AddWithValue("@date", date);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
