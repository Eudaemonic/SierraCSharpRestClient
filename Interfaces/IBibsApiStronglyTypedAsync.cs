using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IBibsApiStronglyTypedAsync
    {
        Task<BibsModel> GetById(int id, string[] fields = null);
        Task<BibSearchModel> Search(Indexes index, string query, string[] fields = null, int limit = 20);
    }
}