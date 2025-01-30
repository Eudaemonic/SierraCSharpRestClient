using Newtonsoft.Json;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.Items;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Concretes
{
    public class ItemsApiStronglyTypedAsync : IItemsApiStronglyTypedAsync
    {
        private readonly ItemsApiAsync _itemsApi;

        public ItemsApiStronglyTypedAsync(ISierraRestClient sierraRestClient)
        {
            _itemsApi = new ItemsApiAsync(sierraRestClient);
        }


        public async Task<ItemResult> Get(string[] itemIds = null, string status = "", string[] bibIds = null,
            string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0, string suppressedOnly = "")
        {
            return JsonConvert.DeserializeObject<ItemResult>(await _itemsApi.Get(itemIds, status, bibIds, fields,
                locations, limit, offset, suppressedOnly));
        }

        public async Task<Item> Get(string id, string[] fields = null)
        {
            return JsonConvert.DeserializeObject<Item>(await _itemsApi.Get(id, fields));
        }


        public async Task<BaseEnumerator> Query(string json, int offset, int limit)
        {
            return JsonConvert.DeserializeObject<BaseEnumerator>(await _itemsApi.Query(json, offset, limit));
        }

        public async Task<SierraResponseMessage> CheckInByBarcode(string barcode, string username = null,
            string statgroup = null)
        {

            var result = await _itemsApi.CheckInByBarcode(barcode, username, statgroup);

            if (string.IsNullOrEmpty(result))
            {


                var result2 = new SierraResponseMessage()
                {
                    Code = "200",
                    Name = "Item has been returned",
                    HttpStatus = "200"

                };

                return result2;
            }


            return  JsonConvert.DeserializeObject<SierraResponseMessage>(result);
            
        }
    }
}
