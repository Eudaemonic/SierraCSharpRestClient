using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IStronglyTypedPatronsApi
    {
        bool CheckIfBarcodeExists(string barcode);
        string Create(Patron patron);
        Patron Get(int id, string fields = null);
        void Update(Patron patron, int id);

        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code">Type of PatronCode</param>
        /// <returns></returns>
        PatronMetaData GetPatronMetaData(PatronCode code);

        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// 
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Patron GetPatronByVarField(char varFieldTag, string query);
    }
}