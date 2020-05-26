using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models.Items;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SierraCSharpRestClient.Concretes
{
    public class ItemsApiStronglyTypedAsync : IItemsApiStronglyTypedAsync
    { 
        private readonly ItemsApiAsync _itemsApi;

        public ItemsApiStronglyTypedAsync(ISierraRestClient sierraRestClient)
        {
            _itemsApi = new ItemsApiAsync(sierraRestClient); 
        }


        public async Task<ItemResult> Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0)
        {
          return JsonConvert.DeserializeObject<ItemResult>(await _itemsApi.Get(itemIds, status, bibIds, fields, locations, limit, offset));
        }

        public async Task<Item> Get(string id,  string[] fields = null)
        {
            return JsonConvert.DeserializeObject<Item>(await _itemsApi.Get(id, fields));
        }
    }
}
