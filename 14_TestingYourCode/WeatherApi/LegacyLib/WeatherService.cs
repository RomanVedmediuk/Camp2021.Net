using WeatherApi.Models;

namespace LegacyLib
{
    public class WeatherService
    {
        public WeatherService()
        {

        }

        public List<WeatherForecast> GetWeatherForecastForUser(string userId)
        {
            var daysLimit = 1;

            var userService = new UserService();
            var user = userService.GetUser(userId);

            if (user.IsPremium)
            {
                daysLimit = 14;
            }
            else if (user.IsTrial)
            {
                daysLimit = 7;
            }
            else if (user.Id == "Roman")
            {
                daysLimit = 21;
            }

            var today = DateTime.Now;

            return Database.GetForecastFoRange(today, daysLimit);
        }
    }
}