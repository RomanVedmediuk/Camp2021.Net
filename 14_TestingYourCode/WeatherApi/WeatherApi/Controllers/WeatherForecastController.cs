using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService weatherForecastService;

    public WeatherForecastController(IWeatherService weatherForecastService)
    {
        this.weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get(string userId)
    {
        return weatherForecastService.GetWeatherForecastForUser(userId);
    }
}
