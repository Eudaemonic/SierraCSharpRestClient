using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SierraCSharpRestClient.Models
{
    public class BaseJsonQuery
    {
        public Target target { get; set; }
        public Expr expr { get; set; }
    }

    public class Record
    {
        public string type { get; set; }

    }

    public class Field
    {
        public string tag { get; set; }

    }


    public class Target
    {
        public Record record { get; set; }

        [DefaultValue(0)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Field field { get; set; }

    }

    public class Expr
    {
        public string op { get; set; }
        public List<string> operands { get; set; }

    }
}
