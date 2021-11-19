using PM2E2GRUPO4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM2E2GRUPO4.Services
{
    public class MockDataStore : IDataStore<Models.ItemModel>
    {
        readonly List<Models.ItemModel> items;

        public MockDataStore()
        {
            items = new List<Models.ItemModel>()
            {
                
            };
        }

        public async Task<bool> AddItemAsync(Models.ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Models.ItemModel item)
        {
            // var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            // items.Remove(oldItem);
            //items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
          // var oldItem = items.Where((Models.ItemModel arg) => arg.ItemId == id).FirstOrDefault();
            //items.Remove(oldItem);

            return await Task.FromResult(true);
        }

       // public async Task<Models.ItemModel> GetItemAsync(string id)
       // {
           // return await Task.FromResult(items.FirstOrDefault(s => s.ItemId == id));
       // }

        public async Task<IEnumerable<Models.ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task<ItemModel> GetItemAsync(string ItemId)
        {
            throw new NotImplementedException();
        }
    }
}