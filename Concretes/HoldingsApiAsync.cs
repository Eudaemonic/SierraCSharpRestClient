using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;

namespace SierraCSharpRestClient.Concretes
{
    public class HoldingsApiAsync : IHoldingsApiAsync
    {
        private readonly ISierraRestClient _sierraRestClient;

        public HoldingsApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }


        /// <summary>
        /// Returns a full patron object with all var fields. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="suppressed"></param>
        /// <param name="bibIds"></param>
        /// <returns></returns>
        public async Task<string> Get(string[] bibIds = null, string[] id = null, string[] fields = null,
            int limit = 20, int offset = 0, string suppressed = null)
        {
            if (fields is null)
            {
                fields = new[] { "varFields" };
            }

            var request = _sierraRestClient.Execute(Branch.holdings, "/", Method.GET);


            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));
            if (bibIds != null) request.AddQueryParameter("bibIds", string.Join(",", bibIds));
            if (id != null) request.AddQueryParameter("id", string.Join(",", id));
            request.AddQueryParameter("limit", limit.ToString());
            if (suppressed != null) request.AddQueryParameter("suppressed", suppressed.ToLower());
            request.AddQueryParameter("offset", offset.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;

        }
    }
}
