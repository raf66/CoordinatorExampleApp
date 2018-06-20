using System;
namespace CoordinatorExampleApp.Models
{
    public class User
    {
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAddress { get; set; }

        public User()
        {
        }

        public User(String userName, String firstname, String lastName)
        {
            this.UserName = userName;
            this.FirstName = firstname;
            this.LastName = lastName;                
        }
    }
}
