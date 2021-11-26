using WeatherApi.Models;
using WeatherApi.Persistance;

namespace WeatherApi.Repository;
public class WeatherRepository : IWeatherRepository
{
    private readonly WeatherDBContext context;

    public WeatherRepository(WeatherDBContext context)
    {
        this.context = context;
    }

    public List<WeatherForecast> GetWeatherForecasts(DateTime fromDate, DateTime toDate)
    {
        return this.context.WeatherForecasts
            .Where(_ => _.Date >= fromDate.Date && _.Date <= toDate.Date)
            .ToList();
    }
}