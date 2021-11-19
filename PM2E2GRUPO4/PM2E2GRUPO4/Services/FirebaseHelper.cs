using PM2E2GRUPO4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

namespace PM2E2GRUPO4.Services
{
    public class FirebaseHelper
    {
        public async Task<List<ItemModel>> GetAllPersons()
        {
            return (await firebase
              .Child("sitios")
              .OnceAsync<ItemModel>()).Select(item => new ItemModel
              {
                  Descripcion = item.Object.Descripcion,
                  ItemId = item.Object.ItemId,
                  Latitud = item.Object.Latitud,
                  Longitud = item.Object.Longitud,
                  Img = item.Object.Img
              }).ToList();
        }
        public async Task AddPerson(Models.ItemModel _itemmodel)
        {
            await firebase
            .Child("sitios")
            .PostAsync(new ItemModel()
            {
                ItemId = Guid.NewGuid(),
                Descripcion = _itemmodel.Descripcion,
                Latitud = _itemmodel.Latitud,
                Longitud = _itemmodel.Longitud,
                Img = _itemmodel.Img
            });
        }


        public async Task UpdatePerson(ItemModel _personModel)
        {
            var toUpdatePerson = (await firebase
              .Child("sitios")
              .OnceAsync<ItemModel>()).Where(a => a.Object.ItemId == _personModel.ItemId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new ItemModel() { ItemId = _personModel.ItemId, Descripcion = _personModel.Descripcion, Latitud = _personModel.Latitud, Longitud = _personModel.Longitud, Img = _personModel.Img });
        }

        public async Task DeletePerson(Guid itemid)
        {
            var toDeletePerson = (await firebase
              .Child("sitios")
              .OnceAsync<ItemModel>()).Where(a => a.Object.ItemId == itemid).FirstOrDefault();
            await firebase.Child("sitios").Child(toDeletePerson.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        public FirebaseHelper()
        {
            firebase = new FirebaseClient("https://in-api-dev-default-rtdb.firebaseio.com/");
        }

    }
}
