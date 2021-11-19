using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PM2E2GRUPO4.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Storage;

namespace PM2E2GRUPO4.Views
{
    public partial class AboutPage : ContentPage
    {
        Firebasedb firebaseHelper = new Firebasedb();
        string base64 = "";
        public AboutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            Localizar();
            CheckConnectivity();
            this.Title = "PM2E2GRUPO4";
        }
        private async void Localizar()
        {
            var result = await Geolocation.GetLocationAsync(new
                GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            lat.Text = $"{ result.Latitude}";
            lonf.Text = $"{ result.Longitude}";
        }
        private void CheckConnectivity()
        {
            if (CrossConnectivity.Current.IsConnected == false)
                DisplayAlert("Mensaje", "Dispositivo no conectado a Internet", "Ok");
        }
        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });
                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                Byte[] imagenByte = null;
                using (var stream = new MemoryStream())
                {
                    photo.GetStream().CopyTo(stream);
                    photo.Dispose();
                    imagenByte = stream.ToArray();
                    base64 = Convert.ToBase64String(imagenByte);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
        private async void Buttonsave_ClickedAsync(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(base64) == true)
            {
                await DisplayAlert("Mensaje", "Imagen vacia", "Ok");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(descrip.Text) == true)
                {
                    await DisplayAlert("Mensaje", "Datos sin rellenar", "Ok");
                }
                else
                {
                    
                    descrip.Text = base64 = String.Empty;
                    imgCam.Source = "https://cdn-icons-png.flaticon.com/512/149/149071.png";
                    await DisplayAlert("Success", "Person Added Successfully", "OK");
                }
            }
        }       
    }      
}