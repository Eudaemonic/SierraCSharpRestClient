using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.BibSubset;
using SierraCSharpRestClient.Models.Items;

namespace SierraCSharpRestClient.Concretes
{
    public class BibsApiStronglyTypedAsync : IBibsApiStronglyTypedAsync
    {
            private readonly IBibsApiAsync _bibsApi;
            private readonly IItemsApiStronglyTypedAsync _itemsApi;

            public BibsApiStronglyTypedAsync(ISierraRestClient sierraRestClient)
            {
                _bibsApi = new BibsApiAsync(sierraRestClient);
                _itemsApi = new ItemsApiStronglyTypedAsync(sierraRestClient);
            }

            public async Task<BibsModel> GetById(int id, string[] fields = null)
            {
                var bib = await _bibsApi.GetById(id, fields);
                
                return JsonConvert.DeserializeObject<BibsModel>(bib); ;

            }

            public async Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20)
            {
                

                var result = JsonConvert.DeserializeObject<BibSearchModel>(await _bibsApi.Search(index, query, fields, limit));

                return result;
            }

            public async Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20, int offset = 0)
            {


                var result = JsonConvert.DeserializeObject<BibSearchModel>(await _bibsApi.Search(index, query, fields, limit, offset));

                return result;
            }

        public async Task<BibSearchModelWithItems> SearchWithItems(Indexes index, string query, string[] fields = null, int limit = 20, int offset = 0)
            {
                
                var result = JsonConvert.DeserializeObject<BibSearchModelWithItems>(await _bibsApi.Search(index, query, fields, limit, offset));


                if (result != null && result.entries.Any())
                {

                     
                        var bibIds = result.entries.Select(m => m.bib.id).ToArray();

                        var items = await _itemsApi.Get(null, null, bibIds);

                        if (items != null && items.entries != null)
                        {
                            foreach (var resultEntry in result.entries)
                            {
                                var itemResults = items.entries.Where(m => m.bibIds.Contains(resultEntry.bib.id));

                                if (itemResults.Any())
                                {
                                    ItemResult itemResult = new ItemResult()
                                    {
                                        entries = itemResults.ToList(),
                                        total = itemResults.Count()
                                    };

                                    resultEntry.items = itemResult;
                                }
                                
                            }

                        }

            }

            return result;
            }

         public async Task<BibQuery> Query(string jsonQuery,  int limit = 20, int offset = 0)
            {

                var result = JsonConvert.DeserializeObject<BibQuery>(await _bibsApi.Query(jsonQuery, limit, offset));

                return result;
            }

        public async Task<BaseGenericEnumerator<SimpleBib>> GetBibs(string ids, string[] fields = null,
            string createdDate = null, string updatedDate = null, int limit = 20, int offset = 0)
        {
            var result = JsonConvert.DeserializeObject<BaseGenericEnumerator<SimpleBib>>(await _bibsApi.GetBibs(ids, fields, createdDate, updatedDate, limit , offset));

            return result;
        }
    }
    }


