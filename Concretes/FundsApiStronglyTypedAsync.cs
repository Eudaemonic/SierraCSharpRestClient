﻿using RestSharp;
using SierraCSharpRestClient.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SierraCSharpRestClient.Models.Fund;

namespace SierraCSharpRestClient.Concretes
{
    public class FundsApiStronglyTypedAsync : IFundsApiStronglyTypedAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public FundsApiStronglyTypedAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods

       

        public async Task<Funds> Get(string login, string code = null, string[] fields = null, string[] fundType = null)
        {

            var request = _sierraRestClient.Execute(Branch.funds, "/", Method.GET);

            
            request.AddQueryParameter("login", login.Trim());

            
            if (code != null) request.AddQueryParameter("code", code.Trim());
            

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (fundType != null) request.AddQueryParameter("fundType", string.Join(",", fundType));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return JsonConvert.DeserializeObject<Funds>(result.Content);


        }



        #endregion

}



  
}