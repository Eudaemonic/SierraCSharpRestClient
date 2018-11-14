using System.Linq;
using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;


namespace SierraCSharpRestClient.Concretes
{
    public class StronglyTypedPatronsApi : IStronglyTypedPatronsApi
    {
        private readonly PatronsApi _patrons;

        public StronglyTypedPatronsApi(ISierraRestClient sierraRestClient)
        {
            _patrons =  new PatronsApi(sierraRestClient);
      
        }

        public bool CheckIfBarcodeExists(string barcode)
        {
            return _patrons.CheckIfBarcodeExists(barcode);
        }

        public string Create(Patron patron)
        {
            var json = JsonConvert.SerializeObject(patron);

            return _patrons.Create(json);

        }

        public Patron Get(int id, string fields)
        {
            var result = new Patron();
       
                var patrons = JsonConvert.DeserializeObject<Models.Patrons>(_patrons.Get(id, fields));

                if (patrons.total > 0)
                {
                    result = patrons.entries.FirstOrDefault();
                }


            return result;
        }

        public void Update(Patron patron, int id)
        {
            var json = JsonConvert.SerializeObject(patron);

            _patrons.Update(json, id);
    
        }

        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PatronMetaData GetPatronMetaData(PatronCode code)
        {
            return _patrons.GetPatronMetaData(code);
        }


        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// 
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Patron GetPatronByVarField(char varFieldTag, string query)
        {
            return JsonConvert.DeserializeObject<Models.Patron>( _patrons.GetPatronByVarField(varFieldTag, query));

        }


    }
}
