using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PM2E2GRUPO4.Models;

namespace PM2E2GRUPO4.Services
{
    public class Item
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        #region Attributes
        public string descripcion;
        public string latitud;
        public string longitud;
        public string img;
        public bool isRefreshing = false;
        public object listViewSource;
        #endregion

        #region Properties
        public string Descripcion
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
        }

        public string Latitud
        {
            get { return this.latitud; }
            set { SetValue(ref this.latitud, value); }
        }
        public string Longitud
        {
            get { return this.longitud; }
            set { SetValue(ref this.longitud, value); }
        }
        public string Img
        {
            get { return this.img; }
            set { SetValue(ref this.img, value); }
        }

        private void SetValue(ref string img, string value)
        {
            throw new NotImplementedException();
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        private void SetValue(ref bool isRefreshing, bool value)
        {
            throw new NotImplementedException();
        }

        public object ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                setValue(ref this.listViewSource, value);
            }
        }

        private void setValue(ref object listViewSource, object value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Commands
        public ICommand InsertCommand
        {
            get
            {
                return new RelayCommand(InsertMethod);
            }
        }
        #endregion

        #region Methods
        private async void InsertMethod()
        {
            var utem = new Models.Item
            {
                Descripcion = descripcion,
                Latitud = latitud,
                Longitud = longitud,
                Img = img,
            };

            await firebaseHelper.AddPerson(utem);

            this.IsRefreshing = true;

            await Task.Delay(1000);

            _ = LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {
            this.ListViewSource = await firebaseHelper.GetItems();
        }

        #endregion

        #region .
        public ObservableCollection<Models.Item> IngredientsCollection = new ObservableCollection<Models.Item>();

        private async Task TestListViewBindingAsync()
        {
            var Ingredients = new List<Models.Item>();

            {
                Ingredients = await firebaseHelper.GetItems();
            }
            foreach (var Ingredient in Ingredients)
            {
                IngredientsCollection.Add(Ingredient);
            }

        }
        #endregion
        #region Constructor
        public Item()
        {
            LoadData();
            TestListViewBindingAsync();

        }
        #endregion
    }
}
