using System.Collections.Generic;
using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IBibsApiStronglyTypedAsync
    {
        Task<BibsModel> GetById(int id, string[] fields = null);

        Task<BaseGenericEnumerator<SimpleBib>> GetBibs(string ids, string[] fields = null, string createdDate = null,
            string updatedDate = null, int limit = 20, int offset = 0);
        Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20);
        Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20, int offset = 0);
        Task<BibSearchModelWithItems> SearchWithItems(Indexes index, string query, string[] fields = null, int limit = 20, int offset = 0);
        Task<BibQuery> Query(string jsonQuery, int limit = 20, int offset = 0);
    }
}