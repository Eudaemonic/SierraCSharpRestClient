﻿using System.Threading.Tasks;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.PatronSubset;

namespace SierraCSharpRestClient.Interfaces
{
    public interface IStronglyTypedPatronApiAsync
    {
        /// <summary>
        /// Simple method to replicate the existing barcode function in Sierra.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        Task<bool> CheckIfBarcodeExists(string barcode);

        /// <summary>
        /// Creates a new patron and returns the Id. 
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        Task<string> Create(Patron patron);

        /// <summary>
        /// Returns a Patron object from record Id.
        /// The default fields are taken from the public properties of the class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<Patron> Get(int id, string fields = null);

        Task Update(Patron patron, int? id);

        /// <summary>
        ///  Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<PatronMetaData> GetPatronMetaData(PatronCode code);

        /// <summary>
        ///     Method accepts the varField tag and returns a single record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<Patron> GetPatronByVarField(char varFieldTag, string query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<CheckOuts> GetCheckouts(int id, string fields = null);
    }
}