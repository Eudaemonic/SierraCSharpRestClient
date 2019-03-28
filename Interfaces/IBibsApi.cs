using SierraCSharpRestClient.Enums;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IBibsApi
    {
        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="fields"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        string Search(Indexes index, string[] fields, string query);

        string GetById(int id, string[] fields = null);
    }
}