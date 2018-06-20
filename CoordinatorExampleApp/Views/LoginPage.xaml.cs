using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.ViewModels;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views
{
    public partial class LoginPage : BaseContentPage
    {
        // Public Hooks
        public OnLoginDidCompleteDelegate OnLoginDidComplete { get; set; }

        // Properties
        protected LoginViewModel ViewModel { get; set; }

        public LoginPage() : this(null) {}

        public LoginPage(ICoordinator coordinator)
        {
            InitializeComponent();
            BindingContext = ViewModel = new LoginViewModel();

            this.AttachHooks();
            this.AttachCoordinator(coordinator);
        }


        protected void AttachHooks()
        {
            ViewModel.OnLoginDidComplete = (accessToken, user) =>
            {
                this.OnLoginDidComplete?.Invoke(accessToken, user);
            };
        }

    }
}
