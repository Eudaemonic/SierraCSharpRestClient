using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
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


    }
}
