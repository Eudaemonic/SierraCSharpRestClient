using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class BibsApiAsync : IBibsApiAsync
    {
        #region Initialiser


        private readonly ISierraRestClient _sierraRestClient;

        public BibsApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="fields"></param>
        /// <param name="query"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="ids">a comma-delimited list of IDs of bibs to retrieve</param>
        /// <returns></returns>
        public async Task<string> Search(Indexes index, string query, string[] fields = null, int limit = 20, int offset = 0, string ids = null)
        {
            if (fields is null)
            {
                fields = new[] {"title", "author", "publishYear"};
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/search", Method.GET);

            if (index != Indexes.none)
            {
                request.AddQueryParameter("index", index.ToString());
            }

            if (!string.IsNullOrWhiteSpace(ids))
            {
                request.AddQueryParameter("id", ids);
            }
            request.AddQueryParameter("fields", string.Join(",", fields));
            request.AddQueryParameter("text", query.ToLower());
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("offset", offset.ToString());

            // execute the request
            var result =  await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;

        }

        public async Task<string> GetBibs(int id, string[] fields = null, string createdDate = null, string updatedDate = null,  int limit = 20, int offset = 0)
        {
            if (fields == null || fields.Length == 0)
            {
                fields = new[] { "title", "author", "publishYear", "available", "varFields" };
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/" + id, Method.GET);

            request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request

            var response = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return response.Content;

        }



        public async Task<string> GetById( int id, string[] fields = null)
        {
            if (fields == null || fields.Length == 0)
            {
                fields = new[] { "title", "author", "publishYear", "available", "varFields" };
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/" + id, Method.GET);

            request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request

            var response = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return response.Content;

        }



        public async Task<string> Query(string jsonQuery,  int limit = 20, int offset = 0)
        {
   
            var request = _sierraRestClient.Execute(Branch.bibs, "/query", Method.POST);

            request.AddParameter("json", jsonQuery, ParameterType.RequestBody);

            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;

        }
        public async Task<string> GetMarc(int id)
        {
   
            var request = _sierraRestClient.Execute(Branch.bibs, $"/{id}/marc", Method.GET);

            request.AddHeader("Accept", "application/marc-xml");
            
            // execute the request
            var result = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return result.Content;

        }



        #endregion

        #region Helpers



        #endregion
    }
}
