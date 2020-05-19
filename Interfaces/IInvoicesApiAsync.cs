using System;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IInvoicesApiAsync
    {
        Task<string> Get(string login, DateTime startDate, DateTime endTime, string status = "", string[] Ids = null, string[] fields = null, string[] locations = null, int limit = 50,
            int offset = 0);

        Task<string> Get(string id, string[] fields = null);
    }
}