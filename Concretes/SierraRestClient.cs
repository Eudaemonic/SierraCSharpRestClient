using RestSharp;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using System;
using System.Diagnostics;
using System.Text;

namespace SierraCSharpRestClient.Concretes
{

    /// <summary>
    /// Gets the SierraRestClient in two different flavours
    /// public SierraRestClient(string baseUrl, string accessToken) will return a rest client
    /// with only one request to the server - but your token will only last 60 minutes
    /// public SierraRestClient(string baseUrl, string clientKey, string clientSecret) will always return
    /// a valid client as it makes a request for a new client as part of the instantiation. 
    /// </summary>
    public sealed class SierraRestClient : ISierraRestClient
    {
        private readonly string _baseUrl;
        private readonly string _clientKey;
        private readonly string _clientSecret;
        private readonly string _accessToken;

        /// <summary>
        /// The access token must not have Bearer before the token
        /// base url example = "https://{your library}/iii/sierra-api/v5/";
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="accessToken"></param>
        public SierraRestClient(string baseUrl, string accessToken)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;

        }

        /// <summary>
        /// To retrieve an Access Token
        /// base url example = "https://{your library}/iii/sierra-api/v5/";
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="clientKey"></param>
        /// <param name="clientSecret"></param>
        public SierraRestClient(string baseUrl, string clientKey, string clientSecret)
        {
            _baseUrl = baseUrl;
            _clientKey = clientKey;
            _clientSecret = clientSecret;
            _accessToken = AccessToken;

        }


        /// <summary>
        /// Our dependency on RESTSharp
        /// </summary>
        public RestClient Client
        {
            get => new RestClient(_baseUrl);
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves an access token which you can then use with the
        ///  public SierraRestClient(string baseUrl, string accessToken) constructor - this results in one request
        /// The access token is only valid for 60 minutes 
        /// </summary>
        public string AccessToken
        {
            get
            {
                try
                {
                    var stringToEncode = Encoding.UTF8.GetBytes(_clientKey + ":" + _clientSecret);

                    var headerValue = "Basic " + Convert.ToBase64String(stringToEncode);

                    var request = new RestRequest("token", Method.POST);

                    request.AddHeader("Authorization", headerValue);

                    var resultToken = Client.Execute<AuthToken>(request);

                    return resultToken.Data.access_token;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }

                return null;

            }
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// We are using RestSharp's method he to make the rest 
        /// /// Branch.patrons, "/find", Method.GET
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public RestRequest Execute(Branch branch, string resource, Method method)
        {
            if (!resource.StartsWith("/"))
                resource = "/" + resource;
       
            var request = new RestRequest(branch + resource, method);

            request.AddHeader("Authorization", "bearer " + _accessToken);

            return request;
        }

    }

 
    



}