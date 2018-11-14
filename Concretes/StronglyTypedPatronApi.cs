using System.Linq;
using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;

namespace SierraCSharpRestClient.Concretes
{
    public class StronglyTypedPatronApi : IStronglyTypedPatronApi
    {
        private readonly PatronApi _patron;

        private readonly string _defaultFields;


        public StronglyTypedPatronApi(ISierraRestClient sierraRestClient)
        {
            _patron = new PatronApi(sierraRestClient);
            _defaultFields = GetResponseFieldsAsString();
        }

        public bool CheckIfBarcodeExists(string barcode)
        {
            return _patron.CheckIfBarcodeExists(barcode);
        }

        public string Create(Patron patron)
        {
            var json = JsonConvert.SerializeObject(patron);

            return _patron.Create(json);
        }

        /// <summary>
        /// Returns a Patron object from record Id.
        /// The default fields are taken from the public properties of the class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Patron Get(int id, string fields = null)
        {
            var result = new Patron();

            if (fields == null) fields = _defaultFields;

            return JsonConvert.DeserializeObject<Patron>(_patron.Get(id, fields)); ;
        }

        public void Update(Patron patron, int? id)
        {
            var json = JsonConvert.SerializeObject(patron);

            _patron.Update(json, id);
        }

        /// <summary>
        ///  Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PatronMetaData GetPatronMetaData(PatronCode code)
        {
            return _patron.GetPatronMetaData(code);
        }


        /// <summary>
        ///     Method accepts the varField tag and returns a single record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Patron GetPatronByVarField(char varFieldTag, string query)
        {
            return JsonConvert.DeserializeObject<Patron>(_patron.GetPatronByVarField(varFieldTag, query));
        }

        #region helpers

        private string GetResponseFieldsAsString()
        {
            var names = typeof(Patron).GetProperties().Select(p => p.Name).ToArray();

            return string.Join(",", names);
        }

        #endregion
    }
}