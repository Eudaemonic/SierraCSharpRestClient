using System.Collections.Generic;
using System.Threading.Tasks;
using SierraCSharpRestClient.Models.Fund;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IFundsApiStronglyTypedAsync

    {
        Task<Funds> Get(string login, string code = null, string[] fields = null, string[] fundType = null);
    }
}