using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.ViewModels
{
    public delegate void OnLoginDidCompleteDelegate(AccessToken accessToken, User user);


    public class LoginViewModel : BaseViewModel
    {
        // Supported delelegate protocols
        public OnLoginDidCompleteDelegate OnLoginDidComplete { get; set; }

        // Commands
        public ICommand LoginCommand { private set; get; }

        // Properties
        private String _userName = String.Empty;
        public String UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); OnPropertyChanged(nameof(IsLoginEnabled)); }
        }

        private String _password = String.Empty;
        public String Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); OnPropertyChanged(nameof(IsLoginEnabled)); }
        }

        public bool IsLoginEnabled => CanExecuteLoginCommand();


        public LoginViewModel() : base()
        {
            LoginCommand = new Command(execute: ExecuteLoginCommand, canExecute: CanExecuteLoginCommand);
        }

        #region Commands

        private async void ExecuteLoginCommand()
        {
            IsBusy = true;

            // This is just a demo app, so simulate a service by havng the thread
            // wait a second, as if it's making a web service call
            await Task.Delay(1000);


            var fakeAccessToken = new AccessToken( Guid.NewGuid().ToString(), TimeSpan.FromHours(24).Milliseconds );
            var fakeUser = new User("string", "Gordon", "Sumner");

            this.OnLoginDidComplete?.Invoke(fakeAccessToken, fakeUser);

            IsBusy = false;
        }

        private bool CanExecuteLoginCommand()
        {
            return (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && !IsBusy);
        }


        #endregion
    }
}
