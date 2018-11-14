using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SierraCSharpRestClient.Concretes
{
    internal class SierraRestRequest
    {
        private readonly string _accessToken;

        public SierraRestRequest(string accessToken)
        {
            _accessToken = accessToken;
        }


        public RestRequest Execute(string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            request.AddHeader("Authorization", _accessToken);


            return request;
        }


    }
}
