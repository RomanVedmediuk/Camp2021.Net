using WeatherApi.Models;

namespace WeatherApi.Services;

public interface IWeatherService
{
    List<WeatherForecast> GetWeatherForecastForUser(string userId);
}
