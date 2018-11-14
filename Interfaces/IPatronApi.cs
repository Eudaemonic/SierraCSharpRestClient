using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IPatronApi
    {
        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        bool CheckIfBarcodeExists(string barcode);

        /// <summary>
        /// Creates a new patron from a patron object
        /// Redturns ID on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        string Create(string patron);

        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        string Get(int id, string fields);


        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <param name="id"></param>
        /// <returns>
        /// </returns>
        void Update(string patron, int? id);

        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        string ListByIds(string[] ids, string fields);



        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        PatronMetaData GetPatronMetaData(PatronCode code);


        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// 
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        string GetPatronByVarField(char varFieldTag, string query);
    }
}