namespace Weather_Application.Models;

public class WeatherData5Days
{
    public class WeatherForecast
    {   
        public List<Forecast> list { get; set; } = new List<Forecast>();
        public CityInfo city { get; set; }
    }

    public class Forecast
    {
        public long dt { get; set; }
        public MainInfo main { get; set; }
        public List<WeatherInfo> weather { get; set; } = new List<WeatherInfo>();
        public CloudInfo clouds { get; set; }
        public WindInfo wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; } // Probability of precipitation
        public RainInfo rain { get; set; }
        public SysInfo sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class MainInfo
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; } // Temperature difference
    }

    public class WeatherInfo
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class CloudInfo
    {
        public int all { get; set; } // Cloudiness in percentage
    }

    public class WindInfo
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class RainInfo
    {
        public double _3h { get; set; } // Rain volume for the last 3 hours
    }

    public class SysInfo
    {
        public string pod { get; set; } // Part of the day
    }

    public class CityInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
}