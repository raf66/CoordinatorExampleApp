using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.ViewModels
{
    // Declare types of delegates this view model supports
    public delegate void OnBootstrapDidCompleteDelegate(AccessToken accessToken);


    public class BootstrapViewModel : BaseViewModel
    {
        // Supported delelegate
        public OnBootstrapDidCompleteDelegate OnDidComplete { get; set; }

        // Commands
        public ICommand StartCommand { private set; get; }


        public BootstrapViewModel()
        {
            StartCommand = new Command(execute: ExecuteStartCommand, canExecute: CanExecuteStartCommand);
        }


        #region Commands

        private async void ExecuteStartCommand()
        {
            IsBusy = true;

            // This is just a demo app, so simulate a service by havng the thread
            // wait a second, as if it's fetching a client access token to bootstrap
            // the application
            await Task.Delay(2000);

            var fakeAccessToken = new AccessToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(24).Milliseconds);

            // Now, invoke the delegate to signal that that received an
            // access token
            OnDidComplete?.Invoke(fakeAccessToken);


            IsBusy = false;
        }

        private bool CanExecuteStartCommand() => (IsBusy == false);


        #endregion

    }
}
