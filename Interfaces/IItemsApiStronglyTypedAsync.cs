using System.Threading.Tasks;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.Items;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IItemsApiStronglyTypedAsync
    {
        Task<ItemResult> Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0, string suppressedOnly = "");

        Task<Item> Get(string id,  string[] fields = null);

        Task<BaseEnumerator> Query(string json, int offset, int limit);
    }
}