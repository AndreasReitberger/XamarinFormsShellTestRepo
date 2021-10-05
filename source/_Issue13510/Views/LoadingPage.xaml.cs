using _Issue13476.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _Issue13476.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await ((LoadingPageViewModel)this.BindingContext).OnAppearing();
            }
            catch (Exception) { }
            //your code here;

        }
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                await ((LoadingPageViewModel)this.BindingContext).OnDisappearing();
            }
            catch (Exception) { }
            //your code here;

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}