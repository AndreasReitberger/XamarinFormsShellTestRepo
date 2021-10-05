using System;
using System.Collections.Generic;
using _Issue13476.ViewModels;
using _Issue13476.Views;
using Xamarin.Forms;

namespace _Issue13476
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
