using System.Threading.Tasks;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IFilesApiAsync
    {
        Task<string> Upload(string loadTable, byte[] file);
    }
}