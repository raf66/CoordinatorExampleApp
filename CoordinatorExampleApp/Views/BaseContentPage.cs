using System;
using CoordinatorExampleApp.Coordinators;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views
{
	public abstract class BaseContentPage : ContentPage
    {
        protected ICoordinator Coordinator { get; set; }

        public BaseContentPage()
        {
        }

        public void AttachCoordinator(ICoordinator coordinator)
        {
            this.DetachCoordinator();

            // Save a reference to the workflow (so that it does not get garbage collected
            this.Coordinator = coordinator;

            // Give the workflow a weak reference to self
            if ( coordinator != null )
            {
                coordinator.AttachToPage(this);    
            }
        }

        public void DetachCoordinator()
        {
            this.Coordinator?.DetachFromPage();
        }

    }
}
