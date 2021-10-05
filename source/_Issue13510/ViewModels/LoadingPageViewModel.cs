using _Issue13476.Models;
using _Issue13476.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace _Issue13476.ViewModels
{
    [Preserve(AllMembers = true)]
    public class LoadingPageViewModel : BaseViewModel
    {
        private bool _ready = false;
        public bool Ready
        {
            get => _ready;
            set
            {
                if (_ready == value) return;
                _ready = value;
                OnPropertyChanged();
            }
        }
        #region Constructor, LoadSettings

        public LoadingPageViewModel()
        {

        }
        #endregion

        #region Methods
        public async Task OnAppearing()
        {
            try
            {
                // Gets called twice if calling await ShellNavigationManager.GoBackAsync(); on LoginPage 
                Console.WriteLine("LoadingPage: OnAppearing called");
                IsBusy = true;
                //await Task.Delay(1000);
                //await Shell.Current.GoToAsync(ShellRoute.LoginPage.ToString());
                if(!Ready)
                    await ShellNavigationManager.GoToAsync(ShellRoute.LoginPage.ToString());
                else
                    await ShellNavigationManager.GoToAsync(ShellRoute.AboutPage.ToString());
                    //await ShellNavigationManager.GoToAsync($"///{ShellRoute.AboutPage}");
                Ready = true;
            }
            catch (Exception exc)
            {
            }
            IsBusy = false;
        }

        public async Task OnDisappearing()
        {
            //await Shell.Current.GoToAsync($"///AboutPage");
        }
        #endregion

    }
}
