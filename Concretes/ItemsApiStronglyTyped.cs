using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models.Items;
using System;
using Newtonsoft.Json;

namespace SierraCSharpRestClient.Concretes
{
    public class ItemsApiStronglyTyped : IItemsApiStronglyTyped
    {
        private readonly ItemsApi _itemsApi;

        public ItemsApiStronglyTyped(ISierraRestClient sierraRestClient)
        {
            _itemsApi = new ItemsApi(sierraRestClient);
        }


        public ItemResult Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0)
        {
          return JsonConvert.DeserializeObject<ItemResult>(_itemsApi.Get(itemIds, status, bibIds, fields, locations, limit, offset));
        }
    }
}
