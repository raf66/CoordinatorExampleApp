using System;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.Views;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Models
{
    public class SideMenuAction : ISideMenuItem
    {
        public String Title { get; set; }
        public String Icon { get; set; }
        public Type PageType { get; set; }
        public Type CoordinatorType { get; set; }

        public SideMenuAction(String title = null, String icon = null, Type pageType = null, Type coordinatorType = null)
        {
            this.Title = title;
            this.Icon = icon;
            this.PageType = pageType;
            this.CoordinatorType = coordinatorType;
        }

        public Page MakePage() 
        {
            if (PageType == null)
                return null;

            var page = Activator.CreateInstance(PageType);
            if (page == null)
                return null;
            
            if ( (page is BaseContentPage) && (CoordinatorType != null))
            {
                var coordinator = Activator.CreateInstance(CoordinatorType);
                ((BaseContentPage)page).AttachCoordinator(coordinator as ICoordinator);
            }

            return page as Page;
        }
    }
}
