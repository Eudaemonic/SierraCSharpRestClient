using System;

namespace SierraCSharpRestClient.Interfaces
{
    public interface ICheckout
    {

         string id { get; set; }
         string patron { get; set; }
         string item { get; set; }
         DateTime dueDate { get; set; }
         int numberOfRenewals { get; set; }
         DateTime outDate { get; set; }
    }
}
