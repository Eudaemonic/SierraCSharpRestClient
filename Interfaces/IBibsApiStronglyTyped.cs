using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IBibsApiStronglyTyped
    {
        BibsModel GetById(int id, string[] fields = null);
    }
}