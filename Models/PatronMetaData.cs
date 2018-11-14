using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Models
{
    public class PatronMetaData
    {

        public string field { get; set; }
        public List<Value> values { get; set; }


        public class Value
        {
            public string code { get; set; }
            public string desc { get; set; }
        }




    }
}
