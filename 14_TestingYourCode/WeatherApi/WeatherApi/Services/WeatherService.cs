using WeatherApi.Models;
using WeatherApi.Providers;
using WeatherApi.Repository;

namespace WeatherApi.Services;

public class WeatherService : IWeatherService
{
    private readonly IForecastRangeProvider forecastRangeProvider;
    private readonly IWeatherRepository weatherRepository;

    public WeatherService(IForecastRangeProvider forecastRangeProvider, IWeatherRepository weatherRepository)
    {
        this.forecastRangeProvider = forecastRangeProvider;
        this.weatherRepository = weatherRepository;
    }

    public List<WeatherForecast> GetWeatherForecastForUser(string userId)
    {
        if (userId == null)
        {
            throw new ArgumentNullException("userId");
        }

        var (fromDate, toDate) = forecastRangeProvider.GetRange(userId);

        if (fromDate > toDate)
        {
            throw new InvalidOperationException($"{toDate} should be grater than {fromDate}");
        }
        var forecast = this.weatherRepository.GetWeatherForecasts(fromDate, toDate);
        return forecast;
    }
}
