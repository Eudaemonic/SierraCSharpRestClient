namespace SierraCSharpRestClient.Enums
{
    public enum InvoiceParameters
    {
        id,
        accountingUnit,
        invDate,
        invNum,
        taxType,
        vendors,
        paidDate,
        forCurrency,
        invTotal,
        useTax,
        lineItems,
        statusCode
     
    }

    public enum InvoiceDateQuery
    {
        createdDate,
        invoiceDate
    }
}
