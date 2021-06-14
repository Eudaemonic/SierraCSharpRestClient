using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraCSharpRestClient.Models.Items
{
 


    public class ItemsSearchModel
    {
        public int total { get; set; }
        public int start { get; set; }
        public List<Item> entries { get; set; }
    }
}
