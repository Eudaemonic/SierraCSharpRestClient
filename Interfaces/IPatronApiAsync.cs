﻿using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IPatronApiAsync
    {
        Task<string> Get(int id, string fields);

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
    }
}