using SierraCSharpRestClient.Enums;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Concretes
{
    public class BibsApiNoDependecy
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient Client = new HttpClient();
        private const string BaseUrl = @"https://catalogue.libraries.london.ac.uk:443/iii/sierra-api/v5/";
        private const string ClientKey = @"Bjh6k5oHovR41afl7zmLd+QpSTo5";
        private const string ClientSecret = @"londwc1e7hu";

        public async Task<string> Search(string token, Indexes index, string query, int limit = 5)
        {
            //Config
            var  fields = new[] { "title", "author", "publishYear" };
            var url = $"{BaseUrl}bibs/search?limit={limit}&fields={string.Join(",", fields)}&text={query}";

                var request = new HttpRequestMessage()
                { 
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                };
           
            request.Headers.Add("Authorization", "bearer " + token);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage httpResponseMessage = await Client.SendAsync(request);

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }


        public async Task<string> GetToken()
        {
            //Config
            var stringToEncode = Encoding.UTF8.GetBytes(ClientKey + ":" + ClientSecret);

            var headerValue = "Basic " + Convert.ToBase64String(stringToEncode);
  
            var url = $"{BaseUrl}token";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
            };

            request.Headers.Add("Authorization", headerValue); ;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage httpResponseMessage = await Client.SendAsync(request);

            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            var start = response.IndexOf(":") + 1;

            var frontRemoved = response.Remove(0, start);

            return frontRemoved.Remove(frontRemoved.IndexOf(',')).Replace('"', ' ').Trim();
        }

    }
}
