using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM2E2GRUPO4.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string ItemId);
        Task<T> GetItemAsync(string ItemId);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
