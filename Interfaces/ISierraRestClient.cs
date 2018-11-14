using RestSharp;

namespace SierraCSharpRestClient.Interfaces
{

    /// <summary>
    /// Gets the SierraRestClient in two different flavours
    /// public SierraRestClient(string baseUrl, string accessToken) will return a rest client
    /// with only one request to the server - but your token will only last 60 minutes
    /// public SierraRestClient(string baseUrl, string clientKey, string clientSecret) will always return
    /// a valid client as it makes a request for a new client as part of the instantiation. 
    /// </summary>
    public interface ISierraRestClient
    {

        /// <summary>
        /// Will return the Client
        /// </summary>
        RestClient Client { get; }


        /// <summary>
        /// The first argument is the branch, the second is route of the operation (e.g /patrons/checkouts/{checkoutId}/renewal)
        /// and the third is the method, which is an ENUM from  RestSharp 
        /// Branch.patrons, "/find", Method.GET
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        RestRequest Execute(Branch branch, string resource, Method method);


        /// <summary>
        /// Retrieves an access token which you can then use with the
        ///  public SierraRestClient(string baseUrl, string accessToken) constructor - this results in one request
        /// The access token is only valid for 60 minutes 
        /// </summary>
        string AccessToken { get; }
    }
}