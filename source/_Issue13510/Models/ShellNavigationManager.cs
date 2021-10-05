using _Issue13476.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _Issue13476.Models
{
    public static class ShellNavigationManager
    {
        #region Properties

        public static string Current
        {
            get => getCurrentRoute();
        }

        #endregion

        public static async Task<bool> GoToAsync(string Target, bool FlyoutIsPresented = false, int Delay = -1)
        {
            try
            {
                Shell.Current.FlyoutIsPresented = FlyoutIsPresented;
                if (Delay != -1)
                    await Task.Delay(Delay);

                //MainThread.BeginInvokeOnMainThread(async () =>
                //{
                var lastPart = getCurrentRoute();
                if (lastPart != Target)
                    await Shell.Current.GoToAsync(Target);
                else
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("ShellNavigationManager: Tried to open the same route again", Target));
                }
                //});
                return true;
            }
            catch (Exception exc)
            {

                return false;
            }
        }
        public static async Task<bool> GoToAsync(ShellRoute Target, bool FlyoutIsPresented = false, int Delay = -1)
        {
            try
            {
                var result = await GoToAsync(Target.ToString(), FlyoutIsPresented, Delay);
                return result;
            }
            catch (Exception exc)
            {

                return false;
            }
        }
        public static async Task GoBackAsync(bool FlyoutIsPresented = false, int Delay = -1)
        {
            try
            {
                await GoToAsync("..", FlyoutIsPresented, Delay);
            }
            catch (Exception exc)
            {

            }
        }

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute(ShellRoute.AboutPage.ToString(), typeof(AboutPage));
            Routing.RegisterRoute(ShellRoute.ItemsPage.ToString(), typeof(ItemsPage));
            Routing.RegisterRoute(ShellRoute.LoginPage.ToString(), typeof(LoginPage));
            Routing.RegisterRoute(ShellRoute.LoadingPage.ToString(), typeof(LoadingPage));
            
        }

        private static string getCurrentRoute()
        {
            try
            {
                var state = Shell.Current.CurrentState;
                var lastPart = state.Location.ToString().Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).LastOrDefault();
                return lastPart;
            }
            catch (Exception exc)
            {
                return string.Empty;
            }
        }
    }

    public enum ShellRoute
    {
        LoadingPage,
        AboutPage,
        ItemsPage,
        LoginPage,
    }
}
