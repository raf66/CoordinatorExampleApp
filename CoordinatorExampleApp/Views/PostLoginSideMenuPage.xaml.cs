using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.ViewModels;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views
{
    public partial class PostLoginSideMenuPage : ContentPage
    {
        protected PostLoginSideMenuViewModel ViewModel { get; set; }

        public PostLoginSideMenuPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new PostLoginSideMenuViewModel();
        }


        protected void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is SideMenuAction)
            {
                var sideMenuAction = e.Item as SideMenuAction;
                var page = sideMenuAction.MakePage();

                if (page != null)
                {
                    MasterDetailPage masterDetailPage = Parent as MasterDetailPage;

                    // Unless it's a TabbedPage, wrap the new page in a Navaigation page
                    if (!(page is TabbedPage))
                    {
                        page = new NavigationPage(page);
                    }

                    // Show it
                    masterDetailPage.Detail = page;
                    masterDetailPage.IsPresented = false;
                }
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}
