using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.FinesSet;
using SierraCSharpRestClient.Models.PatronSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class PatronApiAsync : IPatronApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public PatronApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;

        }

        #endregion

        #region Methods


        public async Task<string> Get(int id, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, @"/" + id, Method.GET);

            request.AddQueryParameter("fields", fields);
            // execute the request
            var x = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return x.Content;
        }


        public async Task<string> Query(string json, int offset, int limit)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/query", Method.POST);

            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            // execute the request
            var x = await _sierraRestClient.Client.ExecutePostTaskAsync(request);

            return x.Content;
        }



        /// <inheritdoc />
        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfBarcodeExists(string barcode)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", "b");
            request.AddQueryParameter("varFieldContent", barcode.Trim());
            request.AddQueryParameter("fields", "id");

            var result = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return result.StatusCode != HttpStatusCode.NotFound;
        }


        /// <summary>
        /// Creates a new patron from a patron object
        /// Returns ID on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public async Task<string> Create(string patron)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, null, Method.POST);

            request.AddParameter("text/json", patron, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecutePostTaskAsync(request);

            return result.StatusCode == HttpStatusCode.OK ? GetIdFromLink(result.Content) : string.Empty;
        }





        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <param name="id"></param>
        /// <returns>
        /// </returns>
        public async Task Update(string patron, int? id)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, "/" + id.ToString(), Method.PUT);

            request.AddParameter("text/json", patron, ParameterType.RequestBody);

            await _sierraRestClient.Client.ExecuteTaskAsync(request);
        }

        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> ListByIds(string[] ids, string fields)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "", Method.GET);

            request.AddQueryParameter("id", string.Join(",", ids));

            request.AddQueryParameter("fields", fields);
            // execute the request

            var result = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return result.Content;
        }




        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PatronMetaData> GetPatronMetaData(PatronCode code)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/metadata", Method.GET);

            request.AddQueryParameter("fields", code.ToString());

            var response = await _sierraRestClient.Client.ExecuteGetTaskAsync<PatronMetaData>(request);

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
        public async Task<string> GetPatronByVarField(char varFieldTag, string query)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, "/find", Method.GET);

            request.AddQueryParameter("varFieldTag", varFieldTag.ToString());
            request.AddQueryParameter("varFieldContent", query);
            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse response = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);


            return response.Content;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> GetCheckouts(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts", Method.GET);

            request.AddQueryParameter("fields", fields);

            IRestResponse response = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return response.Content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the patron record ID</param>
        /// <param name="fields">	a comma-delimited list of fields to retrieve</param>
        /// <param name="expand">a comma-delimited list of fields with urls to expand</param>
        /// <returns></returns>
        public async Task<string> GetCheckouts(int id, string fields, string expand)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts", Method.GET);

            if (!string.IsNullOrWhiteSpace(fields))
            {
                request.AddQueryParameter("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(expand))
            {
                request.AddQueryParameter("expand", expand);
            }
            
            IRestResponse response = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return response.Content;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> GetCheckout(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/checkouts/{id}", Method.GET);

            if (!string.IsNullOrWhiteSpace(fields))
            {
                request.AddQueryParameter("fields", fields);
            }

            IRestResponse response = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return response.Content;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<string> Renew(int id, string fields)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/checkouts/{id}/renewal", Method.POST);

            if (!string.IsNullOrWhiteSpace(fields))
            {
                request.AddQueryParameter("fields", fields);
            }

            IRestResponse response = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return response.Content;
        }
        #endregion

        #region Fines

        public async Task<bool> Charge(int recordId, int amount, string reason, string location)
        {

            var values = new Dictionary<string, object>
            {
                { "amount", amount },
                { "reason", reason},
                { "location", location}
            };
            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines/charge", Method.POST);
            var body = JsonConvert.SerializeObject(values);
            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecutePostTaskAsync(request);

            return result.IsSuccessful;
        }


        public async Task<string> Fines(int recordId)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines", Method.GET);
            
            var result = await _sierraRestClient.Client.ExecuteGetTaskAsync(request);

            return result.Content;
        }



        public async Task<bool> Payment(int recordId, Payments payments)
        {

  
            var request = _sierraRestClient.Execute(Branch.patrons, $"/{recordId}/fines/payment", Method.PUT);
            var body = JsonConvert.SerializeObject(payments);
            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.IsSuccessful;
        }

        #region Holds

        public async Task<string> Holds(int patronId)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{patronId}/holds", Method.GET);


            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }


        public async Task<string> PostHoldRequest(int id, string body)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/holds/requests", Method.POST);

            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }


        public async Task<string> DeleteHold(int id)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/holds/{id}", Method.DELETE);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }    
        
        /// <summary>
        /// Returns a list of Checkout history
        /// </summary>
        /// <param name="id">Patron Id</param>
        /// <returns></returns>
        public async Task<string> CheckoutHistory(int id, int offset = 0, int limit = 20, string[] fields = null, string sortField = "outDate", string sortOrder = "asc")
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts/history", Method.GET);

            //Parameters
            if(fields != null)
            {
                request.AddQueryParameter("fields", string.Join(",", fields));
            }
            request.AddQueryParameter("offset", offset.ToString()); 
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("sortField",  sortField);
            request.AddQueryParameter("sortOrder", sortOrder);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }

        public Task<string> CheckoutHistoryActivation(int id, string body)
        {
            throw new NotImplementedException();
        }

        public async Task<IRestResponse> CheckoutHistoryActivationChange(int id, string body)
        {

            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts/history/activationStatus", Method.POST);

            request.AddParameter("text/json", body, ParameterType.RequestBody);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result;

        }

        public async Task<string> CheckoutHistoryActivationStatus(int id)
        {
            var request = _sierraRestClient.Execute(Branch.patrons, $"/{id}/checkouts/history/activationStatus", Method.GET);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }



        #endregion




            #endregion


            #region StringHelpers

            string GetIdFromLink(string link)
        {
            return link.Contains("/") ? link.Substring(link.LastIndexOf("/", StringComparison.Ordinal) + 1, 7) : string.Empty;
        }

        #endregion

    }
}