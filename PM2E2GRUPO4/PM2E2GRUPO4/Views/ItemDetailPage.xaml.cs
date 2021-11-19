using PM2E2GRUPO4.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PM2E2GRUPO4.Views
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