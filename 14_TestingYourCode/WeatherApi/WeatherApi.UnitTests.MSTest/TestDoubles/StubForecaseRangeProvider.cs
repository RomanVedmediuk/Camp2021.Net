using System;
using WeatherApi.Providers;

namespace WeatherApi.UnitTests.MSTest.TestDoubles
{
    public class StubForecaseRangeProvider : IForecastRangeProvider
    {
        public (DateTime fromDate, DateTime toDate) GetRange(string _)
        {
            return (new DateTime(2021, 1, 1), new DateTime(2021, 1, 4));
        }
    }
}
