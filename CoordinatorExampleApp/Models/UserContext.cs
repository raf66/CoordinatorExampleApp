using System;
namespace CoordinatorExampleApp.Models
{
    public class UserContext
    {
        private static UserContext _instance;
        public static UserContext Instance
        => _instance ?? (_instance = new UserContext());

        public AccessToken AccessToken { get; set; }
        public User User { get; set; }
        public Band Band { get; set; }


        public UserContext()
        {
        }

        public void Reset()
        {
            AccessToken = null;
            User = null;
            Band = null;
        }
    }
}
