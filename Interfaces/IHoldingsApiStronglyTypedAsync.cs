using System.Threading.Tasks;
using SierraCSharpRestClient.Models.Holdings;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IHoldingsApiStronglyTypedAsync
    {
        /// <summary>
        /// Get a list of Holdings </summary>
        /// <param name="bibIds">String Array of bib IDs for which to retrieve associated holdings</param>
        /// <param name="id">String Array of IDs of holdings to retrieve</param>
        /// <param name="fields">String Array of fields to retrieve</param>
        /// <param name="limit">the maximum number of results</param>
        /// <param name="offset">the beginning record (zero-indexed) of the result set returned</param>
        /// <param name="suppressed">This is a string value that must be converted from bool -  the suppressed flag value of items to retrieve</param>
        /// <returns>Holdings</returns>
        Task<Holdings> Get(string[] bibIds = null, string[] id = null, string[] fields = null,
            int limit = 20, int offset = 0, string suppressed = null);
    }
}