using System;
using WeatherApi.Providers;

namespace WeatherApi.UnitTests.MSTest.Providers
{
    internal class ForecastRangeProviderMock : IForecastRangeProvider
    {
        public int GetRangeCounter { get; set; } = 0;

        public (DateTime fromDate, DateTime toDate) GetRange(string userId)
        {
            GetRangeCounter += 1;
            return (new DateTime(2021, 1, 1), new DateTime(2021, 1, 4));
        }
    }
}
