using System;
namespace CoordinatorExampleApp.Models
{
    public class AccessToken
    {
        public String Token { get; set; }
        public long ExpiresIn { get; set; }

        public AccessToken()
        {
        }

        public AccessToken(String token, long expiresIn)
        {
            this.Token = token;
            this.ExpiresIn = expiresIn;
        }

    }
}
