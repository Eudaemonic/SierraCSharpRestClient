using SierraCSharpRestClient.Models.Fund;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IFundsApiStronglyTypedAsync
    {
        Task<Funds> Get(string login, string code = null, string[] fields = null, string[] fundType = null);
    }
}