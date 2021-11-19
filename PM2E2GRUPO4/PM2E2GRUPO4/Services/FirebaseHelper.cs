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
        public async Task<List<Models.Item>> GetItems()
        {
            return (await firebase
                .Child("sitios")
                .OnceAsync<Item>()).Select(utem => new Item
                {
                    Id = utem.Object.Id,
                    Descripcion = utem.Object.Descripcion,
                    Latitud = utem.Object.Latitud,
                    Longitud = utem.Object.Longitud
                }).ToList();
        }
        public async Task AddPerson(Models.Item _item)
        {
            await firebase
            .Child("sitios")
            .PostAsync(new Models.Item()
            {
                Id = Guid.NewGuid(),
                Descripcion = _item.Descripcion,
                Latitud = _item.Latitud,
                Longitud = _item.Longitud,
                Img = _item.Img,
            });
        }


        public async Task UpdatePerson(Models.Item _item)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Item>()).Where(a => a.Object.Id == _item.Id).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child((string)toUpdatePerson.Key)
              .PutAsync(new Models.Item() { Id = _item.Id, Descripcion = _item.Descripcion, Latitud = _item.Latitud, Longitud = _item.Longitud, Img = _item.Img });
        }

        public async Task DeletePerson(Guid itemid)
        {
            var toDeletePerson = (await firebase
              .Child("sitios")
              .OnceAsync<Item>()).Where(a => a.Object.Id == itemid).FirstOrDefault();
            await firebase.Child("sitios").Child(toDeletePerson.Key).DeleteAsync();

        }

        FirebaseClient firebase;
        public FirebaseHelper()
        {
            firebase = new FirebaseClient("https://in-api-dev-default-rtdb.firebaseio.com/");
        }

    }
}
