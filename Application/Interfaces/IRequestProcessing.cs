using System.Text.Json;

namespace Weather_Application.Interfaces;

public interface IRequestProcessing
{
    string PrintWeatherData(string weatherResponse);
    string PrintWeatherData5Days(string cityName);
}
