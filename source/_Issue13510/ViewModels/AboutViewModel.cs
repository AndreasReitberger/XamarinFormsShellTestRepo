using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace _Issue13476.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        public async Task OnAppearing()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(500);
            }
            catch (Exception)
            {
            }
            IsBusy = false;
        }
    }
}