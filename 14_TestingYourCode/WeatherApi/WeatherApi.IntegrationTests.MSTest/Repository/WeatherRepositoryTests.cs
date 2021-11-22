using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherApi.Repository;

namespace WeatherApi.UnitTests.MSTest.Repository;

[TestClass]
public class WeatherRepositoryTests
{
    private readonly WeatherRepository sut;

    public WeatherRepositoryTests()
    {
        this.sut = new WeatherRepository();
    }

    [TestMethod]
    public void GetWeatherForecasts_ValidDateRangeProvided_ReturnsValidResult()
    {
        var startDate = new DateTime(2021, 11, 22);
        var endDate = new DateTime(2021, 11, 26);
        var expectedDiff = (endDate - startDate).TotalDays;

        var data = this.sut.GetWeatherForecasts(startDate, endDate);
        Assert.AreEqual(expectedDiff, data.Count);
    }
}
