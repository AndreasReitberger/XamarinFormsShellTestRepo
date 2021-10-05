using System.ComponentModel;
using Xamarin.Forms;
using _Issue13476.ViewModels;

namespace _Issue13476.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}