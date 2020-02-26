namespace SierraCSharpRestClient.Interfaces
{
    public interface IItemsApi
    {
        string Get(string [] itemIds = null, string status = "", string[] bibIds = null, string[] fields = null, string[] locations = null,  int limit = 50, int offset = 0);
    }
}