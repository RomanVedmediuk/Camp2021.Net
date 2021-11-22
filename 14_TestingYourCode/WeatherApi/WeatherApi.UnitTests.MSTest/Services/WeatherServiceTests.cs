using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WeatherApi.Providers;
using WeatherApi.Repository;
using WeatherApi.Services;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
namespace WeatherApi.UnitTests.MSTest.Services;

[TestClass]
public class WeatherServiceTests
{
    private readonly Mock<IForecastRangeProvider> forecastRangeProviderMock = new();
    private readonly Mock<IWeatherRepository> weatherRepositoryMock = new();
    private readonly WeatherService sut;

    public WeatherServiceTests()
    {
        this.sut = new WeatherService(forecastRangeProviderMock.Object, weatherRepositoryMock.Object);
    }

    [TestMethod]
    public void GetWeatherForecastForUser_UserIsNull_ThrowException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => sut.GetWeatherForecastForUser(null)); ;
    }

    [TestMethod]
    public void GetWeatherForecastForUser_RangeIsNull_ThrowException()
    {
        var startDate = new DateTime(2021, 11, 22);
        var endDate = new DateTime(2021, 11, 26);

        forecastRangeProviderMock.Setup(_ => _.GetRange(It.IsAny<string>())).Returns((endDate, startDate));
        Assert.ThrowsException<InvalidOperationException>(() => sut.GetWeatherForecastForUser("user"));
    }

    [TestMethod]
    public void GetWeatherForecastForUser_RangeIsValid_UseRange()
    {
        var startDate = new DateTime(2021, 11, 22);
        var endDate = new DateTime(2021, 11, 26);

        forecastRangeProviderMock.Setup(_ => _.GetRange(It.IsAny<string>())).Returns((startDate, endDate));
                sut.GetWeatherForecastForUser("user");
        weatherRepositoryMock.Verify(_ => 
            _.GetWeatherForecasts(
                It.Is<DateTime>(sd => sd == startDate),
                It.Is<DateTime>(ed => ed == endDate)));
    }
}
