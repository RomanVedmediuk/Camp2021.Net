namespace WeatherApi.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        protected Func<DateTime> NowFunc = () => DateTime.Now;

        protected Func<DateTime> UtcNowFunc = () => DateTime.UtcNow;

        public DateTimeProvider(Func<DateTime>? nowFunc = null, Func<DateTime>? utcNowFunc = null)
        {
            if (nowFunc != null)
            {
                this.NowFunc = nowFunc;
            }

            if (utcNowFunc != null)
            {
                this.UtcNowFunc = utcNowFunc;
            }
        }

        public DateTimeProvider()
        {
        }

        public DateTime Now => NowFunc();

        public DateTime UtcNow => UtcNowFunc();
    }
}
