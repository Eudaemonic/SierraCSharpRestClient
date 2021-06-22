using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.FinesSet;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IPatronApiAsync
    {
        Task<string> Get(int id, string fields);


        Task<string> Query(string json, int offset = 0, int limit = 1);

        /// <inheritdoc />
        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        Task<bool> CheckIfBarcodeExists(string barcode);

        /// <summary>
        /// Creates a new patron from a patron object
        /// Returns ID on creation
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        Task<string> Create(string patron);

        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <param name="id"></param>
        /// <returns>
        /// </returns>
        Task Update(string patron, int? id);

        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<string> ListByIds(string[] ids, string fields);

        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<PatronMetaData> GetPatronMetaData(PatronCode code);

        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// Returns all fines data for a specified patron record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<string> GetPatronByVarField(char varFieldTag, string query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<string> GetCheckouts(int id, string fields);

        /// <summary>
        /// Get a list of fines for patron.
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        Task<string> Fines(int recordId);


        /// <summary>
        /// POST /v6/patrons/{id}/holds/requests
        /// </summary>
        Task<string> PostHoldRequest(int id, string body);


        Task<string> GetCheckouts(int id, string fields, string expand);

        Task<string> Renew(int id, string fields);


        Task<string> Holds(int patronId);

        Task<bool> Payment(int recordId, Payments payments);

        Task<bool> Charge(int recordId, int amount, string reason, string location);


        Task<string> DeleteHold(int id);
    }
}