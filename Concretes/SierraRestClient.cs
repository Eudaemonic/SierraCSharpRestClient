using System;
using System.Text;
using RestSharp;
using SierraCSharpRestClient.Interfaces;

namespace SierraCSharpRestClient.Concretes
{

    /// <summary>
    /// Gets the SierraRestClient
    /// </summary>
    public sealed class SierraRestClient : ISierraRestClient
    {
        private readonly string _baseUrl;
        private readonly string _clientKey;
        private readonly string _clientSecret;
        private readonly string _accessToken;

        /// <summary>
        /// The access token must not have Bearer before the token
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="accessToken"></param>
        public SierraRestClient(string baseUrl, string accessToken)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;

        }

        public SierraRestClient(string baseUrl, string clientKey, string clientSecret)
        {
            _baseUrl = baseUrl;
            _clientKey = clientKey;
            _clientSecret = clientSecret;
            _accessToken = AccessToken;

        }



        public RestClient Client
        {
            get => new RestClient(_baseUrl);
            set => throw new NotImplementedException();
        }

       
        public string AccessToken
        {
            get
            {
                var stringToEncode = Encoding.UTF8.GetBytes(_clientKey + ":" + _clientSecret);

                var headerValue = "Basic " + Convert.ToBase64String(stringToEncode);

                var request = new RestRequest("token", Method.POST);

                request.AddHeader("Authorization", headerValue);

                var resultToken = Client.Execute<AuthToken>(request).Data;

                return  resultToken.access_token;

            }
            set => throw new NotImplementedException();
        }

        public RestRequest Execute(Branch branch, string resource, Method method)
        {
       
            var request = new RestRequest(branch + resource, method);

            request.AddHeader("Authorization", "bearer " + _accessToken);

            return request;
        }

    }

 
    



}