namespace WeatherApi.Providers
{
    public class ForecastRangeProvider : IForecastRangeProvider
    {
        private const int DefaultForecastDays = 1;
        private const int PremiumUserForecastDays = 14;

        private readonly IDateTimeProvider dateTimeProvider;

        public ForecastRangeProvider(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public (DateTime fromDate, DateTime toDate) GetRange(string userId)
        {
            var range = userId switch
            {
                null => throw new ArgumentNullException(nameof(userId)),
                not { Length: > 0 } => throw new InvalidOperationException(nameof(userId)),
                "admin" => PremiumUserForecastDays,
                _ => DefaultForecastDays
            };

            var fromDate = dateTimeProvider.Now;
            return (fromDate.Date, fromDate.AddDays(range).Date);
        }
    }
}
