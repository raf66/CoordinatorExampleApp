using System;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CoordinatorExampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BootstrapPage( new BootstrapCoordinator() );
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
