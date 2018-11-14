using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Models
{
    public class Patrons
    {
        public int total { get; set; }
        public List<Patron> entries { get; set; }

    }
}
