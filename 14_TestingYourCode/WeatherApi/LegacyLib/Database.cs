using WeatherApi.Models;

namespace LegacyLib
{
    public class Database
    {
        public static List<WeatherForecast> GetForecastFoRange(DateTime today, int days)
        {
            return Enumerable
                .Range(0, days)
                .Select(index => new WeatherForecast
                {
                    Date = today.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 40)
                })
                .ToList();
        }
    }
}