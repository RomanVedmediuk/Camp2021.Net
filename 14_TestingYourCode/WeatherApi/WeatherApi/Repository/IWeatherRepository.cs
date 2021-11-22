using WeatherApi.Models;

namespace WeatherApi.Repository;
public interface IWeatherRepository
{
    public List<WeatherForecast> GetWeatherForecasts(DateTime fromDate, DateTime toDate);
}