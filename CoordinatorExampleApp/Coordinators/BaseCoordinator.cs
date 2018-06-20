using System;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Coordinators
{
	public abstract class BaseCoordinator : ICoordinator
    {
        // This property will store a weak reference to the page to which
        // the coordinator is attached.
        public WeakReference<Page> pageRef { get; set; }


        public BaseCoordinator()
        {
        }

        // Subclass should implement this.
        public abstract void Start();


        // This is just a convenince method so that the 
        // coordinator can acces the page it is attached to.
        public Page GetAttachedPage()
        {
            Page page = null;
            pageRef.TryGetTarget(out page);

            return page;
        }

        // Saves a weak reference to the page, and starts the
        // coordinator
        public void AttachToPage(Page page)
        {
            this.DetachFromPage();

            this.pageRef = new WeakReference<Page>(page);
            this.Start();
        }

        // Kills the weak reference to the page
        public void DetachFromPage()
        {
            this.pageRef = null;
        }
    }
}
