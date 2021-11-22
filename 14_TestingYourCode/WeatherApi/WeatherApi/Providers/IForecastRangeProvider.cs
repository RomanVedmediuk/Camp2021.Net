namespace WeatherApi.Providers;

public interface IForecastRangeProvider
{
    (DateTime fromDate, DateTime toDate) GetRange(string userId);
}
