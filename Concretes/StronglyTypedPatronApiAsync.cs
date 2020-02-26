using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.PatronSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class StronglyTypedPatronApiAsync : IStronglyTypedPatronApiAsync
    {
        private readonly PatronApiAsync _patron;


        public StronglyTypedPatronApiAsync(ISierraRestClient sierraRestClient)
        {
            _patron = new PatronApiAsync(sierraRestClient);
    
        }

        /// <summary>
        /// Simple method to replicate the existing barcode function in Sierra.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfBarcodeExists(string barcode)
        {
            return await _patron.CheckIfBarcodeExists(barcode);
        }

        /// <summary>
        /// Creates a new patron and returns the Id. 
        /// </summary>
        /// <param name="patron"></param>
        /// <returns></returns>
        public async Task<string> Create(Patron patron)
        {
            var json = JsonConvert.SerializeObject(patron);

            return await _patron.Create(json);
        }

        /// <summary>
        /// Returns a Patron object from record Id.
        /// The default fields are taken from the public properties of the class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<Patron> Get(int id, string fields = null)
        {
            var result = new Patron();

            if (fields == null) fields = GetObjectFieldsAsString<Patron>();

            return JsonConvert.DeserializeObject<Patron>(await _patron.Get(id, fields)); ;
        }

        public async Task Update(Patron patron, int? id)
        {
            var json = JsonConvert.SerializeObject(patron);

           await _patron.Update(json, id);
        }

        /// <summary>
        ///  Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PatronMetaData> GetPatronMetaData(PatronCode code)
        {
            return await _patron.GetPatronMetaData(code);
        }


        /// <summary>
        ///     Method accepts the varField tag and returns a single record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<Patron> GetPatronByVarField(char varFieldTag, string query)
        {
            return JsonConvert.DeserializeObject<Patron>(await _patron.GetPatronByVarField(varFieldTag, query));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<CheckOuts> GetCheckouts(int id, string fields = null)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOuts>(await _patron.GetCheckouts(id, fields));
        }

        public async Task<CheckOut> GetCheckout(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOut>(await _patron.GetCheckout(id, fields));
        }


        public async Task<CheckOut> Renew(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOut>(await _patron.Renew(id, fields));
        }


        #region helpers

        private string GetObjectFieldsAsString<T>()
        {
            var names = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            return string.Join(",", names);

        }

        private string GetCheckOutFields()
        {
            return $"id,patron,item,dueDate,numberOfRenewals,outDate,recallDate,callNumber,barcode";
        }

        #endregion
    }
}