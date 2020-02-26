using Newtonsoft.Json;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using System;
using System.Linq;
using System.Net;

namespace SierraCSharpRestClient.Concretes
{
    public class PatronApi : IPatronApi
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public PatronApi(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }

        #endregion

        #region Methods

        /// <inheritdoc />
        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public virtual bool CheckIfBarcodeExists(string barcode)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", "b");
            request.AddQueryParameter("varFieldContent", barcode.Trim());
            request.AddQueryParameter("fields", "id");

            var result = _sierraRestClient.Client.Execute(request);

            return result.StatusCode != HttpStatusCode.NotFound;
        }

        public string Delete(int recordId)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}", Method.DELETE);

            return _sierraRestClient.Client.Execute(request).Content;
        }


        /// <summary>
        /// Creates a new patron from a patron object
        /// Returns ID on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public string Create(string patron)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, null, Method.POST);

            request.AddParameter("text/json", patron, ParameterType.RequestBody);

            var result = _sierraRestClient.Client.Execute(request);

            return  result.StatusCode == HttpStatusCode.OK ? GetIdFromLink(result.Content) : string.Empty;
        }

        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public string Get(int id, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons,@"/" + id, Method.GET);
          
            request.AddQueryParameter("fields", fields);
            // execute the request
            var x = _sierraRestClient.Client.Execute(request);

            return x.Content;
        }

       




        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <param name="id"></param>
        /// <returns>
        /// </returns>
        public void Update(string patron, int? id)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, "/" + id.ToString(), Method.PUT);
    
            request.AddParameter("text/json", patron, ParameterType.RequestBody);

           _sierraRestClient.Client.Execute(request);
        }

        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public string ListByIds(string[] ids, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, null, Method.GET);

            request.AddQueryParameter("id", string.Join(",", ids));

            request.AddQueryParameter("fields", fields);
            // execute the request

            return _sierraRestClient.Client.Execute(request).Content;
        }






        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PatronMetaData GetPatronMetaData(PatronCode code)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/metadata", Method.GET);

            request.AddQueryParameter("fields", code.ToString());

            var response = _sierraRestClient.Client.Execute<PatronMetaData>(request);

            var result = JsonConvert.DeserializeObject<PatronMetaData>(response.Content.Substring(1, response.Content.Length - 2));

            return result;
        }


        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// Returns all fines data for a specified patron record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public string GetPatronByVarField(char varFieldTag, string query)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", varFieldTag.ToString());
            request.AddQueryParameter("varFieldContent", query);
            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse response = _sierraRestClient.Client.Execute(request);


            return response.Content;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public string GetCheckouts( int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts", Method.GET);

            request.AddQueryParameter("fields", fields);

            IRestResponse response = _sierraRestClient.Client.Execute(request);

            return response.Content;
        }

        #endregion



        #region StringHelpers

        string GetIdFromLink(string link)
       {
           return link.Contains('/') ? link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1, 7) : string.Empty;
       }

        #endregion
    }
}
