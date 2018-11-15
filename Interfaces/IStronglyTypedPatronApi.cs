using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.PatronSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IStronglyTypedPatronApi
    {


        /// <param name="barcode"></param>
        /// <returns></returns>
        bool CheckIfBarcodeExists(string barcode);

        /// <summary>
        /// Returns the id (as string) of a patron on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        string Create(Patron patron);

        /// <summary>
        /// Returns a Patron object with only the fields specified
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Patron Get(int id, string fields = null);



        void Update(Patron patron, int? id);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        CheckOuts GetCheckouts(int id, string fields = null);
    }
}