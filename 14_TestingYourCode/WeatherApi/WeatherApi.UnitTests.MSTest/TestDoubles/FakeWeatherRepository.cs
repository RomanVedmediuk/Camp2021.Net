using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApi.Models;
using WeatherApi.Repository;

namespace WeatherApi.UnitTests.MSTest.Repository;

public class FakeWeatherRepository : WeatherRepository
{
    private readonly List<WeatherForecast> weatherForecasts = new();

    public FakeWeatherRepository()
    {
    }

    public new List<WeatherForecast> GetWeatherForecasts(DateTime fromDate, DateTime toDate)
    {
        return weatherForecasts
            .Where(_ => _.Date >= fromDate.Date && _.Date <= toDate.Date)
            .ToList();
    }
}
