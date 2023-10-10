using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IFundsApiAsync

    {
        Task<string> Get(string login, string code = null, string[] fields = null, string[] fundType = null);
    }
}