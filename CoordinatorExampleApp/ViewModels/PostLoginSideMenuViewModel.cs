using System;
using System.Collections.ObjectModel;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.Views;

namespace CoordinatorExampleApp.ViewModels
{
    public class PostLoginSideMenuViewModel : BaseViewModel
    {
        // Properties
        public ObservableCollection<ISideMenuItem> SideMenuItems { get; set; }



        public PostLoginSideMenuViewModel()
        {
            this.LoadItems();
        }


        protected void LoadItems()
        {
            SideMenuItems = new ObservableCollection<ISideMenuItem>();

            SideMenuItems.Add(new SideMenuAction("Dashboard", "outline_aspect_ratio_black", typeof(DashboardPage)));



            SideMenuItems.Add(new SideMenuHeader("More"));

            SideMenuItems.Add(new SideMenuAction("Settings", "outline_toggle_on_black"));
            SideMenuItems.Add(new SideMenuAction("About", "outline_info_black"));
        }
    }
}

