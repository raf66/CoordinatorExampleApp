using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoordinatorExampleApp.Models;
using Xamarin.Forms;

namespace CoordinatorExampleApp.ViewModels
{
    public delegate void OnBandSelectedDelegate(Band band);
    public delegate void OnDidCancelDelegate();


    public class BandPickerViewModel : BaseViewModel
    {
        // Supported delelegate protocols
        public OnDidCancelDelegate OnDidCancel { get; set; }

        // Commands
        public ICommand RefreshCommand { private set; get; }
        public ICommand CancelCommand { private set; get; }

        // Properties
        public ObservableCollection<Band> Bands { get; set; }


        public BandPickerViewModel()
        {
            RefreshCommand = new Command(execute: ExecuteRefreshCommand, canExecute: CanExecuteRefreshCommand);
            CancelCommand = new Command(execute: ExecuteCancelCommand);

            Bands = new ObservableCollection<Band>();
        }


        #region Commands

        private async void ExecuteRefreshCommand()
        {
            IsBusy = true;

            // This is just a demo app, so simulate a service by havng the thread
            // wait a second, as if it's fetching a client access token to bootstrap
            // the application
            await Task.Delay(1000);

            Bands.Clear();
            Bands.Add(new Band("The Police", "www.thepolice.com"));
            Bands.Add(new Band("Fiction Plan", "fictionplaneofficial.tumblr.com"));
            Bands.Add(new Band("Cutler Stew", "www.cutlerstew.com"));

            IsBusy = false;
        }


        private bool CanExecuteRefreshCommand()
        {
            return (!IsBusy);
        }


        private void ExecuteCancelCommand()
        {
            OnDidCancel?.Invoke();
        }

        #endregion


    }
}
