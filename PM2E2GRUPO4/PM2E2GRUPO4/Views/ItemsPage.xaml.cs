using com.sun.tools.corba.se.idl;
using PM2E2GRUPO4.Models;
using PM2E2GRUPO4.Services;
using PM2E2GRUPO4.ViewModels;
using PM2E2GRUPO4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO4.Views
{
    public partial class ItemsPage : ContentPage
    {
        
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = new ItemModel();
        }

        protected override void OnAppearing()
        {
            
        }
    }
}