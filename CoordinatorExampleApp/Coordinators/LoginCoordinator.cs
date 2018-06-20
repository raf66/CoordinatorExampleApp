using System;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.Views;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Coordinators
{
    public class SimpleLoginCoordinator : BaseCoordinator
    {
        public SimpleLoginCoordinator()
        {
        }

        public override void Start()
        {
            // Get a reference to the page we are managing
            LoginPage loginPage = this.GetAttachedPage() as LoginPage;


            // When the login completes, show the band picker page
            loginPage.OnLoginDidComplete = (accessToken, user) =>
            {
                // Save user info
                UserContext.Instance.AccessToken = accessToken;
                UserContext.Instance.User = user;

                // Create the band picker page
                var picker = new BandPickerPage();

                picker.OnBandSelected = (band) =>
                {
                    picker.Navigation.PopModalAsync();
                    Application.Current.MainPage = new PostLoginMasterDetailPage();
                };

                picker.OnDidCancel = () =>
                {
                    picker.Navigation.PopModalAsync();
                };

                // Display it
                loginPage.Navigation.PushModalAsync(new NavigationPage(picker));
            };            

        }
    }
}
