using System;
using System.Collections.Generic;
using CoordinatorExampleApp.Models;
using CoordinatorExampleApp.ViewModels;
using Xamarin.Forms;

namespace CoordinatorExampleApp.Views
{
    public partial class BandPickerPage : ContentPage
    {
        // Public Hooks
        public OnBandSelectedDelegate OnBandSelected { get; set; }
        public OnDidCancelDelegate OnDidCancel { get; set; }

        // Properites
        protected BandPickerViewModel ViewModel { get; set; }



        public BandPickerPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new BandPickerViewModel();

            this.AttachHooks();

            ViewModel.RefreshCommand.Execute(null);
        }

        protected void AttachHooks()
        {
            ViewModel.OnDidCancel = () => {
                this.OnDidCancel?.Invoke();
            };
        }

        public void OnBandTapped(object sender, ItemTappedEventArgs e)
        {
            Band band = e.Item as Band;
            ListView listView = sender as ListView;

            listView.SelectedItem = null;

            this.OnBandSelected?.Invoke(band);
        }

    }
}
