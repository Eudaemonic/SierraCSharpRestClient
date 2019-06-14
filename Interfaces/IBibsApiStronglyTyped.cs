using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IBibsApiStronglyTyped
    {
        BibsModel GetById(int id, string[] fields = null);

        SimpleBib GetBasicModelById(int id, string[] fields = null);

        BibSearchModel Search(Indexes index, string query, string[] fields = null, int limit = 20);
    }
}