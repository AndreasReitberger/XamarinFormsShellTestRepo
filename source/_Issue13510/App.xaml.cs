using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using _Issue13476.Services;
using _Issue13476.Views;
using _Issue13476.Models;

namespace _Issue13476
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            ShellNavigationManager.RegisterRoutes();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
