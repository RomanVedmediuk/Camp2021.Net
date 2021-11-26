using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi.Models;

namespace WeatherApi.IntegrationTests.MSTest.Controllers
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public async Task GetWeatherForecast_ReturnBadRequest_WhenUserIsEmpty()
        {
            //Arrange
            var userId = "";
            const int DefaultForecastDays = 1;

            using var app = new TestApplicationFactory();
            var httpClient = app.CreateClient();

            //Act
            //WeatherForecast?userId=1
            var response = await httpClient.GetAsync($"/WeatherForecast?userId={userId}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task GetWeatherForecast_ReturnForecast_WhenUserIsValid()
        {
            //Arrange
            var userId = "user";
            const int DefaultForecastDays = 1;

            using var app = new TestApplicationFactory();
            var httpClient = app.CreateClient();

            //Act
            //WeatherForecast?userId=1
            var response = await httpClient.GetAsync($"/WeatherForecast?userId={userId}");
            var responseText = await response.Content.ReadAsStringAsync();
            var customerResult = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(responseText);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            customerResult.Should().HaveCount(DefaultForecastDays);
        }

        [TestMethod]
        public async Task GetWeatherForecast_ReturnForecast_WhenUserIsAdmin()
        {
            //Arrange
            var userId = "admin";
            const int PremiumUserForecastDays = 14;

            using var app = new TestApplicationFactory();
            var httpClient = app.CreateClient();

            //Act
            //WeatherForecast?userId=1
            var response = await httpClient.GetAsync($"/WeatherForecast?userId={userId}");
            var responseText = await response.Content.ReadAsStringAsync();
            var customerResult = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(responseText);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            customerResult.Should().HaveCount(PremiumUserForecastDays);
        }
    }
}
