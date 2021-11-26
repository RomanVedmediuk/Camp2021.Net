using Microsoft.EntityFrameworkCore;
using WeatherApi.Persistance;
using WeatherApi.Providers;
using WeatherApi.Repository;
using WeatherApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WeatherAPIConnection") ?? "Server=(localdb)\\MSSQLLocalDB;Database=WeatherDB;Trusted_Connection=True;";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WeatherDBContext>(o => o.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IForecastRangeProvider, ForecastRangeProvider>();
builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
