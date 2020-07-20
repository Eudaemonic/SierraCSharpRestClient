using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Target
    {
        public Record record { get; set; }
        public int id { get; set; }

    }

    public class Expr
    {
        public string op { get; set; }
        public List<string> operands { get; set; }

    }
}
