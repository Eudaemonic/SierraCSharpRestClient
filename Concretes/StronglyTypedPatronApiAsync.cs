using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.CheckoutHistory;
using SierraCSharpRestClient.Models.FinesSet;
using SierraCSharpRestClient.Models.PatronSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class StronglyTypedPatronApiAsync : IStronglyTypedPatronApiAsync
    {
        private readonly IPatronApiAsync _patron;


        public StronglyTypedPatronApiAsync(ISierraRestClient sierraRestClient)
        {
            _patron = new PatronApiAsync(sierraRestClient);
    
        }

        public async Task<BaseEnumerator> Query(string json,  int offset, int limit)
        {
            return JsonConvert.DeserializeObject<BaseEnumerator>(await _patron.Query(json, offset, limit));
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
        public async Task<CheckOutsWithItem> GetCheckoutsWithItem(int id, string fields, string expand)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOutsWithItem>(await _patron.GetCheckouts(id, null, "item"));
        }
        public async Task<CheckOut> GetCheckout(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOut>(await _patron.GetCheckouts(id, fields));
        }

        public async Task<CheckOutWithItem> GetCheckout(int id, string fields, string expand)
        {
            if (fields == null) fields = GetCheckOutFields();

            return JsonConvert.DeserializeObject<CheckOutWithItem>(await _patron.GetCheckouts(id, null,"item"));
        }


        public  async Task<CheckOut> Renew(int id, string fields)
        {
            if (fields == null) fields = GetCheckOutFields();
            
            return JsonConvert.DeserializeObject<CheckOut>(await _patron.Renew(id, fields));
        }



        #region Fines


        public async Task<bool> Charge(int recordId, int amount, string reason, string location)
        {
            return await _patron.Charge(recordId, amount, reason, location);
        }


        public async Task<Fines> Fines(int recordId)
        {
                return JsonConvert.DeserializeObject<Fines>(await _patron.Fines(recordId));
        }


        public async Task<bool> Payment(int recordId, Payments payments)
        {
            return await _patron.Payment(recordId, payments);
        }

        #region Holds

        public async Task<Holds> Holds(int recordId)
        {
            return JsonConvert.DeserializeObject<Holds>(await _patron.Holds(recordId));
        }


        public async Task<BaseResponse> PostHoldRequest(int id, Reservation body)
        {

            return JsonConvert.DeserializeObject<BaseResponse>(
                await _patron.PostHoldRequest(id, JsonConvert.SerializeObject(body)));
        }



        public async Task<BaseResponse> DeleteHold (int id)
        {

            return JsonConvert.DeserializeObject<BaseResponse>(
                await _patron.DeleteHold(id));
        }


        public async Task<BaseGenericEnumerator<CheckoutHistory>> CheckoutHistory(int id, int offset = 0, int limit = 20, string[] fields = null,
            string sortField = "outDate", string sortOrder = "asc")
        {

            return JsonConvert.DeserializeObject<BaseGenericEnumerator<CheckoutHistory>>(
                await _patron.CheckoutHistory(id, offset, limit, fields, sortField, sortOrder));
        }

        public async Task<BaseResponse> CheckoutHistoryActivation(int id, ReadingHistoryActivationModel body)
        {

            return JsonConvert.DeserializeObject<BaseResponse>(
                await _patron.CheckoutHistoryActivation(id, JsonConvert.SerializeObject(body)));
        }

        public async Task<IRestResponse> CheckoutHistoryActivationChange(int id, ReadingHistoryActivationModel body)
        {
            return await _patron.CheckoutHistoryActivationChange(id, JsonConvert.SerializeObject(body));
        }

        public async Task<ReadingHistoryActivationModel> CheckoutHistoryActivationStatus(int id)
        {

            return JsonConvert.DeserializeObject<ReadingHistoryActivationModel>(
                await _patron.CheckoutHistoryActivationStatus(id));
        }



        #endregion







        #endregion

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