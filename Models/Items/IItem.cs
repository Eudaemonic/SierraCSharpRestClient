using System;
using System.Collections.Generic;

namespace SierraCSharpRestClient.Models.Items
{
    public interface IItem
    {
        string id { get; set; }
        DateTime updatedDate { get; set; }
        DateTime createdDate { get; set; }
        bool deleted { get; set; }
        List<string> bibIds { get; set; }
        Location location { get; set; }
        Status status { get; set; }
        string barcode { get; set; }
        string callNumber { get; set; }
    }
}