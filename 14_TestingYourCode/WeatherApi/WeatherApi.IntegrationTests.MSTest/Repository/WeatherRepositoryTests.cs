using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherApi.Persistance;
using WeatherApi.Repository;

namespace WeatherApi.UnitTests.MSTest.Repository;

[TestClass]
public class WeatherRepositoryTests
{
    private readonly WeatherRepository sut;

    public WeatherRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<WeatherDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        var context = new WeatherDBContext(options);
        this.sut = new WeatherRepository(context);
    }

    [TestMethod]
    public void GetWeatherForecasts_ValidDateRangeProvided_ReturnsValidResult()
    {
        var startDate = DateTime.Today;
        var endDate = startDate.AddDays(3).Date;
        var expectedDiff = (endDate - startDate).TotalDays;

        var data = this.sut.GetWeatherForecasts(startDate, endDate);
        Assert.AreEqual(expectedDiff, data.Count);
    }
}
