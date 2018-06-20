using System;
using System.Collections.ObjectModel;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.Views;

namespace CoordinatorExampleApp.ViewModels
{
    public class PreLoginSideMenuViewModel : BaseViewModel
    {
        // Properties
        public ObservableCollection<ISideMenuItem> SideMenuItems { get; set; }



        public PreLoginSideMenuViewModel()
        {
            this.LoadItems();
        }


        protected void LoadItems()
        {
            SideMenuItems = new ObservableCollection<ISideMenuItem>();

            SideMenuItems.Add(new SideMenuAction("Login", "outline_account_circle_black", typeof(LoginPage), typeof(SimpleLoginCoordinator) ));
            SideMenuItems.Add(new SideMenuAction("Join", "outline_person_add_black"));


            SideMenuItems.Add(new SideMenuHeader("More"));

            SideMenuItems.Add(new SideMenuAction("Settings", "outline_toggle_on_black"));
            SideMenuItems.Add(new SideMenuAction("About", "outline_info_black"));
        }

    }
}
