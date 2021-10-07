using System.Collections.Generic;

namespace SierraCSharpRestClient.Helpers
{
    public class PatronVarFields
    {
        public string GetVarFieldName(string key)
        {


            var dict = new Dictionary<string, string>
            {
                { "n", "name" },
                { "b", "barcode" },
                { "m", "message" },
                { "u", "university id" },
                { "z", "email" },
                { "43", "expiry date" },
                { "i", "institution" },
                { "d", "department" },
                { "j", "subject" },
                { "x", "note" }
            };

            if (dict.ContainsKey(key.Trim()))
            {
                return dict[key];
            }

            return key;


        }

        

    }
}
