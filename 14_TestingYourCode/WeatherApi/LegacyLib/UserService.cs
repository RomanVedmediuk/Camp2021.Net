namespace LegacyLib
{
    public class UserService
    {
        public UserService()
        {
        }

        public User GetUser(string userId)
        {
            switch (userId)
            {
                case null:
                    throw new ArgumentNullException("userId");
                case "admin":
                    return new User
                    {
                        Id = userId,
                        Name = userId,
                        IsPremium = true,
                        IsTrial = false
                    };
                case "trial":
                    return new User
                    {
                        Id = userId,
                        Name = userId,
                        IsPremium = false,
                        IsTrial = true
                    };
                default:
                    return new User
                    {
                        Id = userId,
                        Name = userId,
                        IsPremium = false,
                        IsTrial = false
                    };
            }
        }
    }
}