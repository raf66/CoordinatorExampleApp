using System;
namespace CoordinatorExampleApp.Models
{
    public class Band
    {
        public String BandName { get; set; }
        public String WebUrl { get; set; }

        public Band()
        {
        }

        public Band(String name, String webUrl)
        {
            this.BandName = name;
            this.WebUrl = webUrl;
        }
    }
}
