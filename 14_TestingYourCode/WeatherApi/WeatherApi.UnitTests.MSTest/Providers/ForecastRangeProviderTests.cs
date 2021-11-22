using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WeatherApi.Providers;

namespace WeatherApi.UnitTests.MSTest.Providers;

[TestClass]
public class ForecastRangeProviderTests
{
    private readonly Mock<IDateTimeProvider> dateTimeProviderMock = new();
    private readonly ForecastRangeProvider sut;

    public ForecastRangeProviderTests()
    {
        this.sut = new ForecastRangeProvider(dateTimeProviderMock.Object);
    }

    [DataTestMethod]
    [DataRow("test", 1)]
    [DataRow("user", 1)]
    [DataRow("admin", 14)]
    public void WeatherRepositoryTestsss(string userName, int days)
    {
        var today = new DateTime(2021, 11, 22);
        dateTimeProviderMock.Setup(_ => _.Now).Returns(today);
        var data = this.sut.GetRange(userName);
        Assert.AreEqual(today.Date, data.fromDate);
        Assert.AreEqual(today.AddDays(days).Date, data.toDate);
    }
}
