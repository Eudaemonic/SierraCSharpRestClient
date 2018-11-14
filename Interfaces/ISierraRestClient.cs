using RestSharp;

namespace SierraCSharpRestClient.Interfaces
{
    public interface ISierraRestClient
    {
        RestClient Client { get; }
        RestRequest Execute(Branch branch, string resource, Method method);
        string AccessToken { get; }
    }
}