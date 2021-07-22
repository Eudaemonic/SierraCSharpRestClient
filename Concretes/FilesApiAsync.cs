using RestSharp;
using SierraCSharpRestClient.Interfaces;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Concretes
{
    public class FilesApiAsync : IFilesApiAsync
    {


        private readonly ISierraRestClient _sierraRestClient;

        public FilesApiAsync(ISierraRestClient sierraRestClient)
        {
            _sierraRestClient = sierraRestClient;
        }


        public async Task<string> Upload(string loadTable, byte[] file)
        {
            var request = _sierraRestClient.Execute(Branch.bibs, "/marc/files/upload", Method.POST);

            request.AddFileBytes("marcFile", file, $"marc-{loadTable}-", "");

            request.AddQueryParameter("loadTable", loadTable);

            var result = await _sierraRestClient.Client.ExecuteTaskAsync(request);

            if (result.IsSuccessful)
            {
                return result.Content;
            }

            return result.ErrorMessage;


        }
    }
}
