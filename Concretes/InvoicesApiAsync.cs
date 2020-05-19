using System;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
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

        public async Task<string> Get(string login, DateTime startDate, DateTime endDate, string status = "", string[] Ids = null, string[] fields = null, string[] locations = null, int limit = 50, 
            int offset = 0)
        { 
            var request = _sierraRestClient.Execute(Branch.invoices, "/", Method.GET);

            request.AddQueryParameter("createdDate", FormatSierraDateRange(startDate, endDate));
            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            if (!string.IsNullOrWhiteSpace(status)) request.AddQueryParameter("status", status);

            if(Ids != null) request.AddQueryParameter("id", string.Join(",", Ids));

            request.AddQueryParameter("limit", limit.ToString());

            request.AddQueryParameter("offset", offset.ToString());

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }

        public async Task<string> Get(string id, string[] fields = null)
        {

            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}", Method.GET);

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));

            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;


        }

        public async Task<string>LineItems(string id, string login,  string[] fields = null)
        {
            var request = _sierraRestClient.Execute(Branch.invoices, $"/{id}/lineitems", Method.GET);

            request.AddQueryParameter("login", login.Trim());

            if (fields != null) request.AddQueryParameter("fields", string.Join(",", fields));
            // execute the request
            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            return result.Content;
        }

        #endregion

        #region Helpers

       string FormatSierraDateRange(DateTime startDate, DateTime endDate)
        {
            var result = "";
            var sb = new StringBuilder();
            if(endDate != null)
            {
                sb.Append("[");
                sb.Append(startDate.ToString("s"));
                sb.Append(",");
                sb.Append(endDate.ToString("s"));
                sb.Append("]");
                return sb.ToString();
            }
           return startDate.ToString("s");
        }

        #endregion

    }
}