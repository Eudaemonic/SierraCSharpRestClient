using System;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;

namespace SierraCSharpRestClient.Concretes
{
    public class InvoicesApiAsync : IInvoicesApiAsync
    {
        #region Initialiser

        private readonly ISierraRestClient _sierraRestClient;

        public InvoicesApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }

        #endregion

        #region Methods


        public async Task<string> Get(string login, DateTime? startDate, DateTime?  endDate, InvoiceDateQuery dateToQuery, string status = "", string[] Ids = null, string[] invNum = null, string[] fields = null, string[] locations = null, int limit = 50, 
            int offset = 0)
        { 
            var request = _sierraRestClient.Execute(Branch.invoices, "/", Method.GET);

            if (startDate.HasValue && endDate.HasValue)
            {
                request.AddQueryParameter(dateToQuery.ToString(), FormatSierraDateRange(startDate.Value, endDate.Value));
              
            }
            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (!string.IsNullOrWhiteSpace(status)) request.AddQueryParameter("statusCode", status);

            if(Ids != null) request.AddQueryParameter("id", string.Join(",", Ids));

            if(invNum != null) request.AddQueryParameter("invNum", string.Join(",", invNum));

            request.AddQueryParameter("limit", limit.ToString());

            request.AddQueryParameter("offset", offset.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }

        public async Task<string> GetByInvoiceNumber(string login, string invNum, string[] fields = null)
        {
            var request = _sierraRestClient.Execute(Branch.invoices, "/", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (invNum != null) request.AddQueryParameter("invNum", string.Join(",", invNum));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;

        }

        public async Task<string> Get(string login, string id, string[] fields = null)
        {

            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;


        }

        public async Task<string>LineItems(string id, string login,  string[] fields = null)
        {
            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}/lineItems", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            if (result.IsSuccessful)
            {
                return result.Content;
            }

            throw new NullReferenceException(result.ErrorMessage);

        }

        #endregion

        #region Helpers

       string FormatSierraDateRange(DateTime startDate, DateTime endDate)
        {

            var sb = new StringBuilder();
            if(endDate != null)
            {
                sb.Append("[");
                sb.Append(startDate.ToString("yyyy-MM-dd"));
                sb.Append(",");
                sb.Append(endDate.ToString("yyyy-MM-dd"));
                sb.Append("]");
                return sb.ToString();
            }
           return startDate.ToString("s");
        }

        #endregion

    }
}