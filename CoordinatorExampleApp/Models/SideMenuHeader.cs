using System;
namespace CoordinatorExampleApp.Models
{
    public class SideMenuHeader : ISideMenuItem
    {
        public String Title { get; set; }

        public SideMenuHeader(String title = null)
        {
            this.Title = title;
        }
    }
}
