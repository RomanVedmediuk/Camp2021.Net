using Microsoft.EntityFrameworkCore;
using WeatherApi.Models;

namespace WeatherApi.Persistance;

public class WeatherDBContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

    public WeatherDBContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasKey(u => u.Date);
        modelBuilder.Entity<WeatherForecast>().HasData(
            Enumerable.Range(0, 20).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 40)
            }));
    }
}
