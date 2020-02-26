using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IItemsApiAsync
    {
        Task<string> Get(string[] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0);

        Task<string> Get(string id, string[] fields = null);
    }
}