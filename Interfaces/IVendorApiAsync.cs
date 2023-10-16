using System;
using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IVendorApiAsync
    {
         Task<string> Get(string login, DateTime? startDate, DateTime? endDate, InvoiceDateQuery dateToQuery, string[] code = null, string[] ids = null, string[] fields = null, int limit = 50,
            int offset = 0);

         Task<string> Get(string login, string id, string[] fields = null);
         Task<string> GetByCode(string login, string code, string[] fields = null);
    }
}