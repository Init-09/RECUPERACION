using PM2E2GRUPO4.ViewModels;
using PM2E2GRUPO4.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PM2E2GRUPO4
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
