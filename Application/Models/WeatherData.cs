using Weather_Application.Interfaces;

namespace Weather_Application.Models;

public class WeatherData
{
    public MainInfo? main { get; set; }
    public List<WeatherInfo>? weather { get; set; } = new List<WeatherInfo>();
    public WindInfo? wind { get; set; }

    public class MainInfo
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int humidity { get; set; }
    }

    public class WeatherInfo
    {
        public string? main { get; set; }
        public string? description { get; set; }
    }

    public class WindInfo
    {
        public double speed { get; set; }
    }
}