using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Coordinators;
using CoordinatorExampleApp.ViewModels;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views
{
    public partial class BootstrapPage : BaseContentPage
    {
        public OnBootstrapDidCompleteDelegate OnBootstrapDidComplete { get; set; }
        protected BootstrapViewModel ViewModel { private get; set; }

        public BootstrapPage(ICoordinator coordinator)
        {
            InitializeComponent();
            BindingContext = ViewModel = new BootstrapViewModel();

            // Start the boostrap process
            this.AttachHooks();
            this.AttachCoordinator(coordinator);

            // Auto-start the bootstrap process
            ViewModel.StartCommand.Execute(null);
        }


        protected void AttachHooks()
        {
            // Attach and relay the OnDidComplete delegate
            ViewModel.OnDidComplete = (accessToken) =>
            {
                this.OnBootstrapDidComplete?.Invoke(accessToken);
            };
        }
    }
}
