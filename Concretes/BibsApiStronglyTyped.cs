using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class BibsApiStronglyTyped : IBibsApiStronglyTyped
    {
        private readonly IBibsApi _bibsApi;

        public BibsApiStronglyTyped(ISierraRestClient sierraRestClient)
        {
            _bibsApi = new BibsApi(sierraRestClient);
        }

        public BibsModel GetById(int id, string[] fields = null)
        {
            var bib = _bibsApi.GetById(id, fields);

            return JsonConvert.DeserializeObject<BibsModel>(bib); ;

        }

        public SimpleBib GetBasicModelById(int id, string[] fields = null)
        {
            var bib = _bibsApi.GetById(id, fields);

            return JsonConvert.DeserializeObject<SimpleBib>(bib); ;

        }

        public BibSearchModel Search(Indexes index,  string query, string[] fields = null, int limit = 20)
        {
            var result = JsonConvert.DeserializeObject<BibSearchModel>(_bibsApi.Search(index, query, fields, limit));

            return result;
        }


    }
}
