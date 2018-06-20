using System;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Coordinators
{
    public interface ICoordinator
    {
        void Start();

        void AttachToPage(Page page);
        void DetachFromPage();
    }
}
