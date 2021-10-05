using _Issue13476.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _Issue13476.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await ((AboutViewModel)this.BindingContext).OnAppearing();
            }
            catch (Exception) { }
            //your code here;

        }
    }
}