using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IHoldingsApiAsync
    {
        /// <summary>
        /// Returns a full patron object with all var fields. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="suppressed"></param>
        /// <param name="bibIds"></param>
        /// <returns></returns>
        Task<string> Get(string[] bibIds = null, string[] id = null, string[] fields = null,
            int limit = 20, int offset = 0, string suppressed = null);
    }
}