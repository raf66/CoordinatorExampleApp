using System;
using System.Diagnostics;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.Views;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Coordinators
{
	public class BootstrapCoordinator : BaseCoordinator
    {
        public BootstrapCoordinator()
        {
        }

        public override void Start()
        {
            // Get a reference to the page we are managing
            BootstrapPage bootstrapPage = this.GetAttachedPage() as BootstrapPage;


            UserContext.Instance.Reset();

            bootstrapPage.OnBootstrapDidComplete = (accessToken) =>
            {
                Debug.WriteLine("Bootstrap completed.  Got access token = " + accessToken.Token);

                // Save the access token
                UserContext.Instance.AccessToken = accessToken;

                // Show the pre-login master-detail page
                Application.Current.MainPage = new PreLoginMasterDetailPage();
            };

            // Show the page
            Application.Current.MainPage = bootstrapPage;

        }
    }
}
