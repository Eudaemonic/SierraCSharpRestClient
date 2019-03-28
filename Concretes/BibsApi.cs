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
    public class BibsApi : IBibsApi
    {
        #region Initialiser


        private readonly ISierraRestClient _sierraRestClient;

        public BibsApi(ISierraRestClient sierraRestClient)
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
        /// <returns></returns>
        public string Search(Indexes index, string[] fields, string query)
        {
            if (fields.Length == 0)
            {
                fields = new[] {"title", "author", "publishYear", "available"};
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/Search", Method.GET);

            request.AddQueryParameter("index", index.ToString());
            request.AddQueryParameter("fields", string.Join(",", fields));
            request.AddQueryParameter("text", query.ToLower());
            // execute the request
            return _sierraRestClient.Client.Execute(request).Content;

        }



        public string GetById( int id, string[] fields = null)
        {
            if (fields == null || fields.Length == 0)
            {
                fields = new[] { "title", "author", "publishYear", "available", "varFields" };
            }
            var request = _sierraRestClient.Execute(Branch.bibs, "/" + id, Method.GET);

            request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request
            return _sierraRestClient.Client.Execute(request).Content;

        }


        #endregion

        #region Helpers



        #endregion
    }
}
